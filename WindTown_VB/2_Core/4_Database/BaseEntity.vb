

Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public MustInherit Class BaseEntity
    <Key> <Browsable(False)> Public Property id As Integer
End Class