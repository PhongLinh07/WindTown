Imports Azure
Imports Microsoft.IdentityModel.Tokens

Public Class Project_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Project




    Public Sub New(data As Project, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate
        InitComboBox()

        Me.Text = If(isCreate, "New", "Detail")


        If isCreate Then

            _data.code = ""
            _data.name = ""
            _data.start_date = DateTime.Now
            _data.end_date = DateTime.Now
            _data.note = ""
            _data.status = 0
        End If

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub InitComboBox()

        ui_status.DataSource = New BindingSource(Project.Dict_Status, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

    End Sub

    Protected Overrides Sub BindDataToUI()


        ui_code.Text = _data.code
        ui_name.Text = _data.name

        ui_start_date.Value = If(_data.start_date, DateTime.Now)
        ui_end_date.Value = If(_data.end_date, DateTime.Now)

        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status

    End Sub

    Protected Overrides Function SyncUIToData() As Boolean


        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Code cannot be empty")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Name cannot be empty")
            ui_code.Focus()
            Return False
        End If


        _data.code = ui_code.Text
        _data.name = ui_name.Text

        _data.start_date = ui_start_date.Value
        _data.end_date = ui_end_date.Value

        _data.note = ui_note.Text
        _data.status = CInt(ui_status.SelectedValue)

        Return True

    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                        ui_name.TextChanged,
                                        ui_start_date.ValueChanged,
                                        ui_end_date.ValueChanged,
                                        ui_note.TextChanged,
                                        ui_status.SelectedIndexChanged

        tool_save.Enabled = True

    End Sub


End Class