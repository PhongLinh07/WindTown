Imports System.Linq

Partial Public Class formPolicy
    Private Sub ShowTab(tab As Integer)
        _currentTab = tab
        pnlTab1.Visible = (tab = 1)
        pnlTab2.Visible = (tab = 2)
        pnlTab3.Visible = (tab = 3)

        Dim clrActive = System.Drawing.Color.FromArgb(74, 158, 255)
        Dim clrNormal = System.Drawing.Color.FromArgb(123, 139, 178)

        btnTab1.ForeColor = If(tab = 1, clrActive, clrNormal)
        btnTab2.ForeColor = If(tab = 2, clrActive, clrNormal)
        btnTab3.ForeColor = If(tab = 3, clrActive, clrNormal)

        Select Case tab
            Case 1 : pnlTabIndicator.Left = 0 : pnlTabIndicator.Width = 160
            Case 2 : pnlTabIndicator.Left = 160 : pnlTabIndicator.Width = 180
            Case 3 : pnlTabIndicator.Left = 340 : pnlTabIndicator.Width = 200
        End Select
    End Sub

    Private Sub btnTab1_Click(sender As Object, e As EventArgs) Handles btnTab1.Click
        ShowTab(1)
    End Sub

    Private Sub btnTab2_Click(sender As Object, e As EventArgs) Handles btnTab2.Click
        ShowTab(2)
    End Sub

    Private Sub btnTab3_Click(sender As Object, e As EventArgs) Handles btnTab3.Click
        ShowTab(3)
    End Sub
End Class
