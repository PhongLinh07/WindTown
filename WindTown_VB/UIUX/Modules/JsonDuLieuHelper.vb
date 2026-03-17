Imports Newtonsoft.Json.Linq

Public NotInheritable Class JsonDuLieuHelper
    Public Shared Function TaiJson(json As String) As JObject
        If String.IsNullOrWhiteSpace(json) Then
            Return New JObject()
        End If

        Try
            Return JObject.Parse(json)
        Catch
            Return New JObject()
        End Try
    End Function

    Public Shared Function LayChuoi(obj As JObject, khoa As String) As String
        If obj Is Nothing Then Return ""
        Dim token = obj.SelectToken(khoa)
        If token Is Nothing Then Return ""
        Return token.ToString()
    End Function

    Public Shared Function LaySo(obj As JObject, khoa As String) As Integer
        Dim raw = LayChuoi(obj, khoa)
        Dim giaTri As Integer
        If Integer.TryParse(raw, giaTri) Then
            Return giaTri
        End If
        Return 0
    End Function
End Class
