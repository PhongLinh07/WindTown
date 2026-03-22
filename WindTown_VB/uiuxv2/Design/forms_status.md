# Forms Status

Cập nhật theo `degsignUI.json`.

## Tổng quan
- Tổng số form: 20
- Đã hoàn thành: 20
- Chưa hoàn thành: 0

## Theo module
### Hệ thống (3)
- done: formMainV2, formDashBoardV2, formSystem

### Tổ chức (4)
- done: formDepartment, formJob, formLevel, formSalaryMult

### Nhân sự (3)
- done: formEmployee, formContract, formPosition

### Vận hành (6)
- done: formAttendance, formLeave, formLeaveCategory, formHoliday, formProject, formAssignment

### Tài chính (2)
- done: formPayroll, formPayPeriod

### Chính sách lương (1)
- done: formPolicy

---

## Ghi chú
- Status chuẩn: `done` hoặc `pending`.
- Khi cập nhật: chỉnh `degsignUI.json` trước, sau đó đồng bộ file này.

## Kỹ thuật (đồng bộ code, không đổi trạng thái form)
- **R-1:** `formPayroll` tách `Partial` (`formPayroll.Data`, `.Tabs`, `.Period`, `.Grid`, `.Slip`, `.Toolbar`); `formPolicy` tách `Partial` (`.Data`, `.Tabs`, `.EnumAndFormula`, `.Render`, `.Events`, `.Actions`).
- **RP / PDF:** `formReport` — xuất PDF qua máy in hệ thống *Microsoft Print to PDF* (`ReportPdfExport.vb`), cần Windows có máy in này.