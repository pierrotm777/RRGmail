Imports System.Windows.Forms

Public Class JSsetTimeout

    Public res As Object = Nothing
    Dim WithEvents tm As Timer = Nothing
    Dim _MethodName As String
    Dim _args() As Object
    Dim _ClassInstacne As Object = Nothing
    Shared IsON As String

    Public Shared Sub SetTimeout(ByVal ClassInstacne As Object, ByVal obj As String, ByVal TimeSpan As Integer, ByVal ParamArray args() As Object)
        Dim jssto As New JSsetTimeout(ClassInstacne, obj, TimeSpan, args)
    End Sub

    Public Sub New(ByVal ClassInstacne As Object, ByVal obj As String, ByVal TimeSpan As Integer, ByVal ParamArray args() As Object)
        If obj IsNot Nothing Then
            _MethodName = obj
            _args = args
            _ClassInstacne = ClassInstacne
            tm = New Timer With {.Interval = TimeSpan, .Enabled = False}
            AddHandler tm.Tick, AddressOf tm_Tick
            tm.Start()
            IsON = "ON"
        End If
    End Sub

    ''' <summary>
    ''' Get timer output.
    ''' </summary>
    Shared Function GetOutput() As String
        'Return String.Join("<br>", _list)
        Return IsON
    End Function

    Private Sub tm_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tm.Tick
        IsON = "OFF"
        tm.Stop()
        RemoveHandler tm.Tick, AddressOf tm_Tick
        If Not String.IsNullOrEmpty(_MethodName) AndAlso _ClassInstacne IsNot Nothing Then
            res = CallByName(_ClassInstacne, _MethodName, CallType.Method, _args)
        Else
            res = Nothing
        End If
    End Sub
End Class
