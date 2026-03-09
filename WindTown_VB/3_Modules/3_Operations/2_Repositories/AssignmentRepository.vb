Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class AssignmentRepository
    Inherits GenericRepository(Of Assignment)

    Public Overrides Function GetAll() As IEnumerable(Of Assignment)

        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT
                ass.*,
                pos.*,
                ctr.*,
                emp.*,
                job.*,
                lvl.*,
                pr.*
            FROM assignment ass
            LEFT JOIN position pos ON ass.position_id = pos.id
            LEFT JOIN contract ctr ON pos.contract_id = ctr.id
            LEFT JOIN employee emp ON ctr.employee_id = emp.id
            LEFT JOIN job      job ON pos.job_id      = job.id
            LEFT JOIN level    lvl ON pos.level_id      = lvl.id
            LEFT JOIN project  pr  ON ass.project_id  = pr.id
            WHERE CAST(JSON_VALUE(ass.datas, '$.status') AS INT) <> @Status
            "

            Return db.Query(Of Assignment, Position, Contract, Employee, Job, Level, Project, Assignment)(
            sql,
            Function(a, p, c, e, j, l, pr)

                a.Position = p
                a.Project = pr

                If p IsNot Nothing Then
                    p.Contract = c
                    p.Job = j
                    p.Level = l
                End If

                If c IsNot Nothing Then
                    c.Employee = e
                End If

                Return a

            End Function,
            param:=New With {.Status = -1},
            splitOn:="id,id,id,id,id,id"
        )

        End Using

    End Function
End Class
