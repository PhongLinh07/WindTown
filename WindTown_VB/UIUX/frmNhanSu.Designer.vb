<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNhanSu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tlpNhanSu = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlBoPhan = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnThemBoPhan = New System.Windows.Forms.Button()
        Me.txtTenCongTy = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sbmNhanSu = New WindTown_VB.SidebarMenu()
        Me.tvBoPhan = New System.Windows.Forms.TreeView()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnMoiNV = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnXuLyNhanh = New System.Windows.Forms.Button()
        Me.btnThemNV = New System.Windows.Forms.Button()
        Me.btnNhapXuatNV = New System.Windows.Forms.Button()
        Me.cbbxGioiTinh = New System.Windows.Forms.ComboBox()
        Me.cbbxTrangThai = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgvDSNhanVien = New System.Windows.Forms.DataGridView()
        Me.tlpNhanSu.SuspendLayout()
        Me.pnlBoPhan.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgvDSNhanVien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpNhanSu
        '
        Me.tlpNhanSu.ColumnCount = 3
        Me.tlpNhanSu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tlpNhanSu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320.0!))
        Me.tlpNhanSu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNhanSu.Controls.Add(Me.pnlBoPhan, 1, 1)
        Me.tlpNhanSu.Controls.Add(Me.sbmNhanSu, 0, 0)
        Me.tlpNhanSu.Controls.Add(Me.tvBoPhan, 1, 2)
        Me.tlpNhanSu.Controls.Add(Me.pnlHeader, 1, 0)
        Me.tlpNhanSu.Controls.Add(Me.Panel2, 2, 1)
        Me.tlpNhanSu.Controls.Add(Me.dtgvDSNhanVien, 2, 2)
        Me.tlpNhanSu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNhanSu.Location = New System.Drawing.Point(0, 0)
        Me.tlpNhanSu.Name = "tlpNhanSu"
        Me.tlpNhanSu.RowCount = 3
        Me.tlpNhanSu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpNhanSu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tlpNhanSu.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpNhanSu.Size = New System.Drawing.Size(1172, 643)
        Me.tlpNhanSu.TabIndex = 0
        '
        'pnlBoPhan
        '
        Me.pnlBoPhan.BackColor = System.Drawing.Color.White
        Me.pnlBoPhan.Controls.Add(Me.btnSearch)
        Me.pnlBoPhan.Controls.Add(Me.TextBox1)
        Me.pnlBoPhan.Controls.Add(Me.Button3)
        Me.pnlBoPhan.Controls.Add(Me.Button2)
        Me.pnlBoPhan.Controls.Add(Me.btnThemBoPhan)
        Me.pnlBoPhan.Controls.Add(Me.txtTenCongTy)
        Me.pnlBoPhan.Controls.Add(Me.Label2)
        Me.pnlBoPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBoPhan.Location = New System.Drawing.Point(223, 83)
        Me.pnlBoPhan.Name = "pnlBoPhan"
        Me.pnlBoPhan.Size = New System.Drawing.Size(314, 114)
        Me.pnlBoPhan.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Blue
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(224, 45)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 28)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Tìm"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(4, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(213, 29)
        Me.TextBox1.TabIndex = 6
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Lime
        Me.Button3.Location = New System.Drawing.Point(181, 79)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 32)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Sửa"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Location = New System.Drawing.Point(116, 79)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 32)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Thêm"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnThemBoPhan
        '
        Me.btnThemBoPhan.FlatAppearance.BorderSize = 0
        Me.btnThemBoPhan.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemBoPhan.ForeColor = System.Drawing.Color.Red
        Me.btnThemBoPhan.Location = New System.Drawing.Point(247, 79)
        Me.btnThemBoPhan.Name = "btnThemBoPhan"
        Me.btnThemBoPhan.Size = New System.Drawing.Size(53, 32)
        Me.btnThemBoPhan.TabIndex = 3
        Me.btnThemBoPhan.Text = "Xóa"
        Me.btnThemBoPhan.UseVisualStyleBackColor = True
        '
        'txtTenCongTy
        '
        Me.txtTenCongTy.AutoSize = True
        Me.txtTenCongTy.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenCongTy.Location = New System.Drawing.Point(2, 83)
        Me.txtTenCongTy.Name = "txtTenCongTy"
        Me.txtTenCongTy.Size = New System.Drawing.Size(111, 24)
        Me.txtTenCongTy.TabIndex = 2
        Me.txtTenCongTy.Text = "Tên công ty"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bộ phận"
        '
        'sbmNhanSu
        '
        Me.sbmNhanSu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sbmNhanSu.Location = New System.Drawing.Point(4, 4)
        Me.sbmNhanSu.Margin = New System.Windows.Forms.Padding(4)
        Me.sbmNhanSu.Name = "sbmNhanSu"
        Me.tlpNhanSu.SetRowSpan(Me.sbmNhanSu, 3)
        Me.sbmNhanSu.Size = New System.Drawing.Size(212, 645)
        Me.sbmNhanSu.TabIndex = 0
        '
        'tvBoPhan
        '
        Me.tvBoPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvBoPhan.Location = New System.Drawing.Point(223, 203)
        Me.tvBoPhan.Name = "tvBoPhan"
        Me.tvBoPhan.Size = New System.Drawing.Size(314, 447)
        Me.tvBoPhan.TabIndex = 1
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.tlpNhanSu.SetColumnSpan(Me.pnlHeader, 2)
        Me.pnlHeader.Controls.Add(Me.btnMoiNV)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(223, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(946, 74)
        Me.pnlHeader.TabIndex = 1
        '
        'btnMoiNV
        '
        Me.btnMoiNV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoiNV.BackColor = System.Drawing.Color.LimeGreen
        Me.btnMoiNV.FlatAppearance.BorderSize = 0
        Me.btnMoiNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMoiNV.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoiNV.ForeColor = System.Drawing.Color.White
        Me.btnMoiNV.Location = New System.Drawing.Point(752, 26)
        Me.btnMoiNV.Name = "btnMoiNV"
        Me.btnMoiNV.Size = New System.Drawing.Size(177, 31)
        Me.btnMoiNV.TabIndex = 1
        Me.btnMoiNV.Text = "+ Mời thành viên"
        Me.btnMoiNV.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nhân sự"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnXuLyNhanh)
        Me.Panel2.Controls.Add(Me.btnThemNV)
        Me.Panel2.Controls.Add(Me.btnNhapXuatNV)
        Me.Panel2.Controls.Add(Me.cbbxGioiTinh)
        Me.Panel2.Controls.Add(Me.cbbxTrangThai)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(543, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(626, 114)
        Me.Panel2.TabIndex = 3
        '
        'btnXuLyNhanh
        '
        Me.btnXuLyNhanh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnXuLyNhanh.BackColor = System.Drawing.Color.LimeGreen
        Me.btnXuLyNhanh.FlatAppearance.BorderSize = 0
        Me.btnXuLyNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXuLyNhanh.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXuLyNhanh.ForeColor = System.Drawing.Color.White
        Me.btnXuLyNhanh.Location = New System.Drawing.Point(298, 55)
        Me.btnXuLyNhanh.Name = "btnXuLyNhanh"
        Me.btnXuLyNhanh.Size = New System.Drawing.Size(128, 31)
        Me.btnXuLyNhanh.TabIndex = 8
        Me.btnXuLyNhanh.Text = "Xử lý nhanh"
        Me.btnXuLyNhanh.UseVisualStyleBackColor = False
        Me.btnXuLyNhanh.Visible = False
        '
        'btnThemNV
        '
        Me.btnThemNV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnThemNV.BackColor = System.Drawing.Color.LimeGreen
        Me.btnThemNV.FlatAppearance.BorderSize = 0
        Me.btnThemNV.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThemNV.ForeColor = System.Drawing.Color.White
        Me.btnThemNV.Location = New System.Drawing.Point(467, 17)
        Me.btnThemNV.Name = "btnThemNV"
        Me.btnThemNV.Size = New System.Drawing.Size(156, 32)
        Me.btnThemNV.TabIndex = 7
        Me.btnThemNV.Text = "Thêm nhân viên"
        Me.btnThemNV.UseVisualStyleBackColor = False
        '
        'btnNhapXuatNV
        '
        Me.btnNhapXuatNV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNhapXuatNV.BackColor = System.Drawing.Color.White
        Me.btnNhapXuatNV.FlatAppearance.BorderSize = 0
        Me.btnNhapXuatNV.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNhapXuatNV.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.btnNhapXuatNV.Location = New System.Drawing.Point(432, 55)
        Me.btnNhapXuatNV.Name = "btnNhapXuatNV"
        Me.btnNhapXuatNV.Size = New System.Drawing.Size(194, 32)
        Me.btnNhapXuatNV.TabIndex = 6
        Me.btnNhapXuatNV.Text = "Nhập xuất danh sách"
        Me.btnNhapXuatNV.UseVisualStyleBackColor = False
        '
        'cbbxGioiTinh
        '
        Me.cbbxGioiTinh.FormattingEnabled = True
        Me.cbbxGioiTinh.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cbbxGioiTinh.Location = New System.Drawing.Point(156, 57)
        Me.cbbxGioiTinh.Name = "cbbxGioiTinh"
        Me.cbbxGioiTinh.Size = New System.Drawing.Size(121, 31)
        Me.cbbxGioiTinh.TabIndex = 5
        Me.cbbxGioiTinh.Text = "Giới tính"
        '
        'cbbxTrangThai
        '
        Me.cbbxTrangThai.FormattingEnabled = True
        Me.cbbxTrangThai.Items.AddRange(New Object() {"Đang làm việc", "Đã nghỉ ", "Chưa kích hoạt"})
        Me.cbbxTrangThai.Location = New System.Drawing.Point(29, 57)
        Me.cbbxTrangThai.Name = "cbbxTrangThai"
        Me.cbbxTrangThai.Size = New System.Drawing.Size(121, 31)
        Me.cbbxTrangThai.TabIndex = 4
        Me.cbbxTrangThai.Text = "Trạng thái"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tên công ty"
        '
        'dtgvDSNhanVien
        '
        Me.dtgvDSNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgvDSNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgvDSNhanVien.Location = New System.Drawing.Point(543, 203)
        Me.dtgvDSNhanVien.Name = "dtgvDSNhanVien"
        Me.dtgvDSNhanVien.RowHeadersVisible = False
        Me.dtgvDSNhanVien.RowHeadersWidth = 51
        Me.dtgvDSNhanVien.RowTemplate.Height = 24
        Me.dtgvDSNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dtgvDSNhanVien.Size = New System.Drawing.Size(626, 447)
        Me.dtgvDSNhanVien.TabIndex = 4
        '
        'frmNhanSu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1172, 643)
        Me.Controls.Add(Me.tlpNhanSu)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmNhanSu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nhân sự"
        Me.tlpNhanSu.ResumeLayout(False)
        Me.pnlBoPhan.ResumeLayout(False)
        Me.pnlBoPhan.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtgvDSNhanVien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpNhanSu As TableLayoutPanel
    Friend WithEvents sbmNhanSu As SidebarMenu
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnMoiNV As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tvBoPhan As TreeView
    Friend WithEvents pnlBoPhan As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnThemBoPhan As Button
    Friend WithEvents txtTenCongTy As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnNhapXuatNV As Button
    Friend WithEvents cbbxGioiTinh As ComboBox
    Friend WithEvents cbbxTrangThai As ComboBox
    Friend WithEvents btnThemNV As Button
    Friend WithEvents dtgvDSNhanVien As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnXuLyNhanh As Button
End Class
