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
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.split_main = New System.Windows.Forms.SplitContainer()
        Me.tabControl_A = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tabControl_B = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.menu_holiday = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_leave_cat = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_leave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChínhSáchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TàiChínhToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HệThốngToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_account = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me._title = New System.Windows.Forms.ToolStripLabel()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.contextMenu_tab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menu_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_close_all_tab = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_move_to_splitB = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_move_to_splitA = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_move_all_to_splitA = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_move_all_to_splitB = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_main.SuspendLayout()
        CType(Me.split_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.split_main.Panel1.SuspendLayout()
        Me.split_main.Panel2.SuspendLayout()
        Me.split_main.SuspendLayout()
        Me.tabControl_A.SuspendLayout()
        Me.tabControl_B.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.contextMenu_tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_main
        '
        Me.pnl_main.Controls.Add(Me.split_main)
        Me.pnl_main.Controls.Add(Me.ToolStrip1)
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(0, 0)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(1279, 781)
        Me.pnl_main.TabIndex = 3
        '
        'split_main
        '
        Me.split_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split_main.Location = New System.Drawing.Point(0, 29)
        Me.split_main.Name = "split_main"
        '
        'split_main.Panel1
        '
        Me.split_main.Panel1.Controls.Add(Me.tabControl_A)
        '
        'split_main.Panel2
        '
        Me.split_main.Panel2.Controls.Add(Me.tabControl_B)
        Me.split_main.Size = New System.Drawing.Size(1279, 752)
        Me.split_main.SplitterDistance = 760
        Me.split_main.TabIndex = 4
        '
        'tabControl_A
        '
        Me.tabControl_A.Controls.Add(Me.TabPage1)
        Me.tabControl_A.Controls.Add(Me.TabPage2)
        Me.tabControl_A.Controls.Add(Me.TabPage3)
        Me.tabControl_A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl_A.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl_A.Location = New System.Drawing.Point(0, 0)
        Me.tabControl_A.Name = "tabControl_A"
        Me.tabControl_A.SelectedIndex = 0
        Me.tabControl_A.Size = New System.Drawing.Size(760, 752)
        Me.tabControl_A.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(752, 723)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(752, 723)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(752, 723)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tabControl_B
        '
        Me.tabControl_B.Controls.Add(Me.TabPage4)
        Me.tabControl_B.Controls.Add(Me.TabPage5)
        Me.tabControl_B.Controls.Add(Me.TabPage6)
        Me.tabControl_B.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl_B.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl_B.Location = New System.Drawing.Point(0, 0)
        Me.tabControl_B.Name = "tabControl_B"
        Me.tabControl_B.SelectedIndex = 0
        Me.tabControl_B.Size = New System.Drawing.Size(515, 752)
        Me.tabControl_B.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(507, 723)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(507, 723)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(507, 723)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "TabPage6"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripSeparator1, Me.SdvsdToolStripMenuItem, Me.DvsdvToolStripMenuItem, Me.SdvfToolStripMenuItem, Me.ChínhSáchToolStripMenuItem, Me.TàiChínhToolStripMenuItem, Me.HệThốngToolStripMenuItem, Me.ToolStripSeparator2, Me._title})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1279, 29)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(125, 29)
        Me.ToolStripMenuItem2.Text = "Wind Town"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        Me.menu_department.Size = New System.Drawing.Size(145, 24)
        Me.menu_department.Text = "Phòng ban"
        '
        'menu_job
        '
        Me.menu_job.Name = "menu_job"
        Me.menu_job.Size = New System.Drawing.Size(145, 24)
        Me.menu_job.Text = "Công việc"
        '
        'menu_level
        '
        Me.menu_level.Name = "menu_level"
        Me.menu_level.Size = New System.Drawing.Size(145, 24)
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
        Me.SdvfToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_project, Me.menu_attendance, Me.menu_holiday, Me.menu_leave_cat, Me.menu_leave})
        Me.SdvfToolStripMenuItem.Name = "SdvfToolStripMenuItem"
        Me.SdvfToolStripMenuItem.Size = New System.Drawing.Size(80, 29)
        Me.SdvfToolStripMenuItem.Text = "Vận hành"
        '
        'menu_project
        '
        Me.menu_project.Name = "menu_project"
        Me.menu_project.Size = New System.Drawing.Size(207, 24)
        Me.menu_project.Text = "Dự án"
        '
        'menu_attendance
        '
        Me.menu_attendance.Name = "menu_attendance"
        Me.menu_attendance.Size = New System.Drawing.Size(207, 24)
        Me.menu_attendance.Text = "Chấm công"
        '
        'menu_holiday
        '
        Me.menu_holiday.Name = "menu_holiday"
        Me.menu_holiday.Size = New System.Drawing.Size(207, 24)
        Me.menu_holiday.Text = "Hệ số lương ngày lễ"
        '
        'menu_leave_cat
        '
        Me.menu_leave_cat.Name = "menu_leave_cat"
        Me.menu_leave_cat.Size = New System.Drawing.Size(207, 24)
        Me.menu_leave_cat.Text = "Danh mục nghỉ phép"
        '
        'menu_leave
        '
        Me.menu_leave.Name = "menu_leave"
        Me.menu_leave.Size = New System.Drawing.Size(207, 24)
        Me.menu_leave.Text = "Nghỉ phép"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        '_title
        '
        Me._title.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me._title.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me._title.Name = "_title"
        Me._title.Size = New System.Drawing.Size(38, 26)
        Me._title.Text = "Title"
        '
        'contextMenu_tab
        '
        Me.contextMenu_tab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_close, Me.menu_close_all_tab, Me.menu_move_to_splitA, Me.menu_move_all_to_splitA, Me.menu_move_to_splitB, Me.menu_move_all_to_splitB})
        Me.contextMenu_tab.Name = "contextMenu_tab"
        Me.contextMenu_tab.Size = New System.Drawing.Size(187, 136)
        '
        'menu_close
        '
        Me.menu_close.Name = "menu_close"
        Me.menu_close.Size = New System.Drawing.Size(186, 22)
        Me.menu_close.Text = "Đóng"
        '
        'menu_close_all_tab
        '
        Me.menu_close_all_tab.Name = "menu_close_all_tab"
        Me.menu_close_all_tab.Size = New System.Drawing.Size(186, 22)
        Me.menu_close_all_tab.Text = "Đóng tất cả các tab"
        '
        'menu_move_to_splitB
        '
        Me.menu_move_to_splitB.Name = "menu_move_to_splitB"
        Me.menu_move_to_splitB.Size = New System.Drawing.Size(186, 22)
        Me.menu_move_to_splitB.Text = "Chuyển sang B"
        '
        'menu_move_to_splitA
        '
        Me.menu_move_to_splitA.Name = "menu_move_to_splitA"
        Me.menu_move_to_splitA.Size = New System.Drawing.Size(186, 22)
        Me.menu_move_to_splitA.Text = "Chuyển sang A"
        '
        'menu_move_all_to_splitA
        '
        Me.menu_move_all_to_splitA.Name = "menu_move_all_to_splitA"
        Me.menu_move_all_to_splitA.Size = New System.Drawing.Size(186, 22)
        Me.menu_move_all_to_splitA.Text = "Chuyển tất cả sang A"
        '
        'menu_move_all_to_splitB
        '
        Me.menu_move_all_to_splitB.Name = "menu_move_all_to_splitB"
        Me.menu_move_all_to_splitB.Size = New System.Drawing.Size(186, 22)
        Me.menu_move_all_to_splitB.Text = "Chuyển tất cả sang B"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1279, 781)
        Me.Controls.Add(Me.pnl_main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMain"
        Me.pnl_main.ResumeLayout(False)
        Me.pnl_main.PerformLayout()
        Me.split_main.Panel1.ResumeLayout(False)
        Me.split_main.Panel2.ResumeLayout(False)
        CType(Me.split_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.split_main.ResumeLayout(False)
        Me.tabControl_A.ResumeLayout(False)
        Me.tabControl_B.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.contextMenu_tab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_main As Panel
    Friend WithEvents tabControl_A As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
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
    Friend WithEvents menu_holiday As ToolStripMenuItem
    Friend WithEvents menu_leave_cat As ToolStripMenuItem
    Friend WithEvents menu_leave As ToolStripMenuItem
    Friend WithEvents ChínhSáchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TàiChínhToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HệThốngToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_account As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents _title As ToolStripLabel
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents contextMenu_tab As ContextMenuStrip
    Friend WithEvents menu_close As ToolStripMenuItem
    Friend WithEvents menu_move_to_splitB As ToolStripMenuItem
    Friend WithEvents menu_move_to_splitA As ToolStripMenuItem
    Friend WithEvents menu_close_all_tab As ToolStripMenuItem
    Friend WithEvents split_main As SplitContainer
    Friend WithEvents tabControl_B As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents menu_move_all_to_splitA As ToolStripMenuItem
    Friend WithEvents menu_move_all_to_splitB As ToolStripMenuItem
End Class
