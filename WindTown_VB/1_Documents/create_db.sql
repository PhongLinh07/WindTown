-- =======================
-- 0. Rule 
-- =======================

-- =======================
--- Vô hiệu hóa tất cả ràng buộc khóa ngoại trên toàn bộ database
-- EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL";

-- Thường đi kèm với việc vô hiệu hóa cả Trigger nếu có
-- EXEC sp_MSforeachtable "ALTER TABLE ? DISABLE TRIGGER ALL";
-- =======================


-- =======================
-- 1. DROP DATABASE IF EXISTS
-- =======================
IF DB_ID('wind_town') IS NOT NULL
    DROP DATABASE wind_town;
GO

CREATE DATABASE wind_town;
GO

USE wind_town;
GO

-- =======================
-- 2. DROP TABLES IF EXISTS
-- =======================
IF OBJECT_ID('department', 'U')   IS NOT NULL DROP TABLE department;
IF OBJECT_ID('salary_mult', 'U')   IS NOT NULL DROP TABLE salary_mult;
IF OBJECT_ID('job', 'U')          IS NOT NULL DROP TABLE job;
IF OBJECT_ID('level', 'U')        IS NOT NULL DROP TABLE level;

IF OBJECT_ID('employee', 'U')     IS NOT NULL DROP TABLE employee;
IF OBJECT_ID('contract', 'U')     IS NOT NULL DROP TABLE contract;
IF OBJECT_ID('position', 'U')     IS NOT NULL DROP TABLE position;

IF OBJECT_ID('project', 'U')      IS NOT NULL DROP TABLE project;
IF OBJECT_ID('assignment', 'U')   IS NOT NULL DROP TABLE assignment;
IF OBJECT_ID('leave_cat', 'U')        IS NOT NULL DROP TABLE leave_cat;
IF OBJECT_ID('leave', 'U')        IS NOT NULL DROP TABLE leave;
IF OBJECT_ID('attendance', 'U')   IS NOT NULL DROP TABLE attendance;
IF OBJECT_ID('holiday', 'U')      IS NOT NULL DROP TABLE holiday;

IF OBJECT_ID('policy', 'U')       IS NOT NULL DROP TABLE policy;
IF OBJECT_ID('pay_item', 'U')      IS NOT NULL DROP TABLE pay_item;
IF OBJECT_ID('payroll', 'U')      IS NOT NULL DROP TABLE payroll;
IF OBJECT_ID('pay_period', 'U')   IS NOT NULL DROP TABLE pay_period;

IF OBJECT_ID('account', 'U')      IS NOT NULL DROP TABLE account;
GO



-- =======================
-- 3. CREATE TABLES 
-- =======================
-- =============================================
-- 2. MODULE: TỔ CHỨC (ORGANIZATION)
-- =============================================

CREATE TABLE department (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
    
);

CREATE TABLE job (
    id INT IDENTITY(1,1) PRIMARY KEY,
    department_id INT,
    datas NVARCHAR(max)

);

