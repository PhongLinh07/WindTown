<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChamCong
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChamCong))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlHanhDong = New System.Windows.Forms.Panel()
        Me.btnThemChamCong = New System.Windows.Forms.Button()
        Me.btnSuaChamCong = New System.Windows.Forms.Button()
        Me.btnXoaChamCong = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnTrangTruoc = New System.Windows.Forms.Button()
        Me.lblTrang = New System.Windows.Forms.Label()
        Me.btnTrangSau = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelNhanh = New System.Windows.Forms.Panel()
        Me.lblLocNhanh = New System.Windows.Forms.Label()
        Me.cbbxThoiGianNhanh = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnLamMoi = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBaoCao = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.cbbxThoiGian = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpkInday = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.dtpkToday = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmsBaoCao = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBaoCaoLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBaoCaoChon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBaoCaoTongHop = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlHanhDong.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.PanelNhanh.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsBaoCao.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlHeader, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1040, 665)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlHanhDong)
        Me.pnlHeader.Controls.Add(Me.Panel5)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.ForeColor = System.Drawing.Color.Black
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1034, 74)
        Me.pnlHeader.TabIndex = 7
        '
        'pnlHanhDong
        '
        Me.pnlHanhDong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHanhDong.BackColor = System.Drawing.Color.Transparent
        Me.pnlHanhDong.Controls.Add(Me.btnThemChamCong)
        Me.pnlHanhDong.Controls.Add(Me.btnSuaChamCong)
        Me.pnlHanhDong.Controls.Add(Me.btnXoaChamCong)
        Me.pnlHanhDong.Location = New System.Drawing.Point(360, 18)
        Me.pnlHanhDong.Name = "pnlHanhDong"
        Me.pnlHanhDong.Size = New System.Drawing.Size(340, 40)
        Me.pnlHanhDong.TabIndex = 10
        '
        'btnThemChamCong
        '
        Me.btnThemChamCong.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnThemChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThemChamCong.ForeColor = System.Drawing.Color.White
        Me.btnThemChamCong.Location = New System.Drawing.Point(0, 6)
        Me.btnThemChamCong.Name = "btnThemChamCong"
        Me.btnThemChamCong.Size = New System.Drawing.Size(105, 29)
        Me.btnThemChamCong.TabIndex = 0
        Me.btnThemChamCong.Text = "Thêm"
        Me.btnThemChamCong.UseVisualStyleBackColor = False
        '
        'btnSuaChamCong
        '
        Me.btnSuaChamCong.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.btnSuaChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuaChamCong.ForeColor = System.Drawing.Color.Black
        Me.btnSuaChamCong.Location = New System.Drawing.Point(115, 6)
        Me.btnSuaChamCong.Name = "btnSuaChamCong"
        Me.btnSuaChamCong.Size = New System.Drawing.Size(105, 29)
        Me.btnSuaChamCong.TabIndex = 1
        Me.btnSuaChamCong.Text = "Sửa"
        Me.btnSuaChamCong.UseVisualStyleBackColor = False
        '
        'btnXoaChamCong
        '
        Me.btnXoaChamCong.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnXoaChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXoaChamCong.ForeColor = System.Drawing.Color.White
        Me.btnXoaChamCong.Location = New System.Drawing.Point(230, 6)
        Me.btnXoaChamCong.Name = "btnXoaChamCong"
        Me.btnXoaChamCong.Size = New System.Drawing.Size(105, 29)
        Me.btnXoaChamCong.TabIndex = 2
        Me.btnXoaChamCong.Text = "Xóa"
        Me.btnXoaChamCong.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.btnTrangTruoc)
        Me.Panel5.Controls.Add(Me.lblTrang)
        Me.Panel5.Controls.Add(Me.btnTrangSau)
        Me.Panel5.Location = New System.Drawing.Point(714, 18)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(300, 42)
        Me.Panel5.TabIndex = 9
        '
        'btnTrangTruoc
        '
        Me.btnTrangTruoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnTrangTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrangTruoc.ForeColor = System.Drawing.Color.White
        Me.btnTrangTruoc.Location = New System.Drawing.Point(3, 6)
        Me.btnTrangTruoc.Name = "btnTrangTruoc"
        Me.btnTrangTruoc.Size = New System.Drawing.Size(90, 32)
        Me.btnTrangTruoc.TabIndex = 0
        Me.btnTrangTruoc.Text = "Trang trước"
        Me.btnTrangTruoc.UseVisualStyleBackColor = False
        '
        'lblTrang
        '
        Me.lblTrang.AutoSize = True
        Me.lblTrang.ForeColor = System.Drawing.Color.Black
        Me.lblTrang.Location = New System.Drawing.Point(99, 11)
        Me.lblTrang.Name = "lblTrang"
        Me.lblTrang.Size = New System.Drawing.Size(88, 23)
        Me.lblTrang.TabIndex = 1
        Me.lblTrang.Text = "Trang 1/1"
        '
        'btnTrangSau
        '
        Me.btnTrangSau.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnTrangSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrangSau.ForeColor = System.Drawing.Color.White
        Me.btnTrangSau.Location = New System.Drawing.Point(200, 6)
        Me.btnTrangSau.Name = "btnTrangSau"
        Me.btnTrangSau.Size = New System.Drawing.Size(90, 32)
        Me.btnTrangSau.TabIndex = 2
        Me.btnTrangSau.Text = "Trang sau"
        Me.btnTrangSau.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(239, 31)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Quản lý chấm công"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PanelNhanh, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnBaoCao, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 83)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1034, 114)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'PanelNhanh
        '
        Me.PanelNhanh.Controls.Add(Me.lblLocNhanh)
        Me.PanelNhanh.Controls.Add(Me.cbbxThoiGianNhanh)
        Me.PanelNhanh.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNhanh.Location = New System.Drawing.Point(101, 3)
        Me.PanelNhanh.Name = "PanelNhanh"
        Me.PanelNhanh.Size = New System.Drawing.Size(133, 58)
        Me.PanelNhanh.TabIndex = 9
        '
        'lblLocNhanh
        '
        Me.lblLocNhanh.AutoSize = True
        Me.lblLocNhanh.Location = New System.Drawing.Point(3, 3)
        Me.lblLocNhanh.Name = "lblLocNhanh"
        Me.lblLocNhanh.Size = New System.Drawing.Size(91, 23)
        Me.lblLocNhanh.TabIndex = 0
        Me.lblLocNhanh.Text = "Lọc nhanh"
        '
        'cbbxThoiGianNhanh
        '
        Me.cbbxThoiGianNhanh.BackColor = System.Drawing.Color.White
        Me.cbbxThoiGianNhanh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbbxThoiGianNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbxThoiGianNhanh.FormattingEnabled = True
        Me.cbbxThoiGianNhanh.Location = New System.Drawing.Point(0, 27)
        Me.cbbxThoiGianNhanh.Name = "cbbxThoiGianNhanh"
        Me.cbbxThoiGianNhanh.Size = New System.Drawing.Size(133, 31)
        Me.cbbxThoiGianNhanh.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.btnLamMoi)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Location = New System.Drawing.Point(695, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(224, 78)
        Me.Panel2.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(3, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 29)
        Me.TextBox1.TabIndex = 5
        '
        'btnLamMoi
        '
        Me.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLamMoi.ForeColor = System.Drawing.Color.White
        Me.btnLamMoi.Location = New System.Drawing.Point(137, 40)
        Me.btnLamMoi.Name = "btnLamMoi"
        Me.btnLamMoi.Size = New System.Drawing.Size(84, 33)
        Me.btnLamMoi.TabIndex = 8
        Me.btnLamMoi.Text = "Làm mới"
        Me.btnLamMoi.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(137, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 33)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Tìm kiếm"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnBaoCao
        '
        Me.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBaoCao.ForeColor = System.Drawing.Color.White
        Me.btnBaoCao.Location = New System.Drawing.Point(925, 3)
        Me.btnBaoCao.Name = "btnBaoCao"
        Me.btnBaoCao.Size = New System.Drawing.Size(102, 34)
        Me.btnBaoCao.TabIndex = 6
        Me.btnBaoCao.Text = "Báo cáo"
        Me.btnBaoCao.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(92, 31)
        Me.ComboBox1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.cbbxThoiGian)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(240, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(172, 108)
        Me.Panel1.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Theo ca làm"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(0, 27)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(169, 31)
        Me.ComboBox2.TabIndex = 1
        '
        'cbbxThoiGian
        '
        Me.cbbxThoiGian.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbxThoiGian.BackColor = System.Drawing.Color.White
        Me.cbbxThoiGian.FormattingEnabled = True
        Me.cbbxThoiGian.Location = New System.Drawing.Point(0, 73)
        Me.cbbxThoiGian.Name = "cbbxThoiGian"
        Me.cbbxThoiGian.Size = New System.Drawing.Size(169, 31)
        Me.cbbxThoiGian.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.dtpkInday)
        Me.Panel3.Controls.Add(Me.ComboBox3)
        Me.Panel3.Controls.Add(Me.dtpkToday)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(418, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(271, 108)
        Me.Panel3.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Đến"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Từ"
        '
        'dtpkInday
        '
        Me.dtpkInday.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpkInday.Location = New System.Drawing.Point(51, 76)
        Me.dtpkInday.Name = "dtpkInday"
        Me.dtpkInday.Size = New System.Drawing.Size(217, 29)
        Me.dtpkInday.TabIndex = 8
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.White
        Me.ComboBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(271, 31)
        Me.ComboBox3.TabIndex = 4
        '
        'dtpkToday
        '
        Me.dtpkToday.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpkToday.Location = New System.Drawing.Point(51, 42)
        Me.dtpkToday.Name = "dtpkToday"
        Me.dtpkToday.Size = New System.Drawing.Size(217, 29)
        Me.dtpkToday.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(3, 203)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1034, 459)
        Me.DataGridView1.TabIndex = 6
        '
        'cmsBaoCao
        '
        Me.cmsBaoCao.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsBaoCao.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBaoCaoLoc, Me.mnuBaoCaoChon, Me.mnuBaoCaoTongHop})
        Me.cmsBaoCao.Name = "cmsBaoCao"
        Me.cmsBaoCao.Size = New System.Drawing.Size(242, 76)
        '
        'mnuBaoCaoLoc
        '
        Me.mnuBaoCaoLoc.Name = "mnuBaoCaoLoc"
        Me.mnuBaoCaoLoc.Size = New System.Drawing.Size(241, 24)
        Me.mnuBaoCaoLoc.Text = "Xuất theo bộ lọc hiện tại"
        '
        'mnuBaoCaoChon
        '
        Me.mnuBaoCaoChon.Name = "mnuBaoCaoChon"
        Me.mnuBaoCaoChon.Size = New System.Drawing.Size(241, 24)
        Me.mnuBaoCaoChon.Text = "Xuất theo lựa chọn"
        '
        'mnuBaoCaoTongHop
        '
        Me.mnuBaoCaoTongHop.Name = "mnuBaoCaoTongHop"
        Me.mnuBaoCaoTongHop.Size = New System.Drawing.Size(241, 24)
        Me.mnuBaoCaoTongHop.Text = "Tổng hợp tháng/quý"
        '
        'frmChamCong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 665)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmChamCong"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chấm công"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlHanhDong.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.PanelNhanh.ResumeLayout(False)
        Me.PanelNhanh.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsBaoCao.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlHanhDong As Panel
    Friend WithEvents btnThemChamCong As Button
    Friend WithEvents btnSuaChamCong As Button
    Friend WithEvents btnXoaChamCong As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnTrangTruoc As Button
    Friend WithEvents lblTrang As Label
    Friend WithEvents btnTrangSau As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents cbbxThoiGian As ComboBox
    Friend WithEvents dtpkToday As DateTimePicker
    Friend WithEvents PanelNhanh As Panel
    Friend WithEvents lblLocNhanh As Label
    Friend WithEvents cbbxThoiGianNhanh As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnLamMoi As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents btnBaoCao As Button
    Friend WithEvents cmsBaoCao As ContextMenuStrip
    Friend WithEvents mnuBaoCaoLoc As ToolStripMenuItem
    Friend WithEvents mnuBaoCaoChon As ToolStripMenuItem
    Friend WithEvents mnuBaoCaoTongHop As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dtpkInday As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
