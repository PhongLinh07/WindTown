## Mục tiêu thiết kế (2026-03-13)
- Sửa lỗi hiển thị tiếng Việt bị sai dấu trong UIUX.
- Chuẩn hóa font hiển thị bằng `HoTroPhongChu` trên tất cả form.
- Đảm bảo file được lưu UTF-8 để tránh tái phát lỗi.

## Quyết định chính
- Ưu tiên sửa tại UIUX, không động vào backend.
- Với form chưa áp dụng font, thêm `HoTroPhongChu.ApDungPhongChu(Me)` ở `MyBase.Load`.
- Với text bị lỗi ký tự, chỉnh trực tiếp trong file và lưu UTF-8.
