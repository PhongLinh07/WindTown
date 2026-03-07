<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSidebar
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnToggle = New System.Windows.Forms.Button()
        Me.ptbLogo = New System.Windows.Forms.PictureBox()
        Me.flpnlMenu = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpMain.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.BackColor = System.Drawing.Color.Moccasin
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.pnlHeader, 0, 0)
        Me.tlpMain.Controls.Add(Me.flpnlMenu, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(210, 700)
        Me.tlpMain.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.btnToggle)
        Me.pnlHeader.Controls.Add(Me.ptbLogo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(204, 74)
        Me.pnlHeader.TabIndex = 0
        '
        'btnToggle
        '
        Me.btnToggle.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnToggle.Location = New System.Drawing.Point(164, 0)
        Me.btnToggle.MaximumSize = New System.Drawing.Size(40, 40)
        Me.btnToggle.MinimumSize = New System.Drawing.Size(40, 40)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.Size = New System.Drawing.Size(40, 40)
        Me.btnToggle.TabIndex = 1
        Me.btnToggle.Text = "<"
        Me.btnToggle.UseVisualStyleBackColor = True
        '
        'ptbLogo
        '
        Me.ptbLogo.Dock = System.Windows.Forms.DockStyle.Left
        Me.ptbLogo.ErrorImage = Global.WindTown_VB.My.Resources.Resources.ErrorImage
        Me.ptbLogo.Image = Global.WindTown_VB.My.Resources.Resources.LogoHR
        Me.ptbLogo.InitialImage = Global.WindTown_VB.My.Resources.Resources.LogoHR
        Me.ptbLogo.Location = New System.Drawing.Point(0, 0)
        Me.ptbLogo.Name = "ptbLogo"
        Me.ptbLogo.Size = New System.Drawing.Size(126, 74)
        Me.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ptbLogo.TabIndex = 0
        Me.ptbLogo.TabStop = False
        '
        'flpnlMenu
        '
        Me.flpnlMenu.AutoScroll = True
        Me.flpnlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpnlMenu.Location = New System.Drawing.Point(3, 83)
        Me.flpnlMenu.Name = "flpnlMenu"
        Me.flpnlMenu.Size = New System.Drawing.Size(204, 614)
        Me.flpnlMenu.TabIndex = 1
        '
        'ucSidebar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucSidebar"
        Me.Size = New System.Drawing.Size(210, 700)
        Me.tlpMain.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.ptbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents ptbLogo As PictureBox
    Friend WithEvents btnToggle As Button
    Friend WithEvents flpnlMenu As FlowLayoutPanel
End Class
