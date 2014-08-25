Imports System.Windows.Forms.VisualStyles
Imports System.Drawing.Drawing2D
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomButton
    Inherits Windows.Forms.Button

    Const SPLIT_SECTION_WIDTH As Integer = 18
    Shared ReadOnly BorderSize As Integer = SystemInformation.Border3DSize.Width * 2
    Private skipNextOpen As Boolean
    Private dropDownRectangle As Rectangle
    Private m_showSplit As Boolean

    Private isSplitMenuVisible As Boolean


    Private m_SplitMenuStrip As ContextMenuStrip
    Private m_SplitMenu As ContextMenu

    Private state As PushButtonState = PushButtonState.Normal
    Private textFormatFlags As TextFormatFlags = textFormatFlags.[Default]

    Public Sub New()
        Me.AutoSize = True
        Me.Font = New Font("Tahoma", 8)
    End Sub
    
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rect As New Rectangle(0, 0, Width - 1, Height - 1)
        Dim g As Graphics = e.Graphics

        Using gp As New GraphicsPath
            RoundedRectanglePath(gp, rect.X, rect.Y, rect.Width, rect.Height, 2)

            If state = PushButtonState.Pressed Then
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
            ElseIf state = PushButtonState.Normal Then
                'Background
                e.Graphics.Clip = New Region(gp)
                Using baseBackground As New SolidBrush(Color.FromArgb(232, 232, 232))
                    e.Graphics.FillRectangle(baseBackground, New Rectangle(0, 0, rect.Width, rect.Height))
                End Using
                'Pop effects
                Using Brush As New SolidBrush(Color.FromArgb(125, Color.White))
                    e.Graphics.FillRectangle(Brush, rect.X, rect.Y, rect.Width, CInt(rect.Height / 2))
                End Using
                e.Graphics.ResetClip()
                'Border
                Using p As New Pen(Color.FromArgb(200, 203, 206))
                    e.Graphics.DrawPath(p, gp)
                End Using

            Else
                DrawSelection(e.Graphics, rect)
            End If
        End Using

        'paint the image and text in the "button" part of the splitButton
        PaintTextandImage(g, New Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height))
    End Sub

    Private Sub PaintTextandImage(g As Graphics, sBounds As Rectangle)
        ' Figure out where our text and image should go
        Dim text_rectangle As Rectangle
        Dim image_rectangle As Rectangle

        CalculateButtonTextAndImageLayout(sBounds, text_rectangle, image_rectangle)

        'draw the image
        If Image IsNot Nothing Then
            If Enabled Then
                g.DrawImage(Image, image_rectangle.X, image_rectangle.Y, Image.Width, Image.Height)
            Else
                ControlPaint.DrawImageDisabled(g, Image, image_rectangle.X, image_rectangle.Y, BackColor)
            End If
        End If

        ' If we dont' use mnemonic, set formatFlag to NoPrefix as this will show ampersand.
        If Not UseMnemonic Then
            textFormatFlags = textFormatFlags Or textFormatFlags.NoPrefix
        ElseIf Not ShowKeyboardCues Then
            textFormatFlags = textFormatFlags Or textFormatFlags.HidePrefix
        End If

        'draw the text
        If Not String.IsNullOrEmpty(Text) Then
            If Enabled Then
                TextRenderer.DrawText(g, Text, Font, text_rectangle, ForeColor, textFormatFlags)
            Else
                ControlPaint.DrawStringDisabled(g, Text, Font, BackColor, text_rectangle, textFormatFlags)
            End If
        End If
    End Sub

    Private Sub PaintArrow(g As Graphics, dropDownRect As Rectangle)
        Dim middle As New Point(Convert.ToInt32(dropDownRect.Left + dropDownRect.Width \ 2), Convert.ToInt32(dropDownRect.Top + dropDownRect.Height \ 2))

        'if the width is odd - favor pushing it over one pixel right.
        middle.X += (dropDownRect.Width Mod 2)

        Dim arrow As Point() = {New Point(middle.X - 2, middle.Y - 1), New Point(middle.X + 3, middle.Y - 1), New Point(middle.X, middle.Y + 2)}

        If Enabled Then
            g.FillPolygon(SystemBrushes.ControlText, arrow)
        Else
            g.FillPolygon(SystemBrushes.ButtonShadow, arrow)
        End If
    End Sub

