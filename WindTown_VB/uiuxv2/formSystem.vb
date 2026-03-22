Imports Microsoft.Data.SqlClient

Public Class formSystem

    Private Sub formSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboTheme.SelectedIndex = 0
        cboAccent.SelectedIndex = 0
        cboFontSize.SelectedIndex = 1

        LoadConnectionFieldsFromRuntime()
        LoadMockRoles()
    End Sub

    Private Sub LoadConnectionFieldsFromRuntime()
        Dim cs = DatabaseConfig.Database.ConnectionString
        Try
            Dim b As New SqlConnectionStringBuilder(cs)
            txtDbHost.Text = b.DataSource
            txtDbName.Text = If(String.IsNullOrWhiteSpace(b.InitialCatalog),
                                ConnectionSettingsStore.RecommendedCatalog,
                                b.InitialCatalog)
            If b.IntegratedSecurity Then
                txtDbUser.Text = ""
                txtDbPass.Text = ""
            Else
                txtDbUser.Text = b.UserID
                txtDbPass.Text = b.Password
            End If
            txtDbPort.Text = "1433"
            If b.ConnectTimeout > 0 Then
                txtDbTimeout.Text = b.ConnectTimeout.ToString()
            Else
                txtDbTimeout.Text = "30"
            End If
        Catch
            txtDbHost.Text = "."
            txtDbName.Text = ConnectionSettingsStore.RecommendedCatalog
            txtDbUser.Text = ""
            txtDbPass.Text = ""
            txtDbPort.Text = "1433"
            txtDbTimeout.Text = "30"
        End Try
    End Sub

    Private Function BuildConnectionStringFromUi() As String
        Dim host = txtDbHost.Text.Trim()
        If String.IsNullOrWhiteSpace(host) Then host = "."

        Dim portTxt = txtDbPort.Text.Trim()
        Dim dataSource = host
        If portTxt <> "" AndAlso portTxt <> "1433" AndAlso
           Not host.Contains(","c) AndAlso Not host.Contains("\"c) Then
            dataSource = host & "," & portTxt
        End If

        Dim catalog = txtDbName.Text.Trim()
        If String.IsNullOrWhiteSpace(catalog) Then catalog = ConnectionSettingsStore.RecommendedCatalog

        Dim b As New SqlConnectionStringBuilder With {
            .DataSource = dataSource,
            .InitialCatalog = catalog,
            .TrustServerCertificate = True
        }

        Dim timeout As Integer
        If Integer.TryParse(txtDbTimeout.Text.Trim(), timeout) AndAlso timeout > 0 Then
            b.ConnectTimeout = timeout
        Else
            b.ConnectTimeout = 30
        End If

        If String.IsNullOrWhiteSpace(txtDbUser.Text.Trim()) Then
            b.IntegratedSecurity = True
        Else
            b.IntegratedSecurity = False
            b.UserID = txtDbUser.Text.Trim()
            b.Password = txtDbPass.Text
        End If

        Return b.ConnectionString
    End Function

    Private Sub btnTestConn_Click(sender As Object, e As EventArgs) Handles btnTestConn.Click
        Dim cs = BuildConnectionStringFromUi()
        If modDB.TestConnection(cs) Then
            MessageBox.Show("Kết nối tới SQL Server thành công.", "Cơ sở dữ liệu",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Không kết nối được. Kiểm tra máy chủ, tên CSDL (khuyến nghị: wind_town), cổng và tài khoản.",
                            "Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnSaveDb_Click(sender As Object, e As EventArgs) Handles btnSaveDb.Click
        Dim cs = BuildConnectionStringFromUi()
        If Not modDB.TestConnection(cs) Then
            MessageBox.Show("Chưa lưu: kiểm tra kết nối thất bại. Hãy dùng ""Kiểm tra kết nối"" trước.",
                            "Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        DatabaseConfig.Database.SetConnectionString(cs)
        ConnectionSettingsStore.SaveConnectionString(cs)

        MessageBox.Show(
            "Đã lưu chuỗi kết nối. Lần mở ứng dụng sau sẽ ưu tiên cấu hình này." & vbCrLf &
            "Nếu có lỗi lạ, hãy khởi động lại ứng dụng.",
            "Cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSaveDisplay_Click(sender As Object, e As EventArgs) Handles btnSaveDisplay.Click
        MessageBox.Show("Giao diện: lưu cục bộ (mock). Các tùy chọn theme sẽ được nối My.Settings khi có.",
                        "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAddRole_Click(sender As Object, e As EventArgs) Handles btnAddRole.Click
        MessageBox.Show("Thêm role (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDeleteRole_Click(sender As Object, e As EventArgs) Handles btnDeleteRole.Click
        MessageBox.Show("Xóa role (mock).", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadMockRoles()
        dgvRoles.Rows.Clear()
        dgvRoles.Rows.Add("Admin", "Toàn quyền hệ thống", "*")
        dgvRoles.Rows.Add("HR", "Quản lý nhân sự", "employee, contract, position")
        dgvRoles.Rows.Add("Accountant", "Quản lý lương", "payroll, pay_period")
    End Sub

End Class
