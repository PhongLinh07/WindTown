<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBaoCaoTongHop
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.tlpChinh = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTieuDe = New System.Windows.Forms.Panel()
        Me.lblMoTa = New System.Windows.Forms.Label()
        Me.lblTieuDe = New System.Windows.Forms.Label()
        Me.pnlBoLoc = New System.Windows.Forms.Panel()
        Me.btnXuatBaoCao = New System.Windows.Forms.Button()
        Me.btnTaiLai = New System.Windows.Forms.Button()
        Me.cboPhongBan = New System.Windows.Forms.ComboBox()
        Me.lblPhongBan = New System.Windows.Forms.Label()
        Me.cboNam = New System.Windows.Forms.ComboBox()
        Me.lblNam = New System.Windows.Forms.Label()
        Me.cboThang = New System.Windows.Forms.ComboBox()
        Me.lblThang = New System.Windows.Forms.Label()
        Me.tlpNoiDung = New System.Windows.Forms.TableLayoutPanel()
        Me.flpKpi = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlKpiNhanVien = New System.Windows.Forms.Panel()
        Me.lblTongNhanVienValue = New System.Windows.Forms.Label()
        Me.lblTongNhanVien = New System.Windows.Forms.Label()
        Me.pnlKpiLuong = New System.Windows.Forms.Panel()
        Me.lblTongLuongValue = New System.Windows.Forms.Label()
        Me.lblTongLuong = New System.Windows.Forms.Label()
        Me.pnlKpiTangCa = New System.Windows.Forms.Panel()
        Me.lblTongTangCaValue = New System.Windows.Forms.Label()
        Me.lblTongTangCa = New System.Windows.Forms.Label()
        Me.pnlKpiNghiPhep = New System.Windows.Forms.Panel()
        Me.lblTongNghiPhepValue = New System.Windows.Forms.Label()
        Me.lblTongNghiPhep = New System.Windows.Forms.Label()
        Me.splitNoiDung = New System.Windows.Forms.SplitContainer()
        Me.tlpBieuDo = New System.Windows.Forms.TableLayoutPanel()
        Me.chartNhanSuPhongBan = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartLuongTheoThang = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartChamCong = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dgvTopLuong = New System.Windows.Forms.DataGridView()
        Me.tlpChinh.SuspendLayout()
        Me.pnlTieuDe.SuspendLayout()
        Me.pnlBoLoc.SuspendLayout()
        Me.tlpNoiDung.SuspendLayout()
        Me.flpKpi.SuspendLayout()
        Me.pnlKpiNhanVien.SuspendLayout()
        Me.pnlKpiLuong.SuspendLayout()
        Me.pnlKpiTangCa.SuspendLayout()
        Me.pnlKpiNghiPhep.SuspendLayout()
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitNoiDung.Panel1.SuspendLayout()
        Me.splitNoiDung.Panel2.SuspendLayout()
        Me.splitNoiDung.SuspendLayout()
        Me.tlpBieuDo.SuspendLayout()
        CType(Me.chartNhanSuPhongBan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartLuongTheoThang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartChamCong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTopLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpChinh
        '
        Me.tlpChinh.ColumnCount = 1
        Me.tlpChinh.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChinh.Controls.Add(Me.pnlTieuDe, 0, 0)
        Me.tlpChinh.Controls.Add(Me.pnlBoLoc, 0, 1)
        Me.tlpChinh.Controls.Add(Me.tlpNoiDung, 0, 2)
        Me.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpChinh.Location = New System.Drawing.Point(0, 0)
        Me.tlpChinh.Name = "tlpChinh"
        Me.tlpChinh.RowCount = 3
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChinh.Size = New System.Drawing.Size(1200, 760)
        Me.tlpChinh.TabIndex = 0
        '
        'pnlTieuDe
        '
        Me.pnlTieuDe.BackColor = System.Drawing.Color.White
        Me.pnlTieuDe.Controls.Add(Me.lblMoTa)
        Me.pnlTieuDe.Controls.Add(Me.lblTieuDe)
        Me.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTieuDe.Location = New System.Drawing.Point(3, 3)
        Me.pnlTieuDe.Name = "pnlTieuDe"
        Me.pnlTieuDe.Padding = New System.Windows.Forms.Padding(20, 12, 20, 8)
        Me.pnlTieuDe.Size = New System.Drawing.Size(1194, 84)
        Me.pnlTieuDe.TabIndex = 0
        '
        'lblMoTa
        '
        Me.lblMoTa.AutoSize = True
        Me.lblMoTa.ForeColor = System.Drawing.Color.DimGray
        Me.lblMoTa.Location = New System.Drawing.Point(22, 45)
        Me.lblMoTa.Name = "lblMoTa"
        Me.lblMoTa.Size = New System.Drawing.Size(388, 20)
        Me.lblMoTa.TabIndex = 1
        Me.lblMoTa.Text = "Báo cáo tổng hợp KPI, biểu đồ và bảng dữ liệu toàn hệ thống."
        '
        'lblTieuDe
        '
        Me.lblTieuDe.AutoSize = True
        Me.lblTieuDe.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.Location = New System.Drawing.Point(20, 12)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(232, 32)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "Báo cáo tổng hợp"
        '
        'pnlBoLoc
        '
        Me.pnlBoLoc.BackColor = System.Drawing.Color.White
        Me.pnlBoLoc.Controls.Add(Me.btnXuatBaoCao)
        Me.pnlBoLoc.Controls.Add(Me.btnTaiLai)
        Me.pnlBoLoc.Controls.Add(Me.cboPhongBan)
        Me.pnlBoLoc.Controls.Add(Me.lblPhongBan)
        Me.pnlBoLoc.Controls.Add(Me.cboNam)
        Me.pnlBoLoc.Controls.Add(Me.lblNam)
        Me.pnlBoLoc.Controls.Add(Me.cboThang)
        Me.pnlBoLoc.Controls.Add(Me.lblThang)
        Me.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBoLoc.Location = New System.Drawing.Point(3, 93)
        Me.pnlBoLoc.Name = "pnlBoLoc"
        Me.pnlBoLoc.Padding = New System.Windows.Forms.Padding(20, 12, 20, 12)
        Me.pnlBoLoc.Size = New System.Drawing.Size(1194, 64)
        Me.pnlBoLoc.TabIndex = 1
        '
        'btnXuatBaoCao
        '
        Me.btnXuatBaoCao.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXuatBaoCao.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnXuatBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXuatBaoCao.ForeColor = System.Drawing.Color.White
        Me.btnXuatBaoCao.Location = New System.Drawing.Point(1064, 14)
        Me.btnXuatBaoCao.Name = "btnXuatBaoCao"
        Me.btnXuatBaoCao.Size = New System.Drawing.Size(110, 34)
        Me.btnXuatBaoCao.TabIndex = 7
        Me.btnXuatBaoCao.Text = "Xuất báo cáo"
        Me.btnXuatBaoCao.UseVisualStyleBackColor = False
        '
        'btnTaiLai
        '
        Me.btnTaiLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTaiLai.BackColor = System.Drawing.Color.White
        Me.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaiLai.Location = New System.Drawing.Point(950, 14)
        Me.btnTaiLai.Name = "btnTaiLai"
        Me.btnTaiLai.Size = New System.Drawing.Size(100, 34)
        Me.btnTaiLai.TabIndex = 6
        Me.btnTaiLai.Text = "Tải lại"
        Me.btnTaiLai.UseVisualStyleBackColor = False
        '
        'cboPhongBan
        '
        Me.cboPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPhongBan.FormattingEnabled = True
        Me.cboPhongBan.Location = New System.Drawing.Point(430, 17)
        Me.cboPhongBan.Name = "cboPhongBan"
        Me.cboPhongBan.Size = New System.Drawing.Size(220, 28)
        Me.cboPhongBan.TabIndex = 5
        '
        'lblPhongBan
        '
        Me.lblPhongBan.AutoSize = True
        Me.lblPhongBan.Location = New System.Drawing.Point(348, 20)
        Me.lblPhongBan.Name = "lblPhongBan"
        Me.lblPhongBan.Size = New System.Drawing.Size(79, 20)
        Me.lblPhongBan.TabIndex = 4
        Me.lblPhongBan.Text = "Phòng ban"
        '
        'cboNam
        '
        Me.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNam.FormattingEnabled = True
        Me.cboNam.Location = New System.Drawing.Point(254, 17)
        Me.cboNam.Name = "cboNam"
        Me.cboNam.Size = New System.Drawing.Size(80, 28)
        Me.cboNam.TabIndex = 3
        '
        'lblNam
        '
        Me.lblNam.AutoSize = True
        Me.lblNam.Location = New System.Drawing.Point(214, 20)
        Me.lblNam.Name = "lblNam"
        Me.lblNam.Size = New System.Drawing.Size(41, 20)
        Me.lblNam.TabIndex = 2
        Me.lblNam.Text = "Năm"
        '
        'cboThang
        '
        Me.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThang.FormattingEnabled = True
        Me.cboThang.Location = New System.Drawing.Point(86, 17)
        Me.cboThang.Name = "cboThang"
        Me.cboThang.Size = New System.Drawing.Size(70, 28)
        Me.cboThang.TabIndex = 1
        '
        'lblThang
        '
        Me.lblThang.AutoSize = True
        Me.lblThang.Location = New System.Drawing.Point(22, 20)
        Me.lblThang.Name = "lblThang"
        Me.lblThang.Size = New System.Drawing.Size(50, 20)
        Me.lblThang.TabIndex = 0
        Me.lblThang.Text = "Tháng"
        '
        'tlpNoiDung
        '
        Me.tlpNoiDung.ColumnCount = 1
        Me.tlpNoiDung.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNoiDung.Controls.Add(Me.flpKpi, 0, 0)
        Me.tlpNoiDung.Controls.Add(Me.splitNoiDung, 0, 1)
        Me.tlpNoiDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNoiDung.Location = New System.Drawing.Point(3, 163)
        Me.tlpNoiDung.Name = "tlpNoiDung"
        Me.tlpNoiDung.RowCount = 2
        Me.tlpNoiDung.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpNoiDung.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNoiDung.Size = New System.Drawing.Size(1194, 594)
        Me.tlpNoiDung.TabIndex = 2
        '
        'flpKpi
        '
        Me.flpKpi.Controls.Add(Me.pnlKpiNhanVien)
        Me.flpKpi.Controls.Add(Me.pnlKpiLuong)
        Me.flpKpi.Controls.Add(Me.pnlKpiTangCa)
        Me.flpKpi.Controls.Add(Me.pnlKpiNghiPhep)
        Me.flpKpi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpKpi.Location = New System.Drawing.Point(3, 3)
        Me.flpKpi.Name = "flpKpi"
        Me.flpKpi.Padding = New System.Windows.Forms.Padding(8)
        Me.flpKpi.Size = New System.Drawing.Size(1188, 114)
        Me.flpKpi.TabIndex = 0
        '
        'pnlKpiNhanVien
        '
        Me.pnlKpiNhanVien.BackColor = System.Drawing.Color.White
        Me.pnlKpiNhanVien.Controls.Add(Me.lblTongNhanVienValue)
        Me.pnlKpiNhanVien.Controls.Add(Me.lblTongNhanVien)
        Me.pnlKpiNhanVien.Location = New System.Drawing.Point(11, 11)
        Me.pnlKpiNhanVien.Margin = New System.Windows.Forms.Padding(3, 3, 12, 3)
        Me.pnlKpiNhanVien.Name = "pnlKpiNhanVien"
        Me.pnlKpiNhanVien.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlKpiNhanVien.Size = New System.Drawing.Size(260, 90)
        Me.pnlKpiNhanVien.TabIndex = 0
        '
        'lblTongNhanVienValue
        '
        Me.lblTongNhanVienValue.AutoSize = True
        Me.lblTongNhanVienValue.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTongNhanVienValue.Location = New System.Drawing.Point(12, 40)
        Me.lblTongNhanVienValue.Name = "lblTongNhanVienValue"
        Me.lblTongNhanVienValue.Size = New System.Drawing.Size(28, 37)
        Me.lblTongNhanVienValue.TabIndex = 1
        Me.lblTongNhanVienValue.Text = "0"
        '
        'lblTongNhanVien
        '
        Me.lblTongNhanVien.AutoSize = True
        Me.lblTongNhanVien.ForeColor = System.Drawing.Color.DimGray
        Me.lblTongNhanVien.Location = New System.Drawing.Point(12, 12)
        Me.lblTongNhanVien.Name = "lblTongNhanVien"
        Me.lblTongNhanVien.Size = New System.Drawing.Size(117, 20)
        Me.lblTongNhanVien.TabIndex = 0
        Me.lblTongNhanVien.Text = "Tổng nhân viên"
        '
        'pnlKpiLuong
        '
        Me.pnlKpiLuong.BackColor = System.Drawing.Color.White
        Me.pnlKpiLuong.Controls.Add(Me.lblTongLuongValue)
        Me.pnlKpiLuong.Controls.Add(Me.lblTongLuong)
        Me.pnlKpiLuong.Location = New System.Drawing.Point(286, 11)
        Me.pnlKpiLuong.Margin = New System.Windows.Forms.Padding(3, 3, 12, 3)
        Me.pnlKpiLuong.Name = "pnlKpiLuong"
        Me.pnlKpiLuong.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlKpiLuong.Size = New System.Drawing.Size(260, 90)
        Me.pnlKpiLuong.TabIndex = 1
        '
        'lblTongLuongValue
        '
        Me.lblTongLuongValue.AutoSize = True
        Me.lblTongLuongValue.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTongLuongValue.Location = New System.Drawing.Point(12, 40)
        Me.lblTongLuongValue.Name = "lblTongLuongValue"
        Me.lblTongLuongValue.Size = New System.Drawing.Size(28, 37)
        Me.lblTongLuongValue.TabIndex = 1
        Me.lblTongLuongValue.Text = "0"
        '
        'lblTongLuong
        '
        Me.lblTongLuong.AutoSize = True
        Me.lblTongLuong.ForeColor = System.Drawing.Color.DimGray
        Me.lblTongLuong.Location = New System.Drawing.Point(12, 12)
        Me.lblTongLuong.Name = "lblTongLuong"
        Me.lblTongLuong.Size = New System.Drawing.Size(132, 20)
        Me.lblTongLuong.TabIndex = 0
        Me.lblTongLuong.Text = "Tổng chi phí lương"
        '
        'pnlKpiTangCa
        '
        Me.pnlKpiTangCa.BackColor = System.Drawing.Color.White
        Me.pnlKpiTangCa.Controls.Add(Me.lblTongTangCaValue)
        Me.pnlKpiTangCa.Controls.Add(Me.lblTongTangCa)
        Me.pnlKpiTangCa.Location = New System.Drawing.Point(561, 11)
        Me.pnlKpiTangCa.Margin = New System.Windows.Forms.Padding(3, 3, 12, 3)
        Me.pnlKpiTangCa.Name = "pnlKpiTangCa"
        Me.pnlKpiTangCa.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlKpiTangCa.Size = New System.Drawing.Size(260, 90)
        Me.pnlKpiTangCa.TabIndex = 2
        '
        'lblTongTangCaValue
        '
        Me.lblTongTangCaValue.AutoSize = True
        Me.lblTongTangCaValue.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTongTangCaValue.Location = New System.Drawing.Point(12, 40)
        Me.lblTongTangCaValue.Name = "lblTongTangCaValue"
        Me.lblTongTangCaValue.Size = New System.Drawing.Size(28, 37)
        Me.lblTongTangCaValue.TabIndex = 1
        Me.lblTongTangCaValue.Text = "0"
        '
        'lblTongTangCa
        '
        Me.lblTongTangCa.AutoSize = True
        Me.lblTongTangCa.ForeColor = System.Drawing.Color.DimGray
        Me.lblTongTangCa.Location = New System.Drawing.Point(12, 12)
        Me.lblTongTangCa.Name = "lblTongTangCa"
        Me.lblTongTangCa.Size = New System.Drawing.Size(120, 20)
        Me.lblTongTangCa.TabIndex = 0
        Me.lblTongTangCa.Text = "Tổng giờ tăng ca"
        '
        'pnlKpiNghiPhep
        '
        Me.pnlKpiNghiPhep.BackColor = System.Drawing.Color.White
        Me.pnlKpiNghiPhep.Controls.Add(Me.lblTongNghiPhepValue)
        Me.pnlKpiNghiPhep.Controls.Add(Me.lblTongNghiPhep)
        Me.pnlKpiNghiPhep.Location = New System.Drawing.Point(836, 11)
        Me.pnlKpiNghiPhep.Name = "pnlKpiNghiPhep"
        Me.pnlKpiNghiPhep.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlKpiNghiPhep.Size = New System.Drawing.Size(260, 90)
        Me.pnlKpiNghiPhep.TabIndex = 3
        '
        'lblTongNghiPhepValue
        '
        Me.lblTongNghiPhepValue.AutoSize = True
        Me.lblTongNghiPhepValue.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTongNghiPhepValue.Location = New System.Drawing.Point(12, 40)
        Me.lblTongNghiPhepValue.Name = "lblTongNghiPhepValue"
        Me.lblTongNghiPhepValue.Size = New System.Drawing.Size(28, 37)
        Me.lblTongNghiPhepValue.TabIndex = 1
        Me.lblTongNghiPhepValue.Text = "0"
        '
        'lblTongNghiPhep
        '
        Me.lblTongNghiPhep.AutoSize = True
        Me.lblTongNghiPhep.ForeColor = System.Drawing.Color.DimGray
        Me.lblTongNghiPhep.Location = New System.Drawing.Point(12, 12)
        Me.lblTongNghiPhep.Name = "lblTongNghiPhep"
        Me.lblTongNghiPhep.Size = New System.Drawing.Size(114, 20)
        Me.lblTongNghiPhep.TabIndex = 0
        Me.lblTongNghiPhep.Text = "Tổng ngày nghỉ"
        '
        'splitNoiDung
        '
        Me.splitNoiDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitNoiDung.Location = New System.Drawing.Point(3, 123)
        Me.splitNoiDung.Name = "splitNoiDung"
        '
        'splitNoiDung.Panel1
        '
        Me.splitNoiDung.Panel1.Controls.Add(Me.tlpBieuDo)
        '
        'splitNoiDung.Panel2
        '
        Me.splitNoiDung.Panel2.Controls.Add(Me.dgvTopLuong)
        Me.splitNoiDung.Size = New System.Drawing.Size(1188, 468)
        Me.splitNoiDung.SplitterDistance = 620
        Me.splitNoiDung.TabIndex = 1
        '
        'tlpBieuDo
        '
        Me.tlpBieuDo.ColumnCount = 1
        Me.tlpBieuDo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBieuDo.Controls.Add(Me.chartNhanSuPhongBan, 0, 0)
        Me.tlpBieuDo.Controls.Add(Me.chartLuongTheoThang, 0, 1)
        Me.tlpBieuDo.Controls.Add(Me.chartChamCong, 0, 2)
        Me.tlpBieuDo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBieuDo.Location = New System.Drawing.Point(0, 0)
        Me.tlpBieuDo.Name = "tlpBieuDo"
        Me.tlpBieuDo.RowCount = 3
        Me.tlpBieuDo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpBieuDo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpBieuDo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpBieuDo.Size = New System.Drawing.Size(620, 468)
        Me.tlpBieuDo.TabIndex = 0
        '
        'chartNhanSuPhongBan
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartNhanSuPhongBan.ChartAreas.Add(ChartArea1)
        Me.chartNhanSuPhongBan.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chartNhanSuPhongBan.Legends.Add(Legend1)
        Me.chartNhanSuPhongBan.Location = New System.Drawing.Point(3, 3)
        Me.chartNhanSuPhongBan.Name = "chartNhanSuPhongBan"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartNhanSuPhongBan.Series.Add(Series1)
        Me.chartNhanSuPhongBan.Size = New System.Drawing.Size(614, 150)
        Me.chartNhanSuPhongBan.TabIndex = 0
        Me.chartNhanSuPhongBan.Text = "chartNhanSuPhongBan"
        '
        'chartLuongTheoThang
        '
        ChartArea2.Name = "ChartArea1"
        Me.chartLuongTheoThang.ChartAreas.Add(ChartArea2)
        Me.chartLuongTheoThang.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.chartLuongTheoThang.Legends.Add(Legend2)
        Me.chartLuongTheoThang.Location = New System.Drawing.Point(3, 159)
        Me.chartLuongTheoThang.Name = "chartLuongTheoThang"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chartLuongTheoThang.Series.Add(Series2)
        Me.chartLuongTheoThang.Size = New System.Drawing.Size(614, 150)
        Me.chartLuongTheoThang.TabIndex = 1
        Me.chartLuongTheoThang.Text = "chartLuongTheoThang"
        '
        'chartChamCong
        '
        ChartArea3.Name = "ChartArea1"
        Me.chartChamCong.ChartAreas.Add(ChartArea3)
        Me.chartChamCong.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Name = "Legend1"
        Me.chartChamCong.Legends.Add(Legend3)
        Me.chartChamCong.Location = New System.Drawing.Point(3, 315)
        Me.chartChamCong.Name = "chartChamCong"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chartChamCong.Series.Add(Series3)
        Me.chartChamCong.Size = New System.Drawing.Size(614, 150)
        Me.chartChamCong.TabIndex = 2
        Me.chartChamCong.Text = "chartChamCong"
        '
        'dgvTopLuong
        '
        Me.dgvTopLuong.AllowUserToAddRows = False
        Me.dgvTopLuong.AllowUserToDeleteRows = False
        Me.dgvTopLuong.AllowUserToResizeRows = False
        Me.dgvTopLuong.BackgroundColor = System.Drawing.Color.White
        Me.dgvTopLuong.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTopLuong.ColumnHeadersHeight = 40
        Me.dgvTopLuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTopLuong.Location = New System.Drawing.Point(0, 0)
        Me.dgvTopLuong.Name = "dgvTopLuong"
        Me.dgvTopLuong.RowHeadersVisible = False
        Me.dgvTopLuong.RowTemplate.Height = 40
        Me.dgvTopLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTopLuong.Size = New System.Drawing.Size(564, 468)
        Me.dgvTopLuong.TabIndex = 0
        '
        'frmBaoCaoTongHop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 760)
        Me.Controls.Add(Me.tlpChinh)
        Me.Name = "frmBaoCaoTongHop"
        Me.Text = "Báo cáo tổng hợp"
        Me.tlpChinh.ResumeLayout(False)
        Me.pnlTieuDe.ResumeLayout(False)
        Me.pnlTieuDe.PerformLayout()
        Me.pnlBoLoc.ResumeLayout(False)
        Me.pnlBoLoc.PerformLayout()
        Me.tlpNoiDung.ResumeLayout(False)
        Me.flpKpi.ResumeLayout(False)
        Me.pnlKpiNhanVien.ResumeLayout(False)
        Me.pnlKpiNhanVien.PerformLayout()
        Me.pnlKpiLuong.ResumeLayout(False)
        Me.pnlKpiLuong.PerformLayout()
        Me.pnlKpiTangCa.ResumeLayout(False)
        Me.pnlKpiTangCa.PerformLayout()
        Me.pnlKpiNghiPhep.ResumeLayout(False)
        Me.pnlKpiNghiPhep.PerformLayout()
        Me.splitNoiDung.Panel1.ResumeLayout(False)
        Me.splitNoiDung.Panel2.ResumeLayout(False)
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitNoiDung.ResumeLayout(False)
        Me.tlpBieuDo.ResumeLayout(False)
        CType(Me.chartNhanSuPhongBan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartLuongTheoThang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartChamCong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTopLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpChinh As TableLayoutPanel
    Friend WithEvents pnlTieuDe As Panel
    Friend WithEvents lblMoTa As Label
    Friend WithEvents lblTieuDe As Label
    Friend WithEvents pnlBoLoc As Panel
    Friend WithEvents btnXuatBaoCao As Button
    Friend WithEvents btnTaiLai As Button
    Friend WithEvents cboPhongBan As ComboBox
    Friend WithEvents lblPhongBan As Label
    Friend WithEvents cboNam As ComboBox
    Friend WithEvents lblNam As Label
    Friend WithEvents cboThang As ComboBox
    Friend WithEvents lblThang As Label
    Friend WithEvents tlpNoiDung As TableLayoutPanel
    Friend WithEvents flpKpi As FlowLayoutPanel
    Friend WithEvents pnlKpiNhanVien As Panel
    Friend WithEvents lblTongNhanVienValue As Label
    Friend WithEvents lblTongNhanVien As Label
    Friend WithEvents pnlKpiLuong As Panel
    Friend WithEvents lblTongLuongValue As Label
    Friend WithEvents lblTongLuong As Label
    Friend WithEvents pnlKpiTangCa As Panel
    Friend WithEvents lblTongTangCaValue As Label
    Friend WithEvents lblTongTangCa As Label
    Friend WithEvents pnlKpiNghiPhep As Panel
    Friend WithEvents lblTongNghiPhepValue As Label
    Friend WithEvents lblTongNghiPhep As Label
    Friend WithEvents splitNoiDung As SplitContainer
    Friend WithEvents tlpBieuDo As TableLayoutPanel
    Friend WithEvents chartNhanSuPhongBan As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents chartLuongTheoThang As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents chartChamCong As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dgvTopLuong As DataGridView
End Class
