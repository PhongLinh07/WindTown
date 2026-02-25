Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports Dapper.Contrib.Extensions

<Table("department")>
Public Class Department
    Inherits BaseEntity

    <Write(False)> <DisplayName("Code")>
    Public Property code As String
        Get
            Return GetV("code")
        End Get
        Set(value As String)
            SetV("code", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Name")>
    Public Property name As String
        Get
            Return GetV("name")
        End Get
        Set(value As String)
            SetV("name", value)
        End Set
    End Property
    <Write(False)> <DisplayName("Note")>
    Public Property note As String
        Get
            Return GetV("note")
        End Get
        Set(value As String)
            SetV("note", value)
        End Set
    End Property

    <Write(False)> <DisplayName("Status")>
    Public Property status As String
        Get
            Return GetV("status")
        End Get
        Set(value As String)
            SetV("status", value)
        End Set
    End Property
End Class