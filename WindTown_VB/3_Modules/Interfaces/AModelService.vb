Imports WindTown_VB.DatabaseConfig

Namespace WindTown.Core.Shared.Interfaces

    Public MustInherit Class AModelService(Of MODEL As {Class, New}, REPOSITORY As {Class, New})

        ' ===== Repository instance =====
        Protected ReadOnly _Repository As REPOSITORY = New REPOSITORY()

        ' ===== Dictionary Intent → Func =====
        Protected IntentDict As New Dictionary(Of EIntent, Func(Of MODEL, Response(Of MODEL)))()

        ' ===== Process method =====
        Public Sub Process(intent As EIntent, param As MODEL, ByRef result As Response(Of MODEL))
            result = New Response(Of MODEL)(False)

            Dim action As Func(Of MODEL, Response(Of MODEL)) = Nothing
            If IntentDict.TryGetValue(intent, action) Then
                result = action(param)
            Else
                Throw New ArgumentException($"Intent {intent} not registered in {NameOf(MODEL)}")
            End If
        End Sub

        ' ===== Abstract methods =====
        Protected MustOverride Function Selects(data As MODEL) As Response(Of MODEL)
        Protected MustOverride Function Update(data As MODEL) As Response(Of MODEL)
        Protected MustOverride Function Insert(data As MODEL) As Response(Of MODEL)
        Protected MustOverride Function Delete(data As MODEL) As Response(Of MODEL)

    End Class

End Namespace
