<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SdvsdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_department = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_job = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_level = New System.Windows.Forms.ToolStripMenuItem()
        Me.DvsdvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_empolyee = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_contract = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_position = New System.Windows.Forms.ToolStripMenuItem()
        Me.SdvfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_project = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_attendance = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChínhSáchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TàiChínhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HệThốngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_account = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.pnl_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(61, 4)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SdvsdToolStripMenuItem, Me.DvsdvToolStripMenuItem, Me.SdvfToolStripMenuItem, Me.ChínhSáchToolStripMenuItem, Me.TàiChínhToolStripMenuItem, Me.HệThốngToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1424, 33)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SdvsdToolStripMenuItem
        '
        Me.SdvsdToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_department, Me.menu_job, Me.menu_level})
        Me.SdvsdToolStripMenuItem.Name = "SdvsdToolStripMenuItem"
        Me.SdvsdToolStripMenuItem.Size = New System.Drawing.Size(68, 29)
        Me.SdvsdToolStripMenuItem.Text = "Tổ chức"
        '
        'menu_department
        '
        Me.menu_department.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.menu_department.Name = "menu_department"
        Me.menu_department.Size = New System.Drawing.Size(180, 24)
        Me.menu_department.Text = "Phòng ban"
        '
        'menu_job
        '
        Me.menu_job.Name = "menu_job"
        Me.menu_job.Size = New System.Drawing.Size(180, 24)
        Me.menu_job.Text = "Công việc"
        '
        'menu_level
        '
        Me.menu_level.Name = "menu_level"
        Me.menu_level.Size = New System.Drawing.Size(180, 24)
        Me.menu_level.Text = "Trình độ"
        '
        'DvsdvToolStripMenuItem
        '
        Me.DvsdvToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_empolyee, Me.menu_contract, Me.menu_position})
        Me.DvsdvToolStripMenuItem.Name = "DvsdvToolStripMenuItem"
        Me.DvsdvToolStripMenuItem.Size = New System.Drawing.Size(72, 29)
        Me.DvsdvToolStripMenuItem.Text = "Nhân sự"
        '
        'menu_empolyee
        '
        Me.menu_empolyee.Name = "menu_empolyee"
        Me.menu_empolyee.Size = New System.Drawing.Size(140, 24)
        Me.menu_empolyee.Text = "Nhân viên"
        '
        'menu_contract
        '
        Me.menu_contract.Name = "menu_contract"
        Me.menu_contract.Size = New System.Drawing.Size(140, 24)
        Me.menu_contract.Text = "Hợp đồng"
        '
        'menu_position
        '
        Me.menu_position.Name = "menu_position"
        Me.menu_position.Size = New System.Drawing.Size(140, 24)
        Me.menu_position.Text = "Chức vụ"
        '
        'SdvfToolStripMenuItem
        '
        Me.SdvfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_project, Me.menu_attendance})
        Me.SdvfToolStripMenuItem.Name = "SdvfToolStripMenuItem"
        Me.SdvfToolStripMenuItem.Size = New System.Drawing.Size(80, 29)
        Me.SdvfToolStripMenuItem.Text = "Vận hành"
        '
        'menu_project
        '
        Me.menu_project.Name = "menu_project"
        Me.menu_project.Size = New System.Drawing.Size(148, 24)
        Me.menu_project.Text = "Dự án"
        '
        'menu_attendance
        '
        Me.menu_attendance.Name = "menu_attendance"
        Me.menu_attendance.Size = New System.Drawing.Size(148, 24)
        Me.menu_attendance.Text = "Chấm công"
        '
        'ChínhSáchToolStripMenuItem
        '
        Me.ChínhSáchToolStripMenuItem.Name = "ChínhSáchToolStripMenuItem"
        Me.ChínhSáchToolStripMenuItem.Size = New System.Drawing.Size(144, 29)
        Me.ChínhSáchToolStripMenuItem.Text = "Quy tắc & Chính sách"
        '
        'TàiChínhToolStripMenuItem
        '
        Me.TàiChínhToolStripMenuItem.Name = "TàiChínhToolStripMenuItem"
        Me.TàiChínhToolStripMenuItem.Size = New System.Drawing.Size(73, 29)
        Me.TàiChínhToolStripMenuItem.Text = "Tài chính"
        '
        'HệThốngToolStripMenuItem
        '
        Me.HệThốngToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_account})
        Me.HệThốngToolStripMenuItem.Name = "HệThốngToolStripMenuItem"
        Me.HệThốngToolStripMenuItem.Size = New System.Drawing.Size(79, 29)
        Me.HệThốngToolStripMenuItem.Text = "Hệ thống"
        '
        'menu_account
        '
        Me.menu_account.Name = "menu_account"
        Me.menu_account.Size = New System.Drawing.Size(135, 24)
        Me.menu_account.Text = "Tài khoản"
        '
        'pnl_main
        '
        Me.pnl_main.Controls.Add(Me.MenuStrip1)
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(0, 0)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(1424, 821)
        Me.pnl_main.TabIndex = 3
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(125, 29)
        Me.ToolStripMenuItem1.Text = "Wind Town"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1424, 821)
        Me.Controls.Add(Me.pnl_main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMain"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnl_main.ResumeLayout(False)
        Me.pnl_main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SdvsdToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_department As ToolStripMenuItem
    Friend WithEvents menu_job As ToolStripMenuItem
    Friend WithEvents menu_level As ToolStripMenuItem
    Friend WithEvents DvsdvToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_empolyee As ToolStripMenuItem
    Friend WithEvents menu_contract As ToolStripMenuItem
    Friend WithEvents menu_position As ToolStripMenuItem
    Friend WithEvents SdvfToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_project As ToolStripMenuItem
    Friend WithEvents menu_attendance As ToolStripMenuItem
    Friend WithEvents ChínhSáchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TàiChínhToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HệThốngToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_account As ToolStripMenuItem
    Friend WithEvents pnl_main As Panel
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
