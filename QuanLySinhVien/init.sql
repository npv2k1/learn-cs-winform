SET QUOTED_IDENTIFIER ON;
GO
IF DB_ID('StudentDb') IS NULL
    CREATE DATABASE StudentDb COLLATE Vietnamese_100_CI_AS;
GO
USE StudentDb;
GO

IF OBJECT_ID('dbo.Faculties', 'U') IS NULL
CREATE TABLE dbo.Faculties (
    Id   INT IDENTITY(1,1) CONSTRAINT PK_Faculties PRIMARY KEY,
    Code VARCHAR(20) NOT NULL CONSTRAINT UQ_Faculties_Code UNIQUE,
    Name NVARCHAR(150) NOT NULL CONSTRAINT UQ_Faculties_Name UNIQUE
);
GO

IF OBJECT_ID('dbo.StudentClasses', 'U') IS NULL
CREATE TABLE dbo.StudentClasses (
    Id         INT IDENTITY(1,1) CONSTRAINT PK_StudentClasses PRIMARY KEY,
    Code       VARCHAR(20) NOT NULL CONSTRAINT UQ_StudentClasses_Code UNIQUE,
    Name       NVARCHAR(150) NOT NULL,
    FacultyId  INT NOT NULL CONSTRAINT FK_StudentClasses_Faculties REFERENCES dbo.Faculties(Id),
    IntakeYear SMALLINT NOT NULL
);
GO

IF OBJECT_ID('dbo.Students', 'U') IS NULL
CREATE TABLE dbo.Students (
    Id             INT IDENTITY(1,1) CONSTRAINT PK_Students PRIMARY KEY,
    StudentCode    VARCHAR(20) NOT NULL CONSTRAINT UQ_Students_StudentCode UNIQUE,
    FullName       NVARCHAR(150) NOT NULL,
    DateOfBirth    DATE NOT NULL,
    Gender         VARCHAR(10) NOT NULL,
    Email          VARCHAR(150) NULL,
    Phone          VARCHAR(20) NULL,
    Address        NVARCHAR(255) NULL,
    StudentClassId INT NOT NULL CONSTRAINT FK_Students_StudentClasses REFERENCES dbo.StudentClasses(Id),
    Status         VARCHAR(20) NOT NULL CONSTRAINT DF_Students_Status DEFAULT 'Studying',
    CONSTRAINT CK_Students_Gender CHECK (Gender IN ('Male', 'Female', 'Other')),
    CONSTRAINT CK_Students_Status CHECK (Status IN ('Studying', 'Suspended', 'Graduated', 'Dropped'))
);
GO

IF OBJECT_ID('dbo.Lecturers', 'U') IS NULL
CREATE TABLE dbo.Lecturers (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_Lecturers PRIMARY KEY,
    LecturerCode VARCHAR(20) NOT NULL CONSTRAINT UQ_Lecturers_LecturerCode UNIQUE,
    FullName     NVARCHAR(150) NOT NULL,
    Email        VARCHAR(150) NULL,
    Phone        VARCHAR(20) NULL,
    FacultyId    INT NOT NULL CONSTRAINT FK_Lecturers_Faculties REFERENCES dbo.Faculties(Id)
);
GO

IF OBJECT_ID('dbo.Courses', 'U') IS NULL
CREATE TABLE dbo.Courses (
    Id        INT IDENTITY(1,1) CONSTRAINT PK_Courses PRIMARY KEY,
    Code      VARCHAR(20) NOT NULL CONSTRAINT UQ_Courses_Code UNIQUE,
    Name      NVARCHAR(150) NOT NULL,
    Credits   TINYINT NOT NULL,
    FacultyId INT NOT NULL CONSTRAINT FK_Courses_Faculties REFERENCES dbo.Faculties(Id),
    CONSTRAINT CK_Courses_Credits CHECK (Credits > 0)
);
GO

IF OBJECT_ID('dbo.CourseSections', 'U') IS NULL
CREATE TABLE dbo.CourseSections (
    Id           INT IDENTITY(1,1) CONSTRAINT PK_CourseSections PRIMARY KEY,
    Code         VARCHAR(20) NOT NULL CONSTRAINT UQ_CourseSections_Code UNIQUE,
    CourseId     INT NOT NULL CONSTRAINT FK_CourseSections_Courses REFERENCES dbo.Courses(Id),
    LecturerId   INT NULL CONSTRAINT FK_CourseSections_Lecturers REFERENCES dbo.Lecturers(Id),
    AcademicYear CHAR(9) NOT NULL,
    Semester     TINYINT NOT NULL,
    MaxStudents  INT NOT NULL,
    CONSTRAINT CK_CourseSections_AcademicYear CHECK (AcademicYear LIKE '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
    CONSTRAINT CK_CourseSections_Semester CHECK (Semester BETWEEN 1 AND 3),
    CONSTRAINT CK_CourseSections_MaxStudents CHECK (MaxStudents > 0)
);
GO

IF OBJECT_ID('dbo.Enrollments', 'U') IS NULL
CREATE TABLE dbo.Enrollments (
    Id              INT IDENTITY(1,1) CONSTRAINT PK_Enrollments PRIMARY KEY,
    StudentId       INT NOT NULL CONSTRAINT FK_Enrollments_Students REFERENCES dbo.Students(Id),
    CourseSectionId INT NOT NULL CONSTRAINT FK_Enrollments_CourseSections REFERENCES dbo.CourseSections(Id),
    EnrolledDate    DATE NOT NULL,
    ProcessScore    DECIMAL(4,2) NULL,
    FinalScore      DECIMAL(4,2) NULL,
    CONSTRAINT UQ_Enrollments_Student_Section UNIQUE (StudentId, CourseSectionId),
    CONSTRAINT CK_Enrollments_ProcessScore CHECK (ProcessScore BETWEEN 0 AND 10),
    CONSTRAINT CK_Enrollments_FinalScore CHECK (FinalScore BETWEEN 0 AND 10)
);
GO
