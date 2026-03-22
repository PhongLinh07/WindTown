# Kế hoạch triển khai dài hạn — WindTown HRM

Tài liệu này cố định **thứ tự ưu tiên**, **chia task cụ thể**, **tiêu chí hoàn thành** và **các nhóm công việc có thể làm song song**. Dùng làm checklist khi triển khai từng bước.

---

## 1. Phạm vi và mục tiêu

- **Phạm vi:** Toàn dự án `WindTown_VB` (ưu tiên `uiuxv2/`, lõi `2_Core/`, service `AppServices`, cấu hình DB).
- **Mục tiêu:** (1) Giảm trùng lặp code UI, (2) đưa mock → dữ liệu thật có kiểm soát, (3) đồng bộ tài liệu/trạng thái form, (4) chuẩn bị mở rộng (báo cáo, cài đặt, dashboard).

**Nguyên tắc khi làm từng task**

- Chỉ sửa phạm vi task; không refactor lan sang file không liên quan.
- Ưu tiên thay `LoadMock*` / binding bằng service hiện có; hạn chế đụng `Designer.vb` trừ khi task yêu cầu.
- Sau mỗi nhóm task: chạy `.\build.ps1` từ thư mục repo `WindTown`.

---

## 2. Quy ước mã công việc

| Tiền tố | Ý nghĩa |
|---------|---------|
| `F-*` | Nền tảng / hạ tầng UI & chuẩn hóa |
| `D-*` | Dữ liệu thật (mock → service/EF) theo module |
| `S-*` | Shell, cấu hình hệ thống, dashboard |
| `R-*` | Refactor cấu trúc (partial class, UC, đặt tên file) |
| `C-*` | Dọn dependency & polish |
| `RP-*` | Báo cáo (`formReport`) |

**Song song:** các task trong cùng ô “Có thể song song” không phụ thuộc nhau về file hoặc đã tách branch rõ.

---

## 3. Giai đoạn F — Nền tảng kỹ thuật (ưu tiên cao nhất)

**Mục tiêu:** Một lần đầu tư để các form sau bớt copy-paste và lệch theme.

| ID | Công việc cụ thể | File / vị trí gợi ý | Tiêu chí hoàn thành |
|----|------------------|---------------------|---------------------|
| F-1 | Tạo helper **cue banner** (Win32 `EM_SETCUEBANNER`) dùng chung | Ví dụ `uiuxv2/Modules/UiTextBoxHints.vb` hoặc `2_Core/3_Utils/` | Một API kiểu `SetCueBanner(tb, hint)`; xóa bản copy `DllImport` + `SetPlaceholder` khỏi ít nhất `formEmployee`, `formContract`, `formPayroll`, `formPolicy` (lần lượt hoặc một PR). |
| F-2 | Chuẩn **palette màu** và/hoặc **avatar colors** dùng chung | Ví dụ `uiuxv2/Modules/ThemeColors.vb` hoặc `2_Core/2_Common/` | Các form uiuxv2 đọc từ một nguồn; không đổi visual bắt buộc nếu chỉ extract hằng số. |
| F-3 | Sửa comment/header **.NET 4.8 → .NET 8** (hoặc xóa dòng framework thừa) | `uiuxv2/*.vb` có ghi nhầm | Build OK; comment phản ánh đúng `net8.0-windows`. |
| F-4 | Đồng bộ **trạng thái form** tài liệu ↔ code | `uiuxv2/Design/degsignUI.json`, `forms_status.md` | `formAssignment` (và form khác nếu có) mô tả đúng `done`/`pending` so với `formMainV2` / code thực tế. |

**Có thể song song:** F-1, F-2, F-3 (khác file trọng tâm). **F-4** nên làm sau khi biết rõ trạng thái thật của từng form (có thể song song với F-3).

**Đã triển khai (Giai đoạn F):** `UiTextBoxHints.SetCueBanner` + `ThemeColors.AvatarPalette` trong `uiuxv2/Modules/`; toàn bộ form uiuxv2 dùng cue banner chung; comment `.NET 8`; `degsignUI.json` / `forms_status.md` đồng bộ (gồm `formAssignment` = done, sửa encoding module Báo cáo).

**Đã triển khai (Giai đoạn D — phần D-1):** `formDepartment`, `formJob`, `formLevel`, `formSalaryMult` nối `AppServices` (CRUD + kiểm tra trùng mã / cặp job+level / ràng buộc xóa qua salary_mult & job). Cột DGV phòng ban đổi nhãn “CÔNG VIỆC” (số chức danh); chức danh cột “HỆ SỐ SM”. **D-2** (`formPosition`) chưa làm — bước tiếp theo.

