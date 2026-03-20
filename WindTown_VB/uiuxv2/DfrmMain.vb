Imports System.Drawing
Imports System.Drawing.Text

' ============================================================
'  dfrmMain.vb — Shell chính: điều hướng + sidebar animation
' ============================================================
Public Class DfrmMain

    ' ── Sidebar animation state ───────────────────────────────
    Private Const SB_EXPANDED As Integer = 200
    Private Const SB_COLLAPSED As Integer = 52
    Private Const SB_STEP As Integer = 14         ' pixels per tick
    Private _sbTargetW As Integer = SB_EXPANDED
    Private _sbExpanded As Boolean = True

    ' ── Active nav button ─────────────────────────────────────
    Private _activeBtn As Button = Nothing

    ' ── Avatar rounded corner (round lblTopAvatar) ────────────
    Private Sub lblTopAvatar_Paint(sender As Object, e As PaintEventArgs) Handles lblTopAvatar.Paint
        Dim lbl = CType(sender, Label)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Using br = New SolidBrush(Color.FromArgb(59, 125, 216))
            g.FillEllipse(br, 0, 0, lbl.Width - 1, lbl.Height - 1)
        End Using
        Using br = New SolidBrush(Color.White)
            Using f = New Font("Microsoft YaHei UI", 9.5, FontStyle.Bold)
                Dim sz = g.MeasureString(lbl.Text, f)
                g.DrawString(lbl.Text, f, br, (lbl.Width - sz.Width) / 2, (lbl.Height - sz.Height) / 2)
            End Using
        End Using
        'e.Handled = True
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub dfrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cập nhật thông tin người dùng từ session
        lblSbUser.Text = modSession.DisplayName
        lblSbRole.Text = If(modSession.CurrentRole = 1, "Quản trị viên", "Nhân viên")
        lblTopAvatar.Text = If(modSession.DisplayName.Length >= 2,
                               modSession.DisplayName.Substring(0, 2).ToUpper(),
                               "AD")
        lblTopAvatar.Text = "" ' paint event handles it

        ' Ngày hiện tại
        UpdateDateLabel()

        ' Điều hướng mặc định → Dashboard
        SetActiveNav(btnDash, "Dashboard")
        NavigateTo(New DfrmDashBoard())

        ' Responsive: cập nhật vị trí pnlTopRight khi resize
        AddHandler Me.Resize, Sub(s, ev) RepositionTopRight()
        RepositionTopRight()
    End Sub

    Private Sub UpdateDateLabel()
        Dim culture = New System.Globalization.CultureInfo("vi-VN")
        lblPageDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", culture)
    End Sub

    Private Sub RepositionTopRight()
        pnlTopRight.Location = New Point(pnlTopbar.Width - pnlTopRight.Width - 16,
                                         (pnlTopbar.Height - pnlTopRight.Height) \ 2)
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  NAVIGATION
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

    ''' <summary>Nhúng form con vào pnlContent, giải phóng form cũ.</summary>
    Public Sub NavigateTo(frm As Form)
        ' Đóng và xoá child form cũ
        Dim toClose As New List(Of Form)
        For Each ctrl As Control In pnlContent.Controls
            Dim f = TryCast(ctrl, Form)
            If f IsNot Nothing Then toClose.Add(f)
        Next
        For Each f In toClose
            f.Close()
        Next
        pnlContent.Controls.Clear()

        ' Nhúng form mới
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        pnlContent.Controls.Add(frm)
        frm.BringToFront()
        frm.Show()
    End Sub

    ''' <summary>Đặt nút nav active, đổi màu, cập nhật tiêu đề trang.</summary>
    Private Sub SetActiveNav(btn As Button, pageTitle As String)
        ' Reset tất cả nút
        Dim allBtns = {btnDash, btnEmployee, btnContract, btnAttend, btnPayroll,
                       btnProject, btnReport, btnSettings, btnPayPeriod}
        For Each b In allBtns
            b.BackColor = Color.FromArgb(19, 22, 41)
            b.ForeColor = Color.FromArgb(123, 139, 178)
        Next

        ' Active state
        btn.BackColor = Color.FromArgb(25, 35, 62)
        btn.ForeColor = Color.FromArgb(74, 158, 255)
        _activeBtn = btn
        lblPageTitle.Text = pageTitle
    End Sub

    ' ── Nav Button Clicks ─────────────────────────────────────
    Private Sub btnDash_Click(sender As Object, e As EventArgs) Handles btnDash.Click
        SetActiveNav(btnDash, "Dashboard")
        NavigateTo(New DfrmDashBoard())
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        SetActiveNav(btnEmployee, "Nhân viên")
        NavigateTo(New formEmployee())   '← thêm khi có form
        'ShowPlaceholder("Nhân viên")
    End Sub

    Private Sub btnContract_Click(sender As Object, e As EventArgs) Handles btnContract.Click
        SetActiveNav(btnContract, "Hợp đồng")
        NavigateTo(New formContract())
    End Sub
    Private Sub btnAttend_Click(sender As Object, e As EventArgs) Handles btnAttend.Click
        SetActiveNav(btnAttend, "Chấm công")
        ShowPlaceholder("Chấm công")
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        SetActiveNav(btnPayroll, "Lương thưởng")
        NavigateTo(New formPayroll())   '← thêm khi có form 
    End Sub

    Private Sub btnPayPeriod_Click(sender As Object, e As EventArgs) Handles btnPayPeriod.Click
        SetActiveNav(btnPayPeriod, "Kỳ lương")
        NavigateTo(New formPayPeriod())
    End Sub

    Private Sub btnProject_Click(sender As Object, e As EventArgs) Handles btnProject.Click
        SetActiveNav(btnProject, "Chính sách")
        NavigateTo(New formPolicy())
        'ShowPlaceholder("Chính sách")
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        SetActiveNav(btnReport, "Báo cáo")
        ShowPlaceholder("Báo cáo")
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        SetActiveNav(btnSettings, "Cài đặt")
        Dim frm As New frmSystem()
        NavigateTo(frm)
    End Sub

    ''' <summary>Placeholder khi chưa có form tương ứng.</summary>
    Private Sub ShowPlaceholder(name As String)
        Dim pnl As New Panel() With {
            .BackColor = Color.FromArgb(26, 29, 46),
            .Dock = DockStyle.Fill
        }
        Dim lbl As New Label() With {
            .AutoSize = True,
            .Font = New Font("Microsoft YaHei UI", 14, FontStyle.Bold),
            .ForeColor = Color.FromArgb(42, 48, 80),
            .Text = $"[ {name} — Đang phát triển ]"
        }
        pnl.Controls.Add(lbl)
        AddHandler pnl.Resize, Sub(s, ev)
                                   lbl.Location = New Point((pnl.Width - lbl.Width) \ 2, (pnl.Height - lbl.Height) \ 2)
                               End Sub

        Dim toClose As New List(Of Control)(pnlContent.Controls.OfType(Of Control)())
        For Each c In toClose
            Dim f = TryCast(c, Form)
            If f IsNot Nothing Then f.Close()
        Next
        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(pnl)
        pnl.BringToFront()
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  SIDEBAR COLLAPSE / EXPAND ANIMATION
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        _sbExpanded = Not _sbExpanded
        _sbTargetW = If(_sbExpanded, SB_EXPANDED, SB_COLLAPSED)
        tmrSb.Start()
    End Sub

    Private Sub tmrSb_Tick(sender As Object, e As EventArgs) Handles tmrSb.Tick
        Dim current = pnlSidebar.Width
        If current < _sbTargetW Then
            pnlSidebar.Width = Math.Min(current + SB_STEP, _sbTargetW)
        ElseIf current > _sbTargetW Then
            pnlSidebar.Width = Math.Max(current - SB_STEP, _sbTargetW)
        Else
            tmrSb.Stop()
            ApplySidebarState()
        End If
    End Sub

    ''' <summary>Cập nhật giao diện sau khi sidebar đã animation xong.</summary>
    Private Sub ApplySidebarState()
        If _sbExpanded Then
            ' Expanded: hiện text đầy đủ
            btnToggle.Text = "<"
            btnToggle.Location = New Point(166, 18)
            lblBrand.Visible = True
            lblBrandSub.Visible = True
            lblSec1.Visible = True
            lblSec2.Visible = True
            lblSbUser.Visible = True
            lblSbRole.Visible = True

            For Each btn In {btnDash, btnEmployee, btnAttend, btnPayroll,
                              btnProject, btnReport, btnSettings}
                btn.Text = CStr(btn.Tag)
                btn.TextAlign = ContentAlignment.MiddleLeft
                btn.Padding = New Padding(10, 0, 0, 0)
                btn.Size = New Size(200, 42)
            Next
        Else
            ' Collapsed: chỉ hiện icon chữ viết tắt, căn giữa
            btnToggle.Text = ">"
            btnToggle.Location = New Point(14, 18)
            lblBrand.Visible = False
            lblBrandSub.Visible = False
            lblSec1.Visible = False
            lblSec2.Visible = False
            lblSbUser.Visible = False
            lblSbRole.Visible = False

            Dim icons() As String = {"DB", "NV", "PL", "CC", "LT", "TD", "BC", "CD"}
            Dim btns = {btnDash, btnEmployee, btnAttend, btnPayroll,
                        btnProject, btnReport, btnSettings}
            For i = 0 To btns.Length - 1
                btns(i).Text = icons(i)
                btns(i).TextAlign = ContentAlignment.MiddleCenter
                btns(i).Padding = New Padding(0)
                btns(i).Size = New Size(52, 42)
            Next
        End If
    End Sub

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM CLOSING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub dfrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?",
                                     "Xác nhận thoát",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)
        If result = DialogResult.No Then e.Cancel = True
    End Sub


End Class