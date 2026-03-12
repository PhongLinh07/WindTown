# Design frmPhongBan

## Muc tieu
- Quan ly phong ban va cong viec (department + job).
- Hien thi du lieu dang tree: Department -> Job.
- Ho tro them/sua/xoa theo nut btnThemPhongBan/btnSua/btnXoa.
- Hien thi mo ta phong ban (note) ben panel phai.

## Pham vi file
- UIUX/frmPhongBan.vb
- UIUX/frmPhongBan.Designer.vb (khong sua)

## UI/UX
- Header: btnThemPhongBan, btnSua, btnXoa.
- Body: tim kiem + TreeView (tvChucVu).
- Panel phai: mo ta phong ban (Label2).

## Hien thi du lieu
- Node cha: Department (code - name).
- Node con: Job (code - name).
- Loc theo tu khoa: hien department neu dept match hoac co job match.

## Thao tac nguoi dung
- Them:
  - Neu khong chon node -> them Department.
  - Neu dang chon Department/Job -> them Job thuoc Department.
- Sua:
  - Chon node Department/Job -> sua tuong ung.
- Xoa:
  - Chon node Department/Job -> xoa tuong ung.
- Tim kiem: nhap tu khoa -> Enter hoac nut Tim.

## Giao dien CRUD (moi, trong UIUX)
- Department: code, name, status, note.
- Job: code, name, department, status, note.
