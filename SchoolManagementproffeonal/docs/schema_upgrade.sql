/*
  School Management System — recommended schema
  Run against database: SchoolManagementDB
  Safe to re-run: uses IF NOT EXISTS / conditional ALTERs where practical.
*/

USE SchoolManagementDB;
GO

/* ---------- Core tables ---------- */
IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
  CREATE TABLE dbo.Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(80) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin','Teacher','Student','Parent'))
  );
END
GO

IF OBJECT_ID('dbo.Teachers','U') IS NULL
BEGIN
  CREATE TABLE dbo.Teachers (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(120) NOT NULL,
    Salary DECIMAL(12,2) NULL,
    Contact NVARCHAR(40) NULL,
    UserID INT NULL REFERENCES dbo.Users(UserID)
  );
END
GO

IF OBJECT_ID('dbo.Parents','U') IS NULL
BEGIN
  CREATE TABLE dbo.Parents (
    ParentID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(120) NOT NULL,
    Contact NVARCHAR(40) NULL,
    Email NVARCHAR(120) NULL,
    Address NVARCHAR(250) NULL,
    UserID INT NULL REFERENCES dbo.Users(UserID)
  );
END
GO

IF OBJECT_ID('dbo.Classes','U') IS NULL
BEGIN
  CREATE TABLE dbo.Classes (
    ClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(80) NOT NULL,
    Section NVARCHAR(20) NULL,
    TeacherID INT NULL REFERENCES dbo.Teachers(TeacherID)
  );
END
GO

IF OBJECT_ID('dbo.Students','U') IS NULL
BEGIN
  CREATE TABLE dbo.Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(120) NOT NULL,
    DOB DATE NULL,
    Address NVARCHAR(250) NULL,
    Contact NVARCHAR(40) NULL,
    ClassID INT NULL REFERENCES dbo.Classes(ClassID),
    ParentID INT NULL REFERENCES dbo.Parents(ParentID),
    UserID INT NULL REFERENCES dbo.Users(UserID)
  );
END
GO

IF OBJECT_ID('dbo.Subjects','U') IS NULL
BEGIN
  CREATE TABLE dbo.Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectName NVARCHAR(120) NOT NULL,
    ClassID INT NOT NULL REFERENCES dbo.Classes(ClassID)
  );
END
GO

IF OBJECT_ID('dbo.Exams','U') IS NULL
BEGIN
  CREATE TABLE dbo.Exams (
    ExamID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectID INT NOT NULL REFERENCES dbo.Subjects(SubjectID),
    Date DATE NOT NULL,
    MaxMarks INT NOT NULL
  );
END
GO

IF OBJECT_ID('dbo.Results','U') IS NULL
BEGIN
  CREATE TABLE dbo.Results (
    ResultID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL REFERENCES dbo.Students(StudentID),
    ExamID INT NOT NULL REFERENCES dbo.Exams(ExamID),
    MarksObtained DECIMAL(8,2) NOT NULL
  );
END
GO

IF OBJECT_ID('dbo.Fees','U') IS NULL
BEGIN
  CREATE TABLE dbo.Fees (
    FeeID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL REFERENCES dbo.Students(StudentID),
    Amount DECIMAL(12,2) NOT NULL,
    DueDate DATE NOT NULL,
    PaidStatus NVARCHAR(20) NOT NULL CHECK (PaidStatus IN ('Pending','Paid'))
  );
END
GO

IF OBJECT_ID('dbo.Attendance','U') IS NULL
BEGIN
  CREATE TABLE dbo.Attendance (
    AttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL REFERENCES dbo.Students(StudentID),
    AttendanceDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Present','Absent','Late'))
  );
END
GO

IF OBJECT_ID('dbo.Library','U') IS NULL
BEGIN
  CREATE TABLE dbo.Library (
    LibraryID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL REFERENCES dbo.Students(StudentID),
    BookName NVARCHAR(200) NOT NULL,
    IssueDate DATE NOT NULL,
    ReturnDate DATE NULL
  );
END
GO

IF OBJECT_ID('dbo.Transport','U') IS NULL
BEGIN
  CREATE TABLE dbo.Transport (
    TransportID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL REFERENCES dbo.Students(StudentID),
    Route NVARCHAR(120) NOT NULL,
    VehicleNo NVARCHAR(40) NULL
  );
END
GO

/* ---------- Optional column upgrades for existing DBs ---------- */
IF COL_LENGTH('dbo.Teachers','UserID') IS NULL
  ALTER TABLE dbo.Teachers ADD UserID INT NULL REFERENCES dbo.Users(UserID);
GO
IF COL_LENGTH('dbo.Students','UserID') IS NULL
  ALTER TABLE dbo.Students ADD UserID INT NULL REFERENCES dbo.Users(UserID);
GO
IF COL_LENGTH('dbo.Parents','UserID') IS NULL
  ALTER TABLE dbo.Parents ADD UserID INT NULL REFERENCES dbo.Users(UserID);
GO
IF COL_LENGTH('dbo.Parents','Email') IS NULL
  ALTER TABLE dbo.Parents ADD Email NVARCHAR(120) NULL;
GO
IF COL_LENGTH('dbo.Parents','Address') IS NULL
  ALTER TABLE dbo.Parents ADD Address NVARCHAR(250) NULL;
GO
IF COL_LENGTH('dbo.Attendance','AttendanceDate') IS NULL AND COL_LENGTH('dbo.Attendance','Date') IS NOT NULL
  EXEC sp_rename 'dbo.Attendance.Date', 'AttendanceDate', 'COLUMN';
GO
IF COL_LENGTH('dbo.Library','BookName') IS NULL AND COL_LENGTH('dbo.Library','Title') IS NOT NULL
  EXEC sp_rename 'dbo.Library.Title', 'BookName', 'COLUMN';
GO
IF COL_LENGTH('dbo.Transport','Route') IS NULL AND COL_LENGTH('dbo.Transport','RouteName') IS NOT NULL
  EXEC sp_rename 'dbo.Transport.RouteName', 'Route', 'COLUMN';
GO
IF COL_LENGTH('dbo.Transport','VehicleNo') IS NULL AND COL_LENGTH('dbo.Transport','BusNumber') IS NOT NULL
  EXEC sp_rename 'dbo.Transport.BusNumber', 'VehicleNo', 'COLUMN';
GO

/* ---------- Seed admin (password: admin123) ---------- */
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
BEGIN
  INSERT INTO dbo.Users (Username, PasswordHash, Role)
  VALUES ('admin', 'admin123', 'Admin');
END
GO
