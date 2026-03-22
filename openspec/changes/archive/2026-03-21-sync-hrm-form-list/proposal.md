## Why

Cac thong tin form/module trong `hrm_form_list.html` dang bi lech so luong va noi dung so voi `degsignUI.json`, gay kho theo doi tien do va thiet ke. Can dong bo de UI list phan anh dung tinh trang va mo ta tu nguon du lieu duy nhat.

## What Changes

- Cap nhat `hrm_form_list.html` de dong bo module, form, table, mo ta, layout badge va trang thai theo `degsignUI.json`.
- Chuan hoa so lieu tong ket (tong form/da hoan thanh/con lai/module) theo du lieu JSON.
- Giu nguyen `degsignUI.json` (khong chinh sua file nay).

## Capabilities

### New Capabilities
- `hrm-form-list-sync`: Dong bo hien thi danh sach form/module trong HTML theo `degsignUI.json` bao gom thong ke, mo ta, trang thai va layout badge.

### Modified Capabilities
- 

## Impact

- `WindTown/WindTown_VB/uiuxv2/Design/hrm_form_list.html`
- `WindTown/WindTown_VB/uiuxv2/Design/AGENTS.md` (chi la huong dan, khong thay doi noi dung hien tai)
- `WindTown/WindTown_VB/uiuxv2/Design/degsignUI.json` (doc lam nguon du lieu, khong chinh sua)
