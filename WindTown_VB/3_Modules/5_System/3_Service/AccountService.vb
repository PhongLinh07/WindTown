Public Class AccountService
    Inherits BaseService(Of Account)

    Private _repoAcc As AccountRepository = New AccountRepository()
    Public Sub New()
        ' Vì JobRepository kế thừa từ GenericRepository(Of Job),
        ' nên việc gán này là hoàn toàn hợp lệ (tính đa hình).
        _repo = New AccountRepository()
    End Sub

    ''' <summary>
    ''' Ghi đè (Override) lại hàm Execute nếu bạn muốn thêm logic kiểm tra (Validation)
    ''' trước khi gọi các lệnh gốc ở BaseService.
    ''' </summary>
    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        Try
            Select Case intent

                Case DataIntent.Login

                    Dim accInput As Account = TryCast(data, Account)

                    If accInput Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Thiếu thông tin đăng nhập")
                    End If

                    Dim acc = _repoAcc.GetAccountByUsername(accInput)

                    If acc Is Nothing Then
                        Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Tài khoản không tồn tại")
                    End If

                    If acc.user = accInput.user AndAlso acc.password = accInput.password Then
                        ' Trả về tài khoản để UI tái sử dụng, tránh truy vấn lại.
                        acc.last_active = DateTime.Now
                        Me.Execute(DataIntent.Update, acc)
                        Return ServiceResponse(Of Object).Success(acc)
                    Else
                        Return ServiceResponse(Of Object).Fail("Đăng nhập thất bại: Sai mật khẩu")
                    End If

                Case Else
                    Return MyBase.Execute(intent, data)

            End Select

        Catch ex As Exception
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try

    End Function
End Class
