## Mục tiêu
- Kiểm tra toàn bộ luồng frontend theo các form trong UIUX.
- Ưu tiên fail-case trước pass-case.

## Chuẩn bị
- Đảm bảo SQL Server chạy và DB `wind_town` sẵn sàng.
- Build Debug trước khi test.

## frmLogin
Fail-case:
1. Để trống `Tên đăng nhập` -> bấm `Đăng nhập`.
2. Nhập username, để trống `Mật khẩu` -> bấm `Đăng nhập`.
3. Nhập sai user/password -> bấm `Đăng nhập`.
4. Tắt SQL Server -> mở app.
Pass-case:
1. Nhập đúng user/password -> đăng nhập thành công, chuyển `frmMain`.
2. Bấm `Đăng ký` -> mở `frmRegister`.

## frmRegister
Fail-case:
1. Bỏ trống các trường bắt buộc -> bấm `Đăng ký`.
2. Nhập email sai định dạng (nếu có).
Pass-case:
1. Nhập đủ thông tin -> đăng ký thành công, quay lại login.

## frmMain + NavigationService
Fail-case:
1. Nhấn `Alt+Left` khi không có lịch sử -> không crash.
Pass-case:
1. Chuyển qua 2-3 màn bằng sidebar -> nội dung load đúng.
2. `Alt+Left` -> quay lại màn trước.

## frmDashboard
Fail-case:
1. DB không kết nối -> hiển thị thông báo phù hợp.
Pass-case:
1. Dữ liệu summary hiển thị đúng định dạng (số, tên).

## frmNhanSu
Fail-case:
1. Lọc với điều kiện không có dữ liệu -> bảng rỗng nhưng không lỗi.
2. Chọn node tree không hợp lệ -> không crash.
3. Xuất danh sách khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Load danh sách nhân sự -> hiển thị tree + bảng.
2. Mở chi tiết nhân sự (nếu có) -> đúng dữ liệu.
3. Xuất danh sách -> tạo file thành công.

## frmPhongBan
Fail-case:
1. Thêm phòng ban thiếu tên -> cảnh báo.
2. Xóa phòng ban đang có ràng buộc -> thông báo hợp lệ.
Pass-case:
1. Thêm/Sửa/Xóa phòng ban -> cập nhật tree.

## frmChucVu
Fail-case:
1. Thêm chức vụ trùng mã -> cảnh báo.
2. Xóa chức vụ đang dùng -> thông báo hợp lệ.
Pass-case:
1. CRUD chức vụ thành công.

## frmChamCong
Fail-case:
1. Thêm chấm công trùng mã -> cảnh báo.
2. Nhập giờ âm/không hợp lệ -> cảnh báo.
3. Xuất báo cáo khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Thêm/Sửa/Xóa chấm công -> cập nhật dgv.
2. Lọc theo tháng/quý -> kết quả đúng.
3. Xuất báo cáo theo bộ lọc -> tạo file thành công.
4. Xuất báo cáo theo lựa chọn -> tạo file thành công.

## frmKyLuong
Fail-case:
1. Tạo kỳ lương trùng mã/khoảng thời gian -> cảnh báo.
2. Xuất báo cáo khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Tạo kỳ lương -> hiển thị danh sách.
2. Xuất báo cáo -> tạo file thành công.

## frmTinhLuong
Fail-case:
1. Tính lương khi chưa chọn kỳ -> cảnh báo.
2. Xuất báo cáo khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Tính lương theo kỳ -> hiển thị bảng lương.
2. Xuất báo cáo theo bộ lọc/lựa chọn -> tạo file thành công.

## frmHopDong
Fail-case:
1. Thêm hợp đồng thiếu thông tin bắt buộc -> cảnh báo.
2. Ngày kết thúc < ngày bắt đầu -> cảnh báo.
3. Xuất báo cáo khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Thêm/Sửa/Xóa hợp đồng -> cập nhật bảng.
2. Xuất báo cáo -> tạo file thành công.

## frmSystem
Fail-case:
1. Kiểm tra kết nối CSDL với thông tin sai -> báo lỗi.
2. Lưu cấu hình khi thiếu thông tin -> cảnh báo.
Pass-case:
1. Kiểm tra kết nối thành công -> hiển thị trạng thái.
2. Lưu cấu hình -> thông báo thành công.
3. Quản lý tài khoản: Thêm/Sửa/Xóa -> danh sách cập nhật.
4. Phân quyền: chọn vai trò -> chỉnh quyền -> lưu quyền.

## frmLuong
Fail-case:
1. Lọc kỳ lương không có dữ liệu -> bảng rỗng.
2. Xuất báo cáo khi không có dữ liệu -> cảnh báo.
Pass-case:
1. Xem bảng lương -> số liệu đúng định dạng.
2. Xuất báo cáo -> tạo file thành công.

## frmTest (nếu dùng nội bộ)
Fail-case:
1. Thao tác bất kỳ không hợp lệ -> không crash.
Pass-case:
1. Các nút demo hoạt động bình thường.
