<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTinhLuong
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTinhLuong))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlHanhDong = New System.Windows.Forms.Panel()
        Me.btnTaoBangLuong = New System.Windows.Forms.Button()
        Me.btnDongBangLuong = New System.Windows.Forms.Button()
        Me.btnBaoCao = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnLamMoi = New System.Windows.Forms.Button()
        Me.btnTimKiem = New System.Windows.Forms.Button()
        Me.txtTuKhoa = New System.Windows.Forms.TextBox()
        Me.cbbKyLuong = New System.Windows.Forms.ComboBox()
        Me.cbbTrangThai = New System.Windows.Forms.ComboBox()
        Me.cbbViTri = New System.Windows.Forms.ComboBox()
        Me.cbbThoiGian = New System.Windows.Forms.ComboBox()
        Me.dtTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.dtDenNgay = New System.Windows.Forms.DateTimePicker()
        Me.cbbThoiGianNhanh = New System.Windows.Forms.ComboBox()
        Me.lblKyLuong = New System.Windows.Forms.Label()
        Me.lblTrangThai = New System.Windows.Forms.Label()
        Me.lblViTri = New System.Windows.Forms.Label()
        Me.lblTuKhoa = New System.Windows.Forms.Label()
        Me.lblThoiGian = New System.Windows.Forms.Label()
        Me.lblLocNhanh = New System.Windows.Forms.Label()
        Me.dgvBangLuong = New System.Windows.Forms.DataGridView()
        Me.cmsBaoCao = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBaoCaoLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBaoCaoChon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBaoCaoTongHop = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlHeader.SuspendLayout()
        Me.pnlHanhDong.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvBangLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsBaoCao.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlHanhDong)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1040, 80)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlHanhDong
        '
        Me.pnlHanhDong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHanhDong.BackColor = System.Drawing.Color.Transparent
        Me.pnlHanhDong.Controls.Add(Me.btnTaoBangLuong)
        Me.pnlHanhDong.Controls.Add(Me.btnDongBangLuong)
        Me.pnlHanhDong.Controls.Add(Me.btnBaoCao)
        Me.pnlHanhDong.Location = New System.Drawing.Point(590, 20)
        Me.pnlHanhDong.Name = "pnlHanhDong"
        Me.pnlHanhDong.Size = New System.Drawing.Size(430, 44)
        Me.pnlHanhDong.TabIndex = 1
        '
        'btnTaoBangLuong
        '
        Me.btnTaoBangLuong.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnTaoBangLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaoBangLuong.ForeColor = System.Drawing.Color.White
        Me.btnTaoBangLuong.Location = New System.Drawing.Point(0, 6)
        Me.btnTaoBangLuong.Name = "btnTaoBangLuong"
        Me.btnTaoBangLuong.Size = New System.Drawing.Size(130, 33)
        Me.btnTaoBangLuong.TabIndex = 0
        Me.btnTaoBangLuong.Text = "Tạo bảng lương"
        Me.btnTaoBangLuong.UseVisualStyleBackColor = False
        '
        'btnDongBangLuong
        '
        Me.btnDongBangLuong.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDongBangLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDongBangLuong.ForeColor = System.Drawing.Color.White
        Me.btnDongBangLuong.Location = New System.Drawing.Point(140, 6)
        Me.btnDongBangLuong.Name = "btnDongBangLuong"
        Me.btnDongBangLuong.Size = New System.Drawing.Size(130, 33)
        Me.btnDongBangLuong.TabIndex = 1
        Me.btnDongBangLuong.Text = "Đóng bảng lương"
        Me.btnDongBangLuong.UseVisualStyleBackColor = False
        '
        'btnBaoCao
        '
        Me.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaoCao.ForeColor = System.Drawing.Color.White
        Me.btnBaoCao.Location = New System.Drawing.Point(280, 6)
        Me.btnBaoCao.Name = "btnBaoCao"
        Me.btnBaoCao.Size = New System.Drawing.Size(130, 33)
        Me.btnBaoCao.TabIndex = 2
        Me.btnBaoCao.Text = "Báo cáo"
        Me.btnBaoCao.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 31)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tính lương"
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.White
        Me.pnlFilters.Controls.Add(Me.btnLamMoi)
        Me.pnlFilters.Controls.Add(Me.btnTimKiem)
        Me.pnlFilters.Controls.Add(Me.txtTuKhoa)
        Me.pnlFilters.Controls.Add(Me.cbbKyLuong)
        Me.pnlFilters.Controls.Add(Me.cbbTrangThai)
        Me.pnlFilters.Controls.Add(Me.cbbViTri)
        Me.pnlFilters.Controls.Add(Me.cbbThoiGian)
        Me.pnlFilters.Controls.Add(Me.dtTuNgay)
        Me.pnlFilters.Controls.Add(Me.dtDenNgay)
        Me.pnlFilters.Controls.Add(Me.cbbThoiGianNhanh)
        Me.pnlFilters.Controls.Add(Me.lblKyLuong)
        Me.pnlFilters.Controls.Add(Me.lblTrangThai)
        Me.pnlFilters.Controls.Add(Me.lblViTri)
        Me.pnlFilters.Controls.Add(Me.lblTuKhoa)
        Me.pnlFilters.Controls.Add(Me.lblThoiGian)
        Me.pnlFilters.Controls.Add(Me.lblLocNhanh)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 80)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1040, 120)
        Me.pnlFilters.TabIndex = 1
        '
        'btnLamMoi
        '
        Me.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLamMoi.ForeColor = System.Drawing.Color.White
        Me.btnLamMoi.Location = New System.Drawing.Point(880, 62)
        Me.btnLamMoi.Name = "btnLamMoi"
        Me.btnLamMoi.Size = New System.Drawing.Size(120, 33)
        Me.btnLamMoi.TabIndex = 15
        Me.btnLamMoi.Text = "Làm mới"
        Me.btnLamMoi.UseVisualStyleBackColor = False
        '
        'btnTimKiem
        '
        Me.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimKiem.ForeColor = System.Drawing.Color.White
        Me.btnTimKiem.Location = New System.Drawing.Point(880, 18)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(120, 33)
        Me.btnTimKiem.TabIndex = 14
        Me.btnTimKiem.Text = "Tìm kiếm"
        Me.btnTimKiem.UseVisualStyleBackColor = False
        '
        'txtTuKhoa
        '
        Me.txtTuKhoa.Location = New System.Drawing.Point(120, 18)
        Me.txtTuKhoa.Name = "txtTuKhoa"
        Me.txtTuKhoa.Size = New System.Drawing.Size(240, 29)
        Me.txtTuKhoa.TabIndex = 0
        '
        'cbbKyLuong
        '
        Me.cbbKyLuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbKyLuong.FormattingEnabled = True
        Me.cbbKyLuong.Location = New System.Drawing.Point(520, 18)
        Me.cbbKyLuong.Name = "cbbKyLuong"
        Me.cbbKyLuong.Size = New System.Drawing.Size(200, 31)
        Me.cbbKyLuong.TabIndex = 2
        '
        'cbbTrangThai
        '
        Me.cbbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbTrangThai.FormattingEnabled = True
        Me.cbbTrangThai.Location = New System.Drawing.Point(520, 92)
        Me.cbbTrangThai.Name = "cbbTrangThai"
        Me.cbbTrangThai.Size = New System.Drawing.Size(200, 31)
        Me.cbbTrangThai.TabIndex = 3
        '
        'cbbViTri
        '
        Me.cbbViTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbViTri.FormattingEnabled = True
        Me.cbbViTri.Location = New System.Drawing.Point(520, 62)
        Me.cbbViTri.Name = "cbbViTri"
        Me.cbbViTri.Size = New System.Drawing.Size(200, 31)
        Me.cbbViTri.TabIndex = 6
        '
        'cbbThoiGian
        '
        Me.cbbThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbThoiGian.FormattingEnabled = True
        Me.cbbThoiGian.Location = New System.Drawing.Point(120, 62)
        Me.cbbThoiGian.Name = "cbbThoiGian"
        Me.cbbThoiGian.Size = New System.Drawing.Size(200, 31)
        Me.cbbThoiGian.TabIndex = 4
        '
        'dtTuNgay
        '
        Me.dtTuNgay.Location = New System.Drawing.Point(330, 62)
        Me.dtTuNgay.Name = "dtTuNgay"
        Me.dtTuNgay.Size = New System.Drawing.Size(180, 29)
        Me.dtTuNgay.TabIndex = 5
        '
        'dtDenNgay
        '
        Me.dtDenNgay.Location = New System.Drawing.Point(330, 92)
        Me.dtDenNgay.Name = "dtDenNgay"
        Me.dtDenNgay.Size = New System.Drawing.Size(180, 29)
        Me.dtDenNgay.TabIndex = 6
        '
        'cbbThoiGianNhanh
        '
        Me.cbbThoiGianNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbThoiGianNhanh.FormattingEnabled = True
        Me.cbbThoiGianNhanh.Location = New System.Drawing.Point(120, 92)
        Me.cbbThoiGianNhanh.Name = "cbbThoiGianNhanh"
        Me.cbbThoiGianNhanh.Size = New System.Drawing.Size(200, 31)
        Me.cbbThoiGianNhanh.TabIndex = 7
        '
        'lblKyLuong
        '
        Me.lblKyLuong.AutoSize = True
        Me.lblKyLuong.Location = New System.Drawing.Point(400, 22)
        Me.lblKyLuong.Name = "lblKyLuong"
        Me.lblKyLuong.Size = New System.Drawing.Size(79, 23)
        Me.lblKyLuong.TabIndex = 9
        Me.lblKyLuong.Text = "Kỳ lương"
        '
        'lblTrangThai
        '
        Me.lblTrangThai.AutoSize = True
        Me.lblTrangThai.Location = New System.Drawing.Point(400, 96)
        Me.lblTrangThai.Name = "lblTrangThai"
        Me.lblTrangThai.Size = New System.Drawing.Size(89, 23)
        Me.lblTrangThai.TabIndex = 10
        Me.lblTrangThai.Text = "Trạng thái"
        '
        'lblViTri
        '
        Me.lblViTri.AutoSize = True
        Me.lblViTri.Location = New System.Drawing.Point(400, 66)
        Me.lblViTri.Name = "lblViTri"
        Me.lblViTri.Size = New System.Drawing.Size(55, 23)
        Me.lblViTri.TabIndex = 11
        Me.lblViTri.Text = "V? tr?"
        '
        'lblTuKhoa
        '
        Me.lblTuKhoa.AutoSize = True
        Me.lblTuKhoa.Location = New System.Drawing.Point(12, 22)
        Me.lblTuKhoa.Name = "lblTuKhoa"
        Me.lblTuKhoa.Size = New System.Drawing.Size(73, 23)
        Me.lblTuKhoa.TabIndex = 12
        Me.lblTuKhoa.Text = "Từ khóa"
        '
        'lblThoiGian
        '
        Me.lblThoiGian.AutoSize = True
        Me.lblThoiGian.Location = New System.Drawing.Point(12, 66)
        Me.lblThoiGian.Name = "lblThoiGian"
        Me.lblThoiGian.Size = New System.Drawing.Size(84, 23)
        Me.lblThoiGian.TabIndex = 13
        Me.lblThoiGian.Text = "Thời gian"
        '
        'lblLocNhanh
        '
        Me.lblLocNhanh.AutoSize = True
        Me.lblLocNhanh.Location = New System.Drawing.Point(12, 96)
        Me.lblLocNhanh.Name = "lblLocNhanh"
        Me.lblLocNhanh.Size = New System.Drawing.Size(91, 23)
        Me.lblLocNhanh.TabIndex = 16
        Me.lblLocNhanh.Text = "Lọc nhanh"
        '
        'dgvBangLuong
        '
        Me.dgvBangLuong.BackgroundColor = System.Drawing.Color.White
        Me.dgvBangLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBangLuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBangLuong.Location = New System.Drawing.Point(0, 200)
        Me.dgvBangLuong.Name = "dgvBangLuong"
        Me.dgvBangLuong.RowHeadersWidth = 51
        Me.dgvBangLuong.RowTemplate.Height = 24
        Me.dgvBangLuong.Size = New System.Drawing.Size(1040, 465)
        Me.dgvBangLuong.TabIndex = 2
        '
        'cmsBaoCao
        '
        Me.cmsBaoCao.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsBaoCao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBaoCaoLoc, Me.mnuBaoCaoChon, Me.mnuBaoCaoTongHop})
        Me.cmsBaoCao.Name = "cmsBaoCao"
        Me.cmsBaoCao.Size = New System.Drawing.Size(235, 76)
        '
        'mnuBaoCaoLoc
        '
        Me.mnuBaoCaoLoc.Name = "mnuBaoCaoLoc"
        Me.mnuBaoCaoLoc.Size = New System.Drawing.Size(234, 24)
        Me.mnuBaoCaoLoc.Text = "Xuất theo bản lọc hiện tại"
        '
        'mnuBaoCaoChon
        '
        Me.mnuBaoCaoChon.Name = "mnuBaoCaoChon"
        Me.mnuBaoCaoChon.Size = New System.Drawing.Size(234, 24)
        Me.mnuBaoCaoChon.Text = "Xuất theo lựa chọn"
        '
        'mnuBaoCaoTongHop
        '
        Me.mnuBaoCaoTongHop.Name = "mnuBaoCaoTongHop"
        Me.mnuBaoCaoTongHop.Size = New System.Drawing.Size(234, 24)
        Me.mnuBaoCaoTongHop.Text = "Tổng hợp báo cáo"
        '
        'frmTinhLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 665)
        Me.Controls.Add(Me.dgvBangLuong)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTinhLuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tính lương"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlHanhDong.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvBangLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsBaoCao.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlHanhDong As Panel
    Friend WithEvents btnTaoBangLuong As Button
    Friend WithEvents btnDongBangLuong As Button
    Friend WithEvents btnBaoCao As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnLamMoi As Button
    Friend WithEvents btnTimKiem As Button
    Friend WithEvents txtTuKhoa As TextBox
    Friend WithEvents cbbKyLuong As ComboBox
    Friend WithEvents cbbTrangThai As ComboBox
    Friend WithEvents cbbViTri As ComboBox
    Friend WithEvents cbbThoiGian As ComboBox
    Friend WithEvents dtTuNgay As DateTimePicker
    Friend WithEvents dtDenNgay As DateTimePicker
    Friend WithEvents cbbThoiGianNhanh As ComboBox
    Friend WithEvents lblKyLuong As Label
    Friend WithEvents lblTrangThai As Label
    Friend WithEvents lblViTri As Label
    Friend WithEvents lblTuKhoa As Label
    Friend WithEvents lblThoiGian As Label
    Friend WithEvents lblLocNhanh As Label
    Friend WithEvents dgvBangLuong As DataGridView
    Friend WithEvents cmsBaoCao As ContextMenuStrip
    Friend WithEvents mnuBaoCaoLoc As ToolStripMenuItem
    Friend WithEvents mnuBaoCaoChon As ToolStripMenuItem
    Friend WithEvents mnuBaoCaoTongHop As ToolStripMenuItem
End Class


