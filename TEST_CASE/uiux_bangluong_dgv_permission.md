## Mục tiêu

Xác nhận sửa lỗi SplitterDistance trên form Bảng lương, đồng bộ định dạng DataGridView và kiểm soát quyền chỉnh sửa.

## Tiền điều kiện

- Build solution thành công.
- Có tài khoản đăng nhập hợp lệ trong CSDL.

## Bước thực hiện

1. Đăng nhập bằng tài khoản có quyền quản trị.
2. Mở form Bảng lương, kéo thu nhỏ cửa sổ để kiểm tra SplitContainer.
3. Mở các form Dự án, Phân công, Nghỉ phép, Ngày lễ và quan sát định dạng lưới.
4. Kiểm tra thông tin CSDL và tài khoản hiển thị trong phần mô tả của form.
5. Đăng xuất và đăng nhập bằng tài khoản không có quyền chỉnh sửa.
6. Mở các form Dự án, Phân công, Nghỉ phép, Ngày lễ và kiểm tra nút Thêm/Sửa/Xóa/Lưu bị khóa.
7. Mở form Bảng lương và kiểm tra nút Chốt bảng lương bị khóa.

## Kết quả mong đợi

- Không xuất hiện lỗi `SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize`.
- Định dạng DataGridView giống chuẩn của `frmChamCong`.
- Thông tin CSDL và tài khoản hiển thị đúng.
- Người dùng không có quyền không thể thao tác chỉnh sửa.

## Kết quả thực tế

- Đã build thành công (Debug|Any CPU).
- Chưa kiểm tra runtime trong môi trường chạy.