CREATE TABLE level (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE salary_mult (
    id INT IDENTITY(1,1) PRIMARY KEY,
    job_id INT,
    level_id INT,
    datas NVARCHAR(max)
);

-- =============================================
-- 3. MODULE: NHÂN SỰ (HUMAN RESOURCE)
-- =============================================

CREATE TABLE employee (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE contract (
    id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    datas NVARCHAR(max)
);

CREATE TABLE position (
    id INT IDENTITY(1,1) PRIMARY KEY,
    contract_id INT,
    salary_mult_id INT,
    datas NVARCHAR(max)
);

-- =============================================
-- 4. MODULE: VẬN HÀNH (OPERATIONAL)
-- =============================================

CREATE TABLE project (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE assignment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    position_id INT,
    project_id INT,
    datas NVARCHAR(max)
);

CREATE TABLE attendance (
    id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    datas NVARCHAR(max)
);

CREATE TABLE holiday (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE leave_cat (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE leave (
    id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    approved_id INT,
    leave_cat_id INT,
    datas NVARCHAR(max)
);

-- =============================================
-- 5. MODULE: QUY TẮC & CHÍNH SÁCH (RULE ENGINE)
-- =============================================

CREATE TABLE policy (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

-- =============================================
-- 6. MODULE: TÀI CHÍNH (FINANCE)
-- =============================================

CREATE TABLE pay_item (
    id INT IDENTITY(1,1) PRIMARY KEY,
    payroll_id INT,
    datas NVARCHAR(max)
);

CREATE TABLE pay_period (
    id INT IDENTITY(1,1) PRIMARY KEY,
    datas NVARCHAR(max)
);

CREATE TABLE payroll (
    id INT IDENTITY(1,1) PRIMARY KEY,
    period_id INT,
    position_id INT,
    datas NVARCHAR(max)
);

-- =============================================
-- 7. MODULE: HỆ THỐNG (SYSTEM)
-- =============================================

CREATE TABLE account (
    id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    datas NVARCHAR(max)
);
GO
-- =============================================
-- 4. ADD FOREIGN KEY CONSTRAINTS
-- =============================================

-- Module: Tổ chức
ALTER TABLE job ADD CONSTRAINT FK_job_department FOREIGN KEY (department_id) REFERENCES department(id);

ALTER TABLE salary_mult ADD CONSTRAINT FK_salary_mult_job FOREIGN KEY (job_id) REFERENCES job(id);
ALTER TABLE salary_mult ADD CONSTRAINT FK_salary_mult_level FOREIGN KEY (level_id) REFERENCES level(id);
-- Module: Nhân sự
ALTER TABLE contract ADD CONSTRAINT FK_contract_employee FOREIGN KEY (employee_id) REFERENCES employee(id);

ALTER TABLE position ADD CONSTRAINT FK_position_contract FOREIGN KEY (contract_id) REFERENCES contract(id);
ALTER TABLE position ADD CONSTRAINT FK_position_salary_mult FOREIGN KEY (salary_mult_id) REFERENCES salary_mult(id);


-- Module: Vận hành
ALTER TABLE assignment ADD CONSTRAINT FK_assignment_position FOREIGN KEY (position_id) REFERENCES position(id);

ALTER TABLE assignment ADD CONSTRAINT FK_assignment_project FOREIGN KEY (project_id) REFERENCES project(id);

ALTER TABLE attendance ADD CONSTRAINT FK_attendance_employee FOREIGN KEY (employee_id) REFERENCES employee(id);

ALTER TABLE leave ADD CONSTRAINT FK_leave_employee FOREIGN KEY (employee_id) REFERENCES employee(id);
ALTER TABLE leave ADD CONSTRAINT FK_leave_approved FOREIGN KEY (approved_id) REFERENCES employee(id);
ALTER TABLE leave ADD CONSTRAINT FK_leave_leave_cat FOREIGN KEY (leave_cat_id) REFERENCES leave_cat(id);

-- Module: Tài chính
ALTER TABLE payroll ADD CONSTRAINT FK_payroll_period FOREIGN KEY (period_id) REFERENCES pay_period(id);
ALTER TABLE payroll ADD CONSTRAINT FK_payroll_position FOREIGN KEY (position_id) REFERENCES position(id);
ALTER TABLE pay_item ADD CONSTRAINT FK_pay_item_payroll FOREIGN KEY (payroll_id) REFERENCES payroll(id);

-- Module: Hệ thống
ALTER TABLE account ADD CONSTRAINT FK_account_employee FOREIGN KEY (employee_id) REFERENCES employee(id);
GO

INSERT INTO employee (datas) VALUES
(N'{"code": "admin1", "name": "ADMIN", "gender": 1, "cccd": "000000000", "birth_date": "2002-03-02", "address": "Phú Thọ", "email": "admin@windtown.com", "phone": "0000000000", "bank": "ACB_000000000", "note": "", "status": 1}'),
(N'{"code": "nvbt", "name": "Nguyên Văn An", "gender": 1, "cccd": "000000001", "birth_date": "2002-03-02", "address": "Ha Noi", "email": "nva@windtown.com", "phone": "0000000001", "bank": "MB_000000000", "note": "", "status": 1}')
GO

INSERT INTO account (employee_id ,datas) VALUES 
(1,  N'{"user": "admin", "password": "123456", "role": 1, "status": 0}'),
(2,  N'{"user": "nvbt", "password": "123", "role": 2, "status": 0}')
GO