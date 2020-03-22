Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class GoogleProfile
    Public Property id() As String
        Get
            Return m_id
        End Get
        Set(value As String)
            m_id = Value
        End Set
    End Property
    Private m_id As String
    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(value As String)
            m_email = Value
        End Set
    End Property
    Private m_email As String
End Class
