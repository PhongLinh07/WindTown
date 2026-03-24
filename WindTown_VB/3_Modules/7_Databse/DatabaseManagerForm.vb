Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.IO

''' <summary>
''' Form quản lý database: tạo rỗng, xóa, load dữ liệu, backup, đổi kết nối.
''' Mở từ menu Settings hoặc bất kỳ đâu: DatabaseManagerForm.OpenAsDialog(Me)
''' </summary>
Public Class DatabaseManagerForm
    Inherits Form

#Region "Fields & Colors"
    Private ReadOnly C_BG As Color = Color.FromArgb(15, 17, 23)
    Private ReadOnly C_SURFACE As Color = Color.FromArgb(22, 27, 38)
    Private ReadOnly C_BORDER As Color = Color.FromArgb(48, 54, 68)
    Private ReadOnly C_ACCENT As Color = Color.FromArgb(56, 189, 248)
    Private ReadOnly C_DANGER As Color = Color.FromArgb(239, 68, 68)
    Private ReadOnly C_SUCCESS As Color = Color.FromArgb(34, 197, 94)
    Private ReadOnly C_WARN As Color = Color.FromArgb(251, 191, 36)
    Private ReadOnly C_TEXT As Color = Color.FromArgb(226, 232, 240)
    Private ReadOnly C_MUTED As Color = Color.FromArgb(100, 116, 139)

    ' Controls
    Private pnlLeft As Panel
    Private pnlRight As Panel
    Private pnlLog As Panel
    Private lblTitle As Label
    Private lblConnLabel As Label
    Private txtConn As TextBox
    Private btnTestConn As Button
    Private btnApplyConn As Button
    Private lblStatus As Label
    Private lblStatusDot As Label
    Private lstLog As ListBox
    Private pnlInfo As Panel
    Private lblInfoTitle As Label

    ' Nav buttons
    Private WithEvents btnNavInfo As Button
    Private WithEvents btnNavCreate As Button
    Private WithEvents btnNavLoad As Button
    Private WithEvents btnNavBackup As Button
    Private WithEvents btnNavDrop As Button

    ' Action panels
    Private pnlCreate As Panel
    Private pnlLoad As Panel
    Private pnlBackup As Panel
    Private pnlDrop As Panel

    Private _currentNav As Button = Nothing
#End Region

#Region "Factory"
    Public Shared Sub OpenAsDialog(owner As Form)
        Using frm As New DatabaseManagerForm()
            frm.ShowDialog(owner)
        End Using
    End Sub
#End Region

