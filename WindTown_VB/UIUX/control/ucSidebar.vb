Public Class ucSidebar

    Private menuData As List(Of MenuItemModel)

    Private mainPanel As Panel
    Private activeButton As Button

    Private expandedWidth As Integer
    Private collapsedWidth As Integer = 64
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

        designToggleButton(False)

        toolTipMenu.AutoPopDelay = 5000
        toolTipMenu.InitialDelay = 200
        toolTipMenu.ReshowDelay = 100
        toolTipMenu.ShowAlways = True


    End Sub


    '============================
    ' Xác d?nh TableLayoutPanel
    '============================
    Private Sub InitSidebarLayout()

        parentTable = TryCast(Me.Parent, TableLayoutPanel)

        If parentTable Is Nothing Then Exit Sub

        columnIndex = parentTable.GetColumn(Me)

    End Sub


    '============================
    ' L?y kích thu?c sidebar
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

        Dim col As ColumnStyle = Nothing

        If parentTable IsNot Nothing AndAlso columnIndex >= 0 Then
            col = parentTable.ColumnStyles(columnIndex)
            col.SizeType = SizeType.Absolute
        End If

        If isCollapsed Then

            '===== M? SIDEBAR =====
            If col IsNot Nothing Then
                col.Width = expandedWidth
            Else
                Me.Width = expandedWidth
            End If
            ptbLogo.Visible = True
            designToggleButton(False)
            UpdateMenuButtonText(True)

        Else

            '===== THU SIDEBAR =====
            If col IsNot Nothing Then
                col.Width = collapsedWidth
            Else
                Me.Width = collapsedWidth
            End If
            ptbLogo.Visible = False

            designToggleButton(True)
            UpdateMenuButtonText(False)

        End If

        If parentTable IsNot Nothing Then
            parentTable.PerformLayout()
        Else
            Me.PerformLayout()
        End If

        isCollapsed = Not isCollapsed

    End Sub

    Private Sub UpdateMenuButtonText(isExpandedState As Boolean)

        For Each ctrl As Control In flpnlMenu.Controls
            UpdateButtonTextRecursive(ctrl, isExpandedState)
        Next

    End Sub

    Private Sub UpdateButtonTextRecursive(ctrl As Control, isExpandedState As Boolean)

        If TypeOf ctrl Is Button Then

            Dim btn As Button = CType(ctrl, Button)

            If isExpandedState Then
                Dim menuTitle As String = toolTipMenu.GetToolTip(btn)
                btn.Text = If(String.IsNullOrWhiteSpace(menuTitle), btn.Text, "   " & menuTitle)
            Else
                btn.Text = ""
            End If

        End If

        For Each child As Control In ctrl.Controls
            UpdateButtonTextRecursive(child, isExpandedState)
        Next

    End Sub

    '============================
    ' Nút toggle
    '============================
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click

        ToggleSidebar()

    End Sub

    Private Sub designToggleButton(status As Boolean)

        If status = False Then
            btnToggle.Size = New Size(40, 40)
            btnToggle.Text = "<"
            btnToggle.Dock = DockStyle.Right
            btnToggle.FlatStyle = FlatStyle.Flat
            btnToggle.FlatAppearance.BorderSize = 0
            btnToggle.BackColor = Color.White
            btnToggle.ForeColor = Color.Black
            btnToggle.MaximumSize = New Size(40, 40)
            btnToggle.MinimumSize = New Size(40, 40)
        ElseIf status = True Then

            btnToggle.Size = New Size(40, 40)
            btnToggle.Text = ">"
            btnToggle.Dock = DockStyle.None
            btnToggle.Anchor = AnchorStyles.None

            btnToggle.FlatStyle = FlatStyle.Flat
            btnToggle.FlatAppearance.BorderSize = 0
            btnToggle.BackColor = Color.White
            btnToggle.ForeColor = Color.Black

            btnToggle.MaximumSize = New Size(40, 40)
            btnToggle.MinimumSize = New Size(40, 40)

            ' ===== Can gi?a =====
            btnToggle.Left = 4
            btnToggle.Top = 4

        End If
    End Sub


    '============================
    ' Khai báo menu
    '============================
    Private Sub BuildMenuData()

        menuData = New List(Of MenuItemModel)

        menuData.Add(New MenuItemModel("Dashboard", GetType(frmDashboard), ResizeImage(My.Resources.home1, 38, 38))) ' icon dashboard

        Dim qlns As New MenuItemModel("Quản lý nhân sự", Nothing, ResizeImage(My.Resources.saff, 38, 38)) ' icon nhân s?

        qlns.Children.Add(New MenuItemModel("Nhân sự", GetType(frmNhanSu))) ' icon ngu?i dùng
        qlns.Children.Add(New MenuItemModel("Chức vụ", GetType(frmChucVu))) ' icon ch?c v?

        menuData.Add(qlns)

        menuData.Add(New MenuItemModel("Hợp đồng", GetType(frmHopDong), ResizeImage(My.Resources.contract, 38, 38))) ' icon h?p d?ng
        menuData.Add(New MenuItemModel("Chấm công", GetType(frmChamCong), ResizeImage(My.Resources.checkin, 38, 38))) ' icon ch?m công

        Dim luong As New MenuItemModel("Lương", Nothing, ResizeImage(My.Resources.salary, 38, 38)) ' icon luong

        luong.Children.Add(New MenuItemModel("Kỳ lương", GetType(frmKyLuong))) ' icon k? luong
        luong.Children.Add(New MenuItemModel("Tính lương", GetType(frmTinhLuong)))

        menuData.Add(luong)

        menuData.Add(New MenuItemModel("Cài đặt", GetType(frmSystem), ResizeImage(My.Resources.gear, 38, 38))) ' icon cài d?t

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

                For i As Integer = item.Children.Count - 1 To 0 Step -1

                    Dim child = item.Children(i)

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
        toolTipMenu.SetToolTip(btn, text)

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
    ' M? form
    '============================
    Private Sub OpenForm(type As Type)

        If NavigationService.IsInitialized Then
            NavigationService.NavigateInMain(type)
            Return
        End If

        If mainPanel Is Nothing Then Return

        For i As Integer = mainPanel.Controls.Count - 1 To 0 Step -1
            Dim oldCtrl As Control = mainPanel.Controls(i)
            mainPanel.Controls.RemoveAt(i)
            oldCtrl.Dispose()
        Next

        Dim frm As Form = CType(Activator.CreateInstance(type), Form)

        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        mainPanel.Controls.Add(frm)

        frm.Show()

    End Sub

End Class

