Imports WindTown_VB.AppServices

Public Class BaseList_UC
    Inherits UserControl

    Protected _service As IBaseService
    Protected _bindingSource As New BindingSource()

    ' ── Filter ───────────────────────────────────────────────
    Private _filterPanel As FilterPanel_UC
    Private _allData As Object   ' giữ reference list gốc

#Region "Setting Form"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(service As IBaseService, tag As String, title As String)
        InitializeComponent()
        Me.Tag = tag
        Me.Text = title
        _service = service

        tool_filter.Visible = False
    End Sub

    Protected Sub Init(modelType As Type)
        GridHelper.SetupGrid(_dgv, modelType)
        LoadData()
    End Sub

    Protected Overridable Sub LoadData()
        _dgv.ClearSelection()
        Dim response = _service.GetList()
        If response.IsSuccess Then
            ' ✅ Lưu list gốc để filter in-memory
            Dim lis As List(Of Employee) = If(response.Data, New List(Of Employee))
            _allData = response.Data

            _bindingSource.DataSource = Nothing
            _bindingSource.DataSource = lis
            _dgv.DataSource = _bindingSource
        Else
            MessageBox.Show(response.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        _dgv.ClearSelection()
        viewSelected.Text = "Rows selected:  0"
        tool_delete.Enabled = False
    End Sub

    Public Sub Refreash()
        LoadData()
    End Sub

#End Region

#Region "Dgv & Toolbar"
    Protected Overridable Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dgv.CellDoubleClick
    End Sub

    Protected Overridable Sub Dgv_SelectionChanged(sender As Object, e As EventArgs) Handles _dgv.SelectionChanged
        If Not viewSelected.Text.StartsWith("Lọc:") Then
            viewSelected.Text = $"Rows selected:  {_dgv.SelectedRows.Count}"
        End If
        tool_delete.Enabled = _dgv.SelectedRows.Count > 0
    End Sub

    Protected Overridable Sub tool_new_Click(sender As Object, e As EventArgs) Handles tool_new.Click
    End Sub

    Protected Overridable Sub tool_delete_Click(sender As Object, e As EventArgs) Handles tool_delete.Click
    End Sub

    Private Sub tool_filter_Click(sender As Object, e As EventArgs) Handles tool_filter.Click
        _filterPanel?.Toggle()
    End Sub

    Private Sub tool_hide_column_Click(sender As Object, e As EventArgs) Handles tool_hide_column.Click
        Dim frm As New DgvDisplay_frm(_dgv)
        frm.ShowDialog()
    End Sub

    Private Sub tool_refresh_Click(sender As Object, e As EventArgs) Handles tool_refresh.Click
        Refreash()
    End Sub

#End Region

#Region "Filter tool"
    ' ✅ Thêm 1 dòng này trong List_UC con để bật filter
    Protected Sub EnableFilter(modelType As Type)
        _filterPanel = New FilterPanel_UC(modelType)
        AddHandler _filterPanel.FilterApplied, AddressOf OnFilterApplied
        AddHandler _filterPanel.FilterCleared, AddressOf OnFilterCleared

        pnl_filter.Controls.Add(_filterPanel)

        tool_filter.Visible = True
    End Sub

    ' ── Filter applied ────────────────────────────────────────
    Private Sub OnFilterApplied(filters As List(Of FilterModel))
        If _allData Is Nothing Then Return

        ' ✅ Cast về IEnumerable(Of Object) an toàn
        Dim source = TryCast(_allData, IEnumerable(Of Object))
        If source Is Nothing Then
            ' Fallback: thử cast qua IList
            Dim lst = TryCast(_allData, System.Collections.IList)
            If lst Is Nothing Then Return
            source = lst.Cast(Of Object)()
        End If

        Dim filtered = source.Where(Function(item) MatchAll(item, filters)).ToList()
        _bindingSource.DataSource = Nothing
        _bindingSource.DataSource = filtered
        viewSelected.Text = $"Lọc: {filtered.Count} / {source.Count()} dòng"
    End Sub

    ' ── Filter cleared ────────────────────────────────────────
    Private Sub OnFilterCleared()
        If _allData Is Nothing Then Return
        _bindingSource.DataSource = Nothing
        _bindingSource.DataSource = _allData
        viewSelected.Text = "Rows selected:  0"
    End Sub

    ' ── Match tất cả filter (AND) ─────────────────────────────
    Private Function MatchAll(item As Object, filters As List(Of FilterModel)) As Boolean
        For Each f In filters
            If Not MatchOne(item, f) Then Return False
        Next
        Return True
    End Function

    Private Function MatchOne(item As Object, f As FilterModel) As Boolean
        Try
            Dim prop = item.GetType().GetProperty(f.Field)
            If prop Is Nothing Then Return True

            Dim raw = prop.GetValue(item)
            Dim t = If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType)

            If t = GetType(String) Then
                Dim s = If(raw?.ToString(), "").ToLower()
                Dim v = If(f.Value1?.ToString(), "").ToLower()
                Select Case f.Opera.ToLower()
                    Case "contains" : Return s.Contains(v)
                    Case "starts with" : Return s.StartsWith(v)
                    Case "ends with" : Return s.EndsWith(v)
                    Case "=" : Return s = v
                    Case Else : Return True
                End Select

            ElseIf t = GetType(DateTime) Then
                If raw Is Nothing Then Return True
                Dim d = CDate(raw)
                Dim v1 = CDate(f.Value1)
                Select Case f.Opera.ToLower()
                    Case "=" : Return d.Date = v1.Date
                    Case ">" : Return d > v1
                    Case "<" : Return d < v1
                    Case ">=" : Return d >= v1
                    Case "<=" : Return d <= v1
                    Case "between" : Return d >= v1 AndAlso d <= CDate(f.Value2)
                    Case Else : Return True
                End Select

            ElseIf t = GetType(Boolean) Then
                Return CBool(raw) = CBool(f.Value1)

            Else
                ' Số: Integer, Decimal, Double, Long...
                If raw Is Nothing OrElse f.Value1 Is Nothing Then Return True
                Dim d1 = CDec(raw)
                Dim v1 = CDec(f.Value1)
                Select Case f.Opera
                    Case "=" : Return d1 = v1
                    Case "<>" : Return d1 <> v1
                    Case ">" : Return d1 > v1
                    Case "<" : Return d1 < v1
                    Case ">=" : Return d1 >= v1
                    Case "<=" : Return d1 <= v1
                    Case "between"
                        If f.Value2 Is Nothing Then Return True
                        Return d1 >= v1 AndAlso d1 <= CDec(f.Value2)
                    Case Else : Return True
                End Select
            End If
        Catch
            Return True   ' lỗi cast → không filter dòng đó
        End Try
        Return True
    End Function
#End Region
End Class