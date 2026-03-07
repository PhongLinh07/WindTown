Public Class frmRegister
    Private account As New List(Of Account)
    Private employee As New List(Of Employee)

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
            ErrorProvider1.SetError(tbxUsername, "Vui long nhap ten dang nhap")
            isValid = False
        End If

        If id < 1 Then
            ErrorProvider1.SetError(cbxEmployeeId, "Vui long chon nhan vien")
            isValid = False
        End If

        If password = "" Then
            ErrorProvider1.SetError(tbxPassword, "Vui long nhap mat khau")
            isValid = False
        End If

        If confirmPassword = "" Then
            ErrorProvider1.SetError(tbxAcceptPassword, "Vui long xac nhan mat khau")
            isValid = False
        End If

        If password <> "" AndAlso confirmPassword <> "" AndAlso password <> confirmPassword Then
            ErrorProvider1.SetError(tbxAcceptPassword, "Mat khau xac nhan khong khop")
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

            Dim accountSV As New AccountService()
            Dim result = accountSV.Execute(DataIntent.Insert, newAccount)

            If result.IsSuccess Then
                MessageBox.Show("Dang ky thanh cong!")
                NavigationService.SwitchTopLevel(Of frmLogin)(Me)
            Else
                MessageBox.Show(result.Message, "Loi")
            End If
        Else
            ErrorProvider1.SetError(tbxUsername, "Ten dang nhap da ton tai")
        End If
    End Sub

    Private Function checkRegister(username As String, password As String) As Boolean
        If account.Any(Function(acc) acc.user = username) Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        NavigationService.SwitchTopLevel(Of frmLogin)(Me)
    End Sub
End Class
