Imports WindTown_VB.AppServices

Public Class BaseList_UC
    Inherits UserControl

    Protected _service As IBaseService
    Protected _bindingSource As New BindingSource()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(service As IBaseService, tag As String, title As String)
        InitializeComponent()

        Me.Tag = tag
        Me.Text = title
        _service = service

    End Sub

    Protected Sub Init(modelType As Type)
        GridHelper.SetupGrid(_dgv, modelType)
        LoadData()
    End Sub

    Private Sub ConfigDGV()
    End Sub
    Public Sub Refreash()
        LoadData()
    End Sub

    ' load data từ service và gán vào DataGridView thông qua BindingSource để hỗ trợ tính năng lọc (Search)
    Protected Overridable Sub LoadData()
        _dgv.ClearSelection()
        Dim response = _service.GetList()
        If response.IsSuccess Then
            ' Gán danh sách vào BindingSource để hỗ trợ lọc (Search)
            _bindingSource.DataSource = response.Data
            _dgv.DataSource = _bindingSource

        Else
            MessageBox.Show(response.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        _dgv.ClearSelection()
        viewSelected.Text = "Rows selected:  0"
        tool_delete.Enabled = False
    End Sub


    ' khi người dùng double click vào 1 dòng, sẽ mở form CRUD để xem/sửa chi tiết. Form CRUD sẽ trả về DialogResult.OK nếu có thay đổi và cần refresh lại danh sách
    Protected Overridable Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dgv.CellDoubleClick

    End Sub

    ' khi người dùng chọn 1 hoặc nhiều dòng, sẽ hiển thị số lượng đã chọn và bật/tắt các tool tương ứng (ví dụ: tool_delete chỉ bật khi có ít nhất 1 dòng được chọn)
    Protected Overridable Sub Dgv_SelectionChanged(sender As Object, e As EventArgs) Handles _dgv.SelectionChanged
        viewSelected.Text = $"Rows selected:  {_dgv.SelectedRows.Count}"
        tool_delete.Enabled = _dgv.SelectedRows.Count > 0
    End Sub

    ' Tool: New
    Protected Overridable Sub tool_new_Click(sender As Object, e As EventArgs) Handles tool_new.Click
        ' TODO: implement
    End Sub

    ' Tool: Delete (xóa) - xóa các dòng được chọn. Sau khi xóa sẽ refresh lại danh sách
    Protected Overridable Sub tool_delete_Click(sender As Object, e As EventArgs) Handles tool_delete.Click
        ' TODO: implement
    End Sub

    Private Sub tool_hide_column_Click(sender As Object, e As EventArgs) Handles tool_hide_column.Click
        ' Khởi tạo Form thiết lập, truyền DataGridView1 vào
        Dim frm As New DgvDisplay_frm(_dgv)

        ' Hiển thị Form theo dạng Dialog (cửa sổ con hiện lên đè lên form chính)
        frm.ShowDialog()
    End Sub

    Private Sub tool_refresh_Click(sender As Object, e As EventArgs) Handles tool_refresh.Click
        Refreash()
    End Sub


End Class