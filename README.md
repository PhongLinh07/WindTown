# WindTown (VB.NET WinForms)

## 1. Tổng quan
- Ứng dụng quản lý nhân sự, tổ chức, vận hành, lương (WinForms VB.NET).
- Dữ liệu lưu trên SQL Server, DB mặc định: `wind_town`.

## 2. Yêu cầu môi trường
- Windows
- .NET Framework 4.8 (project `WindTown_VB`)
- SQL Server cục bộ (ưu tiên): `.`, `localhost`, `.\SQLEXPRESS`, `(local)`

## 3. Cách chạy nhanh
- Chạy file exe debug: `WindTown_VB\bin\Debug\WindTown_VB.exe`
- Hoặc mở `WindTown_VB.sln` bằng Visual Studio và Run.

## 4. Build
### 4.1 Build bằng dotnet
Trong môi trường build tự động, nên set:
- `DOTNET_CLI_HOME` trỏ về thư mục có quyền ghi (ví dụ: `.dotnet_home` trong repo)
- `DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1`

Ví dụ:
```powershell
$env:DOTNET_CLI_HOME = "D:\FTC\Visual_BasicNet\WindTown\.dotnet_home"
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = "1"

dotnet build "D:\FTC\Visual_BasicNet\WindTown\WindTown_VB.sln" -v minimal
```

### 4.2 Lưu ý resource (resx)
Project có nhiều `resx` chứa ảnh/icon. Khi build bằng SDK mới, MSBuild yêu cầu:
- `GenerateResourceUsePreserializedResources=true`
- Có reference `System.Resources.Extensions`

Repo đã thêm:
- DLL: `WindTown_VB\lib\System.Resources.Extensions\net472\System.Resources.Extensions.dll`
- Reference + property trong `WindTown_VB\WindTown_VB.vbproj`

## 5. Luồng chạy chính
### 5.1 Điểm vào (Startup)
- Startup object: `WindTown_VB.My.MyApplication`
- MainForm hiện tại: `Developer_Mode`

### 5.2 Developer_Mode
- Khi load: gọi `DatabaseBootstrapService.EnsureReady()` để đảm bảo DB sẵn sàng.
- Có 2 nhánh:
  - `Backend`: mở `FormMain` (tab-based UI cổ điển).
  - `Frontend`: mở `frmLogin` (UIUX mới).

### 5.3 Frontend (UIUX)
1. `frmLogin`
   - Khi load: bootstrap DB, sau đó load danh sách account.
   - Login OK: chuyển top-level sang `frmMain`.
2. `frmMain`
   - Gọi `NavigationService.Initialize(Me, pnlMain)`.
   - Navigate mặc định: `frmDashboard`.
   - Alt+Left: quay lại màn trước (history) trong vùng `pnlMain`.
3. `ucSidebar`
   - Tạo menu động từ `MenuItemModel`.
   - Click menu: `NavigationService.NavigateInMain(...)` để nhúng form vào `pnlMain`.

### 5.4 Logout
- `frmDashboard` có menu “Đăng xuất” -> `NavigationService.LogoutToLogin()`.
- `NavigationService` đóng `frmMain` theo cơ chế không thoát ứng dụng trong luồng logout.

## 6. Database bootstrap
- File script: `WindTown_VB\1_Documents\db_json.sql`
- `DatabaseBootstrapService`:
  - Tự tạo DB `wind_town` nếu chưa có.
  - Tự chạy script nếu DB thiếu schema.
  - Ghi log: `logs\db_bootstrap.log` dưới `AppDomain.CurrentDomain.BaseDirectory`.

## 7. Chức năng đã cập nhật
### 7.1 frmNhanSu: Nhập/Xuất nhân sự
- Nút `btnNhapXuatNV` hiển thị menu:
  - “Nhập danh sách Excel”: đọc `.xlsx/.xls` (OleDb ACE/JET) hoặc `.csv`.
  - “Xuất Excel (bảng ô)”: xuất `.xls` dạng HTML table có border.
- Logic nằm ở:
  - UI: `WindTown_VB\UIUX\frmNhanSu.vb`
  - Helper: `WindTown_VB\UIUX\Modules\EmployeeExcelTransfer.vb`
- Quy ước import tối thiểu:
  - Bắt buộc: `code` (mã NV), `name` (tên NV)
  - Tùy chọn: `email`, `phone`, `gender`, `status`, `birth_date`, `address`, `cccd`, `bank`, `note`

Ghi chú:
- Import hiện chỉ cập nhật bảng `employee` (chưa tự tạo/đổi `job/position` vì cần quy ước thêm).
- Đọc Excel phụ thuộc driver ACE/JET trên máy.

### 7.2 frmChucVu: Quản lý chức vụ (Job)
- `frmChucVu` hiển thị TreeView theo Bộ phận -> Job.
- Hỗ trợ:
  - Thêm: mở `Job_CRUD_Frm` (tạo mới) -> `JobService.Insert`.
  - Sửa: double click / menu -> `Job_CRUD_Frm` -> `JobService.Update`.
  - Xóa: menu -> `JobService.SoftDeleteMany`.
- File: `WindTown_VB\UIUX\frmChucVu.vb`

## 8. Cấu trúc thư mục
- `WindTown_VB\2_Core`: base/entity/service, utils, database config, base forms.
- `WindTown_VB\3_Modules`: domain modules (Organization/HR/Operations/Payroll/System).
- `WindTown_VB\UIUX`: luồng UI mới (frmLogin/frmMain/ucSidebar/NavigationService...).
- `packages`: thư viện NuGet kiểu `packages.config`.

## 9. Mở rộng về sau
- Thêm màn hình mới vào sidebar:
  - Cập nhật `BuildMenuData()` trong `WindTown_VB\UIUX\control\ucSidebar.vb`.
  - Form mới nên có `Public Sub New()` không tham số để `Activator.CreateInstance` hoạt động.
- Thêm intent/service:
  - Mở rộng `DataIntent` và implement trong `BaseService`/Service cụ thể.

## 10. Thông tin cần xác nhận (để hoàn thiện import/export)
- File Excel import bạn muốn theo mẫu cột nào (tên cột tiếng Việt/tiếng Anh)?
- Khi trùng `code`, ưu tiên Update toàn bộ hay chỉ update các cột có giá trị?
- Có cần import luôn bộ phận/chức vụ (Job/Position) theo Excel không?
