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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.menu_employee = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.menu_level = New System.Windows.Forms.Button()
        Me.menu_job = New System.Windows.Forms.Button()
        Me.menu_department = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.47113!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.52887!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1424, 41)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "WindTown"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 773)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1424, 48)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.menu_employee)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.menu_level)
        Me.Panel2.Controls.Add(Me.menu_job)
        Me.Panel2.Controls.Add(Me.menu_department)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(268, 732)
        Me.Panel2.TabIndex = 2
        '
        'menu_employee
        '
        Me.menu_employee.AutoSize = True
        Me.menu_employee.Dock = System.Windows.Forms.DockStyle.Top
        Me.menu_employee.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.menu_employee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_employee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu_employee.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.menu_employee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_employee.Location = New System.Drawing.Point(0, 431)
        Me.menu_employee.Name = "menu_employee"
        Me.menu_employee.Size = New System.Drawing.Size(268, 43)
        Me.menu_employee.TabIndex = 12
        Me.menu_employee.Text = "Employee"
        Me.menu_employee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_employee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.menu_employee.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 394)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(5)
        Me.Label3.Size = New System.Drawing.Size(268, 37)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "HR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'menu_level
        '
        Me.menu_level.AutoSize = True
        Me.menu_level.Dock = System.Windows.Forms.DockStyle.Top
        Me.menu_level.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.menu_level.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_level.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu_level.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.menu_level.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_level.Location = New System.Drawing.Point(0, 350)
        Me.menu_level.Name = "menu_level"
        Me.menu_level.Size = New System.Drawing.Size(268, 44)
        Me.menu_level.TabIndex = 10
        Me.menu_level.Text = "Level"
        Me.menu_level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_level.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.menu_level.UseVisualStyleBackColor = True
        '
        'menu_job
        '
        Me.menu_job.AutoSize = True
        Me.menu_job.Dock = System.Windows.Forms.DockStyle.Top
        Me.menu_job.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.menu_job.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu_job.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.menu_job.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_job.Location = New System.Drawing.Point(0, 307)
        Me.menu_job.Name = "menu_job"
        Me.menu_job.Size = New System.Drawing.Size(268, 43)
        Me.menu_job.TabIndex = 9
        Me.menu_job.Text = "Job"
        Me.menu_job.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_job.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.menu_job.UseVisualStyleBackColor = True
        '
        'menu_department
        '
        Me.menu_department.AutoSize = True
        Me.menu_department.Dock = System.Windows.Forms.DockStyle.Top
        Me.menu_department.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.menu_department.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu_department.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu_department.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.menu_department.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_department.Location = New System.Drawing.Point(0, 264)
        Me.menu_department.Name = "menu_department"
        Me.menu_department.Size = New System.Drawing.Size(268, 43)
        Me.menu_department.TabIndex = 8
        Me.menu_department.Text = "Department"
        Me.menu_department.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.menu_department.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.menu_department.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 227)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(5)
        Me.Label2.Size = New System.Drawing.Size(268, 37)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Organization"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.WindTown_VB.My.Resources.Resources.ffc7f2dc_3179_4108_86fb_19ef31407e4e
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(268, 227)
        Me.Panel3.TabIndex = 0
        '
        'pnl_main
        '
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(268, 41)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(1156, 732)
        Me.pnl_main.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 474)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(5)
        Me.Label4.Size = New System.Drawing.Size(268, 37)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "System"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.WindTown_VB.My.Resources.Resources.home
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(0, 511)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(268, 43)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Account"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1424, 821)
        Me.Controls.Add(Me.pnl_main)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMain"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnl_main As Panel
    Friend WithEvents menu_department As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents menu_level As Button
    Friend WithEvents menu_job As Button
    Friend WithEvents menu_employee As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
End Class
