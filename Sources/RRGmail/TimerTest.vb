Imports Microsoft.VisualBasic
Imports System.Timers

Public Class TimerTest
    Shared _timer As Timer
    'Shared _list As List(Of String) = New List(Of String)
    Shared MyDate As String

    ''' <summary>
    ''' Start the timer.
    ''' </summary>
    Shared Sub StartTimer()
        _timer = New Timer(1000)
        AddHandler _timer.Elapsed, New ElapsedEventHandler(AddressOf Handler)
        _timer.Enabled = True
    End Sub

    ''' <summary>
    ''' Stop the timer.
    ''' </summary>
    Shared Sub StopTimer()
        _timer.Enabled = False
    End Sub

    ''' <summary>
    ''' Get timer output.
    ''' </summary>
    Shared Function GetOutput() As String
        'Return String.Join("<br>", _list)
        Return MyDate
    End Function

    ''' <summary>
    ''' Timer event handler.
    ''' </summary>
    Shared Sub Handler(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        '_list.Add(DateTime.Now.ToString())
        MyDate = DateTime.Now.ToString()
    End Sub
End Class
