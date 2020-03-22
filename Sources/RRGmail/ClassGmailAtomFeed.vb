Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Globalization

Namespace RC.Gmail

	''' <summary>
	''' Provides an easy method of retreiving and programming against gmail atom feeds.
	''' </summary>
    Public Class ClassGmailAtomFeed

#Region "Private Variables"

        'private static string	_gmailFeedUrl	= "https://gmail.google.com/gmail/feed/atom";
        Private Shared _gmailFeedUrl As String = "https://mail.google.com/mail/feed/atom"
        Private _gmailUserName As String = String.Empty
        Private _gmailPassword As String = String.Empty
        Private _feedLabel As String = String.Empty
        Private _title As String = String.Empty
        Private _message As String = String.Empty
        Private _modified As DateTime = DateTime.MinValue
        Private _feedXml As XmlDocument = Nothing

        Private _entryCol As AtomFeedEntryCollection = Nothing

#End Region


        ''' <summary>
        ''' Constructor, creates the gmail atom feed object. 
        ''' <note>
        ''' Creating the object does not get the feed, the <c>GetFeed</c> method must be called to get the current feed.
        ''' </note>
        ''' </summary>
        ''' <param name="gmailUserName">The username of the gmail account that the message will be sent through</param>
        ''' <param name="gmailPassword">The password of the gmail account that the message will be sent through</param>
        Public Sub New(gmailUserName As String, gmailPassword As String)
            _gmailUserName = gmailUserName
            _gmailPassword = gmailPassword
            _entryCol = New AtomFeedEntryCollection()
        End Sub

        ''' <summary>
        ''' Gets the current atom feed for the specified account and loads all properties and collections with the feed data. Any existing data will be replaced by the new feed.
        ''' <note>
        ''' If the <c>FeedLabel</c> property equals <c>string.Empty</c> the feed for the inbox will be retreived.
        ''' </note>
        ''' </summary>
        Public Sub GetFeed()
            Dim sBuilder As New StringBuilder()
            Dim buffer As Byte() = New Byte(8191) {}
            Dim byteCount As Integer = 0

            Try
                Dim url As String = ClassGmailAtomFeed.FeedUrl

                If Me.FeedLabel <> String.Empty Then
                    url += If((url.EndsWith("/")), String.Empty, "/")
                    url += Me.FeedLabel
                End If

                Dim credentials As System.Net.NetworkCredential = New NetworkCredential(Me.GmailUserName, Me.GmailPassword)

                Dim webRequest__1 As WebRequest = WebRequest.Create(url)
                webRequest__1.Credentials = credentials

                Dim webResponse As WebResponse = webRequest__1.GetResponse()
                Dim stream As Stream = webResponse.GetResponseStream()

                While (InlineAssignHelper(byteCount, stream.Read(buffer, 0, buffer.Length))) > 0
                    sBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteCount))
                End While


                _feedXml = New XmlDocument()
                _feedXml.LoadXml(sBuilder.ToString())

                loadFeedEntries()

            Catch ex As Exception
                'TODO: add error handling
                Throw ex
            End Try
        End Sub


        ''' <summary>
        ''' Loads the <c>FeedEntries</c> collection to the data retreived in the feed.
        ''' </summary>
        Private Sub loadFeedEntries()
            Dim nsm As New XmlNamespaceManager(_feedXml.NameTable)
            nsm.AddNamespace("atom", "http://purl.org/atom/ns#")

            _title = _feedXml.SelectSingleNode("/atom:feed/atom:title", nsm).InnerText
            _message = _feedXml.SelectSingleNode("/atom:feed/atom:tagline", nsm).InnerText
            _modified = DateTime.Parse(_feedXml.SelectSingleNode("/atom:feed/atom:modified", nsm).InnerText.Replace("T24:", "T00:"))



            Dim nodeCount As Integer = _feedXml.SelectNodes("//atom:entry", nsm).Count
            Dim baseXPath As String = String.Empty
            _entryCol.Clear()

            For i As Integer = 1 To nodeCount
                baseXPath = "/atom:feed/atom:entry[position()=" & i.ToString() & "]/atom:"
                Dim subject As String = _feedXml.SelectSingleNode(baseXPath & "title", nsm).InnerText
                Dim summary As String = _feedXml.SelectSingleNode(baseXPath & "summary", nsm).InnerText
                Dim linkEmail As String = _feedXml.SelectSingleNode(baseXPath & "link", nsm).InnerText 'ajout pierre
                Dim fromName As String = _feedXml.SelectSingleNode(baseXPath & "author/atom:name", nsm).InnerText
                Dim fromEmail As String = _feedXml.SelectSingleNode(baseXPath & "author/atom:email", nsm).InnerText
                Dim id As String = _feedXml.SelectSingleNode(baseXPath & "id", nsm).InnerText.Split(":"c)(2)
                Dim received As DateTime = DateTime.Now
                DateTime.TryParse(_feedXml.SelectSingleNode(baseXPath & "issued", nsm).InnerText.Replace("T24:", "T00:"), received)
                Dim atomEntry As New AtomFeedEntry(subject, summary, linkEmail, fromName, fromEmail, id, received)
                _entryCol.Add(atomEntry)
            Next
        End Sub


        ''' <summary>
        ''' Collection containing the feeds entry objects
        ''' </summary>
        Public ReadOnly Property FeedEntries() As AtomFeedEntryCollection
            Get
                Return _entryCol
            End Get
        End Property

        ''' <summary>
        ''' The username of the gmail account that the message will be sent through
        ''' </summary>
        Public Property GmailUserName() As String
            Get
                Return _gmailUserName
            End Get
            Set(value As String)
                _gmailUserName = Value
            End Set
        End Property

        ''' <summary>
        ''' The password of the gmail account that the message will be sent through
        ''' </summary>
        Public Property GmailPassword() As String
            Get
                Return _gmailPassword
            End Get
            Set(value As String)
                _gmailPassword = Value
            End Set
        End Property

        ''' <summary>
        ''' The label to retreive the feeds to. To get the new inbox messages set this to <c>string.Empty</c>.
        ''' </summary>
        Public Property FeedLabel() As String
            Get
                Return _feedLabel
            End Get
            Set(value As String)
                _feedLabel = Value
            End Set
        End Property

        ''' <summary>
        ''' Returns the feed data retreived to gmail
        ''' </summary>
        Public ReadOnly Property FeedXml() As XmlDocument
            Get
                Return _feedXml
            End Get
        End Property

        ''' <summary>
        ''' Returns the feed data retreived to gmail
        ''' </summary>
        Public ReadOnly Property RawFeed() As String
            Get
                Return _feedXml.OuterXml
            End Get
        End Property

        ''' <summary>
        ''' Returns the <c>/feed/tagline</c> property
        ''' </summary>
        Public ReadOnly Property Message() As String
            Get
                Return _message
            End Get
        End Property

        ''' <summary>
        ''' Returns the <c>/feed/title</c> property
        ''' </summary>
        Public ReadOnly Property Title() As String
            Get
                Return _title
            End Get
        End Property

        ''' <summary>
        ''' Returns the <c>/feed/modified</c> property
        ''' </summary>
        Public ReadOnly Property Modified() As DateTime
            Get
                Return _modified
            End Get
        End Property

        ''' <summary>
        ''' Base Url for the gmail atom feed, the default is "https://gmail.google.com/gmail/feed/atom"
        ''' </summary>
        Public Shared Property FeedUrl() As String
            Get
                Return _gmailFeedUrl
            End Get
            Set(value As String)
                _gmailFeedUrl = Value
            End Set
        End Property



        ''' <summary>
        ''' Class for storing the <c>/feed/entry</c> items
        ''' </summary>
        Public Class AtomFeedEntry
            Private _subject As String = String.Empty
            Private _summary As String = String.Empty
            Private _linkEmail As String = String.Empty 'ajout pierre
            Private _fromName As String = String.Empty
            Private _fromEmail As String = String.Empty
            Private _id As String = String.Empty
            Private _received As DateTime = DateTime.MinValue

            ''' <summary>
            ''' Constructor, loads the object
            ''' </summary>
            ''' <param name="subject"><c>/feed/entry/title</c> property</param>
            ''' <param name="summary"><c>/feed/entry/summary</c> property</param>
            ''' <param name="summary"><c>/feed/entry/link</c> property</param> ' jout pierre
            ''' <param name="fromName"><c>/feed/entry/author/name</c> property</param>
            ''' <param name="fromEmail"><c>/feed/entry/author/email</c> property</param>
            ''' <param name="id"><c>/feed/entry/id</c> property</param>
            ''' <param name="received"><c>/feed/entry/issued</c> property</param>
            Public Sub New(ByVal subject As String, ByVal summary As String, ByVal linkEmail As String, ByVal fromName As String, ByVal fromEmail As String, ByVal id As String, ByVal received As DateTime)
                _subject = subject
                _summary = summary
                _linkEmail = linkEmail 'ajout pierre
                _fromName = fromName
                _fromEmail = fromEmail
                _id = id
                _received = received
            End Sub

            ''' <summary>
            ''' Returns the <c>/feed/entry/title</c> property
            ''' </summary>
            Public ReadOnly Property Subject() As String
                Get
                    Return _subject
                End Get
            End Property

            ''' <summary>
            ''' Returns the <c>/feed/entry/summary</c> property
            ''' </summary>
            Public ReadOnly Property Summary() As String 'ajout pierre
                Get
                    Return _summary
                End Get
            End Property

            ''' <link>
            ''' Returns the <c>/feed/entry/link</c> property
            ''' </summary>
            Public ReadOnly Property LinkEmail() As String
                Get
                    Return _linkEmail
                End Get
            End Property

            ''' <summary>
            ''' Returns the <c>/feed/entry/author/name</c> property
            ''' </summary>
            Public ReadOnly Property FromName() As String
                Get
                    Return _fromName
                End Get
            End Property

            ''' <summary>
            ''' Returns the <c>/feed/entry/author/email</c> property
            ''' </summary>
            Public ReadOnly Property FromEmail() As String
                Get
                    Return _fromEmail
                End Get
            End Property

            ''' <summary>
            ''' Returns the <c>/feed/entry/id</c> property
            ''' </summary>
            Public ReadOnly Property Id() As String
                Get
                    Return _id
                End Get
            End Property

            ''' <summary>
            ''' Returns the <c>/feed/entry/issued</c> property
            ''' </summary>
            Public ReadOnly Property Received() As DateTime
                Get
                    Return _received
                End Get
            End Property

        End Class


        'AtomFeedEntry

        ''' <summary>
        ''' Collection of <c>AtomFeedEntry</c> objects
        ''' </summary>
        Public Class AtomFeedEntryCollection
            Inherits System.Collections.CollectionBase

            ''' <summary>
            ''' Indexer for retreiving an <c>AtomFeedEntry</c> object
            ''' </summary>
            Default Public Property Item(index As Integer) As AtomFeedEntry
                Get
                    Return TryCast(Me.List(index), AtomFeedEntry)
                End Get
                Set(value As AtomFeedEntry)
                    Me.List(index) = Value
                End Set
            End Property

            ''' <summary>
            ''' Adds an <c>AtomFeedEntry</c> object to the collection
            ''' </summary>
            ''' <param name="feedEntry"><c>AtomFeedEntry</c> to add</param>
            Public Sub Add(feedEntry As AtomFeedEntry)
                Me.List.Add(feedEntry)
            End Sub

            ''' <summary>
            ''' Clears the collection
            ''' </summary>
            Public Shadows Sub Clear()
                Me.List.Clear()
            End Sub

            ''' <summary>
            ''' Returns true if the collection contains the specified object
            ''' </summary>
            ''' <param name="feedEntry"><c>AtomFeedEntry</c> to find</param>
            ''' <returns></returns>
            Public Function Contains(feedEntry As AtomFeedEntry) As Boolean
                Return Me.List.Contains(feedEntry)
            End Function

            ''' <summary>
            ''' Returns the position of the first of the <c>AtomFeedEntry</c> object. If it is not found then <c>-1</c> is returned.
            ''' </summary>
            ''' <param name="feedEntry"><c>AtomFeedEntry</c> to find</param>
            ''' <returns></returns>
            Public Function IndexOf(feedEntry As AtomFeedEntry) As Integer
                Return Me.List.IndexOf(feedEntry)
            End Function

            ''' <summary>
            ''' Inserts an <c>AtomFeedEntry</c> at the specified position
            ''' </summary>
            ''' <param name="index">Position to insert at</param>
            ''' <param name="feedEntry"><c>AtomFeedEntry</c> to insert</param>
            Public Sub Insert(index As Integer, feedEntry As AtomFeedEntry)
                Me.List.Insert(index, feedEntry)
            End Sub

            ''' <summary>
            ''' Removes an <c>AtomFeedEntry</c> to the collection
            ''' </summary>
            ''' <param name="feedEntry"><c>AtomFeedEntry</c> to be removed</param>
            Public Sub Remove(feedEntry As AtomFeedEntry)
                Me.List.Remove(feedEntry)
            End Sub

            ''' <summary>
            ''' Removes an <c>AtomFeedEntry</c> object to the specified position
            ''' </summary>
            ''' <param name="index">Position of <c>AtomFeedEntry</c> to be removed</param>
            Public Shadows Sub RemoveAt(index As Integer)
                Me.List.RemoveAt(index)
            End Sub

        End Class
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
        'AtomFeedEntryCollection
    End Class
	'GmailAtomFeed
End Namespace
'RC.Gmail
