Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Drawing
Public Class formDepartment


    ' ============================================================
    '  formDepartment.vb — Phòng ban  (.NET 4.8 · Mock data)
    '  table: department  |  datas: code, name, note, status
    ' ============================================================

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Sub SetPH(tb As TextBox, h As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), h)
    End Sub

    Private Structure DeptRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim EmpCount As Integer
        Dim Note As String
        Dim Status As Integer   ' 1=active 0=inactive
    End Structure

    Private _all As New List(Of DeptRow)()
    Private _filtered As New List(Of DeptRow)()
    Private _selId As Integer = -1

    Private Sub formDepartment_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        SetPH(txtSearch, "🔍  Tìm mã hoặc tên phòng ban...")
        SetPH(txtFCode, "DEPT01")
        SetPH(txtFName, "Kỹ thuật")
        SetPH(txtFNote, "Ghi chú...")
        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        LoadMock()
        _filtered = New List(Of DeptRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub LoadMock()
        _all.Clear()
        Dim rows(,) As Object = {
        {1, "DEPT01", "Kỹ thuật", 54, "Phòng phát triển phần mềm và hạ tầng"},
        {2, "DEPT02", "Kế toán", 28, "Phòng tài chính kế toán"},
        {3, "DEPT03", "Nhân sự", 12, "Phòng quản lý nhân lực"},
        {4, "DEPT04", "Marketing", 18, "Phòng truyền thông và marketing"},
        {5, "DEPT05", "Kinh doanh", 32, "Phòng kinh doanh và bán hàng"},
        {6, "DEPT06", "Vận hành", 24, "Phòng vận hành hệ thống"},
        {7, "DEPT07", "Pháp lý", 6, "Phòng pháp lý và tuân thủ"},
        {8, "DEPT08", "R&D", 14, "Phòng nghiên cứu và phát triển"}
    }
        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New DeptRow()
            r.Id = CInt(rows(i, 0)) : r.Code = CStr(rows(i, 1))
            r.Name = CStr(rows(i, 2)) : r.EmpCount = CInt(rows(i, 3))
            r.Note = CStr(rows(i, 4)) : r.Status = 1
            _all.Add(r)
        Next
        ' Dept 7 inactive
        Dim d7 = _all(6) : d7.Status = 0 : _all(6) = d7
    End Sub

    Private Sub RenderTable(data As List(Of DeptRow))
        dgv.Rows.Clear()
        For Each r In data
            dgv.Rows.Add(r.Code, r.Name, r.EmpCount, If(r.Status = 1, "● Hoạt động", "○ Ngừng"))
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.Id
            row.Cells("colStatus").Style.ForeColor = If(r.Status = 1,
            Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        Dim active = data.Where(Function(x) x.Status = 1).Count()
        lblRowInfo.Text = String.Format("{0} phòng ban  ·  {1} hoạt động", data.Count, active)
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id
        RenderTable(_filtered)
        Dim r As DeptRow = Nothing
        Dim found = False
        For Each x In _all
            If x.Id = id Then : r = x : found = True : Exit For
            End If
        Next
        If Not found Then Return
        lblHdrTitle.Text = r.Name
        lblHdrSub.Text = r.Code & "  ·  " & r.EmpCount & " nhân viên"
        lblHdrBadge.Text = If(r.Status = 1, "● Đang hoạt động", "○ Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(r.Status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.Status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
        txtFCode.Text = r.Code : txtFName.Text = r.Name
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)
        txtFNote.Text = r.Note
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

    Private Sub cboStatusFilter_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim st = cboStatusFilter.SelectedIndex
        _filtered = New List(Of DeptRow)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.Code.ToLower().Contains(q) OrElse r.Name.ToLower().Contains(q)
            Dim mS = st = 0 OrElse (st = 1 AndAlso r.Status = 1) OrElse (st = 2 AndAlso r.Status = 0)
            If mQ AndAlso mS Then _filtered.Add(r)
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
            MessageBox.Show("Vui lòng nhập mã phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus() : Return
        End If
        MessageBox.Show("Đã lưu: " & txtFName.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim r As DeptRow = Nothing
        For Each x In _all
            If x.Id = _selId Then : r = x : Exit For
            End If
        Next
        If r.EmpCount > 0 Then
            MessageBox.Show("Không thể xóa phòng ban đang có nhân viên.", "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim res = MessageBox.Show("Xóa phòng ban """ & r.Name & """?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1 : NewItem()
        End If
    End Sub

    Private Sub cboFStatus_SelectedIndexChanged(s As Object, e As EventArgs) Handles cboFStatus.SelectedIndexChanged
        Dim active = (cboFStatus.SelectedIndex = 0)
        lblHdrBadge.Text = If(active, "● Đang hoạt động", "○ Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(active, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(active, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear() : txtFName.Clear() : txtFNote.Clear()
        cboFStatus.SelectedIndex = 0
        lblHdrTitle.Text = "Thêm phòng ban mới"
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
        Using br = New SolidBrush(Color.FromArgb(20, 74, 158, 255)) : g.FillRectangle(br, 0, 0, w, h) : End Using
        Using pen = New Pen(Color.FromArgb(74, 158, 255), 1.5!)
            ' Building icon: 3 rectangles
            g.DrawRectangle(pen, p, p + 10, 10, 18)
            g.DrawRectangle(pen, p + 14, p + 4, 12, 24)
            g.DrawRectangle(pen, p + 30, p + 8, 10, 20)
            Using br = New SolidBrush(Color.FromArgb(60, 74, 158, 255))
                g.FillRectangle(br, p, p + 10, 10, 18)
                g.FillRectangle(br, p + 14, p + 4, 12, 24)
                g.FillRectangle(br, p + 30, p + 8, 10, 20)
            End Using
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
