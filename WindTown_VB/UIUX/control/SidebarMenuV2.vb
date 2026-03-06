Public Class SidebarMenuV2
    'tlpnlMenu As TableLayoutPanel
    'pnlMenuHeader As Panel
    'pctbLogo As PictureBox
    'btnToggle As Button
    'flpnlMenu

    '==============================
    ' Event gửi ra ngoài khi chọn menu
    '==============================
    Public Event MenuSelected(menuName As String)

    '==============================
    ' Button đang active
    '==============================
    Private activeButton As Button = Nothing

    '==============================
    ' Panel chứa submenu nhân sự
    '==============================
    Private pnlSubQLNS As Panel

    '==============================
    ' Kích thước sidebar
    '==============================
    Private originalSidebarWidth As Integer
    Private collapsedWidth As Integer

    '==============================
    ' Trạng thái sidebar
    '==============================
    Private isCollapsed As Boolean = False

    ' ==============================
    ' Timer cho animation (nếu muốn)
    '===============================
    Private sidebarTimer As New Timer()
    Private animationSpeed As Integer = 20

    '==============================
    ' Load control
    '==============================
    Private Sub SidebarMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Lấy kích thước sidebar
        InitSidebarSize()

        ' Tạo menu
        CreateMenu()

    End Sub


    '==============================
    ' Lấy kích thước sidebar ban đầu
    '==============================
    Private Sub InitSidebarSize()

        Dim parentTable = TryCast(Me.Parent, TableLayoutPanel)

        If parentTable Is Nothing Then Return

        If parentTable.ColumnStyles.Count = 0 Then Return

        originalSidebarWidth = parentTable.ColumnStyles(0).Width

        collapsedWidth = 60

        pnlHeader.Height = 50
        btnToggle.Width = 40
        btnToggle.Height = 40
        btnToggle.Location = New Point(10, 5)

        sidebarTimer.Interval = 10
        AddHandler sidebarTimer.Tick, AddressOf AnimateSidebar

    End Sub

    Private Sub AnimateSidebar()

        Dim parentTable = TryCast(Me.Parent, TableLayoutPanel)
        If parentTable Is Nothing Then Return

        Dim currentWidth = parentTable.ColumnStyles(0).Width

        If isCollapsed Then

            If currentWidth < originalSidebarWidth Then
                parentTable.ColumnStyles(0).Width += animationSpeed
            Else
                sidebarTimer.Stop()
            End If

        Else

            If currentWidth > collapsedWidth Then
                parentTable.ColumnStyles(0).Width -= animationSpeed
            Else
                sidebarTimer.Stop()
            End If

        End If

    End Sub

    '==============================
    ' Tạo menu
    '==============================
    Private Sub CreateMenu()

        flpnlMenu.Controls.Clear()

        CreateButton("Dashboard")

        CreateButton("Quản lý nhân sự")

        CreateSubMenu()

        CreateButton("Hợp đồng")

        CreateButton("Lương")

    End Sub


    '==============================
    ' Tạo button menu chính
    '==============================
    Private Function CreateButton(text As String) As Button

        Dim btn As New Button With {
            .Text = text,
            .Height = 45,
            .Width = flpnlMenu.Width,
            .FlatStyle = FlatStyle.Flat,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(255, 165, 0),
            .Margin = New Padding(0)
        }

        btn.FlatAppearance.BorderSize = 0

        AddHandler btn.Click, AddressOf MenuButton_Click

        flpnlMenu.Controls.Add(btn)

        Return btn

    End Function


    '==============================
    ' Tạo submenu
    '==============================
    Private Sub CreateSubMenu()

        pnlSubQLNS = New Panel With {
            .Width = flpnlMenu.Width,
            .Height = 0,
            .Visible = False
        }

        Dim btnNhanSu = CreateSubButton("Nhân sự")
        Dim btnChucVu = CreateSubButton("Chức vụ")

        pnlSubQLNS.Controls.Add(btnChucVu)
        pnlSubQLNS.Controls.Add(btnNhanSu)

        flpnlMenu.Controls.Add(pnlSubQLNS)

    End Sub


    '==============================
    ' Tạo button submenu
    '==============================
    Private Function CreateSubButton(text As String) As Button

        Dim btn As New Button With {
            .Text = "   " & text,
            .Height = 40,
            .Width = flpnlMenu.Width,
            .FlatStyle = FlatStyle.Flat,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.White,
            .BackColor = Color.DarkOrange,
            .Dock = DockStyle.Top
        }

        btn.FlatAppearance.BorderSize = 0

        AddHandler btn.Click, AddressOf MenuButton_Click

        Return btn

    End Function


    '==============================
    ' Xử lý click menu
    '==============================
    Private Sub MenuButton_Click(sender As Object, e As EventArgs)

        Dim btn As Button = CType(sender, Button)

        ' Highlight button
        HighlightButton(btn)

        ' Nếu là menu nhân sự -> mở submenu
        If btn.Text.Contains("Quản lý nhân sự") Then

            ToggleSubMenu()

            Return

        End If

        ' Gửi sự kiện ra ngoài
        RaiseEvent MenuSelected(btn.Text.Trim())

    End Sub


    '==============================
    ' Highlight button active
    '==============================
    Private Sub HighlightButton(btn As Button)

        If activeButton IsNot Nothing Then
            activeButton.BackColor = Color.FromArgb(255, 165, 0)
        End If

        btn.BackColor = Color.OrangeRed

        activeButton = btn

    End Sub


    '==============================
    ' Mở / đóng submenu
    '==============================
    Private Sub ToggleSubMenu()

        If pnlSubQLNS.Visible Then

            pnlSubQLNS.Visible = False
            pnlSubQLNS.Height = 0

        Else

            pnlSubQLNS.Visible = True

            ' Tính height dựa trên số button
            Dim h As Integer = 0

            For Each ctrl As Control In pnlSubQLNS.Controls
                h += ctrl.Height
            Next

            pnlSubQLNS.Height = h

        End If

    End Sub


    '==============================
    ' Click nút Toggle Sidebar
    '==============================
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click

        ToggleSidebar()

    End Sub


    '==============================
    ' Thu / mở sidebar
    '==============================
    Private Sub ToggleSidebar()

        Dim parentTable = TryCast(Me.Parent, TableLayoutPanel)

        If parentTable Is Nothing Then Exit Sub

        If isCollapsed Then

            ' ===== MỞ SIDEBAR =====
            parentTable.ColumnStyles(0).Width = originalSidebarWidth

            flpnlMenu.Visible = True
            pctbLogo.Visible = True

        Else

            ' ===== THU SIDEBAR =====
            parentTable.ColumnStyles(0).Width = collapsedWidth

            flpnlMenu.Visible = False
            pctbLogo.Visible = False

        End If

        parentTable.PerformLayout()

        isCollapsed = Not isCollapsed

    End Sub
End Class
