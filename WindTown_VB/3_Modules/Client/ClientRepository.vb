Imports System.ComponentModel
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports WindTown_VB.DatabaseConfig
Imports WindTown_VB.WindTown.Core.Shared.Interfaces


Namespace WindTown.Modules.Assignment

    Friend Class ClientRepository
        Inherits AModelRepository(Of ClientModel)

        ' ===== Select all =====
        Public Sub Selects(data As ClientModel, ByRef result As BindingList(Of ClientModel))
            result = New BindingList(Of ClientModel)()
            If data Is Nothing Then Return

            Using con As New SqlConnection(Database.Config)
                con.Open()
                Dim sql As String = $"
                    SELECT *
                    FROM {ClientModel.tableName}"

                Dim list = con.Query(Of ClientModel)(sql) _
             .Select(Function(x) ClientModel.MapToClient(x)) _
             .ToList()

                result = New BindingList(Of ClientModel)(list)

                result = New BindingList(Of ClientModel)(list)
            End Using
        End Sub

        ' ===== Select single by id =====
        Public Sub [Select](data As ClientModel, ByRef result As ClientModel)
            result = Nothing
            If data Is Nothing Then Return

            Try
                Using con As New SqlConnection(Database.Config)
                    con.Open()

                    Dim sql As String = $"
                        SELECT *
                        FROM {ClientModel.tableName}
                        WHERE id = @id"

                    result = con.QuerySingleOrDefault(Of ClientModel)(sql, data)
                End Using
            Catch ex As Exception
                ' Logger.Instance.Logging(ex.Message, Logger.Error)
            End Try
        End Sub

        ' ===== Insert =====
        Public Sub Insert(data As ClientModel, ByRef result As ClientModel)
            result = Nothing
            If data Is Nothing Then Return

            Try
                Using con As New SqlConnection(Database.Config)
                    con.Open()

                    Dim sql As String = $"
                        INSERT INTO {ClientModel.tableName}
                        (
                            name,
                            phone,
                            email,
                            status,
                            description
                        )
                        OUTPUT INSERTED.*
                        VALUES
                        (
                            @name,
                            @phone,
                            @email,
                            @status,
                            @description
                        );"

                    result = con.QuerySingleOrDefault(Of ClientModel)(sql, data)
                End Using
            Catch ex As Exception
                ' Logger.Instance.Logging(ex.Message, Logger.Error)
            End Try
        End Sub

        ' ===== Update =====
        Public Sub Update(data As ClientModel, ByRef result As ClientModel)
            result = Nothing
            If data Is Nothing Then Return

            Using con As New SqlConnection(Database.Config)
                con.Open()

                Dim sql As String = $"
                    UPDATE {ClientModel.tableName}
                    SET
                        name = @name,
                        phone = @phone,
                        email = @email,
                        status = @status,
                        description = @description
                    OUTPUT INSERTED.*
                    WHERE id = @id"

                result = con.QuerySingleOrDefault(Of ClientModel)(sql, data)
            End Using
        End Sub

    End Class

End Namespace
