Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("holiday")>
Public Class Holiday
    Inherits BaseEntity

    Public Sub New()
        code = ""
        name = ""
        of_date = DateTime.Now
        mult = 3.0
        note = ""
        status = 3
    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Mã ngày lễ")> <Display(Order:=2)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên ngày lễ")> <Display(Order:=2)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Thời gian")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=2)>
    Public Property of_date As DateTime ' Thêm dấu ? để cho phép Null
        Get
            Return GetV(Of DateTime)("of_date") ' Trả về giá trị mặc định nếu Null
        End Get
        Set(value As DateTime)
            ' Bắt buộc dùng SetV(Of T) để đồng bộ kiểu dữ liệu
            SetV("of_date", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Hệ số")> <Display(Order:=2)>
    Public Property mult As Decimal
        Get
            Return GetV(Of Decimal)("mult")
        End Get
        Set(value As Decimal)
            SetV("mult", value)
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
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=3)>
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

    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=2)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region


#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region

End Class