Imports Dapper
Imports WindTown_VB.DatabaseConfig
Imports System.Data

Public Class AccountRepository
    Inherits GenericRepository(Of Account)

    Public Overrides Function GetAll() As IEnumerable(Of Account)
        Using db As IDbConnection = Database.GetConnection()

            ' a.* lấy toàn bộ cột của account, e.* lấy toàn bộ cột của employee | nhưng trả về 1 đối tượng Account duy nhất (chứ không phải 2 đối tượng)
            Dim sql As String = $"
                SELECT a.*, e.* 
                FROM account a
                LEFT JOIN employee e ON a.employee_id = e.id
                WHERE CAST(JSON_VALUE(a.datas, '$.status') AS INT) <> @Status"

            ' 3. Thực thi Multi-Mapping
            ' Of Account, Empployee, Account -> Đọc Empolyee, đọc Employee, trả về Account
            Return db.Query(Of Account, Employee, Account)(
                sql,
                Function(accObj, empObj)
                    ' ĐÂY LÀ BƯỚC "SNAP": Gán đối tượng phòng ban vào Job
                    accObj.Employee = empObj
                    Return accObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id" ' Dấu hiệu để Dapper biết bắt đầu bảng thứ 2 từ cột "id"
            )
        End Using
    End Function

    Public Function GetAccountByUsername(data As Account) As Account
        Using db As IDbConnection = Database.GetConnection()

            Dim sql = "
            SELECT a.*, e.*
            FROM account a
            LEFT JOIN employee e ON a.employee_id = e.id
            WHERE JSON_VALUE(a.datas, '$.status') <> '-1'
            AND JSON_VALUE(a.datas, '$.user') = @User 
            "

            Return db.Query(Of Account, Employee, Account)(
                sql,
                Function(acc, emp)
                    acc.Employee = emp
                    Return acc
                End Function,
                New With {.User = data.user},
                splitOn:="id"
            ).FirstOrDefault()

        End Using
    End Function
End Class