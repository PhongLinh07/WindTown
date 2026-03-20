Public Class frmChonCotXuat

    Private ReadOnly _cot As List(Of BaoCaoXuatCot)
    Public ReadOnly Property CotDuocChon As List(Of BaoCaoXuatCot)

    Public Sub New(cot As IEnumerable(Of BaoCaoXuatCot))
        InitializeComponent()
        _cot = If(cot IsNot Nothing, cot.Select(Function(x) New BaoCaoXuatCot With {
                                                .TenCot = x.TenCot,
                                                .TieuDe = x.TieuDe,
                                                .DuocChon = x.DuocChon
                                            }).ToList(), New List(Of BaoCaoXuatCot)())
        CotDuocChon = New List(Of BaoCaoXuatCot)()
    End Sub

    Private Sub frmChonCotXuat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clbCot.Items.Clear()
        For Each item In _cot
            clbCot.Items.Add(item, item.DuocChon)
        Next
        chkChonTatCa.Checked = _cot.All(Function(x) x.DuocChon)
    End Sub

    Private Sub clbCot_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clbCot.ItemCheck
        BeginInvoke(New Action(Sub()
                                   chkChonTatCa.Checked = _cot.Count > 0 AndAlso clbCot.CheckedItems.Count = _cot.Count
                               End Sub))
    End Sub

    Private Sub chkChonTatCa_CheckedChanged(sender As Object, e As EventArgs) Handles chkChonTatCa.CheckedChanged
        For i As Integer = 0 To clbCot.Items.Count - 1
            clbCot.SetItemChecked(i, chkChonTatCa.Checked)
        Next
    End Sub

    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub btnXacNhan_Click(sender As Object, e As EventArgs) Handles btnXacNhan.Click
        CotDuocChon.Clear()
        For i As Integer = 0 To clbCot.Items.Count - 1
            Dim item = TryCast(clbCot.Items(i), BaoCaoXuatCot)
            If item Is Nothing Then Continue For
            If clbCot.GetItemChecked(i) Then
                CotDuocChon.Add(item)
            End If
        Next
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function
End Class
