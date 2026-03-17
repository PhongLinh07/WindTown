## Mục tiêu

Xác nhận đã bổ sung clamp `SplitterDistance` cho các form có `splitNoiDung` để tránh lỗi runtime khi resize.

## Tiền điều kiện

- Có thể truy cập mã nguồn trong thư mục `WindTown_VB/UIUX`.

## Bước thực hiện

1. Kiểm tra `frmDuAn.vb` có đăng ký `splitNoiDung.SizeChanged` và xử lý `CapNhatSplitter`.
2. Kiểm tra `frmPhanCong.vb` có đăng ký `splitNoiDung.SizeChanged` và xử lý `CapNhatSplitter`.
3. Kiểm tra `frmNghiPhep.vb` có đăng ký `splitNoiDung.SizeChanged` và xử lý `CapNhatSplitter`.
4. Kiểm tra `frmNgayLe.vb` có đăng ký `splitNoiDung.SizeChanged` và xử lý `CapNhatSplitter`.

## Kết quả mong đợi

- Các form trên có xử lý clamp `SplitterDistance` khi resize và sau khi form hiển thị.

## Kết quả thực tế

- Đã chạy `rg -n "CapNhatSplitter|SizeChanged"` và thấy khai báo xử lý trong cả bốn file mục tiêu.
