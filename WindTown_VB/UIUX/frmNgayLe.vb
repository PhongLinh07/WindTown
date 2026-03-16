Imports System.Globalization

Public Class frmNgayLe
    Private ReadOnly ngayLeRepo As New NgayLeRepository()
    Private bangDuLieu As DataTable
    Private cheDo As String = ""
    Private moTaGoc As String = ""
    Private ReadOnly splitterMacDinh As Integer = 700

    Private Sub frmNgayLe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        dgvNgayLe.ReadOnly = False
        dgvNgayLe.AllowUserToAddRows = False
        dgvNgayLe.AllowUserToDeleteRows = False
        dgvNgayLe.MultiSelect = False
        dgvNgayLe.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        UiDinhDang.ApDungDinhDangLuoiChamCong(dgvNgayLe)
        ThemCotChon(dgvNgayLe)
        AddHandler dgvNgayLe.DataBindingComplete, AddressOf DatCotChiDoc
    End Sub

    Private Sub TaiDuLieu()
        bangDuLieu = ngayLeRepo.LayDanhSach()
        dgvNgayLe.DataSource = bangDuLieu
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatChiTietTheoDong() Handles dgvNgayLe.SelectionChanged
        If dgvNgayLe.CurrentRow Is Nothing OrElse dgvNgayLe.CurrentRow.DataBoundItem Is Nothing Then Return
        If cheDo = "Them" Then Return

        Dim row = CType(dgvNgayLe.CurrentRow.DataBoundItem, DataRowView).Row
        txtMaNgay.Text = row.Field(Of String)("MaNgay")
        txtTenNgay.Text = row.Field(Of String)("TenNgay")
        txtDayMult.Text = row.Field(Of Decimal)("DayMult").ToString()
        txtNightMult.Text = row.Field(Of Decimal)("NightMult").ToString()
        txtOtMult.Text = row.Field(Of Decimal)("OtMult").ToString()
        txtTrangThai.Text = row.Field(Of Integer)("TrangThai").ToString()
        txtGhiChu.Text = row.Field(Of String)("GhiChu")
        GanNgay(dtpNgay, row.Field(Of String)("Ngay"))
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        If bangDuLieu Is Nothing Then Return
        Dim tuKhoa = txtTuKhoa.Text.Trim().Replace("'", "''")
        Dim view As New DataView(bangDuLieu)
        If String.IsNullOrWhiteSpace(tuKhoa) Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"MaNgay LIKE '%{tuKhoa}%' OR TenNgay LIKE '%{tuKhoa}%'"
        End If
        dgvNgayLe.DataSource = view
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
        If dgvNgayLe.CurrentRow Is Nothing Then Return
        cheDo = "Sua"
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvNgayLe.CurrentRow Is Nothing Then Return
        Dim row = CType(dgvNgayLe.CurrentRow.DataBoundItem, DataRowView).Row
        Dim id = row.Field(Of Integer)("Id")
        If MessageBox.Show("Xóa ngày lễ đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ngayLeRepo.Xoa(id)
            TaiDuLieu()
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If cheDo = "" Then Return

        Dim model As New NgayLeModel()
        model.MaNgay = txtMaNgay.Text.Trim()
        model.TenNgay = txtTenNgay.Text.Trim()
        model.Ngay = dtpNgay.Value.ToString("yyyy-MM-dd")
        model.DayMult = LaySoThapPhan(txtDayMult.Text)
        model.NightMult = LaySoThapPhan(txtNightMult.Text)
        model.OtMult = LaySoThapPhan(txtOtMult.Text)
        model.TrangThai = LaySo(txtTrangThai.Text)
        model.GhiChu = txtGhiChu.Text.Trim()

        If cheDo = "Them" Then
            ngayLeRepo.Them(model)
        Else
            Dim row = CType(dgvNgayLe.CurrentRow.DataBoundItem, DataRowView).Row
            model.Id = row.Field(Of Integer)("Id")
            ngayLeRepo.CapNhat(model)
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
        txtMaNgay.Text = ""
        txtTenNgay.Text = ""
        txtDayMult.Text = "0"
        txtNightMult.Text = "0"
        txtOtMult.Text = "0"
        txtTrangThai.Text = "1"
        txtGhiChu.Text = ""
        dtpNgay.Value = DateTime.Today
    End Sub

    Private Function LaySo(raw As String) As Integer
        Dim giaTri As Integer
        If Integer.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0
    End Function

    Private Function LaySoThapPhan(raw As String) As Decimal
        Dim giaTri As Decimal
        If Decimal.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0D
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
        For Each cot As DataGridViewColumn In dgvNgayLe.Columns
            cot.ReadOnly = True
        Next
        If dgvNgayLe.Columns.Contains("colChon") Then
            dgvNgayLe.Columns("colChon").ReadOnly = False
        End If
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
