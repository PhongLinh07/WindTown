# Auto Sync Guide

## Mục đích
Script này đồng bộ trạng thái form từ `degsignUI.json` sang:
- `forms_status.md`
- `hrm_form_list.html`

Bao gồm:
- Cập nhật tổng số form / done / pending
- Thêm class `done` + badge `Xong` cho form đã hoàn thành
- Dọn sạch dòng trống dư trong block `fc-badges`

## Cách dùng
Chạy ở thư mục dự án:
```powershell
python WindTown/WindTown_VB/uiuxv2/Design/sync_forms_status.py
```

## Khi nào chạy
- Sau khi chốt VB.NET form
- Khi thay đổi status trong `degsignUI.json`

## Ghi chú
- `degsignUI.json` là source of truth.
- Script không thay đổi nội dung nghiệp vụ, chỉ đồng bộ trạng thái hiển thị.
