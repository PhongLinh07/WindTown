Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("policy")>
Public Class Policy
    Inherits BaseEntity

    Public Sub New()
        code = ""
        name = ""
        category = 1
        priority = 1
        note = ""
        status = 0
    End Sub

#Region "Field Json"
    <Write(False)> <DisplayName("Mã chính sách")> <Display(Order:=2)>
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
    <Write(False)> <DisplayName("Tần Xuất áp dụng")> <Display(Order:=3)>
    Public Property frequency As Integer
        Get
            Return GetV(Of Integer)("frequency")
        End Get
        Set(value As Integer)
            SetV("frequency", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Danh mục")> <Display(Order:=3)>
    Public Property category As Integer
        Get
            Return GetV(Of Integer)("category")
        End Get
        Set(value As Integer)
            SetV("category", value)
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

    <Write(False)> <DisplayName("Độ ưu tiên")> <Display(Order:=3)>
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

    <Write(False)> <DisplayName("Danh mục")> <Display(Order:=4)>
    Public ReadOnly Property category_UI As String
        Get
            Return If(category_Dict.ContainsKey(Me.category), category_Dict(Me.category), "---")

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
    Public Shared ReadOnly category_Dict As New Dictionary(Of Integer, String) From {
        {1, "Thu nhập"},
        {2, "Phụ cấp"},
        {3, "Khấu trừ"},
        {4, "Thuế"},
        {5, "Thưởng"}
    }
    Public Shared ReadOnly frequency_Dict As New Dictionary(Of Integer, String) From {
        {1, "Theo ngày"},
        {2, "Theo chuy kỳ"}
    }

    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region

End Class