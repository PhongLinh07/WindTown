Partial Public Class frmCapBac
    Private ReadOnly capBacRepo As New LevelRepository()
    Private bangDuLieu As DataTable
    Private cheDo As String = ""
    Private moTaGoc As String = ""
    Private ReadOnly splitterMacDinh As Integer = 700

    Private Sub frmCapBac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        CapNhatThongTinHeThong()
        CaiDatBang()
        TaiDuLieu()
        CapNhatTrangThaiNut()
        AddHandler splitNoiDung.SizeChanged, AddressOf CapNhatSplitter
        AddHandler Me.Shown, AddressOf XuLyFormShown
        CapNhatSplitter()
    End Sub

    Private Sub CaiDatBang()
        dgvCapBac.ReadOnly = False
        dgvCapBac.AllowUserToAddRows = False
        dgvCapBac.AllowUserToDeleteRows = False
        dgvCapBac.MultiSelect = False
        dgvCapBac.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        UiDinhDang.ApDungDinhDangLuoiChamCong(dgvCapBac)
        ThemCotChon(dgvCapBac)
        AddHandler dgvCapBac.DataBindingComplete, AddressOf DatCotChiDoc
    End Sub

    Private Sub TaiDuLieu()
        bangDuLieu = capBacRepo.LayDanhSach()
        dgvCapBac.DataSource = bangDuLieu
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatChiTietTheoDong() Handles dgvCapBac.SelectionChanged
        If dgvCapBac.CurrentRow Is Nothing OrElse dgvCapBac.CurrentRow.DataBoundItem Is Nothing Then Return
        If cheDo = "Them" Then Return

        Dim row = CType(dgvCapBac.CurrentRow.DataBoundItem, DataRowView).Row
        txtMaCapBac.Text = row.Field(Of String)("MaCapBac")
        txtTenCapBac.Text = row.Field(Of String)("TenCapBac")
        txtThuHang.Text = row.Field(Of Integer)("ThuHang").ToString()
        txtTrangThai.Text = row.Field(Of Integer)("TrangThai").ToString()
        txtGhiChu.Text = row.Field(Of String)("GhiChu")
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        If bangDuLieu Is Nothing Then Return
        Dim tuKhoa = txtTuKhoa.Text.Trim().Replace("'", "''")
        Dim view As New DataView(bangDuLieu)
        If String.IsNullOrWhiteSpace(tuKhoa) Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"MaCapBac LIKE '%{tuKhoa}%' OR TenCapBac LIKE '%{tuKhoa}%'"
        End If
        dgvCapBac.DataSource = view
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        txtTuKhoa.Text = ""
        TaiDuLieu()
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        cheDo = "Them"
        XoaNhap()
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If dgvCapBac.CurrentRow Is Nothing Then Return
        cheDo = "Sua"
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvCapBac.CurrentRow Is Nothing Then Return
        Dim row = CType(dgvCapBac.CurrentRow.DataBoundItem, DataRowView).Row
        Dim id = row.Field(Of Integer)("Id")
        If MessageBox.Show("Xóa cấp bậc đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            capBacRepo.Xoa(id)
            TaiDuLieu()
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If cheDo = "" Then Return

        'Bổ sung kiểm tra dữ liệu bắt buộc trước khi lưu cấp bậc.
        If String.IsNullOrWhiteSpace(txtMaCapBac.Text) Then
            MessageBox.Show("Vui lòng nhập mã cấp bậc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaCapBac.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtTenCapBac.Text) Then
            MessageBox.Show("Vui lòng nhập tên cấp bậc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTenCapBac.Focus()
            Return
        End If

        Dim thuHang As Integer
        If Not Integer.TryParse(txtThuHang.Text, thuHang) Then
            MessageBox.Show("Vui lòng nhập thứ hạng hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtThuHang.Focus()
            Return
        End If

        Dim model As New LevelModel()
        model.MaCapBac = txtMaCapBac.Text.Trim()
        model.TenCapBac = txtTenCapBac.Text.Trim()
        model.ThuHang = thuHang
        model.TrangThai = LaySo(txtTrangThai.Text)
        model.GhiChu = txtGhiChu.Text.Trim()

        If cheDo = "Them" Then
            capBacRepo.Them(model)
        Else
            Dim row = CType(dgvCapBac.CurrentRow.DataBoundItem, DataRowView).Row
            model.Id = row.Field(Of Integer)("Id")
            capBacRepo.CapNhat(model)
        End If

        cheDo = ""
        TaiDuLieu()
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        cheDo = ""
        CapNhatTrangThaiNut()
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatTrangThaiNut()
        Dim dangSua = (cheDo <> "")
        btnLuu.Enabled = dangSua
        btnHuy.Enabled = dangSua
        btnThem.Enabled = Not dangSua
        btnSua.Enabled = Not dangSua
        btnXoa.Enabled = Not dangSua
        pnlChiTiet.Enabled = True
    End Sub

    Private Sub XoaNhap()
        txtMaCapBac.Text = ""
        txtTenCapBac.Text = ""
        txtThuHang.Text = "1"
        txtTrangThai.Text = "1"
        txtGhiChu.Text = ""
    End Sub

    Private Function LaySo(raw As String) As Integer
        Dim giaTri As Integer
        If Integer.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0
    End Function

    Private Sub ThemCotChon(dgv As DataGridView)
        If dgv.Columns.Contains("colChon") Then Return
        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        dgv.Columns.Add(colChon)
        colChon.DisplayIndex = 0
    End Sub

    Private Sub DatCotChiDoc(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        For Each cot As DataGridViewColumn In dgvCapBac.Columns
            cot.ReadOnly = True
        Next
        If dgvCapBac.Columns.Contains("colChon") Then
            dgvCapBac.Columns("colChon").ReadOnly = False
        End If
        'Việt hóa tiêu đề cột sau khi bind dữ liệu.
        UiVietHoa.ApDungVietHoa(dgvCapBac)
    End Sub

    Private Sub CapNhatSplitter()
        If splitNoiDung Is Nothing Then Return
        Dim minTrai = splitNoiDung.Panel1MinSize
        Dim minPhai = splitNoiDung.Panel2MinSize
        Dim gioiHan = splitNoiDung.Width - minPhai
        If gioiHan < minTrai Then Return

        Dim giaTri = splitNoiDung.SplitterDistance
        If giaTri <= 0 Then
            giaTri = splitterMacDinh
        End If
        If giaTri < minTrai Then giaTri = minTrai
        If giaTri > gioiHan Then giaTri = gioiHan
        If splitNoiDung.SplitterDistance <> giaTri Then
            splitNoiDung.SplitterDistance = giaTri
        End If
    End Sub

    Private Sub XuLyFormShown(sender As Object, e As EventArgs)
        BeginInvoke(New Action(Sub() CapNhatSplitter()))
    End Sub

    Private Sub CapNhatThongTinHeThong()
        Dim thongTin = ThongTinHeThongService.LayThongTinHienThi()
        If String.IsNullOrWhiteSpace(thongTin) Then Return
        If String.IsNullOrWhiteSpace(moTaGoc) Then
            moTaGoc = lblMoTa.Text
        End If
        lblMoTa.Text = $"{moTaGoc}{Environment.NewLine}{thongTin}"
    End Sub
End Class
