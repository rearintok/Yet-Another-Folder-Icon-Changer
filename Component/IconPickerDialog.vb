Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Public Class IconPickerDialog
    Inherits CommonDialog
    Private Const MAX_PATH As Integer = 260

    <DllImport("shell32.dll", EntryPoint:="#62", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function SHPickIconDialog(hWnd As IntPtr, pszFilename As StringBuilder, cchFilenameMax As Integer, ByRef pnIconIndex As Integer) As Boolean
    End Function

    Private _filename As String = Nothing

    <DefaultValue("")> _
    Public Property Filename() As String
        Get
            Return Me._filename
        End Get
        Set(value As String)
            Me._filename = value
        End Set
    End Property

    Private _iconIndex As Integer = 0

    <DefaultValue(0)> _
    Public Property IconIndex() As Integer
        Get
            Return Me._iconIndex
        End Get
        Set(value As Integer)
            Me._iconIndex = value
        End Set
    End Property

    Protected Overrides Function RunDialog(hwndOwner As IntPtr) As Boolean
        Dim buf As New StringBuilder(Me._filename, MAX_PATH)
        Dim iconIndex As Integer

        Dim ok As Boolean = SHPickIconDialog(hwndOwner, buf, MAX_PATH, iconIndex)
        If ok Then
            Me._filename = Environment.ExpandEnvironmentVariables(buf.ToString())
            Me._iconIndex = iconIndex
        End If

        Return ok
    End Function

    Public Overrides Sub Reset()
        Me._filename = Nothing
        Me._iconIndex = 0
    End Sub
End Class

