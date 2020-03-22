Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Net.NetworkInformation
Imports System.Net.Mime
Imports System.Text.RegularExpressions

''Imports Google
Imports Google.GData
Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.Contacts
Imports Google.GData.Contacts
'Imports Google.GData.Contacts.ContactsService
'Imports Google.GData.Contacts.ContactEntry
''Imports Google.GData.Contacts.ContactGroupFeed
'Imports Google.GData.Extensions.City
'Imports Google.GData.Extensions.Country
'Imports Google.GData.Extensions.EMail
'Imports Google.GData.Extensions.ExtendedProperty
'Imports Google.GData.Extensions.FormattedAddress
'Imports Google.GData.Extensions.FullName
''Imports Google.GData.Extensions.Im
'Imports Google.GData.Extensions.Name
'Imports Google.GData.Extensions.PhoneNumber
'Imports Google.GData.Extensions.Postcode
'Imports Google.GData.Extensions.Region
'Imports Google.GData.Extensions.Street
'Imports Google.GData.Extensions.StructuredPostalAddress


'Imports POP3
Imports OpenPop.Common.Logging
Imports OpenPop.Mime
Imports OpenPop.Mime.Decode
Imports OpenPop.Mime.Header
Imports OpenPop.Pop3
Imports OpenPop.Pop3.Exceptions
Imports System.Threading
Imports System.Windows.Forms
Imports Message = OpenPop.Mime.Message

'Import IMPX
'Imports ImapX



'*****************************************************************
' Every Plugin MUST have its OWN set of GUIDs. use Tools->Create GUID
'*****************************************************************
<ComClass("6FB47490-9784-4384-B5BB-32184565C798", "2AB7293A-A1D8-46E8-ACB8-6C9179FAF336")> _
Public Class RRExtension

    Dim RunOnce As Boolean ' set to prevent a double execution of code
    Dim SDK As RRSDK ' set type of var to the subclass
    Dim MainPath As String
    Dim SkinPath As String
    Dim GmailPath As String
    Dim EmailProviderName As String

    'Create the object and get the feed
    Dim gmailFeed As RC.Gmail.ClassGmailAtomFeed
    Dim NewCount As Integer

    'Entry Variables
    Dim entryAuthorName As String
    Dim entryAuthorEmail As String
    Dim entryTitle As String
    Dim entrySummary As String
    Dim entryLinkEmail As String
    Dim entryIssuedDate As String
    Dim entryId As String
    Dim messagenumber As String

    'Access the feed through the object
    Dim feedTitle As String
    Dim feedTagline As String
    Dim feedModified As DateTime

    Dim FuncCls As New ClassCommonFunctions()
    Dim Language As String, TextWithoutLF As String, sArray(), dt(), s(), u()
    Dim Username As String
    Dim Password As String
    Dim Profile As String
    Dim MessageOnOff As Boolean = True
    Dim CheckDelay As Integer
    Dim NumberofMail As Integer = 0, RRGMAIL_ALREADY_CHECKED As Integer = 0
    Dim ActualMessage As Integer = 0
    Dim SendToUsername As String, Subject As String, BodyTextToSend As String, AttchedFile As String, Contacts As String
    Dim GmailUserName As String

    'POP3 Setup
    Dim pop3Client As New Pop3Client()
    Dim messages As New Dictionary(Of Integer, OpenPop.Mime.Message)
    'Dim messages As New Dictionary(Of Integer, String)
    Dim PopServer As String, PopPort As Integer
    'Dim message As OpenPop.Mime.Message = pop3Client.GetMessage(ActualMessage)

    'IMAPX Setup
    'Dim imapxClient As ImapClient

    Dim INI As INIReader

    Dim WithEvents Timer1 As System.Timers.Timer

    'Events
    Private Event GmailReceivedEmail()
    Private Event GmailSendEmail()
    Private Event GmailInternetStatusIsOn()
    Private Event GmailInternetStatusIsOff()
    Dim GmailInternetStatus As Boolean = False

    'Contacts Dico
    Public RRContactsList As New ArrayList

    'Speech recognition
    Dim WithEvents speechrecognition As ClassSpeechRecognition

    '*****************************************************************
    '* This is an interface to add commands/labels/indicators/sliders
    '* to RideRunner without needing a whole new application for such.
    '*
    '* You can monitor commands executed in RR by checking the CMD
    '* paramter of ProcessCommand and similarly monitor labels and
    '* indicators of the current screen. The idea is so you can create
    '* new commands, labels, indicators and sliders without having
    '* to re-compile or understand the code in RideRunner.
    '*
    '* Furthermore, it should be possible to intercept commands and
    '* modify them to your interst, say "AUDIO" to "LOAD;MYAUDIO.SKIN"
    '* for this all you need to do is modify CMD and return 3 on the
    '* processcommand call so that RR executes the command you return.
    '*
    '* You're free to use this code in any way you see fit.
    '*
    '*****************************************************************

    '*****************************************************************
    '* This sub is called when pluginmgr;about command is used
    '*
    '*****************************************************************
    Public Sub About(ByRef frm As Object)
        MsgBox("RRGmail Plugin for RideRunner", vbOKOnly, "By pierrotm777")
    End Sub

    '*****************************************************************
    '* This sub is called when pluginmgr;settings command is used
    '*
    '*****************************************************************
    Public Sub Settings(ByRef frm As Object)
        SDK.Execute("RR_Gmail_SETTINGS")
    End Sub

    '*****************************************************************
    '* This function is called immediatly after plugin is loaded and
    '* when ever RR is changing the plugin status (enabled/disabled)
    '* when True its enabled, False its disabled
    '* calls to the SDK methods should not be made when the plugin is
    '* disabled. When plugin is DISABLED no calls into the plugin will
    '* be made. This is all handled by the Sub-Class I have created
    '* (RRSDK.cls)
    '*
    '*****************************************************************
    Public Sub Enabled(ByRef state As Boolean)

        ' set sub class state, which will handle all processing to the
        ' real RR SDK
        SDK.Enabled = state

    End Sub

    '*****************************************************************
    '* This sub is called immediatly after plugin is loaded and
    '* enabled, its only called once.
    '* pluginDataPath = contains where the plugin should store any of
    '* its WRITEABLE\SETTINGS data to.
    '*
    '* NOTE: The plugin is required to create this directory if needed.
    '*
    '*****************************************************************
    Public Sub Initialize(ByRef pluginDataPath As String)
        On Error Resume Next

        ' pluginDataPath will contain a USER Profile (my documents) folder path
        ' suitable for storing WRITEABLE settings to
        ' this would make your plugin OS compliant (VISTA and onward)
        ' not to mention, its proper programming, user data should NOT be stored in "Program Files"
        '
        ' example (typical vista): "C:\Users\Username\Documents\RideRunner\Plugins\MyPlugin\"
        '
        ' App.path will be the path of the ACTUALL LOADED .dll (not recomend for any writes)
        '
        ' uncomment code below if u need the directory
        '
        If Directory.Exists(pluginDataPath) = False Then Directory.CreateDirectory(pluginDataPath)
        MainPath = pluginDataPath
        SkinPath = SDK.GetUserVar("SKINPATH")

        INI = New INIReader(MainPath & "RRGmail.ini")

        'creation de la liste des languages
        If Not File.Exists(MainPath & "Languages.txt") Then ListeDirectoriesIntoDirectory(MainPath & "Languages", True)

        'initialise le langage
        RRGmailSettings()

        'lecture des variables language
        ReadLanguageVars()

        ' saftey check
        If CheckDelay < 5000 Or CheckDelay > 60000 * 30 Then ' si < 5 secondes ou > à 30 minutes alors = 1 minute
            CheckDelay = 60000
        End If

        'NumberofMail = GmailUnreadCount(Username, Password)

        'set update timer for repeating and inital time
        Timer1 = New System.Timers.Timer()
        Timer1.Interval = CheckDelay
        Timer1.Enabled = True
        Timer1.AutoReset = True

        'Lecture du nombre de mails
        gmailFeed = New RC.Gmail.ClassGmailAtomFeed(Username, Password)
        gmailFeed.GetFeed()

        SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", gmailFeed.FeedEntries.Count)
        NumberofMail = gmailFeed.FeedEntries.Count

        'définition du path des fichiers à attacher
        SDK.SetUserVar("RRGMAILPATHFILE", GmailPath)

        'defini l'dle des messages popup
        SDK.SetUserVar("RR_GMAIL_IDLE", "3")

        'Init Speech Recognition
        Select Case GetOSName()
            Case OsNames.Windows8, OsNames.Windows7, OsNames.WindowsVista
                ' j’active ici mes contrôles pour Windows 8 , 8.1 , 7 et Vista
                speechrecognition = New ClassSpeechRecognition()

            Case OsNames.WindowsXP
                ' j’active ici mes contrôles pour Windows XP
                'Try
                '    speechrecognition = New ClassSpeechRecognition()
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try
        End Select

        'IMAP
        'imapxClient = New ImapClient("imap.gmail.com", 993, True)

    End Sub

    '*****************************************************************
    '* This sub is called on unload of plugin by RR
    '*
    '*****************************************************************
    Public Sub Terminate()
        speechrecognition.unload()
        Timer1.Enabled = False
        Timer1.Dispose()
        If pop3Client.Connected Then
            pop3Client.Disconnect()
        End If
    End Sub

    '*****************************************************************
    '* This function provides the metadata
    '*
    '* a string containing a "item" is passed into the function
    '*
    '*
    '*****************************************************************
    Public Function Properties(ByRef item As String) As String
        Properties = ""
        Select Case item
            Case "version"
                Properties = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            Case "author"
                Properties = "pierrotm777"
            Case "category"
                Properties = "TBD"
            Case "description"
                Properties = "Gmail Notifier/Emailer"
            Case "supporturl"
                Properties = "pierrotm777@gmail.com"
            Case "menuitem"
                Properties = Chr(34) + "RR_GMAIL_GETEMAILS" + Chr(34) + ",RRGMAIL,Icons\E-MAIL.png,Gmail,Gmail is selected"

        End Select

    End Function




