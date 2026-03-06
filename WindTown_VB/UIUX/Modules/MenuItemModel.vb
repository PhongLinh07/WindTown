Public Class MenuItemModel

    Public Property Title As String
    Public Property FormType As Type
    Public Property Icon As Image
    Public Property Children As New List(Of MenuItemModel)

    Public Sub New(title As String, Optional formType As Type = Nothing, Optional icon As Image = Nothing)

        Me.Title = title
        Me.FormType = formType
        Me.Icon = icon

    End Sub

End Class