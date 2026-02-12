Imports System.Data.SqlClient
Imports Dapper
Imports Dapper.Contrib.Extensions
Imports WindTown_VB.DatabaseConfig

Public Class GenericRepository(Of T As {BaseEntity, New})

    ' Lấy tất cả (Active)
    Public Overridable Function GetAll() As IEnumerable(Of T)
        Using db As IDbConnection = Database.GetConnection()
            ' Tự động lấy tên bảng từ Attribute <Table>
            Dim tableName As String = GetType(T).Name.ToLower()
            Return db.Query(Of T)($"SELECT * FROM [{tableName}] WHERE status <> -1")
        End Using
    End Function

    '' Lấy theo ID
    'Public Overridable Function GetById(id As Integer) As T
    '    Using db As IDbConnection = Database.GetConnection()
    '        Return db.Get(Of T)(id)
    '    End Using
    'End Function

    '' Thêm mới (Dùng Dapper.Contrib)
    'Public Overridable Function Insert(entity As T) As Long
    '    Using db As IDbConnection = Database.GetConnection()
    '        Return db.Insert(entity)
    '    End Using
    'End Function

    '' Cập nhật (Dùng Dapper.Contrib)
    'Public Overridable Function Update(entity As T) As Boolean
    '    Using db As IDbConnection = Database.GetConnection()
    '        Return db.Update(entity)
    '    End Using
    'End Function

    '' Xóa mềm
    'Public Overridable Function SoftDelete(id As Integer) As Boolean
    '    Using db As IDbConnection = Database.GetConnection()
    '        Dim tableName As String = GetType(T).Name.ToLower()
    '        Return db.Execute($"UPDATE [{tableName}] SET status = -1 WHERE id = @id", New With {id}) > 0
    '    End Using
    'End Function
End Class