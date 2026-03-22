Imports System.Drawing

' ============================================================
'  formPayPeriod.vb — Kỳ tính lương  (.NET 8 · Mock data)
'  Bảng: pay_period
'  fields: id, code, name, month, start_date, end_date,
'          std_hours, note, status
' ============================================================
Public Class formPayPeriod

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DATA STRUCTURE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure PeriodRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Month As Date
        Dim StartDate As Date
        Dim EndDate As Date
        Dim StdHours As Decimal
        Dim Note As String
        Dim Status As Integer   ' 0=Nháp 1=Đang xử lý 2=Đã chốt
    End Structure


    Private _allPeriods As New List(Of PeriodRow)()
    Private _filtered As New List(Of PeriodRow)()
    Private _selectedId As Integer = -1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formPayPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        UiTextBoxHints.SetCueBanner(txtSearch, "🔍  Tìm mã hoặc tên kỳ lương...")
        UiTextBoxHints.SetCueBanner(txtFCode, "PP2026-04")
        UiTextBoxHints.SetCueBanner(txtFName, "Lương tháng 4/2026")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú kỳ lương...")

        AddHandler pnlRightHdrIcon.Paint, AddressOf HdrIcon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlRightFooter.Resize, AddressOf OnFooterResize
        AddHandler pnlKpiRow.Resize, AddressOf OnKpiRowResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        AddHandler pnlRight.Resize, AddressOf OnRightResize
        AddHandler dtpStart.ValueChanged, AddressOf OnDatesChanged
        AddHandler dtpEnd.ValueChanged, AddressOf OnDatesChanged
        AddHandler txtFStdHours.TextChanged, AddressOf OnStdHoursChanged

        LoadMockData()
        _filtered = New List(Of PeriodRow)(_allPeriods)
        RenderTable(_filtered)

        ' Select first by default
        If _allPeriods.Count > 0 Then
            SelectPeriod(_allPeriods(0).Id)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockData()
        _allPeriods.Clear()

        Dim p1 As New PeriodRow()
        p1.Id = 1 : p1.Code = "PP2026-03" : p1.Name = "Lương tháng 3/2026"
        p1.Month = #3/1/2026# : p1.StartDate = #3/1/2026# : p1.EndDate = #3/31/2026#
        p1.StdHours = 176 : p1.Status = 1
        p1.Note = "Kỳ lương tháng 3 năm 2026"
        _allPeriods.Add(p1)

        Dim p2 As New PeriodRow()
        p2.Id = 2 : p2.Code = "PP2026-02" : p2.Name = "Lương tháng 2/2026"
        p2.Month = #2/1/2026# : p2.StartDate = #2/1/2026# : p2.EndDate = #2/28/2026#
        p2.StdHours = 160 : p2.Status = 2
        p2.Note = "Kỳ lương tháng 2 năm 2026"
        _allPeriods.Add(p2)

        Dim p3 As New PeriodRow()
        p3.Id = 3 : p3.Code = "PP2026-01" : p3.Name = "Lương tháng 1/2026"
        p3.Month = #1/1/2026# : p3.StartDate = #1/1/2026# : p3.EndDate = #1/31/2026#
        p3.StdHours = 184 : p3.Status = 2
        p3.Note = "Kỳ lương tháng 1 năm 2026"
        _allPeriods.Add(p3)

        Dim p4 As New PeriodRow()
        p4.Id = 4 : p4.Code = "PP2025-12" : p4.Name = "Lương tháng 12/2025"
        p4.Month = #12/1/2025# : p4.StartDate = #12/1/2025# : p4.EndDate = #12/31/2025#
        p4.StdHours = 184 : p4.Status = 2
        p4.Note = "Kỳ lương tháng 12 năm 2025"
        _allPeriods.Add(p4)

        Dim p5 As New PeriodRow()
        p5.Id = 5 : p5.Code = "PP2025-11" : p5.Name = "Lương tháng 11/2025"
        p5.Month = #11/1/2025# : p5.StartDate = #11/1/2025# : p5.EndDate = #11/30/2025#
        p5.StdHours = 168 : p5.Status = 2
        p5.Note = ""
        _allPeriods.Add(p5)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER TABLE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderTable(data As List(Of PeriodRow))
        dgvPeriod.Rows.Clear()

        For Each p In data
            dgvPeriod.Rows.Add(
                p.Code,
                p.Name,
                p.Month.ToString("MM/yyyy"),
                p.StartDate.ToString("dd/MM/yyyy"),
                p.EndDate.ToString("dd/MM/yyyy"),
                p.StdHours.ToString("0") & " h",
                GetStatusText(p.Status))

            Dim row = dgvPeriod.Rows(dgvPeriod.Rows.Count - 1)
            row.Tag = p.Id

            ' Highlight selected row
            If p.Id = _selectedId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If

            ' Status color
            Select Case p.Status
                Case 0
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(123, 139, 178)
                Case 1
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
                Case 2
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(76, 175, 80)
            End Select
        Next

        lblRowInfo.Text = String.Format("{0} kỳ lương  ·  {1} đang xử lý  ·  {2} đã chốt",
                                         data.Count,
                                         data.Where(Function(x) x.Status = 1).Count(),
                                         data.Where(Function(x) x.Status = 2).Count())

        ' Fit DGV to panel
        dgvPeriod.Size = New Size(
            pnlLeft.Width,
            pnlLeft.Height - pnlLeftFooter.Height)
    End Sub

    Private Function GetStatusText(status As Integer) As String
        Select Case status
            Case 0 : Return "○ Nháp"
            Case 1 : Return "● Đang xử lý"
            Case 2 : Return "✓ Đã chốt"
            Case Else : Return "?"
        End Select
    End Function

    Private Function GetStatusColor(status As Integer) As Color
        Select Case status
            Case 0 : Return Color.FromArgb(123, 139, 178)
            Case 1 : Return Color.FromArgb(245, 158, 11)
            Case 2 : Return Color.FromArgb(76, 175, 80)
            Case Else : Return Color.FromArgb(123, 139, 178)
        End Select
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SELECT & FILL FORM
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub SelectPeriod(id As Integer)
        _selectedId = id
        RenderTable(_filtered)

        Dim p As PeriodRow = Nothing
        Dim found = False
        For Each x In _allPeriods
            If x.Id = id Then
                p = x
                found = True
                Exit For
            End If
        Next
        If Not found Then Return

        ' Header
        lblRightTitle.Text = p.Code & "  —  " & p.Name
        lblRightSub.Text = p.StartDate.ToString("dd/MM/yyyy") &
                           "  →  " & p.EndDate.ToString("dd/MM/yyyy")
        lblRightBadge.Text = GetStatusText(p.Status)
        lblRightBadge.ForeColor = GetStatusColor(p.Status)
        lblRightBadge.BackColor = Color.FromArgb(20, GetStatusColor(p.Status))

        ' Form fields
        txtFCode.Text = p.Code
        txtFName.Text = p.Name
        dtpMonth.Value = p.Month
        cboFStatus.SelectedIndex = p.Status
        dtpStart.Value = p.StartDate
        dtpEnd.Value = p.EndDate
        txtFStdHours.Text = p.StdHours.ToString("0")
        txtFNote.Text = p.Note

        ' KPI
        UpdateKpi(p.StartDate, p.EndDate, p.StdHours, p.Status)

        ' Footer buttons state
        btnClose.Enabled = (p.Status = 1)
        btnDelete.Enabled = (p.Status <> 2)
    End Sub

    Private Sub UpdateKpi(startD As Date, endD As Date,
                           stdHours As Decimal, status As Integer)
        ' Số ngày làm việc (trừ thứ 7, CN — đơn giản)
        Dim workDays As Integer = 0
        Dim cur = startD
        Do While cur <= endD
            If cur.DayOfWeek <> DayOfWeek.Saturday AndAlso
               cur.DayOfWeek <> DayOfWeek.Sunday Then
                workDays += 1
            End If
            cur = cur.AddDays(1)
        Loop
        lblKpi1Val.Text = workDays.ToString() & " ngày"

        ' Giờ chuẩn
        lblKpi2Val.Text = stdHours.ToString("0") & " h"

        ' Thời hạn còn lại
        If status = 2 Then
            lblKpi3Val.Text = "Đã chốt"
            lblKpi3Val.ForeColor = Color.FromArgb(74, 158, 255)
        ElseIf endD < Date.Today Then
            lblKpi3Val.Text = "Đã hết hạn"
            lblKpi3Val.ForeColor = Color.FromArgb(240, 128, 128)
        Else
            Dim days = CInt((endD - Date.Today).TotalDays)
            lblKpi3Val.Text = days.ToString() & " ngày"
            lblKpi3Val.ForeColor = If(days <= 5,
                                      Color.FromArgb(245, 158, 11),
                                      Color.FromArgb(76, 175, 80))
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DGV EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub dgvPeriod_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPeriod.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvPeriod.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        SelectPeriod(CInt(row.Tag))
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TOOLBAR EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        NewPeriod()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim statIdx = cboStatusFilter.SelectedIndex  ' 0=all 1=nháp 2=xử lý 3=chốt

        _filtered = New List(Of PeriodRow)()
        For Each p In _allPeriods
            Dim mQ = q = "" OrElse
                     p.Code.ToLower().Contains(q) OrElse
                     p.Name.ToLower().Contains(q)
            Dim mS = statIdx = 0 OrElse p.Status = statIdx - 1
            If mQ AndAlso mS Then _filtered.Add(p)
        Next
        RenderTable(_filtered)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM FOOTER EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã kỳ lương.",
                            "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên kỳ lương.",
                            "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus()
            Return
        End If
        If dtpEnd.Value < dtpStart.Value Then
            MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim hours As Decimal = 0
        If Not Decimal.TryParse(txtFStdHours.Text.Trim(), hours) OrElse hours <= 0 Then
            MessageBox.Show("Giờ chuẩn phải là số dương.",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFStdHours.Focus()
            Return
        End If

        MessageBox.Show("Đã lưu kỳ lương: " & txtFCode.Text & " — " & txtFName.Text,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        NewPeriod()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId < 0 Then
            MessageBox.Show("Chưa chọn kỳ lương.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim p As PeriodRow = Nothing
        For Each x In _allPeriods
            If x.Id = _selectedId Then
                p = x
                Exit For
            End If
        Next
        If p.Status = 2 Then
            MessageBox.Show("Không thể xóa kỳ lương đã chốt.",
                            "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim r = MessageBox.Show(
            "Bạn có chắc muốn xóa kỳ lương """ & p.Name & """?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selectedId = -1
            NewPeriod()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If _selectedId < 0 Then Return
        Dim r = MessageBox.Show(
            "Chốt kỳ lương sẽ khóa toàn bộ dữ liệu bảng lương." & vbCrLf &
            "Sau khi chốt không thể chỉnh sửa. Tiếp tục?",
            "Xác nhận chốt kỳ lương",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Kỳ lương đã được chốt (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  LIVE KPI UPDATE (khi thay đổi ngày / giờ)
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnDatesChanged(sender As Object, e As EventArgs)
        If dtpEnd.Value >= dtpStart.Value Then
            Dim hours As Decimal = 0
            Decimal.TryParse(txtFStdHours.Text.Trim(), hours)
            UpdateKpi(dtpStart.Value, dtpEnd.Value, hours, cboFStatus.SelectedIndex)
        End If
    End Sub

    Private Sub OnStdHoursChanged(sender As Object, e As EventArgs)
        Dim hours As Decimal = 0
        If Decimal.TryParse(txtFStdHours.Text.Trim(), hours) Then
            lblKpi2Val.Text = hours.ToString("0") & " h"
        End If
    End Sub

    Private Sub cboFStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFStatus.SelectedIndexChanged
        Dim clr = GetStatusColor(cboFStatus.SelectedIndex)
        lblRightBadge.Text = GetStatusText(cboFStatus.SelectedIndex)
        lblRightBadge.ForeColor = clr
        lblRightBadge.BackColor = Color.FromArgb(20, clr)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub NewPeriod()
        _selectedId = -1
        txtFCode.Clear()
        txtFName.Clear()
        txtFNote.Clear()
        dtpMonth.Value = Date.Today
        dtpStart.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        dtpEnd.Value = New Date(Date.Today.Year, Date.Today.Month,
                                Date.DaysInMonth(Date.Today.Year, Date.Today.Month))
        txtFStdHours.Text = "176"
        cboFStatus.SelectedIndex = 0

        lblRightTitle.Text = "Tạo kỳ lương mới"
        lblRightSub.Text = "Điền thông tin bên dưới"
        lblRightBadge.Text = "○ Nháp"
        lblRightBadge.ForeColor = Color.FromArgb(123, 139, 178)
        lblRightBadge.BackColor = Color.FromArgb(20, 123, 139, 178)

        lblKpi1Val.Text = "—"
        lblKpi2Val.Text = "—"
        lblKpi3Val.Text = "—"

        btnDelete.Enabled = False
        btnClose.Enabled = False

        RenderTable(_filtered)
        txtFCode.Focus()
    End Sub

    ' ── GDI+ calendar icon for header ────────────────────────
    Private Sub HdrIcon_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl = CType(sender, Panel)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim w = pnl.Width, h = pnl.Height
        Dim pad = 10

        ' Rounded background
        Using br = New SolidBrush(Color.FromArgb(20, 74, 158, 255))
            g.FillRectangle(br, 0, 0, w, h)
        End Using

        ' Calendar outline
        Using pen = New Pen(Color.FromArgb(74, 158, 255), 1.5!)
            g.DrawRectangle(pen, pad, pad + 4, w - pad * 2, h - pad * 2 - 2)
            ' Header bar
            Using brH = New SolidBrush(Color.FromArgb(74, 158, 255))
                g.FillRectangle(brH, pad, pad + 4, w - pad * 2, 10)
            End Using
            ' Dots (calendar days)
            Using brD = New SolidBrush(Color.FromArgb(74, 158, 255))
                g.FillEllipse(brD, pad + 4, pad + 18, 5, 5)
                g.FillEllipse(brD, pad + 12, pad + 18, 5, 5)
                g.FillEllipse(brD, pad + 20, pad + 18, 5, 5)
                g.FillEllipse(brD, pad + 4, pad + 26, 5, 5)
                g.FillEllipse(brD, pad + 12, pad + 26, 5, 5)
            End Using
        End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE HANDLERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnToolbarResize(sender As Object, e As EventArgs)
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
    End Sub

    Private Sub OnFooterResize(sender As Object, e As EventArgs)
        btnSave.Left = pnlRightFooter.Width - btnSave.Width - 14
        btnClear.Left = btnSave.Left - btnClear.Width - 10
        btnClose.Left = btnClear.Left - btnClose.Width - 10
    End Sub

    Private Sub OnKpiRowResize(sender As Object, e As EventArgs)
        Dim w = (pnlKpiRow.Width - 4) \ 3
        pnlKpi1.Width = w : pnlKpi1.Left = 0
        pnlKpi2.Width = w : pnlKpi2.Left = w + 2
        pnlKpi3.Width = w : pnlKpi3.Left = (w + 2) * 2
    End Sub

    Private Sub OnLeftResize(sender As Object, e As EventArgs)
        dgvPeriod.Size = New Size(
            pnlLeft.Width,
            pnlLeft.Height - pnlLeftFooter.Height)
    End Sub

    Private Sub OnRightResize(sender As Object, e As EventArgs)
        ' Fit note textbox width to right panel
        txtFNote.Width = pnlSec3.Width - 32
    End Sub
End Class