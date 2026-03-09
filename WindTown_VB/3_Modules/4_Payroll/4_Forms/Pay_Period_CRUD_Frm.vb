Imports Microsoft.IdentityModel.Tokens

Public Class Pay_Period_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Pay_Period

    Public Sub New(data As Pay_Period, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "Tạo kỳ lương", "Chi tiết kỳ lương")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Pay_Period.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_start_date.Value = _data.start_date
        ui_end_date.Value = _data.end_date

        ui_std_hours.Text = _data.std_hours

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean


        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã kỳ lương không hợp lệ")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tiêu đề kỳ lương không hợp lệ")
            ui_name.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()

        _data.start_date = ui_start_date.Value
        _data.end_date = ui_end_date.Value

        If Not Decimal.TryParse(ui_std_hours.Text, _data.std_hours) Then
            _data.std_hours = 0
        End If


        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_start_date.ValueChanged,
                                        ui_end_date.ValueChanged,
                                        ui_std_hours.TextChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

    Private Sub Calculator() Handles ui_start_date.ValueChanged,
                                     ui_end_date.ValueChanged

        'call...
    End Sub

End Class