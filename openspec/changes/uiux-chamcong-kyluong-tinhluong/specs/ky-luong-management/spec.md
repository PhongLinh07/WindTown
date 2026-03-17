## ADDED Requirements

### Requirement: Qu?n lý k? luong theo CSDL
H? th?ng MUST cho phép t?o, s?a, xoá k? luong bám sát b?ng pay_period.

#### Scenario: T?o k? luong h?p l?
- **WHEN** ngu?i dùng nh?p d?y d? mã, tên, ngày b?t d?u, ngày k?t thúc và gi? chu?n h?p l?
- **THEN** h? th?ng luu k? luong và hi?n th? trong danh sách

### Requirement: Ki?m tra trùng mã k? luong
H? th?ng MUST ki?m tra trùng mã k? luong tru?c khi luu.

#### Scenario: Trùng mã khi t?o m?i
- **WHEN** ngu?i dùng luu k? luong có mã dã t?n t?i
- **THEN** h? th?ng hi?n th? c?nh báo và không luu

### Requirement: Ràng bu?c ngày h?p l?
H? th?ng MUST ch?n luu khi ngày b?t d?u l?n hon ngày k?t thúc.

#### Scenario: Ngày b?t d?u l?n hon ngày k?t thúc
- **WHEN** ngu?i dùng d?t ngày b?t d?u sau ngày k?t thúc
- **THEN** h? th?ng hi?n th? c?nh báo và không luu
