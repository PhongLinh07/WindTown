# Design frmChamCong

## Mục tiêu
- Kết nối dữ liệu chấm công từ DB và hiển thị trong DataGridView.
- Lọc theo trạng thái, ca làm, nhân viên, khoảng ngày và từ khóa.
- Phân trang 10 nhân viên/trang.
- Hỗ trợ thêm/sửa/xóa chấm công bám sát CSDL.
- Hỗ trợ xuất báo cáo (placeholder), chuẩn hóa font Microsoft YaHei UI.
- Thiết kế lại bố cục và màu sắc cho giao diện dễ nhìn hơn.

## Phân tích UI hiện tại
- Có bộ lọc ngày, trạng thái, ca làm, nhân viên và ô tìm kiếm nhưng chưa có logic.
- DataGridView chưa bám sát cấu trúc bảng attendance.

## Đề xuất bám sát CSDL
- Cột hiển thị: Mã chấm công, Nhân viên, Ngày chấm công, Ca làm, Giờ hành chính, Giờ tăng ca, Giờ đi muộn, Giờ về sớm, Trạng thái, Ghi chú.
- Bộ lọc:
  - Trạng thái (status_Dict) + “Tất cả”.
  - Ca làm (shift_Dic) + “Tất cả”.
  - Nhân viên (employee id) + “Tất cả”.
  - Thời gian: “Tất cả” hoặc “Theo khoảng”.
  - Từ khóa theo mã/nhân viên/ghi chú.
- Phân trang: 10 dòng/trang, nút Trang trước/Trang sau, hiển thị số trang.

## Bố cục & màu sắc đề xuất
- Header nền xanh đậm, chữ trắng, khu vực phân trang nằm bên phải.
- Nút hành động (Thêm/Sửa/Xóa) nằm giữa header.
- Khu lọc nền trắng, khoảng đệm thoáng hơn.
- Nút hành động màu theo mục đích:
  - Thêm: xanh lá.
  - Sửa: vàng.
  - Xóa: đỏ.
  - Tìm kiếm: xanh dương.
  - Làm mới: xám xanh.
  - Xuất báo cáo: xanh ngọc.
- DataGridView nền trắng, lưới xám nhạt.
- Nền tổng thể xám nhạt để tách lớp nội dung.

## Model kết nối riêng cho frmChamCong
- ChamCongDataModel (trong `frmChamCong.vb`).
- Sử dụng AttendanceService + EmployeeService.
- Hàm: TaiDanhSachChamCong, TaiDanhSachNhanVien, TaoChamCong, CapNhatChamCong, XoaChamCong.

## Kịch bản người dùng
- Mở form:
  - Fail-case: DB không kết nối -> khóa UI + thông báo.
  - Pass-case: tải danh sách chấm công.
- Lọc dữ liệu: chọn trạng thái/ca làm/nhân viên/thời gian -> bảng cập nhật.
- Tìm kiếm: nhập từ khóa -> bảng cập nhật.
- Phân trang: bấm Trang trước/Trang sau để xem 10 dòng mỗi trang.
- Thêm chấm công: bấm “Thêm” -> nhập dữ liệu -> Lưu.
- Sửa chấm công: chọn 1 dòng -> bấm “Sửa” -> cập nhật -> Lưu.
- Xóa chấm công: chọn 1+ dòng -> bấm “Xóa” -> xác nhận.
- Xuất báo cáo: chọn dòng -> bấm “Xuất báo cáo” (placeholder).

## Ghi chú
- Không chỉnh sửa backend.
- Font được chuẩn hóa bằng HoTroPhongChu (Microsoft YaHei UI).

## Bổ sung thiết kế (lọc nhanh & báo cáo)
- Thêm bộ lọc nhanh theo tháng/quý: “Không áp dụng”, “Tháng này”, “Tháng trước”, “Quý này”, “Quý trước”, “Năm nay”.
- Khi chọn lọc nhanh, tự chuyển về “Theo khoảng” và cập nhật DateTimePicker.
- Tách “Báo cáo” ra menu phụ với các mục: Xuất theo bộ lọc, Xuất theo lựa chọn, Tổng hợp tháng/quý.

## Bổ sung logic dữ liệu
- Kiểm tra trùng mã chấm công trước khi lưu (so sánh không phân biệt hoa thường).
- Khi sửa, bỏ qua kiểm tra trùng với chính bản ghi hiện tại.
