Imports System.Linq

Public Class frmChamCongEdit
    Inherits Form

    Private ReadOnly _employeeService As New EmployeeService()
    Private ReadOnly _data As Attendance
    Private ReadOnly _isCreate As Boolean
    Private _employees As New List(Of Employee)()

    Private ReadOnly _statusList As New List(Of KeyValuePair(Of Integer, String)) From {
        New KeyValuePair(Of Integer, String)(1, "Đang hoạt động"),
        New KeyValuePair(Of Integer, String)(0, "Ngừng hoạt động")
    }

    Private ReadOnly _shiftList As New List(Of KeyValuePair(Of Integer, String)) From {
        New KeyValuePair(Of Integer, String)(0, "Ngày"),
        New KeyValuePair(Of Integer, String)(1, "Đêm")
    }

    Private lblTitle As Label
    Private cboEmployee As ComboBox
    Private txtCode As TextBox
    Private dtOfDate As DateTimePicker
    Private cboShift As ComboBox
    Private txtOffice As TextBox
    Private txtOvertime As TextBox
    Private txtLate As TextBox
    Private txtEarly As TextBox
    Private cboStatus As ComboBox
    Private txtNote As TextBox
    Private btnSave As Button
    Private btnCancel As Button

    Public Sub New(data As Attendance, Optional isCreate As Boolean = False)
        _data = data
        _isCreate = isCreate
        BuildLayout()
    End Sub

    Private Sub BuildLayout()
        Me.Text = If(_isCreate, "Tạo chấm công", "Cập nhật chấm công")
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        Me.ClientSize = New Size(760, 520)

        lblTitle = New Label() With {
            .Text = If(_isCreate, "Tạo mới chấm công", "Chi tiết chấm công"),
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
            .RowCount = 11,
            .Padding = New Padding(16, 8, 16, 8)
        }
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        For i = 0 To 8
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        Next
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 52))

        cboEmployee = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtCode = New TextBox() With {.Dock = DockStyle.Fill}
        dtOfDate = New DateTimePicker() With {.Dock = DockStyle.Fill, .Format = DateTimePickerFormat.Short}
        cboShift = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtOffice = New TextBox() With {.Dock = DockStyle.Fill}
        txtOvertime = New TextBox() With {.Dock = DockStyle.Fill}
        txtLate = New TextBox() With {.Dock = DockStyle.Fill}
        txtEarly = New TextBox() With {.Dock = DockStyle.Fill}
        cboStatus = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtNote = New TextBox() With {.Dock = DockStyle.Fill, .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        layout.Controls.Add(New Label() With {.Text = "Nhân viên", .TextAlign = ContentAlignment.MiddleLeft}, 0, 0)
        layout.Controls.Add(cboEmployee, 1, 0)
        layout.Controls.Add(New Label() With {.Text = "Mã chấm công", .TextAlign = ContentAlignment.MiddleLeft}, 0, 1)
        layout.Controls.Add(txtCode, 1, 1)
        layout.Controls.Add(New Label() With {.Text = "Ngày chấm công", .TextAlign = ContentAlignment.MiddleLeft}, 0, 2)
        layout.Controls.Add(dtOfDate, 1, 2)
        layout.Controls.Add(New Label() With {.Text = "Ca làm", .TextAlign = ContentAlignment.MiddleLeft}, 0, 3)
        layout.Controls.Add(cboShift, 1, 3)
        layout.Controls.Add(New Label() With {.Text = "Giờ hành chính", .TextAlign = ContentAlignment.MiddleLeft}, 0, 4)
        layout.Controls.Add(txtOffice, 1, 4)
        layout.Controls.Add(New Label() With {.Text = "Giờ tăng ca", .TextAlign = ContentAlignment.MiddleLeft}, 0, 5)
        layout.Controls.Add(txtOvertime, 1, 5)
        layout.Controls.Add(New Label() With {.Text = "Đi muộn", .TextAlign = ContentAlignment.MiddleLeft}, 0, 6)
        layout.Controls.Add(txtLate, 1, 6)
        layout.Controls.Add(New Label() With {.Text = "Về sớm", .TextAlign = ContentAlignment.MiddleLeft}, 0, 7)
        layout.Controls.Add(txtEarly, 1, 7)
        layout.Controls.Add(New Label() With {.Text = "Trạng thái", .TextAlign = ContentAlignment.MiddleLeft}, 0, 8)
        layout.Controls.Add(cboStatus, 1, 8)
        layout.Controls.Add(New Label() With {.Text = "Ghi chú", .TextAlign = ContentAlignment.MiddleLeft}, 0, 9)
        layout.Controls.Add(txtNote, 1, 9)

        Dim panelButtons As New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(0, 4, 0, 4)}
        btnSave = New Button() With {.Text = "Lưu", .Width = 100, .Height = 32, .BackColor = Color.FromArgb(24, 119, 242), .ForeColor = Color.White}
        btnCancel = New Button() With {.Text = "Hủy", .Width = 100, .Height = 32, .DialogResult = DialogResult.Cancel}
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        panelButtons.Controls.Add(btnSave)
        panelButtons.Controls.Add(btnCancel)

        AddHandler panelButtons.Resize, Sub()
                                            btnCancel.Left = panelButtons.Width - 110
                                            btnSave.Left = panelButtons.Width - 220
                                        End Sub
        btnSave.Top = 8
        btnCancel.Top = 8
        btnCancel.Left = panelButtons.Width - 110
        btnSave.Left = panelButtons.Width - 220

        layout.Controls.Add(panelButtons, 0, 10)
        layout.SetColumnSpan(panelButtons, 2)

        Me.Controls.Add(layout)
        Me.Controls.Add(lblTitle)

        AddHandler Me.Load, AddressOf frmChamCongEdit_Load
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel

        Me.AcceptButton = btnSave
        Me.CancelButton = btnCancel
    End Sub

    Private Sub frmChamCongEdit_Load(sender As Object, e As EventArgs)
        LoadEmployees()
        InitShift()
        InitStatus()
        BindDataToUI()
    End Sub

    Private Sub LoadEmployees()
        Dim response = _employeeService.Execute(DataIntent.GetList)
        _employees = TryCast(response?.Data, IEnumerable(Of Employee))?.Where(Function(e) e IsNot Nothing).ToList()
        If _employees Is Nothing Then _employees = New List(Of Employee)()

        cboEmployee.DataSource = _employees.Select(Function(e) New With {
            .Display = $"{e.code} - {e.name}",
            .Value = e.id
        }).ToList()
        cboEmployee.DisplayMember = "Display"
        cboEmployee.ValueMember = "Value"
    End Sub

    Private Sub InitShift()
        cboShift.DataSource = _shiftList
        cboShift.DisplayMember = "Value"
        cboShift.ValueMember = "Key"
    End Sub

    Private Sub InitStatus()
        cboStatus.DataSource = _statusList
        cboStatus.DisplayMember = "Value"
        cboStatus.ValueMember = "Key"
    End Sub

    Private Sub BindDataToUI()
        If _data Is Nothing Then Return

        txtCode.Text = If(_data.code, String.Empty)
        dtOfDate.Value = If(_data.of_date, DateTime.Now)
        txtOffice.Text = _data.office_hours.ToString()
        txtOvertime.Text = _data.overtime_hours.ToString()
        txtLate.Text = _data.late_hours.ToString()
        txtEarly.Text = _data.early_hours.ToString()
        txtNote.Text = If(_data.note, String.Empty)
        cboStatus.SelectedValue = _data.status
        cboShift.SelectedValue = _data.shift

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

    Private Function ParseDecimal(text As String) As Decimal
        Dim value As Decimal
        Decimal.TryParse(If(text, "0").Replace(",", ""), value)
        Return value
    End Function

    Private Function SyncUIToData() As Boolean
        If _data Is Nothing Then Return False

        If cboEmployee.SelectedValue Is Nothing Then
            MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployee.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        Dim empId = Convert.ToInt32(cboEmployee.SelectedValue)
        Dim emp = _employees.FirstOrDefault(Function(e) e.id = empId)
        If emp Is Nothing Then
            MessageBox.Show("Nhân viên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmployee.Focus()
            Return False
        End If

        Dim office = ParseDecimal(txtOffice.Text)
        Dim overtime = ParseDecimal(txtOvertime.Text)
        Dim late = ParseDecimal(txtLate.Text)
        Dim early = ParseDecimal(txtEarly.Text)

        If office < 0 OrElse overtime < 0 OrElse late < 0 OrElse early < 0 Then
            MessageBox.Show("Giờ công không được âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        _data.Employee = emp
        _data.code = txtCode.Text.Trim()
        _data.of_date = dtOfDate.Value
        _data.shift = Convert.ToInt32(cboShift.SelectedValue)
        _data.office_hours = office
        _data.overtime_hours = overtime
        _data.late_hours = late
        _data.early_hours = early
        _data.status = Convert.ToInt32(cboStatus.SelectedValue)
        _data.note = txtNote.Text.Trim()

        Return True
    End Function
End Class
