Imports System.ComponentModel
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json


Public Class ClientModel
    Inherits AModel

    '#Region "Tool"
    <Browsable(False)>
    Public Shared ReadOnly tableName As String = "client"

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
        Return IdConverter.ID_To_Code("CLI", id)
    End Function

    <Browsable(False)>
    Public ReadOnly Property Display As String
        Get
            Return $"{IdConverter.ID_To_Code("CLI", id)} - {name}"
        End Get
    End Property
    '#End Region


#Region "Property"
    <DisplayName("Code")>
    Public ReadOnly Property code As String
        Get
            Return To_Code(id)
        End Get
    End Property

    <DisplayName("Name")>
    Public Property name As String

    <Browsable(False)>
    Public Property datas As String

    <DisplayName("Phone")>
    Public Property phone As String

    <DisplayName("Email")>
    Public Property email As String

    <Browsable(True)>
    <DisplayName("Status")>
    Public Property status As String

    <Browsable(True)>
    <DisplayName("Description")>
    Public Property description As String
#End Region

    Public Shared Function MapToClient(rawData As ClientModel) As ClientModel
        ' 1. Giải mã JSON thành đối tượng Model
        Dim client As ClientModel = JsonConvert.DeserializeObject(Of ClientModel)(rawData.datas)

        Return client
    End Function

End Class
