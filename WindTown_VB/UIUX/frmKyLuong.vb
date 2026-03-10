Imports System.Linq

Public Class frmKyLuong
    Private ReadOnly _service As New Pay_PeriodService()
    Private _periods As New List(Of Pay_Period)()
    Private ReadOnly _binding As New BindingSource()

    Private Sub frmKyLuong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitGrid()
        LoadData()
        ApplyFilter()

        AddHandler Button1.Click, Sub() ApplyFilter()
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
        AddHandler Button2.Click, AddressOf Button2_Click
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ApplyFilter()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub InitGrid()
        With DataGridView1
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .ColumnHeadersHeight = 36
            .RowTemplate.Height = 36
        End With

        GridHelper.SetupGrid(DataGridView1, GetType(Pay_Period))
        DataGridView1.RowHeadersVisible = False

        Dim colEdit As New DataGridViewImageColumn() With {
            .Name = "colEdit",
            .HeaderText = "",
            .Image = My.Resources.compose,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        DataGridView1.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewImageColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Image = My.Resources.bin,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        DataGridView1.Columns.Add(colDelete)

        For Each col As DataGridViewColumn In DataGridView1.Columns
            col.ReadOnly = True
        Next
        DataGridView1.Columns("colEdit").ReadOnly = False
        DataGridView1.Columns("colDelete").ReadOnly = False

        DataGridView1.DataSource = _binding
        AddHandler DataGridView1.CellClick, AddressOf DataGridView1_CellClick
    End Sub

    Private Sub LoadData()
        Dim response = _service.Execute(DataIntent.GetList)
        _periods = TryCast(response?.Data, IEnumerable(Of Pay_Period))?.Where(Function(p) p IsNot Nothing).ToList()
        If _periods Is Nothing Then _periods = New List(Of Pay_Period)()
    End Sub

    Private Sub ApplyFilter()
        Dim query = If(TextBox1.Text, String.Empty).Trim()

        Dim filtered = _periods.Where(
            Function(p)
                If p Is Nothing Then Return False
                If String.IsNullOrWhiteSpace(query) Then Return True
                Dim codeMatch = If(p.code, String.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                Dim nameMatch = If(p.name, String.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                Return codeMatch OrElse nameMatch
            End Function).ToList()

        _binding.DataSource = filtered
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim data As New Pay_Period()
        Using crud As New Pay_Period_CRUD_Frm(data, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _service.Execute(DataIntent.Insert, data)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Thêm kỳ lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilter()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row = DataGridView1.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Pay_Period)
        If data Is Nothing Then Return

        Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            Dim clone = Utils.DeepClone(data)
            Using crud As New Pay_Period_CRUD_Frm(clone)
                If crud.ShowDialog(Me) <> DialogResult.OK Then Return
            End Using

            Dim result = _service.Execute(DataIntent.Update, clone)
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Cập nhật kỳ lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        ElseIf colName = "colDelete" Then
            If MessageBox.Show("Xác nhận xóa kỳ lương?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim result = _service.Execute(DataIntent.SoftDeleteMany, New List(Of Pay_Period) From {data})
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Xóa kỳ lương không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        End If
    End Sub
End Class
