## Rà soát CSDL và gợi ý chức năng (2026-03-13)

### Nguồn dữ liệu
- Tài liệu `1_Documents/db_json.sql` có các bảng: `project`, `assignment`, `leave_cat`, `leave`, `holiday`, `policy`, `pay_item`, `account`, `salary_mult`, `level`.

### Gợi ý chức năng có thể triển khai thêm (chưa thực hiện)
1. Quản lý dự án và phân công
- Form đề xuất: `frmDuAn`, `frmPhanCong`.
- Dữ liệu: `project`, `assignment`.
- Nghiệp vụ: tạo dự án, gán nhân viên, theo dõi tiến độ và trạng thái.

2. Quản lý nghỉ phép và duyệt phép
- Form đề xuất: `frmNghiPhep`, `frmDanhMucNghi`.
- Dữ liệu: `leave_cat`, `leave`.
- Nghiệp vụ: tạo đơn nghỉ, duyệt/ từ chối, thống kê theo tháng/quý.

3. Lịch nghỉ lễ
- Form đề xuất: `frmNgayLe`.
- Dữ liệu: `holiday`.
- Nghiệp vụ: thêm ngày lễ, đồng bộ vào chấm công và tính lương.

4. Chính sách và khoản lương
- Form đề xuất: `frmChinhSachLuong`, `frmKhoanLuong`.
- Dữ liệu: `policy`, `pay_item`.
- Nghiệp vụ: cấu hình khoản cộng/trừ, hệ số áp dụng.

5. Quản lý hệ số theo cấp bậc
- Form đề xuất: `frmHeSoLuong`.
- Dữ liệu: `level`, `salary_mult`.
- Nghiệp vụ: khai báo bậc, hệ số lương, ánh xạ theo job/level.

6. Quản lý tài khoản và phân quyền nâng cao
- Form đề xuất: mở rộng `frmSystem`.
- Dữ liệu: `account`.
- Nghiệp vụ: phân vai trò, khóa/mở tài khoản, nhật ký thao tác.

### Ghi chú
- Đây là đề xuất dựa trên CSDL, chỉ triển khai khi bạn xác nhận.
