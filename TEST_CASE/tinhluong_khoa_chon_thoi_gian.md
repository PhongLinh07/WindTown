## Mục tiêu

Khóa hai mục chọn thời gian trong form Tính lương khi bộ lọc thời gian chưa chọn "Theo khoảng thời gian".

## Tiền điều kiện

- Mã nguồn đã cập nhật logic khóa/mở `dtTuNgay` và `dtDenNgay`.

## Bước thực hiện

1. Chạy lệnh `rg -n "CapNhatTrangThaiThoiGian|dtTuNgay.Enabled|dtDenNgay.Enabled" -S WindTown_VB\\UIUX\\frmTinhLuong.vb`.

## Kết quả mong đợi

- Có hàm `CapNhatTrangThaiThoiGian` và các điểm gọi đảm bảo khóa/mở theo lựa chọn `cbbThoiGian`.

## Kết quả thực tế

- Đã thấy hàm và điểm gọi trong `frmTinhLuong.vb`.
