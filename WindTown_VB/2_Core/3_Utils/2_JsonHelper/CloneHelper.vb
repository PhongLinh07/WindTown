Imports Newtonsoft.Json


Namespace Utils

    Public Module CloneHelper

        Private ReadOnly _settings As New JsonSerializerSettings() With {
            .ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            .NullValueHandling = NullValueHandling.Ignore
        }

        Public Function DeepClone(Of T)(obj As T) As T
            Dim json As String = JsonConvert.SerializeObject(obj, _settings)
            Return JsonConvert.DeserializeObject(Of T)(json, _settings)
        End Function

    End Module

End Namespace
