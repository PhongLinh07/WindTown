Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("policy")>
Public Class Policy
    Inherits BaseEntity

    Public Sub New()
        code = $"POL{GenerateRandomNumbers.Generate()}"
        name = ""
        rule = ""
        aggregate = 1
        category = 1
        gen_item = 1
        source = 1
        unit = CInt(UnitSuffix.ID.NONE)
        priority = 1
        note = ""
        status = 0
    End Sub

#Region "Field"
    <DisplayName("Mã chính sách")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên chính sách")> <Display(Order:=2)>
    Public Property name As String

    <DisplayName("Quy tắc")> <Display(Order:=3)>
    Public Property rule As String

    <DisplayName("Độ ưu tiên")> <Display(Order:=4)>
    Public Property priority As Integer

    <Browsable(False)>
    Public Property source As Integer

    <Browsable(False)>
    Public Property aggregate As Integer

    <Browsable(False)>
    Public Property category As Integer

    <Browsable(False)>
    Public Property unit As Integer

    <Browsable(False)>
    Public Property gen_item As Integer

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Nguồn dữ liệu")> <Display(Order:=5)>
    Public ReadOnly Property source_UI As String
        Get
            Return If(Data_Source.GetParameter(Me.source)?.name, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Kiểu tổng hợp")> <Display(Order:=6)>
    Public ReadOnly Property aggregate_UI As String
        Get
            Return If(Aggregate_Func.GetParameter(Me.aggregate)?.code, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Danh mục")> <Display(Order:=7)>
    Public ReadOnly Property category_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.category)?.name, "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Đơn vị giá trị")> <Display(Order:=7)>
    Public ReadOnly Property unit_UI As String
        Get
            Return If(UnitSuffix.GetSuffix(Me.unit), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Thêm vào bảng lương")> <Display(Order:=8)>
    Public ReadOnly Property gen_item_UI As String
        Get
            Return If(gen_item_Dict.ContainsKey(Me.gen_item), gen_item_Dict(Me.gen_item), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly gen_item_Dict As New Dictionary(Of Integer, String) From {
        {1, "YES"},
        {2, "NO"}
    }

    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region

End Class