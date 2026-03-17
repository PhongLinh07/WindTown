## Context

- Các file `.Designer.vb` mới chỉnh sửa đang có nguy cơ thiếu `components` khiến `ContextMenuStrip` nhận `container = Nothing`.
- Người dùng đã cài WinAppDriver và muốn hướng dẫn cấu hình để hỗ trợ kiểm thử UI.
- Ràng buộc dự án: chỉ chỉnh sửa trong UIUX/, ghi log trong UIUX/.agent/.

## Goals / Non-Goals

**Goals:**
- Loại bỏ lỗi `ArgumentNullException` do `container` null trong Designer.
- Rà soát và chuẩn hóa các file Designer đã chỉnh sửa gần đây.
- Cung cấp hướng dẫn chạy WinAppDriver và kết nối kiểm thử UI.

**Non-Goals:**
- Không thay đổi backend hoặc API công khai.
- Không triển khai framework kiểm thử UI tự động đầy đủ trong repo.

## Decisions

- Khởi tạo `components` trong `InitializeComponent` trước khi tạo `ContextMenuStrip`.
- Kiểm tra các Designer đã chỉnh sửa: `frmChamCong`, `frmKyLuong`, `frmTinhLuong`.
- Hướng dẫn WinAppDriver bằng thao tác cài dịch vụ, mở port mặc định và xác nhận kết nối.

## Risks / Trade-offs

- [Rủi ro] UI vẫn lỗi do các control chưa được add đúng thứ tự → [Giảm thiểu] rà soát lại `InitializeComponent` và build lại.
- [Rủi ro] WinAppDriver bị chặn bởi quyền admin/firewall → [Giảm thiểu] hướng dẫn chạy với quyền admin và mở port `4723`.
