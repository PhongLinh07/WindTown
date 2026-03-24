<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        tlpLogin = New TableLayoutPanel()
        pnLogin = New Panel()
        Label6 = New Label()
        lbQuenMK = New Label()
        btnLogin = New Button()
        tbxPassword = New TextBox()
        Label3 = New Label()
        tbxUsername = New TextBox()
        Label2 = New Label()
        pnLogoApp = New Panel()
        PictureBox1 = New PictureBox()
        Label5 = New Label()
        Label4 = New Label()
        Label1 = New Label()
        tlpLogin.SuspendLayout()
        pnLogin.SuspendLayout()
        pnLogoApp.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tlpLogin
        ' 
        tlpLogin.BackColor = Color.Transparent
        tlpLogin.ColumnCount = 2
        tlpLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 48.4654732F))
        tlpLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 51.5345268F))
        tlpLogin.Controls.Add(pnLogin, 1, 0)
        tlpLogin.Controls.Add(pnLogoApp, 0, 0)
        tlpLogin.Dock = DockStyle.Fill
        tlpLogin.Location = New Point(0, 0)
        tlpLogin.Margin = New Padding(4, 3, 4, 3)
        tlpLogin.Name = "tlpLogin"
        tlpLogin.RowCount = 1
        tlpLogin.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpLogin.RowStyles.Add(New RowStyle(SizeType.Absolute, 573F))
        tlpLogin.Size = New Size(823, 573)
        tlpLogin.TabIndex = 0
        ' 
        ' pnLogin
        ' 
        pnLogin.BackColor = Color.LightSkyBlue
        pnLogin.Controls.Add(Label6)
        pnLogin.Controls.Add(lbQuenMK)
        pnLogin.Controls.Add(btnLogin)
        pnLogin.Controls.Add(tbxPassword)
        pnLogin.Controls.Add(Label3)
        pnLogin.Controls.Add(tbxUsername)
        pnLogin.Controls.Add(Label2)
        pnLogin.Dock = DockStyle.Fill
        pnLogin.Location = New Point(402, 3)
        pnLogin.Margin = New Padding(4, 3, 4, 3)
        pnLogin.Name = "pnLogin"
        pnLogin.Size = New Size(417, 567)
        pnLogin.TabIndex = 1
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 20F, FontStyle.Bold)
        Label6.ForeColor = Color.Black
        Label6.Location = New Point(106, 57)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 32)
        Label6.TabIndex = 3
        Label6.Text = "ĐĂNG NHẬP"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lbQuenMK
        ' 
        lbQuenMK.AutoSize = True
        lbQuenMK.BackColor = Color.Transparent
        lbQuenMK.ForeColor = SystemColors.InactiveCaptionText
        lbQuenMK.Location = New Point(231, 391)
        lbQuenMK.Margin = New Padding(4, 0, 4, 0)
        lbQuenMK.Name = "lbQuenMK"
        lbQuenMK.Size = New Size(134, 19)
        lbQuenMK.TabIndex = 5
        lbQuenMK.Text = "Quên mật khẩu?"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.DodgerBlue
        btnLogin.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(43, 331)
        btnLogin.Margin = New Padding(4, 3, 4, 3)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(325, 48)
        btnLogin.TabIndex = 3
        btnLogin.Text = "Đăng nhập"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' tbxPassword
        ' 
        tbxPassword.Location = New Point(46, 268)
        tbxPassword.Margin = New Padding(4, 3, 4, 3)
        tbxPassword.Name = "tbxPassword"
        tbxPassword.Size = New Size(319, 26)
        tbxPassword.TabIndex = 2
        tbxPassword.Text = "123456"
        tbxPassword.UseSystemPasswordChar = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(39, 246)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 19)
        Label3.TabIndex = 0
        Label3.Text = "Mật khẩu:"
        ' 
        ' tbxUsername
        ' 
        tbxUsername.Location = New Point(43, 187)
        tbxUsername.Margin = New Padding(4, 3, 4, 3)
        tbxUsername.Name = "tbxUsername"
        tbxUsername.Size = New Size(322, 26)
        tbxUsername.TabIndex = 1
        tbxUsername.Text = "admin"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(43, 165)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(130, 19)
        Label2.TabIndex = 0
        Label2.Text = "Tên đăng nhập:"
        ' 
        ' pnLogoApp
        ' 
        pnLogoApp.BackColor = Color.LightSkyBlue
        pnLogoApp.Controls.Add(PictureBox1)
        pnLogoApp.Controls.Add(Label5)
        pnLogoApp.Controls.Add(Label4)
        pnLogoApp.Controls.Add(Label1)
        pnLogoApp.Dock = DockStyle.Fill
        pnLogoApp.Location = New Point(4, 3)
        pnLogoApp.Margin = New Padding(4, 3, 4, 3)
        pnLogoApp.Name = "pnLogoApp"
        pnLogoApp.Size = New Size(390, 567)
        pnLogoApp.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.LogoHR1
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Image = My.Resources.Resources.LogoHR
        PictureBox1.Location = New Point(64, 134)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(225, 187)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 16F, FontStyle.Bold)
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(70, 384)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(219, 26)
        Label5.TabIndex = 1
        Label5.Text = "QUẢN LÝ NHÂN SỰ"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(113, 84)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 19)
        Label4.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16F, FontStyle.Bold)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(113, 341)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 26)
        Label1.TabIndex = 0
        Label1.Text = "PHẦN MỀM"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(823, 573)
        Controls.Add(tlpLogin)
        Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(5, 4, 5, 4)
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmLogin"
        tlpLogin.ResumeLayout(False)
        pnLogin.ResumeLayout(False)
        pnLogin.PerformLayout()
        pnLogoApp.ResumeLayout(False)
        pnLogoApp.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

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
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
