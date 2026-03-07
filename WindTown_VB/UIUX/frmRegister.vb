
Public Class frmRegister
    Dim account As List(Of Account) = New List(Of Account)
    Dim employee As List(Of Employee) = New List(Of Employee)

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAccount()
        loadEmployeeWithoutAccount()
    End Sub
    Private Sub loadAccount()
        Dim accountSV = New AccountService()
        Dim result = accountSV.Execute(DataIntent.GetList)

        If result.IsSuccess Then
            account = CType(result.Data, List(Of Account))
        End If
    End Sub
    Private Sub loadEmployeeWithoutAccount()

        Dim employeeSV = New EmployeeService()
        Dim resultEmployee = employeeSV.Execute(DataIntent.GetEmployeesWithoutAccount)

        If resultEmployee.IsSuccess Then
            employee = CType(resultEmployee.Data, List(Of Employee))
        End If

        cbxEmployeeId.DataSource = employee _
        .Select(Function(x) New With {
            .Display = x.code & " - " & x.name,
            .Value = x.id
        }).ToList()

        cbxEmployeeId.DisplayMember = "Display"
        cbxEmployeeId.ValueMember = "Value"

    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click

        ErrorProvider1.Clear()

        Dim username As String = tbxUsername.Text.Trim()
        Dim id As Integer = cbxEmployeeId.SelectedValue
        Dim password As String = tbxPassword.Text.Trim()
        Dim confirmPassword As String = tbxAcceptPassword.Text.Trim()

        Dim isValid As Boolean = True

        If username = "" Then
            ErrorProvider1.SetError(tbxUsername, "Vui lòng nhập tên đăng nhập")
            isValid = False
        End If

        If id < 1 Then
            ErrorProvider1.SetError(cbxEmployeeId, "Vui lòng ID nhân viên")
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
            ErrorProvider1.SetError(tbxAcceptPassword, "Mật khẩu xác nhận không khớp")
            isValid = False
        End If

        If Not isValid Then Return

        If checkRegister(username, password) Then

            ' Tạo account mới
            Dim newAccount As New Account()
            newAccount.user = username
            newAccount.Employee = employee.FirstOrDefault(Function(emp) emp.id = id)
            newAccount.password = password
            newAccount.role = 2
            newAccount.status = 1

            ' Lưu vào database
            Dim accountSV As New AccountService()
            Dim result = accountSV.Execute(DataIntent.Insert, newAccount)

            If result.IsSuccess Then
                MessageBox.Show("Đăng ký thành công!")

                Dim frm As New frmLogin()
                frm.Show()
                Me.Close()
            Else
                MessageBox.Show(result.Message, "Lỗi")
            End If

        Else
            ErrorProvider1.SetError(tbxUsername, "Tên đăng nhập đã tồn tại")
        End If
    End Sub

    Private Function checkRegister(username As String, password As String) As Boolean

        ' Kiểm tra username đã tồn tại trong danh sách account
        If account.Any(Function(acc) acc.user = username) Then
            Return False
        End If

        Return True

    End Function
End Class