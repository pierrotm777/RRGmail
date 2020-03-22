Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class ServerCallCompletedEventArgs
    Inherits EventArgs
    Public Property Result() As Boolean
        Get
            Return m_Result
        End Get
        Set(value As Boolean)
            m_Result = Value
        End Set
    End Property
    Private m_Result As Boolean
    Public Property Arg() As Object
        Get
            Return m_Arg
        End Get
        Set(value As Object)
            m_Arg = Value
        End Set
    End Property
    Private m_Arg As Object
    Public Property Exception() As Exception
        Get
            Return m_Exception
        End Get
        Set(value As Exception)
            m_Exception = Value
        End Set
    End Property
    Private m_Exception As Exception

    Public Sub New(Optional result__1 As Boolean = True, Optional exception__2 As Exception = Nothing, Optional arg__3 As Object = Nothing)
        Result = result__1
        Exception = exception__2
        Arg = arg__3
    End Sub
End Class

