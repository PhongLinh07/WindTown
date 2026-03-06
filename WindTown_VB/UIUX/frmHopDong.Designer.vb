<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHopDong
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
        Me.tlpnlMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpDashboard = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnThemHD = New System.Windows.Forms.Button()
        Me.dtpkDenNgay = New System.Windows.Forms.DateTimePicker()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dtpkTuNgay = New System.Windows.Forms.DateTimePicker()
        Me.cbbxCongTy = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbxSearch = New System.Windows.Forms.TextBox()
        Me.cbbxThoiGianHD = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cbbxHopDong = New System.Windows.Forms.ComboBox()
        Me.cbbxTrangThai = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbbxLoaiHopDong = New System.Windows.Forms.ComboBox()
        Me.cbbxBoPhan = New System.Windows.Forms.ComboBox()
        Me.dtgvDSHopDong = New System.Windows.Forms.DataGridView()
        Me.SidebarMenu1 = New WindTown_VB.SidebarMenu()
        Me.tlpnlMain.SuspendLayout()
        Me.tlpDashboard.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgvDSHopDong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpnlMain
        '
        Me.tlpnlMain.ColumnCount = 2
        Me.tlpnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.80887!))
        Me.tlpnlMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.19112!))
        Me.tlpnlMain.Controls.Add(Me.tlpDashboard, 1, 0)
        Me.tlpnlMain.Controls.Add(Me.SidebarMenu1, 0, 0)
        Me.tlpnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpnlMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpnlMain.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpnlMain.Name = "tlpnlMain"
        Me.tlpnlMain.RowCount = 1
        Me.tlpnlMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpnlMain.Size = New System.Drawing.Size(1172, 643)
        Me.tlpnlMain.TabIndex = 1
        '
        'tlpDashboard
        '
        Me.tlpDashboard.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpDashboard.ColumnCount = 5
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpDashboard.Controls.Add(Me.Panel6, 4, 1)
        Me.tlpDashboard.Controls.Add(Me.Panel5, 3, 1)
        Me.tlpDashboard.Controls.Add(Me.Panel4, 2, 1)
        Me.tlpDashboard.Controls.Add(Me.Panel3, 1, 1)
        Me.tlpDashboard.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpDashboard.Controls.Add(Me.Panel2, 0, 1)
        Me.tlpDashboard.Controls.Add(Me.dtgvDSHopDong, 0, 2)
        Me.tlpDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDashboard.Location = New System.Drawing.Point(198, 3)
        Me.tlpDashboard.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpDashboard.Name = "tlpDashboard"
        Me.tlpDashboard.RowCount = 3
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.39286!))
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.60714!))
        Me.tlpDashboard.Size = New System.Drawing.Size(972, 637)
        Me.tlpDashboard.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.btnThemHD)
        Me.Panel6.Controls.Add(Me.dtpkDenNgay)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(779, 80)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(190, 69)
        Me.Panel6.TabIndex = 6
        '
        'btnThemHD
        '
        Me.btnThemHD.BackColor = System.Drawing.Color.LimeGreen
        Me.btnThemHD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnThemHD.ForeColor = System.Drawing.Color.White
        Me.btnThemHD.Location = New System.Drawing.Point(0, 39)
        Me.btnThemHD.Name = "btnThemHD"
        Me.btnThemHD.Size = New System.Drawing.Size(190, 30)
        Me.btnThemHD.TabIndex = 4
        Me.btnThemHD.Text = "Thêm hợp đồng"
        Me.btnThemHD.UseVisualStyleBackColor = False
        '
        'dtpkDenNgay
        '
        Me.dtpkDenNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpkDenNgay.Location = New System.Drawing.Point(0, 0)
        Me.dtpkDenNgay.Name = "dtpkDenNgay"
        Me.dtpkDenNgay.Size = New System.Drawing.Size(190, 27)
        Me.dtpkDenNgay.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.dtpkTuNgay)
        Me.Panel5.Controls.Add(Me.cbbxCongTy)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(585, 80)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(188, 69)
        Me.Panel5.TabIndex = 5
        '
        'dtpkTuNgay
        '
        Me.dtpkTuNgay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpkTuNgay.Location = New System.Drawing.Point(0, 0)
        Me.dtpkTuNgay.Name = "dtpkTuNgay"
        Me.dtpkTuNgay.Size = New System.Drawing.Size(188, 27)
        Me.dtpkTuNgay.TabIndex = 2
        '
        'cbbxCongTy
        '
        Me.cbbxCongTy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbbxCongTy.FormattingEnabled = True
        Me.cbbxCongTy.Location = New System.Drawing.Point(0, 39)
        Me.cbbxCongTy.Name = "cbbxCongTy"
        Me.cbbxCongTy.Size = New System.Drawing.Size(188, 30)
        Me.cbbxCongTy.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.btnSearch)
        Me.Panel4.Controls.Add(Me.tbxSearch)
        Me.Panel4.Controls.Add(Me.cbbxThoiGianHD)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(391, 80)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(188, 69)
        Me.Panel4.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.Font = New System.Drawing.Font("Arial Narrow", 8.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.WindTown_VB.My.Resources.Resources.search
        Me.btnSearch.Location = New System.Drawing.Point(162, 42)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(26, 26)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tbxSearch
        '
        Me.tbxSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxSearch.Location = New System.Drawing.Point(3, 42)
        Me.tbxSearch.Name = "tbxSearch"
        Me.tbxSearch.Size = New System.Drawing.Size(150, 27)
        Me.tbxSearch.TabIndex = 1
        '
        'cbbxThoiGianHD
        '
        Me.cbbxThoiGianHD.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbbxThoiGianHD.FormattingEnabled = True
        Me.cbbxThoiGianHD.Location = New System.Drawing.Point(0, 0)
        Me.cbbxThoiGianHD.Name = "cbbxThoiGianHD"
        Me.cbbxThoiGianHD.Size = New System.Drawing.Size(188, 30)
        Me.cbbxThoiGianHD.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.cbbxHopDong)
        Me.Panel3.Controls.Add(Me.cbbxTrangThai)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(197, 80)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(188, 69)
        Me.Panel3.TabIndex = 3
        '
        'cbbxHopDong
        '
        Me.cbbxHopDong.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbbxHopDong.FormattingEnabled = True
        Me.cbbxHopDong.Location = New System.Drawing.Point(0, 39)
        Me.cbbxHopDong.Name = "cbbxHopDong"
        Me.cbbxHopDong.Size = New System.Drawing.Size(188, 30)
        Me.cbbxHopDong.TabIndex = 1
        '
        'cbbxTrangThai
        '
        Me.cbbxTrangThai.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbbxTrangThai.FormattingEnabled = True
        Me.cbbxTrangThai.Location = New System.Drawing.Point(0, 0)
        Me.cbbxTrangThai.Name = "cbbxTrangThai"
        Me.cbbxTrangThai.Size = New System.Drawing.Size(188, 30)
        Me.cbbxTrangThai.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.tlpDashboard.SetColumnSpan(Me.Panel1, 5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 71)
        Me.Panel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(224, 31)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Quản lý hợp đồng"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.cbbxLoaiHopDong)
        Me.Panel2.Controls.Add(Me.cbbxBoPhan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(188, 69)
        Me.Panel2.TabIndex = 2
        '
        'cbbxLoaiHopDong
        '
        Me.cbbxLoaiHopDong.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbbxLoaiHopDong.FormattingEnabled = True
        Me.cbbxLoaiHopDong.Location = New System.Drawing.Point(0, 39)
        Me.cbbxLoaiHopDong.Name = "cbbxLoaiHopDong"
        Me.cbbxLoaiHopDong.Size = New System.Drawing.Size(188, 30)
        Me.cbbxLoaiHopDong.TabIndex = 1
        '
        'cbbxBoPhan
        '
        Me.cbbxBoPhan.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbbxBoPhan.FormattingEnabled = True
        Me.cbbxBoPhan.Location = New System.Drawing.Point(0, 0)
        Me.cbbxBoPhan.Name = "cbbxBoPhan"
        Me.cbbxBoPhan.Size = New System.Drawing.Size(188, 30)
        Me.cbbxBoPhan.TabIndex = 0
        '
        'dtgvDSHopDong
        '
        Me.dtgvDSHopDong.AllowUserToAddRows = False
        Me.dtgvDSHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgvDSHopDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.dtgvDSHopDong.BackgroundColor = System.Drawing.Color.White
        Me.dtgvDSHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpDashboard.SetColumnSpan(Me.dtgvDSHopDong, 5)
        Me.dtgvDSHopDong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgvDSHopDong.Location = New System.Drawing.Point(3, 155)
        Me.dtgvDSHopDong.Name = "dtgvDSHopDong"
        Me.dtgvDSHopDong.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtgvDSHopDong.RowHeadersVisible = False
        Me.dtgvDSHopDong.RowHeadersWidth = 51
        Me.dtgvDSHopDong.RowTemplate.Height = 24
        Me.dtgvDSHopDong.Size = New System.Drawing.Size(966, 479)
        Me.dtgvDSHopDong.TabIndex = 7
        '
        'SidebarMenu1
        '
        Me.SidebarMenu1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SidebarMenu1.Location = New System.Drawing.Point(3, 4)
        Me.SidebarMenu1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SidebarMenu1.Name = "SidebarMenu1"
        Me.SidebarMenu1.Size = New System.Drawing.Size(190, 635)
        Me.SidebarMenu1.TabIndex = 0
        '
        'frmHopDong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1172, 643)
        Me.Controls.Add(Me.tlpnlMain)
        Me.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "frmHopDong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmHopDong"
        Me.tlpnlMain.ResumeLayout(False)
        Me.tlpDashboard.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dtgvDSHopDong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpnlMain As TableLayoutPanel
    Friend WithEvents SidebarMenu1 As SidebarMenu
    Friend WithEvents tlpDashboard As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents cbbxCongTy As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cbbxThoiGianHD As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cbbxHopDong As ComboBox
    Friend WithEvents cbbxTrangThai As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cbbxLoaiHopDong As ComboBox
    Friend WithEvents cbbxBoPhan As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents tbxSearch As TextBox
    Friend WithEvents dtpkTuNgay As DateTimePicker
    Friend WithEvents dtpkDenNgay As DateTimePicker
    Friend WithEvents btnThemHD As Button
    Friend WithEvents dtgvDSHopDong As DataGridView
End Class
