Imports System.Data
Imports System.Linq

Public Class frmChamCong

    Private ReadOnly _duLieu As New ChamCongDataModel()
    Private _danhSachChamCong As List(Of Attendance) = New List(Of Attendance)()
    Private _danhSachNhanVien As List(Of Employee) = New List(Of Employee)()
    Private _daTai As Boolean = False
    Private _trangHienTai As Integer = 1
    Private _kichThuocTrang As Integer = 10
    Private _tongTrang As Integer = 1

    Private Class LuaChon(Of T)
        Public Property HienThi As String
        Public Property GiaTri As T
        Public Overrides Function ToString() As String
            Return HienThi
        End Function
    End Class

    Private Sub TaiForm(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)

        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Không thể kết nối database: " & bootstrap.Message, "Lỗi kết nối DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            KhoaUI()
            Return
        End If

        CauHinhLuoi()
        TaiBoLoc()
        TaiDuLieu()
        _daTai = True
    End Sub

    Private Sub KhoaUI()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        cbbxThoiGianNhanh.Enabled = False
        dtpkToday.Enabled = False
        dtpkInday.Enabled = False
        TextBox1.Enabled = False
        Button1.Enabled = False
        btnBaoCao.Enabled = False
        btnThemChamCong.Enabled = False
        btnSuaChamCong.Enabled = False
        btnXoaChamCong.Enabled = False
        DataGridView1.Enabled = False
    End Sub

    Private Sub CauHinhLuoi()
        With DataGridView1
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .ColumnHeadersHeight = 40
            .RowTemplate.Height = 56
        End With

        TaoCotLuoi()
        DatCotChiDoc()
    End Sub

    Private Sub DatCotChiDoc()
        For Each cot As DataGridViewColumn In DataGridView1.Columns
            cot.ReadOnly = True
        Next
        DataGridView1.Columns("colChon").ReadOnly = False
    End Sub

    Private Sub TaoCotLuoi()
        DataGridView1.Columns.Clear()

        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        DataGridView1.Columns.Add(colChon)

        Dim colMa As New DataGridViewTextBoxColumn()
        colMa.Name = "colMa"
        colMa.HeaderText = "Mã chấm công"
        colMa.Width = 140
        colMa.Frozen = True
        DataGridView1.Columns.Add(colMa)

        Dim colNhanVien As New DataGridViewTextBoxColumn()
        colNhanVien.Name = "colNhanVien"
        colNhanVien.HeaderText = "Nhân viên"
        colNhanVien.Width = 200
        DataGridView1.Columns.Add(colNhanVien)

        Dim colNgay As New DataGridViewTextBoxColumn()
        colNgay.Name = "colNgay"
        colNgay.HeaderText = "Ngày chấm công"
        colNgay.Width = 130
        DataGridView1.Columns.Add(colNgay)

        Dim colCa As New DataGridViewTextBoxColumn()
        colCa.Name = "colCa"
        colCa.HeaderText = "Ca làm"
        colCa.Width = 120
        DataGridView1.Columns.Add(colCa)

        Dim colGioHanhChinh As New DataGridViewTextBoxColumn()
        colGioHanhChinh.Name = "colGioHanhChinh"
        colGioHanhChinh.HeaderText = "Giờ hành chính"
        colGioHanhChinh.Width = 120
        DataGridView1.Columns.Add(colGioHanhChinh)

        Dim colGioTangCa As New DataGridViewTextBoxColumn()
        colGioTangCa.Name = "colGioTangCa"
        colGioTangCa.HeaderText = "Giờ tăng ca"
        colGioTangCa.Width = 110
        DataGridView1.Columns.Add(colGioTangCa)

        Dim colDiMuon As New DataGridViewTextBoxColumn()
        colDiMuon.Name = "colDiMuon"
        colDiMuon.HeaderText = "Giờ đi muộn"
        colDiMuon.Width = 110
        DataGridView1.Columns.Add(colDiMuon)

        Dim colVeSom As New DataGridViewTextBoxColumn()
        colVeSom.Name = "colVeSom"
        colVeSom.HeaderText = "Giờ về sớm"
        colVeSom.Width = 110
        DataGridView1.Columns.Add(colVeSom)

        Dim colTrangThai As New DataGridViewTextBoxColumn()
        colTrangThai.Name = "colTrangThai"
        colTrangThai.HeaderText = "Trạng thái"
        colTrangThai.Width = 120
        DataGridView1.Columns.Add(colTrangThai)

        Dim colGhiChu As New DataGridViewTextBoxColumn()
        colGhiChu.Name = "colGhiChu"
        colGhiChu.HeaderText = "Ghi chú"
        colGhiChu.Width = 200
        DataGridView1.Columns.Add(colGhiChu)

        UiDinhDang.ApDungDinhDangCotNgay(colNgay)
        UiDinhDang.ApDungDinhDangCotSo(colGioHanhChinh, "N2")
        UiDinhDang.ApDungDinhDangCotSo(colGioTangCa, "N2")
        UiDinhDang.ApDungDinhDangCotSo(colDiMuon, "N2")
        UiDinhDang.ApDungDinhDangCotSo(colVeSom, "N2")
    End Sub

    Private Sub TaiBoLoc()
        cbbxThoiGian.Items.Clear()
        cbbxThoiGian.Items.AddRange(New Object() {"Tất cả", "Theo khoảng thời gian"})
        cbbxThoiGian.SelectedIndex = 0

        Dim trangThaiItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "Tất cả", .GiaTri = -999}
        }
        For Each kv In Attendance.status_Dict
            trangThaiItems.Add(New LuaChon(Of Integer) With {.HienThi = kv.Value, .GiaTri = kv.Key})
        Next
        ComboBox1.DataSource = trangThaiItems
        ComboBox1.DisplayMember = "HienThi"
        ComboBox1.ValueMember = "GiaTri"

        Dim caLamItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "Tất cả", .GiaTri = -999}
        }
        For Each kv In Attendance.shift_Dic
            caLamItems.Add(New LuaChon(Of Integer) With {.HienThi = kv.Value, .GiaTri = kv.Key})
        Next
        ComboBox2.DataSource = caLamItems
        ComboBox2.DisplayMember = "HienThi"
        ComboBox2.ValueMember = "GiaTri"

        Try
            _danhSachNhanVien = _duLieu.TaiDanhSachNhanVien()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách nhân viên: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _danhSachNhanVien = New List(Of Employee)()
        End Try

        Dim nhanVienItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "Tất cả", .GiaTri = -999}
        }
        For Each nv In _danhSachNhanVien
            nhanVienItems.Add(New LuaChon(Of Integer) With {.HienThi = $"{nv.code} - {nv.name}", .GiaTri = nv.id})
        Next
        ComboBox3.DataSource = nhanVienItems
        ComboBox3.DisplayMember = "HienThi"
        ComboBox3.ValueMember = "GiaTri"

        cbbxThoiGianNhanh.Items.Clear()
        cbbxThoiGianNhanh.Items.AddRange(New Object() {"Không áp dụng", "Tháng này", "Tháng trước", "Quý này", "Quý trước", "Năm nay"})
        cbbxThoiGianNhanh.SelectedIndex = 0

        UiDinhDang.ApDungDinhDangNgayPicker(dtpkToday)
        UiDinhDang.ApDungDinhDangNgayPicker(dtpkInday)
        dtpkToday.Value = DateTime.Today.AddMonths(-1)
        dtpkInday.Value = DateTime.Today
        CapNhatTrangThaiThoiGian()
    End Sub

    Private Sub TaiDuLieu()
        Dim danhSachKhoa As Control() = {btnThemChamCong, btnSuaChamCong, btnXoaChamCong, btnBaoCao, DataGridView1}
        UiTrangThai.BatLoading(Me, danhSachKhoa)
        Try
            _danhSachChamCong = _duLieu.TaiDanhSachChamCong()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách chấm công: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _danhSachChamCong = New List(Of Attendance)()
        Finally
            UiTrangThai.TatLoading(Me, danhSachKhoa)
        End Try

        _trangHienTai = 1
        CapNhatTrang()
    End Sub

    Private Function ApDungLoc(nguon As List(Of Attendance)) As List(Of Attendance)
        If nguon Is Nothing Then Return New List(Of Attendance)()

        Dim query = nguon.AsEnumerable()
        Dim tuKhoa = If(TextBox1.Text, String.Empty).Trim().ToLowerInvariant()
        If tuKhoa <> "" Then
            query = query.Where(Function(x)
                                    Dim hay = ($"{x.code} {x.employee_UI} {x.note}").ToLowerInvariant()
                                    Return hay.Contains(tuKhoa)
                                End Function)
        End If

        Dim trangThai = LayGiaTriBoLoc(ComboBox1)
        If trangThai >= 0 Then
            query = query.Where(Function(x) x.status = trangThai)
        End If

        Dim caLam = LayGiaTriBoLoc(ComboBox2)
        If caLam >= 0 Then
            query = query.Where(Function(x) x.shift = caLam)
        End If

        Dim nvId = LayGiaTriBoLoc(ComboBox3)
        If nvId > 0 Then
            query = query.Where(Function(x) x.employee_id = nvId)
        End If

        If DangLocKhoangThoiGian() Then
            Dim tuNgay = dtpkToday.Value.Date
            Dim denNgay = dtpkInday.Value.Date
            If tuNgay > denNgay Then
                Dim tmp = tuNgay
                tuNgay = denNgay
                denNgay = tmp
            End If
            query = query.Where(Function(x)
                                    Dim ngay = If(x.of_date, DateTime.MinValue).Date
                                    Return ngay >= tuNgay AndAlso ngay <= denNgay
                                End Function)
        End If

        Return query.ToList()
    End Function

    Private Function DangLocKhoangThoiGian() As Boolean
        Return cbbxThoiGian.SelectedItem IsNot Nothing AndAlso cbbxThoiGian.SelectedItem.ToString() = "Theo khoảng thời gian"
    End Function

    Private Sub CapNhatTrangThaiThoiGian()
        Dim batLoc = DangLocKhoangThoiGian()
        dtpkToday.Enabled = batLoc
        dtpkInday.Enabled = batLoc
    End Sub

    Private Function LayGiaTriBoLoc(cb As ComboBox) As Integer
        If cb Is Nothing Then Return -999
        Dim value = cb.SelectedValue
        If value Is Nothing Then Return -999

        If TypeOf value Is Integer Then
            Return CInt(value)
        End If

        Dim luaChon = TryCast(value, LuaChon(Of Integer))
        If luaChon IsNot Nothing Then
            Return luaChon.GiaTri
        End If

        Dim ketQua As Integer
        If Integer.TryParse(value.ToString(), ketQua) Then
            Return ketQua
        End If

        Return -999
    End Function

    Private Sub VeDong(ds As List(Of Attendance))
        DataGridView1.Rows.Clear()

        For Each cc In ds
            Dim idx = DataGridView1.Rows.Add(
                False,
                cc.code,
                cc.employee_UI,
                If(cc.of_date, DateTime.MinValue).ToString("dd/MM/yyyy"),
                cc.shift_UI,
                cc.office_hours.ToString("N2"),
                cc.overtime_hours.ToString("N2"),
                cc.late_hours.ToString("N2"),
                cc.early_hours.ToString("N2"),
                cc.status_UI,
                cc.note
            )
            DataGridView1.Rows(idx).Tag = cc
        Next
    End Sub

    Private Sub SuKienLoc(sender As Object, e As EventArgs) Handles Button1.Click, ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged, ComboBox3.SelectedIndexChanged, dtpkToday.ValueChanged, dtpkInday.ValueChanged, TextBox1.TextChanged, cbbxThoiGian.SelectedIndexChanged
        If Not _daTai Then Return
        If sender Is cbbxThoiGian Then
            CapNhatTrangThaiThoiGian()
        End If
        _trangHienTai = 1
        CapNhatTrang()
    End Sub

    Private Sub btnBaoCao_Click(sender As Object, e As EventArgs) Handles btnBaoCao.Click
        cmsBaoCao.Show(btnBaoCao, New Point(0, btnBaoCao.Height))
    End Sub

    Private Sub mnuBaoCaoLoc_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoLoc.Click
        Dim dsLoc = ApDungLoc(_danhSachChamCong)
        Dim bang = TaoBangChamCong(dsLoc)
        BaoCaoXuat.XuatTuDataTable(bang, "cham_cong_loc")
    End Sub

    Private Sub mnuBaoCaoChon_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoChon.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            UiThongBao.HienThiCanhBao("Vui lòng chọn ít nhất một dòng để xuất.")
            Return
        End If
        Dim bang = TaoBangChamCong(dsChon)
        BaoCaoXuat.XuatTuDataTable(bang, "cham_cong_chon")
    End Sub

    Private Sub mnuBaoCaoTongHop_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoTongHop.Click
        Dim dsLoc = ApDungLoc(_danhSachChamCong)
        Dim bang = TaoBangChamCong(dsLoc)
        BaoCaoXuat.XuatTuDataTable(bang, "cham_cong_tong_hop")
    End Sub

    Private Sub cbbxThoiGianNhanh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbxThoiGianNhanh.SelectedIndexChanged
        If Not _daTai Then Return
        ApDungLocNhanh()
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        TextBox1.Text = ""
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        cbbxThoiGian.SelectedIndex = 0
        cbbxThoiGianNhanh.SelectedIndex = 0
        dtpkToday.Value = DateTime.Today.AddMonths(-1)
        dtpkInday.Value = DateTime.Today
        CapNhatTrangThaiThoiGian()
        _trangHienTai = 1
        CapNhatTrang()
    End Sub

    Private Sub btnTrangTruoc_Click(sender As Object, e As EventArgs) Handles btnTrangTruoc.Click
        If _trangHienTai > 1 Then
            _trangHienTai -= 1
            CapNhatTrang()
        End If
    End Sub

    Private Sub btnTrangSau_Click(sender As Object, e As EventArgs) Handles btnTrangSau.Click
        If _trangHienTai < _tongTrang Then
            _trangHienTai += 1
            CapNhatTrang()
        End If
    End Sub

    Private Sub CapNhatTrang()
        Dim dsLoc = ApDungLoc(_danhSachChamCong)
        Dim tongDong = dsLoc.Count
        _tongTrang = Math.Max(1, CInt(Math.Ceiling(tongDong / CDbl(_kichThuocTrang))))
        If _trangHienTai > _tongTrang Then _trangHienTai = _tongTrang

        Dim dsTrang = dsLoc.Skip((_trangHienTai - 1) * _kichThuocTrang).Take(_kichThuocTrang).ToList()
        VeDong(dsTrang)
        lblTrang.Text = $"Trang {_trangHienTai}/{_tongTrang}"

        btnTrangTruoc.Enabled = _trangHienTai > 1
        btnTrangSau.Enabled = _trangHienTai < _tongTrang
    End Sub

    Private Function LayDanhSachChon() As List(Of Attendance)
        Dim ketQua As New List(Of Attendance)()
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim isChecked = False
            If row.Cells("colChon").Value IsNot Nothing Then
                Boolean.TryParse(row.Cells("colChon").Value.ToString(), isChecked)
            End If
            If isChecked Then
                Dim data = TryCast(row.Tag, Attendance)
                If data IsNot Nothing Then ketQua.Add(data)
            End If
        Next
        Return ketQua
    End Function

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnThemChamCong_Click(sender As Object, e As EventArgs) Handles btnThemChamCong.Click
        Dim data As New Attendance()
        If Not ShowChamCongDialog(data, True) Then Return

        Dim result = _duLieu.TaoChamCong(data)
        If result.IsSuccess Then
            MessageBox.Show("Thêm chấm công thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSuaChamCong_Click(sender As Object, e As EventArgs) Handles btnSuaChamCong.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn chấm công cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dsChon.Count > 1 Then
            MessageBox.Show("Vui lòng chỉ chọn 1 dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        SuaChamCong(dsChon(0))
    End Sub

    Private Sub btnXoaChamCong_Click(sender As Object, e As EventArgs) Handles btnXoaChamCong.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn chấm công cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Xác nhận xóa {dsChon.Count} dòng chấm công?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim result = _duLieu.XoaChamCong(dsChon)
        If result.IsSuccess Then
            MessageBox.Show("Xóa chấm công thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub SuaChamCong(chamCong As Attendance)
        Dim data = Utils.DeepClone(chamCong)
        If Not ShowChamCongDialog(data, False) Then Return

        Dim result = _duLieu.CapNhatChamCong(data)
        If result.IsSuccess Then
            MessageBox.Show("Cập nhật chấm công thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ShowChamCongDialog(data As Attendance, isCreate As Boolean) As Boolean
        Dim tieuDe = If(isCreate, "Thêm chấm công", "Sửa chấm công")
        Using frm As New Form()
            frm.Text = tieuDe
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(520, 460)
            HoTroPhongChu.ApDungPhongChu(frm)

            Dim lblCode As New Label() With {.Text = "Mã chấm công", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(190, 18), .Width = 300, .Text = data.code}

            Dim lblEmp As New Label() With {.Text = "Nhân viên", .Location = New Point(20, 60), .AutoSize = True}
            Dim cboEmp As New ComboBox() With {.Location = New Point(190, 58), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            Dim empItems = _danhSachNhanVien.Select(Function(e) New LuaChon(Of Employee) With {.HienThi = e.employee_UI, .GiaTri = e}).ToList()
            cboEmp.DataSource = empItems
            cboEmp.DisplayMember = "HienThi"
            cboEmp.ValueMember = "GiaTri"
            If data.Employee IsNot Nothing Then
                cboEmp.SelectedItem = empItems.FirstOrDefault(Function(x) x.GiaTri.id = data.Employee.id)
            End If

            Dim lblNgay As New Label() With {.Text = "Ngày chấm công", .Location = New Point(20, 100), .AutoSize = True}
            Dim dtNgay As New DateTimePicker() With {.Location = New Point(190, 98), .Width = 300}
            dtNgay.Value = If(data.of_date, DateTime.Today)

            Dim lblCa As New Label() With {.Text = "Ca làm", .Location = New Point(20, 140), .AutoSize = True}
            Dim cboCa As New ComboBox() With {.Location = New Point(190, 138), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboCa.DataSource = New BindingSource(Attendance.shift_Dic, Nothing)
            cboCa.DisplayMember = "Value"
            cboCa.ValueMember = "Key"
            cboCa.SelectedValue = data.shift

            Dim lblGioHC As New Label() With {.Text = "Giờ hành chính", .Location = New Point(20, 180), .AutoSize = True}
            Dim numGioHC As New NumericUpDown() With {.Location = New Point(190, 178), .Width = 300, .Maximum = Decimal.MaxValue, .DecimalPlaces = 2}
            numGioHC.Value = data.office_hours

            Dim lblTangCa As New Label() With {.Text = "Giờ tăng ca", .Location = New Point(20, 220), .AutoSize = True}
            Dim numTangCa As New NumericUpDown() With {.Location = New Point(190, 218), .Width = 300, .Maximum = Decimal.MaxValue, .DecimalPlaces = 2}
            numTangCa.Value = data.overtime_hours

            Dim lblDiMuon As New Label() With {.Text = "Giờ đi muộn", .Location = New Point(20, 260), .AutoSize = True}
            Dim numDiMuon As New NumericUpDown() With {.Location = New Point(190, 258), .Width = 300, .Maximum = Decimal.MaxValue, .DecimalPlaces = 2}
            numDiMuon.Value = data.late_hours

            Dim lblVeSom As New Label() With {.Text = "Giờ về sớm", .Location = New Point(20, 300), .AutoSize = True}
            Dim numVeSom As New NumericUpDown() With {.Location = New Point(190, 298), .Width = 300, .Maximum = Decimal.MaxValue, .DecimalPlaces = 2}
            numVeSom.Value = data.early_hours

            Dim lblTrangThai As New Label() With {.Text = "Trạng thái", .Location = New Point(20, 340), .AutoSize = True}
            Dim cboTrangThai As New ComboBox() With {.Location = New Point(190, 338), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboTrangThai.DataSource = New BindingSource(Attendance.status_Dict, Nothing)
            cboTrangThai.DisplayMember = "Value"
            cboTrangThai.ValueMember = "Key"
            cboTrangThai.SelectedValue = data.status

            Dim lblGhiChu As New Label() With {.Text = "Ghi chú", .Location = New Point(20, 380), .AutoSize = True}
            Dim txtGhiChu As New TextBox() With {.Location = New Point(190, 378), .Width = 300, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "Luu", .Location = New Point(330, 420), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnHuy As New Button() With {.Text = "Hủy", .Location = New Point(415, 420), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblEmp, cboEmp, lblNgay, dtNgay, lblCa, cboCa, lblGioHC, numGioHC, lblTangCa, numTangCa, lblDiMuon, numDiMuon, lblVeSom, numVeSom, lblTrangThai, cboTrangThai, lblGhiChu, txtGhiChu, btnOk, btnHuy})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnHuy

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) Then
                MessageBox.Show("Vui lòng nhập mã chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim chonNV = TryCast(cboEmp.SelectedItem, LuaChon(Of Employee))
            If chonNV Is Nothing Then
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim ma = txtCode.Text.Trim()
            If KiemTraTrungMaChamCong(ma, If(isCreate, 0, data.id)) Then
                MessageBox.Show("Mã chấm công đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = ma
            data.Employee = chonNV.GiaTri
            data.of_date = dtNgay.Value
            data.shift = CInt(cboCa.SelectedValue)
            data.office_hours = numGioHC.Value
            data.overtime_hours = numTangCa.Value
            data.late_hours = numDiMuon.Value
            data.early_hours = numVeSom.Value
            data.status = CInt(cboTrangThai.SelectedValue)
            data.note = txtGhiChu.Text.Trim()
            Return True
        End Using
    End Function

    Private Function KiemTraTrungMaChamCong(ma As String, idHienTai As Integer) As Boolean
        If String.IsNullOrWhiteSpace(ma) Then Return False
        Dim maSoSanh = ma.Trim()
        Return _danhSachChamCong.Any(Function(x)
                                         If x Is Nothing OrElse String.IsNullOrWhiteSpace(x.code) Then Return False
                                         If idHienTai > 0 AndAlso x.id = idHienTai Then Return False
                                         Return String.Equals(x.code.Trim(), maSoSanh, StringComparison.OrdinalIgnoreCase)
                                     End Function)
    End Function

    Private Sub ApDungLocNhanh()
        If cbbxThoiGianNhanh.SelectedItem Is Nothing Then Return

        Dim luaChon = cbbxThoiGianNhanh.SelectedItem.ToString()
        If luaChon = "Không áp dụng" Then Return

        Dim homNay = DateTime.Today
        Dim tuNgay As DateTime
        Dim denNgay As DateTime

        Select Case luaChon
            Case "Tháng này"
                tuNgay = New DateTime(homNay.Year, homNay.Month, 1)
                denNgay = tuNgay.AddMonths(1).AddDays(-1)
            Case "Tháng trước"
                Dim thangTruoc = homNay.AddMonths(-1)
                tuNgay = New DateTime(thangTruoc.Year, thangTruoc.Month, 1)
                denNgay = tuNgay.AddMonths(1).AddDays(-1)
            Case "Quý này"
                Dim quy = CInt(Math.Floor((homNay.Month - 1) / 3)) + 1
                Dim thangBatDau = (quy - 1) * 3 + 1
                tuNgay = New DateTime(homNay.Year, thangBatDau, 1)
                denNgay = tuNgay.AddMonths(3).AddDays(-1)
            Case "Quý trước"
                Dim thang = homNay.AddMonths(-3)
                Dim quy = CInt(Math.Floor((thang.Month - 1) / 3)) + 1
                Dim thangBatDau = (quy - 1) * 3 + 1
                tuNgay = New DateTime(thang.Year, thangBatDau, 1)
                denNgay = tuNgay.AddMonths(3).AddDays(-1)
            Case "Năm nay"
                tuNgay = New DateTime(homNay.Year, 1, 1)
                denNgay = New DateTime(homNay.Year, 12, 31)
            Case Else
                Return
        End Select

        dtpkToday.Value = tuNgay
        dtpkInday.Value = denNgay
        cbbxThoiGian.SelectedIndex = 1
        _trangHienTai = 1
        CapNhatTrang()
    End Sub

    Private Function TaoBangChamCong(ds As IEnumerable(Of Attendance)) As DataTable
        Dim bang As New DataTable()
        bang.Columns.Add("Mã chấm công")
        bang.Columns.Add("Nhân viên")
        bang.Columns.Add("Ngày chấm công")
        bang.Columns.Add("Ca làm")
        bang.Columns.Add("Giờ hành chính")
        bang.Columns.Add("Giờ tăng ca")
        bang.Columns.Add("Giờ đi muộn")
        bang.Columns.Add("Giờ về sớm")
        bang.Columns.Add("Trạng thái")
        bang.Columns.Add("Ghi chú")

        If ds Is Nothing Then Return bang
        For Each cc In ds
            bang.Rows.Add(
                cc.code,
                cc.employee_UI,
                If(cc.of_date, DateTime.MinValue).ToString(UiDinhDang.DinhDangNgayMacDinh),
                cc.shift_UI,
                cc.office_hours.ToString("N2"),
                cc.overtime_hours.ToString("N2"),
                cc.late_hours.ToString("N2"),
                cc.early_hours.ToString("N2"),
                cc.status_UI,
                cc.note
            )
        Next

        Return bang
    End Function

End Class

Friend Class ChamCongDataModel

    Private ReadOnly _chamCongService As New AttendanceService()
    Private ReadOnly _nhanVienService As New EmployeeService()

    Public Function TaiDanhSachChamCong() As List(Of Attendance)
        Dim response = _chamCongService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Attendance))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Attendance)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaiDanhSachNhanVien() As List(Of Employee)
        Dim response = _nhanVienService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Employee))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Employee)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function TaoChamCong(data As Attendance) As ServiceResponse(Of Object)
        Return _chamCongService.Execute(DataIntent.Insert, data)
    End Function

    Public Function CapNhatChamCong(data As Attendance) As ServiceResponse(Of Object)
        Return _chamCongService.Execute(DataIntent.Update, data)
    End Function

    Public Function XoaChamCong(items As List(Of Attendance)) As ServiceResponse(Of Object)
        Return _chamCongService.Execute(DataIntent.SoftDeleteMany, items)
    End Function

End Class





