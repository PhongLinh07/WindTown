Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmBaoCaoTongHop

    Private ReadOnly _dashboardService As New DashboardService()
    Private ReadOnly _baoCaoRepo As New BaoCaoTongHopRepository()
    Private _dangTai As Boolean
    Private _duLieuBaoCao As BaoCaoTongHopDto

    Private Sub frmBaoCaoTongHop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HoTroPhongChu.ApDungPhongChu(Me)
        KhoiTaoBoLoc()
        KhoiTaoLuoi()
        KhoiTaoBieuDo()
        TaiDuLieu()
    End Sub

    Private Sub KhoiTaoBoLoc()
        _dangTai = True

        cboThang.Items.Clear()
        For thang As Integer = 1 To 12
            cboThang.Items.Add(thang)
        Next

        cboNam.Items.Clear()
        Dim namHienTai = DateTime.Today.Year
        For nam As Integer = namHienTai - 4 To namHienTai + 1
            cboNam.Items.Add(nam)
        Next

        Dim danhSachPhongBan = _baoCaoRepo.TaiDanhSachPhongBan()
        danhSachPhongBan.Insert(0, New LuaChonPhongBan With {.Id = 0, .Ten = "Tất cả phòng ban"})
        cboPhongBan.DataSource = danhSachPhongBan
        cboPhongBan.DisplayMember = "Ten"
        cboPhongBan.ValueMember = "Id"

        cboThang.SelectedItem = DateTime.Today.Month
        cboNam.SelectedItem = DateTime.Today.Year

        _dangTai = False
    End Sub

    Private Sub KhoiTaoLuoi()
        dgvTopLuong.AutoGenerateColumns = False
        dgvTopLuong.Columns.Clear()

        Dim colMa As New DataGridViewTextBoxColumn()
        colMa.DataPropertyName = "MaNhanVien"
        colMa.HeaderText = "Mã nhân viên"
        colMa.Width = 120
        dgvTopLuong.Columns.Add(colMa)

        Dim colTen As New DataGridViewTextBoxColumn()
        colTen.DataPropertyName = "TenNhanVien"
        colTen.HeaderText = "Nhân viên"
        colTen.Width = 180
        dgvTopLuong.Columns.Add(colTen)

        Dim colPhong As New DataGridViewTextBoxColumn()
        colPhong.DataPropertyName = "PhongBan"
        colPhong.HeaderText = "Phòng ban"
        colPhong.Width = 160
        dgvTopLuong.Columns.Add(colPhong)

        Dim colLuong As New DataGridViewTextBoxColumn()
        colLuong.DataPropertyName = "TongLuong"
        colLuong.HeaderText = "Tổng lương"
        colLuong.Width = 140
        colLuong.DefaultCellStyle.Format = "N0"
        colLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTopLuong.Columns.Add(colLuong)
    End Sub

    Private Sub KhoiTaoBieuDo()
        chartNhanSuPhongBan.Series.Clear()
        chartNhanSuPhongBan.Series.Add(New Series("NhanSu") With {.ChartType = SeriesChartType.Pie})

        chartLuongTheoThang.Series.Clear()
        chartLuongTheoThang.Series.Add(New Series("Luong") With {.ChartType = SeriesChartType.Line})

        chartChamCong.Series.Clear()
        chartChamCong.Series.Add(New Series("ChamCong") With {.ChartType = SeriesChartType.Column})
    End Sub

    Private Sub TaiDuLieu()
        If _dangTai Then Return
        _dangTai = True
        Try
            Dim boLoc = LayBoLoc()
            Dim duLieu = _dashboardService.TaiBaoCaoTongHop(boLoc)
            _duLieuBaoCao = duLieu
            BindKpi(duLieu)
            BindBieuDo(duLieu)
            BindBangTopLuong(duLieu)
        Catch ex As Exception
            MessageBox.Show("Lỗi tải báo cáo: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _dangTai = False
        End Try
    End Sub

    Private Function LayBoLoc() As BaoCaoBoLoc
        Dim thang = If(cboThang.SelectedItem IsNot Nothing, Convert.ToInt32(cboThang.SelectedItem), DateTime.Today.Month)
        Dim nam = If(cboNam.SelectedItem IsNot Nothing, Convert.ToInt32(cboNam.SelectedItem), DateTime.Today.Year)
        Dim phongBanId = If(cboPhongBan.SelectedValue IsNot Nothing, Convert.ToInt32(cboPhongBan.SelectedValue), 0)
        Return New BaoCaoBoLoc With {
            .Thang = thang,
            .Nam = nam,
            .PhongBanId = phongBanId
        }
    End Function

    Private Sub BindKpi(duLieu As BaoCaoTongHopDto)
        lblTongNhanVienValue.Text = duLieu.TongNhanVien.ToString()
        lblTongLuongValue.Text = duLieu.TongChiPhiLuong.ToString("N0")
        lblTongTangCaValue.Text = duLieu.TongGioTangCa.ToString("N2")
        lblTongNghiPhepValue.Text = duLieu.TongNgayNghi.ToString("N2")
    End Sub

    Private Sub BindBieuDo(duLieu As BaoCaoTongHopDto)
        Dim pieSeries = chartNhanSuPhongBan.Series(0)
        pieSeries.Points.Clear()
        For Each item In duLieu.NhanSuTheoPhongBan
            pieSeries.Points.AddXY(item.Nhan, item.GiaTri)
        Next

        Dim lineSeries = chartLuongTheoThang.Series(0)
        lineSeries.Points.Clear()
        For Each item In duLieu.LuongTheoThang
            lineSeries.Points.AddXY(item.Nhan, item.GiaTri)
        Next

        Dim barSeries = chartChamCong.Series(0)
        barSeries.Points.Clear()
        For Each item In duLieu.ChamCongTongQuan
            barSeries.Points.AddXY(item.Nhan, item.GiaTri)
        Next
    End Sub

    Private Sub BindBangTopLuong(duLieu As BaoCaoTongHopDto)
        dgvTopLuong.DataSource = duLieu.TopLuong
    End Sub

    Private Sub cboBoLoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboThang.SelectedIndexChanged, cboNam.SelectedIndexChanged, cboPhongBan.SelectedIndexChanged
        If _dangTai Then Return
        TaiDuLieu()
    End Sub

    Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
        TaiDuLieu()
    End Sub

    Private Sub btnXuatBaoCao_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCao.Click
        If _duLieuBaoCao Is Nothing Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return
        End If
        Dim bang = TaoBangXuatBaoCao(_duLieuBaoCao)
        If bang.Rows.Count = 0 Then
            UiThongBao.HienThiCanhBao("Không có dữ liệu để xuất.")
            Return
        End If
        BaoCaoXuat.XuatTuDataTable(bang, "bao_cao_tong_hop")
    End Sub

    Private Function TaoBangXuatBaoCao(duLieu As BaoCaoTongHopDto) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Loai", GetType(String))
        dt.Columns.Add("NoiDung", GetType(String))
        dt.Columns.Add("GiaTri", GetType(Decimal))
        dt.Columns.Add("MaNhanVien", GetType(String))
        dt.Columns.Add("TenNhanVien", GetType(String))
        dt.Columns.Add("PhongBan", GetType(String))
        dt.Columns.Add("TongLuong", GetType(Decimal))

        dt.Rows.Add("KPI", "Tổng nhân viên", Convert.ToDecimal(duLieu.TongNhanVien), "", "", "", 0D)
        dt.Rows.Add("KPI", "Tổng chi phí lương", duLieu.TongChiPhiLuong, "", "", "", 0D)
        dt.Rows.Add("KPI", "Tổng giờ tăng ca", duLieu.TongGioTangCa, "", "", "", 0D)
        dt.Rows.Add("KPI", "Tổng ngày nghỉ", duLieu.TongNgayNghi, "", "", "", 0D)

        If duLieu.TopLuong IsNot Nothing AndAlso duLieu.TopLuong.Count > 0 Then
            For Each item In duLieu.TopLuong
                dt.Rows.Add("TopLuong", "", 0D, item.MaNhanVien, item.TenNhanVien, item.PhongBan, item.TongLuong)
            Next
        End If

        Return dt
    End Function
End Class
