## Mục tiêu
- Rà soát và cải thiện UI/UX, đặc biệt các luồng frontend (UIUX).
- Đảm bảo luồng dữ liệu và hành vi tìm kiếm/CRUD ổn định.

## Quy ước
- Luôn ghi log thay đổi vào mục **Log thay đổi** sau mỗi lần cập nhật.
- Ưu tiên kiểm tra lỗi tiềm ẩn trong các luồng tìm kiếm/lọc/danh sách.
- Sử dụng UTF-8 cho những thay đổi liên quan đến hiển thị (đặc biệt tiếng Việt) để tránh lỗi font.
- Chỉ tham chiếu không trực tiếp thay đổi nội dung trong 1_Documents, 2_Core, 3_Modules
- Khi UIUX cần gì hãy tạo mới hoặc chỉnh sửa ngay trong UIUX

## Tiến trình
### Đã làm
- Đọc `README.md` để bám theo hướng dẫn chạy/build.
- Thêm nút Sửa/Xóa cho `frmChucVu` và tự căn chỉnh theo header.
- Tăng tính hiển thị cho nút Lưu/Hủy ở `frmHopDongEdit` (Accept/Cancel + padding).
- Chuyển build sang `dotnet build` do không tìm thấy `msbuild.exe`.
- Triển khai UI chấm công: lọc, danh sách, thêm/sửa/xóa, form chi tiết.
- Bổ sung form `frmChamCongEdit` và build lại sau khi chỉnh layout.
- Sửa hiển thị nút Lưu/Hủy của `frmHopDongEdit`.
- Bổ sung logic `btnEdit` trong `frmHopDong`.
- Ẩn hiển thị `code` của nhân viên/phòng ban ở các danh sách UI (trừ màn chi tiết).
- Ẩn `code` trong các combobox nhân viên/phòng ban ở UIUX và module cũ.
- Build thành công với `dotnet build` (0 warnings/errors).

### Đang làm
- Rà soát toàn bộ luồng UIUX (tìm kiếm/lọc/CRUD), ghi nhận lỗi tồn tại hoặc tiềm ẩn.

### Sắp làm
- Nếu cần, triển khai/chuẩn hóa xuất báo cáo chấm công theo định dạng cụ thể.

## Sự cố / Hạn chế
- Không tìm thấy `msbuild.exe` trong `C:\Program Files (x86)\`, hiện dùng `dotnet build`.
- Môi trường hiện tại không thể attach/debug qua Visual Studio trực tiếp.

## Log thay đổi
### 2026-03-11
- Build: `dotnet build d:\FTC\Visual_BasicNet\WindTown\WindTown_VB.sln` thành công.
- Ẩn hiển thị `code` trong các list view/grid và combobox (nhân viên/phòng ban) ở UIUX và module cũ.
- Dashboard: hiển thị top check-in theo tên nhân viên (không kèm code).
- `frmHopDong`: bổ sung xử lý `btnEdit`.
- `frmHopDong`: bổ sung handler lọc theo `cbbxThoiGianHD` và `dtpkDenNgay`.

## Gợi ý UI/UX chấm công (dựa trên bảng attendance)
- Bộ lọc: khoảng ngày (từ/đến), ca làm (Dict_Shift), trạng thái, nhân viên.
- Cột hiển thị: Nhân viên, Ngày chấm công, Ca làm, Giờ hành chính, Tăng ca, Đi muộn, Về sớm, Trạng thái, Ghi chú.
- Nút thao tác: Thêm mới, Sửa, Xóa, Xuất báo cáo.
- Hành vi: click dòng mở form chi tiết; double click để sửa nhanh.
- Ràng buộc: ngày chấm công không vượt khoảng lọc; giờ hành chính/tăng ca/đi muộn/về sớm không âm.
- Gợi ý nâng cấp: tổng hợp theo nhân viên trong khoảng ngày (sum giờ hành chính/tăng ca), cảnh báo đi muộn/về sớm vượt ngưỡng.
