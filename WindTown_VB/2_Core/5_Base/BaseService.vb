
Public Interface IBaseService
    Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
End Interface

Public Class BaseService(Of T As {BaseEntity, New})
    Implements IBaseService

    Protected ReadOnly _repo As GenericRepository(Of T)
    Public Sub New()
        _repo = New GenericRepository(Of T)
    End Sub

    ' HÀM DUY NHẤT MÀ FORM GỌI
    Public Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object) Implements IBaseService.Execute
        Try
            Select Case intent
                Case DataIntent.GetList
                    Dim list = _repo.GetAll()
                    Return ServiceResponse(Of Object).Success(list)

                Case DataIntent.Insert
                    Try
                        Dim result = _repo.Insert(DirectCast(data, T))
                        Return ServiceResponse(Of Object).Success(result, "Thêm mới thành công!")

                    Catch ex As Exception
                        Return ServiceResponse(Of Object).Fail("Không thể thêm: " & ex.Message, ex)
                    End Try
                Case DataIntent.Update
                    Try
                        Dim result = _repo.Update(DirectCast(data, T))
                        Return ServiceResponse(Of Object).Success(result, "Cập nhật thành công!")

                    Catch ex As Exception
                        Return ServiceResponse(Of Object).Fail("Không thể cập nhật: " & ex.Message, ex)
                    End Try

                Case DataIntent.SoftDeleteMany
                    Try
                        Dim result = _repo.SoftDeleteMany(DirectCast(data, IEnumerable(Of T)))
                        Return ServiceResponse(Of Object).Success(result, "Xóa thành công!")

                    Catch ex As Exception
                        Return ServiceResponse(Of Object).Fail("Không thể Xóa: " & ex.Message, ex)
                    End Try


                Case Else
                    Return ServiceResponse(Of Object).Fail("Yêu cầu không hợp lệ")
            End Select
        Catch ex As Exception
            ' Bạn có thể ghi log lỗi vào file ở đây
            Return ServiceResponse(Of Object).Fail("Lỗi hệ thống: " & ex.Message, ex)
        End Try
    End Function

End Class