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
            .RowHeadersVisible = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10)
            .RowTemplate.Height = 35
            .Columns.Clear()
        End With

        ' 2. Đọc Attribute và tạo cột
        Dim props = modelType.GetProperties()
        Dim columnConfigs As New List(Of ColumnConfig)

        For Each prop In props
            ' Kiểm tra BrowsableAttribute (Thay cho ?.Browsable)
            Dim browsAttr = DirectCast(prop.GetCustomAttribute(Of BrowsableAttribute)(), BrowsableAttribute)
            If browsAttr IsNot Nothing AndAlso browsAttr.Browsable = False Then
                Continue For
            End If

            ' Lấy DisplayName (Thay cho ?? prop.Name)
            Dim dispNameAttr = DirectCast(prop.GetCustomAttribute(Of DisplayNameAttribute)(), DisplayNameAttribute)
            Dim headerText As String = prop.Name
            If dispNameAttr IsNot Nothing Then headerText = dispNameAttr.DisplayName

            ' Lấy Order (Thay cho ?? 999)
            Dim dispAttr = DirectCast(prop.GetCustomAttribute(Of DisplayAttribute)(), DisplayAttribute)
            Dim orderIndex As Integer = 999
            If dispAttr IsNot Nothing Then orderIndex = dispAttr.Order

            ' Lưu vào danh sách để sắp xếp
            columnConfigs.Add(New ColumnConfig With {
                .PropName = prop.Name,
                .HeaderText = headerText,
                .Order = orderIndex
            })
        Next

        ' Sắp xếp theo thứ tự Order và thêm vào DGV
        For Each config In columnConfigs.OrderBy(Function(x) x.Order)
            Dim col As New DataGridViewTextBoxColumn()
            col.DataPropertyName = config.PropName
            col.HeaderText = config.HeaderText
            col.Name = "col_" & config.PropName
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.Columns.Add(col)
        Next

    End Sub

    ' Lớp phụ trợ để sắp xếp cột (Vì VB.NET cũ không hỗ trợ Order nặc danh tốt)
    Private Class ColumnConfig
        Public Property PropName As String
        Public Property HeaderText As String
        Public Property Order As Integer
    End Class


End Module