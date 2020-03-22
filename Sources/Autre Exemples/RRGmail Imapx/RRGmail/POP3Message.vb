Imports System
Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Module POP3Message1


    Dim Server As TcpClient
    Dim NetStrm As NetworkStream
    Dim RdStrm As StreamReader
    Dim _Strm As Net.Security.SslStream

    Public Function connect() As Integer
        Dim POP3Account As String
        POP3Account = "pop.gmail.com"
        If POP3Account.Trim = "" Then Exit Function
        Try
            Server = New TcpClient(POP3Account.Trim, 995)
            NetStrm = Server.GetStream
            _Strm = New Net.Security.SslStream(Server.GetStream())
            DirectCast(_Strm, Net.Security.SslStream).AuthenticateAsClient("pop.gmail.com")
            RdStrm = New StreamReader(Server.GetStream)
        Catch exc As Exception
            MsgBox(exc.Message)

            Exit Function
        End Try

        Dim user As String
        user = "******@gmail.com"
        Dim data As String = "USER " + user.Trim + vbCrLf
        Dim szData() As Byte = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(szData, 0, szData.Length)
        Dim POPResponse As String
        POPResponse = RdStrm.ReadLine
        If POPResponse.Substring(0, 4) = "-ERR" Then
            MsgBox("Invalid user Name")
            Return -1
        End If
        Dim password As String
        password = "*******"
        data = "PASS " & password & vbCrLf
        szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(szData, 0, szData.Length)
        POPResponse = RdStrm.ReadLine
        If POPResponse.Substring(0, 4) = "-ERR" Then
            MsgBox("Invalid Passwprd")
            Return (-1)
        End If
        data = "STAT" + vbCrLf
        szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(szData, 0, szData.Length)
        POPResponse = RdStrm.ReadLine
        If POPResponse.Substring(0, 4) = "-ERR" Then
            MsgBox("could not log your in")
            Return -1
        End If
        data = "Stat" + vbCrLf
        szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(szData, 0, szData.Length)
        POPResponse = RdStrm.ReadLine
        If POPResponse.Substring(0, 4) = "-ERR" Then
            MsgBox("could not log your in")
            Return -1
        End If
        Dim parts() As String
        parts = POPResponse.Split(" ")
        Dim messages, totsize As Integer

        'messages = parts(3)
        messages = CInt(parts(1))
        Return messages



    End Function
    Public Function DeleteMessage(ByVal msgIndex As Integer)
        Dim data As String = "DELE " & msgIndex.ToString & vbCrLf
        Dim SzData() As Byte = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(SzData, 0, SzData.Length)
        Dim tmpString As String = RdStrm.ReadLine()
        If tmpString.Substring(0, 4) = "-ERR" Then
            MsgBox("Could Not Delete Message")
            Return (-1)
        Else
            Return 11
        End If
    End Function
    Public Function Quit()
        Dim data As String = "Quit " & vbCrLf
        Dim szData() As Byte = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray())
        NetStrm.Write(szData, 0, szData.Length)
        Dim tmpString As String = RdStrm.ReadLine()
    End Function
    Public Structure Message
        Dim _From As String
        Dim _To As String
        Dim _Date As String
        Dim _Subject As String
        Dim _CC As String
        Dim _BCC As String
        Dim _Body As String
        Dim _Received As String
    End Structure
    Public Function CreateFromText(ByVal strMessage As String) As Message
        Dim Mssg As New Message
        Dim brkPos As Integer
        Dim Header As String
        Dim Headers() As String
        Dim Body As String
        Dim vField As Object
        Dim strHeader As String
        Dim HeaderName As String
        Dim HeaderValue As String


        brkPos = InStr(1, strMessage, vbCrLf & vbCrLf)
        If brkPos Then
            Header = strMessage.Substring(0, brkPos - 1)
            Body = strMessage.Substring(brkPos + 1, _
            strMessage.Length - Header.Length - 3)
            Mssg._Body = Body
        Else
            Throw New Exception("Invalid Message Format")
            Exit Function
        End If
        Headers = Split(Header, vbCrLf)
        Dim _header As String
        For Each _header In Headers
            brkPos = _header.IndexOf(":")
            If brkPos >= 0 Then
                HeaderName = _header.Substring(0, brkPos)
            Else
                HeaderName = ""
            End If
            HeaderValue = _header.Substring(brkPos + 1)
            Select Case HeaderName.ToLower
                Case "received"
                    Mssg._Received = HeaderValue
                Case "from"
                    Mssg._From = HeaderValue
                Case "to"
                    Mssg._To = HeaderValue
                Case "cc"
                    Mssg._CC = HeaderValue
                Case "bcc"
                    Mssg._BCC = HeaderValue
                Case "subject"
                    Mssg._Subject = HeaderValue
                Case "date"
                    Mssg._Date = HeaderValue
            End Select
        Next
        Return Mssg
    End Function
    Function GetMessage(ByVal msgindex As Integer) As String
        Dim tmpString As String
        Dim Data As String
        Dim SzData() As Byte
        Dim msg As String
        Try
            Data = "RETR " & msgindex.ToString & vbCrLf
            SzData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray())
            NetStrm.Write(SzData, 0, SzData.Length)
            tmpString = RdStrm.ReadLine()
            If tmpString.Substring(0, 4) <> "-ERR" Then
                While (tmpString <> ".")
                    msg = msg & tmpString & vbCrLf
                    tmpString = RdStrm.ReadLine
                End While
            End If
        Catch exc As InvalidOperationException
            MsgBox("Message Retrival Failed: " & vbCrLf & Err.ToString())
        End Try
        Return msg
    End Function
End Module
