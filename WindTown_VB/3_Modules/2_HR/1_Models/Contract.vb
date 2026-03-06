Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("contract")>
Public Class Contract
    Inherits BaseEntity

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee = New Employee()
#End Region

#Region "Field Json"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property

    <Write(False)> <DisplayName("Mã hợp đồng")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("start_date") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("start_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime?)("end_date")
        End Get
        Set(value As DateTime?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("end_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Lương cơ bản")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=5)>
    Public Property base_salary As Decimal? ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of Decimal?)("base_salary")
        End Get
        Set(value As Decimal?)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("base_salary", value)
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

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=6)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status = 1, "Đang hoạt động", "Ngừng hoạt động")
        End Get
    End Property

    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property Employee_UI As String
        Get
            Return If(Employee?.code, "---")
        End Get
    End Property
#End Region
End Class