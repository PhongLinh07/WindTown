Imports Microsoft.EntityFrameworkCore

Public Class SqlFilter(Of T As Class)

    Private ReadOnly _predicates As New List(Of Expressions.Expression(Of Func(Of T, Boolean)))

    ' ✅ Mặc định loại soft-delete — gọi khi không có filter đặc biệt
    Public Shared Function [Default]() As SqlFilter(Of T)
        Return New SqlFilter(Of T)()
    End Function

    ' Thêm điều kiện bất kỳ (LINQ Expression)
    Public Function Add(predicate As Expressions.Expression(Of Func(Of T, Boolean))) As SqlFilter(Of T)
        _predicates.Add(predicate)
        Return Me
    End Function

    ' Áp toàn bộ điều kiện vào IQueryable
    Public Function Apply(query As IQueryable(Of T)) As IQueryable(Of T)
        For Each p In _predicates
            query = query.Where(p)
        Next
        Return query
    End Function

End Class