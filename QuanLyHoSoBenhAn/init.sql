SET QUOTED_IDENTIFIER ON;
GO
IF DB_ID('MedicalRecordDb') IS NULL
    CREATE DATABASE MedicalRecordDb COLLATE Vietnamese_100_CI_AS;
GO
USE MedicalRecordDb;
GO

IF OBJECT_ID('dbo.Departments', 'U') IS NULL
CREATE TABLE dbo.Departments (
    Id       INT IDENTITY(1,1) CONSTRAINT PK_Departments PRIMARY KEY,
    Name     NVARCHAR(150) NOT NULL CONSTRAINT UQ_Departments_Name UNIQUE,
    Location NVARCHAR(100) NULL
);
GO

IF OBJECT_ID('dbo.Doctors', 'U') IS NULL
CREATE TABLE dbo.Doctors (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_Doctors PRIMARY KEY,
    DoctorCode   VARCHAR(20) NOT NULL CONSTRAINT UQ_Doctors_DoctorCode UNIQUE,
    FullName     NVARCHAR(150) NOT NULL,
    Specialty    NVARCHAR(100) NULL,
    Phone        VARCHAR(20) NULL,
    DepartmentId INT NOT NULL CONSTRAINT FK_Doctors_Departments REFERENCES dbo.Departments(Id)
);
GO

IF OBJECT_ID('dbo.Patients', 'U') IS NULL
CREATE TABLE dbo.Patients (
    Id                    INT IDENTITY(1,1) CONSTRAINT PK_Patients PRIMARY KEY,
    PatientCode           VARCHAR(20) NOT NULL CONSTRAINT UQ_Patients_PatientCode UNIQUE,
    FullName              NVARCHAR(150) NOT NULL,
    DateOfBirth           DATE NOT NULL,
    Gender                VARCHAR(10) NOT NULL,
    IdentityNumber        VARCHAR(20) NULL,
    HealthInsuranceNumber VARCHAR(20) NULL,
    Phone                 VARCHAR(20) NULL,
    Address               NVARCHAR(255) NULL,
    BloodType             VARCHAR(3) NULL,
    Allergies             NVARCHAR(500) NULL,
    CONSTRAINT CK_Patients_Gender CHECK (Gender IN ('Male', 'Female', 'Other')),
    CONSTRAINT CK_Patients_BloodType CHECK (BloodType IN ('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-')),
    INDEX UX_Patients_IdentityNumber UNIQUE (IdentityNumber) WHERE IdentityNumber IS NOT NULL,
    INDEX UX_Patients_HealthInsuranceNumber UNIQUE (HealthInsuranceNumber) WHERE HealthInsuranceNumber IS NOT NULL
);
GO

IF OBJECT_ID('dbo.MedicalRecords', 'U') IS NULL
CREATE TABLE dbo.MedicalRecords (
    Id            INT IDENTITY(1,1) CONSTRAINT PK_MedicalRecords PRIMARY KEY,
    RecordCode    VARCHAR(20) NOT NULL CONSTRAINT UQ_MedicalRecords_RecordCode UNIQUE,
    PatientId     INT NOT NULL CONSTRAINT FK_MedicalRecords_Patients REFERENCES dbo.Patients(Id),
    DoctorId      INT NOT NULL CONSTRAINT FK_MedicalRecords_Doctors REFERENCES dbo.Doctors(Id),
    VisitDate     DATETIME2(0) NOT NULL,
    Symptoms      NVARCHAR(1000) NOT NULL,
    Diagnosis     NVARCHAR(1000) NULL,
    TreatmentPlan NVARCHAR(1000) NULL,
    Notes         NVARCHAR(1000) NULL,
    Status        VARCHAR(20) NOT NULL CONSTRAINT DF_MedicalRecords_Status DEFAULT 'Open',
    CONSTRAINT CK_MedicalRecords_Status CHECK (Status IN ('Open', 'Closed'))
);
GO

IF OBJECT_ID('dbo.Medicines', 'U') IS NULL
CREATE TABLE dbo.Medicines (
    Id        INT IDENTITY(1,1) CONSTRAINT PK_Medicines PRIMARY KEY,
    Code      VARCHAR(20) NOT NULL CONSTRAINT UQ_Medicines_Code UNIQUE,
    Name      NVARCHAR(150) NOT NULL,
    Unit      NVARCHAR(30) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL CONSTRAINT DF_Medicines_UnitPrice DEFAULT 0,
    CONSTRAINT CK_Medicines_UnitPrice CHECK (UnitPrice >= 0)
);
GO

IF OBJECT_ID('dbo.Prescriptions', 'U') IS NULL
CREATE TABLE dbo.Prescriptions (
    Id              INT IDENTITY(1,1) CONSTRAINT PK_Prescriptions PRIMARY KEY,
    MedicalRecordId INT NOT NULL CONSTRAINT FK_Prescriptions_MedicalRecords REFERENCES dbo.MedicalRecords(Id),
    IssuedDate      DATE NOT NULL,
    Notes           NVARCHAR(500) NULL
);
GO

IF OBJECT_ID('dbo.PrescriptionItems', 'U') IS NULL
CREATE TABLE dbo.PrescriptionItems (
    Id             INT IDENTITY(1,1) CONSTRAINT PK_PrescriptionItems PRIMARY KEY,
    PrescriptionId INT NOT NULL CONSTRAINT FK_PrescriptionItems_Prescriptions REFERENCES dbo.Prescriptions(Id) ON DELETE CASCADE,
    MedicineId     INT NOT NULL CONSTRAINT FK_PrescriptionItems_Medicines REFERENCES dbo.Medicines(Id),
    Quantity       INT NOT NULL,
    Dosage         NVARCHAR(255) NOT NULL,
    CONSTRAINT UQ_PrescriptionItems_Prescription_Medicine UNIQUE (PrescriptionId, MedicineId),
    CONSTRAINT CK_PrescriptionItems_Quantity CHECK (Quantity > 0)
);
GO
