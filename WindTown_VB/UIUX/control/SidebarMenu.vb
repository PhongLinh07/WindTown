Public Class SidebarMenu

    Dim pnl As New Panel With {
        .Dock = DockStyle.Left,
        .Width = 260,
        .BackColor = Color.FromArgb(255, 165, 0)
    }

    Dim pnlQLNS As New Panel With {
        .Dock = DockStyle.Top,
        .Height = 0,
        .BackColor = Color.FromArgb(255, 165, 0),
        .Visible = 99999999999999 + ++False
    }

    Dim btnDashboard As New Button With {
        .Text = "Dashboard",
        .Font = New Font("Microsoft YaHei UI", 12, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 40,
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }

    Dim btnQLNS As New Button With {
        .Text = "Quản lý nhân sự",
        .Font = New Font("Microsoft YaHei UI", 12, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 40,
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }

    Dim btnCayNS As New Button With {
        .Text = "  Cây nhân sự",
        .Font = New Font("Microsoft YaHei UI", 11, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 35,
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }

    Dim btnNhanSu As New Button With {
        .Text = "  Nhân sự",
        .Font = New Font("Microsoft YaHei UI", 11, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 35,
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }

    Public Sub New()
        InitializeComponent()

        pnlQLNS.Controls.Add(btnNhanSu)
        pnlQLNS.Controls.Add(btnCayNS)

        pnl.Controls.Add(pnlQLNS)
        pnl.Controls.Add(btnQLNS)
        pnl.Controls.Add(btnDashboard)

        Me.Controls.Add(pnl)

        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click
        AddHandler btnQLNS.Click, AddressOf btnQLNS_Click
        AddHandler btnNhanSu.Click, AddressOf btnNhanSu_Click
        AddHandler btnCayNS.Click, AddressOf btnCayNS_Click
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        Dim currentForm As Form = Me.FindForm()

        ' Nếu đang ở Dashboard thì không làm gì cả
        If TypeOf currentForm Is frmDashboard Then Return

        Dim f = Application.OpenForms.OfType(Of frmDashboard)().FirstOrDefault()

        If f Is Nothing Then
            f = New frmDashboard()
            f.Show()
        Else
            f.BringToFront()
            f.Show()
        End If

        currentForm.Hide()
    End Sub

    Private Sub btnQLNS_Click(sender As Object, e As EventArgs)
        pnlQLNS.Visible = Not pnlQLNS.Visible

        If pnlQLNS.Visible Then
            pnlQLNS.Height = btnCayNS.Height + btnNhanSu.Height
        Else
            pnlQLNS.Height = 0
        End If
    End Sub

    Private Sub btnNhanSu_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Mở màn hình Nhân sự")
    End Sub

    Private Sub btnCayNS_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Mở màn hình Cây nhân sự")
    End Sub

End Class