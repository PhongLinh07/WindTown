Imports System.Linq

Partial Public Class formPolicy
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Function TryLoadPoliciesFromDatabase() As Boolean
        Dim res = AppServices.Instance.PolicySV.GetList()
        If Not res.IsSuccess OrElse res.Data Is Nothing Then Return False

        Dim lst = CType(res.Data, List(Of Policy))
        If lst.Count = 0 Then Return False

        _allPolicies.Clear()
        _policyEntityById.Clear()
        For Each pol In lst.OrderBy(Function(x) x.priority)
            _policyEntityById(pol.id) = pol
            Dim r As New PolicyRow()
            r.Id = pol.id
            r.Code = If(pol.code, "")
            r.Name = If(pol.name, "")
            r.Category = DbCategoryToUi(pol.category)
            r.DataSource = DbSourceToUi(pol.source)
            r.Aggregate = ClampAggIndex(pol.aggregate - 1)
            r.GenItem = ClampGenIndex(pol.gen_item - 1)
            r.Priority = pol.priority
            r.Status = pol.status
            r.Note = If(pol.note, "")
            r.Rule = If(pol.rule, "")
            _allPolicies.Add(r)
        Next
        _usePolicyDb = True
        Return True
    End Function

    Private Function ClampAggIndex(idx As Integer) As Integer
        Return Math.Max(0, Math.Min(idx, AGG_LABELS.Length - 1))
    End Function

    Private Function ClampGenIndex(idx As Integer) As Integer
        Return Math.Max(0, Math.Min(idx, GEN_LABELS.Length - 1))
    End Function

    Private Function DbCategoryToUi(cat As Integer) As Integer
        Select Case cat
            Case CInt(Category_PayItem.ID.INCOME), CInt(Category_PayItem.ID.ALLOWANCE),
                 CInt(Category_PayItem.ID.ATTENDANCE), CInt(Category_PayItem.ID.INFORMATION)
                Return 0
            Case CInt(Category_PayItem.ID.DEDUCTION), CInt(Category_PayItem.ID.TAX),
                 CInt(Category_PayItem.ID.INSURANCE)
                Return 1
            Case CInt(Category_PayItem.ID.BONUS)
                Return 2
            Case Else
                Return 3
        End Select
    End Function

    Private Function DbSourceToUi(src As Integer) As Integer
        If src = CInt(Data_Source.ID.ATTENDANCE) Then Return 1
        Return 4
    End Function

    Private Function UiCategoryToDb(ui As Integer) As Integer
        Select Case ui
            Case 0 : Return CInt(Category_PayItem.ID.INCOME)
            Case 1 : Return CInt(Category_PayItem.ID.DEDUCTION)
            Case 2 : Return CInt(Category_PayItem.ID.BONUS)
            Case Else : Return CInt(Category_PayItem.ID.ALLOWANCE)
        End Select
    End Function

    Private Function UiSourceToDb(ui As Integer) As Integer
        If ui = 1 Then Return CInt(Data_Source.ID.ATTENDANCE)
        Return CInt(Data_Source.ID.NONE)
    End Function

    Private Sub LoadMockPolicies()
        _allPolicies.Clear()

        Dim p1 As New PolicyRow()
        p1.Id = 1 : p1.Code = "POL001" : p1.Name = "Lương cơ bản"
        p1.Category = 0 : p1.DataSource = 0 : p1.Aggregate = 0 : p1.GenItem = 0
        p1.Priority = 1 : p1.Status = 1
        p1.Note = "Lương cơ bản từ hợp đồng × hệ số cấp bậc"
        p1.Rule = "{""formula"":""base_salary * salary_mult.mult"",""round"":1000,""min"":0}"
        _allPolicies.Add(p1)

        Dim p2 As New PolicyRow()
        p2.Id = 2 : p2.Code = "POL002" : p2.Name = "Thưởng chuyên cần"
        p2.Category = 2 : p2.DataSource = 1 : p2.Aggregate = 1 : p2.GenItem = 2
        p2.Priority = 2 : p2.Status = 1
        p2.Note = "Thưởng nếu không đi trễ và không vắng trong tháng"
        p2.Rule = "{""formula"":""IF(late_count=0 AND absent_count=0, 500000, 0)"",""round"":0,""min"":0}"
        _allPolicies.Add(p2)

        Dim p3 As New PolicyRow()
        p3.Id = 3 : p3.Code = "POL003" : p3.Name = "Khấu trừ đi trễ"
        p3.Category = 1 : p3.DataSource = 1 : p3.Aggregate = 1 : p3.GenItem = 3
        p3.Priority = 3 : p3.Status = 1
        p3.Note = "Trừ tiền theo tổng số giờ đi trễ trong kỳ"
        p3.Rule = "{""formula"":""-1 * SUM(late_hours) * hourly_rate"",""round"":1000,""max"":0}"
        _allPolicies.Add(p3)

        Dim p4 As New PolicyRow()
        p4.Id = 4 : p4.Code = "POL004" : p4.Name = "Phụ cấp ăn trưa"
        p4.Category = 3 : p4.DataSource = 0 : p4.Aggregate = 0 : p4.GenItem = 1
        p4.Priority = 4 : p4.Status = 1
        p4.Note = "Phụ cấp cố định 30.000đ × số ngày làm việc"
        p4.Rule = "{""formula"":""30000 * work_days"",""round"":0,""min"":0}"
        _allPolicies.Add(p4)

        Dim p5 As New PolicyRow()
        p5.Id = 5 : p5.Code = "POL005" : p5.Name = "Phụ cấp điện thoại"
        p5.Category = 3 : p5.DataSource = 0 : p5.Aggregate = 0 : p5.GenItem = 1
        p5.Priority = 5 : p5.Status = 1
        p5.Note = "Phụ cấp điện thoại cố định theo vị trí công việc"
        p5.Rule = "{""formula"":""job.phone_allowance"",""round"":0,""min"":0}"
        _allPolicies.Add(p5)

        Dim p6 As New PolicyRow()
        p6.Id = 6 : p6.Code = "POL006" : p6.Name = "BHXH người lao động"
        p6.Category = 1 : p6.DataSource = 0 : p6.Aggregate = 4 : p6.GenItem = 4
        p6.Priority = 6 : p6.Status = 1
        p6.Note = "8% lương đóng BHXH phần người lao động chịu"
        p6.Rule = "{""formula"":""-0.08 * base_salary"",""round"":0,""max"":0}"
        _allPolicies.Add(p6)

        Dim p7 As New PolicyRow()
        p7.Id = 7 : p7.Code = "POL007" : p7.Name = "BHYT người lao động"
        p7.Category = 1 : p7.DataSource = 0 : p7.Aggregate = 4 : p7.GenItem = 4
        p7.Priority = 7 : p7.Status = 1
        p7.Note = "1.5% lương đóng BHYT phần người lao động chịu"
        p7.Rule = "{""formula"":""-0.015 * base_salary"",""round"":0,""max"":0}"
        _allPolicies.Add(p7)

        Dim p8 As New PolicyRow()
        p8.Id = 8 : p8.Code = "POL008" : p8.Name = "Thưởng dự án"
        p8.Category = 2 : p8.DataSource = 3 : p8.Aggregate = 1 : p8.GenItem = 2
        p8.Priority = 8 : p8.Status = 0
        p8.Note = "Thưởng theo số dự án hoàn thành trong kỳ (tắt)"
        p8.Rule = "{""formula"":""COUNT(completed_projects) * 1000000"",""round"":0,""min"":0}"
        _allPolicies.Add(p8)
    End Sub

    Private Sub LoadMockPreview()
        _allPreview.Clear()

        Dim r1 As New PreviewRow()
        r1.Name = "Lương cơ bản" : r1.Category = 0 : r1.EmpCount = 230
        r1.Total = "3.45 tỷ" : r1.MinVal = "8 tr" : r1.MaxVal = "45 tr"
        r1.IsOk = True : r1.IsIncome = True
        _allPreview.Add(r1)

        Dim r2 As New PreviewRow()
        r2.Name = "Thưởng chuyên cần" : r2.Category = 2 : r2.EmpCount = 198
        r2.Total = "99 tr" : r2.MinVal = "0" : r2.MaxVal = "500k"
        r2.IsOk = True : r2.IsIncome = True
        _allPreview.Add(r2)

        Dim r3 As New PreviewRow()
        r3.Name = "Khấu trừ đi trễ" : r3.Category = 1 : r3.EmpCount = 47
        r3.Total = "-23.5 tr" : r3.MinVal = "-2.5 tr" : r3.MaxVal = "-150k"
        r3.IsOk = True : r3.IsIncome = False
        _allPreview.Add(r3)

        Dim r4 As New PreviewRow()
        r4.Name = "Phụ cấp ăn trưa" : r4.Category = 3 : r4.EmpCount = 230
        r4.Total = "138 tr" : r4.MinVal = "600k" : r4.MaxVal = "660k"
        r4.IsOk = True : r4.IsIncome = True
        _allPreview.Add(r4)

        Dim r5 As New PreviewRow()
        r5.Name = "Phụ cấp điện thoại" : r5.Category = 3 : r5.EmpCount = 85
        r5.Total = "51 tr" : r5.MinVal = "300k" : r5.MaxVal = "1 tr"
        r5.IsOk = True : r5.IsIncome = True
        _allPreview.Add(r5)

        Dim r6 As New PreviewRow()
        r6.Name = "BHXH người lao động" : r6.Category = 1 : r6.EmpCount = 230
        r6.Total = "-276 tr" : r6.MinVal = "-2.2 tr" : r6.MaxVal = "-3.6 tr"
        r6.IsOk = True : r6.IsIncome = False
        _allPreview.Add(r6)

        Dim r7 As New PreviewRow()
        r7.Name = "BHYT người lao động" : r7.Category = 1 : r7.EmpCount = 230
        r7.Total = "-51.75 tr" : r7.MinVal = "-413k" : r7.MaxVal = "-675k"
        r7.IsOk = True : r7.IsIncome = False
        _allPreview.Add(r7)

        Dim r8 As New PreviewRow()
        r8.Name = "Thưởng dự án" : r8.Category = 2 : r8.EmpCount = 0
        r8.Total = "—" : r8.MinVal = "—" : r8.MaxVal = "—"
        r8.IsOk = False : r8.IsIncome = True
        _allPreview.Add(r8)
    End Sub
End Class
