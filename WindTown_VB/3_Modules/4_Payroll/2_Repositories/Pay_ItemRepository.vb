Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class Pay_ItemRepository
    Inherits GenericRepository(Of Pay_Item)

    Public Function GetPayItemByPayroll(payroll As Payroll) As IEnumerable(Of Pay_Item)
        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT 
                p.*
            FROM pay_item p
            WHERE p.payroll_id = @PayrollId
                AND ISNULL(CAST(JSON_VALUE(p.datas, '$.status') AS INT), 0) <> -1"

            Return db.Query(Of Pay_Item)(
                sql,
                New With {.PayrollId = payroll.id}
            )

        End Using
    End Function
End Class