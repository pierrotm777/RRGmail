Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports OpenPop.Mime
Imports OpenPop.Mime.Header
Imports OpenPop.Pop3
Imports OpenPop.Pop3.Exceptions
Imports OpenPop.Common.Logging
Imports Message = OpenPop.Mime.Message

Namespace OpenPop.TestApplication
	''' <summary>
	''' This class is a form which makes it possible to download all messages
	''' from a pop3 mailbox in a simply way.
	''' </summary>
	Public Class TestForm
		Inherits Form
		Private ReadOnly messages As New Dictionary(Of Integer, Message)()
		Private ReadOnly pop3Client As Pop3Client
		Private connectAndRetrieveButton As Button
		Private uidlButton As Button
		Private attachmentPanel As Panel
		Private contextMenuMessages As ContextMenu
		Private gridHeaders As DataGrid
		Private labelServerAddress As Label
		Private labelServerPort As Label
		Private labelAttachments As Label
		Private labelMessageBody As Label
		Private labelMessageNumber As Label
		Private labelTotalMessages As Label
		Private labelPassword As Label
		Private labelUsername As Label
		Private listAttachments As TreeView
		Private listMessages As TreeView
		Private menuDeleteMessage As MenuItem
		Private menuViewSource As MenuItem
		Private panelTop As Panel
		Private panelProperties As Panel
		Private panelMiddle As Panel
		Private panelMessageBody As Panel
		Private panelMessagesView As Panel
		Private saveFile As SaveFileDialog
		Private loginTextBox As TextBox
		Private messageTextBox As TextBox
		Private popServerTextBox As TextBox
		Private passwordTextBox As TextBox
		Private portTextBox As TextBox
		Private totalMessagesTextBox As TextBox
		Private progressBar As ProgressBar
		Private useSslCheckBox As CheckBox

		Private Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' User defined stuff here 
			'

			' This is how you would override the default logger type
			' Here we want to log to a file
			DefaultLogger.SetLog(New FileLogger())

			' Enable file logging and include verbose information
			FileLogger.Enabled = True
			FileLogger.Verbose = True

			pop3Client = New Pop3Client()

			' This is only for faster debugging purposes
			' We will try to load in default values for the hostname, port, ssl, username and password from a file
			Dim myDocs As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
			Dim file__1 As String = Path.Combine(myDocs, "OpenPopLogin.txt")
			If File.Exists(file__1) Then
				Using reader As New StreamReader(File.OpenRead(file__1))
					' This describes how the OpenPOPLogin.txt file should look like
					popServerTextBox.Text = reader.ReadLine()
					' Hostname
					portTextBox.Text = reader.ReadLine()
					' Port
					useSslCheckBox.Checked = Boolean.Parse(If(reader.ReadLine(), "true"))
					' Whether to use SSL or not
					loginTextBox.Text = reader.ReadLine()
					' Username
						' Password
					passwordTextBox.Text = reader.ReadLine()
				End Using
			End If
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		'''   Required method for Designer support - do not modify
		'''   the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(TestForm))
			Me.panelTop = New System.Windows.Forms.Panel()
			Me.useSslCheckBox = New System.Windows.Forms.CheckBox()
			Me.uidlButton = New System.Windows.Forms.Button()
			Me.totalMessagesTextBox = New System.Windows.Forms.TextBox()
			Me.labelTotalMessages = New System.Windows.Forms.Label()
			Me.labelPassword = New System.Windows.Forms.Label()
			Me.passwordTextBox = New System.Windows.Forms.TextBox()
			Me.labelUsername = New System.Windows.Forms.Label()
			Me.loginTextBox = New System.Windows.Forms.TextBox()
			Me.connectAndRetrieveButton = New System.Windows.Forms.Button()
			Me.labelServerPort = New System.Windows.Forms.Label()
			Me.portTextBox = New System.Windows.Forms.TextBox()
			Me.labelServerAddress = New System.Windows.Forms.Label()
			Me.popServerTextBox = New System.Windows.Forms.TextBox()
			Me.panelProperties = New System.Windows.Forms.Panel()
			Me.gridHeaders = New System.Windows.Forms.DataGrid()
			Me.panelMiddle = New System.Windows.Forms.Panel()
			Me.panelMessageBody = New System.Windows.Forms.Panel()
			Me.progressBar = New System.Windows.Forms.ProgressBar()
			Me.messageTextBox = New System.Windows.Forms.TextBox()
			Me.labelMessageBody = New System.Windows.Forms.Label()
			Me.panelMessagesView = New System.Windows.Forms.Panel()
			Me.listMessages = New System.Windows.Forms.TreeView()
			Me.contextMenuMessages = New System.Windows.Forms.ContextMenu()
			Me.menuDeleteMessage = New System.Windows.Forms.MenuItem()
			Me.menuViewSource = New System.Windows.Forms.MenuItem()
			Me.labelMessageNumber = New System.Windows.Forms.Label()
			Me.attachmentPanel = New System.Windows.Forms.Panel()
			Me.listAttachments = New System.Windows.Forms.TreeView()
			Me.labelAttachments = New System.Windows.Forms.Label()
			Me.saveFile = New System.Windows.Forms.SaveFileDialog()
			Me.panelTop.SuspendLayout()
			Me.panelProperties.SuspendLayout()
			DirectCast(Me.gridHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelMiddle.SuspendLayout()
			Me.panelMessageBody.SuspendLayout()
			Me.panelMessagesView.SuspendLayout()
			Me.attachmentPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panelTop
			' 
			Me.panelTop.Controls.Add(Me.useSslCheckBox)
			Me.panelTop.Controls.Add(Me.uidlButton)
			Me.panelTop.Controls.Add(Me.totalMessagesTextBox)
			Me.panelTop.Controls.Add(Me.labelTotalMessages)
			Me.panelTop.Controls.Add(Me.labelPassword)
			Me.panelTop.Controls.Add(Me.passwordTextBox)
			Me.panelTop.Controls.Add(Me.labelUsername)
			Me.panelTop.Controls.Add(Me.loginTextBox)
			Me.panelTop.Controls.Add(Me.connectAndRetrieveButton)
			Me.panelTop.Controls.Add(Me.labelServerPort)
			Me.panelTop.Controls.Add(Me.portTextBox)
			Me.panelTop.Controls.Add(Me.labelServerAddress)
			Me.panelTop.Controls.Add(Me.popServerTextBox)
			Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelTop.Location = New System.Drawing.Point(0, 0)
			Me.panelTop.Name = "panelTop"
			Me.panelTop.Size = New System.Drawing.Size(865, 64)
			Me.panelTop.TabIndex = 0
			' 
			' useSslCheckBox
			' 
			Me.useSslCheckBox.AutoSize = True
			Me.useSslCheckBox.Checked = True
			Me.useSslCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
			Me.useSslCheckBox.Location = New System.Drawing.Point(19, 38)
			Me.useSslCheckBox.Name = "useSslCheckBox"
			Me.useSslCheckBox.Size = New System.Drawing.Size(68, 18)
			Me.useSslCheckBox.TabIndex = 4
			Me.useSslCheckBox.Text = "Use SSL"
			Me.useSslCheckBox.UseVisualStyleBackColor = True
			' 
			' uidlButton
			' 
			Me.uidlButton.Enabled = False
			Me.uidlButton.Location = New System.Drawing.Point(460, 42)
			Me.uidlButton.Name = "uidlButton"
			Me.uidlButton.Size = New System.Drawing.Size(82, 21)
			Me.uidlButton.TabIndex = 6
			Me.uidlButton.Text = "UIDL"
			AddHandler Me.uidlButton.Click, New System.EventHandler(AddressOf Me.UidlButtonClick)
			' 
			' totalMessagesTextBox
			' 
			Me.totalMessagesTextBox.Location = New System.Drawing.Point(553, 30)
			Me.totalMessagesTextBox.Name = "totalMessagesTextBox"
			Me.totalMessagesTextBox.Size = New System.Drawing.Size(100, 20)
			Me.totalMessagesTextBox.TabIndex = 7
			' 
			' labelTotalMessages
			' 
			Me.labelTotalMessages.Location = New System.Drawing.Point(553, 7)
			Me.labelTotalMessages.Name = "labelTotalMessages"
			Me.labelTotalMessages.Size = New System.Drawing.Size(100, 23)
			Me.labelTotalMessages.TabIndex = 9
			Me.labelTotalMessages.Text = "Total Messages"
			' 
			' labelPassword
			' 
			Me.labelPassword.Location = New System.Drawing.Point(264, 36)
			Me.labelPassword.Name = "labelPassword"
			Me.labelPassword.Size = New System.Drawing.Size(64, 23)
			Me.labelPassword.TabIndex = 8
			Me.labelPassword.Text = "Password"
			' 
			' passwordTextBox
			' 
			Me.passwordTextBox.Location = New System.Drawing.Point(328, 36)
			Me.passwordTextBox.Name = "passwordTextBox"
			Me.passwordTextBox.PasswordChar = "*"C
			Me.passwordTextBox.Size = New System.Drawing.Size(128, 20)
			Me.passwordTextBox.TabIndex = 2
			' 
			' labelUsername
			' 
			Me.labelUsername.Location = New System.Drawing.Point(264, 5)
			Me.labelUsername.Name = "labelUsername"
			Me.labelUsername.Size = New System.Drawing.Size(64, 23)
			Me.labelUsername.TabIndex = 6
			Me.labelUsername.Text = "Username"
			' 
			' loginTextBox
			' 
			Me.loginTextBox.Location = New System.Drawing.Point(328, 5)
			Me.loginTextBox.Name = "loginTextBox"
			Me.loginTextBox.Size = New System.Drawing.Size(128, 20)
			Me.loginTextBox.TabIndex = 1
			' 
			' connectAndRetrieveButton
			' 
			Me.connectAndRetrieveButton.Location = New System.Drawing.Point(460, 0)
			Me.connectAndRetrieveButton.Name = "connectAndRetrieveButton"
			Me.connectAndRetrieveButton.Size = New System.Drawing.Size(82, 39)
			Me.connectAndRetrieveButton.TabIndex = 5
			Me.connectAndRetrieveButton.Text = "Connect and Retreive"
			AddHandler Me.connectAndRetrieveButton.Click, New System.EventHandler(AddressOf Me.ConnectAndRetrieveButtonClick)
			' 
			' labelServerPort
			' 
			Me.labelServerPort.Location = New System.Drawing.Point(97, 39)
			Me.labelServerPort.Name = "labelServerPort"
			Me.labelServerPort.Size = New System.Drawing.Size(31, 23)
			Me.labelServerPort.TabIndex = 3
			Me.labelServerPort.Text = "Port"
			' 
			' portTextBox
			' 
			Me.portTextBox.Location = New System.Drawing.Point(128, 39)
			Me.portTextBox.Name = "portTextBox"
			Me.portTextBox.Size = New System.Drawing.Size(128, 20)
			Me.portTextBox.TabIndex = 3
			Me.portTextBox.Text = "110"
			' 
			' labelServerAddress
			' 
			Me.labelServerAddress.Location = New System.Drawing.Point(16, 8)
			Me.labelServerAddress.Name = "labelServerAddress"
			Me.labelServerAddress.Size = New System.Drawing.Size(112, 23)
			Me.labelServerAddress.TabIndex = 1
			Me.labelServerAddress.Text = "POP Server Address"
			' 
			' popServerTextBox
			' 
			Me.popServerTextBox.Location = New System.Drawing.Point(128, 8)
			Me.popServerTextBox.Name = "popServerTextBox"
			Me.popServerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
			Me.popServerTextBox.Size = New System.Drawing.Size(128, 20)
			Me.popServerTextBox.TabIndex = 0
			' 
			' panelProperties
			' 
			Me.panelProperties.Controls.Add(Me.gridHeaders)
			Me.panelProperties.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panelProperties.Location = New System.Drawing.Point(0, 260)
			Me.panelProperties.Name = "panelProperties"
			Me.panelProperties.Size = New System.Drawing.Size(865, 184)
			Me.panelProperties.TabIndex = 1
			' 
			' gridHeaders
			' 
			Me.gridHeaders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.gridHeaders.DataMember = ""
			Me.gridHeaders.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.gridHeaders.Location = New System.Drawing.Point(0, 0)
			Me.gridHeaders.Name = "gridHeaders"
			Me.gridHeaders.PreferredColumnWidth = 400
			Me.gridHeaders.[ReadOnly] = True
			Me.gridHeaders.Size = New System.Drawing.Size(865, 188)
			Me.gridHeaders.TabIndex = 3
			' 
			' panelMiddle
			' 
			Me.panelMiddle.Controls.Add(Me.panelMessageBody)
			Me.panelMiddle.Controls.Add(Me.panelMessagesView)
			Me.panelMiddle.Controls.Add(Me.attachmentPanel)
			Me.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panelMiddle.Location = New System.Drawing.Point(0, 64)
			Me.panelMiddle.Name = "panelMiddle"
			Me.panelMiddle.Size = New System.Drawing.Size(865, 196)
			Me.panelMiddle.TabIndex = 2
			' 
			' panelMessageBody
			' 
			Me.panelMessageBody.Controls.Add(Me.progressBar)
			Me.panelMessageBody.Controls.Add(Me.messageTextBox)
			Me.panelMessageBody.Controls.Add(Me.labelMessageBody)
			Me.panelMessageBody.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panelMessageBody.Location = New System.Drawing.Point(281, 0)
			Me.panelMessageBody.Name = "panelMessageBody"
			Me.panelMessageBody.Size = New System.Drawing.Size(376, 196)
			Me.panelMessageBody.TabIndex = 6
			' 
			' progressBar
			' 
			Me.progressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.progressBar.Location = New System.Drawing.Point(7, 172)
			Me.progressBar.Name = "progressBar"
			Me.progressBar.Size = New System.Drawing.Size(360, 12)
			Me.progressBar.TabIndex = 10
			' 
			' messageTextBox
			' 
			Me.messageTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.messageTextBox.Location = New System.Drawing.Point(7, 22)
			Me.messageTextBox.MaxLength = 999999999
			Me.messageTextBox.Multiline = True
			Me.messageTextBox.Name = "messageTextBox"
			Me.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.messageTextBox.Size = New System.Drawing.Size(360, 143)
			Me.messageTextBox.TabIndex = 9
			' 
			' labelMessageBody
			' 
			Me.labelMessageBody.Location = New System.Drawing.Point(8, 8)
			Me.labelMessageBody.Name = "labelMessageBody"
			Me.labelMessageBody.Size = New System.Drawing.Size(136, 16)
			Me.labelMessageBody.TabIndex = 5
			Me.labelMessageBody.Text = "Message Body"
			' 
			' panelMessagesView
			' 
			Me.panelMessagesView.Controls.Add(Me.listMessages)
			Me.panelMessagesView.Controls.Add(Me.labelMessageNumber)
			Me.panelMessagesView.Dock = System.Windows.Forms.DockStyle.Left
			Me.panelMessagesView.Location = New System.Drawing.Point(0, 0)
			Me.panelMessagesView.Name = "panelMessagesView"
			Me.panelMessagesView.Size = New System.Drawing.Size(281, 196)
			Me.panelMessagesView.TabIndex = 5
			' 
			' listMessages
			' 
			Me.listMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.listMessages.ContextMenu = Me.contextMenuMessages
			Me.listMessages.Location = New System.Drawing.Point(8, 24)
			Me.listMessages.Name = "listMessages"
			Me.listMessages.Size = New System.Drawing.Size(266, 160)
			Me.listMessages.TabIndex = 8
			AddHandler Me.listMessages.AfterSelect, New System.Windows.Forms.TreeViewEventHandler(AddressOf Me.ListMessagesMessageSelected)
			' 
			' contextMenuMessages
			' 
			Me.contextMenuMessages.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuDeleteMessage, Me.menuViewSource})
			' 
			' menuDeleteMessage
			' 
			Me.menuDeleteMessage.Index = 0
			Me.menuDeleteMessage.Text = "Delete Mail"
			AddHandler Me.menuDeleteMessage.Click, New System.EventHandler(AddressOf Me.MenuDeleteMessageClick)
			' 
			' menuViewSource
			' 
			Me.menuViewSource.Index = 1
			Me.menuViewSource.Text = "View source"
			AddHandler Me.menuViewSource.Click, New System.EventHandler(AddressOf Me.MenuViewSourceClick)
			' 
			' labelMessageNumber
			' 
			Me.labelMessageNumber.Location = New System.Drawing.Point(8, 8)
			Me.labelMessageNumber.Name = "labelMessageNumber"
			Me.labelMessageNumber.Size = New System.Drawing.Size(136, 16)
			Me.labelMessageNumber.TabIndex = 1
			Me.labelMessageNumber.Text = "Messages"
			' 
			' attachmentPanel
			' 
			Me.attachmentPanel.Controls.Add(Me.listAttachments)
			Me.attachmentPanel.Controls.Add(Me.labelAttachments)
			Me.attachmentPanel.Dock = System.Windows.Forms.DockStyle.Right
			Me.attachmentPanel.Location = New System.Drawing.Point(657, 0)
			Me.attachmentPanel.Name = "attachmentPanel"
			Me.attachmentPanel.Size = New System.Drawing.Size(208, 196)
			Me.attachmentPanel.TabIndex = 4
			Me.attachmentPanel.Visible = False
			' 
			' listAttachments
			' 
			Me.listAttachments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.listAttachments.Location = New System.Drawing.Point(8, 24)
			Me.listAttachments.Name = "listAttachments"
			Me.listAttachments.ShowLines = False
			Me.listAttachments.ShowRootLines = False
			Me.listAttachments.Size = New System.Drawing.Size(192, 160)
			Me.listAttachments.TabIndex = 10
			AddHandler Me.listAttachments.AfterSelect, New System.Windows.Forms.TreeViewEventHandler(AddressOf Me.ListAttachmentsAttachmentSelected)
			' 
			' labelAttachments
			' 
			Me.labelAttachments.Location = New System.Drawing.Point(12, 8)
			Me.labelAttachments.Name = "labelAttachments"
			Me.labelAttachments.Size = New System.Drawing.Size(136, 16)
			Me.labelAttachments.TabIndex = 3
			Me.labelAttachments.Text = "Attachments"
			' 
			' saveFile
			' 
			Me.saveFile.Title = "Save Attachment"
			' 
			' TestForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(865, 444)
			Me.Controls.Add(Me.panelMiddle)
			Me.Controls.Add(Me.panelProperties)
			Me.Controls.Add(Me.panelTop)
			Me.Icon = DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "TestForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "OpenPOP.NET Test Application"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			Me.panelTop.ResumeLayout(False)
			Me.panelTop.PerformLayout()
			Me.panelProperties.ResumeLayout(False)
			DirectCast(Me.gridHeaders, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelMiddle.ResumeLayout(False)
			Me.panelMessageBody.ResumeLayout(False)
			Me.panelMessageBody.PerformLayout()
			Me.panelMessagesView.ResumeLayout(False)
			Me.attachmentPanel.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		'''   The main entry point for the application.
		''' </summary>
		<STAThread> _
		Private Shared Sub Main()
			Application.Run(New TestForm())
		End Sub

		Private Sub ReceiveMails()
			' Disable buttons while working
			connectAndRetrieveButton.Enabled = False
			uidlButton.Enabled = False
			progressBar.Value = 0

			Try
				If pop3Client.Connected Then
					pop3Client.Disconnect()
				End If
				pop3Client.Connect(popServerTextBox.Text, Integer.Parse(portTextBox.Text), useSslCheckBox.Checked)
				pop3Client.Authenticate(loginTextBox.Text, passwordTextBox.Text)
				Dim count As Integer = pop3Client.GetMessageCount()
				totalMessagesTextBox.Text = count.ToString()
				messageTextBox.Text = ""
				messages.Clear()
				listMessages.Nodes.Clear()
				listAttachments.Nodes.Clear()

				Dim success As Integer = 0
				Dim fail As Integer = 0
				For i As Integer = count To 1 Step -1
					' Check if the form is closed while we are working. If so, abort
					If IsDisposed Then
						Return
					End If

					' Refresh the form while fetching emails
					' This will fix the "Application is not responding" problem
					Application.DoEvents()

					Try
						Dim message As Message = pop3Client.GetMessage(i)

						' Add the message to the dictionary from the messageNumber to the Message
						messages.Add(i, message)

						' Create a TreeNode tree that mimics the Message hierarchy
						Dim node As TreeNode = New TreeNodeBuilder().VisitMessage(message)

						' Set the Tag property to the messageNumber
						' We can use this to find the Message again later
						node.Tag = i

						' Show the built node in our list of messages
						listMessages.Nodes.Add(node)

						success += 1
					Catch e As Exception
						DefaultLogger.Log.LogError("TestForm: Message fetching failed: " & e.Message & vbCr & vbLf & "Stack trace:" & vbCr & vbLf & e.StackTrace)
						fail += 1
					End Try

					progressBar.Value = CInt(Math.Truncate((CDbl(count - i) / count) * 100))
				Next

				MessageBox.Show(Me, "Mail received!" & vbLf & "Successes: " & success & vbLf & "Failed: " & fail, "Message fetching done")

				If fail > 0 Then
					MessageBox.Show(Me, "Since some of the emails were not parsed correctly (exceptions were thrown)" & vbCr & vbLf & "please consider sending your log file to the developer for fixing." & vbCr & vbLf & "If you are able to include any extra information, please do so.", "Help improve OpenPop!")
				End If
			Catch generatedExceptionName As InvalidLoginException
				MessageBox.Show(Me, "The server did not accept the user credentials!", "POP3 Server Authentication")
			Catch generatedExceptionName As PopServerNotFoundException
				MessageBox.Show(Me, "The server could not be found", "POP3 Retrieval")
			Catch generatedExceptionName As PopServerLockedException
				MessageBox.Show(Me, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked")
			Catch generatedExceptionName As LoginDelayException
				MessageBox.Show(Me, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay")
			Catch e As Exception
				MessageBox.Show(Me, "Error occurred retrieving mail. " & e.Message, "POP3 Retrieval")
			Finally
				' Enable the buttons again
				connectAndRetrieveButton.Enabled = True
				uidlButton.Enabled = True
				progressBar.Value = 100
			End Try
		End Sub

		Private Sub ConnectAndRetrieveButtonClick(sender As Object, e As EventArgs)
			ReceiveMails()
		End Sub

		Private Sub ListMessagesMessageSelected(sender As Object, e As TreeViewEventArgs)
			' Fetch out the selected message
			Dim message As Message = messages(GetMessageNumberFromSelectedNode(listMessages.SelectedNode))

			' If the selected node contains a MessagePart and we can display the contents - display them
			If TypeOf listMessages.SelectedNode.Tag Is MessagePart Then
				Dim selectedMessagePart As MessagePart = DirectCast(listMessages.SelectedNode.Tag, MessagePart)
				If selectedMessagePart.IsText Then
					' We can show text MessageParts
					messageTextBox.Text = selectedMessagePart.GetBodyAsText()
				Else
					' We are not able to show non-text MessageParts (MultiPart messages, images, pdf's ...)
					messageTextBox.Text = "<<OpenPop>> Cannot show this part of the email. It is not text <<OpenPop>>"
				End If
			Else
				' If the selected node is not a subnode and therefore does not
				' have a MessagePart in it's Tag property, we genericly find some content to show

				' Find the first text/plain version
				Dim plainTextPart As MessagePart = message.FindFirstPlainTextVersion()
				If plainTextPart IsNot Nothing Then
					' The message had a text/plain version - show that one
					messageTextBox.Text = plainTextPart.GetBodyAsText()
				Else
					' Try to find a body to show in some of the other text versions
					Dim textVersions As List(Of MessagePart) = message.FindAllTextVersions()
					If textVersions.Count >= 1 Then
						messageTextBox.Text = textVersions(0).GetBodyAsText()
					Else
						messageTextBox.Text = "<<OpenPop>> Cannot find a text version body in this message to show <<OpenPop>>"
					End If
				End If
			End If

			' Clear the attachment list from any previus shown attachments
			listAttachments.Nodes.Clear()

			' Build up the attachment list
			Dim attachments As List(Of MessagePart) = message.FindAllAttachments()
			For Each attachment As MessagePart In attachments
				' Add the attachment to the list of attachments
				Dim addedNode As TreeNode = listAttachments.Nodes.Add((attachment.FileName))

				' Keep a reference to the attachment in the Tag property
				addedNode.Tag = attachment
			Next

			' Only show that attachmentPanel if there is attachments in the message
			Dim hadAttachments As Boolean = attachments.Count > 0
			attachmentPanel.Visible = hadAttachments

			' Generate header table
			Dim dataSet As New DataSet()
			Dim table As DataTable = dataSet.Tables.Add("Headers")
			table.Columns.Add("Header")
			table.Columns.Add("Value")

			Dim rows As DataRowCollection = table.Rows

			' Add all known headers
			rows.Add(New Object() {"Content-Description", message.Headers.ContentDescription})
			rows.Add(New Object() {"Content-Id", message.Headers.ContentId})
			For Each keyword As String In message.Headers.Keywords
				rows.Add(New Object() {"Keyword", keyword})
			Next
			For Each dispositionNotificationTo As RfcMailAddress In message.Headers.DispositionNotificationTo
				rows.Add(New Object() {"Disposition-Notification-To", dispositionNotificationTo})
			Next
			For Each received As Received In message.Headers.Received
				rows.Add(New Object() {"Received", received.Raw})
			Next
			rows.Add(New Object() {"Importance", message.Headers.Importance})
			rows.Add(New Object() {"Content-Transfer-Encoding", message.Headers.ContentTransferEncoding})
			For Each cc As RfcMailAddress In message.Headers.Cc
				rows.Add(New Object() {"Cc", cc})
			Next
			For Each bcc As RfcMailAddress In message.Headers.Bcc
				rows.Add(New Object() {"Bcc", bcc})
			Next
			For Each [to] As RfcMailAddress In message.Headers.[To]
				rows.Add(New Object() {"To", [to]})
			Next
			rows.Add(New Object() {"From", message.Headers.From})
			rows.Add(New Object() {"Reply-To", message.Headers.ReplyTo})
			For Each inReplyTo As String In message.Headers.InReplyTo
				rows.Add(New Object() {"In-Reply-To", inReplyTo})
			Next
			For Each reference As String In message.Headers.References
				rows.Add(New Object() {"References", reference})
			Next
			rows.Add(New Object() {"Sender", message.Headers.Sender})
			rows.Add(New Object() {"Content-Type", message.Headers.ContentType})
			rows.Add(New Object() {"Content-Disposition", message.Headers.ContentDisposition})
			rows.Add(New Object() {"Date", message.Headers.[Date]})
			rows.Add(New Object() {"Date", message.Headers.DateSent})
			rows.Add(New Object() {"Message-Id", message.Headers.MessageId})
			rows.Add(New Object() {"Mime-Version", message.Headers.MimeVersion})
			rows.Add(New Object() {"Return-Path", message.Headers.ReturnPath})
			rows.Add(New Object() {"Subject", message.Headers.Subject})

			' Add all unknown headers
			For Each key As String In message.Headers.UnknownHeaders
				Dim values As String() = message.Headers.UnknownHeaders.GetValues(key)
				If values IsNot Nothing Then
					For Each value As String In values
						rows.Add(New Object() {key, value})
					Next
				End If
			Next

			' Now set the headers displayed on the GUI to the header table we just generated
			gridHeaders.DataMember = table.TableName
			gridHeaders.DataSource = dataSet
		End Sub

		''' <summary>
		''' Finds the MessageNumber of a Message given a <see cref="TreeNode"/> to search in.
		''' The root of this <see cref="TreeNode"/> should have the Tag property set to a int, which
		''' points into the <see cref="messages"/> dictionary.
		''' </summary>
		''' <param name="node">The <see cref="TreeNode"/> to look in. Cannot be <see langword="null"/>.</param>
		''' <returns>The found int</returns>
		Private Shared Function GetMessageNumberFromSelectedNode(node As TreeNode) As Integer
			If node Is Nothing Then
				Throw New ArgumentNullException("node")
			End If

			' Check if we are at the root, by seeing if it has the Tag property set to an int
			If TypeOf node.Tag Is Integer Then
				Return CInt(node.Tag)
			End If

			' Otherwise we are not at the root, move up the tree
			Return GetMessageNumberFromSelectedNode(node.Parent)
		End Function

		Private Sub ListAttachmentsAttachmentSelected(sender As Object, args As TreeViewEventArgs)
			' Fetch the attachment part which is currently selected
			Dim attachment As MessagePart = DirectCast(listAttachments.SelectedNode.Tag, MessagePart)

			If attachment IsNot Nothing Then
				saveFile.FileName = attachment.FileName
				Dim result As DialogResult = saveFile.ShowDialog()
				If result <> DialogResult.OK Then
					Return
				End If

				' Now we want to save the attachment
				Dim file As New FileInfo(saveFile.FileName)

				' Check if the file already exists
				If file.Exists Then
					' User was asked when he chose the file, if he wanted to overwrite it
					' Therefore, when we get to here, it is okay to delete the file
					file.Delete()
				End If

				' Lets try to save to the file
				Try
					attachment.Save(file)

					MessageBox.Show(Me, "Attachment saved successfully")
				Catch e As Exception
					MessageBox.Show(Me, "Attachment saving failed. Exception message: " & e.Message)
				End Try
			Else
				MessageBox.Show(Me, "Attachment object was null!")
			End If
		End Sub

		Private Sub MenuDeleteMessageClick(sender As Object, e As EventArgs)
			If listMessages.SelectedNode IsNot Nothing Then
				Dim drRet As DialogResult = MessageBox.Show(Me, "Are you sure to delete the email?", "Delete email", MessageBoxButtons.YesNo)
				If drRet = DialogResult.Yes Then
					Dim messageNumber As Integer = GetMessageNumberFromSelectedNode(listMessages.SelectedNode)
					pop3Client.DeleteMessage(messageNumber)

					listMessages.Nodes(messageNumber).Remove()

					drRet = MessageBox.Show(Me, "Do you want to receive email again (this will commit your changes)?", "Receive email", MessageBoxButtons.YesNo)
					If drRet = DialogResult.Yes Then
						ReceiveMails()
					End If
				End If
			End If
		End Sub

		Private Sub UidlButtonClick(sender As Object, e As EventArgs)
			Dim uids As List(Of String) = pop3Client.GetMessageUids()

			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("UIDL:")
			stringBuilder.Append(vbCr & vbLf)
			For Each uid As String In uids
				stringBuilder.Append(uid)
				stringBuilder.Append(vbCr & vbLf)
			Next

			messageTextBox.Text = stringBuilder.ToString()
		End Sub

		Private Sub MenuViewSourceClick(sender As Object, e As EventArgs)

			If listMessages.SelectedNode IsNot Nothing Then
				Dim messageNumber As Integer = GetMessageNumberFromSelectedNode(listMessages.SelectedNode)
				Dim m As Message = messages(messageNumber)

				' We do not know the encoding of the full message - and the parts could be differently
				' encoded. Therefore we take a choice of simply using US-ASCII encoding on the raw bytes
				' to get the source code for the message. Any bytes not in th US-ASCII encoding, will then be
				' turned into question marks "?"
				Dim sourceForm As New ShowSourceForm(Encoding.ASCII.GetString(m.RawMessage))
				sourceForm.ShowDialog()
			End If
		End Sub
	End Class
End Namespace
