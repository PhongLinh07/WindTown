## Context

`degsignUI.json` hien la nguon du lieu chinh cho danh sach module/form, nhung trang thai hoan thanh chua khop voi thuc te va thieu `formMainV2`. `hrm_form_list.html` phai dong bo theo JSON sau khi cap nhat.

## Goals / Non-Goals

**Goals:**
- Cap nhat `degsignUI.json` theo danh sach trang thai moi va them `formMainV2`.
- Dong bo `hrm_form_list.html` theo JSON da cap nhat.
- Giu nguyen CSS/markup, chi thay doi noi dung hien thi.

**Non-Goals:**
- Khong thay doi logic render hay them tooling sinh HTML.
- Khong thay doi ten form (ngoai viec them `formMainV2`).

## Decisions

- **JSON la single source of truth**: cap nhat truoc trong `degsignUI.json`, sau do dong bo HTML.
  - *Alternative*: Sua HTML truc tiep va bo qua JSON. **Khong chon** vi de lech du lieu ve sau.
- **Them `formMainV2` vao JSON**: de trang thai hoan thanh duoc the hien trong danh sach form.
  - *Alternative*: Bo qua `formMainV2` neu khong hien tren HTML. **Khong chon** theo yeu cau.

## Risks / Trade-offs

- **[Encoding]** Noi dung tieng Viet co dau co the bi lech ? Mitigation: giu encoding hien tai khi ghi file.
- **[Line endings]** CRLF/LF khong dong nhat ? Mitigation: giu CRLF theo quy dinh AGENTS.md.

## Migration Plan

- Khong can migration. Chi cap nhat JSON va HTML static.

## Open Questions

- Khong.
