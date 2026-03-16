<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPhanCong
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
        Me.tlpChinh = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTieuDe = New System.Windows.Forms.Panel()
        Me.lblMoTa = New System.Windows.Forms.Label()
        Me.lblTieuDe = New System.Windows.Forms.Label()
        Me.pnlLoc = New System.Windows.Forms.Panel()
        Me.btnLamMoi = New System.Windows.Forms.Button()
        Me.btnTimKiem = New System.Windows.Forms.Button()
        Me.txtTuKhoa = New System.Windows.Forms.TextBox()
        Me.lblTuKhoa = New System.Windows.Forms.Label()
        Me.splitNoiDung = New System.Windows.Forms.SplitContainer()
        Me.dgvPhanCong = New System.Windows.Forms.DataGridView()
        Me.pnlChiTiet = New System.Windows.Forms.Panel()
        Me.pnlNut = New System.Windows.Forms.Panel()
        Me.btnHuy = New System.Windows.Forms.Button()
        Me.btnLuu = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.tlpChiTiet = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMaPhanCong = New System.Windows.Forms.Label()
        Me.txtMaPhanCong = New System.Windows.Forms.TextBox()
        Me.lblProjectId = New System.Windows.Forms.Label()
        Me.txtProjectId = New System.Windows.Forms.TextBox()
        Me.lblPositionId = New System.Windows.Forms.Label()
        Me.txtPositionId = New System.Windows.Forms.TextBox()
        Me.lblVaiTro = New System.Windows.Forms.Label()
        Me.txtVaiTro = New System.Windows.Forms.TextBox()
        Me.lblNgayBatDau = New System.Windows.Forms.Label()
        Me.dtpNgayBatDau = New System.Windows.Forms.DateTimePicker()
        Me.lblNgayKetThuc = New System.Windows.Forms.Label()
        Me.dtpNgayKetThuc = New System.Windows.Forms.DateTimePicker()
        Me.lblTrangThai = New System.Windows.Forms.Label()
        Me.txtTrangThai = New System.Windows.Forms.TextBox()
        Me.lblGhiChu = New System.Windows.Forms.Label()
        Me.txtGhiChu = New System.Windows.Forms.TextBox()
        Me.lblChiTiet = New System.Windows.Forms.Label()
        Me.tlpChinh.SuspendLayout()
        Me.pnlTieuDe.SuspendLayout()
        Me.pnlLoc.SuspendLayout()
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitNoiDung.Panel1.SuspendLayout()
        Me.splitNoiDung.Panel2.SuspendLayout()
        Me.splitNoiDung.SuspendLayout()
        CType(Me.dgvPhanCong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChiTiet.SuspendLayout()
        Me.pnlNut.SuspendLayout()
        Me.tlpChiTiet.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpChinh
        '
        Me.tlpChinh.ColumnCount = 1
        Me.tlpChinh.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChinh.Controls.Add(Me.pnlTieuDe, 0, 0)
        Me.tlpChinh.Controls.Add(Me.pnlLoc, 0, 1)
        Me.tlpChinh.Controls.Add(Me.splitNoiDung, 0, 2)
        Me.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpChinh.Location = New System.Drawing.Point(0, 0)
        Me.tlpChinh.Name = "tlpChinh"
        Me.tlpChinh.RowCount = 3
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChinh.Size = New System.Drawing.Size(1100, 700)
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
        Me.pnlTieuDe.Padding = New System.Windows.Forms.Padding(24, 14, 24, 10)
        Me.pnlTieuDe.Size = New System.Drawing.Size(1094, 74)
        Me.pnlTieuDe.TabIndex = 0
        '
        'lblMoTa
        '
        Me.lblMoTa.AutoSize = True
        Me.lblMoTa.ForeColor = System.Drawing.Color.DimGray
        Me.lblMoTa.Location = New System.Drawing.Point(26, 44)
        Me.lblMoTa.Name = "lblMoTa"
        Me.lblMoTa.Size = New System.Drawing.Size(297, 23)
        Me.lblMoTa.TabIndex = 1
        Me.lblMoTa.Text = "Quản lý phân bổ nhân sự theo dự án."
        '
        'lblTieuDe
        '
        Me.lblTieuDe.AutoSize = True
        Me.lblTieuDe.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.Location = New System.Drawing.Point(24, 10)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(279, 37)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "Phân công công việc"
        '
        'pnlLoc
        '
        Me.pnlLoc.BackColor = System.Drawing.Color.White
        Me.pnlLoc.Controls.Add(Me.btnLamMoi)
        Me.pnlLoc.Controls.Add(Me.btnTimKiem)
        Me.pnlLoc.Controls.Add(Me.txtTuKhoa)
        Me.pnlLoc.Controls.Add(Me.lblTuKhoa)
        Me.pnlLoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoc.Location = New System.Drawing.Point(3, 83)
        Me.pnlLoc.Name = "pnlLoc"
        Me.pnlLoc.Padding = New System.Windows.Forms.Padding(24, 10, 24, 10)
        Me.pnlLoc.Size = New System.Drawing.Size(1094, 64)
        Me.pnlLoc.TabIndex = 1
        '
        'btnLamMoi
        '
        Me.btnLamMoi.Location = New System.Drawing.Point(520, 24)
        Me.btnLamMoi.Name = "btnLamMoi"
        Me.btnLamMoi.Size = New System.Drawing.Size(96, 30)
        Me.btnLamMoi.TabIndex = 3
        Me.btnLamMoi.Text = "Làm mới"
        Me.btnLamMoi.UseVisualStyleBackColor = True
        '
        'btnTimKiem
        '
        Me.btnTimKiem.Location = New System.Drawing.Point(410, 24)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(96, 30)
        Me.btnTimKiem.TabIndex = 2
        Me.btnTimKiem.Text = "Tìm kiếm"
        Me.btnTimKiem.UseVisualStyleBackColor = True
        '
        'txtTuKhoa
        '
        Me.txtTuKhoa.Location = New System.Drawing.Point(120, 25)
        Me.txtTuKhoa.Name = "txtTuKhoa"
        Me.txtTuKhoa.Size = New System.Drawing.Size(270, 30)
        Me.txtTuKhoa.TabIndex = 1
        '
        'lblTuKhoa
        '
        Me.lblTuKhoa.AutoSize = True
        Me.lblTuKhoa.Location = New System.Drawing.Point(26, 28)
        Me.lblTuKhoa.Name = "lblTuKhoa"
        Me.lblTuKhoa.Size = New System.Drawing.Size(71, 23)
        Me.lblTuKhoa.TabIndex = 0
        Me.lblTuKhoa.Text = "Từ khóa"
        '
        'splitNoiDung
        '
        Me.splitNoiDung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitNoiDung.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitNoiDung.Location = New System.Drawing.Point(3, 153)
        Me.splitNoiDung.Name = "splitNoiDung"
        '
        'splitNoiDung.Panel1
        '
        Me.splitNoiDung.Panel1.Controls.Add(Me.dgvPhanCong)
        '
        'splitNoiDung.Panel2
        '
        Me.splitNoiDung.Panel2.Controls.Add(Me.pnlChiTiet)
        Me.splitNoiDung.Panel2MinSize = 320
        Me.splitNoiDung.Size = New System.Drawing.Size(1094, 544)
        Me.splitNoiDung.SplitterDistance = 700
        Me.splitNoiDung.TabIndex = 2
        '
        'dgvPhanCong
        '
        Me.dgvPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPhanCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPhanCong.Location = New System.Drawing.Point(0, 0)
        Me.dgvPhanCong.Name = "dgvPhanCong"
        Me.dgvPhanCong.RowHeadersWidth = 51
        Me.dgvPhanCong.Size = New System.Drawing.Size(700, 544)
        Me.dgvPhanCong.TabIndex = 0
        '
        'pnlChiTiet
        '
        Me.pnlChiTiet.Controls.Add(Me.pnlNut)
        Me.pnlChiTiet.Controls.Add(Me.tlpChiTiet)
        Me.pnlChiTiet.Controls.Add(Me.lblChiTiet)
        Me.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChiTiet.Location = New System.Drawing.Point(0, 0)
        Me.pnlChiTiet.Name = "pnlChiTiet"
        Me.pnlChiTiet.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlChiTiet.Size = New System.Drawing.Size(390, 544)
        Me.pnlChiTiet.TabIndex = 0
        '
        'pnlNut
        '
        Me.pnlNut.Controls.Add(Me.btnHuy)
        Me.pnlNut.Controls.Add(Me.btnLuu)
        Me.pnlNut.Controls.Add(Me.btnXoa)
        Me.pnlNut.Controls.Add(Me.btnSua)
        Me.pnlNut.Controls.Add(Me.btnThem)
        Me.pnlNut.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNut.Location = New System.Drawing.Point(12, 496)
        Me.pnlNut.Name = "pnlNut"
        Me.pnlNut.Size = New System.Drawing.Size(366, 36)
        Me.pnlNut.TabIndex = 2
        '
        'btnHuy
        '
        Me.btnHuy.Location = New System.Drawing.Point(286, 3)
        Me.btnHuy.Name = "btnHuy"
        Me.btnHuy.Size = New System.Drawing.Size(70, 30)
        Me.btnHuy.TabIndex = 4
        Me.btnHuy.Text = "Hủy"
        Me.btnHuy.UseVisualStyleBackColor = True
        '
        'btnLuu
        '
        Me.btnLuu.Location = New System.Drawing.Point(214, 3)
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(70, 30)
        Me.btnLuu.TabIndex = 3
        Me.btnLuu.Text = "Lưu"
        Me.btnLuu.UseVisualStyleBackColor = True
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(142, 3)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(70, 30)
        Me.btnXoa.TabIndex = 2
        Me.btnXoa.Text = "Xóa"
        Me.btnXoa.UseVisualStyleBackColor = True
        '
        'btnSua
        '
        Me.btnSua.Location = New System.Drawing.Point(70, 3)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(70, 30)
        Me.btnSua.TabIndex = 1
        Me.btnSua.Text = "Sửa"
        Me.btnSua.UseVisualStyleBackColor = True
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(0, 3)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(70, 30)
        Me.btnThem.TabIndex = 0
        Me.btnThem.Text = "Thêm"
        Me.btnThem.UseVisualStyleBackColor = True
        '
        'tlpChiTiet
        '
        Me.tlpChiTiet.ColumnCount = 2
        Me.tlpChiTiet.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpChiTiet.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChiTiet.Controls.Add(Me.lblMaPhanCong, 0, 0)
        Me.tlpChiTiet.Controls.Add(Me.txtMaPhanCong, 1, 0)
        Me.tlpChiTiet.Controls.Add(Me.lblProjectId, 0, 1)
        Me.tlpChiTiet.Controls.Add(Me.txtProjectId, 1, 1)
        Me.tlpChiTiet.Controls.Add(Me.lblPositionId, 0, 2)
        Me.tlpChiTiet.Controls.Add(Me.txtPositionId, 1, 2)
        Me.tlpChiTiet.Controls.Add(Me.lblVaiTro, 0, 3)
        Me.tlpChiTiet.Controls.Add(Me.txtVaiTro, 1, 3)
        Me.tlpChiTiet.Controls.Add(Me.lblNgayBatDau, 0, 4)
        Me.tlpChiTiet.Controls.Add(Me.dtpNgayBatDau, 1, 4)
        Me.tlpChiTiet.Controls.Add(Me.lblNgayKetThuc, 0, 5)
        Me.tlpChiTiet.Controls.Add(Me.dtpNgayKetThuc, 1, 5)
        Me.tlpChiTiet.Controls.Add(Me.lblTrangThai, 0, 6)
        Me.tlpChiTiet.Controls.Add(Me.txtTrangThai, 1, 6)
        Me.tlpChiTiet.Controls.Add(Me.lblGhiChu, 0, 7)
        Me.tlpChiTiet.Controls.Add(Me.txtGhiChu, 1, 7)
        Me.tlpChiTiet.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpChiTiet.Location = New System.Drawing.Point(12, 12)
        Me.tlpChiTiet.Name = "tlpChiTiet"
        Me.tlpChiTiet.RowCount = 8
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpChiTiet.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpChiTiet.Size = New System.Drawing.Size(366, 260)
        Me.tlpChiTiet.TabIndex = 1
        '
        'lblMaPhanCong
        '
        Me.lblMaPhanCong.AutoSize = True
        Me.lblMaPhanCong.Location = New System.Drawing.Point(3, 0)
        Me.lblMaPhanCong.Name = "lblMaPhanCong"
        Me.lblMaPhanCong.Size = New System.Drawing.Size(83, 30)
        Me.lblMaPhanCong.TabIndex = 0
        Me.lblMaPhanCong.Text = "Mã phân công"
        '
        'txtMaPhanCong
        '
        Me.txtMaPhanCong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMaPhanCong.Location = New System.Drawing.Point(123, 3)
        Me.txtMaPhanCong.Name = "txtMaPhanCong"
        Me.txtMaPhanCong.Size = New System.Drawing.Size(240, 30)
        Me.txtMaPhanCong.TabIndex = 1
        '
        'lblProjectId
        '
        Me.lblProjectId.AutoSize = True
        Me.lblProjectId.Location = New System.Drawing.Point(3, 30)
        Me.lblProjectId.Name = "lblProjectId"
        Me.lblProjectId.Size = New System.Drawing.Size(83, 23)
        Me.lblProjectId.TabIndex = 2
        Me.lblProjectId.Text = "Project Id"
        '
        'txtProjectId
        '
        Me.txtProjectId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProjectId.Location = New System.Drawing.Point(123, 33)
        Me.txtProjectId.Name = "txtProjectId"
        Me.txtProjectId.Size = New System.Drawing.Size(240, 30)
        Me.txtProjectId.TabIndex = 3
        '
        'lblPositionId
        '
        Me.lblPositionId.AutoSize = True
        Me.lblPositionId.Location = New System.Drawing.Point(3, 60)
        Me.lblPositionId.Name = "lblPositionId"
        Me.lblPositionId.Size = New System.Drawing.Size(90, 23)
        Me.lblPositionId.TabIndex = 4
        Me.lblPositionId.Text = "Position Id"
        '
        'txtPositionId
        '
        Me.txtPositionId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPositionId.Location = New System.Drawing.Point(123, 63)
        Me.txtPositionId.Name = "txtPositionId"
        Me.txtPositionId.Size = New System.Drawing.Size(240, 30)
        Me.txtPositionId.TabIndex = 5
        '
        'lblVaiTro
        '
        Me.lblVaiTro.AutoSize = True
        Me.lblVaiTro.Location = New System.Drawing.Point(3, 90)
        Me.lblVaiTro.Name = "lblVaiTro"
        Me.lblVaiTro.Size = New System.Drawing.Size(60, 23)
        Me.lblVaiTro.TabIndex = 6
        Me.lblVaiTro.Text = "Vai trò"
        '
        'txtVaiTro
        '
        Me.txtVaiTro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVaiTro.Location = New System.Drawing.Point(123, 93)
        Me.txtVaiTro.Name = "txtVaiTro"
        Me.txtVaiTro.Size = New System.Drawing.Size(240, 30)
        Me.txtVaiTro.TabIndex = 7
        '
        'lblNgayBatDau
        '
        Me.lblNgayBatDau.AutoSize = True
        Me.lblNgayBatDau.Location = New System.Drawing.Point(3, 120)
        Me.lblNgayBatDau.Name = "lblNgayBatDau"
        Me.lblNgayBatDau.Size = New System.Drawing.Size(114, 23)
        Me.lblNgayBatDau.TabIndex = 8
        Me.lblNgayBatDau.Text = "Ngày bắt đầu"
        '
        'dtpNgayBatDau
        '
        Me.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgayBatDau.Location = New System.Drawing.Point(123, 123)
        Me.dtpNgayBatDau.Name = "dtpNgayBatDau"
        Me.dtpNgayBatDau.Size = New System.Drawing.Size(240, 30)
        Me.dtpNgayBatDau.TabIndex = 9
        '
        'lblNgayKetThuc
        '
        Me.lblNgayKetThuc.AutoSize = True
        Me.lblNgayKetThuc.Location = New System.Drawing.Point(3, 150)
        Me.lblNgayKetThuc.Name = "lblNgayKetThuc"
        Me.lblNgayKetThuc.Size = New System.Drawing.Size(83, 30)
        Me.lblNgayKetThuc.TabIndex = 10
        Me.lblNgayKetThuc.Text = "Ngày kết thúc"
        '
        'dtpNgayKetThuc
        '
        Me.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgayKetThuc.Location = New System.Drawing.Point(123, 153)
        Me.dtpNgayKetThuc.Name = "dtpNgayKetThuc"
        Me.dtpNgayKetThuc.Size = New System.Drawing.Size(240, 30)
        Me.dtpNgayKetThuc.TabIndex = 11
        '
        'lblTrangThai
        '
        Me.lblTrangThai.AutoSize = True
        Me.lblTrangThai.Location = New System.Drawing.Point(3, 180)
        Me.lblTrangThai.Name = "lblTrangThai"
        Me.lblTrangThai.Size = New System.Drawing.Size(87, 23)
        Me.lblTrangThai.TabIndex = 12
        Me.lblTrangThai.Text = "Trạng thái"
        '
        'txtTrangThai
        '
        Me.txtTrangThai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrangThai.Location = New System.Drawing.Point(123, 183)
        Me.txtTrangThai.Name = "txtTrangThai"
        Me.txtTrangThai.Size = New System.Drawing.Size(240, 30)
        Me.txtTrangThai.TabIndex = 13
        '
        'lblGhiChu
        '
        Me.lblGhiChu.AutoSize = True
        Me.lblGhiChu.Location = New System.Drawing.Point(3, 210)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(69, 23)
        Me.lblGhiChu.TabIndex = 14
        Me.lblGhiChu.Text = "Ghi chú"
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGhiChu.Location = New System.Drawing.Point(123, 213)
        Me.txtGhiChu.Multiline = True
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(240, 44)
        Me.txtGhiChu.TabIndex = 15
        '
        'lblChiTiet
        '
        Me.lblChiTiet.AutoSize = True
        Me.lblChiTiet.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblChiTiet.Location = New System.Drawing.Point(12, 12)
        Me.lblChiTiet.Name = "lblChiTiet"
        Me.lblChiTiet.Size = New System.Drawing.Size(186, 28)
        Me.lblChiTiet.TabIndex = 0
        Me.lblChiTiet.Text = "Chi tiết phân công"
        '
        'frmPhanCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.tlpChinh)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPhanCong"
        Me.Text = "Phân công"
        Me.tlpChinh.ResumeLayout(False)
        Me.pnlTieuDe.ResumeLayout(False)
        Me.pnlTieuDe.PerformLayout()
        Me.pnlLoc.ResumeLayout(False)
        Me.pnlLoc.PerformLayout()
        Me.splitNoiDung.Panel1.ResumeLayout(False)
        Me.splitNoiDung.Panel2.ResumeLayout(False)
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitNoiDung.ResumeLayout(False)
        CType(Me.dgvPhanCong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChiTiet.ResumeLayout(False)
        Me.pnlChiTiet.PerformLayout()
        Me.pnlNut.ResumeLayout(False)
        Me.tlpChiTiet.ResumeLayout(False)
        Me.tlpChiTiet.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpChinh As TableLayoutPanel
    Friend WithEvents pnlTieuDe As Panel
    Friend WithEvents lblMoTa As Label
    Friend WithEvents lblTieuDe As Label
    Friend WithEvents pnlLoc As Panel
    Friend WithEvents btnLamMoi As Button
    Friend WithEvents btnTimKiem As Button
    Friend WithEvents txtTuKhoa As TextBox
    Friend WithEvents lblTuKhoa As Label
    Friend WithEvents splitNoiDung As SplitContainer
    Friend WithEvents dgvPhanCong As DataGridView
    Friend WithEvents pnlChiTiet As Panel
    Friend WithEvents pnlNut As Panel
    Friend WithEvents btnHuy As Button
    Friend WithEvents btnLuu As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnSua As Button
    Friend WithEvents btnThem As Button
    Friend WithEvents tlpChiTiet As TableLayoutPanel
    Friend WithEvents lblMaPhanCong As Label
    Friend WithEvents txtMaPhanCong As TextBox
    Friend WithEvents lblProjectId As Label
    Friend WithEvents txtProjectId As TextBox
    Friend WithEvents lblPositionId As Label
    Friend WithEvents txtPositionId As TextBox
    Friend WithEvents lblVaiTro As Label
    Friend WithEvents txtVaiTro As TextBox
    Friend WithEvents lblNgayBatDau As Label
    Friend WithEvents dtpNgayBatDau As DateTimePicker
    Friend WithEvents lblNgayKetThuc As Label
    Friend WithEvents dtpNgayKetThuc As DateTimePicker
    Friend WithEvents lblTrangThai As Label
    Friend WithEvents txtTrangThai As TextBox
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents txtGhiChu As TextBox
    Friend WithEvents lblChiTiet As Label
End Class
