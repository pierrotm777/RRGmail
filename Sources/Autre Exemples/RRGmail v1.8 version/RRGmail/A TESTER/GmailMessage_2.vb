Imports System.Web.Mail

Namespace RC.Gmail

	''' <summary>
	''' Provides a message object that sends the email through gmail. 
	''' GmailMessage is inherited to <c>System.Web.Mail.MailMessage</c>, so all the mail message features are available.
	''' </summary>
	Public Class GmailMessage
        Inherits System.Web.Mail.MailMessage

		#Region "CDO Configuration Constants"

		Private Const SMTP_SERVER As String = "http://schemas.microsoft.com/cdo/configuration/smtpserver"
		Private Const SMTP_SERVER_PORT As String = "http://schemas.microsoft.com/cdo/configuration/smtpserverport"
		Private Const SEND_USING As String = "http://schemas.microsoft.com/cdo/configuration/sendusing"
		Private Const SMTP_USE_SSL As String = "http://schemas.microsoft.com/cdo/configuration/smtpusessl"
		Private Const SMTP_AUTHENTICATE As String = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"
		Private Const SEND_USERNAME As String = "http://schemas.microsoft.com/cdo/configuration/sendusername"
		Private Const SEND_PASSWORD As String = "http://schemas.microsoft.com/cdo/configuration/sendpassword"

		#End Region

		#Region "Private Variables"

		Private Shared _gmailServer As String = "smtp.gmail.com"
        Private Shared _gmailPort As Long = 587 '465 'or 587
		Private _gmailUserName As String = String.Empty
		Private _gmailPassword As String = String.Empty

		#End Region

		#Region "Public Members"

		''' <summary>
		''' Constructor, creates the GmailMessage object
		''' </summary>
		''' <param name="gmailUserName">The username of the gmail account that the message will be sent through</param>
		''' <param name="gmailPassword">The password of the gmail account that the message will be sent through</param>
		Public Sub New(gmailUserName As String, gmailPassword As String)
			Me.Fields(SMTP_SERVER) = GmailMessage.GmailServer
			Me.Fields(SMTP_SERVER_PORT) = GmailMessage.GmailServerPort
			Me.Fields(SEND_USING) = 2
			Me.Fields(SMTP_USE_SSL) = True
			Me.Fields(SMTP_AUTHENTICATE) = 1
			Me.Fields(SEND_USERNAME) = gmailUserName
			Me.Fields(SEND_PASSWORD) = gmailPassword

			_gmailUserName = gmailUserName
			_gmailPassword = gmailPassword
		End Sub

		''' <summary>
		''' Sends the message. If no to address is given the message will be to <c>GmailUserName</c>@Gmail.com
		''' </summary>
		Public Sub Send()
			Try
				If Me.From = String.Empty Then
					Me.From = GmailUserName
					If GmailUserName.IndexOf("@"C) = -1 Then
						Me.From += "@Gmail.com"
					End If
				End If

                System.Web.Mail.SmtpMail.Send(Me)
			Catch ex As Exception
				'TODO: Add error handling
				Throw ex
			End Try
		End Sub

		''' <summary>
		''' The username of the gmail account that the message will be sent through
		''' </summary>
		Public Property GmailUserName() As String
			Get
				Return _gmailUserName
			End Get
			Set
				_gmailUserName = value
			End Set
		End Property

		''' <summary>
		''' The password of the gmail account that the message will be sent through
		''' </summary>
		Public Property GmailPassword() As String
			Get
				Return _gmailPassword
			End Get
			Set
				_gmailPassword = value
			End Set
		End Property

		#End Region

		#Region "Static Members"

		''' <summary>
		''' Send a <c>System.Web.Mail.MailMessage</c> through the specified gmail account
		''' </summary>
		''' <param name="gmailUserName">The username of the gmail account that the message will be sent through</param>
		''' <param name="gmailPassword">The password of the gmail account that the message will be sent through</param>
		''' <param name="message"><c>System.Web.Mail.MailMessage</c> object to send</param>
        Public Shared Sub SendMailMessageFromGmail(gmailUserName As String, gmailPassword As String, message As MailMessage)
            Try
                message.Fields(SMTP_SERVER) = GmailMessage.GmailServer
                message.Fields(SMTP_SERVER_PORT) = GmailMessage.GmailServerPort
                message.Fields(SEND_USING) = 2
                message.Fields(SMTP_USE_SSL) = True
                message.Fields(SMTP_AUTHENTICATE) = 1
                message.Fields(SEND_USERNAME) = gmailUserName
                message.Fields(SEND_PASSWORD) = gmailPassword

                System.Web.Mail.SmtpMail.Send(message)
            Catch ex As Exception
                'TODO: Add error handling
                Throw ex
            End Try
        End Sub

		''' <summary>
		''' Sends an email through the specified gmail account
		''' </summary>
		''' <param name="gmailUserName">The username of the gmail account that the message will be sent through</param>
		''' <param name="gmailPassword">The password of the gmail account that the message will be sent through</param>
		''' <param name="toAddress">Recipients email address</param>
		''' <param name="subject">Message subject</param>
        ''' <param name="messageBody">Message body</param>
        ''' <param name="gmailAttachment">attached file</param>
        Public Shared Sub SendFromGmail(gmailUserName As String, gmailPassword As String, toAddress As String, subject As String, messageBody As String)
            Try
                Dim gMessage As New GmailMessage(gmailUserName, gmailPassword)

                gMessage.[To] = toAddress
                gMessage.Subject = subject
                gMessage.Body = messageBody
                gMessage.From = gmailUserName
                If gmailUserName.IndexOf("@"c) = -1 Then
                    gMessage.From += "@Gmail.com"
                End If

                System.Web.Mail.SmtpMail.Send(gMessage)
            Catch ex As Exception
                'TODO: Add error handling
                Throw ex
            End Try
        End Sub

		''' <summary>
		''' The name of the gmail server, the default is "smtp.gmail.com"
		''' </summary>
		Public Shared Property GmailServer() As String
			Get
				Return _gmailServer
			End Get
			Set
				_gmailServer = value
			End Set
		End Property

		''' <summary>
		''' The port to use when sending the email, the default is 465
		''' </summary>
		Public Shared Property GmailServerPort() As Long
			Get
				Return _gmailPort
			End Get
			Set
				_gmailPort = value
			End Set
		End Property

		#End Region

	End Class
	'GmailMessage
End Namespace
'RC.Gmail