#Region "Constructor & Init"
    Public Sub New()
        InitializeComponent()

        Me.Text = "Database Manager"
        Me.Size = New Size(820, 580)
        Me.MinimumSize = New Size(1080, 648)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = C_BG
        Me.Font = New Font("Segoe UI", 9)

        BuildLayout()
    End Sub

    Private Sub BuildLayout()
        ' ── Header ─────────────────────────────────────────────────────────
        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 52,
            .BackColor = C_SURFACE
        }
        Dim lblH As New Label With {
            .Text = "⚙  Database Manager",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = C_TEXT,
            .AutoSize = True,
            .Location = New Point(20, 14)
        }
        Dim lblSub As New Label With {
            .Text = "wind_town",
            .Font = New Font("Segoe UI", 9),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(250, 20)
        }
        pnlHeader.Controls.AddRange({lblH, lblSub})

        ' ── Left nav (160px) ────────────────────────────────────────────────
        pnlLeft = New Panel With {
            .Width = 160,
            .Dock = DockStyle.Left,
            .BackColor = C_SURFACE,
            .Padding = New Padding(0, 8, 0, 0)
        }

        Dim navItems = {
            ("btnNavInfo", "●  Thông tin", C_ACCENT),
            ("btnNavCreate", "+  Tạo rỗng", C_ACCENT),
            ("btnNavLoad", "↓  Load dữ liệu", C_ACCENT),
            ("btnNavBackup", "◎  Backup", C_ACCENT),
            ("btnNavDrop", "✕  Xóa database", C_DANGER)
        }

        Dim yPos = 12
        For Each item In navItems
            Dim btn As New Button With {
                .Name = item.Item1,
                .Text = item.Item2,
                .Size = New Size(152, 38),
                .Location = New Point(4, yPos),
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.Transparent,
                .ForeColor = C_MUTED,
                .Font = New Font("Segoe UI", 9),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(12, 0, 0, 0),
                .Cursor = Cursors.Hand,
                .Tag = item.Item3
            }
            btn.FlatAppearance.BorderSize = 0
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 56, 189, 248)
            AddHandler btn.Click, AddressOf NavButton_Click

            Select Case item.Item1
                Case "btnNavInfo" : btnNavInfo = btn
                Case "btnNavCreate" : btnNavCreate = btn
                Case "btnNavLoad" : btnNavLoad = btn
                Case "btnNavBackup" : btnNavBackup = btn
                Case "btnNavDrop" : btnNavDrop = btn
            End Select

            pnlLeft.Controls.Add(btn)
            yPos += 42
        Next

        ' Separator trước Xóa
        Dim sep As New Panel With {
            .Size = New Size(130, 1),
            .Location = New Point(15, yPos - 6),
            .BackColor = C_BORDER
        }
        pnlLeft.Controls.Add(sep)

        ' ── Right content ───────────────────────────────────────────────────
        pnlRight = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Padding = New Padding(20, 16, 20, 0)
        }

        ' Connection bar ở trên
        Dim pnlConn As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 82,
            .BackColor = C_SURFACE,
            .Padding = New Padding(16, 10, 16, 10)
        }

        lblConnLabel = New Label With {
            .Text = "Chuỗi kết nối",
            .Font = New Font("Segoe UI", 8),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(16, 10)
        }

        txtConn = New TextBox With {
            .Location = New Point(16, 28),
            .Width = 450,
            .Height = 26,
            .BackColor = C_BG,
            .ForeColor = C_TEXT,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Consolas", 8.5F),
            .Text = DatabaseConfig.Database.ConnectionString
        }

        btnTestConn = MakeButton("Test", 480, 26, C_ACCENT, C_BG, 72, 26)
        btnApplyConn = MakeButton("Áp dụng", 558, 26, C_SURFACE, C_TEXT, 80, 26)
        btnApplyConn.FlatAppearance.BorderColor = C_BORDER
        btnApplyConn.FlatAppearance.BorderSize = 1

        lblStatusDot = New Label With {
            .Size = New Size(10, 10),
            .Location = New Point(650, 31),
            .BackColor = C_MUTED
        }
        MakeRound(lblStatusDot, 5)

        lblStatus = New Label With {
            .Text = "Chưa kiểm tra",
            .Font = New Font("Segoe UI", 8),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(665, 30)
        }

        AddHandler btnTestConn.Click, AddressOf BtnTestConn_Click
        AddHandler btnApplyConn.Click, AddressOf BtnApplyConn_Click

        pnlConn.Controls.AddRange({lblConnLabel, txtConn, btnTestConn, btnApplyConn, lblStatusDot, lblStatus})

        ' Content area
        Dim pnlContent As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG
        }

        ' Log panel ở dưới
        pnlLog = New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 120,
            .BackColor = C_SURFACE,
            .Padding = New Padding(0)
        }
        Dim lblLog As New Label With {
            .Text = "  LOG",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .ForeColor = C_MUTED,
            .Size = New Size(80, 20),
            .Location = New Point(0, 0),
            .BackColor = Color.FromArgb(28, 33, 45)
        }
        lstLog = New ListBox With {
            .Dock = DockStyle.Fill,
            .BackColor = C_SURFACE,
            .ForeColor = C_MUTED,
            .Font = New Font("Consolas", 8),
            .BorderStyle = BorderStyle.None,
            .SelectionMode = SelectionMode.None
        }
        pnlLog.Controls.Add(lstLog)
        pnlLog.Controls.Add(lblLog)

        ' Action panels (chỉ 1 hiển thị tại 1 thời điểm)
        BuildInfoPanel(pnlContent)
        BuildCreatePanel(pnlContent)
        BuildLoadPanel(pnlContent)
        BuildBackupPanel(pnlContent)
        BuildDropPanel(pnlContent)

        pnlContent.Controls.Add(pnlLog)

        pnlRight.Controls.Add(pnlContent)
        pnlRight.Controls.Add(pnlConn)

        Me.Controls.Add(pnlRight)
        Me.Controls.Add(pnlLeft)
        Me.Controls.Add(pnlHeader)
        AddHandler Me.Load, AddressOf Form_Load
    End Sub
