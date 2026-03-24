Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class formDashBoardV2

    Public Sub New()
        InitializeComponent()
        Me.Tag = "formDashBoardV2"
        Me.Text = "Trang chủ"
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private _totalEmp As Integer = 0
    Private _activeEmp As Integer = 0
    Private _presentToday As Integer = 0
    Private _lateToday As Integer = 0
    Private _absentToday As Integer = 0
    Private _payrollTotal As Decimal = 0
    Private _kpiPayrollSub As String = ""

    Private _deptNames() As String = {}
    Private _deptCounts() As Integer = {}

    Private _attendLabels() As String = {}
    Private _attendPresent() As Integer = {}
    Private _attendLate() As Integer = {}

    Private _donutLabels() As String = {"Có HĐ hiện hành", "Hết hạn 30 ngày", "Chưa có HĐ"}
    Private _donutCounts() As Integer = {0, 0, 0}
    Private _donutColors() As Color = {
        Color.FromArgb(74, 158, 255),
        Color.FromArgb(245, 158, 11),
        Color.FromArgb(123, 97, 255)
    }

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        LoadData()
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            LoadFromDatabase()
        Catch
            ' DB lỗi → để nguyên giá trị 0
        End Try

        pnlK1.Invalidate()
        pnlK2.Invalidate()
        pnlK3.Invalidate()
        pnlChartLine.Invalidate()
        pnlChartBar.Invalidate()
        pnlChartDonut.Invalidate()
    End Sub

    Private Sub LoadFromDatabase()
        Dim sv = AppServices.Instance

        Dim empList = TryCast(sv.EmployeeSV.GetList().Data, IList)?.Cast(Of Employee)().ToList()
        Dim attList = TryCast(sv.AttendanceSV.GetList().Data, IList)?.Cast(Of Attendance)().ToList()
        Dim deptList = TryCast(sv.DepartmentSV.GetList().Data, IList)?.Cast(Of Department)().ToList()
        Dim ctrList = TryCast(sv.ContractSV.GetList().Data, IList)?.Cast(Of Contract)().ToList()
        Dim itemList = TryCast(sv.Pay_ItemSV.GetList().Data, IList)?.Cast(Of Pay_Item)().ToList()
        Dim contrList = TryCast(sv.ContractSV.GetList().Data, IList)?.Cast(Of Contract)().ToList()

        If empList Is Nothing Then empList = New List(Of Employee)()
        If attList Is Nothing Then attList = New List(Of Attendance)()
        If deptList Is Nothing Then deptList = New List(Of Department)()
        If ctrList Is Nothing Then ctrList = New List(Of Contract)()
        If itemList Is Nothing Then itemList = New List(Of Pay_Item)()
        If contrList Is Nothing Then contrList = New List(Of Contract)()

        Dim today As DateTime = New DateTime(2026, 1, 7)
        Dim weekStart = today.AddDays(-6)
        Dim monthStart = New DateTime(today.Year, today.Month, 1)

        ' ── KPI Nhân viên ────────────────────────────────────
        _totalEmp = empList.Count
        _activeEmp = empList.Where(Function(e) e.status = 1).Count()

        Dim todayAtt = attList.Where(Function(a) a.status <> -1 AndAlso a.of_date.Date = today).ToList()
        Dim checkedIds = New HashSet(Of Integer)(todayAtt.Select(Function(a) a.employee_id))

        _presentToday = todayAtt.Where(Function(a) a.office_hours > 0).Select(Function(a) a.employee_id).Distinct().Count()
        _lateToday = todayAtt.Where(Function(a) a.late_hours > 0).Select(Function(a) a.employee_id).Distinct().Count()
        _absentToday = empList.Where(Function(e) e.status = 1 AndAlso Not checkedIds.Contains(e.id)).Count

        ' ── KPI Lương ────────────────────────────────────────
        Dim netCode = System_Parameter.GetParameter(System_Parameter.ID.SYS_NET_SALARY)?.code
        Dim monthItems = itemList.Where(Function(x) x.status <> -1 AndAlso
                                         x.Payroll?.Pay_Period?.month.Value.Month = today.Month AndAlso
                                         x.Payroll?.Pay_Period?.month.Value.Year = today.Year).ToList()

        _payrollTotal = If(Not String.IsNullOrEmpty(netCode),
            monthItems.Where(Function(x) x.code = netCode).Sum(Function(x) x.value),
            monthItems.Where(Function(x) Category_PayItem.GetSign(x.category) = 1).Sum(Function(x) x.value) -
            monthItems.Where(Function(x) Category_PayItem.GetSign(x.category) = -1).Sum(Function(x) x.value))
        _kpiPayrollSub = $"Tháng {today.Month}/{today.Year}"

        ' ── Bar chart: NV theo phòng ban ─────────────────────
        Dim deptGroups = deptList.Select(Function(d) New With {
            .Name = d.name,
            .Count = empList.Where(Function(e) e.status <> -1).Count() ' cần map qua Contract/Position
        }).Where(Function(x) x.Count > 0).ToList()

        ' Nếu có DashboardService thì dùng map đầy đủ hơn
        Try
            Dim svc As New DashboardService()
            Dim boLoc As New BaoCaoBoLoc With {.Thang = today.Month, .Nam = today.Year, .PhongBanId = 0}
            Dim tongHop = svc.TaiBaoCaoTongHop(boLoc)
            If tongHop?.NhanSuTheoPhongBan?.Count > 0 Then
                _deptNames = tongHop.NhanSuTheoPhongBan.Select(Function(x) x.Nhan).ToArray()
                _deptCounts = tongHop.NhanSuTheoPhongBan.Select(Function(x) CInt(x.GiaTri)).ToArray()
                _payrollTotal = tongHop.TongChiPhiLuong
            End If
        Catch
        End Try

        ' Fallback nếu DashboardService lỗi
        If _deptNames.Length = 0 Then
            _deptNames = deptList.Select(Function(d) d.name).ToArray()
            _deptCounts = deptList.Select(Function(d) 0).ToArray()
        End If

        ' ── Line chart: Chấm công 7 ngày ─────────────────────
        Dim culture = New System.Globalization.CultureInfo("vi-VN")
        _attendLabels = Enumerable.Range(0, 7).Select(Function(i) today.AddDays(-6 + i).ToString("dd/MM", culture)).ToArray()
        _attendPresent = New Integer(6) {}
        _attendLate = New Integer(6) {}

        Dim weekAtt = attList.Where(Function(a) a.status <> -1 AndAlso
                                         a.of_date.Date >= weekStart AndAlso
                                         a.of_date.Date <= today).ToList()
        For i = 0 To 6
            Dim d = today.AddDays(-6 + i).Date
            Dim dayAtt = weekAtt.Where(Function(a) a.of_date.Date = d).ToList()
            _attendPresent(i) = dayAtt.Where(Function(a) a.office_hours > 0).Select(Function(a) a.employee_id).Distinct().Count()
            _attendLate(i) = dayAtt.Where(Function(a) a.late_hours > 0).Select(Function(a) a.employee_id).Distinct().Count()
        Next

        ' ── Donut chart: Hợp đồng ────────────────────────────
        Dim activeEmps = empList.Where(Function(e) e.status = 1).ToList()
        Dim deadline = today.AddDays(30)
        Dim co = 0, ex = 0, none = 0

        For Each emp In activeEmps
            Dim empContracts = contrList.Where(Function(c) c.employee_id = emp.id AndAlso
                                                c.status <> -1 AndAlso
                                                c.start_date.Date <= today).ToList()
            If empContracts.Count = 0 Then
                none += 1
                Continue For
            End If
            Dim best = empContracts.OrderByDescending(Function(c) c.start_date).First()
            Dim endDate = best.end_date.Date
            If endDate < today Then
                none += 1
            ElseIf endDate <= deadline Then
                ex += 1
            Else
                co += 1
            End If
        Next

        _donutCounts(0) = co
        _donutCounts(1) = ex
        _donutCounts(2) = none

        ' ── Bảng đi trễ ──────────────────────────────────────
        Dim svcDash As New DashboardService()
        Dim sum = svcDash.BuildSummary(today)
        LoadLateTable(sum)
    End Sub

    Private Sub LoadLateTable(sum As DashboardSummaryDto)
        dgvLate.Rows.Clear()
        If sum?.TopLateInWeek Is Nothing OrElse sum.TopLateInWeek.Count = 0 Then Return

        Dim no = 1
        For Each it In sum.TopLateInWeek
            dgvLate.Rows.Add(no, it.EmployeeName, "—", "—", it.MetricValue.ToString("0.#") & "h", "Trong 7 ngày")
            dgvLate.Rows(dgvLate.Rows.Count - 1).Cells("colStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
            no += 1
        Next
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  KPI CARDS PAINT
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlK1_Paint(sender As Object, e As PaintEventArgs) Handles pnlK1.Paint
        DrawKpiCard(e.Graphics, pnlK1.ClientRectangle,
                    "TỔNG NHÂN VIÊN", _totalEmp.ToString(),
                    "Đang làm việc: " & _activeEmp,
                    "+" & (_totalEmp - _activeEmp) & " không hoạt động",
                    False, Color.FromArgb(74, 158, 255),
                    If(_totalEmp > 0, CSng(_activeEmp) / _totalEmp, 0))
    End Sub

    Private Sub pnlK2_Paint(sender As Object, e As PaintEventArgs) Handles pnlK2.Paint
        Dim pct = If(_activeEmp > 0, CSng(_presentToday) / _activeEmp, 0)
        DrawKpiCard(e.Graphics, pnlK2.ClientRectangle,
                    "CÓ MẶT HÔM NAY", $"{_presentToday} / {_activeEmp}",
                    $"{_lateToday} đi trễ · {_absentToday} vắng",
                    CInt(pct * 100) & "% có mặt",
                    pct >= 0.9, Color.FromArgb(245, 158, 11), pct)
    End Sub

    Private Sub pnlK3_Paint(sender As Object, e As PaintEventArgs) Handles pnlK3.Paint
        DrawKpiCard(e.Graphics, pnlK3.ClientRectangle,
                    "CHI PHÍ LƯƠNG THÁNG", FormatVND(_payrollTotal),
                    _kpiPayrollSub, "Tổng thực lĩnh",
                    True, Color.FromArgb(76, 175, 80), 0.67)
    End Sub

    Private Sub DrawKpiCard(g As Graphics, bounds As Rectangle,
                            label As String, value As String,
                            subText As String, delta As String,
                            deltaPositive As Boolean,
                            accentColor As Color, fillPct As Single)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim deltaColor = If(deltaPositive, Color.FromArgb(76, 175, 80), Color.FromArgb(224, 85, 85))
        Dim deltaBg = If(deltaPositive, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 224, 85, 85))

        Using br = New SolidBrush(Color.FromArgb(30, accentColor))
            g.FillEllipse(br, bounds.Width - 44, 10, 32, 32)
        End Using
        Using br = New SolidBrush(accentColor)
            g.FillEllipse(br, bounds.Width - 38, 16, 20, 20)
        End Using

        Using f = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Bold)
            Using br = New SolidBrush(clrSub)
                g.DrawString(label, f, br, 14, 12)
            End Using
        End Using
        Using f = New Font("Microsoft YaHei UI", 16.0!)
            Using br = New SolidBrush(clrTitle)
                g.DrawString(value, f, br, 12, 34)
            End Using
        End Using
        Using f = New Font("Microsoft YaHei UI", 9.0!)
            Using br = New SolidBrush(clrSub)
                g.DrawString(subText, f, br, 14, bounds.Height - 46)
            End Using
            Dim sz = g.MeasureString(delta, f)
            Using br = New SolidBrush(deltaBg)
                g.FillRectangle(br, 12, bounds.Height - 30, sz.Width + 16, 18)
            End Using
            Using br = New SolidBrush(deltaColor)
                g.DrawString(delta, f, br, 20, bounds.Height - 29)
            End Using
        End Using

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
    '  LINE CHART
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartLine_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartLine.Paint
        Dim g = e.Graphics : g.SmoothingMode = SmoothingMode.AntiAlias
        Dim w = pnlChartLine.Width, h = pnlChartLine.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim clrGrid = Color.FromArgb(42, 48, 80)
        Dim clrPresent = Color.FromArgb(74, 158, 255)
        Dim clrLate = Color.FromArgb(245, 158, 11)

        Using f1 = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9.0!)
                Using brT = New SolidBrush(clrTitle) : Using brS = New SolidBrush(clrSub)
                        g.DrawString("Xu hướng chấm công", f1, brT, 14, 12)
                        g.DrawString("Có mặt & đi trễ theo ngày", f2, brS, 14, 32)
                    End Using : End Using
            End Using
        End Using

        ' Legend
        Using fL = New Font("Microsoft YaHei UI", 9.0!) : Using brS = New SolidBrush(clrSub)
                Dim lx = w - 130
                Using brP = New SolidBrush(clrPresent) : g.FillRectangle(brP, lx, 15, 10, 10) : End Using
                g.DrawString("Có mặt", fL, brS, lx + 14, 13)
                Using brL = New SolidBrush(clrLate) : g.FillRectangle(brL, lx, 31, 10, 10) : End Using
                g.DrawString("Đi trễ", fL, brS, lx + 14, 29)
            End Using : End Using

        If _attendLabels Is Nothing OrElse _attendLabels.Length < 2 Then
            DrawNoData(g, w, h, "Chưa có dữ liệu chấm công") : Return
        End If

        Dim n = _attendLabels.Length
        Dim cL = 44, cR = w - 16, cT = 52, cB = h - 30
        Dim cW = cR - cL, cH = cB - cT
        Dim maxV = Math.Max(If(_attendPresent.Length > 0, _attendPresent.Max(), 0), 1)

        Using penGrid = New Pen(clrGrid, 0.5!) : Using fTick = New Font("Microsoft YaHei UI", 9.0!) : Using brS = New SolidBrush(clrSub)
                    For i = 0 To 4
                        Dim yy = cB - CInt(cH * i / 4)
                        g.DrawLine(penGrid, cL, yy, cR, yy)
                        If i > 0 Then g.DrawString(CInt(maxV * i / 4).ToString(), fTick, brS, 2, yy - 8)
                    Next
                End Using : End Using : End Using

        Dim xStep = CSng(cW) / Math.Max(n - 1, 1)
        Dim pPts(n - 1) As PointF, lPts(n - 1) As PointF
        For j = 0 To n - 1
            Dim x = cL + CInt(j * xStep)
            pPts(j) = New PointF(x, cB - CInt(CSng(cH) * _attendPresent(j) / maxV))
            lPts(j) = New PointF(x, cB - CInt(CSng(cH) * _attendLate(j) / maxV))
        Next

        Dim fillPts(n + 1) As PointF
        fillPts(0) = New PointF(cL, cB)
        For k = 0 To n - 1 : fillPts(k + 1) = pPts(k) : Next
        fillPts(n + 1) = New PointF(cL + CInt((n - 1) * xStep), cB)
        Using br = New SolidBrush(Color.FromArgb(25, 74, 158, 255))
            g.FillClosedCurve(br, fillPts, FillMode.Winding, 0.3!)
        End Using
        Using pen = New Pen(clrPresent, 2.0!) : g.DrawCurve(pen, pPts, 0.35!) : End Using
        For Each pt In pPts
            Using br = New SolidBrush(Color.FromArgb(26, 29, 46)) : g.FillEllipse(br, pt.X - 4, pt.Y - 4, 8, 8) : End Using
            Using br = New SolidBrush(clrPresent) : g.FillEllipse(br, pt.X - 3, pt.Y - 3, 6, 6) : End Using
        Next
        Using pen = New Pen(clrLate, 1.5!)
            pen.DashPattern = {5.0!, 3.0!}
            g.DrawCurve(pen, lPts, 0.35!)
        End Using

        Using fLbl = New Font("Microsoft YaHei UI", 9.0!) : Using brS = New SolidBrush(clrSub)
                For m = 0 To n - 1
                    Dim x = cL + CInt(m * xStep)
                    Dim sz = g.MeasureString(_attendLabels(m), fLbl)
                    g.DrawString(_attendLabels(m), fLbl, brS, x - sz.Width / 2, cB + 4)
                Next
            End Using : End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  BAR CHART
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartBar_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartBar.Paint
        Dim g = e.Graphics : g.SmoothingMode = SmoothingMode.AntiAlias
        Dim w = pnlChartBar.Width, h = pnlChartBar.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)
        Dim barColors() As Color = {
            Color.FromArgb(74, 158, 255), Color.FromArgb(123, 97, 255),
            Color.FromArgb(76, 175, 80), Color.FromArgb(245, 158, 11),
            Color.FromArgb(224, 85, 85), Color.FromArgb(38, 198, 218)
        }

        Using f1 = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9.0!)
                Using brT = New SolidBrush(clrTitle) : Using brS = New SolidBrush(clrSub)
                        g.DrawString("Nhân viên / Phòng ban", f1, brT, 14, 12)
                        g.DrawString("Phân bổ hiện tại", f2, brS, 14, 32)
                    End Using : End Using
            End Using
        End Using

        If _deptNames Is Nothing OrElse _deptNames.Length = 0 Then
            DrawNoData(g, w, h, "Chưa có dữ liệu phòng ban") : Return
        End If

        Dim n = _deptNames.Length
        Dim cL = 14, cR = w - 14, cT = 52, cB = h - 32
        Dim cW = cR - cL, cH = cB - cT
        Dim maxV = Math.Max(If(_deptCounts.Length > 0, _deptCounts.Max(), 0), 1)
        Dim barW = Math.Min(44, (cW \ n) - 8)
        Dim totalW = n * (barW + 8) - 8
        Dim startX = cL + (cW - totalW) \ 2

        Using penGrid = New Pen(Color.FromArgb(42, 48, 80), 0.5!)
            For gi = 1 To 4
                g.DrawLine(penGrid, cL, cB - CInt(cH * gi / 4), cR, cB - CInt(cH * gi / 4))
            Next
        End Using

        Using fVal = New Font("Microsoft YaHei UI", 9.0!) : Using fLbl = New Font("Microsoft YaHei UI", 9.0!)
                Using brT = New SolidBrush(clrTitle) : Using brS = New SolidBrush(clrSub)
                        For i = 0 To n - 1
                            Dim x = startX + i * (barW + 8)
                            Dim bH = CInt(CSng(cH) * _deptCounts(i) / maxV)
                            Dim y = cB - bH
                            Dim clr = barColors(i Mod barColors.Length)

                            If bH > 6 Then
                                Dim path As New GraphicsPath()
                                path.AddArc(x, y, 5, 5, 180, 90)
                                path.AddArc(x + barW - 5, y, 5, 5, 270, 90)
                                path.AddLine(x + barW, y + 5, x + barW, cB)
                                path.AddLine(x + barW, cB, x, cB)
                                path.CloseFigure()
                                Using br = New SolidBrush(clr) : g.FillPath(br, path) : End Using
                            ElseIf bH > 0 Then
                                Using br = New SolidBrush(clr) : g.FillRectangle(br, x, y, barW, bH) : End Using
                            End If

                            Dim valStr = _deptCounts(i).ToString()
                            Dim vsz = g.MeasureString(valStr, fVal)
                            g.DrawString(valStr, fVal, brT, x + (barW - vsz.Width) / 2, y - vsz.Height - 2)

                            Dim lbl = If(_deptNames(i).Length > 6, _deptNames(i).Substring(0, 5) & ".", _deptNames(i))
                            Dim lsz = g.MeasureString(lbl, fLbl)
                            g.DrawString(lbl, fLbl, brS, x + (barW - lsz.Width) / 2, cB + 5)
                        Next
                    End Using : End Using
            End Using : End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DONUT CHART
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlChartDonut_Paint(sender As Object, e As PaintEventArgs) Handles pnlChartDonut.Paint
        Dim g = e.Graphics : g.SmoothingMode = SmoothingMode.AntiAlias
        Dim w = pnlChartDonut.Width, h = pnlChartDonut.Height
        Dim clrTitle = Color.FromArgb(232, 236, 240)
        Dim clrSub = Color.FromArgb(123, 139, 178)

        Using f1 = New Font("Microsoft YaHei UI", 11.0!, FontStyle.Bold)
            Using f2 = New Font("Microsoft YaHei UI", 9.0!)
                Using brT = New SolidBrush(clrTitle) : Using brS = New SolidBrush(clrSub)
                        g.DrawString("Phân bổ hợp đồng", f1, brT, 14, 12)
                        g.DrawString("Theo tình trạng hiện tại", f2, brS, 14, 32)
                    End Using : End Using
            End Using
        End Using

        Dim total = _donutCounts.Sum()
        If total = 0 Then DrawNoData(g, w, h, "Chưa có dữ liệu") : Return

        Dim size2 = Math.Max(Math.Min(w - 28, h - 120), 60)
        Dim dX = (w - size2) \ 2, dY = 52
        Dim startAngle As Single = -90

        For i = 0 To _donutLabels.Length - 1
            Dim sweep = CSng(360.0 * _donutCounts(i) / total)
            Using br = New SolidBrush(_donutColors(i)) : g.FillPie(br, dX, dY, size2, size2, startAngle, sweep) : End Using
            startAngle += sweep
        Next

        Dim pad = CInt(size2 * 0.32)
        Using br = New SolidBrush(Color.FromArgb(30, 34, 53))
            g.FillEllipse(br, dX + pad, dY + pad, size2 - pad * 2, size2 - pad * 2)
        End Using

        Using fC = New Font("Microsoft YaHei UI", 14.0!, FontStyle.Bold)
            Using fCS = New Font("Microsoft YaHei UI", 9.0!)
                Using brT = New SolidBrush(clrTitle) : Using brS = New SolidBrush(clrSub)
                        Dim totalStr = total.ToString()
                        Dim tsz = g.MeasureString(totalStr, fC)
                        Dim cx = dX + size2 / 2, cy = dY + size2 / 2
                        g.DrawString(totalStr, fC, CType(brT, Brush), CSng(cx - tsz.Width / 2), CSng(cy - tsz.Height / 2 - 4))
                        Dim ssz = g.MeasureString("HĐ", fCS)
                        g.DrawString("HĐ", fCS, CType(brS, Brush), CSng(cx - ssz.Width / 2), CSng(cy + tsz.Height / 2 - 6))
                    End Using : End Using
            End Using
        End Using

        Dim legendY = dY + size2 + 12
        Using fL = New Font("Microsoft YaHei UI", 9.0!) : Using brS = New SolidBrush(clrSub) : Using brT = New SolidBrush(clrTitle)
                    For j = 0 To _donutLabels.Length - 1
                        Dim pct = CInt(_donutCounts(j) * 100.0 / total)
                        Using br = New SolidBrush(_donutColors(j)) : g.FillRectangle(br, 14, legendY + j * 20, 10, 10) : End Using
                        g.DrawString(_donutLabels(j), fL, brS, 28, legendY + j * 20 - 1)
                        Dim psz = g.MeasureString(pct & "%", fL)
                        g.DrawString(pct & "%", fL, brT, w - psz.Width - 14, legendY + j * 20 - 1)
                    Next
                End Using : End Using : End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub pnlTableCard_Resize(sender As Object, e As EventArgs) Handles pnlTableCard.Resize
        dgvLate.Size = New Size(pnlTableCard.Width - 28, pnlTableCard.Height - 62)
    End Sub

    Private Sub DrawNoData(g As Graphics, w As Integer, h As Integer, msg As String)
        Using f = New Font("Microsoft YaHei UI", 10.0!)
            Using br = New SolidBrush(Color.FromArgb(45, 55, 85))
                Dim sz = g.MeasureString(msg, f)
                g.DrawString(msg, f, br, (w - sz.Width) / 2, (h - sz.Height) / 2)
            End Using
        End Using
    End Sub

    Private Function FormatVND(amount As Decimal) As String
        If amount >= 1000000000D Then Return (amount / 1000000000D).ToString("0.#") & " tỷ"
        If amount >= 1000000D Then Return (amount / 1000000D).ToString("0.#") & " tr"
        Return amount.ToString("N0")
    End Function

End Class