## Tiến trình
- Sửa lỗi UI liên quan đến nút Lưu/Hủy ở frmHopDongEdit.
- Dựa vào database đưa ra gợi ý về thiết kế giao diện chấm công cho phù hợp với dữ liệu hiện có.

### Đã làm
- Đọc OpenSpec.md theo yêu cầu.
- Đọc README.md để bám theo hướng dẫn chạy/build.
- Thêm nút Sửa/Xóa cho `frmChucVu` và tự căn chỉnh theo header.
- Tăng tính hiển thị cho nút Lưu/Hủy ở `frmHopDongEdit` (Accept/Cancel + padding).
- Tìm `msbuild.exe` trong `C:\Program Files (x86)\` (không thấy) và chuyển sang build bằng `dotnet`.
- Thực hiện test failing trước (build với file .sln không tồn tại) rồi test passing với `dotnet build`.
- Triển khai UI chấm công: lọc, danh sách, thêm/sửa/xóa, form chi tiết.
- Bổ sung form `frmChamCongEdit` và build lại sau khi chỉnh layout.
- Test failing/passing lại sau khi cập nhật UI chấm công.
- Khắc phục hiển thị nút Lưu/Hủy của `frmHopDongEdit`.
- Test failing/passing sau khi sửa `frmHopDongEdit`.

### Đang làm
- Hoàn tất rà soát nhanh UI chấm công sau khi build.

### Sắp làm
- Nếu bạn muốn, triển khai xuất báo cáo chấm công theo định dạng cụ thể.

### Sự cố
- Không tìm thấy `msbuild.exe` trong `C:\Program Files (x86)\`, hiện dùng `dotnet build`.
- frmHopDongEdit: Chưa hiển thị nút được Lưu/Hủy (đã xử lý).


### Yêu cầu
- Luôn test tất cả failing trước khi test passing để đảm bảo tính ổn định của code.
- Luôn kiểm tra kỹ lưỡng các thay đổi UI để tránh ảnh hưởng đến trải nghiệm người dùng.
- Luôn chạy thử nghiệm trên môi trường staging trước khi deploy lên production để đảm bảo không có lỗi phát sinh.

## Gợi ý UI/UX chấm công (dựa trên bảng attendance)
- Bộ lọc: khoảng ngày (từ/đến), ca làm (Dict_Shift), trạng thái, nhân viên.
- Cột hiển thị: Mã chấm công, Nhân viên, Ngày chấm công, Ca làm, Giờ hành chính, Tăng ca, Đi muộn, Về sớm, Trạng thái, Ghi chú.
- Nút thao tác: Thêm mới, Sửa, Xóa, Xuất báo cáo.
- Hành vi: click dòng mở form chi tiết; double click để sửa nhanh.
- Ràng buộc: ngày chấm công không vượt khoảng lọc; giờ hành chính/tăng ca/đi muộn/về sớm không âm.
- Gợi ý nâng cấp: tổng hợp theo nhân viên trong khoảng ngày (sum giờ hành chính/tăng ca), cảnh báo đi muộn/về sớm vượt ngưỡng.