#Region "ProcessCommand"
    '*****************************************************************
    '* This Function will be called with the current command string
    '* The return parameter of this function determines the handling
    '* To be taken upon returning to RR:
    '*
    '* 0 = Command not processed here
    '* 1 = Command completed + return to previous screen
    '* 2 = Command completed, stay on current screen
    '* 3 = Command has been changed/modified, execute returned one
    '*
    '* frm is the form object which generated the current command. Be
    '* VERY VERY careful when using it.
    '*
    '* frm.tag contains the screen name for the same screen.
    '* you can poll other propperties/methods from the screen but you
    '* will need to look at RR's frmskin to know what you can use/do.
    '*****************************************************************
    Public Function ProcessCommand(ByRef CMD As String, ByRef frm As Object) As Short

        Select Case LCase(CMD)
            '#################" RECEPTION de MAIL #########################################
            Case "rr_gmail_login"
                gmailFeed = New RC.Gmail.ClassGmailAtomFeed(Username, Password)
                ProcessCommand = 2
                'A REGARDER
                'http://mail.google.com/mail/feed/atom/
                'http://mail.google.com/mail/feed/atom/labelname/
                'http://mail.google.com/mail/feed/atom/unread/

            Case "rr_gmail_check" 'OK
                gmailFeed.GetFeed()
                ProcessCommand = 2

            Case "rr_gmail_getemails" 'OK
                ActualMessage = 0
                Select Case LCase(Profile)
                    Case "gmail"
                        gmailFeed.GetFeed()
                        SDK.Execute("menu;rrgmail_detail.skin")
                        'Access the feeds XmlDocument
                        'Dim myXml As XmlDocument = gmailFeed.FeedXml
                        ''test lecteur de tous les noeuds
                        'Dim child As XmlNode = myXml.SelectSingleNode("/root/child")
                        'If Not (child Is Nothing) Then
                        '    Dim nr As New XmlNodeReader(child)
                        '    While nr.Read()
                        '        Console.WriteLine(nr.Value)
                        '    End While
                        'End If

                        'Access the raw feed as a string
                        'Dim feedstrinf As String = gmailFeed.RawFeed
                        'SDK.SetUserVar("feedstrinf", gmailFeed.RawFeed)

                        'Access the feed through the object
                        'Dim feedTitle As String = gmailFeed.Title
                        'SDK.SetUserVar("feedTitle", gmailFeed.Title)
                        'Dim feedTagline As String = gmailFeed.Modified
                        'SDK.SetUserVar("feedTagline", gmailFeed.Modified)
                        'Dim feedModified As DateTime


                    Case "pop3"
                        SDK.Execute("menu;rrgmail_detail.skin")
                        ActualMessage = pop3Client.GetMessageCount()

                End Select
                GmailEntryUpdate("0")
                ProcessCommand = 2

            Case "rr_gmail_saymessage"
                CMD = "SAY;" & gmailFeed.FeedEntries(ActualMessage).Summary
                ProcessCommand = 3
            Case "rr_gmail_saytranslated"
                CMD = "SAY;" & SDK.GetUserVar("RR_GMAIL_TRANSLATED")
                ProcessCommand = 3

            Case "rr_gmail_next"
                GmailEntryUpdate("+1")
                ProcessCommand = 2

            Case "rr_gmail_prev"
                GmailEntryUpdate("-1")
                ProcessCommand = 2

            Case "rr_gmail_settings"
                Profile = INI.ReadString("RRGmail", "Profile", "")
                Select Case LCase(Profile)
                    Case "gmail"
                        Username = INI.ReadString("Gmail", "Username", "")
                        Password = INI.ReadString("Gmail", "Password", "")
                    Case "pop3"
                        Username = INI.ReadString("POP3", "Username", "")
                        Password = INI.ReadString("POP3", "Password", "")
                End Select

                SDK.SetUserVar("RR_GmailInfo", SDK.GetUserVar("l_set_ActualRRGmailLanguage") & " '" & Language & "'")
                SDK.Execute("LOAD;RRGmail_Settings.skin||CLCLEAR;ALL")

                If File.Exists(MainPath & "Languages.txt") Then
                    SDK.Execute("CLCLEAR;ALL||CLLOAD;" & MainPath & "Languages.txt" & "||CLFIND;" & Language) 'selectionne la ligne du language actuel
                Else
                    SDK.ErrScrn("!! Info !!", MainPath & "'Languages.txt' file is not found !!!", "")
                End If

                If INI.ReadString("Gmail", "Username", "") = "****@gmail.com" Or INI.ReadString("Gmail", "Password", "") = "password" Then
                    Timer1.Stop()
                    SDK.ErrScrn("Settings Error found !!!", "Your 'GMAIL email' and your 'GMAIL password' are not defined!!!", "Please, edit your RRGmail.ini file ...", 5)
                End If
                ProcessCommand = 2

            Case "rr_gmail_language_select"
                TextWithoutLF = Replace(frm.CL.Text, vbLf, "", 1) 'efface le linefeed retourné par le frm.CL.Text
                SDK.Execute("SETVAR;RR_GMailInfo;" & SDK.GetUserVar("l_set_NewLanguage") & " '" & TextWithoutLF & "'")
                INI.Write("RRGmail", "Language", TextWithoutLF)
                RRGmailSettings()
                ProcessCommand = 2

            Case "rr_gmail_language_updatelist"
                ListeDirectoriesIntoDirectory(MainPath & "Languages", True)
                ProcessCommand = 2

            Case "rr_gmail_editusr"
                CMD = "OSKTOCMD;RR_GMAIL_USERNAME;RR_GMAIL_SETUSR||OSKTEXT;" & INI.ReadString("Gmail", "Username", "")
                ProcessCommand = 3
            Case "rr_gmail_setusr"
                Profile = INI.ReadString("RRGmail", "Profile", "")
                Select Case LCase(Profile)
                    Case "gmail"
                        INI.Write("Gmail", "Username", SDK.GetUserVar("RR_GMAIL_USERNAME"))
                    Case "pop3"
                        INI.Write("POP3", "Username", SDK.GetUserVar("RR_GMAIL_USERNAME"))
                End Select
                Username = SDK.GetUserVar("RR_GMAIL_USERNAME")
                ProcessCommand = 2

            Case "rr_gmail_editpwd"
                CMD = "OSKTOCMD;RR_GMAIL_PASSWORD;RR_GMAIL_SETPWD||OSKTEXT;" & INI.ReadString("Gmail", "Password", "")
                ProcessCommand = 3
            Case "rr_gmail_setpwd"
                Select Case LCase(Profile)
                    Case "gmail"
                        INI.Write("Gmail", "Password", SDK.GetUserVar("RR_GMAIL_PASSWORD"))
                    Case "pop3"
                        INI.Write("POP3", "Password", SDK.GetUserVar("RR_GMAIL_PASSWORD"))
                End Select
                Password = SDK.GetUserVar("RR_GMAIL_PASSWORD")
                Profile = INI.ReadString("RRGmail", "Profile", "")
                SDK.Execute("RR_GMAIL_CRYPT||WAIT;2||RR_GMAIL_SETTINGS")
                Timer1.Start()
                ProcessCommand = 2

                'Case "rr_gmail_profiles"
                '    SDK.Execute("menu;RRGmail_Profiles.skin")
                '    If File.Exists(MainPath & "Profiles.txt") Then
                '        sArray = File.ReadAllLines(MainPath & "Profiles.txt")
                '        For n = 0 To UBound(sArray)
                '            s = Split(sArray(n), "|")
                '            u = Split(Replace(s(0), "@", " ").Replace(".", " "), " ")
                '            SDK.Execute("CLADD;" & s(0))
                '            If File.Exists(MainPath & "Profiles\" & u(1) & ".gif") Then
                '                SDK.Execute("CLSETIMG;" & n + 1 & ";" & MainPath & "Profiles\" & u(1) & ".gif")
                '            Else
                '                SDK.Execute("CLSETIMG;" & n + 1 & ";" & MainPath & "Profiles\Error.gif")
                '            End If
                '        Next
                '        SDK.Execute("CLFIND;" & FuncCls.DecryptPassword(Username)) 'selectionne la ligne du profile actuel
                '        'SDK.Execute("CLLOAD;" & MainPath & "Profiles.txt||CLFIND;" & FuncCls.DecryptPassword(Username)) 'selectionne la ligne du profile actuel
                '    Else
                '        SDK.ErrScrn("!! Info !!", MainPath & "Profiles.txt file is not found !!!", "")
                '    End If
                '    ProcessCommand = 2
            Case "rr_gmail_profile_select"
                Profile = INI.ReadString("RRGmail", "Profile", "")
                Select Case LCase(Profile)
                    Case "gmail"
                        INI.Write("RRGmail", "Profile", "pop3")
                    Case "pop3"
                        INI.Write("RRGmail", "Profile", "gmail")
                End Select
                'sArray = File.ReadAllLines(MainPath & "Profiles.txt")
                'TextWithoutLF = Replace(frm.CL.Text, vbLf, "", 1) 'efface le linefeed retourné par le frm.CL.Text
                Profile = INI.ReadString("RRGmail", "Profile", "")
                ProcessCommand = 2
            Case "rr_gmail_profiles_updatelist"
                ListeDirectoriesIntoDirectory(MainPath & "Languages", True)
                ProcessCommand = 2

            Case "rr_gmail_crypt"
                Profile = INI.ReadString("RRGmail", "Profile", "")
                Select Case LCase(Profile)
                    Case "gmail"
                        INI.Write("Gmail", "Username", FuncCls.EncryptPassword(Username.Trim))
                        INI.Write("Gmail", "Password", FuncCls.EncryptPassword(Password.Trim))
                    Case "pop3"
                        INI.Write("POP3", "Username", FuncCls.EncryptPassword(Username.Trim))
                        INI.Write("POP3", "Password", FuncCls.EncryptPassword(Password.Trim))
                End Select
                ProcessCommand = 2

            Case "rr_gmail_reset_usrpwd"
                Select Case INI.ReadString("RRGmail", "Profile", "")
                    Case "gmail"
                        INI.Write("Gmail", "Username", "****@gmail.com")
                        INI.Write("Gmail", "Password", "password")
                        Username = INI.ReadString("Gmail", "Username", "")
                        Password = INI.ReadString("Gmail", "Password", "")
                    Case "pop3"
                        INI.Write("POP3", "Username", "****@****.***")
                        INI.Write("POP3", "Password", "password")
                        Username = INI.ReadString("POP3", "Username", "")
                        Password = INI.ReadString("POP3", "Password", "")
                End Select
                SDK.SetUserVar("RR_GMAIL_USERNAME", Username)
                SDK.SetUserVar("RR_GMAIL_PASSWORD", Password)
                ProcessCommand = 2

            Case "rr_gmail_settings_unhide"
                Username = FuncCls.DecryptPassword(Username)
                Password = FuncCls.DecryptPassword(Password)
                ProcessCommand = 2
            Case "rr_gmail_settings_hide"
                Select Case INI.ReadString("RRGmail", "Profile", "")
                    Case "gmail"
                        Username = INI.ReadString("Gmail", "Username", "")
                        Password = INI.ReadString("Gmail", "Password", "")
                    Case "pop3"
                        Username = INI.ReadString("POP3", "Username", "")
                        Password = INI.ReadString("POP3", "Password", "")
                End Select
                ProcessCommand = 2
            Case "rr_gmail_view_settings"
                SDK.Execute("rr_gmail_settings_unhide||wait;2||rr_gmail_settings_hide")
                ProcessCommand = 2

            Case "rr_gmail_decrypt"
                MsgBox(FuncCls.DecryptPassword(Username) & vbCrLf & _
                        FuncCls.DecryptPassword(Password), vbOKOnly, "Gmail settings")
                ProcessCommand = 2

            Case "rr_gmail_translate"
                If SDK.GetInd("pluginmgr;status;rrtranslator") = "True" Then
                    SDK.Execute("SETVAR;RR_TRANSLATOR_FROMTEXT;" & entrySummary & "||RR_TRANSLATOR_TRANSLATE")
                    SDK.Execute("SETVARFROMVAR;RR_GMAIL_TRANSLATED;RR_TRANSLATOR_TOTEXT||MENU;RRGMAIL_TRANSLATED.SKIN")
                Else
                    SDK.ErrScrn("Translator Error !!!", "If you want to use this function,", " you need to install the plugin RRTranslator ...", 5)
                End If
                ProcessCommand = 2

            Case "rr_gmail_popup_onoff"
                Select Case INI.ReadString("RRGmail", "MessageOnOff", "")
                    Case "True"
                        INI.Write("RRGmail", "MessageOnOff", "False")
                    Case "False"
                        INI.Write("RRGmail", "MessageOnOff", "True")
                End Select
                MessageOnOff = CBool(INI.ReadString("RRGmail", "MessageOnOff", ""))
                ProcessCommand = 2
                '##############################################################################

                '#################" ENVOIE de MAIL ############################################
            Case "rr_gmail_emailer"
                SDK.Execute("load;rrgmail_emailer.skin")
                ProcessCommand = 2

            Case "rr_gmail_sendmail" 'OK
                Username = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", ""))
                Password = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", ""))
                SendToUsername = SDK.GetUserVar("RR_GMAIL_TOUSERNAME")
                Subject = SDK.GetUserVar("RR_GMAIL_SUBJECT")
                BodyTextToSend = SDK.GetUserVar("RR_GMAIL_EMAILBODY")
                AttchedFile = SDK.GetUserVar("RR_GMAIL_ATTACHFILE")
                'Send a message with one line of code 
                gmail_send(SendToUsername, Subject, BodyTextToSend, AttchedFile, "")
                RaiseEvent GmailSendEmail()
                If AttchedFile = "" Then
                    If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                Else
                    If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail2||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                End If
                ProcessCommand = 2

            Case "rr_gmail_reset_tousername"
                SDK.SetUserVar("RR_GMAIL_TOUSERNAME", "")
                ProcessCommand = 2

            Case "rr_gmail_unattach" 'OK
                SDK.SetUserVar("RR_GMAIL_ATTACHFILE", "")
                ProcessCommand = 2

            Case "rr_gmail_contacts"
                GetGmailContacts(Username, Password)
                ProcessCommand = 2

            Case "oncldblclick"
                Select Case LCase(frm.tag)
                    Case "rrgmail_contacts.skin"
                        SDK.SetUserVar("RR_GMAIL_TOUSERNAME", SDK.GetUserVar("LISTTEXT"))
                        SDK.Execute("ESC")
                        'Case "rrgmail_profiles.skin"
                        '    SDK.Execute("RR_GMAIL_PROFILE_SELECT")
                        '    Profile = INI.ReadString("RRGmail", "Profile", "")
                End Select
                ProcessCommand = 2

            Case "pop3test"
                FetchAllMessages("pop.gmail.com", 995, True, "pierrotm777@gmail.com", "*marley#marley*")
                ProcessCommand = 2

            Case "rr_gmail_pop3"
                'OpenPop.PopModule.FetchAllMessages("pop.free.fr", 110, False, "kristie33140@free.fr", "Todpaqjx")
                'ReceiveMails(PopServer, PopPort, False, Username, Password)
                'Using pop3Client As New Pop3Client()
                Try
                    If pop3Client.Connected Then
                        pop3Client.Disconnect()
                    End If
                    pop3Client.Connect(PopServer, PopPort, False)
                    pop3Client.Authenticate(FuncCls.DecryptPassword(Username), FuncCls.DecryptPassword(Password))
                    NumberofMail = pop3Client.GetMessageCount()
                    SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", NumberofMail.ToString())
                    'totalMessagesTextBox.Text = count.ToString()
                    'messageTextBox.Text = ""
                    messages.Clear()
                    'listMessages.Nodes.Clear()
                    'listAttachments.Nodes.Clear()

                    Dim success As Integer = 0
                    Dim fail As Integer = 0
                    For i As Integer = NumberofMail To 1 Step -1
                        Try
                            Dim message As Message = pop3Client.GetMessage(i)
                            'Dim message As OpenPop.Mime.Message = pop3Client.GetMessage(i)

                            ' Add the message to the dictionary from the messageNumber to the Message
                            messages.Add(i, message)

                            ' Create a TreeNode tree that mimics the Message hierarchy
                            'Dim node As TreeNode = New TreeNodeBuilder().VisitMessage(message)

                            ' Set the Tag property to the messageNumber
                            ' We can use this to find the Message again later
                            'node.Tag = i

                            ' Show the built node in our list of messages
                            'listMessages.Nodes.Add(node)
                            MsgBox(pop3Client.GetMessage(i), vbOKOnly, "Message")

                            success += 1
                        Catch e As Exception
                            DefaultLogger.Log.LogError("TestForm: Message fetching failed: " & e.Message & vbCr & vbLf & "Stack trace:" & vbCr & vbLf & e.StackTrace)
                            fail += 1
                        End Try

                    Next

                    'return the number of unread mail
                    'MsgBox("Mail received!" & vbLf & "Successes: " & success & vbLf & "Failed: " & fail, vbOKOnly, "Message fetching done")

                    If fail > 0 Then
                        MsgBox("Since some of the emails were not parsed correctly (exceptions were thrown)" & vbCr & vbLf & "please consider sending your log file to the developer for fixing." & vbCr & vbLf & "If you are able to include any extra information, please do so.", vbOKOnly, "Help improve OpenPop!")
                        Timer1.Stop()
                    End If
                Catch generatedExceptionName As InvalidLoginException
                    MsgBox("Login or Password error !!!", vbOKOnly, "POP3 Server Authentication")
                    Timer1.Stop()
                Catch generatedExceptionName As PopServerNotFoundException
                    MsgBox("The POP server could not be found", "POP3 Retrieval")
                    Timer1.Stop()
                Catch generatedExceptionName As PopServerLockedException
                    MsgBox("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", vbOKOnly, "POP3 Account Locked")
                    Timer1.Stop()
                Catch generatedExceptionName As LoginDelayException
                    MsgBox("Login not allowed. Server enforces delay between logins. Have you connected recently?", vbOKOnly, "POP3 Account Login Delay")
                    Timer1.Stop()
                Catch e As Exception
                    MsgBox("Error occurred retrieving mail. " & e.Message, vbOKOnly, "POP3 Retrieval")
                    Timer1.Stop()
                End Try
                'End Using
                ProcessCommand = 2

                'Case "test"
                '    ' This is how you would override the default logger type
                '    ' Here we want to log to a file
                '    DefaultLogger.SetLog(New FileLogger())

                '    ' Enable file logging and include verbose information
                '    FileLogger.Enabled = True
                '    FileLogger.Verbose = True

                '    pop3Client = New Pop3Client()

                '    ' This is only for faster debugging purposes
                '    ' We will try to load in default values for the hostname, port, ssl, username and password from a file
                '    'Dim myDocs As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                '    'Dim file__1 As String = Path.Combine(myDocs, "OpenPopLogin.txt")
                '    'If File.Exists(file__1) Then
                '    '    Using reader As New StreamReader(File.OpenRead(file__1))
                '    '        ' This describes how the OpenPOPLogin.txt file should look like
                '    '        popServerTextBox.Text = reader.ReadLine()
                '    '        ' Hostname
                '    '        portTextBox.Text = reader.ReadLine()
                '    '        ' Port
                '    '        useSslCheckBox.Checked = Boolean.Parse(If(reader.ReadLine(), "true"))
                '    '        ' Whether to use SSL or not
                '    '        loginTextBox.Text = reader.ReadLine()
                '    '        ' Username
                '    '        ' Password
                '    '        passwordTextBox.Text = reader.ReadLine()
                '    '    End Using
                '    'End If
                '    ProcessCommand = 2

                'Case "test2"
                '    ' Connect to the server
                '    'pop3Client.Connect("pop.free.fr", 110, False)
                '    pop3Client.Connect("pop.gmail.com", 995, True)

                '    ' Authenticate ourselves towards the server
                '    'pop3Client.Authenticate("kristie33140@free.fr", "Todpaqjx")
                '    pop3Client.Authenticate("pierrotm777@gmail.com", "*marley#marley*")

                '    ' Get the number of messages in the inbox
                '    Dim NumberofMail As Integer = pop3Client.GetMessageCount()
                '    SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", NumberofMail.ToString())

                '    'MsgBox(pop3Client.GetMessage(1).FindFirstPlainTextVersion.GetBodyAsText, vbOKOnly, "") 'GetBodyAsText
                '    ' We want to download all messages
                '    'Dim allMessages As New List(Of Message)(messageCount)

                '    '' Messages are numbered in the interval: [1, messageCount]
                '    '' Ergo: message numbers are 1-based.
                '    'For i As Integer = 1 To messageCount
                '    '    'allMessages.Add(client.GetMessage(i))
                '    '    MsgBox(pop3Client.GetMessage(i).MessagePart.BodyEncoding, vbOKOnly, "") 'GetBodyAsText
                '    'Next

                '    ' Now return the fetched messages
                '    'Return allMessages
                '    'End Using
                '    'End Function
                '    ProcessCommand = 2

            Case "popplus"
                ' Messages are numbered in the interval: [1, messageCount]
                ' Ergo: message numbers are 1-based.
                For i As Integer = NumberofMail To 1 Step -1
                    MsgBox(pop3Client.GetMessage(i).FindFirstPlainTextVersion.GetBodyAsText, vbOKOnly, "") 'GetBodyAsText
                Next
                ProcessCommand = 2
            Case "popmoins"
                ' Messages are numbered in the interval: [1, messageCount]
                ' Ergo: message numbers are 1-based.
                For i As Integer = 1 To NumberofMail
                    MsgBox(pop3Client.GetMessage(i).FindFirstPlainTextVersion.GetBodyAsText, vbOKOnly, "") 'GetBodyAsText
                Next
                ProcessCommand = 2

                'Case "traffic"
                '    ShowNetworkTraffic()
                '    ProcessCommand = 2
                '##############################################################################
        End Select

        'rr_gmail_sendemail;toaddress;subject;body;file
        If Left(LCase(CMD), 19) = "rr_gmail_sendemail;" Then  '<----- new
            AttchedFile = ""
            Username = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", ""))
            Password = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", ""))
            sArray = LCase(CMD).Split(";")
            Select Case sArray.Length '<----- new
                Case 4 '<----- new
                    If gmail_send(sArray(1), sArray(2), sArray(3), "", SDK.GetUserVar("RR_GMAIL_USRLOGO")) = True Then
                        RaiseEvent GmailSendEmail()
                        If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                    End If
                Case 5 '<----- new
                    If gmail_send(sArray(1), sArray(2), sArray(3), sArray(4), SDK.GetUserVar("RR_GMAIL_USRLOGO")) = True Then
                        RaiseEvent GmailSendEmail()
                        If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail2||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                    Else
                        SDK.ErrScrn("Error found !!!", SDK.GetUserVar("l_set_NoSendRRGmail") & " '" & sArray(4) & "' !!!", "************************************************", 5)
                    End If
            End Select '<----- new
            ProcessCommand = 2
        End If

    End Function
