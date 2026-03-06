Public Class ucSidebar

    Private menuData As List(Of MenuItemModel)

    Private mainPanel As Panel
    Private activeButton As Button

    Private expandedWidth As Integer
    Private collapsedWidth As Integer = 60
    Private isCollapsed As Boolean = False

    Private parentTable As TableLayoutPanel
    Private columnIndex As Integer = -1

    Private toolTipMenu As New ToolTip


    Public Sub SetMainPanel(panel As Panel)
        mainPanel = panel
    End Sub


    Private Sub ucSidebar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitSidebarLayout()

        InitSidebarSize()

        BuildMenuData()

        BuildMenuUI()

        toolTipMenu.AutoPopDelay = 5000
        toolTipMenu.InitialDelay = 200
        toolTipMenu.ReshowDelay = 100
        toolTipMenu.ShowAlways = True


    End Sub


    '============================
    ' Xác định TableLayoutPanel
    '============================
    Private Sub InitSidebarLayout()

        parentTable = TryCast(Me.Parent, TableLayoutPanel)

        If parentTable Is Nothing Then Exit Sub

        columnIndex = parentTable.GetColumn(Me)

    End Sub


    '============================
    ' Lấy kích thước sidebar
    '============================
    Private Sub InitSidebarSize()

        If parentTable IsNot Nothing AndAlso columnIndex >= 0 Then

            expandedWidth = Me.Width

            parentTable.ColumnStyles(columnIndex).SizeType = SizeType.Absolute
            parentTable.ColumnStyles(columnIndex).Width = expandedWidth

        Else

            expandedWidth = Me.Width

        End If

    End Sub


    '============================
    ' Toggle sidebar
    '============================
    Private Sub ToggleSidebar()

        If parentTable Is Nothing Then Return
        If columnIndex < 0 Then Return

        Dim col = parentTable.ColumnStyles(columnIndex)

        col.SizeType = SizeType.Absolute

        If isCollapsed Then

            '===== MỞ SIDEBAR =====
            col.Width = expandedWidth

            ptbLogo.Visible = True

            For Each ctrl As Control In flpnlMenu.Controls

                If TypeOf ctrl Is Button Then

                    Dim btn As Button = CType(ctrl, Button)

                    btn.Text = btn.Tag?.ToString()

                End If

            Next

        Else

            '===== THU SIDEBAR =====
            col.Width = collapsedWidth

            ptbLogo.Visible = False

            For Each ctrl As Control In flpnlMenu.Controls

                If TypeOf ctrl Is Button Then

                    Dim btn As Button = CType(ctrl, Button)

                    btn.Tag = btn.Text
                    btn.Text = ""

                End If

            Next

        End If

        parentTable.PerformLayout()

        isCollapsed = Not isCollapsed

    End Sub


    '============================
    ' Nút toggle
    '============================
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click

        ToggleSidebar()

    End Sub


    '============================
    ' Khai báo menu
    '============================
    Private Sub BuildMenuData()

        menuData = New List(Of MenuItemModel)

        menuData.Add(New MenuItemModel("Dashboard", GetType(frmDashboard), My.Resources.ErrorImage)) ' icon dashboard

        Dim qlns As New MenuItemModel("Quản lý nhân sự", Nothing, My.Resources.ErrorImage) ' icon nhân sự

        qlns.Children.Add(New MenuItemModel("Nhân sự", GetType(frmNhanSu), My.Resources.user)) ' icon người dùng
        qlns.Children.Add(New MenuItemModel("Chức vụ", GetType(frmChucVu), My.Resources.ErrorImage)) ' icon chức vụ

        menuData.Add(qlns)

        menuData.Add(New MenuItemModel("Hợp đồng", GetType(frmHopDong), My.Resources.ErrorImage)) ' icon hợp đồng
        menuData.Add(New MenuItemModel("Chấm công", GetType(frmChamCong), My.Resources.ErrorImage)) ' icon chấm công

        Dim luong As New MenuItemModel("Lương", Nothing, My.Resources.ErrorImage) ' icon lương

        luong.Children.Add(New MenuItemModel("Kỳ lương", GetType(frmKyLuong), My.Resources.ErrorImage)) ' icon kỳ lương
        luong.Children.Add(New MenuItemModel("Tính lương", GetType(frmTinhLuong), My.Resources.money))

        menuData.Add(luong)

        menuData.Add(New MenuItemModel("Cài đặt", GetType(frmSystem), My.Resources.gear)) ' icon cài đặt

    End Sub


    '============================
    ' Build UI menu
    '============================
    Private Sub BuildMenuUI()

        flpnlMenu.Controls.Clear()

        For Each item In menuData

            Dim btn = CreateButton(item.Title)

            '====== THÊM ICON ======
            btn.Image = item.Icon
            btn.ImageAlign = ContentAlignment.MiddleLeft
            btn.TextImageRelation = TextImageRelation.ImageBeforeText

            flpnlMenu.Controls.Add(btn)

            If item.Children.Count > 0 Then

                Dim subPanel As New Panel

                subPanel.Width = flpnlMenu.Width
                subPanel.Height = 0
                subPanel.Visible = False

                For Each child In item.Children

                    Dim subBtn = CreateSubButton(child.Title)

                    subBtn.Tag = child.FormType

                    '====== ICON SUBMENU ======
                    subBtn.Image = child.Icon
                    subBtn.ImageAlign = ContentAlignment.MiddleLeft
                    subBtn.TextImageRelation = TextImageRelation.ImageBeforeText

                    subPanel.Controls.Add(subBtn)

                Next

                btn.Tag = subPanel

                flpnlMenu.Controls.Add(subPanel)

            Else

                btn.Tag = item.FormType

            End If

        Next

    End Sub


    '============================
    ' Button chính
    '============================
    Private Function CreateButton(text As String) As Button

        Dim btn As New Button

        btn.Text = "   " & text
        btn.Height = 45
        btn.Width = flpnlMenu.Width
        btn.FlatStyle = FlatStyle.Flat
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.ImageAlign = ContentAlignment.MiddleLeft
        btn.TextImageRelation = TextImageRelation.ImageBeforeText

        btn.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btn.ForeColor = Color.White
        btn.BackColor = Color.FromArgb(255, 165, 0)

        btn.FlatAppearance.BorderSize = 0


        AddHandler btn.Click, AddressOf MainButton_Click

        toolTipMenu.SetToolTip(btn, text)

        Return btn

    End Function


    '============================
    ' Button submenu
    '============================
    Private Function CreateSubButton(text As String) As Button

        Dim btn As New Button

        btn.Text = "   " & text
        btn.Height = 40
        btn.Width = flpnlMenu.Width
        btn.FlatStyle = FlatStyle.Flat
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.ForeColor = Color.White
        btn.BackColor = Color.DarkOrange
        btn.Dock = DockStyle.Top

        btn.FlatAppearance.BorderSize = 0

        AddHandler btn.Click, AddressOf SubButton_Click

        Return btn

    End Function


    '============================
    ' Click button chính
    '============================
    Private Sub MainButton_Click(sender As Object, e As EventArgs)

        Dim btn As Button = CType(sender, Button)

        HighlightButton(btn)

        If TypeOf btn.Tag Is Panel Then

            ToggleSubMenu(CType(btn.Tag, Panel))

        ElseIf TypeOf btn.Tag Is Type Then

            OpenForm(CType(btn.Tag, Type))

        End If

    End Sub


    '============================
    ' Click submenu
    '============================
    Private Sub SubButton_Click(sender As Object, e As EventArgs)

        Dim btn As Button = CType(sender, Button)

        HighlightButton(btn)

        If TypeOf btn.Tag Is Type Then

            OpenForm(CType(btn.Tag, Type))

        End If

    End Sub


    '============================
    ' Toggle submenu
    '============================
    Private Sub ToggleSubMenu(panel As Panel)

        If panel.Visible Then

            panel.Visible = False
            panel.Height = 0

        Else

            panel.Visible = True

            Dim h As Integer = 0

            For Each c As Control In panel.Controls
                h += c.Height
            Next

            panel.Height = h

        End If

    End Sub


    '============================
    ' Highlight button
    '============================
    Private Sub HighlightButton(btn As Button)

        If activeButton IsNot Nothing Then

            If activeButton.Height = 45 Then
                activeButton.BackColor = Color.FromArgb(255, 165, 0)
            Else
                activeButton.BackColor = Color.DarkOrange
            End If

        End If

        btn.BackColor = Color.OrangeRed

        activeButton = btn

    End Sub


    '============================
    ' Mở form
    '============================
    Private Sub OpenForm(type As Type)

        If mainPanel Is Nothing Then Return

        mainPanel.Controls.Clear()

        Dim frm As Form = CType(Activator.CreateInstance(type), Form)

        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        mainPanel.Controls.Add(frm)

        frm.Show()

    End Sub

End Class