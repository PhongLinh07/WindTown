Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

' ============================================================
'  formContract.vb — Quản lý hợp đồng  (.NET 4.8 · Mock data)
'  contract: code, start_date, end_date, base_salary,
'            note, status  — FK: employee_id
' ============================================================
Public Class formContract

    ' ── Win32 placeholder ────────────────────────────────────
    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer,
                                        wParam As IntPtr, lParam As String) As IntPtr
    End Function
    Private Const EM_SETCUEBANNER As Integer = &H1501

    Private Sub SetPlaceholder(tb As TextBox, hint As String)
        SendMessage(tb.Handle, EM_SETCUEBANNER, New IntPtr(1), hint)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  STRUCTURES
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure EmpRef
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Dept As String
        Dim Job As String
        Dim AvatarColor As Color
    End Structure

    Private Structure ContractRow
        Dim Id As Integer
        Dim Code As String
        Dim EmpId As Integer
        Dim StartDate As Date
        Dim EndDate As Date          ' MinValue = không thời hạn
        Dim BaseSalary As Decimal
        Dim Note As String
        Dim Status As Integer        ' 0=active 1=expiring 2=expired 3=cancelled
    End Structure

    ' Avatar palette
    Private ReadOnly _avatarColors() As Color = {
        Color.FromArgb(74, 158, 255),
        Color.FromArgb(123, 97, 255),
        Color.FromArgb(76, 175, 80),
        Color.FromArgb(245, 158, 11),
        Color.FromArgb(224, 85, 85),
        Color.FromArgb(38, 198, 218),
        Color.FromArgb(236, 72, 153),
        Color.FromArgb(249, 115, 22)
    }

    Private _employees As New List(Of EmpRef)()
    Private _allContracts As New List(Of ContractRow)()
    Private _filtered As New List(Of ContractRow)()
    Private _selectedId As Integer = -1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        SetPlaceholder(txtSearch, "🔍  Tìm mã HĐ hoặc tên nhân viên...")
        SetPlaceholder(txtFCode, "CTR2026-001")
        SetPlaceholder(txtFNote, "Ghi chú hợp đồng...")

        AddHandler pnlEmpAvatar.Paint, AddressOf EmpAvatar_Paint
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlRightFooter.Resize, AddressOf OnFooterResize
        AddHandler pnlLeft.Resize, AddressOf OnLeftResize
        AddHandler pnlSec4.Resize, AddressOf OnSec4Resize
        AddHandler pnlEmpCard.Resize, AddressOf OnEmpCardResize
        AddHandler dtpStart.ValueChanged, AddressOf OnDatesChanged
        AddHandler dtpEnd.ValueChanged, AddressOf OnDatesChanged
        AddHandler txtFBaseSalary.TextChanged, AddressOf OnSalaryChanged

        LoadMockEmployees()
        LoadMockContracts()
        PopulateEmpCombo()

        _filtered = New List(Of ContractRow)(_allContracts)
        RenderTable(_filtered)

        If _allContracts.Count > 0 Then
            SelectContract(_allContracts(0).Id)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockEmployees()
        _employees.Clear()

        Dim rows(,) As Object = {
            {1, "EMP001", "Nguyễn Văn An", "Kỹ thuật", "Lập trình viên"},
            {2, "EMP002", "Trần Thị Bình", "Kế toán", "Kế toán trưởng"},
            {3, "EMP003", "Lê Văn Cường", "Nhân sự", "Chuyên viên NS"},
            {4, "EMP004", "Phạm Thị Dung", "Marketing", "Marketing Manager"},
            {5, "EMP005", "Hoàng Văn Em", "Kinh doanh", "Sales Executive"},
            {6, "EMP006", "Vũ Thị Phương", "Kỹ thuật", "QA Engineer"},
            {7, "EMP007", "Đặng Văn Giang", "Vận hành", "Ops Manager"},
            {8, "EMP008", "Bùi Thị Hoa", "Kỹ thuật", "Frontend Dev"}
        }

        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim e As New EmpRef()
            e.Id = CInt(rows(i, 0))
            e.Code = CStr(rows(i, 1))
            e.Name = CStr(rows(i, 2))
            e.Dept = CStr(rows(i, 3))
            e.Job = CStr(rows(i, 4))
            e.AvatarColor = _avatarColors(e.Id Mod _avatarColors.Length)
            _employees.Add(e)
        Next
    End Sub

    Private Sub LoadMockContracts()
        _allContracts.Clear()

        Dim c1 As New ContractRow()
        c1.Id = 1 : c1.Code = "CTR2024001" : c1.EmpId = 1
        c1.StartDate = #1/1/2024# : c1.EndDate = #12/31/2025#
        c1.BaseSalary = 15000000D : c1.Status = 2
        c1.Note = "Hợp đồng chính thức năm 2024"
        _allContracts.Add(c1)

        Dim c2 As New ContractRow()
        c2.Id = 2 : c2.Code = "CTR2026001" : c2.EmpId = 1
        c2.StartDate = #1/1/2026# : c2.EndDate = #12/31/2027#
        c2.BaseSalary = 18000000D : c2.Status = 0
        c2.Note = "Gia hạn hợp đồng 2 năm"
        _allContracts.Add(c2)

        Dim c3 As New ContractRow()
        c3.Id = 3 : c3.Code = "CTR2023001" : c3.EmpId = 2
        c3.StartDate = #6/1/2023# : c3.EndDate = #5/31/2024#
        c3.BaseSalary = 25000000D : c3.Status = 2
        c3.Note = ""
        _allContracts.Add(c3)

        Dim c4 As New ContractRow()
        c4.Id = 4 : c4.Code = "CTR2024002" : c4.EmpId = 2
        c4.StartDate = #6/1/2024# : c4.EndDate = #5/31/2025#
        c4.BaseSalary = 28000000D : c4.Status = 2
        c4.Note = "Tăng lương theo đánh giá"
        _allContracts.Add(c4)

        Dim c5 As New ContractRow()
        c5.Id = 5 : c5.Code = "CTR2025002" : c5.EmpId = 2
        c5.StartDate = #6/1/2025# : c5.EndDate = #5/31/2026#
        c5.BaseSalary = 30000000D : c5.Status = 1
        c5.Note = ""
        _allContracts.Add(c5)

        Dim c6 As New ContractRow()
        c6.Id = 6 : c6.Code = "CTR2024003" : c6.EmpId = 4
        c6.StartDate = #3/1/2024# : c6.EndDate = Date.MinValue
        c6.BaseSalary = 22000000D : c6.Status = 0
        c6.Note = "Hợp đồng không thời hạn"
        _allContracts.Add(c6)

        Dim c7 As New ContractRow()
        c7.Id = 7 : c7.Code = "CTR2025003" : c7.EmpId = 6
        c7.StartDate = #1/15/2025# : c7.EndDate = #1/14/2027#
        c7.BaseSalary = 18000000D : c7.Status = 0
        c7.Note = ""
        _allContracts.Add(c7)

        Dim c8 As New ContractRow()
        c8.Id = 8 : c8.Code = "CTR2025001" : c8.EmpId = 8
        c8.StartDate = #3/1/2025# : c8.EndDate = #8/31/2025#
        c8.BaseSalary = 5000000D : c8.Status = 2
        c8.Note = "Hợp đồng thực tập 6 tháng"
        _allContracts.Add(c8)
    End Sub

    Private Sub PopulateEmpCombo()
        cboFEmp.Items.Clear()
        cboFEmp.Items.Add("— Chọn nhân viên —")
        For Each e In _employees
            cboFEmp.Items.Add(e.Code & "  " & e.Name & "  (" & e.Dept & ")")
        Next
        cboFEmp.SelectedIndex = 0
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  STATUS HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    ' Tự động tính status từ end_date nếu chưa bị hủy
    Private Function CalcStatus(c As ContractRow) As Integer
        If c.Status = 3 Then Return 3  ' đã hủy, không đổi
        If c.EndDate = Date.MinValue Then Return 0  ' không thời hạn = active
        Dim daysLeft = CInt((c.EndDate - Date.Today).TotalDays)
        If daysLeft < 0 Then Return 2
        If daysLeft <= 30 Then Return 1
        Return 0
    End Function

    Private Function GetStatusText(status As Integer) As String
        Select Case status
            Case 0 : Return "● Đang hiệu lực"
            Case 1 : Return "⚠ Sắp hết hạn"
            Case 2 : Return "○ Đã hết hạn"
            Case 3 : Return "✕ Đã hủy"
            Case Else : Return "?"
        End Select
    End Function

    Private Function GetStatusColor(status As Integer) As Color
        Select Case status
            Case 0 : Return Color.FromArgb(76, 175, 80)
            Case 1 : Return Color.FromArgb(245, 158, 11)
            Case 2 : Return Color.FromArgb(123, 139, 178)
            Case 3 : Return Color.FromArgb(224, 85, 85)
            Case Else : Return Color.FromArgb(123, 139, 178)
        End Select
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RENDER TABLE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub RenderTable(data As List(Of ContractRow))
        dgvContract.Rows.Clear()

        For Each c In data
            Dim emp = FindEmp(c.EmpId)
            Dim status = CalcStatus(c)
            Dim endTxt = If(c.EndDate = Date.MinValue,
                            "Không thời hạn",
                            c.EndDate.ToString("dd/MM/yyyy"))

            Dim daysLeftTxt As String
            If c.EndDate = Date.MinValue Then
                daysLeftTxt = "∞"
            ElseIf status = 2 OrElse status = 3 Then
                daysLeftTxt = "—"
            Else
                Dim d = CInt((c.EndDate - Date.Today).TotalDays)
                daysLeftTxt = d.ToString() & " ngày"
            End If

            dgvContract.Rows.Add(
                GetInitials(emp.Name),
                emp.Name,
                c.Code,
                c.StartDate.ToString("dd/MM/yyyy"),
                endTxt,
                FmtM(c.BaseSalary),
                GetStatusText(status),
                daysLeftTxt)

            Dim row = dgvContract.Rows(dgvContract.Rows.Count - 1)
            row.Tag = c.Id

            ' Status color
            row.Cells("colStatus").Style.ForeColor = GetStatusColor(status)

            ' Days left color
            If c.EndDate <> Date.MinValue AndAlso status <> 2 AndAlso status <> 3 Then
                Dim d = CInt((c.EndDate - Date.Today).TotalDays)
                If d <= 30 Then
                    row.Cells("colDaysLeft").Style.ForeColor = Color.FromArgb(245, 158, 11)
                Else
                    row.Cells("colDaysLeft").Style.ForeColor = Color.FromArgb(76, 175, 80)
                End If
            ElseIf c.EndDate = Date.MinValue Then
                row.Cells("colDaysLeft").Style.ForeColor = Color.FromArgb(74, 158, 255)
            End If

            ' Highlight selected
            If c.Id = _selectedId Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(30, 74, 158, 255)
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 74, 158, 255)
            End If
        Next

        ' Footer summary
        Dim activeCount = data.Where(Function(x) CalcStatus(x) = 0).Count()
        Dim expiringCount = data.Where(Function(x) CalcStatus(x) = 1).Count()
        lblRowInfo.Text = String.Format(
            "{0} hợp đồng  ·  {1} hiệu lực  ·  {2} sắp hết hạn",
            data.Count, activeCount, expiringCount)

        dgvContract.Size = New Size(
            pnlLeft.Width,
            pnlLeft.Height - pnlLeftFooter.Height)
    End Sub

    ' ── DGV CellPainting — avatar circle ─────────────────────
    Private Sub dgvContract_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvContract.CellPainting
        If e.ColumnIndex <> dgvContract.Columns("colAvatar").Index OrElse e.RowIndex < 0 Then Return

        e.PaintBackground(e.ClipBounds, True)

        Dim row = dgvContract.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        Dim ctr = FindContract(CInt(row.Tag))
        Dim emp = FindEmp(ctr.EmpId)
        If emp.Id = 0 Then Return

        Dim g = e.Graphics
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim sz = 34
        Dim ax = e.CellBounds.X + (e.CellBounds.Width - sz) \ 2
        Dim ay = e.CellBounds.Y + (e.CellBounds.Height - sz) \ 2

        Using br = New SolidBrush(emp.AvatarColor)
            g.FillEllipse(br, ax, ay, sz, sz)
        End Using
        Using f = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim ini = GetInitials(emp.Name)
                Dim s = g.MeasureString(ini, f)
                g.DrawString(ini, f, br, ax + (sz - s.Width) / 2, ay + (sz - s.Height) / 2)
            End Using : End Using

        e.Handled = True
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SELECT CONTRACT
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub SelectContract(id As Integer)
        _selectedId = id
        RenderTable(_filtered)

        Dim c = FindContract(id)
        If c.Id = 0 Then Return
        Dim emp = FindEmp(c.EmpId)
        Dim status = CalcStatus(c)

        ' Employee card
        pnlEmpAvatar.BackColor = emp.AvatarColor
        pnlEmpAvatar.Tag = GetInitials(emp.Name)
        pnlEmpAvatar.Invalidate()
        lblEmpName.Text = emp.Name
        lblEmpMeta.Text = emp.Code
        lblEmpDept.Text = emp.Dept & "  ·  " & emp.Job

        ' Status badge
        lblBadgeStatus.Text = GetStatusText(status)
        lblBadgeStatus.ForeColor = GetStatusColor(status)
        lblBadgeStatus.BackColor = Color.FromArgb(20, GetStatusColor(status))

        ' Days left badge
        If c.EndDate = Date.MinValue Then
            lblBadgeDaysLeft.Text = "Không có ngày kết thúc"
            lblBadgeDaysLeft.ForeColor = Color.FromArgb(74, 158, 255)
        ElseIf status = 2 Then
            Dim overdue = CInt((Date.Today - c.EndDate).TotalDays)
            lblBadgeDaysLeft.Text = "Đã hết hạn " & overdue & " ngày trước"
            lblBadgeDaysLeft.ForeColor = Color.FromArgb(123, 139, 178)
        ElseIf status = 3 Then
            lblBadgeDaysLeft.Text = "Hợp đồng đã bị hủy"
            lblBadgeDaysLeft.ForeColor = Color.FromArgb(224, 85, 85)
        Else
            Dim d = CInt((c.EndDate - Date.Today).TotalDays)
            lblBadgeDaysLeft.Text = "Còn " & d & " ngày"
            lblBadgeDaysLeft.ForeColor = If(d <= 30,
                                            Color.FromArgb(245, 158, 11),
                                            Color.FromArgb(76, 175, 80))
        End If

        ' Form fields
        txtFCode.Text = c.Code
        cboFStatus.SelectedIndex = status

        ' Employee combo
        Dim empIdx = 0
        Dim j As Integer
        For j = 0 To _employees.Count - 1
            If _employees(j).Id = c.EmpId Then
                empIdx = j + 1
                Exit For
            End If
        Next
        cboFEmp.SelectedIndex = empIdx

        dtpStart.Value = c.StartDate

        Dim isNoEnd = (c.EndDate = Date.MinValue)
        chkNoEndDate.Checked = isNoEnd
        dtpEnd.Enabled = Not isNoEnd
        If Not isNoEnd Then
            dtpEnd.Value = c.EndDate
        End If

        txtFBaseSalary.Text = c.BaseSalary.ToString("0")
        txtFNote.Text = c.Note

        UpdateDuration()
        UpdateSalaryPreview()

        btnDelete.Enabled = (status <> 2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  DGV CLICK
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub dgvContract_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContract.CellClick
        If e.RowIndex < 0 Then Return
        Dim row = dgvContract.Rows(e.RowIndex)
        If row.Tag Is Nothing Then Return
        SelectContract(CInt(row.Tag))
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TOOLBAR FILTER
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilter()
    End Sub

    Private Sub cboDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim q = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDept.SelectedIndex <= 0, "", cboDept.SelectedItem.ToString())
        Dim statIdx = cboStatusFilter.SelectedIndex  ' 0=all 1=active 2=expiring 3=expired 4=cancelled

        _filtered = New List(Of ContractRow)()
        For Each c In _allContracts
            Dim emp = FindEmp(c.EmpId)
            Dim status = CalcStatus(c)

            Dim mQ = q = "" OrElse
                     c.Code.ToLower().Contains(q) OrElse
                     emp.Name.ToLower().Contains(q) OrElse
                     emp.Code.ToLower().Contains(q)
            Dim mD = dept = "" OrElse emp.Dept = dept
            Dim mS = statIdx = 0 OrElse status = statIdx - 1

            If mQ AndAlso mD AndAlso mS Then _filtered.Add(c)
        Next
        RenderTable(_filtered)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM EVENTS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        NewContract()
    End Sub

    Private Sub chkNoEndDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoEndDate.CheckedChanged
        dtpEnd.Enabled = Not chkNoEndDate.Checked
        UpdateDuration()
    End Sub

    Private Sub cboFEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFEmp.SelectedIndexChanged
        If cboFEmp.SelectedIndex <= 0 Then
            pnlEmpAvatar.BackColor = Color.FromArgb(38, 43, 66)
            pnlEmpAvatar.Tag = "?"
            pnlEmpAvatar.Invalidate()
            lblEmpName.Text = "Chọn nhân viên"
            lblEmpMeta.Text = "—"
            lblEmpDept.Text = "—"
            Return
        End If
        Dim emp = _employees(cboFEmp.SelectedIndex - 1)
        pnlEmpAvatar.BackColor = emp.AvatarColor
        pnlEmpAvatar.Tag = GetInitials(emp.Name)
        pnlEmpAvatar.Invalidate()
        lblEmpName.Text = emp.Name
        lblEmpMeta.Text = emp.Code
        lblEmpDept.Text = emp.Dept & "  ·  " & emp.Job
    End Sub

    Private Sub OnDatesChanged(sender As Object, e As EventArgs)
        UpdateDuration()
    End Sub

    Private Sub OnSalaryChanged(sender As Object, e As EventArgs)
        UpdateSalaryPreview()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate
        If String.IsNullOrWhiteSpace(txtFCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã hợp đồng.",
                            "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFCode.Focus() : Return
        End If
        If cboFEmp.SelectedIndex <= 0 Then
            MessageBox.Show("Vui lòng chọn nhân viên.",
                            "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboFEmp.Focus() : Return
        End If
        If Not chkNoEndDate.Checked AndAlso dtpEnd.Value <= dtpStart.Value Then
            MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim salary As Decimal = 0
        If Not Decimal.TryParse(txtFBaseSalary.Text.Trim(), salary) OrElse salary <= 0 Then
            MessageBox.Show("Lương cơ bản phải là số dương.",
                            "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFBaseSalary.Focus() : Return
        End If

        MessageBox.Show("Đã lưu hợp đồng: " & txtFCode.Text,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        NewContract()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _selectedId < 0 Then
            MessageBox.Show("Chưa chọn hợp đồng.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim c = FindContract(_selectedId)
        If CalcStatus(c) = 2 Then
            MessageBox.Show("Không thể xóa hợp đồng đã hết hạn. Hãy đổi trạng thái sang Đã hủy.",
                            "Không thể thực hiện", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim r = MessageBox.Show(
            "Xóa hợp đồng """ & c.Code & """?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If r = DialogResult.Yes Then
            MessageBox.Show("Đã xóa (mock).",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _selectedId = -1
            NewContract()
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  LIVE UPDATE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub UpdateDuration()
        If chkNoEndDate.Checked Then
            lblDurationVal.Text = "Không thời hạn"
            lblDurationVal.ForeColor = Color.FromArgb(74, 158, 255)
            Return
        End If
        If dtpEnd.Value <= dtpStart.Value Then
            lblDurationVal.Text = "⚠ Ngày không hợp lệ"
            lblDurationVal.ForeColor = Color.FromArgb(245, 158, 11)
            Return
        End If
        Dim totalDays = CInt((dtpEnd.Value - dtpStart.Value).TotalDays)
        Dim months = CInt(Math.Round(totalDays / 30.44))
        Dim years = months \ 12
        Dim remMonths = months Mod 12
        Dim txt As String
        If years > 0 AndAlso remMonths > 0 Then
            txt = years & " năm " & remMonths & " tháng  (" & totalDays & " ngày)"
        ElseIf years > 0 Then
            txt = years & " năm  (" & totalDays & " ngày)"
        Else
            txt = months & " tháng  (" & totalDays & " ngày)"
        End If
        lblDurationVal.Text = txt
        lblDurationVal.ForeColor = Color.FromArgb(74, 158, 255)
    End Sub

    Private Sub UpdateSalaryPreview()
        Dim salary As Decimal = 0
        If Decimal.TryParse(txtFBaseSalary.Text.Trim(), salary) AndAlso salary > 0 Then
            lblSalaryPreviewVal.Text = FmtVND(salary)
            lblSalaryPreviewVal.ForeColor = Color.FromArgb(76, 175, 80)
        Else
            lblSalaryPreviewVal.Text = "—"
            lblSalaryPreviewVal.ForeColor = Color.FromArgb(61, 74, 114)
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Function FindEmp(empId As Integer) As EmpRef
        For Each e In _employees
            If e.Id = empId Then Return e
        Next
        Return Nothing
    End Function

    Private Function FindContract(id As Integer) As ContractRow
        For Each c In _allContracts
            If c.Id = id Then Return c
        Next
        Return Nothing
    End Function

    Private Function GetInitials(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "?"
        Dim parts = name.Trim().Split(" "c)
        If parts.Length >= 2 Then
            Return (parts(0)(0).ToString() & parts(parts.Length - 1)(0).ToString()).ToUpper()
        End If
        Return name.Substring(0, Math.Min(2, name.Length)).ToUpper()
    End Function

    Private Function FmtM(amount As Decimal) As String
        If amount >= 1000000000D Then Return (amount / 1000000000D).ToString("0.#") & " tỷ"
        If amount >= 1000000D Then Return (amount / 1000000D).ToString("0.#") & " tr"
        Return amount.ToString("N0") & "đ"
    End Function

    Private Function FmtVND(amount As Decimal) As String
        Return amount.ToString("N0") & " đ"
    End Function

    Private Sub NewContract()
        _selectedId = -1
        txtFCode.Clear()
        cboFEmp.SelectedIndex = 0
        cboFStatus.SelectedIndex = 0
        dtpStart.Value = Date.Today
        dtpEnd.Value = Date.Today.AddYears(1)
        chkNoEndDate.Checked = False
        dtpEnd.Enabled = True
        txtFBaseSalary.Text = "0"
        txtFNote.Clear()

        pnlEmpAvatar.BackColor = Color.FromArgb(38, 43, 66)
        pnlEmpAvatar.Tag = "?"
        pnlEmpAvatar.Invalidate()
        lblEmpName.Text = "Chọn nhân viên"
        lblEmpMeta.Text = "—"
        lblEmpDept.Text = "—"
        lblBadgeStatus.Text = "● Đang hiệu lực"
        lblBadgeStatus.ForeColor = Color.FromArgb(76, 175, 80)
        lblBadgeStatus.BackColor = Color.FromArgb(20, 76, 175, 80)
        lblBadgeDaysLeft.Text = ""

        UpdateDuration()
        UpdateSalaryPreview()
        btnDelete.Enabled = False
        RenderTable(_filtered)
        txtFCode.Focus()
    End Sub

    ' ── GDI+ avatar circle ────────────────────────────────────
    Private Sub EmpAvatar_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl = CType(sender, Panel)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Using br = New SolidBrush(pnl.BackColor)
            g.FillEllipse(br, 0, 0, pnl.Width - 1, pnl.Height - 1)
        End Using
        Dim initials = If(pnl.Tag IsNot Nothing, pnl.Tag.ToString(), "?")
        Using f = New Font("Microsoft YaHei UI", 13.0!, FontStyle.Bold)
            Using br = New SolidBrush(Color.White)
                Dim sz = g.MeasureString(initials, f)
                g.DrawString(initials, f, br,
                             (pnl.Width - sz.Width) / 2,
                             (pnl.Height - sz.Height) / 2)
            End Using : End Using
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  RESIZE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub OnToolbarResize(sender As Object, e As EventArgs)
        btnAdd.Left = pnlToolbar.Width - btnAdd.Width - 14
    End Sub

    Private Sub OnFooterResize(sender As Object, e As EventArgs)
        btnSave.Left = pnlRightFooter.Width - btnSave.Width - 14
        btnClear.Left = btnSave.Left - btnClear.Width - 10
    End Sub

    Private Sub OnLeftResize(sender As Object, e As EventArgs)
        dgvContract.Size = New Size(
            pnlLeft.Width,
            pnlLeft.Height - pnlLeftFooter.Height)
        pnlPageBtns.Left = pnlLeftFooter.Width - pnlPageBtns.Width - 10
    End Sub

    Private Sub OnSec4Resize(sender As Object, e As EventArgs)
        txtFNote.Width = pnlSec4.Width - 32
    End Sub

    Private Sub OnEmpCardResize(sender As Object, e As EventArgs)
        pnlContractBadge.Left = pnlEmpCard.Width - pnlContractBadge.Width - 20
    End Sub

End Class