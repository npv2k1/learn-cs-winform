SET QUOTED_IDENTIFIER ON;
GO
IF DB_ID('StoreDb') IS NULL
    CREATE DATABASE StoreDb COLLATE Vietnamese_100_CI_AS;
GO
USE StoreDb;
GO

IF OBJECT_ID('dbo.Categories', 'U') IS NULL
CREATE TABLE dbo.Categories (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_Categories PRIMARY KEY,
    Name        NVARCHAR(100) NOT NULL CONSTRAINT UQ_Categories_Name UNIQUE,
    Description NVARCHAR(500) NULL
);
GO

IF OBJECT_ID('dbo.Suppliers', 'U') IS NULL
CREATE TABLE dbo.Suppliers (
    Id      INT IDENTITY(1,1) CONSTRAINT PK_Suppliers PRIMARY KEY,
    Name    NVARCHAR(150) NOT NULL,
    Phone   VARCHAR(20) NULL,
    Email   VARCHAR(150) NULL,
    Address NVARCHAR(255) NULL
);
GO

IF OBJECT_ID('dbo.Products', 'U') IS NULL
CREATE TABLE dbo.Products (
    Id            INT IDENTITY(1,1) CONSTRAINT PK_Products PRIMARY KEY,
    Sku           VARCHAR(30) NOT NULL CONSTRAINT UQ_Products_Sku UNIQUE,
    Name          NVARCHAR(200) NOT NULL,
    CategoryId    INT NOT NULL CONSTRAINT FK_Products_Categories REFERENCES dbo.Categories(Id),
    SupplierId    INT NULL CONSTRAINT FK_Products_Suppliers REFERENCES dbo.Suppliers(Id),
    Unit          NVARCHAR(30) NOT NULL,
    PurchasePrice DECIMAL(18,2) NOT NULL CONSTRAINT DF_Products_PurchasePrice DEFAULT 0,
    SalePrice     DECIMAL(18,2) NOT NULL CONSTRAINT DF_Products_SalePrice DEFAULT 0,
    StockQuantity INT NOT NULL CONSTRAINT DF_Products_StockQuantity DEFAULT 0,
    IsActive      BIT NOT NULL CONSTRAINT DF_Products_IsActive DEFAULT 1,
    CONSTRAINT CK_Products_Values CHECK (PurchasePrice >= 0 AND SalePrice >= 0 AND StockQuantity >= 0)
);
GO

IF OBJECT_ID('dbo.Customers', 'U') IS NULL
CREATE TABLE dbo.Customers (
    Id       INT IDENTITY(1,1) CONSTRAINT PK_Customers PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Phone    VARCHAR(20) NULL,
    Email    VARCHAR(150) NULL,
    Address  NVARCHAR(255) NULL,
    INDEX UX_Customers_Phone UNIQUE (Phone) WHERE Phone IS NOT NULL
);
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NULL
CREATE TABLE dbo.Employees (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_Employees PRIMARY KEY,
    EmployeeCode VARCHAR(20) NOT NULL CONSTRAINT UQ_Employees_EmployeeCode UNIQUE,
    FullName     NVARCHAR(150) NOT NULL,
    Phone        VARCHAR(20) NULL,
    Position     NVARCHAR(100) NULL,
    HireDate     DATE NOT NULL,
    IsActive     BIT NOT NULL CONSTRAINT DF_Employees_IsActive DEFAULT 1
);
GO

