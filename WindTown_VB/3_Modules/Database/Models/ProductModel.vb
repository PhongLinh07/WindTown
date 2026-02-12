Imports System.ComponentModel

Public Class ProductModel
    Inherits AModel

    '#Region "Tool"
    <Browsable(False)>
    Public Shared ReadOnly tableName As String = "product"

    <Browsable(False)>
    Public Overrides ReadOnly Property GetTableName As String
        Get
            Return tableName
        End Get
    End Property

    <Browsable(False)>
    Public Shared Function To_ID(code As String) As Integer
        Return IdConverter.Code_To_ID(code)
    End Function

    <Browsable(False)>
    Public Shared Function To_Code(id As Integer) As String
        Return IdConverter.ID_To_Code("PRO", id)
    End Function

    <Browsable(False)>
    Public ReadOnly Property Display As String
        Get
            Return $"{IdConverter.ID_To_Code("PRO", id)} - {name}"
        End Get
    End Property
    '#End Region


    '#Region "Property"
    <DisplayName("Code")>
    Public ReadOnly Property code As String
        Get
            Return To_Code(id)
        End Get
    End Property

    <DisplayName("Name")>
    Public Property name As String

    <DisplayName("Unit Price")>
    Public Property unit_price As Single

    <DisplayName("Quantity")>
    Public Property quantity As Integer

    <Browsable(False)>
    <DisplayName("Status")>
    Public Property status As String

    <Browsable(False)>
    <DisplayName("Description")>
    Public Property description As String
    '#End Region

End Class
