Public Class frmLuong

    Private Sub frmLuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
    End Sub

    Private Sub btnXuatBaoCao_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCao.Click
        If DataGridView1 Is Nothing OrElse DataGridView1.Rows.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return
        End If

        BaoCaoXuat.XuatTuDataGridView(DataGridView1, "bang_luong")
    End Sub

End Class
