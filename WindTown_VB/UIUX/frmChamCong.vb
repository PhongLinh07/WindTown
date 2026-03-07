Public Class frmChamCong

<<<<<<< HEAD
=======
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'tlpMain.ColumnCount = 2

        'tlpMain.ColumnStyles.Clear()

        'tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 260))
        'tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))

        'NavigationService.MainPanel = pnlMain

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
>>>>>>> b8b1ee3e3c86ee9f34e596c8a2296823ce7993f5
End Class