Imports System.Drawing
Imports System.Linq

' ============================================================
'  formPayroll.vb — Bảng lương: trường + Load (các partial khác trong formPayroll.*.vb)
' ============================================================
Partial Public Class formPayroll

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA STRUCTURES
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure PeriodRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim StartDate As Date
        Dim EndDate As Date
        Dim Month As Date
        Dim StdHours As Decimal
        Dim Note As String
        Dim Status As Integer   ' 0=draft 1=processing 2=closed
    End Structure

    Private Structure PayrollRow
        Dim Id As Integer
        Dim EmpName As String
        Dim EmpCode As String
        Dim Dept As String
        Dim Job As String
        Dim BaseSalary As Decimal
        Dim TotalIncome As Decimal
        Dim TotalDeduct As Decimal
        Dim NetSalary As Decimal
        Dim IsDone As Boolean
        Dim AvatarColor As Color
    End Structure

    Private Structure PayItemRow
        Dim Code As String
        Dim Name As String
        Dim Value As Decimal
        Dim Category As Integer  ' 0=lương 1=khấu trừ 2=thưởng 3=phụ cấp 4=BHXH
    End Structure

    Private _allPeriods As New List(Of PeriodRow)()
    Private _allPayrolls As New List(Of PayrollRow)()
    Private _payItems As New Dictionary(Of Integer, List(Of PayItemRow))()
    Private _filteredPayrolls As New List(Of PayrollRow)()

    Private _selPeriodId As Integer = 1
    Private _selEmpId As Integer = 1

    Private _useDatabase As Boolean
    Private ReadOnly _periodById As New Dictionary(Of Integer, Pay_Period)()

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        ' Placeholders
        UiTextBoxHints.SetCueBanner(txtSearch, "Tìm nhân viên...")
        UiTextBoxHints.SetCueBanner(txtPCode, "PP2026-03")
        UiTextBoxHints.SetCueBanner(txtPName, "Lương tháng 3/2026")
        UiTextBoxHints.SetCueBanner(txtStdHours, "176")
        UiTextBoxHints.SetCueBanner(txtPNote, "Ghi chú kỳ lương...")

        ' Avatar circle paint
        AddHandler pnlSlipAvatar.Paint, AddressOf SlipAvatar_Paint

        _periodById.Clear()
        If TryLoadPeriodsFromDatabase() Then
            _useDatabase = True
            LoadPayrollsForCurrentPeriodFromDatabase()
        Else
            _useDatabase = False
            LoadMockPeriods()
            LoadMockPayrolls()
            LoadMockPayItems()
        End If

        _filteredPayrolls = New List(Of PayrollRow)(_allPayrolls)

        ' Render
        RenderPeriodCards()
        RenderPayrollTable(_filteredPayrolls)
        RenderSlipEmpList()

        ' Select defaults
        SelectPeriod(_selPeriodId)
        SelectEmployee(_selEmpId)

        ' Resize handlers
        AddHandler pnlTab2.Resize, AddressOf OnTab2Resize
        AddHandler pnlSlipCard.Resize, AddressOf OnSlipCardResize
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlPeriodFooter.Resize, AddressOf OnPeriodFooterResize
        AddHandler pnlSummaryChips.Resize, AddressOf OnChipsResize
        AddHandler pnlKpiRow.Resize, AddressOf OnKpiRowResize
        AddHandler pnlSlipActions.Resize, AddressOf OnSlipActionsResize
        AddHandler pnlSlipCardHeader.Resize, AddressOf OnSlipHeaderResize

        ShowTab(2)
    End Sub
End Class
