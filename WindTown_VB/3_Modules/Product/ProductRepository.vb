Imports System.ComponentModel
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports WindTown_VB.DatabaseConfig
Imports WindTown_VB.WindTown.Core.Shared.Interfaces

Namespace WindTown.Modules.Assignment

    Friend Class ProductRepository
        Inherits AModelRepository(Of ProductModel)

        ' ===== Select all =====
        Public Sub Selects(data As ProductModel, ByRef result As BindingList(Of ProductModel))
            result = New BindingList(Of ProductModel)()
            If data Is Nothing Then Return

            Using con As New SqlConnection(Database.Config)
                con.Open()
                Dim sql As String = $"
                    SELECT *
                    FROM {ProductModel.tableName}"
                Dim list = con.Query(Of ProductModel)(sql).ToList()
                result = New BindingList(Of ProductModel)(list)
            End Using
        End Sub

        ' ===== Select single by id =====
        Public Sub [Select](data As ProductModel, ByRef result As ProductModel)
            result = Nothing
            If data Is Nothing Then Return

            Try
                Using con As New SqlConnection(Database.Config)
                    con.Open()

                    Dim sql As String = $"
                        SELECT *
                        FROM {ProductModel.tableName}
                        WHERE id = @id"

                    result = con.QuerySingleOrDefault(Of ProductModel)(sql, data)
                End Using
            Catch ex As Exception
                ' Logger.Instance.Logging(ex.Message, Logger.Error)
            End Try
        End Sub

        ' ===== Insert =====
        Public Sub Insert(data As ProductModel, ByRef result As ProductModel)
            result = Nothing
            If data Is Nothing Then Return

            Try
                Using con As New SqlConnection(Database.Config)
                    con.Open()

                    Dim sql As String = $"
                        INSERT INTO {ProductModel.tableName}
                        (
                            name,
                            unit_price,
                            quantity,
                            status,
                            description
                        )
                        OUTPUT INSERTED.*
                        VALUES
                        (
                            @name,
                            @unit_price,
                            @quantity,
                            @status,
                            @description
                        );"

                    result = con.QuerySingleOrDefault(Of ProductModel)(sql, data)
                End Using
            Catch ex As Exception
                ' Logger.Instance.Logging(ex.Message, Logger.Error)
            End Try
        End Sub

        ' ===== Update =====
        Public Sub Update(data As ProductModel, ByRef result As ProductModel)
            result = Nothing
            If data Is Nothing Then Return

            Using con As New SqlConnection(Database.Config)
                con.Open()

                Dim sql As String = $"
                    UPDATE {ProductModel.tableName}
                    SET
                        name = @name,
                        unit_price = @unit_price,
                        quantity = @quantity,
                        status = @status,
                        description = @description
                    OUTPUT INSERTED.*
                    WHERE id = @id"

                result = con.QuerySingleOrDefault(Of ProductModel)(sql, data)
            End Using
        End Sub

    End Class

End Namespace
