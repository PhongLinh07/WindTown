Imports System.Data.SqlClient

Public Class frmSystem

    Private Sub frmSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        TaiDuLieuHeThong()
    End Sub

    Private Sub TaiDuLieuHeThong()
        Try
            Dim conn = DatabaseConfig.Database.GetConnection()
            Dim builder As New SqlConnectionStringBuilder(conn.ConnectionString)

            txtMayChu.Text = builder.DataSource
            txtTenCSDL.Text = builder.InitialCatalog

            If builder.IntegratedSecurity Then
                txtTaiKhoan.Text = ""
                txtMatKhau.Text = ""
            Else
                txtTaiKhoan.Text = builder.UserID
                txtMatKhau.Text = builder.Password
            End If

            If cboNgonNgu.Items.Count > 0 Then
                cboNgonNgu.SelectedItem = "Tiếng Việt"
            End If
            If cboDinhDangNgay.Items.Count > 0 Then
                cboDinhDangNgay.SelectedItem = "dd/MM/yyyy"
            End If

            lblTrangThai.Text = "Đã tải cấu hình hệ thống."
        Catch ex As Exception
            lblTrangThai.Text = "Không thể tải cấu hình hệ thống."
            MessageBox.Show("Không thể tải cấu hình hệ thống: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
