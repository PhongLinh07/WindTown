## Why

Trang thai hoan thanh cac form trong `degsignUI.json` dang lech so voi thuc te, khien danh sach form va thong ke trong `hrm_form_list.html` khong phan anh dung tien do. Can cap nhat trang thai theo danh sach moi va dong bo lai HTML.

## What Changes

- Cap nhat `degsignUI.json` de them `formMainV2` va dieu chinh trang thai (done/pending) cho cac form theo danh sach cung cap.
- Dong bo `hrm_form_list.html` theo `degsignUI.json` sau khi cap nhat.

## Capabilities

### New Capabilities
- `designui-status-sync`: Cap nhat trang thai form trong `degsignUI.json` (bao gom them `formMainV2`) va dong bo danh sach HTML theo nguon JSON.

### Modified Capabilities
- `hrm-form-list-sync`: Thay doi yeu cau dong bo de bao gom form moi va trang thai cap nhat.

## Impact

- `WindTown/WindTown_VB/uiuxv2/Design/degsignUI.json`
- `WindTown/WindTown_VB/uiuxv2/Design/hrm_form_list.html`
- `openspec/specs/hrm-form-list-sync/spec.md` (cap nhat delta)
