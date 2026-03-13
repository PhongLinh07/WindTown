# Progress frmChamCong

## 2026-03-12
- Mục tiêu: kết nối DB, hiển thị chấm công, bổ sung lọc và chuẩn hóa font.
- Phạm vi: UIUX/frmChamCong.vb, UIUX/frmChamCong.Designer.vb.
- Đã tạo model kết nối riêng trong frmChamCong.vb.
- Đã cấu hình DataGridView và bộ lọc theo CSDL.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-12 (bổ sung)
- Mục tiêu: khắc phục lưới rỗng do lọc ngày và phân trang 10 dòng/trang.
- Phạm vi: UIUX/frmChamCong.vb, UIUX/frmChamCong.Designer.vb.
- Đã thêm bộ lọc thời gian “Tất cả/Theo khoảng”.
- Đã thêm phân trang, nút Trang trước/Trang sau và nút Làm mới.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-12 (bổ sung 2)
- Mục tiêu: thiết kế lại bố cục và màu sắc giao diện.
- Phạm vi: UIUX/frmChamCong.Designer.vb.
- Đã đổi màu header, nền tổng thể, DataGridView và các nút thao tác.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-12 (bổ sung 3)
- Mục tiêu: thêm CRUD chấm công và mapping control bám CSDL.
- Phạm vi: UIUX/frmChamCong.vb, UIUX/frmChamCong.Designer.vb.
- Đã thêm nút Thêm/Sửa/Xóa trên header.
- Đã thêm dialog nhập liệu và logic tạo/sửa/xóa.
- Đã gắn lại đầy đủ Handles cho các sự kiện filter và nút thao tác.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-12 (bổ sung 4)
- Mục tiêu: thêm lọc nhanh tháng/quý, tách báo cáo khỏi CRUD, kiểm tra trùng mã trước khi lưu.
- Phạm vi: UIUX/frmChamCong.vb, UIUX/frmChamCong.Designer.vb.
- Đã thêm bộ lọc nhanh và hành vi map khoảng ngày.
- Đã chuyển “Báo cáo” sang menu phụ với các tuỳ chọn xuất.
- Đã bổ sung kiểm tra trùng mã chấm công khi tạo/sửa.
- Đã chuẩn hóa text UI có dấu và làm sạch file logic.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-13
- Mục tiêu: sửa lỗi `ArgumentNullException` do container null trong Designer.
- Phạm vi: UIUX/frmChamCong.Designer.vb.
- Đã khởi tạo `components` trước khi tạo `ContextMenuStrip`.
