Imports Microsoft.EntityFrameworkCore

Public Class GenericRepository(Of T As Class)

    Protected ReadOnly _ctx As AppDbContext

    Sub New(ctx As AppDbContext)
        _ctx = ctx
    End Sub

    Protected Overridable Function BaseQuery() As IQueryable(Of T)
        Return _ctx.Set(Of T)().AsNoTracking()
    End Function

    Private Function Execute(filter As SqlFilter(Of T)) As IQueryable(Of T)
        Return filter.Apply(BaseQuery())
    End Function

    Public Overridable Function GetList() As List(Of T)
        Dim f = SqlFilter(Of T).Default() _
            .Add(Function(x) EF.Property(Of Integer)(x, "status") <> -1)
        Return Execute(f).ToList()
    End Function

    Public Overridable Function GetById(id As Integer) As T
        Dim f = SqlFilter(Of T).Default() _
            .Add(Function(x) EF.Property(Of Integer)(x, "status") <> -1) _
            .Add(Function(x) EF.Property(Of Integer)(x, "id") = id)
        Return Execute(f).FirstOrDefault()
    End Function

    Public Function Search(filter As SqlFilter(Of T)) As List(Of T)
        Return Execute(filter).ToList()
    End Function

    Public Function Insert(entity As T) As Boolean
        Try
            Using ctx As New AppDbContext()
                For Each nav In ctx.Entry(entity).Navigations
                    nav.CurrentValue = Nothing
                Next
                ctx.Set(Of T)().Add(entity)
                ctx.SaveChanges()

                ' ✅ Copy id mới về entity gốc
                Dim newId = ctx.Entry(entity).Property("id").CurrentValue
                entity.GetType().GetProperty("id")?.SetValue(entity, newId)
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi Insert: {ex.Message}{vbCrLf}{ex.InnerException?.Message}")
            Return False
        End Try
    End Function

    Public Function Update(entity As T) As Boolean
        Try
            Using ctx As New AppDbContext()
                For Each nav In ctx.Entry(entity).Navigations
                    nav.CurrentValue = Nothing
                Next
                ctx.Set(Of T)().Attach(entity)
                ctx.Entry(entity).State = EntityState.Modified
                ctx.SaveChanges()
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show($"Lỗi Update: {ex.Message}{vbCrLf}{ex.InnerException?.Message}")
            Return False
        End Try
    End Function

    Public Function Delete(id As Integer) As Boolean
        Try
            Using ctx As New AppDbContext()
                Dim entity = ctx.Set(Of T)().Find(id)
                If entity Is Nothing Then Return False
                ctx.Entry(entity).Property("status").CurrentValue = -1
                ctx.SaveChanges()
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class