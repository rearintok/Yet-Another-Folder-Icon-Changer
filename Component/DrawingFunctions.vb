﻿Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class DrawingFunctions

#Region "i00 Logo"

    '26x26 is the origional logo's canvas size :)
    Public Shared ReadOnly Property OrigLogoCanvasSize() As Size
        Get
            Return New Size(26, 26)
        End Get
    End Property

    Private Shared Function LogoRatio(ByVal xy As Single, ByVal rect As RectangleF, Optional ByVal x As Boolean = True) As Single
        If x Then
            'x
            Return (xy * (rect.Width / OrigLogoCanvasSize.Width)) + rect.X
        Else
            'y
            Return (xy * (rect.Height / OrigLogoCanvasSize.Height)) + rect.Y
        End If
    End Function

    Public Shared Sub DrawLogo(ByVal g As Graphics, ByVal Brush As Brush, ByVal Rect As RectangleF)
        'Dim Rect As New Rectangle(0, 0, 26, 26)
        Using p As New Pen(Brush, (4 * (Rect.Width / OrigLogoCanvasSize.Width)))
            g.DrawLine(p, LogoRatio(13, Rect), LogoRatio(4, Rect, False), LogoRatio(13, Rect), LogoRatio(8, Rect, False))
            g.DrawLine(p, LogoRatio(13, Rect), LogoRatio(10, Rect, False), LogoRatio(13, Rect), LogoRatio(23.5, Rect, False))
        End Using
        Dim RectOrigCanvas As New Rectangle(New Point(0, 0), OrigLogoCanvasSize)
        Using p As New GraphicsPath
            p.AddArc(8, 0, 5, 5, 90, 180)
            p.AddArc(RectOrigCanvas, -90, 135)
            p.AddArc(New RectangleF(3.3, 5, 21, 21), 45, -135)
            p.CloseFigure()
            Using m As New Matrix
                m.Translate(Rect.X, Rect.Y)
                m.Scale(Rect.Width / RectOrigCanvas.Width, Rect.Height / RectOrigCanvas.Height)
                p.Transform(m)
            End Using
            g.FillPath(Brush, p)

            Using m As New Matrix
                m.RotateAt(180, New PointF(Rect.X + (Rect.Width / 2), Rect.Y + (Rect.Height / 2)))
                p.Transform(m)
            End Using
            g.FillPath(Brush, p)

        End Using

    End Sub

#End Region

    Public Enum BestFitStyle
        Zoom
        Stretch
    End Enum

    Public Shared Function GetBestFitRect(ByVal rectFrame As RectangleF, ByVal rect As RectangleF, Optional ByVal BestFitStyle As BestFitStyle = BestFitStyle.Zoom) As RectangleF
        Dim origImageRatio = rect.Width / rect.Height
        Dim canvasRatio = rectFrame.Width / rectFrame.Height
        Dim DrawRect As RectangleF
        If (origImageRatio > canvasRatio AndAlso BestFitStyle = BestFitStyle.Stretch) OrElse (origImageRatio < canvasRatio AndAlso BestFitStyle = BestFitStyle.Zoom) Then
            DrawRect = New RectangleF(rectFrame.Left, rectFrame.Top, rectFrame.Width, rectFrame.Width * (1 / origImageRatio))
        Else
            DrawRect = New RectangleF(rectFrame.Left, rectFrame.Top, rectFrame.Height * origImageRatio, rectFrame.Height)
        End If
        DrawRect.X += ((rectFrame.Width - DrawRect.Width) / 2)
        DrawRect.Y += ((rectFrame.Height - DrawRect.Height) / 2)
        Return DrawRect
    End Function

#Region "Gray scale image"

    Private Shared Function draw_adjusted_image(ByVal img As Image, ByVal cm As ColorMatrix) As Boolean
        Try
            Dim bmp As New Bitmap(img) ' create a copy of the source image 
            Dim imgattr As New ImageAttributes()
            Dim rc As New Rectangle(0, 0, img.Width, img.Height)
            Using g As Graphics = Graphics.FromImage(img)
                imgattr.SetColorMatrix(cm)
                g.DrawImage(bmp, rc, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgattr)
            End Using
            Return True
        Catch
            Return False
        End Try

    End Function

    Public Shared Function Grayscale(ByVal img As Image) As Boolean
        Dim cm As New ColorMatrix(New Single()() _
                               {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                                New Single() {0.587, 0.587, 0.587, 0, 0}, _
                                New Single() {0.114, 0.114, 0.114, 0, 0}, _
                                New Single() {0, 0, 0, 1, 0}, _
                                New Single() {0, 0, 0, 0, 1}})

        Return draw_adjusted_image(img, cm)

    End Function

