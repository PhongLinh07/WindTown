Imports Microsoft.VisualBasic

Public Class frmDashboard

    Private ReadOnly _dashboardService As New DashboardService()
    Private ReadOnly _employeeService As New EmployeeService()
    Private menuCaiDat As ContextMenuStrip
    Private _btnRefresh As Button
    Private _lblLoading As Label
    Private _isLoading As Boolean

    Private Async Sub load_form(sender As Object, e As EventArgs) Handles MyBase.Load
        InitSettingMenu()
        InitDashboardActions()
        InitListViews()

        dtpkThongKe.Value = DateTime.Today
        Await LoadDashboardDataAsync()
    End Sub

    Private Sub InitSettingMenu()
        menuCaiDat = New ContextMenuStrip()
        menuCaiDat.Items.Add("Dang xuat", Nothing, AddressOf XuLy_DangXuat)
    End Sub

    Private Sub InitDashboardActions()
        dtpkThongKe.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        _btnRefresh = New Button With {
            .Name = "btnRefresh",
            .Text = "Refresh",
            .Size = New Size(80, 27),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        AddHandler _btnRefresh.Click, AddressOf btnRefresh_Click

        _lblLoading = New Label With {
            .Name = "lblLoading",
            .Text = "Dang tai...",
            .AutoSize = True,
            .Visible = False,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }

        Panel6.Controls.Add(_btnRefresh)
        Panel6.Controls.Add(_lblLoading)
        AddHandler Panel6.Resize, AddressOf Panel6_Resize

        LayoutDashboardActions()
    End Sub

    Private Sub LayoutDashboardActions()
        dtpkThongKe.Left = Math.Max(0, Panel6.Width - dtpkThongKe.Width - 8)
        _btnRefresh.Left = Math.Max(0, dtpkThongKe.Left - _btnRefresh.Width - 8)
        _lblLoading.Left = Math.Max(0, _btnRefresh.Left - _lblLoading.Width - 8)

        dtpkThongKe.Top = 9
        _btnRefresh.Top = 9
        _lblLoading.Top = 12
    End Sub

    Private Sub Panel6_Resize(sender As Object, e As EventArgs)
        LayoutDashboardActions()
    End Sub

    Private Sub InitListViews()

        lvTopCheckinSom.View = View.Details
        lvTopCheckinSom.FullRowSelect = True
        lvTopCheckinSom.GridLines = True
        lvTopCheckinSom.Columns.Clear()
        lvTopCheckinSom.Columns.Add("Nhan vien", 320)
        lvTopCheckinSom.Columns.Add("So ngay dung gio", 220)

        lvTopCheckinMuon.View = View.Details
        lvTopCheckinMuon.FullRowSelect = True
        lvTopCheckinMuon.GridLines = True
        lvTopCheckinMuon.Columns.Clear()
        lvTopCheckinMuon.Columns.Add("Nhan vien", 250)
        lvTopCheckinMuon.Columns.Add("Tong gio di muon", 180)

        'Label10.Text = "Top dung gio trong thang"
        'Label12.Text = "Di muon 7 ngay gan nhat"
        'txDenMuon.Text = "Di muon (7 ngay)"

    End Sub

    Private Async Function LoadDashboardDataAsync() As Task

        If _isLoading Then Return

        _isLoading = True
        SetLoadingState(True)

        Try
            Dim selectedDate = dtpkThongKe.Value.Date
            Dim summary = Await Task.Run(Function() _dashboardService.BuildSummary(selectedDate))
            BindSummary(summary)
        Catch ex As Exception
            MessageBox.Show("Khong tai duoc du lieu dashboard: " & ex.Message, "Loi")
        Finally
            SetLoadingState(False)
            _isLoading = False
        End Try

    End Function

    Private Sub SetLoadingState(isLoading As Boolean)
        _lblLoading.Visible = isLoading
        _btnRefresh.Enabled = Not isLoading
        dtpkThongKe.Enabled = Not isLoading
        Cursor = If(isLoading, Cursors.WaitCursor, Cursors.Default)
    End Sub

    Private Sub BindSummary(summary As DashboardSummaryDto)

        txtTongNV.Text = summary.TotalEmployees.ToString()
        txtDangLV.Text = summary.ActiveEmployees.ToString()
        txtDaNghiViec.Text = summary.InactiveEmployees.ToString()
        txtSoBoPhan.Text = summary.TotalDepartments.ToString()

        txtDungGio.Text = summary.OnTimeTodayCount.ToString()
        txtChuaCheckin.Text = summary.MissingCheckInTodayCount.ToString()
        Label15.Text = summary.LateInWeekCount.ToString()

        lvTopCheckinSom.Items.Clear()
        For Each item In summary.TopOnTimeInMonth
            Dim name = If(String.IsNullOrWhiteSpace(item.EmployeeName), "---", item.EmployeeName)
            Dim row As New ListViewItem(name)
            row.SubItems.Add(item.MetricValue.ToString("0"))
            lvTopCheckinSom.Items.Add(row)
        Next

        lvTopCheckinMuon.Items.Clear()
        For Each item In summary.TopLateInWeek
            Dim name = If(String.IsNullOrWhiteSpace(item.EmployeeName), "---", item.EmployeeName)
            Dim row As New ListViewItem(name)
            row.SubItems.Add(item.MetricValue.ToString("0.##"))
            lvTopCheckinMuon.Items.Add(row)
        Next

        AdjustColumnWidth()

    End Sub

    Private Sub XuLy_DangXuat(sender As Object, e As EventArgs)

        Dim rs = MessageBox.Show("Ban co chac muon dang xuat?", "Xac nhan", MessageBoxButtons.YesNo)

        If rs = DialogResult.Yes Then
            NavigationService.LogoutToLogin()
        End If

    End Sub

    Private Sub AdjustColumnWidth()

        AutoResizeListViewColumns(lvTopCheckinSom)
        AutoResizeListViewColumns(lvTopCheckinMuon)

    End Sub

    Private Sub AutoResizeListViewColumns(listView As ListView)

        If listView.Columns.Count = 0 Then Return

        Dim colWidth As Integer = Math.Max(100, listView.ClientSize.Width \ listView.Columns.Count)
        For Each col As ColumnHeader In listView.Columns
            col.Width = colWidth
        Next

    End Sub

    Private Sub frmDashboard_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AdjustColumnWidth()
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        menuCaiDat.Show(btnSetting, 0, btnSetting.Height)
    End Sub

    Private Async Sub dtpkThongKe_ValueChanged(sender As Object, e As EventArgs) Handles dtpkThongKe.ValueChanged
        Await LoadDashboardDataAsync()
    End Sub

    Private Async Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Await LoadDashboardDataAsync()
    End Sub

    Private Async Sub btnThemNV_Click(sender As Object, e As EventArgs) Handles btnThemNV.Click
        Dim newEmployee As New Employee()
        Using detailForm As New Employee_CRUD_Frm(newEmployee, True)
            If detailForm.ShowDialog() <> DialogResult.OK Then Return
        End Using

        Dim response = _employeeService.Execute(DataIntent.Insert, newEmployee)
        If response Is Nothing OrElse Not response.IsSuccess Then
            MessageBox.Show("Them nhan vien khong thanh cong: " & If(response?.Message, "Loi khong xac dinh."), "Loi")
            Return
        End If

        MessageBox.Show("Da them nhan vien moi.", "Thong bao")
        Await LoadDashboardDataAsync()
    End Sub

    Private Sub btnMoiNV_Click(sender As Object, e As EventArgs) Handles btnMoiNV.Click
        Dim email = Interaction.InputBox("Nhap email nhan vien can moi:", "Moi nhan vien", "")
        If String.IsNullOrWhiteSpace(email) Then Return

        email = email.Trim()
        If Not IsValidEmail(email) Then
            MessageBox.Show("Email khong hop le.", "Thong bao")
            Return
        End If

        MessageBox.Show("Da moi nhan vien: " & email, "Thong bao")
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim mailAddress = New System.Net.Mail.MailAddress(email)
            Return True
        Catch
            Return False
        End Try
    End Function

End Class


