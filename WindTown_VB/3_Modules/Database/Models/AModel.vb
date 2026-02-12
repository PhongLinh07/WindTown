Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations.Schema

Public MustInherit Class AModel

    ' ===== Table Name =====
    <Browsable(False)>
    Public Overridable ReadOnly Property GetTableName As String
        Get
            Return "Invalid"
        End Get
    End Property


    ' ===== ID Tool =====
    <Browsable(False)>
    Public Property id As Integer


End Class
