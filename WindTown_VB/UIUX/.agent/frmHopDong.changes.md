# Changes frmHopDong

## 2026-03-12
- Thay dữ liệu demo bằng dữ liệu từ ContractService.
- Đổi cột DataGridView bám sát CSDL Contract.
- Thêm dialog CRUD mới (không kế thừa backend).
- Thêm HopDongDataModel trong UIUX/Modules.
- Bổ sung trạng thái "Tất cả" trong bộ lọc.
- Chuyển các nút Thêm/Sửa/Xóa/Xuất/Sửa hàng loạt lên header.
- Loại bỏ 3 cột hành động trong DataGridView.
- Thêm bộ lọc theo phòng ban (map hợp đồng -> phòng ban).
- Chuẩn hóa text UI có dấu và đặt lại tiêu đề form bằng code.
- Áp dụng font Microsoft YaHei UI cho dialog thêm/sửa và sửa hàng loạt.
- Đặt module áp dụng font trong UIUX/Modules/NavigationService.vb để tránh lỗi build.
- Chuẩn hóa chuỗi hiển thị trong Designer về ASCII để tránh lỗi mã hóa.
