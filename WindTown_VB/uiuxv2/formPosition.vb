Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

' ============================================================
'  formPosition.vb — Vị trí  (.NET 4.8 · Mock data)
'  table: position  |  datas: code, name, dept, contract, salary_mult,
'           base_salary, effective_date, note, status
' ============================================================
Public Class formPosition

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501
    Private Sub SetPH(tb As TextBox, h As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), h)
    End Sub

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

    Private Structure ContractRef
        Dim Id As Integer
        Dim Name As String
    End Structure

    Private Structure SalaryMultRef
        Dim Id As Integer
        Dim Name As String
        Dim Mult As Decimal
    End Structure

    Private ReadOnly _depts() As String = {
        "Kỹ thuật", "Kế toán", "Nhân sự",
        "Marketing", "Kinh doanh", "Vận hành"
    }

    Private ReadOnly _contracts As New List(Of ContractRef)()
    Private ReadOnly _salaryMults As New List(Of SalaryMultRef)()

    Private _all As New List(Of PositionRow)()
    Private _filtered As New List(Of PositionRow)()
    Private _selId As Integer = -1

    Private Sub formPosition_Load(s As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        SetPH(txtSearch, "🔍  Tìm mã hoặc tên vị trí...")
        SetPH(txtFCode, "POS-ENG")
        SetPH(txtFName, "Lập trình viên")
        SetPH(txtFNote, "Ghi chú...")
        SetPH(txtFBaseSalary, "15000000")

        toolTip1.SetToolTip(cboFContract, "Chọn loại hợp đồng áp dụng")
        toolTip1.SetToolTip(cboFSalaryMult, "Chọn hệ số lương cho vị trí")
        toolTip1.SetToolTip(txtFBaseSalary, "Nhập lương cơ bản (VNĐ)")
        toolTip1.SetToolTip(dtpEffective, "Ngày hiệu lực vị trí")
        toolTip1.SetToolTip(cboFDept, "Chọn phòng ban áp dụng")
        toolTip1.SetToolTip(cboFStatus, "Trạng thái vị trí")

        AddHandler pnlHdrIcon.Paint, AddressOf Icon_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlFoot.Resize, AddressOf OnFootResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize

        PopulateCombos()
        LoadMock()

        _filtered = New List(Of PositionRow)(_all)
        RenderTable(_filtered)
        If _all.Count > 0 Then SelectItem(_all(0).Id)
    End Sub

    Private Sub PopulateCombos()
        ' Dept
        cboFDept.Items.Clear()
        cboFDept.Items.Add("— Chọn phòng ban —")
        For Each d In _depts
            cboFDept.Items.Add(d)
        Next
        cboFDept.SelectedIndex = 0

        ' Status
        cboFStatus.SelectedIndex = 0

        ' Contract & Salary Mult
        _contracts.Clear()
        _contracts.Add(New ContractRef With {.Id = 1, .Name = "Toàn thời gian"})
        _contracts.Add(New ContractRef With {.Id = 2, .Name = "Bán thời gian"})
        _contracts.Add(New ContractRef With {.Id = 3, .Name = "Thực tập"})

        _salaryMults.Clear()
        _salaryMults.Add(New SalaryMultRef With {.Id = 1, .Name = "Level 1", .Mult = 1.0D})
        _salaryMults.Add(New SalaryMultRef With {.Id = 2, .Name = "Level 2", .Mult = 1.4D})
        _salaryMults.Add(New SalaryMultRef With {.Id = 3, .Name = "Level 3", .Mult = 1.8D})
        _salaryMults.Add(New SalaryMultRef With {.Id = 4, .Name = "Lead", .Mult = 2.2D})

        cboFContract.Items.Clear()
        cboFContract.Items.Add("— Chọn hợp đồng —")
        For Each c In _contracts
            cboFContract.Items.Add(c.Name)
        Next
        cboFContract.SelectedIndex = 0

        cboFSalaryMult.Items.Clear()
        cboFSalaryMult.Items.Add("— Chọn hệ số —")
        For Each s In _salaryMults
            cboFSalaryMult.Items.Add(s.Name & " (x" & s.Mult.ToString("0.##") & ")")
        Next
        cboFSalaryMult.SelectedIndex = 0
    End Sub

    Private Sub LoadMock()
        _all.Clear()
        Dim rows(,) As Object = {
            {1, "POS-ENG", "Lập trình viên", 1, "Kỹ thuật", 1, 2, 15000000D, #1/1/2026#, "Áp dụng cho nhân viên full-time.", 1},
            {2, "POS-QA", "QA Engineer", 1, "Kỹ thuật", 1, 2, 13000000D, #2/15/2026#, "", 1},
            {3, "POS-HR", "Chuyên viên nhân sự", 3, "Nhân sự", 1, 1, 12000000D, #1/5/2026#, "Ưu tiên nội bộ.", 1},
            {4, "POS-OPS", "Ops Manager", 6, "Vận hành", 1, 3, 20000000D, #12/1/2025#, "Tạm dừng tuyển.", 0}
        }
        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New PositionRow()
            r.Id = CInt(rows(i, 0)) : r.Code = CStr(rows(i, 1))
            r.Name = CStr(rows(i, 2)) : r.DeptId = CInt(rows(i, 3))
            r.DeptName = CStr(rows(i, 4)) : r.ContractId = CInt(rows(i, 5))
            r.SalaryMultId = CInt(rows(i, 6)) : r.BaseSalary = CDec(rows(i, 7))
            r.EffectiveDate = CDate(rows(i, 8)) : r.Note = CStr(rows(i, 9))
            r.Status = CInt(rows(i, 10))
            _all.Add(r)
        Next
    End Sub

    Private Sub RenderTable(data As List(Of PositionRow))
        dgv.Rows.Clear()
        For Each r In data
            dgv.Rows.Add(r.Code, r.Name, r.DeptName, GetContractName(r.ContractId),
                         If(r.Status = 1, "● Đang dùng", "○ Tạm dừng"))
            Dim row = dgv.Rows(dgv.Rows.Count - 1)
            row.Tag = r.Id
            row.Cells("colStatus").Style.ForeColor = If(r.Status = 1,
                Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
            If r.Id = _selId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next
        lblRowInfo.Text = String.Format("{0} vị trí  ·  {1} phòng ban",
                                         data.Count,
                                         data.Select(Function(x) x.DeptId).Distinct().Count())
        dgv.Size = New Size(pnlLeft.Width, pnlLeft.Height - pnlLeftFoot.Height)
    End Sub

    Private Sub SelectItem(id As Integer)
        _selId = id : RenderTable(_filtered)
        Dim r As PositionRow = Nothing
        For Each x In _all
            If x.Id = id Then : r = x : Exit For
            End If
        Next
        If r.Id = 0 Then Return
        lblHdrTitle.Text = r.Name
        lblHdrSub.Text = r.Code & "  ·  " & r.DeptName
        lblHdrBadge.Text = If(r.Status = 1, "● Đang dùng", "○ Tạm dừng")
        lblHdrBadge.ForeColor = If(r.Status = 1, Color.FromArgb(76, 175, 80), Color.FromArgb(123, 139, 178))
        lblHdrBadge.BackColor = If(r.Status = 1, Color.FromArgb(20, 76, 175, 80), Color.FromArgb(20, 123, 139, 178))

        txtFCode.Text = r.Code
        txtFName.Text = r.Name
        txtFNote.Text = r.Note
        cboFStatus.SelectedIndex = If(r.Status = 1, 0, 1)
        cboFDept.SelectedIndex = If(r.DeptId > 0, r.DeptId, 0)
        cboFContract.SelectedIndex = If(r.ContractId > 0, r.ContractId, 0)
        cboFSalaryMult.SelectedIndex = If(r.SalaryMultId > 0, r.SalaryMultId, 0)
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
            txtFCode.Focus() : Return
        End If
        If String.IsNullOrWhiteSpace(txtFName.Text) Then
            MessageBox.Show("Vui lòng nhập tên vị trí.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFName.Focus() : Return
        End If
        If cboFDept.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn phòng ban.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFDept.Focus() : Return
        End If
        If cboFContract.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn hợp đồng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFContract.Focus() : Return
        End If
        If cboFSalaryMult.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn hệ số lương.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFSalaryMult.Focus() : Return
        End If
        MessageBox.Show("Đã lưu: " & txtFName.Text, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDelete_Click(s As Object, e As EventArgs) Handles btnDelete.Click
        If _selId < 0 Then Return
        Dim res = MessageBox.Show("Xóa vị trí này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selId = -1
            NewItem()
        End If
    End Sub

    Private Sub NewItem()
        _selId = -1
        txtFCode.Clear() : txtFName.Clear() : txtFNote.Clear()
        cboFDept.SelectedIndex = 0 : cboFStatus.SelectedIndex = 0
        cboFContract.SelectedIndex = 0 : cboFSalaryMult.SelectedIndex = 0
        txtFBaseSalary.Text = ""
        dtpEffective.Value = Date.Today
        lblHdrTitle.Text = "Thêm vị trí mới"
        lblHdrSub.Text = "Điền thông tin bên dưới"
        lblHdrBadge.Text = "● Đang dùng"
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

    Private Function GetContractName(id As Integer) As String
        For Each c In _contracts
            If c.Id = id Then Return c.Name
        Next
        Return "—"
    End Function

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
