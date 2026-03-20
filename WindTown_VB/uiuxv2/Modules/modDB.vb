Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

' ============================================================
'  modDB.vb — Helpers tiện ích (không dùng SQL trực tiếp)
'  ConnectionString đồng bộ từ DatabaseConfig — do Bootstrap set
' ============================================================
Module modDB

    ' ── ConnectionString đồng bộ với DatabaseConfig ──────────
    Public ReadOnly Property ConnectionString As String
        Get
            Return DatabaseConfig.Database.ConnectionString
        End Get
    End Property

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    Public Function TestConnection() As Boolean
        Try
            Using conn = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function

    ' ── Helpers ──────────────────────────────────────────────
    Public Function SafeInt(o As Object) As Integer
        If o Is Nothing OrElse IsDBNull(o) Then Return 0
        Try : Return CInt(o) : Catch : Return 0 : End Try
    End Function

    Public Function SafeDec(o As Object) As Decimal
        If o Is Nothing OrElse IsDBNull(o) Then Return 0
        Try : Return CDec(o) : Catch : Return 0 : End Try
    End Function

    Public Function SafeStr(o As Object) As String
        If o Is Nothing OrElse IsDBNull(o) Then Return ""
        Return o.ToString().Trim()
    End Function

    Public Function FormatVND(amount As Decimal) As String
        If amount >= 1_000_000_000 Then Return (amount / 1_000_000_000).ToString("0.#") & " tỷ"
        If amount >= 1_000_000 Then Return (amount / 1_000_000).ToString("0.#") & " tr"
        Return amount.ToString("N0") & "đ"
    End Function

End Module

' ============================================================
'  modSession.vb — Thông tin phiên đăng nhập
' ============================================================
Module modSession
    Public CurrentUserId As Integer = 0
    Public CurrentEmployeeId As Integer = 0
    Public CurrentUser As String = "Admin"
    Public CurrentRole As Integer = 1
    Public DisplayName As String = "Quản trị viên"
End Module