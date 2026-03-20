Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

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

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property payroll_id As Integer

    <Browsable(False)>
    Public Property Payroll As Payroll
#End Region

#Region "Field"
    <DisplayName("Mã thành phần")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên thành phần")> <Display(Order:=2)>
    Public Property name As String

    <Browsable(False)>
    Public Property category As Integer

    <Browsable(False)>
    Public Property value As Decimal

    <Browsable(False)>
    Public Property unit As Integer

    <DisplayName("Độ ưu tiên")> <Display(Order:=7)>
    Public Property priority As Integer

    <Browsable(False)>
    Public Property status As Integer

    <Browsable(False)>
    Public Property source As Integer

    <DisplayName("Ghi chú")> <Display(Order:=9)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Giá trị")> <Display(Order:=3)>
    Public ReadOnly Property value_UI As String
        Get
            Return UnitSuffix.FomatNumber(Me.value, Me.unit)
        End Get
    End Property

    <NotMapped> <DisplayName("Danh mục")> <Display(Order:=5)>
    Public ReadOnly Property category_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.category)?.name, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Nguồn")> <Display(Order:=6)>
    Public ReadOnly Property source_UI As String
        Get
            Return If(source_Dict.ContainsKey(Me.source), source_Dict(Me.source), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Chưa xác nhận"},
        {1, "Đã xác nhận"}
    }

    <Browsable(False)>
    Public Const source_custum As Integer = 0
    <Browsable(False)>
    Public Const source_system As Integer = 1

    <NotMapped>
    Public Shared ReadOnly source_Dict As New Dictionary(Of Integer, String) From {
        {source_custum, "Thủ công"},
        {source_system, "Hệ thống"}
    }
#End Region

End Class
