## Context

H? th?ng UI hi?n chua có chu?n th?ng nh?t v? thông báo, tr?ng thái t?i, ki?m tra d? li?u và d?nh d?ng hi?n th?. Ngoài ra, ch?c nang xu?t báo cáo chua có module dùng chung cho toàn b? form UI. Ràng bu?c quan tr?ng: ch? ch?nh s?a trong thu m?c UIUX, không thay d?i backend hay API công khai.

## Goals / Non-Goals

**Goals:**
- Chu?n hóa thông báo thành công/th?t b?i và tr?ng thái loading trên các form UI.
- B? sung ki?m tra d? li?u d?u vào tru?c khi g?i luu.
- Chu?n hóa d?nh d?ng ngày/gi?/s? ? UI theo c?u hình chung.
- T?o module xu?t báo cáo dùng chung và tích h?p nút xu?t vào các form UI.
- Rà soát d? li?u CSDL m?u d? dua ra g?i ý ch?c nang m?i (d?ng tài li?u d? xu?t).

**Non-Goals:**
- Không thay d?i schema CSDL, stored procedures, hay backend.
- Không thay d?i API công khai.
- Không refactor l?n ngoài ph?m vi UI.

## Decisions

- Dùng các module dùng chung trong `UIUX/Modules/`:
  - `UiThongBao`: d?nh d?ng và hi?n th? thông báo chung (success/fail), uu tiên MessageBox + nhãn tr?ng thái n?u form có.
  - `UiTrangThai`: hi?n th?/?n loading và khóa/m? control theo nhóm.
  - `UiDinhDang`: chu?n hóa format ngày/gi?/s? theo c?u hình chung.
  - `BaoCaoXuat`: module xu?t báo cáo, d?u vào là DataTable/DataGridView và thông tin tiêu d?.
- Tích h?p nút “Xu?t báo cáo” vào t?ng form UI b?ng cách dùng module `BaoCaoXuat`, gi? v? trí nút nh?t quán trong header.
- Ki?m tra d? li?u d?u vào b?ng hàm validate riêng ? m?i form, t?n d?ng helper chung ? `UiKiemTra` n?u dùng l?p l?i.

## Risks / Trade-offs

- [R?i ro] Các form hi?n t?i có b? c?c khác nhau ? Mitigation: ch? thêm nút xu?t ? header n?u dã có, không ch?nh layout sâu n?u không c?n.
- [R?i ro] Chu?n hóa d?nh d?ng có th? làm thay d?i cách hi?n th? quen thu?c ? Mitigation: d?a trên c?u hình hi?n có và ch? áp d?ng ? UI.
- [R?i ro] Không có backend th?ng nh?t cho xu?t báo cáo ? Mitigation: xu?t t? d? li?u dang hi?n th? trên UI d? không ph? thu?c backend.
