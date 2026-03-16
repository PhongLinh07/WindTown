Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions


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
        data_source = 1
        unit = CInt(UnitSuffix.ID.NONE)
        priority = 1
        note = ""
        status = 0
    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Mã chính sách")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên chính sách")> <Display(Order:=2)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Quy tắc")> <Display(Order:=3)>
    Public Property rule As String
        Get
            Return GetV(Of String)("rule")
        End Get
        Set(value As String)
            SetV("rule", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Độ ưu tiên")> <Display(Order:=4)>
    Public Property priority As Integer
        Get
            Return GetV(Of Integer)("priority")
        End Get
        Set(value As Integer)
            SetV("priority", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property data_source As Integer
        Get
            Return GetV(Of Integer)("data_source")
        End Get
        Set(value As Integer)
            SetV("data_source", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property aggregate As Integer
        Get
            Return GetV(Of Integer)("aggregate")
        End Get
        Set(value As Integer)
            SetV("aggregate", value)
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
    Public Property unit As Integer
        Get
            Return GetV(Of Integer)("unit")
        End Get
        Set(value As Integer)
            SetV("unit", value)
        End Set
    End Property
    <Write(False)> <Browsable(False)>
    Public Property gen_item As Integer
        Get
            Return GetV(Of Integer)("gen_item")
        End Get
        Set(value As Integer)
            SetV("gen_item", value)
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
    <Write(False)> <DisplayName("Ghi chú")> <Display(Order:=10)>
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

    <Write(False)> <DisplayName("Nguồn dữ liệu")> <Display(Order:=5)>
    Public ReadOnly Property data_source_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.data_source)?.name, "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Kiểu tổng hợp")> <Display(Order:=6)>
    Public ReadOnly Property aggregate_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.aggregate)?.code, "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Danh mục")> <Display(Order:=7)>
    Public ReadOnly Property category_UI As String
        Get
            Return If(Category_PayItem.GetParameter(Me.category)?.name, "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Đơn vị giá trị")> <Display(Order:=7)>
    Public ReadOnly Property unit_UI As String
        Get
            Return If(UnitSuffix.GetSuffix(Me.unit), "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Thêm vào bảng lương")> <Display(Order:=8)>
    Public ReadOnly Property gen_item_UI As String
        Get
            Return If(gen_item_Dict.ContainsKey(Me.gen_item), gen_item_Dict(Me.gen_item), "---")

        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")

        End Get
    End Property

#End Region

#Region "Dict"

    Public Shared ReadOnly gen_item_Dict As New Dictionary(Of Integer, String) From {
        {1, "YES"},
        {2, "NO"}
    }
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region


End Class