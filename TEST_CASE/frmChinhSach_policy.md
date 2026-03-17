## Mục tiêu

Xác nhận form Chính sách đã có CRUD dựa trên bảng `policy`.

## Tiền điều kiện

- CSDL có bảng `policy`.
- Ứng dụng build thành công.

## Bước thực hiện

1. Chạy lệnh `rg -n "ChinhSachRepository|policy" -S WindTown_VB\\UIUX`.
2. Mở form Chính sách, kiểm tra dữ liệu hiển thị từ bảng `policy`.
3. Thực hiện Thêm/Sửa/Xóa một chính sách và xác nhận dữ liệu cập nhật.

## Kết quả mong đợi

- Form hiển thị dữ liệu từ bảng `policy`.
- CRUD hoạt động và cập nhật đúng dữ liệu.

## Kết quả thực tế

- Đã xác nhận có repository và truy vấn `policy` trong mã nguồn.
- Chưa thể xác nhận CRUD do cần kiểm thử UI trực tiếp.
