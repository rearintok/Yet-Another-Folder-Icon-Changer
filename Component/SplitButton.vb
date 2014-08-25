Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles


'Get the latest version of SplitButton at: http://wyday.com/splitbutton/

Public Class SplitButton
    Inherits Button
    Private _state As PushButtonState


    Const SPLIT_SECTION_WIDTH As Integer = 18

    Shared ReadOnly BorderSize As Integer = SystemInformation.Border3DSize.Width * 2
    Private skipNextOpen As Boolean
    Private dropDownRectangle As Rectangle
    Private m_showSplit As Boolean

    Private isSplitMenuVisible As Boolean


    Private m_SplitMenuStrip As ContextMenuStrip
    Private m_SplitMenu As ContextMenu

    Private textFormatFlags As TextFormatFlags = textFormatFlags.[Default]

    Public Sub New()
        AutoSize = True
    End Sub

#Region "Properties"

    '<Browsable(False)> _
    Public Overrides Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return SplitMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            SplitMenuStrip = value
        End Set
    End Property

    '<DefaultValue(Nothing)> _
    Public Property SplitMenu() As ContextMenu
        Get
            Return m_SplitMenu
        End Get
        Set(ByVal value As ContextMenu)
            'remove the event handlers for the old SplitMenu
            If m_SplitMenu IsNot Nothing Then
                RemoveHandler m_SplitMenu.Popup, AddressOf SplitMenu_Popup
            End If

            'add the event handlers for the new SplitMenu
            If value IsNot Nothing Then
                ShowSplit = True
                AddHandler value.Popup, AddressOf SplitMenu_Popup
            Else
                ShowSplit = False
            End If

            m_SplitMenu = value
        End Set
    End Property

    '<DefaultValue(Nothing)> _
    Public Property SplitMenuStrip() As ContextMenuStrip
        Get
            Return m_SplitMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            'remove the event handlers for the old SplitMenuStrip
            If m_SplitMenuStrip IsNot Nothing Then
                RemoveHandler m_SplitMenuStrip.Closing, AddressOf SplitMenuStrip_Closing
                RemoveHandler m_SplitMenuStrip.Opening, AddressOf SplitMenuStrip_Opening
            End If

            'add the event handlers for the new SplitMenuStrip
            If value IsNot Nothing Then
                ShowSplit = True
                AddHandler value.Closing, AddressOf SplitMenuStrip_Closing
                AddHandler value.Opening, AddressOf SplitMenuStrip_Opening
            Else
                ShowSplit = False
            End If


            m_SplitMenuStrip = value
        End Set
    End Property

    <DefaultValue(False)> _
    Public WriteOnly Property ShowSplit() As Boolean
        Set(value As Boolean)
            If value <> m_showSplit Then
                m_showSplit = value
                Invalidate()

                If Parent IsNot Nothing Then
                    Parent.PerformLayout()
                End If
            End If
        End Set
    End Property

    Private Property State() As PushButtonState
        Get
            Return _state
        End Get
        Set(value As PushButtonState)
            If Not _state.Equals(value) Then
                _state = value
                Invalidate()
            End If
        End Set
    End Property

