Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Linq
Imports System.Windows.Forms

''' <summary>
''' Xuất DataGridView ra PDF qua máy in "Microsoft Print to PDF" (Windows 10+).
''' </summary>
Friend NotInheritable Class ReportPdfExport

    Private Sub New()
    End Sub

    Friend Shared Function TryFindWindowsPdfPrinterName() As String
        For Each name As String In PrinterSettings.InstalledPrinters
            If name.IndexOf("Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Return name
            End If
        Next
        Return Nothing
    End Function

    Friend Shared Function ExportDataGridViewToPdf(dgv As DataGridView, pdfFilePath As String, title As String, owner As IWin32Window) As Boolean
        If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then Return False
        Dim printer = TryFindWindowsPdfPrinterName()
        If String.IsNullOrEmpty(printer) Then
            MessageBox.Show(
                "Không tìm thấy máy in ""Microsoft Print to PDF""." & vbCrLf &
                "Bật tính năng Windows hoặc cài driver PDF, rồi thử lại.",
                "Xuất PDF",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return False
        End If

        Dim visibleCols = dgv.Columns.Cast(Of DataGridViewColumn)().Where(Function(c) c.Visible).ToList()
        If visibleCols.Count = 0 Then Return False

        Dim state As New PdfGridState With {
            .Dgv = dgv,
            .Cols = visibleCols,
            .Title = If(String.IsNullOrWhiteSpace(title), "Báo cáo", title),
            .RowIndex = 0,
            .NeedTitle = True
        }

        Using pd As New PrintDocument()
            pd.DocumentName = state.Title
            pd.PrinterSettings.PrinterName = printer
            pd.PrinterSettings.PrintToFile = True
            pd.PrinterSettings.PrintFileName = pdfFilePath
            pd.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)
            pd.DefaultPageSettings.Landscape = visibleCols.Count > 5

            Dim handler As PrintPageEventHandler = Sub(s, ev) PrintPage(state, ev)
            AddHandler pd.PrintPage, handler
            Try
                pd.Print()
            Catch ex As Exception
                MessageBox.Show("Không ghi được PDF: " & ex.Message, "Xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RemoveHandler pd.PrintPage, handler
                Return False
            End Try
            RemoveHandler pd.PrintPage, handler
        End Using

        MessageBox.Show(owner, "Đã lưu: " & pdfFilePath, "Xuất PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function

    Private Class PdfGridState
        Public Dgv As DataGridView
        Public Cols As List(Of DataGridViewColumn)
        Public Title As String
        Public RowIndex As Integer
        Public NeedTitle As Boolean
    End Class

    Private Shared Sub PrintPage(state As PdfGridState, e As PrintPageEventArgs)
        Dim g = e.Graphics
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim margin = e.MarginBounds
        Dim y As Single = margin.Top
        Const lineH As Single = 16.0F

        Using titleFont As New Font("Microsoft YaHei UI", 12.0F, FontStyle.Bold),
              headerFont As New Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold),
              cellFont As New Font("Microsoft YaHei UI", 8.0F, FontStyle.Regular),
              brush As New SolidBrush(Color.Black),
              headerBrush As New SolidBrush(Color.FromArgb(40, 40, 40)),
              hdrBg As New SolidBrush(Color.FromArgb(235, 235, 240))

            If state.NeedTitle Then
                g.DrawString(state.Title, titleFont, brush, margin.Left, y)
                y += lineH * 2.2F
                g.DrawString("WindTown — " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"), cellFont, brush, margin.Left, y)
                y += lineH * 1.8F
                state.NeedTitle = False
            End If

            Dim colWidths = ComputeColumnWidths(state.Cols.Count, margin.Width)
            Dim x0 As Single = margin.Left

            Dim x = x0
            For c = 0 To state.Cols.Count - 1
                Dim col = state.Cols(c)
                Dim w = colWidths(c)
                g.FillRectangle(hdrBg, x, y, w, lineH + 4)
                g.DrawRectangle(Pens.Gray, x, y, w, lineH + 4)
                g.DrawString(Truncate(col.HeaderText, 36), headerFont, headerBrush, x + 3, y + 2)
                x += w
            Next
            y += lineH + 8

            While state.RowIndex < state.Dgv.Rows.Count
                Dim row = state.Dgv.Rows(state.RowIndex)
                If row.IsNewRow Then
                    state.RowIndex += 1
                    Continue While
                End If

                If y + lineH + 6 > margin.Bottom Then
                    e.HasMorePages = True
                    Return
                End If

                x = x0
                For c = 0 To state.Cols.Count - 1
                    Dim col = state.Cols(c)
                    Dim w = colWidths(c)
                    Dim txt = If(row.Cells(col.Index).Value, String.Empty).ToString()
                    g.DrawRectangle(Pens.LightGray, x, y, w, lineH + 2)
                    g.DrawString(Truncate(txt, 48), cellFont, brush, New RectangleF(x + 3, y + 1, w - 6, lineH + 2))
                    x += w
                Next
                y += lineH + 4
                state.RowIndex += 1
            End While
        End Using

        e.HasMorePages = False
    End Sub

    Private Shared Function ComputeColumnWidths(colCount As Integer, totalWidth As Single) As Single()
        Dim arr(colCount - 1) As Single
        If colCount <= 0 Then Return arr
        Dim w = totalWidth / colCount
        For i = 0 To colCount - 1
            arr(i) = w
        Next
        Return arr
    End Function

    Private Shared Function Truncate(s As String, maxLen As Integer) As String
        If s Is Nothing Then Return ""
        If s.Length <= maxLen Then Return s
        Return s.Substring(0, maxLen - 1) & "…"
    End Function

End Class
