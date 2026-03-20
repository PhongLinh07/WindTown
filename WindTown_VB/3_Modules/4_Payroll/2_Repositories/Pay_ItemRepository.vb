Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class Pay_ItemRepository
    Inherits GenericRepository(Of Pay_Item)

    Public Overrides Function GetAll() As IEnumerable(Of Pay_Item)

        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT 
                p.*,
                pr.*
            FROM pay_item p
            JOIN payroll pr ON p.payroll_id = pr.id
            WHERE p.status <> -1
            AND pr.status <> -1
            "

            Return db.Query(Of Pay_Item, Payroll, Pay_Item)(
            sql,
            Function(pItem, pr)
                pItem.Payroll = pr
                Return pItem
            End Function,
            splitOn:="id"
        )

        End Using

    End Function

    Public Function GetPayItemByPayroll(payroll As Payroll) As IEnumerable(Of Pay_Item)

        Using db As IDbConnection = Database.GetConnection()

            Dim sql As String = "
            SELECT 
                p.*,
                pr.*
            FROM pay_item p
            JOIN payroll pr ON p.payroll_id = pr.id
            WHERE p.payroll_id = @PayrollId
            AND pr.status <> -1"

            Return db.Query(Of Pay_Item, Payroll, Pay_Item)(
            sql,
            Function(pItem, pr)
                pItem.Payroll = pr
                Return pItem
            End Function,
            New With {.PayrollId = payroll.id},
            splitOn:="id"
        )

        End Using

    End Function
End Class