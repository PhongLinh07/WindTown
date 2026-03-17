<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKyLuong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKyLuong))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlHanhDong = New System.Windows.Forms.Panel()
        Me.btnThemKyLuong = New System.Windows.Forms.Button()
        Me.btnSuaKyLuong = New System.Windows.Forms.Button()
        Me.btnXoaKyLuong = New System.Windows.Forms.Button()
        Me.btnXuatBaoCao = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnLamMoi = New System.Windows.Forms.Button()
        Me.btnTimKiem = New System.Windows.Forms.Button()
        Me.txtTuKhoa = New System.Windows.Forms.TextBox()
        Me.cbbTrangThai = New System.Windows.Forms.ComboBox()
        Me.cbbThoiGian = New System.Windows.Forms.ComboBox()
        Me.dtTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.dtDenNgay = New System.Windows.Forms.DateTimePicker()
        Me.lblTrangThai = New System.Windows.Forms.Label()
        Me.lblThoiGian = New System.Windows.Forms.Label()
        Me.lblTuKhoa = New System.Windows.Forms.Label()
        Me.dgvKyLuong = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        Me.pnlHanhDong.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvKyLuong, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHanhDong.Controls.Add(Me.btnThemKyLuong)
        Me.pnlHanhDong.Controls.Add(Me.btnSuaKyLuong)
        Me.pnlHanhDong.Controls.Add(Me.btnXoaKyLuong)
        Me.pnlHanhDong.Controls.Add(Me.btnXuatBaoCao)
        Me.pnlHanhDong.Location = New System.Drawing.Point(520, 20)
        Me.pnlHanhDong.Name = "pnlHanhDong"
        Me.pnlHanhDong.Size = New System.Drawing.Size(500, 40)
        Me.pnlHanhDong.TabIndex = 1
        '
        'btnThemKyLuong
        '
        Me.btnThemKyLuong.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnThemKyLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThemKyLuong.ForeColor = System.Drawing.Color.White
        Me.btnThemKyLuong.Location = New System.Drawing.Point(0, 6)
        Me.btnThemKyLuong.Name = "btnThemKyLuong"
        Me.btnThemKyLuong.Size = New System.Drawing.Size(110, 30)
        Me.btnThemKyLuong.TabIndex = 0
        Me.btnThemKyLuong.Text = "Thêm"
        Me.btnThemKyLuong.UseVisualStyleBackColor = False
        '
        'btnSuaKyLuong
        '
        Me.btnSuaKyLuong.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.btnSuaKyLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuaKyLuong.ForeColor = System.Drawing.Color.Black
        Me.btnSuaKyLuong.Location = New System.Drawing.Point(125, 6)
        Me.btnSuaKyLuong.Name = "btnSuaKyLuong"
        Me.btnSuaKyLuong.Size = New System.Drawing.Size(110, 30)
        Me.btnSuaKyLuong.TabIndex = 1
        Me.btnSuaKyLuong.Text = "Sửa"
        Me.btnSuaKyLuong.UseVisualStyleBackColor = False
        '
        'btnXoaKyLuong
        '
        Me.btnXoaKyLuong.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnXoaKyLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXoaKyLuong.ForeColor = System.Drawing.Color.White
        Me.btnXoaKyLuong.Location = New System.Drawing.Point(250, 6)
        Me.btnXoaKyLuong.Name = "btnXoaKyLuong"
        Me.btnXoaKyLuong.Size = New System.Drawing.Size(110, 30)
        Me.btnXoaKyLuong.TabIndex = 2
        Me.btnXoaKyLuong.Text = "Xóa"
        Me.btnXoaKyLuong.UseVisualStyleBackColor = False
        '
        'btnXuatBaoCao
        '
        Me.btnXuatBaoCao.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnXuatBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXuatBaoCao.ForeColor = System.Drawing.Color.White
        Me.btnXuatBaoCao.Location = New System.Drawing.Point(375, 6)
        Me.btnXuatBaoCao.Name = "btnXuatBaoCao"
        Me.btnXuatBaoCao.Size = New System.Drawing.Size(110, 30)
        Me.btnXuatBaoCao.TabIndex = 3
        Me.btnXuatBaoCao.Text = "Xuất báo cáo"
        Me.btnXuatBaoCao.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 31)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Kỳ lương"
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.White
        Me.pnlFilters.Controls.Add(Me.btnLamMoi)
        Me.pnlFilters.Controls.Add(Me.btnTimKiem)
        Me.pnlFilters.Controls.Add(Me.txtTuKhoa)
        Me.pnlFilters.Controls.Add(Me.cbbTrangThai)
        Me.pnlFilters.Controls.Add(Me.cbbThoiGian)
        Me.pnlFilters.Controls.Add(Me.dtTuNgay)
        Me.pnlFilters.Controls.Add(Me.dtDenNgay)
        Me.pnlFilters.Controls.Add(Me.lblTrangThai)
        Me.pnlFilters.Controls.Add(Me.lblThoiGian)
        Me.pnlFilters.Controls.Add(Me.lblTuKhoa)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 80)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1040, 90)
        Me.pnlFilters.TabIndex = 1
        '
        'btnLamMoi
        '
        Me.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLamMoi.ForeColor = System.Drawing.Color.White
        Me.btnLamMoi.Location = New System.Drawing.Point(880, 50)
        Me.btnLamMoi.Name = "btnLamMoi"
        Me.btnLamMoi.Size = New System.Drawing.Size(120, 30)
        Me.btnLamMoi.TabIndex = 9
        Me.btnLamMoi.Text = "Làm mới"
        Me.btnLamMoi.UseVisualStyleBackColor = False
        '
        'btnTimKiem
        '
        Me.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimKiem.ForeColor = System.Drawing.Color.White
        Me.btnTimKiem.Location = New System.Drawing.Point(880, 14)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(120, 30)
        Me.btnTimKiem.TabIndex = 8
        Me.btnTimKiem.Text = "Tìm kiếm"
        Me.btnTimKiem.UseVisualStyleBackColor = False
        '
        'txtTuKhoa
        '
        Me.txtTuKhoa.Location = New System.Drawing.Point(120, 14)
        Me.txtTuKhoa.Name = "txtTuKhoa"
        Me.txtTuKhoa.Size = New System.Drawing.Size(300, 29)
        Me.txtTuKhoa.TabIndex = 0
        '
        'cbbTrangThai
        '
        Me.cbbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbTrangThai.FormattingEnabled = True
        Me.cbbTrangThai.Location = New System.Drawing.Point(560, 14)
        Me.cbbTrangThai.Name = "cbbTrangThai"
        Me.cbbTrangThai.Size = New System.Drawing.Size(200, 31)
        Me.cbbTrangThai.TabIndex = 2
        '
        'cbbThoiGian
        '
        Me.cbbThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbThoiGian.FormattingEnabled = True
        Me.cbbThoiGian.Location = New System.Drawing.Point(120, 50)
        Me.cbbThoiGian.Name = "cbbThoiGian"
        Me.cbbThoiGian.Size = New System.Drawing.Size(200, 31)
        Me.cbbThoiGian.TabIndex = 3
        '
        'dtTuNgay
        '
        Me.dtTuNgay.Location = New System.Drawing.Point(330, 51)
        Me.dtTuNgay.Name = "dtTuNgay"
        Me.dtTuNgay.Size = New System.Drawing.Size(205, 29)
        Me.dtTuNgay.TabIndex = 4
        '
        'dtDenNgay
        '
        Me.dtDenNgay.Location = New System.Drawing.Point(584, 51)
        Me.dtDenNgay.Name = "dtDenNgay"
        Me.dtDenNgay.Size = New System.Drawing.Size(205, 29)
        Me.dtDenNgay.TabIndex = 5
        '
        'lblTrangThai
        '
        Me.lblTrangThai.AutoSize = True
        Me.lblTrangThai.Location = New System.Drawing.Point(460, 18)
        Me.lblTrangThai.Name = "lblTrangThai"
        Me.lblTrangThai.Size = New System.Drawing.Size(91, 23)
        Me.lblTrangThai.TabIndex = 7
        Me.lblTrangThai.Text = "Trạng thái"
        '
        'lblThoiGian
        '
        Me.lblThoiGian.AutoSize = True
        Me.lblThoiGian.Location = New System.Drawing.Point(12, 54)
        Me.lblThoiGian.Name = "lblThoiGian"
        Me.lblThoiGian.Size = New System.Drawing.Size(84, 23)
        Me.lblThoiGian.TabIndex = 6
        Me.lblThoiGian.Text = "Thời gian"
        '
        'lblTuKhoa
        '
        Me.lblTuKhoa.AutoSize = True
        Me.lblTuKhoa.Location = New System.Drawing.Point(12, 18)
        Me.lblTuKhoa.Name = "lblTuKhoa"
        Me.lblTuKhoa.Size = New System.Drawing.Size(73, 23)
        Me.lblTuKhoa.TabIndex = 5
        Me.lblTuKhoa.Text = "Từ khóa"
        '
        'dgvKyLuong
        '
        Me.dgvKyLuong.BackgroundColor = System.Drawing.Color.White
        Me.dgvKyLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKyLuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKyLuong.Location = New System.Drawing.Point(0, 170)
        Me.dgvKyLuong.Name = "dgvKyLuong"
        Me.dgvKyLuong.RowHeadersWidth = 51
        Me.dgvKyLuong.RowTemplate.Height = 24
        Me.dgvKyLuong.Size = New System.Drawing.Size(1040, 495)
        Me.dgvKyLuong.TabIndex = 2
        '
        'frmKyLuong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 665)
        Me.Controls.Add(Me.dgvKyLuong)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKyLuong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kỳ lương"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlHanhDong.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvKyLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlHanhDong As Panel
    Friend WithEvents btnThemKyLuong As Button
    Friend WithEvents btnSuaKyLuong As Button
    Friend WithEvents btnXoaKyLuong As Button
    Friend WithEvents btnXuatBaoCao As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnLamMoi As Button
    Friend WithEvents btnTimKiem As Button
    Friend WithEvents txtTuKhoa As TextBox
    Friend WithEvents cbbTrangThai As ComboBox
    Friend WithEvents cbbThoiGian As ComboBox
    Friend WithEvents dtTuNgay As DateTimePicker
    Friend WithEvents dtDenNgay As DateTimePicker
    Friend WithEvents lblTrangThai As Label
    Friend WithEvents lblThoiGian As Label
    Friend WithEvents lblTuKhoa As Label
    Friend WithEvents dgvKyLuong As DataGridView
End Class

