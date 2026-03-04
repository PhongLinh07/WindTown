Public Class frmNhanSu

    Dim phongBan As List(Of Department) = New List(Of Department)
    Dim jobList As List(Of Job) = New List(Of Job)
    Dim nhanVien As List(Of Employee) = New List(Of Employee)

    Private Sub frmNhanSu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm()
    End Sub
    Private Sub loadForm()
        loadData()
        loadBoPhan()
        SetupGrid()
    End Sub
    ' ================= LOAD DATA =================
    Private Sub loadData()

        Dim departmentSV = New BaseService(Of Department)().Execute(DataIntent.GetList)
        Dim jobSV = New JobService().Execute(DataIntent.GetList)
        Dim employeeSV = New EmployeeService().Execute(DataIntent.GetList)

        If departmentSV.IsSuccess Then
            phongBan = CType(departmentSV.Data, List(Of Department))
        End If

        If jobSV.IsSuccess Then
            jobList = CType(jobSV.Data, List(Of Job))
        End If

        If employeeSV.IsSuccess Then
            nhanVien = CType(employeeSV.Data, List(Of Employee))
        End If

    End Sub

    ' ================= TREEVIEW =================
    Private Sub loadBoPhan()

        tvBoPhan.Nodes.Clear()

        If phongBan Is Nothing OrElse phongBan.Count = 0 Then Exit Sub

        For Each pb In phongBan

            ' Node Department
            Dim parentNode As New TreeNode()
            parentNode.Text = pb.name
            parentNode.Tag = "D_" & pb.id     ' D = Department
            parentNode.ForeColor = Color.Blue

            ' Lấy Job thuộc Department
            Dim dsJob = jobList.Where(Function(j) j.department_id = pb.id).ToList()

            For Each jb In dsJob
                Dim childNode As New TreeNode()
                childNode.Text = jb.name
                childNode.Tag = "J_" & jb.id   ' J = Job
                childNode.ForeColor = Color.Black

                parentNode.Nodes.Add(childNode)
            Next

            tvBoPhan.Nodes.Add(parentNode)
        Next

        tvBoPhan.ExpandAll()

    End Sub

    ' ================= CLICK TREEVIEW =================
    Private Sub tvBoPhan_AfterSelect(sender As Object, e As TreeViewEventArgs) _
        Handles tvBoPhan.AfterSelect

        If e.Node Is Nothing OrElse e.Node.Tag Is Nothing Then Exit Sub

        Dim tagValue As String = e.Node.Tag.ToString()

        ' Click Department
        If tagValue.StartsWith("D_") Then
            Dim departmentId As Integer = CInt(tagValue.Replace("D_", ""))
            LoadNhanVienTheoDepartment(departmentId)
        End If

        ' Click Job
        If tagValue.StartsWith("J_") Then
            Dim jobId As Integer = CInt(tagValue.Replace("J_", ""))
            LoadNhanVienTheoJob(jobId)
        End If

    End Sub

    ' ================= FILTER THEO DEPARTMENT =================
    Private Sub LoadNhanVienTheoDepartment(departmentId As Integer)

        Dim ds = nhanVien.
            Where(Function(x) x.id = departmentId).
            ToList()

        AddDataToGridView(ds)

    End Sub

    ' ================= FILTER THEO JOB =================
    Private Sub LoadNhanVienTheoJob(jobId As Integer)

        Dim ds = nhanVien.
            Where(Function(x) x.id = jobId).
            ToList()

        AddDataToGridView(ds)

    End Sub

    ' ================= GRIDVIEW =================
    Private Sub SetupGrid()

        dtgvDSNhanVien.AutoGenerateColumns = False

        '   dtgvDSNhanVien.Columns("colTenNV").DataPropertyName = "name"
        '   dtgvDSNhanVien.Columns("colMaNV").DataPropertyName = "code"
        '   dtgvDSNhanVien.Columns("colEmail").DataPropertyName = "email"
        '   dtgvDSNhanVien.Columns("colTrangThai").DataPropertyName = "status"
        '   dtgvDSNhanVien.Columns("colBoPhan").DataPropertyName = "department_id"
        '   dtgvDSNhanVien.Columns("colNgayBatDau").DataPropertyName = "start_date"
        '   dtgvDSNhanVien.Columns("colSDT").DataPropertyName = "phone"
        '   dtgvDSNhanVien.Columns("colGioiTinh").DataPropertyName = "gender"

    End Sub
    Private Sub AddDataToGridView(ds As List(Of Employee))
        dtgvDSNhanVien.DataSource = Nothing
        dtgvDSNhanVien.DataSource = ds
    End Sub

End Class