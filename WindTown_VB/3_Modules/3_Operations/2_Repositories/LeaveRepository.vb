Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class LeaveRepository
    Inherits GenericRepository(Of Leave)

    Public Overrides Function GetAll() As IEnumerable(Of Leave)
        Using db As IDbConnection = Database.GetConnection()

            ' a.* lấy toàn bộ cột của Leave, e.* lấy toàn bộ cột của employee | nhưng trả về 1 đối tượng Leave duy nhất (chứ không phải 2 đối tượng)
            Dim sql As String = "
            SELECT l.*, e.*, a.*, l_c.*
            FROM leave l
            LEFT JOIN employee e ON l.employee_id = e.id
            LEFT JOIN employee a ON l.approved_id = a.id
            LEFT JOIN leave_cat l_c ON l.leave_cat_id = l_c.id
            WHERE l.status <> @Status"

            Return db.Query(Of Leave, Employee, Employee, Leave_Cat, Leave)(
                sql,
                Function(leaveObj, empObj, apprObj, cat)
                    leaveObj.Employee = empObj
                    leaveObj.Approved = apprObj
                    leaveObj.Leave_Cat = cat
                    Return leaveObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id,id,id"
            )
        End Using
    End Function
End Class