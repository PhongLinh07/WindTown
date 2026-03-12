# Errors frmHopDong

## 2026-03-12
- Text tiếng Việt trong Designer bị lỗi mã hóa (hiển thị sai dấu).
  - Cách xử lý: đặt lại Text của form/label/nút trong code (frmHopDong_Load) và chuẩn hóa chuỗi trong Designer về ASCII.
- Build lỗi do module áp dụng font chưa được compile (FontHelper không khai báo).
  - Cách xử lý: chuyển module áp dụng font vào UIUX/Modules/NavigationService.vb và cập nhật cách gọi.
- Build Debug đã PASS sau khi sửa.
