Module NavigationService
    Public MainPanel As Panel

    Public Sub LoadForm(f As Form)

        If MainPanel Is Nothing Then Return

        MainPanel.Controls.Clear()

        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill

        MainPanel.Controls.Add(f)

        f.Show()

    End Sub
End Module
