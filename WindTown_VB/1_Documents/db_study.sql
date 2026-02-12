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

USE wind_town;
GO

-- =======================
-- 2. DROP TABLES IF EXISTS
-- =======================

IF OBJECT_ID('product','U') IS NOT NULL DROP TABLE product;
IF OBJECT_ID('client','U') IS NOT NULL DROP TABLE product;

GO


-- -----------------------------
-- Bảng Product
-- -----------------------------
CREATE TABLE product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX),
    unit_price DECIMAL(18,2) DEFAULT 0,
    quantity INT DEFAULT 0,  
    status NVARCHAR(MAX) DEFAULT 'Enable',
    description NVARCHAR(MAX)
);
                       
 -- -----------------------------
-- Bảng Client
-- -----------------------------
CREATE TABLE client (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(MAX),
    phone NVARCHAR(MAX),
    email NVARCHAR(MAX),
    status NVARCHAR(MAX) DEFAULT 'Enable',
    description NVARCHAR(MAX)
);

-- Dữ liệu demo: mỗi loại 5 dòng
INSERT INTO product (name, unit_price, quantity, status, description)
VALUES
('iPhone 15', 29999.99, 10, 'Enable', 'New Apple phone'),
('iPhone 15 Pro', 39999.99, 5, 'Enable', 'Pro version Apple phone'),
('iPhone 15 Mini', 19999.99, 7, 'Enable', 'Mini version Apple phone'),
('iPhone 15 SE', 15999.99, 12, 'Enable', 'Budget Apple phone'),
('iPhone 15 Ultra', 49999.99, 3, 'Enable', 'Top-tier Apple phone');
GO


-- Dữ liệu demo cho khách hàng
INSERT INTO client (name, phone, email, status, description)
VALUES
('Nguyen Van A', '0901234567', 'a.nguyen@gmail.com', 'Enable', 'VIP client'),
('Tran Thi B', '0912345678', 'b.tran@yahoo.com', 'Enable', 'Regular client'),
('Le Van C', '0923456789', 'c.le@hotmail.com', 'Enable', 'New client'),
('Pham Thi D', '0934567890', 'd.pham@gmail.com', 'Enable', 'Loyal client'),
('Hoang Van E', '0945678901', 'e.hoang@gmail.com', 'Enable', 'Corporate client');

GO