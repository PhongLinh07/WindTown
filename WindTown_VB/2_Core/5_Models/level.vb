Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("level")>
Public Class Level
    Inherits BaseEntity

    Public Sub New()
        code = ""
        name = ""
        note = ""
        rank = 1
        status = 0
    End Sub

#Region "Field"
    <DisplayName("Mã trình độ")> <Display(Order:=0)>
    Public Property code As String

    <DisplayName("Tên trình độ")> <Display(Order:=1)>
    Public Property name As String

    <DisplayName("Giá trị cấp bậc")> <Display(Order:=2)>
    Public Property rank As Integer

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=4)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property level_UI As String
        Get
            Return $"{name} ({code})"
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=3)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng áp dụng"},
        {1, "Đang áp dụng"}
    }
#End Region

End Class