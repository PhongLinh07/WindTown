Imports System.Linq

Public Class frmChamCong
    Private ReadOnly _service As New AttendanceService()
    Private ReadOnly _employeeService As New EmployeeService()

    Private _attendances As New List(Of Attendance)()
    Private _employees As New List(Of Employee)()
    Private ReadOnly _binding As New BindingSource()

    Private _btnAdd As Button

    Private Sub frmChamCong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitHeaderActions()
        InitFilters()
        InitGrid()
        LoadData()
        ApplyFilter()
    End Sub

    Private Sub InitHeaderActions()
        If _btnAdd IsNot Nothing Then Return

        _btnAdd = New Button() With {
            .Text = "Thêm mới",
            .Size = New Size(120, 30),
            .BackColor = Color.FromArgb(24, 119, 242),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        _btnAdd.FlatAppearance.BorderSize = 0

        Panel3.Controls.Add(_btnAdd)
        AddHandler Panel3.Resize, AddressOf PositionHeaderButtons
        AddHandler _btnAdd.Click, AddressOf BtnAdd_Click
        PositionHeaderButtons(Nothing, EventArgs.Empty)
    End Sub

    Private Sub PositionHeaderButtons(sender As Object, e As EventArgs)
        If _btnAdd Is Nothing Then Return
        _btnAdd.Top = 20
        _btnAdd.Left = Panel3.Width - _btnAdd.Width - 16
    End Sub

    Private Sub InitFilters()
        Dim statusItems As New List(Of Object) From {
            New With {.Display = "Tất cả trạng thái", .Value = -1},
            New With {.Display = "Đang hoạt động", .Value = 1},
            New With {.Display = "Ngừng hoạt động", .Value = 0}
        }
        ComboBox1.DataSource = statusItems
        ComboBox1.DisplayMember = "Display"
        ComboBox1.ValueMember = "Value"
        ComboBox1.SelectedValue = -1

        Dim shiftItems As New List(Of Object) From {
            New With {.Display = "Tất cả ca", .Value = -1},
            New With {.Display = "Ngày", .Value = 0},
            New With {.Display = "Đêm", .Value = 1}
        }
        ComboBox2.DataSource = shiftItems
        ComboBox2.DisplayMember = "Display"
        ComboBox2.ValueMember = "Value"
        ComboBox2.SelectedValue = -1

        Dim empResponse = _employeeService.Execute(DataIntent.GetList)
        _employees = TryCast(empResponse?.Data, IEnumerable(Of Employee))?.Where(Function(e) e IsNot Nothing).ToList()
        If _employees Is Nothing Then _employees = New List(Of Employee)()

        Dim empItems As New List(Of Object)
        empItems.Add(New With {.Display = "Tất cả nhân viên", .Value = 0})
        empItems.AddRange(_employees.Select(Function(e) New With {
            .Display = If(String.IsNullOrWhiteSpace(e.name), "---", e.name),
            .Value = e.id
        }))
        ComboBox3.DataSource = empItems
        ComboBox3.DisplayMember = "Display"
        ComboBox3.ValueMember = "Value"
        ComboBox3.SelectedValue = 0

        AddHandler Button1.Click, Sub() ApplyFilter()
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
        AddHandler ComboBox1.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler ComboBox2.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler ComboBox3.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler DateTimePicker1.ValueChanged, Sub() ApplyFilter()
        AddHandler DateTimePicker2.ValueChanged, Sub() ApplyFilter()
        AddHandler Button2.Click, AddressOf BtnExport_Click
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ApplyFilter()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub InitGrid()
        With DataGridView1
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .ColumnHeadersHeight = 36
            .RowTemplate.Height = 36
        End With

        GridHelper.SetupGrid(DataGridView1, GetType(Attendance))
        DataGridView1.RowHeadersVisible = False

        Dim colEdit As New DataGridViewImageColumn() With {
            .Name = "colEdit",
            .HeaderText = "",
            .Image = My.Resources.compose,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        DataGridView1.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewImageColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Image = My.Resources.bin,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        DataGridView1.Columns.Add(colDelete)

        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.ReadOnly = True
        Next
        DataGridView1.Columns("colEdit").ReadOnly = False
        DataGridView1.Columns("colDelete").ReadOnly = False

        DataGridView1.DataSource = _binding
        AddHandler DataGridView1.CellClick, AddressOf DataGridView1_CellClick
        AddHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
    End Sub

    Private Sub LoadData()
        Dim response = _service.Execute(DataIntent.GetList)
        _attendances = TryCast(response?.Data, IEnumerable(Of Attendance))?.Where(Function(a) a IsNot Nothing).ToList()
        If _attendances Is Nothing Then _attendances = New List(Of Attendance)()
    End Sub

    Private Sub ApplyFilter()
        Dim query = If(TextBox1.Text, String.Empty).Trim()
        Dim statusFilter = Convert.ToInt32(ComboBox1.SelectedValue)
        Dim shiftFilter = Convert.ToInt32(ComboBox2.SelectedValue)
        Dim empId = Convert.ToInt32(ComboBox3.SelectedValue)

        Dim fromDate = DateTimePicker1.Value.Date
        Dim toDate = DateTimePicker2.Value.Date
        If fromDate > toDate Then
            Dim tmp = fromDate
            fromDate = toDate
            toDate = tmp
        End If

        Dim filtered = _attendances.Where(
            Function(a)
                If a Is Nothing Then Return False

                If statusFilter <> -1 AndAlso a.status <> statusFilter Then Return False
                If shiftFilter <> -1 AndAlso a.shift <> shiftFilter Then Return False
                If empId <> 0 Then
                    Dim currentEmpId = a.Employee?.id
                    If currentEmpId Is Nothing OrElse currentEmpId.Value <> empId Then Return False
                End If

                If a.of_date.HasValue Then
                    Dim d = a.of_date.Value.Date
                    If d < fromDate OrElse d > toDate Then Return False
                End If

                If Not String.IsNullOrWhiteSpace(query) Then
                    Dim code = If(a.code, String.Empty)
                    Dim empCode = If(a.Employee?.code, String.Empty)
                    Dim empName = If(a.Employee?.name, String.Empty)
                    If code.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       empCode.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       empName.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 Then
                        Return False
                    End If
                End If

                Return True
            End Function).ToList()

        _binding.DataSource = filtered
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        Dim data As New Attendance()
        Using crud As New frmChamCongEdit(data, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _service.Execute(DataIntent.Insert, data)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Thêm chấm công không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilter()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Xuất báo cáo đang được chuẩn bị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row = DataGridView1.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Attendance)
        If data Is Nothing Then Return

        OpenEdit(data)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row = DataGridView1.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Attendance)
        If data Is Nothing Then Return

        Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            OpenEdit(data)
        ElseIf colName = "colDelete" Then
            If MessageBox.Show("Xác nhận xóa chấm công?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim result = _service.Execute(DataIntent.SoftDeleteMany, New List(Of Attendance) From {data})
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Xóa chấm công không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        End If
    End Sub

    Private Sub OpenEdit(data As Attendance)
        Dim clone = Utils.DeepClone(data)
        Using crud As New frmChamCongEdit(clone)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _service.Execute(DataIntent.Update, clone)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Cập nhật chấm công không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilter()
    End Sub
End Class
