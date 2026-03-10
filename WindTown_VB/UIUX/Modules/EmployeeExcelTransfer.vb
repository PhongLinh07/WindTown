Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public NotInheritable Class EmployeeExcelTransfer

    Private Sub New()
    End Sub

    Public Class ImportEmployeesResult
        Public Property Total As Integer
        Public Property Inserted As Integer
        Public Property Updated As Integer
        Public Property Failed As Integer
    End Class

    Public Shared Function LoadToDataTable(filePath As String, ByRef table As DataTable, ByRef errorMessage As String) As Boolean
        table = Nothing
        errorMessage = Nothing

        If String.IsNullOrWhiteSpace(filePath) Then
            errorMessage = "Đường dẫn rỗng."
            Return False
        End If

        Dim ext = Path.GetExtension(filePath).ToLowerInvariant()

        Try
            If ext = ".csv" Then
                table = LoadCsvToDataTable(filePath)
                Return table IsNot Nothing
            End If

            Return TryLoadExcelToDataTable(filePath, table, errorMessage)
        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ImportEmployees(table As DataTable, employeeService As EmployeeService, existingByCode As Dictionary(Of String, Employee)) As ImportEmployeesResult
        Dim result As New ImportEmployeesResult()
        If table Is Nothing OrElse employeeService Is Nothing OrElse existingByCode Is Nothing Then
            Return result
        End If

        Dim map = BuildColumnMap(table)

        For Each row As DataRow In table.Rows
            result.Total += 1

            Try
                Dim code = GetCellString(row, map, "code")
                Dim name = GetCellString(row, map, "name")

                If String.IsNullOrWhiteSpace(code) OrElse String.IsNullOrWhiteSpace(name) Then
                    result.Failed += 1
                    Continue For
                End If

                code = code.Trim()
                name = name.Trim()

                Dim existing As Employee = Nothing
                existingByCode.TryGetValue(code, existing)

                If existing Is Nothing Then
                    Dim emp As New Employee()
                    emp.code = code
                    emp.name = name
                    ApplyOptionalEmployeeFields(emp, row, map)
                    If emp.status = 0 Then emp.status = 1

                    Dim resp = employeeService.Execute(DataIntent.Insert, emp)
                    If resp Is Nothing OrElse Not resp.IsSuccess Then
                        result.Failed += 1
                    Else
                        result.Inserted += 1
                    End If
                Else
                    Dim clone = Utils.DeepClone(existing)
                    clone.name = name
                    ApplyOptionalEmployeeFields(clone, row, map)

                    Dim resp = employeeService.Execute(DataIntent.Update, clone)
                    If resp Is Nothing OrElse Not resp.IsSuccess Then
                        result.Failed += 1
                    Else
                        result.Updated += 1
                    End If
                End If
            Catch
                result.Failed += 1
            End Try
        Next

        Return result
    End Function

    Public Shared Sub ExportNhanVienToXlsHtml(rows As IEnumerable(Of NhanVien), outputPath As String)
        If rows Is Nothing Then rows = New List(Of NhanVien)()
        If String.IsNullOrWhiteSpace(outputPath) Then Throw New ArgumentException("outputPath")

        Dim html = BuildEmployeeHtmlTable(rows)
        File.WriteAllText(outputPath, html, New UTF8Encoding(True))
    End Sub

    Private Shared Function TryLoadExcelToDataTable(filePath As String, ByRef table As DataTable, ByRef errorMessage As String) As Boolean
        table = Nothing
        errorMessage = Nothing

        Dim ext = Path.GetExtension(filePath).ToLowerInvariant()
        Dim connStr As String

        If ext = ".xlsx" Then
            connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"
        ElseIf ext = ".xls" Then
            connStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"";"
        Else
            errorMessage = "Chỉ hỗ trợ .xlsx/.xls/.csv"
            Return False
        End If

        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()

                Dim schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                If schema Is Nothing OrElse schema.Rows.Count = 0 Then
                    errorMessage = "Không tìm thấy sheet."
                    Return False
                End If

                Dim sheetName As String = Nothing
                For Each r As DataRow In schema.Rows
                    Dim name = Convert.ToString(r("TABLE_NAME"))
                    If Not String.IsNullOrWhiteSpace(name) AndAlso name.EndsWith("$", StringComparison.Ordinal) Then
                        sheetName = name
                        Exit For
                    End If
                Next
                If String.IsNullOrWhiteSpace(sheetName) Then sheetName = Convert.ToString(schema.Rows(0)("TABLE_NAME"))

                Dim sql = $"SELECT * FROM [{sheetName}]"
                Using da As New OleDbDataAdapter(sql, conn)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    table = dt
                End Using
            End Using

            Return table IsNot Nothing
        Catch ex As Exception
            errorMessage = ex.Message & " (Có thể máy thiếu driver ACE/JET để đọc Excel)"
            Return False
        End Try
    End Function

    Private Shared Function LoadCsvToDataTable(filePath As String) As DataTable
        Dim dt As New DataTable()

        Using parser As New TextFieldParser(filePath, New UTF8Encoding(True))
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",", ";", vbTab)
            parser.HasFieldsEnclosedInQuotes = True

            If parser.EndOfData Then Return dt

            Dim headers = parser.ReadFields()
            If headers Is Nothing Then Return dt

            For Each h In headers
                dt.Columns.Add(If(h, String.Empty))
            Next

            While Not parser.EndOfData
                Dim fields = parser.ReadFields()
                If fields Is Nothing Then Continue While

                Dim row = dt.NewRow()
                For i As Integer = 0 To Math.Min(fields.Length, dt.Columns.Count) - 1
                    row(i) = fields(i)
                Next

                dt.Rows.Add(row)
            End While
        End Using

        Return dt
    End Function

    Private Shared Function BuildColumnMap(table As DataTable) As Dictionary(Of String, String)
        Dim map As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        If table Is Nothing Then Return map

        For Each col As DataColumn In table.Columns
            Dim normalized = NormalizeHeader(col.ColumnName)
            If String.IsNullOrWhiteSpace(normalized) Then Continue For

            If normalized.Contains("ma") AndAlso normalized.Contains("nhan") Then
                map("code") = col.ColumnName
            ElseIf normalized = "code" OrElse normalized = "manv" OrElse normalized = "employee_code" Then
                map("code") = col.ColumnName
            ElseIf normalized.Contains("ten") AndAlso normalized.Contains("nhan") Then
                map("name") = col.ColumnName
            ElseIf normalized = "name" OrElse normalized = "ten" OrElse normalized = "employee_name" Then
                map("name") = col.ColumnName
            ElseIf normalized.Contains("email") Then
                map("email") = col.ColumnName
            ElseIf normalized.Contains("phone") OrElse normalized.Contains("dienthoai") OrElse normalized.Contains("sdt") Then
                map("phone") = col.ColumnName
            ElseIf normalized.Contains("gioitinh") OrElse normalized.Contains("gender") Then
                map("gender") = col.ColumnName
            ElseIf normalized.Contains("diachi") OrElse normalized.Contains("address") Then
                map("address") = col.ColumnName
            ElseIf normalized.Contains("cccd") Then
                map("cccd") = col.ColumnName
            ElseIf normalized.Contains("ngaysinh") OrElse normalized.Contains("birth") Then
                map("birth_date") = col.ColumnName
            ElseIf normalized.Contains("bank") OrElse normalized.Contains("nganhang") Then
                map("bank") = col.ColumnName
            ElseIf normalized.Contains("note") OrElse normalized.Contains("ghichu") Then
                map("note") = col.ColumnName
            ElseIf normalized.Contains("trangthai") OrElse normalized.Contains("status") Then
                map("status") = col.ColumnName
            End If
        Next

        Return map
    End Function

    Private Shared Function NormalizeHeader(text As String) As String
        If text Is Nothing Then Return String.Empty

        Dim s = text.Trim().ToLowerInvariant()
        s = s.Replace("đ", "d")

        Dim sb As New StringBuilder()
        For Each ch In s
            If Char.IsLetterOrDigit(ch) Then
                sb.Append(ch)
            End If
        Next

        Return sb.ToString()
    End Function

    Private Shared Function GetCellString(row As DataRow, map As Dictionary(Of String, String), key As String) As String
        If row Is Nothing OrElse map Is Nothing Then Return String.Empty

        Dim colName As String = Nothing
        If Not map.TryGetValue(key, colName) Then Return String.Empty

        If String.IsNullOrWhiteSpace(colName) OrElse Not row.Table.Columns.Contains(colName) Then Return String.Empty

        Dim val = row(colName)
        If val Is Nothing OrElse val Is DBNull.Value Then Return String.Empty

        Return Convert.ToString(val)
    End Function

    Private Shared Sub ApplyOptionalEmployeeFields(emp As Employee, row As DataRow, map As Dictionary(Of String, String))
        Dim email = GetCellString(row, map, "email")
        If Not String.IsNullOrWhiteSpace(email) Then emp.email = email.Trim()

        Dim phone = GetCellString(row, map, "phone")
        If Not String.IsNullOrWhiteSpace(phone) Then emp.phone = phone.Trim()

        Dim address = GetCellString(row, map, "address")
        If Not String.IsNullOrWhiteSpace(address) Then emp.address = address.Trim()

        Dim cccd = GetCellString(row, map, "cccd")
        If Not String.IsNullOrWhiteSpace(cccd) Then emp.cccd = cccd.Trim()

        Dim bank = GetCellString(row, map, "bank")
        If Not String.IsNullOrWhiteSpace(bank) Then emp.bank = bank.Trim()

        Dim note = GetCellString(row, map, "note")
        If Not String.IsNullOrWhiteSpace(note) Then emp.note = note.Trim()

        Dim genderRaw = GetCellString(row, map, "gender")
        Dim genderValue As Integer
        If TryParseGender(genderRaw, genderValue) Then emp.gender = genderValue

        Dim statusRaw = GetCellString(row, map, "status")
        Dim statusValue As Integer
        If TryParseStatus(statusRaw, statusValue) Then emp.status = statusValue

        Dim birthRaw = GetCellString(row, map, "birth_date")
        Dim birthDate As DateTime
        If TryParseDate(birthRaw, birthDate) Then emp.birth_date = birthDate
    End Sub

    Private Shared Function TryParseGender(raw As String, ByRef value As Integer) As Boolean
        value = 0
        If String.IsNullOrWhiteSpace(raw) Then Return False

        Dim s = raw.Trim().ToLowerInvariant()
        If s = "1" OrElse s = "nam" OrElse s = "male" Then
            value = 1
            Return True
        End If

        If s = "0" OrElse s = "nu" OrElse s = "nữ" OrElse s = "female" Then
            value = 0
            Return True
        End If

        Return False
    End Function

    Private Shared Function TryParseStatus(raw As String, ByRef value As Integer) As Boolean
        value = 0
        If String.IsNullOrWhiteSpace(raw) Then Return False

        Dim s = raw.Trim().ToLowerInvariant()
        If s = "1" OrElse s.Contains("dang") OrElse s.Contains("active") Then
            value = 1
            Return True
        End If

        If s = "0" OrElse s.Contains("ngung") OrElse s.Contains("inactive") Then
            value = 0
            Return True
        End If

        Return False
    End Function

    Private Shared Function TryParseDate(raw As String, ByRef value As DateTime) As Boolean
        value = DateTime.MinValue
        If String.IsNullOrWhiteSpace(raw) Then Return False

        Dim s = raw.Trim()
        Dim formats = New String() {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy", "yyyy-MM-dd"}

        Return DateTime.TryParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, value) OrElse DateTime.TryParse(s, value)
    End Function

    Private Shared Function BuildEmployeeHtmlTable(rows As IEnumerable(Of NhanVien)) As String
        Dim sb As New StringBuilder()

        sb.AppendLine("<html><head><meta charset='UTF-8'/>")
        sb.AppendLine("<style>table{border-collapse:collapse;}td,th{border:1px solid #000;padding:4px;}th{background:#f0f0f0;}</style>")
        sb.AppendLine("</head><body>")
        sb.AppendLine($"<h3>Danh sách nhân sự ({DateTime.Now:dd-MM-yyyy HH:mm})</h3>")
        sb.AppendLine("<table>")
        sb.AppendLine("<tr><th>Mã NV</th><th>Tên NV</th><th>Email</th><th>Điện thoại</th><th>Giới tính</th><th>Bộ phận</th><th>Chức vụ</th><th>Trạng thái</th><th>Ngày bắt đầu</th></tr>")

        For Each r In rows
            sb.Append("<tr>")
            sb.Append($"<td>{EscapeHtml(r.Code)}</td>")
            sb.Append($"<td>{EscapeHtml(r.Name)}</td>")
            sb.Append($"<td>{EscapeHtml(r.Email)}</td>")
            sb.Append($"<td>{EscapeHtml(r.Phone)}</td>")
            sb.Append($"<td>{EscapeHtml(r.Gender)}</td>")
            sb.Append($"<td>{EscapeHtml(r.DepartmentName)}</td>")
            sb.Append($"<td>{EscapeHtml(r.JobName)}</td>")
            sb.Append($"<td>{EscapeHtml(r.Status)}</td>")
            sb.Append($"<td>{EscapeHtml(r.StartDate)}</td>")
            sb.AppendLine("</tr>")
        Next

        sb.AppendLine("</table>")
        sb.AppendLine("</body></html>")

        Return sb.ToString()
    End Function

    Private Shared Function EscapeHtml(text As String) As String
        If text Is Nothing Then Return String.Empty

        Return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;")
    End Function

End Class





