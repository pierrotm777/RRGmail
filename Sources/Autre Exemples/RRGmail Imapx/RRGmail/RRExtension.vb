Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Reflection

'Imports Google
Imports Google.GData
Imports Google.GData.Client
Imports Google.GData.Extensions
Imports Google.Contacts
Imports Google.GData.Contacts

'Import IMPX
Imports ImapX
Imports ImapX.Enums
Imports ImapX.Collections
Imports System.Security.Authentication

Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Windows.Forms
Imports ImapX.Authentication

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
    'Dim gmailFeed As RC.Gmail.ClassGmailAtomFeed
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

    'IMAPX Setup
    Dim imapxClient As ImapClient
    Dim folderImap As Folder
    Dim _googleOAuth2Key As String
    Private threadAuthenticate As Thread

    'Init ini file
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
        'gmailFeed = New RC.Gmail.ClassGmailAtomFeed(Username, Password)
        'gmailFeed.GetFeed()
        'SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", gmailFeed.FeedEntries.Count)
        'NumberofMail = gmailFeed.FeedEntries.Count

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

    End Sub

    '*****************************************************************
    '* This sub is called on unload of plugin by RR
    '*
    '*****************************************************************
    Public Sub Terminate()
        speechrecognition.unload()
        Timer1.Enabled = False
        Timer1.Dispose()

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
            Case "imaps"
                'IMAP
                imapxClient = New ImapClient("imap.gmail.com", 993, True)
                If imapxClient.Connect = True Then
                    imapxClient.Login("pierrotm777@gmail.com", "*marley#marley*")
                    imapxClient.Behavior.MessageFetchMode = MessageFetchMode.Basic And MessageFetchMode.GMailExtendedData
                    imapxClient.Behavior.ExamineFolders = False

                    Dim myInbox As ImapX.Folder = imapxClient.Folders.Inbox
                    Dim myArchive As ImapX.Folder = imapxClient.Folders.All
                    'Dim messages As ImapX.Message() = myInbox.Search("ALL", ImapX.Enums.MessageFetchMode.Basic Or ImapX.Enums.MessageFetchMode.GMailExtendedData, 1000)
                    'recherche optimisée
                    Dim messages As ImapX.Message() = myInbox.Search("ALL", ImapX.Enums.MessageFetchMode.None, 1000)
                    For Each msg In messages
                        msg.Download(ImapX.Enums.MessageFetchMode.Basic Or ImapX.Enums.MessageFetchMode.GMailExtendedData)
                    Next

                End If
                ProcessCommand = 2

            Case "rr_gmail_check" 'OK
                ProcessCommand = 2

            Case "rr_gmail_getemails" 'OK
                ActualMessage = 0
                Select Case LCase(Profile)
                    Case "gmail"
                        'gmailFeed.GetFeed()
                        SDK.Execute("menu;rrgmail_detail.skin")

                End Select
                GmailEntryUpdate("0")
                ProcessCommand = 2

            Case "rr_gmail_saymessage"
                'CMD = "SAY;" & gmailFeed.FeedEntries(ActualMessage).Summary
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
                'gmail_send(SendToUsername, Subject, BodyTextToSend, AttchedFile, "")
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

                'Case "rr_gmail_pop3"
                '    'OpenPop.PopModule.FetchAllMessages("pop.free.fr", 110, False, "kristie33140@free.fr", "Todpaqjx")
                '    'ReceiveMails(PopServer, PopPort, False, Username, Password)
                '    'Using pop3Client As New Pop3Client()
                '    Try
                '        If pop3Client.Connected Then
                '            pop3Client.Disconnect()
                '        End If
                '        pop3Client.Connect(PopServer, PopPort, False)
                '        pop3Client.Authenticate(FuncCls.DecryptPassword(Username), FuncCls.DecryptPassword(Password))
                '        NumberofMail = pop3Client.GetMessageCount()
                '        SDK.SetUserVar("RR_GMAIL_UNREAD_MAIL", NumberofMail.ToString())
                '        'totalMessagesTextBox.Text = count.ToString()
                '        'messageTextBox.Text = ""
                '        messages.Clear()
                '        'listMessages.Nodes.Clear()
                '        'listAttachments.Nodes.Clear()

                '        Dim success As Integer = 0
                '        Dim fail As Integer = 0
                '        For i As Integer = NumberofMail To 1 Step -1
                '            Try
                '                Dim message As Message = pop3Client.GetMessage(i)
                '                'Dim message As OpenPop.Mime.Message = pop3Client.GetMessage(i)

                '                ' Add the message to the dictionary from the messageNumber to the Message
                '                messages.Add(i, message)

                '                ' Create a TreeNode tree that mimics the Message hierarchy
                '                'Dim node As TreeNode = New TreeNodeBuilder().VisitMessage(message)

                '                ' Set the Tag property to the messageNumber
                '                ' We can use this to find the Message again later
                '                'node.Tag = i

                '                ' Show the built node in our list of messages
                '                'listMessages.Nodes.Add(node)
                '                MsgBox(pop3Client.GetMessage(i), vbOKOnly, "Message")

                '                success += 1
                '            Catch e As Exception
                '                DefaultLogger.Log.LogError("TestForm: Message fetching failed: " & e.Message & vbCr & vbLf & "Stack trace:" & vbCr & vbLf & e.StackTrace)
                '                fail += 1
                '            End Try

                '        Next

                '        'return the number of unread mail
                '        'MsgBox("Mail received!" & vbLf & "Successes: " & success & vbLf & "Failed: " & fail, vbOKOnly, "Message fetching done")

                '        If fail > 0 Then
                '            MsgBox("Since some of the emails were not parsed correctly (exceptions were thrown)" & vbCr & vbLf & "please consider sending your log file to the developer for fixing." & vbCr & vbLf & "If you are able to include any extra information, please do so.", vbOKOnly, "Help improve OpenPop!")
                '            Timer1.Stop()
                '        End If
                '    Catch generatedExceptionName As InvalidLoginException
                '        MsgBox("Login or Password error !!!", vbOKOnly, "POP3 Server Authentication")
                '        Timer1.Stop()
                '    Catch generatedExceptionName As PopServerNotFoundException
                '        MsgBox("The POP server could not be found", "POP3 Retrieval")
                '        Timer1.Stop()
                '    Catch generatedExceptionName As PopServerLockedException
                '        MsgBox("The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", vbOKOnly, "POP3 Account Locked")
                '        Timer1.Stop()
                '    Catch generatedExceptionName As LoginDelayException
                '        MsgBox("Login not allowed. Server enforces delay between logins. Have you connected recently?", vbOKOnly, "POP3 Account Login Delay")
                '        Timer1.Stop()
                '    Catch e As Exception
                '        MsgBox("Error occurred retrieving mail. " & e.Message, vbOKOnly, "POP3 Retrieval")
                '        Timer1.Stop()
                '    End Try
                '    'End Using
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
                    'If gmail_send(sArray(1), sArray(2), sArray(3), "", SDK.GetUserVar("RR_GMAIL_USRLOGO")) = True Then
                    '    RaiseEvent GmailSendEmail()
                    '    If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                    'End If
                Case 5 '<----- new
                    'If gmail_send(sArray(1), sArray(2), sArray(3), sArray(4), SDK.GetUserVar("RR_GMAIL_USRLOGO")) = True Then
                    '    RaiseEvent GmailSendEmail()
                    '    If MessageOnOff = True Then SDK.Execute("SETVAR;RR_GMAIL_IDLE;3||SETVARFROMVAR;RR_GMAIL_INFO;l_set_SendRRGmail2||MENU;RRGMAIL_NEWMAIL.SKIN||WAIT;3||SETVAR;RR_GMAIL_INFO;")
                    'Else
                    '    SDK.ErrScrn("Error found !!!", SDK.GetUserVar("l_set_NoSendRRGmail") & " '" & sArray(4) & "' !!!", "************************************************", 5)
                    'End If
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

                'Case "rr_gmail_myname"
                '    ReturnLabel = GmailUserName
                'Case "rr_gmail_gmailmessage"
                '    ReturnLabel = gmailFeed.Message
                'Case "rr_gmail_gmailmodified"
                '    ReturnLabel = gmailFeed.Modified
                'Case "rr_gmail_gmailtitle"
                '    ReturnLabel = gmailFeed.Title
                'Case "rr_gmail_gmailrawfeed"
                '    ReturnLabel = gmailFeed.RawFeed

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

        'If gmailFeed.FeedEntries.Count = 0 Then
        '    NumberofMail = 0
        '    NewCount = 0
        'End If
        'Select Case LCase(Profile)
        '    Case "gmail"
        '        gmailFeed.GetFeed()
        '        NewCount = gmailFeed.FeedEntries.Count

        'End Select

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
                'Case "pop3"
                '    Username = FuncCls.DecryptPassword(INI.ReadString("POP3", "Username", ""))
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
            RRGmailSettings()
        End If

        Select Case LCase(Profile)
            Case "gmail"
                SDK.SetUserVar("RR_GMAIL_USERNAME", INI.ReadString("Gmail", "Username", ""))
                SDK.SetUserVar("RR_GMAIL_PASSWORD", INI.ReadString("Gmail", "Password", ""))
                SDK.SetUserVar("RR_GMAIL_PROFILE", INI.ReadString("RRGmail", "Profile", ""))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_USERNAME", FuncCls.DecryptPassword(INI.ReadString("Gmail", "Username", "")))
                SDK.SetUserVar("RR_GMAIL_DECRYPTED_PASSWORD", FuncCls.DecryptPassword(INI.ReadString("Gmail", "Password", "")))

        End Select

    End Sub


