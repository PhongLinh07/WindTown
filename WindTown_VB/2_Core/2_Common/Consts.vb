Imports System.Text.RegularExpressions

'Public Enum DataIntent
'    GetList        ' Lấy danh sách tất cả bản ghi chưa bị xóa | status != -1
'    GetById        ' Lấy 1 bản ghi
'    Insert         ' Thêm mới
'    Update         ' Cập nhật
'    'SoftDelete     ' Xóa tạm
'    SoftDeleteMany ' Xóa tạm nhiều bản ghi

'#Region "'Employee Custom Intent"
'    GetEmployeesWithoutContract ' Những nhân viên đang ko có hợp đồng nào Active
'    GetEmployeesWithoutAccount  ' Những nhân viên đang ko có tài khoản nào Active
'    GetContractsWithoutPosition  ' Những Hợp đồng Active đang ko có vị trí nào Active 
'#End Region

'#Region "'Position Custom Intent"
'    GetProjectsIsActive ' Những dự án đang trong tiến trình hoạt động | status != (-1.delete, 0.jected,3.complete )
'    GetPositionsWithoutAssignment ' Những Position đang ko có Phân công nào Active
'#End Region

'#Region "'Account Custom Intent"
'    Login
'    GetAccountByUsername 'lấy thông tin tài khoản bằng user
'#End Region

'#Region "'Pay_Item Custom Intent"
'    GetPayItemByPayroll 'lấy các khoản tiền theo payroll
'#End Region

'#Region "'Pay_Period Custom Intent"
'    StandardHoursCalculator 'Tính số giờ hành chính của chu kỳ
'#End Region
'#Region "'Payroll Custom Intent"
'    Init_Payrolls 'Khởi tạo các bảng lương theo hợp đòng đang hoạt động
'    GetPayrollByPeriod ' Lấy bảng lưuong theo chu kỳ
'    Aggregation_Data_One_Payroll ' Tổng hợp dữ liệu cho 1 bảng lương
'    Aggregation_Data_One_Period ' Tổng hượp dữ liệu cho 1 kỳ lương (nhiều bảng lương)
'    Cal_Net_Salary_One_Payroll ' Tính lương cho 1 bảng lương theo kỳ lương
'    Cal_Net_Salary_One_Period ' Tính lương cho 1 chu kỳ lương (nhiều bảng lương)

'#End Region

'#Region "'Salary_Mult Custom Intent"
'    GetSalaryMultItemByJob 'lấy dải hệ số theo công việc
'#End Region

'#Region "'Attendance Custom Intent"
'    GetAttendanceByPeriod 'lấy chấm công theo chu kỳ
'#End Region


'End Enum


Public NotInheritable Class Display_Field
    Public Enum Status
        Active = 1
        Inactive = 0
        Deleted = -1
    End Enum
End Class