#End Region

#Region "Labels"
    '*****************************************************************
    '* This Function will be called with a requested label code and
    '* format specified at the skin file. Simply return any text to
    '* be displayed for the specified format.
    '*****************************************************************
    Public Function ReturnLabel(ByRef LBL As String, ByRef FMT As String) As String

        ReturnLabel = ""
        Select Case LCase(LBL)
            Case "rr_gmail_plugindesc"
                ReturnLabel = "RRGmail.NET"
            Case "rr_gmail_pluginver"
                ReturnLabel = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            Case "rr_gmail_mylabel"
                ReturnLabel = "Gmail Notifier/Emailer"

            Case "rr_gmail_myname"
                ReturnLabel = GmailUserName
            Case "rr_gmail_gmailmessage"
                ReturnLabel = gmailFeed.Message
            Case "rr_gmail_gmailmodified"
                ReturnLabel = gmailFeed.Modified
            Case "rr_gmail_gmailtitle"
                ReturnLabel = gmailFeed.Title
            Case "rr_gmail_gmailrawfeed"
                ReturnLabel = gmailFeed.RawFeed

            Case "rr_gmail_entryauthorname"
                ReturnLabel = entryAuthorName
            Case "rr_gmail_entryauthoremail"
                ReturnLabel = entryAuthorEmail
            Case "rr_gmail_entrytitle"
                ReturnLabel = entryTitle
            Case "rr_gmail_entrysummary"
                ReturnLabel = entrySummary
            Case "rr_gmail_entrylinkemail"
                ReturnLabel = entryLinkEmail
            Case "rr_gmail_entryissueddate"
                ReturnLabel = entryIssuedDate
            Case "rr_gmail_entryid"
                ReturnLabel = entryId
            Case "rr_gmail_messagenumber"
                ReturnLabel = messagenumber

            Case "rr_gmail_count"
                ReturnLabel = SDK.GetUserVar("RR_GMAIL_UNREAD_MAIL")


            Case "rr_gmail_username"
                ReturnLabel = Username 'INI.ReadString("Gmail", "Username", "")
            Case "rr_gmail_password"
                ReturnLabel = Password 'INI.ReadString("Gmail", "Password", "")
            Case "rr_gmail_decrypted_username"
                ReturnLabel = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", ""))
            Case "rr_gmail_decrypted_password"
                ReturnLabel = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", ""))

            Case "rr_gmail_profile"
                ReturnLabel = Profile 'INI.ReadString("RRGmail", "Profile", "")

            Case "rr_gmail_popup_onoff"
                ReturnLabel = MessageOnOff.ToString




                'Case "rr_gmail_dfxvoice"
                '    If SDK.GetInd("pluginmgr;status;dfxvoice") = "True" Then
                '        If SDK.GetUserVar("DFXVOICE_HYPOTHESIS") <> "" Or SDK.GetUserVar("DFXVOICE_RECOGNIZED") <> "" Then
                '            ReturnLabel = "=You said:>" & SDK.GetUserVar("DFXVOICE_HYPOTHESIS") & "= *** " & "=Recognized Command:> " & SDK.GetUserVar("DFXVOICE_RECOGNIZED")
                '        Else
                '            ReturnLabel = "***"
                '        End If
                '    Else
                '        ReturnLabel = "*** DFXVoice not found ***"
                '    End If

            Case "rr_gmail_provider"
                ReturnLabel = EmailProviderName

        End Select

    End Function
