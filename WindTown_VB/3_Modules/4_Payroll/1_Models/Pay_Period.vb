Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("pay_period")>
Public Class Pay_Period
    Inherits BaseEntity

    Public Sub New()
        code = ""
        name = ""
        month = DateTime.Now
        start_date = DateTime.Now
        end_date = DateTime.Now
        std_hours = 0
        note = ""
        status = 0
    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Mã Kỳ lương")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên Kỳ lương")> <Display(Order:=1)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Tháng lương")> <DisplayFormat(DataFormatString:="{0:MM-yyyy}")> <Display(Order:=3)>
    Public Property month As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("month") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("month", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime)("start_date") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("start_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime)("end_date")
        End Get
        Set(value As DateTime)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("end_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Số gờ chuẩn")> <DisplayFormat(DataFormatString:="{0:N2}")> <Display(Order:=5)>
    Public Property std_hours As Decimal? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of Decimal?)("std_hours")
        End Get
        Set(value As Decimal?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("std_hours", value)
        End Set
    End Property

    <Write(False)> <Browsable(False)>
    Public Property status As Integer
        Get
            Return GetV(Of Integer)("status")
        End Get
        Set(value As Integer)
            SetV("status", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String
        Get
            Return GetV(Of String)("note")
        End Get
        Set(value As String)
            SetV("note", value)
        End Set
    End Property

#End Region

#Region "Field Display"
    <Write(False)> <Browsable(False)>
    Public ReadOnly Property pay_period_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=6)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    <Browsable(False)>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã đóng"},
        {1, "Đang mở"}
    }

#End Region
#Region "Const" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    <Write(False)> <Browsable(False)>
    Public Shared ReadOnly Property status_closed = 0
    <Write(False)> <Browsable(False)>
    Public Shared ReadOnly Property status_opening = 1


#End Region
End Class