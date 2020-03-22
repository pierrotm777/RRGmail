Imports System.Windows.Forms
Imports OpenPop.Mime
Imports OpenPop.Mime.Traverse
Imports Message = OpenPop.Mime.Message

'Namespace OpenPop.TestApplication
	''' <summary>
	''' Builds up a <see cref="TreeNode"/> with the same hierarchy as
	''' a <see cref="Message"/>.
	''' 
	''' The root <see cref="TreeNode"/> has the subject as text and has one one child.
	''' The root has no Tag attribute set.
	''' 
	''' The children of the root has the MediaType of the <see cref="MessagePart"/> as text and the
	''' MessagePart's children as <see cref="TreeNode"/> children.
	''' Each <see cref="MessagePart"/> <see cref="TreeNode"/> has a Tag property set to that <see cref="MessagePart"/>
	''' </summary>
	Friend Class TreeNodeBuilder
    'Implements IAnswerMessageTraverser(Of TreeNode)
		Public Function VisitMessage(message As Message) As TreeNode
			If message Is Nothing Then
				Throw New ArgumentNullException("message")
			End If

			' First build up the child TreeNode
			Dim child As TreeNode = VisitMessagePart(message.MessagePart)

			' Then create the topmost root node with the subject as text
        'Dim topNode As New TreeNode(message.Headers.Subject, New () {child})
        Dim topNode As New TreeNode(message.Headers.Subject)

			Return topNode
		End Function

		Public Function VisitMessagePart(messagePart As MessagePart) As TreeNode
			If messagePart Is Nothing Then
				Throw New ArgumentNullException("messagePart")
			End If

			' Default is that this MessagePart TreeNode has no children
			Dim children As TreeNode() = New TreeNode(-1) {}

			If messagePart.IsMultiPart Then
				' If the MessagePart has children, in which case it is a MultiPart, then
				' we create the child TreeNodes here
				children = New TreeNode(messagePart.MessageParts.Count - 1) {}

				For i As Integer = 0 To messagePart.MessageParts.Count - 1
					children(i) = VisitMessagePart(messagePart.MessageParts(i))
				Next
			End If

			' Create the current MessagePart TreeNode with the found children
			Dim currentNode As New TreeNode(messagePart.ContentType.MediaType, children)

			' Set the Tag attribute to point to the MessagePart.
			currentNode.Tag = messagePart

			Return currentNode
		End Function
	End Class
'End Namespace
