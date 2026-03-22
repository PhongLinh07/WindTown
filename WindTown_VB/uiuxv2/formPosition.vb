Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq

' ============================================================
'  formPosition.vb — Vị trí (.NET 8) — Dữ liệu qua PositionSV / Contract / Salary_Mult
' ============================================================
Public Class formPosition

    Private Structure PositionRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim DeptId As Integer
        Dim DeptName As String
        Dim ContractId As Integer
        Dim SalaryMultId As Integer
        Dim BaseSalary As Decimal
        Dim EffectiveDate As Date
        Dim Note As String
        Dim Status As Integer
    End Structure

    Private ReadOnly _contractIds As New List(Of Integer)()
    Private ReadOnly _salaryMultIds As New List(Of Integer)()
    Private ReadOnly _deptIds As New List(Of Integer)()

    Private _loaded As New List(Of Position)()
    Private _all As New List(Of PositionRow)()
    Private _filtered As New List(Of PositionRow)()
    Private _selId As Integer = -1

    Private Sub formPosition_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        UiTextBoxHints.SetCueBanner(txtSearch, "Tìm mã hoặc mô tả vị trí...")
        UiTextBoxHints.SetCueBanner(txtFCode, "Mã vị trí (code)")
        UiTextBoxHints.SetCueBanner(txtFName, "Hiển thị: công việc / trình độ")
        UiTextBoxHints.SetCueBanner(txtFNote, "Ghi chú...")
        UiTextBoxHints.SetCueBanner(txtFBaseSalary, "Lương HĐ (VNĐ) — chỉnh sẽ cập nhật hợp đồng")

        toolTip1.SetToolTip(cboFContract, "Chọn hợp đồng áp dụng")
        toolTip1.SetToolTip(cboFSalaryMult, "Chọn hệ số lương (job + level + phòng ban)")
        toolTip1.SetToolTip(txtFBaseSalary, "Lương cơ bản từ hợp đồng")
        toolTip1.SetToolTip(dtpEffective, "Ngày bắt đầu vị trí")
        toolTip1.SetToolTip(cboFDept, "Lọc theo phòng ban của công việc")
        toolTip1.SetToolTip(cboFStatus, "Trạng thái vị trí")

        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize

        PopulateCombos()
        ReloadFromDatabase()

        _filtered = New List(Of PositionRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub PopulateCombos()
        cboFDept.Items.Clear()
        _deptIds.Clear()
        cboFDept.Items.Add("— Chọn phòng ban —")
        _deptIds.Add(0)

        Dim rd = AppServices.Instance.DepartmentSV.GetList()
        If rd.IsSuccess AndAlso rd.Data IsNot Nothing Then
            For Each d In CType(rd.Data, List(Of Department)).OrderBy(Function(x) x.name)
                cboFDept.Items.Add(d.name)
                _deptIds.Add(d.id)
            Next
        End If
        cboFDept.SelectedIndex = 0

        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.Add("Tất cả phòng ban")
        If rd.IsSuccess AndAlso rd.Data IsNot Nothing Then
            For Each d In CType(rd.Data, List(Of Department)).OrderBy(Function(x) x.name)
                cboDeptFilter.Items.Add(d.name)
            Next
        End If
        cboDeptFilter.SelectedIndex = 0

        cboFStatus.SelectedIndex = 0

        cboFContract.Items.Clear()
        _contractIds.Clear()
        cboFContract.Items.Add("— Chọn hợp đồng —")
        _contractIds.Add(0)

        Dim rc = AppServices.Instance.ContractSV.GetList()
        If rc.IsSuccess AndAlso rc.Data IsNot Nothing Then
            For Each c In CType(rc.Data, List(Of Contract)).OrderBy(Function(x) x.code)
                Dim line = c.code & " — " & c.employee_UI
                cboFContract.Items.Add(line)
                _contractIds.Add(c.id)
            Next
        End If
        cboFContract.SelectedIndex = 0

        cboFSalaryMult.Items.Clear()
        _salaryMultIds.Clear()
        cboFSalaryMult.Items.Add("— Chọn hệ số —")
        _salaryMultIds.Add(0)

        Dim rs = AppServices.Instance.Salary_MultSV.GetList()
        If rs.IsSuccess AndAlso rs.Data IsNot Nothing Then
            For Each sm In CType(rs.Data, List(Of Salary_Mult)).OrderBy(Function(x) x.Job?.name).ThenBy(Function(x) x.level_UI)
                Dim dept = sm.Job?.Department?.name
                Dim line = If(String.IsNullOrWhiteSpace(dept), "", dept & " · ") &
                    If(sm.Job?.name, "?") & " / " & sm.level_UI &
                    " (x" & sm.mult.ToString("0.##") & ")"
                cboFSalaryMult.Items.Add(line)
                _salaryMultIds.Add(sm.id)
            Next
        End If
        cboFSalaryMult.SelectedIndex = 0
    End Sub

    Private Sub ReloadFromDatabase()
        _all.Clear()
        _loaded.Clear()
        Dim res = AppServices.Instance.PositionSV.GetList()
        If Not res.IsSuccess OrElse res.Data Is Nothing Then
            MessageBox.Show("Không tải được danh sách vị trí: " & res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        _loaded = CType(res.Data, List(Of Position))
        For Each pos In _loaded
            Dim r As New PositionRow()
            r.Id = pos.id
            r.Code = If(pos.code, "")
            Dim j = pos.job_UI
            Dim lv = pos.level_UI
            r.Name = (j & " / " & lv).Trim()
            If r.Name = "/" Then r.Name = r.Code
            r.DeptId = If(pos.Salary_Mult?.Job?.department_id, 0)
            r.DeptName = If(pos.Salary_Mult?.Job?.Department?.name, "---")
            r.ContractId = pos.contract_id
            r.SalaryMultId = pos.salary_mult_id
            r.BaseSalary = If(pos.Contract?.base_salary, 0D)
            r.EffectiveDate = pos.start_date.Date
            r.Note = If(pos.note, "")
            r.Status = pos.status
            _all.Add(r)
        Next
    End Sub

    Private Sub RenderTable(data As List(Of PositionRow))
        dgv.Rows.Clear()
        For Each r In data
            dgv.Rows.Add(r.Code, r.Name, r.DeptName, GetContractLine(r.ContractId),
                         If(r.Status = 1, "Đang dùng", "Tạm dừng"))
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.Id
            row.Cells("colStatus").Style.ForeColor = If(r.Status = 1,
                Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        Dim deptCount = data.Where(Function(x) Not String.IsNullOrWhiteSpace(x.DeptName) AndAlso x.DeptName <> "---").
            Select(Function(x) x.DeptName).Distinct().Count()
        lblRowInfo.Text = String.Format("{0} vị trí  ·  {1} phòng ban", data.Count, deptCount)
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Function GetContractLine(contractId As Integer) As String
        Dim idx = _contractIds.IndexOf(contractId)
        If idx > 0 AndAlso idx < cboFContract.Items.Count Then
            Return cboFContract.Items(idx).ToString()
        End If
        Return "—"
    End Function

    Private Sub SelectItem(id As Integer)
        _selId = id
        RenderTable(_filtered)
        Dim r As PositionRow = Nothing
        Dim found = False
        For Each x In _all
            If x.Id = id Then
                r = x
                found = True
                Exit For
            End If
        Next
        If Not found Then Return

        lblHdrTitle.Text = r.Name
        lblHdrSub.Text = r.Code & "  ·  " & r.DeptName
        lblHdrBadge.Text = If(r.Status = 1, "Đang dùng", "Tạm dừng")
        lblHdrBadge.ForeColor = If(r.Status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.Status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))

        txtFCode.Text = r.Code
        txtFName.Text = r.Name
        txtFNote.Text = r.Note
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)

        Dim di = _deptIds.IndexOf(r.DeptId)
        cboFDept.SelectedIndex = If(di >= 0, di, 0)

        Dim ci = _contractIds.IndexOf(r.ContractId)
        cboFContract.SelectedIndex = If(ci >= 0, ci, 0)

        Dim si = _salaryMultIds.IndexOf(r.SalaryMultId)
        cboFSalaryMult.SelectedIndex = If(si >= 0, si, 0)

        txtFBaseSalary.Text = r.BaseSalary.ToString("0")
        dtpEffective.Value = r.EffectiveDate

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

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        Dim st = cboStatusFilter.SelectedIndex
        _filtered = New List(Of PositionRow)()
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
            MessageBox.Show("Vui lòng nhập mã vị trí.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus()
            Return
        End If
        If cboFDept.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn phòng ban (theo công việc).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFDept.Focus()
            Return
        End If
        If cboFContract.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn hợp đồng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFContract.Focus()
            Return
        End If
        If cboFSalaryMult.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn hệ số lương.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFSalaryMult.Focus()
            Return
        End If

        Dim deptId = _deptIds(cboFDept.SelectedIndex)
        Dim smId = _salaryMultIds(cboFSalaryMult.SelectedIndex)
        Dim smList = AppServices.Instance.Salary_MultSV.GetList()
        If smList.IsSuccess AndAlso smList.Data IsNot Nothing Then
            Dim sm = CType(smList.Data, List(Of Salary_Mult)).FirstOrDefault(Function(x) x.id = smId)
            If sm IsNot Nothing AndAlso sm.Job IsNot Nothing AndAlso sm.Job.department_id <> deptId Then
                MessageBox.Show("Phòng ban đã chọn không khớp với công việc của hệ số lương.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Dim contractId = _contractIds(cboFContract.SelectedIndex)
        Dim code = txtFCode.Text.Trim()

        If _selId <= 0 Then
            Dim dup = _all.Any(Function(x) String.Equals(x.Code, code, StringComparison.OrdinalIgnoreCase))
            If dup Then
                MessageBox.Show("Mã vị trí đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Dim pos As Position
        If _selId > 0 Then
            pos = _loaded.FirstOrDefault(Function(x) x.id = _selId)
            If pos Is Nothing Then
                MessageBox.Show("Không tìm thấy bản ghi để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            pos = New Position()
        End If

        pos.code = code
        pos.contract_id = contractId
        pos.salary_mult_id = smId
        pos.start_date = dtpEffective.Value.Date
        pos.note = txtFNote.Text.Trim()
        pos.status = If(cboFStatus.SelectedIndex = 0, 1, 0)
        pos.Contract = Nothing
        pos.Salary_Mult = Nothing

        Dim salaryVal As Decimal
        If Decimal.TryParse(txtFBaseSalary.Text.Trim(), Globalization.NumberStyles.Any, Globalization.CultureInfo.CurrentCulture, salaryVal) OrElse
            Decimal.TryParse(txtFBaseSalary.Text.Trim(), salaryVal) Then
            Dim rc = AppServices.Instance.ContractSV.GetList()
            If rc.IsSuccess AndAlso rc.Data IsNot Nothing Then
                Dim ctr = CType(rc.Data, List(Of Contract)).FirstOrDefault(Function(x) x.id = contractId)
                If ctr IsNot Nothing Then
                    ctr.base_salary = salaryVal
                    ctr.Employee = Nothing
                    Dim ur = AppServices.Instance.ContractSV.Update(ctr)
                    If Not ur.IsSuccess Then
                        MessageBox.Show("Không cập nhật được lương hợp đồng: " & ur.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            End If
        End If

        Dim result As ServiceResponse(Of Object)
        If _selId > 0 Then
            result = AppServices.Instance.PositionSV.Update(pos)
        Else
            result = AppServices.Instance.PositionSV.Insert(pos)
        End If

        If result.IsSuccess Then
            MessageBox.Show("Đã lưu vị trí.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PopulateCombos()
            ReloadFromDatabase()
            ApplyFilter()
            If _selId > 0 Then
                SelectItem(_selId)
            ElseIf _all.Count > 0 Then
                SelectItem(_all.Last().Id)
            End If
        Else
            MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim res = MessageBox.Show("Xóa vị trí này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res <> DialogResult.Yes Then Return

        Dim p As New Position With {.id = _selId}
        Dim dr = AppServices.Instance.PositionSV.Delete(New List(Of Position) From {p})
        If dr.IsSuccess Then
            MessageBox.Show("Đã xóa vị trí.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1
            PopulateCombos()
            ReloadFromDatabase()
            ApplyFilter()
            NewItem()
        Else
            MessageBox.Show(dr.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear()
        txtFName.Clear()
        txtFNote.Clear()
        cboFDept.SelectedIndex = 0
        cboFStatus.SelectedIndex = 0
        cboFContract.SelectedIndex = 0
        cboFSalaryMult.SelectedIndex = 0
        txtFBaseSalary.Text = ""
        dtpEffective.Value = Date.Today
        lblHdrTitle.Text = "Thêm vị trí mới"
        lblHdrSub.Text = "Điền thông tin bên dưới"
        lblHdrBadge.Text = "Đang dùng"
        lblHdrBadge.ForeColor = Color.FromArgb(76, 175, 80)
        lblHdrBadge.BackColor = Color.FromArgb(20, 76, 175, 80)
        btnDelete.Enabled = False
        RenderTable(_filtered)
        txtFCode.Focus()
    End Sub

    Private Sub Icon_Paint(s As Object, e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim w = pnlHdrIcon.Width
        Dim h = pnlHdrIcon.Height
        Dim p = 10
        Using br = New SolidBrush(Color.FromArgb(20, 123, 97, 255))
            g.FillRectangle(br, 0, 0, w, h)
        End Using
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
