Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text

Public Class cMySettings

    Public DebugMode As Boolean
    Public DebugRstOnStart As Boolean
    Public Language As String
    Public SmtpServer As String
    Public SmtpPort As Integer
    Public PopServer As String
    Public PopPort As Integer
    Public Ssl As Boolean
    Public Provider As String
    Public MessageOnOff As Boolean
    Public CheckDelay As Integer
    Public GmailPath As String
    Public Username As String
    Public Password As String
    Public SpeechWords As String

    Private Shared XMLFilename As String

    Public Sub New()
        SetToDefault(Me)
    End Sub

    Public Sub New(FileName As String)
        XMLFilename = FileName
        If Path.GetExtension(XMLFilename).ToLower() <> "xml" Then XMLFilename = XMLFilename + ".xml"
        If File.Exists(XMLFilename) = False Then SerializeToXML(New cMySettings())
    End Sub

    Public Sub New(ByRef Settings As cMySettings)
        Me.DebugMode = Settings.DebugMode
        Me.DebugRstOnStart = Settings.DebugRstOnStart
        Me.Language = Settings.Language
        Me.SmtpServer = Settings.SmtpServer
        Me.SmtpPort = Settings.SmtpPort
        Me.PopServer = Settings.PopServer
        Me.PopPort = Settings.PopPort
        Me.Ssl = Settings.Ssl
        Me.Provider = Settings.Provider
        Me.MessageOnOff = Settings.MessageOnOff
        Me.CheckDelay = Settings.CheckDelay
        Me.GmailPath = Settings.GmailPath
        Me.Username = Settings.Username
        Me.Password = Settings.Password
        Me.SpeechWords = Settings.SpeechWords

    End Sub

    Public Shared Sub SerializeToXML(ByRef Settings As cMySettings)

        Dim xmlSerializer As New XmlSerializer(GetType(cMySettings))

        Using xmlTextWriter As New XmlTextWriter(XMLFilename, Encoding.UTF8)
            xmlTextWriter.Formatting = Formatting.Indented
            xmlSerializer.Serialize(xmlTextWriter, Settings)
            xmlTextWriter.Close()
        End Using


    End Sub

    Public Shared Sub DeseralizeFromXML(ByRef Settings As cMySettings)

        Dim fs As FileStream = Nothing

        ' do i have settings?
        If File.Exists(XMLFilename) = True Then
            Try
                fs = New FileStream(XMLFilename, FileMode.Open, FileAccess.Read)
                Dim xmlSerializer As New XmlSerializer(GetType(cMySettings))
                Settings = xmlSerializer.Deserialize(fs)
            Catch
                'load error of some sort, or OBJECT deserialize error
                'do we tell anyone?
                Exit Sub
            Finally
                If Not fs Is Nothing Then fs.Close()
                fs = Nothing
            End Try
        End If

    End Sub

    Public Shared Sub Copy(ByRef SourceSettings As cMySettings, ByRef DestSettings As cMySettings)
        DestSettings.DebugMode = SourceSettings.DebugMode
        DestSettings.DebugRstOnStart = SourceSettings.DebugRstOnStart
        DestSettings.Language = SourceSettings.Language
        DestSettings.SmtpServer = SourceSettings.SmtpServer
        DestSettings.SmtpPort = SourceSettings.SmtpPort
        DestSettings.PopServer = SourceSettings.PopServer
        DestSettings.PopPort = SourceSettings.PopPort
        DestSettings.Ssl = SourceSettings.Ssl
        DestSettings.Provider = SourceSettings.Provider
        DestSettings.MessageOnOff = SourceSettings.MessageOnOff
        DestSettings.CheckDelay = SourceSettings.CheckDelay
        DestSettings.GmailPath = SourceSettings.GmailPath
        DestSettings.Username = SourceSettings.Username
        DestSettings.Password = SourceSettings.Password
        DestSettings.SpeechWords = SourceSettings.SpeechWords

    End Sub

    Public Shared Sub SetToDefault(ByRef Settings)
        Settings.DebugMode = False
        Settings.DebugRstOnStart = False
        Settings.Language = "english"
        Settings.SmtpServer = "smtp.gmail.com"
        Settings.SmtpPort = 587
        Settings.PopServer = "pop.gmail.com"
        Settings.PopPort = 995
        Settings.Ssl = True
        Settings.Provider = "gmail"
        Settings.MessageOnOff = True
        Settings.CheckDelay = 10
        Settings.GmailPath = "C:\Temp\Gmail\"
        Settings.Username = "username"
        Settings.Password = "password"
        Settings.SpeechWords = "nothing,nothing"

    End Sub

    Public Shared Function Compare(ByRef Settings1 As cMySettings, ByRef Setting2 As cMySettings) As Boolean
        If Settings1.DebugMode <> Setting2.DebugMode Then Compare = False : Exit Function
        If Settings1.DebugRstOnStart <> Setting2.DebugRstOnStart Then Compare = False : Exit Function
        If Settings1.Language <> Setting2.Language Then Compare = False : Exit Function
        If Settings1.SmtpServer <> Setting2.SmtpServer Then Compare = False : Exit Function
        If Settings1.SmtpPort <> Setting2.SmtpPort Then Compare = False : Exit Function
        If Settings1.PopServer <> Setting2.PopServer Then Compare = False : Exit Function
        If Settings1.PopPort <> Setting2.PopPort Then Compare = False : Exit Function
        If Settings1.Ssl <> Setting2.Ssl Then Compare = False : Exit Function
        If Settings1.Provider <> Setting2.Provider Then Compare = False : Exit Function
        If Settings1.MessageOnOff <> Setting2.MessageOnOff Then Compare = False : Exit Function
        If Settings1.CheckDelay <> Setting2.CheckDelay Then Compare = False : Exit Function
        If Settings1.GmailPath <> Setting2.GmailPath Then Compare = False : Exit Function
        If Settings1.Username <> Setting2.Username Then Compare = False : Exit Function
        If Settings1.Password <> Setting2.Password Then Compare = False : Exit Function
        If Settings1.SpeechWords <> Setting2.SpeechWords Then Compare = False : Exit Function

        Compare = True

    End Function

End Class
