Imports System.Drawing
Imports System.Linq

Partial Public Class formPayroll
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub LoadMockPeriods()
        _allPeriods.Clear()

        Dim p1 As New PeriodRow()
        p1.Id = 1 : p1.Code = "PP2026-03" : p1.Name = "Lương tháng 3/2026"
        p1.StartDate = #3/1/2026# : p1.EndDate = #3/31/2026#
        p1.Month = #3/1/2026# : p1.StdHours = 176 : p1.Status = 1
        p1.Note = "Kỳ lương tháng 3 năm 2026"
        _allPeriods.Add(p1)

        Dim p2 As New PeriodRow()
        p2.Id = 2 : p2.Code = "PP2026-02" : p2.Name = "Lương tháng 2/2026"
        p2.StartDate = #2/1/2026# : p2.EndDate = #2/28/2026#
        p2.Month = #2/1/2026# : p2.StdHours = 160 : p2.Status = 2
        p2.Note = "Kỳ lương tháng 2 năm 2026"
        _allPeriods.Add(p2)

        Dim p3 As New PeriodRow()
        p3.Id = 3 : p3.Code = "PP2026-01" : p3.Name = "Lương tháng 1/2026"
        p3.StartDate = #1/1/2026# : p3.EndDate = #1/31/2026#
        p3.Month = #1/1/2026# : p3.StdHours = 184 : p3.Status = 2
        p3.Note = "Kỳ lương tháng 1 năm 2026"
        _allPeriods.Add(p3)
    End Sub

    Private Sub LoadMockPayrolls()
        _allPayrolls.Clear()

        Dim rows(,) As Object = {
            {1, "Nguyễn Văn An", "EMP001", "Kỹ thuật", "Lập trình viên", 15000000D, 17500000D, 1875000D, True},
            {2, "Trần Thị Bình", "EMP002", "Kế toán", "Kế toán trưởng", 28000000D, 31000000D, 3300000D, True},
            {3, "Lê Văn Cường", "EMP003", "Nhân sự", "Chuyên viên NS", 14000000D, 15400000D, 1650000D, True},
            {4, "Phạm Thị Dung", "EMP004", "Marketing", "Marketing Manager", 22000000D, 25200000D, 2700000D, True},
            {5, "Hoàng Văn Em", "EMP005", "Kinh doanh", "Sales Executive", 12000000D, 14800000D, 1560000D, False},
            {6, "Vũ Thị Phương", "EMP006", "Kỹ thuật", "QA Engineer", 18000000D, 20200000D, 2160000D, True},
            {7, "Đặng Văn Giang", "EMP007", "Vận hành", "Ops Manager", 24000000D, 27600000D, 2940000D, True},
            {8, "Bùi Thị Hoa", "EMP008", "Kỹ thuật", "Frontend Dev", 10000000D, 11200000D, 1200000D, True}
        }

        Dim i As Integer
        For i = 0 To rows.GetUpperBound(0)
            Dim r As New PayrollRow()
            r.Id = CInt(rows(i, 0))
            r.EmpName = CStr(rows(i, 1))
            r.EmpCode = CStr(rows(i, 2))
            r.Dept = CStr(rows(i, 3))
            r.Job = CStr(rows(i, 4))
            r.BaseSalary = CDec(rows(i, 5))
            r.TotalIncome = CDec(rows(i, 6))
            r.TotalDeduct = CDec(rows(i, 7))
            r.NetSalary = r.TotalIncome - r.TotalDeduct
            r.IsDone = CBool(rows(i, 8))
            Dim pal = ThemeColors.AvatarPalette
            r.AvatarColor = pal(r.Id Mod pal.Length)
            _allPayrolls.Add(r)
        Next
    End Sub

    Private Sub LoadMockPayItems()
        _payItems.Clear()

        ' EMP001
        Dim items1 As New List(Of PayItemRow)()
        items1.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = 15000000D, .Category = 0})
        items1.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
        items1.Add(New PayItemRow() With {.Code = "PI003", .Name = "Phụ cấp điện thoại", .Value = 500000D, .Category = 3})
        items1.Add(New PayItemRow() With {.Code = "PI004", .Name = "Thưởng chuyên cần", .Value = 500000D, .Category = 2})
        items1.Add(New PayItemRow() With {.Code = "PI005", .Name = "Thưởng KPI tháng", .Value = 840000D, .Category = 2})
        items1.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -1200000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -225000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI008", .Name = "BHTN người lao động", .Value = -150000D, .Category = 4})
        items1.Add(New PayItemRow() With {.Code = "PI009", .Name = "Khấu trừ đi trễ", .Value = -300000D, .Category = 1})
        _payItems(1) = items1

        ' EMP002
        Dim items2 As New List(Of PayItemRow)()
        items2.Add(New PayItemRow() With {.Code = "PI001", .Name = "Lương cơ bản", .Value = 28000000D, .Category = 0})
        items2.Add(New PayItemRow() With {.Code = "PI002", .Name = "Phụ cấp ăn trưa", .Value = 660000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI003", .Name = "Phụ cấp điện thoại", .Value = 1000000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI004", .Name = "Thưởng chuyên cần", .Value = 500000D, .Category = 2})
        items2.Add(New PayItemRow() With {.Code = "PI005", .Name = "Phụ cấp quản lý", .Value = 840000D, .Category = 3})
        items2.Add(New PayItemRow() With {.Code = "PI006", .Name = "BHXH người lao động", .Value = -2240000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI007", .Name = "BHYT người lao động", .Value = -420000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI008", .Name = "BHTN người lao động", .Value = -280000D, .Category = 4})
        items2.Add(New PayItemRow() With {.Code = "PI009", .Name = "Thuế TNCN tạm tính", .Value = -360000D, .Category = 1})
        _payItems(2) = items2
    End Sub

    Private Function TryLoadPeriodsFromDatabase() As Boolean
        Dim res = AppServices.Instance.Pay_PeriodSV.GetList()
        If Not res.IsSuccess OrElse res.Data Is Nothing Then Return False

        Dim lst = CType(res.Data, List(Of Pay_Period))
        If lst.Count = 0 Then Return False

        _allPeriods.Clear()
        _periodById.Clear()
        For Each pp In lst.OrderByDescending(Function(x) x.start_date)
            Dim row As New PeriodRow()
            row.Id = pp.id
            row.Code = If(pp.code, "")
            row.Name = If(pp.name, row.Code)
            row.StartDate = pp.start_date.Date
            row.EndDate = pp.end_date.Date
            row.Month = If(pp.month.HasValue, pp.month.Value, pp.start_date)
            row.StdHours = pp.std_hours
            row.Note = If(pp.note, "")
            row.Status = If(pp.status = Pay_Period.status_closed, 2, 1)
            _allPeriods.Add(row)
            _periodById(pp.id) = pp
        Next

        _selPeriodId = _allPeriods(0).Id
        Return True
    End Function

    Private Sub LoadPayrollsForCurrentPeriodFromDatabase()
        _allPayrolls.Clear()
        _payItems.Clear()

        Dim period As Pay_Period = Nothing
        If Not _periodById.TryGetValue(_selPeriodId, period) Then Return

        Dim res = AppServices.Instance.PayrollSV.GetByPeriod(period)
        If Not res.IsSuccess OrElse res.Data Is Nothing Then Return

        Dim pal = ThemeColors.AvatarPalette
        Dim idx As Integer = 0
        For Each pr In CType(res.Data, List(Of Payroll))
            Dim row As New PayrollRow()
            row.Id = pr.id
            row.EmpName = If(pr.employee_UI, "---")
            Dim emp = pr.Position?.Contract?.Employee
            row.EmpCode = If(emp?.code, "")
            row.Dept = If(pr.Position?.Salary_Mult?.Job?.Department?.name, "---")
            row.Job = If(pr.job_UI, "---")
            row.BaseSalary = If(pr.Position?.Contract?.base_salary, 0D)

            Dim items As List(Of Pay_Item) = If(pr.Pay_Items, New List(Of Pay_Item)()).Where(Function(x) x.status <> -1).ToList()
            Dim posSum As Decimal = 0
            Dim negSum As Decimal = 0
            For Each pi In items
                Dim s = Category_PayItem.GetSign(pi.category)
                If s > 0 Then posSum += pi.value
                If s < 0 Then negSum += pi.value
            Next
            row.TotalIncome = posSum
            row.TotalDeduct = negSum
            row.NetSalary = posSum - negSum
            row.IsDone = (pr.status = Payroll.status_closed)
            row.AvatarColor = pal(idx Mod pal.Length)
            idx += 1
            _allPayrolls.Add(row)

            Dim slip As New List(Of PayItemRow)()
            For Each pi In items
                Dim signed = CDec(Category_PayItem.GetSign(pi.category)) * pi.value
                slip.Add(New PayItemRow With {
                    .Code = If(pi.code, ""),
                    .Name = If(pi.name, ""),
                    .Value = signed,
                    .Category = MapPayItemCategory(pi.category)
                })
            Next
            _payItems(pr.id) = slip
        Next

        _filteredPayrolls = New List(Of PayrollRow)(_allPayrolls)
        ApplyFilter()
        RenderSlipEmpList()
        If _allPayrolls.Count > 0 Then
            SelectEmployee(_allPayrolls(0).Id)
        End If
    End Sub

    Private Shared Function MapPayItemCategory(cat As Integer) As Integer
        Select Case cat
            Case CInt(Category_PayItem.ID.DEDUCTION), CInt(Category_PayItem.ID.TAX), CInt(Category_PayItem.ID.INSURANCE)
                Return 1
            Case CInt(Category_PayItem.ID.BONUS)
                Return 2
            Case CInt(Category_PayItem.ID.ALLOWANCE)
                Return 3
            Case CInt(Category_PayItem.ID.INCOME)
                Return 0
            Case Else
                Return 0
        End Select
    End Function

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORMAT HELPERS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Function FmtM(amount As Decimal) As String
        Dim a = Math.Abs(amount)
        Dim sign = If(amount < 0, "-", "")
        If a >= 1000000000D Then Return sign & (a / 1000000000D).ToString("0.#") & " tỷ"
        If a >= 1000000D Then Return sign & (a / 1000000D).ToString("0.#") & " tr"
        Return sign & a.ToString("N0") & "đ"
    End Function

    Private Function FmtVND(amount As Decimal) As String
        If amount < 0 Then
            Return "-" & Math.Abs(amount).ToString("N0") & "đ"
        End If
        Return amount.ToString("N0") & "đ"
    End Function

    Private Function GetInitials(name As String) As String
        If String.IsNullOrWhiteSpace(name) Then Return "NV"
        Dim parts = name.Trim().Split(" "c)
        If parts.Length >= 2 Then
            Return (parts(0)(0).ToString() & parts(parts.Length - 1)(0).ToString()).ToUpper()
        End If
        Return name.Substring(0, Math.Min(2, name.Length)).ToUpper()
    End Function
End Class
