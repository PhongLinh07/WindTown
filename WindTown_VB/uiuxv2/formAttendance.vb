Imports System.Drawing
Imports System.Drawing.Drawing2D

' ============================================================
'  formAttendance.vb — Chấm công  (.NET 8 · Mock data)
'  tables: attendance, employee
' ============================================================
Public Class formAttendance

    Private Structure AttendanceRow
        Dim Id As Integer
        Dim AttDate As Date
        Dim EmpId As Integer
        Dim EmpCode As String
        Dim EmpName As String
        Dim DeptId As Integer
        Dim DeptName As String
        Dim CheckIn As String
        Dim CheckOut As String
        Dim Hours As Decimal
        Dim Status As String
        Dim Shift As String
        Dim Note As String
    End Structure

    Private Structure EmpRef
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim DeptId As Integer
        Dim DeptName As String
    End Structure

    Private ReadOnly _depts() As String = {
        "Kỹ thuật", "Nhân sự", "Kế toán", "Vận hành"
    }
    Private ReadOnly _shifts() As String = {
        "Hành chính", "Ca sáng", "Ca chiều"
    }
    Private ReadOnly _statuses() As String = {
        "Đủ công", "Thiếu", "Nghỉ"
    }

    Private ReadOnly _emps As New List(Of EmpRef)()
    Private _all As New List(Of AttendanceRow)()
    Private _filtered As New List(Of AttendanceRow)()
    Private _selId As Integer = -1

    Private Sub formAttendance_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        UiTextBoxHints.SetCueBanner(txtSearch, "🔍  Tìm theo mã / tên nhân viên...")
        UiTextBoxHints.SetCueBanner(txtFCheckIn, "08:00")
        UiTextBoxHints.SetCueBanner(txtFCheckOut, "17:30")
        UiTextBoxHints.SetCueBanner(txtFHours, "8.0")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú...")

        toolTip1.SetToolTip(cboFEmp, "Chọn nhân viên chấm công")
        toolTip1.SetToolTip(cboFDept, "Phòng ban liên quan")
        toolTip1.SetToolTip(dtpFDate, "Ngày chấm công")
        toolTip1.SetToolTip(cboFShift, "Chọn ca làm")
        toolTip1.SetToolTip(txtFCheckIn, "Giờ vào (hh:mm)")
        toolTip1.SetToolTip(txtFCheckOut, "Giờ ra (hh:mm)")
        toolTip1.SetToolTip(txtFHours, "Tổng giờ làm (mock)")
        toolTip1.SetToolTip(cboFStatus, "Trạng thái chấm công")

        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize

        PopulateCombos()
        LoadMock()

        _filtered = New List(Of AttendanceRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub PopulateCombos()
        cboMonthFilter.SelectedIndex = 0
        cboDeptFilter.SelectedIndex = 0
        cboStatusFilter.SelectedIndex = 0

        _emps.Clear()
        _emps.Add(New EmpRef With {.Id = 1, .Code = "EMP-001", .Name = "Nguyễn An", .DeptId = 1, .DeptName = "Kỹ thuật"})
        _emps.Add(New EmpRef With {.Id = 2, .Code = "EMP-014", .Name = "Trần Bình", .DeptId = 2, .DeptName = "Nhân sự"})
        _emps.Add(New EmpRef With {.Id = 3, .Code = "EMP-033", .Name = "Lê Chi", .DeptId = 3, .DeptName = "Kế toán"})
        _emps.Add(New EmpRef With {.Id = 4, .Code = "EMP-009", .Name = "Phạm Duy", .DeptId = 4, .DeptName = "Vận hành"})

        cboFEmp.Items.Clear()
        cboFEmp.Items.Add("— Chọn nhân viên —")
        For Each e In _emps
            cboFEmp.Items.Add(e.Code & " - " & e.Name)
        Next
        cboFEmp.SelectedIndex = 0

        cboFDept.Items.Clear()
        cboFDept.Items.Add("— Chọn phòng ban —")
        For Each d In _depts
            cboFDept.Items.Add(d)
        Next
        cboFDept.SelectedIndex = 0

        cboFShift.Items.Clear()
        For Each s In _shifts
            cboFShift.Items.Add(s)
        Next
        cboFShift.SelectedIndex = 0

        cboFStatus.Items.Clear()
        For Each s In _statuses
            cboFStatus.Items.Add(s)
        Next
        cboFStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadMock()
        _all.Clear()
        Dim rows(,) As Object = {
            {1, #3/2/2026#, 1, "EMP-001", "Nguyễn An", 1, "Kỹ thuật", "08:05", "17:32", 8.4D, "Đủ công", "Hành chính", ""},
            {2, #3/2/2026#, 2, "EMP-014", "Trần Bình", 2, "Nhân sự", "08:20", "17:10", 7.9D, "Thiếu", "Hành chính", "Đi trễ 20 phút."},
            {3, #3/2/2026#, 3, "EMP-033", "Lê Chi", 3, "Kế toán", "", "", 0D, "Nghỉ", "Hành chính", "Nghỉ phép."},
            {4, #2/15/2026#, 4, "EMP-009", "Phạm Duy", 4, "Vận hành", "07:50", "16:55", 8.1D, "Đủ công", "Ca sáng", ""}
        }
        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New AttendanceRow()
            r.Id = CInt(rows(i, 0)) : r.AttDate = CDate(rows(i, 1))
            r.EmpId = CInt(rows(i, 2)) : r.EmpCode = CStr(rows(i, 3))
            r.EmpName = CStr(rows(i, 4)) : r.DeptId = CInt(rows(i, 5))
            r.DeptName = CStr(rows(i, 6)) : r.CheckIn = CStr(rows(i, 7))
            r.CheckOut = CStr(rows(i, 8)) : r.Hours = CDec(rows(i, 9))
            r.Status = CStr(rows(i, 10)) : r.Shift = CStr(rows(i, 11))
            r.Note = CStr(rows(i, 12))
            _all.Add(r)
        Next
    End Sub

    Private Sub RenderTable(data As List(Of AttendanceRow))
        dgv.Rows.Clear()
        For Each r In data
            dgv.Rows.Add(r.AttDate.ToString("dd/MM"), r.EmpName, r.DeptName,
                         If(r.CheckIn = "", "—", r.CheckIn),
                         If(r.CheckOut = "", "—", r.CheckOut),
                         If(r.Hours = 0D, "—", r.Hours.ToString("0.0")),
                         r.Status)
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.Id
            Select Case r.Status
                Case "Đủ công"
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(76, 175, 80)
                Case "Thiếu"
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(245, 158, 11)
                Case Else
                    row.Cells("colStatus").Style.ForeColor = Color.FromArgb(123, 139, 178)
            End Select
            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        lblRowInfo.Text = String.Format("{0} dòng  ·  {1} phòng ban",
                                         data.Count,
                                         data.Select(Function(x) x.DeptId).Distinct().Count())
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id : RenderTable(_filtered)
        Dim r As AttendanceRow = Nothing
        For Each x In _all
            If x.Id = id Then : r = x : Exit For
            End If
        Next
        If r.Id = 0 Then Return

        lblHdrTitle.Text = r.EmpName
        lblHdrSub.Text = r.EmpCode & "  ·  " & r.DeptName
        lblHdrBadge.Text = "● " & r.Status
        Select Case r.Status
            Case "Đủ công"
                lblHdrBadge.ForeColor = Color.FromArgb(76, 175, 80)
                lblHdrBadge.BackColor = Color.FromArgb(20, 76, 175, 80)
            Case "Thiếu"
                lblHdrBadge.ForeColor = Color.FromArgb(245, 158, 11)
                lblHdrBadge.BackColor = Color.FromArgb(20, 245, 158, 11)
            Case Else
                lblHdrBadge.ForeColor = Color.FromArgb(123, 139, 178)
                lblHdrBadge.BackColor = Color.FromArgb(20, 123, 139, 178)
        End Select

        cboFEmp.SelectedIndex = If(r.EmpId > 0, r.EmpId, 0)
        cboFDept.SelectedIndex = If(r.DeptId > 0, r.DeptId, 0)
        dtpFDate.Value = r.AttDate
        cboFShift.SelectedIndex = Array.IndexOf(_shifts, r.Shift)
        cboFStatus.SelectedIndex = Array.IndexOf(_statuses, r.Status)
        txtFCheckIn.Text = r.CheckIn
        txtFCheckOut.Text = r.CheckOut
        txtFHours.Text = If(r.Hours = 0D, "", r.Hours.ToString("0.0"))
        txtFNote.Text = r.Note

        btnDelete.Enabled = True
    End Sub

    Private Sub dgv_CellClick(s As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.RowIndex < 0 Then Return
        If dgv.Rows(e.RowIndex).Tag IsNot Nothing Then
            SelectItem(CInt(dgv.Rows(e.RowIndex).Tag))
        End If
    End Sub

    Private Sub txtSearch_TextChanged(s As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub
    Private Sub cboDeptFilter_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboDeptFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub
    Private Sub cboStatusFilter_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub
    Private Sub cboMonthFilter_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboMonthFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        Dim st = cboStatusFilter.SelectedIndex
        Dim monthKey As String = ""
        Select Case cboMonthFilter.SelectedIndex
            Case 1 : monthKey = "2026-01"
            Case 2 : monthKey = "2026-02"
            Case 3 : monthKey = "2026-03"
        End Select

        _filtered = New List(Of AttendanceRow)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.EmpCode.ToLower().Contains(q) OrElse r.EmpName.ToLower().Contains(q)
            Dim mD = dept = "" OrElse r.DeptName = dept
            Dim mS = st = 0 OrElse r.Status = _statuses(st - 1)
            Dim mM = monthKey = "" OrElse r.AttDate.ToString("yyyy-MM") = monthKey
            If mQ AndAlso mD AndAlso mS AndAlso mM Then _filtered.Add(r)
        Next
        RenderTable(_filtered)
    End Sub

    Private Sub btnAdd_Click(s As Object, e As EventArgs) Handles btnAdd.Click
        NewItem()
    End Sub
    Private Sub btnClear_Click(s As Object, e As EventArgs) Handles btnClear.Click
        NewItem()
    End Sub

    Private Sub btnSave_Click(s As Object, e As EventArgs) Handles btnSave.Click
        If cboFEmp.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFEmp.Focus() : Return
        End If
        If cboFDept.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFDept.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFCheckIn.Text) Then
            MessageBox.Show("Vui lòng nhập giờ vào.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCheckIn.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFCheckOut.Text) Then
            MessageBox.Show("Vui lòng nhập giờ ra.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCheckOut.Focus() : Return
        End If
        If cboFStatus.SelectedIndex < 0 Then
            MessageBox.Show("Vui lòng chọn trạng thái.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFStatus.Focus() : Return
        End If
        MessageBox.Show("Đã lưu chấm công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim res = MessageBox.Show("Xóa dòng chấm công này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1
            NewItem()
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        cboFEmp.SelectedIndex = 0
        cboFDept.SelectedIndex = 0
        dtpFDate.Value = Date.Today
        cboFShift.SelectedIndex = 0
        cboFStatus.SelectedIndex = 0
        txtFCheckIn.Clear()
        txtFCheckOut.Clear()
        txtFHours.Clear()
        txtFNote.Clear()
        lblHdrTitle.Text = "Tạo chấm công mới"
        lblHdrSub.Text = "Điền thông tin bên dưới"
        lblHdrBadge.Text = "● Đủ công"
        lblHdrBadge.ForeColor = Color.FromArgb(76, 175, 80)
        lblHdrBadge.BackColor = Color.FromArgb(20, 76, 175, 80)
        btnDelete.Enabled = False
        RenderTable(_filtered)
        cboFEmp.Focus()
    End Sub

    Private Sub Icon_Paint(s As Object, e As PaintEventArgs)
        Dim g = e.Graphics : g.SmoothingMode = SmoothingMode.AntiAlias
        Using br = New SolidBrush(Color.FromArgb(20, 123, 97, 255))
            g.FillRectangle(br, 0, 0, pnlHdrIcon.Width, pnlHdrIcon.Height)
        End Using
        Using pen = New Pen(Color.FromArgb(123, 97, 255), 1.6!)
            g.DrawEllipse(pen, 14, 12, 22, 22)
            g.DrawLine(pen, 25, 23, 25, 16)
            g.DrawLine(pen, 25, 23, 31, 26)
        End Using
    End Sub

    Private Sub OnToolbarResize(s As Object, e As EventArgs)
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
    End Sub
    Private Sub OnFootResize(s As Object, e As EventArgs)
        btnSave.Left = pnlFoot.Width - btnSave.Width - 14
        btnClear.Left = btnSave.Left - btnClear.Width - 10
    End Sub
    Private Sub OnLeftResize(s As Object, e As EventArgs)
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub
End Class
