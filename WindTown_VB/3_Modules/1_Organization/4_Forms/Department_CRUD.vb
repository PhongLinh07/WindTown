Public Class Department_CRUD
    Inherits BaseACRUDForm
    Protected _data As Department

    Private _displayStatus As New Dictionary(Of String, String) From {
        {"-1", "DELETED"},
        {"0", "INACTIVE"},
        {"1", "ACTIVE"}
    }
    Public Sub New(data As Department, Optional isCreate As Boolean = False)

        InitializeComponent()

        ui_status.DataSource = New BindingSource(_displayStatus, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        Me.isCreate = isCreate
        Me._data = data

        Me.Text = $"{If(isCreate, "New", "Detail")} Department"

        ui_code.Text = If(isCreate, "", _data.code)
        ui_name.Text = If(isCreate, "", _data.name)
        ui_note.Text = If(isCreate, "", _data.note)
        ui_status.SelectedValue = If(isCreate, "0", _data.status)

        isInited = True
    End Sub


    Private Sub ui_name_TextChanged(sender As Object, e As EventArgs) Handles ui_name.TextChanged

    End Sub

    Private Sub ui_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ui_status.SelectedIndexChanged
        If isInited = False Then Return

        isChanged = True
        tool_save.Enabled = True
        If ui_status.SelectedValue Is Nothing Then Return

        _data.status = ui_status.SelectedValue
    End Sub
End Class