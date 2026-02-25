Imports Newtonsoft.Json

Namespace Utils

    Public Module CloneHelper

        Public Function DeepClone(Of T)(obj As T) As T
            Dim json As String = JsonConvert.SerializeObject(obj)
            Return JsonConvert.DeserializeObject(Of T)(json)
        End Function

    End Module

End Namespace