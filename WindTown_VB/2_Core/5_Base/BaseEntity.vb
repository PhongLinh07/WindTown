Imports System.ComponentModel
Imports Dapper.Contrib.Extensions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public MustInherit Class BaseEntity

    <Key> <Browsable(False)> Public Property id As Integer
    <Browsable(False)> Public Property datas As String ' Lưu JSON nvarchar(max)


    ' Hàm đọc giá trị từ chuỗi JSON datas
    ' Hàm đọc giá trị với kiểu dữ liệu động
    Protected Function GetV(Of T)(key As String) As T
        If String.IsNullOrEmpty(Me.datas) Then Return Nothing
        Try
            Dim obj = JObject.Parse(Me.datas)
            Dim token = obj(key)
            If token Is Nothing Then Return Nothing

            ' Tự động chuyển đổi từ JSON sang kiểu T (Date, Int, Decimal...)
            Return token.ToObject(Of T)()
        Catch
            Return Nothing
        End Try
    End Function

    ' Hàm ghi giá trị với kiểu dữ liệu động
    Protected Sub SetV(Of T)(key As String, value As T)
        Dim obj As JObject
        Try
            obj = If(String.IsNullOrEmpty(Me.datas), New JObject(), JObject.Parse(Me.datas))
        Catch
            obj = New JObject()
        End Try

        ' Chuyển đối tượng value sang JToken để lưu vào JSON
        obj(key) = If(value Is Nothing, JValue.CreateNull(), JToken.FromObject(value))

        Me.datas = obj.ToString(Formatting.None)


    End Sub

End Class