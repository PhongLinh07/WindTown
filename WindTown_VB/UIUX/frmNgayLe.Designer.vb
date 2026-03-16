<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNgayLe
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
        Me.dgvNgayLe = New System.Windows.Forms.DataGridView()
        Me.pnlChiTiet = New System.Windows.Forms.Panel()
        Me.pnlNut = New System.Windows.Forms.Panel()
        Me.btnHuy = New System.Windows.Forms.Button()
        Me.btnLuu = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.tlpChiTiet = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMaNgay = New System.Windows.Forms.Label()
        Me.txtMaNgay = New System.Windows.Forms.TextBox()
        Me.lblTenNgay = New System.Windows.Forms.Label()
        Me.txtTenNgay = New System.Windows.Forms.TextBox()
        Me.lblNgay = New System.Windows.Forms.Label()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblDayMult = New System.Windows.Forms.Label()
        Me.txtDayMult = New System.Windows.Forms.TextBox()
        Me.lblNightMult = New System.Windows.Forms.Label()
        Me.txtNightMult = New System.Windows.Forms.TextBox()
        Me.lblOtMult = New System.Windows.Forms.Label()
        Me.txtOtMult = New System.Windows.Forms.TextBox()
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
        CType(Me.dgvNgayLe, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tlpChinh.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
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
        Me.pnlTieuDe.Size = New System.Drawing.Size(1094, 114)
        Me.pnlTieuDe.TabIndex = 0
        '
        'lblMoTa
        '
        Me.lblMoTa.AutoSize = True
        Me.lblMoTa.ForeColor = System.Drawing.Color.DimGray
        Me.lblMoTa.Location = New System.Drawing.Point(26, 44)
        Me.lblMoTa.Name = "lblMoTa"
        Me.lblMoTa.Size = New System.Drawing.Size(291, 23)
        Me.lblMoTa.TabIndex = 1
        Me.lblMoTa.Text = "Quản lý lịch nghỉ lễ và ngày đặc biệt."
        '
        'lblTieuDe
        '
        Me.lblTieuDe.AutoSize = True
        Me.lblTieuDe.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.Location = New System.Drawing.Point(24, 10)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(247, 37)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "Danh sách ngày lễ"
        '
        'pnlLoc
        '
        Me.pnlLoc.BackColor = System.Drawing.Color.White
        Me.pnlLoc.Controls.Add(Me.btnLamMoi)
        Me.pnlLoc.Controls.Add(Me.btnTimKiem)
        Me.pnlLoc.Controls.Add(Me.txtTuKhoa)
        Me.pnlLoc.Controls.Add(Me.lblTuKhoa)
        Me.pnlLoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoc.Location = New System.Drawing.Point(3, 123)
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
        Me.splitNoiDung.Location = New System.Drawing.Point(3, 193)
        Me.splitNoiDung.Name = "splitNoiDung"
        '
        'splitNoiDung.Panel1
        '
        Me.splitNoiDung.Panel1.Controls.Add(Me.dgvNgayLe)
        '
        'splitNoiDung.Panel2
        '
        Me.splitNoiDung.Panel2.Controls.Add(Me.pnlChiTiet)
        Me.splitNoiDung.Panel2MinSize = 320
        Me.splitNoiDung.Size = New System.Drawing.Size(1094, 504)
        Me.splitNoiDung.SplitterDistance = 700
        Me.splitNoiDung.TabIndex = 2
        '
        'dgvNgayLe
        '
        Me.dgvNgayLe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNgayLe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNgayLe.Location = New System.Drawing.Point(0, 0)
        Me.dgvNgayLe.Name = "dgvNgayLe"
        Me.dgvNgayLe.RowHeadersWidth = 51
        Me.dgvNgayLe.Size = New System.Drawing.Size(700, 504)
        Me.dgvNgayLe.TabIndex = 0
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
        Me.pnlChiTiet.Size = New System.Drawing.Size(390, 504)
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
        Me.pnlNut.Location = New System.Drawing.Point(12, 456)
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
        Me.tlpChiTiet.Controls.Add(Me.lblMaNgay, 0, 0)
        Me.tlpChiTiet.Controls.Add(Me.txtMaNgay, 1, 0)
        Me.tlpChiTiet.Controls.Add(Me.lblTenNgay, 0, 1)
        Me.tlpChiTiet.Controls.Add(Me.txtTenNgay, 1, 1)
        Me.tlpChiTiet.Controls.Add(Me.lblNgay, 0, 2)
        Me.tlpChiTiet.Controls.Add(Me.dtpNgay, 1, 2)
        Me.tlpChiTiet.Controls.Add(Me.lblDayMult, 0, 3)
        Me.tlpChiTiet.Controls.Add(Me.txtDayMult, 1, 3)
        Me.tlpChiTiet.Controls.Add(Me.lblNightMult, 0, 4)
        Me.tlpChiTiet.Controls.Add(Me.txtNightMult, 1, 4)
        Me.tlpChiTiet.Controls.Add(Me.lblOtMult, 0, 5)
        Me.tlpChiTiet.Controls.Add(Me.txtOtMult, 1, 5)
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
        'lblMaNgay
        '
        Me.lblMaNgay.AutoSize = True
        Me.lblMaNgay.Location = New System.Drawing.Point(3, 0)
        Me.lblMaNgay.Name = "lblMaNgay"
        Me.lblMaNgay.Size = New System.Drawing.Size(76, 23)
        Me.lblMaNgay.TabIndex = 0
        Me.lblMaNgay.Text = "Mã ngày"
        '
        'txtMaNgay
        '
        Me.txtMaNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMaNgay.Location = New System.Drawing.Point(123, 3)
        Me.txtMaNgay.Name = "txtMaNgay"
        Me.txtMaNgay.Size = New System.Drawing.Size(240, 30)
        Me.txtMaNgay.TabIndex = 1
        '
        'lblTenNgay
        '
        Me.lblTenNgay.AutoSize = True
        Me.lblTenNgay.Location = New System.Drawing.Point(3, 30)
        Me.lblTenNgay.Name = "lblTenNgay"
        Me.lblTenNgay.Size = New System.Drawing.Size(78, 23)
        Me.lblTenNgay.TabIndex = 2
        Me.lblTenNgay.Text = "Tên ngày"
        '
        'txtTenNgay
        '
        Me.txtTenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTenNgay.Location = New System.Drawing.Point(123, 33)
        Me.txtTenNgay.Name = "txtTenNgay"
        Me.txtTenNgay.Size = New System.Drawing.Size(240, 30)
        Me.txtTenNgay.TabIndex = 3
        '
        'lblNgay
        '
        Me.lblNgay.AutoSize = True
        Me.lblNgay.Location = New System.Drawing.Point(3, 60)
        Me.lblNgay.Name = "lblNgay"
        Me.lblNgay.Size = New System.Drawing.Size(50, 23)
        Me.lblNgay.TabIndex = 4
        Me.lblNgay.Text = "Ngày"
        '
        'dtpNgay
        '
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(123, 63)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(240, 30)
        Me.dtpNgay.TabIndex = 5
        '
        'lblDayMult
        '
        Me.lblDayMult.AutoSize = True
        Me.lblDayMult.Location = New System.Drawing.Point(3, 90)
        Me.lblDayMult.Name = "lblDayMult"
        Me.lblDayMult.Size = New System.Drawing.Size(95, 23)
        Me.lblDayMult.TabIndex = 6
        Me.lblDayMult.Text = "Hệ số ngày"
        '
        'txtDayMult
        '
        Me.txtDayMult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDayMult.Location = New System.Drawing.Point(123, 93)
        Me.txtDayMult.Name = "txtDayMult"
        Me.txtDayMult.Size = New System.Drawing.Size(240, 30)
        Me.txtDayMult.TabIndex = 7
        '
        'lblNightMult
        '
        Me.lblNightMult.AutoSize = True
        Me.lblNightMult.Location = New System.Drawing.Point(3, 120)
        Me.lblNightMult.Name = "lblNightMult"
        Me.lblNightMult.Size = New System.Drawing.Size(92, 23)
        Me.lblNightMult.TabIndex = 8
        Me.lblNightMult.Text = "Hệ số đêm"
        '
        'txtNightMult
        '
        Me.txtNightMult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNightMult.Location = New System.Drawing.Point(123, 123)
        Me.txtNightMult.Name = "txtNightMult"
        Me.txtNightMult.Size = New System.Drawing.Size(240, 30)
        Me.txtNightMult.TabIndex = 9
        '
        'lblOtMult
        '
        Me.lblOtMult.AutoSize = True
        Me.lblOtMult.Location = New System.Drawing.Point(3, 150)
        Me.lblOtMult.Name = "lblOtMult"
        Me.lblOtMult.Size = New System.Drawing.Size(98, 30)
        Me.lblOtMult.TabIndex = 10
        Me.lblOtMult.Text = "Hệ số tăng ca"
        '
        'txtOtMult
        '
        Me.txtOtMult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOtMult.Location = New System.Drawing.Point(123, 153)
        Me.txtOtMult.Name = "txtOtMult"
        Me.txtOtMult.Size = New System.Drawing.Size(240, 30)
        Me.txtOtMult.TabIndex = 11
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
        Me.lblChiTiet.Size = New System.Drawing.Size(156, 28)
        Me.lblChiTiet.TabIndex = 0
        Me.lblChiTiet.Text = "Chi tiết ngày lễ"
        '
        'frmNgayLe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.tlpChinh)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNgayLe"
        Me.Text = "Ngày lễ"
        Me.tlpChinh.ResumeLayout(False)
        Me.pnlTieuDe.ResumeLayout(False)
        Me.pnlTieuDe.PerformLayout()
        Me.pnlLoc.ResumeLayout(False)
        Me.pnlLoc.PerformLayout()
        Me.splitNoiDung.Panel1.ResumeLayout(False)
        Me.splitNoiDung.Panel2.ResumeLayout(False)
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitNoiDung.ResumeLayout(False)
        CType(Me.dgvNgayLe, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvNgayLe As DataGridView
    Friend WithEvents pnlChiTiet As Panel
    Friend WithEvents pnlNut As Panel
    Friend WithEvents btnHuy As Button
    Friend WithEvents btnLuu As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnSua As Button
    Friend WithEvents btnThem As Button
    Friend WithEvents tlpChiTiet As TableLayoutPanel
    Friend WithEvents lblMaNgay As Label
    Friend WithEvents txtMaNgay As TextBox
    Friend WithEvents lblTenNgay As Label
    Friend WithEvents txtTenNgay As TextBox
    Friend WithEvents lblNgay As Label
    Friend WithEvents dtpNgay As DateTimePicker
    Friend WithEvents lblDayMult As Label
    Friend WithEvents txtDayMult As TextBox
    Friend WithEvents lblNightMult As Label
    Friend WithEvents txtNightMult As TextBox
    Friend WithEvents lblOtMult As Label
    Friend WithEvents txtOtMult As TextBox
    Friend WithEvents lblTrangThai As Label
    Friend WithEvents txtTrangThai As TextBox
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents txtGhiChu As TextBox
    Friend WithEvents lblChiTiet As Label
End Class
