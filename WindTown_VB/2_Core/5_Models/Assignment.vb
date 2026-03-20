Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("assignment")>
Public Class Assignment
    Inherits BaseEntity

    Public Sub New()
        code = $"ASSM{GenerateRandomNumbers.Generate}"
        start_date = DateTime.Now
        end_date = DateTime.Now
        note = ""
        status = 0
    End Sub

#Region "FK + Navigation"
    <Browsable(False)>
    Public Property position_id As Integer

    <Browsable(False)>
    Public Property Position As Position

    <Browsable(False)>
    Public Property project_id As Integer

    <Browsable(False)>
    Public Property Project As Project
#End Region

#Region "Field"
    <DisplayName("Mã phân công")> <Display(Order:=1)>
    Public Property code As String

    <Browsable(False)>
    Public Property role As Integer

    <DisplayName("Ngày bắt đầu")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=7)>
    Public Property start_date As DateTime

    <DisplayName("Ngày kết thúc")> <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}")> <Display(Order:=8)>
    Public Property end_date As DateTime?

    <Browsable(False)>
    Public Property status As Integer

    <DisplayName("Ghi chú")> <Display(Order:=10)>
    Public Property note As String
#End Region

#Region "Field Display"
    <NotMapped> <DisplayName("Trạng thái")> <Display(Order:=9)>
    Public ReadOnly Property status_UI As String
        Get
            Return If(status_Dict.ContainsKey(Me.status), status_Dict(Me.status), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Quyền hạn")> <Display(Order:=6)>
    Public ReadOnly Property role_UI As String
        Get
            Return If(role_Dict.ContainsKey(Me.role), role_Dict(Me.role), "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Dự án")> <Display(Order:=5)>
    Public ReadOnly Property project_UI As String
        Get
            Return If(Project IsNot Nothing, $"{Project?.name} ({Project?.code})", "---")
        End Get
    End Property

    <NotMapped> <DisplayName("Nhân viên")> <Display(Order:=2)>
    Public ReadOnly Property employee_UI As String
        Get
            Return Position?.employee_UI
        End Get
    End Property

    <NotMapped> <DisplayName("Công việc")> <Display(Order:=3)>
    Public ReadOnly Property job_UI As String
        Get
            Return Position?.job_UI
        End Get
    End Property

    <NotMapped> <DisplayName("Trình độ")> <Display(Order:=4)>
    Public ReadOnly Property level_UI As String
        Get
            Return Position?.level_UI
        End Get
    End Property
#End Region

#Region "Dictionary Display"
    <NotMapped>
    Public Shared ReadOnly status_Dict As New Dictionary(Of Integer, String) From {
        {0, "Ngừng hoạt động"},
        {1, "Đang hoạt động"}
    }

    <NotMapped>
    Public Shared ReadOnly role_Dict As New Dictionary(Of Integer, String) From {
        {1, "Quản lý dự án"},
        {2, "Phát triển"}
    }
#End Region

End Class
