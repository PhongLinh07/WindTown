Imports System.ComponentModel
Imports System.Linq

Public Class frmNhanSu
    Private ReadOnly _employeeService As New EmployeeService()
    Private ReadOnly _departmentService As New BaseService(Of Department)()
    Private ReadOnly _positionService As New PositionService()
    Private ReadOnly _jobService As New JobService()

    Private phongBan As New List(Of Department)
    Private nhanVien As New List(Of Employee)
    Private jobs As New List(Of Job)
    Private positions As New List(Of Position)
    Private allNhanVienView As New List(Of NhanVien)
    Private boPhanUi As New List(Of BoPhan)
    Private employeeByCode As New Dictionary(Of String, Employee)(StringComparer.OrdinalIgnoreCase)
    Private positionByEmployeeId As New Dictionary(Of Integer, Position)()
    Private jobById As New Dictionary(Of Integer, Job)()

    Private menuXuLyNhanh As ContextMenuStrip
    Private _lblTreeSelection As Label

    Private Const NODE_ROOT As String = "ROOT"
    Private Const NODE_DEPARTMENT As String = "DEPARTMENT"
    Private Const NODE_JOB As String = "JOB"

    Private Class TreeNodeMeta
        Public Property NodeType As String
        Public Property Id As Integer
        Public Property ParentDepartmentId As Integer
    End Class

    Private Class TransferSelection
        Public Property UseJob As Boolean
        Public Property Job As Job
        Public Property DepartmentId As Integer
        Public Property PreferNullJob As Boolean
    End Class

    ' ================= LOAD FORM =================
    Private Sub frmNhanSu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigDataGridView()
        loadControls()
        loadData()
        loadBoPhan()
        tvBoPhan.AllowDrop = True
        UpdateDepartmentActionButtons()
        UpdateSelectedNodeStatus()
        ApplyFilters()

        btnXuLyNhanh.Visible = False
    End Sub

    ' ================= LOAD CONTROLS =================
    Private Sub loadControls()
        menuXuLyNhanh = New ContextMenuStrip()

        menuXuLyNhanh.Items.Add("Cập nhật bộ phận", Nothing, AddressOf XuLy_CapNhatBoPhan)
        menuXuLyNhanh.Items.Add("Cho nghỉ việc", Nothing, AddressOf XuLy_NghiViec)
        menuXuLyNhanh.Items.Add("Xóa nhân viên", Nothing, AddressOf XuLy_XoaNhanVien)

        If _lblTreeSelection Is Nothing Then
            _lblTreeSelection = New Label With {
                .Name = "lblTreeSelection",
                .AutoSize = False,
                .TextAlign = ContentAlignment.MiddleLeft,
                .ForeColor = Color.DimGray,
                .Location = New Point(6, 80),
                .Size = New Size(108, 27),
                .Text = "Đang chọn: (gốc)"
            }
            pnlBoPhan.Controls.Add(_lblTreeSelection)
            _lblTreeSelection.BringToFront()
        End If
    End Sub

    ' ================= LOAD DATA =================
    Private Sub loadData()
        Dim employeeResponse = _employeeService.Execute(DataIntent.GetList)
        If employeeResponse Is Nothing OrElse Not employeeResponse.IsSuccess Then
            nhanVien = New List(Of Employee)()
            employeeByCode = New Dictionary(Of String, Employee)(StringComparer.OrdinalIgnoreCase)
            positionByEmployeeId = New Dictionary(Of Integer, Position)()
            jobById = New Dictionary(Of Integer, Job)()
            MessageBox.Show("Không tải được danh sách nhân viên: " & If(employeeResponse?.Message, "Lỗi không xác định."))
            allNhanVienView = New List(Of NhanVien)()
            boPhanUi = New List(Of BoPhan)()
            Return
        End If

        nhanVien = TryCast(employeeResponse.Data, IEnumerable(Of Employee))?.ToList()
        If nhanVien Is Nothing Then
            nhanVien = New List(Of Employee)()
        End If
        employeeByCode = nhanVien.
            Where(Function(emp) emp IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(emp.code)).
            GroupBy(Function(emp) emp.code, StringComparer.OrdinalIgnoreCase).
            ToDictionary(Function(g) g.Key, Function(g) g.First(), StringComparer.OrdinalIgnoreCase)

        Dim departmentResponse = _departmentService.Execute(DataIntent.GetList)
        phongBan = TryCast(departmentResponse?.Data, IEnumerable(Of Department))?.ToList()
        If phongBan Is Nothing Then
            phongBan = New List(Of Department)()
        End If

        Dim positionResponse = _positionService.Execute(DataIntent.GetList)
        positions = TryCast(positionResponse?.Data, IEnumerable(Of Position))?.ToList()
        If positions Is Nothing Then
            positions = New List(Of Position)()
        End If

        Dim jobResponse = _jobService.Execute(DataIntent.GetList)
        jobs = TryCast(jobResponse?.Data, IEnumerable(Of Job))?.ToList()
        If jobs Is Nothing Then
            jobs = New List(Of Job)()
        End If
        jobById = jobs.
            Where(Function(j) j IsNot Nothing).
            GroupBy(Function(j) j.id).
            ToDictionary(Function(g) Convert.ToInt32(g.Key), Function(g) g.First())

        positionByEmployeeId = positions.
            Where(Function(p) p IsNot Nothing AndAlso p.Contract IsNot Nothing AndAlso p.Contract.Employee IsNot Nothing).
            GroupBy(Function(p) Convert.ToInt32(p.Contract.Employee.id)).
            ToDictionary(
                Function(g) Convert.ToInt32(g.Key),
                Function(g) g.
                    OrderByDescending(Function(p) If(p.status = 1, 1, 0)).
                    ThenByDescending(Function(p) If(p.start_date, DateTime.MinValue)).
                    First())

        allNhanVienView = nhanVien.Select(
            Function(emp)
                Dim pos As Position = Nothing
                Dim deptId As Integer? = Nothing
                Dim jobId As Integer? = Nothing
                Dim deptName As String = "---"
                Dim jobName As String = "---"
                Dim ngayBatDau As String = String.Empty

                If positionByEmployeeId.TryGetValue(emp.id, pos) Then
                    If pos IsNot Nothing AndAlso pos.Job IsNot Nothing Then
                        jobId = pos.Job.id

                        Dim resolvedJob As Job = Nothing
                        If jobById.TryGetValue(pos.Job.id, resolvedJob) Then
                            jobName = If(resolvedJob.name, "---")
                            If resolvedJob.Department IsNot Nothing Then
                                deptId = resolvedJob.Department.id
                                deptName = If(resolvedJob.Department.name, "---")
                            End If
                        Else
                            jobName = If(pos.Job.name, "---")
                            If pos.Job.Department IsNot Nothing Then
                                deptId = pos.Job.Department.id
                                deptName = If(pos.Job.Department.name, "---")
                            End If
                        End If
                    End If

                    Dim startDate As DateTime? = Nothing
                    If pos IsNot Nothing AndAlso pos.start_date.HasValue Then
                        startDate = pos.start_date
                    ElseIf pos IsNot Nothing AndAlso pos.Contract IsNot Nothing AndAlso pos.Contract.start_date.HasValue Then
                        startDate = pos.Contract.start_date
                    End If

                    If startDate.HasValue Then
                        ngayBatDau = startDate.Value.ToString("dd-MM-yyyy")
                    End If
                End If

                Return New NhanVien With {
                    .Id = emp.id,
                    .DepartmentId = deptId,
                    .JobId = jobId,
                    .JobName = jobName,
                    .Code = emp.code,
                    .Name = emp.name,
                    .Email = emp.email,
                    .Status = ConvertStatus(emp.status),
                    .DepartmentName = deptName,
                    .StartDate = ngayBatDau,
                    .Phone = emp.phone,
                    .Gender = ConvertGender(emp.gender)
                }
            End Function).ToList()

        BuildBoPhanUiModel(positionByEmployeeId)
    End Sub

    ' ================= TREEVIEW =================
    Private Sub BuildBoPhanUiModel(positionMap As Dictionary(Of Integer, Position))
        Dim jobsByDepartment = jobs.
            Where(Function(j) j IsNot Nothing AndAlso j.Department IsNot Nothing AndAlso j.status <> -1).
            GroupBy(Function(j) j.Department.id).
            ToDictionary(Function(g) Convert.ToInt32(g.Key), Function(g) g.OrderBy(Function(x) x.code).ToList())

        boPhanUi = phongBan.
            Where(Function(d) d IsNot Nothing AndAlso d.status <> -1).
            OrderBy(Function(d) d.name).
            Select(
                Function(d)
                    Dim jobsInDepartment As List(Of Job) = Nothing
                    If Not jobsByDepartment.TryGetValue(d.id, jobsInDepartment) Then
                        jobsInDepartment = New List(Of Job)()
                    End If

                    Return New BoPhan With {
                        .Id = d.id,
                        .Code = d.code,
                        .Name = d.name,
                        .CongViec = jobsInDepartment.
                            Select(Function(j) New CongViec With {
                                .Id = j.id,
                                .DepartmentId = d.id,
                                .Code = j.code,
                                .Name = j.name,
                                .NhanVien = New List(Of NhanVien)()
                            }).ToList()
                    }
                End Function).ToList()

        Dim jobUiMap As New Dictionary(Of Integer, CongViec)()
        For Each bp In boPhanUi
            If bp.CongViec Is Nothing Then Continue For
            For Each cv In bp.CongViec
                jobUiMap(cv.Id) = cv
            Next
        Next

        For Each nv In allNhanVienView
            Dim pos As Position = Nothing
            If Not positionMap.TryGetValue(nv.Id, pos) Then Continue For
            If pos Is Nothing OrElse pos.Job Is Nothing Then Continue For

            Dim targetJob As CongViec = Nothing
            If jobUiMap.TryGetValue(pos.Job.id, targetJob) Then
                targetJob.NhanVien.Add(nv)
            End If
        Next
    End Sub

    Private Sub loadBoPhan()
        tvBoPhan.Nodes.Clear()

        Dim root = tvBoPhan.Nodes.Add($"{txtTenCongTy.Text} ({allNhanVienView.Count})")
        root.Tag = New TreeNodeMeta With {.NodeType = NODE_ROOT, .Id = 0, .ParentDepartmentId = 0}

        For Each bp In boPhanUi
            Dim departmentCount As Integer = 0
            If bp.CongViec IsNot Nothing Then
                departmentCount = bp.CongViec.Sum(Function(cv) If(cv.NhanVien IsNot Nothing, cv.NhanVien.Count, 0))
            End If

            Dim deptNode = root.Nodes.Add($"{bp.Code} - {bp.Name} ({departmentCount})")
            deptNode.Tag = New TreeNodeMeta With {.NodeType = NODE_DEPARTMENT, .Id = bp.Id, .ParentDepartmentId = bp.Id}

            If bp.CongViec Is Nothing Then Continue For
            For Each cv In bp.CongViec
                Dim jobCount = If(cv.NhanVien IsNot Nothing, cv.NhanVien.Count, 0)
                Dim jobNode = deptNode.Nodes.Add($"{cv.Code} - {cv.Name} ({jobCount})")
                jobNode.Tag = New TreeNodeMeta With {.NodeType = NODE_JOB, .Id = cv.Id, .ParentDepartmentId = bp.Id}
            Next
        Next

        root.Expand()
    End Sub
    ' ================= GRID DATA =================
    Private Sub addDataToGridView()
        dtgvDSNhanVien.DataSource = New BindingList(Of NhanVien)(allNhanVienView.ToList())
    End Sub

    ' ================= CONFIG GRID =================
    Private Sub ConfigDataGridView()
        With dtgvDSNhanVien
            .AutoGenerateColumns = False
            .Columns.Clear()

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False

            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = True
            .ScrollBars = ScrollBars.Both
            .Dock = DockStyle.Fill

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            .Columns.Add(New DataGridViewCheckBoxColumn With {
                .Name = "colChon",
                .HeaderText = "",
                .Width = 40,
                .Frozen = True
            })

            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colMaNV", .HeaderText = "Mã", .DataPropertyName = "Code", .Frozen = True})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTenNV", .HeaderText = "Tên", .DataPropertyName = "Name", .Frozen = True})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colEmail", .HeaderText = "Email", .DataPropertyName = "Email"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colTrangThai", .HeaderText = "Trạng thái", .DataPropertyName = "Status"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colBoPhan", .HeaderText = "Bộ phận", .DataPropertyName = "DepartmentName"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colNgayBatDau", .HeaderText = "Ngày bắt đầu", .DataPropertyName = "StartDate"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colSDT", .HeaderText = "SĐT", .DataPropertyName = "Phone"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "colGioiTinh", .HeaderText = "Giới tính", .DataPropertyName = "Gender"})

            .Columns.Add(New DataGridViewButtonColumn With {
                .Name = "colChiTiet",
                .HeaderText = "Chi tiết",
                .Text = "Xem",
                .UseColumnTextForButtonValue = True
            })

            For Each col As DataGridViewColumn In .Columns
                col.ReadOnly = True
            Next

            .Columns("colChon").ReadOnly = False
        End With
    End Sub

    ' ================= LẤY DANH SÁCH ĐÃ CHỌN =================
    Private Sub btnXuLyNhanh_Click(sender As Object, e As EventArgs) Handles btnXuLyNhanh.Click
        menuXuLyNhanh.Show(btnXuLyNhanh, 0, btnXuLyNhanh.Height)
    End Sub

    Private Function GetSelected() As List(Of NhanVien)
        Dim list As New List(Of NhanVien)

        For Each row As DataGridViewRow In dtgvDSNhanVien.Rows
            Dim isChecked As Boolean = False
            If row.Cells("colChon").Value IsNot Nothing Then
                Boolean.TryParse(row.Cells("colChon").Value.ToString(), isChecked)
            End If

            If isChecked AndAlso TypeOf row.DataBoundItem Is NhanVien Then
                list.Add(DirectCast(row.DataBoundItem, NhanVien))
            End If
        Next

        Return list
    End Function

    ' ================= MENU XỬ LÝ =================
    Private Sub XuLy_CapNhatBoPhan(sender As Object, e As EventArgs)
        Dim selectedEmployees = GetSelectedEmployees()
        If selectedEmployees.Count = 0 Then Return

        Dim transfer = ShowTransferSelectionDialog()
        If transfer Is Nothing Then Return

        ExecuteTransfer(selectedEmployees, transfer, True)
    End Sub

    Private Sub XuLy_NghiViec(sender As Object, e As EventArgs)
        Dim selectedEmployees = GetSelectedEmployees()
        If selectedEmployees.Count = 0 Then Return

        Dim failCount As Integer = 0

        For Each emp In selectedEmployees
            emp.status = 0
            Dim response = _employeeService.Execute(DataIntent.Update, emp)
            If response Is Nothing OrElse Not response.IsSuccess Then
                failCount += 1
            End If
        Next

        If failCount > 0 Then
            MessageBox.Show("Có " & failCount & " nhân viên cập nhật nghỉ việc không thành công.")
        End If

        ReloadDataAndView()
    End Sub

    Private Sub XuLy_XoaNhanVien(sender As Object, e As EventArgs)
        Dim selectedEmployees = GetSelectedEmployees()
        If selectedEmployees.Count = 0 Then Return

        Dim response = _employeeService.Execute(DataIntent.SoftDeleteMany, selectedEmployees)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Xóa nhân viên không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub ClearCheckBox()
        For Each row As DataGridViewRow In dtgvDSNhanVien.Rows
            row.Cells("colChon").Value = False
        Next

        btnXuLyNhanh.Visible = False
    End Sub

    ' ================= CHECKBOX COMMIT =================
    Private Sub dtgvDSNhanVien_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dtgvDSNhanVien.CurrentCellDirtyStateChanged
        If dtgvDSNhanVien.IsCurrentCellDirty Then
            dtgvDSNhanVien.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' ================= HIỆN / ẨN NÚT =================
    Private Sub dtgvDSNhanVien_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtgvDSNhanVien.CellValueChanged
        If e.RowIndex < 0 Then Return

        If e.ColumnIndex = dtgvDSNhanVien.Columns("colChon").Index Then
            Dim anyChecked = dtgvDSNhanVien.Rows.Cast(Of DataGridViewRow)().
                Any(Function(r)
                        Dim value = r.Cells("colChon").Value
                        Return value IsNot Nothing AndAlso Convert.ToBoolean(value)
                    End Function)

            btnXuLyNhanh.Visible = anyChecked
        End If
    End Sub

    Private Sub tvBoPhan_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvBoPhan.AfterSelect
        UpdateDepartmentActionButtons()
        UpdateSelectedNodeStatus()
        ApplyFilters()
    End Sub

    Private Sub dtgvDSNhanVien_MouseDown(sender As Object, e As MouseEventArgs) Handles dtgvDSNhanVien.MouseDown
        If e.Button <> MouseButtons.Left Then Return

        Dim hit = dtgvDSNhanVien.HitTest(e.X, e.Y)
        If hit.RowIndex < 0 Then Return
        If hit.ColumnIndex < 0 Then Return

        Dim clickedCol = dtgvDSNhanVien.Columns(hit.ColumnIndex)
        If clickedCol IsNot Nothing AndAlso (clickedCol.Name = "colChon" OrElse clickedCol.Name = "colChiTiet") Then
            Return
        End If

        Dim draggedEmployees = GetDraggedEmployeesFromGrid()
        If draggedEmployees.Count = 0 Then Return

        dtgvDSNhanVien.DoDragDrop(draggedEmployees, DragDropEffects.Move)
    End Sub

    Private Sub tvBoPhan_DragEnter(sender As Object, e As DragEventArgs) Handles tvBoPhan.DragEnter
        If e.Data.GetDataPresent(GetType(List(Of Employee))) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tvBoPhan_DragOver(sender As Object, e As DragEventArgs) Handles tvBoPhan.DragOver
        If Not e.Data.GetDataPresent(GetType(List(Of Employee))) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        e.Effect = DragDropEffects.Move
        Dim pt = tvBoPhan.PointToClient(New Point(e.X, e.Y))
        Dim hoverNode = tvBoPhan.GetNodeAt(pt)
        If hoverNode IsNot Nothing Then
            tvBoPhan.SelectedNode = hoverNode
        End If
    End Sub

    Private Sub tvBoPhan_DragDrop(sender As Object, e As DragEventArgs) Handles tvBoPhan.DragDrop
        If Not e.Data.GetDataPresent(GetType(List(Of Employee))) Then Return
        Dim draggedEmployees = TryCast(e.Data.GetData(GetType(List(Of Employee))), List(Of Employee))
        If draggedEmployees Is Nothing OrElse draggedEmployees.Count = 0 Then Return

        Dim pt = tvBoPhan.PointToClient(New Point(e.X, e.Y))
        Dim targetNode = tvBoPhan.GetNodeAt(pt)
        If targetNode Is Nothing Then Return

        tvBoPhan.SelectedNode = targetNode
        Dim transfer = BuildTransferFromNode(targetNode)
        If transfer Is Nothing Then
            MessageBox.Show("Vui lòng thả vào Bộ phận hoặc Job hợp lệ.")
            Return
        End If

        ExecuteTransfer(draggedEmployees, transfer, True)
    End Sub

    Private Sub cbbxTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbxTrangThai.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub cbbxGioiTinh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbxGioiTinh.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ApplyFilters()
    End Sub

    Private Sub btnMoiNV_Click(sender As Object, e As EventArgs) Handles btnMoiNV.Click, btnThemNV.Click
        Dim newEmployee As New Employee()
        Dim detailForm As New Employee_CRUD_Frm(newEmployee, True)

        If detailForm.ShowDialog() <> DialogResult.OK Then Return

        Dim response = _employeeService.Execute(DataIntent.Insert, newEmployee)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Thêm nhân viên không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnThemBoPhan.Click
        Dim meta = GetSelectedNodeMeta()

        If meta Is Nothing OrElse meta.NodeType = NODE_ROOT Then
            AddDepartment()
            Return
        End If

        Dim departmentId As Integer = If(meta.NodeType = NODE_DEPARTMENT, meta.Id, meta.ParentDepartmentId)
        AddJob(departmentId)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSuaBoPhan.Click
        Dim meta = GetSelectedNodeMeta()
        If meta Is Nothing OrElse meta.NodeType = NODE_ROOT Then
            MessageBox.Show("Vui lòng chọn bộ phận hoặc công việc cần sửa trong cây.")
            Return
        End If

        If meta.NodeType = NODE_DEPARTMENT Then
            EditDepartment(meta.Id)
        ElseIf meta.NodeType = NODE_JOB Then
            EditJob(meta.Id)
        End If
    End Sub

    Private Sub btnXoaBoPhan_Click(sender As Object, e As EventArgs) Handles btnXoaBoPhan.Click
        Dim meta = GetSelectedNodeMeta()
        If meta Is Nothing OrElse meta.NodeType = NODE_ROOT Then
            MessageBox.Show("Vui lòng chọn bộ phận hoặc công việc cần xóa trong cây.")
            Return
        End If

        If meta.NodeType = NODE_DEPARTMENT Then
            DeleteDepartment(meta.Id)
        ElseIf meta.NodeType = NODE_JOB Then
            DeleteJob(meta.Id)
        End If
    End Sub

    Private Sub dtgvDSNhanVien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgvDSNhanVien.CellContentClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex <> dtgvDSNhanVien.Columns("colChiTiet").Index Then Return

        OpenEmployeeDetailFromRow(e.RowIndex)
    End Sub

    Private Sub dtgvDSNhanVien_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgvDSNhanVien.CellDoubleClick
        If e.RowIndex < 0 Then Return
        OpenEmployeeDetailFromRow(e.RowIndex)
    End Sub

    Private Sub ApplyFilters()
        Dim query = allNhanVienView.AsEnumerable()

        Dim keyword = TextBox1.Text.Trim()
        If keyword <> String.Empty Then
            query = query.Where(
                Function(x)
                    Return ContainsIgnoreCase(x.Code, keyword) OrElse
                           ContainsIgnoreCase(x.Name, keyword) OrElse
                           ContainsIgnoreCase(x.Email, keyword) OrElse
                           ContainsIgnoreCase(x.Phone, keyword)
                End Function)
        End If

        Select Case cbbxTrangThai.Text.Trim()
            Case "Đang làm việc"
                query = query.Where(Function(x) x.Status = "Đang làm việc")
            Case "Đã nghỉ"
                query = query.Where(Function(x) x.Status = "Đã nghỉ")
            Case "Chưa kích hoạt"
                query = query.Where(Function(x) x.Status = "Chưa kích hoạt")
        End Select

        Select Case cbbxGioiTinh.Text.Trim()
            Case "Nam"
                query = query.Where(Function(x) x.Gender = "Nam")
            Case "Nữ"
                query = query.Where(Function(x) x.Gender = "Nữ")
        End Select

        Dim selectedMeta = GetSelectedNodeMeta()
        If selectedMeta IsNot Nothing Then
            If selectedMeta.NodeType = NODE_DEPARTMENT Then
                query = query.Where(Function(x) x.DepartmentId.HasValue AndAlso x.DepartmentId.Value = selectedMeta.Id)
            ElseIf selectedMeta.NodeType = NODE_JOB Then
                query = query.Where(Function(x) x.JobId.HasValue AndAlso x.JobId.Value = selectedMeta.Id)
            End If
        End If

        dtgvDSNhanVien.DataSource = New BindingList(Of NhanVien)(query.ToList())
        btnXuLyNhanh.Visible = False
    End Sub

    Private Function ContainsIgnoreCase(source As String, keyword As String) As Boolean
        If String.IsNullOrEmpty(source) Then Return False
        Return source.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    Private Function ConvertStatus(status As Integer) As String
        Select Case status
            Case 1
                Return "Đang làm việc"
            Case 0
                Return "Đã nghỉ"
            Case Else
                Return "Chưa kích hoạt"
        End Select
    End Function

    Private Function ConvertGender(gender As Integer) As String
        Select Case gender
            Case 1
                Return "Nam"
            Case 0
                Return "Nữ"
            Case Else
                Return "Khác"
        End Select
    End Function

    Private Function GetDraggedEmployeesFromGrid() As List(Of Employee)
        Dim rowIndexes = dtgvDSNhanVien.SelectedCells.Cast(Of DataGridViewCell)().Select(Function(cel) cel.RowIndex).Distinct().ToList()
        Dim selectedCodes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        For Each idx In rowIndexes
            If idx < 0 OrElse idx >= dtgvDSNhanVien.Rows.Count Then Continue For
            Dim row = dtgvDSNhanVien.Rows(idx)
            If TypeOf row.DataBoundItem Is NhanVien Then
                Dim vm = DirectCast(row.DataBoundItem, NhanVien)
                If Not String.IsNullOrWhiteSpace(vm.Code) Then
                    selectedCodes.Add(vm.Code)
                End If
            End If
        Next

        If selectedCodes.Count = 0 Then
            Return GetSelectedEmployees()
        End If

        Dim result As New List(Of Employee)()
        For Each code In selectedCodes
            Dim emp As Employee = Nothing
            If employeeByCode.TryGetValue(code, emp) Then
                result.Add(emp)
            End If
        Next

        Return result
    End Function

    Private Function BuildTransferFromNode(node As TreeNode) As TransferSelection
        If node Is Nothing Then Return Nothing
        Dim meta = TryCast(node.Tag, TreeNodeMeta)
        If meta Is Nothing Then Return Nothing

        If meta.NodeType = NODE_JOB Then
            Dim targetJob As Job = Nothing
            If Not jobById.TryGetValue(meta.Id, targetJob) Then Return Nothing
            If targetJob Is Nothing Then Return Nothing
            Return New TransferSelection With {
                .UseJob = True,
                .Job = targetJob,
                .DepartmentId = meta.ParentDepartmentId,
                .PreferNullJob = False
            }
        End If

        If meta.NodeType = NODE_DEPARTMENT Then
            Return New TransferSelection With {
                .UseJob = False,
                .DepartmentId = meta.Id,
                .PreferNullJob = True
            }
        End If

        Return Nothing
    End Function

    Private Sub ExecuteTransfer(selectedEmployees As List(Of Employee), transfer As TransferSelection, showResult As Boolean)
        If selectedEmployees Is Nothing OrElse selectedEmployees.Count = 0 Then Return
        If transfer Is Nothing Then Return

        Dim transferService As New NhanSuTransferService(_positionService)
        Dim result = transferService.ExecuteTransfer(New NhanSuTransferRequest With {
            .SelectedEmployees = selectedEmployees,
            .Positions = positions,
            .Jobs = jobs,
            .UseJob = transfer.UseJob,
            .TargetJob = transfer.Job,
            .TargetDepartmentId = transfer.DepartmentId,
            .PreferNullJob = transfer.PreferNullJob
        })

        ReloadDataAndView()

        If showResult Then
            MessageBox.Show($"Đã chuyển thành công {result.UpdatedCount} nhân viên. Lỗi: {result.FailCount}.")
        End If
    End Sub

    Private Function GetSelectedEmployees() As List(Of Employee)
        Dim selectedCodes = GetSelected().
            Select(Function(x) x.Code).
            Where(Function(code) Not String.IsNullOrWhiteSpace(code)).
            Distinct(StringComparer.OrdinalIgnoreCase)

        Dim result As New List(Of Employee)()
        For Each code In selectedCodes
            Dim emp As Employee = Nothing
            If employeeByCode.TryGetValue(code, emp) Then
                result.Add(emp)
            End If
        Next

        Return result
    End Function

    Private Function GetSelectedDepartmentFromTree() As Department
        Dim meta = GetSelectedNodeMeta()
        If meta Is Nothing Then Return Nothing

        If meta.NodeType = NODE_DEPARTMENT Then
            Return phongBan.FirstOrDefault(Function(d) d.id = meta.Id)
        End If

        If meta.NodeType = NODE_JOB Then
            Return phongBan.FirstOrDefault(Function(d) d.id = meta.ParentDepartmentId)
        End If

        Return Nothing
    End Function

    Private Function ShowTransferSelectionDialog() As TransferSelection
        Dim dialog As New Form With {
            .Text = "Chuyển bộ phận / công việc",
            .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .MinimizeBox = False,
            .MaximizeBox = False,
            .ClientSize = New Size(460, 210)
        }

        Dim rbDept As New RadioButton With {.Text = "Chuyển theo bộ phận", .Location = New Point(12, 12), .Checked = True, .AutoSize = True}
        Dim rbJob As New RadioButton With {.Text = "Chuyển theo job cụ thể", .Location = New Point(180, 12), .AutoSize = True}

        Dim lblDept As New Label With {.Text = "Bộ phận đích:", .Location = New Point(12, 45), .AutoSize = True}
        Dim cbbDept As New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(12, 66), .Width = 430}

        Dim deptList = phongBan.Where(Function(d) d IsNot Nothing AndAlso d.status <> -1).OrderBy(Function(d) d.name).ToList()
        cbbDept.DataSource = deptList.Select(Function(d) New With {.Display = $"{d.code} - {d.name}", .Value = d.id}).ToList()
        cbbDept.DisplayMember = "Display"
        cbbDept.ValueMember = "Value"

        Dim chkNullJob As New CheckBox With {
            .Text = "Nếu chọn bộ phận: ưu tiên để job trống (job_id = null) nếu hệ thống cho phép",
            .Location = New Point(12, 95),
            .AutoSize = True,
            .Checked = True
        }

        Dim lblJob As New Label With {.Text = "Job đích:", .Location = New Point(12, 125), .AutoSize = True}
        Dim cbbJob As New ComboBox With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(12, 146), .Width = 430, .Enabled = False}

        Dim jobList = jobs.
            Where(Function(j) j IsNot Nothing AndAlso j.status <> -1 AndAlso j.Department IsNot Nothing).
            OrderBy(Function(j) j.Department.name).
            ThenBy(Function(j) j.code).
            ToList()
        cbbJob.DataSource = jobList.Select(Function(j) New With {.Display = $"[{j.Department.name}] {j.code} - {j.name}", .Value = j}).ToList()
        cbbJob.DisplayMember = "Display"
        cbbJob.ValueMember = "Value"

        Dim btnOk As New Button With {.Text = "Đồng ý", .DialogResult = DialogResult.OK, .Location = New Point(286, 176), .Width = 75}
        Dim btnCancel As New Button With {.Text = "Hủy", .DialogResult = DialogResult.Cancel, .Location = New Point(367, 176), .Width = 75}

        AddHandler rbDept.CheckedChanged,
            Sub()
                cbbDept.Enabled = rbDept.Checked
                chkNullJob.Enabled = rbDept.Checked
                cbbJob.Enabled = rbJob.Checked
            End Sub

        AddHandler rbJob.CheckedChanged,
            Sub()
                cbbDept.Enabled = rbDept.Checked
                chkNullJob.Enabled = rbDept.Checked
                cbbJob.Enabled = rbJob.Checked
            End Sub

        dialog.Controls.Add(rbDept)
        dialog.Controls.Add(rbJob)
        dialog.Controls.Add(lblDept)
        dialog.Controls.Add(cbbDept)
        dialog.Controls.Add(chkNullJob)
        dialog.Controls.Add(lblJob)
        dialog.Controls.Add(cbbJob)
        dialog.Controls.Add(btnOk)
        dialog.Controls.Add(btnCancel)
        dialog.AcceptButton = btnOk
        dialog.CancelButton = btnCancel

        If dialog.ShowDialog(Me) <> DialogResult.OK Then
            Return Nothing
        End If

        If rbJob.Checked Then
            If cbbJob.SelectedValue Is Nothing Then Return Nothing
            Dim selectedJob = DirectCast(cbbJob.SelectedValue, Job)
            Return New TransferSelection With {
                .UseJob = True,
                .Job = selectedJob,
                .DepartmentId = selectedJob.Department.id,
                .PreferNullJob = False
            }
        End If

        If cbbDept.SelectedValue Is Nothing Then Return Nothing
        Return New TransferSelection With {
            .UseJob = False,
            .DepartmentId = Convert.ToInt32(cbbDept.SelectedValue),
            .PreferNullJob = chkNullJob.Checked
        }
    End Function

    Private Function GetSelectedNodeMeta() As TreeNodeMeta
        If tvBoPhan.SelectedNode Is Nothing Then Return Nothing

        Dim meta = TryCast(tvBoPhan.SelectedNode.Tag, TreeNodeMeta)
        If meta IsNot Nothing Then Return meta

        Dim deptId As Integer
        If tvBoPhan.SelectedNode.Tag IsNot Nothing AndAlso Integer.TryParse(tvBoPhan.SelectedNode.Tag.ToString(), deptId) Then
            Return New TreeNodeMeta With {.NodeType = NODE_DEPARTMENT, .Id = deptId, .ParentDepartmentId = deptId}
        End If

        If tvBoPhan.SelectedNode.Level = 0 Then
            Return New TreeNodeMeta With {.NodeType = NODE_ROOT, .Id = 0, .ParentDepartmentId = 0}
        End If

        Return Nothing
    End Function

    Private Sub AddDepartment()

        Dim data As New Department()

        Using crud As New Department_CRUD_Frm(data, True)

            If crud.ShowDialog() <> DialogResult.OK Then Return

        End Using

        Try

            Dim response = _departmentService.Execute(DataIntent.Insert, data)

            If response Is Nothing OrElse Not response.IsSuccess Then
                MessageBox.Show("Thêm bộ phận không thành công: " & If(response?.Message, "Lỗi không xác định."))
                Return
            End If

            ReloadDataAndView()

        Catch ex As Exception
            MessageBox.Show("Lỗi hệ thống: " & ex.Message)
        End Try

    End Sub

    'Private Sub AddDepartment()
    '    Dim data As New Department()
    '    Dim crud As New Department_CRUD_Frm(data, True)
    '    If crud.ShowDialog() <> DialogResult.OK Then Return
    '
    '    Dim response = _departmentService.Execute(DataIntent.Insert, data)
    '    If response Is Nothing OrElse Not response.IsSuccess Then
    '        MessageBox.Show("Thêm bộ phận không thành công: " & If(response?.Message, "Lỗi không xác định."))
    '        Return
    '    End If
    '
    '    ReloadDataAndView()
    'End Sub

    Private Sub AddJob(departmentId As Integer)
        Dim dept = phongBan.FirstOrDefault(Function(d) d.id = departmentId)
        If dept Is Nothing Then
            MessageBox.Show("Không tìm thấy bộ phận để tạo công việc.")
            Return
        End If

        Dim data As New Job()
        data.Department = dept

        Dim crud As New Job_CRUD_Frm(data, True)
        If crud.ShowDialog() <> DialogResult.OK Then Return

        Dim response = _jobService.Execute(DataIntent.Insert, data)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Thêm công việc không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub EditDepartment(departmentId As Integer)
        Dim selectedDept = phongBan.FirstOrDefault(Function(d) d.id = departmentId)
        If selectedDept Is Nothing Then
            MessageBox.Show("Không tìm thấy bộ phận cần sửa.")
            Return
        End If

        Dim clone = Utils.DeepClone(selectedDept)
        Dim crud As New Department_CRUD_Frm(clone)
        If crud.ShowDialog() <> DialogResult.OK Then Return

        Dim response = _departmentService.Execute(DataIntent.Update, clone)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Sửa bộ phận không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub EditJob(jobId As Integer)
        Dim selectedJob = jobs.FirstOrDefault(Function(j) j.id = jobId)
        If selectedJob Is Nothing Then
            MessageBox.Show("Không tìm thấy công việc cần sửa.")
            Return
        End If

        Dim clone = Utils.DeepClone(selectedJob)
        Dim crud As New Job_CRUD_Frm(clone)
        If crud.ShowDialog() <> DialogResult.OK Then Return

        Dim response = _jobService.Execute(DataIntent.Update, clone)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Sửa công việc không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub DeleteDepartment(departmentId As Integer)
        Dim selectedDept = phongBan.FirstOrDefault(Function(d) d.id = departmentId)
        If selectedDept Is Nothing Then
            MessageBox.Show("Không tìm thấy bộ phận cần xóa.")
            Return
        End If

        Dim hasJob = jobs.Any(Function(j) j IsNot Nothing AndAlso j.Department IsNot Nothing AndAlso j.Department.id = selectedDept.id AndAlso j.status <> -1)
        If hasJob Then
            MessageBox.Show("Không thể xóa bộ phận vì còn công việc đang hoạt động. Hãy xóa/chuyển job trước.")
            Return
        End If

        If MessageBox.Show("Xác nhận xóa bộ phận '" & selectedDept.name & "'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim response = _departmentService.Execute(DataIntent.SoftDeleteMany, New List(Of Department) From {selectedDept})
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Xóa bộ phận không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub DeleteJob(jobId As Integer)
        Dim selectedJob = jobs.FirstOrDefault(Function(j) j.id = jobId)
        If selectedJob Is Nothing Then
            MessageBox.Show("Không tìm thấy công việc cần xóa.")
            Return
        End If

        Dim hasPosition = positions.Any(Function(p) p IsNot Nothing AndAlso p.Job IsNot Nothing AndAlso p.Job.id = selectedJob.id AndAlso p.status <> -1)
        If hasPosition Then
            MessageBox.Show("Không thể xóa công việc vì đang có vị trí sử dụng job này.")
            Return
        End If

        If MessageBox.Show("Xác nhận xóa công việc '" & selectedJob.code & " - " & selectedJob.name & "'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim response = _jobService.Execute(DataIntent.SoftDeleteMany, New List(Of Job) From {selectedJob})
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Xóa công việc không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub ReloadDataAndView()
        loadData()
        loadBoPhan()
        UpdateDepartmentActionButtons()
        UpdateSelectedNodeStatus()
        ApplyFilters()
        ClearCheckBox()
    End Sub

    Private Sub OpenEmployeeDetailFromRow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dtgvDSNhanVien.Rows.Count Then Return

        Dim row = dtgvDSNhanVien.Rows(rowIndex)
        If row Is Nothing OrElse Not TypeOf row.DataBoundItem Is NhanVien Then Return

        Dim viewModel = DirectCast(row.DataBoundItem, NhanVien)
        If String.IsNullOrWhiteSpace(viewModel.Code) Then
            MessageBox.Show("Không tìm thấy mã nhân viên.")
            Return
        End If

        Dim employee As Employee = Nothing
        If Not employeeByCode.TryGetValue(viewModel.Code, employee) Then
            MessageBox.Show("Không tìm thấy dữ liệu nhân viên trong bộ nhớ hiện tại.")
            Return
        End If

        Dim clone = Utils.DeepClone(employee)
        Dim detailForm As New Employee_CRUD_Frm(clone)
        If detailForm.ShowDialog() <> DialogResult.OK Then Return

        Dim response = _employeeService.Execute(DataIntent.Update, clone)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Cập nhật nhân viên không thành công: " & If(response?.Message, "Lỗi không xác định."))
            Return
        End If

        ReloadDataAndView()
    End Sub

    Private Sub UpdateDepartmentActionButtons()
        Dim meta = GetSelectedNodeMeta()

        If meta Is Nothing OrElse meta.NodeType = NODE_ROOT Then
            btnThemBoPhan.Text = "Thêm BP"
            btnSuaBoPhan.Text = "Sửa BP"
            btnXoaBoPhan.Text = "Xóa BP"
            Return
        End If

        If meta.NodeType = NODE_DEPARTMENT Then
            btnThemBoPhan.Text = "Thêm Job"
            btnSuaBoPhan.Text = "Sửa BP"
            btnXoaBoPhan.Text = "Xóa BP"
            Return
        End If

        If meta.NodeType = NODE_JOB Then
            btnThemBoPhan.Text = "Thêm Job"
            btnSuaBoPhan.Text = "Sửa Job"
            btnXoaBoPhan.Text = "Xóa Job"
        End If
    End Sub

    Private Sub UpdateSelectedNodeStatus()
        If _lblTreeSelection Is Nothing Then Return

        Dim meta = GetSelectedNodeMeta()
        If meta Is Nothing OrElse meta.NodeType = NODE_ROOT Then
            _lblTreeSelection.Text = "Đang chọn: (gốc)"
            Return
        End If

        If meta.NodeType = NODE_DEPARTMENT Then
            Dim dept = phongBan.FirstOrDefault(Function(d) d.id = meta.Id)
            _lblTreeSelection.Text = "Đang chọn: BP - " & If(dept?.name, "(không rõ)")
            Return
        End If

        If meta.NodeType = NODE_JOB Then
            Dim job = jobs.FirstOrDefault(Function(j) j.id = meta.Id)
            _lblTreeSelection.Text = "Đang chọn: Job - " & If(job?.code, "?") & " / " & If(job?.name, "(không rõ)")
        End If
    End Sub

    Private Sub btnNhapXuatNV_Click(sender As Object, e As EventArgs) Handles btnNhapXuatNV.Click

    End Sub
End Class