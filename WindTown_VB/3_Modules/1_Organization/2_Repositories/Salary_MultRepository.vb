Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class Salary_MultRepository
    Inherits GenericRepository(Of Salary_Mult)

    Public Overrides Function GetAll() As IEnumerable(Of Salary_Mult)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = $"
                SELECT sm.*, j.* , l.*
                FROM salary_mult sm
                LEFT JOIN job j ON sm.job_id = j.id
                LEFT JOIN level l ON sm.level_id = l.id
                WHERE sm.status <> -1"

            Return db.Query(Of Salary_Mult, Job, Level, Salary_Mult)(
                sql,
                Function(mult, jobObj, lvlObj)
                    mult.Job = jobObj
                    mult.Level = lvlObj
                    Return mult
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id,id"
            )
        End Using
    End Function

    Public Function GetSalaryMultItemByJob(job As Job) As IEnumerable(Of Salary_Mult)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT sm.*, j.* , l.*
                FROM salary_mult sm
                LEFT JOIN job j ON sm.job_id = j.id
                LEFT JOIN level l ON sm.level_id = l.id
            WHERE sm.job_id = @JobId
                AND sm.status <> -1"

            Return db.Query(Of Salary_Mult, Job, Level, Salary_Mult)(
                sql,
                Function(mult, jobObj, lvlObj)
                    mult.Job = jobObj
                    mult.Level = lvlObj
                    Return mult
                End Function,
                param:=New With {.JobId = job.id},
                splitOn:="id,id"
            )

        End Using
    End Function
End Class