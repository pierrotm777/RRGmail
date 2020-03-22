Imports System.Runtime.InteropServices


<StructLayout(LayoutKind.Sequential)> _
Public Structure SHFILEINFO
    Public hIcon As IntPtr
    Public iIcon As IntPtr
    Public dwAttributes As UInteger
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
    Public szTypeName As String
End Structure

