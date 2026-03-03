Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Reflection

Public Module GridHelper
    Public Sub SetupGrid(dgv As DataGridView, modelType As Type)
        ' 1. Cấu hình giao diện Flat Style
        With dgv
            .AutoGenerateColumns = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = True ' Wind Town thường để False cho sạch
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10)
            .RowTemplate.Height = 35
            .Columns.Clear()
        End With

        ' 2. Đọc Attribute và tạo danh sách cấu hình
        Dim props = modelType.GetProperties()
        Dim columnConfigs As New List(Of ColumnConfig)

        For Each prop In props
            ' Kiểm tra BrowsableAttribute
            Dim browsAttr = DirectCast(prop.GetCustomAttribute(Of BrowsableAttribute)(), BrowsableAttribute)
            If browsAttr IsNot Nothing AndAlso browsAttr.Browsable = False Then
                Continue For
            End If

            ' Lấy DisplayName
            Dim dispNameAttr = DirectCast(prop.GetCustomAttribute(Of DisplayNameAttribute)(), DisplayNameAttribute)
            Dim headerText As String = prop.Name
            If dispNameAttr IsNot Nothing Then headerText = dispNameAttr.DisplayName

            ' Lấy Order
            Dim dispAttr = DirectCast(prop.GetCustomAttribute(Of DisplayAttribute)(), DisplayAttribute)
            Dim orderIndex As Integer = 999
            If dispAttr IsNot Nothing Then orderIndex = dispAttr.Order

            ' --- BỔ SUNG: Đọc DisplayFormat ---
            Dim formatAttr = DirectCast(prop.GetCustomAttribute(Of DisplayFormatAttribute)(), DisplayFormatAttribute)
            Dim formatString As String = ""
            If formatAttr IsNot Nothing AndAlso Not String.IsNullOrEmpty(formatAttr.DataFormatString) Then
                ' Chuyển đổi {0:dd-MM-yyyy} thành dd-MM-yyyy (DGV chỉ cần phần sau dấu hai chấm)
                formatString = formatAttr.DataFormatString.Replace("{0:", "").Replace("}", "")
            End If

            ' Lưu vào danh sách tạm
            columnConfigs.Add(New ColumnConfig With {
                .PropName = prop.Name,
                .HeaderText = headerText,
                .Order = orderIndex,
                .Format = formatString ' Gán format đã đọc được
            })
        Next

        ' 3. Sắp xếp theo Order và thêm vào DGV
        For Each config In columnConfigs.OrderBy(Function(x) x.Order)
            Dim col As New DataGridViewTextBoxColumn()
            col.DataPropertyName = config.PropName
            col.HeaderText = config.HeaderText
            col.Name = "col_" & config.PropName
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            ' --- BỔ SUNG: Áp dụng định dạng vào CellStyle ---
            If Not String.IsNullOrEmpty(config.Format) Then
                col.DefaultCellStyle.Format = config.Format
            End If

            dgv.Columns.Add(col)
        Next
    End Sub

    ' Lớp phụ trợ (Thêm thuộc tính Format)
    Private Class ColumnConfig
        Public Property PropName As String
        Public Property HeaderText As String
        Public Property Order As Integer
        Public Property Format As String ' <-- Thêm cột này
    End Class
End Module