Imports System.Xml
Imports System.Text
Public Class LoginForm1
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim objClient As New System.Net.WebClient
        Dim nodelist As XmlNodeList
        Dim node As XmlNode
        Dim response As String
        Dim xmlDoc As New XmlDocument
        Try

            objClient.Credentials = New System.Net.NetworkCredential(UsernameTextBox.Text.Trim, PasswordTextBox.Text.Trim)
            response = Encoding.UTF8.GetString(objClient.DownloadData("https://mail.google.com/mail/feed/atom"))
            response = response.Replace("<feed version=""0.3"" xmlns=""http://purl.org/atom/ns#"">", "<feed>")

            xmlDoc.LoadXml(response)
            node = xmlDoc.SelectSingleNode("/feed/fullcount")
            mailCount = node.InnerText 'Get the number of unread emails

            If mailCount > 0 Then
                ReDim emailFrom(mailCount - 1)
                ReDim emailMessages(mailCount - 1)
                nodelist = xmlDoc.SelectNodes("/feed/entry")
                node = xmlDoc.SelectSingleNode("title")

                For Each node In nodelist
                    emailMessages(tempCounter) = node.ChildNodes.Item(0).InnerText
                    emailFrom(tempCounter) = node.ChildNodes.Item(6).ChildNodes(0).InnerText
                    tempCounter += 1
                Next
                tempCounter = 0
            End If
            Me.Hide()
            Form1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
