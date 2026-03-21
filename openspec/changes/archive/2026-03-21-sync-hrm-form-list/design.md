## Context

Hien tai `hrm_form_list.html` la file preview danh sach module/form, duoc cap nhat thu cong. Du lieu nguon nam trong `degsignUI.json` (khong duoc chinh sua). Can dong bo noi dung HTML de phan anh dung ten module, so luong form, bang lien quan, mo ta, layout badge va trang thai.

## Goals / Non-Goals

**Goals:**
- Dong bo noi dung `hrm_form_list.html` theo `degsignUI.json`.
- Cap nhat thong ke tong quan (tong form, da hoan thanh, con lai, so module) theo JSON.
- Giu nguyen CSS va cau truc markup hien co (chi thay doi noi dung/labels).

**Non-Goals:**
- Khong thay doi `degsignUI.json`.
- Khong thay doi he thong render hay them build/bundling.
- Khong doi theme, font, hay layout CSS.

## Decisions

- **Nguon du lieu la JSON**: `degsignUI.json` la single source of truth; HTML duoc chinh sua de khop day du cac module/form, status va mo ta.
  - *Alternative*: Tu dong sinh HTML tu JSON bang script. **Khong chon** vi pham vi nho, chi can cap nhat file static.
- **Giu markup hien co**: Su dung cau truc module/cards hien tai de giam rui ro va cong sua.
  - *Alternative*: Refactor to template/loop. **Khong chon** do khong co he thong render.

## Risks / Trade-offs

- **[Encoding/diacritics]** Noi dung tieng Viet co dau co the bi lech encoding ? Mitigation: giu nguyen encoding file, chi sua noi dung can thiet.
- **[Line endings]** CRLF/LF khong dong nhat ? Mitigation: giu CRLF theo quy dinh AGENTS.md.

## Migration Plan

- Khong can migrate. Chi cap nhat file HTML static va verify thong ke/khoi module khop JSON.

## Open Questions

- Khong.
