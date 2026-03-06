Public Class frmDashboard
    Private Sub load_form(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Tạo cột cho Top Checkin Sớm
        lvTopCheckinSom.View = View.Details
        lvTopCheckinSom.Columns.Add("Tên nhân viên")
        lvTopCheckinSom.Columns.Add("Thời gian Checkin")

        ' Tạo cột cho Top Checkin Muộn
        lvTopCheckinMuon.View = View.Details
        lvTopCheckinMuon.Columns.Add("Tên nhân viên")
        lvTopCheckinMuon.Columns.Add("Thời gian Checkin")

        ' Thêm dữ liệu mẫu
        Dim item1 As New ListViewItem("Nguyễn Văn A")
        item1.SubItems.Add(DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"))
        lvTopCheckinSom.Items.Add(item1)

        Dim item2 As New ListViewItem("Trần Thị B")
        item2.SubItems.Add(DateTime.Now.AddMinutes(-15).ToString("HH:mm:ss dd/MM/yyyy"))
        lvTopCheckinSom.Items.Add(item2)

        Dim item3 As New ListViewItem("Lê Văn C")
        item3.SubItems.Add(DateTime.Now.AddMinutes(30).ToString("HH:mm:ss dd/MM/yyyy"))
        lvTopCheckinMuon.Items.Add(item3)

        Dim item4 As New ListViewItem("Phạm Thị D")
        item4.SubItems.Add(DateTime.Now.AddMinutes(45).ToString("HH:mm:ss dd/MM/yyyy"))
        lvTopCheckinMuon.Items.Add(item4)

        ' Căn đều cột
        AdjustColumnWidth()
    End Sub

    Private Sub AdjustColumnWidth()
        ' Tự động căn đều cột dựa trên tổng chiều rộng của ListView
        Dim totalWidth As Integer = lvTopCheckinSom.ClientSize.Width
        Dim colCount As Integer = lvTopCheckinSom.Columns.Count

        Dim totalWidthMuon As Integer = lvTopCheckinMuon.ClientSize.Width
        Dim colCountMuon As Integer = lvTopCheckinMuon.Columns.Count

        ' Chia đều độ rộng cho các cột
        For i As Integer = 0 To colCount - 1
            lvTopCheckinSom.Columns(i).Width = totalWidth \ colCount
        Next

        For i As Integer = 0 To colCountMuon - 1
            lvTopCheckinMuon.Columns(i).Width = totalWidthMuon \ colCountMuon
        Next
    End Sub

    ' Nếu muốn tự động căn lại khi resize form:
    Private Sub frmDashboard_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AdjustColumnWidth()
    End Sub

    Private Sub SidebarMenu1_Load(sender As Object, e As EventArgs) Handles SidebarMenu1.Load

    End Sub
End Class