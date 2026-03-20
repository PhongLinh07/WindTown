Public Class frmSystem

    Private Sub frmSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        TaiDuLieuHeThong()
    End Sub

    Private Sub TaiDuLieuHeThong()
        Try
            Dim cauHinh = HeThongCauHinhService.TaiCauHinh()

            txtMayChu.Text = cauHinh.MayChu
            txtTenCSDL.Text = cauHinh.TenCSDL
            txtTaiKhoan.Text = cauHinh.TaiKhoan
            txtMatKhau.Text = cauHinh.MatKhau

            ChonGiaTriCombo(cboNgonNgu, cauHinh.NgonNgu)
            ChonGiaTriCombo(cboDinhDangNgay, cauHinh.DinhDangNgay)

            lblTrangThai.Text = "Đã tải cấu hình hệ thống."
        Catch ex As Exception
            lblTrangThai.Text = "Không thể tải cấu hình hệ thống."
            MessageBox.Show("Không thể tải cấu hình hệ thống: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKiemTraKetNoi_Click(sender As Object, e As EventArgs) Handles btnKiemTraKetNoi.Click
        Dim thongBao As String = ""
        Dim model = LayDuLieuTuForm()
        Dim thanhCong = HeThongCauHinhService.KiemTraKetNoi(model, thongBao)

        lblTrangThai.Text = thongBao

        If thanhCong Then
            MessageBox.Show(thongBao, "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(thongBao, "Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        Try
            Dim model = LayDuLieuTuForm()
            If Not KiemTraCauHinhBatBuoc(model) Then Return
            HeThongCauHinhService.LuuCauHinh(model)
            lblTrangThai.Text = "Đã lưu cấu hình hệ thống."
            MessageBox.Show("Lưu cấu hình thành công.", "Cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            lblTrangThai.Text = "Không thể lưu cấu hình hệ thống."
            MessageBox.Show("Không thể lưu cấu hình hệ thống: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
        Me.Close()
    End Sub

    Private Sub dgvPhanQuyen_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvPhanQuyen.CurrentCellDirtyStateChanged
        If dgvPhanQuyen.IsCurrentCellDirty Then
            dgvPhanQuyen.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvPhanQuyen_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPhanQuyen.CellValueChanged
        If e.RowIndex < 0 Then Return
        Dim cot = dgvPhanQuyen.Columns(e.ColumnIndex)
        If TypeOf cot Is DataGridViewCheckBoxColumn Then
            lblTrangThai.Text = "Đã thay đổi quyền, vui lòng lưu."
        End If
    End Sub

    Private Function LayDuLieuTuForm() As HeThongCauHinhModel
        Dim model As New HeThongCauHinhModel()
        model.MayChu = txtMayChu.Text.Trim()
        model.TenCSDL = txtTenCSDL.Text.Trim()
        model.TaiKhoan = txtTaiKhoan.Text.Trim()
        model.MatKhau = txtMatKhau.Text
        model.SuDungXacThucWindows = String.IsNullOrWhiteSpace(model.TaiKhoan)
        Dim giaTriNgonNgu = If(cboNgonNgu.SelectedItem, cboNgonNgu.Text)
        Dim giaTriDinhDang = If(cboDinhDangNgay.SelectedItem, cboDinhDangNgay.Text)
        model.NgonNgu = If(giaTriNgonNgu Is Nothing, "", giaTriNgonNgu.ToString())
        model.DinhDangNgay = If(giaTriDinhDang Is Nothing, "", giaTriDinhDang.ToString())
        Return model
    End Function

    'Kiểm tra thông tin bắt buộc trước khi lưu cấu hình.
    Private Function KiemTraCauHinhBatBuoc(model As HeThongCauHinhModel) As Boolean
        If model Is Nothing Then Return False

        If String.IsNullOrWhiteSpace(model.MayChu) Then
            MessageBox.Show("Vui lòng nhập máy chủ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMayChu.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(model.TenCSDL) Then
            MessageBox.Show("Vui lòng nhập tên cơ sở dữ liệu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTenCSDL.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ChonGiaTriCombo(cbo As ComboBox, giaTri As String)
        If cbo Is Nothing Then Return
        If String.IsNullOrWhiteSpace(giaTri) Then Return

        If cbo.Items.Contains(giaTri) Then
            cbo.SelectedItem = giaTri
        Else
            cbo.Items.Add(giaTri)
            cbo.SelectedItem = giaTri
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Thực hiện đăng xuất và điều hướng về form đăng nhập.
        NavigationService.LogoutToLogin(Me)
    End Sub
End Class