#End Region

#Region "Build Action Panels"
    Private Sub BuildInfoPanel(parent As Panel)
        pnlInfo = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Visible = False,
            .Padding = New Padding(20, 16, 20, 16)
        }
        lblInfoTitle = New Label With {
            .Text = "Đang tải thông tin...",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = C_TEXT,
            .AutoSize = True,
            .Location = New Point(20, 16)
        }
        pnlInfo.Controls.Add(lblInfoTitle)
        parent.Controls.Add(pnlInfo)
    End Sub

    Private Sub BuildCreatePanel(parent As Panel)
        pnlCreate = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Visible = False,
            .Padding = New Padding(20, 20, 20, 20)
        }

        Dim y = 20
        AddSectionTitle(pnlCreate, "Tạo database rỗng", y)
        AddDescription(pnlCreate,
            "Tạo mới database '" & DatabaseManagerService.DatabaseName & "' với cấu trúc bảng đầy đủ nhưng không có dữ liệu." & vbCrLf &
            "Yêu cầu: database chưa tồn tại. File schema SQL phải có tại 1_Documents/.", y)

        Dim btnCreate = MakeActionButton("✦  Tạo database rỗng", C_ACCENT, C_BG, 200, 38)
        btnCreate.Location = New Point(20, y + 8)
        AddHandler btnCreate.Click, Sub()
                                        If Confirm("Xác nhận tạo database rỗng?") Then
                                            RunOp(Function() DatabaseManagerService.CreateEmptyDatabase(txtConn.Text))
                                        End If
                                    End Sub
        pnlCreate.Controls.Add(btnCreate)
        parent.Controls.Add(pnlCreate)
    End Sub

    Private Sub BuildLoadPanel(parent As Panel)
        pnlLoad = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Visible = False,
            .Padding = New Padding(20, 20, 20, 20)
        }

        Dim y = 20
        AddSectionTitle(pnlLoad, "Load dữ liệu từ file SQL", y)
        AddDescription(pnlLoad,
            "Chọn file .sql để thực thi vào database hiện tại." & vbCrLf &
            "Có thể dùng để restore dữ liệu, import từ backup script hoặc chạy seed data.", y)

        Dim lblFile As New Label With {
            .Text = "File SQL:",
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(20, y + 8)
        }
        Dim txtFile As New TextBox With {
            .Location = New Point(20, y + 26),
            .Width = 360,
            .Height = 26,
            .BackColor = C_SURFACE,
            .ForeColor = C_TEXT,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Consolas", 8.5F),
            .ReadOnly = True
        }
        Dim btnBrowse = MakeButton("Chọn file...", 390, y + 24, C_SURFACE, C_TEXT, 90, 26)
        btnBrowse.FlatAppearance.BorderColor = C_BORDER
        btnBrowse.FlatAppearance.BorderSize = 1
        AddHandler btnBrowse.Click, Sub()
                                        Using ofd As New OpenFileDialog With {
                                            .Filter = "SQL files (*.sql)|*.sql|Tất cả|*.*",
                                            .Title = "Chọn file SQL"
                                        }
                                            If ofd.ShowDialog() = DialogResult.OK Then
                                                txtFile.Text = ofd.FileName
                                            End If
                                        End Using
                                    End Sub

        Dim btnLoad = MakeActionButton("↓  Load dữ liệu", C_ACCENT, C_BG, 160, 38)
        btnLoad.Location = New Point(20, y + 62)
        AddHandler btnLoad.Click, Sub()
                                      If String.IsNullOrWhiteSpace(txtFile.Text) Then
                                          Log("⚠ Chưa chọn file SQL.", C_WARN)
                                          Return
                                      End If
                                      If Confirm($"Load dữ liệu từ:{vbCrLf}{txtFile.Text}?") Then
                                          RunOp(Function() DatabaseManagerService.LoadFromSqlFile(txtConn.Text, txtFile.Text))
                                      End If
                                  End Sub

        pnlLoad.Controls.AddRange({lblFile, txtFile, btnBrowse, btnLoad})
        parent.Controls.Add(pnlLoad)
    End Sub

    Private Sub BuildBackupPanel(parent As Panel)
        pnlBackup = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Visible = False,
            .Padding = New Padding(20, 20, 20, 20)
        }

        Dim y = 20
        AddSectionTitle(pnlBackup, "Backup database", y)
        AddDescription(pnlBackup,
            "Xuất file .bak chứa toàn bộ database (schema + dữ liệu)." & vbCrLf &
            "File được lưu trực tiếp trên máy chủ SQL Server.", y)

        Dim defaultPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            $"WindTown_backup_{DateTime.Now:yyyyMMdd_HHmm}.bak")

        Dim lblPath As New Label With {
            .Text = "Đường dẫn file backup:",
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(20, y + 8)
        }
        Dim txtPath As New TextBox With {
            .Location = New Point(20, y + 26),
            .Width = 420,
            .Height = 26,
            .BackColor = C_SURFACE,
            .ForeColor = C_TEXT,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Consolas", 8.5F),
            .Text = defaultPath
        }

        Dim btnBackup = MakeActionButton("◎  Bắt đầu backup", C_WARN, C_BG, 180, 38)
        btnBackup.Location = New Point(20, y + 62)
        AddHandler btnBackup.Click, Sub()
                                        If String.IsNullOrWhiteSpace(txtPath.Text) Then Return
                                        If Confirm($"Backup database vào:{vbCrLf}{txtPath.Text}?") Then
                                            RunOp(Function() DatabaseManagerService.BackupDatabase(txtConn.Text, txtPath.Text))
                                        End If
                                    End Sub

        pnlBackup.Controls.AddRange({lblPath, txtPath, btnBackup})
        parent.Controls.Add(pnlBackup)
    End Sub

    Private Sub BuildDropPanel(parent As Panel)
        pnlDrop = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = C_BG,
            .Visible = False,
            .Padding = New Padding(20, 20, 20, 20)
        }

        Dim y = 20
        AddSectionTitle(pnlDrop, "Xóa database", y, C_DANGER)

        ' Warning box
        Dim pnlWarn As New Panel With {
            .Location = New Point(20, y + 4),
            .Size = New Size(520, 64),
            .BackColor = Color.FromArgb(40, 239, 68, 68)
        }
        MakeRound(pnlWarn, 6)
        Dim lblWarnText As New Label With {
            .Text = "⚠  Thao tác này KHÔNG THỂ HOÀN TÁC." & vbCrLf &
                    $"   Toàn bộ dữ liệu trong database '{DatabaseManagerService.DatabaseName}' sẽ bị xóa vĩnh viễn.",
            .Font = New Font("Segoe UI", 9),
            .ForeColor = Color.FromArgb(252, 165, 165),
            .Dock = DockStyle.Fill,
            .Padding = New Padding(12, 8, 8, 8)
        }
        pnlWarn.Controls.Add(lblWarnText)
        pnlDrop.Controls.Add(pnlWarn)
        y += 76

        ' Confirm input
        Dim lblConfirm As New Label With {
            .Text = $"Nhập tên database để xác nhận xóa:",
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = C_MUTED,
            .AutoSize = True,
            .Location = New Point(20, y + 8)
        }
        Dim txtConfirm As New TextBox With {
            .Location = New Point(20, y + 28),
            .Width = 200,
            .Height = 26,
            .BackColor = C_SURFACE,
            .ForeColor = C_TEXT,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Consolas", 9),
            .PlaceholderText = DatabaseManagerService.DatabaseName
        }

        Dim btnDrop = MakeActionButton("✕  Xóa database", C_DANGER, Color.White, 160, 38)
        btnDrop.Location = New Point(20, y + 64)
        AddHandler btnDrop.Click, Sub()
                                      If txtConfirm.Text.Trim() <> DatabaseManagerService.DatabaseName Then
                                          Log($"⚠ Nhập đúng tên database '{DatabaseManagerService.DatabaseName}' để xác nhận.", C_WARN)
                                          Return
                                      End If
                                      txtConfirm.BackColor = C_SURFACE
                                      If Confirm($"XÓA TOÀN BỘ database '{DatabaseManagerService.DatabaseName}'?{vbCrLf}Hành động này KHÔNG thể hoàn tác!",
                                                 MessageBoxIcon.Warning) Then
                                          RunOp(Function() DatabaseManagerService.DropDatabase(txtConn.Text))
                                          txtConfirm.Clear()
                                      End If
                                  End Sub

        pnlDrop.Controls.AddRange({lblConfirm, txtConfirm, btnDrop})
        parent.Controls.Add(pnlDrop)
    End Sub
