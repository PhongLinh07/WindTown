Module NavigationService

    Private _mainPanel As Panel
    Private _mainHostForm As Form

    Private ReadOnly _history As New Stack(Of Type)
    Private _currentFormType As Type

    Private _isSwitchingFromMain As Boolean = False

    Public ReadOnly Property IsInitialized As Boolean
        Get
            Return _mainPanel IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property CanGoBack As Boolean
        Get
            Return _history.Count > 0
        End Get
    End Property

    ' Gọi hàm này khi đăng nhập thành công để thiết lập form chính và panel chứa nội dung
    Public Sub Initialize(mainHostForm As Form, mainPanel As Panel)

        If mainHostForm Is Nothing OrElse mainPanel Is Nothing Then Return

        _mainHostForm = mainHostForm
        _mainPanel = mainPanel

        _history.Clear()
        _currentFormType = Nothing

    End Sub

    ' formType phải là một lớp kế thừa từ Form
    Public Sub NavigateInMain(formType As Type, Optional addToHistory As Boolean = True)

        If Not IsInitialized Then Return
        If formType Is Nothing Then Return
        If Not GetType(Form).IsAssignableFrom(formType) Then Return

        If addToHistory AndAlso _currentFormType IsNot Nothing AndAlso _currentFormType IsNot formType Then
            _history.Push(_currentFormType)
        End If

        ShowInMain(formType)

    End Sub

    ' Generic version để gọi dễ dàng hơn, ví dụ: NavigateInMain(Of frmDashboard)()
    Public Sub NavigateInMain(Of T As Form)(Optional addToHistory As Boolean = True)
        NavigateInMain(GetType(T), addToHistory)
    End Sub

    ' Trả về true nếu đã quay lại thành công, false nếu không thể quay lại (ví dụ: không có lịch sử)
    Public Function GoBackInMain() As Boolean

        If Not CanGoBack Then Return False

        Dim previousType As Type = _history.Pop()
        ShowInMain(previousType)

        Return True

    End Function

    ' Đóng form hiện tại và mở form mới ở cấp độ top-level (không trong panel)
    Public Sub SwitchTopLevel(currentForm As Form, nextForm As Form)

        If nextForm Is Nothing Then Return

        nextForm.Show()

        If currentForm IsNot Nothing AndAlso Not currentForm.IsDisposed Then
            currentForm.Close()
        End If

    End Sub

    ' Phiên bản generic để gọi dễ dàng hơn, ví dụ: SwitchTopLevel(Of frmLogin)(Me)
    Public Sub SwitchTopLevel(Of T As {Form, New})(currentForm As Form)
        Dim nextForm As New T()
        SwitchTopLevel(currentForm, nextForm)
    End Sub

    ' Đăng xuất về form đăng nhập, đồng thời đóng form chính nếu đang ở trong đó
    Public Sub LogoutToLogin()

        Dim login As New frmLogin()
        login.Show()

        If _mainHostForm IsNot Nothing AndAlso Not _mainHostForm.IsDisposed Then
            _isSwitchingFromMain = True
            _mainHostForm.Close()
        End If

    End Sub

    ' Khi form chính bị đóng, nếu đang chuyển từ form chính sang form khác thì không thoát ứng dụng
    Public Function ShouldTerminateWhenMainClosed() As Boolean

        If _isSwitchingFromMain Then
            _isSwitchingFromMain = False
            Return False
        End If

        Return True

    End Function

    ' Hàm nội bộ để hiển thị form trong panel chính, sẽ dispose form cũ nếu có
    Private Sub ShowInMain(formType As Type)

        If _mainPanel Is Nothing Then Return

        For i As Integer = _mainPanel.Controls.Count - 1 To 0 Step -1
            Dim oldCtrl As Control = _mainPanel.Controls(i)
            _mainPanel.Controls.RemoveAt(i)
            oldCtrl.Dispose()
        Next

        Dim frm As Form = CType(Activator.CreateInstance(formType), Form)
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        _mainPanel.Controls.Add(frm)
        frm.Show()

        _currentFormType = formType

    End Sub

End Module

