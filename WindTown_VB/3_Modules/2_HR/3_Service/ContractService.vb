Public Class ContractService
    Inherits BaseService(Of Contract)

    Private _repoCustom As ContractRepository = New ContractRepository()

    Public Sub New()
        _repo = New ContractRepository()
    End Sub

    ''' <summary>
    ''' Ghi đè (Override) lại hàm Execute nếu bạn muốn thêm logic kiểm tra (Validation)
    ''' trước khi gọi các lệnh gốc ở BaseService.
    ''' </summary>
    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        Try
            Select Case intent
                Case DataIntent.GetContractsWithoutPosition
                    Dim list = _repoCustom.GetContractsWithoutPosition()
                    Return ServiceResponse(Of Object).Success(list)

                Case Else
                    Return MyBase.Execute(intent, data)
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try

    End Function
End Class