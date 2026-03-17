## Why

Một số form UIUX vừa thay đổi đang phát sinh lỗi `System.ArgumentNullException` do `container` bị null trong Designer, gây crash khi chạy. Đồng thời cần có hướng dẫn cấu hình WinAppDriver để hỗ trợ kiểm thử UI tự động.

## What Changes

- Sửa lỗi `ArgumentNullException` liên quan tới `components`/`container` trong các file Designer đã chỉnh sửa.
- Rà soát và khắc phục các lỗi/khác thường trong các file `.Designer.vb` đã thay đổi.
- Bổ sung hướng dẫn cấu hình WinAppDriver để chạy kiểm thử UI.

## Capabilities

### New Capabilities
- `uiux-designer-safety`: Chuẩn hóa khởi tạo `components` trong Designer để tránh lỗi container null.
- `winappdriver-setup-guidance`: Hướng dẫn cấu hình WinAppDriver phục vụ kiểm thử UI.

### Modified Capabilities
- `<existing-name>`: <what requirement is changing>

## Impact

- UIUX/frmChamCong.Designer.vb
- UIUX/frmKyLuong.Designer.vb
- UIUX/frmTinhLuong.Designer.vb
- Tài liệu hướng dẫn vận hành WinAppDriver (trong phản hồi và log .agent nếu cần)
