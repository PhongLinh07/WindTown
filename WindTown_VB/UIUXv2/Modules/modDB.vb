Imports System.Data.SqlClient

' ============================================================
'  modDB.vb — Trợ lý kết nối & truy vấn Database
'  wind_town · pattern: JSON_VALUE(datas, '$.field')
' ============================================================
Module modDB

    ' ── Thay đổi để khớp môi trường thực tế ──────────────────
    Public ConnectionString As String =
        "Server=localhost;Database=wind_town;Integrated Security=True;MultipleActiveResultSets=True;"
    ' Nếu dùng SQL Auth:
    ' "Server=localhost;Database=wind_town;User Id=sa;Password=YourPwd;MultipleActiveResultSets=True;"

    ''' <summary>Tạo SqlConnection mới từ ConnectionString.</summary>
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    ''' <summary>Trả về giá trị đơn (scalar). Nothing nếu có lỗi hoặc không có dữ liệu.</summary>
    Public Function ExecScalar(sql As String) As Object
        Try
            Using conn = GetConnection()
                conn.Open()
                Using cmd = New SqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    Return If(IsDBNull(result), Nothing, result)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[modDB.ExecScalar] " & ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>Trả về DataTable từ câu SQL. DataTable rỗng nếu có lỗi.</summary>
    Public Function ExecTable(sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn = GetConnection()
                conn.Open()
                Using da = New SqlDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("[modDB.ExecTable] " & ex.Message)
        End Try
        Return dt
    End Function

    ''' <summary>Kiểm tra kết nối DB có thành công không.</summary>
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

    ''' <summary>Format tiền VNĐ — ví dụ: 4.200.000.000 → "4,2 tỷ"</summary>
    Public Function FormatVND(amount As Decimal) As String
        If amount >= 1_000_000_000 Then
            Return (amount / 1_000_000_000).ToString("0.#") & " tỷ"
        ElseIf amount >= 1_000_000 Then
            Return (amount / 1_000_000).ToString("0.#") & " tr"
        Else
            Return amount.ToString("N0")
        End If
    End Function

End Module

' ============================================================
'  modSession.vb — Thông tin phiên đăng nhập hiện tại
' ============================================================
Module modSession
    Public CurrentUserId As Integer = 0
    Public CurrentEmployeeId As Integer = 0
    Public CurrentUser As String = "Admin"
    Public CurrentRole As Integer = 1   ' 1 = Admin
    Public DisplayName As String = "Quản trị viên"
End Module