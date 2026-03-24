'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.IO
'Imports System.Windows.Forms
'Imports Microsoft.EntityFrameworkCore

'''' <summary>
'''' Form quản lý database: tạo rỗng, xóa, load dữ liệu, backup, đổi kết nối.
'''' Mở từ menu Settings hoặc bất kỳ đâu: DatabaseManagerForm.OpenAsDialog(Me)
'''' </summary>
'Public Class DatabaseManager
'    Inherits Form


'#Region "Factory"
'    Public Shared Sub OpenAsDialog(owner As Form)
'        Using frm As New DatabaseManagerForm()
'            frm.ShowDialog(owner)
'        End Using
'    End Sub
'#End Region

'#Region "Constructor & Init"
'    Public Sub New()
'        InitializeComponent()
'    End Sub

'    Private Sub InitializeComponent()


'        BuildLayout()
'    End Sub


'#End Region

'#Region "Build Action Panels"
'    Private Sub BuildInfoPanel(parent As Panel)
'        pnlInfo = New Panel With {
'            .Dock = DockStyle.Fill,
'            .BackColor = C_BG,
'            .Visible = False,
'            .Padding = New Padding(20, 16, 20, 16)
'        }
'        lblInfoTitle = New Label With {
'            .Text = "Đang tải thông tin...",
'            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
'            .ForeColor = C_TEXT,
'            .AutoSize = True,
'            .Location = New Point(20, 16)
'        }
'        pnlInfo.Controls.Add(lblInfoTitle)
'        parent.Controls.Add(pnlInfo)
'    End Sub

'    Private Sub BuildCreatePanel(parent As Panel)
'        pnlCreate = New Panel With {
'            .Dock = DockStyle.Fill,
'            .BackColor = C_BG,
'            .Visible = False,
'            .Padding = New Padding(20, 20, 20, 20)
'        }

'        Dim y = 20
'        AddSectionTitle(pnlCreate, "Tạo database rỗng", ref y)
'        AddDescription(pnlCreate,
'            "Tạo mới database '" & DatabaseManagerService.DatabaseName & "' với cấu trúc bảng đầy đủ nhưng không có dữ liệu." & vbCrLf &
'            "Yêu cầu: database chưa tồn tại. File schema SQL phải có tại 1_Documents/.", ref y)

'        Dim btnCreate = MakeActionButton("✦  Tạo database rỗng", C_ACCENT, C_BG, 200, 38)
'        btnCreate.Location = New Point(20, y + 8)
'        AddHandler btnCreate.Click, Sub()
'                                        If Confirm("Xác nhận tạo database rỗng?") Then
'                                            RunOp(Sub() DatabaseManagerService.CreateEmptyDatabase(txtConn.Text))
'                                        End If
'                                    End Sub
'        pnlCreate.Controls.Add(btnCreate)
'        parent.Controls.Add(pnlCreate)
'    End Sub

'    Private Sub BuildLoadPanel(parent As Panel)
'        pnlLoad = New Panel With {
'            .Dock = DockStyle.Fill,
'            .BackColor = C_BG,
'            .Visible = False,
'            .Padding = New Padding(20, 20, 20, 20)
'        }

'        Dim y = 20
'        AddSectionTitle(pnlLoad, "Load dữ liệu từ file SQL", ref y)
'        AddDescription(pnlLoad,
'            "Chọn file .sql để thực thi vào database hiện tại." & vbCrLf &
'            "Có thể dùng để restore dữ liệu, import từ backup script hoặc chạy seed data.", ref y)

