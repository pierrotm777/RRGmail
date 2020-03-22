Imports System.Collections.Generic
Imports System.Linq
Imports System.Text


Public Class GoogleEmail
    Public Property value() As String
        Get
            Return m_value
        End Get
        Set(value As String)
            m_value = Value
        End Set
    End Property
    Private m_value As String
End Class
