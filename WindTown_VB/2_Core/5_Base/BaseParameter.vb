Public Class BaseParameter
    Public Sub New()
        id = -1
        code = ""
        name = ""
        sign = 0
        priority = 1
        resource = CInt(Data_Source.ID.NONE)
        unit = CInt(UnitSuffix.ID.NONE)
        category = CInt(Category_PayItem.ID.INFORMATION)
        note = ""
    End Sub

    Public Property id As Integer
    Public Property code As String
    Public Property name As String
    Public Property sign As Integer
    Public Property resource As String
    Public Property unit As Integer
    Public Property category As Integer
    Public Property priority As Integer
    Public Property note As String


End Class