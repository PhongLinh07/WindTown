Imports System.Linq

Public Class frmTinhLuong

    Private ReadOnly _duLieu As New TinhLuongDataModel()
    Private _danhSachBangLuong As List(Of Payroll) = New List(Of Payroll)()
    Private _danhSachKyLuong As List(Of Pay_Period) = New List(Of Pay_Period)()
    Private _danhSachViTri As List(Of Position) = New List(Of Position)()
    Private _daTai As Boolean = False

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
            MessageBox.Show("Kh?ng th? k?t n?i database: " & bootstrap.Message, "L?i k?t n?i DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            KhoaUI()
            Return
        End If

        CauHinhLuoi()
        TaiBoLoc()
        TaiDuLieu()
        _daTai = True
    End Sub

    Private Sub KhoaUI()
        txtTuKhoa.Enabled = False
        cbbKyLuong.Enabled = False
        cbbViTri.Enabled = False
        cbbTrangThai.Enabled = False
        cbbThoiGian.Enabled = False
        dtTuNgay.Enabled = False
        dtDenNgay.Enabled = False
        cbbThoiGianNhanh.Enabled = False
        btnTimKiem.Enabled = False
        btnLamMoi.Enabled = False
        btnTaoBangLuong.Enabled = False
        btnDongBangLuong.Enabled = False
        btnBaoCao.Enabled = False
        dgvBangLuong.Enabled = False
    End Sub

    Private Sub CauHinhLuoi()
        With dgvBangLuong
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
            .RowTemplate.Height = 48
        End With

        TaoCotLuoi()
        DatCotChiDoc()
    End Sub

    Private Sub DatCotChiDoc()
        For Each cot As DataGridViewColumn In dgvBangLuong.Columns
            cot.ReadOnly = True
        Next
        dgvBangLuong.Columns("colChon").ReadOnly = False
    End Sub

    Private Sub TaoCotLuoi()
        dgvBangLuong.Columns.Clear()

        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        dgvBangLuong.Columns.Add(colChon)

        Dim colMa As New DataGridViewTextBoxColumn()
        colMa.Name = "colMa"
        colMa.HeaderText = "Mã bảng lương"
        colMa.Width = 140
        colMa.Frozen = True
        dgvBangLuong.Columns.Add(colMa)

        Dim colKyLuong As New DataGridViewTextBoxColumn()
        colKyLuong.Name = "colKyLuong"
        colKyLuong.HeaderText = "Kỳ lương"
        colKyLuong.Width = 170
        dgvBangLuong.Columns.Add(colKyLuong)

        Dim colNhanVien As New DataGridViewTextBoxColumn()
        colNhanVien.Name = "colNhanVien"
        colNhanVien.HeaderText = "Nh?n vi?n"
        colNhanVien.Width = 160
        dgvBangLuong.Columns.Add(colNhanVien)

        Dim colCongViec As New DataGridViewTextBoxColumn()
        colCongViec.Name = "colCongViec"
        colCongViec.HeaderText = "C?ng vi?c"
        colCongViec.Width = 140
        dgvBangLuong.Columns.Add(colCongViec)

        Dim colTrinhDo As New DataGridViewTextBoxColumn()
        colTrinhDo.Name = "colTrinhDo"
        colTrinhDo.HeaderText = "Trình độ"
        colTrinhDo.Width = 120
        dgvBangLuong.Columns.Add(colTrinhDo)

        Dim colTrangThai As New DataGridViewTextBoxColumn()
        colTrangThai.Name = "colTrangThai"
        colTrangThai.HeaderText = "Tr?ng th?i"
        colTrangThai.Width = 120
        dgvBangLuong.Columns.Add(colTrangThai)

        Dim colGhiChu As New DataGridViewTextBoxColumn()
        colGhiChu.Name = "colGhiChu"
        colGhiChu.HeaderText = "Ghi ch?"
        colGhiChu.Width = 200
        dgvBangLuong.Columns.Add(colGhiChu)
    End Sub

    Private Sub TaiBoLoc()
        Dim trangThaiItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "T?t c?", .GiaTri = -999}
        }
        For Each kv In Payroll.status_Dict
            trangThaiItems.Add(New LuaChon(Of Integer) With {.HienThi = kv.Value, .GiaTri = kv.Key})
        Next
        cbbTrangThai.DataSource = trangThaiItems
        cbbTrangThai.DisplayMember = "HienThi"
        cbbTrangThai.ValueMember = "GiaTri"

        Try
            _danhSachKyLuong = _duLieu.TaiDanhSachKyLuong()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách kỳ lương: " & ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _danhSachKyLuong = New List(Of Pay_Period)()
        End Try

        Dim kyLuongItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "T?t c?", .GiaTri = -999}
        }
        For Each ky In _danhSachKyLuong
            kyLuongItems.Add(New LuaChon(Of Integer) With {.HienThi = ky.pay_period_UI, .GiaTri = ky.id})
        Next
        cbbKyLuong.DataSource = kyLuongItems
        cbbKyLuong.DisplayMember = "HienThi"
        cbbKyLuong.ValueMember = "GiaTri"

        Try
            _danhSachViTri = _duLieu.TaiDanhSachViTri()
        Catch ex As Exception
            MessageBox.Show("Kh?ng th? t?i danh s?ch v? tr?: " & ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _danhSachViTri = New List(Of Position)()
        End Try

        Dim viTriItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "T?t c?", .GiaTri = -999}
        }
        For Each vt In _danhSachViTri
            viTriItems.Add(New LuaChon(Of Integer) With {.HienThi = vt.employee_UI, .GiaTri = vt.id})
        Next
        cbbViTri.DataSource = viTriItems
        cbbViTri.DisplayMember = "HienThi"
        cbbViTri.ValueMember = "GiaTri"

        cbbThoiGian.Items.Clear()
        cbbThoiGian.Items.AddRange(New Object() {"T?t c?", "Theo kho?ng"})
        cbbThoiGian.SelectedIndex = 0

        cbbThoiGianNhanh.Items.Clear()
        cbbThoiGianNhanh.Items.AddRange(New Object() {"Không áp dụng", "Tháng này", "Tháng trước", "Quý này", "Quý trước", "Năm nay"})
        cbbThoiGianNhanh.SelectedIndex = 0

        dtTuNgay.Value = DateTime.Today.AddMonths(-1)
        dtDenNgay.Value = DateTime.Today
    End Sub

    Private Sub TaiDuLieu()
        Try
            _danhSachBangLuong = _duLieu.TaiDanhSachBangLuong()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách bảng lương: " & ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _danhSachBangLuong = New List(Of Payroll)()
        End Try

        CapNhatLuoi()
    End Sub

    Private Function ApDungLoc(nguon As List(Of Payroll)) As List(Of Payroll)
        If nguon Is Nothing Then Return New List(Of Payroll)()

        Dim query = nguon.AsEnumerable()
        Dim tuKhoa = If(txtTuKhoa.Text, String.Empty).Trim().ToLowerInvariant()
        If tuKhoa <> "" Then
            query = query.Where(Function(x)
                                    Dim hay = ($"{x.code} {x.employee_UI} {x.job_UI} {x.note}").ToLowerInvariant()
                                    Return hay.Contains(tuKhoa)
                                End Function)
        End If

        Dim kyId = LayGiaTriBoLoc(cbbKyLuong)
        If kyId > 0 Then
            query = query.Where(Function(x) x.Pay_Period IsNot Nothing AndAlso x.Pay_Period.id = kyId)
        End If

        Dim vtId = LayGiaTriBoLoc(cbbViTri)
        If vtId > 0 Then
            query = query.Where(Function(x) x.Position IsNot Nothing AndAlso x.Position.id = vtId)
        End If

        Dim trangThai = LayGiaTriBoLoc(cbbTrangThai)
        If trangThai >= 0 Then
            query = query.Where(Function(x) x.status = trangThai)
        End If

        If cbbThoiGian.SelectedItem IsNot Nothing AndAlso cbbThoiGian.SelectedItem.ToString() = "Theo kho?ng" Then
            Dim tuNgay = dtTuNgay.Value.Date
            Dim denNgay = dtDenNgay.Value.Date
            If tuNgay > denNgay Then
                Dim tmp = tuNgay
                tuNgay = denNgay
                denNgay = tmp
            End If
            query = query.Where(Function(x)
                                    Dim batDau = If(x.Pay_Period?.start_date, DateTime.MinValue).Date
                                    Dim ketThuc = If(x.Pay_Period?.end_date, DateTime.MinValue).Date
                                    Return batDau >= tuNgay AndAlso ketThuc <= denNgay
                                End Function)
        End If

        Return query.ToList()
    End Function

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

    Private Sub VeDong(ds As List(Of Payroll))
        dgvBangLuong.Rows.Clear()

        For Each item In ds
            Dim idx = dgvBangLuong.Rows.Add(
                False,
                item.code,
                item.pay_period_UI,
                item.employee_UI,
                item.job_UI,
                item.level_UI,
                item.status_UI,
                item.note
            )
            dgvBangLuong.Rows(idx).Tag = item
        Next
    End Sub

    Private Sub CapNhatLuoi()
        Dim dsLoc = ApDungLoc(_danhSachBangLuong)
        VeDong(dsLoc)
    End Sub

    Private Sub SuKienLoc(sender As Object, e As EventArgs) Handles btnTimKiem.Click, txtTuKhoa.TextChanged, cbbKyLuong.SelectedIndexChanged, cbbViTri.SelectedIndexChanged, cbbTrangThai.SelectedIndexChanged, cbbThoiGian.SelectedIndexChanged, dtTuNgay.ValueChanged, dtDenNgay.ValueChanged
        If Not _daTai Then Return
        CapNhatLuoi()
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        txtTuKhoa.Text = ""
        cbbKyLuong.SelectedIndex = 0
        cbbViTri.SelectedIndex = 0
        cbbTrangThai.SelectedIndex = 0
        cbbThoiGian.SelectedIndex = 0
        cbbThoiGianNhanh.SelectedIndex = 0
        dtTuNgay.Value = DateTime.Today.AddMonths(-1)
        dtDenNgay.Value = DateTime.Today
        CapNhatLuoi()
    End Sub

    Private Sub dgvBangLuong_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvBangLuong.CurrentCellDirtyStateChanged
        If dgvBangLuong.IsCurrentCellDirty Then
            dgvBangLuong.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Function LayDanhSachChon() As List(Of Payroll)
        Dim ketQua As New List(Of Payroll)()
        For Each row As DataGridViewRow In dgvBangLuong.Rows
            Dim isChecked = False
            If row.Cells("colChon").Value IsNot Nothing Then
                Boolean.TryParse(row.Cells("colChon").Value.ToString(), isChecked)
            End If
            If isChecked Then
                Dim data = TryCast(row.Tag, Payroll)
                If data IsNot Nothing Then ketQua.Add(data)
            End If
        Next
        Return ketQua
    End Function

    Private Sub btnBaoCao_Click(sender As Object, e As EventArgs) Handles btnBaoCao.Click
        cmsBaoCao.Show(btnBaoCao, New Point(0, btnBaoCao.Height))
    End Sub

    Private Sub mnuBaoCaoLoc_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoLoc.Click
        MessageBox.Show("Chức năng xuất theo bộ lọc đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub mnuBaoCaoChon_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoChon.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn ít nhất một dòng để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        MessageBox.Show("Chức năng xuất theo lựa chọn đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub mnuBaoCaoTongHop_Click(sender As Object, e As EventArgs) Handles mnuBaoCaoTongHop.Click
        MessageBox.Show("Chức năng tổng hợp tháng/quý đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cbbThoiGianNhanh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbbThoiGianNhanh.SelectedIndexChanged
        If Not _daTai Then Return
        ApDungLocNhanh()
    End Sub

    Private Sub btnTaoBangLuong_Click(sender As Object, e As EventArgs) Handles btnTaoBangLuong.Click
        Dim data As New Payroll()
        If Not ShowBangLuongDialog(data, True) Then Return

        Dim result = _duLieu.TaoBangLuong(data)
        If result.IsSuccess Then
            MessageBox.Show("Tạo bảng lương thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnDongBangLuong_Click(sender As Object, e As EventArgs) Handles btnDongBangLuong.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn bảng lương cần đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Xác nhận đóng {dsChon.Count} bảng lương?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim coLoi = False
        For Each item In dsChon
            item.status = 0
            Dim result = _duLieu.CapNhatBangLuong(item)
            If Not result.IsSuccess Then
                coLoi = True
            End If
        Next

        If coLoi Then
            MessageBox.Show("Có lỗi khi đóng bảng lương. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MessageBox.Show("Đóng bảng lương thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        TaiDuLieu()
    End Sub

    Private Function ShowBangLuongDialog(data As Payroll, isCreate As Boolean) As Boolean
        Dim tieuDe = If(isCreate, "Tạo bảng lương", "Sửa bảng lương")
        Using frm As New Form()
            frm.Text = tieuDe
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(520, 360)
            HoTroPhongChu.ApDungPhongChu(frm)

            Dim lblCode As New Label() With {.Text = "Mã bảng lương", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(190, 18), .Width = 300, .Text = data.code}

            Dim lblKy As New Label() With {.Text = "Kỳ lương", .Location = New Point(20, 60), .AutoSize = True}
            Dim cboKy As New ComboBox() With {.Location = New Point(190, 58), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            Dim kyItems = _danhSachKyLuong.Select(Function(k) New LuaChon(Of Pay_Period) With {.HienThi = k.pay_period_UI, .GiaTri = k}).ToList()
            cboKy.DataSource = kyItems
            cboKy.DisplayMember = "HienThi"
            cboKy.ValueMember = "GiaTri"
            If data.Pay_Period IsNot Nothing Then
                cboKy.SelectedItem = kyItems.FirstOrDefault(Function(x) x.GiaTri.id = data.Pay_Period.id)
            End If

            Dim lblViTri As New Label() With {.Text = "V? tr?", .Location = New Point(20, 100), .AutoSize = True}
            Dim cboViTri As New ComboBox() With {.Location = New Point(190, 98), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            Dim vtItems = _danhSachViTri.Select(Function(v) New LuaChon(Of Position) With {.HienThi = v.employee_UI, .GiaTri = v}).ToList()
            cboViTri.DataSource = vtItems
            cboViTri.DisplayMember = "HienThi"
            cboViTri.ValueMember = "GiaTri"
            If data.Position IsNot Nothing Then
                cboViTri.SelectedItem = vtItems.FirstOrDefault(Function(x) x.GiaTri.id = data.Position.id)
            End If

            Dim lblTrangThai As New Label() With {.Text = "Tr?ng th?i", .Location = New Point(20, 140), .AutoSize = True}
            Dim cboTrangThai As New ComboBox() With {.Location = New Point(190, 138), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboTrangThai.DataSource = New BindingSource(Payroll.status_Dict, Nothing)
            cboTrangThai.DisplayMember = "Value"
            cboTrangThai.ValueMember = "Key"
            cboTrangThai.SelectedValue = data.status

            Dim lblGhiChu As New Label() With {.Text = "Ghi ch?", .Location = New Point(20, 180), .AutoSize = True}
            Dim txtGhiChu As New TextBox() With {.Location = New Point(190, 178), .Width = 300, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "L?u", .Location = New Point(330, 300), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnHuy As New Button() With {.Text = "H?y", .Location = New Point(415, 300), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblKy, cboKy, lblViTri, cboViTri, lblTrangThai, cboTrangThai, lblGhiChu, txtGhiChu, btnOk, btnHuy})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnHuy

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) Then
                MessageBox.Show("Vui lòng nhập mã bảng lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim chonKy = TryCast(cboKy.SelectedItem, LuaChon(Of Pay_Period))
            If chonKy Is Nothing Then
                MessageBox.Show("Vui lòng chọn kỳ lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim chonViTri = TryCast(cboViTri.SelectedItem, LuaChon(Of Position))
            If chonViTri Is Nothing Then
                MessageBox.Show("Vui l?ng ch?n v? tr?.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim ma = txtCode.Text.Trim()
            If KiemTraTrungMaBangLuong(ma, If(isCreate, 0, data.id)) Then
                MessageBox.Show("Mã bảng lương đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = ma
            data.Pay_Period = chonKy.GiaTri
            data.Position = chonViTri.GiaTri
            data.status = CInt(cboTrangThai.SelectedValue)
            data.note = txtGhiChu.Text.Trim()
            Return True
        End Using
    End Function

    Private Function KiemTraTrungMaBangLuong(ma As String, idHienTai As Integer) As Boolean
        If String.IsNullOrWhiteSpace(ma) Then Return False
        Dim maSoSanh = ma.Trim()
        Return _danhSachBangLuong.Any(Function(x)
                                          If x Is Nothing OrElse String.IsNullOrWhiteSpace(x.code) Then Return False
                                          If idHienTai > 0 AndAlso x.id = idHienTai Then Return False
                                          Return String.Equals(x.code.Trim(), maSoSanh, StringComparison.OrdinalIgnoreCase)
                                      End Function)
    End Function

    Private Sub ApDungLocNhanh()
        If cbbThoiGianNhanh.SelectedItem Is Nothing Then Return

        Dim luaChon = cbbThoiGianNhanh.SelectedItem.ToString()
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

        dtTuNgay.Value = tuNgay
        dtDenNgay.Value = denNgay
        cbbThoiGian.SelectedIndex = 1
        CapNhatLuoi()
    End Sub

End Class


