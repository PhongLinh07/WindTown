## Context

- UIUX hi?n có frmChamCong v?i logic co b?n, nhung chua có l?c nhanh theo tháng/quý và ki?m tra trùng mã tru?c khi luu.
- frmKyLuong và frmTinhLuong m?i ch? có b? c?c UI, chua có logic nghi?p v?.
- Backend dã có các service/model: Pay_PeriodService, PayrollService, Pay_ItemService, AttendanceService.
- Ràng bu?c d? án: ch? ch?nh s?a trong UIUX/, không thay d?i backend; ghi log thi?t k?/ti?n trình/l?i trong UIUX/.agent/.

## Goals / Non-Goals

**Goals:**
- B? sung ki?m tra trùng mã phía UI tru?c khi luu d? li?u cho frmChamCong, frmKyLuong.
- Thêm l?c nhanh theo tháng/quý và menu báo cáo ph? cho frmChamCong.
- Hoàn thi?n hành vi và lu?ng thao tác cho frmKyLuong (pay_period) và frmTinhLuong (payroll/pay_item) theo CSDL.
- Chu?n hóa b? c?c, nhãn, và hành vi theo hu?ng d? dùng, rõ vai trò CRUD vs báo cáo.

**Non-Goals:**
- Không thay d?i API/backend, không s?a các service/repository.
- Không can thi?p vào nhánh backend ngoài UIUX/.
- Không t?i uu hi?u nang truy v?n backend ? m?c h? th?ng.

## Decisions

- T?n d?ng các service hi?n có (AttendanceService, Pay_PeriodService, PayrollService, Pay_ItemService) d? tránh s?a backend.
- L?c nhanh tháng/quý du?c x? lý ? UI b?ng cách map th?i gian nhanh -> kho?ng ngày, sau dó áp d?ng filter hi?n có.
- “Xu?t báo cáo” chuy?n thành menu ph? d? tách kh?i thao tác CRUD.
- Ki?m tra trùng mã ? UI: so sánh case-insensitive trên t?p d? li?u dã t?i; khi s?a ch? ch?n n?u trùng v?i b?n ghi khác.
- Module d? li?u m?i trong UIUX (n?u thi?u) ch? dóng vai trò di?u ph?i g?i service (DataIntent).

## Risks / Trade-offs

- [R?i ro] D? li?u trùng mã v?n có th? x?y ra n?u backend không khóa và d? li?u du?c t?o d?ng th?i ? [Gi?m thi?u] Ki?m tra trùng ? UI, thông báo rõ và khuy?n ngh? backend ki?m tra thêm.
- [R?i ro] L?c nhanh tháng/quý có th? gây hi?u nh?m múi gi?/ngày ? [Gi?m thi?u] Ch? dùng DateTime.Date, hi?n th? kho?ng ngày rõ ràng.
- [R?i ro] Nhi?u b? l?c k?t h?p làm r?ng k?t qu? ? [Gi?m thi?u] Nút “Làm m?i” d? reset toàn b?.
