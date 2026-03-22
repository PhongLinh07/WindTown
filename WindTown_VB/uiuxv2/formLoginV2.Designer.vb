<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formLoginV2
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New System.ComponentModel.Container()
        pnlRoot = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        tabMain = New TabControl()
        tabLogin = New TabPage()
        lblLoginUser = New Label()
        txtLoginUser = New TextBox()
        lblLoginPass = New Label()
        txtLoginPass = New TextBox()
        btnLogin = New Button()
        tabRegister = New TabPage()
        lblRegUser = New Label()
        txtRegUser = New TextBox()
        lblRegPass = New Label()
        txtRegPass = New TextBox()
        lblRegConfirm = New Label()
        txtRegConfirm = New TextBox()
        lblRegEmp = New Label()
        cboEmployee = New ComboBox()
        btnRegister = New Button()
        lblDbStatus = New Label()
        errReg = New ErrorProvider(components)
        pnlRoot.SuspendLayout()
        tabMain.SuspendLayout()
        tabLogin.SuspendLayout()
        tabRegister.SuspendLayout()
        SuspendLayout()
        '
        ' pnlRoot
        '
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(lblDbStatus)
        pnlRoot.Controls.Add(tabMain)
        pnlRoot.Controls.Add(lblSubtitle)
        pnlRoot.Controls.Add(lblTitle)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Padding = New Padding(24, 20, 24, 16)
        pnlRoot.Size = New Size(520, 560)
        pnlRoot.TabIndex = 0
        '
        ' lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Microsoft YaHei UI", 16.0!, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblTitle.Location = New Point(24, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(120, 30)
        lblTitle.TabIndex = 0
        lblTitle.Text = "WindTown"
        '
        ' lblSubtitle
        '
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblSubtitle.Location = New Point(26, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(280, 17)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Đăng nhập hoặc đăng ký tài khoản nhân viên"
        '
        ' tabMain
        '
        tabMain.Controls.Add(tabLogin)
        tabMain.Controls.Add(tabRegister)
        tabMain.Font = New Font("Microsoft YaHei UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabMain.ItemSize = New Size(120, 32)
        tabMain.Location = New Point(24, 88)
        tabMain.Name = "tabMain"
        tabMain.SelectedIndex = 0
        tabMain.Size = New Size(472, 380)
        tabMain.TabIndex = 2
        '
        ' tabLogin
        '
        tabLogin.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        tabLogin.Controls.Add(btnLogin)
        tabLogin.Controls.Add(txtLoginPass)
        tabLogin.Controls.Add(lblLoginPass)
        tabLogin.Controls.Add(txtLoginUser)
        tabLogin.Controls.Add(lblLoginUser)
        tabLogin.Location = New Point(4, 36)
        tabLogin.Name = "tabLogin"
        tabLogin.Padding = New Padding(16)
        tabLogin.Size = New Size(464, 340)
        tabLogin.TabIndex = 0
        tabLogin.Text = "Đăng nhập"
        '
        ' lblLoginUser
        '
        lblLoginUser.AutoSize = True
        lblLoginUser.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblLoginUser.Location = New Point(16, 24)
        lblLoginUser.Name = "lblLoginUser"
        lblLoginUser.Size = New Size(99, 17)
        lblLoginUser.TabIndex = 0
        lblLoginUser.Text = "Tên đăng nhập"
        '
        ' txtLoginUser
        '
        txtLoginUser.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtLoginUser.BorderStyle = BorderStyle.FixedSingle
        txtLoginUser.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtLoginUser.Location = New Point(16, 48)
        txtLoginUser.Name = "txtLoginUser"
        txtLoginUser.Size = New Size(424, 23)
        txtLoginUser.TabIndex = 1
        '
        ' lblLoginPass
        '
        lblLoginPass.AutoSize = True
        lblLoginPass.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblLoginPass.Location = New Point(16, 88)
        lblLoginPass.Name = "lblLoginPass"
        lblLoginPass.Size = New Size(61, 17)
        lblLoginPass.TabIndex = 2
        lblLoginPass.Text = "Mật khẩu"
        '
        ' txtLoginPass
        '
        txtLoginPass.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtLoginPass.BorderStyle = BorderStyle.FixedSingle
        txtLoginPass.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtLoginPass.Location = New Point(16, 112)
        txtLoginPass.Name = "txtLoginPass"
        txtLoginPass.PasswordChar = "*"c
        txtLoginPass.Size = New Size(424, 23)
        txtLoginPass.TabIndex = 3
        '
        ' btnLogin
        '
        btnLogin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLogin.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Microsoft YaHei UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(16, 168)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(424, 40)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Đăng nhập"
        btnLogin.UseVisualStyleBackColor = False
        '
        ' tabRegister
        '
        tabRegister.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        tabRegister.Controls.Add(btnRegister)
        tabRegister.Controls.Add(cboEmployee)
        tabRegister.Controls.Add(lblRegEmp)
        tabRegister.Controls.Add(txtRegConfirm)
        tabRegister.Controls.Add(lblRegConfirm)
        tabRegister.Controls.Add(txtRegPass)
        tabRegister.Controls.Add(lblRegPass)
        tabRegister.Controls.Add(txtRegUser)
        tabRegister.Controls.Add(lblRegUser)
        tabRegister.Location = New Point(4, 36)
        tabRegister.Name = "tabRegister"
        tabRegister.Padding = New Padding(16)
        tabRegister.Size = New Size(464, 340)
        tabRegister.TabIndex = 1
        tabRegister.Text = "Đăng ký"
        '
        ' lblRegUser
        '
        lblRegUser.AutoSize = True
        lblRegUser.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblRegUser.Location = New Point(16, 16)
        lblRegUser.Name = "lblRegUser"
        lblRegUser.Size = New Size(99, 17)
        lblRegUser.TabIndex = 0
        lblRegUser.Text = "Tên đăng nhập"
        '
        ' txtRegUser
        '
        txtRegUser.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtRegUser.BorderStyle = BorderStyle.FixedSingle
        txtRegUser.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtRegUser.Location = New Point(16, 40)
        txtRegUser.Name = "txtRegUser"
        txtRegUser.Size = New Size(424, 23)
        txtRegUser.TabIndex = 1
        '
        ' lblRegPass
        '
        lblRegPass.AutoSize = True
        lblRegPass.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblRegPass.Location = New Point(16, 72)
        lblRegPass.Name = "lblRegPass"
        lblRegPass.Size = New Size(61, 17)
        lblRegPass.TabIndex = 2
        lblRegPass.Text = "Mật khẩu"
        '
        ' txtRegPass
        '
        txtRegPass.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtRegPass.BorderStyle = BorderStyle.FixedSingle
        txtRegPass.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtRegPass.Location = New Point(16, 96)
        txtRegPass.Name = "txtRegPass"
        txtRegPass.PasswordChar = "*"c
        txtRegPass.Size = New Size(424, 23)
        txtRegPass.TabIndex = 3
        '
        ' lblRegConfirm
        '
        lblRegConfirm.AutoSize = True
        lblRegConfirm.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblRegConfirm.Location = New Point(16, 128)
        lblRegConfirm.Name = "lblRegConfirm"
        lblRegConfirm.Size = New Size(122, 17)
        lblRegConfirm.TabIndex = 4
        lblRegConfirm.Text = "Xác nhận mật khẩu"
        '
        ' txtRegConfirm
        '
        txtRegConfirm.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtRegConfirm.BorderStyle = BorderStyle.FixedSingle
        txtRegConfirm.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        txtRegConfirm.Location = New Point(16, 152)
        txtRegConfirm.Name = "txtRegConfirm"
        txtRegConfirm.PasswordChar = "*"c
        txtRegConfirm.Size = New Size(424, 23)
        txtRegConfirm.TabIndex = 5
        '
        ' lblRegEmp
        '
        lblRegEmp.AutoSize = True
        lblRegEmp.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblRegEmp.Location = New Point(16, 184)
        lblRegEmp.Name = "lblRegEmp"
        lblRegEmp.Size = New Size(70, 17)
        lblRegEmp.TabIndex = 6
        lblRegEmp.Text = "Nhân viên"
        '
        ' cboEmployee
        '
        cboEmployee.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList
        cboEmployee.FlatStyle = FlatStyle.Flat
        cboEmployee.ForeColor = Color.FromArgb(CByte(232), CByte(236), CByte(240))
        cboEmployee.Location = New Point(16, 208)
        cboEmployee.Name = "cboEmployee"
        cboEmployee.Size = New Size(424, 25)
        cboEmployee.TabIndex = 7
        '
        ' btnRegister
        '
        btnRegister.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRegister.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.Font = New Font("Microsoft YaHei UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegister.ForeColor = Color.White
        btnRegister.Location = New Point(16, 260)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(424, 40)
        btnRegister.TabIndex = 8
        btnRegister.Text = "Đăng ký"
        btnRegister.UseVisualStyleBackColor = False
        '
        ' lblDbStatus
        '
        lblDbStatus.AutoSize = True
        lblDbStatus.Font = New Font("Microsoft YaHei UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDbStatus.ForeColor = Color.FromArgb(CByte(123), CByte(139), CByte(178))
        lblDbStatus.Location = New Point(24, 478)
        lblDbStatus.Name = "lblDbStatus"
        lblDbStatus.Size = New Size(0, 16)
        lblDbStatus.TabIndex = 3
        '
        ' errReg
        '
        errReg.ContainerControl = Me
        '
        ' formLoginV2
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(520, 560)
        Controls.Add(pnlRoot)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "formLoginV2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "WindTown — Đăng nhập"
        pnlRoot.ResumeLayout(False)
        pnlRoot.PerformLayout()
        tabMain.ResumeLayout(False)
        tabLogin.ResumeLayout(False)
        tabLogin.PerformLayout()
        tabRegister.ResumeLayout(False)
        tabRegister.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlRoot As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabLogin As TabPage
    Friend WithEvents tabRegister As TabPage
    Friend WithEvents lblLoginUser As Label
    Friend WithEvents txtLoginUser As TextBox
    Friend WithEvents lblLoginPass As Label
    Friend WithEvents txtLoginPass As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblRegUser As Label
    Friend WithEvents txtRegUser As TextBox
    Friend WithEvents lblRegPass As Label
    Friend WithEvents txtRegPass As TextBox
    Friend WithEvents lblRegConfirm As Label
    Friend WithEvents txtRegConfirm As TextBox
    Friend WithEvents lblRegEmp As Label
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents lblDbStatus As Label
    Friend WithEvents errReg As ErrorProvider
End Class
