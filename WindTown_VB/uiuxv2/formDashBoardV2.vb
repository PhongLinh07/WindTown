Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Linq

' ============================================================
'  formDashBoardV2 — Dashboard HRM (DashboardService + fallback mock)
' ============================================================
Public Class formDashBoardV2

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DATA FIELDS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

    ' KPI
    Private _totalEmp As Integer = 0
    Private _activeEmp As Integer = 0
    Private _presentToday As Integer = 0
    Private _lateToday As Integer = 0
    Private _absentToday As Integer = 0
    Private _payrollTotal As Decimal = 0

    ' Bar chart — Nhân viên theo phòng ban
    Private _deptNames() As String = {}
    Private _deptCounts() As Integer = {}

    ' Line chart — Chấm công 7 ngày gần nhất
    Private _attendLabels() As String = {}
    Private _attendPresent() As Integer = {}
    Private _attendLate() As Integer = {}

    ' Donut chart — Phân bổ theo nhóm hợp đồng
    Private _donutLabels() As String = {"Có HĐ hiện hành", "Hết hạn 30 ngày", "Chưa có HĐ"}
    Private _donutCounts() As Integer = {0, 0, 0}
    Private _donutColors() As Color = {
        Color.FromArgb(74, 158, 255),
        Color.FromArgb(245, 158, 11),
        Color.FromArgb(123, 97, 255)
    }

    Private _kpiPayrollSub As String = "Từ dữ liệu lương tháng"

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD & REFRESH
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        LoadData()
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        LoadData()
    End Sub

    ''' <summary>Tải toàn bộ dữ liệu rồi repaint charts.</summary>
    Private Sub LoadData()
        If Not TryLoadFromDatabase() Then
            LoadKPI()
            LoadDeptChart()
            LoadAttendanceChart()
            LoadContractDonut()
            LoadLateTable()
        End If

        pnlK1.Invalidate()
        pnlK2.Invalidate()
        pnlK3.Invalidate()
        pnlChartLine.Invalidate()
        pnlChartBar.Invalidate()
        pnlChartDonut.Invalidate()
    End Sub

    Private Function TryLoadFromDatabase() As Boolean
        Try
            Dim svc As New DashboardService()
            Dim sum = svc.BuildSummary(DateTime.Today)
            Dim boLoc As New BaoCaoBoLoc With {.Thang = DateTime.Now.Month, .Nam = DateTime.Now.Year, .PhongBanId = 0}
            Dim tongHop = svc.TaiBaoCaoTongHop(boLoc)

            _totalEmp = sum.TotalEmployees
            _activeEmp = sum.ActiveEmployees
            _presentToday = Math.Max(0, sum.ActiveEmployees - sum.MissingCheckInTodayCount)
            _lateToday = DemSoNhanVienDiTreHomNay()
            _absentToday = sum.MissingCheckInTodayCount
            _payrollTotal = tongHop.TongChiPhiLuong
            _kpiPayrollSub = "Tháng " & DateTime.Now.Month.ToString() & "/" & DateTime.Now.Year.ToString() & " · tổng hợp Pay_Item"

            LoadDeptChartFromBaoCao(tongHop.NhanSuTheoPhongBan)
            LoadAttendanceChartFromDb()
            LoadContractDonutFromDb()
            LoadLateTableFromSummary(sum)

            Return _totalEmp > 0 OrElse _presentToday > 0 OrElse tongHop.NhanSuTheoPhongBan.Count > 0
        Catch
            Return False
        End Try
    End Function

    Private Function DemSoNhanVienDiTreHomNay() As Integer
        Dim r = AppServices.Instance.AttendanceSV.GetList()
        If Not r.IsSuccess OrElse r.Data Is Nothing Then Return 0
        Dim today = DateTime.Today.Date
        Return CType(r.Data, List(Of Attendance)).
            Where(Function(a) a.status <> -1 AndAlso a.of_date.Date = today AndAlso a.late_hours > 0D).
            Select(Function(a) a.employee_id).
            Distinct().
            Count()
    End Function

    Private Sub LoadDeptChartFromBaoCao(items As List(Of BaoCaoDuLieuBieuDo))
        If items Is Nothing OrElse items.Count = 0 Then
            LoadDeptChart()
            Return
        End If
        _deptNames = items.Select(Function(x) If(x.Nhan, "?")).ToArray()
        _deptCounts = items.Select(Function(x) CInt(Math.Min(Integer.MaxValue, Math.Max(0, x.GiaTri)))).ToArray()
    End Sub

    Private Sub LoadAttendanceChartFromDb()
        Dim r = AppServices.Instance.AttendanceSV.GetList()
        Dim culture = New System.Globalization.CultureInfo("vi-VN")
        Dim today = DateTime.Today
        _attendLabels = Enumerable.Range(0, 7).
            Select(Function(i) today.AddDays(-6 + i).ToString("dd/MM", culture)).
            ToArray()

        If Not r.IsSuccess OrElse r.Data Is Nothing Then
            LoadAttendanceChart()
            Return
        End If

        Dim all = CType(r.Data, List(Of Attendance)).Where(Function(a) a.status <> -1).ToList()
        _attendPresent = New Integer(6) {}
        _attendLate = New Integer(6) {}
        Dim idx As Integer
        For idx = 0 To 6
            Dim d = today.AddDays(-6 + idx).Date
            _attendPresent(idx) = all.
                Where(Function(a) a.of_date.Date = d AndAlso a.office_hours > 0D).
                Select(Function(a) a.employee_id).
                Distinct().
                Count()
            _attendLate(idx) = all.
                Where(Function(a) a.of_date.Date = d AndAlso a.late_hours > 0D).
                Select(Function(a) a.employee_id).
                Distinct().
                Count()
        Next
    End Sub

    Private Sub LoadContractDonutFromDb()
        Dim rc = AppServices.Instance.ContractSV.GetList()
        Dim re = AppServices.Instance.EmployeeSV.GetList()
        If Not rc.IsSuccess OrElse rc.Data Is Nothing OrElse Not re.IsSuccess OrElse re.Data Is Nothing Then
            LoadContractDonut()
            Return
        End If

        Dim contracts = CType(rc.Data, List(Of Contract)).Where(Function(c) c.status <> -1).ToList()
        Dim act = Display_Field.Status.Active
        Dim employees = CType(re.Data, List(Of Employee)).Where(Function(x) x.status = CInt(act)).ToList()
        Dim today = DateTime.Today.Date
        Dim deadline = today.AddDays(30)

        Dim co As Integer = 0
        Dim ex As Integer = 0
        Dim none As Integer = 0

        For Each emp In employees
            Dim list = contracts.Where(Function(c) c.employee_id = emp.id AndAlso
                c.start_date.Date <= today AndAlso c.end_date.Date >= today).ToList()
            If list.Count = 0 Then
                none += 1
                Continue For
            End If
            Dim best = list.OrderByDescending(Function(c) c.start_date).First()
            If best.end_date.Date >= today AndAlso best.end_date.Date <= deadline Then
                ex += 1
            Else
                co += 1
            End If
        Next

        _donutCounts(0) = co
        _donutCounts(1) = ex
        _donutCounts(2) = none
    End Sub

    Private Sub LoadLateTableFromSummary(sum As DashboardSummaryDto)
        dgvLate.Rows.Clear()
        If sum.TopLateInWeek Is Nothing OrElse sum.TopLateInWeek.Count = 0 Then
            LoadLateTable()
            Return
        End If

        Dim no As Integer = 1
        For Each it In sum.TopLateInWeek
            dgvLate.Rows.Add(
                no.ToString(),
                it.EmployeeName,
                "—",
                "—",
                it.MetricValue.ToString("0.#") & "h",
                "Trong 7 ngày")
            no += 1
        Next

        Dim row As DataGridViewRow
        For Each row In dgvLate.Rows
            row.Cells("colStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
        Next
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA — fallback khi DB trống hoặc lỗi
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

    Private Sub LoadKPI()
        _totalEmp = 247
        _activeEmp = 230
        _presentToday = 218
        _lateToday = 12
        _absentToday = _activeEmp - _presentToday   ' = 12
        _payrollTotal = 4200000000D
    End Sub

    Private Sub LoadDeptChart()
        Dim dept = AppServices.Instance.DepartmentSV.GetList()
        Dim deptList = If(dept.IsSuccess, dept.Data, New List(Of Department))
        _deptNames = New String() {"Kỹ thuật", "Phòng nhân sự", "Phòng điều hành", "Phòng phát triển", "Phòng A", "Phòng B"}
        _deptCounts = New Integer() {54, 45, 50, 38, 32, 28}
    End Sub

    Private Sub LoadAttendanceChart()
        Dim culture = New System.Globalization.CultureInfo("vi-VN")
        Dim today = DateTime.Today

        _attendLabels = New String() {
            today.AddDays(-6).ToString("dd/MM", culture),
            today.AddDays(-5).ToString("dd/MM", culture),
            today.AddDays(-4).ToString("dd/MM", culture),
            today.AddDays(-3).ToString("dd/MM", culture),
            today.AddDays(-2).ToString("dd/MM", culture),
            today.AddDays(-1).ToString("dd/MM", culture),
            today.ToString("dd/MM", culture)
        }

        _attendPresent = New Integer() {228, 235, 220, 230, 225, 210, 218}
        _attendLate = New Integer() {8, 5, 12, 7, 9, 6, 12}
    End Sub

    Private Sub LoadContractDonut()
        _donutCounts(0) = 198   ' Có HĐ hiện hành
        _donutCounts(1) = 21    ' Hết hạn trong 30 ngày
        _donutCounts(2) = 11    ' Chưa có HĐ
    End Sub

    Private Sub LoadLateTable()
        dgvLate.Rows.Clear()

        Dim mockData(,) As Object = {
            {"1", "Nguyễn Văn An", "Kỹ thuật", 9, "3.5h", "[!] Cảnh cáo"},
            {"2", "Trần Thị Bình", "Kế toán", 7, "2.8h", "[!] Cảnh cáo"},
            {"3", "Lê Văn Cường", "Nhân sự", 6, "2.1h", "(*) Nhắc nhở"},
            {"4", "Phạm Thị Dung", "Marketing", 5, "1.9h", "(*) Nhắc nhở"},
            {"5", "Hoàng Văn Em", "Kinh doanh", 4, "1.5h", "(*) Nhắc nhở"},
            {"6", "Vũ Thị Phương", "Kỹ thuật", 3, "1.1h", "[OK] Bình thường"},
            {"7", "Đặng Văn Giang", "Vận hành", 2, "0.8h", "[OK] Bình thường"},
            {"8", "Bùi Thị Hoa", "Kỹ thuật", 1, "0.5h", "[OK] Bình thường"}
        }

        Dim i As Integer
        For i = 0 To mockData.GetUpperBound(0)
            dgvLate.Rows.Add(
                mockData(i, 0),
                mockData(i, 1),
                mockData(i, 2),
                mockData(i, 3),
                mockData(i, 4),
                mockData(i, 5))
        Next

        ' Color-code status column
        Dim r As DataGridViewRow
        For Each r In dgvLate.Rows
            Dim statusVal = If(r.Cells("colStatus").Value IsNot Nothing,
                               r.Cells("colStatus").Value.ToString(), "")
            If statusVal.Contains("Cảnh cáo") Then
                r.Cells("colStatus").Style.ForeColor = Color.FromArgb(240, 128, 128)
            ElseIf statusVal.Contains("Nhắc nhở") Then
                r.Cells("colStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
            Else
                r.Cells("colStatus").Style.ForeColor = Color.FromArgb(76, 175, 80)
            End If
        Next
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  GDI+ PAINT — KPI CARDS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlK1_Paint(sender As Object, e As PaintEventArgs) Handles pnlK1.Paint
        DrawKpiCard(e.Graphics, pnlK1.ClientRectangle,
                    "TỔNG NHÂN VIÊN",
                    _totalEmp.ToString(),
                    "Đang làm việc: " & _activeEmp,
                    "+" & (_totalEmp - _activeEmp).ToString() & " không hoạt động",
                    False,
                    Color.FromArgb(74, 158, 255),
                    If(_totalEmp > 0, CSng(_activeEmp) / _totalEmp, 0))
    End Sub

    Private Sub pnlK2_Paint(sender As Object, e As PaintEventArgs) Handles pnlK2.Paint
        Dim presentPct = If(_activeEmp > 0, CSng(_presentToday) / _activeEmp, 0)
        DrawKpiCard(e.Graphics, pnlK2.ClientRectangle,
                    "CÓ MẶT HÔM NAY",
                    _presentToday.ToString() & " / " & _activeEmp,
                    _lateToday & " đi trễ · " & _absentToday & " vắng",
                    CInt(presentPct * 100) & "% có mặt",
                    presentPct >= 0.9,
                    Color.FromArgb(245, 158, 11),
                    presentPct)
    End Sub

    Private Sub pnlK3_Paint(sender As Object, e As PaintEventArgs) Handles pnlK3.Paint
        DrawKpiCard(e.Graphics, pnlK3.ClientRectangle,
                    "CHI PHÍ LƯƠNG THÁNG",
                    FormatVND(_payrollTotal),
                    _kpiPayrollSub,
                    "Theo Pay_Item / kỳ lương",
                    True,
                    Color.FromArgb(76, 175, 80),
                    0.67)
    End Sub

    ''' <summary>Vẽ 1 KPI card bằng GDI+.</summary>
    Private Sub DrawKpiCard(g As Graphics, bounds As Rectangle,
                            label As String, value As String,
                            subText As String, delta As String,
                            deltaPositive As Boolean,
                            accentColor As Color, fillPct As Single)

        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim clrDeltaUp = Color.FromArgb(76, 175, 80)
        Dim clrDeltaDn = Color.FromArgb(224, 85, 85)
        Dim clrDeltaBgUp = Color.FromArgb(20, 76, 175, 80)
        Dim clrDeltaBgDn = Color.FromArgb(20, 224, 85, 85)

        ' Accent dot (top-right)
        Using br = New SolidBrush(Color.FromArgb(30, accentColor))
            g.FillEllipse(br, bounds.Width - 44, 10, 32, 32)
        End Using
        Using br = New SolidBrush(accentColor)
            g.FillEllipse(br, bounds.Width - 38, 16, 20, 20)
        End Using

        ' Label (uppercase, muted)
        Using f = New Font("Microsoft YaHei UI", 9!, FontStyle.Bold)
            Using br = New SolidBrush(clrSub)
                g.DrawString(label, f, br, 14, 12)
            End Using
        End Using

        ' Value (large)
        Using f = New Font("Microsoft YaHei UI", 16.0!, FontStyle.Regular)
            Using br = New SolidBrush(clrTitle)
                g.DrawString(value, f, br, 12, 34)
            End Using
        End Using

        ' Sub text
        Using f = New Font("Microsoft YaHei UI", 9!)
            Using br = New SolidBrush(clrSub)
                g.DrawString(subText, f, br, 14, bounds.Height - 46)
            End Using
        End Using

        ' Delta badge
        Dim deltaColor = If(deltaPositive, clrDeltaUp, clrDeltaDn)
        Dim deltaBg = If(deltaPositive, clrDeltaBgUp, clrDeltaBgDn)
        Using fDelta = New Font("Microsoft YaHei UI", 9!)
            Dim sz = g.MeasureString(delta, fDelta)
            Dim badgeRect = New RectangleF(12, bounds.Height - 30, sz.Width + 16, 18)
            Using br = New SolidBrush(deltaBg)
                g.FillRectangle(br, badgeRect)
            End Using
            Using br = New SolidBrush(deltaColor)
                g.DrawString(delta, fDelta, br, 20, bounds.Height - 29)
            End Using
        End Using

        ' Progress bar (bottom, 4px)
        Dim barY = bounds.Height - 4
        Using br = New SolidBrush(Color.FromArgb(42, 48, 80))
            g.FillRectangle(br, 0, barY, bounds.Width, 4)
        End Using
        Dim fillW = CInt(bounds.Width * Math.Min(Math.Max(fillPct, 0), 1))
        If fillW > 0 Then
            Using br = New SolidBrush(accentColor)
                g.FillRectangle(br, 0, barY, fillW, 4)
            End Using
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  GDI+ PAINT — LINE CHART (Chấm công 7 ngày)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartLine_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartLine.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim w = pnlChartLine.Width, h = pnlChartLine.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim clrGrid = Color.FromArgb(42, 48, 80)
        Dim clrPresent = Color.FromArgb(74, 158, 255)
        Dim clrLate = Color.FromArgb(245, 158, 11)

        ' Title
        Using f1 = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9!)
                Using brT = New SolidBrush(clrTitle)
                    Using brS = New SolidBrush(clrSub)
                        g.DrawString("Xu hướng chấm công", f1, brT, 14, 12)
                        g.DrawString("Có mặt & đi trễ theo ngày", f2, brS, 14, 32)
                    End Using
                End Using
            End Using
        End Using

        ' Legend (top-right)
        Using fL = New Font("Microsoft YaHei UI", 9!)
            Using brS = New SolidBrush(clrSub)
                Using brP = New SolidBrush(clrPresent)
                    Using brL = New SolidBrush(clrLate)
                        Dim lx = w - 130
                        g.FillRectangle(brP, lx, 15, 10, 10)
                        g.DrawString("Có mặt", fL, brS, lx + 14, 13)
                        g.FillRectangle(brL, lx, 31, 10, 10)
                        g.DrawString("Đi trễ", fL, brS, lx + 14, 29)
                    End Using
                End Using
            End Using
        End Using

        If _attendLabels Is Nothing OrElse _attendLabels.Length < 2 Then
            DrawNoData(g, w, h, "Chưa có dữ liệu chấm công")
            Return
        End If

        Dim n = _attendLabels.Length
        Dim chartLeft = 44, chartRight = w - 16
        Dim chartTop = 52, chartBottom = h - 30
        Dim chartW = chartRight - chartLeft
        Dim chartH = chartBottom - chartTop

        Dim maxV = Math.Max(If(_attendPresent.Length > 0, _attendPresent.Max(), 0), 1)

        ' Horizontal grid lines
        Using penGrid = New Pen(clrGrid, 0.5!)
            Using fTick = New Font("Microsoft YaHei UI", 9!)
                Using brS = New SolidBrush(clrSub)
                    Dim i As Integer
                    For i = 0 To 4
                        Dim yy = chartBottom - CInt(chartH * i / 4)
                        g.DrawLine(penGrid, chartLeft, yy, chartRight, yy)
                        If i > 0 Then
                            Dim lbl = CInt(maxV * i / 4).ToString()
                            g.DrawString(lbl, fTick, brS, 2, yy - 8)
                        End If
                    Next
                End Using
            End Using
        End Using

        ' X positions
        Dim xStep = CSng(chartW) / Math.Max(n - 1, 1)
        Dim presentPts(n - 1) As PointF
        Dim latePts(n - 1) As PointF
        Dim j As Integer
        For j = 0 To n - 1
            Dim x = chartLeft + CInt(j * xStep)
            presentPts(j) = New PointF(x, chartBottom - CInt(CSng(chartH) * _attendPresent(j) / maxV))
            latePts(j) = New PointF(x, chartBottom - CInt(CSng(chartH) * _attendLate(j) / maxV))
        Next

        ' Fill area under present line
        Dim fillPts(n + 1) As PointF
        fillPts(0) = New PointF(chartLeft, chartBottom)
        Dim k As Integer
        For k = 0 To n - 1
            fillPts(k + 1) = presentPts(k)
        Next
        fillPts(n + 1) = New PointF(chartLeft + CInt((n - 1) * xStep), chartBottom)
        Using br = New SolidBrush(Color.FromArgb(25, 74, 158, 255))
            g.FillClosedCurve(br, fillPts, FillMode.Winding, 0.3!)
        End Using

        ' Present line (smooth)
        Using pen = New Pen(clrPresent, 2.0!)
            g.DrawCurve(pen, presentPts, 0.35!)
        End Using
        Dim pt As PointF
        For Each pt In presentPts
            Using br = New SolidBrush(Color.FromArgb(26, 29, 46))
                g.FillEllipse(br, pt.X - 4, pt.Y - 4, 8, 8)
            End Using
            Using br = New SolidBrush(clrPresent)
                g.FillEllipse(br, pt.X - 3, pt.Y - 3, 6, 6)
            End Using
        Next

        ' Late line (dashed)
        Using pen = New Pen(clrLate, 1.5!)
            pen.DashPattern = New Single() {5.0!, 3.0!}
            g.DrawCurve(pen, latePts, 0.35!)
        End Using

        ' X axis labels
        Using fLbl = New Font("Microsoft YaHei UI", 9!)
            Using brS = New SolidBrush(clrSub)
                Dim m As Integer
                For m = 0 To n - 1
                    Dim x = chartLeft + CInt(m * xStep)
                    Dim lbl = _attendLabels(m)
                    Dim sz = g.MeasureString(lbl, fLbl)
                    g.DrawString(lbl, fLbl, brS, x - sz.Width / 2, chartBottom + 4)
                Next
            End Using
        End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  GDI+ PAINT — BAR CHART (Nhân viên theo phòng ban)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartBar_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartBar.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim w = pnlChartBar.Width, h = pnlChartBar.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim clrGrid = Color.FromArgb(42, 48, 80)
        Dim barColors() As Color = {
            Color.FromArgb(74, 158, 255),
            Color.FromArgb(123, 97, 255),
            Color.FromArgb(76, 175, 80),
            Color.FromArgb(245, 158, 11),
            Color.FromArgb(224, 85, 85),
            Color.FromArgb(38, 198, 218)
        }

        ' Title
        Using f1 = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9!)
                Using brT = New SolidBrush(clrTitle)
                    Using brS = New SolidBrush(clrSub)
                        g.DrawString("Nhân viên / Phòng ban", f1, brT, 14, 12)
                        g.DrawString("Phân bổ hiện tại", f2, brS, 14, 32)
                    End Using
                End Using
            End Using
        End Using

        If _deptNames Is Nothing OrElse _deptNames.Length = 0 Then
            DrawNoData(g, w, h, "Chưa có dữ liệu phòng ban")
            Return
        End If

        Dim n = _deptNames.Length
        Dim chartLeft = 14, chartRight = w - 14
        Dim chartTop = 52, chartBottom = h - 32
        Dim chartW = chartRight - chartLeft
        Dim chartH = chartBottom - chartTop

        Dim maxV = Math.Max(If(_deptCounts.Length > 0, _deptCounts.Max(), 0), 1)

        ' Grid
        Using penGrid = New Pen(clrGrid, 0.5!)
            Dim gi As Integer
            For gi = 1 To 4
                Dim yy = chartBottom - CInt(chartH * gi / 4)
                g.DrawLine(penGrid, chartLeft, yy, chartRight, yy)
            Next
        End Using

        ' Bars
        Dim barW = Math.Min(44, (chartW \ n) - 8)
        Dim totalW = n * (barW + 8) - 8
        Dim startX = chartLeft + (chartW - totalW) \ 2

        Using fVal = New Font("Microsoft YaHei UI", 9!)
            Using fLbl = New Font("Microsoft YaHei UI", 9!)
                Using brTitle = New SolidBrush(clrTitle)
                    Using brSub = New SolidBrush(clrSub)
                        Dim i As Integer
                        For i = 0 To n - 1
                            Dim x = startX + i * (barW + 8)
                            Dim barH = CInt(CSng(chartH) * _deptCounts(i) / maxV)
                            Dim y = chartBottom - barH
                            Dim clr = barColors(i Mod barColors.Length)

                            ' Bar with rounded top
                            If barH > 6 Then
                                Dim path As New GraphicsPath()
                                path.AddArc(x, y, 5, 5, 180, 90)
                                path.AddArc(x + barW - 5, y, 5, 5, 270, 90)
                                path.AddLine(x + barW, y + 5, x + barW, chartBottom)
                                path.AddLine(x + barW, chartBottom, x, chartBottom)
                                path.CloseFigure()
                                Using br = New SolidBrush(clr)
                                    g.FillPath(br, path)
                                End Using
                            ElseIf barH > 0 Then
                                Using br = New SolidBrush(clr)
                                    g.FillRectangle(br, x, y, barW, barH)
                                End Using
                            End If

                            ' Value above bar
                            Dim valStr = _deptCounts(i).ToString()
                            Dim valSz = g.MeasureString(valStr, fVal)
                            g.DrawString(valStr, fVal, brTitle, x + (barW - valSz.Width) / 2, y - valSz.Height - 2)

                            ' Dept label below
                            Dim lbl = If(_deptNames(i).Length > 6, _deptNames(i).Substring(0, 5) & ".", _deptNames(i))
                            Dim lblSz = g.MeasureString(lbl, fLbl)
                            g.DrawString(lbl, fLbl, brSub, x + (barW - lblSz.Width) / 2, chartBottom + 5)
                        Next
                    End Using
                End Using
            End Using
        End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  GDI+ PAINT — DONUT CHART (Phân bổ hợp đồng)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartDonut_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartDonut.Paint
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim w = pnlChartDonut.Width, h = pnlChartDonut.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim clrBg = Color.FromArgb(30, 34, 53)

        ' Title
        Using f1 = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9!)
                Using brT = New SolidBrush(clrTitle)
                    Using brS = New SolidBrush(clrSub)
                        g.DrawString("Phân bổ hợp đồng", f1, brT, 14, 12)
                        g.DrawString("Theo tình trạng hiện tại", f2, brS, 14, 32)
                    End Using
                End Using
            End Using
        End Using

        Dim total = _donutCounts(0) + _donutCounts(1) + _donutCounts(2)
        If total = 0 Then
            DrawNoData(g, w, h, "Chưa có dữ liệu")
            Return
        End If

        ' Donut area
        Dim size = Math.Min(w - 28, h - 120)
        Dim size2 = Math.Max(size, 60)
        Dim donutX = (w - size2) \ 2
        Dim donutY = 52

        ' Draw segments
        Dim startAngle As Single = -90
        Dim i As Integer
        For i = 0 To _donutLabels.Length - 1
            Dim sweep = CSng(360.0 * _donutCounts(i) / total)
            Using br = New SolidBrush(_donutColors(i))
                g.FillPie(br, donutX, donutY, size2, size2, startAngle, sweep)
            End Using
            startAngle += sweep
        Next

        ' Inner circle (hole)
        Dim innerPad = CInt(size2 * 0.32)
        Using br = New SolidBrush(clrBg)
            g.FillEllipse(br, donutX + innerPad, donutY + innerPad,
                          size2 - innerPad * 2, size2 - innerPad * 2)
        End Using

        ' Center text
        Using fC = New Font("Microsoft YaHei UI", 14.0!, FontStyle.Bold)
            Using fCS = New Font("Microsoft YaHei UI", 9!)
                Using brT = New SolidBrush(clrTitle)
                    Using brS = New SolidBrush(clrSub)
                        Dim totalStr = total.ToString()
                        Dim tsz = g.MeasureString(totalStr, fC)
                        Dim cx = donutX + size2 / 2
                        Dim cy = donutY + size2 / 2
                        g.DrawString(totalStr, fC, CType(brT, Brush), CSng(cx - tsz.Width / 2), CSng(cy - tsz.Height / 2 - 4))
                        Dim subStr = "hợp đồng"
                        Dim ssz = g.MeasureString(subStr, fCS)
                        g.DrawString(subStr, fCS, CType(brS, Brush), CSng(cx - ssz.Width / 2), CSng(cy + tsz.Height / 2 - 6))
                    End Using
                End Using
            End Using
        End Using

        ' Legend below
        Dim legendY = donutY + size2 + 12
        Using fL = New Font("Microsoft YaHei UI", 9!)
            Using brS = New SolidBrush(clrSub)
                Using brT = New SolidBrush(clrTitle)
                    Dim j As Integer
                    For j = 0 To _donutLabels.Length - 1
                        Dim pct = If(total > 0, CInt(_donutCounts(j) * 100.0 / total), 0)
                        Using br = New SolidBrush(_donutColors(j))
                            g.FillRectangle(br, 14, legendY + j * 20, 10, 10)
                        End Using
                        g.DrawString(_donutLabels(j), fL, brS, 28, legendY + j * 20 - 1)
                        Dim pctStr = pct.ToString() & "%"
                        Dim psz = g.MeasureString(pctStr, fL)
                        g.DrawString(pctStr, fL, brT, w - psz.Width - 14, legendY + j * 20 - 1)
                    Next
                End Using
            End Using
        End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DGV resize helper
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlTableCard_Resize(sender As Object, e As EventArgs) Handles pnlTableCard.Resize
        dgvLate.Size = New Size(
            pnlTableCard.Width - 28,
            pnlTableCard.Height - 62)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  UTILITIES
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub DrawNoData(g As Graphics, w As Integer, h As Integer, msg As String)
        Using f = New Font("Microsoft YaHei UI", 10!)
            Using br = New SolidBrush(Color.FromArgb(45, 55, 85))
                Dim sz = g.MeasureString(msg, f)
                g.DrawString(msg, f, br,
                             (w - sz.Width) / 2,
                             (h - sz.Height) / 2)
            End Using
        End Using
    End Sub

    ''' <summary>Format tiền VNĐ — không phụ thuộc modDB.</summary>
    Private Function FormatVND(amount As Decimal) As String
        If amount >= 1000000000D Then
            Return (amount / 1000000000D).ToString("0.#") & " tỷ"
        ElseIf amount >= 1000000D Then
            Return (amount / 1000000D).ToString("0.#") & " tr"
        Else
            Return amount.ToString("N0")
        End If
    End Function

End Class
