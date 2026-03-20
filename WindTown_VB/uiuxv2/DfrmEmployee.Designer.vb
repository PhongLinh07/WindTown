<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formEmployee
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlRoot = New Panel()
        pnlContent = New Panel()
        pnlTab3 = New Panel()
        pnlContractScroll = New Panel()
        pnlContractFooter = New Panel()
        btnAddContract = New Button()
        lblContractEmp = New Label()
        pnlTab2 = New Panel()
        pnlDetailScroll = New Panel()
        txtNote = New TextBox()
        lblSec3 = New Label()
        tlpContact = New TableLayoutPanel()
        lblEmail = New Label()
        txtEmail = New TextBox()
        lblPhone = New Label()
        txtPhone = New TextBox()
        lblBank = New Label()
        txtBank = New TextBox()
        lblSec2 = New Label()
        tlpBasic = New TableLayoutPanel()
        lblCode = New Label()
        txtCode = New TextBox()
        lblFName = New Label()
        txtFName = New TextBox()
        lblGender = New Label()
        cboGender = New ComboBox()
        lblBirth = New Label()
        dtpBirth = New DateTimePicker()
        lblCccd = New Label()
        txtCccd = New TextBox()
        lblFStatus = New Label()
        cboFStatus = New ComboBox()
        lblAddress = New Label()
        txtAddress = New TextBox()
        lblSec1 = New Label()
        pnlDetailHeader = New Panel()
        lblDetailStatus = New Label()
        lblDetailCode = New Label()
        lblDetailName = New Label()
        pnlAvatarCircle = New Panel()
        pnlDetailFooter = New Panel()
        btnSave = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        pnlTab1 = New Panel()
        dgvEmployee = New DataGridView()
        colChk = New DataGridViewCheckBoxColumn()
        colAvatar = New DataGridViewTextBoxColumn()
        colName = New DataGridViewTextBoxColumn()
        colCode = New DataGridViewTextBoxColumn()
        colGender = New DataGridViewTextBoxColumn()
        colDept = New DataGridViewTextBoxColumn()
        colJob = New DataGridViewTextBoxColumn()
        colEmail = New DataGridViewTextBoxColumn()
        colPhone = New DataGridViewTextBoxColumn()
        colContractType = New DataGridViewTextBoxColumn()
        colStatusDgv = New DataGridViewTextBoxColumn()
        colActions = New DataGridViewTextBoxColumn()
        pnlTableFooter = New Panel()
        pnlPageBtns = New Panel()
        btnPageNext = New Button()
        btnPage2 = New Button()
        btnPage1 = New Button()
        btnPagePrev = New Button()
        lblRowInfo = New Label()
        pnlTabBar = New Panel()
        pnlTabIndicator = New Panel()
        btnTabContract = New Button()
        btnTabDetail = New Button()
        btnTabList = New Button()
        pnlToolbar = New Panel()
        btnAdd = New Button()
        btnExport = New Button()
        cboStatus = New ComboBox()
        cboDept = New ComboBox()
        txtSearch = New TextBox()
        pnlRoot.SuspendLayout()
        pnlContent.SuspendLayout()
        pnlTab3.SuspendLayout()
        pnlContractFooter.SuspendLayout()
        pnlTab2.SuspendLayout()
        pnlDetailScroll.SuspendLayout()
        tlpContact.SuspendLayout()
        tlpBasic.SuspendLayout()
        pnlDetailHeader.SuspendLayout()
        pnlDetailFooter.SuspendLayout()
        pnlTab1.SuspendLayout()
        CType(dgvEmployee, ComponentModel.ISupportInitialize).BeginInit()
        pnlTableFooter.SuspendLayout()
        pnlPageBtns.SuspendLayout()
        pnlTabBar.SuspendLayout()
        pnlToolbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlContent)
        pnlRoot.Controls.Add(pnlTabBar)
        pnlRoot.Controls.Add(pnlToolbar)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Size = New Size(1118, 499)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlContent
        ' 
        pnlContent.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContent.Controls.Add(pnlTab3)
        pnlContent.Controls.Add(pnlTab2)
        pnlContent.Controls.Add(pnlTab1)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 96)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1118, 403)
        pnlContent.TabIndex = 0
        ' 
        ' pnlTab3
        ' 
        pnlTab3.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab3.Controls.Add(pnlContractScroll)
        pnlTab3.Controls.Add(pnlContractFooter)
        pnlTab3.Dock = DockStyle.Fill
        pnlTab3.Location = New Point(0, 0)
        pnlTab3.Name = "pnlTab3"
        pnlTab3.Size = New Size(1118, 403)
        pnlTab3.TabIndex = 0
        pnlTab3.Visible = False
        ' 
        ' pnlContractScroll
        ' 
        pnlContractScroll.AutoScroll = True
        pnlContractScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlContractScroll.Dock = DockStyle.Fill
        pnlContractScroll.Location = New Point(0, 0)
        pnlContractScroll.Name = "pnlContractScroll"
        pnlContractScroll.Padding = New Padding(16, 14, 16, 14)
        pnlContractScroll.Size = New Size(1118, 351)
        pnlContractScroll.TabIndex = 0
        ' 
        ' pnlContractFooter
        ' 
        pnlContractFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlContractFooter.Controls.Add(btnAddContract)
        pnlContractFooter.Controls.Add(lblContractEmp)
        pnlContractFooter.Dock = DockStyle.Bottom
        pnlContractFooter.Location = New Point(0, 351)
        pnlContractFooter.Name = "pnlContractFooter"
        pnlContractFooter.Size = New Size(1118, 52)
        pnlContractFooter.TabIndex = 1
        ' 
        ' btnAddContract
        ' 
        btnAddContract.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddContract.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnAddContract.Cursor = Cursors.Hand
        btnAddContract.FlatAppearance.BorderSize = 0
        btnAddContract.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnAddContract.FlatStyle = FlatStyle.Flat
        btnAddContract.Font = New Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold)
        btnAddContract.ForeColor = Color.White
        btnAddContract.Location = New Point(903, 10)
        btnAddContract.Name = "btnAddContract"
        btnAddContract.Size = New Size(160, 32)
        btnAddContract.TabIndex = 0
        btnAddContract.Text = "+ Thêm hợp đồng"
        btnAddContract.UseVisualStyleBackColor = False
        ' 
        ' lblContractEmp
        ' 
        lblContractEmp.AutoSize = True
        lblContractEmp.Font = New Font("Microsoft YaHei UI", 8.5F)
        lblContractEmp.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblContractEmp.Location = New Point(14, 16)
        lblContractEmp.Name = "lblContractEmp"
        lblContractEmp.Size = New Size(198, 17)
        lblContractEmp.TabIndex = 1
        lblContractEmp.Text = "Chọn nhân viên từ tab Danh sách"
        ' 
        ' pnlTab2
        ' 
        pnlTab2.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab2.Controls.Add(pnlDetailScroll)
        pnlTab2.Controls.Add(pnlDetailFooter)
        pnlTab2.Dock = DockStyle.Fill
        pnlTab2.Location = New Point(0, 0)
        pnlTab2.Name = "pnlTab2"
        pnlTab2.Size = New Size(1118, 403)
        pnlTab2.TabIndex = 1
        pnlTab2.Visible = False
        ' 
        ' pnlDetailScroll
        ' 
        pnlDetailScroll.AutoScroll = True
        pnlDetailScroll.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlDetailScroll.Controls.Add(txtNote)
        pnlDetailScroll.Controls.Add(lblSec3)
        pnlDetailScroll.Controls.Add(tlpContact)
        pnlDetailScroll.Controls.Add(lblSec2)
        pnlDetailScroll.Controls.Add(tlpBasic)
        pnlDetailScroll.Controls.Add(lblSec1)
        pnlDetailScroll.Controls.Add(pnlDetailHeader)
        pnlDetailScroll.Dock = DockStyle.Fill
        pnlDetailScroll.Location = New Point(0, 0)
        pnlDetailScroll.Name = "pnlDetailScroll"
        pnlDetailScroll.Padding = New Padding(20, 16, 20, 16)
        pnlDetailScroll.Size = New Size(1118, 351)
        pnlDetailScroll.TabIndex = 0
        ' 
        ' txtNote
        ' 
        txtNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtNote.BorderStyle = BorderStyle.FixedSingle
        txtNote.Dock = DockStyle.Top
        txtNote.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtNote.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtNote.Location = New Point(20, 600)
        txtNote.Multiline = True
        txtNote.Name = "txtNote"
        txtNote.ScrollBars = ScrollBars.Vertical
        txtNote.Size = New Size(1061, 80)
        txtNote.TabIndex = 0
        ' 
        ' lblSec3
        ' 
        lblSec3.BackColor = Color.Transparent
        lblSec3.Dock = DockStyle.Top
        lblSec3.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblSec3.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec3.Location = New Point(20, 564)
        lblSec3.Name = "lblSec3"
        lblSec3.Padding = New Padding(0, 14, 0, 0)
        lblSec3.Size = New Size(1061, 36)
        lblSec3.TabIndex = 1
        lblSec3.Text = "GHI CHÚ NỘI BỘ"
        ' 
        ' tlpContact
        ' 
        tlpContact.BackColor = Color.Transparent
        tlpContact.ColumnCount = 2
        tlpContact.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContact.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpContact.Controls.Add(lblEmail, 0, 0)
        tlpContact.Controls.Add(txtEmail, 0, 1)
        tlpContact.Controls.Add(lblPhone, 1, 0)
        tlpContact.Controls.Add(txtPhone, 1, 1)
        tlpContact.Controls.Add(lblBank, 0, 2)
        tlpContact.Controls.Add(txtBank, 0, 3)
        tlpContact.Dock = DockStyle.Top
        tlpContact.Location = New Point(20, 432)
        tlpContact.Name = "tlpContact"
        tlpContact.RowCount = 4
        tlpContact.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpContact.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpContact.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpContact.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpContact.Size = New Size(1061, 132)
        tlpContact.TabIndex = 2
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblEmail.Location = New Point(3, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(92, 17)
        lblEmail.TabIndex = 0
        lblEmail.Text = "Email công ty"
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtEmail.BorderStyle = BorderStyle.FixedSingle
        txtEmail.Dock = DockStyle.Fill
        txtEmail.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtEmail.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtEmail.Location = New Point(0, 22)
        txtEmail.Margin = New Padding(0, 0, 8, 4)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(522, 24)
        txtEmail.TabIndex = 1
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblPhone.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblPhone.Location = New Point(538, 0)
        lblPhone.Margin = New Padding(8, 0, 0, 0)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(92, 17)
        lblPhone.TabIndex = 2
        lblPhone.Text = "Số điện thoại"
        ' 
        ' txtPhone
        ' 
        txtPhone.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtPhone.BorderStyle = BorderStyle.FixedSingle
        txtPhone.Dock = DockStyle.Fill
        txtPhone.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtPhone.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtPhone.Location = New Point(538, 22)
        txtPhone.Margin = New Padding(8, 0, 0, 4)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(523, 24)
        txtPhone.TabIndex = 3
        ' 
        ' lblBank
        ' 
        lblBank.AutoSize = True
        tlpContact.SetColumnSpan(lblBank, 2)
        lblBank.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblBank.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblBank.Location = New Point(3, 64)
        lblBank.Name = "lblBank"
        lblBank.Size = New Size(140, 17)
        lblBank.TabIndex = 4
        lblBank.Text = "Tài khoản ngân hàng"
        ' 
        ' txtBank
        ' 
        txtBank.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtBank.BorderStyle = BorderStyle.FixedSingle
        tlpContact.SetColumnSpan(txtBank, 2)
        txtBank.Dock = DockStyle.Fill
        txtBank.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtBank.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtBank.Location = New Point(0, 86)
        txtBank.Margin = New Padding(0, 0, 0, 4)
        txtBank.Name = "txtBank"
        txtBank.Size = New Size(1061, 24)
        txtBank.TabIndex = 5
        ' 
        ' lblSec2
        ' 
        lblSec2.BackColor = Color.Transparent
        lblSec2.Dock = DockStyle.Top
        lblSec2.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblSec2.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec2.Location = New Point(20, 396)
        lblSec2.Name = "lblSec2"
        lblSec2.Padding = New Padding(0, 14, 0, 0)
        lblSec2.Size = New Size(1061, 36)
        lblSec2.TabIndex = 3
        lblSec2.Text = "LIÊN HỆ & TÀI KHOẢN NGÂN HÀNG"
        ' 
        ' tlpBasic
        ' 
        tlpBasic.BackColor = Color.Transparent
        tlpBasic.ColumnCount = 2
        tlpBasic.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpBasic.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpBasic.Controls.Add(lblCode, 0, 0)
        tlpBasic.Controls.Add(txtCode, 0, 1)
        tlpBasic.Controls.Add(lblFName, 1, 0)
        tlpBasic.Controls.Add(txtFName, 1, 1)
        tlpBasic.Controls.Add(lblGender, 0, 2)
        tlpBasic.Controls.Add(cboGender, 0, 3)
        tlpBasic.Controls.Add(lblBirth, 1, 2)
        tlpBasic.Controls.Add(dtpBirth, 1, 3)
        tlpBasic.Controls.Add(lblCccd, 0, 4)
        tlpBasic.Controls.Add(txtCccd, 0, 5)
        tlpBasic.Controls.Add(lblFStatus, 1, 4)
        tlpBasic.Controls.Add(cboFStatus, 1, 5)
        tlpBasic.Controls.Add(lblAddress, 0, 6)
        tlpBasic.Controls.Add(txtAddress, 0, 7)
        tlpBasic.Dock = DockStyle.Top
        tlpBasic.Location = New Point(20, 136)
        tlpBasic.Name = "tlpBasic"
        tlpBasic.RowCount = 8
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 22F))
        tlpBasic.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        tlpBasic.Size = New Size(1061, 260)
        tlpBasic.TabIndex = 4
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblCode.Location = New Point(3, 0)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(92, 17)
        lblCode.TabIndex = 0
        lblCode.Text = "Mã nhân viên"
        ' 
        ' txtCode
        ' 
        txtCode.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtCode.BorderStyle = BorderStyle.FixedSingle
        txtCode.Dock = DockStyle.Fill
        txtCode.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtCode.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtCode.Location = New Point(0, 22)
        txtCode.Margin = New Padding(0, 0, 8, 4)
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(522, 24)
        txtCode.TabIndex = 1
        ' 
        ' lblFName
        ' 
        lblFName.AutoSize = True
        lblFName.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblFName.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFName.Location = New Point(538, 0)
        lblFName.Margin = New Padding(8, 0, 0, 0)
        lblFName.Name = "lblFName"
        lblFName.Size = New Size(82, 17)
        lblFName.TabIndex = 2
        lblFName.Text = "Họ và tên  *"
        ' 
        ' txtFName
        ' 
        txtFName.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtFName.BorderStyle = BorderStyle.FixedSingle
        txtFName.Dock = DockStyle.Fill
        txtFName.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtFName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtFName.Location = New Point(538, 22)
        txtFName.Margin = New Padding(8, 0, 0, 4)
        txtFName.Name = "txtFName"
        txtFName.Size = New Size(523, 24)
        txtFName.TabIndex = 3
        ' 
        ' lblGender
        ' 
        lblGender.AutoSize = True
        lblGender.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblGender.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblGender.Location = New Point(3, 64)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(62, 17)
        lblGender.TabIndex = 4
        lblGender.Text = "Giới tính"
        ' 
        ' cboGender
        ' 
        cboGender.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboGender.Dock = DockStyle.Fill
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.FlatStyle = FlatStyle.Flat
        cboGender.Font = New Font("Microsoft YaHei UI", 9.5F)
        cboGender.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboGender.Items.AddRange(New Object() {"Nam", "Nữ", "Khác"})
        cboGender.Location = New Point(0, 86)
        cboGender.Margin = New Padding(0, 0, 8, 4)
        cboGender.Name = "cboGender"
        cboGender.Size = New Size(522, 27)
        cboGender.TabIndex = 5
        ' 
        ' lblBirth
        ' 
        lblBirth.AutoSize = True
        lblBirth.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblBirth.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblBirth.Location = New Point(538, 64)
        lblBirth.Margin = New Padding(8, 0, 0, 0)
        lblBirth.Name = "lblBirth"
        lblBirth.Size = New Size(70, 17)
        lblBirth.TabIndex = 6
        lblBirth.Text = "Ngày sinh"
        ' 
        ' dtpBirth
        ' 
        dtpBirth.CalendarForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dtpBirth.CalendarMonthBackground = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        dtpBirth.CalendarTitleBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        dtpBirth.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        dtpBirth.CustomFormat = "dd/MM/yyyy"
        dtpBirth.Dock = DockStyle.Fill
        dtpBirth.Font = New Font("Microsoft YaHei UI", 9.5F)
        dtpBirth.Format = DateTimePickerFormat.Custom
        dtpBirth.Location = New Point(538, 86)
        dtpBirth.Margin = New Padding(8, 0, 0, 4)
        dtpBirth.Name = "dtpBirth"
        dtpBirth.Size = New Size(523, 24)
        dtpBirth.TabIndex = 7
        ' 
        ' lblCccd
        ' 
        lblCccd.AutoSize = True
        lblCccd.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblCccd.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblCccd.Location = New Point(3, 128)
        lblCccd.Name = "lblCccd"
        lblCccd.Size = New Size(96, 17)
        lblCccd.TabIndex = 8
        lblCccd.Text = "CCCD / CMND"
        ' 
        ' txtCccd
        ' 
        txtCccd.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtCccd.BorderStyle = BorderStyle.FixedSingle
        txtCccd.Dock = DockStyle.Fill
        txtCccd.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtCccd.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtCccd.Location = New Point(0, 150)
        txtCccd.Margin = New Padding(0, 0, 8, 4)
        txtCccd.Name = "txtCccd"
        txtCccd.Size = New Size(522, 24)
        txtCccd.TabIndex = 9
        ' 
        ' lblFStatus
        ' 
        lblFStatus.AutoSize = True
        lblFStatus.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblFStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblFStatus.Location = New Point(538, 128)
        lblFStatus.Margin = New Padding(8, 0, 0, 0)
        lblFStatus.Name = "lblFStatus"
        lblFStatus.Size = New Size(73, 17)
        lblFStatus.TabIndex = 10
        lblFStatus.Text = "Trạng thái"
        ' 
        ' cboFStatus
        ' 
        cboFStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboFStatus.Dock = DockStyle.Fill
        cboFStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboFStatus.FlatStyle = FlatStyle.Flat
        cboFStatus.Font = New Font("Microsoft YaHei UI", 9.5F)
        cboFStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboFStatus.Items.AddRange(New Object() {"Đang làm việc", "Nghỉ việc"})
        cboFStatus.Location = New Point(538, 150)
        cboFStatus.Margin = New Padding(8, 0, 0, 4)
        cboFStatus.Name = "cboFStatus"
        cboFStatus.Size = New Size(523, 27)
        cboFStatus.TabIndex = 11
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        tlpBasic.SetColumnSpan(lblAddress, 2)
        lblAddress.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold)
        lblAddress.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblAddress.Location = New Point(3, 192)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(51, 17)
        lblAddress.TabIndex = 12
        lblAddress.Text = "Địa chỉ"
        ' 
        ' txtAddress
        ' 
        txtAddress.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtAddress.BorderStyle = BorderStyle.FixedSingle
        tlpBasic.SetColumnSpan(txtAddress, 2)
        txtAddress.Dock = DockStyle.Fill
        txtAddress.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtAddress.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtAddress.Location = New Point(0, 214)
        txtAddress.Margin = New Padding(0, 0, 0, 4)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(1061, 24)
        txtAddress.TabIndex = 13
        ' 
        ' lblSec1
        ' 
        lblSec1.BackColor = Color.Transparent
        lblSec1.Dock = DockStyle.Top
        lblSec1.Font = New Font("Microsoft YaHei UI", 8F, FontStyle.Bold)
        lblSec1.ForeColor = Color.FromArgb(CByte(61), CByte(74), CByte(114))
        lblSec1.Location = New Point(20, 104)
        lblSec1.Name = "lblSec1"
        lblSec1.Padding = New Padding(0, 10, 0, 0)
        lblSec1.Size = New Size(1061, 32)
        lblSec1.TabIndex = 5
        lblSec1.Text = "THÔNG TIN CƠ BẢN"
        ' 
        ' pnlDetailHeader
        ' 
        pnlDetailHeader.BackColor = Color.Transparent
        pnlDetailHeader.Controls.Add(lblDetailStatus)
        pnlDetailHeader.Controls.Add(lblDetailCode)
        pnlDetailHeader.Controls.Add(lblDetailName)
        pnlDetailHeader.Controls.Add(pnlAvatarCircle)
        pnlDetailHeader.Dock = DockStyle.Top
        pnlDetailHeader.Location = New Point(20, 16)
        pnlDetailHeader.Name = "pnlDetailHeader"
        pnlDetailHeader.Size = New Size(1061, 88)
        pnlDetailHeader.TabIndex = 6
        ' 
        ' lblDetailStatus
        ' 
        lblDetailStatus.AutoSize = True
        lblDetailStatus.BackColor = Color.FromArgb(CByte(20), CByte(76), CByte(175), CByte(80))
        lblDetailStatus.Font = New Font("Microsoft YaHei UI", 8.5F)
        lblDetailStatus.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        lblDetailStatus.Location = New Point(78, 60)
        lblDetailStatus.Name = "lblDetailStatus"
        lblDetailStatus.Padding = New Padding(6, 2, 6, 2)
        lblDetailStatus.Size = New Size(114, 21)
        lblDetailStatus.TabIndex = 0
        lblDetailStatus.Text = "● Đang làm việc"
        ' 
        ' lblDetailCode
        ' 
        lblDetailCode.AutoSize = True
        lblDetailCode.Font = New Font("Microsoft YaHei UI", 8.5F)
        lblDetailCode.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDetailCode.Location = New Point(80, 40)
        lblDetailCode.Name = "lblDetailCode"
        lblDetailCode.Size = New Size(145, 17)
        lblDetailCode.TabIndex = 1
        lblDetailCode.Text = "Điền thông tin bên dưới"
        ' 
        ' lblDetailName
        ' 
        lblDetailName.AutoSize = True
        lblDetailName.Font = New Font("Microsoft YaHei UI", 14F, FontStyle.Bold)
        lblDetailName.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        lblDetailName.Location = New Point(78, 10)
        lblDetailName.Name = "lblDetailName"
        lblDetailName.Size = New Size(208, 26)
        lblDetailName.TabIndex = 2
        lblDetailName.Text = "Thêm nhân viên mới"
        ' 
        ' pnlAvatarCircle
        ' 
        pnlAvatarCircle.BackColor = Color.FromArgb(CByte(59), CByte(125), CByte(216))
        pnlAvatarCircle.Location = New Point(0, 10)
        pnlAvatarCircle.Name = "pnlAvatarCircle"
        pnlAvatarCircle.Size = New Size(62, 62)
        pnlAvatarCircle.TabIndex = 3
        ' 
        ' pnlDetailFooter
        ' 
        pnlDetailFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlDetailFooter.Controls.Add(btnSave)
        pnlDetailFooter.Controls.Add(btnClear)
        pnlDetailFooter.Controls.Add(btnDelete)
        pnlDetailFooter.Dock = DockStyle.Bottom
        pnlDetailFooter.Location = New Point(0, 351)
        pnlDetailFooter.Name = "pnlDetailFooter"
        pnlDetailFooter.Size = New Size(1118, 52)
        pnlDetailFooter.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSave.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(953, 10)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(130, 32)
        btnSave.TabIndex = 2
        btnSave.Text = "✓  Lưu thông tin"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnClear.Cursor = Cursors.Hand
        btnClear.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Microsoft YaHei UI", 9F)
        btnClear.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnClear.Location = New Point(843, 10)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 32)
        btnClear.TabIndex = 1
        btnClear.Text = "Làm mới"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.FromArgb(CByte(25), CByte(229), CByte(62), CByte(62))
        btnDelete.Cursor = Cursors.Hand
        btnDelete.FlatAppearance.BorderColor = Color.FromArgb(CByte(80), CByte(229), CByte(62), CByte(62))
        btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(50), CByte(229), CByte(62), CByte(62))
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Microsoft YaHei UI", 9F)
        btnDelete.ForeColor = Color.FromArgb(CByte(240), CByte(128), CByte(128))
        btnDelete.Location = New Point(14, 10)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(130, 32)
        btnDelete.TabIndex = 0
        btnDelete.Text = "Xóa nhân viên"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' pnlTab1
        ' 
        pnlTab1.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlTab1.Controls.Add(dgvEmployee)
        pnlTab1.Controls.Add(pnlTableFooter)
        pnlTab1.Dock = DockStyle.Fill
        pnlTab1.Location = New Point(0, 0)
        pnlTab1.Name = "pnlTab1"
        pnlTab1.Size = New Size(1118, 403)
        pnlTab1.TabIndex = 2
        ' 
        ' dgvEmployee
        ' 
        dgvEmployee.AllowUserToAddRows = False
        dgvEmployee.AllowUserToDeleteRows = False
        dgvEmployee.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(32), CByte(36), CByte(55))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        dgvEmployee.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvEmployee.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEmployee.BackgroundColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        dgvEmployee.BorderStyle = BorderStyle.None
        dgvEmployee.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvEmployee.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvEmployee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvEmployee.ColumnHeadersHeight = 40
        dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvEmployee.Columns.AddRange(New DataGridViewColumn() {colChk, colAvatar, colName, colCode, colGender, colDept, colJob, colEmail, colPhone, colContractType, colStatusDgv, colActions})
        dgvEmployee.Cursor = Cursors.Hand
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        DataGridViewCellStyle8.Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle8.Padding = New Padding(6, 0, 0, 0)
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(30), CByte(74), CByte(158), CByte(255))
        DataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvEmployee.DefaultCellStyle = DataGridViewCellStyle8
        dgvEmployee.EnableHeadersVisualStyles = False
        dgvEmployee.GridColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        dgvEmployee.Location = New Point(0, 0)
        dgvEmployee.Name = "dgvEmployee"
        dgvEmployee.RowHeadersVisible = False
        dgvEmployee.RowHeadersWidth = 51
        dgvEmployee.RowTemplate.Height = 52
        dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEmployee.Size = New Size(833, 246)
        dgvEmployee.TabIndex = 0
        ' 
        ' colChk
        ' 
        colChk.HeaderText = ""
        colChk.MinimumWidth = 6
        colChk.Name = "colChk"
        colChk.Resizable = DataGridViewTriState.False
        colChk.Width = 36
        ' 
        ' colAvatar
        ' 
        colAvatar.HeaderText = ""
        colAvatar.MinimumWidth = 6
        colAvatar.Name = "colAvatar"
        colAvatar.ReadOnly = True
        colAvatar.Resizable = DataGridViewTriState.False
        colAvatar.Width = 52
        ' 
        ' colName
        ' 
        colName.HeaderText = "HỌ VÀ TÊN"
        colName.MinimumWidth = 6
        colName.Name = "colName"
        colName.ReadOnly = True
        colName.Width = 180
        ' 
        ' colCode
        ' 
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colCode.DefaultCellStyle = DataGridViewCellStyle3
        colCode.HeaderText = "MÃ NV"
        colCode.MinimumWidth = 6
        colCode.Name = "colCode"
        colCode.ReadOnly = True
        colCode.Width = 90
        ' 
        ' colGender
        ' 
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colGender.DefaultCellStyle = DataGridViewCellStyle4
        colGender.HeaderText = "GIỚI TÍNH"
        colGender.MinimumWidth = 6
        colGender.Name = "colGender"
        colGender.ReadOnly = True
        colGender.Width = 80
        ' 
        ' colDept
        ' 
        colDept.HeaderText = "PHÒNG BAN"
        colDept.MinimumWidth = 6
        colDept.Name = "colDept"
        colDept.ReadOnly = True
        colDept.Width = 120
        ' 
        ' colJob
        ' 
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colJob.DefaultCellStyle = DataGridViewCellStyle5
        colJob.HeaderText = "VỊ TRÍ"
        colJob.MinimumWidth = 6
        colJob.Name = "colJob"
        colJob.ReadOnly = True
        colJob.Width = 140
        ' 
        ' colEmail
        ' 
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colEmail.DefaultCellStyle = DataGridViewCellStyle6
        colEmail.HeaderText = "EMAIL"
        colEmail.MinimumWidth = 6
        colEmail.Name = "colEmail"
        colEmail.ReadOnly = True
        colEmail.Width = 190
        ' 
        ' colPhone
        ' 
        DataGridViewCellStyle7.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        colPhone.DefaultCellStyle = DataGridViewCellStyle7
        colPhone.HeaderText = "SĐT"
        colPhone.MinimumWidth = 6
        colPhone.Name = "colPhone"
        colPhone.ReadOnly = True
        colPhone.Width = 110
        ' 
        ' colContractType
        ' 
        colContractType.HeaderText = "HỢP ĐỒNG"
        colContractType.MinimumWidth = 6
        colContractType.Name = "colContractType"
        colContractType.ReadOnly = True
        colContractType.Width = 110
        ' 
        ' colStatusDgv
        ' 
        colStatusDgv.HeaderText = "TRẠNG THÁI"
        colStatusDgv.MinimumWidth = 6
        colStatusDgv.Name = "colStatusDgv"
        colStatusDgv.ReadOnly = True
        colStatusDgv.Width = 110
        ' 
        ' colActions
        ' 
        colActions.HeaderText = ""
        colActions.MinimumWidth = 6
        colActions.Name = "colActions"
        colActions.ReadOnly = True
        colActions.Resizable = DataGridViewTriState.False
        colActions.Width = 80
        ' 
        ' pnlTableFooter
        ' 
        pnlTableFooter.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlTableFooter.Controls.Add(pnlPageBtns)
        pnlTableFooter.Controls.Add(lblRowInfo)
        pnlTableFooter.Dock = DockStyle.Bottom
        pnlTableFooter.Location = New Point(0, 359)
        pnlTableFooter.Name = "pnlTableFooter"
        pnlTableFooter.Size = New Size(1118, 44)
        pnlTableFooter.TabIndex = 1
        ' 
        ' pnlPageBtns
        ' 
        pnlPageBtns.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        pnlPageBtns.BackColor = Color.Transparent
        pnlPageBtns.Controls.Add(btnPageNext)
        pnlPageBtns.Controls.Add(btnPage2)
        pnlPageBtns.Controls.Add(btnPage1)
        pnlPageBtns.Controls.Add(btnPagePrev)
        pnlPageBtns.Location = New Point(873, 7)
        pnlPageBtns.Name = "pnlPageBtns"
        pnlPageBtns.Size = New Size(130, 30)
        pnlPageBtns.TabIndex = 0
        ' 
        ' btnPageNext
        ' 
        btnPageNext.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPageNext.Cursor = Cursors.Hand
        btnPageNext.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPageNext.FlatStyle = FlatStyle.Flat
        btnPageNext.Font = New Font("Microsoft YaHei UI", 8.5F)
        btnPageNext.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPageNext.Location = New Point(102, 0)
        btnPageNext.Name = "btnPageNext"
        btnPageNext.Size = New Size(30, 30)
        btnPageNext.TabIndex = 0
        btnPageNext.Text = "›"
        btnPageNext.UseVisualStyleBackColor = False
        ' 
        ' btnPage2
        ' 
        btnPage2.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPage2.Cursor = Cursors.Hand
        btnPage2.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPage2.FlatStyle = FlatStyle.Flat
        btnPage2.Font = New Font("Microsoft YaHei UI", 8.5F)
        btnPage2.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPage2.Location = New Point(68, 0)
        btnPage2.Name = "btnPage2"
        btnPage2.Size = New Size(30, 30)
        btnPage2.TabIndex = 1
        btnPage2.Text = "2"
        btnPage2.UseVisualStyleBackColor = False
        ' 
        ' btnPage1
        ' 
        btnPage1.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnPage1.Cursor = Cursors.Hand
        btnPage1.FlatAppearance.BorderSize = 0
        btnPage1.FlatStyle = FlatStyle.Flat
        btnPage1.Font = New Font("Microsoft YaHei UI", 8.5F)
        btnPage1.ForeColor = Color.White
        btnPage1.Location = New Point(34, 0)
        btnPage1.Name = "btnPage1"
        btnPage1.Size = New Size(30, 30)
        btnPage1.TabIndex = 2
        btnPage1.Text = "1"
        btnPage1.UseVisualStyleBackColor = False
        ' 
        ' btnPagePrev
        ' 
        btnPagePrev.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnPagePrev.Cursor = Cursors.Hand
        btnPagePrev.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnPagePrev.FlatStyle = FlatStyle.Flat
        btnPagePrev.Font = New Font("Microsoft YaHei UI", 8.5F)
        btnPagePrev.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnPagePrev.Location = New Point(0, 0)
        btnPagePrev.Name = "btnPagePrev"
        btnPagePrev.Size = New Size(30, 30)
        btnPagePrev.TabIndex = 3
        btnPagePrev.Text = "‹"
        btnPagePrev.UseVisualStyleBackColor = False
        ' 
        ' lblRowInfo
        ' 
        lblRowInfo.AutoSize = True
        lblRowInfo.Font = New Font("Microsoft YaHei UI", 8.5F)
        lblRowInfo.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblRowInfo.Location = New Point(16, 14)
        lblRowInfo.Name = "lblRowInfo"
        lblRowInfo.Size = New Size(122, 17)
        lblRowInfo.TabIndex = 1
        lblRowInfo.Text = "Hiển thị 0 nhân viên"
        ' 
        ' pnlTabBar
        ' 
        pnlTabBar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlTabBar.Controls.Add(pnlTabIndicator)
        pnlTabBar.Controls.Add(btnTabContract)
        pnlTabBar.Controls.Add(btnTabDetail)
        pnlTabBar.Controls.Add(btnTabList)
        pnlTabBar.Dock = DockStyle.Top
        pnlTabBar.Location = New Point(0, 52)
        pnlTabBar.Name = "pnlTabBar"
        pnlTabBar.Size = New Size(1118, 44)
        pnlTabBar.TabIndex = 1
        ' 
        ' pnlTabIndicator
        ' 
        pnlTabIndicator.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        pnlTabIndicator.Location = New Point(0, 41)
        pnlTabIndicator.Name = "pnlTabIndicator"
        pnlTabIndicator.Size = New Size(160, 3)
        pnlTabIndicator.TabIndex = 0
        ' 
        ' btnTabContract
        ' 
        btnTabContract.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTabContract.Cursor = Cursors.Hand
        btnTabContract.FlatAppearance.BorderSize = 0
        btnTabContract.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTabContract.FlatStyle = FlatStyle.Flat
        btnTabContract.Font = New Font("Microsoft YaHei UI", 9.5F)
        btnTabContract.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnTabContract.Location = New Point(320, 0)
        btnTabContract.Name = "btnTabContract"
        btnTabContract.Size = New Size(180, 42)
        btnTabContract.TabIndex = 2
        btnTabContract.Text = "Hợp đồng & Vị trí"
        btnTabContract.UseVisualStyleBackColor = False
        ' 
        ' btnTabDetail
        ' 
        btnTabDetail.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTabDetail.Cursor = Cursors.Hand
        btnTabDetail.FlatAppearance.BorderSize = 0
        btnTabDetail.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTabDetail.FlatStyle = FlatStyle.Flat
        btnTabDetail.Font = New Font("Microsoft YaHei UI", 9.5F)
        btnTabDetail.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnTabDetail.Location = New Point(160, 0)
        btnTabDetail.Name = "btnTabDetail"
        btnTabDetail.Size = New Size(160, 42)
        btnTabDetail.TabIndex = 1
        btnTabDetail.Text = "Thông tin cá nhân"
        btnTabDetail.UseVisualStyleBackColor = False
        ' 
        ' btnTabList
        ' 
        btnTabList.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        btnTabList.Cursor = Cursors.Hand
        btnTabList.FlatAppearance.BorderSize = 0
        btnTabList.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(28), CByte(32), CByte(52))
        btnTabList.FlatStyle = FlatStyle.Flat
        btnTabList.Font = New Font("Microsoft YaHei UI", 9.5F)
        btnTabList.ForeColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnTabList.Location = New Point(0, 0)
        btnTabList.Name = "btnTabList"
        btnTabList.Size = New Size(160, 42)
        btnTabList.TabIndex = 0
        btnTabList.Text = "Danh sách"
        btnTabList.UseVisualStyleBackColor = False
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(21), CByte(24), CByte(36))
        pnlToolbar.Controls.Add(btnAdd)
        pnlToolbar.Controls.Add(btnExport)
        pnlToolbar.Controls.Add(cboStatus)
        pnlToolbar.Controls.Add(cboDept)
        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(0, 0)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Size = New Size(1118, 52)
        pnlToolbar.TabIndex = 2
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAdd.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnAdd.Cursor = Cursors.Hand
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(58), CByte(138), CByte(224))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(813, 11)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(154, 30)
        btnAdd.TabIndex = 4
        btnAdd.Text = "+ Thêm nhân viên"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnExport
        ' 
        btnExport.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnExport.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderColor = Color.FromArgb(CByte(42), CByte(48), CByte(80))
        btnExport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(48), CByte(55), CByte(85))
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Microsoft YaHei UI", 8.5F)
        btnExport.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        btnExport.Location = New Point(703, 11)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(100, 30)
        btnExport.TabIndex = 3
        btnExport.Text = "Xuất Excel"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' cboStatus
        ' 
        cboStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FlatStyle = FlatStyle.Flat
        cboStatus.Font = New Font("Microsoft YaHei UI", 8.5F)
        cboStatus.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboStatus.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang làm việc", "Nghỉ việc"})
        cboStatus.Location = New Point(464, 11)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(150, 24)
        cboStatus.TabIndex = 2
        ' 
        ' cboDept
        ' 
        cboDept.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboDept.DropDownStyle = ComboBoxStyle.DropDownList
        cboDept.FlatStyle = FlatStyle.Flat
        cboDept.Font = New Font("Microsoft YaHei UI", 8.5F)
        cboDept.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboDept.Items.AddRange(New Object() {"Tất cả phòng ban", "Kỹ thuật", "Kế toán", "Nhân sự", "Marketing", "Kinh doanh", "Vận hành"})
        cboDept.Location = New Point(282, 11)
        cboDept.Name = "cboDept"
        cboDept.Size = New Size(172, 24)
        cboDept.TabIndex = 1
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Microsoft YaHei UI", 9.5F)
        txtSearch.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtSearch.Location = New Point(12, 11)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(260, 24)
        txtSearch.TabIndex = 0
        ' 
        ' formEmployee
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(1118, 499)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "formEmployee"
        Text = "Nhân viên"
        pnlRoot.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlTab3.ResumeLayout(False)
        pnlContractFooter.ResumeLayout(False)
        pnlContractFooter.PerformLayout()
        pnlTab2.ResumeLayout(False)
        pnlDetailScroll.ResumeLayout(False)
        pnlDetailScroll.PerformLayout()
        tlpContact.ResumeLayout(False)
        tlpContact.PerformLayout()
        tlpBasic.ResumeLayout(False)
        tlpBasic.PerformLayout()
        pnlDetailHeader.ResumeLayout(False)
        pnlDetailHeader.PerformLayout()
        pnlDetailFooter.ResumeLayout(False)
        pnlTab1.ResumeLayout(False)
        CType(dgvEmployee, ComponentModel.ISupportInitialize).EndInit()
        pnlTableFooter.ResumeLayout(False)
        pnlTableFooter.PerformLayout()
        pnlPageBtns.ResumeLayout(False)
        pnlTabBar.ResumeLayout(False)
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        ResumeLayout(False)

    End Sub

    ' ── Declarations ──────────────────────────────────────────
    Friend WithEvents pnlRoot As System.Windows.Forms.Panel
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pnlTabBar As System.Windows.Forms.Panel
    Friend WithEvents btnTabList As System.Windows.Forms.Button
    Friend WithEvents btnTabDetail As System.Windows.Forms.Button
    Friend WithEvents btnTabContract As System.Windows.Forms.Button
    Friend WithEvents pnlTabIndicator As System.Windows.Forms.Panel
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlTab1 As System.Windows.Forms.Panel
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents colChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colAvatar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContractType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatusDgv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlTableFooter As System.Windows.Forms.Panel
    Friend WithEvents lblRowInfo As System.Windows.Forms.Label
    Friend WithEvents pnlPageBtns As System.Windows.Forms.Panel
    Friend WithEvents btnPagePrev As System.Windows.Forms.Button
    Friend WithEvents btnPage1 As System.Windows.Forms.Button
    Friend WithEvents btnPage2 As System.Windows.Forms.Button
    Friend WithEvents btnPageNext As System.Windows.Forms.Button
    Friend WithEvents pnlTab2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlDetailHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAvatarCircle As System.Windows.Forms.Panel
    Friend WithEvents lblDetailName As System.Windows.Forms.Label
    Friend WithEvents lblDetailCode As System.Windows.Forms.Label
    Friend WithEvents lblDetailStatus As System.Windows.Forms.Label
    Friend WithEvents lblSec1 As System.Windows.Forms.Label
    Friend WithEvents tlpBasic As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblBirth As System.Windows.Forms.Label
    Friend WithEvents dtpBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCccd As System.Windows.Forms.Label
    Friend WithEvents txtCccd As System.Windows.Forms.TextBox
    Friend WithEvents lblFStatus As System.Windows.Forms.Label
    Friend WithEvents cboFStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblSec2 As System.Windows.Forms.Label
    Friend WithEvents tlpContact As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblBank As System.Windows.Forms.Label
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents lblSec3 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlDetailFooter As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlTab3 As System.Windows.Forms.Panel
    Friend WithEvents pnlContractScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlContractFooter As System.Windows.Forms.Panel
    Friend WithEvents lblContractEmp As System.Windows.Forms.Label
    Friend WithEvents btnAddContract As System.Windows.Forms.Button

End Class