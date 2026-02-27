Public Class Job_CRUD_Frm
    Inherits BaseACRUDForm
    Protected _data As Job

    Private _displayStatus As New Dictionary(Of Integer, String) From {
        {0, "INACTIVE"},
        {1, "ACTIVE"}
    }
    Private _deparments As List(Of Department)

    Public Sub New(data As Job, Optional isCreate As Boolean = False)

        InitializeComponent()
        InitComboBox()

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
            _data.status = 0
        End If

        BindDataToUI()

        tool_save.Enabled = False
    End Sub

    Private Sub InitComboBox()
        Dim departmentService As New BaseService(Of Department)

        Dim response = departmentService.Execute(DataIntent.GetList)
        _deparments = If(response.IsSuccess, response.Data, New List(Of Department))

        ui_department.DataSource =
            _deparments.
            Select(Function(x) New With {
                .Display = $"{x.code} - {x.name}",
                .Value = x.id
            }).ToList()

        ui_department.DisplayMember = "Display"
        ui_department.ValueMember = "Value"
    End Sub

    Protected Overrides Sub BindDataToUI()
        ui_code.Text = _data.code
        ui_name.Text = _data.name
        ui_note.Text = _data.note
        ui_status.SelectedValue = _data.status
        ui_department.SelectedValue = _data.department_id
    End Sub

    Protected Overrides Function SyncUIToData() As Boolean
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

        If _deparments.All(Function(d) d.id <> Convert.ToInt32(ui_department.SelectedValue)) Then
            MessageBox.Show("Invalid department selected")
            ui_department.Focus()
            Return False
        End If

        _data.code = ui_code.Text.Trim()
        _data.name = ui_name.Text.Trim()
        _data.note = ui_note.Text

        If ui_department.SelectedValue IsNot Nothing Then
            _data.Department = _deparments.FirstOrDefault(Function(x) x.id = Convert.ToInt32(ui_department.SelectedValue))
        End If

        If ui_status.SelectedValue IsNot Nothing Then
            _data.status = ui_status.SelectedValue.ToString()
        End If

        Return True
    End Function

    Protected Overrides Sub DataChanged() Handles ui_code.TextChanged,
                                 ui_name.TextChanged,
                                 ui_note.TextChanged,
                                 ui_status.SelectedIndexChanged,
                                 ui_department.SelectedIndexChanged
        tool_save.Enabled = True
    End Sub
End Class