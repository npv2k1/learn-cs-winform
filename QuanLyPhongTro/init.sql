SET QUOTED_IDENTIFIER ON;
GO
IF DB_ID('RoomRentalDb') IS NULL
    CREATE DATABASE RoomRentalDb COLLATE Vietnamese_100_CI_AS;
GO
USE RoomRentalDb;
GO

IF OBJECT_ID('dbo.Rooms', 'U') IS NULL
CREATE TABLE dbo.Rooms (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_Rooms PRIMARY KEY,
    RoomNumber   NVARCHAR(20) NOT NULL CONSTRAINT UQ_Rooms_RoomNumber UNIQUE,
    Floor        INT NOT NULL CONSTRAINT DF_Rooms_Floor DEFAULT 1,
    Area         DECIMAL(6,2) NOT NULL,
    MonthlyRent  DECIMAL(18,2) NOT NULL,
    MaxOccupants INT NOT NULL CONSTRAINT DF_Rooms_MaxOccupants DEFAULT 1,
    Status       VARCHAR(20) NOT NULL CONSTRAINT DF_Rooms_Status DEFAULT 'Available',
    CONSTRAINT CK_Rooms_Values CHECK (Area > 0 AND MonthlyRent >= 0 AND MaxOccupants > 0),
    CONSTRAINT CK_Rooms_Status CHECK (Status IN ('Available', 'Occupied', 'Maintenance'))
);
GO

IF OBJECT_ID('dbo.Tenants', 'U') IS NULL
CREATE TABLE dbo.Tenants (
    Id             INT IDENTITY(1,1) CONSTRAINT PK_Tenants PRIMARY KEY,
    FullName       NVARCHAR(150) NOT NULL,
    IdentityNumber VARCHAR(20) NOT NULL CONSTRAINT UQ_Tenants_IdentityNumber UNIQUE,
    DateOfBirth    DATE NULL,
    Phone          VARCHAR(20) NOT NULL,
    Address        NVARCHAR(255) NULL
);
GO

IF OBJECT_ID('dbo.Contracts', 'U') IS NULL
CREATE TABLE dbo.Contracts (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_Contracts PRIMARY KEY,
    RoomId      INT NOT NULL CONSTRAINT FK_Contracts_Rooms REFERENCES dbo.Rooms(Id),
    StartDate   DATE NOT NULL,
    EndDate     DATE NULL,
    MonthlyRent DECIMAL(18,2) NOT NULL,
    Deposit     DECIMAL(18,2) NOT NULL CONSTRAINT DF_Contracts_Deposit DEFAULT 0,
    Status      VARCHAR(20) NOT NULL CONSTRAINT DF_Contracts_Status DEFAULT 'Active',
    CONSTRAINT CK_Contracts_Dates CHECK (EndDate IS NULL OR EndDate >= StartDate),
    CONSTRAINT CK_Contracts_Amounts CHECK (MonthlyRent >= 0 AND Deposit >= 0),
    CONSTRAINT CK_Contracts_Status CHECK (Status IN ('Active', 'Ended')),
    INDEX UX_Contracts_ActiveRoom UNIQUE (RoomId) WHERE Status = 'Active'
);
GO

IF OBJECT_ID('dbo.ContractTenants', 'U') IS NULL
CREATE TABLE dbo.ContractTenants (
    ContractId       INT NOT NULL CONSTRAINT FK_ContractTenants_Contracts REFERENCES dbo.Contracts(Id) ON DELETE CASCADE,
    TenantId         INT NOT NULL CONSTRAINT FK_ContractTenants_Tenants REFERENCES dbo.Tenants(Id),
    IsRepresentative BIT NOT NULL CONSTRAINT DF_ContractTenants_IsRepresentative DEFAULT 0,
    MoveInDate       DATE NOT NULL,
    MoveOutDate      DATE NULL,
    CONSTRAINT PK_ContractTenants PRIMARY KEY (ContractId, TenantId),
    CONSTRAINT CK_ContractTenants_Dates CHECK (MoveOutDate IS NULL OR MoveOutDate >= MoveInDate),
    INDEX UX_ContractTenants_Representative UNIQUE (ContractId) WHERE IsRepresentative = 1
);
GO

