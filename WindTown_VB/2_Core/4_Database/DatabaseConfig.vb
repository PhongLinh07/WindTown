Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class DatabaseConfig

    Public Enum EIntent
        ' ===== Model Intents =====
        Select1
        Selects
        Selects_By_Period
        Selects_By_IdPayroll
        SelectByType
        GetById
        Calculator_Salary
        Calculator_Salarys
        net_Salary
        net_Salarys
        Insert
        Update
        Delete
        Selects_By_Department
        Sort
        Selects_SummaryMode          ' For Attendance Summary Mode
        Already_Existed_IdPayPeriod_And_Assignment
        Select_Top_Status_Enable
        Is_Status_Matched
        Selects_By_IdEmployee_And_Period
        Select_CurrOfEmp             ' For Attendance Summary Mode
        SelectValidContracts         ' For Attendance Summary Mode
        Selects_By_CodeEmployee
        Init_Period

        ' ===== Usecase Intents =====
        Login
        Logout
        Register
    End Enum

    ' ===== Generic Response(Of T) =====
    Public Class Response(Of T)

        Public Sub New()
        End Sub

        Public Sub New(isSuccess As Boolean)
            Me.IsSuccess = isSuccess
        End Sub

        Public Property Datas As BindingList(Of T) = New BindingList(Of T)()
        Public Property Data As T
        Public Property ErrorMessage As String = ""
        Public Property IsSuccess As Boolean = False

    End Class

    ' ===== Database config =====
    Friend NotInheritable Class Database
        Private Shared ReadOnly Config As String = "Data Source=localhost;Initial Catalog=wind_town;Integrated Security=True;TrustServerCertificate=True"
        Public Shared Function GetConnection() As IDbConnection
            Return New SqlConnection(Config)
        End Function
    End Class

End Class
