# Changes frmChamCong

## 2026-03-12
- Thêm logic tải dữ liệu chấm công và bộ lọc bám sát CSDL.
- Cấu hình DataGridView với các cột theo bảng attendance.
- Tạo ChamCongDataModel (cục bộ trong frmChamCong.vb) dùng AttendanceService/EmployeeService.
- Chuẩn hóa text UI có dấu và font Microsoft YaHei UI cho frmChamCong.
- Sửa lỗi InvalidCastException khi đọc SelectedValue từ ComboBox bộ lọc.
- Bổ sung bộ lọc thời gian “Tất cả/Theo khoảng”.
- Thêm phân trang 10 dòng/trang với nút Trang trước/Trang sau.
- Bổ sung nút Làm mới bộ lọc.
- Thiết kế lại màu sắc header, nút và nền tổng thể.
- Thêm nút Thêm/Sửa/Xóa chấm công trên header.
- Bổ sung dialog thêm/sửa chấm công và logic CRUD bám CSDL.
- Gắn lại đầy đủ Handles cho các sự kiện filter và nút thao tác.

## 2026-03-12 (bổ sung)
- Thêm bộ lọc nhanh theo tháng/quý và hành vi tự đặt khoảng ngày.
- Chuyển “Xuất báo cáo” thành menu phụ (Báo cáo) để tách khỏi CRUD.
- Bổ sung kiểm tra trùng mã chấm công trước khi lưu (tạo/sửa).
- Chuẩn hóa lại text hiển thị tiếng Việt có dấu trong frmChamCong.

## 2026-03-13
- Sửa lọc theo khoảng thời gian để dùng `dtpkToday` (từ ngày) và `dtpkInday` (đến ngày).
- Đồng bộ trạng thái bật/tắt bộ lọc thời gian theo lựa chọn `cbbxThoiGian`.
