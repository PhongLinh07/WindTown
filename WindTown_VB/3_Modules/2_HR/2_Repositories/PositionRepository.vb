Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class PositionRepository
    Inherits GenericRepository(Of Position)

    Public Overrides Function GetAll() As IEnumerable(Of Position)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
                SELECT 
                p.*, 
                c.*, 
                e.*,
                j.*, 
                l.*
            FROM position p
            LEFT JOIN contract c ON p.contract_id = c.id
            LEFT JOIN employee e ON c.employee_id = e.id
            LEFT JOIN job j ON p.job_id = j.id
            LEFT JOIN level l ON p.level_id = l.id
            WHERE CAST(JSON_VALUE(p.datas, '$.status') AS INT) <> @Status
            "

            Return db.Query(Of Position, Contract, Employee, Job, Level, Position)(
            sql,
            Function(posObj, conObj, empObj, jobObj, lvlObj)

                posObj.Contract = conObj
                posObj.Job = jobObj
                posObj.Level = lvlObj

                If conObj IsNot Nothing Then
                    conObj.Employee = empObj
                End If

                Return posObj
            End Function,
            param:=New With {.Status = -1},
            splitOn:="id,id,id,id"
        )
        End Using
    End Function
End Class
