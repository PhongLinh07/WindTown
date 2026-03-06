<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SidebarMenuV2
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tpnlSidebar = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnToggle = New System.Windows.Forms.Button()
        Me.flpnlMenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.pctbLogo = New System.Windows.Forms.PictureBox()
        Me.tpnlSidebar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pctbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tpnlSidebar
        '
        Me.tpnlSidebar.BackColor = System.Drawing.Color.Moccasin
        Me.tpnlSidebar.ColumnCount = 1
        Me.tpnlSidebar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlSidebar.Controls.Add(Me.pnlHeader, 0, 0)
        Me.tpnlSidebar.Controls.Add(Me.flpnlMenu, 0, 1)
        Me.tpnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tpnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.tpnlSidebar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tpnlSidebar.Name = "tpnlSidebar"
        Me.tpnlSidebar.RowCount = 2
        Me.tpnlSidebar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tpnlSidebar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tpnlSidebar.Size = New System.Drawing.Size(167, 656)
        Me.tpnlSidebar.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BackColor = System.Drawing.Color.Orange
        Me.pnlHeader.Controls.Add(Me.btnToggle)
        Me.pnlHeader.Controls.Add(Me.pctbLogo)
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(161, 94)
        Me.pnlHeader.TabIndex = 0
        '
        'btnToggle
        '
        Me.btnToggle.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggle.Location = New System.Drawing.Point(121, 0)
        Me.btnToggle.MaximumSize = New System.Drawing.Size(40, 40)
        Me.btnToggle.MinimumSize = New System.Drawing.Size(40, 40)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(40, 40)
        Me.btnToggle.TabIndex = 1
        Me.btnToggle.Text = "☰"
        Me.btnToggle.UseVisualStyleBackColor = True
        '
        'flpnlMenu
        '
        Me.flpnlMenu.AutoScroll = True
        Me.flpnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpnlMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpnlMenu.Location = New System.Drawing.Point(3, 103)
        Me.flpnlMenu.Name = "flpnlMenu"
        Me.flpnlMenu.Size = New System.Drawing.Size(161, 550)
        Me.flpnlMenu.TabIndex = 1
        Me.flpnlMenu.WrapContents = False
        '
        'pctbLogo
        '
        Me.pctbLogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctbLogo.ErrorImage = Global.WindTown_VB.My.Resources.Resources.ErrorImage
        Me.pctbLogo.Image = Global.WindTown_VB.My.Resources.Resources.LogoHR
        Me.pctbLogo.InitialImage = Global.WindTown_VB.My.Resources.Resources.LogoHR
        Me.pctbLogo.Location = New System.Drawing.Point(4, 3)
        Me.pctbLogo.Name = "pctbLogo"
        Me.pctbLogo.Size = New System.Drawing.Size(100, 88)
        Me.pctbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctbLogo.TabIndex = 0
        Me.pctbLogo.TabStop = False
        '
        'SidebarMenuV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tpnlSidebar)
        Me.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SidebarMenuV2"
        Me.Size = New System.Drawing.Size(167, 656)
        Me.tpnlSidebar.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.pctbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tpnlSidebar As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pctbLogo As PictureBox
    Friend WithEvents btnToggle As Button
    Friend WithEvents flpnlMenu As FlowLayoutPanel
End Class
