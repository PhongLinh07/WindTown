
Public Class frmNhanSu

    Private Sub frmNhanSu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBoPhan()
    End Sub

    Dim PhongBan As List(Of String) = New List(Of String) From {
        "Phát triển phần mềm",
        "Hạ tầng mạng",
        "Kinh doanh",
        "Marketing",
        "Tài chính",
        "Hành chính nhân sự"
    }
    Dim NhanVien As List(Of String) = New List(Of String) From {
        "Nguyễn Văn A",
        "Trần Thị B",
        "Lê Văn C",
        "Phạm Thị D",
        "Hoàng Văn E"
    }
    Private Sub loadBoPhan()
        ' Khởi tạo TreeView
        tvBoPhan.Nodes.Clear()

        ' Thêm bộ phận chính
        Dim itNode As TreeNode = tvBoPhan.Nodes.Add("ITWord")

        ' Thêm bộ phận con cho ITWord
        itNode.Nodes.Add("Phát triển phần mềm")
        itNode.Nodes.Add("Hạ tầng mạng")

        ' Thêm các bộ phận khác
        tvBoPhan.Nodes.Add("Kinh doanh")
        tvBoPhan.Nodes.Add("Marketing")
        tvBoPhan.Nodes.Add("Tài chính")
        tvBoPhan.Nodes.Add("Hành chính nhân sự")

        ' Mở rộng tất cả
        tvBoPhan.ExpandAll()
    End Sub

    Private Sub AddDataToGridView()

        ' Tạo DataTable để lưu trữ dữ liệu nhân sự
        Dim dt As New DataTable()
        dt.Columns.Add("Mã NV")
        dt.Columns.Add("Họ tên")
        dt.Columns.Add("Bộ phận")
        dt.Columns.Add("Chức vụ")
        ' Thêm dữ liệu mẫu vào DataTable
        dt.Rows.Add("NV001", "Nguyễn Văn A", "Phát triển phần mềm", "Lập trình viên")
        dt.Rows.Add("NV002", "Trần Thị B", "Hạ tầng mạng", "Kỹ sư mạng")
        dt.Rows.Add("NV003", "Lê Văn C", "Kinh doanh", "Nhân viên kinh doanh")
        dt.Rows.Add("NV004", "Phạm Thị D", "Marketing", "Chuyên viên marketing")
        dt.Rows.Add("NV005", "Hoàng Văn E", "Tài chính", "Kế toán")
        ' Gán DataTable cho DataGridView
        dtgvDSNhanVien.DataSource = dt
    End Sub
End Class