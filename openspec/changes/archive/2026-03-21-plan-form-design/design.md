## Context

Danh sach module/form va trang thai hien tai nam trong `degsignUI.json`. Can lap thu tu thiet ke va xac dinh form nao can HTML preview truoc khi code. Viec trien khai chi duoc thuc hien sau khi nguoi dung xac nhan preview.

## Goals / Non-Goals

**Goals:**
- Tong hop trang thai module/form tu `degsignUI.json`.
- Lap thu tu thiet ke form theo muc do phuc tap va uu tien.
- Dinh nghia quy trinh: form phuc tap -> HTML preview -> user xac nhan -> implement.

**Non-Goals:**
- Khong thay doi schema hay noi dung nghiep vu trong DB.
- Khong trien khai form khi chua co xac nhan.

## Decisions

- **degsignUI.json la nguon chinh**: su dung trang thai trong JSON de lap ke hoach.
  - *Alternative*: Su dung ghi chu ngoai JSON. **Khong chon** vi de lech.
- **Preview cho form phuc tap**: form phuc tap se co HTML demo truoc khi code.
  - *Alternative*: Code thang. **Khong chon** theo yeu cau.

## Risks / Trade-offs

- **[Danh gia do phuc tap sai]** co the dan den sap xep thu tu chua hop ly ? Mitigation: xac nhan lai voi nguoi dung truoc khi bat dau.
- **[Cham tien do]** do vong duyet preview ? Mitigation: chia nho theo dot, uu tien form quan trong.

## Migration Plan

- Khong can migration. Chi lap ke hoach va trien khai theo tung dot.

## Open Questions

- Tieu chi cu the de xep loai form phuc tap (neu can dieu chinh).
