Public Class frmRegister
    Private account As New List(Of Account)
    Private employee As New List(Of Employee)

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadAccount()
        loadEmployeeWithoutAccount()
    End Sub

    Private Sub loadAccount()
        Dim result = AppServices.Instance.AccountSV.GetList()

        If result.IsSuccess Then
            account = CType(result.Data, List(Of Account))
        End If
    End Sub

    Private Sub loadEmployeeWithoutAccount()

        Dim resultEmployee = AppServices.Instance.EmployeeSV.GetWithoutAccount()

        If resultEmployee.IsSuccess Then
            employee = CType(resultEmployee.Data, List(Of Employee))
        End If

        cbxEmployeeId.DataSource = employee.
            Select(Function(x) New With {
                .Display = x.code & " - " & x.name,
                .Value = x.id
            }).ToList()

        cbxEmployeeId.DisplayMember = "Display"
        cbxEmployeeId.ValueMember = "Value"
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ErrorProvider1.Clear()

        Dim username As String = tbxUsername.Text.Trim()
        Dim id As Integer = CInt(cbxEmployeeId.SelectedValue)
        Dim password As String = tbxPassword.Text.Trim()
        Dim confirmPassword As String = tbxAcceptPassword.Text.Trim()

        Dim isValid As Boolean = True

        If username = "" Then
            ErrorProvider1.SetError(tbxUsername, "Vui lòng nhập tên đăng nhập")
            isValid = False
        End If

        If id < 1 Then
            ErrorProvider1.SetError(cbxEmployeeId, "Vui lòng chọn nhân viên")
            isValid = False
        End If

        If password = "" Then
            ErrorProvider1.SetError(tbxPassword, "Vui lòng nhập mật khẩu")
            isValid = False
        End If

        If confirmPassword = "" Then
            ErrorProvider1.SetError(tbxAcceptPassword, "Vui lòng xác nhận mật khẩu")
            isValid = False
        End If

        If password <> "" AndAlso confirmPassword <> "" AndAlso password <> confirmPassword Then
            ErrorProvider1.SetError(tbxAcceptPassword, "mật khẩu xác nhận khong khop")
            isValid = False
        End If

        If Not isValid Then Return

        If checkRegister(username, password) Then
            Dim newAccount As New Account()
            newAccount.user = username
            newAccount.Employee = employee.FirstOrDefault(Function(emp) emp.id = id)
            newAccount.password = password
            newAccount.role = 2
            newAccount.status = 1

            Dim result = AppServices.Instance.AccountSV.Insert(newAccount)

            If result.IsSuccess Then
                MessageBox.Show("Đăng ký thành công!")
            Else
                MessageBox.Show(result.Message, "Lỗi")
            End If
        Else
            ErrorProvider1.SetError(tbxUsername, "Tên đăng nhập hoặc mật khẩu đã tồn tại")
        End If
    End Sub

    Private Function checkRegister(username As String, password As String) As Boolean
        If account.Any(Function(acc) acc.user = username) Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    End Sub
End Class
