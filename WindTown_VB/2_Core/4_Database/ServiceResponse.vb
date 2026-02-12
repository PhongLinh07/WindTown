Public Class ServiceResponse(Of T)

    Public Property IsSuccess As Boolean
    Public Property Message As String
    Public Property Data As T
    Public Property [Error] As Exception

    ' Hàm tạo nhanh Success
    Public Shared Function Success(data As T, Optional msg As String = "") As ServiceResponse(Of T)
        Return New ServiceResponse(Of T) With {
            .IsSuccess = True,
            .Data = data,
            .Message = msg
        }
    End Function

    ' Hàm tạo nhanh Fail
    Public Shared Function Fail(msg As String, Optional ex As Exception = Nothing) As ServiceResponse(Of T)
        Return New ServiceResponse(Of T) With {
            .IsSuccess = False,
            .Message = msg,
            .Error = ex
        }
    End Function

End Class