#End Region

#Region "ImapX"
    '  Private Sub InitClient()
    '      If imapxClient Is Nothing Then
    '          imapxClient = New ImapClient()
    '      End If
    '      Dim crypt As Integer

    '      imapxClient.Host = "imap.gmail.com"
    '      imapxClient.Port = Integer.Parse(993)
    '      If crypt = 0 Then
    '          imapxClient.SslProtocol = SslProtocols.None
    '      ElseIf crypt = 1 Then
    '          imapxClient.SslProtocol = SslProtocols.Default
    '      Else
    '          imapxClient.SslProtocol = SslProtocols.Tls
    '      End If
    '      imapxClient.ValidateServerCertificate = False


    '  End Sub

    '  Private Sub OnConnectSuccessful(isOAuth2 As Boolean)
    '      If Not isOAuth2 Then
    '          imapxClient.Credentials = New PlainCredentials("pierrotm777@gmail.com", "*marley#marley*")
    '      End If

    '      threadAuthenticate = New Thread(AddressOf Authenticate)
    '      threadAuthenticate.IsBackground = True
    '      threadAuthenticate.Start(isOAuth2)
    '  End Sub

    '  Private Sub Authenticate(arg As Object)
    '      Try
    '          If CBool(arg) Then
    '              Dim token As GoogleAccessToken = GoogleOAuth2Provider.GetAccessToken(_googleOAuth2Key)
    '              Dim profile As GoogleProfile = GoogleOAuth2Provider.GetUserProfile(token)

    '              imapxClient.Credentials = New OAuth2Credentials(profile.email, token.access_token)
    '          End If


    '          If imapxClient.Login() Then
    '	Invoke(New SuccessDelegate(OnAuthenticateSuccessful), New () {arg})
    '          Else
    '	Invoke(New FailedDelegate(OnAuthenticateFailed), New () {Nothing, arg})
    '          End If
    '      Catch ex As Exception
    'Invoke(New FailedDelegate(OnAuthenticateFailed), New () {ex, arg})
    '      End Try
    '  End Sub
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
                'If ActualMessage <> gmailFeed.FeedEntries.Count Then
                '    If NextPrev = "+1" Then ActualMessage += 1
                '    If NextPrev = "-1" Then ActualMessage -= 1
                '    If NextPrev = "0" Then ActualMessage = 0
                '    entryAuthorName = gmailFeed.FeedEntries(ActualMessage).FromName
                '    entryAuthorEmail = gmailFeed.FeedEntries(ActualMessage).FromEmail
                '    entryTitle = gmailFeed.FeedEntries(ActualMessage).Subject
                '    entrySummary = gmailFeed.FeedEntries(ActualMessage).Summary
                '    entryIssuedDate = gmailFeed.FeedEntries(ActualMessage).Received
                '    entryId = gmailFeed.FeedEntries(ActualMessage).Id
                '    messagenumber = ActualMessage + 1

                'End If


        End Select
    End Sub
