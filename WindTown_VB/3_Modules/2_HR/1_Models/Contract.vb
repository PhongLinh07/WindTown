Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("contract")>
Public Class Contract
    Inherits BaseEntity

    Public Sub New()
        code = "CTR" + GenerateRandomNumbers.Generate()
        start_date = DateTime.Now
        end_date = DateTime.Now
        base_salary = 0.0
        note = ""
        status = 0
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Employee = New Employee()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property employee_id As Integer
        Get
            Return Employee?.id
        End Get
    End Property

    <DisplayName("Mã hợp đồng")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=3)>
    Public Property start_date As DateTime

    <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=4)>
    Public Property end_date As DateTime?

    <DisplayName("Lương cơ bản")> <DisplayFormat(DataFormatString:="{0:N0}")> <Display(Order:=5)>
    Public Property base_salary As Decimal?

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=7)>
    Public Property note As String

#End Region


#Region "Field Display"
    <Write(False)> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return If(Employee?.employee_UI, "---")
        End Get
    End Property

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=7)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
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