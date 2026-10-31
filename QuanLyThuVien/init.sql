SET QUOTED_IDENTIFIER ON;
GO
IF DB_ID('LibraryDb') IS NULL
    CREATE DATABASE LibraryDb COLLATE Vietnamese_100_CI_AS;
GO
USE LibraryDb;
GO

IF OBJECT_ID('dbo.Categories', 'U') IS NULL
CREATE TABLE dbo.Categories (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_Categories PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL CONSTRAINT UQ_Categories_Name UNIQUE,
    Description NVARCHAR(500) NULL
);
GO

IF OBJECT_ID('dbo.Authors', 'U') IS NULL
CREATE TABLE dbo.Authors (
    Id        INT IDENTITY(1,1) CONSTRAINT PK_Authors PRIMARY KEY,
    FullName  NVARCHAR(150) NOT NULL,
    BirthYear SMALLINT NULL,
    Biography NVARCHAR(1000) NULL
);
GO

IF OBJECT_ID('dbo.Publishers', 'U') IS NULL
CREATE TABLE dbo.Publishers (
    Id      INT IDENTITY(1,1) CONSTRAINT PK_Publishers PRIMARY KEY,
    Name    NVARCHAR(150) NOT NULL CONSTRAINT UQ_Publishers_Name UNIQUE,
    Address NVARCHAR(255) NULL,
    Phone   VARCHAR(20) NULL
);
GO

IF OBJECT_ID('dbo.Books', 'U') IS NULL
CREATE TABLE dbo.Books (
    Id              INT IDENTITY(1,1) CONSTRAINT PK_Books PRIMARY KEY,
    Isbn            VARCHAR(20) NULL,
    Title           NVARCHAR(255) NOT NULL,
    CategoryId      INT NOT NULL CONSTRAINT FK_Books_Categories REFERENCES dbo.Categories(Id),
    PublisherId     INT NULL CONSTRAINT FK_Books_Publishers REFERENCES dbo.Publishers(Id),
    PublishedYear   SMALLINT NULL,
    TotalCopies     INT NOT NULL CONSTRAINT DF_Books_TotalCopies DEFAULT 0,
    AvailableCopies INT NOT NULL CONSTRAINT DF_Books_AvailableCopies DEFAULT 0,
    CONSTRAINT CK_Books_Copies CHECK (AvailableCopies >= 0 AND AvailableCopies <= TotalCopies),
    INDEX UX_Books_Isbn UNIQUE (Isbn) WHERE Isbn IS NOT NULL
);
GO

IF OBJECT_ID('dbo.BookAuthors', 'U') IS NULL
CREATE TABLE dbo.BookAuthors (
    BookId   INT NOT NULL CONSTRAINT FK_BookAuthors_Books REFERENCES dbo.Books(Id) ON DELETE CASCADE,
    AuthorId INT NOT NULL CONSTRAINT FK_BookAuthors_Authors REFERENCES dbo.Authors(Id),
    CONSTRAINT PK_BookAuthors PRIMARY KEY (BookId, AuthorId)
);
GO

IF OBJECT_ID('dbo.Members', 'U') IS NULL
CREATE TABLE dbo.Members (
    Id         INT IDENTITY(1,1) CONSTRAINT PK_Members PRIMARY KEY,
    MemberCode VARCHAR(20) NOT NULL CONSTRAINT UQ_Members_MemberCode UNIQUE,
    FullName   NVARCHAR(150) NOT NULL,
    Phone      VARCHAR(20) NULL,
    Email      VARCHAR(150) NULL,
    Address    NVARCHAR(255) NULL,
    JoinedDate DATE NOT NULL,
    ExpiryDate DATE NOT NULL,
    IsActive   BIT NOT NULL CONSTRAINT DF_Members_IsActive DEFAULT 1,
    CONSTRAINT CK_Members_Dates CHECK (ExpiryDate >= JoinedDate)
);
GO

