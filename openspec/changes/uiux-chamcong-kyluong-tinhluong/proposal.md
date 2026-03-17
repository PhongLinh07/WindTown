## Why

Giao di?n và hành vi hi?n t?i c?a ch?m công, k? luong và tính luong còn thi?u các lu?ng nghi?p v? quan tr?ng (l?c nhanh, ki?m tra trùng mã, tách hành d?ng báo cáo), gây khó s? d?ng và d? nh?p sai d? li?u. C?n chu?n hóa hành vi theo CSDL và t?i uu tr?i nghi?m thao tác ngay trong UIUX.

## What Changes

- B? sung ki?m tra trùng mã tru?c khi luu ? frmChamCong và frmKyLuong.
- Thêm l?c nhanh theo tháng/quý và hành vi th?i gian nhanh trong frmChamCong.
- Chuy?n “Xu?t báo cáo” vào menu ph?, tách kh?i nhóm CRUD ? frmChamCong.
- Thi?t k? l?i hành vi và lu?ng thao tác cho frmKyLuong (k? luong) theo CSDL pay_period.
- Thi?t k? l?i hành vi và lu?ng thao tác cho frmTinhLuong (tính luong) theo CSDL payroll/pay_item, k?t n?i UIUX qua module d? li?u.
- Chu?n hóa l?i b? c?c và nhãn d? phù h?p ch?c nang.

## Capabilities

### New Capabilities
- `cham-cong-filters-reporting`: L?c nhanh theo tháng/quý, ki?m tra trùng mã, và hành vi báo cáo trong ch?m công.
- `ky-luong-management`: Qu?n lý k? luong theo CSDL pay_period (t?o/s?a/xóa/dóng, ki?m tra trùng mã, validate ngày).
- `tinh-luong-workflow`: Lu?ng tính luong theo k?, l?c và t?o b?ng luong, k?t n?i d? li?u payroll/pay_item.

### Modified Capabilities
- `<existing-name>`: <what requirement is changing>

## Impact

- UIUX/frmChamCong.vb + Designer.vb + resx
- UIUX/frmKyLuong.vb + Designer.vb + resx
- UIUX/frmTinhLuong.vb + Designer.vb + resx
- UIUX/Modules (thêm module d? li?u cho k? luong/tính luong n?u c?n)
- Tài li?u log trong UIUX/.agent/
