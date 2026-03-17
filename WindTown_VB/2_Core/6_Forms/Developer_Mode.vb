Public Class Developer_Mode

    Public Shared Instance As Developer_Mode

    Public Sub New()
        InitializeComponent()

        Developer_Mode.Instance = Me
    End Sub
    Private Sub Developer_Mode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bootstrap = DatabaseBootstrapService.EnsureReady()
        If Not bootstrap.IsSuccess Then
            MessageBox.Show("Khong the khoi tao ket noi database: " & bootstrap.Message, "Loi ket noi DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn_backend.Enabled = False
            btn_fontend.Enabled = False
            Return
        End If

        If bootstrap.WasCreated Then
            MessageBox.Show("Da tao moi database 'wind_town' va khoi tao du lieu tu db_json.sql.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_backend_Click(sender As Object, e As EventArgs) Handles btn_backend.Click
        Dim f As New FormMain()
        f.Show()
        Me.Hide() ' ÄÃ³ng háº³n Form chá»n, giáº£i phÃ³ng bá»™ nhá»› ngay láº­p tá»©c
    End Sub

    Private Sub btn_fontend_Click(sender As Object, e As EventArgs) Handles btn_fontend.Click
        NavigationService.SwitchTopLevel(Of frmMain)(Me)
    End Sub
End Class
