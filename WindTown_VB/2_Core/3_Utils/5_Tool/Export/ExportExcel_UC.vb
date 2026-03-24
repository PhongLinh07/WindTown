Imports ClosedXML.Excel

Public Class ExportExcel_UC
    Private ReadOnly _dgv As DataGridView

    Public Sub New(dgv As DataGridView)
        InitializeComponent()
        Me.Dock = DockStyle.Fill
        Me.Visible = False
        _dgv = dgv
    End Sub

    Public Sub Toggle()
        Me.Visible = Not Me.Visible
    End Sub

    Private Sub Browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        Using sfd As New SaveFileDialog With {
            .Filter = "Excel (*.xlsx)|*.xlsx",
            .FileName = $"Export_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        }
            If sfd.ShowDialog() = DialogResult.OK Then txtPath.Text = sfd.FileName
        End Using
    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        If String.IsNullOrWhiteSpace(txtPath.Text) Then
            Log("⚠ Chưa chọn file") : Return
        End If
        Try
            progress.Value = 10
            Export(_dgv, txtPath.Text)
            progress.Value = 100
            Log("✅ Export thành công!")
        Catch ex As Exception
            Log("❌ " & ex.Message)
            progress.Value = 0
        End Try
    End Sub

    Private Sub Export(dgv As DataGridView, path As String)
        Dim cols = dgv.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).ToList()
        Dim rows = dgv.Rows.Cast(Of DataGridViewRow)().Where(Function(r) Not r.IsNewRow).ToList()

        Using wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("Data")

            ' ── Title ──────────────────────────────────────────
            Dim title = ws.Range(1, 1, 1, cols.Count)
            title.Merge().Value = "DANH SÁCH DỮ LIỆU"
            title.Style.Font.SetBold().Font.SetFontSize(14)
            title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

            ' ── Header ─────────────────────────────────────────
            For i = 0 To cols.Count - 1
                ws.Cell(2, i + 1).Value = cols(i).HeaderText
            Next
            Dim header = ws.Range(2, 1, 2, cols.Count)
            header.Style.Font.SetBold()
            header.Style.Fill.BackgroundColor = XLColor.FromArgb(68, 114, 196)
            header.Style.Font.FontColor = XLColor.White
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center

            ' ── Data ───────────────────────────────────────────
            For r = 0 To rows.Count - 1
                For c = 0 To cols.Count - 1
                    ws.Cell(r + 3, c + 1).Value = rows(r).Cells(cols(c).Index).Value?.ToString()
                Next
                ' Zebra stripe
                If r Mod 2 = 1 Then
                    ws.Range(r + 3, 1, r + 3, cols.Count).Style.Fill.BackgroundColor = XLColor.FromArgb(242, 242, 242)
                End If
            Next

            ' ── Border + AutoSize ───────────────────────────────
            With ws.RangeUsed().Style
                .Border.OutsideBorder = XLBorderStyleValues.Thin
                .Border.InsideBorder = XLBorderStyleValues.Thin
            End With
            ws.Columns().AdjustToContents()

            wb.SaveAs(path)
        End Using
    End Sub

    Private Sub Log(msg As String)
        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {msg}")
        lstLog.TopIndex = lstLog.Items.Count - 1
    End Sub

End Class