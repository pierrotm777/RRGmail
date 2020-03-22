Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class NativeMethods
    Public Const SHGFI_ICON As UInteger = &H100
    Public Const SHGFI_LARGEICON As UInteger = &H0
    ' 'Large icon 
    Public Const SHGFI_SMALLICON As UInteger = &H1
    ' 'Small icon 
    Public Const GWL_STYLE As Integer = -16

    Public Const WS_VSCROLL As Integer = &H200000
    Public Const WS_HSCROLL As Integer = &H100000

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    <DllImport("shell32.dll")> _
    Public Shared Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbSizeFileInfo As UInteger, uFlags As UInteger) As IntPtr
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function DestroyIcon(hIcon As IntPtr) As Integer
    End Function

    Public Shared Function GetSystemIcon(sFilename As String) As Icon
        Dim shinfo = New SHFILEINFO()
        SHGetFileInfo(sFilename, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), SHGFI_ICON Or SHGFI_SMALLICON)

        Dim myIcon = DirectCast(Icon.FromHandle(shinfo.hIcon).Clone(), Icon)
        DestroyIcon(shinfo.hIcon)
        ' Cleanup 
        Return myIcon
    End Function

    Public Shared Function GetVisibleScrollbars(ctl As Control) As ScrollBars
        Dim wndStyle As Integer = GetWindowLong(ctl.Handle, GWL_STYLE)
        Dim hsVisible As Boolean = (wndStyle And WS_HSCROLL) <> 0
        Dim vsVisible As Boolean = (wndStyle And WS_VSCROLL) <> 0

        If hsVisible Then
            Return If(vsVisible, ScrollBars.Both, ScrollBars.Horizontal)
        End If
        Return If(vsVisible, ScrollBars.Vertical, ScrollBars.None)
    End Function

End Class
