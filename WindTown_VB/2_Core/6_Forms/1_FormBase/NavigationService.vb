Public NotInheritable Class NavigationService
    Public Shared _startForm As Form = Nothing

    Public Shared ReadOnly Property StartForm As Form
        Get
            If _startForm Is Nothing Then
                Init()
            End If
            Return _startForm
        End Get
    End Property

    Public Shared Sub Init()
        ' Tạo form nền (ẩn)
        _startForm = New Form()
        _startForm.Opacity = 0
        _startForm.ShowInTaskbar = False


        ' BƯỚC 1: Kiểm tra kết nối Database
        If True Then
            Dim response = AppServices.Instance.AccountSV.GetList()
            Dim accList As List(Of Account) = If(response.IsSuccess, response.Data, New List(Of Account))

            If accList.Count() = 0 Then
                ToMainForm()
            Else
                ToLoginForm()
            End If
        Else
            ' Nếu người dùng hủy bỏ cấu hình hoặc lỗi không thể sửa -> Thoát
            Application.Exit()
        End If
    End Sub


    Public Shared Sub ToLoginForm()
        SwitchToForm(Nothing, New frmLogin())
    End Sub

    Public Shared Sub ToMainForm()
        SwitchToForm(Nothing, New FormMain())
    End Sub

    Public Shared Sub SwitchToForm(currentForm As Form, nextForm As Form)
        If currentForm IsNot Nothing Then
            currentForm.Close()
        End If

        nextForm.StartPosition = FormStartPosition.CenterScreen
        nextForm.Show()
    End Sub
End Class