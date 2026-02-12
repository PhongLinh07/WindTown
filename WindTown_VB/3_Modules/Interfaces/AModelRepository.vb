Imports System.ComponentModel
Imports Dapper
Imports Microsoft.Data.SqlClient

Imports WindTown_VB.DatabaseConfig

Namespace WindTown.Core.Shared.Interfaces

    Public Class AModelRepository(Of T As AModel)

        ' ===== Selects (chưa triển khai) =====
        Public Overridable Function Selects(data As T) As BindingList(Of T)
            ' TODO: implement select logic
            Return New BindingList(Of T)()
        End Function

        ' ===== Delete =====
        Public Overridable Sub Delete(data As T, ByRef result As Boolean)
            result = False
            If data Is Nothing Then Return

            Using con As New SqlConnection(Database.Config)
                con.Open()

                Dim sql As String = $"DELETE FROM {data.GetTableName} WHERE id = @id"
                result = con.Execute(sql, data) > 0
            End Using
        End Sub

    End Class

End Namespace
