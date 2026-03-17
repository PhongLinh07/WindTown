## ADDED Requirements

### Requirement: L?c nhanh theo tháng/quý
H? th?ng MUST cho phép ngu?i dùng ch?n l?c nhanh theo tháng/quý d? t? d?ng d?t kho?ng ngày l?c.

#### Scenario: Ch?n tháng này
- **WHEN** ngu?i dùng ch?n "Tháng này" ? b? l?c nhanh
- **THEN** h? th?ng d?t kho?ng ngày t? ngày d?u tháng hi?n t?i d?n ngày hi?n t?i và áp d?ng l?c

#### Scenario: Ch?n quý tru?c
- **WHEN** ngu?i dùng ch?n "Quý tru?c" ? b? l?c nhanh
- **THEN** h? th?ng d?t kho?ng ngày theo quý tru?c dó và áp d?ng l?c

### Requirement: Ki?m tra trùng mã tru?c khi luu
H? th?ng MUST ki?m tra trùng mã ch?m công tru?c khi luu và ngan luu n?u mã dã t?n t?i.

#### Scenario: Trùng mã khi t?o m?i
- **WHEN** ngu?i dùng luu b?n ghi có mã dã t?n t?i
- **THEN** h? th?ng hi?n th? c?nh báo và không luu

#### Scenario: Trùng mã khi s?a
- **WHEN** ngu?i dùng s?a và d?i mã trùng v?i b?n ghi khác
- **THEN** h? th?ng hi?n th? c?nh báo và không luu

### Requirement: Báo cáo ? menu ph?
H? th?ng MUST dua ch?c nang "Xu?t báo cáo" vào menu ph? tách kh?i nhóm CRUD.

#### Scenario: M? menu báo cáo
- **WHEN** ngu?i dùng b?m nút "Báo cáo"
- **THEN** h? th?ng hi?n th? các tu? ch?n xu?t báo cáo