#End Region

#Region "Nav"
    Private Sub Form_Load(sender As Object, e As EventArgs)
        SelectNav(btnNavInfo)
    End Sub

    Private Sub NavButton_Click(sender As Object, e As EventArgs)
        SelectNav(CType(sender, Button))
    End Sub

    Private Sub SelectNav(btn As Button)
        If _currentNav IsNot Nothing Then
            _currentNav.BackColor = Color.Transparent
            _currentNav.ForeColor = C_MUTED
            _currentNav.Font = New Font("Segoe UI", 9)
        End If
        btn.BackColor = Color.FromArgb(20, 56, 189, 248)
        btn.ForeColor = If(btn Is btnNavDrop, C_DANGER, C_ACCENT)
        btn.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        _currentNav = btn

        pnlInfo.Visible = btn Is btnNavInfo
        pnlCreate.Visible = btn Is btnNavCreate
        pnlLoad.Visible = btn Is btnNavLoad
        pnlBackup.Visible = btn Is btnNavBackup
        pnlDrop.Visible = btn Is btnNavDrop

        If btn Is btnNavInfo Then LoadDbInfo()
    End Sub

    Private Sub LoadDbInfo()
        pnlInfo.Controls.Clear()
        Dim info = DatabaseManagerService.GetDatabaseInfo(txtConn.Text)

        lblInfoTitle = New Label With {
            .Text = "Thông tin database",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = C_TEXT,
            .AutoSize = True,
            .Location = New Point(20, 16)
        }
        pnlInfo.Controls.Add(lblInfoTitle)

        Dim y = 48
        For Each kv In info
            Dim isError = kv.Key = "Lỗi" OrElse kv.Key = "Trạng thái" AndAlso kv.Value = "Mất kết nối"
            Dim rowPanel As New Panel With {
                .Location = New Point(20, y),
                .Size = New Size(520, 32),
                .BackColor = C_SURFACE
            }
            Dim lblKey As New Label With {
                .Text = kv.Key,
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = C_MUTED,
                .Size = New Size(140, 32),
                .Location = New Point(12, 0),
                .TextAlign = ContentAlignment.MiddleLeft
            }
            Dim lblVal As New Label With {
                .Text = kv.Value,
                .Font = New Font("Consolas", 8.5F),
                .ForeColor = If(isError, C_DANGER, C_TEXT),
                .AutoSize = True,
                .Location = New Point(155, 8)
            }
            rowPanel.Controls.AddRange({lblKey, lblVal})
            pnlInfo.Controls.Add(rowPanel)
            y += 36
        Next
    End Sub
