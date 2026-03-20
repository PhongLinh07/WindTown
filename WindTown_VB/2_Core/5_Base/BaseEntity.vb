Imports System.ComponentModel
Imports Dapper.Contrib.Extensions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public MustInherit Class BaseEntity
    <Key> <Browsable(False)> Public Property id As Integer
End Class