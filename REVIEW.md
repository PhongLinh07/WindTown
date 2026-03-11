# Review dự án WindTown (VB.NET WinForms)

## 1. Tổng quan nhanh
- Ứng dụng quản lý nhân sự, tổ chức, vận hành và lương viết bằng VB.NET WinForms.
- Dữ liệu lưu trên SQL Server, DB mặc định `wind_town`.
- Hướng chạy: mở `WindTown_VB.sln` bằng Visual Studio hoặc chạy trực tiếp `WindTown_VB\bin\Debug\WindTown_VB.exe`.

## 2. Công nghệ và yêu cầu môi trường
- Windows + .NET Framework 4.8.
- SQL Server local (ưu tiên các instance: `.`, `localhost`, `.\SQLEXPRESS`, `(local)`).
- Build tự động qua `dotnet build` cần cấu hình `DOTNET_CLI_HOME` và `DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1`.
- Resource `.resx` dùng `System.Resources.Extensions` (DLL đã đặt ở `WindTown_VB\lib\System.Resources.Extensions\net472\System.Resources.Extensions.dll`).

## 3. Cấu trúc thư mục chính
- `WindTown_VB\2_Core`: base/entity/service, utils, database config, base forms.
- `WindTown_VB\3_Modules`: các module domain (Organization/HR/Operations/Payroll/System).
- `WindTown_VB\UIUX`: luồng UI mới (frmLogin/frmMain/ucSidebar/NavigationService...).
- `WindTown_VB\1_Documents`: script DB (`db_json.sql`).
- `packages`: NuGet theo `packages.config`.

## 4. Luồng chạy chính (theo README)
- Startup object: `WindTown_VB.My.MyApplication`.
- MainForm hiện tại: `Developer_Mode`.
- `Developer_Mode` gọi `DatabaseBootstrapService.EnsureReady()` để bootstrap DB.
- Nhánh Backend mở `FormMain` (UI tab truyền thống); nhánh Frontend mở `frmLogin` (UIUX mới).
- `frmMain` khởi tạo `NavigationService.Initialize(Me, pnlMain)` và mặc định vào `frmDashboard`.
- `ucSidebar` tạo menu động và điều hướng bằng `NavigationService.NavigateInMain(...)`.
- Logout qua `frmDashboard` gọi `NavigationService.LogoutToLogin()`.

## 5. Database bootstrap
- Script: `WindTown_VB\1_Documents\db_json.sql`.
- `DatabaseBootstrapService` tự tạo DB `wind_town` nếu chưa có, tự chạy script nếu thiếu schema.
- Log bootstrap ghi ở `logs\db_bootstrap.log` (theo `AppDomain.CurrentDomain.BaseDirectory`).

## 6. Chức năng/điểm nhấn gần đây (theo OpenSpec)
- UI chấm công đã được triển khai: lọc, danh sách, thêm/sửa/xóa, form chi tiết.
- Bổ sung form `frmChamCongEdit` và đã build lại sau khi chỉnh layout.
- Sửa hiển thị nút Lưu/Hủy ở `frmHopDongEdit` (Accept/Cancel + padding).
- `frmChucVu` có nút Sửa/Xóa và căn chỉnh theo header.

## 7. Lưu ý vận hành
- Import Excel ở `frmNhanSu` dùng driver ACE/JET, phụ thuộc cài đặt trên máy.
- Import nhân sự hiện chỉ cập nhật bảng `employee` (chưa tự tạo/đổi `job/position`).

## 8. Khoảng trống cần xác nhận
- Mẫu cột Excel import (tên cột VN/EN) và xử lý khi trùng `code`.
- Có cần import job/position từ Excel hay không.
- Quy chuẩn xuất báo cáo chấm công (format/fields) nếu cần triển khai tiếp.

## 9. Nguồn thông tin
- `README.md`
- `OpenSpec.md`
