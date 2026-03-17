## Mục tiêu

Xác nhận module fallback đọc/ghi cấu hình kết nối cho frmSystem hoạt động.

## Tiền điều kiện

- Build solution thành công.

## Bước thực hiện

1. Mở `frmSystem`, kiểm tra dữ liệu cấu hình được nạp.
2. Cập nhật thông tin máy chủ/CSDL, bấm `Lưu cấu hình`.
3. Mở lại `frmSystem` để xác nhận cấu hình đã được lưu.

## Kết quả mong đợi

- Dữ liệu cấu hình hiển thị đúng trong `frmSystem`.
- Lưu cấu hình thành công và được đọc lại khi mở form.

## Kết quả thực tế

- Đã build thành công (Debug|Any CPU). Chưa kiểm tra runtime trong môi trường chạy.
