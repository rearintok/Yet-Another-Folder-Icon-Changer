
Public Class Button

    Public Overrides Function GetPreferredSize(ByVal proposedSize As System.Drawing.Size) As System.Drawing.Size

        proposedSize = MyBase.GetPreferredSize(proposedSize)
        proposedSize.Width += 24
        If Image IsNot Nothing Then proposedSize.Width += Image.Width
        proposedSize.Width -= proposedSize.Width Mod 30
        proposedSize.Width = [If](proposedSize.Width < 75, 75, proposedSize.Width)
        proposedSize.Height = [If](proposedSize.Height < 30, 30, proposedSize.Height)
        Return proposedSize

    End Function
End Class



