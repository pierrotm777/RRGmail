

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Me.Hide()
        Me.ShowInTaskbar = False
        Left = (SystemInformation.WorkingArea.Size.Width - Size.Width)
        Top = (SystemInformation.WorkingArea.Size.Height - Size.Height)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Show()
        If tempCounter >= mailCount Then
            Timer1.Enabled = False
            Me.Hide()
        Else
            lblFrom.Text = "From : " & emailFrom(tempCounter)
            lblMessage.Text = "Subject : " & emailMessages(tempCounter)
            tempCounter += 1
        End If

    End Sub

End Class
