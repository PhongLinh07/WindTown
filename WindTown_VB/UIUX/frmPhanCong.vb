Imports System.Globalization

Public Class frmPhanCong
    Private ReadOnly phanCongRepo As New PhanCongRepository()
    Private bangDuLieu As DataTable
    Private cheDo As String = ""
    Private moTaGoc As String = ""
    Private ReadOnly splitterMacDinh As Integer = 700

    Private Sub frmPhanCong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        dgvPhanCong.ReadOnly = False
        dgvPhanCong.AllowUserToAddRows = False
        dgvPhanCong.AllowUserToDeleteRows = False
        dgvPhanCong.MultiSelect = False
        dgvPhanCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        UiDinhDang.ApDungDinhDangLuoiChamCong(dgvPhanCong)
        ThemCotChon(dgvPhanCong)
        AddHandler dgvPhanCong.DataBindingComplete, AddressOf DatCotChiDoc
    End Sub

    Private Sub TaiDuLieu()
        bangDuLieu = phanCongRepo.LayDanhSach()
        dgvPhanCong.DataSource = bangDuLieu
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatChiTietTheoDong() Handles dgvPhanCong.SelectionChanged
        If dgvPhanCong.CurrentRow Is Nothing OrElse dgvPhanCong.CurrentRow.DataBoundItem Is Nothing Then Return
        If cheDo = "Thêm" Then Return

        Dim row = CType(dgvPhanCong.CurrentRow.DataBoundItem, DataRowView).Row
        txtMaPhanCong.Text = row.Field(Of String)("MaPhanCong")
        txtProjectId.Text = row.Field(Of Integer)("ProjectId").ToString()
        txtPositionId.Text = row.Field(Of Integer)("PositionId").ToString()
        txtVaiTro.Text = row.Field(Of String)("Vaitro")
        txtTrangThai.Text = row.Field(Of Integer)("TrangThai").ToString()
        txtGhiChu.Text = row.Field(Of String)("GhiChu")

        GanNgay(dtpNgayBatDau, row.Field(Of String)("NgayBatDau"))
        GanNgay(dtpNgayKetThuc, row.Field(Of String)("NgayKetThuc"))
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        If bangDuLieu Is Nothing Then Return
        Dim tuKhoa = txtTuKhoa.Text.Trim().Replace("'", "''")
        Dim view As New DataView(bangDuLieu)
        If String.IsNullOrWhiteSpace(tuKhoa) Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"MaPhanCong LIKE '%{tuKhoa}%'"
        End If
        dgvPhanCong.DataSource = view
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        txtTuKhoa.Text = ""
        TaiDuLieu()
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        cheDo = "Thêm"
        XoaNhap()
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If dgvPhanCong.CurrentRow Is Nothing Then Return
        cheDo = "Sửa"
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvPhanCong.CurrentRow Is Nothing Then Return
        Dim row = CType(dgvPhanCong.CurrentRow.DataBoundItem, DataRowView).Row
        Dim id = row.Field(Of Integer)("Id")
        If MessageBox.Show("Xóa phân công đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            phanCongRepo.Xoa(id)
            TaiDuLieu()
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If cheDo = "" Then Return

        If String.IsNullOrWhiteSpace(txtMaPhanCong.Text) Then
            MessageBox.Show("Vui lòng nhập mã phân công.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaPhanCong.Focus()
            Return
        End If

        Dim projectId = LaySo(txtProjectId.Text)
        If projectId <= 0 Then
            MessageBox.Show("Vui lòng nhập dự án hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProjectId.Focus()
            Return
        End If

        Dim positionId = LaySo(txtPositionId.Text)
        If positionId <= 0 Then
            MessageBox.Show("Vui lòng nhập chức vụ hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPositionId.Focus()
            Return
        End If

        If dtpNgayBatDau.Value.Date > dtpNgayKetThuc.Value.Date Then
            MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpNgayBatDau.Focus()
            Return
        End If

        Dim model As New PhanCongModel()
        model.MaPhanCong = txtMaPhanCong.Text.Trim()
        model.ProjectId = projectId
        model.PositionId = positionId
        model.VaiTro = txtVaiTro.Text.Trim()
        model.NgayBatDau = dtpNgayBatDau.Value.ToString("yyyy-MM-dd")
        model.NgayKetThuc = dtpNgayKetThuc.Value.ToString("yyyy-MM-dd")
        model.TrangThai = LaySo(txtTrangThai.Text)
        model.GhiChu = txtGhiChu.Text.Trim()

        If cheDo = "Thêm" Then
            phanCongRepo.Them(model)
        Else
            Dim row = CType(dgvPhanCong.CurrentRow.DataBoundItem, DataRowView).Row
            model.Id = row.Field(Of Integer)("Id")
            phanCongRepo.CapNhat(model)
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
        txtMaPhanCong.Text = ""
        txtProjectId.Text = ""
        txtPositionId.Text = ""
        txtVaiTro.Text = ""
        txtTrangThai.Text = "1"
        txtGhiChu.Text = ""
        dtpNgayBatDau.Value = DateTime.Today
        dtpNgayKetThuc.Value = DateTime.Today
    End Sub

    Private Function LaySo(raw As String) As Integer
        Dim giaTri As Integer
        If Integer.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0
    End Function

    Private Sub GanNgay(dtp As DateTimePicker, raw As String)
        Dim ngay As DateTime
        If DateTime.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.None, ngay) Then
            dtp.Value = ngay
        End If
    End Sub

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
        For Each cot As DataGridViewColumn In dgvPhanCong.Columns
            cot.ReadOnly = True
        Next
        If dgvPhanCong.Columns.Contains("colChon") Then
            dgvPhanCong.Columns("colChon").ReadOnly = False
        End If
        'Việt hóa tiêu đề cột sau khi bind dữ liệu.
        UiVietHoa.ApDungVietHoa(dgvPhanCong)
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