#Region "Button Layout Calculations"

    'The following layout functions were taken from Mono's Windows.Forms 
    'implementation, specifically "ThemeWin32Classic.cs", 
    'then modified to fit the context of this splitButton

    Private Sub CalculateButtonTextAndImageLayout(ByRef content_rect As Rectangle, ByRef textRectangle As Rectangle, ByRef imageRectangle As Rectangle)
        Dim text_size As Size = TextRenderer.MeasureText(Text, Font, content_rect.Size, textFormatFlags)
        Dim image_size As Size = If(Image Is Nothing, Size.Empty, Image.Size)

        textRectangle = Rectangle.Empty
        imageRectangle = Rectangle.Empty

        Select Case TextImageRelation
            Case TextImageRelation.Overlay
                ' Overlay is easy, text always goes here
                textRectangle = OverlayObjectRect(content_rect, text_size, TextAlign)
                ' Rectangle.Inflate(content_rect, -4, -4);
                'Offset on Windows 98 style when button is pressed
                If state = PushButtonState.Pressed AndAlso Not Application.RenderWithVisualStyles Then
                    textRectangle.Offset(1, 1)
                End If

                ' Image is dependent on ImageAlign
                If Image IsNot Nothing Then
                    imageRectangle = OverlayObjectRect(content_rect, image_size, ImageAlign)
                End If

                Exit Select
            Case TextImageRelation.ImageAboveText
                content_rect.Inflate(-4, -4)
                LayoutTextAboveOrBelowImage(content_rect, False, text_size, image_size, textRectangle, imageRectangle)
                Exit Select
            Case TextImageRelation.TextAboveImage
                content_rect.Inflate(-4, -4)
                LayoutTextAboveOrBelowImage(content_rect, True, text_size, image_size, textRectangle, imageRectangle)
                Exit Select
            Case TextImageRelation.ImageBeforeText
                content_rect.Inflate(-4, -4)
                LayoutTextBeforeOrAfterImage(content_rect, False, text_size, image_size, textRectangle, imageRectangle)
                Exit Select
            Case TextImageRelation.TextBeforeImage
                content_rect.Inflate(-4, -4)
                LayoutTextBeforeOrAfterImage(content_rect, True, text_size, image_size, textRectangle, imageRectangle)
                Exit Select
        End Select
    End Sub

    Private Shared Function OverlayObjectRect(ByRef container As Rectangle, ByRef sizeOfObject As Size, alignment As Drawing.ContentAlignment) As Rectangle
        Dim x As Integer, y As Integer

        Select Case alignment
            Case Drawing.ContentAlignment.TopLeft
                x = 4
                y = 4
                Exit Select
            Case Drawing.ContentAlignment.TopCenter
                x = (container.Width - sizeOfObject.Width) \ 2
                y = 4
                Exit Select
            Case Drawing.ContentAlignment.TopRight
                x = container.Width - sizeOfObject.Width - 4
                y = 4
                Exit Select
            Case Drawing.ContentAlignment.MiddleLeft
                x = 4
                y = (container.Height - sizeOfObject.Height) \ 2
                Exit Select
            Case Drawing.ContentAlignment.MiddleCenter
                x = (container.Width - sizeOfObject.Width) \ 2
                y = (container.Height - sizeOfObject.Height) \ 2
                Exit Select
            Case Drawing.ContentAlignment.MiddleRight
                x = container.Width - sizeOfObject.Width - 4
                y = (container.Height - sizeOfObject.Height) \ 2
                Exit Select
            Case Drawing.ContentAlignment.BottomLeft
                x = 4
                y = container.Height - sizeOfObject.Height - 4
                Exit Select
            Case Drawing.ContentAlignment.BottomCenter
                x = (container.Width - sizeOfObject.Width) \ 2
                y = container.Height - sizeOfObject.Height - 4
                Exit Select
            Case Drawing.ContentAlignment.BottomRight
                x = container.Width - sizeOfObject.Width - 4
                y = container.Height - sizeOfObject.Height - 4
                Exit Select
            Case Else
                x = 4
                y = 4
                Exit Select
        End Select

        Return New Rectangle(x, y, sizeOfObject.Width, sizeOfObject.Height)
    End Function

    Private Sub LayoutTextBeforeOrAfterImage(totalArea As Rectangle, textFirst As Boolean, textSize As Size, imageSize As Size, ByRef textRect As Rectangle, ByRef imageRect As Rectangle)
        Dim element_spacing As Integer = 0
        ' Spacing between the Text and the Image
        Dim total_width As Integer = textSize.Width + element_spacing + imageSize.Width

        If Not textFirst Then
            element_spacing += 2
        End If

        ' If the text is too big, chop it down to the size we have available to it
        If total_width > totalArea.Width Then
            textSize.Width = totalArea.Width - element_spacing - imageSize.Width
            total_width = totalArea.Width
        End If

        Dim excess_width As Integer = totalArea.Width - total_width
        Dim offset As Integer = 0

        Dim final_text_rect As Rectangle
        Dim final_image_rect As Rectangle

        Dim h_text As HorizontalAlignment = GetHorizontalAlignment(TextAlign)
        Dim h_image As HorizontalAlignment = GetHorizontalAlignment(ImageAlign)

        If h_image = HorizontalAlignment.Left Then
            offset = 0
        ElseIf h_image = HorizontalAlignment.Right AndAlso h_text = HorizontalAlignment.Right Then
            offset = excess_width
        ElseIf h_image = HorizontalAlignment.Center AndAlso (h_text = HorizontalAlignment.Left OrElse h_text = HorizontalAlignment.Center) Then
            offset += excess_width \ 3
        Else
            offset += 2 * (excess_width \ 3)
        End If

        If textFirst Then
            final_text_rect = New Rectangle(totalArea.Left + offset, AlignInRectangle(totalArea, textSize, TextAlign).Top, textSize.Width, textSize.Height)
            final_image_rect = New Rectangle(final_text_rect.Right + element_spacing, AlignInRectangle(totalArea, imageSize, ImageAlign).Top, imageSize.Width, imageSize.Height)
        Else
            final_image_rect = New Rectangle(totalArea.Left + offset, AlignInRectangle(totalArea, imageSize, ImageAlign).Top, imageSize.Width, imageSize.Height)
            final_text_rect = New Rectangle(final_image_rect.Right + element_spacing, AlignInRectangle(totalArea, textSize, TextAlign).Top, textSize.Width, textSize.Height)
        End If

        textRect = final_text_rect
        imageRect = final_image_rect
    End Sub

    Private Sub LayoutTextAboveOrBelowImage(totalArea As Rectangle, textFirst As Boolean, textSize As Size, imageSize As Size, ByRef textRect As Rectangle, ByRef imageRect As Rectangle)
        Dim element_spacing As Integer = 0
        ' Spacing between the Text and the Image
        Dim total_height As Integer = textSize.Height + element_spacing + imageSize.Height

        If textFirst Then
            element_spacing += 2
        End If

        If textSize.Width > totalArea.Width Then
            textSize.Width = totalArea.Width
        End If

        ' If the there isn't enough room and we're text first, cut out the image
        If total_height > totalArea.Height AndAlso textFirst Then
            imageSize = Size.Empty
            total_height = totalArea.Height
        End If

        Dim excess_height As Integer = totalArea.Height - total_height
        Dim offset As Integer = 0

        Dim final_text_rect As Rectangle
        Dim final_image_rect As Rectangle

        Dim v_text As VerticalAlignment = GetVerticalAlignment(TextAlign)
        Dim v_image As VerticalAlignment = GetVerticalAlignment(ImageAlign)

        If v_image = VerticalAlignment.Top Then
            offset = 0
        ElseIf v_image = VerticalAlignment.Bottom AndAlso v_text = VerticalAlignment.Bottom Then
            offset = excess_height
        ElseIf v_image = VerticalAlignment.Center AndAlso (v_text = VerticalAlignment.Top OrElse v_text = VerticalAlignment.Center) Then
            offset += excess_height \ 3
        Else
            offset += 2 * (excess_height \ 3)
        End If

        If textFirst Then
            final_text_rect = New Rectangle(AlignInRectangle(totalArea, textSize, TextAlign).Left, totalArea.Top + offset, textSize.Width, textSize.Height)
            final_image_rect = New Rectangle(AlignInRectangle(totalArea, imageSize, ImageAlign).Left, final_text_rect.Bottom + element_spacing, imageSize.Width, imageSize.Height)
        Else
            final_image_rect = New Rectangle(AlignInRectangle(totalArea, imageSize, ImageAlign).Left, totalArea.Top + offset, imageSize.Width, imageSize.Height)
            final_text_rect = New Rectangle(AlignInRectangle(totalArea, textSize, TextAlign).Left, final_image_rect.Bottom + element_spacing, textSize.Width, textSize.Height)

            If final_text_rect.Bottom > totalArea.Bottom Then
                final_text_rect.Y = totalArea.Top
            End If
        End If

        textRect = final_text_rect
        imageRect = final_image_rect
    End Sub

    Private Shared Function GetHorizontalAlignment(align As Drawing.ContentAlignment) As HorizontalAlignment
        Select Case align
            Case Drawing.ContentAlignment.BottomLeft, Drawing.ContentAlignment.MiddleLeft, Drawing.ContentAlignment.TopLeft
                Return HorizontalAlignment.Left
            Case Drawing.ContentAlignment.BottomCenter, Drawing.ContentAlignment.MiddleCenter, Drawing.ContentAlignment.TopCenter
                Return HorizontalAlignment.Center
            Case Drawing.ContentAlignment.BottomRight, Drawing.ContentAlignment.MiddleRight, Drawing.ContentAlignment.TopRight
                Return HorizontalAlignment.Right
        End Select

        Return HorizontalAlignment.Left
    End Function

    Private Shared Function GetVerticalAlignment(align As Drawing.ContentAlignment) As VerticalAlignment
        Select Case align
            Case Drawing.ContentAlignment.TopLeft, Drawing.ContentAlignment.TopCenter, Drawing.ContentAlignment.TopRight
                Return VerticalAlignment.Top
            Case Drawing.ContentAlignment.MiddleLeft, Drawing.ContentAlignment.MiddleCenter, Drawing.ContentAlignment.MiddleRight
                Return VerticalAlignment.Center
            Case Drawing.ContentAlignment.BottomLeft, Drawing.ContentAlignment.BottomCenter, Drawing.ContentAlignment.BottomRight
                Return VerticalAlignment.Bottom
        End Select

        Return VerticalAlignment.Top
    End Function

    Friend Shared Function AlignInRectangle(outer As Rectangle, inner As Size, align As Drawing.ContentAlignment) As Rectangle
        Dim x As Integer = 0
        Dim y As Integer = 0

        If align = Drawing.ContentAlignment.BottomLeft OrElse align = Drawing.ContentAlignment.MiddleLeft OrElse align = Drawing.ContentAlignment.TopLeft Then
            x = outer.X
        ElseIf align = Drawing.ContentAlignment.BottomCenter OrElse align = Drawing.ContentAlignment.MiddleCenter OrElse align = Drawing.ContentAlignment.TopCenter Then
            x = Math.Max(outer.X + ((outer.Width - inner.Width) \ 2), outer.Left)
        ElseIf align = Drawing.ContentAlignment.BottomRight OrElse align = Drawing.ContentAlignment.MiddleRight OrElse align = Drawing.ContentAlignment.TopRight Then
            x = outer.Right - inner.Width
        End If
        If align = Drawing.ContentAlignment.TopCenter OrElse align = Drawing.ContentAlignment.TopLeft OrElse align = Drawing.ContentAlignment.TopRight Then
            y = outer.Y
        ElseIf align = Drawing.ContentAlignment.MiddleCenter OrElse align = Drawing.ContentAlignment.MiddleLeft OrElse align = Drawing.ContentAlignment.MiddleRight Then
            y = outer.Y + (outer.Height - inner.Height) \ 2
        ElseIf align = Drawing.ContentAlignment.BottomCenter OrElse align = Drawing.ContentAlignment.BottomRight OrElse align = Drawing.ContentAlignment.BottomLeft Then
            y = outer.Bottom - inner.Height
        End If

        Return New Rectangle(x, y, Math.Min(inner.Width, outer.Width), Math.Min(inner.Height, outer.Height))
    End Function

#End Region

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

    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        If keyData.Equals(Keys.Down) AndAlso m_showSplit Then
            Return True
        End If

        Return MyBase.IsInputKey(keyData)
    End Function

    'Draw the button in the unpressed state. 
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        state = PushButtonState.Pressed
        Invalidate()
    End Sub

    'Draw the button in the hot state.  
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        state = PushButtonState.Hot
        Invalidate()
    End Sub

    'Draw the button in the unpressed state. 
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        state = PushButtonState.Normal
        Invalidate()
    End Sub

    'Draw the button hot if the mouse is released on the button. 
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
    End Sub

    'Detect when the cursor leaves the button area while it is pressed. 
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        'Detect when the left mouse button is down and    
        'the cursor has left the pressed button area.  
        If (e.Button And MouseButtons.Left) = MouseButtons.Left And Not _
               Me.ClientRectangle.Contains(e.Location) And _
               state = PushButtonState.Pressed Then
            OnMouseLeave(e)
        Else
            OnMouseEnter(e)
        End If
    End Sub

End Class