IF OBJECT_ID('dbo.Loans', 'U') IS NULL
CREATE TABLE dbo.Loans (
    Id       INT IDENTITY(1,1) CONSTRAINT PK_Loans PRIMARY KEY,
    MemberId INT NOT NULL CONSTRAINT FK_Loans_Members REFERENCES dbo.Members(Id),
    LoanDate DATE NOT NULL,
    DueDate  DATE NOT NULL,
    Status   VARCHAR(20) NOT NULL CONSTRAINT DF_Loans_Status DEFAULT 'Borrowing',
    CONSTRAINT CK_Loans_Dates CHECK (DueDate >= LoanDate),
    CONSTRAINT CK_Loans_Status CHECK (Status IN ('Borrowing', 'Returned'))
);
GO

IF OBJECT_ID('dbo.LoanItems', 'U') IS NULL
CREATE TABLE dbo.LoanItems (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_LoanItems PRIMARY KEY,
    LoanId       INT NOT NULL CONSTRAINT FK_LoanItems_Loans REFERENCES dbo.Loans(Id) ON DELETE CASCADE,
    BookId       INT NOT NULL CONSTRAINT FK_LoanItems_Books REFERENCES dbo.Books(Id),
    ReturnedDate DATE NULL,
    FineAmount   DECIMAL(18,2) NOT NULL CONSTRAINT DF_LoanItems_FineAmount DEFAULT 0,
    CONSTRAINT UQ_LoanItems_Loan_Book UNIQUE (LoanId, BookId),
    CONSTRAINT CK_LoanItems_FineAmount CHECK (FineAmount >= 0)
);
GO

-- Dữ liệu mẫu, chỉ nạp khi database chưa có dữ liệu
IF NOT EXISTS (SELECT 1 FROM dbo.Categories)
   AND NOT EXISTS (SELECT 1 FROM dbo.Books)
   AND NOT EXISTS (SELECT 1 FROM dbo.Members)
