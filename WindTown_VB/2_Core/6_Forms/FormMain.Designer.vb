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
        components = New ComponentModel.Container()
        pnl_main = New Panel()
        split_main = New SplitContainer()
        tabControl_A = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        tabControl_B = New TabControl()
        TabPage4 = New TabPage()
        TabPage5 = New TabPage()
        TabPage6 = New TabPage()
        ToolStrip1 = New ToolStrip()
        tool_user_profile = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        grp_Origanization = New ToolStripMenuItem()
        menu_department = New ToolStripMenuItem()
        menu_level = New ToolStripMenuItem()
        menu_job = New ToolStripMenuItem()
        grp_HR = New ToolStripMenuItem()
        menu_empolyee = New ToolStripMenuItem()
        menu_contract = New ToolStripMenuItem()
        menu_position = New ToolStripMenuItem()
        grp_Operational = New ToolStripMenuItem()
        menu_project = New ToolStripMenuItem()
        menu_assignment = New ToolStripMenuItem()
        menu_attendance = New ToolStripMenuItem()
        menu_holiday = New ToolStripMenuItem()
        menu_leave_cat = New ToolStripMenuItem()
        menu_leave = New ToolStripMenuItem()
        grp_Finance = New ToolStripMenuItem()
        menu_pay_period = New ToolStripMenuItem()
        menu_payroll = New ToolStripMenuItem()
        tool_logger = New ToolStripMenuItem()
        grp_Sys = New ToolStripMenuItem()
        menu_account = New ToolStripMenuItem()
        menu_db_mgr = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        ColorDialog1 = New ColorDialog()
        contextMenu_tab = New ContextMenuStrip(components)
        menu_close = New ToolStripMenuItem()
        menu_close_all_tab = New ToolStripMenuItem()
        menu_move_to_splitA = New ToolStripMenuItem()
        menu_move_all_to_splitA = New ToolStripMenuItem()
        menu_move_to_splitB = New ToolStripMenuItem()
        menu_move_all_to_splitB = New ToolStripMenuItem()
        menu_policy = New ToolStripMenuItem()
        menu_dashboard = New ToolStripMenuItem()
        pnl_main.SuspendLayout()
        CType(split_main, ComponentModel.ISupportInitialize).BeginInit()
        split_main.Panel1.SuspendLayout()
        split_main.Panel2.SuspendLayout()
        split_main.SuspendLayout()
        tabControl_A.SuspendLayout()
        tabControl_B.SuspendLayout()
        ToolStrip1.SuspendLayout()
        contextMenu_tab.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnl_main
        ' 
        pnl_main.Controls.Add(split_main)
        pnl_main.Controls.Add(ToolStrip1)
        pnl_main.Dock = DockStyle.Fill
        pnl_main.Location = New Point(0, 0)
        pnl_main.Margin = New Padding(4, 3, 4, 3)
        pnl_main.Name = "pnl_main"
        pnl_main.Size = New Size(1475, 749)
        pnl_main.TabIndex = 3
        ' 
        ' split_main
        ' 
        split_main.Dock = DockStyle.Fill
        split_main.Location = New Point(0, 36)
        split_main.Margin = New Padding(4, 3, 4, 3)
        split_main.Name = "split_main"
        ' 
        ' split_main.Panel1
        ' 
        split_main.Panel1.Controls.Add(tabControl_A)
        ' 
        ' split_main.Panel2
        ' 
        split_main.Panel2.Controls.Add(tabControl_B)
        split_main.Size = New Size(1475, 713)
        split_main.SplitterDistance = 705
        split_main.SplitterWidth = 5
        split_main.TabIndex = 4
        ' 
        ' tabControl_A
        ' 
        tabControl_A.Controls.Add(TabPage1)
        tabControl_A.Controls.Add(TabPage2)
        tabControl_A.Controls.Add(TabPage3)
        tabControl_A.Dock = DockStyle.Fill
        tabControl_A.Font = New Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabControl_A.Location = New Point(0, 0)
        tabControl_A.Margin = New Padding(4, 3, 4, 3)
        tabControl_A.Name = "tabControl_A"
        tabControl_A.SelectedIndex = 0
        tabControl_A.Size = New Size(705, 713)
        tabControl_A.TabIndex = 2
        ' 
        ' TabPage1
        ' 
        TabPage1.Location = New Point(4, 25)
        TabPage1.Margin = New Padding(4, 3, 4, 3)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(4, 3, 4, 3)
        TabPage1.Size = New Size(697, 684)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Location = New Point(4, 25)
        TabPage2.Margin = New Padding(4, 3, 4, 3)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(4, 3, 4, 3)
        TabPage2.Size = New Size(697, 684)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Location = New Point(4, 25)
        TabPage3.Margin = New Padding(4, 3, 4, 3)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(4, 3, 4, 3)
        TabPage3.Size = New Size(697, 684)
        TabPage3.TabIndex = 2
        TabPage3.Text = "TabPage3"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' tabControl_B
        ' 
        tabControl_B.Controls.Add(TabPage4)
        tabControl_B.Controls.Add(TabPage5)
        tabControl_B.Controls.Add(TabPage6)
        tabControl_B.Dock = DockStyle.Fill
        tabControl_B.Font = New Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabControl_B.Location = New Point(0, 0)
        tabControl_B.Margin = New Padding(4, 3, 4, 3)
        tabControl_B.Name = "tabControl_B"
        tabControl_B.SelectedIndex = 0
        tabControl_B.Size = New Size(765, 713)
        tabControl_B.TabIndex = 3
        ' 
        ' TabPage4
        ' 
        TabPage4.Location = New Point(4, 25)
        TabPage4.Margin = New Padding(4, 3, 4, 3)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(4, 3, 4, 3)
        TabPage4.Size = New Size(757, 684)
        TabPage4.TabIndex = 0
        TabPage4.Text = "TabPage4"
        TabPage4.UseVisualStyleBackColor = True
        ' 
        ' TabPage5
        ' 
        TabPage5.Location = New Point(4, 25)
        TabPage5.Margin = New Padding(4, 3, 4, 3)
        TabPage5.Name = "TabPage5"
        TabPage5.Padding = New Padding(4, 3, 4, 3)
        TabPage5.Size = New Size(757, 684)
        TabPage5.TabIndex = 1
        TabPage5.Text = "TabPage5"
        TabPage5.UseVisualStyleBackColor = True
        ' 
        ' TabPage6
        ' 
        TabPage6.Location = New Point(4, 25)
        TabPage6.Margin = New Padding(4, 3, 4, 3)
        TabPage6.Name = "TabPage6"
        TabPage6.Padding = New Padding(4, 3, 4, 3)
        TabPage6.Size = New Size(757, 684)
        TabPage6.TabIndex = 2
        TabPage6.Text = "TabPage6"
        TabPage6.UseVisualStyleBackColor = True
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Font = New Font("Segoe UI", 10F)
        ToolStrip1.ImageScalingSize = New Size(32, 32)
        ToolStrip1.Items.AddRange(New ToolStripItem() {tool_user_profile, ToolStripSeparator1, menu_dashboard, grp_Origanization, grp_HR, grp_Operational, menu_policy, grp_Finance, tool_logger, grp_Sys, ToolStripSeparator2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.RenderMode = ToolStripRenderMode.System
        ToolStrip1.Size = New Size(1475, 36)
        ToolStrip1.TabIndex = 1
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' tool_user_profile
        ' 
        tool_user_profile.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        tool_user_profile.Image = My.Resources.Resources.LogoHR
        tool_user_profile.Name = "tool_user_profile"
        tool_user_profile.Size = New Size(157, 36)
        tool_user_profile.Text = "Wind Town"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 36)
        ' 
        ' grp_Origanization
        ' 
        grp_Origanization.DropDownItems.AddRange(New ToolStripItem() {menu_department, menu_level, menu_job})
        grp_Origanization.Image = My.Resources.Resources.enterprise
        grp_Origanization.Name = "grp_Origanization"
        grp_Origanization.Size = New Size(100, 36)
        grp_Origanization.Text = "Tổ chức"
        ' 
        ' menu_department
        ' 
        menu_department.Image = My.Resources.Resources.phongban
        menu_department.Name = "menu_department"
        menu_department.Size = New Size(161, 38)
        menu_department.Text = "Phòng ban"
        ' 
        ' menu_level
        ' 
        menu_level.Image = My.Resources.Resources.market
        menu_level.Name = "menu_level"
        menu_level.Size = New Size(161, 38)
        menu_level.Text = "Trình độ"
        ' 
        ' menu_job
        ' 
        menu_job.Image = My.Resources.Resources._case
        menu_job.Name = "menu_job"
        menu_job.Size = New Size(161, 38)
        menu_job.Text = "Công việc"
        ' 
        ' grp_HR
        ' 
        grp_HR.DropDownItems.AddRange(New ToolStripItem() {menu_empolyee, menu_contract, menu_position})
        grp_HR.Image = My.Resources.Resources.book_user
        grp_HR.Name = "grp_HR"
        grp_HR.Size = New Size(104, 36)
        grp_HR.Text = "Nhân sự"
        ' 
        ' menu_empolyee
        ' 
        menu_empolyee.Image = My.Resources.Resources.employee
        menu_empolyee.Name = "menu_empolyee"
        menu_empolyee.Size = New Size(156, 38)
        menu_empolyee.Text = "Nhân viên"
        ' 
        ' menu_contract
        ' 
        menu_contract.Image = My.Resources.Resources.diploma
        menu_contract.Name = "menu_contract"
        menu_contract.Size = New Size(156, 38)
        menu_contract.Text = "Hợp đồng"
        ' 
        ' menu_position
        ' 
        menu_position.Image = My.Resources.Resources.verified
        menu_position.Name = "menu_position"
        menu_position.Size = New Size(156, 38)
        menu_position.Text = "Chức vụ"
        ' 
        ' grp_Operational
        ' 
        grp_Operational.DropDownItems.AddRange(New ToolStripItem() {menu_project, menu_assignment, menu_attendance, menu_holiday, menu_leave_cat, menu_leave})
        grp_Operational.Image = My.Resources.Resources.projectManage
        grp_Operational.Name = "grp_Operational"
        grp_Operational.Size = New Size(112, 36)
        grp_Operational.Text = "Vận hành"
        ' 
        ' menu_project
        ' 
        menu_project.Image = My.Resources.Resources.project1
        menu_project.Name = "menu_project"
        menu_project.Size = New Size(216, 38)
        menu_project.Text = "Dự án"
        ' 
        ' menu_assignment
        ' 
        menu_assignment.Image = My.Resources.Resources.delegation
        menu_assignment.Name = "menu_assignment"
        menu_assignment.Size = New Size(216, 38)
        menu_assignment.Text = "Phân công dự án"
        ' 
        ' menu_attendance
        ' 
        menu_attendance.Image = My.Resources.Resources.calendar_clock
        menu_attendance.Name = "menu_attendance"
        menu_attendance.Size = New Size(216, 38)
        menu_attendance.Text = "Chấm công"
        ' 
        ' menu_holiday
        ' 
        menu_holiday.Image = My.Resources.Resources.Holidays
        menu_holiday.Name = "menu_holiday"
        menu_holiday.Size = New Size(216, 38)
        menu_holiday.Text = "Hệ số lương ngày lễ"
        ' 
        ' menu_leave_cat
        ' 
        menu_leave_cat.Image = My.Resources.Resources.leave2
        menu_leave_cat.Name = "menu_leave_cat"
        menu_leave_cat.Size = New Size(216, 38)
        menu_leave_cat.Text = "Các loại nghỉ phép"
        menu_leave_cat.ToolTipText = "Các loại nghỉ phép"
        ' 
        ' menu_leave
        ' 
        menu_leave.Image = My.Resources.Resources.leave
        menu_leave.Name = "menu_leave"
        menu_leave.Size = New Size(216, 38)
        menu_leave.Text = "Nghỉ phép"
        ' 
        ' grp_Finance
        ' 
        grp_Finance.DropDownItems.AddRange(New ToolStripItem() {menu_pay_period, menu_payroll})
        grp_Finance.Image = My.Resources.Resources.money
        grp_Finance.Name = "grp_Finance"
        grp_Finance.Size = New Size(105, 36)
        grp_Finance.Text = "Tài chính"
        ' 
        ' menu_pay_period
        ' 
        menu_pay_period.Image = My.Resources.Resources.wages1
        menu_pay_period.Name = "menu_pay_period"
        menu_pay_period.Size = New Size(196, 38)
        menu_pay_period.Text = "Chu kỳ lương"
        ' 
        ' menu_payroll
        ' 
        menu_payroll.Image = My.Resources.Resources.financial_reporting
        menu_payroll.Name = "menu_payroll"
        menu_payroll.Size = New Size(196, 38)
        menu_payroll.Text = "Bảng lương"
        ' 
        ' tool_logger
        ' 
        tool_logger.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tool_logger.Image = My.Resources.Resources.log
        tool_logger.Name = "tool_logger"
        tool_logger.Size = New Size(83, 36)
        tool_logger.Text = "Log"
        ' 
        ' grp_Sys
        ' 
        grp_Sys.DropDownItems.AddRange(New ToolStripItem() {menu_account, menu_db_mgr})
        grp_Sys.Image = My.Resources.Resources.gear
        grp_Sys.Name = "grp_Sys"
        grp_Sys.Size = New Size(111, 36)
        grp_Sys.Text = "Hệ thống"
        ' 
        ' menu_account
        ' 
        menu_account.Image = My.Resources.Resources.user1
        menu_account.Name = "menu_account"
        menu_account.Size = New Size(196, 38)
        menu_account.Text = "Tài khoản"
        ' 
        ' menu_db_mgr
        ' 
        menu_db_mgr.Image = My.Resources.Resources.sync2
        menu_db_mgr.Name = "menu_db_mgr"
        menu_db_mgr.Size = New Size(196, 38)
        menu_db_mgr.Text = "Cơ sở dữ liệu"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 36)
        ' 
        ' contextMenu_tab
        ' 
        contextMenu_tab.Items.AddRange(New ToolStripItem() {menu_close, menu_close_all_tab, menu_move_to_splitA, menu_move_all_to_splitA, menu_move_to_splitB, menu_move_all_to_splitB})
        contextMenu_tab.Name = "contextMenu_tab"
        contextMenu_tab.Size = New Size(187, 136)
        ' 
        ' menu_close
        ' 
        menu_close.Name = "menu_close"
        menu_close.Size = New Size(186, 22)
        menu_close.Text = "Đóng"
        ' 
        ' menu_close_all_tab
        ' 
        menu_close_all_tab.Name = "menu_close_all_tab"
        menu_close_all_tab.Size = New Size(186, 22)
        menu_close_all_tab.Text = "Đóng tất cả các tab"
        ' 
        ' menu_move_to_splitA
        ' 
        menu_move_to_splitA.Name = "menu_move_to_splitA"
        menu_move_to_splitA.Size = New Size(186, 22)
        menu_move_to_splitA.Text = "Chuyển sang A"
        ' 
        ' menu_move_all_to_splitA
        ' 
        menu_move_all_to_splitA.Name = "menu_move_all_to_splitA"
        menu_move_all_to_splitA.Size = New Size(186, 22)
        menu_move_all_to_splitA.Text = "Chuyển tất cả sang A"
        ' 
        ' menu_move_to_splitB
        ' 
        menu_move_to_splitB.Name = "menu_move_to_splitB"
        menu_move_to_splitB.Size = New Size(186, 22)
        menu_move_to_splitB.Text = "Chuyển sang B"
        ' 
        ' menu_move_all_to_splitB
        ' 
        menu_move_all_to_splitB.Name = "menu_move_all_to_splitB"
        menu_move_all_to_splitB.Size = New Size(186, 22)
        menu_move_all_to_splitB.Text = "Chuyển tất cả sang B"
        ' 
        ' menu_policy
        ' 
        menu_policy.Image = My.Resources.Resources.rules_alt
        menu_policy.Name = "menu_policy"
        menu_policy.Size = New Size(120, 36)
        menu_policy.Text = "Chính sách"
        ' 
        ' menu_dashboard
        ' 
        menu_dashboard.Image = My.Resources.Resources.home2
        menu_dashboard.Name = "menu_dashboard"
        menu_dashboard.Size = New Size(113, 36)
        menu_dashboard.Text = "Trang chủ"
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(1475, 749)
        Controls.Add(pnl_main)
        ImeMode = ImeMode.On
        Margin = New Padding(4, 3, 4, 3)
        Name = "FormMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormMain"
        pnl_main.ResumeLayout(False)
        pnl_main.PerformLayout()
        split_main.Panel1.ResumeLayout(False)
        split_main.Panel2.ResumeLayout(False)
        CType(split_main, ComponentModel.ISupportInitialize).EndInit()
        split_main.ResumeLayout(False)
        tabControl_A.ResumeLayout(False)
        tabControl_B.ResumeLayout(False)
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        contextMenu_tab.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_main As Panel
    Friend WithEvents tabControl_A As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents grp_Origanization As ToolStripMenuItem
    Friend WithEvents menu_department As ToolStripMenuItem
    Friend WithEvents menu_job As ToolStripMenuItem
    Friend WithEvents menu_level As ToolStripMenuItem
    Friend WithEvents grp_HR As ToolStripMenuItem
    Friend WithEvents menu_empolyee As ToolStripMenuItem
    Friend WithEvents menu_contract As ToolStripMenuItem
    Friend WithEvents menu_position As ToolStripMenuItem
    Friend WithEvents grp_Operational As ToolStripMenuItem
    Friend WithEvents menu_project As ToolStripMenuItem
    Friend WithEvents menu_attendance As ToolStripMenuItem
    Friend WithEvents menu_holiday As ToolStripMenuItem
    Friend WithEvents menu_leave_cat As ToolStripMenuItem
    Friend WithEvents menu_leave As ToolStripMenuItem
    Friend WithEvents grp_Finance As ToolStripMenuItem
    Friend WithEvents grp_Sys As ToolStripMenuItem
    Friend WithEvents menu_account As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
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
    Friend WithEvents menu_assignment As ToolStripMenuItem
    Friend WithEvents menu_pay_period As ToolStripMenuItem
    Friend WithEvents menu_payroll As ToolStripMenuItem
    Friend WithEvents tool_logger As ToolStripMenuItem
    Public WithEvents tool_user_profile As ToolStripMenuItem
    Friend WithEvents menu_db_mgr As ToolStripMenuItem
    Friend WithEvents menu_dashboard As ToolStripMenuItem
    Friend WithEvents menu_policy As ToolStripMenuItem
End Class
