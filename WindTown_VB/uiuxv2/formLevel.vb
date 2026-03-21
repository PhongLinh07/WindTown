Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

' ============================================================
'  formLevel.vb — Cấp bậc  (.NET 4.8 · Mock data)
'  table: level  |  datas: code, name, note, status
'  rank = thứ hạng (1 = thấp nhất)
' ============================================================
Public Class formLevel

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Sub SetPH(tb As TextBox, h As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), h)
    End Sub

    Private Structure LevelRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Rank As Integer
        Dim EmpCount As Integer
        Dim Note As String
        Dim Status As Integer
    End Structure

    Private _all As New List(Of LevelRow)()
    Private _filtered As New List(Of LevelRow)()
    Private _selId As Integer = -1
    Private _rank As Integer = 1

    Private Sub formLevel_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        SetPH(txtSearch, "🔍  Tìm mã hoặc tên cấp bậc...")
        SetPH(txtFCode, "LV01")
        SetPH(txtFName, "Nhân viên")
        SetPH(txtFNote, "Ghi chú...")
        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        LoadMock()
        _filtered = New List(Of LevelRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub LoadMock()
        _all.Clear()
        Dim rows(,) As Object = {
            {1, "LV01", "Thực tập sinh",   1, 8,  "Sinh viên thực tập"},
            {2, "LV02", "Nhân viên",        2, 62, "Nhân viên chính thức"},
            {3, "LV03", "Nhân viên CK",     3, 48, "Nhân viên chính thức chuyên môn cao"},
            {4, "LV04", "Senior",           4, 32, "Chuyên gia cấp cao"},
            {5, "LV05", "Lead",             5, 18, "Trưởng nhóm kỹ thuật"},
            {6, "LV06", "Manager",          6, 14, "Quản lý phòng ban"},
            {7, "LV07", "Senior Manager",   7, 8,  "Quản lý cấp cao"},
            {8, "LV08", "Director",         8, 4,  "Giám đốc bộ phận"}
        }
        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New LevelRow()
            r.Id = CInt(rows(i, 0)) : r.Code = CStr(rows(i, 1))
            r.Name = CStr(rows(i, 2)) : r.Rank = CInt(rows(i, 3))
            r.EmpCount = CInt(rows(i, 4)) : r.Note = CStr(rows(i, 5))
            r.Status = 1
            _all.Add(r)
        Next
    End Sub

    Private Sub RenderTable(data As List(Of LevelRow))
        ' Sort by rank ascending
        Dim sorted = data.OrderBy(Function(x) x.Rank).ToList()
        dgv.Rows.Clear()
        For Each r In sorted
            dgv.Rows.Add(r.Rank, r.Code, r.Name, r.EmpCount,
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
        lblRowInfo.Text = String.Format("{0} cấp bậc  ·  {1} nhân viên",
                                         data.Count,
                                         data.Sum(Function(x) x.EmpCount))
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id : RenderTable(_filtered)
        Dim r As LevelRow = Nothing
        For Each x In _all
            If x.Id = id Then : r = x : Exit For
            End If
        Next
        If r.Id = 0 Then Return
        lblHdrTitle.Text = r.Name
        lblHdrSub.Text = r.Code & "  ·  Rank " & r.Rank & "  ·  " & r.EmpCount & " nhân viên"
        lblHdrBadge.Text = If(r.Status = 1, "● Đang hoạt động", "○ Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(r.Status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.Status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
        txtFCode.Text = r.Code : txtFName.Text = r.Name : txtFNote.Text = r.Note
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)
        _rank = r.Rank : lblRankNum.Text = _rank.ToString()
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
        _filtered = New List(Of LevelRow)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.Code.ToLower().Contains(q) OrElse r.Name.ToLower().Contains(q)
            Dim mS = st = 0 OrElse (st = 1 AndAlso r.Status = 1) OrElse (st = 2 AndAlso r.Status = 0)
            If mQ AndAlso mS Then _filtered.Add(r)
        Next
        RenderTable(_filtered)
    End Sub

    Private Sub btnRankDec_Click(s As Object, e As EventArgs) Handles btnRankDec.Click
        If _rank > 1 Then
            _rank -= 1
            lblRankNum.Text = _rank.ToString()
        End If
    End Sub
    Private Sub btnRankInc_Click(s As Object, e As EventArgs) Handles btnRankInc.Click
        _rank += 1
        lblRankNum.Text = _rank.ToString()
    End Sub

    Private Sub btnAdd_Click(s As Object, e As EventArgs) Handles btnAdd.Click
        NewItem()
    End Sub
    Private Sub btnClear_Click(s As Object, e As EventArgs) Handles btnClear.Click
        NewItem()
    End Sub

    Private Sub btnSave_Click(s As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã cấp bậc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên cấp bậc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus() : Return
        End If
        MessageBox.Show(String.Format("Đã lưu: {0}  —  Rank {1}", txtFName.Text, _rank),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim r As LevelRow = Nothing
        For Each x In _all
            If x.Id = _selId Then : r = x : Exit For
            End If
        Next
        If r.EmpCount > 0 Then
            MessageBox.Show("Không thể xóa cấp bậc đang có nhân viên.", "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim res = MessageBox.Show("Xóa cấp bậc """ & r.Name & """?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1 : NewItem()
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear() : txtFName.Clear() : txtFNote.Clear()
        cboFStatus.SelectedIndex = 0
        _rank = _all.Count + 1 : lblRankNum.Text = _rank.ToString()
        lblHdrTitle.Text = "Thêm cấp bậc mới"
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
        Dim w = pnlHdrIcon.Width, h = pnlHdrIcon.Height, p = 8
        Using br = New SolidBrush(Color.FromArgb(20, 245, 158, 11)) : g.FillRectangle(br, 0, 0, w, h) : End Using
        ' Stair / rank chart icon
        Using pen = New Pen(Color.FromArgb(245, 158, 11), 2.0!)
            g.DrawLine(pen, p, h - p, p + 10, h - p)
            g.DrawLine(pen, p + 10, h - p, p + 10, h - p - 10)
            g.DrawLine(pen, p + 10, h - p - 10, p + 20, h - p - 10)
            g.DrawLine(pen, p + 20, h - p - 10, p + 20, h - p - 20)
            g.DrawLine(pen, p + 20, h - p - 20, w - p, h - p - 20)
            Using brFill = New SolidBrush(Color.FromArgb(40, 245, 158, 11))
                Dim pts() As System.Drawing.Point = {
                    New System.Drawing.Point(p, h - p),
                    New System.Drawing.Point(p + 10, h - p),
                    New System.Drawing.Point(p + 10, h - p - 10),
                    New System.Drawing.Point(p + 20, h - p - 10),
                    New System.Drawing.Point(p + 20, h - p - 20),
                    New System.Drawing.Point(w - p, h - p - 20),
                    New System.Drawing.Point(w - p, h - p)
                }
                g.FillPolygon(brFill, pts)
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
