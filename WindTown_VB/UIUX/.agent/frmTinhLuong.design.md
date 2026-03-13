# Design frmTinhLuong

## Mục tiêu
- Hiển thị và quản lý bảng lương theo kỳ.
- Lọc theo kỳ lương, vị trí, trạng thái và thời gian.
- Hỗ trợ tạo bảng lương, đóng bảng lương, và menu báo cáo.

## Bố cục & hành vi
- Header: tiêu đề + nút Tạo bảng lương / Đóng bảng lương / Báo cáo.
- Bộ lọc: từ khóa, kỳ lương, vị trí, trạng thái, thời gian và lọc nhanh tháng/quý.
- Bảng: Mã bảng lương, Kỳ lương, Nhân viên, Công việc, Trình độ, Trạng thái, Ghi chú.

## Logic chính
- Tạo bảng lương bằng dialog chọn kỳ lương + vị trí.
- Đóng bảng lương theo lựa chọn (cập nhật trạng thái).
- Lọc nhanh tháng/quý map sang khoảng ngày.
- Dữ liệu qua TinhLuongDataModel (PayrollService, Pay_PeriodService, PositionService).
