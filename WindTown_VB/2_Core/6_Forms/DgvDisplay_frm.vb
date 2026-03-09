Public Class DgvDisplay_frm
    ' Biến cục bộ để lưu trữ tham chiếu tới DataGridView bên ngoài
    Private _targetDgv As DataGridView

    ' Hàm khởi tạo (Constructor) nhận vào 1 DataGridView
    Public Sub New(ByVal dgv As DataGridView)
        ' Lệnh này là bắt buộc trong WinForms
        InitializeComponent()

        Me.Text = "Ẩn/Hiện cột"
        ' Lưu tham chiếu dgv vào biến cục bộ
        _targetDgv = dgv
    End Sub

    ' Khi Form load, nạp danh sách cột vào CheckedListBox
    Private Sub DgvDisplay_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _targetDgv Is Nothing Then Exit Sub

        clbColumns.Items.Clear()

        ' Duyệt qua danh sách cột của DGV
        For Each col As DataGridViewColumn In _targetDgv.Columns
            ' Thêm HeaderText vào danh sách, trạng thái check = trạng thái hiển thị của cột
            clbColumns.Items.Add(col.HeaderText, col.Visible)
        Next
    End Sub

    ' Xử lý khi người dùng check/uncheck trên danh sách
    Private Sub clbColumns_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbColumns.ItemCheck
        ' Lấy tên tiêu đề cột tại dòng vừa nhấn
        Dim colName As String = clbColumns.Items(e.Index).ToString()

        ' Tìm cột tương ứng trong DataGridView và ẩn/hiện
        For Each col As DataGridViewColumn In _targetDgv.Columns
            If col.HeaderText = colName Then
                ' Cập nhật trạng thái hiển thị dựa trên giá trị check mới
                col.Visible = (e.NewValue = CheckState.Checked)
                Exit For
            End If
        Next
    End Sub
End Class