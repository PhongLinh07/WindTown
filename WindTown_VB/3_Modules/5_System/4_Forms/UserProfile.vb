Public NotInheritable Class UserProfile

    Private Sub New()
    End Sub

    Private Shared _user As Account = Nothing

    Public Shared Property User As Account
        Get
            Return _user
        End Get
        Set(value As Account)
            _user = value
        End Set
    End Property

End Class