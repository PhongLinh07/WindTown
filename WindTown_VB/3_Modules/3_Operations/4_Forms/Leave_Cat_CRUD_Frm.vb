Imports Microsoft.IdentityModel.Tokens

Public Class Leave_Cat_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Leave_Cat


    Public Sub New(data As Leave_Cat, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "New", "Detail")

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_benefit.DataSource = New BindingSource(Leave_Cat.benefit_Dict, Nothing)
        ui_benefit.DisplayMember = "Value"
        ui_benefit.ValueMember = "Key"

        ui_status.DataSource = New BindingSource(Leave_Cat.status_Dict, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()


        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_benefit.SelectedValue = _data.benefit

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Mã loại không hợp lệ")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Tên loại không hợp lệ")
            ui_name.Focus()
            Return False
        End If


        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()

        _data.benefit = CInt(ui_benefit.SelectedValue)

        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_benefit.SelectedIndexChanged,
                                        ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub

End Class