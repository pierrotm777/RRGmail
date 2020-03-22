Imports System.Collections.Generic
Imports System.IO
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports OpenPop.Common.Logging
Imports OpenPop.Mime
Imports OpenPop.Mime.Decode
Imports OpenPop.Mime.Header
Imports OpenPop.Pop3

Namespace OpenPop
    ''' <summary>
    ''' These are small examples problems for the
    ''' <see cref="OpenPop"/>.NET POP3 library
    ''' </summary>
    Public Class PopModule
        ''' <summary>
        ''' Example showing:
        '''  - how to fetch all messages from a POP3 server
        ''' </summary>
        ''' <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        ''' <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        ''' <param name="useSsl">Whether or not to use SSL to connect to server</param>
        ''' <param name="username">Username of the user on the server</param>
        ''' <param name="password">Password of the user on the server</param>
        ''' <returns>All Messages on the POP3 server</returns>
        Public Shared Function FetchAllMessages(ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String) As List(Of Message)
            ' The client disconnects from the server when being disposed
            Using client As New Pop3Client()
                ' Connect to the server
                client.Connect(hostname, port, useSsl)

                ' Authenticate ourselves towards the server
                client.Authenticate(username, password)

                ' Get the number of messages in the inbox
                Dim messageCount As Integer = client.GetMessageCount()

                ' We want to download all messages
                Dim allMessages As New List(Of Message)(messageCount)

                ' Messages are numbered in the interval: [1, messageCount]
                ' Ergo: message numbers are 1-based.
                For i As Integer = 1 To messageCount
                    allMessages.Add(client.GetMessage(i))
                Next

                ' Now return the fetched messages
                Return allMessages
            End Using
        End Function

        ''' <summary>
        ''' Example showing:
        '''  - how to delete fetch an emails headers only
        '''  - how to delete a message from the server
        ''' </summary>
        ''' <param name="client">A connected and authenticated Pop3Client from which to delete a message</param>
        ''' <param name="messageId">A message ID of a message on the POP3 server. Is located in <see cref="MessageHeader.MessageId"/></param>
        ''' <returns><see langword="true"/> if message was deleted, <see langword="false"/> otherwise</returns>
        Public Function DeleteMessageByMessageId(ByVal client As Pop3Client, ByVal messageId As String) As Boolean
            ' Get the number of messages on the POP3 server
            Dim messageCount As Integer = client.GetMessageCount()

            ' Run trough each of these messages and download the headers
            For messageItem As Integer = messageCount To 1 Step -1
                ' If the Message ID of the current message is the same as the parameter given, delete that message
                If client.GetMessageHeaders(messageItem).MessageId = messageId Then
                    ' Delete
                    client.DeleteMessage(messageItem)
                    Return True
                End If
            Next

            ' We did not find any message with the given messageId, report this back
            Return False
        End Function

        ''' <summary>
        ''' Example showing:
        '''  - how to a find plain text version in a Message
        '''  - how to save MessageParts to file
        ''' </summary>
        ''' <param name="message">The message to examine for plain text</param>
        Public Shared Sub FindPlainTextInMessage(ByVal message As Message)
            Dim plainText As MessagePart = message.FindFirstPlainTextVersion()
            If plainText IsNot Nothing Then
                ' Save the plain text to a file, database or anything you like
                plainText.Save(New FileInfo("plainText.txt"))
            End If
        End Sub

        ''' <summary>
        ''' Example showing:
        '''  - how to find a html version in a Message
        '''  - how to save MessageParts to file
        ''' </summary>
        ''' <param name="message">The message to examine for html</param>
        Public Shared Sub FindHtmlInMessage(ByVal message As Message)
            Dim html As MessagePart = message.FindFirstHtmlVersion()
            If html IsNot Nothing Then
                ' Save the plain text to a file, database or anything you like
                html.Save(New FileInfo("html.txt"))
            End If
        End Sub

        ''' <summary>
        ''' Example showing:
        '''  - how to find a MessagePart with a specified MediaType
        '''  - how to get the body of a MessagePart as a string
        ''' </summary>
        ''' <param name="message">The message to examine for xml</param>
        Public Shared Sub FindXmlInMessage(ByVal message As Message)
            Dim xml As MessagePart = message.FindFirstMessagePartWithMediaType("text/xml")
            If xml IsNot Nothing Then
                ' Get out the XML string from the email
                Dim xmlString As String = xml.GetBodyAsText()

                Dim doc As New System.Xml.XmlDocument()

                ' Load in the XML read from the email
                doc.LoadXml(xmlString)

                ' Save the xml to the filesystem
                doc.Save("test.xml")
            End If
        End Sub

        ''' <summary>
        ''' Example showing:
        '''  - how to fetch only headers from a POP3 server
        '''  - how to examine some of the headers
        '''  - how to fetch a full message
        '''  - how to find a specific attachment and save it to a file
        ''' </summary>
        ''' <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        ''' <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        ''' <param name="useSsl">Whether or not to use SSL to connect to server</param>
        ''' <param name="username">Username of the user on the server</param>
        ''' <param name="password">Password of the user on the server</param>
        ''' <param name="messageNumber">
        ''' The number of the message to examine.
        ''' Must be in range [1, messageCount] where messageCount is the number of messages on the server.
        ''' </param>
        Public Shared Sub HeadersFromAndSubject(ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String, ByVal messageNumber As Integer)
            ' The client disconnects from the server when being disposed
            Using client As New Pop3Client()
                ' Connect to the server
                client.Connect(hostname, port, useSsl)

                ' Authenticate ourselves towards the server
                client.Authenticate(username, password)

                ' We want to check the headers of the message before we download
                ' the full message
                Dim headers As MessageHeader = client.GetMessageHeaders(messageNumber)

                Dim from As RfcMailAddress = headers.From
                Dim subject As String = headers.Subject

                ' Only want to download message if:
                '  - is from test@xample.com
                '  - has subject "Some subject"
                If from.HasValidMailAddress AndAlso from.Address.Equals("test@example.com") AndAlso "Some subject".Equals(subject) Then
                    ' Download the full message
                    Dim message As Message = client.GetMessage(messageNumber)

                    ' We know the message contains an attachment with the name "useful.pdf".
                    ' We want to save this to a file with the same name
                    For Each attachment As MessagePart In message.FindAllAttachments()
                        If attachment.FileName.Equals("useful.pdf") Then
                            ' Save the raw bytes to a file
                            File.WriteAllBytes(attachment.FileName, attachment.Body)
                        End If
                    Next
                End If

            End Using
        End Sub

        ''' <summary>
        ''' Example showing:
        '''  - how to delete a specific message from a server
        ''' </summary>
        ''' <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        ''' <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        ''' <param name="useSsl">Whether or not to use SSL to connect to server</param>
        ''' <param name="username">Username of the user on the server</param>
        ''' <param name="password">Password of the user on the server</param>
        ''' <param name="messageNumber">
        ''' The number of the message to delete.
        ''' Must be in range [1, messageCount] where messageCount is the number of messages on the server.
        ''' </param>
        Public Shared Sub DeleteMessageOnServer(ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String, ByVal messageNumber As Integer)
            ' The client disconnects from the server when being disposed
            Using client As New Pop3Client()
                ' Connect to the server
                client.Connect(hostname, port, useSsl)

                ' Authenticate ourselves towards the server
                client.Authenticate(username, password)

                ' Mark the message as deleted
                ' Notice that it is only MARKED as deleted
                ' POP3 requires you to "commit" the changes
                ' which is done by sending a QUIT command to the server
                ' You can also reset all marked messages, by sending a RSET command.

                ' When a QUIT command is sent to the server, the connection between them are closed.
                ' When the client is disposed, the QUIT command will be sent to the server
                ' just as if you had called the Disconnect method yourself.
                client.DeleteMessage(messageNumber)
            End Using
        End Sub

        ''' <summary>
        ''' Example showing:
        '''  - how to use UID's (unique ID's) of messages from the POP3 server
        '''  - how to download messages not seen before
        '''    (notice that the POP3 protocol cannot see if a message has been read on the server
        '''     before. Therefore the client need to maintain this state for itself)
        ''' </summary>
        ''' <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        ''' <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        ''' <param name="useSsl">Whether or not to use SSL to connect to server</param>
        ''' <param name="username">Username of the user on the server</param>
        ''' <param name="password">Password of the user on the server</param>
        ''' <param name="seenUids">
        ''' List of UID's of all messages seen before.
        ''' New message UID's will be added to the list.
        ''' Consider using a HashSet if you are using >= 3.5 .NET
        ''' </param>
        ''' <returns>A List of new Messages on the server</returns>
        Public Shared Function FetchUnseenMessages(ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String, ByVal seenUids As List(Of String)) As List(Of Message)
            ' The client disconnects from the server when being disposed
            Using client As New Pop3Client()
                ' Connect to the server
                client.Connect(hostname, port, useSsl)

                ' Authenticate ourselves towards the server
                client.Authenticate(username, password)

                ' Fetch all the current uids seen
                Dim uids As List(Of String) = client.GetMessageUids()

                ' Create a list we can return with all new messages
                Dim newMessages As New List(Of Message)()

                ' All the new messages not seen by the POP3 client
                For i As Integer = 0 To uids.Count - 1
                    Dim currentUidOnServer As String = uids(i)
                    If Not seenUids.Contains(currentUidOnServer) Then
                        ' We have not seen this message before.
                        ' Download it and add this new uid to seen uids

                        ' the uids list is in messageNumber order - meaning that the first
                        ' uid in the list has messageNumber of 1, and the second has 
                        ' messageNumber 2. Therefore we can fetch the message using
                        ' i + 1 since messageNumber should be in range [1, messageCount]
                        Dim unseenMessage As Message = client.GetMessage(i + 1)

                        ' Add the message to the new messages
                        newMessages.Add(unseenMessage)

                        ' Add the uid to the seen uids, as it has now been seen
                        seenUids.Add(currentUidOnServer)
                    End If
                Next

                ' Return our new found messages
                Return newMessages
            End Using
        End Function

        ''' <summary>
        ''' Example showing:
        '''  - how to set timeouts
        '''  - how to override the SSL certificate checks with your own implementation
        ''' </summary>
        ''' <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        ''' <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        ''' <param name="timeouts">Read and write timeouts used by the Pop3Client</param>
        Public Shared Sub BypassSslCertificateCheck(ByVal hostname As String, ByVal port As Integer, ByVal timeouts As Integer)
            ' The client disconnects from the server when being disposed
            Using client As New Pop3Client()
                ' Connect to the server using SSL with specified settings
                ' true here denotes that we connect using SSL
                ' The certificateValidator can validate the SSL certificate of the server.
                ' This might be needed if the server is using a custom normally untrusted certificate

                ' Do something extra now that we are connected to the server
                client.Connect(hostname, port, True, timeouts, timeouts, AddressOf certificateValidator)
            End Using
        End Sub

        Private Shared Function certificateValidator(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslpolicyerrors As SslPolicyErrors) As Boolean
            ' We should check if there are some SSLPolicyErrors, but here we simply say that
            ' the certificate is okay - we trust it.
            Return True
        End Function

        ''' <summary>
        ''' Example showing:
        '''  - how to save a message to a file
        '''  - how to load a message from a file at a later point
        ''' </summary>
        ''' <param name="message">The message to save and load at a later point</param>
        ''' <returns>The Message, but loaded from the file system</returns>
        Public Shared Function SaveAndLoadFullMessage(ByVal message__1 As Message) As Message
            ' FileInfo about the location to save/load message
            Dim file As New FileInfo("someFile.eml")

            ' Save the full message to some file
            message__1.Save(file)

            ' Now load the message again. This could be done at a later point
            Dim loadedMessage As Message = Message.Load(file)

            ' use the message again
            Return loadedMessage
        End Function

        ''' <summary>
        ''' Example showing:
        '''  - How to change logging
        '''  - How to implement your own logger
        ''' </summary>
        Public Shared Sub ChangeLogging()
            ' All logging is sent trough logger defined at DefaultLogger.Log
            ' The logger can be changed by calling DefaultLogger.SetLog(someLogger)

            ' By default all logging is sent to the System.Diagnostics.Trace facilities.
            ' These are not very useful if you are not debugging
            ' Instead, lets send logging to a file:
            DefaultLogger.SetLog(New FileLogger())
            FileLogger.LogFile = New FileInfo("MyLoggingFile.log")

            ' It is also possible to implement your own logging:
            DefaultLogger.SetLog(New MyOwnLogger())
        End Sub

        Private Class MyOwnLogger
            'Implements ILog
            Public Sub LogError(ByVal message As String)
                Console.WriteLine("ERROR!!!: " & message)
            End Sub

            Public Sub LogDebug(ByVal message As String)
                ' Dont want to log debug messages
            End Sub
        End Class

        ''' <summary>
        ''' Example showing:
        '''  - How to provide custom Encoding class
        '''  - How to use UTF8 as default Encoding
        ''' </summary>
        ''' <param name="customEncoding">Own Encoding implementation</param>
        Public Sub InsertCustomEncodings(ByVal customEncoding As Encoding)
            ' Lets say some email contains a characterSet of "iso-9999-9" which
            ' is fictional, but is really just UTF-8.
            ' Lets add that mapping to the class responsible for finding
            ' the Encoding from the name of it
            EncodingFinder.AddMapping("iso-9999-9", Encoding.UTF8)

            ' It is also possible to implement your own Encoding if
            ' the framework does not provide what you need
            EncodingFinder.AddMapping("specialEncoding", customEncoding)

            ' Now, if the EncodingFinder is not able to find an encoding, lets
            ' see if we can find one ourselves
            EncodingFinder.FallbackDecoder = AddressOf CustomFallbackDecoder
        End Sub

        Private Function CustomFallbackDecoder(ByVal characterSet As String) As Encoding
            ' Is it a "foo" encoding?
            If characterSet.StartsWith("foo") Then
                Return Encoding.ASCII
            End If
            ' then use ASCII
            ' If no special encoding could be found, provide UTF8 as default.
            ' You can also return null here, which would tell OpenPop that
            ' no encoding could be found. This will then throw an exception.
            Return Encoding.UTF8
        End Function

        ' Other examples to show, that is in the library
        ' Show how to build a TreeNode representation of the Message hierarchy using the
        ' TreeNodeBuilder class in OpenPopTest
    End Class
End Namespace
