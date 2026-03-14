Public Class GenerateRandomNumbers
    Public Shared Function Generate(Optional length As Integer = 7) As String
        ' Dùng Static để tránh việc tạo mã trùng nhau khi gọi hàm quá nhanh trong vòng lặp
        Static rng As New Random()
        Dim result As String = ""

        For i As Integer = 1 To length
            result &= rng.Next(0, 10).ToString()
        Next

        Return result
    End Function
End Class
