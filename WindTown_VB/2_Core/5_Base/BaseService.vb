Public Class BaseService(Of T As {BaseEntity, New})
    Protected ReadOnly _repo As GenericRepository(Of T)
    Public Sub New()
        _repo = New GenericRepository(Of T)
    End Sub

    ' HÀM DUY NHẤT MÀ FORM GỌI
    Public Overridable Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
        Try
            Select Case intent
                Case DataIntent.GetList
                    Dim list = _repo.GetAll()
                    Return ServiceResponse(Of Object).Success(list)


                Case DataIntent.Update
                    Dim result = _repo.Update(DirectCast(data, T))
                    Return ServiceResponse(Of Object).Success(result, "Cập nhật thành công!")


                Case Else
                    Return ServiceResponse(Of Object).Fail("Yêu cầu không hợp lệ")
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try
    End Function
End Class