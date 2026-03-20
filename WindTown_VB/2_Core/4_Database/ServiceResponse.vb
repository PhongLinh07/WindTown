Public Class ServiceResponse(Of T)

    Public Property IsSuccess As Boolean
    Public Property Message As String
    Public Property Data As T
    Public Property [Error] As Exception

    Friend Sub Add(item As Object)
        Throw New NotImplementedException()
    End Sub

    Public Shared Function Success(data As T, Optional msg As String = "") As ServiceResponse(Of T)
        Return New ServiceResponse(Of T) With {
            .IsSuccess = True,
            .Data = data,
            .Message = msg
        }
    End Function

    Public Shared Function Fail(msg As String, Optional ex As Exception = Nothing) As ServiceResponse(Of T)
        Return New ServiceResponse(Of T) With {
            .IsSuccess = False,
            .Message = msg,
            .Error = ex
        }
    End Function

    Friend Function FirstOrDefault(value As Func(Of Object, Object)) As Object
        Throw New NotImplementedException()
    End Function

    Friend Function ToDictionary(value As Func(Of Object, Object), ordinalIgnoreCase As StringComparer) As Object
        Throw New NotImplementedException()
    End Function

    Friend Function Where(value As Func(Of Object, Boolean)) As Object
        Throw New NotImplementedException()
    End Function
End Class