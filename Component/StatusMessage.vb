Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
<System.Drawing.ToolboxBitmap(GetType(System.Windows.Forms.StatusBar))> <ProvideProperty("StatusMessage", GetType(Component))> _
Public Class StatusMessage
    Inherits Component
    Implements IExtenderProvider
    Dim mControlLookup As Hashtable = New Hashtable
    Dim mLastMessage As String = String.Empty
    Public Sub SetStatusMessage(ByVal senderComponent As Component, ByVal strMessage As String)
        If Not mControlLookup.Contains(senderComponent) Then
            mControlLookup.Add(senderComponent, strMessage)
            Dim pMenuItem As ToolStripMenuItem = CType(senderComponent, ToolStripMenuItem)
            If pMenuItem IsNot Nothing Then
                AddHandler pMenuItem.MouseMove, AddressOf Handle_MenuSelect
                AddHandler pMenuItem.MouseLeave, AddressOf Handle_MenuLeave
                AddHandler pMenuItem.MouseEnter, AddressOf Handle_MenuEnter
            Else
                mControlLookup(senderComponent) = strMessage
            End If
        Else
            mControlLookup(senderComponent) = strMessage
        End If
    End Sub
    ''' <summary>
    ''' Returns current controls tool-tip
    ''' </summary>
    ''' <param name="senderComponent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStatusMessage(ByVal senderComponent As Component) As String
        If mControlLookup.Contains(senderComponent) Then
            Return mControlLookup(senderComponent).ToString
        End If
        Return String.Empty
    End Function
    Public Function CanExtend(ByVal senderComponent As Object) As _
       Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        Return TypeOf senderComponent Is ToolStripMenuItem
    End Function
    Private mStatusBar As ToolStripStatusLabel
    Public Property StatusBar() As ToolStripStatusLabel
        Get
            Return mStatusBar
        End Get
        Set(ByVal value As ToolStripStatusLabel)
            mStatusBar = value
        End Set
    End Property
    Private Sub Handle_MenuSelect(ByVal pControl As Object, ByVal e As MouseEventArgs)
        If StatusBar Is Nothing Then
            Exit Sub
        End If
        If mControlLookup.Contains(pControl) Then
            If Not mControlLookup(pControl).ToString.Trim = String.Empty Then
                StatusBar.Text = mControlLookup(pControl).ToString
            End If
        End If
    End Sub
    Private Sub Handle_MenuLeave(ByVal pControl As Object, ByVal e As EventArgs)
        If StatusBar Is Nothing Then
            Exit Sub
        End If
        StatusBar.Text = Me.mLastMessage
    End Sub
    Private Sub Handle_MenuEnter(ByVal pControl As Object, ByVal e As EventArgs)
        If StatusBar Is Nothing Then
            Exit Sub
        End If
        Me.mLastMessage = StatusBar.Text
    End Sub
End Class
