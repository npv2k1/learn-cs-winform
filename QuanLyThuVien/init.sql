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