IF OBJECT_ID('dbo.Services', 'U') IS NULL
CREATE TABLE dbo.Services (
    Id        INT IDENTITY(1,1) CONSTRAINT PK_Services PRIMARY KEY,
    Name      NVARCHAR(100) NOT NULL CONSTRAINT UQ_Services_Name UNIQUE,
    Unit      NVARCHAR(30) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    IsMetered BIT NOT NULL CONSTRAINT DF_Services_IsMetered DEFAULT 0,
    CONSTRAINT CK_Services_UnitPrice CHECK (UnitPrice >= 0)
);
GO

IF OBJECT_ID('dbo.MeterReadings', 'U') IS NULL
CREATE TABLE dbo.MeterReadings (
    Id              INT IDENTITY(1,1) CONSTRAINT PK_MeterReadings PRIMARY KEY,
    RoomId          INT NOT NULL CONSTRAINT FK_MeterReadings_Rooms REFERENCES dbo.Rooms(Id),
    ServiceId       INT NOT NULL CONSTRAINT FK_MeterReadings_Services REFERENCES dbo.Services(Id),
    BillingMonth    DATE NOT NULL,
    PreviousReading DECIMAL(12,2) NOT NULL,
    CurrentReading  DECIMAL(12,2) NOT NULL,
    CONSTRAINT UQ_MeterReadings_Room_Service_Month UNIQUE (RoomId, ServiceId, BillingMonth),
    CONSTRAINT CK_MeterReadings_BillingMonth CHECK (DAY(BillingMonth) = 1),
    CONSTRAINT CK_MeterReadings_Values CHECK (PreviousReading >= 0 AND CurrentReading >= PreviousReading)
);
GO

IF OBJECT_ID('dbo.Invoices', 'U') IS NULL
CREATE TABLE dbo.Invoices (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_Invoices PRIMARY KEY,
    ContractId   INT NOT NULL CONSTRAINT FK_Invoices_Contracts REFERENCES dbo.Contracts(Id),
    BillingMonth DATE NOT NULL,
    IssueDate    DATE NOT NULL,
    DueDate      DATE NOT NULL,
    TotalAmount  DECIMAL(18,2) NOT NULL CONSTRAINT DF_Invoices_TotalAmount DEFAULT 0,
    Status       VARCHAR(20) NOT NULL CONSTRAINT DF_Invoices_Status DEFAULT 'Unpaid',
    CONSTRAINT UQ_Invoices_Contract_Month UNIQUE (ContractId, BillingMonth),
    CONSTRAINT CK_Invoices_BillingMonth CHECK (DAY(BillingMonth) = 1),
    CONSTRAINT CK_Invoices_Dates CHECK (DueDate >= IssueDate),
    CONSTRAINT CK_Invoices_TotalAmount CHECK (TotalAmount >= 0),
    CONSTRAINT CK_Invoices_Status CHECK (Status IN ('Unpaid', 'PartiallyPaid', 'Paid'))
);
GO

IF OBJECT_ID('dbo.InvoiceItems', 'U') IS NULL
CREATE TABLE dbo.InvoiceItems (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_InvoiceItems PRIMARY KEY,
    InvoiceId   INT NOT NULL CONSTRAINT FK_InvoiceItems_Invoices REFERENCES dbo.Invoices(Id) ON DELETE CASCADE,
    ServiceId   INT NULL CONSTRAINT FK_InvoiceItems_Services REFERENCES dbo.Services(Id),
    Description NVARCHAR(255) NOT NULL,
    Quantity    DECIMAL(12,2) NOT NULL,
    UnitPrice   DECIMAL(18,2) NOT NULL,
    Amount      AS CAST(Quantity * UnitPrice AS DECIMAL(18,2)) PERSISTED,
    CONSTRAINT CK_InvoiceItems_Values CHECK (Quantity >= 0 AND UnitPrice >= 0)
);
GO

IF OBJECT_ID('dbo.Payments', 'U') IS NULL
CREATE TABLE dbo.Payments (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_Payments PRIMARY KEY,
    InvoiceId   INT NOT NULL CONSTRAINT FK_Payments_Invoices REFERENCES dbo.Invoices(Id),
    PaymentDate DATE NOT NULL,
    Amount      DECIMAL(18,2) NOT NULL,
    Method      VARCHAR(20) NOT NULL CONSTRAINT DF_Payments_Method DEFAULT 'Cash',
    Note        NVARCHAR(255) NULL,
    CONSTRAINT CK_Payments_Amount CHECK (Amount > 0),
    CONSTRAINT CK_Payments_Method CHECK (Method IN ('Cash', 'BankTransfer'))
);
GO
