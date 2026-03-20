Imports System.Data.SqlClient
Imports Microsoft.EntityFrameworkCore
Public Class DatabaseConfig

    'Public Enum EIntent
    '    ' ===== Model Intents =====
    '    Select1
    '    Selects
    '    Selects_By_Period
    '    Selects_By_IdPayroll
    '    SelectByType
    '    GetById
    '    Calculator_Salary
    '    Calculator_Salarys
    '    net_Salary
    '    net_Salarys
    '    Insert
    '    Update
    '    Delete
    '    Selects_By_Department
    '    Sort
    '    Selects_SummaryMode          ' For Attendance Summary Mode
    '    Already_Existed_IdPayPeriod_And_Assignment
    '    Select_Top_Status_Enable
    '    Is_Status_Matched
    '    Selects_By_IdEmployee_And_Period
    '    Select_CurrOfEmp             ' For Attendance Summary Mode
    '    SelectValidContracts         ' For Attendance Summary Mode
    '    Selects_By_CodeEmployee
    '    Init_Period

    '    ' ===== Usecase Intents =====
    '    Login
    '    Logout
    '    Register
    'End Enum
    ' ===== Database config =====
    Friend NotInheritable Class Database
        Private Shared ReadOnly DefaultConfig As String = "Data Source=.;Initial Catalog=wind_town;Integrated Security=True;TrustServerCertificate=True"
        Private Shared _runtimeConfig As String = DefaultConfig

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


