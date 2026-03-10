Imports Microsoft.IdentityModel.Tokens

Public Class Holiday_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Holiday


    Public Sub New(data As Holiday, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate

        Me.Text = If(isCreate, "Thêm ngày lễ", "Chi tiết ngày lễ")

        InitComboBox()
        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Holiday.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()

        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_of_date.Value = If(_data.of_date, DateTime.Now)

        ui_day_mult.Text = _data.day_mult
        ui_night_mult.Text = _data.night_mult
        ui_ot_mult.Text = _data.ot_mult

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã ngày lễ không hợp lệ")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tên ngày lễ không hợp lệ")
            ui_code.Focus()
            Return False
        End If


        If Not Decimal.TryParse(ui_day_mult.Text, _data.day_mult) Then
            MessageBox.Show("Office Hours must be a valid number")
            ui_day_mult.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_night_mult.Text, _data.night_mult) Then
            MessageBox.Show("Overtime Hours must be a valid number")
            ui_night_mult.Focus()
            Return False
        End If
        If Not Decimal.TryParse(ui_ot_mult.Text, _data.ot_mult) Then
            MessageBox.Show("Late Hours must be a valid number")
            ui_ot_mult.Focus()
            Return False
        End If


        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()

        _data.of_date = ui_of_date.Value


        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_code.TextChanged,
                                        ui_day_mult.TextChanged,
                                        ui_night_mult.TextChanged,
                                        ui_ot_mult.TextChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class