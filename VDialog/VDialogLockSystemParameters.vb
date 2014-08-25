''' <summary>
''' Helper class required by LockSystem feature.
''' </summary>
Friend Class VDialogLockSystemParameters
    Public NewDesktop As IntPtr
    Public Background As Bitmap
    Public Sub New(ByVal newDesktop As IntPtr, ByVal background As Bitmap)
        Me.NewDesktop = newDesktop
        Me.Background = background
    End Sub
End Class