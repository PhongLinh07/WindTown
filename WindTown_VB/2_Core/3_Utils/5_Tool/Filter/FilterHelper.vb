Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Reflection

' ── Model 1 điều kiện lọc ────────────────────────────────────
Public Class FilterModel
    Public Property Field As String
    Public Property Opera As String
    Public Property Value1 As Object
    Public Property Value2 As Object
End Class

' ── Đọc Model → sinh field list + check điều kiện ────────────
Public Module FilterHelper

    ' Thông tin 1 field có thể lọc
    Public Class FieldInfo
        Public Property PropName As String
        Public Property DisplayName As String
        Public Property PropType As Type
        Public Property Order As Integer
    End Class

    ' Đọc Model qua Reflection → danh sách field lọc được
    ' Quy tắc: có DisplayName + không bị Browsable(False)
    Public Function GetFields(modelType As Type) As List(Of FieldInfo)
        Dim list As New List(Of FieldInfo)
        For Each p In modelType.GetProperties()
            Dim br = p.GetCustomAttribute(Of BrowsableAttribute)()
            If br IsNot Nothing AndAlso Not br.Browsable Then Continue For
            Dim dn = p.GetCustomAttribute(Of DisplayNameAttribute)()
            If dn Is Nothing Then Continue For
            Dim dp = p.GetCustomAttribute(Of DisplayAttribute)()
            list.Add(New FieldInfo With {
                .PropName = p.Name,
                .DisplayName = dn.DisplayName,
                .PropType = If(Nullable.GetUnderlyingType(p.PropertyType), p.PropertyType),
                .Order = If(dp IsNot Nothing, dp.Order, 999)
            })
        Next
        Return list.OrderBy(Function(x) x.Order).ToList()
    End Function

    ' Operator theo kiểu dữ liệu
    Public Function GetOperators(t As Type) As String()
        If t = GetType(String) Then Return {"contains", "=", "starts with", "ends with"}
        If t = GetType(DateTime) Then Return {"=", ">", "<", ">=", "<=", "between"}
        If t = GetType(Boolean) Then Return {"="}
        Return {"=", "<>", ">", "<", ">=", "<=", "between"}
    End Function

    ' Check 1 item có khớp toàn bộ filter không (AND)
    Public Function Match(item As Object, filters As List(Of FilterModel)) As Boolean
        For Each f In filters
            If Not MatchOne(item, f) Then Return False
        Next
        Return True
    End Function

    Private Function MatchOne(item As Object, f As FilterModel) As Boolean
        Try
            Dim p = item.GetType().GetProperty(f.Field)
            If p Is Nothing Then Return True
            Dim raw = p.GetValue(item)
            Dim t = If(Nullable.GetUnderlyingType(p.PropertyType), p.PropertyType)

            If t = GetType(String) Then
                Dim s = If(raw?.ToString(), "").ToLower()
                Dim v = If(f.Value1?.ToString(), "").ToLower()
                Select Case f.Opera.ToLower()
                    Case "contains" : Return s.Contains(v)
                    Case "starts with" : Return s.StartsWith(v)
                    Case "ends with" : Return s.EndsWith(v)
                    Case Else : Return s = v
                End Select

            ElseIf t = GetType(DateTime) Then
                If raw Is Nothing Then Return True
                Dim d = CDate(raw) : Dim v1 = CDate(f.Value1)
                Select Case f.Opera.ToLower()
                    Case ">" : Return d > v1
                    Case "<" : Return d < v1
                    Case ">=" : Return d >= v1
                    Case "<=" : Return d <= v1
                    Case "between" : Return d >= v1 AndAlso d <= CDate(f.Value2)
                    Case Else : Return d.Date = v1.Date
                End Select

            ElseIf t = GetType(Boolean) Then
                Return CBool(raw) = CBool(f.Value1)

            Else
                If raw Is Nothing OrElse f.Value1 Is Nothing Then Return True
                Dim d1 = CDec(raw) : Dim v1 = CDec(f.Value1)
                Select Case f.Opera
                    Case "<>" : Return d1 <> v1
                    Case ">" : Return d1 > v1
                    Case "<" : Return d1 < v1
                    Case ">=" : Return d1 >= v1
                    Case "<=" : Return d1 <= v1
                    Case "between" : Return f.Value2 IsNot Nothing AndAlso d1 >= v1 AndAlso d1 <= CDec(f.Value2)
                    Case Else : Return d1 = v1
                End Select
            End If
        Catch
            Return True
        End Try
        Return True
    End Function

End Module