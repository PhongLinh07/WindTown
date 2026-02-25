Imports Microsoft.IdentityModel.Tokens

Public Class Department_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Department


    Private _displayStatus As New Dictionary(Of String, String) From {
        {"0", "INACTIVE"},
        {"1", "ACTIVE"}
    }

    Public Sub New(data As Department, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate

        ui_status.DataSource = New BindingSource(_displayStatus, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        Me.Text = If(isCreate, "New", "Detail")

        If isCreate Then
            _data.code = ""
            _data.name = ""
            _data.note = ""
            _data.status = "0"
        End If

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Private Sub BindDataToUI()
        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    Private Function SyncUIToData() As Boolean

        If String.IsNullOrWhiteSpace(ui_code.Text) Then
            MessageBox.Show("Code cannot be empty")
            ui_code.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ui_name.Text) Then
            MessageBox.Show("Name cannot be empty")
            ui_name.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.note = ui_note.Text

        If ui_status.SelectedValue IsNot Nothing Then
            _data.status = ui_status.SelectedValue.ToString()
        End If

        Return True
    End Function



    Private Shadows Sub DataChanged() Handles ui_code.TextChanged,
                                 ui_name.TextChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub

    Protected Overrides Sub tool_save_Click(sender As Object, e As EventArgs)

        If Not SyncUIToData() Then
            tool_save.Enabled = False
            Return
        End If

        MyBase.tool_save_Click(sender, e)

    End Sub
End Class