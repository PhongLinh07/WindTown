Imports System.Drawing

Public Class formLeave
    Private Class EmployeeItem
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property Dept As String
    End Class

    Private Class LeaveCategory
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
    End Class

    Private Class LeaveRecord
        Public Property Id As Integer
        Public Property Code As String
        Public Property EmployeeId As Integer
        Public Property CategoryId As Integer
        Public Property FromDate As Date
        Public Property ToDate As Date
        Public Property Days As Decimal
        Public Property Status As String
        Public Property Note As String
    End Class

    Private _employees As List(Of EmployeeItem)
    Private _categories As List(Of LeaveCategory)
    Private _leaves As List(Of LeaveRecord)
    Private _filtered As List(Of LeaveRecord)
    Private _selectedId As Integer = -1

    Private ReadOnly _inputBack As Color = Color.FromArgb(38, 43, 66)
    Private ReadOnly _invalidBack As Color = Color.FromArgb(70, 224, 85, 85)

    Private Sub formLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitMockData()
        InitFilters()
        InitTooltips()
        BindList(_leaves)
        If _leaves.Count > 0 Then
            SelectLeave(_leaves(0).Id)
        Else
            ClearForm()
        End If
    End Sub

    Private Sub InitMockData()
        _employees = New List(Of EmployeeItem) From {
            New EmployeeItem With {.Id = 1, .Code = "EMP-001", .Name = "Nguyễn Văn An", .Dept = "Kỹ thuật"},
            New EmployeeItem With {.Id = 2, .Code = "EMP-014", .Name = "Trần Thị Bình", .Dept = "Kế toán"},
            New EmployeeItem With {.Id = 3, .Code = "EMP-027", .Name = "Vũ Thị Phương", .Dept = "Nhân sự"},
            New EmployeeItem With {.Id = 4, .Code = "EMP-033", .Name = "Bùi Thị Hoa", .Dept = "Vận hành"}
        }
        _categories = New List(Of LeaveCategory) From {
            New LeaveCategory With {.Id = 1, .Code = "LC-AN", .Name = "Phép năm"},
            New LeaveCategory With {.Id = 2, .Code = "LC-TS", .Name = "Thai sản"},
            New LeaveCategory With {.Id = 3, .Code = "LC-KL", .Name = "Không lương"},
            New LeaveCategory With {.Id = 4, .Code = "LC-OM", .Name = "Ốm đau"}
        }
        _leaves = New List(Of LeaveRecord) From {
            New LeaveRecord With {.Id = 1, .Code = "LV-2026-01", .EmployeeId = 1, .CategoryId = 1, .FromDate = New Date(2026, 3, 20), .ToDate = New Date(2026, 3, 22), .Days = 3D, .Status = "Đã duyệt", .Note = "Nghỉ phép năm"},
            New LeaveRecord With {.Id = 2, .Code = "LV-2026-02", .EmployeeId = 2, .CategoryId = 4, .FromDate = New Date(2026, 3, 18), .ToDate = New Date(2026, 3, 19), .Days = 2D, .Status = "Chờ duyệt", .Note = ""},
            New LeaveRecord With {.Id = 3, .Code = "LV-2026-03", .EmployeeId = 3, .CategoryId = 3, .FromDate = New Date(2026, 3, 25), .ToDate = New Date(2026, 3, 25), .Days = 1D, .Status = "Từ chối", .Note = "Không đủ giấy tờ"}
        }
        _filtered = New List(Of LeaveRecord)(_leaves)
    End Sub

    Private Sub InitFilters()
        cboDeptFilter.Items.Clear()
        cboDeptFilter.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Nhân sự", "Kế toán", "Vận hành"})
        cboDeptFilter.SelectedIndex = 0

        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.AddRange(New Object() {"Tất cả trạng thái", "Chờ duyệt", "Đã duyệt", "Từ chối"})
        cboStatusFilter.SelectedIndex = 0

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Chờ duyệt", "Đã duyệt", "Từ chối"})

        cboEmployee.Items.Clear()
        For Each emp In _employees
            cboEmployee.Items.Add($"{emp.Name} · {emp.Dept}")
        Next

        cboCategory.Items.Clear()
        For Each cat In _categories
            cboCategory.Items.Add(cat.Name)
        Next
    End Sub

    Private Sub InitTooltips()
        toolTip1.SetToolTip(txtCode, "Bắt buộc")
        toolTip1.SetToolTip(cboEmployee, "Bắt buộc")
        toolTip1.SetToolTip(cboCategory, "Bắt buộc")
        toolTip1.SetToolTip(dtpFrom, "Bắt buộc")
        toolTip1.SetToolTip(dtpTo, "Bắt buộc")
    End Sub

    Private Sub BindList(data As List(Of LeaveRecord))
        dgvLeave.Rows.Clear()
        For Each item In data
            Dim emp = _employees.FirstOrDefault(Function(x) x.Id = item.EmployeeId)
            Dim cat = _categories.FirstOrDefault(Function(x) x.Id = item.CategoryId)
            dgvLeave.Rows.Add(item.Code, If(emp?.Name, "-"), If(cat?.Name, "-"), item.FromDate.ToString("dd/MM/yyyy"), item.ToDate.ToString("dd/MM/yyyy"), item.Days.ToString("0.#"), item.Status)
        Next
        lblRowInfo.Text = $"Hiển thị {data.Count}"
    End Sub

    Private Sub SelectLeave(id As Integer)
        _selectedId = id
        Dim item = _leaves.FirstOrDefault(Function(x) x.Id = id)
        If item Is Nothing Then
            ClearForm()
            Return
        End If
        BindDetail(item)
    End Sub

    Private Sub BindDetail(item As LeaveRecord)
        txtCode.Text = item.Code
        cboEmployee.SelectedIndex = Math.Max(0, _employees.FindIndex(Function(x) x.Id = item.EmployeeId))
        cboCategory.SelectedIndex = Math.Max(0, _categories.FindIndex(Function(x) x.Id = item.CategoryId))
        cboStatus.SelectedItem = item.Status
        dtpFrom.Value = item.FromDate
        dtpTo.Value = item.ToDate
        txtDays.Text = item.Days.ToString("0.#")
        txtReason.Text = item.Note
    End Sub

    Private Sub ClearForm()
        txtCode.Text = ""
        If cboEmployee.Items.Count > 0 Then cboEmployee.SelectedIndex = 0
        If cboCategory.Items.Count > 0 Then cboCategory.SelectedIndex = 0
        If cboStatus.Items.Count > 0 Then cboStatus.SelectedIndex = 0
        dtpFrom.Value = Date.Today
        dtpTo.Value = Date.Today
        txtDays.Text = ""
        txtReason.Text = ""
        ResetValidation()
    End Sub

    Private Sub ResetValidation()
        SetInvalid(txtCode, False)
        SetInvalid(cboEmployee, False)
        SetInvalid(cboCategory, False)
        SetInvalid(dtpFrom, False)
        SetInvalid(dtpTo, False)
    End Sub

    Private Sub SetInvalid(ctrl As Control, isInvalid As Boolean)
        If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox Then
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
        tabMain.SelectedTab = tabDetail
    End Sub

    Private Sub dgvLeave_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLeave.CellClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvLeave.Rows.Count Then Return
        Dim code = Convert.ToString(dgvLeave.Rows(e.RowIndex).Cells(0).Value)
        Dim item = _leaves.FirstOrDefault(Function(x) x.Code = code)
        If item IsNot Nothing Then
            SelectLeave(item.Id)
            tabMain.SelectedTab = tabDetail
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboDeptFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDeptFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub ApplyFilters()
        Dim keyword = txtSearch.Text.Trim().ToLower()
        Dim dept = If(cboDeptFilter.SelectedIndex <= 0, "", cboDeptFilter.SelectedItem.ToString())
        Dim st = If(cboStatusFilter.SelectedIndex <= 0, "", cboStatusFilter.SelectedItem.ToString())

        _filtered = _leaves.Where(Function(l)
                                      Dim emp = _employees.FirstOrDefault(Function(x) x.Id = l.EmployeeId)
                                      Dim matchKeyword = String.IsNullOrWhiteSpace(keyword) OrElse l.Code.ToLower().Contains(keyword) OrElse (emp IsNot Nothing AndAlso emp.Name.ToLower().Contains(keyword))
                                      Dim matchDept = String.IsNullOrWhiteSpace(dept) OrElse (emp IsNot Nothing AndAlso emp.Dept = dept)
                                      Dim matchStatus = String.IsNullOrWhiteSpace(st) OrElse l.Status = st
                                      Return matchKeyword AndAlso matchDept AndAlso matchStatus
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
        If cboEmployee.SelectedIndex < 0 Then
            SetInvalid(cboEmployee, True)
            invalid = True
        End If
        If cboCategory.SelectedIndex < 0 Then
            SetInvalid(cboCategory, True)
            invalid = True
        End If
        If dtpTo.Value < dtpFrom.Value Then
            SetInvalid(dtpFrom, True)
            SetInvalid(dtpTo, True)
            invalid = True
        End If

        If invalid Then
            MessageBox.Show("Vui lòng nhập đủ: Mã đơn, Nhân viên, Loại nghỉ và thời gian hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Đã lưu (mock)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub
End Class
