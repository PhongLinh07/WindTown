Imports System.Linq

Public Class frmChucVu

    Private ReadOnly _service As New PositionService()
    Private _positions As List(Of Position) = New List(Of Position)()
    Private _contextMenu As ContextMenuStrip

    Private Sub frmChucVu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)

        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Lỗi kết nối CSDL: " & bootstrap.Message, "Lỗi kết nối CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisableUi()
            Return
        End If

        InitFormLayout()
        InitContextMenu()
        LoadData()
    End Sub

    Private Sub InitFormLayout()
        Label1.Text = "Chức vụ"
        Me.Text = "Chức vụ"

        Button1.Visible = True
        Button2.Visible = False

        Button5.Visible = True
        Button5.Text = "Sửa chức vụ"
        Button5.Enabled = False

        Label2.Text = "Chi tiết:"
        tvChucVu.HideSelection = False
    End Sub

    Private Sub InitContextMenu()
        _contextMenu = New ContextMenuStrip()
        Dim itemDelete As New ToolStripMenuItem("Xóa chức vụ")
        AddHandler itemDelete.Click, AddressOf ContextDelete_Click
        _contextMenu.Items.Add(itemDelete)
        tvChucVu.ContextMenuStrip = _contextMenu
    End Sub

    Private Sub DisableUi()
        pnlBody.Enabled = False
        Panel1.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button5.Enabled = False
        Button3.Enabled = False
        tbxSearch.Enabled = False
        tvChucVu.Enabled = False
    End Sub

    Private Sub LoadData(Optional keyword As String = Nothing)
        Dim response = _service.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Position))
            _positions = If(data IsNot Nothing, data.ToList(), New List(Of Position)())
        Else
            _positions = New List(Of Position)()
            MessageBox.Show(response.Message, "Lỗi dữ liệu ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim filtered = ApplySearch(_positions, keyword)
        RenderTree(filtered)
    End Sub

    Private Function ApplySearch(source As List(Of Position), keyword As String) As List(Of Position)
        If source Is Nothing Then Return New List(Of Position)()
        If String.IsNullOrWhiteSpace(keyword) OrElse keyword.Trim().ToLowerInvariant() = "Tìm kiếm" Then
            Return source
        End If

        Dim k = keyword.Trim().ToLowerInvariant()
        Return source.Where(Function(p)
                                Dim hay = ($"{p.code} {p.employee_UI} {p.job_UI} {p.level_UI} {p.contract_UI}").ToLowerInvariant()
                                Return hay.Contains(k)
                            End Function).ToList()
    End Function

    Private Sub RenderTree(list As List(Of Position))
        tvChucVu.BeginUpdate()
        tvChucVu.Nodes.Clear()

        Dim nodeActive As New TreeNode("Đang hoạt động")
        Dim nodeInactive As New TreeNode("Ngưng hoạt động")

        For Each pos In list
            Dim text = $"{pos.code} | {pos.employee_UI} | {pos.job_UI} | {pos.level_UI}"
            Dim node As New TreeNode(text) With {.Tag = pos}

            If pos.status = 1 Then
                nodeActive.Nodes.Add(node)
            Else
                nodeInactive.Nodes.Add(node)
            End If
        Next

        If nodeActive.Nodes.Count > 0 Then tvChucVu.Nodes.Add(nodeActive)
        If nodeInactive.Nodes.Count > 0 Then tvChucVu.Nodes.Add(nodeInactive)

        tvChucVu.ExpandAll()
        tvChucVu.EndUpdate()
    End Sub

    Private Sub UpdateDetail(pos As Position)
        If pos Is Nothing Then
            Label2.Text = "Chi tiết chức vụ:"
            Button5.Enabled = False
            Return
        End If

        Button5.Enabled = True
        Dim statusText = If(Position.status_Dict.ContainsKey(pos.status), Position.status_Dict(pos.status), "---")

        Label2.Text = "Chi tiết chức vụ:" & vbCrLf &
                      $"Mã: {pos.code}" & vbCrLf &
                      $"Nhân viên: {pos.employee_UI}" & vbCrLf &
                      $"Hợp đồng: {pos.contract_UI}" & vbCrLf &
                      $"Công việc: {pos.job_UI}" & vbCrLf &
                      $"Trình độ: {pos.level_UI}" & vbCrLf &
                      $"Trạng thái: {statusText}" & vbCrLf &
                      $"Từ ngày: {pos.start_date:dd-MM-yyyy}" & vbCrLf &
                      $"Đến ngày: {pos.end_date:dd-MM-yyyy}" & vbCrLf &
                      $"Ghi chú: {pos.note}"
    End Sub

    Private Function GetSelectedPosition() As Position
        Dim node = tvChucVu.SelectedNode
        If node Is Nothing Then Return Nothing
        Return TryCast(node.Tag, Position)
    End Function

    Private Sub OpenCreate()
        Dim data As New Position()
        Dim crud As New Position_CRUD_Frm(data, True)
        If crud.ShowDialog() = DialogResult.OK Then
            Dim result = _service.Execute(DataIntent.Insert, data)
            If result.IsSuccess Then
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData(tbxSearch.Text)
            Else
                MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub OpenEdit(pos As Position)
        If pos Is Nothing Then
            MessageBox.Show("Vui lòng chọn chức vụ cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim data = Utils.DeepClone(pos)
        Dim crud As New Position_CRUD_Frm(data)
        If crud.ShowDialog() = DialogResult.OK Then
            Dim result = _service.Execute(DataIntent.Update, data)
            If result.IsSuccess Then
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData(tbxSearch.Text)
            Else
                MessageBox.Show(result.Message, "Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub DeleteSelected(pos As Position)
        If pos Is Nothing Then
            MessageBox.Show("Vui lòng chọn chức vụ cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Xác nhận xóa chức vụ '{pos.code}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim items As New List(Of Position) From {pos}
        Dim result = _service.Execute(DataIntent.SoftDeleteMany, items)
        If result.IsSuccess Then
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenCreate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenCreate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEdit(GetSelectedPosition())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadData(tbxSearch.Text)
    End Sub

    Private Sub tvChucVu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvChucVu.AfterSelect
        Dim pos = GetSelectedPosition()
        UpdateDetail(pos)
    End Sub

    Private Sub tvChucVu_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvChucVu.NodeMouseDoubleClick
        Dim pos = GetSelectedPosition()
        If pos IsNot Nothing Then
            OpenEdit(pos)
        End If
    End Sub

    Private Sub ContextDelete_Click(sender As Object, e As EventArgs)
        DeleteSelected(GetSelectedPosition())
    End Sub

    Private Sub tbxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadData(tbxSearch.Text)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub tbxSearch_Enter(sender As Object, e As EventArgs) Handles tbxSearch.Enter
        If tbxSearch.Text.Trim().ToLowerInvariant() = "Tìm kiếm" Then
            tbxSearch.Text = ""
        End If
    End Sub

    Private Sub tbxSearch_Leave(sender As Object, e As EventArgs) Handles tbxSearch.Leave
        If String.IsNullOrWhiteSpace(tbxSearch.Text) Then
            tbxSearch.Text = "Tìm kiếm"
        End If
    End Sub

End Class