---

## 4. Giai đoạn D — Dữ liệu thật theo module (ưu tiên cao)

**Mục tiêu:** Thay dần mock trong `uiuxv2` bằng `AppServices` / repository hiện có, thống nhất xử lý `IsSuccess` và lỗi.

### 4.1 Nhóm tổ chức (ít phụ thuộc nghiệp vụ khác)

| ID | Form / khu vực | Gợi ý triển khai | Tiêu chí hoàn thành |
|----|----------------|------------------|---------------------|
| D-1 | `formDepartment`, `formJob`, `formLevel`, `formSalaryMult` | Rà soát đã gọi service chưa; chỉnh `Load*` / bind; thông báo lỗi | Không còn mock cứng cho luồng chính (hoặc ghi rõ chỗ còn mock trong comment TODO ngắn). |
| D-2 | `formPosition` | Tương tự D-1 | List + chi tiết lấy từ DB qua service. |

**Song song:** D-1 (4 form) có thể chia người hoặc làm tuần tự theo một form một PR để dễ review.

### 4.2 Nhóm nhân sự & hợp đồng

| ID | Form | Gợi ý triển khai | Tiêu chí hoàn thành |
|----|------|------------------|---------------------|
| D-3 | `formContract` | Bỏ `ContractRow` mock; map `Contract`, `Employee` giống pattern `formEmployee` | CRUD hoặc ít nhất đọc/ghi list + chi tiết khớp DB. |
| D-4 | `formEmployee` (hoàn thiện) | Kiểm tra chỗ còn mock/TODO | Luồng chính không còn dữ liệu giả (trừ fallback có log). |

**Phụ thuộc:** D-3 nên sau khi `ContractSV` / entity đã ổn (thường sau D-1 một phần).

### 4.3 Nhóm vận hành

| ID | Form | Gợi ý triển khai | Tiêu chí hoàn thành |
|----|------|------------------|---------------------|
| D-5 | `formAttendance`, `formLeave`, `formLeaveCategory`, `formHoliday` | Nối `AttendanceSV`, `LeaveSV`, … | Filter, grid, chi tiết theo service. |
| D-6 | `formProject`, `formAssignment` | Nối `Project`, `Assignment` | Đồng bộ `forms_status` khi xong nghiệp vụ. |

**Song song:** D-5a (Attendance + Leave + category) và D-5b (Holiday) nếu hai người; hoặc D-6 song song với D-5 sau khi D-1 xong.

### 4.4 Nhóm lương & chính sách (phụ thuộc engine)

| ID | Form | Gợi ý triển khai | Tiêu chí hoàn thành |
|----|------|------------------|---------------------|
| D-7 | `formPayPeriod` | Mock → `Pay_PeriodSV` | Kỳ lương load/save đúng. |
| D-8 | `formPayroll` | Thay `PeriodRow`/`PayrollRow` mock bằng entity + tính toán có kiểm soát | Ít nhất đọc payroll/pay_item từ DB; công thức qua `FormulaHelper`/policy khi có. |
| D-9 | `formPolicy` | Thay `PolicyRow` mock bằng `PolicySV` / entity | Danh sách + editor rule khớp DB. |

**Phụ thuộc:** D-7 → D-8 → D-9 (nên theo thứ tự hoặc D-7 song song với D-9 nếu team tách: một người kỳ lương, một người policy).

---

## 5. Giai đoạn S — Shell, cấu hình, dashboard (ưu tiên trung bình)

| ID | Công việc | Chi tiết | Tiêu chí hoàn thành |
|----|-----------|----------|---------------------|
| S-1 | `formSystem` thật | `DatabaseConfig.SetConnectionString`, test `modDB.TestConnection`, lưu cấu hình (`My.Settings` hoặc file config); thống nhất tên catalog `wind_town` | Người dùng đổi chuỗi kết nối và kiểm tra được; không chỉ MessageBox mock. |
| S-2 | `formDashBoardV2` | Thay `LoadMock*` bằng `DashboardService` hoặc query tổng hợp | KPI + biểu đồ phản ánh DB (hoặc ghi chú rõ phần còn ước lượng). |
| S-3 | `formMainV2` avatar / top bar | Gói logic avatar (bỏ gán `Text` hai lần khó hiểu) | Hành vi giữ nguyên; code đọc được hơn. |

**Song song:** S-1 và S-3 (khác màn). S-2 có thể song song với D-5 nếu `DashboardService` đã có sẵn dữ liệu.