BEGIN
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;

    DECLARE @Today DATE = CAST(GETDATE() AS DATE);

    SET IDENTITY_INSERT dbo.Categories ON;
    INSERT INTO dbo.Categories (Id, Name, Description) VALUES
        (1, N'Văn học', N'Tiểu thuyết và truyện ngắn'),
        (2, N'Thiếu nhi', N'Sách dành cho thiếu nhi'),
        (3, N'Lịch sử', N'Sách lịch sử và nhân học'),
        (4, N'Công nghệ thông tin', N'Lập trình và phần mềm');
    SET IDENTITY_INSERT dbo.Categories OFF;

    SET IDENTITY_INSERT dbo.Authors ON;
    INSERT INTO dbo.Authors (Id, FullName, BirthYear, Biography) VALUES
        (1, N'Nam Cao', 1915, NULL),
        (2, N'Tô Hoài', 1920, NULL),
        (3, N'Nguyễn Nhật Ánh', 1955, NULL),
        (4, N'Vũ Trọng Phụng', 1912, NULL),
        (5, N'Robert C. Martin', 1952, NULL),
        (6, N'Yuval Noah Harari', 1976, NULL);
    SET IDENTITY_INSERT dbo.Authors OFF;

    SET IDENTITY_INSERT dbo.Publishers ON;
    INSERT INTO dbo.Publishers (Id, Name, Address, Phone) VALUES
        (1, N'NXB Kim Đồng', N'Hà Nội', NULL),
        (2, N'NXB Trẻ', N'TP. Hồ Chí Minh', NULL),
        (3, N'NXB Văn học', N'Hà Nội', NULL);
    SET IDENTITY_INSERT dbo.Publishers OFF;

    -- AvailableCopies đã trừ các cuốn chưa trả trong phiếu mượn mẫu bên dưới
    SET IDENTITY_INSERT dbo.Books ON;
    INSERT INTO dbo.Books (Id, Isbn, Title, CategoryId, PublisherId, PublishedYear, TotalCopies, AvailableCopies) VALUES
        (1, 'DEMO-0001', N'Chí Phèo', 1, 3, 1941, 3, 2),
        (2, 'DEMO-0002', N'Dế Mèn phiêu lưu ký', 2, 1, 1941, 5, 4),
        (3, 'DEMO-0003', N'Tôi thấy hoa vàng trên cỏ xanh', 1, 2, 2010, 4, 3),
        (4, 'DEMO-0004', N'Mắt biếc', 1, 2, 1990, 2, 2),
        (5, 'DEMO-0005', N'Số đỏ', 1, 3, 1938, 2, 2),
        (6, 'DEMO-0006', N'Clean Code', 4, NULL, 2008, 2, 2),
        (7, 'DEMO-0007', N'Sapiens: Lược sử loài người', 3, NULL, 2011, 3, 2),
        (8, NULL, N'Tuyển tập truyện ngắn (sách mẫu)', 1, NULL, NULL, 1, 1);
    SET IDENTITY_INSERT dbo.Books OFF;

    INSERT INTO dbo.BookAuthors (BookId, AuthorId) VALUES
        (1, 1), (2, 2), (3, 3), (4, 3), (5, 4), (6, 5), (7, 6), (8, 1), (8, 2);

    -- Độc giả 4 hết hạn thẻ, độc giả 5 bị khóa thẻ
    SET IDENTITY_INSERT dbo.Members ON;
    INSERT INTO dbo.Members (Id, MemberCode, FullName, Phone, Email, Address, JoinedDate, ExpiryDate, IsActive) VALUES
        (1, 'DG0001', N'Nguyễn Văn An', '0900000001', 'an@example.com', N'Hà Nội', DATEADD(MONTH, -6, @Today), DATEADD(MONTH, 6, @Today), 1),
        (2, 'DG0002', N'Trần Thị Bình', '0900000002', 'binh@example.com', N'Đà Nẵng', DATEADD(MONTH, -3, @Today), DATEADD(MONTH, 9, @Today), 1),
        (3, 'DG0003', N'Lê Hoàng Cường', '0900000003', NULL, N'TP. Hồ Chí Minh', DATEADD(MONTH, -8, @Today), DATEADD(MONTH, 4, @Today), 1),
        (4, 'DG0004', N'Phạm Thu Dung', '0900000004', NULL, NULL, DATEADD(MONTH, -14, @Today), DATEADD(MONTH, -2, @Today), 1),
        (5, 'DG0005', N'Đỗ Minh Đức', NULL, NULL, NULL, DATEADD(MONTH, -2, @Today), DATEADD(MONTH, 10, @Today), 0);
    SET IDENTITY_INSERT dbo.Members OFF;

    -- Phiếu 1 đang mượn, phiếu 2 quá hạn, phiếu 3 đã trả xong, phiếu 4 mới trả một phần
    SET IDENTITY_INSERT dbo.Loans ON;
    INSERT INTO dbo.Loans (Id, MemberId, LoanDate, DueDate, Status) VALUES
        (1, 1, DATEADD(DAY, -5, @Today), DATEADD(DAY, 9, @Today), 'Borrowing'),
        (2, 2, DATEADD(DAY, -30, @Today), DATEADD(DAY, -16, @Today), 'Borrowing'),
        (3, 3, DATEADD(DAY, -40, @Today), DATEADD(DAY, -26, @Today), 'Returned'),
        (4, 1, DATEADD(DAY, -10, @Today), DATEADD(DAY, 4, @Today), 'Borrowing');
    SET IDENTITY_INSERT dbo.Loans OFF;

    INSERT INTO dbo.LoanItems (LoanId, BookId, ReturnedDate, FineAmount) VALUES
        (1, 1, NULL, 0),
        (1, 3, NULL, 0),
        (2, 2, NULL, 0),
        (3, 4, DATEADD(DAY, -28, @Today), 0),
        (3, 5, DATEADD(DAY, -24, @Today), 4000),
        (4, 6, DATEADD(DAY, -3, @Today), 0),
        (4, 7, NULL, 0);

    COMMIT TRANSACTION;
END
GO
