Imports System.Linq

Public Class frmTinhLuongEdit
    Inherits Form

    Private ReadOnly _payPeriodService As New Pay_PeriodService()
    Private ReadOnly _positionService As New PositionService()
    Private ReadOnly _data As Payroll
    Private ReadOnly _isCreate As Boolean

    Private _periods As New List(Of Pay_Period)()
    Private _positions As New List(Of Position)()

    Private lblTitle As Label
    Private cboPeriod As ComboBox
    Private cboPosition As ComboBox
    Private txtCode As TextBox
    Private txtGross As TextBox
    Private txtBonus As TextBox
    Private txtDeduction As TextBox
    Private txtNet As TextBox
    Private cboStatus As ComboBox
    Private txtNote As TextBox
    Private btnSave As Button
    Private btnCancel As Button

    Public Sub New(data As Payroll, Optional isCreate As Boolean = False)
        _data = data
        _isCreate = isCreate
        BuildLayout()
    End Sub

    Private Sub BuildLayout()
        Me.Text = If(_isCreate, "Tạo bảng lương", "Cập nhật bảng lương")
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        Me.ClientSize = New Size(760, 520)

        lblTitle = New Label() With {
            .Text = If(_isCreate, "Tạo mới bảng lương", "Chi tiết bảng lương"),
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
            .RowCount = 10,
            .Padding = New Padding(16, 8, 16, 8)
        }
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        For i = 0 To 7
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        Next
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 52))

        cboPeriod = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        cboPosition = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtCode = New TextBox() With {.Dock = DockStyle.Fill}
        txtGross = New TextBox() With {.Dock = DockStyle.Fill}
        txtBonus = New TextBox() With {.Dock = DockStyle.Fill}
        txtDeduction = New TextBox() With {.Dock = DockStyle.Fill}
        txtNet = New TextBox() With {.Dock = DockStyle.Fill, .ReadOnly = True}
        cboStatus = New ComboBox() With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
        txtNote = New TextBox() With {.Dock = DockStyle.Fill, .Multiline = True, .ScrollBars = ScrollBars.Vertical}

        layout.Controls.Add(New Label() With {.Text = "Kỳ lương", .TextAlign = ContentAlignment.MiddleLeft}, 0, 0)
        layout.Controls.Add(cboPeriod, 1, 0)
        layout.Controls.Add(New Label() With {.Text = "Nhân viên / vị trí", .TextAlign = ContentAlignment.MiddleLeft}, 0, 1)
        layout.Controls.Add(cboPosition, 1, 1)
        layout.Controls.Add(New Label() With {.Text = "Mã bảng lương", .TextAlign = ContentAlignment.MiddleLeft}, 0, 2)
        layout.Controls.Add(txtCode, 1, 2)
        layout.Controls.Add(New Label() With {.Text = "Lương cơ bản", .TextAlign = ContentAlignment.MiddleLeft}, 0, 3)
        layout.Controls.Add(txtGross, 1, 3)
        layout.Controls.Add(New Label() With {.Text = "Phụ cấp", .TextAlign = ContentAlignment.MiddleLeft}, 0, 4)
        layout.Controls.Add(txtBonus, 1, 4)
        layout.Controls.Add(New Label() With {.Text = "Khấu trừ", .TextAlign = ContentAlignment.MiddleLeft}, 0, 5)
        layout.Controls.Add(txtDeduction, 1, 5)
        layout.Controls.Add(New Label() With {.Text = "Thực lĩnh", .TextAlign = ContentAlignment.MiddleLeft}, 0, 6)
        layout.Controls.Add(txtNet, 1, 6)
        layout.Controls.Add(New Label() With {.Text = "Trạng thái", .TextAlign = ContentAlignment.MiddleLeft}, 0, 7)
        layout.Controls.Add(cboStatus, 1, 7)
        layout.Controls.Add(New Label() With {.Text = "Ghi chú", .TextAlign = ContentAlignment.MiddleLeft}, 0, 8)
        layout.Controls.Add(txtNote, 1, 8)

        Dim panelButtons As New Panel() With {.Dock = DockStyle.Fill}
        btnSave = New Button() With {.Text = "Lưu", .Width = 100, .Height = 32, .BackColor = Color.FromArgb(24, 119, 242), .ForeColor = Color.White}
        btnCancel = New Button() With {.Text = "Hủy", .Width = 100, .Height = 32}
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

        layout.Controls.Add(panelButtons, 0, 9)
        layout.SetColumnSpan(panelButtons, 2)

        Me.Controls.Add(layout)
        Me.Controls.Add(lblTitle)

        AddHandler Me.Load, AddressOf frmTinhLuongEdit_Load
        AddHandler btnSave.Click, AddressOf btnSave_Click
        AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel

        AddHandler txtGross.TextChanged, Sub() RecalcNet()
        AddHandler txtBonus.TextChanged, Sub() RecalcNet()
        AddHandler txtDeduction.TextChanged, Sub() RecalcNet()
    End Sub

    Private Sub frmTinhLuongEdit_Load(sender As Object, e As EventArgs)
        LoadPeriods()
        LoadPositions()
        InitStatus()
        BindDataToUI()
    End Sub

    Private Sub LoadPeriods()
        Dim response = _payPeriodService.Execute(DataIntent.GetList)
        _periods = TryCast(response?.Data, IEnumerable(Of Pay_Period))?.ToList()
        If _periods Is Nothing Then _periods = New List(Of Pay_Period)()

        cboPeriod.DataSource = _periods.Select(Function(p) New With {
            .Display = $"{p.code} - {p.name}",
            .Value = p.id
        }).ToList()
        cboPeriod.DisplayMember = "Display"
        cboPeriod.ValueMember = "Value"
    End Sub

    Private Sub LoadPositions()
        Dim response = _positionService.Execute(DataIntent.GetList)
        _positions = TryCast(response?.Data, IEnumerable(Of Position))?.ToList()
        If _positions Is Nothing Then _positions = New List(Of Position)()

        cboPosition.DataSource = _positions.Select(Function(p) New With {
            .Display = $"{p.Contract?.Employee?.code} - {p.Contract?.Employee?.name} | {p.Job?.code} - {p.Job?.name}",
            .Value = p.id
        }).ToList()
        cboPosition.DisplayMember = "Display"
        cboPosition.ValueMember = "Value"
    End Sub

    Private Sub InitStatus()
        cboStatus.DataSource = New BindingSource(Payroll.status_Dict, Nothing)
        cboStatus.DisplayMember = "Value"
        cboStatus.ValueMember = "Key"
    End Sub

    Private Sub BindDataToUI()
        If _data Is Nothing Then Return

        txtCode.Text = If(_data.code, String.Empty)
        txtGross.Text = If(_data.gross_salary.HasValue, _data.gross_salary.Value.ToString("N0"), "0")
        txtBonus.Text = If(_data.bonus.HasValue, _data.bonus.Value.ToString("N0"), "0")
        txtDeduction.Text = If(_data.deduction.HasValue, _data.deduction.Value.ToString("N0"), "0")
        txtNet.Text = If(_data.net_salary.HasValue, _data.net_salary.Value.ToString("N0"), "0")
        txtNote.Text = If(_data.note, String.Empty)
        cboStatus.SelectedValue = _data.status

        If _data.Period IsNot Nothing Then
            cboPeriod.SelectedValue = _data.Period.id
        End If
        If _data.Position IsNot Nothing Then
            cboPosition.SelectedValue = _data.Position.id
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        If Not SyncUIToData() Then Return
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub RecalcNet()
        Dim gross = ParseDecimal(txtGross.Text)
        Dim bonus = ParseDecimal(txtBonus.Text)
        Dim deduction = ParseDecimal(txtDeduction.Text)
        Dim net = gross + bonus - deduction
        txtNet.Text = net.ToString("N0")
    End Sub

    Private Function ParseDecimal(text As String) As Decimal
        Dim value As Decimal
        Decimal.TryParse(If(text, "0").Replace(",", ""), value)
        Return value
    End Function

    Private Function SyncUIToData() As Boolean
        If _data Is Nothing Then Return False

        If cboPeriod.SelectedValue Is Nothing Then
            MessageBox.Show("Vui lòng chọn kỳ lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriod.Focus()
            Return False
        End If

        If cboPosition.SelectedValue Is Nothing Then
            MessageBox.Show("Vui lòng chọn nhân viên/vị trí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPosition.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCode.Text) Then
            MessageBox.Show("Vui lòng nhập mã bảng lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        Dim periodId = Convert.ToInt32(cboPeriod.SelectedValue)
        Dim period = _periods.FirstOrDefault(Function(p) p.id = periodId)
        If period Is Nothing Then
            MessageBox.Show("Kỳ lương không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPeriod.Focus()
            Return False
        End If

        Dim positionId = Convert.ToInt32(cboPosition.SelectedValue)
        Dim position = _positions.FirstOrDefault(Function(p) p.id = positionId)
        If position Is Nothing Then
            MessageBox.Show("Vị trí không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPosition.Focus()
            Return False
        End If

        _data.Period = period
        _data.Position = position
        _data.code = txtCode.Text.Trim()
        _data.gross_salary = ParseDecimal(txtGross.Text)
        _data.bonus = ParseDecimal(txtBonus.Text)
        _data.deduction = ParseDecimal(txtDeduction.Text)
        _data.net_salary = ParseDecimal(txtNet.Text)
        _data.note = txtNote.Text.Trim()
        _data.status = Convert.ToInt32(cboStatus.SelectedValue)

        Return True
    End Function
End Class
