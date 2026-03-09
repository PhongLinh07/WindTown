Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class ProjectRepository
    Inherits GenericRepository(Of Project)


    Public Function GetProjectIsActive() As IEnumerable(Of Project)
        Using db As IDbConnection = Database.GetConnection()
            ' Câu lệnh SQL: Lấy dự án đang trong quá trinh hoặt động -1.delete, 0.jected, 1.palnning, 2.doing, 3.complate

            Dim sql As String = $"
            SELECT p.*
            FROM [{GetType(Project).Name.ToLower()}] p
            WHERE CAST(JSON_VALUE(p.datas, '$.status') AS INT) IN (1, 2)"

            Return db.Query(Of Project)(sql)
        End Using
    End Function
End Class