'        Dim lblFile As New Label With {
'            .Text = "File SQL:",
'            .Font = New Font("Segoe UI", 8.5F),
'            .ForeColor = C_MUTED,
'            .AutoSize = True,
'            .Location = New Point(20, y + 8)
'        }
'        Dim txtFile As New TextBox With {
'            .Location = New Point(20, y + 26),
'            .Width = 360,
'            .Height = 26,
'            .BackColor = C_SURFACE,
'            .ForeColor = C_TEXT,
'            .BorderStyle = BorderStyle.FixedSingle,
'            .Font = New Font("Consolas", 8.5F),
'            .ReadOnly = True
'        }
'        Dim btnBrowse = MakeButton("Chọn file...", 390, y + 24, C_SURFACE, C_TEXT, 90, 26)
'        btnBrowse.FlatAppearance.BorderColor = C_BORDER
'        btnBrowse.FlatAppearance.BorderSize = 1
'        AddHandler btnBrowse.Click, Sub()
'                                        Using ofd As New OpenFileDialog With {
'                                            .Filter = "SQL files (*.sql)|*.sql|Tất cả|*.*",
'                                            .Title = "Chọn file SQL"
'                                        }
'                                            If ofd.ShowDialog() = DialogResult.OK Then
'                                                txtFile.Text = ofd.FileName
'                                            End If
'                                        End Using
'                                    End Sub

'        Dim btnLoad = MakeActionButton("↓  Load dữ liệu", C_ACCENT, C_BG, 160, 38)
'        btnLoad.Location = New Point(20, y + 62)
'        AddHandler btnLoad.Click, Sub()
'                                      If String.IsNullOrWhiteSpace(txtFile.Text) Then
'                                          Log("⚠ Chưa chọn file SQL.", C_WARN)
'                                          Return
'                                      End If
'                                      If Confirm($"Load dữ liệu từ:{vbCrLf}{txtFile.Text}?") Then
'                                          RunOp(Sub() DatabaseManagerService.LoadFromSqlFile(txtConn.Text, txtFile.Text))
'                                      End If
'                                  End Sub

'        pnlLoad.Controls.AddRange({lblFile, txtFile, btnBrowse, btnLoad})
'        parent.Controls.Add(pnlLoad)
'    End Sub

'    Private Sub BuildBackupPanel(parent As Panel)
'        pnlBackup = New Panel With {
'            .Dock = DockStyle.Fill,
'            .BackColor = C_BG,
'            .Visible = False,
'            .Padding = New Padding(20, 20, 20, 20)
'        }

'        Dim y = 20
'        AddSectionTitle(pnlBackup, "Backup database", ref y)
'        AddDescription(pnlBackup,
'            "Xuất file .bak chứa toàn bộ database (schema + dữ liệu)." & vbCrLf &
'            "File được lưu trực tiếp trên máy chủ SQL Server.", ref y)

'        Dim defaultPath = Path.Combine(
'            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
'            $"WindTown_backup_{DateTime.Now:yyyyMMdd_HHmm}.bak")

'        Dim lblPath As New Label With {
'            .Text = "Đường dẫn file backup:",
'            .Font = New Font("Segoe UI", 8.5F),
'            .ForeColor = C_MUTED,
'            .AutoSize = True,
'            .Location = New Point(20, y + 8)
'        }
'        Dim txtPath As New TextBox With {
'            .Location = New Point(20, y + 26),
'            .Width = 420,
'            .Height = 26,
'            .BackColor = C_SURFACE,
'            .ForeColor = C_TEXT,
'            .BorderStyle = BorderStyle.FixedSingle,
'            .Font = New Font("Consolas", 8.5F),
'            .Text = defaultPath
'        }

'        Dim btnBackup = MakeActionButton("◎  Bắt đầu backup", C_WARN, C_BG, 180, 38)
'        btnBackup.Location = New Point(20, y + 62)
'        AddHandler btnBackup.Click, Sub()
'                                        If String.IsNullOrWhiteSpace(txtPath.Text) Then Return
'                                        If Confirm($"Backup database vào:{vbCrLf}{txtPath.Text}?") Then
'                                            RunOp(Sub() DatabaseManagerService.BackupDatabase(txtConn.Text, txtPath.Text))
'                                        End If
'                                    End Sub

'        pnlBackup.Controls.AddRange({lblPath, txtPath, btnBackup})
'        parent.Controls.Add(pnlBackup)
'    End Sub

'    Private Sub BuildDropPanel(parent As Panel)
'        pnlDrop = New Panel With {
'            .Dock = DockStyle.Fill,
'            .BackColor = C_BG,
'            .Visible = False,
'            .Padding = New Padding(20, 20, 20, 20)
'        }

