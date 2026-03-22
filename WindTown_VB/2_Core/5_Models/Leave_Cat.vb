Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

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

#Region "Field"
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
    <NotMapped> <Browsable(False)>
    Public ReadOnly Property leave_cat_UI As String
        Get
            Return $"{Me.name} ({Me.code})"
        End Get
    End Property
    <NotMapped> <DisplayName("Quyền lợi")> <Display(Order:=3)>
    Public ReadOnly Property benefit_UI As String
        Get
            Return If(benefit_Dict.ContainsKey(Me.benefit), benefit_Dict(Me.benefit), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=4)>
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

    <NotMapped>
    Public Shared ReadOnly benefit_Dict As New Dictionary(Of Integer, String) From {
        {0, "Không lương"},
        {1, "Hưởng lương đủ 8h"}
    }
#End Region

End Class