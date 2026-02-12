Public NotInheritable Class IdConverter

    ' ===== ID = 7  -> EMP-0000007 =====
    Public Shared Function ID_To_Code(prefix As String, id As Integer, Optional PadLength As Integer = 7) As String
        Return $"{prefix}-{id.ToString("D" & PadLength)}"
    End Function

    Public Shared Function Code_To_ID(code As String) As Integer
        If String.IsNullOrEmpty(code) Then Return 0

        Dim lastDashIndex As Integer = code.LastIndexOf("-"c)
        If lastDashIndex = -1 Then Return 0

        Dim numberPart As String = code.Substring(lastDashIndex + 1)

        ' VB cũng tự hiểu int.Parse("0000007") = 7
        Dim result As Integer
        If Integer.TryParse(numberPart, result) Then
            Return result
        End If

        Return 0
    End Function

End Class
