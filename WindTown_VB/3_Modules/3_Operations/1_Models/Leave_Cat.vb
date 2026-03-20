Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("leave_cat")>
Public Class Leave_Cat
    Inherits BaseEntity

    Public Sub New()
        code = $"LEA_CAT{GenerateRandomNumbers.Generate()}"
        name = ""
        benefit = 0
        note = ""
        status = 0
    End Sub

#Region "Field Json"

    <DisplayName("Mã loại")> <Display(Order:=1)>
    Public Property code As String

    <DisplayName("Tên loại")> <Display(Order:=2)>
    Public Property name As String

    <Browsable(False)>
    Public Property benefit As Integer

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=5)>
    Public Property note As String
#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Quyền lợi")> <Display(Order:=3)>
    Public ReadOnly Property benefit_UI As String
        Get
            Return If(benefit_Dict.ContainsKey(Me.benefit), benefit_Dict(Me.benefit), "---")
        End Get
    End Property
    <Write(False)> <DisplayName("Trạng thái")> <Display(Order:=4)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property


#End Region


#Region "Dictionary Display" 'chứa các dictionary dùng chung trong toàn bộ module Operations, tránh việc phải tạo nhiều dictionary giống nhau ở nhiều form khác
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Đã bị từ chối"},
        {1, "Đã được phê duyệt"}
    }

    Public Shared ReadOnly benefit_Dict As New Dictionary(Of Integer, String) From {
        {0, "Không lương"},
        {1, "Hưởng lương đủ 8h"}
    }

#End Region
End Class