---

## 6. Giai đoạn R — Refactor cấu trúc (ưu tiên trung bình)

| ID | Công việc | Chi tiết | Tiêu chí hoàn thành |
|----|-----------|----------|---------------------|
| R-1 | Tách form dài | `formPayroll`, `formPolicy` → `Partial` theo vùng hoặc UserControl | Mỗi file < ~400–500 dòng hoặc theo chuẩn team. |
| R-2 | Đặt tên file Designer | Chuẩn hóa `FormPosition.Designer.vb` vs `formPosition.vb` | Một quy ước duy nhất trên disk/Git. |

**Phụ thuộc:** Nên làm sau khi D-8/D-9 ổn định để tránh conflict merge lớn.

---

## 7. Giai đoạn C — Dọn dependency & polish (ưu tiên thấp)

| ID | Công việc | Chi tiết |
|----|-----------|----------|
| C-1 | `WinForms.DataVisualization` | Hoặc dùng cho biểu đồ, hoặc gỡ khỏi `.vbproj` nếu không dùng. |
| C-2 | Placeholder / emoji | Rà soát font; thay emoji bằng text nếu cần tương thích tối đa. |

---

## 8. Báo cáo — `formReport` (RP)

**Mục tiêu:** Đưa màn báo cáo từ mock có chủ đích sang nghiệp vụ rõ.

| ID | Công việc | Chi tiết | Tiêu chí hoàn thành |
|----|-----------|----------|---------------------|
| RP-1 | **Model theo loại báo cáo** | Enum `ReportKind` + factory: cột DGV, KPI, chart khác nhau theo loại | Đổi `cboReportType` → layout dữ liệu khớp (không một grid cố định sai ngữ cảnh). |
| RP-2 | **Nối filter** | `cboDeptFilter` (và sau này loại/khoảng ngày) filter list + refresh KPI/chart | Filter không còn “treo”. |
| RP-3 | **`btnView`** | Sau validate → `LoadReportData(...)` → bind lại bảng/KPI/chart | Bỏ hoặc giữ MessageBox chỉ khi debug. |
| RP-4 | **Biểu đồ** | Scale theo max hoặc dùng chart chung (GDI+/thư viện) | Cột phản ánh đúng tỷ lệ hoặc đơn vị thống nhất. |
| RP-5 | **Export scope UX** | Đổi text `formAttendance` → nhãn người dùng; map nội bộ sang exporter | Không lộ tên form cho end user. |
| RP-6 | **Footer / phân trang** | Ẩn `lblPage` hoặc hiển thị khi có logic phân trang | Không nhãn tĩnh gây hiểu nhầm. |
| RP-7 | **Export thật** | Excel/PDF/CSV theo quy ước template (sau RP-1–RP-3) | File tạo được, encoding đúng tiếng Việt. |

**Phụ thuộc:** RP-1 nên trước RP-2/RP-3. RP-7 cuối. **Song song:** RP-5 + RP-6 với RP-2 nếu khác nhánh code.

---

## 9. Lịch gợi ý (có thể song song)

| Tuần / giai đoạn | Track A | Track B (song song nếu có người) |
|------------------|---------|-----------------------------------|
| 1 | F-1, F-2, F-3 | F-4 |
| 2 | D-1 (form tổ chức) | D-2 |
| 3 | D-3, D-4 | — |
| 4 | D-5 | D-6 |
| 5 | D-7 | RP-1 (formReport) |
| 6 | D-8, D-9 | RP-2, RP-3 |
| 7 | S-1, S-2, S-3 | RP-4, RP-5, RP-6 |
| 8 | R-1, R-2 | C-1, C-2 |
| Sau cùng | RP-7 | — |

*(Lịch mang tính tham chiếu — điều chỉnh theo velocity team.)*

---

## 10. Checklist nhanh (copy khi bắt đầu sprint)

- [ ] Chọn nhóm task theo bảng trên (ví dụ chỉ F-*).
- [ ] Gán owner / branch (ví dụ `feat/F-1-cue-banner`).
- [ ] Sau khi xong nhóm: `.\build.ps1` pass.
- [ ] Cập nhật `forms_status.md` / `degsignUI.json` nếu đổi trạng thái form.
- [ ] Ghi chú ngắn trong PR: task ID (F-1, D-3, …).

---

*Tài liệu này có thể chỉnh sửa khi phạm vi dự án thay đổi; giữ mã task (F/D/S/R/C/RP) để tham chiếu trong commit và PR.*
