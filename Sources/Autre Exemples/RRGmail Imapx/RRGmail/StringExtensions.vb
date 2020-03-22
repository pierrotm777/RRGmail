Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text


'Public NotInheritable Class StringExtensions
'    Private Sub New()
'    End Sub
'    <System.Runtime.CompilerServices.Extension()> _
'    Public Shared Function MD5(input As String) As String
'        Dim result As Byte() = TryCast(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(Encoding.UTF8.GetBytes(input))
'        Dim output = New StringBuilder()
'        For Each t As Byte In result
'            output.Append(t.ToString("x2", CultureInfo.InvariantCulture))
'        Next
'        Return output.ToString()
'    End Function
'End Class