#End Region

#Region "Indicators"
    '*****************************************************************
    '* This Function will be called with requested indicator code
    '* specified at the skin file. Simply return "True" or "False" to
    '* displayed the respective ON or OFF layer of the skin images.
    '* alternatively you can specify a path to a file to be displayed
    '* as the indicator specified. Return "False" to erase the image.
    '* ONLY return something else IF AND ONLY IF you process that code
    '*****************************************************************
    Public Function ReturnIndicatorEx(ByRef IND As String) As String
        'Default (No Action)
        'ONLY return something else IF AND ONLY IF you process that code
        ReturnIndicatorEx = ""

        Select Case LCase(IND)
            Case "rr_gmail_logo"
                ReturnIndicatorEx = IIf(CInt(SDK.GetUserVar("RR_GMAIL_UNREAD_MAIL")) > 0, SkinPath & "Indicators\" & ServerName() & "_01.png", SkinPath & "Indicators\" & ServerName() & "_00.png")

            Case "rr_gmail_language_actual"
                ReturnIndicatorEx = MainPath & "Languages\" & Language & "\" & Language & ".gif"

            Case "rr_gmail_attachfile"
                ReturnIndicatorEx = IIf(SDK.GetUserVar("RR_GMAIL_ATTACHFILE") <> "", "True", "False")

            Case "rr_gmail_networkready"
                'ReturnIndicatorEx = IIf(CheckForInternetConnection() = True, "True", "False")
                ReturnIndicatorEx = IIf(GmailInternetStatus = True, "True", "False")

            Case "rr_gmail_speechrecognition"
                ReturnIndicatorEx = IIf(SpeechRecognitionIsActive = True, "True", "False")
        End Select

    End Function

    '*****************************************************************
    '* This Sub will be called with an indicator code "CLICKED"
    '* specified at the skin file. This "event" so to speak can be used
    '* to toggle indicators or execute any code you desire when clicking
    '* on a specifig indicator in the skin. You can also modify IND and
    '* monitor the IND parameter as to detect/alter the behaviour of
    '* how RR will process the indicator code being clicked.
    '*****************************************************************
    Public Sub IndicatorClick(ByRef IND As String)

        Select Case LCase(IND)
            Case "rr_gmail_speechrecognition"
                If SpeechRecognitionIsActive = False Then
                    speechrecognition.SpeechProcessing_Load()
                    SDK.SetUserVar("", SpeechRecognitionSentenceIs)
                ElseIf SpeechRecognitionIsActive = True Then
                    speechrecognition.SpeechProcessing_Stop()
                End If


        End Select

    End Sub
#End Region

#Region "Sliders"
    '*****************************************************************
    '* This Function will be called with requested slider code
    '* specified at the skin file. Simply return the value of the
    '* slider to be displayed. Values should range from 0 to 65536.
    '* It is also possible to intercept/change the slider code before
    '* it is processed in RideRunner (to overwrite existing codes).
    '*****************************************************************
    Public Function ReturnSlider(ByRef SLD As String) As Integer

        'This tells RR that the Slider was not processed in this plugin
        ReturnSlider = -1

        Select Case LCase(SLD)
            'Case "myslider"
            'ReturnSlider = 1000.0! * Val(VB6.Format(TimeOfDay, "SS"))

            'case "myslider2"
            'Insert code here to return your slider value

        End Select

    End Function


    '*****************************************************************
    '* This Function will be called with requested slider code
    '* specified at the skin file. Simply return the value of the
    '* slider to be displayed. Values should range from 0 to 65536.
    '* It is also possible to intercept/change the slider code before
    '* it is processed in RideRunner (to overwrite existing codes).
    '*****************************************************************
    Public Sub SetSlider(ByRef SLD As String, ByRef Value As Integer, ByRef Direction As Boolean)

        Select Case LCase(SLD)
            'Case "myslider"
            'MsgBox("Myslider Clicked to set value to:" & CStr(Value) & " Direction: " + IIf(Direction, "UP", "DOWN"))

            'Case "myslider2"
            'Insert code to process/set slider value here

        End Select

    End Sub
#End Region

    Public Sub New()
        MyBase.New()

        If RunOnce = False Then ' only want to do once
            RunOnce = True
            'Code here is executed when loading the Extension plugin
            ' set RRSDK (this is the sub class)
            SDK = New RRSDK

            ' run any one time code here

        End If

    End Sub

#Region "Timers"
    Private Sub Timer1_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = True Then
            If GmailInternetStatus = False Then RaiseEvent GmailInternetStatusIsOn()
            GmailInternetStatus = True
        ElseIf System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = False Then
            If GmailInternetStatus = True Then RaiseEvent GmailInternetStatusIsOff()
            GmailInternetStatus = False
        End If

        If INI.ReadString("Gmail", "Username", "") = "****@gmail.com" Or INI.ReadString("Gmail", "Password", "") = "password" Then
            Timer1.Stop()
            SDK.ErrScrn("Settings Error found !!!", "Your 'GMAIL email' and your 'GMAIL password' are not defined!!!", "Please, edit your account ...", 5)
            Exit Sub
        End If

        If gmailFeed.FeedEntries.Count = 0 Then
            NumberofMail = 0
            NewCount = 0
        End If
        Select Case LCase(Profile)
            Case "gmail"
                gmailFeed.GetFeed()
                NewCount = gmailFeed.FeedEntries.Count
            Case "pop3"
                'SDK.Execute("rr_gmail_pop3")
                'SDK.Execute("test2")
                ReceiveMails(PopServer, PopPort, False, Username, Password)
                NewCount = CInt(SDK.GetUserVar("RR_GMAIL_UNREAD_MAIL"))
        End Select

        If NewCount <> -1 Then
            If NumberofMail < NewCount Then
                If MessageOnOff = True Then SDK.Execute("SETVARFROMVAR;RR_GMAIL_INFO;l_set_NewRRGmail||MENU;RRGMAIL_NEWMAIL.SKIN")
                RaiseEvent GmailReceivedEmail()
                NumberofMail = NewCount
            End If
            RRGMAIL_ALREADY_CHECKED = RRGMAIL_ALREADY_CHECKED + 1
            SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", NewCount)
            SDK.SetUserVar("RR_GMAIL_ALREADY_CHECKED", RRGMAIL_ALREADY_CHECKED)
        Else
            SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", "Err")
            System.Threading.Thread.Sleep(60000)
            'SDK.ErrScrn("Error found !!!", "Your Gmail settings are bad !!!", "Please, check your Username and Password for the Gmail into the RRGmail.ini file !!!", 5)
        End If

    End Sub
#End Region

#Region "Read ServerName"
    Private Function ServerName() As String
        'lecture du nom du provider
        Select Case LCase(Profile)
            Case "gmail"
                Username = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", ""))
            Case "pop3"
                Username = FuncCls.DecryptPassword(INI.ReadString("POP3", "Username", ""))
        End Select
        s = Split(Replace(Username, "@", " ").Replace(".", " "), " ")
        If File.Exists(SkinPath & "Indicators\" & s(1) & "_01.png") And File.Exists(SkinPath & "Indicators\" & s(1) & "_00.png") Then
            EmailProviderName = s(1)
        Else
            EmailProviderName = SkinPath & "Icons\E-MAIL.png"
        End If
        Return EmailProviderName
    End Function
#End Region

#Region "Read All Gmail Contacts"
    Public Sub GetGmailContacts(ByVal usr As String, ByVal pwd As String)
        Dim rs As New RequestSettings("Gmail Contacts", usr, pwd)
        ' AutoPaging results in automatic paging in order to retrieve all contacts
        rs.AutoPaging = True
        Dim cr As New ContactsRequest(rs)
        Dim line As String = ""
        Dim p As Integer = 1

        'The example assumes the ContactRequest object (cr) is already set up.
        'Dim photoStream As Stream = cr.GetPhoto("pierre@gmail.com")

        SDK.Execute("menu;rrgmail_contacts.skin||CLCLEAR;ALL")

        Dim f As Feed(Of Contact) = cr.GetContacts()
        For Each e As Contact In f.Entries
            'Console.WriteLine(vbTab + e.Title)
            'line = ""
            line = e.Title & "***"
            For Each email As EMail In e.Emails
                'Console.WriteLine(vbTab + email.Address)
                'MsgBox(email.Address, vbOKOnly, "")
                line &= email.Address & "***"
            Next
            'For Each g As GroupMembership In e.GroupMembership
            '    'Console.WriteLine(vbTab + g.HRef)
            '    line &= g.HRef & "***"
            'Next
            'For Each im As IMAddress In e.IMs
            '    'Console.WriteLine(vbTab + im.Address)
            '    line &= im.Address & "***"
            'Next
            'Foe Each ph as 
            s = Split(line, "***")

            RRContactsList.Add(s(1)) 's(0) & " --> " & s(1))
            'RRContactsList.Add(line)
            'SDK.Execute("CLADD;" & s(1) & "||CLSETIMG;" & p & ";" & SkinPath & "Icons\E-MAIL.png")
            'DownloadPhoto(cr, e.PhotoUri)

            'p += 1
            If s(1) = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", "")) Then GmailUserName = s(0)
        Next
        RRContactsList.Sort()
        For Each c In RRContactsList
            SDK.Execute("CLADD;" & c & "||CLSETIMG;" & p & ";" & SkinPath & "Icons\E-MAIL.png")
            p += 1
        Next
        RRContactsList.Clear()
        Contacts = SDK.GetUserVar("RR_GMAIL_TOUSERNAME")
        'SDK.Execute("CLFIND;" & Contacts) 'selectionne la ligne du language actuel

    End Sub

    Public Sub DownloadPhoto(cr As ContactsRequest, contactURL As Uri)
        Dim contact As Contact = cr.Retrieve(Of Contact)(contactURL)

        Dim photoStream As Stream = cr.GetPhoto(contact)
        Dim outStream As FileStream = File.OpenWrite(MainPath & "test.jpg")
        Dim buffer As Byte() = New Byte(photoStream.Length - 1) {}

        photoStream.Read(buffer, 0, photoStream.Length)
        outStream.Write(buffer, 0, photoStream.Length)
        photoStream.Close()
        outStream.Close()
    End Sub


    'Public Function CreateContact2(cr As ContactsRequest) As Contact
    '    'Dim contact As ContactEntry = New ContactEntry
    '    'Dim newEntry As Name = New Name()
    '    Dim newContact As New Contact()
    '    newContact.Title = "Liz Doe"

    '    Dim primaryEmail As New EMail("liz@gmail.com")
    '    primaryEmail.Primary = True
    '    primaryEmail.Rel = ContactsRelationships.IsWork
    '    newContact.Emails.Add(primaryEmail)

    '    Dim secondaryEmail As New EMail("liz@a.com")
    '    secondaryEmail.Rel = ContactsRelationships.IsHome
    '    newContact.Emails.Add(secondaryEmail)

    '    Dim phoneNumber As New PhoneNumber("555-555-5555")
    '    phoneNumber.Primary = True
    '    phoneNumber.Rel = ContactsRelationships.IsMobile
    '    newContact.Phonenumbers.Add(phoneNumber)

    '    Dim postalAddress As New PostalAddress("")
    '    postalAddress.Value = "123 somewhere lane"
    '    postalAddress.Primary = True
    '    postalAddress.Rel = ContactsRelationships.IsHome
    '    newContact.PostalAddresses.Add(postalAddress)

    '    newContact.Content = "Contact information for Liz"

    '    Dim feedUri As New Uri(ContactsQuery.CreateContactsUri("default"))

    '    'The example assumes the ContactRequest object (cr) is already set up.
    '    Dim createdContact As Contact = cr.Insert(feedUri, newContact)
    'End Function


#End Region

#Region "Settings/Languages"
    'lister les dossiers d'un dossier (sous dossiers compris)
    Public Sub ListeDirectoriesIntoDirectory(ByVal MyDirectory As String, ByVal Icons As Boolean)
        Try
            Dim monStreamWriter As New StreamWriter(MyDirectory & ".txt", True, Encoding.Unicode)
            monStreamWriter.WriteLine(" 0")
            For Each ligneF In Directory.GetDirectories(MyDirectory, "*.*", SearchOption.AllDirectories)
                monStreamWriter.WriteLine("LST" & Path.GetFileName(ligneF) & "||" & Path.GetFileName(ligneF))
                If Icons = True Then monStreamWriter.WriteLine("ICO$PLUGINSPATH$RRGmail\Languages\" & Path.GetFileName(ligneF) & "\" & Path.GetFileName(ligneF) & ".gif")
            Next
            monStreamWriter.Close()
        Catch ex As Exception
            'TextBox1.Text = ex.Message
        End Try
    End Sub

    Private Sub ReadLanguageVars()
        If File.Exists(MainPath & "Languages\" & Language & "\RRGmail.txt") Then 'ajout test présence du fichier fichier langue défini dans le fichier .ini
            sArray = File.ReadAllLines(MainPath & "Languages\" & Language & "\RRGmail.txt")
            For Each line In sArray
                If Left(line, 1) <> "[" And Trim(line) <> "" Then
                    dt = Split(line, "=")
                    SDK.SetUserVar(dt(0), dt(1)) 'lecture des variables de langue
                End If
            Next
        Else
            'SDK.Execute("SETVAR;RRGmailInfo;" & MainPath & "Languages\" & Language & "\" & Language & ".txt " & SDK.GetUserVar("l_set_CheckRRGmailtxt") & "||menu;RRGmail_info.skin")
        End If
    End Sub



    '*************************************************************
    'read the language selected
    '*************************************************************
    Private Sub RRGmailSettings()
        If File.Exists(MainPath & "RRGmail.ini") Then
            Profile = INI.ReadString("RRGmail", "Profile", "")
            Select Case LCase(Profile)
                Case "gmail"
                    If INI.ReadString("Gmail", "Username", "") = "****@gmail.com" And INI.ReadString("Gmail", "Password", "") = "password" Then
                        Username = INI.ReadString("Gmail", "Username", "")
                        Password = INI.ReadString("Gmail", "Password", "")
                    Else
                        Username = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", ""))
                        Password = FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", ""))
                    End If

                Case "pop3"
                    If INI.ReadString("POP3", "Username", "") = "username" And INI.ReadString("POP3", "Password", "") = "password" Then
                        Username = INI.ReadString("POP3", "Username", "")
                        Password = INI.ReadString("POP3", "Password", "")
                    Else
                        Username = FuncCls.DecryptPassword(INI.ReadString("POP3", "Username", ""))
                        Password = FuncCls.DecryptPassword(INI.ReadString("POP3", "Password", ""))
                    End If
                    PopServer = INI.ReadString("POP3", "PopServer", "")
                    PopPort = INI.ReadString("POP3", "PopPort", "")
            End Select
            MessageOnOff = CBool(INI.ReadString("RRGmail", "MessageOnOff", ""))
            Language = INI.ReadString("RRGmail", "Language", "")
            CheckDelay = Val(INI.ReadString("RRGmail", "CheckDelay", "")) * 1000 '1 ==> 1 seconde
            GmailPath = INI.ReadString("RRGmail", "GmailPath", "")
        Else
            INI.Write("RRGmail", "MessageOnOff", "true")
            INI.Write("RRGmail", "Profile", "gmail")
            INI.Write("RRGmail", "Language", "english")
            INI.Write("RRGmail", "CheckDelay", "10")
            INI.Write("RRGmail", "GmailPath", "C:\Temp\Gmail\")
            INI.Write("Gmail", "Username", "****@gmail.com")
            INI.Write("Gmail", "Password", "password")
            INI.Write("POP3", "PopServer", "pop.free.fr")
            INI.Write("POP3", "Port", "110")
            INI.Write("POP3", "Username", "****@free.fr")
            INI.Write("POP3", "Password", "password")
            RRGmailSettings()
        End If

        Select Case LCase(Profile)
            Case "gmail"
                SDK.SetUserVar("RR_GMAIL_USERNAME", INI.ReadString("Gmail", "Username", ""))
                SDK.SetUserVar("RR_GMAIL_PASSWORD", INI.ReadString("Gmail", "Password", ""))
                SDK.SetUserVar("RR_GMAIL_PROFILE", INI.ReadString("RRGmail", "Profile", ""))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_USERNAME", FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", "")))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_PASSWORD", FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", "")))
            Case "pop3"
                SDK.SetUserVar("RR_GMAIL_USERNAME", INI.ReadString("POP3", "Username", ""))
                SDK.SetUserVar("RR_GMAIL_PASSWORD", INI.ReadString("POP3", "Password", ""))
                SDK.SetUserVar("RR_GMAIL_PROFILE", INI.ReadString("RRGmail", "Profile", ""))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_USERNAME", FuncCls.DecryptPassword(INI.ReadString("POP3", "Username", "")))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_PASSWORD", FuncCls.DecryptPassword(INI.ReadString("POP3", "Password", "")))
        End Select

    End Sub