Public NotInheritable Class System_Parameter

    Public Enum ID
        'biến toàn cục : khởi tạo 1 lần, dùng chung cho toàn bộ quá trình
        SYS_STD_HOURS = 1
        SYS_BASE_SALARY = 2
        SYS_SALARY_MULT = 3
        'Biến cục bộ : Là thuộc tính của chung trong dữ liệu nguồn : Atendance
        SYS_OFFICE_HOURS = 4
        SYS_OVERTIME_HOURS = 5
        SYS_LATE_HOURS = 6
        SYS_EARLY_LEAVE_HOURS = 7
        SYS_SHIFT = 8
        SYS_IS_HOLIDAY = 9
        SYS_MULT_HOLIDAY = 10

        '
        SYS_TOTAL_INCOME = 20
        SYS_TAX_AMOUNT = 30
        SYS_DEDUCTION = 40
        SYS_NET_SALARY = 50

    End Enum

    Private Shared ReadOnly Dict As New Dictionary(Of ID, BaseParameter) From {
            {ID.SYS_STD_HOURS, New BaseParameter With {.code = "SYS_STD_HOURS", .name = "Giờ công chuẩn", .resource = "pay_period", .note = "Tổng số giờ làm việc tiêu chuẩn của tháng"}},
            {ID.SYS_BASE_SALARY, New BaseParameter With {.code = "SYS_BASE_SALARY", .name = "Lương cơ bản", .resource = "contract", .note = "Mức lương chính trong hợp đồng"}},
            {ID.SYS_SALARY_MULT, New BaseParameter With {.code = "SYS_SALARY_MULT", .name = "Hệ số lương", .resource = "position", .note = "Hệ số lương trong chức vụ"}},
            {ID.SYS_OFFICE_HOURS, New BaseParameter With {.code = "SYS_OFFICE_HOURS", .name = "Giờ hành chính", .resource = "attendance", .note = "Số giờ làm việc trong ca"}},
            {ID.SYS_OVERTIME_HOURS, New BaseParameter With {.code = "SYS_OVERTIME_HOURS", .name = "Giờ tăng ca", .resource = "attendance", .note = "Số giờ làm thêm"}},
            {ID.SYS_LATE_HOURS, New BaseParameter With {.code = "SYS_LATE_HOURS", .name = "Giờ đi trễ", .resource = "attendance", .note = "Số giờ đi trễ"}},
            {ID.SYS_EARLY_LEAVE_HOURS, New BaseParameter With {.code = "SYS_EARLY_LEAVE_HOURS", .name = "Giờ về sớm", .resource = "attendance", .note = "Số giờ về sớm"}},
            {ID.SYS_SHIFT, New BaseParameter With {.code = "SYS_SHIFT", .name = "Ca làm việc", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_IS_HOLIDAY, New BaseParameter With {.code = "SYS_IS_HOLIDAY", .name = "Là ngày lễ", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_MULT_HOLIDAY, New BaseParameter With {.code = "SYS_DAY_MULT_HOLIDAY", .name = "Hệ số ngày lễ", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_TOTAL_INCOME, New BaseParameter With {.code = "SYS_TOTAL_INCOME", .name = "Tổng thu nhập", .resource = "attendance", .category = CInt(Category_PayItem.ID.INCOME), .unit = CInt(UnitSuffix.ID.VND), .priority = 70, .note = ""}},
            {ID.SYS_TAX_AMOUNT, New BaseParameter With {.code = "SYS_TAX_AMOUNT", .name = "Tổng thuế", .resource = "attendance", .category = CInt(Category_PayItem.ID.TAX), .unit = CInt(UnitSuffix.ID.VND), .priority = 80, .note = ""}},
            {ID.SYS_DEDUCTION, New BaseParameter With {.code = "SYS_DEDUCTION", .name = "Tổng khấu trừ", .resource = "attendance", .category = CInt(Category_PayItem.ID.DEDUCTION), .unit = CInt(UnitSuffix.ID.VND), .priority = 90, .note = ""}},
            {ID.SYS_NET_SALARY, New BaseParameter With {.code = "SYS_NET_SALARY", .name = "Thực lĩnh", .resource = "attendance", .category = CInt(Category_PayItem.ID.INCOME), .unit = CInt(UnitSuffix.ID.VND), .priority = 100, .note = ""}}
        }

    Public Shared Function GetParameter(id As ID) As BaseParameter
        If Dict.ContainsKey(id) Then
            Return Dict(id)
        End If
        Return Nothing
    End Function

    Public Shared Function GetParameter(id As Integer) As BaseParameter
        Return GetParameter(CType(id, ID))
    End Function

    Public Shared Function IsSystemParameter(code As String) As Boolean

        If String.IsNullOrEmpty(code) Then Return False

        ' kiểm tra prefix
        If code.Trim().ToUpper().StartsWith("SYS_") Then Return True

        ' kiểm tra trong dict
        Return Dict.Values.Any(Function(p) p.code = code.Trim().ToUpper())

    End Function

End Class


Public NotInheritable Class Category_PayItem
    Public Enum ID
        INFORMATION = 1
        ATTENDANCE = 2
        INCOME = 3
        DEDUCTION = 4
        ALLOWANCE = 5
        BONUS = 6
        INSURANCE = 7
        TAX = 8
    End Enum

    ' ── Dict dùng ID (enum) ──────────────────────────────
    Public Shared ReadOnly Dict As New Dictionary(Of ID, BaseParameter) From {
        {ID.INFORMATION, New BaseParameter With {.code = "INFORMATION", .name = "Thông tin", .sign = 0}},
        {ID.ATTENDANCE, New BaseParameter With {.code = "ATTENDANCE", .name = "Chấm công", .sign = 0}},
        {ID.INCOME, New BaseParameter With {.code = "INCOME", .name = "Thu nhập", .sign = 1}},
        {ID.DEDUCTION, New BaseParameter With {.code = "DEDUCTION", .name = "Khấu trừ", .sign = -1}},
        {ID.ALLOWANCE, New BaseParameter With {.code = "ALLOWANCE", .name = "Phụ cấp", .sign = 1}},
        {ID.BONUS, New BaseParameter With {.code = "BONUS", .name = "Thưởng", .sign = 1}},
        {ID.INSURANCE, New BaseParameter With {.code = "INSURANCE", .name = "Bảo hiểm", .sign = -1}},
        {ID.TAX, New BaseParameter With {.code = "TAX", .name = "Thuế", .sign = -1}}
    }

    ' ── Bind ComboBox — từ Dict gốc, không cần Dict_UI ──
    Public Shared Dict_UI As Dictionary(Of Integer, String) = Dict.ToDictionary(Function(kv) CInt(kv.Key), Function(kv) kv.Value.name)

    Public Shared Function GetParameter(id As ID) As BaseParameter
        If Dict.ContainsKey(id) Then Return Dict(id)
        Return Nothing
    End Function

    Public Shared Function GetParameter(id As Integer) As BaseParameter
        Return GetParameter(CType(id, ID))
    End Function

    ' ── Sign — dùng khi tính NET_SALARY ─────────────────
    Public Shared Function GetSign(id As Integer) As Integer
        Dim p = GetParameter(id)
        Return If(p IsNot Nothing, p.sign, 0)
    End Function

    ' ── Format — dùng khi hiển thị Pay_Item ─────────────

End Class

Public NotInheritable Class Aggregate_Func
    Public Enum ID
        SET_DATA = 1
        SUM = 2
        MAX = 3
        MIN = 4
        COUNT = 5
    End Enum

    Private Shared ReadOnly Dict As New Dictionary(Of ID, BaseParameter) From {
            {ID.SET_DATA, New BaseParameter With {.id = 1, .code = "SET", .name = "Gán dữ lệu"}},
            {ID.SUM, New BaseParameter With {.id = 2, .code = "SUM", .name = "Tính tổng dữ liệu"}},
            {ID.MAX, New BaseParameter With {.id = 3, .code = "MAX", .name = "Tìm dữ liệu lớn nhất"}},
            {ID.MIN, New BaseParameter With {.id = 4, .code = "MIN", .name = "Tìm dữ liệu nhỏ nhất"}},
            {ID.COUNT, New BaseParameter With {.id = 5, .code = "COUNT", .name = "Đếm số dòng số liệu"}}
        }

    Public Shared Dict_UI As Dictionary(Of Integer, String) = Dict.ToDictionary(Function(kv) CInt(kv.Key), Function(kv) $"{kv.Value.code} ({kv.Value.name})")

    Public Shared Function GetParameter(id As ID) As BaseParameter
        If Dict.ContainsKey(id) Then
            Return Dict(id)
        End If
        Return Nothing
    End Function

    Public Shared Function GetParameter(id As Integer) As BaseParameter
        Return GetParameter(CType(id, ID))
    End Function
End Class


Public NotInheritable Class Data_Source

    Public Enum ID
        NONE = 1
        ATTENDANCE = 2
    End Enum

    Private Shared ReadOnly Dict As New Dictionary(Of ID, BaseParameter) From {
            {ID.NONE, New BaseParameter With {.id = 1, .code = "NONE", .name = "*"}},
            {ID.ATTENDANCE, New BaseParameter With {.id = 1, .code = "SRC_ATTENDANCE", .name = "Chấm công"}}
        }
    Public Shared Dict_UI As Dictionary(Of Integer, String) = Dict.ToDictionary(Function(kv) CInt(kv.Key), Function(kv) kv.Value.code)



    Public Shared Function GetParameter(id As ID) As BaseParameter
        If Dict.ContainsKey(id) Then
            Return Dict(id)
        End If
        Return Nothing
    End Function

    Public Shared Function GetParameter(id As Integer) As BaseParameter
        Return GetParameter(CType(id, ID))
    End Function

    Public Shared Function GetDataSourceByRule(rule As String) As Integer
        Dim dictVars As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase) From {
            {System_Parameter.ID.SYS_OFFICE_HOURS.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_OVERTIME_HOURS.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_LATE_HOURS.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_EARLY_LEAVE_HOURS.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_SHIFT.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_IS_HOLIDAY.ToString(), CInt(ID.ATTENDANCE)},
            {System_Parameter.ID.SYS_MULT_HOLIDAY.ToString(), CInt(ID.ATTENDANCE)}
        }

        Dim tokens = Regex.Matches(rule, "[A-Za-z_][A-Za-z0-9_]*")
        For Each m As Match In tokens
            Dim source As Integer
            If dictVars.TryGetValue(m.Value, source) Then
                Return source  ' tìm thấy → trả về ngay
            End If
        Next

        Return CInt(ID.NONE)  ' không tìm thấy → ONCE
    End Function


End Class


Public NotInheritable Class UnitSuffix
    Public Enum ID
        NONE = 1   ' không có suffix — hiển thị số thuần
        VND = 2    ' ₫
        HOUR = 3   ' h
        DAY = 4    ' ngày
        TIMES = 5  ' x  (hệ số)
        PERCENT = 6 ' %
    End Enum

    Public Shared ReadOnly Dict As New Dictionary(Of ID, String) From {
        {ID.NONE, ""},
        {ID.VND, " ₫"},
        {ID.HOUR, " h"},
        {ID.DAY, " ngày"},
        {ID.TIMES, "x"},
        {ID.PERCENT, "%"}
    }
    Public Shared Dict_UI As Dictionary(Of Integer, String) = Dict.ToDictionary(Function(kv) CInt(kv.Key), Function(kv) kv.Value)

    Public Shared Function GetSuffix(id As Integer) As String
        Dim key = CType(id, ID)
        If Dict.ContainsKey(key) Then Return Dict(key)
        Return ""
    End Function

    Public Shared Function FomatNumber(value As Decimal, Optional unit As Integer = 0) As String
        ' Có unit → dùng unit

        Dim suffix = UnitSuffix.GetSuffix(unit)
        Select Case CType(unit, UnitSuffix.ID)
            Case UnitSuffix.ID.VND : Return value.ToString("N0") & suffix
            Case UnitSuffix.ID.HOUR : Return value.ToString("N1") & suffix
            Case UnitSuffix.ID.DAY : Return value.ToString("N1") & suffix
            Case UnitSuffix.ID.TIMES : Return value.ToString("N2") & suffix
            Case UnitSuffix.ID.PERCENT : Return value.ToString("N1") & suffix
            Case Else : Return value.ToString() & suffix
        End Select

    End Function

End Class



