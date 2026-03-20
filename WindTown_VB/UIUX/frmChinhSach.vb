Imports System.Globalization

Public Class frmChinhSach
    Private ReadOnly chinhSachRepo As New ChinhSachRepository()
    Private bangDuLieu As DataTable
    Private cheDo As String = ""
    Private moTaGoc As String = ""
    Private ReadOnly splitterMacDinh As Integer = 700

    Private Sub frmChinhSach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        CapNhatThongTinHeThong()
        CaiDatBang()
        UiDinhDang.ApDungDinhDangNgayPicker(dtpTuNgay)
        UiDinhDang.ApDungDinhDangNgayPicker(dtpDenNgay)
        TaiDuLieu()
        CapNhatTrangThaiNut()
        AddHandler splitNoiDung.SizeChanged, AddressOf CapNhatSplitter
        AddHandler Me.Shown, AddressOf XuLyFormShown
        CapNhatSplitter()
    End Sub

    Private Sub CaiDatBang()
        dgvChinhSach.ReadOnly = False
        dgvChinhSach.AllowUserToAddRows = False
        dgvChinhSach.AllowUserToDeleteRows = False
        dgvChinhSach.MultiSelect = False
        dgvChinhSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        UiDinhDang.ApDungDinhDangLuoiChamCong(dgvChinhSach)
        ThemCotChon(dgvChinhSach)
        AddHandler dgvChinhSach.DataBindingComplete, AddressOf DatCotChiDoc
    End Sub

    Private Sub TaiDuLieu()
        Try
            bangDuLieu = chinhSachRepo.LayDanhSach()
        Catch ex As Exception
            MessageBox.Show("Không thể tải chính sách: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bangDuLieu = chinhSachRepo.TaoBangRong()
        End Try
        dgvChinhSach.DataSource = bangDuLieu
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatChiTietTheoDong() Handles dgvChinhSach.SelectionChanged
        If dgvChinhSach.CurrentRow Is Nothing OrElse dgvChinhSach.CurrentRow.DataBoundItem Is Nothing Then Return
        If cheDo = "Them" Then Return

        Dim row = CType(dgvChinhSach.CurrentRow.DataBoundItem, DataRowView).Row
        txtMaChinhSach.Text = row.Field(Of String)("MaChinhSach")
        txtTenChinhSach.Text = row.Field(Of String)("TenChinhSach")
        txtLoaiChinhSach.Text = row.Field(Of String)("LoaiChinhSach")
        txtTrangThai.Text = row.Field(Of Integer)("TrangThai").ToString()
        txtGhiChu.Text = row.Field(Of String)("GhiChu")

        GanNgay(dtpTuNgay, row.Field(Of String)("NgayHieuLuc"))
        GanNgay(dtpDenNgay, row.Field(Of String)("NgayHetHan"))
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        If bangDuLieu Is Nothing Then Return
        Dim tuKhoa = txtTuKhoa.Text.Trim().Replace("'", "''")
        Dim view As New DataView(bangDuLieu)
        If String.IsNullOrWhiteSpace(tuKhoa) Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"MaChinhSach LIKE '%{tuKhoa}%' OR TenChinhSach LIKE '%{tuKhoa}%'"
        End If
        dgvChinhSach.DataSource = view
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
        If dgvChinhSach.CurrentRow Is Nothing Then Return
        cheDo = "Sua"
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvChinhSach.CurrentRow Is Nothing Then Return
        Dim row = CType(dgvChinhSach.CurrentRow.DataBoundItem, DataRowView).Row
        Dim id = row.Field(Of Integer)("Id")
        If MessageBox.Show("Xóa chính sách đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            chinhSachRepo.Xoa(id)
            TaiDuLieu()
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If cheDo = "" Then Return

        If String.IsNullOrWhiteSpace(txtMaChinhSach.Text) Then
            MessageBox.Show("Vui lòng nhập mã chính sách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaChinhSach.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtTenChinhSach.Text) Then
            MessageBox.Show("Vui lòng nhập tên chính sách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTenChinhSach.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtLoaiChinhSach.Text) Then
            MessageBox.Show("Vui lòng nhập loại chính sách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLoaiChinhSach.Focus()
            Return
        End If

        If dtpTuNgay.Value.Date > dtpDenNgay.Value.Date Then
            MessageBox.Show("Ngày hiệu lực không được lớn hơn ngày hết hạn.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTuNgay.Focus()
            Return
        End If

        Dim model As New ChinhSachModel()
        model.MaChinhSach = txtMaChinhSach.Text.Trim()
        model.TenChinhSach = txtTenChinhSach.Text.Trim()
        model.LoaiChinhSach = txtLoaiChinhSach.Text.Trim()
        model.NgayHieuLuc = dtpTuNgay.Value.ToString("yyyy-MM-dd")
        model.NgayHetHan = dtpDenNgay.Value.ToString("yyyy-MM-dd")
        model.TrangThai = LaySo(txtTrangThai.Text)
        model.GhiChu = txtGhiChu.Text.Trim()

        If cheDo = "Them" Then
            chinhSachRepo.Them(model)
        Else
            Dim row = CType(dgvChinhSach.CurrentRow.DataBoundItem, DataRowView).Row
            model.Id = row.Field(Of Integer)("Id")
            chinhSachRepo.CapNhat(model)
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
        txtMaChinhSach.Text = ""
        txtTenChinhSach.Text = ""
        txtLoaiChinhSach.Text = ""
        txtTrangThai.Text = "1"
        txtGhiChu.Text = ""
        dtpTuNgay.Value = DateTime.Today
        dtpDenNgay.Value = DateTime.Today
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
        For Each cot As DataGridViewColumn In dgvChinhSach.Columns
            cot.ReadOnly = True
        Next
        If dgvChinhSach.Columns.Contains("colChon") Then
            dgvChinhSach.Columns("colChon").ReadOnly = False
        End If
        'Việt hóa tiêu đề cột sau khi bind dữ liệu.
        UiVietHoa.ApDungVietHoa(dgvChinhSach)
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
