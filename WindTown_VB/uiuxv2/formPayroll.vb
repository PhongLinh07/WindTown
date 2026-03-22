Imports System.Drawing
Imports System.Linq

' ============================================================
'  formPayroll.vb — Bảng lương (.NET 8) — mock hoặc pay_period / payroll / pay_item từ DB
' ============================================================
Public Class formPayroll

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA STRUCTURES
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure PeriodRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim StartDate As Date
        Dim EndDate As Date
        Dim Month As Date
        Dim StdHours As Decimal
        Dim Note As String
        Dim Status As Integer   ' 0=draft 1=processing 2=closed
    End Structure

    Private Structure PayrollRow
        Dim Id As Integer
        Dim EmpName As String
        Dim EmpCode As String
        Dim Dept As String
        Dim Job As String
        Dim BaseSalary As Decimal
        Dim TotalIncome As Decimal
        Dim TotalDeduct As Decimal
        Dim NetSalary As Decimal
        Dim IsDone As Boolean
        Dim AvatarColor As Color
    End Structure

    Private Structure PayItemRow
        Dim Code As String
        Dim Name As String
        Dim Value As Decimal
        Dim Category As Integer  ' 0=lương 1=khấu trừ 2=thưởng 3=phụ cấp 4=BHXH
    End Structure

    Private _allPeriods As New List(Of PeriodRow)()
    Private _allPayrolls As New List(Of PayrollRow)()
    Private _payItems As New Dictionary(Of Integer, List(Of PayItemRow))()
    Private _filteredPayrolls As New List(Of PayrollRow)()

    Private _selPeriodId As Integer = 1
    Private _selEmpId As Integer = 1

    Private _useDatabase As Boolean
    Private ReadOnly _periodById As New Dictionary(Of Integer, Pay_Period)()

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        ' Placeholders
        UiTextBoxHints.SetCueBanner(txtSearch, "🔍  Tìm nhân viên...")
        UiTextBoxHints.SetCueBanner(txtPCode, "PP2026-03")
        UiTextBoxHints.SetCueBanner(txtPName, "Lương tháng 3/2026")
        UiTextBoxHints.SetCueBanner(txtStdHours, "176")
        UiTextBoxHints.SetCueBanner(txtPNote, "Ghi chú kỳ lương...")

        ' Avatar circle paint
        AddHandler pnlSlipAvatar.Paint, AddressOf SlipAvatar_Paint

        _periodById.Clear()
        If TryLoadPeriodsFromDatabase() Then
            _useDatabase = True
            LoadPayrollsForCurrentPeriodFromDatabase()
        Else
            _useDatabase = False
            LoadMockPeriods()
            LoadMockPayrolls()
            LoadMockPayItems()
        End If

        _filteredPayrolls = New List(Of PayrollRow)(_allPayrolls)

        ' Render
        RenderPeriodCards()
        RenderPayrollTable(_filteredPayrolls)
        RenderSlipEmpList()

        ' Select defaults
        SelectPeriod(_selPeriodId)
        SelectEmployee(_selEmpId)

        ' Resize handlers
        AddHandler pnlTab2.Resize, AddressOf OnTab2Resize
        AddHandler pnlSlipCard.Resize, AddressOf OnSlipCardResize
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlPeriodFooter.Resize, AddressOf OnPeriodFooterResize
        AddHandler pnlSummaryChips.Resize, AddressOf OnChipsResize
        AddHandler pnlKpiRow.Resize, AddressOf OnKpiRowResize
        AddHandler pnlSlipActions.Resize, AddressOf OnSlipActionsResize
        AddHandler pnlSlipCardHeader.Resize, AddressOf OnSlipHeaderResize

        ShowTab(2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockPeriods()
        _allPeriods.Clear()

        Dim p1 As New PeriodRow()
        p1.Id = 1 : p1.Code = "PP2026-03" : p1.Name = "Lương tháng 3/2026"
        p1.StartDate = #3/1/2026# : p1.EndDate = #3/31/2026#
        p1.Month = #3/1/2026# : p1.StdHours = 176 : p1.Status = 1
        p1.Note = "Kỳ lương tháng 3 năm 2026"
        _allPeriods.Add(p1)

        Dim p2 As New PeriodRow()
        p2.Id = 2 : p2.Code = "PP2026-02" : p2.Name = "Lương tháng 2/2026"
        p2.StartDate = #2/1/2026# : p2.EndDate = #2/28/2026#
        p2.Month = #2/1/2026# : p2.StdHours = 160 : p2.Status = 2
        p2.Note = "Kỳ lương tháng 2 năm 2026"
        _allPeriods.Add(p2)

        Dim p3 As New PeriodRow()
        p3.Id = 3 : p3.Code = "PP2026-01" : p3.Name = "Lương tháng 1/2026"
        p3.StartDate = #1/1/2026# : p3.EndDate = #1/31/2026#
        p3.Month = #1/1/2026# : p3.StdHours = 184 : p3.Status = 2
        p3.Note = "Kỳ lương tháng 1 năm 2026"
        _allPeriods.Add(p3)
    End Sub

    Private Sub LoadMockPayrolls()
        _allPayrolls.Clear()

        Dim rows(,) As Object = {
            {1, "Nguyễn Văn An", "EMP001", "Kỹ thuật", "Lập trình viên", 15000000D, 17500000D, 1875000D, True},
            {2, "Trần Thị Bình", "EMP002", "Kế toán", "Kế toán trưởng", 28000000D, 31000000D, 3300000D, True},
            {3, "Lê Văn Cường", "EMP003", "Nhân sự", "Chuyên viên NS", 14000000D, 15400000D, 1650000D, True},
            {4, "Phạm Thị Dung", "EMP004", "Marketing", "Marketing Manager", 22000000D, 25200000D, 2700000D, True},
            {5, "Hoàng Văn Em", "EMP005", "Kinh doanh", "Sales Executive", 12000000D, 14800000D, 1560000D, False},
            {6, "Vũ Thị Phương", "EMP006", "Kỹ thuật", "QA Engineer", 18000000D, 20200000D, 2160000D, True},
            {7, "Đặng Văn Giang", "EMP007", "Vận hành", "Ops Manager", 24000000D, 27600000D, 2940000D, True},
            {8, "Bùi Thị Hoa", "EMP008", "Kỹ thuật", "Frontend Dev", 10000000D, 11200000D, 1200000D, True}
        }

        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New PayrollRow()
            r.Id = CInt(rows(i, 0))
            r.EmpName = CStr(rows(i, 1))
            r.EmpCode = CStr(rows(i, 2))
            r.Dept = CStr(rows(i, 3))
            r.Job = CStr(rows(i, 4))
            r.BaseSalary = CDec(rows(i, 5))
            r.TotalIncome = CDec(rows(i, 6))
            r.TotalDeduct = CDec(rows(i, 7))
            r.NetSalary = r.TotalIncome - r.TotalDeduct
            r.IsDone = CBool(rows(i, 8))
            Dim pal = ThemeColors.AvatarPalette
            r.AvatarColor = pal(r.Id Mod pal.Length)
            _allPayrolls.Add(r)
        Next
    End Sub

    Private Sub LoadMockPayItems()
        _payItems.Clear()

        ' EMP001
        Dim items1 As New List(Of PayItemRow)()
        items1.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = 15000000D, .Category = 0})
        items1.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
        items1.Add(New PayItemRow() With {.Code = "PI003", .Name = "Phụ cấp điện thoại", .Value = 500000D, .Category = 3})
        items1.Add(New PayItemRow() With {.Code = "PI004", .Name = "Thưởng chuyên cần", .Value = 500000D, .Category = 2})
        items1.Add(New PayItemRow() With {.Code = "PI005", .Name = "Thưởng KPI tháng", .Value = 840000D, .Category = 2})
        items1.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -1200000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -225000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI008", .Name = "BHTN người lao động", .Value = -150000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI009", .Name = "Khấu trừ đi trễ", .Value = -300000D, .Category = 1})
        _payItems(1) = items1

        ' EMP002
        Dim items2 As New List(Of PayItemRow)()
        items2.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = 28000000D, .Category = 0})
        items2.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI003", .Name = "Phụ cấp điện thoại", .Value = 1000000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI004", .Name = "Thưởng chuyên cần", .Value = 500000D, .Category = 2})
        items2.Add(New PayItemRow() With {.Code = "PI005", .Name = "Phụ cấp quản lý", .Value = 840000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -2240000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -420000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI008", .Name = "BHTN người lao động", .Value = -280000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI009", .Name = "Thuế TNCN tạm tính", .Value = -360000D, .Category = 1})
        _payItems(2) = items2
    End Sub

    Private Function TryLoadPeriodsFromDatabase() As Boolean
        Dim res = AppServices.Instance.Pay_PeriodSV.GetList()
        If Not res.IsSuccess OrElse res.Data Is Nothing Then Return False

        Dim lst = CType(res.Data, List(Of Pay_Period))
        If lst.Count = 0 Then Return False

        _allPeriods.Clear()
        _periodById.Clear()
        For Each pp In lst.OrderByDescending(Function(x) x.start_date)
            Dim row As New PeriodRow()
            row.Id = pp.id
            row.Code = If(pp.code, "")
            row.Name = If(pp.name, row.Code)
            row.StartDate = pp.start_date.Date
            row.EndDate = pp.end_date.Date
            row.Month = If(pp.month.HasValue, pp.month.Value, pp.start_date)
            row.StdHours = pp.std_hours
            row.Note = If(pp.note, "")
            row.Status = If(pp.status = Pay_Period.status_closed, 2, 1)
            _allPeriods.Add(row)
            _periodById(pp.id) = pp
        Next

        _selPeriodId = _allPeriods(0).Id
        Return True
    End Function

    Private Sub LoadPayrollsForCurrentPeriodFromDatabase()
        _allPayrolls.Clear()
        _payItems.Clear()

        Dim period As Pay_Period = Nothing
        If Not _periodById.TryGetValue(_selPeriodId, period) Then Return

        Dim res = AppServices.Instance.PayrollSV.GetByPeriod(period)
        If Not res.IsSuccess OrElse res.Data Is Nothing Then Return

        Dim pal = ThemeColors.AvatarPalette
        Dim idx As Integer = 0
        For Each pr In CType(res.Data, List(Of Payroll))
            Dim row As New PayrollRow()
            row.Id = pr.id
            row.EmpName = If(pr.employee_UI, "---")
            Dim emp = pr.Position?.Contract?.Employee
            row.EmpCode = If(emp?.code, "")
            row.Dept = If(pr.Position?.Salary_Mult?.Job?.Department?.name, "---")
            row.Job = If(pr.job_UI, "---")
            row.BaseSalary = If(pr.Position?.Contract?.base_salary, 0D)

            Dim items As List(Of Pay_Item) = If(pr.Pay_Items, New List(Of Pay_Item)()).Where(Function(x) x.status <> -1).ToList()
            Dim posSum As Decimal = 0
            Dim negSum As Decimal = 0
            For Each pi In items
                Dim s = Category_PayItem.GetSign(pi.category)
                If s > 0 Then posSum += pi.value
                If s < 0 Then negSum += pi.value
            Next
            row.TotalIncome = posSum
            row.TotalDeduct = negSum
            row.NetSalary = posSum - negSum
            row.IsDone = (pr.status = Payroll.status_closed)
            row.AvatarColor = pal(idx Mod pal.Length)
            idx += 1
            _allPayrolls.Add(row)

            Dim slip As New List(Of PayItemRow)()
            For Each pi In items
                Dim signed = CDec(Category_PayItem.GetSign(pi.category)) * pi.value
                slip.Add(New PayItemRow With {
                    .Code = If(pi.code, ""),
                    .Name = If(pi.name, ""),
                    .Value = signed,
                    .Category = MapPayItemCategory(pi.category)
                })
            Next
            _payItems(pr.id) = slip
        Next

        _filteredPayrolls = New List(Of PayrollRow)(_allPayrolls)
        ApplyFilter()
        RenderSlipEmpList()
        If _allPayrolls.Count > 0 Then
            SelectEmployee(_allPayrolls(0).Id)
        End If
    End Sub

    Private Shared Function MapPayItemCategory(cat As Integer) As Integer
        Select Case cat
            Case CInt(Category_PayItem.ID.DEDUCTION), CInt(Category_PayItem.ID.TAX), CInt(Category_PayItem.ID.INSURANCE)
                Return 1
            Case CInt(Category_PayItem.ID.BONUS)
                Return 2
            Case CInt(Category_PayItem.ID.ALLOWANCE)
                Return 3
            Case CInt(Category_PayItem.ID.INCOME)
                Return 0
            Case Else
                Return 0
        End Select
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORMAT HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Function FmtM(amount As Decimal) As String
        Dim a = Math.Abs(amount)
        Dim sign = If(amount < 0, "-", "")
        If a >= 1000000000D Then Return sign & (a / 1000000000D).ToString("0.#") & " tỷ"
        If a >= 1000000D Then Return sign & (a / 1000000D).ToString("0.#") & " tr"
        Return sign & a.ToString("N0") & "đ"
    End Function

    Private Function FmtVND(amount As Decimal) As String
        If amount < 0 Then
            Return "-" & Math.Abs(amount).ToString("N0") & "đ"
        End If
        Return amount.ToString("N0") & "đ"
    End Function

    Private Function GetInitials(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "NV"
        Dim parts = name.Trim().Split(" "c)
        If parts.Length >= 2 Then
            Return (parts(0)(0).ToString() & parts(parts.Length - 1)(0).ToString()).ToUpper()
        End If
        Return name.Substring(0, Math.Min(2, name.Length)).ToUpper()
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub ShowTab(tab As Integer)
        ' ── Fix #3: tắt hết trước, rồi BringToFront panel cần hiện ──
        pnlTab1.Visible = False
        pnlTab2.Visible = False
        pnlTab3.Visible = False

        Select Case tab
            Case 1
                pnlTab1.Visible = True
                pnlTab1.BringToFront()
            Case 2
                pnlTab2.Visible = True
                pnlTab2.BringToFront()
            Case 3
                pnlTab3.Visible = True
                pnlTab3.BringToFront()
        End Select

        Dim clrActive = Color.FromArgb(74, 158, 255)
        Dim clrNormal = Color.FromArgb(123, 139, 178)
        btnTab1.ForeColor = If(tab = 1, clrActive, clrNormal)
        btnTab2.ForeColor = If(tab = 2, clrActive, clrNormal)
        btnTab3.ForeColor = If(tab = 3, clrActive, clrNormal)

        Select Case tab
            Case 1
                pnlTabIndicator.Left = 0
                pnlTabIndicator.Width = 160
            Case 2
                pnlTabIndicator.Left = 160
                pnlTabIndicator.Width = 160
            Case 3
                pnlTabIndicator.Left = 320
                pnlTabIndicator.Width = 200
        End Select
    End Sub

    ' ── Fix #2: mỗi Sub phải xuống dòng trước statement đầu tiên ──
    Private Sub btnTab1_Click(s As Object, e As EventArgs) Handles btnTab1.Click
        ShowTab(1)
    End Sub

    Private Sub btnTab2_Click(s As Object, e As EventArgs) Handles btnTab2.Click
        ShowTab(2)
    End Sub

    Private Sub btnTab3_Click(s As Object, e As EventArgs) Handles btnTab3.Click
        ShowTab(3)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 1 — KỲ LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPeriodCards()
        flpPeriods.Controls.Clear()

        For Each p In _allPeriods
            Dim pid = p.Id
            Dim card As New Panel()
            card.BackColor = If(_selPeriodId = p.Id,
                                Color.FromArgb(30, 34, 53),
                                Color.FromArgb(26, 30, 48))
            card.Width = flpPeriods.ClientSize.Width - 20
            card.Height = 96
            card.Margin = New Padding(0, 0, 0, 8)
            card.Cursor = Cursors.Hand
            card.Tag = p.Id

            ' Accent left bar
            Dim bar As New Panel()
            bar.BackColor = GetPeriodStatusColor(p.Status)
            bar.Location = New Point(0, 0)
            bar.Size = New Size(3, 96)

            ' Code label
            Dim lblCode As New Label()
            lblCode.AutoSize = True
            lblCode.Font = New Font("Courier New", 10!, FontStyle.Bold)
            lblCode.ForeColor = Color.FromArgb(232, 236, 240)
            lblCode.Location = New Point(12, 10)
            lblCode.Text = p.Code

            ' Status badge
            Dim lblBadge As New Label()
            lblBadge.AutoSize = True
            lblBadge.BackColor = Color.FromArgb(If(p.Status = 1, 20, 15),
                                                GetPeriodStatusColor(p.Status))
            lblBadge.Font = New Font("Microsoft YaHei UI", 9!)
            lblBadge.ForeColor = GetPeriodStatusColor(p.Status)
            lblBadge.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            lblBadge.Location = New Point(card.Width - 90, 8)
            lblBadge.Padding = New Padding(5, 2, 5, 2)
            lblBadge.Text = GetPeriodStatusText(p.Status)

            ' Name
            Dim lblName As New Label()
            lblName.AutoSize = True
            lblName.Font = New Font("Microsoft YaHei UI", 9.0!)
            lblName.ForeColor = Color.FromArgb(197, 213, 240)
            lblName.Location = New Point(12, 32)
            lblName.Text = p.Name

            ' Dates
            Dim lblDates As New Label()
            lblDates.AutoSize = True
            lblDates.Font = New Font("Microsoft YaHei UI", 9!)
            lblDates.ForeColor = Color.FromArgb(61, 74, 114)
            lblDates.Location = New Point(12, 54)
            lblDates.Text = p.StartDate.ToString("dd/MM") & " → " &
                            p.EndDate.ToString("dd/MM") & " · " &
                            p.StdHours.ToString("0") & " giờ"

            ' Progress bar background
            Dim barBg As New Panel()
            barBg.BackColor = Color.FromArgb(38, 43, 66)
            barBg.Location = New Point(12, 76)
            barBg.Size = New Size(card.Width - 24, 3)

            ' Progress fill
            Dim barFill As New Panel()
            barFill.BackColor = GetPeriodStatusColor(p.Status)
            Dim fillPct = If(p.Status = 2, 1.0, 0.6)
            barFill.Location = New Point(0, 0)
            barFill.Size = New Size(CInt(barBg.Width * fillPct), 3)
            barBg.Controls.Add(barFill)

            card.Controls.Add(bar)
            card.Controls.Add(lblCode)
            card.Controls.Add(lblBadge)
            card.Controls.Add(lblName)
            card.Controls.Add(lblDates)
            card.Controls.Add(barBg)

            Dim clickH As EventHandler = Sub(s, ev) SelectPeriod(pid)
            AddHandler card.Click, clickH
            AddHandler lblCode.Click, clickH
            AddHandler lblName.Click, clickH
            AddHandler lblDates.Click, clickH

            flpPeriods.Controls.Add(card)
        Next
    End Sub

    Private Function GetPeriodStatusColor(status As Integer) As Color
        Select Case status
            Case 1 : Return Color.FromArgb(245, 158, 11)  ' processing
            Case 2 : Return Color.FromArgb(74, 158, 255)  ' closed
            Case Else : Return Color.FromArgb(123, 139, 178) ' draft
        End Select
    End Function

    Private Function GetPeriodStatusText(status As Integer) As String
        Select Case status
            Case 1 : Return "● Đang xử lý"
            Case 2 : Return "✓ Đã chốt"
            Case Else : Return "○ Nháp"
        End Select
    End Function

    Private Sub SelectPeriod(id As Integer)
        _selPeriodId = id
        RenderPeriodCards()

        Dim p As PeriodRow = Nothing
        Dim found = False
        For Each x In _allPeriods
            If x.Id = id Then : p = x : found = True : Exit For
            End If
        Next
        If Not found Then Return

        lblPeriodCode.Text = p.Code & "  —  " & p.Name
        lblPeriodSub.Text = p.StartDate.ToString("dd/MM/yyyy") & " → " & p.EndDate.ToString("dd/MM/yyyy")
        lblPeriodBadge.Text = GetPeriodStatusText(p.Status)
        lblPeriodBadge.ForeColor = GetPeriodStatusColor(p.Status)
        lblPeriodBadge.BackColor = Color.FromArgb(20, GetPeriodStatusColor(p.Status))

        txtPCode.Text = p.Code
        txtPName.Text = p.Name
        dtpStart.Value = p.StartDate
        dtpEnd.Value = p.EndDate
        dtpMonth.Value = p.Month
        txtStdHours.Text = p.StdHours.ToString("0")
        txtPNote.Text = p.Note

        ' Update badge on Tab2
        lblPayPeriodBadge.Text = p.Code & "  —  " & p.Name

        If _useDatabase Then
            LoadPayrollsForCurrentPeriodFromDatabase()
        End If
    End Sub

    Private Sub btnAddPeriod_Click(sender As Object, e As EventArgs) Handles btnAddPeriod.Click
        txtPCode.Clear() : txtPName.Clear() : txtPNote.Clear()
        txtStdHours.Text = "176"
        dtpStart.Value = Date.Today
        dtpEnd.Value = Date.Today.AddDays(30)
        dtpMonth.Value = Date.Today
        lblPeriodCode.Text = "Kỳ lương mới"
        lblPeriodSub.Text = "Điền thông tin bên dưới"
    End Sub

    Private Sub btnSavePeriod_Click(sender As Object, e As EventArgs) Handles btnSavePeriod.Click
        If String.IsNullOrWhiteSpace(txtPCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã kỳ lương.", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        MessageBox.Show("Đã lưu kỳ lương: " & txtPCode.Text,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClosePeriod_Click(sender As Object, e As EventArgs) Handles btnClosePeriod.Click
        Dim r = MessageBox.Show("Chốt kỳ lương sẽ khóa toàn bộ dữ liệu. Tiếp tục?",
                                "Xác nhận chốt kỳ lương",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Kỳ lương đã được chốt (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDeletePeriod_Click(sender As Object, e As EventArgs) Handles btnDeletePeriod.Click
        Dim r = MessageBox.Show("Xóa kỳ lương này và toàn bộ bảng lương liên quan?",
                                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 2 — BẢNG LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderPayrollTable(data As List(Of PayrollRow))
        dgvPayroll.Rows.Clear()

        For Each p In data
            dgvPayroll.Rows.Add(
                False,
                p.EmpName,
                p.Dept,
                p.Job,
                FmtM(p.BaseSalary),
                "+" & FmtM(p.TotalIncome),
                "-" & FmtM(p.TotalDeduct),
                FmtM(p.NetSalary),
                If(p.IsDone, "✓ Đã tính", "• Chờ xử lý"),
                "Xem →")

            Dim row = dgvPayroll.Rows(dgvPayroll.Rows.Count - 1)
            row.Tag = p.Id

            If p.IsDone Then
                row.Cells("colPayStatus").Style.ForeColor = Color.FromArgb(76, 175, 80)
            Else
                row.Cells("colPayStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
            End If
        Next

        ' Update summary chips
        Dim totalIncome = data.Where(Function(x) x.IsDone).Sum(Function(x) x.TotalIncome)
        Dim totalDeduct = data.Where(Function(x) x.IsDone).Sum(Function(x) x.TotalDeduct)
        Dim totalNet = data.Where(Function(x) x.IsDone).Sum(Function(x) x.NetSalary)

        lblChipIncome.Text = "  Thu nhập:  " & FmtM(totalIncome) & "  "
        lblChipDeduct.Text = "  Khấu trừ:  -" & FmtM(totalDeduct) & "  "
        lblChipNet.Text = "  Thực lãnh:  " & FmtM(totalNet) & "  "
        lblChipIncome.ForeColor = Color.FromArgb(76, 175, 80)
        lblChipDeduct.ForeColor = Color.FromArgb(240, 128, 128)
        lblChipNet.ForeColor = Color.FromArgb(74, 158, 255)

        Dim doneCount As Integer = data.Where(Function(x) x.IsDone).Count()
        lblPayInfo.Text = String.Format("Hiển thị {0} / {1} nhân viên · {2} đã tính",
                                         data.Count,
                                         _allPayrolls.Count,
                                         doneCount)

        dgvPayroll.Size = New Size(
            pnlTab2.Width,
            pnlTab2.Height - pnlPayrollHeader.Height - pnlPayFooter.Height)
    End Sub

    ' ── DGV CellPaint — avatar circle in EmpName column ──────
    Private Sub dgvPayroll_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvPayroll.CellPainting
        If e.ColumnIndex <> dgvPayroll.Columns("colEmpName").Index OrElse e.RowIndex < 0 Then Return

        e.PaintBackground(e.ClipBounds, True)

        Dim row = dgvPayroll.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim empId = CInt(row.Tag)
        Dim pr = _allPayrolls.FirstOrDefault(Function(x) x.Id = empId)
        If pr.Id = 0 Then Return

        Dim g = e.Graphics
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim sz = 34
        Dim ax = e.CellBounds.X + 8
        Dim ay = e.CellBounds.Y + (e.CellBounds.Height - sz) \ 2

        Using br = New SolidBrush(pr.AvatarColor)
            g.FillEllipse(br, ax, ay, sz, sz)
        End Using
        Using f = New Font("Microsoft YaHei UI", 10!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim ini = GetInitials(pr.EmpName)
                Dim s = g.MeasureString(ini, f)
                g.DrawString(ini, f, br, ax + (sz - s.Width) / 2, ay + (sz - s.Height) / 2)
            End Using : End Using

        ' Draw employee name to the right of avatar
        Using f = New Font("Microsoft YaHei UI", 10!, FontStyle.Bold)
            Using br = New SolidBrush(Color.FromArgb(232, 236, 240))
                g.DrawString(pr.EmpName, f, CType(br, Brush), CSng(ax + sz + 8), CSng(e.CellBounds.Y + (e.CellBounds.Height - f.Height) / 2))
            End Using : End Using

        e.Handled = True
    End Sub

    Private Sub dgvPayroll_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPayroll.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvPayroll.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim id = CInt(row.Tag)
        SelectEmployee(id)
        If e.ColumnIndex = dgvPayroll.Columns("colView").Index Then
            ShowTab(3)
        End If
    End Sub

    ' ── Toolbar filter ────────────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDept.SelectedIndex <= 0, "", cboDept.SelectedItem.ToString())

        _filteredPayrolls = New List(Of PayrollRow)()
        For Each p In _allPayrolls
            Dim mQ = q = "" OrElse p.EmpName.ToLower().Contains(q) OrElse p.EmpCode.ToLower().Contains(q)
            Dim mD = dept = "" OrElse p.Dept = dept
            If mQ AndAlso mD Then _filteredPayrolls.Add(p)
        Next
        RenderPayrollTable(_filteredPayrolls)
    End Sub

    Private Sub cboPeriodSel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriodSel.SelectedIndexChanged
        ' Switch period (mock: just update badge)
        If cboPeriodSel.SelectedIndex < _allPeriods.Count Then
            Dim p = _allPeriods(cboPeriodSel.SelectedIndex)
            lblPayPeriodBadge.Text = p.Code & "  —  " & p.Name
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB 3 — PHIẾU LƯƠNG
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderSlipEmpList()
        flpSlipEmps.Controls.Clear()

        For Each p In _allPayrolls
            Dim pid = p.Id
            Dim item As New Panel()
            item.BackColor = If(_selEmpId = p.Id,
                                Color.FromArgb(25, 74, 158, 255),
                                Color.Transparent)
            item.Width = flpSlipEmps.ClientSize.Width - 16
            item.Height = 48
            item.Margin = New Padding(0, 0, 0, 2)
            item.Cursor = Cursors.Hand
            item.Tag = p.Id

            ' Avatar
            Dim avatar As New Panel()
            avatar.BackColor = p.AvatarColor
            avatar.Location = New Point(8, 8)
            avatar.Size = New Size(32, 32)
            AddHandler avatar.Paint, Sub(s, ev)
                                         Dim g = ev.Graphics
                                         g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                         Using br = New SolidBrush(p.AvatarColor)
                                             g.FillEllipse(br, 0, 0, 31, 31)
                                         End Using
                                         Using f = New Font("Microsoft YaHei UI", 9!, FontStyle.Bold)
                                             Using br = New SolidBrush(Color.White)
                                                 Dim ini = GetInitials(p.EmpName)
                                                 Dim sz = g.MeasureString(ini, f)
                                                 g.DrawString(ini, f, br, (32 - sz.Width) / 2, (32 - sz.Height) / 2)
                                             End Using : End Using
                                     End Sub

            ' Name
            Dim lblName As New Label()
            lblName.AutoSize = True
            lblName.Font = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Bold)
            lblName.ForeColor = Color.FromArgb(232, 236, 240)
            lblName.Location = New Point(48, 6)
            lblName.Text = p.EmpName

            ' Net value
            Dim lblNet As New Label()
            lblNet.AutoSize = True
            lblNet.Font = New Font("Microsoft YaHei UI", 9!, FontStyle.Bold)
            lblNet.ForeColor = Color.FromArgb(74, 158, 255)
            lblNet.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            lblNet.Location = New Point(item.Width - 80, 6)
            lblNet.Text = FmtM(p.NetSalary)

            ' Dept
            Dim lblDept As New Label()
            lblDept.AutoSize = True
            lblDept.Font = New Font("Microsoft YaHei UI", 9!)
            lblDept.ForeColor = Color.FromArgb(123, 139, 178)
            lblDept.Location = New Point(48, 26)
            lblDept.Text = p.Dept

            item.Controls.Add(avatar)
            item.Controls.Add(lblName)
            item.Controls.Add(lblNet)
            item.Controls.Add(lblDept)

            Dim clickH As EventHandler = Sub(s, ev) SelectEmployee(pid)
            AddHandler item.Click, clickH
            AddHandler lblName.Click, clickH
            AddHandler lblDept.Click, clickH
            AddHandler lblNet.Click, clickH

            flpSlipEmps.Controls.Add(item)
        Next
    End Sub

    Private Sub SelectEmployee(id As Integer)
        _selEmpId = id
        RenderSlipEmpList()

        Dim pr As PayrollRow = Nothing
        Dim found = False
        For Each x In _allPayrolls
            If x.Id = id Then : pr = x : found = True : Exit For
            End If
        Next
        If Not found Then Return

        ' Update slip header
        pnlSlipAvatar.BackColor = pr.AvatarColor
        pnlSlipAvatar.Tag = GetInitials(pr.EmpName)
        pnlSlipAvatar.Invalidate()
        lblSlipEmpName.Text = pr.EmpName
        lblSlipEmpSub.Text = pr.Dept & "  ·  " & pr.Job

        Dim per = _allPeriods.FirstOrDefault(Function(x) x.Id = _selPeriodId)
        If per.Id = 0 AndAlso _allPeriods.Count > 0 Then per = _allPeriods(0)
        If per.Id <> 0 Then
            lblSlipPeriodInfo.Text = per.Code & "  —  " & per.Name
            lblSlipPeriodDates.Text = per.StartDate.ToString("dd/MM/yyyy") & " → " &
                                      per.EndDate.ToString("dd/MM/yyyy") &
                                      "  ·  " & per.StdHours.ToString("0") & " giờ chuẩn"
        End If

        ' Build pay items
        Dim items As List(Of PayItemRow)
        If _payItems.ContainsKey(id) Then
            items = _payItems(id)
        Else
            ' Default items based on base salary
            items = New List(Of PayItemRow)()
            items.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = pr.BaseSalary, .Category = 0})
            items.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
            items.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -pr.BaseSalary * 0.08D, .Category = 4})
            items.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -pr.BaseSalary * 0.015D, .Category = 4})
        End If

        Dim incomeItems = items.Where(Function(x) x.Value > 0).ToList()
        Dim deductItems = items.Where(Function(x) x.Value < 0).ToList()
        Dim totalIncome = incomeItems.Sum(Function(x) x.Value)
        Dim totalDeduct = deductItems.Sum(Function(x) x.Value)
        Dim netVal = totalIncome + totalDeduct

        ' Render income rows
        flpSlipIncomeItems.Controls.Clear()
        For Each item In incomeItems
            flpSlipIncomeItems.Controls.Add(BuildPayItemRow(item))
        Next
        pnlSlipIncomeSection.Height = 36 + incomeItems.Count * 44 + 10
        flpSlipIncomeItems.Height = incomeItems.Count * 44

        ' Render deduct rows
        flpSlipDeductItems.Controls.Clear()
        For Each item In deductItems
            flpSlipDeductItems.Controls.Add(BuildPayItemRow(item))
        Next
        pnlSlipDeductSection.Height = 36 + deductItems.Count * 44 + 10
        flpSlipDeductItems.Height = deductItems.Count * 44

        ' Update totals
        lblSlipIncomeTotal.Text = "+" & FmtVND(totalIncome)
        lblSlipDeductTotal.Text = FmtVND(totalDeduct)
        lblSlipNetVal.Text = FmtVND(netVal)

        ' Resize slip card
        pnlSlipCard.Height = pnlSlipCardHeader.Height +
                             pnlSlipIncomeSection.Height +
                             pnlSlipDeductSection.Height +
                             pnlSlipFooter.Height + 20
    End Sub

    Private Function BuildPayItemRow(item As PayItemRow) As Panel
        Dim row As New Panel()
        row.BackColor = Color.Transparent
        row.Width = flpSlipIncomeItems.ClientSize.Width
        row.Height = 44
        row.Margin = New Padding(0, 0, 0, 0)

        Dim sep As New Panel()
        sep.BackColor = Color.FromArgb(42, 48, 80)
        sep.Dock = DockStyle.Bottom
        sep.Height = 1

        Dim lblName As New Label()
        lblName.AutoSize = True
        lblName.Font = New Font("Microsoft YaHei UI", 10!)
        lblName.ForeColor = Color.FromArgb(197, 213, 240)
        lblName.Location = New Point(18, 8)
        lblName.Text = item.Name

        Dim lblCode As New Label()
        lblCode.AutoSize = True
        lblCode.Font = New Font("Courier New", 9!)
        lblCode.ForeColor = Color.FromArgb(61, 74, 114)
        lblCode.Location = New Point(18, 26)
        lblCode.Text = item.Code

        Dim lblVal As New Label()
        lblVal.AutoSize = True
        lblVal.Font = New Font("Microsoft YaHei UI", 11!, FontStyle.Bold)
        lblVal.ForeColor = If(item.Value >= 0,
                              Color.FromArgb(76, 175, 80),
                              Color.FromArgb(240, 128, 128))
        lblVal.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
        lblVal.Location = New Point(row.Width - 160, 12)
        lblVal.Text = If(item.Value >= 0, "+", "") & FmtVND(item.Value)

        row.Controls.Add(sep)
        row.Controls.Add(lblName)
        row.Controls.Add(lblCode)
        row.Controls.Add(lblVal)
        Return row
    End Function

    ' Avatar paint for slip header
    Private Sub SlipAvatar_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl = CType(sender, Panel)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Using br = New SolidBrush(pnl.BackColor)
            g.FillEllipse(br, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
        Dim initials = If(pnl.Tag IsNot Nothing, pnl.Tag.ToString(), "NV")
        Using f = New Font("Microsoft YaHei UI", 12.0!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim sz = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             (pnl.Width - sz.Width) / 2,
                             (pnl.Height - sz.Height) / 2)
            End Using : End Using
    End Sub

    ' ── Toolbar buttons ───────────────────────────────────────
    Private Sub btnCalcPayroll_Click(sender As Object, e As EventArgs) Handles btnCalcPayroll.Click
        Dim r = MessageBox.Show("Tính lương cho toàn bộ nhân viên trong kỳ này?",
                                "Xác nhận tính lương",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã tính lương xong (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnManagePeriod_Click(sender As Object, e As EventArgs) Handles btnManagePeriod.Click
        ShowTab(1)
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        MessageBox.Show("Tính năng xuất Excel sẽ được tích hợp khi kết nối DB.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrintSlip_Click(sender As Object, e As EventArgs) Handles btnPrintSlip.Click
        ShowTab(3)
    End Sub

    Private Sub btnPrintOne_Click(sender As Object, e As EventArgs) Handles btnPrintOne.Click
        MessageBox.Show("Tính năng in phiếu sẽ được tích hợp.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportOne_Click(sender As Object, e As EventArgs) Handles btnExportOne.Click
        MessageBox.Show("Tính năng xuất PDF sẽ được tích hợp.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE HANDLERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnTab2Resize(s As Object, e As EventArgs)
        dgvPayroll.Size = New Size(
            pnlTab2.Width,
            pnlTab2.Height - pnlPayrollHeader.Height - pnlPayFooter.Height)
    End Sub

    Private Sub OnSlipCardResize(s As Object, e As EventArgs)
        lblSlipNetVal.Left = pnlSlipFooter.Width - lblSlipNetVal.Width - 20
    End Sub

    Private Sub OnToolbarResize(s As Object, e As EventArgs)
        Dim right = pnlToolbar.Width - 14
        btnCalcPayroll.Left = right - btnCalcPayroll.Width
        btnManagePeriod.Left = btnCalcPayroll.Left - btnManagePeriod.Width - 10
        btnPrintSlip.Left = btnManagePeriod.Left - btnPrintSlip.Width - 10
        btnExportExcel.Left = btnPrintSlip.Left - btnExportExcel.Width - 10
    End Sub

    Private Sub OnPeriodFooterResize(s As Object, e As EventArgs)
        btnSavePeriod.Left = pnlPeriodFooter.Width - btnSavePeriod.Width - 14
        btnClosePeriod.Left = btnSavePeriod.Left - btnClosePeriod.Width - 10
    End Sub

    Private Sub OnChipsResize(s As Object, e As EventArgs)
        lblChipIncome.Left = 0
        lblChipDeduct.Left = lblChipIncome.Width + 8
        lblChipNet.Left = lblChipDeduct.Left + lblChipDeduct.Width + 8
    End Sub

    Private Sub OnKpiRowResize(s As Object, e As EventArgs)
        Dim w = (pnlKpiRow.Width - 6) \ 4
        pnlKpi1.Width = w : pnlKpi1.Left = 0
        pnlKpi2.Width = w : pnlKpi2.Left = w + 2
        pnlKpi3.Width = w : pnlKpi3.Left = (w + 2) * 2
        pnlKpi4.Width = w : pnlKpi4.Left = (w + 2) * 3
    End Sub

    Private Sub OnSlipActionsResize(s As Object, e As EventArgs)
        btnExportOne.Left = pnlSlipActions.Width - btnExportOne.Width - 14
        btnPrintOne.Left = btnExportOne.Left - btnPrintOne.Width - 10
    End Sub

    Private Sub OnSlipHeaderResize(s As Object, e As EventArgs)
        lblSlipPeriodInfo.Left = pnlSlipCardHeader.Width - lblSlipPeriodInfo.Width - 20
        lblSlipPeriodDates.Left = pnlSlipCardHeader.Width - lblSlipPeriodDates.Width - 20
    End Sub

End Class