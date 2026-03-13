## Lỗi đã gặp (2026-03-13)
- Lỗi mã hóa tiếng Việt bị thành ký tự `?` do dùng `Set-Content` không kèm `-Encoding utf8`.
- Cách tránh: luôn dùng `Set-Content -Encoding utf8` khi ghi file có tiếng Việt.
- Build lỗi do module mới không được compile (vbproj không include). Khắc phục bằng cách gộp module vào UIUX/Modules/NavigationService.vb để được compile.