IF OBJECT_ID('dbo.Orders', 'U') IS NULL
CREATE TABLE dbo.Orders (
    Id             INT IDENTITY(1,1) CONSTRAINT PK_Orders PRIMARY KEY,
    OrderCode      VARCHAR(20) NOT NULL CONSTRAINT UQ_Orders_OrderCode UNIQUE,
    CustomerId     INT NULL CONSTRAINT FK_Orders_Customers REFERENCES dbo.Customers(Id),
    EmployeeId     INT NOT NULL CONSTRAINT FK_Orders_Employees REFERENCES dbo.Employees(Id),
    OrderDate      DATETIME2(0) NOT NULL,
    DiscountAmount DECIMAL(18,2) NOT NULL CONSTRAINT DF_Orders_DiscountAmount DEFAULT 0,
    TotalAmount    DECIMAL(18,2) NOT NULL CONSTRAINT DF_Orders_TotalAmount DEFAULT 0,
    PaymentMethod  VARCHAR(20) NOT NULL CONSTRAINT DF_Orders_PaymentMethod DEFAULT 'Cash',
    Status         VARCHAR(20) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT 'Pending',
    CONSTRAINT CK_Orders_Amounts CHECK (DiscountAmount >= 0 AND TotalAmount >= 0),
    CONSTRAINT CK_Orders_PaymentMethod CHECK (PaymentMethod IN ('Cash', 'BankTransfer', 'Card')),
    CONSTRAINT CK_Orders_Status CHECK (Status IN ('Pending', 'Completed', 'Cancelled'))
);
GO

IF OBJECT_ID('dbo.OrderItems', 'U') IS NULL
CREATE TABLE dbo.OrderItems (
    Id        INT IDENTITY(1,1) CONSTRAINT PK_OrderItems PRIMARY KEY,
    OrderId   INT NOT NULL CONSTRAINT FK_OrderItems_Orders REFERENCES dbo.Orders(Id) ON DELETE CASCADE,
    ProductId INT NOT NULL CONSTRAINT FK_OrderItems_Products REFERENCES dbo.Products(Id),
    Quantity  INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Amount    AS CAST(Quantity * UnitPrice AS DECIMAL(18,2)) PERSISTED,
    CONSTRAINT UQ_OrderItems_Order_Product UNIQUE (OrderId, ProductId),
    CONSTRAINT CK_OrderItems_Values CHECK (Quantity > 0 AND UnitPrice >= 0)
);
GO

IF OBJECT_ID('dbo.PurchaseReceipts', 'U') IS NULL
CREATE TABLE dbo.PurchaseReceipts (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_PurchaseReceipts PRIMARY KEY,
    ReceiptCode  VARCHAR(20) NOT NULL CONSTRAINT UQ_PurchaseReceipts_ReceiptCode UNIQUE,
    SupplierId   INT NOT NULL CONSTRAINT FK_PurchaseReceipts_Suppliers REFERENCES dbo.Suppliers(Id),
    EmployeeId   INT NOT NULL CONSTRAINT FK_PurchaseReceipts_Employees REFERENCES dbo.Employees(Id),
    ReceivedDate DATE NOT NULL,
    TotalAmount  DECIMAL(18,2) NOT NULL CONSTRAINT DF_PurchaseReceipts_TotalAmount DEFAULT 0,
    Note         NVARCHAR(255) NULL,
    CONSTRAINT CK_PurchaseReceipts_TotalAmount CHECK (TotalAmount >= 0)
);
GO

IF OBJECT_ID('dbo.PurchaseReceiptItems', 'U') IS NULL
CREATE TABLE dbo.PurchaseReceiptItems (
    Id                INT IDENTITY(1,1) CONSTRAINT PK_PurchaseReceiptItems PRIMARY KEY,
    PurchaseReceiptId INT NOT NULL CONSTRAINT FK_PurchaseReceiptItems_PurchaseReceipts REFERENCES dbo.PurchaseReceipts(Id) ON DELETE CASCADE,
    ProductId         INT NOT NULL CONSTRAINT FK_PurchaseReceiptItems_Products REFERENCES dbo.Products(Id),
    Quantity          INT NOT NULL,
    UnitCost          DECIMAL(18,2) NOT NULL,
    Amount            AS CAST(Quantity * UnitCost AS DECIMAL(18,2)) PERSISTED,
    CONSTRAINT UQ_PurchaseReceiptItems_Receipt_Product UNIQUE (PurchaseReceiptId, ProductId),
    CONSTRAINT CK_PurchaseReceiptItems_Values CHECK (Quantity > 0 AND UnitCost >= 0)
);
GO
