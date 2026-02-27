Imports Dapper
Imports WindTown_VB.DatabaseConfig
Imports System.Data

Public Class JobRepository
    Inherits GenericRepository(Of Job)

    Public Overrides Function GetAll() As IEnumerable(Of Job)
        Using db As IDbConnection = Database.GetConnection()

            ' j.* lấy toàn bộ cột của job, d.* lấy toàn bộ cột của department
            Dim sql As String = $"
                SELECT j.*, d.* 
                FROM job j
                LEFT JOIN department d ON j.department_id = d.id
                WHERE CAST(JSON_VALUE(j.datas, '$.status') AS INT) <> @Status"

            ' 3. Thực thi Multi-Mapping
            ' Of Job, Department, Job -> Đọc Job, đọc Department, trả về Job
            Return db.Query(Of Job, Department, Job)(
                sql,
                Function(jobObj, deptObj)
                    ' ĐÂY LÀ BƯỚC "SNAP": Gán đối tượng phòng ban vào Job
                    jobObj.Department = deptObj
                    Return jobObj
                End Function,
                param:=New With {.Status = -1},
                splitOn:="id" ' Dấu hiệu để Dapper biết bắt đầu bảng thứ 2 từ cột "id"
            )
        End Using
    End Function
End Class