#End Region

    Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
        If keyData.Equals(Keys.Down) AndAlso m_showSplit Then
            Return True
        End If

        Return MyBase.IsInputKey(keyData)
    End Function

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        If Not m_showSplit Then
            MyBase.OnGotFocus(e)
            Return
        End If

        If Not State.Equals(PushButtonState.Pressed) AndAlso Not State.Equals(PushButtonState.Disabled) Then
            State = PushButtonState.[Default]
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(kevent As KeyEventArgs)
        If m_showSplit Then
            If kevent.KeyCode.Equals(Keys.Down) AndAlso Not isSplitMenuVisible Then
                ShowContextMenuStrip()

            ElseIf kevent.KeyCode.Equals(Keys.Space) AndAlso kevent.Modifiers = Keys.None Then
                State = PushButtonState.Pressed
            End If
        End If

        MyBase.OnKeyDown(kevent)
    End Sub

    Protected Overrides Sub OnKeyUp(kevent As KeyEventArgs)
        If kevent.KeyCode.Equals(Keys.Space) Then
            If MouseButtons = MouseButtons.None Then
                State = PushButtonState.Normal
            End If
        ElseIf kevent.KeyCode.Equals(Keys.Apps) Then
            If MouseButtons = MouseButtons.None AndAlso Not isSplitMenuVisible Then
                ShowContextMenuStrip()
            End If
        End If

        MyBase.OnKeyUp(kevent)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        State = If(Enabled, PushButtonState.Normal, PushButtonState.Disabled)

        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        If Not m_showSplit Then
            MyBase.OnLostFocus(e)
            Return
        End If

        If Not State.Equals(PushButtonState.Pressed) AndAlso Not State.Equals(PushButtonState.Disabled) Then
            State = PushButtonState.Normal
        End If
    End Sub

    Private isMouseEntered As Boolean

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        If Not m_showSplit Then
            MyBase.OnMouseEnter(e)
            Return
        End If

        isMouseEntered = True

        If Not State.Equals(PushButtonState.Pressed) AndAlso Not State.Equals(PushButtonState.Disabled) Then
            State = PushButtonState.Hot
        End If

    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        If Not m_showSplit Then
            MyBase.OnMouseLeave(e)
            Return
        End If

        isMouseEntered = False

        If Not State.Equals(PushButtonState.Pressed) AndAlso Not State.Equals(PushButtonState.Disabled) Then
            State = If(Focused, PushButtonState.[Default], PushButtonState.Normal)
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If Not m_showSplit Then
            MyBase.OnMouseDown(e)
            Return
        End If

        'handle ContextMenu re-clicking the drop-down region to close the menu
        If m_SplitMenu IsNot Nothing AndAlso e.Button = MouseButtons.Left AndAlso Not isMouseEntered Then
            skipNextOpen = True
        End If

        If dropDownRectangle.Contains(e.Location) AndAlso Not isSplitMenuVisible AndAlso e.Button = MouseButtons.Left Then
            ShowContextMenuStrip()
        Else
            State = PushButtonState.Pressed
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        If Not m_showSplit Then
            MyBase.OnMouseUp(mevent)
            Return
        End If

        ' if the right button was released inside the button
        If mevent.Button = MouseButtons.Right AndAlso ClientRectangle.Contains(mevent.Location) AndAlso Not isSplitMenuVisible Then
            ShowContextMenuStrip()
        ElseIf m_SplitMenuStrip Is Nothing AndAlso m_SplitMenu Is Nothing OrElse Not isSplitMenuVisible Then
            SetButtonDrawState()

            If ClientRectangle.Contains(mevent.Location) AndAlso Not dropDownRectangle.Contains(mevent.Location) Then
                OnClick(New EventArgs())
            End If
        End If
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        If Not m_showSplit Then
            Return
        End If

        Dim g As Graphics = pevent.Graphics
        Dim sBounds As Rectangle = ClientRectangle

        ' draw the button background as according to the current state.
        If State <> PushButtonState.Pressed AndAlso IsDefault AndAlso Not Application.RenderWithVisualStyles Then
            Dim backgroundBounds As Rectangle = sBounds
            backgroundBounds.Inflate(-1, -1)
            ButtonRenderer.DrawButton(g, backgroundBounds, State)

            ' button renderer doesnt draw the black frame when themes are off
            g.DrawRectangle(SystemPens.WindowFrame, 0, 0, sBounds.Width - 1, sBounds.Height - 1)
        Else
            ButtonRenderer.DrawButton(g, sBounds, State)
        End If

        ' calculate the current dropdown rectangle.
        dropDownRectangle = New Rectangle(sBounds.Right - SPLIT_SECTION_WIDTH, 0, SPLIT_SECTION_WIDTH, sBounds.Height)

        Dim internalBorder As Integer = BorderSize
        Dim focusRect As New Rectangle(internalBorder - 1, internalBorder - 1, sBounds.Width - dropDownRectangle.Width - internalBorder, sBounds.Height - (internalBorder * 2) + 2)

        Dim drawSplitLine As Boolean = (State = PushButtonState.Hot OrElse State = PushButtonState.Pressed OrElse Not Application.RenderWithVisualStyles)


        If RightToLeft = RightToLeft.Yes Then
            dropDownRectangle.X = sBounds.Left + 1
            focusRect.X = dropDownRectangle.Right

            If drawSplitLine Then
                ' draw two lines at the edge of the dropdown button
                g.DrawLine(SystemPens.ButtonShadow, sBounds.Left + SPLIT_SECTION_WIDTH, BorderSize, sBounds.Left + SPLIT_SECTION_WIDTH, sBounds.Bottom - BorderSize)
                g.DrawLine(SystemPens.ButtonFace, sBounds.Left + SPLIT_SECTION_WIDTH + 1, BorderSize, sBounds.Left + SPLIT_SECTION_WIDTH + 1, sBounds.Bottom - BorderSize)
            End If
        Else
            If drawSplitLine Then
                ' draw two lines at the edge of the dropdown button
                g.DrawLine(SystemPens.ButtonShadow, sBounds.Right - SPLIT_SECTION_WIDTH, BorderSize, sBounds.Right - SPLIT_SECTION_WIDTH, sBounds.Bottom - BorderSize)
                g.DrawLine(SystemPens.ButtonFace, sBounds.Right - SPLIT_SECTION_WIDTH - 1, BorderSize, sBounds.Right - SPLIT_SECTION_WIDTH - 1, sBounds.Bottom - BorderSize)
            End If
        End If

        ' Draw an arrow in the correct location
        PaintArrow(g, dropDownRectangle)

        'paint the image and text in the "button" part of the splitButton
        PaintTextandImage(g, New Rectangle(0, 0, ClientRectangle.Width - SPLIT_SECTION_WIDTH, ClientRectangle.Height))

        ' draw the focus rectangle.
        If State <> PushButtonState.Pressed AndAlso Focused AndAlso ShowFocusCues Then
            ControlPaint.DrawFocusRectangle(g, focusRect)
        End If
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

    Public Overrides Function GetPreferredSize(proposedSize As Size) As Size
        Dim preferSize As Size = MyBase.GetPreferredSize(proposedSize)

        'autosize correctly for splitbuttons
        If m_showSplit Then
            If AutoSize Then
                Return CalculateButtonAutoSize()
            End If

            If Not String.IsNullOrEmpty(Text) AndAlso TextRenderer.MeasureText(Text, Font).Width + SPLIT_SECTION_WIDTH > preferSize.Width Then
                Return preferSize + New Size(SPLIT_SECTION_WIDTH + BorderSize * 2, 0)
            End If
        End If

        Return preferSize
    End Function

    Private Function CalculateButtonAutoSize() As Size
        Dim ret_size As Size = Size.Empty
        Dim text_size As Size = TextRenderer.MeasureText(Text, Font)
        Dim image_size As Size = If(Image Is Nothing, Size.Empty, Image.Size)

        ' Pad the text size
        If Text.Length <> 0 Then
            text_size.Height += 4
            text_size.Width += 4
        End If

        Select Case TextImageRelation
            Case TextImageRelation.Overlay
                ret_size.Height = Math.Max(If(Text.Length = 0, 0, text_size.Height), image_size.Height)
                ret_size.Width = Math.Max(text_size.Width, image_size.Width)
                Exit Select
            Case TextImageRelation.ImageAboveText, TextImageRelation.TextAboveImage
                ret_size.Height = text_size.Height + image_size.Height
                ret_size.Width = Math.Max(text_size.Width, image_size.Width)
                Exit Select
            Case TextImageRelation.ImageBeforeText, TextImageRelation.TextBeforeImage
                ret_size.Height = Math.Max(text_size.Height, image_size.Height)
                ret_size.Width = text_size.Width + image_size.Width
                Exit Select
        End Select

        ' Pad the result
        ret_size.Height += (Padding.Vertical + 6)
        ret_size.Width += (Padding.Horizontal + 6)

        'pad the splitButton arrow region
        If m_showSplit Then
            ret_size.Width += SPLIT_SECTION_WIDTH
        End If

        Return ret_size
    End Function

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
                If _state = PushButtonState.Pressed AndAlso Not Application.RenderWithVisualStyles Then
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


    Private Sub ShowContextMenuStrip()
        If skipNextOpen Then
            ' we were called because we're closing the context menu strip
            ' when clicking the dropdown button.
            skipNextOpen = False
            Return
        End If

        State = PushButtonState.Pressed

        If m_SplitMenu IsNot Nothing Then
            m_SplitMenu.Show(Me, New Point(0, Height))
        ElseIf m_SplitMenuStrip IsNot Nothing Then
            m_SplitMenuStrip.Show(Me, New Point(0, Height), ToolStripDropDownDirection.BelowRight)
        End If
    End Sub

    Private Sub SplitMenuStrip_Opening(sender As Object, e As CancelEventArgs)
        isSplitMenuVisible = True
    End Sub

    Private Sub SplitMenuStrip_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs)
        isSplitMenuVisible = False

        SetButtonDrawState()

        If e.CloseReason = ToolStripDropDownCloseReason.AppClicked Then
            skipNextOpen = (dropDownRectangle.Contains(PointToClient(Cursor.Position))) AndAlso MouseButtons = MouseButtons.Left
        End If
    End Sub


    Private Sub SplitMenu_Popup(sender As Object, e As EventArgs)
        isSplitMenuVisible = True
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        '0x0212 == WM_EXITMENULOOP
        If m.Msg = &H212 Then
            'this message is only sent when a ContextMenu is closed (not a ContextMenuStrip)
            isSplitMenuVisible = False
            SetButtonDrawState()
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub SetButtonDrawState()
        If Bounds.Contains(Parent.PointToClient(Cursor.Position)) Then
            State = PushButtonState.Hot
        ElseIf Focused Then
            State = PushButtonState.[Default]
        ElseIf Not Enabled Then
            State = PushButtonState.Disabled
        Else
            State = PushButtonState.Normal
        End If
    End Sub


End Class