#End Region

#Region "Button handlers"
    Private Sub BtnTestConn_Click(sender As Object, e As EventArgs)
        Dim result = DatabaseManagerService.TestConnection(txtConn.Text)
        SetConnectionStatus(result.IsSuccess)
        Log(If(result.IsSuccess, "✓ " & result.Message & If(result.Detail <> "", " | " & result.Detail, ""),
                                 "✕ " & result.Message),
            If(result.IsSuccess, C_SUCCESS, C_DANGER))
    End Sub

    Private Sub BtnApplyConn_Click(sender As Object, e As EventArgs)
        RunOp(Function() DatabaseManagerService.ApplyNewConnection(txtConn.Text))
    End Sub

    Private Sub SetConnectionStatus(ok As Boolean)
        lblStatusDot.BackColor = If(ok, C_SUCCESS, C_DANGER)
        lblStatus.Text = If(ok, "Kết nối OK", "Mất kết nối")
        lblStatus.ForeColor = If(ok, C_SUCCESS, C_DANGER)
    End Sub
#End Region

#Region "Helpers"
    Private Sub RunOp(op As Func(Of DbOperationResult))
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim result = op()
            Log(If(result.IsSuccess, "✓ " & result.Message, "✕ " & result.Message),
                If(result.IsSuccess, C_SUCCESS, C_DANGER))
            If result.IsSuccess AndAlso Not String.IsNullOrWhiteSpace(result.Detail) Then
                Log("  → " & result.Detail, C_MUTED)
            End If
            If result.IsSuccess AndAlso (_currentNav Is btnNavInfo) Then LoadDbInfo()
        Catch ex As Exception
            Log("✕ Lỗi không xác định: " & ex.Message, C_DANGER)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Log(msg As String, Optional clr As Color = Nothing)
        Dim entry = $"[{DateTime.Now:HH:mm:ss}]  {msg}"
        lstLog.Items.Add(entry)
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub

    Private Function Confirm(msg As String,
                             Optional icon As MessageBoxIcon = MessageBoxIcon.Question) As Boolean
        Return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, icon) = DialogResult.Yes
    End Function

    Private Sub AddSectionTitle(parent As Panel, text As String, ByRef y As Integer,
                                Optional clr As Color = Nothing)
        If clr = Nothing Then clr = C_TEXT
        Dim lbl As New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .ForeColor = clr,
            .AutoSize = True,
            .Location = New Point(20, y)
        }
        parent.Controls.Add(lbl)
        y += 34
    End Sub

    Private Sub AddDescription(parent As Panel, text As String, ByRef y As Integer)
        Dim lbl As New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = C_MUTED,
            .AutoSize = False,
            .Size = New Size(540, 40),
            .Location = New Point(20, y)
        }
        parent.Controls.Add(lbl)
        y += 52
    End Sub

    Private Function MakeButton(text As String, x As Integer, y As Integer,
                                bg As Color, fg As Color,
                                w As Integer, h As Integer) As Button
        Dim btn As New Button With {
            .Text = text,
            .Location = New Point(x, y),
            .Size = New Size(w, h),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = bg,
            .ForeColor = fg,
            .Font = New Font("Segoe UI", 8.5F),
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0
        Return btn
    End Function

    Private Function MakeActionButton(text As String, bg As Color, fg As Color,
                                      w As Integer, h As Integer) As Button
        Dim btn As New Button With {
            .Text = text,
            .Size = New Size(w, h),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = bg,
            .ForeColor = fg,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0
        Return btn
    End Function

    Private Sub MakeRound(ctrl As Control, radius As Integer)
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90)
        path.AddArc(ctrl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90)
        path.AddArc(ctrl.Width - radius * 2, ctrl.Height - radius * 2, radius * 2, radius * 2, 0, 90)
        path.AddArc(0, ctrl.Height - radius * 2, radius * 2, radius * 2, 90, 90)
        path.CloseFigure()
        ctrl.Region = New Region(path)
    End Sub
#End Region

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        ' Đường viền gradient trên cùng
        Using pen As New LinearGradientBrush(
            New Point(0, 0), New Point(Me.Width, 0),
            Color.FromArgb(99, 102, 241), C_ACCENT)
            e.Graphics.FillRectangle(pen, 0, 0, Me.Width, 2)
        End Using
    End Sub


End Class