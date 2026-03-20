Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("position")>
Public Class Position
    Inherits BaseEntity
    Public Sub New()
        code = $"POS{GenerateRandomNumbers.Generate()}"
        start_date = DateTime.Now
        end_date = DateTime.Now
        note = ""
        status = 0
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Contract As Contract = New Contract()

    <Write(False)> <Browsable(False)>
    Public Property Salary_Mult As Salary_Mult = New Salary_Mult()

#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property contract_id As Integer
        Get
            Return Contract?.id
        End Get
    End Property
    <Browsable(False)>
    Public ReadOnly Property salary_mult_id As Integer
        Get
            Return Salary_Mult?.id
        End Get
    End Property

    <DisplayName("Mã chức vụ")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=5)>
    Public Property start_date As DateTime ' Thêm dấu ? để cho phép Null

    <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=6)>
    Public Property end_date As DateTime? ' Thêm dấu ? để cho phép Null

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=8)>
    Public Property note As String
#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=7)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Hợp đồng")> <Display(Order:=2)>
    Public ReadOnly Property contract_UI As String
        Get
            Return If(Contract?.code, "---")
        End Get
    End Property
    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return Contract?.employee_UI
        End Get
    End Property
    <Write(False)> <DisplayName("Công việc")> <Display(Order:=3)>
    Public ReadOnly Property job_UI As String
        Get
            ' Sử dụng String Interpolation giúp code sạch và dễ đọc hơn
            Return If(Salary_Mult IsNot Nothing, $"{Salary_Mult?.Job.name}", "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Trình độ")> <Display(Order:=4)>
    Public ReadOnly Property level_UI As String
        Get
            Return If(Salary_Mult IsNot Nothing, $"{Salary_Mult?.level_UI}", "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng hoạt động"},
        {1, "Đang hoạt động"}
    }

#End Region
End Class