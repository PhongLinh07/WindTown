Imports System.ComponentModel
Imports Dapper.Contrib.Extensions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public MustInherit Class BaseEntity


    <Key> <Browsable(False)> Public Property id As Integer
    <Browsable(False)> Public Property datas As String ' Lưu JSON nvarchar(max)


    ' Hàm đọc giá trị từ chuỗi JSON datas
    Protected Function GetV(key As String) As String
        If String.IsNullOrEmpty(Me.datas) Then Return ""
        Try
            Dim obj = JObject.Parse(Me.datas)
            Return If(obj(key)?.ToString(), "")
        Catch
            Return ""
        End Try
    End Function

    ' Hàm ghi giá trị vào chuỗi JSON datas
    Protected Sub SetV(key As String, value As String)
        Dim obj As JObject
        Try
            obj = If(String.IsNullOrEmpty(Me.datas), New JObject(), JObject.Parse(Me.datas))
        Catch
            obj = New JObject()
        End Try

        obj(key) = value
        ' Tự động nạp ngược lại vào chuỗi datas để Dapper lưu
        Me.datas = obj.ToString(Formatting.None)
    End Sub

End Class