'        Dim y = 20
'        AddSectionTitle(pnlDrop, "Xóa database", ref y, C_DANGER)

'        ' Warning box
'        Dim pnlWarn As New Panel With {
'            .Location = New Point(20, y + 4),
'            .Size = New Size(520, 64),
'            .BackColor = Color.FromArgb(40, 239, 68, 68)
'        }
'        MakeRound(pnlWarn, 6)
'        Dim lblWarnText As New Label With {
'            .Text = "⚠  Thao tác này KHÔNG THỂ HOÀN TÁC." & vbCrLf &
'                    $"   Toàn bộ dữ liệu trong database '{DatabaseManagerService.DatabaseName}' sẽ bị xóa vĩnh viễn.",
'            .Font = New Font("Segoe UI", 9),
'            .ForeColor = Color.FromArgb(252, 165, 165),
'            .Dock = DockStyle.Fill,
'            .Padding = New Padding(12, 8, 8, 8)
'        }
'        pnlWarn.Controls.Add(lblWarnText)
'        pnlDrop.Controls.Add(pnlWarn)
'        y += 76

'        ' Confirm input
'        Dim lblConfirm As New Label With {
'            .Text = $"Nhập tên database để xác nhận xóa:",
'            .Font = New Font("Segoe UI", 8.5F),
'            .ForeColor = C_MUTED,
'            .AutoSize = True,
'            .Location = New Point(20, y + 8)
'        }
'        Dim txtConfirm As New TextBox With {
'            .Location = New Point(20, y + 28),
'            .Width = 200,
'            .Height = 26,
'            .BackColor = C_SURFACE,
'            .ForeColor = C_TEXT,
'            .BorderStyle = BorderStyle.FixedSingle,
'            .Font = New Font("Consolas", 9),
'            .PlaceholderText = DatabaseManagerService.DatabaseName
'        }

'        Dim btnDrop = MakeActionButton("✕  Xóa database", C_DANGER, Color.White, 160, 38)
'        btnDrop.Location = New Point(20, y + 64)
'        AddHandler btnDrop.Click, Sub()
'                                      If txtConfirm.Text.Trim() <> DatabaseManagerService.DatabaseName Then
'                                          Log($"⚠ Nhập đúng tên database '{DatabaseManagerService.DatabaseName}' để xác nhận.", C_WARN)
'                                          txtConfirm.BackColor = Color.FromArgb(60, 239, 68, 68)
'                                          Return
'                                      End If
'                                      txtConfirm.BackColor = C_SURFACE
'                                      If Confirm($"XÓA TOÀN BỘ database '{DatabaseManagerService.DatabaseName}'?{vbCrLf}Hành động này KHÔNG thể hoàn tác!",
'                                                 MessageBoxIcon.Warning) Then
'                                          RunOp(Sub() DatabaseManagerService.DropDatabase(txtConn.Text))
'                                          txtConfirm.Clear()
'                                      End If
'                                  End Sub

'        pnlDrop.Controls.AddRange({lblConfirm, txtConfirm, btnDrop})
'        parent.Controls.Add(pnlDrop)
'    End Sub
'#End Region

'#Region "Nav"
'    Private Sub Form_Load(sender As Object, e As EventArgs)
'        SelectNav(btnNavInfo)
'    End Sub

'    Private Sub NavButton_Click(sender As Object, e As EventArgs)
'        SelectNav(CType(sender, Button))
'    End Sub

'    Private Sub SelectNav(btn As Button)
'        If _currentNav IsNot Nothing Then
'            _currentNav.BackColor = Color.Transparent
'            _currentNav.ForeColor = C_MUTED
'            _currentNav.Font = New Font("Segoe UI", 9)
'        End If
'        btn.BackColor = Color.FromArgb(20, 56, 189, 248)
'        btn.ForeColor = If(btn Is btnNavDrop, C_DANGER, C_ACCENT)
'        btn.Font = New Font("Segoe UI", 9, FontStyle.Bold)
'        _currentNav = btn

'        pnlInfo.Visible = btn Is btnNavInfo
'        pnlCreate.Visible = btn Is btnNavCreate
'        pnlLoad.Visible = btn Is btnNavLoad
'        pnlBackup.Visible = btn Is btnNavBackup
'        pnlDrop.Visible = btn Is btnNavDrop

