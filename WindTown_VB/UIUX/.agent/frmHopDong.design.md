# Design frmHopDong

## Mục tiêu
- Kết nối dữ liệu hợp đồng từ DB và hiển thị trong DataGridView.
- Lọc/tìm kiếm theo từ khóa, trạng thái, phòng ban, khoảng thời gian.
- Thêm/Sửa/Xóa hợp đồng bằng giao diện mới (không kế thừa backend).
- Hỗ trợ sửa hàng loạt các trường chung khi cần.

## Phân tích UI hiện tại
- Có nhiều bộ lọc (Bộ phận, Loại hợp đồng, Hợp đồng, Công ty) nhưng DB Contract không có các trường này.
- DataGridView đang có nhiều cột không khớp CSDL.

## Đề xuất bám sát CSDL
- Đổi cột theo DB: Mã hợp đồng, Nhân viên, Ngày bắt đầu, Ngày kết thúc, Lương cơ bản, Trạng thái, Ghi chú.
- Bố trí nút hành động trên header: Thêm/Sửa/Xóa/Xuất/Sửa hàng loạt.
- Loại bỏ các cột nút hành động trong DataGridView.
- Bộ lọc thực tế:
  - Tìm kiếm theo mã/nhân viên/ghi chú.
  - Lọc theo trạng thái.
  - Lọc theo phòng ban (map hợp đồng -> phòng ban).
  - Lọc theo khoảng ngày khi chọn "Theo khoảng".
- Chuẩn hóa text UI tiếng Việt có dấu; dùng Microsoft YaHei UI.

## Model kết nối riêng cho frmHopDong
- HopDongDataModel (UIUX/Modules) dùng ContractService + EmployeeService.
- Bổ sung LoadDepartments và LoadContractDepartmentMap.

## Kịch bản người dùng
- Mở form:
  - Fail-case: DB không kết nối -> khóa UI + thông báo.
  - Pass-case: tải danh sách hợp đồng.
- Tìm kiếm: nhập từ khóa -> bấm Tìm.
- Lọc trạng thái/phòng ban/thời gian: chọn bộ lọc -> bảng cập nhật.
- Thêm hợp đồng: bấm "Thêm hợp đồng" -> nhập thông tin -> Lưu.
- Sửa hợp đồng: chọn checkbox 1 dòng -> bấm "Sửa" -> cập nhật -> Lưu.
- Sửa hàng loạt: chọn nhiều dòng -> bấm "Sửa hàng loạt" -> chọn trường cần cập nhật -> Lưu.
- Xóa hợp đồng: chọn 1+ dòng -> bấm "Xóa" -> xác nhận.
- Xuất hợp đồng: chọn 1+ dòng -> bấm "Xuất" (placeholder).

## Ghi chú
- Không chỉnh sửa backend, chỉ tham chiếu giao thức ContractService/EmployeeService.
- Bộ lọc trạng thái có thêm "Tất cả".
