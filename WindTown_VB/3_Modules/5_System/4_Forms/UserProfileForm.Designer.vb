<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserProfileForm
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ui_role = New System.Windows.Forms.TextBox()
        Me.ui_employee = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ui_user = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ui_selectUI = New System.Windows.Forms.GroupBox()
        Me.btn_ui_dev = New System.Windows.Forms.Button()
        Me.btn_ui_user = New System.Windows.Forms.Button()
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ui_selectUI.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(762, 581)
        Me.SplitContainer1.SplitterDistance = 393
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.Controls.Add(Me.ui_role)
        Me.Panel1.Controls.Add(Me.ui_employee)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ui_user)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 581)
        Me.Panel1.TabIndex = 0
        '
        'ui_role
        '
        Me.ui_role.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_role.Location = New System.Drawing.Point(27, 502)
        Me.ui_role.Name = "ui_role"
        Me.ui_role.ReadOnly = True
        Me.ui_role.Size = New System.Drawing.Size(336, 26)
        Me.ui_role.TabIndex = 19
        '
        'ui_employee
        '
        Me.ui_employee.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_employee.Location = New System.Drawing.Point(27, 311)
        Me.ui_employee.Name = "ui_employee"
        Me.ui_employee.ReadOnly = True
        Me.ui_employee.Size = New System.Drawing.Size(336, 26)
        Me.ui_employee.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(23, 386)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 19)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Tên tài khoản:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.WindTown_VB.My.Resources.Resources.Avatar
        Me.PictureBox1.Location = New System.Drawing.Point(108, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(166, 216)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ui_user
        '
        Me.ui_user.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_user.Location = New System.Drawing.Point(27, 408)
        Me.ui_user.Name = "ui_user"
        Me.ui_user.ReadOnly = True
        Me.ui_user.Size = New System.Drawing.Size(336, 26)
        Me.ui_user.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(23, 289)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nhân viên:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(23, 480)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 19)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Quyền hạn hệ thống:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.ui_selectUI)
        Me.Panel2.Controls.Add(Me.btn_logout)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(365, 581)
        Me.Panel2.TabIndex = 0
        '
        'ui_selectUI
        '
        Me.ui_selectUI.Controls.Add(Me.btn_ui_dev)
        Me.ui_selectUI.Controls.Add(Me.btn_ui_user)
        Me.ui_selectUI.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ui_selectUI.Location = New System.Drawing.Point(19, 73)
        Me.ui_selectUI.Name = "ui_selectUI"
        Me.ui_selectUI.Size = New System.Drawing.Size(334, 192)
        Me.ui_selectUI.TabIndex = 24
        Me.ui_selectUI.TabStop = False
        Me.ui_selectUI.Text = "Chế độ giao diện:"
        '
        'btn_ui_dev
        '
        Me.btn_ui_dev.BackColor = System.Drawing.Color.Transparent
        Me.btn_ui_dev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ui_dev.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ui_dev.Location = New System.Drawing.Point(185, 76)
        Me.btn_ui_dev.Name = "btn_ui_dev"
        Me.btn_ui_dev.Size = New System.Drawing.Size(128, 41)
        Me.btn_ui_dev.TabIndex = 26
        Me.btn_ui_dev.Text = "Nhà phát triển"
        Me.btn_ui_dev.UseVisualStyleBackColor = False
        '
        'btn_ui_user
        '
        Me.btn_ui_user.BackColor = System.Drawing.Color.Transparent
        Me.btn_ui_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ui_user.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ui_user.Location = New System.Drawing.Point(26, 76)
        Me.btn_ui_user.Name = "btn_ui_user"
        Me.btn_ui_user.Size = New System.Drawing.Size(130, 41)
        Me.btn_ui_user.TabIndex = 25
        Me.btn_ui_user.Text = "Người dùng"
        Me.btn_ui_user.UseVisualStyleBackColor = False
        '
        'btn_logout
        '
        Me.btn_logout.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.Location = New System.Drawing.Point(128, 296)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(112, 41)
        Me.btn_logout.TabIndex = 23
        Me.btn_logout.Text = "Đăng Xuất"
        Me.btn_logout.UseVisualStyleBackColor = True
        '
        'UserProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 581)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "UserProfileForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserProfileForm"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ui_selectUI.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ui_role As TextBox
    Friend WithEvents btn_logout As Button
    Protected WithEvents ui_employee As TextBox
    Protected WithEvents ui_user As TextBox
    Friend WithEvents ui_selectUI As GroupBox
    Friend WithEvents btn_ui_dev As Button
    Friend WithEvents btn_ui_user As Button
End Class
