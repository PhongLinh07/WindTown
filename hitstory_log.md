## 2026-03-16

- Rà soát lỗi runtime `System.IO.FileLoadException` tại `frmLogin`.
- Thêm bindingRedirect cho `System.Resources.Extensions` trong `WindTown_VB/App.config`.
- Tạo test case kiểm tra mở `frmLogin` sau khi build.
- Build `WindTown_VB.sln` (Debug|Any CPU) thành công.
## 2026-03-16

- Triển khai form mới: frmDuAn, frmPhanCong, frmNghiPhep, frmNgayLe, frmChinhSach.
- Thiết kế lại frmBangLuong theo luồng bảng lương -> khoản tiền.
- Bổ sung menu cho Dự án, Nghỉ phép, Ngày lễ, Chính sách.
- Tạo test case cho menu form mới và frmBangLuong.
- Build `WindTown_VB.sln` (Debug|Any CPU) thành công sau khi cập nhật form.
## 2026-03-16

- Thiết kế lại UIUX cho frmDuAn, frmPhanCong, frmNghiPhep, frmNgayLe, frmBangLuong theo phong cách chuyên nghiệp.
- Gỡ frmLuong khỏi menu lương trong ucSidebar.
- Thêm module cấu hình hệ thống trong UIUX và tích hợp lưu/kiểm tra kết nối DB cho frmSystem.
- Bổ sung `connectionStrings` và `appSettings` trong `WindTown_VB/App.config`.
- Build `WindTown_VB.sln` (Debug|Any CPU) thành công sau khi đóng tiến trình khóa file.
## 2026-03-16

- Hoàn tất change fallback module cho frmSystem trong UIUX/Modules.
- Tạo test case `uiux_fallback_module.md`.
## 2026-03-16

- Đồng bộ spec từ change uiux-redesign-form-system vào `openspec/specs`.
- Archive change uiux-redesign-form-system.
## 2026-03-16

- Đồng bộ spec từ change uiux-fallback-module-method vào `openspec/specs`.
- Archive change uiux-fallback-module-method.
## 2026-03-16

- Bổ sung `frmDuAn.resx`, `frmPhanCong.resx`, `frmNghiPhep.resx`, `frmNgayLe.resx` và khai báo trong `WindTown_VB.vbproj`.
- Điều chỉnh xử lý `SplitterDistance` khi resize trong `frmNghiPhep`.
- Tạo test case `uiux_form_db_features.md` và build `WindTown_VB.sln` (Debug|Any CPU) thành công.
## 2026-03-16

- Cập nhật `WindTown_VB/App.config` với chuỗi kết nối `wind_town` và mở ứng dụng để kiểm thử thủ công.
## 2026-03-16

- Thêm `NguoiDungHienTaiService` và `ThongTinHeThongService`, tự động hiển thị CSDL/tài khoản trên các form mục tiêu.
- Đồng bộ định dạng DataGridView theo chuẩn `frmChamCong` cho Dự án/Phân công/Nghỉ phép/Ngày lễ.
- Sửa clamp SplitterDistance trong `frmBangLuong` và khóa thao tác chỉnh sửa theo quyền.
- Build `WindTown_VB.sln` (Debug|Any CPU) thành công.
## 2026-03-16

- Đồng bộ spec của change `uiux-form-db-features` vào `openspec/specs`.
- Archive change `uiux-form-db-features`.
## 2026-03-16

- Gỡ chặn quyền chỉnh sửa ở form Dự án/Phân công/Nghỉ phép/Ngày lễ và thêm cột tích chọn cho lưới dữ liệu.
- Bổ sung sự kiện cập nhật trạng thái khi tick quyền trong form Cài đặt.
## 2026-03-16

- Chuẩn hóa lưới dữ liệu có cột tích chọn và bỏ chặn quyền sửa theo yêu cầu mới.
- Build `WindTown_VB.sln` (Debug|Any CPU) thành công sau cập nhật.
## 2026-03-16

- Rà soát và loại bỏ tham chiếu `frmBangLuong` khỏi menu và project file.
- Tạo test case `remove_frmbangluong_refs.md` để kiểm tra không còn trỏ tới `frmBangLuong`.
## 2026-03-16

- Bổ sung clamp `SplitterDistance` khi resize và khi form hiển thị cho frmDuAn, frmPhanCong, frmNghiPhep, frmNgayLe để tránh lỗi runtime.