#End Region

#Region "XmlFeedParser"
    Public Structure GmailInfo
        Public Failed As Boolean
        Public errormessage As Exception
        Public AcceptNewStep As Integer
        Public ActualStep As Integer
        Public stepbystep_title() As String
        Public stepbystep_summary() As String
        Public stepbystep_link() As String
        Public stepbystep_modified() As String
        Public stepbystep_issued() As String
        Public stepbystep_id() As String
        Public stepbystep_author() As String
        Public stepbystep_name() As String
        Public stepbystep_email() As String

        Public xml As String
    End Structure
    Public NewGmailInfo As New GmailInfo()

    'to obtain itinery info by google
    Public Function CheckGmailFeed()
        CheckGmailFeed = ""
        Dim googleto As String
        Dim webclient As New Net.WebClient

        With NewGmailInfo
            .Failed = True
            Try

                'https://mail.google.com/mail/feed/atom

                SDK.SetUserVar("XMLFILE", "Non utilisé")
                googleto = "https://mail.google.com/mail/feed/atom"

                .xml = webclient.DownloadString(googleto)
                'If .xml.Contains("<status>OVER_QUERY_LIMIT</status>") Then '
                '    .Failed = True
                '    MsgBox("OVER_QUERY_LIMIT", vbOKOnly, "Error")
                'ElseIf .xml.Contains("<status>ZERO_RESULTS</status>") Then
                '    .Failed = True
                '    MsgBox("ZERO_RESULTS", vbOKOnly, "Error")
                '    'Exit Function
                'End If
                SDK.SetUserVar("URL", googleto)
                SDK.SetUserVar("ACTUALSTEP", 1)

                Dim stepbystep() As String
                stepbystep = Split(.xml, "<entry>")
                Dim onestep() As String
                ReDim .stepbystep_title(UBound(stepbystep) - 1)
                ReDim .stepbystep_summary(UBound(stepbystep) - 1)
                ReDim .stepbystep_link(UBound(stepbystep) - 1)
                ReDim .stepbystep_issued(UBound(stepbystep) - 1)
                ReDim .stepbystep_modified(UBound(stepbystep) - 1)
                ReDim .stepbystep_id(UBound(stepbystep) - 1)
                ReDim .stepbystep_author(UBound(stepbystep) - 1)
                ReDim .stepbystep_name(UBound(stepbystep) - 1)
                ReDim .stepbystep_email(UBound(stepbystep) - 1)

                Dim x As Integer
                For x = 1 To stepbystep.Length - 1
                    onestep = Split(stepbystep(x), vbLf)
                    .stepbystep_title(x) = GetStringBetween(onestep(1), "<title>", "</title>")
                    .stepbystep_summary(x) = GetStringBetween(onestep(2), "<summary>", "</summary>")
                    .stepbystep_link(x) = GetStringBetween(onestep(3), "<link rel=""alternate"" href=>", "</>")
                    .stepbystep_modified(x) = GetStringBetween(onestep(4), "<modified>", "</modified>")
                    .stepbystep_issued(x) = GetStringBetween(onestep(5), "<issued>", "</issued>")
                    .stepbystep_id(x) = GetStringBetween(onestep(6), "<id>", "</id>")
                    .stepbystep_author(x) = GetStringBetween(onestep(7), "<author>", "</author>")

                    MsgBox("Title       > " + .stepbystep_title(x) + vbCrLf & _
                        "Summary   > " + .stepbystep_summary(x) + vbCrLf & _
                        "Link      > " + .stepbystep_link(x) + vbCrLf & _
                        "Modified   > " + .stepbystep_modified(x) & vbCrLf & _
                        "Issued   > " + .stepbystep_issued(x) & vbCrLf & _
                        "Id   > " + .stepbystep_id(x) & vbCrLf & _
                        "Author      > " + .stepbystep_author(x), vbOKOnly, "Gmail Info")


                    'SDK.SetUserVar("Step_Origine", .stepbystep_title(x))
                    'SDK.SetUserVar("Step_Destination", .stepbystep_summary(x))
                    'SDK.SetUserVar("Step_Duration", .stepbystep_link(x))
                    'SDK.SetUserVar("Step_Instruction", .stepbystep_issued(x))
                    'SDK.SetUserVar("Step_Distance", .stepbystep_modified(x))
                    'SDK.SetUserVar("Step_Number", stepbystep.Length - 1)
                    'SDK.Execute("menu;RRGmail_Steps.skin")

                    Exit For
                Next

            Catch ex As Exception
                .Failed = True
                .errormessage = ex
                Exit Function
            End Try
            .Failed = False
        End With
    End Function

    '*****************************************************************
    '           Extract a string between two specific strings
    '*****************************************************************
    Public Function GetStringBetween(ByVal Haystack As String, ByVal StartSearch As String, ByVal EndSearch As String) As String
        GetStringBetween = ""
        If InStr(Haystack, StartSearch) < 1 Then Return False
        Dim rx As New Regex(StartSearch & "(.+?)" & EndSearch)
        Dim m As Match = rx.Match(Haystack)
        If m.Success Then
            Return m.Groups(1).ToString()
        End If
    End Function
