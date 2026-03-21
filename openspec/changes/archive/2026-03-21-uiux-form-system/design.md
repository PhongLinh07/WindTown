## Context

Tai lieu UI/UX trong `WindTown/WindTown_VB/uiuxv2/Design/` can duoc dung lam nguon thiet ke cho `formSystem`. Hien chua co ban thiet ke/tri?n khai day du cho form nay.

## Goals / Non-Goals

**Goals:**
- Xay dung layout/UI cho `formSystem` theo noi dung trong thu muc Design.
- Trien khai form WinForms (Designer + code-behind) theo thiet ke.
- Giu dong bo voi phong cach chung cua uiuxv2.

**Non-Goals:**
- Khong thay doi cac form khac.
- Khong thay doi logic DB/Business ngoai pham vi giao dien.
- Khong tu dong sinh UI tu JSON (chi tham chieu tai lieu thiet ke).

## Decisions

- **Thiet ke dua tren tai lieu Design**: Lay cac noi dung, thong tin form tu `uiuxv2/Design/` lam nguon duy nhat.
  - *Alternative*: Tu do thiet ke lai. **Khong chon** vi de lech tong the UI/UX.
- **WinForms designer first**: Tao layout trong Designer.vb, logic trong Form.vb theo quy tac du an.
  - *Alternative*: Gop logic vao Designer. **Khong chon** theo quy uoc du an.

## Risks / Trade-offs

- **[Thieu thong tin thiet ke]** Neu tai lieu Design khong day du ? Mitigation: can xac nhan voi nguoi dung truoc khi code.
- **[Dong bo line endings]** CRLF/LF lech ? Mitigation: giu CRLF theo quy dinh AGENTS.md.

## Migration Plan

- Khong can migration. Chi them/hoan thien form moi.

## Open Questions

- Can xac nhan chinh xac file/thiet ke nao trong `uiuxv2/Design/` la nguon chinh cho `formSystem`.