#End Region

    Public Shared Sub AlphaImage(ByVal g As Graphics, ByVal b As Bitmap, ByVal Rect As Rectangle, Optional ByVal Alpha As Byte = 127)
        Dim cm As New System.Drawing.Imaging.ColorMatrix()
        cm.Matrix33 = CSng(Alpha / 255)
        Using ia As New System.Drawing.Imaging.ImageAttributes
            ia.SetColorMatrix(cm)
            g.DrawImage(b, Rect, 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ia)
        End Using
    End Sub


    Public Shared Sub DrawString(ByVal g As Graphics, ByVal s As String, ByVal font As System.Drawing.Font, ByVal brush As System.Drawing.Brush, ByVal x As Single, ByVal y As Single, Optional ByVal Ratio As Single = 1)
        Using gp = GetStringPath(s, font, x, y, Ratio, g)
            g.FillPath(brush, gp)
        End Using
    End Sub

    Public Shared Function GetStringPath(ByVal s As String, ByVal font As System.Drawing.Font, ByVal x As Single, ByVal y As Single, Optional ByVal Ratio As Single = 1, Optional ByVal g As Graphics = Nothing) As GraphicsPath
        Dim FontSize As SizeF
        If g Is Nothing Then
            Using b As New Bitmap(1, 1)
                Using g2 = Graphics.FromImage(b)
                    FontSize = g2.MeasureString(s, font, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
                End Using
            End Using
        Else
            FontSize = g.MeasureString(s, font, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
        End If
        GetStringPath = New GraphicsPath
        GetStringPath.AddString(s, font.FontFamily, font.Style, font.Size, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
        Dim scale As Single = FontSize.Width / (GetStringPath.GetBounds.Right + GetStringPath.GetBounds.Left)
        Using m As New Matrix
            m.Translate(x, y, MatrixOrder.Append)
            scale = scale * Ratio
            m.Scale(scale, scale, MatrixOrder.Prepend)
            GetStringPath.Transform(m)
        End Using
    End Function

    Public Shared Sub DrawElipseText(ByVal g As Graphics, ByVal RequiredLocation As PointF, ByVal Text As String, ByVal font As Font, ByVal requiredWidth As Integer, ByVal fontColor As Color)
        Dim StringSize As SizeF = g.MeasureString(Text, font)
        If StringSize.Width > requiredWidth Then

            Dim ElipseWidth As Single = g.MeasureString("...", font).Width
            Dim TweenCurrentRectWithFont As New RectangleF(RequiredLocation.X, RequiredLocation.Y, StringSize.Width, StringSize.Height)

            Dim lgb As New LinearGradientBrush(TweenCurrentRectWithFont, Color.Magenta, Color.Magenta, LinearGradientMode.Horizontal)
            Dim InterpolationColors As New ColorBlend(3)
            Dim ElipseGradRatio As Single = ElipseWidth / StringSize.Width
            Dim ShowTextGradRatio As Single = requiredWidth / StringSize.Width
            Dim FadeStartRatio As Single = ShowTextGradRatio - (ElipseGradRatio * 2)
            If FadeStartRatio < 0 Then FadeStartRatio = 0
            InterpolationColors.Positions = New Single() {0, FadeStartRatio, ShowTextGradRatio, 1}
            InterpolationColors.Colors = New Color() {fontColor, AlphaColor(fontColor, 191), Color.Transparent, Color.Transparent}

            lgb.InterpolationColors = InterpolationColors

            DrawString(g, Text, font, lgb, RequiredLocation.X, RequiredLocation.Y)
            DrawString(g, "...", font, New SolidBrush(AlphaColor(fontColor, 191)), (RequiredLocation.X + requiredWidth) - ElipseWidth, RequiredLocation.Y)

        Else

            Dim lgb As New LinearGradientBrush(New RectangleF(RequiredLocation.X, RequiredLocation.Y, RequiredLocation.X + requiredWidth, 1), fontColor, AlphaColor(fontColor, 191), LinearGradientMode.Horizontal)

            DrawString(g, Text, font, lgb, RequiredLocation.X, RequiredLocation.Y)

        End If
    End Sub

    Public Shared Function AlphaColor(ByVal theColor As Color, Optional ByVal AlphaLevel As Byte = 255) As Color
        AlphaColor = Color.FromArgb(AlphaLevel, theColor.R, theColor.G, theColor.B)
    End Function

    Public Shared Function BlendColor(ByVal FromColor As Color, ByVal ToColor As Color, Optional ByVal alpha As Integer = 127) As Color
        BlendColor = Color.FromArgb(CInt(((FromColor.A * alpha) / 255) + ((ToColor.A * (255 - alpha)) / 255)), _
                                    CInt(((FromColor.R * alpha) / 255) + ((ToColor.R * (255 - alpha)) / 255)), _
                                    CInt(((FromColor.G * alpha) / 255) + ((ToColor.G * (255 - alpha)) / 255)), _
                                    CInt(((FromColor.B * alpha) / 255) + ((ToColor.B * (255 - alpha)) / 255)))
    End Function

    Public Shared Function StringToPath(ByVal g As Graphics, ByVal s As String, ByVal font As System.Drawing.Font) As GraphicsPath
        Dim FontSize As SizeF = g.MeasureString(s, font, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
        Dim gp As New GraphicsPath
        gp.AddString(s, font.FontFamily, font.Style, font.Size, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
        Dim scale As Single = FontSize.Width / (gp.GetBounds.Right + gp.GetBounds.Left)
        Return gp
    End Function

    Public Class Text

        Public Enum TextRenderMode
            Auto
            Windows
            i00
        End Enum

        'sets a new size for a given font
        Public Shared Function FontSetNewSize(ByVal theFont As Font, ByVal NewSize As Single) As Font
            FontSetNewSize = New Font(theFont.Name, NewSize, theFont.Style)
        End Function

        'allows you to specify width and/or height bounds for a given string and it will return the maximum 
        'font size to fit within that region
        Public Shared Function DetermineFontSizeForBounds(ByVal Text As String, ByVal theFont As Drawing.Font, Optional ByVal RequiredWidth As Single = 0, Optional ByVal RequiredHeight As Single = 0, Optional ByVal UseTextRenderer As Boolean = False) As Single
            Using b As New Bitmap(1, 1)
                Using g As Graphics = Graphics.FromImage(b)
                    If Text = "" Then
                        Return 8
                    End If

                    If RequiredWidth <> 0 Then
                        DetermineFontSizeForBounds = 8
                        If UseTextRenderer Then
                            Do While TextRenderer.MeasureText(Text, FontSetNewSize(theFont, DetermineFontSizeForBounds)).Width < RequiredWidth
                                DetermineFontSizeForBounds += 1
                            Loop
                        Else
                            Do While g.MeasureString(Text, FontSetNewSize(theFont, DetermineFontSizeForBounds)).Width < RequiredWidth
                                DetermineFontSizeForBounds += 1
                            Loop
                        End If
                        DetermineFontSizeForBounds = DetermineFontSizeForBounds - 1 'because we are one more than the size we want
                        If RequiredHeight = 0 Then
                            'just use the width
                            Return DetermineFontSizeForBounds
                        End If
                    End If

                    Dim FontSizeHeight As Single = 8
                    If RequiredHeight <> 0 Then
                        If UseTextRenderer Then
                            Do While TextRenderer.MeasureText(Text, FontSetNewSize(theFont, FontSizeHeight)).Height < RequiredHeight
                                FontSizeHeight += 1
                            Loop
                        Else
                            Do While g.MeasureString(Text, FontSetNewSize(theFont, FontSizeHeight)).Height < RequiredHeight
                                FontSizeHeight += 1
                            Loop
                        End If
                        FontSizeHeight -= 1 'because we are one more than the size we want
                        If RequiredWidth = 0 Then
                            'just use the height
                            Return FontSizeHeight
                        End If
                    End If

                    If RequiredWidth <> 0 AndAlso RequiredHeight <> 0 Then
                        'we have both a width and height so lets pick the smallest
                        If FontSizeHeight < DetermineFontSizeForBounds Then
                            Return FontSizeHeight
                        Else
                            Return DetermineFontSizeForBounds
                        End If
                    End If
                End Using
            End Using
        End Function

        Public Shared Sub DrawString(ByVal g As Graphics, ByVal s As String, ByVal font As System.Drawing.Font, ByVal brush As System.Drawing.Brush, ByVal x As Single, ByVal y As Single, Optional ByVal TextRenderMode As TextRenderMode = TextRenderMode.Auto)
            If Trim(s) = "" Then Exit Sub
            If (TextRenderMode = Text.TextRenderMode.Windows OrElse (TextRenderMode = Text.TextRenderMode.Auto AndAlso Screen.PrimaryScreen.BitsPerPixel < 24)) AndAlso TypeOf brush Is SolidBrush Then
                'also only works for solid brushes
                Dim ForeColor As Color = Color.FromKnownColor(KnownColor.ControlText)
                If TypeOf brush Is SolidBrush Then
                    ForeColor = CType(brush, SolidBrush).Color
                End If
                'this adds the transform location as the text renderer does not take this into consideration :S
                TextRenderer.DrawText(g, s, font, New Rectangle(CInt(x + g.Transform.OffsetX), CInt(y + g.Transform.OffsetY), Integer.MaxValue, Integer.MaxValue), ForeColor, TextFormatFlags.Default)
            Else
                Dim FontSize As SizeF = g.MeasureString(s, font, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
                Using gp As New GraphicsPath

                    gp.AddString(s, font.FontFamily, font.Style, font.Size, New PointF(0, 0), System.Drawing.StringFormat.GenericDefault)
                    Dim scale As Single = FontSize.Width / (gp.GetBounds.Right + gp.GetBounds.Left)
                    Using m As New Matrix
                        m.Translate(x, y, MatrixOrder.Append)
                        m.Scale(scale, scale, MatrixOrder.Prepend)
                        gp.Transform(m)
                    End Using
                    Try
                        g.FillPath(brush, gp)
                    Catch ex As Exception
                        Debug.Print("error modDrawing.DrawString")
                    End Try
                End Using
            End If
        End Sub

    End Class

End Class
