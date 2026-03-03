<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Me.components = New System.ComponentModel.Container()
        Me.tbxPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxAcceptPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbxPassword
        '
        Me.tbxPassword.Location = New System.Drawing.Point(353, 230)
        Me.tbxPassword.Name = "tbxPassword"
        Me.tbxPassword.Size = New System.Drawing.Size(258, 27)
        Me.tbxPassword.TabIndex = 7
        Me.tbxPassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(349, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Mật khẩu"
        '
        'tbxUsername
        '
        Me.tbxUsername.Location = New System.Drawing.Point(353, 161)
        Me.tbxUsername.Name = "tbxUsername"
        Me.tbxUsername.Size = New System.Drawing.Size(258, 27)
        Me.tbxUsername.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(349, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tên đăng nhập"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(446, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Đăng nhập"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbxAcceptPassword
        '
        Me.tbxAcceptPassword.Location = New System.Drawing.Point(353, 295)
        Me.tbxAcceptPassword.Name = "tbxAcceptPassword"
        Me.tbxAcceptPassword.Size = New System.Drawing.Size(258, 27)
        Me.tbxAcceptPassword.TabIndex = 9
        Me.tbxAcceptPassword.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(349, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Xác nhận mật khẩu"
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.LimeGreen
        Me.btnRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.ForeColor = System.Drawing.Color.White
        Me.btnRegister.Location = New System.Drawing.Point(353, 342)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(258, 39)
        Me.btnRegister.TabIndex = 10
        Me.btnRegister.Text = "Đăng ký"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Orange
        Me.ClientSize = New System.Drawing.Size(1000, 562)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.tbxAcceptPassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbxPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbxUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRegister"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbxPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbxUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbxAcceptPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRegister As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
