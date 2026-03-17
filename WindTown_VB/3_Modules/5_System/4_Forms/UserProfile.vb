Public NotInheritable Class UserProfile

    Private Sub New()
    End Sub

    Private Shared _user As Account = Nothing
    Private Shared _isDEV As Boolean = False

    Public Shared Property User As Account
        Get
            Return Utils.DeepClone(Of Account)(_user)
        End Get
        Set(value As Account)
            _user = value
        End Set
    End Property

    Public Shared ReadOnly Property IsDev As Boolean
        Get
            Return _isDEV
        End Get
    End Property

    Public Shared ReadOnly Property Is_User As Boolean
        Get
            Return Not _isDEV
        End Get
    End Property

    Public Shared ReadOnly Property Is_Staff As Boolean
        Get
            Return _user.role = Account.ROLE_STAFF
        End Get
    End Property


    Public Shared Sub SwitchDev()
        _isDEV = True
    End Sub

    Public Shared Sub SwitchUser()
        _isDEV = False
    End Sub




End Class