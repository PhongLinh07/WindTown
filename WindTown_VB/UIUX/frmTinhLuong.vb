Imports System.Linq

Public Class frmTinhLuong
    Private ReadOnly _payrollService As New PayrollService()
    Private ReadOnly _payPeriodService As New Pay_PeriodService()
    Private ReadOnly _positionService As New PositionService()

    Private _payrolls As New List(Of Payroll)()
    Private _periods As New List(Of Pay_Period)()
    Private _positions As New List(Of Position)()

    Private ReadOnly _binding As New BindingSource()

    Private Sub frmTinhLuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitFilters()
        InitGrid()
        LoadData()
        ApplyFilter()

        AddHandler Button1.Click, Sub() ApplyFilter()
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
        AddHandler Button2.Click, AddressOf Button2_Click
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ApplyFilter()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub InitFilters()
        Dim periodResponse = _payPeriodService.Execute(DataIntent.GetList)
        _periods = TryCast(periodResponse?.Data, IEnumerable(Of Pay_Period))?.ToList()
        If _periods Is Nothing Then _periods = New List(Of Pay_Period)()

        Dim periodItems As New List(Of Object)
        periodItems.Add(New With {.Display = "Tất cả kỳ lương", .Value = 0})
        periodItems.AddRange(_periods.Select(Function(p) New With {
            .Display = $"{p.code} - {p.name}",
            .Value = p.id
        }))
        ComboBox1.DataSource = periodItems
        ComboBox1.DisplayMember = "Display"
        ComboBox1.ValueMember = "Value"
        ComboBox1.SelectedValue = 0

        Dim statusItems As New List(Of Object)
        statusItems.Add(New With {.Display = "Tất cả trạng thái", .Value = -1})
        statusItems.AddRange(Payroll.status_Dict.Select(Function(kv) New With {
            .Display = kv.Value,
            .Value = kv.Key
        }))
        ComboBox2.DataSource = statusItems
        ComboBox2.DisplayMember = "Display"
        ComboBox2.ValueMember = "Value"
        ComboBox2.SelectedValue = -1

        Dim posResponse = _positionService.Execute(DataIntent.GetList)
        _positions = TryCast(posResponse?.Data, IEnumerable(Of Position))?.ToList()
        If _positions Is Nothing Then _positions = New List(Of Position)()

        Dim employees = _positions.
            Where(Function(p) p IsNot Nothing AndAlso p.Contract IsNot Nothing AndAlso p.Contract.Employee IsNot Nothing).
            Select(Function(p) p.Contract.Employee).
            GroupBy(Function(e) e.id).
            Select(Function(g) g.First()).
            ToList()

        Dim employeeItems As New List(Of Object)
        employeeItems.Add(New With {.Display = "Tất cả nhân viên", .Value = 0})
        employeeItems.AddRange(employees.Select(Function(e) New With {
            .Display = $"{e.code} - {e.name}",
            .Value = e.id
        }))
        ComboBox3.DataSource = employeeItems
        ComboBox3.DisplayMember = "Display"
        ComboBox3.ValueMember = "Value"
        ComboBox3.SelectedValue = 0

        Dim jobs = _positions.
            Where(Function(p) p IsNot Nothing AndAlso p.Job IsNot Nothing).
            Select(Function(p) p.Job).
            GroupBy(Function(j) j.id).
            Select(Function(g) g.First()).
            ToList()

        Dim jobItems As New List(Of Object)
        jobItems.Add(New With {.Display = "Tất cả công việc", .Value = 0})
        jobItems.AddRange(jobs.Select(Function(j) New With {
            .Display = $"{j.code} - {j.name}",
            .Value = j.id
        }))
        ComboBox4.DataSource = jobItems
        ComboBox4.DisplayMember = "Display"
        ComboBox4.ValueMember = "Value"
        ComboBox4.SelectedValue = 0

        AddHandler ComboBox1.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler ComboBox2.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler ComboBox3.SelectedIndexChanged, Sub() ApplyFilter()
        AddHandler ComboBox4.SelectedIndexChanged, Sub() ApplyFilter()
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

        GridHelper.SetupGrid(DataGridView1, GetType(Payroll))
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
    End Sub

    Private Sub LoadData()
        Dim response = _payrollService.Execute(DataIntent.GetList)
        _payrolls = TryCast(response?.Data, IEnumerable(Of Payroll))?.Where(Function(p) p IsNot Nothing).ToList()
        If _payrolls Is Nothing Then _payrolls = New List(Of Payroll)()
    End Sub

    Private Sub ApplyFilter()
        Dim query = If(TextBox1.Text, String.Empty).Trim()
        Dim periodId = Convert.ToInt32(ComboBox1.SelectedValue)
        Dim statusFilter = Convert.ToInt32(ComboBox2.SelectedValue)
        Dim employeeId = Convert.ToInt32(ComboBox3.SelectedValue)
        Dim jobId = Convert.ToInt32(ComboBox4.SelectedValue)

        Dim filtered = _payrolls.Where(
            Function(p)
                If p Is Nothing Then Return False

                If periodId <> 0 Then
                    If p.Period Is Nothing OrElse p.Period.id <> periodId Then Return False
                End If
                If statusFilter <> -1 AndAlso p.status <> statusFilter Then Return False
                If employeeId <> 0 Then
                    Dim empId = p.Position?.Contract?.Employee?.id
                    If Not empId.HasValue OrElse empId.Value <> employeeId Then Return False
                End If
                If jobId <> 0 Then
                    Dim pjId = p.Position?.Job?.id
                    If Not pjId.HasValue OrElse pjId.Value <> jobId Then Return False
                End If

                If Not String.IsNullOrWhiteSpace(query) Then
                    Dim code = If(p.code, String.Empty)
                    Dim emp = If(p.employee_UI, String.Empty)
                    Dim job = If(p.job_UI, String.Empty)
                    If code.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       emp.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 AndAlso
                       job.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 Then
                        Return False
                    End If
                End If

                Return True
            End Function).ToList()

        _binding.DataSource = filtered
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim data As New Payroll()
        Using crud As New frmTinhLuongEdit(data, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _payrollService.Execute(DataIntent.Insert, data)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Thêm bảng lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilter()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row = DataGridView1.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Payroll)
        If data Is Nothing Then Return

        Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            Dim clone = Utils.DeepClone(data)
            Using crud As New frmTinhLuongEdit(clone)
                If crud.ShowDialog(Me) <> DialogResult.OK Then Return
            End Using

            Dim result = _payrollService.Execute(DataIntent.Update, clone)
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Cập nhật bảng lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        ElseIf colName = "colDelete" Then
            If MessageBox.Show("Xác nhận xóa bảng lương?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim result = _payrollService.Execute(DataIntent.SoftDeleteMany, New List(Of Payroll) From {data})
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Xóa bảng lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        End If
    End Sub
End Class