'        If btn Is btnNavInfo Then LoadDbInfo()
'    End Sub

'    Private Sub LoadDbInfo()
'        pnlInfo.Controls.Clear()
'        Dim info = DatabaseManagerService.GetDatabaseInfo(txtConn.Text)

'        lblInfoTitle = New Label With {
'            .Text = "Thông tin database",
'            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
'            .ForeColor = C_TEXT,
'            .AutoSize = True,
'            .Location = New Point(20, 16)
'        }
'        pnlInfo.Controls.Add(lblInfoTitle)

'        Dim y = 48
'        For Each kv In info
'            Dim isError = kv.Key = "Lỗi" OrElse kv.Key = "Trạng thái" AndAlso kv.Value = "Mất kết nối"
'            Dim rowPanel As New Panel With {
'                .Location = New Point(20, y),
'                .Size = New Size(520, 32),
'                .BackColor = C_SURFACE
'            }
'            Dim lblKey As New Label With {
'                .Text = kv.Key,
'                .Font = New Font("Segoe UI", 8.5F),
'                .ForeColor = C_MUTED,
'                .Size = New Size(140, 32),
'                .Location = New Point(12, 0),
'                .TextAlign = ContentAlignment.MiddleLeft
'            }
'            Dim lblVal As New Label With {
'                .Text = kv.Value,
'                .Font = New Font("Consolas", 8.5F),
'                .ForeColor = If(isError, C_DANGER, C_TEXT),
'                .AutoSize = True,
'                .Location = New Point(155, 8)
'            }
'            rowPanel.Controls.AddRange({lblKey, lblVal})
'            pnlInfo.Controls.Add(rowPanel)
'            y += 36
'        Next
'    End Sub
'#End Region

'#Region "Button handlers"
'    Private Sub BtnTestConn_Click(sender As Object, e As EventArgs)
'        Dim result = DatabaseManagerService.TestConnection(txtConn.Text)
'        SetConnectionStatus(result.IsSuccess)
'        Log(If(result.IsSuccess, "✓ " & result.Message & If(result.Detail <> "", " | " & result.Detail, ""),
'                                 "✕ " & result.Message),
'            If(result.IsSuccess, C_SUCCESS, C_DANGER))
'    End Sub

'    Private Sub BtnApplyConn_Click(sender As Object, e As EventArgs)
'        RunOp(Sub() DatabaseManagerService.ApplyNewConnection(txtConn.Text))
'    End Sub

'    Private Sub SetConnectionStatus(ok As Boolean)
'        lblStatusDot.BackColor = If(ok, C_SUCCESS, C_DANGER)
'        lblStatus.Text = If(ok, "Kết nối OK", "Mất kết nối")
'        lblStatus.ForeColor = If(ok, C_SUCCESS, C_DANGER)
'    End Sub
'#End Region

'#Region "Helpers"
'    Private Sub RunOp(op As Func(Of DbOperationResult))
'        Me.Cursor = Cursors.WaitCursor
'        Try
'            Dim result = op()
'            Log(If(result.IsSuccess, "✓ " & result.Message, "✕ " & result.Message),
'                If(result.IsSuccess, C_SUCCESS, C_DANGER))
'            If result.IsSuccess AndAlso Not String.IsNullOrWhiteSpace(result.Detail) Then
'                Log("  → " & result.Detail, C_MUTED)
'            End If
'            If result.IsSuccess AndAlso (_currentNav Is btnNavInfo) Then LoadDbInfo()
'        Catch ex As Exception
'            Log("✕ Lỗi không xác định: " & ex.Message, C_DANGER)
'        Finally
'            Me.Cursor = Cursors.Default
'        End Try
'    End Sub

'    Private Sub Log(msg As String, Optional clr As Color = Nothing)
'        Dim entry = $"[{DateTime.Now:HH:mm:ss}]  {msg}"
'        lstLog.Items.Add(entry)
'        lstLog.TopIndex = lstLog.Items.Count - 1
'    End Sub



'#End Region

'End Class