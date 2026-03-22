Imports System.Drawing
Imports System.Linq

Partial Public Class formPayroll
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  TAB SWITCHING
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub ShowTab(tab As Integer)
        ' ── Fix #3: tắt hết trước, rồi BringToFront panel cần hiện ──
        pnlTab1.Visible = False
        pnlTab2.Visible = False
        pnlTab3.Visible = False

        Select Case tab
            Case 1
                pnlTab1.Visible = True
                pnlTab1.BringToFront()
            Case 2
                pnlTab2.Visible = True
                pnlTab2.BringToFront()
            Case 3
                pnlTab3.Visible = True
                pnlTab3.BringToFront()
        End Select

        Dim clrActive = Color.FromArgb(74, 158, 255)
        Dim clrNormal = Color.FromArgb(123, 139, 178)
        btnTab1.ForeColor = If(tab = 1, clrActive, clrNormal)
        btnTab2.ForeColor = If(tab = 2, clrActive, clrNormal)
        btnTab3.ForeColor = If(tab = 3, clrActive, clrNormal)

        Select Case tab
            Case 1
                pnlTabIndicator.Left = 0
                pnlTabIndicator.Width = 160
            Case 2
                pnlTabIndicator.Left = 160
                pnlTabIndicator.Width = 160
            Case 3
                pnlTabIndicator.Left = 320
                pnlTabIndicator.Width = 200
        End Select
    End Sub

    ' ── Fix #2: mỗi Sub phải xuống dòng trước statement đầu tiên ──
    Private Sub btnTab1_Click(s As Object, e As EventArgs) Handles btnTab1.Click
        ShowTab(1)
    End Sub

    Private Sub btnTab2_Click(s As Object, e As EventArgs) Handles btnTab2.Click
        ShowTab(2)
    End Sub

    Private Sub btnTab3_Click(s As Object, e As EventArgs) Handles btnTab3.Click
        ShowTab(3)
    End Sub
End Class
