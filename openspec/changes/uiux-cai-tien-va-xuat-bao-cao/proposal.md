## Why

C?n chu?n hóa tr?i nghi?m UI/UX (thông báo, tr?ng thái t?i, ki?m tra d? li?u) d? gi?m l?i nh?p li?u và tang d? tin c?y khi thao tác. Ð?ng th?i b? sung xu?t báo cáo th?ng nh?t cho t?t c? form nh?m ph?c v? nhu c?u t?ng h?p nhanh.

## What Changes

- Chu?n hóa thông báo và tr?ng thái (loading/success/fail) cho các form UI.
- B? sung ki?m tra d?u vào tru?c khi luu/ghi d? li?u.
- Chu?n hóa d?nh d?ng ngày/gi? và s? theo c?u hình chung.
- T?o module xu?t báo cáo dùng chung và tích h?p nút xu?t báo cáo cho các form UI.
- Rà soát schema CSDL hi?n có d? d? xu?t ch?c nang còn thi?u và ghi nh?n thành m?t d? xu?t ti?p theo (không thay d?i backend).

## Capabilities

### New Capabilities
- `uiux-thong-bao-chuan`: Chu?n hóa hi?n th? thông báo và tr?ng thái thao tác trên UI.
- `uiux-kiem-tra-dau-vao`: Ki?m tra d? li?u d?u vào tru?c khi g?i x? lý luu.
- `uiux-dinh-dang-chuan`: Áp d?ng d?nh d?ng ngày/gi?/s? dùng chung cho UI.
- `xuat-bao-cao`: Module xu?t báo cáo dùng chung và tích h?p nút xu?t cho các form UI.
- `ra-soat-csdl-goi-y`: Rà soát d? li?u m?u/CSDL d? d? xu?t ch?c nang b? sung (tài li?u d? xu?t).

### Modified Capabilities
- (Không có)

## Impact

- Thu m?c UIUX: thêm module dùng chung, c?p nh?t các form d? hi?n th? thông báo, loading, validate, và nút xu?t báo cáo.
- Không thay d?i backend hay API công khai.
