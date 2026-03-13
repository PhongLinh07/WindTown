# Errors frmTinhLuong

## 2026-03-13
- System.ArgumentNullException: Value cannot be null. Parameter name: container
  - Nguyên nhân: `components` chưa được khởi tạo trước khi tạo `ContextMenuStrip`.
  - Cách xử lý: thêm `Me.components = New System.ComponentModel.Container()` ở đầu `InitializeComponent`.
