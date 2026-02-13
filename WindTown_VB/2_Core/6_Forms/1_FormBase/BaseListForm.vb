Imports System.Windows.Forms

Public Class BaseListForm(Of T As {BaseEntity, New})
    Inherits Form

    Protected _service As BaseService(Of T)
    Protected _bindingSource As New BindingSource()
    Protected txtSearch As TextBox


    Public Sub New(service As BaseService(Of T), title As String)
        InitializeComponent()
        ' Thiết lập cơ bản cho Form
        Me.Text = "Quản lý " & title
        Me.Size = New Size(900, 500)
        Me.StartPosition = FormStartPosition.CenterScreen

        _service = service
        LoadData()
        ConfigDGV()
    End Sub

    ' 1. NẠP DỮ LIỆU
    Protected Sub LoadData()
        Dim response = _service.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            ' Gán danh sách vào BindingSource để hỗ trợ lọc (Search)
            _bindingSource.DataSource = response.Data
            _dgv.DataSource = _bindingSource

        Else
            MessageBox.Show(response.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ConfigDGV()

    End Sub
End Class