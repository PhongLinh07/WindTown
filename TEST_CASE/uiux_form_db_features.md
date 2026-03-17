## Mục tiêu

Xác nhận các form Dự án, Phân công, Nghỉ phép, Ngày lễ kết nối CSDL và thực hiện CRUD đúng luồng.

## Tiền điều kiện

- Build solution thành công.
- Chuỗi kết nối trong `WindTown_VB/App.config` hợp lệ.
- CSDL có các bảng `project`, `assignment`, `leave`, `holiday` theo `db_json.sql`.

## Bước thực hiện

1. Mở form Dự án, kiểm tra lưới hiển thị dữ liệu từ `project`.
2. Thực hiện thêm một dự án mới, bấm `Lưu`, kiểm tra dữ liệu xuất hiện trên lưới.
3. Chọn một dự án, bấm `Sửa`, cập nhật dữ liệu, bấm `Lưu`.
4. Chọn một dự án, bấm `Xóa`, xác nhận xóa.
5. Mở form Phân công, kiểm tra lưới hiển thị dữ liệu từ `assignment`.
6. Thực hiện thêm/sửa/xóa một bản ghi phân công như các bước 2-4.
7. Mở form Nghỉ phép, kiểm tra lưới hiển thị dữ liệu từ `leave`.
8. Thực hiện thêm/sửa/xóa một bản ghi nghỉ phép như các bước 2-4.
9. Mở form Ngày lễ, kiểm tra lưới hiển thị dữ liệu từ `holiday`.
10. Thực hiện thêm/sửa/xóa một bản ghi ngày lễ như các bước 2-4.
11. Thu nhỏ form Nghỉ phép và xác nhận không còn lỗi `SplitterDistance`.

## Kết quả mong đợi

- Các lưới dữ liệu hiển thị đúng nội dung từ CSDL.
- Luồng thêm/sửa/xóa cập nhật lại dữ liệu sau khi thao tác.
- Không xuất hiện lỗi `SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize`.

## Kết quả thực tế

- Đã build thành công (Debug|Any CPU).
- Đã cập nhật chuỗi kết nối và mở ứng dụng để kiểm tra thủ công.
- Chưa thể ghi nhận kết quả CRUD vì cần thao tác UI trực tiếp.
