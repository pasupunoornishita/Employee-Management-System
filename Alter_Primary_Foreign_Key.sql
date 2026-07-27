-- ============================================================
-- Employee & Department tables
-- Primary Key (PK) and Foreign Key (FK) using ALTER
-- Database: EmployeeDB (SQL Server)
-- ============================================================

USE EmployeeDB;
GO

-- ============================================================
-- STEP 1: Department table (parent) — create if not exists
-- ============================================================

IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Department')
BEGIN
    CREATE TABLE Department (
        dept_id   INT          NOT NULL,
        dept_name VARCHAR(100) NOT NULL
    );
END
GO

-- Primary Key on Department.dept_id
IF NOT EXISTS (
    SELECT 1 FROM sys.key_constraints
    WHERE name = 'PK_Department' AND parent_object_id = OBJECT_ID('Department'))
BEGIN
    ALTER TABLE Department
    ADD CONSTRAINT PK_Department
        PRIMARY KEY (dept_id);
END
GO

-- Sample department data
IF NOT EXISTS (SELECT 1 FROM Department WHERE dept_id = 1)
    INSERT INTO Department (dept_id, dept_name) VALUES (1, 'IT');
IF NOT EXISTS (SELECT 1 FROM Department WHERE dept_id = 2)
    INSERT INTO Department (dept_id, dept_name) VALUES (2, 'HR');
IF NOT EXISTS (SELECT 1 FROM Department WHERE dept_id = 3)
    INSERT INTO Department (dept_id, dept_name) VALUES (3, 'Finance');
GO

-- ============================================================
-- STEP 2: Employee table (child) — create if not exists
-- ============================================================

IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Employee')
BEGIN
    CREATE TABLE Employee (
        emp_id   INT          NOT NULL IDENTITY(1,1),
        emp_name VARCHAR(100) NOT NULL,
        salary   FLOAT        NOT NULL,
        dept_id  INT          NOT NULL
    );
END
GO

-- Primary Key on Employee.emp_id
IF NOT EXISTS (
    SELECT 1 FROM sys.key_constraints
    WHERE name = 'PK_Employee' AND parent_object_id = OBJECT_ID('Employee'))
BEGIN
    ALTER TABLE Employee
    ADD CONSTRAINT PK_Employee
        PRIMARY KEY (emp_id);
END
GO

-- ============================================================
-- STEP 3: Foreign Key — Employee.dept_id → Department.dept_id
-- ============================================================

IF NOT EXISTS (
    SELECT 1 FROM sys.foreign_keys
    WHERE name = 'FK_Employee_Department')
BEGIN
    ALTER TABLE Employee
    ADD CONSTRAINT FK_Employee_Department
        FOREIGN KEY (dept_id)
        REFERENCES Department (dept_id);
END
GO

-- ============================================================
-- STEP 4: Verify joined tables
-- ============================================================

SELECT
    e.emp_id,
    e.emp_name,
    e.salary,
    e.dept_id,
    d.dept_name
FROM Employee e
INNER JOIN Department d ON e.dept_id = d.dept_id;
GO
