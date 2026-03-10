Imports System.Linq

Public Class frmDuAn
    Private ReadOnly _service As New ProjectService()
    Private _projects As New List(Of Project)()
    Private ReadOnly _binding As New BindingSource()

    Private _initialized As Boolean = False

    Private pnlHeader As Panel
    Private lblTitle As Label
    Private pnlToolbar As Panel
    Private txtSearch As TextBox
    Private btnSearch As Button
    Private btnAdd As Button
    Private dgv As DataGridView

    Private Sub frmDuAn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not _initialized Then
            BuildLayout()
            InitGrid()
            _initialized = True
        End If

        LoadData()
        ApplyFilter()
    End Sub

    Private Sub BuildLayout()
        Me.BackColor = Color.White

        pnlHeader = New Panel() With {.Dock = DockStyle.Top, .Height = 64, .BackColor = Color.White}
        lblTitle = New Label() With {
            .Text = "Dự án",
            .Font = New Font("Segoe UI Semibold", 14.0F, FontStyle.Bold),
            .AutoSize = True,
            .Location = New Point(16, 18)
        }
        pnlHeader.Controls.Add(lblTitle)

        pnlToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 48, .BackColor = Color.White}
        txtSearch = New TextBox() With {.Width = 260, .Location = New Point(16, 10)}
        btnSearch = New Button() With {.Text = "Tìm kiếm", .Width = 100, .Height = 28, .Location = New Point(284, 9)}
        btnAdd = New Button() With {.Text = "Thêm mới dự án", .Width = 160, .Height = 28, .BackColor = Color.LimeGreen, .ForeColor = Color.White}
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.FlatAppearance.BorderSize = 0

        btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAdd.Left = Me.ClientSize.Width - 180
        AddHandler pnlToolbar.Resize, Sub()
                                           btnAdd.Left = pnlToolbar.Width - 180
                                       End Sub

        pnlToolbar.Controls.Add(txtSearch)
        pnlToolbar.Controls.Add(btnSearch)
        pnlToolbar.Controls.Add(btnAdd)

        dgv = New DataGridView() With {.Dock = DockStyle.Fill}

        Me.Controls.Add(dgv)
        Me.Controls.Add(pnlToolbar)
        Me.Controls.Add(pnlHeader)

        AddHandler btnSearch.Click, Sub() ApplyFilter()
        AddHandler txtSearch.KeyDown, AddressOf txtSearch_KeyDown
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ApplyFilter()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub InitGrid()
        With dgv
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

        GridHelper.SetupGrid(dgv, GetType(Project))
        dgv.RowHeadersVisible = False

        Dim colEdit As New DataGridViewImageColumn() With {
            .Name = "colEdit",
            .HeaderText = "",
            .Image = My.Resources.compose,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        dgv.Columns.Add(colEdit)

        Dim colDelete As New DataGridViewImageColumn() With {
            .Name = "colDelete",
            .HeaderText = "",
            .Image = My.Resources.bin,
            .Width = 36,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
        dgv.Columns.Add(colDelete)

        For Each col As DataGridViewColumn In dgv.Columns
            col.ReadOnly = True
        Next
        dgv.Columns("colEdit").ReadOnly = False
        dgv.Columns("colDelete").ReadOnly = False

        dgv.DataSource = _binding
        AddHandler dgv.CellClick, AddressOf dgv_CellClick
    End Sub

    Private Sub LoadData()
        Dim response = _service.Execute(DataIntent.GetList)
        _projects = TryCast(response?.Data, IEnumerable(Of Project))?.Where(Function(p) p IsNot Nothing).ToList()
        If _projects Is Nothing Then _projects = New List(Of Project)()
    End Sub

    Private Sub ApplyFilter()
        Dim query = If(txtSearch.Text, String.Empty).Trim()

        Dim filtered = _projects.Where(
            Function(p)
                If p Is Nothing Then Return False
                If String.IsNullOrWhiteSpace(query) Then Return True
                Dim codeMatch = If(p.code, String.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                Dim nameMatch = If(p.name, String.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                Return codeMatch OrElse nameMatch
            End Function).ToList()

        _binding.DataSource = filtered
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim data As New Project()
        Using crud As New Project_CRUD_Frm(data, True)
            If crud.ShowDialog(Me) <> DialogResult.OK Then Return
        End Using

        Dim result = _service.Execute(DataIntent.Insert, data)
        If result Is Nothing OrElse Not result.IsSuccess Then
            MessageBox.Show("Thêm dự án không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        LoadData()
        ApplyFilter()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim row = dgv.Rows(e.RowIndex)
        Dim data = TryCast(row.DataBoundItem, Project)
        If data Is Nothing Then Return

        Dim colName = dgv.Columns(e.ColumnIndex).Name
        If colName = "colEdit" Then
            Dim clone = Utils.DeepClone(data)
            Using crud As New Project_CRUD_Frm(clone)
                If crud.ShowDialog(Me) <> DialogResult.OK Then Return
            End Using

            Dim result = _service.Execute(DataIntent.Update, clone)
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Cập nhật dự án không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        ElseIf colName = "colDelete" Then
            If MessageBox.Show("Xác nhận xóa dự án?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim result = _service.Execute(DataIntent.SoftDeleteMany, New List(Of Project) From {data})
            If result Is Nothing OrElse Not result.IsSuccess Then
                MessageBox.Show("Xóa dự án không thành công: " & If(result?.Message, "Lỗi không xác định."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            LoadData()
            ApplyFilter()
        End If
    End Sub
End Class