#End Region

#Region "POP3 Connection" 'ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String
    Public Sub ReceiveMails(ByVal hostname As String, ByVal port As Integer, ByVal useSsl As Boolean, ByVal username As String, ByVal password As String)
        ' The client disconnects from the server when being disposed
        'Using pop3Client As New Pop3Client()
        Try
            If pop3Client.Connected Then
                pop3Client.Disconnect()
            End If
            pop3Client.Connect(hostname, port, useSsl)
            pop3Client.Authenticate(username, password)
            Dim count As Integer = pop3Client.GetMessageCount()
            SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", count.ToString())

            'totalMessagesTextBox.Text = count.ToString()
            'messageTextBox.Text = ""
            'messages.Clear()
            'listMessages.Nodes.Clear()
            'listAttachments.Nodes.Clear()

            Dim success As Integer = 0
            Dim fail As Integer = 0
            'For i As Integer = count To 1 Step -1
            '    ' Check if the form is closed while we are working. If so, abort
            '    'If IsDisposed Then
            '    '    Return
            '    'End If

            '    Try
            '        'Dim message As OpenPop.Mime.Message = pop3Client.GetMessage(i)
            '        ' Add the message to the dictionary from the messageNumber to the Message
            '        'messages.Add(i, message)

            '        ' Create a TreeNode tree that mimics the Message hierarchy
            '        'Dim node As TreeNode = New TreeNodeBuilder().VisitMessage(message)

            '        ' Set the Tag property to the messageNumber
            '        ' We can use this to find the Message again later
            '        'node.Tag = i

            '        ' Show the built node in our list of messages
            '        'listMessages.Nodes.Add(node)

            '        success += 1
            '    Catch e As Exception
            '        DefaultLogger.Log.LogError("TestForm: Message fetching failed: " & e.Message & vbCr & vbLf & "Stack trace:" & vbCr & vbLf & e.StackTrace)
            '        fail += 1
            '    End Try

            '    'progressBar.Value = CInt(Math.Truncate((CDbl(count - i) / count) * 100))
            'Next

            'MsgBox("Mail received!" & vbLf & "Successes: " & success & vbLf & "Failed: " & fail, vbOKOnly, "Message fetching done")

            If fail > 0 Then
                'MessageBox.Show(Me, "Since some of the emails were not parsed correctly (exceptions were thrown)" & vbCr & vbLf & "please consider sending your log file to the developer for fixing." & vbCr & vbLf & "If you are able to include any extra information, please do so.", "Help improve OpenPop!")
                MsgBox("Since some of the emails were not parsed correctly (exceptions were thrown)" & vbCr & vbLf & "please consider sending your log file to the developer for fixing." & vbCr & vbLf & "If you are able to include any extra information, please do so.", vbOKOnly, "Help improve OpenPop!")
            End If
        Catch generatedExceptionName As InvalidLoginException
            MsgBox("Login or Password error !!!", vbOKOnly, "POP3 Server Authentication")
            Timer1.Stop()
        Catch generatedExceptionName As PopServerNotFoundException
            MsgBox("The POP server could not be found", "POP3 Retrieval")
            Timer1.Stop()
        Catch generatedExceptionName As PopServerLockedException
            MsgBox("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", vbOKOnly, "POP3 Account Locked")
            Timer1.Stop()
        Catch generatedExceptionName As LoginDelayException
            MsgBox("Login not allowed. Server enforces delay between logins. Have you connected recently?", vbOKOnly, "POP3 Account Login Delay")
            Timer1.Stop()
        Catch e As Exception
            MsgBox("Error occurred retrieving mail. " & e.Message, vbOKOnly, "POP3 Retrieval")
            Timer1.Stop()
        Finally
            ' Enable the buttons again
            'connectAndRetrieveButton.Enabled = True
            'uidlButton.Enabled = True
            'progressBar.Value = 100
        End Try
        'End Using
    End Sub

    'Private Sub ConnectAndRetrieveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
    '    ReceiveMails()
    'End Sub

    'Private Sub ListMessagesMessageSelected(ByVal sender As Object, ByVal e As TreeViewEventArgs)
    '    ' Fetch out the selected message
    '    Dim message As OpenPop.Mime.Message = messages(GetMessageNumberFromSelectedNode(listMessages.SelectedNode))

    '    ' If the selected node contains a MessagePart and we can display the contents - display them
    '    If TypeOf listMessages.SelectedNode.Tag Is MessagePart Then
    '        Dim selectedMessagePart As MessagePart = DirectCast(listMessages.SelectedNode.Tag, MessagePart)
    '        If selectedMessagePart.IsText Then
    '            ' We can show text MessageParts
    '            'messageTextBox.Text = selectedMessagePart.GetBodyAsText()
    '            SDK.SetUserVar("RR_GMAIL_ERROR", selectedMessagePart.GetBodyAsText())
    '        Else
    '            ' We are not able to show non-text MessageParts (MultiPart messages, images, pdf's ...)
    '            'messageTextBox.Text = "<<OpenPop>> Cannot show this part of the email. It is not text <<OpenPop>>"
    '            SDK.SetUserVar("RR_GMAIL_ERROR", "<<OpenPop>> Cannot show this part of the email. It is not text <<OpenPop>>")
    '        End If
    '    Else
    '        ' If the selected node is not a subnode and therefore does not
    '        ' have a MessagePart in it's Tag property, we genericly find some content to show

    '        ' Find the first text/plain version
    '        Dim plainTextPart As MessagePart = OpenPop.Mime.message.FindFirstPlainTextVersion()
    '        If plainTextPart IsNot Nothing Then
    '            ' The message had a text/plain version - show that one
    '            'messageTextBox.Text = plainTextPart.GetBodyAsText()
    '            SDK.SetUserVar("RR_GMAIL_ERROR", plainTextPart.GetBodyAsText())
    '        Else
    '            ' Try to find a body to show in some of the other text versions
    '            Dim textVersions As List(Of MessagePart) = OpenPop.Mime.message.FindAllTextVersions()
    '            If textVersions.Count >= 1 Then
    '                'messageTextBox.Text = textVersions(0).GetBodyAsText()
    '                SDK.SetUserVar("RR_GMAIL_ERROR", textVersions(0).GetBodyAsText())
    '            Else
    '                'messageTextBox.Text = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>"
    '                SDK.SetUserVar("RR_GMAIL_ERROR", "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>")
    '            End If
    '        End If
    '    End If

    '    ' Clear the attachment list from any previus shown attachments
    '    listAttachments.Nodes.Clear()

    '    ' Build up the attachment list
    '    Dim attachments As List(Of MessagePart) = OpenPop.Mime.message.FindAllAttachments()
    '    For Each attachment As MessagePart In attachments
    '        ' Add the attachment to the list of attachments
    '        Dim addedNode As TreeNode = listAttachments.Nodes.Add((attachment.FileName))

    '        ' Keep a reference to the attachment in the Tag property
    '        addedNode.Tag = attachment
    '    Next

    '    ' Only show that attachmentPanel if there is attachments in the message
    '    Dim hadAttachments As Boolean = attachments.Count > 0
    '    attachmentPanel.Visible = hadAttachments

    '    ' Generate header table
    '    Dim dataSet As New DataSet()
    '    Dim table As DataTable = dataSet.Tables.Add("Headers")
    '    table.Columns.Add("Header")
    '    table.Columns.Add("Value")

    '    Dim rows As DataRowCollection = table.Rows

    '    ' Add all known headers
    '    rows.Add(New Object() {"Content-Description", OpenPop.Mime.Message.Headers.ContentDescription})
    '    rows.Add(New Object() {"Content-Id", OpenPop.Mime.message.Headers.ContentId})
    '    For Each keyword As String In OpenPop.Mime.message.Headers.Keywords
    '        rows.Add(New Object() {"Keyword", keyword})
    '    Next
    '    For Each dispositionNotificationTo As RfcMailAddress In OpenPop.Mime.message.Headers.DispositionNotificationTo
    '        rows.Add(New Object() {"Disposition-Notification-To", dispositionNotificationTo})
    '    Next
    '    For Each received As Received In OpenPop.Mime.message.Headers.Received
    '        rows.Add(New Object() {"Received", received.Raw})
    '    Next
    '    rows.Add(New Object() {"Importance", OpenPop.Mime.message.Headers.Importance})
    '    rows.Add(New Object() {"Content-Transfer-Encoding", OpenPop.Mime.message.Headers.ContentTransferEncoding})
    '    For Each cc As RfcMailAddress In OpenPop.Mime.message.Headers.Cc
    '        rows.Add(New Object() {"Cc", cc})
    '    Next
    '    For Each bcc As RfcMailAddress In OpenPop.Mime.message.Headers.Bcc
    '        rows.Add(New Object() {"Bcc", bcc})
    '    Next
    '    For Each [to] As RfcMailAddress In OpenPop.Mime.message.Headers.[To]
    '        rows.Add(New Object() {"To", [to]})
    '    Next
    '    rows.Add(New Object() {"From", OpenPop.Mime.message.Headers.From})
    '    rows.Add(New Object() {"Reply-To", OpenPop.Mime.message.Headers.ReplyTo})
    '    For Each inReplyTo As String In OpenPop.Mime.message.Headers.InReplyTo
    '        rows.Add(New Object() {"In-Reply-To", inReplyTo})
    '    Next
    '    For Each reference As String In OpenPop.Mime.message.Headers.References
    '        rows.Add(New Object() {"References", reference})
    '    Next
    '    rows.Add(New Object() {"Sender", OpenPop.Mime.message.Headers.Sender})
    '    rows.Add(New Object() {"Content-Type", OpenPop.Mime.message.Headers.ContentType})
    '    rows.Add(New Object() {"Content-Disposition", OpenPop.Mime.message.Headers.ContentDisposition})
    '    rows.Add(New Object() {"Date", OpenPop.Mime.message.Headers.[Date]})
    '    rows.Add(New Object() {"Date", OpenPop.Mime.message.Headers.DateSent})
    '    rows.Add(New Object() {"Message-Id", OpenPop.Mime.message.Headers.MessageId})
    '    rows.Add(New Object() {"Mime-Version", OpenPop.Mime.message.Headers.MimeVersion})
    '    rows.Add(New Object() {"Return-Path", OpenPop.Mime.message.Headers.ReturnPath})
    '    rows.Add(New Object() {"Subject", OpenPop.Mime.message.Headers.Subject})

    '    ' Add all unknown headers
    '    For Each key As String In OpenPop.Mime.message.Headers.UnknownHeaders
    '        Dim values As String() = OpenPop.Mime.message.Headers.UnknownHeaders.GetValues(key)
    '        If values IsNot Nothing Then
    '            For Each value As String In values
    '                rows.Add(New Object() {key, value})
    '            Next
    '        End If
    '    Next

    '    ' Now set the headers displayed on the GUI to the header table we just generated
    '    gridHeaders.DataMember = table.TableName
    '    gridHeaders.DataSource = dataSet
    'End Sub

    ''' <summary>
    ''' Finds the MessageNumber of a Message given a <see cref="TreeNode"/> to search in.
    ''' The root of this <see cref="TreeNode"/> should have the Tag property set to a int, which
    ''' points into the <see cref="messages"/> dictionary.
    ''' </summary>
    ''' <param name="node">The <see cref="TreeNode"/> to look in. Cannot be <see langword="null"/>.</param>
    ''' <returns>The found int</returns>
    'Private Shared Function GetMessageNumberFromSelectedNode(ByVal node As TreeNode) As Integer
    '    If node Is Nothing Then
    '        Throw New ArgumentNullException("node")
    '    End If

    '    ' Check if we are at the root, by seeing if it has the Tag property set to an int
    '    If TypeOf node.Tag Is Integer Then
    '        Return CInt(node.Tag)
    '    End If

    '    ' Otherwise we are not at the root, move up the tree
    '    Return GetMessageNumberFromSelectedNode(node.Parent)
    'End Function

    'Private Sub ListAttachmentsAttachmentSelected(ByVal sender As Object, ByVal args As TreeViewEventArgs)
    '    ' Fetch the attachment part which is currently selected
    '    Dim attachment As MessagePart = DirectCast(listAttachments.SelectedNode.Tag, MessagePart)

    '    If attachment IsNot Nothing Then
    '        saveFile.FileName = attachment.FileName
    '        Dim result As DialogResult = saveFile.ShowDialog()
    '        If result <> DialogResult.OK Then
    '            Return
    '        End If

    '        ' Now we want to save the attachment
    '        Dim file As New FileInfo(saveFile.FileName)

    '        ' Check if the file already exists
    '        If file.Exists Then
    '            ' User was asked when he chose the file, if he wanted to overwrite it
    '            ' Therefore, when we get to here, it is okay to delete the file
    '            file.Delete()
    '        End If

    '        ' Lets try to save to the file
    '        Try
    '            attachment.Save(file)

    '            MessageBox.Show(Me, "Attachment saved successfully")
    '        Catch e As Exception
    '            MessageBox.Show(Me, "Attachment saving failed. Exception message: " + e.Message)
    '        End Try
    '    Else
    '        MessageBox.Show(Me, "Attachment object was null!")
    '    End If
    'End Sub


#End Region

#Region "Internet check"
    'Public Function CheckForInternetConnection() As Boolean
    '    Try
    '        Using client As New WebClient()
    '            Using stream = client.OpenRead("http://www.google.com")
    '                Return True
    '                If GmailInternetStatus = False And CheckForInternetConnection = True Then RaiseEvent GmailInternetStatusIsOn()
    '                GmailInternetStatus = True
    '            End Using
    '        End Using

    '    Catch
    '        Return False
    '        If GmailInternetStatus = True And CheckForInternetConnection = False Then RaiseEvent GmailInternetStatusIsOff()
    '        GmailInternetStatus = False
    '    End Try
    'End Function

#End Region

#Region "Gmail Entry Update"
    Private Sub GmailEntryUpdate(ByVal NextPrev As String)
        Select Case LCase(Profile)
            Case "gmail"
                If ActualMessage <> gmailFeed.FeedEntries.Count Then
                    If NextPrev = "+1" Then ActualMessage += 1
                    If NextPrev = "-1" Then ActualMessage -= 1
                    If NextPrev = "0" Then ActualMessage = 0
                    entryAuthorName = gmailFeed.FeedEntries(ActualMessage).FromName
                    entryAuthorEmail = gmailFeed.FeedEntries(ActualMessage).FromEmail
                    entryTitle = gmailFeed.FeedEntries(ActualMessage).Subject
                    entrySummary = gmailFeed.FeedEntries(ActualMessage).Summary
                    entryIssuedDate = gmailFeed.FeedEntries(ActualMessage).Received
                    entryId = gmailFeed.FeedEntries(ActualMessage).Id
                    messagenumber = ActualMessage + 1

                End If

            Case "pop3"
                If ActualMessage <> pop3Client.GetMessageCount() Then
                    If NextPrev = "+1" Then ActualMessage += 1
                    If NextPrev = "-1" Then ActualMessage -= 1
                    If NextPrev = "0" Then ActualMessage = 0
                    entryAuthorName = ""
                    entryAuthorEmail = ""
                    entryTitle = ""
                    entrySummary = pop3Client.GetMessage(ActualMessage).FindFirstPlainTextVersion.GetBodyAsText
                    entryIssuedDate = ""
                    entryId = ""
                    messagenumber = ActualMessage + 1
                End If
                'For i As Integer = NumberofMail To 1 Step -1
                '    MsgBox(pop3Client.GetMessage(i).FindFirstPlainTextVersion.GetBodyAsText, vbOKOnly, "") 'GetBodyAsText
                'Next
        End Select
    End Sub
#End Region

#Region "Gmail Send"
    Public Function gmail_send(toUsername As String, subject As String, body As String, attfile As String, logoFile As String) As Boolean
        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient()
            SmtpServer.Host = "smtp.gmail.com"
            SmtpServer.Port = 587
            SmtpServer.Credentials = New System.Net.NetworkCredential(Username, Password)
            SmtpServer.EnableSsl = True

            mail.From = New MailAddress(Username)

            If toUsername.Contains("|") Then
                Dim addr() As String = toUsername.Split("|")
                For i = 0 To addr.Length - 1
                    mail.[To].Add(addr(i))
                Next
            Else
                mail.[To].Add(toUsername)
            End If

            mail.Subject = subject
            mail.Body = body
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            mail.ReplyTo = New MailAddress(Username, "", System.Text.Encoding.UTF8)

            'If attfile <> "" Then
            '    Dim attachment As System.Net.Mail.Attachment
            '    attachment = New System.Net.Mail.Attachment(attfile)
            '    mail.Attachments.Add(attachment)
            'End If
            If attfile.Contains("|") Then
                Dim attfiles() As String = attfile.Split("|")
                For i = 0 To attfile.Length - 1
                    mail.Attachments.Add(New Attachment(attfile(i)))
                Next
            Else
                mail.Attachments.Add(New Attachment(attfile))
            End If
            logoFile = MainPath & logoFile
            If logoFile <> "" AndAlso File.Exists(logoFile) Then
                Dim logo As New LinkedResource(logoFile)
                logo.ContentId = "Logo"
                Dim htmlview As String = "<html><body><table border=2><tr width=100%><td><img src=cid:Logo alt=companyname /></td><td>Send By RRGmail</td></tr></table><hr/></body></html>"
                Dim alternateView1 As AlternateView = AlternateView.CreateAlternateViewFromString(htmlview & body, Nothing, MediaTypeNames.Text.Html)
                alternateView1.LinkedResources.Add(logo)
                mail.AlternateViews.Add(alternateView1)
                mail.IsBodyHtml = True
            End If

            SmtpServer.Send(mail)
            Return True
        Catch
            Return False
        End Try

    End Function
#End Region

#Region "RR Events"
    Public Sub GmailNewRecievedEmail() Handles Me.GmailReceivedEmail
        SDK.Execute("*ONRRGMAILRECEIVEDMAIL", True)
    End Sub
    Public Sub GmailNewSendEmail() Handles Me.GmailSendEmail
        SDK.Execute("*ONRRGMAILSENDMAIL", True)
    End Sub
    Public Sub GmailInternetStatusOn() Handles Me.GmailInternetStatusIsOn
        SDK.Execute("*ONRRGMAILINTERNETISON", True)
    End Sub
    Public Sub GmailInternetStatusOff() Handles Me.GmailInternetStatusIsOff
        SDK.Execute("*ONRRGMAILINTERNETISOFF", True)
    End Sub

#End Region


#Region "pop3 test"
    'Here is an example of how you can download all messages from one POP3 server. It takes the //various connection settings as arguments.
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
    Public Function FetchAllMessages(hostname As String, port As Integer, useSsl As Boolean, username As String, password As String) As List(Of Message)
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
            ' Most servers give the latest message the highest number
            For i As Integer = messageCount To 1 Step -1
                'allMessages.Add(client.GetMessage(i))
                MsgBox(client.GetMessage(i))
            Next

            ' Now return the fetched messages
            Return allMessages
        End Using
    End Function
#End Region

End Class