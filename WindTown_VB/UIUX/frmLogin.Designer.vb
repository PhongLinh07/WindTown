<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlpLogin = New System.Windows.Forms.TableLayoutPanel()
        Me.pnLogin = New System.Windows.Forms.Panel()
        Me.lbQuenMK = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.tbxPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnLogoApp = New System.Windows.Forms.Panel()
        Me.tlpLogin.SuspendLayout()
        Me.pnLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpLogin
        '
        Me.tlpLogin.ColumnCount = 2
        Me.tlpLogin.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogin.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogin.Controls.Add(Me.pnLogin, 1, 0)
        Me.tlpLogin.Controls.Add(Me.pnLogoApp, 0, 0)
        Me.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLogin.Location = New System.Drawing.Point(0, 0)
        Me.tlpLogin.Name = "tlpLogin"
        Me.tlpLogin.RowCount = 1
        Me.tlpLogin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLogin.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpLogin.Size = New System.Drawing.Size(1000, 647)
        Me.tlpLogin.TabIndex = 0
        '
        'pnLogin
        '
        Me.pnLogin.BackColor = System.Drawing.Color.DarkOrange
        Me.pnLogin.Controls.Add(Me.lbQuenMK)
        Me.pnLogin.Controls.Add(Me.btnRegister)
        Me.pnLogin.Controls.Add(Me.btnLogin)
        Me.pnLogin.Controls.Add(Me.tbxPassword)
        Me.pnLogin.Controls.Add(Me.Label3)
        Me.pnLogin.Controls.Add(Me.tbxUsername)
        Me.pnLogin.Controls.Add(Me.Label2)
        Me.pnLogin.Controls.Add(Me.Label1)
        Me.pnLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnLogin.Location = New System.Drawing.Point(503, 3)
        Me.pnLogin.Name = "pnLogin"
        Me.pnLogin.Size = New System.Drawing.Size(494, 641)
        Me.pnLogin.TabIndex = 1
        '
        'lbQuenMK
        '
        Me.lbQuenMK.AutoSize = True
        Me.lbQuenMK.BackColor = System.Drawing.Color.Transparent
        Me.lbQuenMK.ForeColor = System.Drawing.Color.White
        Me.lbQuenMK.Location = New System.Drawing.Point(223, 418)
        Me.lbQuenMK.Name = "lbQuenMK"
        Me.lbQuenMK.Size = New System.Drawing.Size(141, 23)
        Me.lbQuenMK.TabIndex = 5
        Me.lbQuenMK.Text = "Quên mật khẩu?"
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.Green
        Me.btnRegister.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(106, 365)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(260, 50)
        Me.btnRegister.TabIndex = 4
        Me.btnRegister.Text = "Đăng ký"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(106, 294)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(260, 50)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Đăng nhập"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'tbxPassword
        '
        Me.tbxPassword.Location = New System.Drawing.Point(106, 245)
        Me.tbxPassword.Name = "tbxPassword"
        Me.tbxPassword.Size = New System.Drawing.Size(258, 29)
        Me.tbxPassword.TabIndex = 2
        Me.tbxPassword.Text = "123"
        Me.tbxPassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(102, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Mật khẩu"
        '
        'tbxUsername
        '
        Me.tbxUsername.Location = New System.Drawing.Point(106, 176)
        Me.tbxUsername.Name = "tbxUsername"
        Me.tbxUsername.Size = New System.Drawing.Size(258, 29)
        Me.tbxUsername.TabIndex = 1
        Me.tbxUsername.Text = "admin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(102, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tên đăng nhập"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(199, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Đăng nhập"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnLogoApp
        '
        Me.pnLogoApp.BackColor = System.Drawing.Color.Transparent
        Me.pnLogoApp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnLogoApp.Location = New System.Drawing.Point(3, 3)
        Me.pnLogoApp.Name = "pnLogoApp"
        Me.pnLogoApp.Size = New System.Drawing.Size(494, 641)
        Me.pnLogoApp.TabIndex = 0
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 647)
        Me.Controls.Add(Me.tlpLogin)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLogin"
        Me.tlpLogin.ResumeLayout(False)
        Me.pnLogin.ResumeLayout(False)
        Me.pnLogin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpLogin As TableLayoutPanel
    Friend WithEvents pnLogin As Panel
    Friend WithEvents pnLogoApp As Panel
    Friend WithEvents btnLogin As Button
    Friend WithEvents tbxPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbxUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbQuenMK As Label
    Friend WithEvents btnRegister As Button
End Class
