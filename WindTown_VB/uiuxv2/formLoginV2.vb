Imports System.Linq

''' <summary>Màn đăng nhập / đăng ký UIUX v2 — bootstrap DB khi mở form.</summary>
Public Class formLoginV2

    Private _employeesNoAccount As New List(Of Employee)()

    Private Sub formLoginV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiTextBoxHints.SetCueBanner(txtLoginUser, "Tên đăng nhập (mặc định: admin)")
        UiTextBoxHints.SetCueBanner(txtLoginPass, "Mật khẩu")
        UiTextBoxHints.SetCueBanner(txtRegUser, "Chọn tên đăng nhập")
        UiTextBoxHints.SetCueBanner(txtRegPass, "Mật khẩu")
        UiTextBoxHints.SetCueBanner(txtRegConfirm, "Nhập lại mật khẩu")

        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            lblDbStatus.Text = "CSDL: " & bootstrap.Message
            lblDbStatus.ForeColor = Drawing.Color.FromArgb(240, 128, 128)
            btnLogin.Enabled = False
            btnRegister.Enabled = False
            MessageBox.Show("Lỗi kết nối CSDL: " & bootstrap.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        lblDbStatus.Text = "CSDL: " & bootstrap.Message
        lblDbStatus.ForeColor = Drawing.Color.FromArgb(123, 139, 178)
        ReloadEmployeesForRegister()
    End Sub

    Private Sub ReloadEmployeesForRegister()
        _employeesNoAccount.Clear()
        cboEmployee.DataSource = Nothing

        Dim res = AppServices.Instance.EmployeeSV.GetWithoutAccount()
        If res.IsSuccess AndAlso res.Data IsNot Nothing Then
            _employeesNoAccount = CType(res.Data, List(Of Employee))
        End If

        If _employeesNoAccount.Count = 0 Then
            cboEmployee.Enabled = False
            Return
        End If

        cboEmployee.Enabled = True
        Dim src = _employeesNoAccount.Select(Function(x) New With {
            .Display = x.code & " — " & x.name,
            .Value = x.id
        }).ToList()
        cboEmployee.DataSource = src
        cboEmployee.DisplayMember = "Display"
        cboEmployee.ValueMember = "Value"
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username = txtLoginUser.Text.Trim()
        Dim password = txtLoginPass.Text.Trim()

        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLoginUser.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Vui lòng nhập mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLoginPass.Focus()
            Return
        End If

        Dim ketQua = AppServices.Instance.AccountSV.Login(New Account With {.user = username, .password = password})
        If Not ketQua.IsSuccess Then
            Dim msg = If(String.IsNullOrWhiteSpace(ketQua.Message), "Sai tài khoản hoặc mật khẩu.", ketQua.Message)
            MessageBox.Show(msg, "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim acc = TryCast(ketQua.Data, Account)
        If acc Is Nothing Then
            MessageBox.Show("Không lấy được thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        CapNhatThongTinPhien(acc)
        NguoiDungHienTaiService.GanTaiKhoanDangNhap(acc)
        UserProfile.User = acc
    End Sub

    Private Sub CapNhatThongTinPhien(acc As Account)
        If acc Is Nothing Then Return
        modSession.CurrentUserId = acc.id
        modSession.CurrentEmployeeId = acc.employee_id
        modSession.CurrentUser = If(String.IsNullOrWhiteSpace(acc.user), modSession.CurrentUser, acc.user)
        modSession.CurrentRole = acc.role
        Dim ten = acc.Employee?.name
        If String.IsNullOrWhiteSpace(ten) Then ten = acc.user
        modSession.DisplayName = ten
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        errReg.Clear()

        Dim username = txtRegUser.Text.Trim()
        Dim password = txtRegPass.Text.Trim()
        Dim confirm = txtRegConfirm.Text.Trim()

        Dim ok As Boolean = True
        If username = "" Then
            errReg.SetError(txtRegUser, "Nhập tên đăng nhập")
            ok = False
        End If
        If Not cboEmployee.Enabled OrElse cboEmployee.SelectedValue Is Nothing OrElse CInt(cboEmployee.SelectedValue) < 1 Then
            errReg.SetError(cboEmployee, "Không có nhân viên chưa có tài khoản")
            ok = False
        End If
        If password = "" Then
            errReg.SetError(txtRegPass, "Nhập mật khẩu")
            ok = False
        End If
        If confirm = "" Then
            errReg.SetError(txtRegConfirm, "Xác nhận mật khẩu")
            ok = False
        End If
        If password <> "" AndAlso confirm <> "" AndAlso password <> confirm Then
            errReg.SetError(txtRegConfirm, "Mật khẩu xác nhận không khớp")
            ok = False
        End If
        If Not ok Then Return

        Dim dup = AppServices.Instance.AccountSV.GetList()
        If dup.IsSuccess AndAlso dup.Data IsNot Nothing Then
            Dim list = CType(dup.Data, List(Of Account))
            If list.Any(Function(a) String.Equals(a.user, username, StringComparison.OrdinalIgnoreCase)) Then
                errReg.SetError(txtRegUser, "Tên đăng nhập đã tồn tại")
                Return
            End If
        End If

        Dim empId = CInt(cboEmployee.SelectedValue)
        Dim emp = _employeesNoAccount.FirstOrDefault(Function(x) x.id = empId)
        If emp Is Nothing Then
            MessageBox.Show("Không tìm thấy nhân viên đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newAcc As New Account()
        newAcc.user = username
        newAcc.password = password
        newAcc.employee_id = emp.id
        ' newAcc.role = Account.ROLE_STAFF
        newAcc.status = 1

        Dim ins = AppServices.Instance.AccountSV.Insert(newAcc)
        If ins.IsSuccess Then
            MessageBox.Show("Đăng ký thành công. Vui lòng đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRegUser.Clear()
            txtRegPass.Clear()
            txtRegConfirm.Clear()
            ReloadEmployeesForRegister()
            tabMain.SelectedTab = tabLogin
            txtLoginUser.Text = username
            txtLoginPass.Focus()
        Else
            MessageBox.Show(ins.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
