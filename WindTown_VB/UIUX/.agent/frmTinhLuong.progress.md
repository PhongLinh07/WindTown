# Progress frmTinhLuong

## 2026-03-12
- Mục tiêu: thiết kế UI + logic tính lương theo kỳ.
- Phạm vi: UIUX/frmTinhLuong.vb, UIUX/frmTinhLuong.Designer.vb, UIUX/Modules/TinhLuongDataModel.vb.
- Đã tạo giao diện mới với header, bộ lọc và bảng dữ liệu.
- Đã bổ sung logic lọc, tạo/đóng bảng lương, menu báo cáo.
- Đã chạy build Debug: PASS (0 warning, 0 error).

## 2026-03-13
- Mục tiêu: sửa lỗi `ArgumentNullException` do container null trong Designer.
- Phạm vi: UIUX/frmTinhLuong.Designer.vb.
- Đã khởi tạo `components` trước khi tạo `ContextMenuStrip`.
