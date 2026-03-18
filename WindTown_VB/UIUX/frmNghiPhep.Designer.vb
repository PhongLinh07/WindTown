<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNghiPhep
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
        Me.dgvNghiPhep = New System.Windows.Forms.DataGridView()
        Me.pnlChiTiet = New System.Windows.Forms.Panel()
        Me.pnlNut = New System.Windows.Forms.Panel()
        Me.btnHuy = New System.Windows.Forms.Button()
        Me.btnLuu = New System.Windows.Forms.Button()
        Me.btnXoa = New System.Windows.Forms.Button()
        Me.btnSua = New System.Windows.Forms.Button()
        Me.btnThem = New System.Windows.Forms.Button()
        Me.tlpChiTiet = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMaNghiPhep = New System.Windows.Forms.Label()
        Me.txtMaNghiPhep = New System.Windows.Forms.TextBox()
        Me.lblEmployeeId = New System.Windows.Forms.Label()
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.lblApprovedId = New System.Windows.Forms.Label()
        Me.txtApprovedId = New System.Windows.Forms.TextBox()
        Me.lblLeaveCatId = New System.Windows.Forms.Label()
        Me.txtLeaveCatId = New System.Windows.Forms.TextBox()
        Me.lblTuNgay = New System.Windows.Forms.Label()
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblDenNgay = New System.Windows.Forms.Label()
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker()
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
        CType(Me.dgvNghiPhep, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblMoTa.Size = New System.Drawing.Size(273, 19)
        Me.lblMoTa.TabIndex = 1
        Me.lblMoTa.Text = "Theo dõi đơn nghỉ phép và trạng thái xử lý."
        '
        'lblTieuDe
        '
        Me.lblTieuDe.AutoSize = True
        Me.lblTieuDe.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTieuDe.Location = New System.Drawing.Point(24, 10)
        Me.lblTieuDe.Name = "lblTieuDe"
        Me.lblTieuDe.Size = New System.Drawing.Size(203, 30)
        Me.lblTieuDe.TabIndex = 0
        Me.lblTieuDe.Text = "Quản lý nghỉ phép"
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
        Me.txtTuKhoa.Size = New System.Drawing.Size(270, 25)
        Me.txtTuKhoa.TabIndex = 1
        '
        'lblTuKhoa
        '
        Me.lblTuKhoa.AutoSize = True
        Me.lblTuKhoa.Location = New System.Drawing.Point(26, 28)
        Me.lblTuKhoa.Name = "lblTuKhoa"
        Me.lblTuKhoa.Size = New System.Drawing.Size(58, 19)
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
        Me.splitNoiDung.Panel1.Controls.Add(Me.dgvNghiPhep)
        '
        'splitNoiDung.Panel2
        '
        Me.splitNoiDung.Panel2.Controls.Add(Me.pnlChiTiet)
        Me.splitNoiDung.Panel2MinSize = 320
        Me.splitNoiDung.Size = New System.Drawing.Size(1094, 504)
        Me.splitNoiDung.SplitterDistance = 700
        Me.splitNoiDung.TabIndex = 2
        '
        'dgvNghiPhep
        '
        Me.dgvNghiPhep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNghiPhep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNghiPhep.Location = New System.Drawing.Point(0, 0)
        Me.dgvNghiPhep.Name = "dgvNghiPhep"
        Me.dgvNghiPhep.RowHeadersWidth = 51
        Me.dgvNghiPhep.Size = New System.Drawing.Size(700, 504)
        Me.dgvNghiPhep.TabIndex = 0
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
        Me.tlpChiTiet.Controls.Add(Me.lblMaNghiPhep, 0, 0)
        Me.tlpChiTiet.Controls.Add(Me.txtMaNghiPhep, 1, 0)
        Me.tlpChiTiet.Controls.Add(Me.lblEmployeeId, 0, 1)
        Me.tlpChiTiet.Controls.Add(Me.txtEmployeeId, 1, 1)
        Me.tlpChiTiet.Controls.Add(Me.lblApprovedId, 0, 2)
        Me.tlpChiTiet.Controls.Add(Me.txtApprovedId, 1, 2)
        Me.tlpChiTiet.Controls.Add(Me.lblLeaveCatId, 0, 3)
        Me.tlpChiTiet.Controls.Add(Me.txtLeaveCatId, 1, 3)
        Me.tlpChiTiet.Controls.Add(Me.lblTuNgay, 0, 4)
        Me.tlpChiTiet.Controls.Add(Me.dtpTuNgay, 1, 4)
        Me.tlpChiTiet.Controls.Add(Me.lblDenNgay, 0, 5)
        Me.tlpChiTiet.Controls.Add(Me.dtpDenNgay, 1, 5)
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
        'lblMaNghiPhep
        '
        Me.lblMaNghiPhep.AutoSize = True
        Me.lblMaNghiPhep.Location = New System.Drawing.Point(3, 0)
        Me.lblMaNghiPhep.Name = "lblMaNghiPhep"
        Me.lblMaNghiPhep.Size = New System.Drawing.Size(95, 19)
        Me.lblMaNghiPhep.TabIndex = 0
        Me.lblMaNghiPhep.Text = "Mã nghỉ phép"
        '
        'txtMaNghiPhep
        '
        Me.txtMaNghiPhep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMaNghiPhep.Location = New System.Drawing.Point(123, 3)
        Me.txtMaNghiPhep.Name = "txtMaNghiPhep"
        Me.txtMaNghiPhep.Size = New System.Drawing.Size(240, 25)
        Me.txtMaNghiPhep.TabIndex = 1
        '
        'lblEmployeeId
        '
        Me.lblEmployeeId.AutoSize = True
        Me.lblEmployeeId.Location = New System.Drawing.Point(3, 30)
        Me.lblEmployeeId.Name = "lblEmployeeId"
        Me.lblEmployeeId.Size = New System.Drawing.Size(84, 19)
        Me.lblEmployeeId.TabIndex = 2
        Me.lblEmployeeId.Text = "Employee Id"
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmployeeId.Location = New System.Drawing.Point(123, 33)
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(240, 25)
        Me.txtEmployeeId.TabIndex = 3
        '
        'lblApprovedId
        '
        Me.lblApprovedId.AutoSize = True
        Me.lblApprovedId.Location = New System.Drawing.Point(3, 60)
        Me.lblApprovedId.Name = "lblApprovedId"
        Me.lblApprovedId.Size = New System.Drawing.Size(85, 19)
        Me.lblApprovedId.TabIndex = 4
        Me.lblApprovedId.Text = "Approved Id"
        '
        'txtApprovedId
        '
        Me.txtApprovedId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtApprovedId.Location = New System.Drawing.Point(123, 63)
        Me.txtApprovedId.Name = "txtApprovedId"
        Me.txtApprovedId.Size = New System.Drawing.Size(240, 25)
        Me.txtApprovedId.TabIndex = 5
        '
        'lblLeaveCatId
        '
        Me.lblLeaveCatId.AutoSize = True
        Me.lblLeaveCatId.Location = New System.Drawing.Point(3, 90)
        Me.lblLeaveCatId.Name = "lblLeaveCatId"
        Me.lblLeaveCatId.Size = New System.Drawing.Size(81, 19)
        Me.lblLeaveCatId.TabIndex = 6
        Me.lblLeaveCatId.Text = "LeaveCat Id"
        '
        'txtLeaveCatId
        '
        Me.txtLeaveCatId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLeaveCatId.Location = New System.Drawing.Point(123, 93)
        Me.txtLeaveCatId.Name = "txtLeaveCatId"
        Me.txtLeaveCatId.Size = New System.Drawing.Size(240, 25)
        Me.txtLeaveCatId.TabIndex = 7
        '
        'lblTuNgay
        '
        Me.lblTuNgay.AutoSize = True
        Me.lblTuNgay.Location = New System.Drawing.Point(3, 120)
        Me.lblTuNgay.Name = "lblTuNgay"
        Me.lblTuNgay.Size = New System.Drawing.Size(58, 19)
        Me.lblTuNgay.TabIndex = 8
        Me.lblTuNgay.Text = "Từ ngày"
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(123, 123)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(240, 25)
        Me.dtpTuNgay.TabIndex = 9
        '
        'lblDenNgay
        '
        Me.lblDenNgay.AutoSize = True
        Me.lblDenNgay.Location = New System.Drawing.Point(3, 150)
        Me.lblDenNgay.Name = "lblDenNgay"
        Me.lblDenNgay.Size = New System.Drawing.Size(68, 19)
        Me.lblDenNgay.TabIndex = 10
        Me.lblDenNgay.Text = "Đến ngày"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(123, 153)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(240, 25)
        Me.dtpDenNgay.TabIndex = 11
        '
        'lblTrangThai
        '
        Me.lblTrangThai.AutoSize = True
        Me.lblTrangThai.Location = New System.Drawing.Point(3, 180)
        Me.lblTrangThai.Name = "lblTrangThai"
        Me.lblTrangThai.Size = New System.Drawing.Size(70, 19)
        Me.lblTrangThai.TabIndex = 12
        Me.lblTrangThai.Text = "Trạng thái"
        '
        'txtTrangThai
        '
        Me.txtTrangThai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrangThai.Location = New System.Drawing.Point(123, 183)
        Me.txtTrangThai.Name = "txtTrangThai"
        Me.txtTrangThai.Size = New System.Drawing.Size(240, 25)
        Me.txtTrangThai.TabIndex = 13
        '
        'lblGhiChu
        '
        Me.lblGhiChu.AutoSize = True
        Me.lblGhiChu.Location = New System.Drawing.Point(3, 210)
        Me.lblGhiChu.Name = "lblGhiChu"
        Me.lblGhiChu.Size = New System.Drawing.Size(56, 19)
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
        Me.lblChiTiet.Size = New System.Drawing.Size(147, 21)
        Me.lblChiTiet.TabIndex = 0
        Me.lblChiTiet.Text = "Chi tiết nghỉ phép"
        '
        'frmNghiPhep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.tlpChinh)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNghiPhep"
        Me.Text = "Nghỉ phép"
        Me.tlpChinh.ResumeLayout(False)
        Me.pnlTieuDe.ResumeLayout(False)
        Me.pnlTieuDe.PerformLayout()
        Me.pnlLoc.ResumeLayout(False)
        Me.pnlLoc.PerformLayout()
        Me.splitNoiDung.Panel1.ResumeLayout(False)
        Me.splitNoiDung.Panel2.ResumeLayout(False)
        CType(Me.splitNoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitNoiDung.ResumeLayout(False)
        CType(Me.dgvNghiPhep, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvNghiPhep As DataGridView
    Friend WithEvents pnlChiTiet As Panel
    Friend WithEvents pnlNut As Panel
    Friend WithEvents btnHuy As Button
    Friend WithEvents btnLuu As Button
    Friend WithEvents btnXoa As Button
    Friend WithEvents btnSua As Button
    Friend WithEvents btnThem As Button
    Friend WithEvents tlpChiTiet As TableLayoutPanel
    Friend WithEvents lblMaNghiPhep As Label
    Friend WithEvents txtMaNghiPhep As TextBox
    Friend WithEvents lblEmployeeId As Label
    Friend WithEvents txtEmployeeId As TextBox
    Friend WithEvents lblApprovedId As Label
    Friend WithEvents txtApprovedId As TextBox
    Friend WithEvents lblLeaveCatId As Label
    Friend WithEvents txtLeaveCatId As TextBox
    Friend WithEvents lblTuNgay As Label
    Friend WithEvents dtpTuNgay As DateTimePicker
    Friend WithEvents lblDenNgay As Label
    Friend WithEvents dtpDenNgay As DateTimePicker
    Friend WithEvents lblTrangThai As Label
    Friend WithEvents txtTrangThai As TextBox
    Friend WithEvents lblGhiChu As Label
    Friend WithEvents txtGhiChu As TextBox
    Friend WithEvents lblChiTiet As Label
End Class
