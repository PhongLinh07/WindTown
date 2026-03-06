Public Class frmChamCong
    Private originalSidebarWidth As Integer
    Private collapsedWidth As Integer = 60
    Private isSidebarCollapsed As Boolean = False

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpMain.ColumnCount = 2

        tlpMain.ColumnStyles.Clear()

        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 260))
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        NavigationService.MainPanel = pnlMain

    End Sub


    Private Sub SidebarMenu1_MenuSelected(menuName As String)


        Select Case menuName

            Case "Dashboard"
                NavigationService.LoadForm(New frmDashboard)

            Case "Nhân sự"
                NavigationService.LoadForm(New frmNhanSu)

            Case "Chức vụ"
                NavigationService.LoadForm(New frmChucVu)

            Case "Hợp đồng"
                NavigationService.LoadForm(New frmHopDong)

        End Select

    End Sub
End Class