Imports System.Drawing.Drawing2D

Friend Class MyRenderer
    Inherits ToolStripProfessionalRenderer

    Private SmallArrowImage As Bitmap = BitmapFromBase64("iVBORw0KGgoAAAANSUhEUgAAAAUAAAAICAYAAAAx8TU7AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAABFSURBVBhXY2BgYNAFYl8oDaQgwPc/EKBL+P779+8/CCNL+P758+c/DEMlGHxfvnz5H4bhgo8ePfoPwija79y5g2ERhpMATx8zcVrCPmoAAAAASUVORK5CYII=")
    Private SmallCheckImage As Bitmap = BitmapFromBase64("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAACCSURBVDhPzZMxCsAgDEU9Tc/hzb2H4ODg4B3U3wY6BJPQQIc28KYfnho1hD/VcW0mOqFeURHOuheRgrUWPJiCOScI6xhbLnfAG5BC4pD0UTDGAEHNmoDn6hB77yAsAc9VQWsNhCXguSqotYKwhrjlcoilFHgwrzHnDA+W4PVT/uZfniJNKgx621dNAAAAAElFTkSuQmC=")

    'Base64 -> Bitmap
    Private Function BitmapFromBase64(ByVal base64 As String) As Bitmap
        Dim oBitmap As System.Drawing.Bitmap
        Using memory As New System.IO.MemoryStream(Convert.FromBase64String(base64))
            oBitmap = New System.Drawing.Bitmap(memory)
        End Using
        Return oBitmap
    End Function

    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBackground(e)

        If e.ToolStrip.IsDropDown Then
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.AffectedBounds)
        Else
            'Background
            Using Brush As New SolidBrush(Color.FromArgb(232, 232, 232))
                e.Graphics.FillRectangle(Brush, e.AffectedBounds)
            End Using

            'Pop effects
            Using Brush As New SolidBrush(Color.FromArgb(125, Color.White))
                e.Graphics.FillRectangle(Brush, e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width, CInt(e.AffectedBounds.Height / 2))
            End Using

            'Bottom line
            Using p As New Pen(Color.FromArgb(200, 200, 200))
                e.Graphics.DrawLine(p, e.AffectedBounds.X, e.AffectedBounds.Bottom - 1, e.AffectedBounds.Right, e.AffectedBounds.Bottom - 1)
            End Using

            'Top line
            Using p As New Pen(Color.FromArgb(200, 200, 200))
                e.Graphics.DrawLine(p, e.AffectedBounds.X, e.AffectedBounds.Top, e.AffectedBounds.Right, e.AffectedBounds.Top)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        If e.ToolStrip.Parent Is Nothing Then

            'Background
            Dim borderRect As New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
            Using p As New Pen(Color.FromArgb(155, 167, 183))
                e.Graphics.DrawRectangle(p, borderRect)
            End Using

            'Border
            Using b As New SolidBrush(Color.FromArgb(233, 236, 238))
                e.Graphics.FillRectangle(b, e.ConnectedArea)
            End Using
        End If
    End Sub


    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)

        If e.Item.Enabled Then

            If e.Item.Selected Then
                'Menu item hovering
                If Not e.Item.IsOnDropDown Then
                    Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
                    DrawSelection(e.Graphics, rect)
                Else
                    Dim rect As New Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1)
                    DrawSelection(e.Graphics, rect)
                End If
            End If

            If CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso Not e.Item.IsOnDropDown Then

                Dim borderRect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height)

                ' Background
                Dim bgRect As New Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2)
                Using b As New SolidBrush(Color.FromArgb(233, 236, 238))
                    e.Graphics.FillRectangle(b, bgRect)
                End Using

                ' Border
                Using p As New Pen(Color.FromArgb(155, 167, 183))
                    Using gp As New GraphicsPath
                        RoundedRectanglePath(gp, borderRect.X, borderRect.Y, borderRect.Width, borderRect.Height, 2)

                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                        e.Graphics.DrawPath(p, gp)
                        e.Graphics.SmoothingMode = SmoothingMode.Default

                    End Using
                End Using
            End If
        End If

    End Sub

    Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
        e.Graphics.DrawImage(SmallCheckImage, New Point(5, 3))
    End Sub

    Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
        '  e.Graphics.DrawImage(SmallArrowImage, New Point(e.ArrowRectangle.Location.X + 5, e.ArrowRectangle.Y + 6))
        e.ArrowColor = Color.Black
        MyBase.OnRenderArrow(e)
    End Sub

    Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        MyBase.OnRenderImageMargin(e)

        'background
        Dim bgRect As New Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1)
        Using b As New SolidBrush(Color.WhiteSmoke)
            e.Graphics.FillRectangle(b, bgRect)
        End Using

        'Image margin
        Using b As New SolidBrush(Color.FromArgb(233, 236, 238))
            e.Graphics.FillRectangle(b, e.AffectedBounds)
        End Using
    End Sub


    Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)

        If e.Item.Enabled Then
            If e.Item.Pressed Then
                'Button pressed
                Using gp As New GraphicsPath
                    RoundedRectanglePath(gp, rect.X, rect.Y, rect.Width, rect.Height, 2)

                    'Background
                    e.Graphics.Clip = New Region(gp)
                    Using baseBackground As New SolidBrush(Color.FromArgb(230, 233, 236))
                        e.Graphics.FillRectangle(baseBackground, New Rectangle(0, 0, rect.Width, rect.Height))
                    End Using
                    e.Graphics.ResetClip()

                    'Border
                    Using p As New Pen(Color.FromArgb(200, 203, 206))
                        e.Graphics.DrawPath(p, gp)
                    End Using

                End Using

            ElseIf e.Item.Selected Then
                'Button hovered
                DrawSelection(e.Graphics, rect)
            End If
        End If
    End Sub

    Private Sub DrawSelection(ByVal g As Graphics, ByVal rect As Rectangle)
        Dim topRect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 1, CInt((rect.Height - 1) / 2))
        Dim bottomRect As New Rectangle(topRect.X, topRect.Bottom, topRect.Width, rect.Height - 1 - topRect.Height)

        ' Top
        Using b As New LinearGradientBrush(topRect, Color.FromArgb(255, 249, 218), Color.FromArgb(255, 238, 177), LinearGradientMode.Vertical)
            g.FillRectangle(b, topRect)
        End Using

        ' Bottom
        Using b As New LinearGradientBrush(bottomRect, Color.FromArgb(255, 214, 107), Color.FromArgb(255, 224, 135), LinearGradientMode.Vertical)
            g.FillRectangle(b, bottomRect)
        End Using

        ' Border Inside
        Using b As New LinearGradientBrush(bottomRect, Color.FromArgb(255, 255, 249), Color.FromArgb(255, 247, 185), LinearGradientMode.Vertical)
            Using p As New Pen(b)
                Using gp As New GraphicsPath
                    RoundedRectanglePath(gp, rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2, 2)

                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.DrawPath(p, gp)
                    g.SmoothingMode = SmoothingMode.Default

                End Using
            End Using
        End Using

        ' Border
        Using b As New LinearGradientBrush(bottomRect, Color.FromArgb(216, 202, 149), Color.FromArgb(215, 201, 148), LinearGradientMode.Vertical)
            Using p As New Pen(b)
                Using gp As New GraphicsPath
                    RoundedRectanglePath(gp, rect.X, rect.Y, rect.Width, rect.Height, 2)

                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.DrawPath(p, gp)
                    g.SmoothingMode = SmoothingMode.Default

                End Using
            End Using
        End Using

    End Sub

    Private Sub RoundedRectanglePath(ByRef gp As GraphicsPath, ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        gp.AddLine(x + radius, y, x + width - (radius * 2), y)
        gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
        gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
        gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
        gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
        gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
        gp.AddLine(x, y + height - (radius * 2), x, y + radius)
        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        gp.CloseFigure()
    End Sub

End Class
