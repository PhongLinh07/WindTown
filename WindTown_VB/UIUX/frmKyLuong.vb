Imports System.Linq

Public Class frmKyLuong

    Private ReadOnly _duLieu As New KyLuongDataModel()
    Private _danhSachKyLuong As List(Of Pay_Period) = New List(Of Pay_Period)()
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
            MessageBox.Show("Kh?ng th? k?t n?i database: " & bootstrap.Message, "Lỗi k?t n?i DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        cbbTrangThai.Enabled = False
        cbbThoiGian.Enabled = False
        dtTuNgay.Enabled = False
        dtDenNgay.Enabled = False
        btnTimKiem.Enabled = False
        btnLamMoi.Enabled = False
        btnThemKyLuong.Enabled = False
        btnSuaKyLuong.Enabled = False
        btnXoaKyLuong.Enabled = False
        dgvKyLuong.Enabled = False
    End Sub

    Private Sub CauHinhLuoi()
        With dgvKyLuong
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
        For Each cot As DataGridViewColumn In dgvKyLuong.Columns
            cot.ReadOnly = True
        Next
        dgvKyLuong.Columns("colChon").ReadOnly = False
    End Sub

    Private Sub TaoCotLuoi()
        dgvKyLuong.Columns.Clear()

        Dim colChon As New DataGridViewCheckBoxColumn()
        colChon.Name = "colChon"
        colChon.HeaderText = ""
        colChon.Width = 40
        colChon.Frozen = True
        dgvKyLuong.Columns.Add(colChon)

        Dim colMa As New DataGridViewTextBoxColumn()
        colMa.Name = "colMa"
        colMa.HeaderText = "Mã kỳ lương"
        colMa.Width = 140
        colMa.Frozen = True
        dgvKyLuong.Columns.Add(colMa)

        Dim colTen As New DataGridViewTextBoxColumn()
        colTen.Name = "colTen"
        colTen.HeaderText = "Tên kỳ lương"
        colTen.Width = 180
        dgvKyLuong.Columns.Add(colTen)

        Dim colTuNgay As New DataGridViewTextBoxColumn()
        colTuNgay.Name = "colTuNgay"
        colTuNgay.HeaderText = "Ngày bắt đầu"
        colTuNgay.Width = 120
        dgvKyLuong.Columns.Add(colTuNgay)

        Dim colDenNgay As New DataGridViewTextBoxColumn()
        colDenNgay.Name = "colDenNgay"
        colDenNgay.HeaderText = "Ngày kết thúc"
        colDenNgay.Width = 120
        dgvKyLuong.Columns.Add(colDenNgay)

        Dim colGioChuan As New DataGridViewTextBoxColumn()
        colGioChuan.Name = "colGioChuan"
        colGioChuan.HeaderText = "Giờ chuẩn"
        colGioChuan.Width = 110
        dgvKyLuong.Columns.Add(colGioChuan)

        Dim colTrangThai As New DataGridViewTextBoxColumn()
        colTrangThai.Name = "colTrangThai"
        colTrangThai.HeaderText = "Trạng thái"
        colTrangThai.Width = 120
        dgvKyLuong.Columns.Add(colTrangThai)

        Dim colGhiChu As New DataGridViewTextBoxColumn()
        colGhiChu.Name = "colGhiChu"
        colGhiChu.HeaderText = "Ghi chú"
        colGhiChu.Width = 220
        dgvKyLuong.Columns.Add(colGhiChu)
    End Sub

    Private Sub TaiBoLoc()
        Dim trangThaiItems As New List(Of LuaChon(Of Integer)) From {
            New LuaChon(Of Integer) With {.HienThi = "T?t c?", .GiaTri = -999}
        }
        For Each kv In Pay_Period.status_Dict
            trangThaiItems.Add(New LuaChon(Of Integer) With {.HienThi = kv.Value, .GiaTri = kv.Key})
        Next
        cbbTrangThai.DataSource = trangThaiItems
        cbbTrangThai.DisplayMember = "HienThi"
        cbbTrangThai.ValueMember = "GiaTri"

        cbbThoiGian.Items.Clear()
        cbbThoiGian.Items.AddRange(New Object() {"T?t c?", "Theo kho?ng"})
        cbbThoiGian.SelectedIndex = 0

        dtTuNgay.Value = DateTime.Today.AddMonths(-1)
        dtDenNgay.Value = DateTime.Today
    End Sub

    Private Sub TaiDuLieu()
        Try
            _danhSachKyLuong = _duLieu.TaiDanhSachKyLuong()
        Catch ex As Exception
            MessageBox.Show("Không thể tải danh sách kỳ lương: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _danhSachKyLuong = New List(Of Pay_Period)()
        End Try

        CapNhatLuoi()
    End Sub

    Private Function ApDungLoc(nguon As List(Of Pay_Period)) As List(Of Pay_Period)
        If nguon Is Nothing Then Return New List(Of Pay_Period)()

        Dim query = nguon.AsEnumerable()
        Dim tuKhoa = If(txtTuKhoa.Text, String.Empty).Trim().ToLowerInvariant()
        If tuKhoa <> "" Then
            query = query.Where(Function(x)
                                    Dim hay = ($"{x.code} {x.name} {x.note}").ToLowerInvariant()
                                    Return hay.Contains(tuKhoa)
                                End Function)
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
                                    Dim batDau = If(x.start_date, DateTime.MinValue).Date
                                    Dim ketThuc = If(x.end_date, DateTime.MinValue).Date
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

    Private Sub VeDong(ds As List(Of Pay_Period))
        dgvKyLuong.Rows.Clear()

        For Each item In ds
            Dim idx = dgvKyLuong.Rows.Add(
                False,
                item.code,
                item.name,
                If(item.start_date, DateTime.MinValue).ToString("dd/MM/yyyy"),
                If(item.end_date, DateTime.MinValue).ToString("dd/MM/yyyy"),
                If(item.std_hours, 0D).ToString("N2"),
                item.status_UI,
                item.note
            )
            dgvKyLuong.Rows(idx).Tag = item
        Next
    End Sub

    Private Sub CapNhatLuoi()
        Dim dsLoc = ApDungLoc(_danhSachKyLuong)
        VeDong(dsLoc)
    End Sub

    Private Sub SuKienLoc(sender As Object, e As EventArgs) Handles btnTimKiem.Click, cbbTrangThai.SelectedIndexChanged, cbbThoiGian.SelectedIndexChanged, dtTuNgay.ValueChanged, dtDenNgay.ValueChanged, txtTuKhoa.TextChanged
        If Not _daTai Then Return
        CapNhatLuoi()
    End Sub

    Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
        txtTuKhoa.Text = ""
        cbbTrangThai.SelectedIndex = 0
        cbbThoiGian.SelectedIndex = 0
        dtTuNgay.Value = DateTime.Today.AddMonths(-1)
        dtDenNgay.Value = DateTime.Today
        CapNhatLuoi()
    End Sub

    Private Sub dgvKyLuong_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvKyLuong.CurrentCellDirtyStateChanged
        If dgvKyLuong.IsCurrentCellDirty Then
            dgvKyLuong.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Function LayDanhSachChon() As List(Of Pay_Period)
        Dim ketQua As New List(Of Pay_Period)()
        For Each row As DataGridViewRow In dgvKyLuong.Rows
            Dim isChecked = False
            If row.Cells("colChon").Value IsNot Nothing Then
                Boolean.TryParse(row.Cells("colChon").Value.ToString(), isChecked)
            End If
            If isChecked Then
                Dim data = TryCast(row.Tag, Pay_Period)
                If data IsNot Nothing Then ketQua.Add(data)
            End If
        Next
        Return ketQua
    End Function

    Private Sub btnThemKyLuong_Click(sender As Object, e As EventArgs) Handles btnThemKyLuong.Click
        Dim data As New Pay_Period()
        If Not ShowKyLuongDialog(data, True) Then Return

        Dim result = _duLieu.TaoKyLuong(data)
        If result.IsSuccess Then
            MessageBox.Show("Thêm kỳ lương th?nh c?ng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSuaKyLuong_Click(sender As Object, e As EventArgs) Handles btnSuaKyLuong.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn kỳ lương cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dsChon.Count > 1 Then
            MessageBox.Show("Vui lòng chỉ chọn 1 dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim data = Utils.DeepClone(dsChon(0))
        If Not ShowKyLuongDialog(data, False) Then Return

        Dim result = _duLieu.CapNhatKyLuong(data)
        If result.IsSuccess Then
            MessageBox.Show("Cập nhật kỳ lương thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnXoaKyLuong_Click(sender As Object, e As EventArgs) Handles btnXoaKyLuong.Click
        Dim dsChon = LayDanhSachChon()
        If dsChon.Count = 0 Then
            MessageBox.Show("Vui lòng chọn kỳ lương cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show($"Xác nhận xóa {dsChon.Count} kỳ lương?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim result = _duLieu.XoaKyLuong(dsChon)
        If result.IsSuccess Then
            MessageBox.Show("Xóa kỳ lương thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDuLieu()
        Else
            MessageBox.Show(result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ShowKyLuongDialog(data As Pay_Period, isCreate As Boolean) As Boolean
        Dim tieuDe = If(isCreate, "Thêm kỳ lương", "Sửa kỳ lương")
        Using frm As New Form()
            frm.Text = tieuDe
            frm.StartPosition = FormStartPosition.CenterParent
            frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ClientSize = New Size(520, 360)
            HoTroPhongChu.ApDungPhongChu(frm)

            Dim lblCode As New Label() With {.Text = "Mã kỳ lương", .Location = New Point(20, 20), .AutoSize = True}
            Dim txtCode As New TextBox() With {.Location = New Point(190, 18), .Width = 300, .Text = data.code}

            Dim lblTen As New Label() With {.Text = "Tên kỳ lương", .Location = New Point(20, 60), .AutoSize = True}
            Dim txtTen As New TextBox() With {.Location = New Point(190, 58), .Width = 300, .Text = data.name}

            Dim lblTuNgay As New Label() With {.Text = "Ngày bắt đầu", .Location = New Point(20, 100), .AutoSize = True}
            Dim dtBatDau As New DateTimePicker() With {.Location = New Point(190, 98), .Width = 300}
            dtBatDau.Value = If(data.start_date, DateTime.Today)

            Dim lblDenNgay As New Label() With {.Text = "Ng?y k?t th?c", .Location = New Point(20, 140), .AutoSize = True}
            Dim dtKetThuc As New DateTimePicker() With {.Location = New Point(190, 138), .Width = 300}
            dtKetThuc.Value = If(data.end_date, DateTime.Today)

            Dim lblGioChuan As New Label() With {.Text = "Gi? chu?n", .Location = New Point(20, 180), .AutoSize = True}
            Dim numGioChuan As New NumericUpDown() With {.Location = New Point(190, 178), .Width = 300, .Maximum = Decimal.MaxValue, .DecimalPlaces = 2}
            numGioChuan.Value = If(data.std_hours, 0D)

            Dim lblTrangThai As New Label() With {.Text = "Tr?ng th?i", .Location = New Point(20, 220), .AutoSize = True}
            Dim cboTrangThai As New ComboBox() With {.Location = New Point(190, 218), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
            cboTrangThai.DataSource = New BindingSource(Pay_Period.status_Dict, Nothing)
            cboTrangThai.DisplayMember = "Value"
            cboTrangThai.ValueMember = "Key"
            cboTrangThai.SelectedValue = data.status

            Dim lblGhiChu As New Label() With {.Text = "Ghi ch?", .Location = New Point(20, 260), .AutoSize = True}
            Dim txtGhiChu As New TextBox() With {.Location = New Point(190, 258), .Width = 300, .Text = data.note}

            Dim btnOk As New Button() With {.Text = "L?u", .Location = New Point(330, 300), .Width = 75, .DialogResult = DialogResult.OK}
            Dim btnHuy As New Button() With {.Text = "H?y", .Location = New Point(415, 300), .Width = 75, .DialogResult = DialogResult.Cancel}

            frm.Controls.AddRange(New Control() {lblCode, txtCode, lblTen, txtTen, lblTuNgay, dtBatDau, lblDenNgay, dtKetThuc, lblGioChuan, numGioChuan, lblTrangThai, cboTrangThai, lblGhiChu, txtGhiChu, btnOk, btnHuy})
            frm.AcceptButton = btnOk
            frm.CancelButton = btnHuy

            If frm.ShowDialog(Me) <> DialogResult.OK Then Return False

            If String.IsNullOrWhiteSpace(txtCode.Text) Then
                MessageBox.Show("Vui lòng nhập mã kỳ lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If String.IsNullOrWhiteSpace(txtTen.Text) Then
                MessageBox.Show("Vui lòng nhập tên kỳ lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If dtBatDau.Value.Date > dtKetThuc.Value.Date Then
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Dim ma = txtCode.Text.Trim()
            If KiemTraTrungMaKyLuong(ma, If(isCreate, 0, data.id)) Then
                MessageBox.Show("Mã kỳ lương đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            data.code = ma
            data.name = txtTen.Text.Trim()
            data.start_date = dtBatDau.Value
            data.end_date = dtKetThuc.Value
            data.std_hours = numGioChuan.Value
            data.status = CInt(cboTrangThai.SelectedValue)
            data.note = txtGhiChu.Text.Trim()
            Return True
        End Using
    End Function

    Private Function KiemTraTrungMaKyLuong(ma As String, idHienTai As Integer) As Boolean
        If String.IsNullOrWhiteSpace(ma) Then Return False
        Dim maSoSanh = ma.Trim()
        Return _danhSachKyLuong.Any(Function(x)
                                        If x Is Nothing OrElse String.IsNullOrWhiteSpace(x.code) Then Return False
                                        If idHienTai > 0 AndAlso x.id = idHienTai Then Return False
                                        Return String.Equals(x.code.Trim(), maSoSanh, StringComparison.OrdinalIgnoreCase)
                                    End Function)
    End Function

End Class


