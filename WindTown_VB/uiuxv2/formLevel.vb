Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

' ============================================================
'  formLevel.vb — Cấp bậc  (.NET 8 · DB qua LevelSV)
' ============================================================
Public Class formLevel

    Private ReadOnly _levelSv = AppServices.Instance.LevelSV

    Private _all As New List(Of Level)()
    Private _filtered As New List(Of Level)()
    Private _selId As Integer = -1
    Private _rank As Integer = 1

    Private Function SalaryMultCount(levelId As Integer) As Integer
        Dim res = AppServices.Instance.Salary_MultSV.GetList()
        If Not res.IsSuccess Then Return 0
        Return CType(res.Data, IEnumerable(Of Salary_Mult)).Count(
            Function(sm) sm.level_id = levelId AndAlso sm.status <> -1)
    End Function

    Private Function IsCodeDuplicate(code As String, excludeId As Integer) As Boolean
        Dim res = _levelSv.GetList()
        If Not res.IsSuccess Then Return False
        Return CType(res.Data, IEnumerable(Of Level)).Any(
            Function(x) x.code = code AndAlso x.id <> excludeId)
    End Function

    Private Sub formLevel_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        UiTextBoxHints.SetCueBanner(txtSearch, "Tìm mã hoặc tên cấp bậc...")
        UiTextBoxHints.SetCueBanner(txtFCode, "LV01")
        UiTextBoxHints.SetCueBanner(txtFName, "Nhân viên")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú...")
        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim res = _levelSv.GetList()
        If Not res.IsSuccess Then
            MessageBox.Show(res.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _all = New List(Of Level)()
        Else
            _all = CType(res.Data, IEnumerable(Of Level)).ToList()
        End If
        _filtered = New List(Of Level)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then
            If _selId > 0 AndAlso _all.Any(Function(x) x.id = _selId) Then
                SelectItem(_selId)
            Else
                SelectItem(_all.OrderBy(Function(x) x.rank).First().id)
            End If
        Else
            NewItem()
        End If
    End Sub

    Private Sub RenderTable(data As List(Of Level))
        Dim sorted = data.OrderBy(Function(x) x.rank).ToList()
        dgv.Rows.Clear()
        For Each r In sorted
            Dim smc = SalaryMultCount(r.id)
            dgv.Rows.Add(r.rank, r.code, r.name, smc,
                         If(r.status = 1, "Hoạt động", "Ngừng"))
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.id
            row.Cells("colStatus").Style.ForeColor = If(r.status = 1,
                Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            If r.id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        Dim totalSm = sorted.Sum(Function(x) SalaryMultCount(x.id))
        lblRowInfo.Text = String.Format("{0} cấp bậc  ·  {1} liên kết hệ số", data.Count, totalSm)
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id
        RenderTable(_filtered)
        Dim r = _all.FirstOrDefault(Function(x) x.id = id)
        If r Is Nothing Then Return
        lblHdrTitle.Text = r.name
        lblHdrSub.Text = r.code & "  ·  Rank " & r.rank.ToString() & "  ·  " & SalaryMultCount(r.id).ToString() & " hệ số"
        lblHdrBadge.Text = If(r.status = 1, "Đang hoạt động", "Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(r.status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
        txtFCode.Text = r.code
        txtFName.Text = r.name
        txtFNote.Text = r.note
        cboFStatus.SelectedIndex = If(r.status = 1, 0, 1)
        _rank = r.rank
        lblRankNum.Text = _rank.ToString()
        btnDelete.Enabled = (SalaryMultCount(r.id) = 0)
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
        _filtered = New List(Of Level)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.code.ToLower().Contains(q) OrElse r.name.ToLower().Contains(q)
            Dim mS = st = 0 OrElse (st = 1 AndAlso r.status = 1) OrElse (st = 2 AndAlso r.status = 0)
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

        Dim code = txtFCode.Text.Trim()

        If _selId <= 0 Then
            If IsCodeDuplicate(code, 0) Then
                MessageBox.Show("Mã cấp bậc đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFCode.Focus() : Return
            End If
            Dim lv As New Level()
            lv.code = code
            lv.name = txtFName.Text.Trim()
            lv.note = txtFNote.Text.Trim()
            lv.rank = _rank
            lv.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _levelSv.Insert(lv)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã thêm cấp bậc.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _selId = lv.id
                LoadData()
            Else
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If IsCodeDuplicate(code, _selId) Then
                MessageBox.Show("Mã cấp bậc đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFCode.Focus() : Return
            End If
            Dim existing = _all.FirstOrDefault(Function(x) x.id = _selId)
            If existing Is Nothing Then Return
            existing.code = code
            existing.name = txtFName.Text.Trim()
            existing.note = txtFNote.Text.Trim()
            existing.rank = _rank
            existing.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _levelSv.Update(existing)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã cập nhật cấp bậc.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Else
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim r = _all.FirstOrDefault(Function(x) x.id = _selId)
        If r Is Nothing Then Return
        If SalaryMultCount(r.id) > 0 Then
            MessageBox.Show("Không thể xóa cấp bậc đang có hệ số lương liên kết.", "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim ask = MessageBox.Show("Ngừng sử dụng cấp bậc """ & r.name & """?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ask <> DialogResult.Yes Then Return
        Dim res = _levelSv.Delete(New List(Of Level) From {r})
        If res.IsSuccess Then
            MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã xóa.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1
            LoadData()
        Else
            MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear()
        txtFName.Clear()
        txtFNote.Clear()
        cboFStatus.SelectedIndex = 0
        _rank = If(_all.Count = 0, 1, _all.Max(Function(x) x.rank) + 1)
        lblRankNum.Text = _rank.ToString()
        lblHdrTitle.Text = "Thêm cấp bậc mới"
        lblHdrSub.Text = "Điền thông tin bên dưới"
        lblHdrBadge.Text = "Đang hoạt động"
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
