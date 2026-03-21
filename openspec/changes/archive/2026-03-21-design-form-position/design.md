## Context

Form Position thuộc module Nhân sự, layout popup, trạng thái pending. Hiện đã có Design System Core trong `AGENTS.md` và các preview HTML chuẩn. Cần thiết kế formPosition theo chuẩn mới để sẵn sàng triển khai code.

## Goals / Non-Goals

**Goals:**
- Định nghĩa cấu trúc popup formPosition theo chuẩn Design System.
- Chuẩn hóa component sử dụng (input/select/pill/toolbar/footer).
- Tạo preview HTML/CSS/JS độc lập để review trước khi code thật.

**Non-Goals:**
- Không thay đổi logic nghiệp vụ hoặc API.
- Không triển khai code VB.NET trong bước proposal.

## Decisions

- Dùng layout `popup` thống nhất theo guideline: header, body (grid 2 cột), footer actions.
- Màu sắc, spacing, typography theo `preview_formEmployee.html` để đồng bộ toàn bộ UI.
- Mock data tách biệt, chỉ phục vụ preview, không liên kết data thật.

## Risks / Trade-offs

- [Risk] Popup layout có thể thiếu chỗ cho trường dữ liệu dài → Mitigation: hỗ trợ scroll dọc trong body.
- [Risk] Chưa có mapping field chính xác từ DB → Mitigation: xác nhận với bảng `position`, `contract`, `salary_mult` trước khi triển khai.
