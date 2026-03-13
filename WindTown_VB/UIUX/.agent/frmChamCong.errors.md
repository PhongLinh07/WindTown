# Errors frmChamCong

## 2026-03-12
- System.InvalidCastException: Conversion from type 'LuaChon(Of Integer)' to type 'Integer' is not valid.
  - Nguyên nhân: SelectedValue trả về đối tượng LuaChon khi binding chưa ổn định.
  - Cách xử lý: thêm hàm LayGiaTriBoLoc để đọc giá trị an toàn.
- Lỗi build BC30689 sau khi thêm pnlHanhDong vào Designer.
  - Nguyên nhân: khối khai báo control bị đặt ngoài InitializeComponent.
  - Cách xử lý: đưa khối pnlHanhDong/btnThêm/Sửa/Xóa vào trong InitializeComponent.
- Build Debug đã PASS sau khi sửa.

## 2026-03-13
- System.ArgumentNullException: Value cannot be null. Parameter name: container
  - Nguyên nhân: `components` chưa được khởi tạo trước khi tạo `ContextMenuStrip`.
  - Cách xử lý: thêm `Me.components = New System.ComponentModel.Container()` ở đầu `InitializeComponent`.
