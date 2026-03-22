Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

' ============================================================
'  formJob.vb — Chức danh  (.NET 8 · DB qua JobSV)
' ============================================================
Public Class formJob

    Private Class IdNameItem
        Public Id As Integer
        Public Caption As String
        Public Sub New(id As Integer, caption As String)
            Me.Id = id
            Me.Caption = caption
        End Sub
        Public Overrides Function ToString() As String
            Return Caption
        End Function
    End Class

    Private ReadOnly _jobSv = AppServices.Instance.JobSV
    Private ReadOnly _deptSv = AppServices.Instance.DepartmentSV

    Private _all As New List(Of Job)()
    Private _filtered As New List(Of Job)()
    Private _selId As Integer = -1

    Private Shared Function DeptName(j As Job) As String
        Return If(j.Department IsNot Nothing, j.Department.name, "—")
    End Function

    Private Function SalaryMultCount(jobId As Integer) As Integer
        Dim res = AppServices.Instance.Salary_MultSV.GetList()
        If Not res.IsSuccess Then Return 0
        Return CType(res.Data, IEnumerable(Of Salary_Mult)).Count(
            Function(sm) sm.job_id = jobId AndAlso sm.status <> -1)
    End Function

    Private Sub formJob_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        UiTextBoxHints.SetCueBanner(txtSearch, "Tìm mã hoặc tên chức danh...")
        UiTextBoxHints.SetCueBanner(txtFCode, "JOB01")
        UiTextBoxHints.SetCueBanner(txtFName, "Lập trình viên")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú...")
        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize

        PopulateDeptCombos()
        LoadData()
    End Sub

    Private Sub PopulateDeptCombos()
        Dim dr = _deptSv.GetList()
        Dim depts = If(dr.IsSuccess,
                       CType(dr.Data, IEnumerable(Of Department)).OrderBy(Function(x) x.name).ToList(),
                       New List(Of Department)())

        cboFDept.Items.Clear()
        cboFDept.Items.Add(New IdNameItem(0, "— Chọn phòng ban —"))
        For Each d In depts
            cboFDept.Items.Add(New IdNameItem(d.id, d.name))
        Next
        cboFDept.SelectedIndex = 0

        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.Add("Tất cả phòng ban")
        For Each d In depts
            cboDeptFilter.Items.Add(d.name)
        Next
        cboDeptFilter.SelectedIndex = 0
    End Sub

    Private Sub LoadData()
        Dim res = _jobSv.GetList()
        If Not res.IsSuccess Then
            MessageBox.Show(res.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _all = New List(Of Job)()
        Else
            _all = CType(res.Data, IEnumerable(Of Job)).ToList()
        End If
        _filtered = New List(Of Job)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then
            If _selId > 0 AndAlso _all.Any(Function(x) x.id = _selId) Then
                SelectItem(_selId)
            Else
                SelectItem(_all(0).id)
            End If
        Else
            NewItem()
        End If
    End Sub

    Private Sub RenderTable(data As List(Of Job))
        dgv.Rows.Clear()
        For Each r In data
            Dim dn = DeptName(r)
            Dim smc = SalaryMultCount(r.id)
            dgv.Rows.Add(r.code, r.name, dn, smc,
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
        lblRowInfo.Text = String.Format("{0} chức danh  ·  {1} phòng ban",
                                         data.Count,
                                         data.Select(Function(x) x.department_id).Distinct().Count())
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id
        RenderTable(_filtered)
        Dim r = _all.FirstOrDefault(Function(x) x.id = id)
        If r Is Nothing Then Return
        lblHdrTitle.Text = r.name
        lblHdrSub.Text = r.code & "  ·  " & DeptName(r) & "  ·  " & SalaryMultCount(r.id).ToString() & " hệ số"
        lblHdrBadge.Text = If(r.status = 1, "Đang hoạt động", "Ngừng hoạt động")
        lblHdrBadge.ForeColor = If(r.status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))
        txtFCode.Text = r.code
        txtFName.Text = r.name
        txtFNote.Text = r.note
        cboFStatus.SelectedIndex = If(r.status = 1, 0, 1)
        For i = 0 To cboFDept.Items.Count - 1
            Dim it = TryCast(cboFDept.Items(i), IdNameItem)
            If it IsNot Nothing AndAlso it.Id = r.department_id Then
                cboFDept.SelectedIndex = i
                Exit For
            End If
        Next
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
        _filtered = New List(Of Job)()
        For Each r In _all
            Dim mQ = q = "" OrElse r.code.ToLower().Contains(q) OrElse r.name.ToLower().Contains(q)
            Dim mD = dept = "" OrElse DeptName(r) = dept
            Dim mS = st = 0 OrElse (st = 1 AndAlso r.status = 1) OrElse (st = 2 AndAlso r.status = 0)
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
        Dim deptItem = TryCast(cboFDept.SelectedItem, IdNameItem)
        If deptItem Is Nothing OrElse deptItem.Id <= 0 Then
            MessageBox.Show("Vui lòng chọn phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim code = txtFCode.Text.Trim()

        If _selId <= 0 Then
            If _jobSv.IsCodeDuplicate(code, 0) Then
                MessageBox.Show("Mã chức danh đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFCode.Focus() : Return
            End If
            Dim j As New Job()
            j.code = code
            j.name = txtFName.Text.Trim()
            j.note = txtFNote.Text.Trim()
            j.department_id = deptItem.Id
            j.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _jobSv.Insert(j)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã thêm chức danh.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _selId = j.id
                LoadData()
            Else
                MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If _jobSv.IsCodeDuplicate(code, _selId) Then
                MessageBox.Show("Mã chức danh đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFCode.Focus() : Return
            End If
            Dim existing = _all.FirstOrDefault(Function(x) x.id = _selId)
            If existing Is Nothing Then Return
            existing.code = code
            existing.name = txtFName.Text.Trim()
            existing.note = txtFNote.Text.Trim()
            existing.department_id = deptItem.Id
            existing.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
            Dim res = _jobSv.Update(existing)
            If res.IsSuccess Then
                MessageBox.Show(If(String.IsNullOrEmpty(res.Message), "Đã cập nhật chức danh.", res.Message), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Không thể xóa chức danh đang có hệ số lương (salary_mult) liên kết.", "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim ask = MessageBox.Show("Ngừng sử dụng chức danh """ & r.name & """?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If ask <> DialogResult.Yes Then Return
        Dim res = _jobSv.Delete(New List(Of Job) From {r})
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
        cboFDept.SelectedIndex = 0
        cboFStatus.SelectedIndex = 0
        lblHdrTitle.Text = "Thêm chức danh mới"
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
        Dim w = pnlHdrIcon.Width, h = pnlHdrIcon.Height, p = 10
        Using br = New SolidBrush(Color.FromArgb(20, 123, 97, 255)) : g.FillRectangle(br, 0, 0, w, h) : End Using
        Using pen = New Pen(Color.FromArgb(123, 97, 255), 1.5!)
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
