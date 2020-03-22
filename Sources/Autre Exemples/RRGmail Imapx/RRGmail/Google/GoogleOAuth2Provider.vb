Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text

Public Class GoogleOAuth2Provider

    Const AUTH_URI As String = "https://accounts.google.com/o/oauth2/auth"
    Const REDIRECT_URI As String = "urn:ietf:wg:oauth:2.0:oob"
    Const GET_ACCESS_TOKEN_URI As String = "https://accounts.google.com/o/oauth2/token"
    Const GET_USER_PROFILE_URI As String = "https://www.googleapis.com/oauth2/v1/userinfo"

    Const CLIENT_ID As String = "819410764762.apps.googleusercontent.com"
    Const CLIENT_SECRET As String = "vz1VGPT2meoSJ5RXBco-56aR"


    Const SCOPE_USER_EMAIL As String = "https://www.googleapis.com/auth/userinfo.email"
    Const SCOPE_GMAIL As String = "https://mail.google.com/"
    Const RESPONSE_TYPE_CODE As String = "code"

    Public Shared Function BuildAuthenticationUri() As Uri
        Return New Uri(String.Format("{0}?response_type={1}&client_id={2}&redirect_uri={3}&scope={4}%20{5}", AUTH_URI, RESPONSE_TYPE_CODE, CLIENT_ID, REDIRECT_URI, SCOPE_USER_EMAIL, _
         SCOPE_GMAIL))
    End Function

    Public Shared Function GetAccessToken(code As String) As GoogleAccessToken
        Dim postData As String = String.Format("client_id={0}&client_secret={1}&grant_type=authorization_code&code={2}&redirect_uri={3}", CLIENT_ID, CLIENT_SECRET, code, REDIRECT_URI)


        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(GET_ACCESS_TOKEN_URI), HttpWebRequest)
        request.KeepAlive = False
        request.ProtocolVersion = HttpVersion.Version10
        request.Method = "POST"


        Dim postBytes As Byte() = Encoding.UTF8.GetBytes(postData)

        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = postBytes.Length
        Dim requestStream As Stream = request.GetRequestStream()

        requestStream.Write(postBytes, 0, postBytes.Length)
        requestStream.Close()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
        Using responseReader = New StreamReader(response.GetResponseStream())
            Dim tmp = responseReader.ReadToEnd()
            Return JsonHelper.From(Of GoogleAccessToken)(tmp)
        End Using
    End Function

    Public Shared Function GetUserProfile(accessToken As GoogleAccessToken) As GoogleProfile
        Using w = New WebClient()
            Dim url = String.Format("{0}?access_token=", GET_USER_PROFILE_URI, accessToken.access_token)

            w.Headers.Add("Authorization", String.Format("Bearer  {0}", accessToken.access_token))

            w.Encoding = Encoding.UTF8
            Dim tmp = w.DownloadString(url)

            Return JsonHelper.From(Of GoogleProfile)(tmp)
        End Using
    End Function

End Class
