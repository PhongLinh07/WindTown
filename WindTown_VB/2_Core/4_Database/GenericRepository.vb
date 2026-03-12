Imports Dapper
Imports Dapper.Contrib.Extensions
Imports WindTown_VB.DatabaseConfig

Public Interface IRepository
    Function Execute(intent As DataIntent, Optional data As Object = Nothing) As ServiceResponse(Of Object)
End Interface

Public Class GenericRepository(Of T As {BaseEntity, New})

    ' Lấy tất cả (Active)
    Public Overridable Function GetAll() As IEnumerable(Of T)
        Using db As IDbConnection = Database.GetConnection()
            ' Tự động lấy tên bảng từ Attribute <Table>
            Dim tableName As String = GetType(T).Name.ToLower()

            Return db.Query(Of T)(
            $"SELECT * FROM [{tableName}] 
              WHERE CAST(JSON_VALUE(datas, '$.status') AS INT) <> @Status",
            New With {.Status = -1}
        )
        End Using
    End Function

    'Insert (Dùng Dapper.Contrib)
    Public Overridable Function Insert(entity As T) As Long
        Using db As IDbConnection = Database.GetConnection()
            Return db.Insert(entity)
        End Using
    End Function

    ' Update (Dùng Dapper.Contrib)
    Public Overridable Function Update(entity As T) As Boolean
        Using db As IDbConnection = Database.GetConnection()

            Return db.Update(entity)
        End Using
    End Function

    ' SoftDeleteMany (Xóa mềm nhiều bản ghi)
    Public Function SoftDeleteMany(entities As IEnumerable(Of T)) As Integer
        Using db As IDbConnection = Database.GetConnection()

            Dim tableName = GetType(T).Name.ToLower()

            Dim sql = $"
            UPDATE [{tableName}]
            SET datas = JSON_MODIFY(datas,'$.status',-1)
            WHERE id IN @Ids
            "

            Return db.Execute(sql, New With {.Ids = entities.Select(Function(x) x.id)})

        End Using
    End Function
End Class