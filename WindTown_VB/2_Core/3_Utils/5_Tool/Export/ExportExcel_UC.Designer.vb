<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportExcel_UC
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
        Panel1 = New Panel()
        lstLog = New ListBox()
        btn_export = New Button()
        progress = New ProgressBar()
        btn_browse = New Button()
        txtPath = New TextBox()
        Label1 = New Label()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.Controls.Add(lstLog)
        Panel1.Controls.Add(btn_export)
        Panel1.Controls.Add(progress)
        Panel1.Controls.Add(btn_browse)
        Panel1.Controls.Add(txtPath)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(575, 274)
        Panel1.TabIndex = 0
        ' 
        ' lstLog
        ' 
        lstLog.FormattingEnabled = True
        lstLog.ItemHeight = 15
        lstLog.Location = New Point(0, 90)
        lstLog.Name = "lstLog"
        lstLog.Size = New Size(467, 124)
        lstLog.TabIndex = 6
        ' 
        ' btn_export
        ' 
        btn_export.Location = New Point(473, 61)
        btn_export.Name = "btn_export"
        btn_export.Size = New Size(78, 23)
        btn_export.TabIndex = 5
        btn_export.Text = "Export"
        btn_export.UseVisualStyleBackColor = True
        ' 
        ' progress
        ' 
        progress.Enabled = False
        progress.Location = New Point(0, 61)
        progress.Name = "progress"
        progress.Size = New Size(467, 23)
        progress.TabIndex = 3
        ' 
        ' btn_browse
        ' 
        btn_browse.Location = New Point(473, 16)
        btn_browse.Name = "btn_browse"
        btn_browse.Size = New Size(78, 23)
        btn_browse.TabIndex = 2
        btn_browse.Text = "Chọn"
        btn_browse.UseVisualStyleBackColor = True
        ' 
        ' txtPath
        ' 
        txtPath.Font = New Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPath.Location = New Point(0, 16)
        txtPath.Name = "txtPath"
        txtPath.Size = New Size(467, 22)
        txtPath.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(121, 16)
        Label1.TabIndex = 0
        Label1.Text = "Nơi lưu file excel:"
        ' 
        ' ExportExcel_UC
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "ExportExcel_UC"
        Size = New Size(575, 274)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPath As TextBox
    Friend WithEvents btn_browse As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents progress As ProgressBar
    Friend WithEvents btn_export As Button
    Friend WithEvents lstLog As ListBox

End Class
