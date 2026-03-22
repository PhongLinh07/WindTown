Imports System.Linq

' ============================================================
'  formPolicy.vb — Chính sách lương: trường + Load (partial: formPolicy.*.vb)
' ============================================================
Partial Public Class formPolicy

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  ENUM LABELS
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private ReadOnly CAT_LABELS As String() = {"Thu nhập", "Khấu trừ", "Thưởng", "Phụ cấp"}
    Private ReadOnly SRC_LABELS As String() = {"Hợp đồng", "Chấm công", "Nghỉ phép", "Phân công", "Thủ công"}
    Private ReadOnly AGG_LABELS As String() = {"Cố định", "Tổng", "Trung bình", "Đếm", "Tỷ lệ"}
    Private ReadOnly GEN_LABELS As String() = {"Lương chính", "Phụ cấp", "Thưởng", "Khấu trừ", "Bảo hiểm"}

    ' Current enum selections
    Private _selCat As Integer = 0
    Private _selSrc As Integer = 0
    Private _selAgg As Integer = 0
    Private _selGen As Integer = 0
    Private _priority As Integer = 1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  MOCK DATA STRUCTURE
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Structure PolicyRow
        Dim Id As Integer
        Dim Code As String
        Dim Name As String
        Dim Category As Integer    ' 0=Thu nhập 1=Khấu trừ 2=Thưởng 3=Phụ cấp
        Dim DataSource As Integer  ' 0=HĐ 1=CC 2=NP 3=PD 4=Thủ công
        Dim Aggregate As Integer   ' 0=Cố định 1=Tổng 2=TB 3=Đếm 4=Tỷ lệ
        Dim GenItem As Integer     ' 0=Lương 1=Phụ cấp 2=Thưởng 3=Khấu trừ 4=BHXH
        Dim Priority As Integer
        Dim Status As Integer      ' 1=active 0=off
        Dim Note As String
        Dim Rule As String         ' JSON formula
    End Structure

    Private Structure PreviewRow
        Dim Name As String
        Dim Category As Integer
        Dim EmpCount As Integer
        Dim Total As String
        Dim MinVal As String
        Dim MaxVal As String
        Dim IsOk As Boolean
        Dim IsIncome As Boolean    ' True=positive, False=negative
    End Structure

    Private _allPolicies As New List(Of PolicyRow)()
    Private _allPreview As New List(Of PreviewRow)()
    Private _filtered As New List(Of PolicyRow)()
    Private _selectedId As Integer = -1

    Private _usePolicyDb As Boolean
    Private ReadOnly _policyEntityById As New Dictionary(Of Integer, Policy)()

    Private _currentTab As Integer = 1

    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    '  FORM LOAD
    ' ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    Private Sub formPolicy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True

        UiTextBoxHints.SetCueBanner(txtSearch, "Tìm kiếm chính sách...")
        UiTextBoxHints.SetCueBanner(txtEditorSearch, "Tìm trong danh sách...")
        UiTextBoxHints.SetCueBanner(txtCode, "POL001")
        UiTextBoxHints.SetCueBanner(txtFName, "Lương cơ bản")
        UiTextBoxHints.SetCueBanner(txtFNote, "Mô tả chính sách...")

        ' Build dynamic enum button groups
        BuildEnumGroup(pnlCatGroup, CAT_LABELS, 0,
                       Sub(v) SetCat(v))
        BuildEnumGroup(pnlSrcGroup, SRC_LABELS, 0,
                       Sub(v) SetSrc(v))
        BuildEnumGroup(pnlAggGroup, AGG_LABELS, 0,
                       Sub(v) SetAgg(v))
        BuildEnumGroup(pnlGenGroup, GEN_LABELS, 0,
                       Sub(v) SetGen(v))

        ' Load data
        If Not TryLoadPoliciesFromDatabase() Then
            LoadMockPolicies()
        End If
        LoadMockPreview()
        _filtered = New List(Of PolicyRow)(_allPolicies)

        ' Render
        RenderPolicyTable(_filtered)
        RenderPolicyList(_allPolicies)
        RenderPreview()

        ' Add default condition rows
        AddCondRow("contract.status", "=", "1")
        AddCondRow("employee.status", "=", "1")

        ' Default formula
        txtFormula.Text = "{" & vbCrLf &
            "  ""formula"": ""base_salary * salary_mult.mult""," & vbCrLf &
            "  ""fields"": [""contract.base_salary"", ""salary_mult.mult""]," & vbCrLf &
            "  ""round"": 1000," & vbCrLf &
            "  ""min"": 0" & vbCrLf &
            "}"

        ' Resize handlers
        AddHandler pnlTab1.Resize, AddressOf OnTab1Resize
        AddHandler pnlPreviewResult.Resize, AddressOf OnPreviewResultResize
        AddHandler pnlEditorFooter.Resize, AddressOf OnEditorFooterResize
        AddHandler pnlToolbar.Resize, AddressOf OnToolbarResize
        AddHandler pnlPreviewSummary.Resize, AddressOf OnSummaryResize
        AddHandler pnlPreviewCtrl.Resize, AddressOf OnPreviewCtrlResize

        ShowTab(1)

        ' Select first policy
        If _allPolicies.Count > 0 Then
            SelectPolicy(_allPolicies(0).Id)
        End If
    End Sub
End Class
