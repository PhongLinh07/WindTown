Imports System.Globalization

Public Class frmNghiPhep
    Private ReadOnly nghiPhepRepo As New NghiPhepRepository()
    Private bangDuLieu As DataTable
    Private cheDo As String = ""
    Private moTaGoc As String = ""
    Private ReadOnly splitterMacDinh As Integer = 700
    Private danhSachNhanVien As List(Of LuaChonNhanVien) = New List(Of LuaChonNhanVien)()

    Private Sub frmNghiPhep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        CapNhatThongTinHeThong()
        CaiDatBang()
        TaiDanhSachNhanVien()
        TaiDuLieu()
        CapNhatTrangThaiNut()
        AddHandler splitNoiDung.SizeChanged, AddressOf CapNhatSplitter
        AddHandler Me.Shown, AddressOf XuLyFormShown
        CapNhatSplitter()
    End Sub

    Private Sub CaiDatBang()
        dgvNghiPhep.ReadOnly = False
        dgvNghiPhep.AllowUserToAddRows = False
        dgvNghiPhep.AllowUserToDeleteRows = False
        dgvNghiPhep.MultiSelect = False
        dgvNghiPhep.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        UiDinhDang.ApDungDinhDangLuoiChamCong(dgvNghiPhep)
        ThemCotChon(dgvNghiPhep)
        AddHandler dgvNghiPhep.DataBindingComplete, AddressOf DatCotChiDoc
    End Sub

    Private Sub TaiDuLieu()
        bangDuLieu = nghiPhepRepo.LayDanhSach()
        dgvNghiPhep.DataSource = bangDuLieu
        CapNhatChiTietTheoDong()
    End Sub

    Private Sub CapNhatChiTietTheoDong() Handles dgvNghiPhep.SelectionChanged
        If dgvNghiPhep.CurrentRow Is Nothing OrElse dgvNghiPhep.CurrentRow.DataBoundItem Is Nothing Then Return
        If cheDo = "Them" Then Return

        Dim row = CType(dgvNghiPhep.CurrentRow.DataBoundItem, DataRowView).Row
        txtMaNghiPhep.Text = row.Field(Of String)("MaNghiPhep")
        ChonGiaTriCombobox(cbbNhanVien, row.Field(Of Integer)("EmployeeId"))
        ChonGiaTriCombobox(cbbNguoiDuyet, row.Field(Of Integer)("ApprovedId"))
        txtLeaveCatId.Text = row.Field(Of Integer)("LeaveCatId").ToString()
        txtTrangThai.Text = row.Field(Of Integer)("TrangThai").ToString()
        txtGhiChu.Text = row.Field(Of String)("GhiChu")

        GanNgay(dtpTuNgay, row.Field(Of String)("TuNgay"))
        GanNgay(dtpDenNgay, row.Field(Of String)("DenNgay"))
    End Sub

    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        If bangDuLieu Is Nothing Then Return
        Dim tuKhoa = txtTuKhoa.Text.Trim().Replace("'", "''")
        Dim view As New DataView(bangDuLieu)
        If String.IsNullOrWhiteSpace(tuKhoa) Then
            view.RowFilter = ""
        Else
            view.RowFilter = $"MaNghiPhep LIKE '%{tuKhoa}%'"
        End If
        dgvNghiPhep.DataSource = view
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
        If dgvNghiPhep.CurrentRow Is Nothing Then Return
        cheDo = "Sua"
        CapNhatTrangThaiNut()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If dgvNghiPhep.CurrentRow Is Nothing Then Return
        Dim row = CType(dgvNghiPhep.CurrentRow.DataBoundItem, DataRowView).Row
        Dim id = row.Field(Of Integer)("Id")
        If MessageBox.Show("Xóa đơn nghỉ phép đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            nghiPhepRepo.Xoa(id)
            TaiDuLieu()
        End If
    End Sub

    Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
        If cheDo = "" Then Return

        If String.IsNullOrWhiteSpace(txtMaNghiPhep.Text) Then
            MessageBox.Show("Vui lòng nhập mã nghỉ phép.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaNghiPhep.Focus()
            Return
        End If

        Dim employeeId = LayGiaTriCombobox(cbbNhanVien)
        If employeeId <= 0 Then
            MessageBox.Show("Vui lòng chọn nhân viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbbNhanVien.Focus()
            Return
        End If

        Dim approvedId = LayGiaTriCombobox(cbbNguoiDuyet)
        If approvedId <= 0 Then
            MessageBox.Show("Vui lòng chọn người duyệt.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbbNguoiDuyet.Focus()
            Return
        End If

        Dim leaveCatId = LaySo(txtLeaveCatId.Text)
        If leaveCatId <= 0 Then
            MessageBox.Show("Vui lòng nhập loại nghỉ hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLeaveCatId.Focus()
            Return
        End If

        If dtpTuNgay.Value.Date > dtpDenNgay.Value.Date Then
            MessageBox.Show("Từ ngày không được lớn hơn đến ngày.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTuNgay.Focus()
            Return
        End If

        Dim model As New NghiPhepModel()
        model.MaNghiPhep = txtMaNghiPhep.Text.Trim()
        model.EmployeeId = employeeId
        ' Kiểm tra nhân viên hợp lệ trước khi lưu để tránh lỗi khóa ngoại.
        If Not nghiPhepRepo.KiemTraNhanVienTonTai(model.EmployeeId) Then
            MessageBox.Show("Vui lòng chọn nhân viên hợp lệ trước khi lưu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cbbNhanVien.Focus()
            Return
        End If
        model.ApprovedId = approvedId
        model.LeaveCatId = leaveCatId
        model.TuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd")
        model.DenNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd")
        model.TrangThai = LaySo(txtTrangThai.Text)
        model.GhiChu = txtGhiChu.Text.Trim()

        If cheDo = "Them" Then
            nghiPhepRepo.Them(model)
        Else
            Dim row = CType(dgvNghiPhep.CurrentRow.DataBoundItem, DataRowView).Row
            model.Id = row.Field(Of Integer)("Id")
            nghiPhepRepo.CapNhat(model)
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
        txtMaNghiPhep.Text = ""
        cbbNhanVien.SelectedIndex = -1
        cbbNguoiDuyet.SelectedIndex = -1
        txtLeaveCatId.Text = ""
        txtTrangThai.Text = "1"
        txtGhiChu.Text = ""
        dtpTuNgay.Value = DateTime.Today
        dtpDenNgay.Value = DateTime.Today
    End Sub

    Private Sub TaiDanhSachNhanVien()
        danhSachNhanVien = nghiPhepRepo.TaiDanhSachNhanVien()
        CaiDatComboboxNhanVien(cbbNhanVien, danhSachNhanVien)
        CaiDatComboboxNhanVien(cbbNguoiDuyet, danhSachNhanVien)
    End Sub

    Private Sub CaiDatComboboxNhanVien(cbb As ComboBox, ds As List(Of LuaChonNhanVien))
        If cbb Is Nothing Then Return
        cbb.DisplayMember = "HienThi"
        cbb.ValueMember = "Id"
        cbb.DataSource = New List(Of LuaChonNhanVien)(ds)
        cbb.SelectedIndex = -1
    End Sub

    Private Sub ChonGiaTriCombobox(cbb As ComboBox, giaTri As Integer)
        If cbb Is Nothing Then Return
        If giaTri <= 0 Then
            cbb.SelectedIndex = -1
            Return
        End If
        cbb.SelectedValue = giaTri
    End Sub

    Private Function LayGiaTriCombobox(cbb As ComboBox) As Integer
        If cbb Is Nothing OrElse cbb.SelectedValue Is Nothing Then Return 0
        Dim giaTri As Integer
        If Integer.TryParse(cbb.SelectedValue.ToString(), giaTri) Then
            Return giaTri
        End If
        Return 0
    End Function

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
        For Each cot As DataGridViewColumn In dgvNghiPhep.Columns
            cot.ReadOnly = True
        Next
        If dgvNghiPhep.Columns.Contains("colChon") Then
            dgvNghiPhep.Columns("colChon").ReadOnly = False
        End If
        'Việt hóa tiêu đề cột sau khi bind dữ liệu.
        UiVietHoa.ApDungVietHoa(dgvNghiPhep)
    End Sub

    Private Sub CapNhatSplitter() Handles splitNoiDung.SizeChanged
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
