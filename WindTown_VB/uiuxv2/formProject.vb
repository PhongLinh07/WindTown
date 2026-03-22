Imports System.Drawing

Public Class formProject
    Private Class ProjectItem
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property Manager As String
        Public Property Status As String
        Public Property Client As String
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property Budget As String
    End Class

    Private _projects As List(Of ProjectItem)
    Private _filtered As List(Of ProjectItem)
    Private _selectedId As Integer = -1

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMockData()
        InitFilters()
        InitTooltips()
        BindList(_projects)
        If _projects.Count > 0 Then
            SelectProject(_projects(0).Id)
        Else
            ClearForm()
        End If
        tabMain.SelectedIndex = 0
    End Sub

    Private Sub InitMockData()
        _projects = New List(Of ProjectItem) From {
            New ProjectItem With {.Id = 1, .Code = "PRJ-001", .Name = "CRM Upgrade", .Manager = "Nguyễn Văn An", .Status = "active", .Client = "WindTown", .StartDate = New Date(2026, 1, 10), .EndDate = New Date(2026, 6, 20), .Budget = "500,000,000"},
            New ProjectItem With {.Id = 2, .Code = "PRJ-002", .Name = "Website HRM", .Manager = "Trần Thị Binh", .Status = "pause", .Client = "Internal", .StartDate = New Date(2026, 2, 5), .EndDate = New Date(2026, 9, 30), .Budget = "280,000,000"},
            New ProjectItem With {.Id = 3, .Code = "PRJ-003", .Name = "Mobile Payroll", .Manager = "Phạm Thị Dung", .Status = "active", .Client = "WindTown", .StartDate = New Date(2026, 3, 1), .EndDate = New Date(2026, 12, 15), .Budget = "750,000,000"}
        }
        _filtered = New List(Of ProjectItem)(_projects)
    End Sub

    Private Sub InitFilters()
        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang chạy", "Tạm dừng"})
        cboStatusFilter.SelectedIndex = 0

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Đang chạy", "Tạm dừng"})
        cboStatus.SelectedIndex = 0

        cboManager.Items.Clear()
        cboManager.Items.AddRange(New Object() {"Nguyễn Văn An", "Trần Thị Binh", "Phạm Thị Dung"})
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(txtCode, "Bắt buộc")
        toolTip1.SetToolTip(txtName, "Bắt buộc")
        toolTip1.SetToolTip(cboStatus, "Bắt buộc")
        toolTip1.SetToolTip(dtpStart, "Bắt buộc")
        toolTip1.SetToolTip(dtpEnd, "Bắt buộc")
        toolTip1.SetToolTip(cboManager, "Bắt buộc")
        toolTip1.SetToolTip(txtClient, "Tên khách hàng (không bắt buộc)")
        toolTip1.SetToolTip(txtBudget, "Ngân sách dự án (không bắt buộc)")
    End Sub

    Private Sub BindList(data As List(Of ProjectItem))
        dgvProject.Rows.Clear()
        For Each item In data
            dgvProject.Rows.Add(item.Code, item.Name, item.Manager, If(item.Status = "active", "Đang chạy", "Tạm dừng"))
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count}"
    End Sub

    Private Sub BindDetail(item As ProjectItem)
        txtCode.Text = item.Code
        txtName.Text = item.Name
        txtClient.Text = item.Client
        cboStatus.SelectedItem = If(item.Status = "active", "Đang chạy", "Tạm dừng")
        dtpStart.Value = item.StartDate
        dtpEnd.Value = item.EndDate
        cboManager.SelectedItem = item.Manager
        txtBudget.Text = item.Budget
    End Sub

    Private Sub SelectProject(id As Integer)
        _selectedId = id
        Dim item = _projects.FirstOrDefault(Function(x) x.Id = id)
        If item Is Nothing Then
            ClearForm()
            Return
        End If
        BindDetail(item)
    End Sub

    Private Sub ClearForm()
        txtCode.Text = ""
        txtName.Text = ""
        txtClient.Text = ""
        cboStatus.SelectedIndex = 0
        dtpStart.Value = Date.Today
        dtpEnd.Value = Date.Today
        cboManager.SelectedIndex = -1
        txtBudget.Text = ""
        ResetValidation()
    End Sub

    Private Sub ResetValidation()
        SetInvalid(txtCode, False)
        SetInvalid(txtName, False)
        SetInvalid(cboStatus, False)
        SetInvalid(dtpStart, False)
        SetInvalid(dtpEnd, False)
        SetInvalid(cboManager, False)
    End Sub

    Private Sub SetInvalid(ctrl As Control, isInvalid As Boolean)
        If TypeOf ctrl Is TextBox Then
            ctrl.BackColor = If(isInvalid, _invalidBack, _inputBack)
        ElseIf TypeOf ctrl Is ComboBox Then
            ctrl.BackColor = If(isInvalid, _invalidBack, _inputBack)
        ElseIf TypeOf ctrl Is DateTimePicker Then
            Dim dtp = CType(ctrl, DateTimePicker)
            dtp.CalendarMonthBackground = If(isInvalid, _invalidBack, _inputBack)
            dtp.BackColor = If(isInvalid, _invalidBack, _inputBack)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        _selectedId = -1
        ClearForm()
        tabMain.SelectedIndex = 1
    End Sub

    Private Sub dgvProject_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProject.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvProject.Rows.Count Then Return
        Dim code = Convert.ToString(dgvProject.Rows(e.RowIndex).Cells(0).Value)
        Dim item = _projects.FirstOrDefault(Function(x) x.Code = code)
        If item IsNot Nothing Then
            SelectProject(item.Id)
            tabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim keyword = txtSearch.Text.Trim().ToLower()
        Dim statusFilter = cboStatusFilter.SelectedItem?.ToString()

        _filtered = _projects.Where(Function(p)
                                        Dim matchKeyword = String.IsNullOrWhiteSpace(keyword) OrElse p.Code.ToLower().Contains(keyword) OrElse p.Name.ToLower().Contains(keyword)
                                        Dim matchStatus = True
                                        If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter <> "Tất cả trạng thái" Then
                                            matchStatus = (statusFilter = "Đang chạy" AndAlso p.Status = "active") OrElse (statusFilter = "Tạm dừng" AndAlso p.Status = "pause")
                                        End If
                                        Return matchKeyword AndAlso matchStatus
                                    End Function).ToList()

        BindList(_filtered)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResetValidation()
        Dim invalid = False

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            SetInvalid(txtCode, True)
            invalid = True
        End If
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            SetInvalid(txtName, True)
            invalid = True
        End If
        If cboStatus.SelectedIndex < 0 Then
            SetInvalid(cboStatus, True)
            invalid = True
        End If
        If dtpStart.Value = Date.MinValue Then
            SetInvalid(dtpStart, True)
            invalid = True
        End If
        If dtpEnd.Value = Date.MinValue Then
            SetInvalid(dtpEnd, True)
            invalid = True
        End If
        If cboManager.SelectedIndex < 0 Then
            SetInvalid(cboManager, True)
            invalid = True
        End If

        If invalid Then
            MessageBox.Show("Vui lòng nhập đủ: Mã dự án, Tên dự án, Trạng thái, Ngày bắt đầu, Ngày kết thúc, Quản lý dự án", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Đã lưu (mock)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
