## Mục tiêu
- Thiết kế giao diện form cài đặt hệ thống dễ đọc, rõ nhóm cấu hình.
- Tách khu vực danh mục và nội dung chi tiết.

## Bố cục
- `tlpMain`: 3 hàng
  - Header: tiêu đề + mô tả.
  - Nội dung: 2 cột (danh mục + nội dung).
  - Chân trang: trạng thái + nút hành động.

## Khu vực danh mục
- `grpDanhMuc` + `lstDanhMuc`:
  - Các mục: Cơ sở dữ liệu, Hiển thị, Sao lưu, Nhật ký.

## Khu vực nội dung
- `grpCoSoDuLieu`:
  - Máy chủ, Tên CSDL, Tài khoản, Mật khẩu.
  - Nút kiểm tra kết nối.
- `grpHienThi`:
  - Ngôn ngữ, Định dạng ngày.
  - Tùy chọn hiển thị thông báo.
- `grpTaiKhoan`:
  - Form nhập nhanh: tên đăng nhập, họ tên, email, vai trò, trạng thái kích hoạt.
  - Lưới danh sách tài khoản: tên đăng nhập, họ tên, vai trò, trạng thái.
  - Nút thao tác: Thêm, Sửa, Xóa, Phân quyền.
- `grpPhanQuyen`:
  - Chọn vai trò cần cấu hình quyền.
  - Bảng quyền theo chức năng: Xem, Thêm, Sửa, Xóa, Xuất.
  - Hành động: Lưu quyền, Sao chép quyền, Đặt lại.

## Chân trang
- Trạng thái hiển thị thay đổi.
- Nút `Lưu cấu hình` và `Đóng`.

## Gợi ý thiết kế thêm
- Thêm nhóm `Sao lưu` với đường dẫn + lịch sao lưu tự động.
- Thêm mục `Nhật ký` hiển thị danh sách thao tác quan trọng.
- Cho phép hiển thị trạng thái kết nối trực tiếp sau khi kiểm tra.
- Thêm màn hình phân quyền chi tiết theo chức năng (xem, thêm, sửa, xóa, xuất).
