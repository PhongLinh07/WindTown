Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Imports Microsoft.EntityFrameworkCore
Public Class DatabaseConfig

    Friend NotInheritable Class Database
        Public Shared ReadOnly DefaultConfig As String = "Data Source=.;Initial Catalog=wind_town;Integrated Security=True;TrustServerCertificate=True"
        Private Shared _runtimeConfig As String = DefaultConfig

        ' ✅ Expose cho AppDbContext dùng — không cần tạo connection object
        Public Shared ReadOnly Property ConnectionString As String
            Get
                Return _runtimeConfig
            End Get
        End Property

        Public Shared Sub SetConnectionString(connectionString As String)
            If String.IsNullOrWhiteSpace(connectionString) Then
                _runtimeConfig = DefaultConfig
            Else
                _runtimeConfig = connectionString.Trim()
            End If
        End Sub

        Public Shared Function GetConnection() As IDbConnection
            Return New SqlConnection(_runtimeConfig)
        End Function
    End Class

End Class