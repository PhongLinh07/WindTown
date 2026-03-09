Imports Dapper
Imports WindTown_VB.DatabaseConfig
Imports System.Data

Public Class ContractRepository
    Inherits GenericRepository(Of Contract)

    Public Overrides Function GetAll() As IEnumerable(Of Contract)
        Using db As IDbConnection = Database.GetConnection()

            ' a.* lấy toàn bộ cột của Contract, e.* lấy toàn bộ cột của employee | nhưng trả về 1 đối tượng Contract duy nhất (chứ không phải 2 đối tượng)
            Dim sql As String = "
            SELECT 
                a.*, e.*
            FROM contract a
            LEFT JOIN employee e ON a.employee_id = e.id
            WHERE 
                ISNULL(CAST(JSON_VALUE(a.datas, '$.status') AS INT), 0) <> -1 
                AND ISNULL(CAST(JSON_VALUE(e.datas, '$.status') AS INT), 0) <> -1"

            Return db.Query(Of Contract, Employee, Contract)(
            sql,
            Function(contractObj, empObj)
                ' Gán đối tượng Employee vào Property của Contract
                contractObj.Employee = empObj
                Return contractObj
            End Function,
            splitOn:="id"
        )
        End Using
    End Function

    ' Đăng ký chức vụ theo hợp đồng
    ' Lấy những hợp đồng đang Active mà Không có thông tin vị trí (Position) tương ứng được Active
    Public Function GetContractsWithoutPosition() As IEnumerable(Of Contract)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT c.*, e.*
            FROM contract c
            LEFT JOIN employee e ON c.employee_id = e.id
            WHERE 
                ISNULL(CAST(JSON_VALUE(c.datas, '$.status') AS INT), 0) NOT IN (-1, 0)
                AND ISNULL(CAST(JSON_VALUE(e.datas, '$.status') AS INT), 0) <> -1
                AND NOT EXISTS (
                    SELECT 1
                    FROM position p
                    WHERE p.contract_id = c.id
                    AND ISNULL(CAST(JSON_VALUE(p.datas, '$.status') AS INT), 0) <> -1
                )
            "

            Return db.Query(Of Contract, Employee, Contract)(
            sql,
            Function(contractObj, empObj)
                contractObj.Employee = empObj
                Return contractObj
            End Function,
            splitOn:="id"
        )

        End Using
    End Function

End Class