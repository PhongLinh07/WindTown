## Why

Hiện có nhiều lỗi hiển thị chữ tiếng Việt bị sai dấu và font không thống nhất trên UI, gây khó đọc và giảm trải nghiệm người dùng. Cần xử lý sớm để đồng bộ hiển thị và tránh lỗi ký tự phát sinh thêm khi chỉnh sửa.

## What Changes

- Rà soát toàn bộ UIUX để tìm và sửa lỗi hiển thị chữ tiếng Việt (mojibake, dấu bị mất, ký tự lạ).
- Chuẩn hóa font hiển thị cho các form theo một chuẩn thống nhất.
- Cập nhật tài liệu và bộ test để phản ánh các chỉnh sửa liên quan đến font/hiển thị.

## Capabilities

### New Capabilities
- `chuan-hoa-font-chu`: Chuẩn hóa font và sửa lỗi hiển thị tiếng Việt trên UI.

### Modified Capabilities
- (Không có)

## Impact

- Thư mục UIUX: chỉnh sửa text hiển thị và font trên các form/designer liên quan.
- Không thay đổi backend hay API công khai.
