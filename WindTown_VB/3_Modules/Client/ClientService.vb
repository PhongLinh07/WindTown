Imports WindTown_VB.DatabaseConfig
Imports WindTown_VB.WindTown.Core.Shared.Interfaces
Imports WindTown_VB.WindTown.Modules.Assignment

Friend Class ClientService
    Inherits AModelService(Of ClientModel, ClientRepository)

    ' ===== Constructor =====
    Public Sub New()
        ' Register intents
        IntentDict(EIntent.Selects) = AddressOf Selects
        IntentDict(EIntent.Select1) = AddressOf Select1
        IntentDict(EIntent.Update) = AddressOf Update
        IntentDict(EIntent.Insert) = AddressOf Insert
        IntentDict(EIntent.Delete) = AddressOf Delete
    End Sub

    ' ===== Selects all =====
    Protected Overrides Function Selects(data As ClientModel) As Response(Of ClientModel)
        Dim state As New Response(Of ClientModel)(False)
        If data Is Nothing Then Return state

        Try
            _Repository.Selects(data, state.Datas)
            state.IsSuccess = True
        Catch ex As Exception
            state.ErrorMessage = ex.Message
        End Try

        Return state
    End Function

    ' ===== Select single =====
    Private Function Select1(data As ClientModel) As Response(Of ClientModel)
        Dim state As New Response(Of ClientModel)(False)
        If data Is Nothing Then Return state

        Try
            Dim result As ClientModel = Nothing
            _Repository.Select(data, result)
            state.Data = result
            state.IsSuccess = (result IsNot Nothing)
        Catch ex As Exception
            state.ErrorMessage = ex.Message
        End Try

        Return state
    End Function


    ' ===== Update =====
    Protected Overrides Function Update(data As ClientModel) As Response(Of ClientModel)
        Dim state As New Response(Of ClientModel)(False)
        If data Is Nothing Then Return state

        Try
            Dim result As ClientModel = Nothing
            _Repository.Update(data, result)
            state.Data = result
            state.IsSuccess = True
        Catch ex As Exception
            state.ErrorMessage = ex.Message
        End Try

        Return state
    End Function

    ' ===== Insert =====
    Protected Overrides Function Insert(data As ClientModel) As Response(Of ClientModel)
        Dim state As New Response(Of ClientModel)(False)
        If data Is Nothing Then Return state

        Try
            Dim result As ClientModel = Nothing
            _Repository.Insert(data, result)
            state.Data = result
            state.IsSuccess = True
        Catch ex As Exception
            state.ErrorMessage = ex.Message
        End Try

        Return state
    End Function

    ' ===== Delete =====
    Protected Overrides Function Delete(data As ClientModel) As Response(Of ClientModel)
        Dim state As New Response(Of ClientModel)(False)
        If data Is Nothing Then Return state

        Try
            Dim result As Boolean = False
            _Repository.Delete(data, result)
            state.IsSuccess = result
        Catch ex As Exception
            state.ErrorMessage = ex.Message
        End Try

        Return state
    End Function

End Class