Public Class SidebarMenu

    ' Panel chính (sidebar)
    Dim pnl As New Panel With {
        .Dock = DockStyle.Left,
        .Width = 260,
        .BackColor = Color.FromArgb(255, 165, 0)
    }

    ' Panel con (menu quản lý nhân sự)
    Dim pnlQLNS As New Panel With {
        .Dock = DockStyle.Top,
        .Height = 0,
        .BackColor = Color.FromArgb(255, 165, 0),
        .Visible = False
    }

    ' Các nút
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

    Dim btnChucVu As New Button With {
        .Text = "  Chức vụ",
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

    Dim btnHopDong As New Button With {
        .Text = "  Hợp đồng",
        .Font = New Font("Microsoft YaHei UI", 12, FontStyle.Bold),
        .TextAlign = ContentAlignment.MiddleLeft,
        .Dock = DockStyle.Top,
        .Height = 35,
        .FlatStyle = FlatStyle.Flat,
        .ForeColor = Color.White
    }

    Public Sub New()
        InitializeComponent()

        ' Thêm nút con vào panel QLNS
        pnlQLNS.Controls.Add(btnNhanSu)
        pnlQLNS.Controls.Add(btnChucVu)

        ' Thêm các nút vào sidebar
        pnl.Controls.Add(btnHopDong)
        pnl.Controls.Add(pnlQLNS)
        pnl.Controls.Add(btnQLNS)
        pnl.Controls.Add(btnDashboard)

        Me.Controls.Add(pnl)

        ' Gắn sự kiện click
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click
        AddHandler btnQLNS.Click, AddressOf btnQLNS_Click
        AddHandler btnNhanSu.Click, AddressOf btnNhanSu_Click
        AddHandler btnChucVu.Click, AddressOf btnChucVu_Click
        AddHandler btnHopDong.Click, AddressOf btnHopDong_Click
    End Sub

    ' Mở Dashboard
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        Dim currentForm As Form = Me.FindForm()

        If TypeOf currentForm Is frmDashboard Then Return

        Dim f = Application.OpenForms.OfType(Of frmDashboard)().FirstOrDefault()

        If f Is Nothing Then
            f = New frmDashboard()
            f.Show()
        Else
            f.BringToFront()
            f.Show()
        End If

        currentForm.Hide() ' chỉ ẩn, không đóng
    End Sub

    ' Toggle panel QLNS
    Private Sub btnQLNS_Click(sender As Object, e As EventArgs)
        If pnlQLNS.Height = 0 Then
            pnlQLNS.Height = btnChucVu.Height + btnNhanSu.Height
            pnlQLNS.Visible = True
        Else
            pnlQLNS.Height = 0
            pnlQLNS.Visible = False
        End If
    End Sub

    ' Mở Nhân sự
    Private Sub btnNhanSu_Click(sender As Object, e As EventArgs)
        Dim currentForm As Form = Me.FindForm()

        If TypeOf currentForm Is frmNhanSu Then Return

        Dim f = Application.OpenForms.OfType(Of frmNhanSu)().FirstOrDefault()

        If f Is Nothing Then
            f = New frmNhanSu()
            f.Show()
        Else
            f.BringToFront()
            f.Show()
        End If

        currentForm.Hide() ' chỉ ẩn
    End Sub

    ' Mở Chức vụ
    Private Sub btnChucVu_Click(sender As Object, e As EventArgs)
        Dim currentForm As Form = Me.FindForm()

        If TypeOf currentForm Is frmChucVu Then Return

        Dim f = Application.OpenForms.OfType(Of frmChucVu)().FirstOrDefault()

        If f Is Nothing Then
            f = New frmChucVu()
            f.Show()
        Else
            f.BringToFront()
            f.Show()
        End If

        currentForm.Hide() ' chỉ ẩn
    End Sub

    ' Mở Hợp đồng
    Private Sub btnHopDong_Click(sender As Object, e As EventArgs)
        Dim currentForm As Form = Me.FindForm()
        If TypeOf currentForm Is frmHopDong Then Return
        Dim f = Application.OpenForms.OfType(Of frmHopDong)().FirstOrDefault()
        If f Is Nothing Then
            f = New frmHopDong()
            f.Show()
        Else
            f.BringToFront()
            f.Show()
        End If
        currentForm.Hide() ' chỉ ẩn
    End Sub
End Class