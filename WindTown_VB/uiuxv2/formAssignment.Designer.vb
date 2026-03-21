<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAssignment
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlRoot = New Panel()
        pnlBody = New Panel()
        tlpFields = New TableLayoutPanel()
        lblProject = New Label()
        cboProject = New ComboBox()
        lblEmployee = New Label()
        cboEmployee = New ComboBox()
        lblRole = New Label()
        cboRole = New ComboBox()
        lblAllocation = New Label()
        txtAllocation = New TextBox()
        lblStart = New Label()
        dtpStart = New DateTimePicker()
        lblEnd = New Label()
        dtpEnd = New DateTimePicker()
        lblStatus = New Label()
        cboStatus = New ComboBox()
        lblNote = New Label()
        txtNote = New TextBox()
        pnlFooter = New Panel()
        btnCancel = New Button()
        btnSave = New Button()
        pnlHeader = New Panel()
        lblSubTitle = New Label()
        lblTitle = New Label()
        pnlRoot.SuspendLayout()
        pnlBody.SuspendLayout()
        tlpFields.SuspendLayout()
        pnlFooter.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlRoot
        ' 
        pnlRoot.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlRoot.Controls.Add(pnlBody)
        pnlRoot.Controls.Add(pnlFooter)
        pnlRoot.Controls.Add(pnlHeader)
        pnlRoot.Dock = DockStyle.Fill
        pnlRoot.Location = New Point(0, 0)
        pnlRoot.Name = "pnlRoot"
        pnlRoot.Padding = New Padding(16)
        pnlRoot.Size = New Size(838, 541)
        pnlRoot.TabIndex = 0
        ' 
        ' pnlBody
        ' 
        pnlBody.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlBody.Controls.Add(tlpFields)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Location = New Point(16, 76)
        pnlBody.Name = "pnlBody"
        pnlBody.Padding = New Padding(16)
        pnlBody.Size = New Size(806, 393)
        pnlBody.TabIndex = 1
        ' 
        ' tlpFields
        ' 
        tlpFields.ColumnCount = 2
        tlpFields.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFields.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpFields.Controls.Add(lblProject, 0, 0)
        tlpFields.Controls.Add(cboProject, 0, 1)
        tlpFields.Controls.Add(lblEmployee, 1, 0)
        tlpFields.Controls.Add(cboEmployee, 1, 1)
        tlpFields.Controls.Add(lblRole, 0, 2)
        tlpFields.Controls.Add(cboRole, 0, 3)
        tlpFields.Controls.Add(lblAllocation, 1, 2)
        tlpFields.Controls.Add(txtAllocation, 1, 3)
        tlpFields.Controls.Add(lblStart, 0, 4)
        tlpFields.Controls.Add(dtpStart, 0, 5)
        tlpFields.Controls.Add(lblEnd, 1, 4)
        tlpFields.Controls.Add(dtpEnd, 1, 5)
        tlpFields.Controls.Add(lblStatus, 0, 6)
        tlpFields.Controls.Add(cboStatus, 0, 7)
        tlpFields.Controls.Add(lblNote, 1, 6)
        tlpFields.Controls.Add(txtNote, 1, 7)
        tlpFields.Dock = DockStyle.Fill
        tlpFields.Location = New Point(16, 16)
        tlpFields.Name = "tlpFields"
        tlpFields.RowCount = 8
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpFields.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpFields.Size = New Size(774, 361)
        tlpFields.TabIndex = 0
        ' 
        ' lblProject
        ' 
        lblProject.AutoSize = True
        lblProject.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblProject.Location = New Point(3, 0)
        lblProject.Name = "lblProject"
        lblProject.Size = New Size(49, 20)
        lblProject.TabIndex = 0
        lblProject.Text = "Dự án"
        ' 
        ' cboProject
        ' 
        cboProject.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboProject.DropDownStyle = ComboBoxStyle.DropDownList
        cboProject.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboProject.FormattingEnabled = True
        cboProject.Location = New Point(3, 23)
        cboProject.Name = "cboProject"
        cboProject.Size = New Size(320, 28)
        cboProject.TabIndex = 1
        ' 
        ' lblEmployee
        ' 
        lblEmployee.AutoSize = True
        lblEmployee.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblEmployee.Location = New Point(390, 0)
        lblEmployee.Name = "lblEmployee"
        lblEmployee.Size = New Size(81, 20)
        lblEmployee.TabIndex = 2
        lblEmployee.Text = "Nhân viên"
        ' 
        ' cboEmployee
        ' 
        cboEmployee.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList
        cboEmployee.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboEmployee.FormattingEnabled = True
        cboEmployee.Location = New Point(390, 23)
        cboEmployee.Name = "cboEmployee"
        cboEmployee.Size = New Size(322, 28)
        cboEmployee.TabIndex = 3
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblRole.Location = New Point(3, 52)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(57, 20)
        lblRole.TabIndex = 4
        lblRole.Text = "Vai trò"
        ' 
        ' cboRole
        ' 
        cboRole.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(3, 75)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(320, 28)
        cboRole.TabIndex = 5
        ' 
        ' lblAllocation
        ' 
        lblAllocation.AutoSize = True
        lblAllocation.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblAllocation.Location = New Point(390, 52)
        lblAllocation.Name = "lblAllocation"
        lblAllocation.Size = New Size(68, 20)
        lblAllocation.TabIndex = 6
        lblAllocation.Text = "Tỷ lệ (%)"
        ' 
        ' txtAllocation
        ' 
        txtAllocation.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtAllocation.BorderStyle = BorderStyle.FixedSingle
        txtAllocation.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtAllocation.Location = New Point(390, 75)
        txtAllocation.Name = "txtAllocation"
        txtAllocation.Size = New Size(140, 27)
        txtAllocation.TabIndex = 7
        ' 
        ' lblStart
        ' 
        lblStart.AutoSize = True
        lblStart.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblStart.Location = New Point(3, 104)
        lblStart.Name = "lblStart"
        lblStart.Size = New Size(65, 20)
        lblStart.TabIndex = 8
        lblStart.Text = "Từ ngày"
        ' 
        ' dtpStart
        ' 
        dtpStart.CalendarForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        dtpStart.CalendarMonthBackground = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpStart.CalendarTitleBackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpStart.CalendarTitleForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        dtpStart.Format = DateTimePickerFormat.Short
        dtpStart.Location = New Point(3, 127)
        dtpStart.Name = "dtpStart"
        dtpStart.Size = New Size(200, 27)
        dtpStart.TabIndex = 9
        ' 
        ' lblEnd
        ' 
        lblEnd.AutoSize = True
        lblEnd.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblEnd.Location = New Point(390, 104)
        lblEnd.Name = "lblEnd"
        lblEnd.Size = New Size(76, 20)
        lblEnd.TabIndex = 10
        lblEnd.Text = "Đến ngày"
        ' 
        ' dtpEnd
        ' 
        dtpEnd.CalendarForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        dtpEnd.CalendarMonthBackground = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpEnd.CalendarTitleBackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        dtpEnd.CalendarTitleForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        dtpEnd.Format = DateTimePickerFormat.Short
        dtpEnd.Location = New Point(390, 127)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(200, 27)
        dtpEnd.TabIndex = 11
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblStatus.Location = New Point(3, 156)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(82, 20)
        lblStatus.TabIndex = 12
        lblStatus.Text = "Trạng thái"
        ' 
        ' cboStatus
        ' 
        cboStatus.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        cboStatus.FormattingEnabled = True
        cboStatus.Location = New Point(3, 179)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(200, 28)
        cboStatus.TabIndex = 13
        ' 
        ' lblNote
        ' 
        lblNote.AutoSize = True
        lblNote.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblNote.Location = New Point(390, 156)
        lblNote.Name = "lblNote"
        lblNote.Size = New Size(63, 20)
        lblNote.TabIndex = 14
        lblNote.Text = "Ghi chú"
        ' 
        ' txtNote
        ' 
        txtNote.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        txtNote.BorderStyle = BorderStyle.FixedSingle
        txtNote.Dock = DockStyle.Fill
        txtNote.ForeColor = Color.FromArgb(CByte(225), CByte(232), CByte(245))
        txtNote.Location = New Point(390, 179)
        txtNote.Multiline = True
        txtNote.Name = "txtNote"
        txtNote.Size = New Size(381, 179)
        txtNote.TabIndex = 15
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        pnlFooter.Controls.Add(btnCancel)
        pnlFooter.Controls.Add(btnSave)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Location = New Point(16, 469)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Padding = New Padding(16, 10, 16, 10)
        pnlFooter.Size = New Size(806, 56)
        pnlFooter.TabIndex = 2
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(38), CByte(43), CByte(66))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        btnCancel.Location = New Point(16, 12)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(120, 30)
        btnCancel.TabIndex = 0
        btnCancel.Text = "Hủy"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(74), CByte(158), CByte(255))
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(146, 12)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(120, 30)
        btnSave.TabIndex = 1
        btnSave.Text = "Lưu"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(30), CByte(34), CByte(53))
        pnlHeader.Controls.Add(lblSubTitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(16, 16)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(16, 10, 16, 10)
        pnlHeader.Size = New Size(806, 60)
        pnlHeader.TabIndex = 0
        ' 
        ' lblSubTitle
        ' 
        lblSubTitle.AutoSize = True
        lblSubTitle.Font = New Font("Microsoft YaHei UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubTitle.ForeColor = Color.FromArgb(CByte(139), CByte(154), CByte(181))
        lblSubTitle.Location = New Point(18, 32)
        lblSubTitle.Name = "lblSubTitle"
        lblSubTitle.Size = New Size(303, 20)
        lblSubTitle.TabIndex = 1
        lblSubTitle.Text = "Chọn dự án, nhân viên và vai trò tham gia"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        lblTitle.Location = New Point(16, 8)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(71, 27)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Dự án"
        ' 
        ' formAssignment
        ' 
        AutoScaleDimensions = New SizeF(9F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(26), CByte(29), CByte(46))
        ClientSize = New Size(838, 541)
        Controls.Add(pnlRoot)
        Font = New Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.FromArgb(CByte(197), CByte(213), CByte(240))
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "formAssignment"
        StartPosition = FormStartPosition.CenterParent
        Text = "Phân công dự án"
        pnlRoot.ResumeLayout(False)
        pnlBody.ResumeLayout(False)
        tlpFields.ResumeLayout(False)
        tlpFields.PerformLayout()
        pnlFooter.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlRoot As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubTitle As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents tlpFields As TableLayoutPanel
    Friend WithEvents lblProject As Label
    Friend WithEvents cboProject As ComboBox
    Friend WithEvents lblEmployee As Label
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents lblAllocation As Label
    Friend WithEvents txtAllocation As TextBox
    Friend WithEvents lblStart As Label
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents lblEnd As Label
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button

End Class
