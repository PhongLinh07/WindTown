
USE wind_town;
GO

-- =========================================================
-- INSERT DATA FOR ACCOUNT (Relational IDs + JSON Datas)
-- =========================================================

INSERT INTO account (employee_id, datas) VALUES 
(1,  N'{"user": "EMP001", "password": "PW_EMP001", "role": 1, "status": 0}'),
(2,  N'{"user": "EMP002", "password": "PW_EMP002", "role": 1, "status": 0}'),
(3,  N'{"user": "EMP003", "password": "PW_EMP003", "role": 1, "status": 0}'),
(4,  N'{"user": "EMP004", "password": "PW_EMP004", "role": 2, "status": 0}'),
(5,  N'{"user": "EMP005", "password": "PW_EMP005", "role": 2, "status": 0}'),
(6,  N'{"user": "EMP006", "password": "PW_EMP006", "role": 2, "status": 0}'),
(7,  N'{"user": "EMP007", "password": "PW_EMP007", "role": 2, "status": 0}'),
(8,  N'{"user": "EMP008", "password": "PW_EMP008", "role": 2, "status": 0}'),
(9,  N'{"user": "EMP009", "password": "PW_EMP009", "role": 2, "status": 0}'),
(10, N'{"user": "EMP010", "password": "PW_EMP010", "role": 2, "status": 0}'),
(11, N'{"user": "EMP011", "password": "PW_EMP011", "role": 2, "status": 0}'),
(12, N'{"user": "EMP012", "password": "PW_EMP012", "role": 2, "status": 0}'),
(13, N'{"user": "EMP013", "password": "PW_EMP013", "role": 2, "status": 0}'),
(14, N'{"user": "EMP014", "password": "PW_EMP014", "role": 2, "status": 0}'),
(15, N'{"user": "EMP015", "password": "PW_EMP015", "role": 2, "status": 0}'),
(16, N'{"user": "EMP016", "password": "PW_EMP016", "role": 2, "status": 0}'),
(17, N'{"user": "EMP017", "password": "PW_EMP017", "role": 2, "status": 0}'),
(18, N'{"user": "EMP018", "password": "PW_EMP018", "role": 2, "status": 0}'),
(19, N'{"user": "EMP019", "password": "PW_EMP019", "role": 2, "status": 0}'),
(20, N'{"user": "EMP020", "password": "PW_EMP020", "role": 2, "status": 0}'),
(21, N'{"user": "EMP021", "password": "PW_EMP021", "role": 2, "status": 0}'),
(22, N'{"user": "EMP022", "password": "PW_EMP022", "role": 2, "status": 0}'),
(23, N'{"user": "EMP023", "password": "PW_EMP023", "role": 2, "status": 0}'),
(24, N'{"user": "EMP024", "password": "PW_EMP024", "role": 2, "status": 0}'),
(25, N'{"user": "EMP025", "password": "PW_EMP025", "role": 2, "status": 0}'),
(26, N'{"user": "EMP026", "password": "PW_EMP026", "role": 2, "status": 0}'),
(27, N'{"user": "EMP027", "password": "PW_EMP027", "role": 2, "status": 0}'),
(28, N'{"user": "EMP028", "password": "PW_EMP028", "role": 2, "status": 0}'),
(29, N'{"user": "EMP029", "password": "PW_EMP029", "role": 2, "status": 0}'),
(30, N'{"user": "EMP030", "password": "PW_EMP030", "role": 2, "status": 0}'),
(31, N'{"user": "EMP031", "password": "PW_EMP031", "role": 2, "status": 0}'),
(32, N'{"user": "EMP032", "password": "PW_EMP032", "role": 2, "status": 0}'),
(33, N'{"user": "EMP033", "password": "PW_EMP033", "role": 2, "status": 0}'),
(34, N'{"user": "EMP034", "password": "PW_EMP034", "role": 2, "status": 0}'),
(35, N'{"user": "EMP035", "password": "PW_EMP035", "role": 2, "status": 0}'),
(36, N'{"user": "EMP036", "password": "PW_EMP036", "role": 2, "status": 0}'),
(37, N'{"user": "EMP037", "password": "PW_EMP037", "role": 2, "status": 0}'),
(38, N'{"user": "EMP038", "password": "PW_EMP038", "role": 2, "status": 0}'),
(39, N'{"user": "EMP039", "password": "PW_EMP039", "role": 2, "status": 0}'),
(40, N'{"user": "EMP040", "password": "PW_EMP040", "role": 2, "status": 0}');
GO



