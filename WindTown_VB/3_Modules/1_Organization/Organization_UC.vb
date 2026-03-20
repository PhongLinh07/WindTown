Public Class Organization_UC

    Public Sub New()
        InitializeComponent()
        LoadOrganizationTree()
    End Sub

    Private Sub LoadOrganizationTree()
        ' 1. Lấy dữ liệu từ Service
        Dim deptSV = AppServices.Instance.DepartmentSV
        Dim jobSV = AppServices.Instance.JobSV

        ' Sửa lại 2 dòng này:
        Dim listDept As List(Of Department) = DirectCast(deptSV.Execute(DataIntent.GetList).Data, List(Of Department))
        Dim listJob As List(Of Job) = DirectCast(jobSV.Execute(DataIntent.GetList).Data, List(Of Job))

        tree_org.Nodes.Clear()

        ' Tạo Node gốc của Tổng công ty
        Dim rootNode As New TreeNode("COMPANY WIND TOWN")
        rootNode.ImageIndex = 0 ' Icon công ty
        tree_org.Nodes.Add(rootNode)

        ' 2. Duyệt danh sách Phòng ban
        For Each dept In listDept
            Dim deptNode As New TreeNode(dept.name)
            deptNode.Tag = dept ' Lưu đối tượng vào Tag để dùng sau này
            deptNode.ForeColor = Color.Blue ' Phân biệt bằng màu sắc

            ' 3. Lọc và thêm các Job thuộc phòng ban này
            ' Sử dụng LINQ để lọc cho nhanh
            Dim jobsInDept = listJob.Where(Function(j) j.department_id = dept.id).ToList()

            For Each j In jobsInDept
                Dim jobNode As New TreeNode(j.name)
                jobNode.Tag = j ' Lưu đối tượng Job vào Tag
                deptNode.Nodes.Add(jobNode)
            Next

            rootNode.Nodes.Add(deptNode)
        Next

        tree_org.ExpandAll() ' Mở rộng tất cả các nhánh
    End Sub
End Class
