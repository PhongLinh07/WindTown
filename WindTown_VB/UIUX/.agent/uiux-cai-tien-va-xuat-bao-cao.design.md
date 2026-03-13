## Mục tiêu thiết kế (2026-03-13)
- Chuẩn hóa thông báo, trạng thái loading, định dạng hiển thị ngày/giờ/số cho UI.
- Tạo module xuất báo cáo dùng chung, ưu tiên xuất từ dữ liệu đang hiển thị trên UI.
- Giảm rủi ro bằng cách bổ sung theo từng form, không refactor lớn.

## Quyết định chính
- Tạo 4 module dùng chung trong `UIUX/Modules`: `UiThongBao`, `UiTrangThai`, `UiDinhDang`, `BaoCaoXuat`.
- Xuất báo cáo dạng CSV bằng `SaveFileDialog`, không phụ thuộc backend.
- Áp dụng định dạng ngày/giờ/số qua `UiDinhDang` cho các cột phù hợp.
- Chỉ chỉnh sửa trong `UIUX/`, không thay đổi backend/API.

## Ghi chú triển khai
- Form có sẵn nút báo cáo: dùng lại và nối tới `BaoCaoXuat`.
- Form chưa có nút: thêm nút xuất ở khu vực header nếu phù hợp bố cục.
