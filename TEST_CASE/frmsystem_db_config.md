## Mục tiêu

Xác nhận frmSystem tải, kiểm tra kết nối và lưu cấu hình cơ sở dữ liệu.

## Tiền điều kiện

- Build solution thành công.
- Có thông tin máy chủ và tên CSDL hợp lệ để kiểm tra kết nối (nếu test runtime).

## Bước thực hiện

1. Mở menu `Cài đặt` -> `Cài đặt hệ thống`.
2. Kiểm tra dữ liệu được tải vào các ô Máy chủ, Tên CSDL, Tài khoản, Mật khẩu.
3. Chọn Ngôn ngữ, Định dạng ngày, bấm `Kiểm tra kết nối`.
4. Bấm `Lưu cấu hình`, quan sát thông báo.

## Kết quả mong đợi

- Form hiển thị dữ liệu cấu hình mặc định.
- Nút `Kiểm tra kết nối` báo kết quả thành công hoặc lỗi hợp lệ.
- Nút `Lưu cấu hình` ghi cấu hình và thông báo thành công.

## Kết quả thực tế

- Đã build thành công (Debug|Any CPU). Chưa kiểm tra runtime trong môi trường chạy.
