Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

Public Class PolicyParameter
    Inherits BaseEntity
    Public Sub New()
        code = ""
        name = ""
        resource = 1
        sign = 1
        note = ""

    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Tham số")> <Display(Order:=2)>
    Public Property code As String

    <Write(False)> <DisplayName("Tên tham số")> <Display(Order:=2)>
    Public Property name As String

    <Write(False)> <DisplayName("Nguồn dữ liệu")> <Display(Order:=3)>
    Public Property resource As String

    <Write(False)> <DisplayName("Tiền tố")> <Display(Order:=7)>
    Public Property sign As Integer

    <Write(False)> <DisplayName("Mô tả")> <Display(Order:=7)>
    Public Property note As String


#End Region

#Region "Static readonly"

    Public NotInheritable Class System_Parameter

        Public Enum ID
            'biến toàn cục : khởi tạo 1 lần, dùng chung cho toàn bộ quá trình
            SYS_STD_HOURS = 1
            SYS_BASE_SALARY = 2
            SYS_SALARY_MULT = 3
            'Biến cục bộ : Là thuộc tính của chung trong dữ liệu nguồn 
            SYS_OFFICE_HOURS = 4
            SYS_OVERTIME_HOURS = 5
            SYS_LATE_HOURS = 6
            SYS_EARLY_LEAVE_HOURS = 7
            SYS_SHIFT = 8
            SYS_IS_HOLIDAY = 9
            SYS_MULT_HOLIDAY = 10
            SYS_TOTAL_INCOME = 20
            SYS_TAX_AMOUNT = 30
            SYS_DEDUCTION = 40
            SYS_NET_SALARY = 50

        End Enum

        Private Shared ReadOnly Dict As New Dictionary(Of ID, PolicyParameter) From {
            {ID.SYS_STD_HOURS, New PolicyParameter With {.code = "SYS_STD_HOURS", .name = "Giờ công chuẩn", .resource = "pay_period", .note = "Tổng số giờ làm việc tiêu chuẩn của tháng"}},
            {ID.SYS_BASE_SALARY, New PolicyParameter With {.code = "SYS_BASE_SALARY", .name = "Lương cơ bản", .resource = "contract", .note = "Mức lương chính trong hợp đồng"}},
            {ID.SYS_SALARY_MULT, New PolicyParameter With {.code = "SYS_SALARY_MULT", .name = "Hệ số lương", .resource = "position", .note = "Hệ số lương trong chức vụ"}},
            {ID.SYS_OFFICE_HOURS, New PolicyParameter With {.code = "SYS_OFFICE_HOURS", .name = "Giờ hành chính", .resource = "attendance", .note = "Số giờ làm việc trong ca"}},
            {ID.SYS_OVERTIME_HOURS, New PolicyParameter With {.code = "SYS_OVERTIME_HOURS", .name = "Giờ tăng ca", .resource = "attendance", .note = "Số giờ làm thêm"}},
            {ID.SYS_LATE_HOURS, New PolicyParameter With {.code = "SYS_LATE_HOURS", .name = "Giờ đi trễ", .resource = "attendance", .note = "Số giờ đi trễ"}},
            {ID.SYS_EARLY_LEAVE_HOURS, New PolicyParameter With {.code = "SYS_EARLY_LEAVE_HOURS", .name = "Giờ về sớm", .resource = "attendance", .note = "Số giờ về sớm"}},
            {ID.SYS_SHIFT, New PolicyParameter With {.code = "SYS_SHIFT", .name = "Ca làm việc", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_IS_HOLIDAY, New PolicyParameter With {.code = "SYS_IS_HOLIDAY", .name = "Là ngày lễ", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_MULT_HOLIDAY, New PolicyParameter With {.code = "SYS_DAY_MULT_HOLIDAY", .name = "Hệ số ngày lễ", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_TOTAL_INCOME, New PolicyParameter With {.code = "SYS_TOTAL_INCOME", .name = "Tổng thu nhập", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_TAX_AMOUNT, New PolicyParameter With {.code = "SYS_TAX_AMOUNT", .name = "Tổng thuế", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_DEDUCTION, New PolicyParameter With {.code = "SYS_DEDUCTION", .name = "Tổng khấu trừ", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}},
            {ID.SYS_NET_SALARY, New PolicyParameter With {.code = "SYS_NET_SALARY", .name = "Thực lĩnh", .resource = "attendance", .note = "1 = ca đêm, 0 = ca ngày"}}
        }

        Public Shared Function GetParameter(id As ID) As PolicyParameter
            If Dict.ContainsKey(id) Then
                Return Dict(id)
            End If
            Return Nothing
        End Function

        Public Shared Function GetParameter(id As Integer) As PolicyParameter
            Return GetParameter(CType(id, ID))
        End Function




    End Class

    Public NotInheritable Class Data_Source

        Public Enum ID
            NONE = 1
            ATTENDANCE = 2
        End Enum

        Private Shared ReadOnly Dict As New Dictionary(Of ID, PolicyParameter) From {
            {ID.NONE, New PolicyParameter With {.id = 1, .code = "NONE", .name = "*"}},
            {ID.ATTENDANCE, New PolicyParameter With {.id = 1, .code = "SRC_ATTENDANCE", .name = "Chấm công"}}
        }

        Public Shared ReadOnly Dict_UI As New Dictionary(Of Integer, String) From {
           {ID.NONE, "NONE"},
           {ID.ATTENDANCE, "Chấm công"}
       }

        Public Shared Function GetParameter(id As ID) As PolicyParameter
            If Dict.ContainsKey(id) Then
                Return Dict(id)
            End If
            Return Nothing
        End Function

        Public Shared Function GetParameter(id As Integer) As PolicyParameter
            Return GetParameter(CType(id, ID))
        End Function
    End Class

    Public NotInheritable Class Aggregate_Func
        Public Enum ID
            SET_DATA = 1
            SUM = 2
            MAX = 3
            MIN = 4
            COUNT = 5
        End Enum

        Private Shared ReadOnly Dict As New Dictionary(Of ID, PolicyParameter) From {
            {ID.SET_DATA, New PolicyParameter With {.id = 1, .code = "SET", .name = "Gán dữ lệu"}},
            {ID.SUM, New PolicyParameter With {.id = 2, .code = "SUM", .name = "Tính tổng dữ liệu"}},
            {ID.MAX, New PolicyParameter With {.id = 3, .code = "MAX", .name = "Tìm dữ liệu lớn nhất"}},
            {ID.MIN, New PolicyParameter With {.id = 4, .code = "MIN", .name = "Tìm dữ liệu nhỏ nhất"}},
            {ID.COUNT, New PolicyParameter With {.id = 5, .code = "COUNT", .name = "Đếm số dòng số liệu"}}
        }

        Public Shared ReadOnly Dict_UI As New Dictionary(Of Integer, String) From {
           {ID.SET_DATA, "SET (Gán dữ lệu)"},
           {ID.SUM, "SUM (Tính tổng dữ liệu)"},
           {ID.MAX, "MAX (Tìm dữ liệu lớn nhất)"},
           {ID.MIN, "MIN (Tìm dữ liệu nhỏ nhất)"},
           {ID.COUNT, "COUNT (Đếm số dòng số liệu)"}
       }
        Public Shared Function GetParameter(id As ID) As PolicyParameter
            If Dict.ContainsKey(id) Then
                Return Dict(id)
            End If
            Return Nothing
        End Function

        Public Shared Function GetParameter(id As Integer) As PolicyParameter
            Return GetParameter(CType(id, ID))
        End Function
    End Class

    Public NotInheritable Class Category_Amount

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
        Public Shared ReadOnly Dict As New Dictionary(Of ID, PolicyParameter) From {
        {ID.INFORMATION, New PolicyParameter With {.code = "INFORMATION", .name = "Thông tin", .sign = 0}},
        {ID.ATTENDANCE, New PolicyParameter With {.code = "ATTENDANCE", .name = "Chấm công", .sign = 0}},
        {ID.INCOME, New PolicyParameter With {.code = "INCOME", .name = "Thu nhập", .sign = 1}},
        {ID.DEDUCTION, New PolicyParameter With {.code = "DEDUCTION", .name = "Khấu trừ", .sign = -1}},
        {ID.ALLOWANCE, New PolicyParameter With {.code = "ALLOWANCE", .name = "Phụ cấp", .sign = 1}},
        {ID.BONUS, New PolicyParameter With {.code = "BONUS", .name = "Thưởng", .sign = 1}},
        {ID.INSURANCE, New PolicyParameter With {.code = "INSURANCE", .name = "Bảo hiểm", .sign = -1}},
        {ID.TAX, New PolicyParameter With {.code = "TAX", .name = "Thuế", .sign = -1}}
    }

        ' ── Bind ComboBox — từ Dict gốc, không cần Dict_UI ──
        Public Shared Function ToList() As List(Of Object)
            Return Dict.Select(Function(kv) CType(New With {
                .id = CInt(kv.Key),
                .name = kv.Value.name
            }, Object)).ToList()
        End Function

        ' ── GetParameter — nhận cả 2 kiểu ───────────────────
        Public Shared Function GetParameter(id As ID) As PolicyParameter
            If Dict.ContainsKey(id) Then Return Dict(id)
            Return Nothing
        End Function

        Public Shared Function GetParameter(id As Integer) As PolicyParameter
            Return GetParameter(CType(id, ID))
        End Function

        ' ── Sign — dùng khi tính NET_SALARY ─────────────────
        Public Shared Function GetSign(id As Integer) As Integer
            Dim p = GetParameter(id)
            Return If(p IsNot Nothing, p.sign, 0)
        End Function

        ' ── Format — dùng khi hiển thị Pay_Item ─────────────
        Public Shared Function FomatByCat(value As Decimal, category As Integer) As String
            ' unit không có → fallback về category
            Select Case CType(category, ID)
                Case ID.INCOME,
                 ID.DEDUCTION,
                 ID.ALLOWANCE,
                 ID.BONUS,
                 ID.INSURANCE,
                 ID.TAX : Return value.ToString("N0")
                Case ID.ATTENDANCE : Return value.ToString("N1")
                Case ID.INFORMATION : Return value.ToString("N2")
                Case Else : Return value.ToString("N2")
            End Select
        End Function

    End Class

#End Region
End Class
