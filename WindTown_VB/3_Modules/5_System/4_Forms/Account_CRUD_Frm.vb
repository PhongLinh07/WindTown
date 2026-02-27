Imports Microsoft.IdentityModel.Tokens

Public Class Account_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Account


    Private _displayStatus As New Dictionary(Of Integer, String) From {
        {0, "INACTIVE"},
        {1, "ACTIVE"}
    }
    Private _displayRole As New Dictionary(Of Integer, String) From {
        {1, "ADMIN"},
        {2, "STAFF"}
    }

    Public Sub New(data As Account, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me._data = data
        Me.isCreate = isCreate

        ui_status.DataSource = New BindingSource(_displayStatus, Nothing)
        ui_status.DisplayMember = "Value"
        ui_status.ValueMember = "Key"

        ui_role.DataSource = New BindingSource(_displayStatus, Nothing)
        ui_role.DisplayMember = "Value"
        ui_role.ValueMember = "Key"

        Me.Text = If(isCreate, "New", "Detail")

        If isCreate Then

            _data.password = ""
            _data.role = 1
            _data.last_login = DateTime.Now
            _data.last_logout = DateTime.Now
            _data.note = ""
            _data.status = 0
        End If

        BindDataToUI()

        tool_save.Enabled = False
    End Sub
    Protected Overrides Sub BindDataToUI()
        ui_employee.Text = _data.Employee_UI
        ui_password.Text = _data.password
        ui_role.SelectedValue = _data.role
        ui_last_login.Value = If(_data.last_login, DateTime.Now)
        ui_last_logout.Value = If(_data.last_logout, DateTime.Now)
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean

        'If String.IsNullOrWhiteSpace(ui_code.Text) Then
        '    MessageBox.Show("Code cannot be empty")
        '    ui_code.Focus()
        '    Return False
        'End If

        'If String.IsNullOrWhiteSpace(ui_password.Text) Then
        '    MessageBox.Show("Name cannot be empty")
        '    ui_password.Focus()
        '    Return False
        'End If

        '_data.code = ui_code.Text.Trim()
        '_data.name = ui_password.Text.Trim()

        _data.last_login = ui_last_login.Value
        _data.last_logout = ui_last_logout.Value
        _data.note = ui_note.Text

        If ui_status.SelectedValue IsNot Nothing Then
            _data.status = ui_status.SelectedValue.ToString()
        End If

        Return True
    End Function

    Protected Overrides Sub DataChanged() Handles ui_employee.SelectedIndexChanged,
                                 ui_password.TextChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged

        tool_save.Enabled = True
    End Sub

End Class