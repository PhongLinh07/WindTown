
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
-- 1. MODULE: TỔ CHỨC (ORGANIZATION)
-- =============================================

CREATE TABLE department (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255) NOT NULL,
note NVARCHAR(255),
status INT DEFAULT 1 -- -1:Xóa, 0:Ngưng, 1:Hoạt động
);

CREATE TABLE job (
id INT IDENTITY(1,1) PRIMARY KEY,
department_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255) NOT NULL,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE level (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255) NOT NULL,
rank INT DEFAULT 0,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE salary_mult (
id INT IDENTITY(1,1) PRIMARY KEY,
job_id INT,
level_id INT,
mult DECIMAL(10, 2) NOT NULL,
note NVARCHAR(255),
status INT DEFAULT 1
);

-- =============================================
-- 2. MODULE: NHÂN SỰ (HUMAN RESOURCE)
-- =============================================

CREATE TABLE employee (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255) NOT NULL,
gender INT, -- 0:Nữ, 1:Nam, 2:Khác
cccd NVARCHAR(255),
birth_date DATE,
address NVARCHAR(255),
email NVARCHAR(255),
phone NVARCHAR(255),
bank NVARCHAR(255),
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE contract (
id INT IDENTITY(1,1) PRIMARY KEY,
employee_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
start_date DATE,
end_date DATE,
base_salary DECIMAL(18, 0),
note NVARCHAR(MAX),
status INT DEFAULT 1
);

CREATE TABLE position (
id INT IDENTITY(1,1) PRIMARY KEY,
contract_id INT,
salary_mult_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
start_date DATE,
end_date DATE,
note NVARCHAR(255),
status INT DEFAULT 1
);

-- =============================================
-- 3. MODULE: VẬN HÀNH (OPERATIONAL)
-- =============================================

CREATE TABLE project (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255) NOT NULL,
start_date DATE,
end_date DATE,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE assignment (
id INT IDENTITY(1,1) PRIMARY KEY,
position_id INT,
project_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
role INT DEFAULT 0,
start_date DATE,
end_date DATE,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE attendance (
id INT IDENTITY(1,1) PRIMARY KEY,
employee_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
of_date DATE NOT NULL,
office_hours DECIMAL(5, 2),
overtime_hours DECIMAL(5, 2),
late_hours DECIMAL(5, 2),
early_hours DECIMAL(5, 2),
shift INT DEFAULT 0,
note NVARCHAR(MAX),
status INT DEFAULT 1
);

CREATE TABLE holiday (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
of_date DATE NOT NULL,
name NVARCHAR(255),
mult DECIMAL(5, 2),
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE leave_cat (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255),
benefit INT DEFAULT 0,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE leave (
id INT IDENTITY(1,1) PRIMARY KEY,
employee_id INT,
approved_id INT,
leave_cat_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
start_date DATE,
total_days DECIMAL(5, 2),
reason NVARCHAR(255),
note NVARCHAR(255),
status INT DEFAULT 1
);

-- =============================================
-- 4. MODULE: QUY TẮC & CHÍNH SÁCH (RULE ENGINE)
-- =============================================

CREATE TABLE policy (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255),
[rule] NVARCHAR(MAX),
[source] INT,
aggregate INT,
priority INT,
category INT,
unit INT,
gen_item INT DEFAULT 1,
note NVARCHAR(MAX),
status INT DEFAULT 1
);

-- =============================================
-- 5. MODULE: TÀI CHÍNH (FINANCE)
-- =============================================

CREATE TABLE pay_period (
id INT IDENTITY(1,1) PRIMARY KEY,
code NVARCHAR(255) UNIQUE NOT NULL,
name NVARCHAR(255),
month DATE,
start_date DATE,
end_date DATE,
std_hours DECIMAL(18, 2),
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE payroll (
id INT IDENTITY(1,1) PRIMARY KEY,
period_id INT,
position_id INT,
code NVARCHAR(255) UNIQUE NOT NULL,
note NVARCHAR(255),
status INT DEFAULT 1
);

CREATE TABLE pay_item (
id INT IDENTITY(1,1) PRIMARY KEY,
payroll_id INT,
code NVARCHAR(255),
name NVARCHAR(255),
value DECIMAL(18, 2),
priority INT,
category INT,
unit INT,
source INT,
note NVARCHAR(255),
status INT DEFAULT 1
);

-- =============================================
-- 6. MODULE: HỆ THỐNG (SYSTEM)
-- =============================================

CREATE TABLE account (
id INT IDENTITY(1,1) PRIMARY KEY,
employee_id INT,
[user] NVARCHAR(255) UNIQUE NOT NULL,
[password] NVARCHAR(255) NOT NULL,
role INT DEFAULT 1,
last_active DATETIME2,
note NVARCHAR(255),
status INT DEFAULT 1
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
-- ======================= Datas


-- Chèn dữ liệu cho Employee
INSERT INTO employee (code, name, gender, cccd, birth_date, address, email, phone, bank, note, status) VALUES
(N'EMP001', N'Nguyễn Văn An', 1, N'047636216680', '2002-03-02', N'Phú Thọ', N'emp001@windtown.com', N'0211532090', N'ACB_0211532090', N'', 1)

INSERT INTO account (employee_id, [user], [password], role, status) VALUES
(1, N'admin', N'123', 1, 0)