#End Region

#Region "Gmail Send"
    'Public Function gmail_send(toUsername As String, subject As String, body As String, attfile As String, logoFile As String) As Boolean
    '    Try
    '        Dim mail As New MailMessage()
    '        Dim SmtpServer As New SmtpClient()
    '        SmtpServer.Host = "smtp.gmail.com"
    '        SmtpServer.Port = 587
    '        SmtpServer.Credentials = New System.Net.NetworkCredential(Username, Password)
    '        SmtpServer.EnableSsl = True

    '        mail.From = New MailAddress(Username)

    '        If toUsername.Contains("|") Then
    '            Dim addr() As String = toUsername.Split("|")
    '            For i = 0 To addr.Length - 1
    '                mail.[To].Add(addr(i))
    '            Next
    '        Else
    '            mail.[To].Add(toUsername)
    '        End If

    '        mail.Subject = subject
    '        mail.Body = body
    '        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
    '        mail.ReplyTo = New MailAddress(Username, "", System.Text.Encoding.UTF8)

    '        'If attfile <> "" Then
    '        '    Dim attachment As System.Net.Mail.Attachment
    '        '    attachment = New System.Net.Mail.Attachment(attfile)
    '        '    mail.Attachments.Add(attachment)
    '        'End If
    '        If attfile.Contains("|") Then
    '            Dim attfiles() As String = attfile.Split("|")
    '            For i = 0 To attfile.Length - 1
    '                mail.Attachments.Add(New Attachment(attfile(i)))
    '            Next
    '        Else
    '            mail.Attachments.Add(New Attachment(attfile))
    '        End If
    '        logoFile = MainPath & logoFile
    '        If logoFile <> "" AndAlso File.Exists(logoFile) Then
    '            Dim logo As New LinkedResource(logoFile)
    '            logo.ContentId = "Logo"
    '            Dim htmlview As String = "<html><body><table border=2><tr width=100%><td><img src=cid:Logo alt=companyname /></td><td>Send By RRGmail</td></tr></table><hr/></body></html>"
    '            Dim alternateView1 As AlternateView = AlternateView.CreateAlternateViewFromString(htmlview & body, Nothing, MediaTypeNames.Text.Html)
    '            alternateView1.LinkedResources.Add(logo)
    '            mail.AlternateViews.Add(alternateView1)
    '            mail.IsBodyHtml = True
    '        End If

    '        SmtpServer.Send(mail)
    '        Return True
    '    Catch
    '        Return False
    '    End Try

    'End Function
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

End Class