Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

' ============================================================
'  formJob.vb — Chức danh  (.NET 4.8 · Mock data)
'  table: job  |  datas: code, name, note, status
'  FK: department_id
' ============================================================
Public Class formJob

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Sub SetPH(tb As TextBox, h As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), h)
    End Sub

    Private Structure JobRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim DeptId As Integer
        Dim DeptName As String
        Dim EmpCount As Integer
        Dim Note As String
        Dim Status As Integer
    End Structure

    ' Department master list (shared data từ formDepartment)
    Private ReadOnly _depts() As String = {
        "Kỹ thuật", "Kế toán", "Nhân sự",
        "Marketing", "Kinh doanh", "Vận hành"
    }

    Private _all As New List(Of JobRow)()
    Private _filtered As New List(Of JobRow)()
    Private _selId As Integer = -1

    Private Sub formJob_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        SetPH(txtSearch, "🔍  Tìm mã hoặc tên chức danh...")
        SetPH(txtFCode, "JOB01")
        SetPH(txtFName, "Lập trình viên")
        SetPH(txtFNote, "Ghi chú...")
        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize

        ' Populate dept combo in form
        cboFDept.Items.Clear()
        cboFDept.Items.Add("— Chọn phòng ban —")
        For Each d In _depts
            cboFDept.Items.Add(d)
        Next
        cboFDept.SelectedIndex = 0

        LoadMock()
        _filtered = New List(Of JobRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub LoadMock()
        _all.Clear()
        Dim rows(,) As Object = {
            {1,  "JOB01", "Lập trình viên",      1, "Kỹ thuật",  12, ""},
            {2,  "JOB02", "Senior Developer",     1, "Kỹ thuật",  8,  ""},
            {3,  "JOB03", "QA Engineer",          1, "Kỹ thuật",  6,  ""},
            {4,  "JOB04", "DevOps Engineer",      1, "Kỹ thuật",  4,  ""},
            {5,  "JOB05", "Frontend Developer",   1, "Kỹ thuật",  4,  ""},
            {6,  "JOB06", "Kế toán trưởng",       2, "Kế toán",   2,  ""},
            {7,  "JOB07", "Kế toán viên",         2, "Kế toán",   8,  ""},
            {8,  "JOB08", "Chuyên viên NS",       3, "Nhân sự",   5,  ""},
            {9,  "JOB09", "Trưởng phòng NS",      3, "Nhân sự",   1,  ""},
            {10, "JOB10", "Marketing Manager",    4, "Marketing", 2,  ""},
            {11, "JOB11", "Content Creator",      4, "Marketing", 6,  ""},
            {12, "JOB12", "Sales Executive",      5, "Kinh doanh",8,  ""},
            {13, "JOB13", "Sales Manager",        5, "Kinh doanh",2,  ""},
            {14, "JOB14", "Ops Manager",          6, "Vận hành",  2,  ""},
            {15, "JOB15", "Kỹ thuật viên vận hành",6,"Vận hành", 5,  ""}
        }
        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New JobRow()
            r.Id = CInt(rows(i, 0)) : r.Code = CStr(rows(i, 1))
            r.Name = CStr(rows(i, 2)) : r.DeptId = CInt(rows(i, 3))
            r.DeptName = CStr(rows(i, 4)) : r.EmpCount = CInt(rows(i, 5))
            r.Note = CStr(rows(i, 6)) : r.Status = 1
            _all.Add(r)
        Next
    End Sub

    Private Sub RenderTable(data As List(Of JobRow))
        dgv.Rows.Clear()
        For Each r In data
            dgv.Rows.Add(r.Code, r.Name, r.DeptName, r.EmpCount,
                         If(r.Status = 1, "● Hoạt động", "○ Ngừng"))
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.Id
            row.Cells("colStatus").Style.ForeColor = If(r.Status = 1,
                Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        lblRowInfo.Text = String.Format("{0} chức danh  ·  {1} phòng ban",
                                         data.Count,
                                         data.Select(Function(x) x.DeptId).Distinct().Count())
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id : RenderTable(_filtered)
        Dim r As JobRow = Nothing
        For Each x In _all
            If x.Id = id Then : r = x : Exit For
            End If
        Next
        If r.Id = 0 Then Return
        lblHdrTitle.Text = r.Name
        lblHdrSub.Text = r.Code & "  ·  " & r.DeptName & "  ·  " & r.EmpCount & " nhân viên"
        lblHdrBadge.Text = If(r.Status = 1, "● Đang hoạt động", "○ Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(r.Status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.Status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
        txtFCode.Text = r.Code : txtFName.Text = r.Name : txtFNote.Text = r.Note
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)
        Dim dIdx = Array.IndexOf(_depts, r.DeptName)
        cboFDept.SelectedIndex = If(dIdx >= 0, dIdx + 1, 0)
        btnDelete.Enabled = (r.EmpCount = 0)
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

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        Dim st = cboStatusFilter.SelectedIndex
        _filtered = New List(Of JobRow)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.Code.ToLower().Contains(q) OrElse r.Name.ToLower().Contains(q)
            Dim mD = dept = "" OrElse r.DeptName = dept
            Dim mS = st = 0 OrElse (st = 1 AndAlso r.Status = 1) OrElse (st = 2 AndAlso r.Status = 0)
            If mQ AndAlso mD AndAlso mS Then _filtered.Add(r)
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
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã chức danh.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên chức danh.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus() : Return
        End If
        If cboFDept.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFDept.Focus() : Return
        End If
        MessageBox.Show("Đã lưu: " & txtFName.Text & "  —  " & cboFDept.SelectedItem.ToString(),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim r As JobRow = Nothing
        For Each x In _all
            If x.Id = _selId Then : r = x : Exit For
            End If
        Next
        If r.EmpCount > 0 Then
            MessageBox.Show("Không thể xóa chức danh đang có nhân viên.", "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim res = MessageBox.Show("Xóa chức danh """ & r.Name & """?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1 : NewItem()
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear() : txtFName.Clear() : txtFNote.Clear()
        cboFDept.SelectedIndex = 0 : cboFStatus.SelectedIndex = 0
        lblHdrTitle.Text = "Thêm chức danh mới"
        lblHdrSub.Text = "Điền thông tin bên dưới"
        lblHdrBadge.Text = "● Đang hoạt động"
        lblHdrBadge.ForeColor = Color.FromArgb(76, 175, 80)
        lblHdrBadge.BackColor = Color.FromArgb(20, 76, 175, 80)
        btnDelete.Enabled = False
        RenderTable(_filtered)
        txtFCode.Focus()
    End Sub

    Private Sub Icon_Paint(s As Object, e As PaintEventArgs)
        Dim g = e.Graphics : g.SmoothingMode = SmoothingMode.AntiAlias
        Dim w = pnlHdrIcon.Width, h = pnlHdrIcon.Height, p = 10
        Using br = New SolidBrush(Color.FromArgb(20, 123, 97, 255)) : g.FillRectangle(br, 0, 0, w, h) : End Using
        Using pen = New Pen(Color.FromArgb(123, 97, 255), 1.5!)
            ' Person icon
            g.DrawEllipse(pen, p + 12, p + 2, 14, 14)
            g.DrawArc(pen, p + 4, p + 18, 30, 20, 0, 180)
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
