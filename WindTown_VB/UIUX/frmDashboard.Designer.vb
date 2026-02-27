<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
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
        Me.tlpDasboard = New System.Windows.Forms.TableLayoutPanel()
        Me.SidebarMenu1 = New SidebarMenu()
        Me.tlpDashboard = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTopCheckinMuon = New System.Windows.Forms.TableLayoutPanel()
        Me.lvTopCheckinMuon = New System.Windows.Forms.ListView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tlpThongKe = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txDenMuon = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtChuaCheckin = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpkThongKe = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDungGio = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tlpNhanVien = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMoiNV = New System.Windows.Forms.Button()
        Me.txtSoBoPhan = New System.Windows.Forms.Label()
        Me.txtDaNghiViec = New System.Windows.Forms.Label()
        Me.txtDangLV = New System.Windows.Forms.Label()
        Me.txtTongNV = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnThemNV = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tlpTopCheckin = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvTopCheckinSom = New System.Windows.Forms.ListView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tlpDasboard.SuspendLayout()
        Me.tlpDashboard.SuspendLayout()
        Me.tlpTopCheckinMuon.SuspendLayout()
        Me.tlpThongKe.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tlpNhanVien.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tlpTopCheckin.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpDasboard
        '
        Me.tlpDasboard.ColumnCount = 2
        Me.tlpDasboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.80887!))
        Me.tlpDasboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.19112!))
        Me.tlpDasboard.Controls.Add(Me.SidebarMenu1, 0, 0)
        Me.tlpDasboard.Controls.Add(Me.tlpDashboard, 1, 0)
        Me.tlpDasboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDasboard.Location = New System.Drawing.Point(0, 0)
        Me.tlpDasboard.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpDasboard.Name = "tlpDasboard"
        Me.tlpDasboard.RowCount = 1
        Me.tlpDasboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDasboard.Size = New System.Drawing.Size(1172, 643)
        Me.tlpDasboard.TabIndex = 0
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
        'tlpDashboard
        '
        Me.tlpDashboard.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpDashboard.ColumnCount = 2
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDashboard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpDashboard.Controls.Add(Me.tlpTopCheckinMuon, 1, 2)
        Me.tlpDashboard.Controls.Add(Me.tlpThongKe, 1, 1)
        Me.tlpDashboard.Controls.Add(Me.tlpNhanVien, 0, 1)
        Me.tlpDashboard.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpDashboard.Controls.Add(Me.tlpTopCheckin, 0, 2)
        Me.tlpDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDashboard.Location = New System.Drawing.Point(198, 3)
        Me.tlpDashboard.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpDashboard.Name = "tlpDashboard"
        Me.tlpDashboard.RowCount = 3
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.77738!))
        Me.tlpDashboard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.22262!))
        Me.tlpDashboard.Size = New System.Drawing.Size(972, 637)
        Me.tlpDashboard.TabIndex = 1
        '
        'tlpTopCheckinMuon
        '
        Me.tlpTopCheckinMuon.BackColor = System.Drawing.Color.White
        Me.tlpTopCheckinMuon.ColumnCount = 1
        Me.tlpTopCheckinMuon.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopCheckinMuon.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpTopCheckinMuon.Controls.Add(Me.lvTopCheckinMuon, 0, 1)
        Me.tlpTopCheckinMuon.Controls.Add(Me.Label12, 0, 0)
        Me.tlpTopCheckinMuon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopCheckinMuon.Location = New System.Drawing.Point(488, 257)
        Me.tlpTopCheckinMuon.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpTopCheckinMuon.Name = "tlpTopCheckinMuon"
        Me.tlpTopCheckinMuon.RowCount = 2
        Me.tlpTopCheckinMuon.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpTopCheckinMuon.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.tlpTopCheckinMuon.Size = New System.Drawing.Size(482, 377)
        Me.tlpTopCheckinMuon.TabIndex = 4
        '
        'lvTopCheckinMuon
        '
        Me.lvTopCheckinMuon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTopCheckinMuon.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTopCheckinMuon.HideSelection = False
        Me.lvTopCheckinMuon.Location = New System.Drawing.Point(2, 97)
        Me.lvTopCheckinMuon.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lvTopCheckinMuon.Name = "lvTopCheckinMuon"
        Me.lvTopCheckinMuon.Size = New System.Drawing.Size(478, 277)
        Me.lvTopCheckinMuon.TabIndex = 3
        Me.lvTopCheckinMuon.UseCompatibleStateImageBehavior = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.tlpTopCheckinMuon.SetColumnSpan(Me.Label12, 3)
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 0)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(478, 94)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Đi muộn hôm nay"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpThongKe
        '
        Me.tlpThongKe.BackColor = System.Drawing.Color.White
        Me.tlpThongKe.ColumnCount = 3
        Me.tlpThongKe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpThongKe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpThongKe.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpThongKe.Controls.Add(Me.Panel5, 2, 1)
        Me.tlpThongKe.Controls.Add(Me.Panel4, 1, 1)
        Me.tlpThongKe.Controls.Add(Me.Label14, 0, 0)
        Me.tlpThongKe.Controls.Add(Me.dtpkThongKe, 2, 0)
        Me.tlpThongKe.Controls.Add(Me.Panel2, 0, 1)
        Me.tlpThongKe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpThongKe.Location = New System.Drawing.Point(488, 80)
        Me.tlpThongKe.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpThongKe.Name = "tlpThongKe"
        Me.tlpThongKe.RowCount = 2
        Me.tlpThongKe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tlpThongKe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpThongKe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpThongKe.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpThongKe.Size = New System.Drawing.Size(482, 171)
        Me.tlpThongKe.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.txDenMuon)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(322, 32)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(158, 136)
        Me.Panel5.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(59, 62)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 37)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "0"
        '
        'txDenMuon
        '
        Me.txDenMuon.AutoSize = True
        Me.txDenMuon.Location = New System.Drawing.Point(38, 21)
        Me.txDenMuon.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txDenMuon.Name = "txDenMuon"
        Me.txDenMuon.Size = New System.Drawing.Size(68, 22)
        Me.txDenMuon.TabIndex = 0
        Me.txDenMuon.Text = "Đúng giờ"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtChuaCheckin)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(162, 32)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(156, 136)
        Me.Panel4.TabIndex = 3
        '
        'txtChuaCheckin
        '
        Me.txtChuaCheckin.AutoSize = True
        Me.txtChuaCheckin.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChuaCheckin.ForeColor = System.Drawing.Color.Red
        Me.txtChuaCheckin.Location = New System.Drawing.Point(59, 62)
        Me.txtChuaCheckin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtChuaCheckin.Name = "txtChuaCheckin"
        Me.txtChuaCheckin.Size = New System.Drawing.Size(34, 37)
        Me.txtChuaCheckin.TabIndex = 1
        Me.txtChuaCheckin.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 21)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Chưa checkin"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.tlpThongKe.SetColumnSpan(Me.Label14, 2)
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(2, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(316, 29)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Thống kê chấm công"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpkThongKe
        '
        Me.dtpkThongKe.CalendarFont = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpkThongKe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpkThongKe.Location = New System.Drawing.Point(322, 3)
        Me.dtpkThongKe.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpkThongKe.Name = "dtpkThongKe"
        Me.dtpkThongKe.Size = New System.Drawing.Size(158, 27)
        Me.dtpkThongKe.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(2, 32)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(156, 136)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtDungGio)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(156, 136)
        Me.Panel3.TabIndex = 3
        '
        'txtDungGio
        '
        Me.txtDungGio.AutoSize = True
        Me.txtDungGio.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDungGio.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtDungGio.Location = New System.Drawing.Point(58, 62)
        Me.txtDungGio.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtDungGio.Name = "txtDungGio"
        Me.txtDungGio.Size = New System.Drawing.Size(34, 37)
        Me.txtDungGio.TabIndex = 1
        Me.txtDungGio.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 21)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 22)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Đúng giờ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label9.Location = New System.Drawing.Point(46, 62)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 37)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 21)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 22)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Đúng giờ"
        '
        'tlpNhanVien
        '
        Me.tlpNhanVien.BackColor = System.Drawing.Color.White
        Me.tlpNhanVien.ColumnCount = 4
        Me.tlpNhanVien.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNhanVien.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNhanVien.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNhanVien.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpNhanVien.Controls.Add(Me.btnMoiNV, 2, 3)
        Me.tlpNhanVien.Controls.Add(Me.txtSoBoPhan, 3, 2)
        Me.tlpNhanVien.Controls.Add(Me.txtDaNghiViec, 2, 2)
        Me.tlpNhanVien.Controls.Add(Me.txtDangLV, 1, 2)
        Me.tlpNhanVien.Controls.Add(Me.txtTongNV, 0, 2)
        Me.tlpNhanVien.Controls.Add(Me.Label5, 3, 1)
        Me.tlpNhanVien.Controls.Add(Me.Label4, 2, 1)
        Me.tlpNhanVien.Controls.Add(Me.Label3, 1, 1)
        Me.tlpNhanVien.Controls.Add(Me.Label1, 0, 0)
        Me.tlpNhanVien.Controls.Add(Me.Label2, 0, 1)
        Me.tlpNhanVien.Controls.Add(Me.btnThemNV, 0, 3)
        Me.tlpNhanVien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNhanVien.Location = New System.Drawing.Point(2, 80)
        Me.tlpNhanVien.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpNhanVien.Name = "tlpNhanVien"
        Me.tlpNhanVien.RowCount = 4
        Me.tlpNhanVien.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.tlpNhanVien.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNhanVien.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.tlpNhanVien.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.tlpNhanVien.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpNhanVien.Size = New System.Drawing.Size(482, 171)
        Me.tlpNhanVien.TabIndex = 0
        '
        'btnMoiNV
        '
        Me.tlpNhanVien.SetColumnSpan(Me.btnMoiNV, 2)
        Me.btnMoiNV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMoiNV.Location = New System.Drawing.Point(242, 137)
        Me.btnMoiNV.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnMoiNV.Name = "btnMoiNV"
        Me.btnMoiNV.Size = New System.Drawing.Size(238, 31)
        Me.btnMoiNV.TabIndex = 10
        Me.btnMoiNV.Text = "Mời nhân viên"
        Me.btnMoiNV.UseVisualStyleBackColor = True
        '
        'txtSoBoPhan
        '
        Me.txtSoBoPhan.AutoSize = True
        Me.txtSoBoPhan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSoBoPhan.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoBoPhan.ForeColor = System.Drawing.Color.DarkViolet
        Me.txtSoBoPhan.Location = New System.Drawing.Point(362, 57)
        Me.txtSoBoPhan.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtSoBoPhan.Name = "txtSoBoPhan"
        Me.txtSoBoPhan.Size = New System.Drawing.Size(118, 77)
        Me.txtSoBoPhan.TabIndex = 8
        Me.txtSoBoPhan.Text = "0"
        Me.txtSoBoPhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDaNghiViec
        '
        Me.txtDaNghiViec.AutoSize = True
        Me.txtDaNghiViec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDaNghiViec.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaNghiViec.ForeColor = System.Drawing.Color.Orange
        Me.txtDaNghiViec.Location = New System.Drawing.Point(242, 57)
        Me.txtDaNghiViec.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtDaNghiViec.Name = "txtDaNghiViec"
        Me.txtDaNghiViec.Size = New System.Drawing.Size(116, 77)
        Me.txtDaNghiViec.TabIndex = 7
        Me.txtDaNghiViec.Text = "0"
        Me.txtDaNghiViec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDangLV
        '
        Me.txtDangLV.AutoSize = True
        Me.txtDangLV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDangLV.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDangLV.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtDangLV.Location = New System.Drawing.Point(122, 57)
        Me.txtDangLV.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtDangLV.Name = "txtDangLV"
        Me.txtDangLV.Size = New System.Drawing.Size(116, 77)
        Me.txtDangLV.TabIndex = 6
        Me.txtDangLV.Text = "0"
        Me.txtDangLV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTongNV
        '
        Me.txtTongNV.AutoSize = True
        Me.txtTongNV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTongNV.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongNV.ForeColor = System.Drawing.Color.DodgerBlue
        Me.txtTongNV.Location = New System.Drawing.Point(2, 57)
        Me.txtTongNV.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txtTongNV.Name = "txtTongNV"
        Me.txtTongNV.Size = New System.Drawing.Size(116, 77)
        Me.txtTongNV.TabIndex = 5
        Me.txtTongNV.Text = "0"
        Me.txtTongNV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(362, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 28)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Số bộ phận"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(242, 29)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Đã nghỉ việc"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(122, 29)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Đang làm việc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.tlpNhanVien.SetColumnSpan(Me.Label1, 4)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(478, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Số nhân viên"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tổng nhân viên"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnThemNV
        '
        Me.tlpNhanVien.SetColumnSpan(Me.btnThemNV, 2)
        Me.btnThemNV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnThemNV.Location = New System.Drawing.Point(2, 137)
        Me.btnThemNV.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnThemNV.Name = "btnThemNV"
        Me.btnThemNV.Size = New System.Drawing.Size(236, 31)
        Me.btnThemNV.TabIndex = 9
        Me.btnThemNV.Text = "+ Thêm nhân viên"
        Me.btnThemNV.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.tlpDashboard.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.btnSetting)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 71)
        Me.Panel1.TabIndex = 1
        '
        'btnSetting
        '
        Me.btnSetting.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.Location = New System.Drawing.Point(850, 23)
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(101, 33)
        Me.btnSetting.TabIndex = 1
        Me.btnSetting.Text = "Cài đặt"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 20)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 31)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Dashboard"
        '
        'tlpTopCheckin
        '
        Me.tlpTopCheckin.BackColor = System.Drawing.Color.White
        Me.tlpTopCheckin.ColumnCount = 1
        Me.tlpTopCheckin.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpTopCheckin.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpTopCheckin.Controls.Add(Me.Label10, 0, 0)
        Me.tlpTopCheckin.Controls.Add(Me.lvTopCheckinSom, 1, 1)
        Me.tlpTopCheckin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpTopCheckin.Location = New System.Drawing.Point(2, 257)
        Me.tlpTopCheckin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tlpTopCheckin.Name = "tlpTopCheckin"
        Me.tlpTopCheckin.RowCount = 2
        Me.tlpTopCheckin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpTopCheckin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.tlpTopCheckin.Size = New System.Drawing.Size(482, 377)
        Me.tlpTopCheckin.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.tlpTopCheckin.SetColumnSpan(Me.Label10, 3)
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(478, 94)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Top checkin sớm"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvTopCheckinSom
        '
        Me.lvTopCheckinSom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvTopCheckinSom.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTopCheckinSom.HideSelection = False
        Me.lvTopCheckinSom.Location = New System.Drawing.Point(2, 97)
        Me.lvTopCheckinSom.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lvTopCheckinSom.Name = "lvTopCheckinSom"
        Me.lvTopCheckinSom.Size = New System.Drawing.Size(478, 277)
        Me.lvTopCheckinSom.TabIndex = 2
        Me.lvTopCheckinSom.UseCompatibleStateImageBehavior = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Arial", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Orange
        Me.Label8.Location = New System.Drawing.Point(321, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 30)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "0"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 643)
        Me.Controls.Add(Me.tlpDasboard)
        Me.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDashboard"
        Me.tlpDasboard.ResumeLayout(False)
        Me.tlpDashboard.ResumeLayout(False)
        Me.tlpTopCheckinMuon.ResumeLayout(False)
        Me.tlpTopCheckinMuon.PerformLayout()
        Me.tlpThongKe.ResumeLayout(False)
        Me.tlpThongKe.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tlpNhanVien.ResumeLayout(False)
        Me.tlpNhanVien.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tlpTopCheckin.ResumeLayout(False)
        Me.tlpTopCheckin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpDasboard As TableLayoutPanel
    Friend WithEvents SidebarMenu1 As SidebarMenu
    Friend WithEvents tlpDashboard As TableLayoutPanel
    Friend WithEvents tlpNhanVien As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSoBoPhan As Label
    Friend WithEvents txtDaNghiViec As Label
    Friend WithEvents txtDangLV As Label
    Friend WithEvents txtTongNV As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMoiNV As Button
    Friend WithEvents btnThemNV As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSetting As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents tlpThongKe As TableLayoutPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txDenMuon As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtChuaCheckin As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dtpkThongKe As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtDungGio As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tlpTopCheckin As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents lvTopCheckinSom As ListView
    Friend WithEvents tlpTopCheckinMuon As TableLayoutPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents lvTopCheckinMuon As ListView
End Class
