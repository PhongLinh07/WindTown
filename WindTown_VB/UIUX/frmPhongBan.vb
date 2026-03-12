Imports System.Linq

Public Class frmPhongBan

    Private ReadOnly _deptService As New BaseService(Of Department)()
    Private ReadOnly _jobService As New JobService()

    Private _departments As List(Of Department) = New List(Of Department)()
    Private _jobs As List(Of Job) = New List(Of Job)()

    Private Class TreeNodePayload
        Public Property Kind As String
        Public Property Department As Department
        Public Property Job As Job
    End Class

    Private Class ComboItem(Of T)
        Public Property Display As String
        Public Property Value As T
        Public Overrides Function ToString() As String
            Return Display
        End Function
    End Class

    Private Sub frmPhongBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " & bootstrap.Message, "Lỗi kết nối DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DisableUi()
            Return
        End If

        InitFormLayout()
        LoadData()
    End Sub

    Private Sub InitFormLayout()
        Label1.Text = "Phòng ban và công việc"
        Me.Text = "Phòng ban và công việc"
        Label2.Text = "Mô tả phòng ban và công việc:"

        Button2.Visible = False
        Button5.Visible = False

        btnSua.Enabled = False
        btnXoa.Enabled = False
        tvChucVu.HideSelection = False
    End Sub

    Private Sub DisableUi()
        pnlBody.Enabled = False
        Panel1.Enabled = False
        btnThemPhongBan.Enabled = False
        btnSua.Enabled = False
        btnXoa.Enabled = False
        btnSearch.Enabled = False
        tbxSearch.Enabled = False
        tvChucVu.Enabled = False
    End Sub

    Private Sub LoadData(Optional keyword As String = Nothing)
        Dim deptResp = _deptService.Execute(DataIntent.GetList)
        If deptResp.IsSuccess Then
            Dim data = TryCast(deptResp.Data, IEnumerable(Of Department))
            _departments = If(data IsNot Nothing, data.ToList(), New List(Of Department)())
        Else
            _departments = New List(Of Department)()
            MessageBox.Show(deptResp.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim jobResp = _jobService.Execute(DataIntent.GetList)
        If jobResp.IsSuccess Then
            Dim data = TryCast(jobResp.Data, IEnumerable(Of Job))
            _jobs = If(data IsNot Nothing, data.ToList(), New List(Of Job)())
        Else
            _jobs = New List(Of Job)()
            MessageBox.Show(jobResp.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        RenderTree(keyword)
    End Sub

    Private Sub RenderTree(Optional keyword As String = Nothing)
        tvChucVu.BeginUpdate()
        tvChucVu.Nodes.Clear()

        Dim k = If(keyword, String.Empty).Trim().ToLowerInvariant()
        Dim useFilter = Not String.IsNullOrWhiteSpace(k) AndAlso k <> "Tìm kiếm"

        For Each dept In _departments
            Dim deptMatch = Not useFilter OrElse MatchDept(dept, k)
            Dim jobsForDept = _jobs.Where(Function(j) j.Department IsNot Nothing AndAlso j.Department.id = dept.id).ToList()
            Dim jobMatches = If(useFilter, jobsForDept.Where(Function(j) MatchJob(j, k)).ToList(), jobsForDept)

            If deptMatch OrElse jobMatches.Count > 0 Then
                Dim deptNode As New TreeNode($"{dept.code} - {dept.name}") With {
                    .Tag = New TreeNodePayload With {.Kind = "Department", .Department = dept}
                }

                Dim jobsToShow = If(deptMatch, jobsForDept, jobMatches)
                For Each job In jobsToShow
                    Dim jobNode As New TreeNode($"{job.code} - {job.name}") With {
                        .Tag = New TreeNodePayload With {.Kind = "Job", .Job = job, .Department = dept}
                    }
                    deptNode.Nodes.Add(jobNode)
                Next

                tvChucVu.Nodes.Add(deptNode)
            End If
        Next

        tvChucVu.ExpandAll()
        tvChucVu.EndUpdate()
    End Sub

    Private Function MatchDept(dept As Department, keyword As String) As Boolean
        Dim hay = ($"{dept.code} {dept.name} {dept.note}").ToLowerInvariant()
        Return hay.Contains(keyword)
    End Function

    Private Function MatchJob(job As Job, keyword As String) As Boolean
        Dim hay = ($"{job.code} {job.name} {job.note} {job.Department_UI}").ToLowerInvariant()
        Return hay.Contains(keyword)
    End Function

    Private Sub UpdateDetail(payload As TreeNodePayload)
        If payload Is Nothing Then
            Label2.Text = "Mô tả phòng ban:"
            btnSua.Enabled = False
            btnXoa.Enabled = False
            Return
        End If

        btnSua.Enabled = True
        btnXoa.Enabled = True

        If payload.Kind = "Department" AndAlso payload.Department IsNot Nothing Then
            Dim dept = payload.Department
            Dim statusText = If(Department.status_Dict.ContainsKey(dept.status), Department.status_Dict(dept.status), "---")
            Label2.Text = "Mô tả phòng ban:" & vbCrLf &
                          $"Mã: {dept.code}" & vbCrLf &
                          $"Tên: {dept.name}" & vbCrLf &
                          $"Trạng thái: {statusText}" & vbCrLf &
                          $"Ghi chú: {dept.note}"
            Return
        End If

        If payload.Kind = "Job" AndAlso payload.Job IsNot Nothing Then
            Dim job = payload.Job
            Dim statusText = If(Job.status_Dict.ContainsKey(job.status), Job.status_Dict(job.status), "---")
            Label2.Text = "Mô tả phòng ban:" & vbCrLf &
                          $"Công việc: {job.code} - {job.name}" & vbCrLf &
                          $"Phòng ban: {job.Department_UI}" & vbCrLf &
                          $"Trạng thái: {statusText}" & vbCrLf &
                          $"Ghi chú: {job.note}"
        End If
    End Sub

    Private Function GetPayload() As TreeNodePayload
        Return TryCast(tvChucVu.SelectedNode?.Tag, TreeNodePayload)
    End Function

    Private Sub btnThemPhongBan_Click(sender As Object, e As EventArgs) Handles btnThemPhongBan.Click
        Dim payload = GetPayload()
        Dim dept = If(payload?.Kind = "Department", payload.Department, If(payload?.Job IsNot Nothing, payload.Job.Department, Nothing))

        If dept Is Nothing Then
            CreateDepartment()
        Else
            CreateJob(dept)
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim payload = GetPayload()
        If payload Is Nothing Then
            MessageBox.Show("Vui lòng chọn phòng ban hoặc công việc cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If payload.Kind = "Department" Then
            EditDepartment(payload.Department)
        ElseIf payload.Kind = "Job" Then
            EditJob(payload.Job)
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim payload = GetPayload()
        If payload Is Nothing Then
            MessageBox.Show("Vui lòng chọn phòng ban hoặc công việc cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If payload.Kind = "Department" Then
            DeleteDepartment(payload.Department)
        ElseIf payload.Kind = "Job" Then
            DeleteJob(payload.Job)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        RenderTree(tbxSearch.Text)
    End Sub

    Private Sub tbxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            RenderTree(tbxSearch.Text)
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

    Private Sub tvChucVu_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvChucVu.AfterSelect
        UpdateDetail(GetPayload())
    End Sub

    Private Sub CreateDepartment()
        Dim data As New Department()
        If Not ShowDepartmentDialog(data, True) Then Return

        Dim result = _deptService.Execute(DataIntent.Insert, data)
        If result.IsSuccess Then
            MessageBox.Show("Thêm phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EditDepartment(dept As Department)
        If dept Is Nothing Then Return
        Dim data = Utils.DeepClone(dept)
        If Not ShowDepartmentDialog(data, False) Then Return

        Dim result = _deptService.Execute(DataIntent.Update, data)
        If result.IsSuccess Then
            MessageBox.Show("Cập nhật phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DeleteDepartment(dept As Department)
        If dept Is Nothing Then Return
        If MessageBox.Show($"Xác nhận xóa phòng ban '{dept.name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim result = _deptService.Execute(DataIntent.SoftDeleteMany, New List(Of Department) From {dept})
        If result.IsSuccess Then
            MessageBox.Show("Xóa phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub CreateJob(dept As Department)
        Dim data As New Job()
        data.Department = dept
        If Not ShowJobDialog(data, True) Then Return

        Dim result = _jobService.Execute(DataIntent.Insert, data)
        If result.IsSuccess Then
            MessageBox.Show("Thêm công việc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub EditJob(job As Job)
        If job Is Nothing Then Return
        Dim data = Utils.DeepClone(job)
        If Not ShowJobDialog(data, False) Then Return

        Dim result = _jobService.Execute(DataIntent.Update, data)
        If result.IsSuccess Then
            MessageBox.Show("Cập nhật công việc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DeleteJob(job As Job)
        If job Is Nothing Then Return
        If MessageBox.Show($"Xác nhận xóa công việc '{job.name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim result = _jobService.Execute(DataIntent.SoftDeleteMany, New List(Of Job) From {job})
        If result.IsSuccess Then
            MessageBox.Show("Xóa công việc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData(tbxSearch.Text)
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ShowDepartmentDialog(data As Department, isCreate As Boolean) As Boolean
        Dim formTitle = If(isCreate, "Thêm phòng ban", "Sửa phòng ban")
        Using frm As New Form()
            frm.Text = formTitle
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(420, 260)

            Dim lblCode As New Label() With {.Text = "Mã phòng ban", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(160, 18), .Width = 220, .Text = data.code}

            Dim lblName As New Label() With {.Text = "Tên phòng ban", .Location = New Point(20, 60), .AutoSize = True}
            Dim txtName As New TextBox() With {.Location = New Point(160, 58), .Width = 220, .Text = data.name}

            Dim lblStatus As New Label() With {.Text = "Trạng thái", .Location = New Point(20, 100), .AutoSize = True}
            Dim cboStatus As New ComboBox() With {.Location = New Point(160, 98), .Width = 220, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboStatus.DataSource = New BindingSource(Department.status_Dict, Nothing)
            cboStatus.DisplayMember = "Value"
            cboStatus.ValueMember = "Key"
            cboStatus.SelectedValue = data.status

            Dim lblNote As New Label() With {.Text = "Ghi chú", .Location = New Point(20, 140), .AutoSize = True}
            Dim txtNote As New TextBox() With {.Location = New Point(160, 138), .Width = 220, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "Lưu", .Location = New Point(220, 200), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Hủy", .Location = New Point(305, 200), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblName, txtName, lblStatus, cboStatus, lblNote, txtNote, btnOk, btnCancel})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) OrElse String.IsNullOrWhiteSpace(txtName.Text) Then
                MessageBox.Show("Vui lòng nhập mã và tên phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = txtCode.Text.Trim()
            data.name = txtName.Text.Trim()
            data.note = txtNote.Text.Trim()
            data.status = CInt(cboStatus.SelectedValue)
            Return True
        End Using
    End Function

    Private Function ShowJobDialog(data As Job, isCreate As Boolean) As Boolean
        Dim formTitle = If(isCreate, "Thêm công việc", "Sửa công việc")
        Using frm As New Form()
            frm.Text = formTitle
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(420, 300)

            Dim lblCode As New Label() With {.Text = "Mã công việc", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(160, 18), .Width = 220, .Text = data.code}

            Dim lblName As New Label() With {.Text = "Tên công việc", .Location = New Point(20, 60), .AutoSize = True}
            Dim txtName As New TextBox() With {.Location = New Point(160, 58), .Width = 220, .Text = data.name}

            Dim lblDept As New Label() With {.Text = "Phòng ban", .Location = New Point(20, 100), .AutoSize = True}
            Dim cboDept As New ComboBox() With {.Location = New Point(160, 98), .Width = 220, .DropDownStyle = ComboBoxStyle.DropDownList}
            Dim deptItems = _departments.Select(Function(d) New ComboItem(Of Department) With {.Display = $"{d.code} - {d.name}", .Value = d}).ToList()
            cboDept.DataSource = deptItems
            cboDept.DisplayMember = "Display"
            cboDept.ValueMember = "Value"
            If data.Department IsNot Nothing Then
                cboDept.SelectedItem = deptItems.FirstOrDefault(Function(x) x.Value.id = data.Department.id)
            End If

            Dim lblStatus As New Label() With {.Text = "Trạng thái", .Location = New Point(20, 140), .AutoSize = True}
            Dim cboStatus As New ComboBox() With {.Location = New Point(160, 138), .Width = 220, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboStatus.DataSource = New BindingSource(Job.status_Dict, Nothing)
            cboStatus.DisplayMember = "Value"
            cboStatus.ValueMember = "Key"
            cboStatus.SelectedValue = data.status

            Dim lblNote As New Label() With {.Text = "Ghi chú", .Location = New Point(20, 180), .AutoSize = True}
            Dim txtNote As New TextBox() With {.Location = New Point(160, 178), .Width = 220, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "Lưu", .Location = New Point(220, 230), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button() With {.Text = "Hủy", .Location = New Point(305, 230), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblName, txtName, lblDept, cboDept, lblStatus, cboStatus, lblNote, txtNote, btnOk, btnCancel})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnCancel

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) OrElse String.IsNullOrWhiteSpace(txtName.Text) Then
                MessageBox.Show("Vui lòng nhập mã và tên công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim selected = TryCast(cboDept.SelectedItem, ComboItem(Of Department))
            Dim deptValue = If(selected IsNot Nothing, selected.Value, Nothing)
            If deptValue Is Nothing Then
                MessageBox.Show("Vui lòng chọn phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = txtCode.Text.Trim()
            data.name = txtName.Text.Trim()
            data.note = txtNote.Text.Trim()
            data.status = CInt(cboStatus.SelectedValue)
            data.Department = deptValue
            Return True
        End Using
    End Function

End Class
