Public Class Pay_ItemService
    Inherits BaseService(Of Pay_Item)

    Private _repoPayItem As Pay_ItemRepository = New Pay_ItemRepository()
    Public Sub New()

        _repo = New Pay_ItemRepository()
    End Sub

    Public Overrides Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)

        Try
            Select Case intent
                Case DataIntent.GetPayItemByPayroll
                    Dim payroll As Payroll = TryCast(data, Payroll)
                    Dim list = _repoPayItem.GetPayItemByPayroll(data)
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