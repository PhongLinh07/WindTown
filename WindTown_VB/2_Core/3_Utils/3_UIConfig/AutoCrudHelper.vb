Imports System.ComponentModel
Imports System.Reflection

Public Module AutoCrudHelper
    ''' <summary>
    ''' Tự động tạo các TextBox/Input dựa trên Model và nạp vào một Panel
    ''' </summary>
    Public Sub BuildDynamicForm(container As Control, model As Object)
        container.Controls.Clear()

        ' 1. Tạo một TableLayoutPanel để tự động dàn hàng
        Dim layout As New TableLayoutPanel()
        layout.Dock = DockStyle.Top
        layout.ColumnCount = 2
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30)) ' Label chiếm 30%
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70)) ' Input chiếm 70%
        layout.AutoSize = True

        ' 2. Quét các thuộc tính của Model
        Dim props = model.GetType().GetProperties()
        Dim rowIndex As Integer = 0

        For Each prop In props
            ' Bỏ qua nếu là cột ẩn hoặc cột ID (thường ID không cho sửa trực tiếp)
            Dim browsAttr = prop.GetCustomAttribute(Of BrowsableAttribute)()
            If browsAttr IsNot Nothing AndAlso Not browsAttr.Browsable Then Continue For
            If prop.Name.ToLower() = "id" Or prop.Name.ToLower() = "datas" Then Continue For

            ' Lấy tên hiển thị
            Dim dispAttr = prop.GetCustomAttribute(Of DisplayNameAttribute)()
            Dim labelText As String = If(dispAttr IsNot Nothing, dispAttr.DisplayName, prop.Name)

            ' 3. Tạo Label
            Dim lbl As New Label() With {
                .Text = labelText & ":",
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleRight,
                .Font = New Font("Segoe UI", 9)
            }

            ' 4. Tạo Input Control tương ứng với kiểu dữ liệu
            Dim inputCtrl As Control = CreateInputControl(prop, model)
            inputCtrl.Dock = DockStyle.Top
            inputCtrl.Width = 200 ' Độ rộng mặc định

            ' 5. Đưa vào TableLayoutPanel
            layout.Controls.Add(lbl, 0, rowIndex)
            layout.Controls.Add(inputCtrl, 1, rowIndex)

            rowIndex += 1
        Next

        container.Controls.Add(layout)
    End Sub

    Private Function CreateInputControl(prop As PropertyInfo, model As Object) As Control
        Dim ctrl As Control

        ' Tùy biến loại Control dựa trên kiểu dữ liệu
        If prop.PropertyType = GetType(Boolean) Then
            Dim chk As New CheckBox() With {.Text = ""}
            chk.DataBindings.Add("Checked", model, prop.Name, True, DataSourceUpdateMode.OnPropertyChanged)
            ctrl = chk
        Else
            Dim txt As New TextBox() With {.Width = 200, .Font = New Font("Segoe UI", 10)}
            ' Data Binding: Khi gõ vào TextBox, thuộc tính của Model tự cập nhật
            txt.DataBindings.Add("Text", model, prop.Name, True, DataSourceUpdateMode.OnPropertyChanged)

            ' Kiểm tra ReadOnly
            Dim readOnlyAttr = prop.GetCustomAttribute(Of ReadOnlyAttribute)()
            If readOnlyAttr IsNot Nothing AndAlso readOnlyAttr.IsReadOnly Then
                txt.ReadOnly = True
                txt.BackColor = Color.LightGray
            End If

            ctrl = txt
        End If

        Return ctrl
    End Function
End Module