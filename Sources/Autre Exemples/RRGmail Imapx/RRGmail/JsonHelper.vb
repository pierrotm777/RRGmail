Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.Serialization.Json

Public Class JsonHelper
    Public Shared Function [To](Of T)(obj As T) As String
        Dim serializer = New DataContractJsonSerializer(obj.[GetType]())
        Using ms = New MemoryStream()
            serializer.WriteObject(ms, obj)
            Dim retVal As String = Encoding.[Default].GetString(ms.ToArray())
            Return retVal
        End Using
    End Function

    Public Shared Function From(Of T)(json As String) As T
        Dim obj = Activator.CreateInstance(Of T)()
        Using ms = New MemoryStream(Encoding.Unicode.GetBytes(json))
            Dim serializer = New DataContractJsonSerializer(obj.[GetType]())
            obj = DirectCast(serializer.ReadObject(ms), T)
        End Using

        Return obj
    End Function
End Class
