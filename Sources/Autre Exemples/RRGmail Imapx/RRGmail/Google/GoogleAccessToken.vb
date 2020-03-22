Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class GoogleAccessToken
    Public Property refresh_token() As String
        Get
            Return m_refresh_token
        End Get
        Set(value As String)
            m_refresh_token = Value
        End Set
    End Property
    Private m_refresh_token As String
    Public Property expires_in() As String
        Get
            Return m_expires_in
        End Get
        Set(value As String)
            m_expires_in = Value
        End Set
    End Property
    Private m_expires_in As String
    Public Property access_token() As String
        Get
            Return m_access_token
        End Get
        Set(value As String)
            m_access_token = Value
        End Set
    End Property
    Private m_access_token As String
End Class