-- =========================================================
-- INSERT DATA FOR POLICY (Relational IDs + JSON Datas)
-- =========================================================


-- Giả định bảng: PayrollPolicies (id int identity, datas nvarchar(max))

INSERT INTO policy (datas)
VALUES 
-- 1. Đơn vị lương
(N'{
    "code": "HOURLY_RATE",
    "name": "Đơn vị lương 1h",
    "rule": "SYS_BASE_SALARY * SYS_SALARY_MULT / SYS_STD_HOURS",
    "priority": 1,
    "data_source": 1,
    "aggregate": 1,
    "category": 1,
    "gen_item": 1,
    "unit": 2,
    "note": "Xác định đơn giá lương mỗi giờ làm việc dựa trên lương cơ bản và định mức giờ công.",
    "status": 1
}'),

-- 2. Hệ số ca làm
(N'{
    "code": "MULT_SHIFT",
    "name": "Hệ số giờ hành chính của ca làm",
    "rule": "IF(SYS_SHIFT = 1, 1.0, 1.3) * IF(SYS_IS_HOLIDAY = 1, SYS_MULT_HOLIDAY, 1.0)",
    "priority": 2,
    "data_source": 2,
    "aggregate": 1,
    "category": 1,
    "gen_item": 2,
    "unit": 5,
    "note": "Tính toán hệ số nhân lương tùy theo ca ngày/đêm và điều kiện ngày lễ/tết.",
    "status": 1
}'),

-- 3. Hệ số tăng ca
(N'{
    "code": "MULT_OVERTIME",
    "name": "Hệ số tăng ca của ca làm",
    "rule": "1.2 * MULT_SHIFT",
    "priority": 3,
    "data_source": 2,
    "aggregate": 1,
    "category": 1,
    "gen_item": 2,
    "unit": 5,
    "note": "Hệ số nhân dành riêng cho các giờ làm thêm, phụ thuộc vào hệ số ca gốc.",
    "status": 1
}'),

-- 4. Tổng giờ hành chính
(N'{
    "code": "SUM_OFFICE_HOURS",
    "name": "Tổng giờ hành chính cả kỳ",
    "rule": "SYS_OFFICE_HOURS * MULT_SHIFT",
    "priority": 4,
    "data_source": 2,
    "aggregate": 2,
    "category": 2,
    "gen_item": 1,
    "unit": 3,
    "note": "Tổng thời gian làm việc chính thức trong kỳ lương sau khi quy đổi hệ số.",
    "status": 1
}'),

-- 5. Tổng giờ tăng ca
(N'{
    "code": "SUM_OVERTIME_HOURS",
    "name": "Tổng giờ tăng ca cả kỳ",
    "rule": "SYS_OVERTIME_HOURS * MULT_OVERTIME",
    "priority": 5,
    "data_source": 2,
    "aggregate": 2,
    "category": 2,
    "gen_item": 1,
    "unit": 3,
    "note": "Tổng số giờ làm thêm đã được nhân hệ số tăng ca tương ứng.",
    "status": 1
}'),

-- 6. Tổng giờ đi muộn
(N'{
    "code": "SUM_LATE_HOURS",
    "name": "Tổng giờ đi muộn cả kỳ",
    "rule": "SYS_LATE_HOURS * MULT_SHIFT",
    "priority": 6,
    "data_source": 2,
    "aggregate": 2,
    "category": 2,
    "gen_item": 1,
    "unit": 3,
    "note": "Tổng thời gian vi phạm đi trễ theo dữ liệu máy chấm công.",
    "status": 1
}'),

-- 7. Tổng giờ về sớm
(N'{
    "code": "SUM_EARLY_HOURS",
    "name": "Tổng giờ về sớm cả kỳ",
    "rule": "SYS_EARLY_LEAVE_HOURS * MULT_SHIFT",
    "priority": 7,
    "data_source": 2,
    "aggregate": 2,
    "category": 2,
    "gen_item": 1,
    "unit": 3,
    "note": "Tổng thời gian vi phạm về sớm theo dữ liệu máy chấm công.",
    "status": 1
}'),

-- 8. Tổng giờ chuẩn
(N'{
    "code": "SUM_OFFICE_HOURS_RAW",
    "name": "Tổng giờ hành chính chuẩn cả kỳ",
    "rule": "SYS_OFFICE_HOURS",
    "priority": 8,
    "data_source": 2,
    "aggregate": 2,
    "category": 2,
    "gen_item": 1,
    "unit": 3,
    "note": "Giờ hành chính thực tế chưa nhân hệ số, dùng làm căn cứ xét phụ cấp.",
    "status": 1
}'),

