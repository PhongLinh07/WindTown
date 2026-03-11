Imports System.Linq

Public Class frmHopDongEdit
    Inherits Form

    Private ReadOnly _employeeService As New EmployeeService()
    Private ReadOnly _data As Contract
    Private ReadOnly _isCreate As Boolean
    Private _employees As New List(Of Employee)()

    Private ReadOnly _statusList As New List(Of KeyValuePair(Of Integer, String)) From {
        New KeyValuePair(Of Integer, String)(1, "Đang hoạt động"),
        New KeyValuePair(Of Integer, String)(0, "Ngừng hoạt động")
    }

    Private lblTitle As Label
    Private cboEmployee As ComboBox
    Private txtCode As TextBox
    Private dtStart As DateTimePicker
    Private dtEnd As DateTimePicker
    Private txtBaseSalary As TextBox
    Private cboStatus As ComboBox
    Private txtNote As TextBox
    Private btnSave As Button
    Private btnCancel As Button

    Public Sub New(data As Contract, Optional isCreate As Boolean = False)
        _data = data
        _isCreate = isCreate
        BuildLayout()
    End Sub

    Private Sub BuildLayout()
        Me.Text = If(_isCreate, "Tạo hợp đồng", "Cập nhật hợp đồng")
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        Me.ClientSize = New Size(720, 480)

        lblTitle = New Label() With {
            .Text = If(_isCreate, "Tạo mới hợp đồng", "Chi tiết hợp đồng"),
            .Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Dock = DockStyle.Top,
            .Height = 48,
            .Padding = New Padding(16, 8, 0, 0)
        }

        Dim layout As New TableLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 8,
            .Padding = New Padding(16, 8, 16, 8)
        }
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 160))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 52))

        cboEmployee = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtCode = New TextBox() With {.Dock = DockStyle.Fill}
        dtStart = New DateTimePicker() With {.Dock = DockStyle.Fill, .Format = DateTimePickerFormat.Short}
        dtEnd = New DateTimePicker() With {.Dock = DockStyle.Fill, .Format = DateTimePickerFormat.Short}
        txtBaseSalary = New TextBox() With {.Dock = DockStyle.Fill}
        cboStatus = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtNote = New TextBox() With {.Dock = DockStyle.Fill, .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        layout.Controls.Add(New Label() With {.Text = "Nhân viên", .TextAlign = ContentAlignment.MiddleLeft}, 0, 0)
        layout.Controls.Add(cboEmployee, 1, 0)
        layout.Controls.Add(New Label() With {.Text = "Mã hợp đồng", .TextAlign = ContentAlignment.MiddleLeft}, 0, 1)
        layout.Controls.Add(txtCode, 1, 1)
        layout.Controls.Add(New Label() With {.Text = "Ngày bắt đầu", .TextAlign = ContentAlignment.MiddleLeft}, 0, 2)
        layout.Controls.Add(dtStart, 1, 2)
        layout.Controls.Add(New Label() With {.Text = "Ngày kết thúc", .TextAlign = ContentAlignment.MiddleLeft}, 0, 3)
        layout.Controls.Add(dtEnd, 1, 3)
        layout.Controls.Add(New Label() With {.Text = "Lương cơ bản", .TextAlign = ContentAlignment.MiddleLeft}, 0, 4)
        layout.Controls.Add(txtBaseSalary, 1, 4)
        layout.Controls.Add(New Label() With {.Text = "Trạng thái", .TextAlign = ContentAlignment.MiddleLeft}, 0, 5)
        layout.Controls.Add(cboStatus, 1, 5)
        layout.Controls.Add(New Label() With {.Text = "Ghi chú", .TextAlign = ContentAlignment.MiddleLeft}, 0, 6)
        layout.Controls.Add(txtNote, 1, 6)

        Dim panelButtons As New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(0, 4, 0, 4),
            .FlowDirection = FlowDirection.RightToLeft,
            .WrapContents = False
        }
        btnSave = New Button() With {.Text = "Lưu", .Width = 100, .Height = 32, .BackColor = Color.FromArgb(24, 119, 242), .ForeColor = Color.White}
        btnCancel = New Button() With {.Text = "Hủy", .Width = 100, .Height = 32, .DialogResult = DialogResult.Cancel}
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnSave.Margin = New Padding(8, 0, 0, 0)
        panelButtons.Controls.Add(btnCancel)
        panelButtons.Controls.Add(btnSave)

        Me.AcceptButton = btnSave
        Me.CancelButton = btnCancel

        layout.Controls.Add(panelButtons, 0, 7)
        layout.SetColumnSpan(panelButtons, 2)

        Me.Controls.Add(layout)
        Me.Controls.Add(lblTitle)

        AddHandler Me.Load, AddressOf frmHopDongEdit_Load
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmHopDongEdit_Load(sender As Object, e As EventArgs)
        LoadEmployees()
        InitStatus()
        BindDataToUI()
    End Sub

    Private Sub LoadEmployees()
        If _isCreate Then
            Dim response = _employeeService.Execute(DataIntent.GetEmployeesWithoutContract)
            _employees = TryCast(response?.Data, IEnumerable(Of Employee))?.ToList()
        Else
            _employees = New List(Of Employee)()
            If _data IsNot Nothing AndAlso _data.Employee IsNot Nothing Then
                _employees.Add(_data.Employee)
            End If
        End If
        If _employees Is Nothing Then _employees = New List(Of Employee)()

        cboEmployee.DataSource = _employees.Select(Function(e) New With {
            .Display = If(String.IsNullOrWhiteSpace(e.name), "---", e.name),
            .Value = e.id
        }).ToList()
        cboEmployee.DisplayMember = "Display"
        cboEmployee.ValueMember = "Value"
        cboEmployee.Enabled = _isCreate
    End Sub

    Private Sub InitStatus()
        cboStatus.DataSource = _statusList
        cboStatus.DisplayMember = "Value"
        cboStatus.ValueMember = "Key"
    End Sub

    Private Sub BindDataToUI()
        If _data Is Nothing Then Return

        txtCode.Text = If(_data.code, String.Empty)
        dtStart.Value = If(_data.start_date, DateTime.Now)
        dtEnd.Value = If(_data.end_date, DateTime.Now)
        txtBaseSalary.Text = If(_data.base_salary.HasValue, _data.base_salary.Value.ToString("N0"), "0")
        txtNote.Text = If(_data.note, String.Empty)
        cboStatus.SelectedValue = _data.status

        If _data.Employee IsNot Nothing Then
            cboEmployee.SelectedValue = _data.Employee.id
        Else
            cboEmployee.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not SyncUIToData() Then Return
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function SyncUIToData() As Boolean
        If _data Is Nothing Then Return False

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        Dim baseSalary As Decimal
        If Not Decimal.TryParse(txtBaseSalary.Text.Replace(",", ""), baseSalary) Then
            MessageBox.Show("Lương cơ bản không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseSalary.Focus()
            Return False
        End If

        If _isCreate Then
            If cboEmployee.SelectedValue Is Nothing Then
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboEmployee.Focus()
                Return False
            End If

            Dim empId = Convert.ToInt32(cboEmployee.SelectedValue)
            Dim emp = _employees.FirstOrDefault(Function(x) x.id = empId)
            If emp Is Nothing Then
                MessageBox.Show("Nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboEmployee.Focus()
                Return False
            End If
            _data.Employee = emp
        End If

        If dtStart.Value.Date > dtEnd.Value.Date Then
            MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtStart.Focus()
            Return False
        End If

        _data.code = txtCode.Text.Trim()
        _data.start_date = dtStart.Value
        _data.end_date = dtEnd.Value
        _data.base_salary = baseSalary
        _data.note = txtNote.Text.Trim()
        _data.status = Convert.ToInt32(cboStatus.SelectedValue)

        Return True
    End Function
End Class
