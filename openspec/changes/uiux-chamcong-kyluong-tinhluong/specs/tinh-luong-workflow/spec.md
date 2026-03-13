## ADDED Requirements

### Requirement: L?c và t?o b?ng luong theo k?
H? th?ng MUST cho phép ch?n k? luong và t?o b?ng luong theo k? dã ch?n.

#### Scenario: Chua ch?n k? luong
- **WHEN** ngu?i dùng b?m t?o b?ng luong khi chua ch?n k? luong
- **THEN** h? th?ng hi?n th? c?nh báo và không t?o

#### Scenario: T?o b?ng luong thành công
- **WHEN** ngu?i dùng ch?n k? luong h?p l? và b?m t?o
- **THEN** h? th?ng t?o các b?n ghi b?ng luong và hi?n th? danh sách

### Requirement: L?c nhanh theo tháng/quý ? tính luong
H? th?ng MUST cho phép l?c nhanh theo tháng/quý trong danh sách b?ng luong.

#### Scenario: Ch?n quý này
- **WHEN** ngu?i dùng ch?n "Quý này" ? b? l?c nhanh
- **THEN** h? th?ng áp d?ng kho?ng ngày c?a quý hi?n t?i và l?c danh sách

### Requirement: Tách báo cáo kh?i CRUD
H? th?ng MUST hi?n th? báo cáo ? menu ph? d? tách kh?i CRUD.

#### Scenario: M? menu báo cáo
- **WHEN** ngu?i dùng b?m nút "Báo cáo"
- **THEN** h? th?ng hi?n th? các tu? ch?n báo cáo theo k?