-- 9. Lương hành chính
(N'{
    "code": "SALARY_OFFICE",
    "name": "Tổng thu nhập giờ hành chính cả kỳ",
    "rule": "SUM_OFFICE_HOURS * HOURLY_RATE",
    "priority": 9,
    "data_source": 1,
    "aggregate": 1,
    "category": 3,
    "gen_item": 1,
    "unit": 2,
    "note": "Tiền lương tính theo giờ làm việc hành chính trong kỳ.",
    "status": 1
}'),

-- 10. Lương tăng ca
(N'{
    "code": "SALARY_OVERTIME",
    "name": "Tổng thu nhập tăng ca cả kỳ",
    "rule": "SUM_OVERTIME_HOURS * HOURLY_RATE",
    "priority": 10,
    "data_source": 1,
    "aggregate": 1,
    "category": 3,
    "gen_item": 1,
    "unit": 2,
    "note": "Tiền lương tính cho các giờ làm thêm ngoài giờ hành chính.",
    "status": 1
}'),

-- 11. Khấu trừ đi muộn
(N'{
    "code": "DEDUCT_LATE",
    "name": "Tổng khấu trừ đi muộn cả kỳ",
    "rule": "SUM_LATE_HOURS * HOURLY_RATE",
    "priority": 11,
    "data_source": 1,
    "aggregate": 1,
    "category": 4,
    "gen_item": 1,
    "unit": 2,
    "note": "Khoản tiền bị trừ tương ứng với thời gian đi muộn.",
    "status": 1
}'),

-- 12. Khấu trừ về sớm
(N'{
    "code": "DEDUCT_EARLY",
    "name": "Tổng khấu trừ về sớm cả kỳ",
    "rule": "SUM_EARLY_HOURS * HOURLY_RATE",
    "priority": 12,
    "data_source": 1,
    "aggregate": 1,
    "category": 4,
    "gen_item": 1,
    "unit": 2,
    "note": "Khoản tiền bị trừ tương ứng với thời gian về sớm.",
    "status": 1
}'),

-- 13. Phụ cấp công ty
(N'{
    "code": "ALLOW_COMPANY",
    "name": "Phụ cấp chung của công ty",
    "rule": "IF(SUM_OFFICE_HOURS_RAW >= SYS_STD_HOURS, 700000, 0.0)",
    "priority": 13,
    "data_source": 1,
    "aggregate": 1,
    "category": 5,
    "gen_item": 1,
    "unit": 2,
    "note": "Phụ cấp chuyên cần dành cho nhân viên đạt đủ số giờ công chuẩn.",
    "status": 1
}'),

-- 14. BHXH
(N'{
    "code": "INS_SOCIAL",
    "name": "Khấu trừ bảo hiểm xã hội",
    "rule": "SYS_BASE_SALARY * 0.08",
    "priority": 14,
    "data_source": 1,
    "aggregate": 1,
    "category": 7,
    "gen_item": 1,
    "unit": 2,
    "note": "Trích đóng bảo hiểm xã hội (8%) tính trên mức lương cơ bản.",
    "status": 1
}'),

-- 15. BHYT
(N'{
    "code": "INS_HEALTH",
    "name": "Khấu trừ bảo hiểm sức khỏe",
    "rule": "SYS_BASE_SALARY * 0.015",
    "priority": 15,
    "data_source": 1,
    "aggregate": 1,
    "category": 7,
    "gen_item": 1,
    "unit": 2,
    "note": "Trích đóng bảo hiểm y tế (1.5%) tính trên mức lương cơ bản.",
    "status": 1
}'),

-- 16. BHTN
(N'{
    "code": "INS_UNEMP",
    "name": "Khấu trừ bảo hiểm thất nghiệp",
    "rule": "SYS_BASE_SALARY * 0.01",
    "priority": 16,
    "data_source": 1,
    "aggregate": 1,
    "category": 7,
    "gen_item": 1,
    "unit": 2,
    "note": "Trích đóng bảo hiểm thất nghiệp (1%) tính trên mức lương cơ bản.",
    "status": 1
}'),

-- 17. Thuế TNCN 
(N'{
    "code": "TAX_AMOUNT",
    "name": "Thuế thu nhập các nhân",
    "rule": "TOTAL_INCOME * 0.10",
    "priority": 18,
    "data_source": 1,
    "aggregate": 1,
    "category": 8,
    "gen_item": 1,
    "unit": 2,
    "note": "Tạm tính thuế thu nhập cá nhân phải nộp theo tỷ lệ quy định.",
    "status": 0
}');