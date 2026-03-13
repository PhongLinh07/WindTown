# Design frmKyLuong

## Mục tiêu
- Quản lý kỳ lương bám sát CSDL pay_period.
- Lọc theo từ khóa, trạng thái và khoảng thời gian.
- Hỗ trợ CRUD và kiểm tra trùng mã trước khi lưu.

## Bố cục & hành vi
- Header: tiêu đề + nút Thêm/Sửa/Xóa.
- Bộ lọc: từ khóa, trạng thái, thời gian (Tất cả/Theo khoảng) + ngày bắt đầu/kết thúc.
- Bảng: Mã, Tên, Ngày bắt đầu, Ngày kết thúc, Giờ chuẩn, Trạng thái, Ghi chú.

## Logic chính
- Kiểm tra trùng mã (không phân biệt hoa thường) trước khi lưu.
- Validate ngày bắt đầu không lớn hơn ngày kết thúc.
- Tải dữ liệu qua KyLuongDataModel (Pay_PeriodService).
