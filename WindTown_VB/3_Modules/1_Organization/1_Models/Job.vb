Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("job")>
Public Class Job
    Inherits BaseEntity

#Region "Join"
    <Write(False)> <Browsable(False)>
    Public Property Department = New Department()
#End Region

#Region "Field"
    <Browsable(False)>
    Public ReadOnly Property department_id As Integer
        Get
            Return Department?.id
        End Get
    End Property
#End Region

#Region "Field Json"
    <Write(False)> <DisplayName("Code")> <Display(Order:=1)>
    Public Property code As String
        Get
            Return GetV("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Name")> <Display(Order:=2)>
    Public Property name As String
        Get
            Return GetV("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Note")> <Display(Order:=7)>
    Public Property note As String
        Get
            Return GetV("note")
        End Get
        Set(value As String)
            SetV("note", value)
        End Set
    End Property

    <Write(False)> <Browsable(False)>
    Public Property status As Integer
        Get
            Return GetV("status")
        End Get
        Set(value As Integer)
            SetV("status", value)
        End Set
    End Property

#End Region

#Region "Field Display"

    <Write(False)> <DisplayName("Status")> <Display(Order:=8)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status = 1, "Active", "Inactive")
        End Get
    End Property

    <Write(False)> <DisplayName("Department")> <Display(Order:=3)>
    Public ReadOnly Property Department_UI As String
        Get
            Return If(Department?.name, "---")
        End Get
    End Property
#End Region
End Class