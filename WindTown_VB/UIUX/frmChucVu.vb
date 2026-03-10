Imports System.Linq

Public Class frmChucVu

    Private ReadOnly _departmentService As New BaseService(Of Department)()
    Private ReadOnly _jobService As New JobService()

    Private _departments As New List(Of Department)()
    Private _jobs As New List(Of Job)()

    Private _menu As ContextMenuStrip
    Private _btnEdit As Button
    Private _btnDelete As Button

    Private Const NODE_DEPARTMENT As String = "DEPARTMENT"
    Private Const NODE_JOB As String = "JOB"

    Private Class NodeMeta
        Public Property NodeType As String
        Public Property Id As Integer
    End Class

    Private Sub frmChucVu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitContextMenu()
        InitActionButtons()
        ReloadAndBind()
    End Sub

    Private Sub InitActionButtons()
        If _btnEdit IsNot Nothing Then Return

        _btnEdit = New Button() With {
            .Text = "Sửa",
            .Size = New Size(100, 31),
            .BackColor = Color.FromArgb(255, 193, 7),
            .ForeColor = Color.Black,
            .FlatStyle = FlatStyle.Flat,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        _btnEdit.FlatAppearance.BorderSize = 0

        _btnDelete = New Button() With {
            .Text = "Xóa",
            .Size = New Size(100, 31),
            .BackColor = Color.FromArgb(220, 53, 69),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        _btnDelete.FlatAppearance.BorderSize = 0

        pnlHeader.Controls.Add(_btnEdit)
        pnlHeader.Controls.Add(_btnDelete)

        AddHandler _btnEdit.Click, AddressOf Menu_Sua
        AddHandler _btnDelete.Click, AddressOf Menu_Xoa
        AddHandler pnlHeader.Resize, AddressOf PositionActionButtons

        PositionActionButtons(Nothing, EventArgs.Empty)
        UpdateActionButtons()
    End Sub

    Private Sub PositionActionButtons(sender As Object, e As EventArgs)
        If _btnEdit Is Nothing OrElse _btnDelete Is Nothing Then Return

        Dim rightEdge = pnlHeader.Width - 10
        _btnDelete.Top = 20
        _btnEdit.Top = 20
        _btnDelete.Left = rightEdge - _btnDelete.Width
        _btnEdit.Left = _btnDelete.Left - 10 - _btnEdit.Width

        If Button1 IsNot Nothing Then
            Button1.Left = _btnEdit.Left - 10 - Button1.Width
        End If
    End Sub

    Private Sub InitContextMenu()
        _menu = New ContextMenuStrip()
        _menu.Items.Add("Thêm chức vụ", Nothing, AddressOf Menu_Them)
        _menu.Items.Add("Sửa", Nothing, AddressOf Menu_Sua)
        _menu.Items.Add("Xóa", Nothing, AddressOf Menu_Xoa)

        AddHandler tvChucVu.NodeMouseClick, AddressOf tvChucVu_NodeMouseClick
        AddHandler tvChucVu.NodeMouseDoubleClick, AddressOf tvChucVu_NodeMouseDoubleClick
        AddHandler tvChucVu.AfterSelect, AddressOf tvChucVu_AfterSelect
    End Sub

    Private Sub ReloadAndBind(Optional searchText As String = Nothing)
        LoadData()
        BuildTree(searchText)
        ShowSelectedDetails()
    End Sub

    Private Sub LoadData()
        Dim deptResponse = _departmentService.Execute(DataIntent.GetList)
        _departments = TryCast(deptResponse?.Data, IEnumerable(Of Department))?.Where(Function(d) d IsNot Nothing AndAlso d.status <> -1).ToList()
        If _departments Is Nothing Then _departments = New List(Of Department)()

        Dim jobResponse = _jobService.Execute(DataIntent.GetList)
        _jobs = TryCast(jobResponse?.Data, IEnumerable(Of Job))?.Where(Function(j) j IsNot Nothing AndAlso j.status <> -1).ToList()
        If _jobs Is Nothing Then _jobs = New List(Of Job)()

        ' Bảo vệ trường hợp repository không fill Department.
        Dim deptById = _departments.ToDictionary(Function(d) d.id)
        For Each j In _jobs
            If j.Department Is Nothing Then j.Department = New Department()
            Dim depId = j.department_id
            Dim resolved As Department = Nothing
            If depId > 0 AndAlso deptById.TryGetValue(depId, resolved) Then
                j.Department = resolved
            End If
        Next
    End Sub

    Private Sub BuildTree(Optional searchText As String = Nothing)
        tvChucVu.BeginUpdate()
        Try
            tvChucVu.Nodes.Clear()

            Dim query = (If(searchText, String.Empty)).Trim()
            Dim hasSearch = Not String.IsNullOrWhiteSpace(query) AndAlso query <> "Tìm kiếm"

            For Each dept In _departments.OrderBy(Function(d) d.code)
                Dim deptNode As New TreeNode($"[{dept.code}] {dept.name}")
                deptNode.Tag = New NodeMeta With {.NodeType = NODE_DEPARTMENT, .Id = dept.id}

                Dim jobsInDept = _jobs.
                    Where(Function(j) j.Department IsNot Nothing AndAlso j.Department.id = dept.id).
                    OrderBy(Function(j) j.code).
                    ToList()

                For Each job In jobsInDept
                    Dim label = $"{job.code} - {job.name}"
                    If hasSearch AndAlso label.IndexOf(query, StringComparison.OrdinalIgnoreCase) < 0 Then
                        Continue For
                    End If

                    Dim jobNode As New TreeNode(label)
                    jobNode.Tag = New NodeMeta With {.NodeType = NODE_JOB, .Id = job.id}
                    deptNode.Nodes.Add(jobNode)
                Next

                ' Nếu đang search: chỉ add department có con.
                If (Not hasSearch) OrElse deptNode.Nodes.Count > 0 Then
                    tvChucVu.Nodes.Add(deptNode)
                End If
            Next

            tvChucVu.ExpandAll()
        Finally
            tvChucVu.EndUpdate()
        End Try
    End Sub

    Private Function GetSelectedMeta() As NodeMeta
        Dim node = tvChucVu.SelectedNode
        If node Is Nothing Then Return Nothing
        Return TryCast(node.Tag, NodeMeta)
    End Function

    Private Function GetSelectedJob() As Job
        Dim meta = GetSelectedMeta()
        If meta Is Nothing OrElse meta.NodeType <> NODE_JOB Then Return Nothing
        Return _jobs.FirstOrDefault(Function(j) j.id = meta.Id)
    End Function

    Private Function GetSelectedDepartment() As Department
        Dim meta = GetSelectedMeta()
        If meta Is Nothing OrElse meta.NodeType <> NODE_DEPARTMENT Then Return Nothing
        Return _departments.FirstOrDefault(Function(d) d.id = meta.Id)
    End Function

    Private Sub ShowSelectedDetails()
        Dim job = GetSelectedJob()
        If job IsNot Nothing Then
            Label2.Text = "Mô tả chức vụ:" & Environment.NewLine &
                         $"- Mã: {job.code}" & Environment.NewLine &
                         $"- Tên: {job.name}" & Environment.NewLine &
                         $"- Bộ phận: {job.Department_UI}" & Environment.NewLine &
                         $"- Trạng thái: {job.status_UI}" & Environment.NewLine &
                         $"- Ghi chú: {If(job.note, String.Empty)}"
            UpdateActionButtons()
            Return
        End If

        Dim dept = GetSelectedDepartment()
        If dept IsNot Nothing Then
            Label2.Text = "Mô tả chức vụ:" & Environment.NewLine &
                         $"- Bộ phận: [{dept.code}] {dept.name}" & Environment.NewLine &
                         "- Chọn 1 chức vụ để xem chi tiết."
            UpdateActionButtons()
            Return
        End If

        Label2.Text = "Mô tả chức vụ:" & Environment.NewLine & "- Chọn 1 bộ phận hoặc chức vụ."
        UpdateActionButtons()
    End Sub

    Private Sub UpdateActionButtons()
        If _btnEdit Is Nothing OrElse _btnDelete Is Nothing Then Return
        Dim hasJob = (GetSelectedJob() IsNot Nothing)
        _btnEdit.Enabled = hasJob
        _btnDelete.Enabled = hasJob
    End Sub

    Private Sub tvChucVu_AfterSelect(sender As Object, e As TreeViewEventArgs)
        ShowSelectedDetails()
    End Sub

    Private Sub tvChucVu_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs)
        If e.Node Is Nothing Then Return
        tvChucVu.SelectedNode = e.Node

        Dim job = GetSelectedJob()
        If job Is Nothing Then Return

        OpenEditJob(job)
    End Sub

    Private Sub tvChucVu_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs)
        If e.Node Is Nothing Then Return

        tvChucVu.SelectedNode = e.Node

        If e.Button = MouseButtons.Right Then
            Dim meta = GetSelectedMeta()
            If meta Is Nothing Then Return

            ' Bật/tắt menu theo node.
            _menu.Items(1).Enabled = (meta.NodeType = NODE_JOB) ' Sửa
            _menu.Items(2).Enabled = (meta.NodeType = NODE_JOB) ' Xóa
            _menu.Show(tvChucVu, e.Location)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query = If(tbxSearch.Text, String.Empty).Trim()
        ReloadAndBind(query)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button5.Click
        OpenCreateJob()
    End Sub

    Private Sub Menu_Them(sender As Object, e As EventArgs)
        OpenCreateJob()
    End Sub

    Private Sub Menu_Sua(sender As Object, e As EventArgs)
        Dim job = GetSelectedJob()
        If job Is Nothing Then Return
        OpenEditJob(job)
    End Sub

    Private Sub Menu_Xoa(sender As Object, e As EventArgs)
        Dim job = GetSelectedJob()
        If job Is Nothing Then Return

        If MessageBox.Show($"Xác nhận xóa chức vụ '{job.code} - {job.name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim response = _jobService.Execute(DataIntent.SoftDeleteMany, New List(Of Job) From {job})
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Xóa chức vụ không thành công: " & If(response?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ReloadAndBind(If(tbxSearch.Text, Nothing))
    End Sub

    Private Sub OpenCreateJob()
        Dim job As New Job()

        Using crud As New frmChucVuEdit(job, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim response = _jobService.Execute(DataIntent.Insert, job)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Thêm chức vụ không thành công: " & If(response?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ReloadAndBind(If(tbxSearch.Text, Nothing))
    End Sub

    Private Sub OpenEditJob(job As Job)
        If job Is Nothing Then Return

        Dim clone = Utils.DeepClone(job)

        Using crud As New frmChucVuEdit(clone)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim response = _jobService.Execute(DataIntent.Update, clone)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Cập nhật chức vụ không thành công: " & If(response?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ReloadAndBind(If(tbxSearch.Text, Nothing))
    End Sub

End Class
