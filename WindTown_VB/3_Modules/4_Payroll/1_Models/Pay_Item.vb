Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("pay_item")>
Public Class Pay_Item
    Inherits BaseEntity

    Public Sub New()
        code = $"PAY_ITEM{GenerateRandomNumbers.Generate()}"
        name = ""
        value = 0
        category = CInt(Category_PayItem.ID.INFORMATION)
        unit = CInt(UnitSuffix.ID.NONE)
        source = source_system
        note = ""
        status = 0
    End Sub

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Payroll As Payroll = New Payroll()
#End Region

#Region "Field Json"
    <Browsable(False)>
    Public ReadOnly Property payroll_id As Integer
        Get
            Return Payroll?.id
        End Get
    End Property

    <Write(False)> <DisplayName("Mã thành phần")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên thành phần")> <Display(Order:=2)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property category As Integer
        Get
            Return GetV(Of Integer)("category")
        End Get
        Set(value As Integer)
            SetV("category", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property value As Decimal
        Get
            Return GetV(Of Decimal)("value")
        End Get
        Set(value As Decimal)
            SetV("value", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property unit As Integer
        Get
            Return GetV(Of Integer)("unit")
        End Get
        Set(value As Integer)
            SetV("unit", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Độ ưu tiên")> <Display(Order:=7)>
    Public Property priority As Integer
        Get
            Return GetV(Of Integer)("priority")
        End Get
        Set(value As Integer)
            SetV("priority", value)
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
    <Write(False)> <Browsable(False)>
    Public Property source As Integer
        Get
            Return GetV(Of Integer)("source")
        End Get
        Set(value As Integer)
            SetV("source", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=9)>
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

    <Write(False)> <DisplayName("Giá trị")> <Display(Order:=3)>
    Public ReadOnly Property value_UI As String
        Get
            Return UnitSuffix.FomatNumber(Me.value, Me.unit)

        End Get
    End Property
    <Write(False)> <DisplayName("Đơn vị giá trị")> <Display(Order:=4)>
    Public ReadOnly Property unit_UI As String
        Get
            Return If(UnitSuffix.GetSuffix(Me.unit), "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Danh mục")> <Display(Order:=5)>
    Public ReadOnly Property category_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.category)?.name, "---")

        End Get
    End Property

    <Write(False)> <DisplayName("Nguồn")> <Display(Order:=6)>
    Public ReadOnly Property source_UI As String
        Get
            Return If(source_Dict.ContainsKey(Me.source), source_Dict(Me.source), "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")

        End Get
    End Property
#End Region

#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Chưa xác nhận"},
        {1, "đã xác nhận"}
    }
#End Region
    <Browsable(False)>
    Public Const source_custum As Integer = 0
    <Browsable(False)>
    Public Const source_system As Integer = 1
#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly source_Dict As New Dictionary(Of Integer, String) From {
        {source_custum, "Thủ công"},
        {source_system, "Hệ thống"}
    }

#End Region
End Class