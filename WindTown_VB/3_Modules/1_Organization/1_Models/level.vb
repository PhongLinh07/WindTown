Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("level")>
Public Class Level
    Inherits BaseEntity

#Region "Field json"
    <Write(False)> <DisplayName("Mã trình độ")> <Display(Order:=0)>
    Public Property code As String
        Get
            Return GetV(Of String)("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Tên trình độ")> <Display(Order:=1)>
    Public Property name As String
        Get
            Return GetV(Of String)("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Số thứ tự")> <Display(Order:=2)>
    Public Property rank As Integer
        Get
            Return GetV(Of String)("rank")
        End Get
        Set(value As Integer)
            SetV("rank", value)
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
            Return If(status = 1, "Đang hoạt động", "Ngừng hoạt động")
        End Get
    End Property
#End Region
End Class









