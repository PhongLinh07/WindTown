## Context

Hệ thống UI đang có lỗi hiển thị tiếng Việt do mã hóa không đồng nhất và text bị mojibake ở nhiều file. Toàn bộ chỉnh sửa phải nằm trong `UIUX/` theo quy ước. Cần chuẩn hóa font hiển thị và sửa lỗi ký tự mà không thay đổi backend.

## Goals / Non-Goals

**Goals:**
- Sửa lỗi ký tự tiếng Việt trên tất cả form trong UIUX.
- Chuẩn hóa font hiển thị trên UI theo một chuẩn thống nhất.
- Đảm bảo lưu file với UTF-8 để tránh tái phát lỗi.

**Non-Goals:**
- Không chỉnh sửa backend, API công khai, hoặc schema CSDL.
- Không refactor lớn cấu trúc form.

## Decisions

- Sử dụng `HoTroPhongChu` làm nguồn áp dụng font thống nhất cho tất cả form chạy runtime.
- Chuẩn hóa văn bản hiển thị trực tiếp trong `Designer.vb` hoặc `*.vb` bằng UTF-8 để tránh mojibake.
- Ưu tiên sửa theo từng form nhỏ để giảm rủi ro và dễ kiểm soát.

## Risks / Trade-offs

- [Rủi ro] Một số text nằm trong `*.resx` có thể vẫn lỗi → Mitigation: rà soát `*.resx` liên quan và sửa nếu cần.
- [Rủi ro] Designer tự ghi đè text khi mở bằng Visual Studio → Mitigation: hạn chế mở Designer sau khi đã sửa hoặc xác nhận lại text sau khi mở.
- [Rủi ro] Font khác nhau giữa runtime và designer → Mitigation: áp dụng `HoTroPhongChu` khi load form và giữ font trong Designer ở mức cơ bản.
