

Public Class ProductCRUD
    Inherits ACRUDForm

    Protected _data As ProductModel


    Public Sub New(data As ProductModel, Optional isCreate As Boolean = False)

        InitializeComponent()

        Me.isCreate = isCreate
        Me._data = data

        Me.Text = $"{If(isCreate, "New", "Detail")} Product"

        ui_id.Text = If(isCreate, "", _data.code)
        ui_unit_price.Text = If(isCreate, 0.0, _data.unit_price.ToString(":N0"))
        ui_name.Text = If(isCreate, "", _data.name)
        ui_quantity.Text = If(isCreate, 0, _data.quantity)

    End Sub

    Private Sub ui_name_TextChanged(sender As Object, e As EventArgs) Handles ui_name.TextChanged

        isChanged = True
        tool_save.Enabled = True

        _data.name = ui_name.Text
    End Sub

    Private Sub ui_unit_price_TextChanged(sender As Object, e As EventArgs) Handles ui_unit_price.TextChanged

        isChanged = True
        tool_save.Enabled = True

        If Not Decimal.TryParse(ui_unit_price.Text, _data.unit_price) Then

            ui_unit_price.Text = 0.0F
            _data.unit_price = 0.0F
        End If
    End Sub

    Private Sub ui_quantity_TextChanged(sender As Object, e As EventArgs) Handles ui_quantity.TextChanged

        isChanged = True
        tool_save.Enabled = True

        If Not Integer.TryParse(ui_quantity.Text, _data.quantity) Then

            ui_quantity.Text = 0
            _data.quantity = 0
        End If
    End Sub
End Class
