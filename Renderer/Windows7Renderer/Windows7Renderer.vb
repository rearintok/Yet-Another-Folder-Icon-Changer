' Windows 7 ToolStrip Renderer
'
' Andrea Martinelli
' http://at-my-window.blogspot.com/?page=windows7renderer
'
' Based on Office 2007 Renderer by Phil Wright
' http://www.componentfactory.com


Imports System.Drawing
Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Collections.Generic


Public Class Windows7Renderer
	Inherits ToolStripProfessionalRenderer


	Private Shared _instance As Windows7Renderer
	Public Shared ReadOnly Property Instance() As Windows7Renderer
		Get
			Return If(_instance, (InlineAssignHelper(_instance, New Windows7Renderer())))
		End Get
	End Property

	#Region "GradientItemColors"
	Private Class GradientItemColors
		#Region "Public Fields"
		Public InsideTop1 As Color
		Public InsideTop2 As Color
		Public InsideBottom1 As Color
		Public InsideBottom2 As Color
		Public FillTop1 As Color
		Public FillTop2 As Color
		Public FillBottom1 As Color
		Public FillBottom2 As Color
		Public Border1 As Color
		Public Border2 As Color
		#End Region

		#Region "Identity"
		Public Sub New(insideTop1__1 As Color, insideTop2__2 As Color, insideBottom1__3 As Color, insideBottom2__4 As Color, fillTop1__5 As Color, fillTop2__6 As Color, _
			fillBottom1__7 As Color, fillBottom2__8 As Color, border1__9 As Color, border2__10 As Color)
			InsideTop1 = insideTop1__1
			InsideTop2 = insideTop2__2
			InsideBottom1 = insideBottom1__3
			InsideBottom2 = insideBottom2__4
			FillTop1 = fillTop1__5
			FillTop2 = fillTop2__6
			FillBottom1 = fillBottom1__7
			FillBottom2 = fillBottom2__8
			Border1 = border1__9
			Border2 = border2__10
		End Sub
		#End Region
	End Class
	#End Region




	#Region "Static Metrics"
	Private Const _gripOffset As Integer = 1
	Private Const _gripSquare As Integer = 2
	Private Const _gripSize As Integer = 3
	Private Const _gripMove As Integer = 4
	Private Const _gripLines As Integer = 3
	Private Const _checkInset As Integer = 0
	Private Const _marginInset As Integer = 2
	Private Const _separatorInset As Integer = 25
	Private Const _cutToolItemMenu As Single = 1F
	Private Const _cutContextMenu As Single = 0F
	Private Const _cutMenuItemBack As Single = 1.2F
	Private Const _contextCheckTickThickness As Single = 1.6F
	Private Shared _statusStripBlend As Blend
	#End Region

	#Region "Static Colors"
	Private Shared _c1 As Color = Color.FromArgb(167, 167, 167)
	Private Shared _c2 As Color = Color.FromArgb(21, 66, 139)
	Private Shared _c3 As Color = Color.FromArgb(76, 83, 92)
	Private Shared _c4 As Color = Color.FromArgb(250, 250, 250)
	Private Shared _c5 As Color = Color.FromArgb(248, 248, 248)
	Private Shared _c6 As Color = Color.FromArgb(243, 243, 243)
	Private Shared _r1 As Color = Color.FromArgb(255, 255, 251)
	Private Shared _r2 As Color = Color.FromArgb(255, 249, 227)
	Private Shared _r3 As Color = Color.FromArgb(255, 242, 201)
	Private Shared _r4 As Color = Color.FromArgb(248, 251, 254)

	Private Shared _r5 As Color = Color.FromArgb(248, 251, 254)
	Private Shared _r6 As Color = Color.FromArgb(237, 242, 250)

	Private Shared _r7 As Color = Color.FromArgb(215, 228, 244)
	Private Shared _r8 As Color = Color.FromArgb(193, 210, 232)


	Private Shared _r9 As Color = Color.FromArgb(187, 202, 219)
	Private Shared _rA As Color = Color.FromArgb(177, 195, 216)

	Private Shared _rB As Color = Color.FromArgb(182, 190, 192)
	Private Shared _rC As Color = Color.FromArgb(155, 163, 167)

	Private Shared _rD As Color = Color.FromArgb(201, 212, 228)
	Private Shared _rE As Color = Color.FromArgb(177, 195, 216)
	Private Shared _rF As Color = Color.FromArgb(170, 188, 211)
	Private Shared _rG As Color = Color.FromArgb(207, 220, 237)

	Private Shared _rH As Color = Color.FromArgb(221, 232, 241)
	Private Shared _rI As Color = Color.FromArgb(216, 228, 241)
	Private Shared _rJ As Color = Color.FromArgb(207, 220, 237)
	Private Shared _rK As Color = Color.FromArgb(207, 219, 236)

	Private Shared _rL As Color = Color.FromArgb(249, 192, 103)
	Private Shared _rM As Color = Color.FromArgb(250, 195, 93)
	Private Shared _rN As Color = Color.FromArgb(248, 190, 81)
	Private Shared _rO As Color = Color.FromArgb(255, 208, 49)
	Private Shared _rP As Color = Color.FromArgb(254, 214, 168)
	Private Shared _rQ As Color = Color.FromArgb(252, 180, 100)
	Private Shared _rR As Color = Color.FromArgb(252, 161, 54)
	Private Shared _rS As Color = Color.FromArgb(254, 238, 170)
	Private Shared _rT As Color = Color.FromArgb(249, 202, 113)
	Private Shared _rU As Color = Color.FromArgb(250, 205, 103)
	Private Shared _rV As Color = Color.FromArgb(248, 200, 91)
	Private Shared _rW As Color = Color.FromArgb(255, 218, 59)
	Private Shared _rX As Color = Color.FromArgb(254, 185, 108)
	Private Shared _rY As Color = Color.FromArgb(252, 161, 54)
	Private Shared _rZ As Color = Color.FromArgb(254, 238, 170)


	'private static Color clrBGTop1 = Color.FromArgb(255, 253, 255, 254);
	'private static Color clrBGTop2 = Color.FromArgb(255, 222, 231, 240);
	'private static Color clrBGBottom1 = Color.FromArgb(255, 231, 240, 249);
	'private static Color clrBGBottom2 = Color.FromArgb(255, 224, 232, 243);
	'private static Color clrBGBorder = Color.FromArgb(255, 235, 243, 254);
	'private static Color clrBGGreen = Color.FromArgb(0, 255, 255, 255);
	'private static Color clrBtnDarkBorder = Color.FromArgb(200, 3, 50, 81);
	'private static Color clrBtnLightBorder = Color.FromArgb(200, 216, 228, 236);



	Private Shared clrWindows7text As Color = Color.FromArgb(30, 57, 91)
	Private Shared clrWindows7topBegin As Color = Color.FromArgb(250, 252, 253)
	Private Shared clrWindows7topEnd As Color = Color.FromArgb(230, 240, 250)
	Private Shared clrWindows7bottomBegin As Color = Color.FromArgb(220, 230, 244)
	Private Shared clrWindows7bottomEnd As Color = Color.FromArgb(221, 233, 247)
	Private Shared clrWindows7bottomBorder3 As Color = Color.FromArgb(228, 239, 251)
	Private Shared clrWindows7bottomBorder2 As Color = Color.FromArgb(205, 218, 234)
	Private Shared clrWindows7bottomBorder1 As Color = Color.FromArgb(160, 175, 195)




	' Color scheme values
	Private Shared _textDisabled As Color = _c1

	Private Shared _textMenuStripItem As Color = Color.Black
	Private Shared _textStatusStripItem As Color = clrWindows7text
	Private Shared _textContextMenuItem As Color = clrWindows7text

	Private Shared _arrowDisabled As Color = _c1
	Private Shared _arrowLight As Color = Color.FromArgb(106, 126, 197)
	Private Shared _arrowDark As Color = clrWindows7text
	Private Shared _separatorMenuDark As Color = Color.FromArgb(226, 227, 227)
	Private Shared _separatorMenuLight As Color = Color.FromArgb(255, 255, 255)
	Private Shared _contextMenuBack As Color = Color.FromArgb(240, 240, 240)
	Private Shared _contextCheckBorder As Color = Color.FromArgb(175, 208, 247)
	Private Shared _contextCheckTick As Color = Color.FromArgb(12, 18, 161)
	Private Shared _statusStripBorderDark As Color = Color.FromArgb(86, 125, 176)
	Private Shared _statusStripBorderLight As Color = Color.White
	Private Shared _gripDark As Color = Color.FromArgb(114, 152, 204)
	Private Shared _gripLight As Color = _c5


	Private Shared _statusBarDark As Color = Color.FromArgb(204, 217, 234)
	Private Shared _statusBarLight As Color = Color.FromArgb(241, 245, 251)


	Private Shared _itemContextItemEnabledColors As New GradientItemColors(Color.FromArgb(127, 242, 244, 246), Color.FromArgb(127, 236, 241, 247), Color.FromArgb(127, 231, 238, 247), Color.FromArgb(127, 236, 241, 247), Color.Transparent, Color.Transparent, _
		Color.Transparent, Color.Transparent, Color.FromArgb(174, 207, 247), Color.FromArgb(174, 207, 247))





	Private Shared _itemDisabledColors As New GradientItemColors(Color.FromArgb(127, 242, 244, 246), Color.FromArgb(127, 236, 241, 247), Color.FromArgb(127, 231, 238, 247), Color.FromArgb(127, 236, 241, 247), Color.Transparent, Color.Transparent, _
		Color.Transparent, Color.Transparent, Color.FromArgb(212, 212, 212), Color.FromArgb(195, 195, 195))
	'**
	Private Shared _itemToolItemSelectedColors As New GradientItemColors(_r1, _r2, _r3, _r4, _r5, _r6, _
		_r7, _r8, _r9, _rA)
	'***
	Private Shared _itemToolItemPressedColors As New GradientItemColors(_rD, _rE, _rF, _rG, _rH, _rI, _
		_rJ, _rK, _r9, _rA)
	'***
	Private Shared _itemToolItemCheckedColors As New GradientItemColors(_rD, _rE, _rF, _rG, _rH, _rI, _
		_rJ, _rK, _r9, _rA)

	'new GradientItemColors(/*****/ _rL, _rM, _rN, _rO, _rP, _rQ, _rR, _rS, _r9, _rA);
	'***
	Private Shared _itemToolItemCheckPressColors As New GradientItemColors(_rD, _rE, _rF, _rG, _rH, _rI, _
		_rJ, _rK, _r9, _rA)
	'new GradientItemColors(/**/ _rT, _rU, _rV, _rW, _rX, _rI, _rY, _rZ, _r9, _rA);
	#End Region

	#Region "Identity"
	Shared Sub New()
		' One time creation of the blend for the status strip gradient brush
		_statusStripBlend = New Blend()
		_statusStripBlend.Positions = New Single() {0F, 0.25F, 0.25F, 0.57F, 0.86F, 1F}
		_statusStripBlend.Factors = New Single() {0.1F, 0.6F, 1F, 0.4F, 0F, 0.95F}
	End Sub






	Protected Overrides Sub InitializeItem(item As ToolStripItem)
		MyBase.InitializeItem(item)

		If item.DisplayStyle = ToolStripItemDisplayStyle.Image Then
			Dim m = item.Margin
            m.Left += 4
            m.Right += 4
			item.Margin = m
		End If

		If True Then
			Dim a = TryCast(item, ToolStripSplitButton)
			If a IsNot Nothing Then

				a.DropDownButtonWidth = 17

				If a.DisplayStyle = ToolStripItemDisplayStyle.Image Then
                    a.Padding = New Padding(3, 0, 3, 0)
				ElseIf a.DisplayStyle = ToolStripItemDisplayStyle.Text Then
					a.Padding = New Padding(14, 3, 15, 3)
				Else
					a.Padding = New Padding(25, 3, 0, 3)
					a.TextAlign = ContentAlignment.MiddleRight
				End If
			End If
		End If






		If True Then
			Dim a = TryCast(item, ToolStripDropDownButton)
			If a IsNot Nothing Then

				If a.DisplayStyle = ToolStripItemDisplayStyle.Image Then
						' a.Margin = new Padding(4, 0, 4, 0);
					a.Padding = New Padding(7, 0, 7, 0)
				ElseIf a.DisplayStyle = ToolStripItemDisplayStyle.Text Then
					a.Padding = New Padding(14, 3, 15, 3)
				Else
					a.Padding = New Padding(25, 3, 0, 3)
					a.TextAlign = ContentAlignment.MiddleRight
				End If
			End If
		End If



		If True Then
			Dim a = TryCast(item, ToolStripButton)
			If a IsNot Nothing Then

				If a.DisplayStyle = ToolStripItemDisplayStyle.Image Then
						' a.Margin = new Padding(4, 0, 4, 0);
					a.Padding = New Padding(4, 0, 4, 0)
				ElseIf a.DisplayStyle = ToolStripItemDisplayStyle.Text Then
					a.Padding = New Padding(15, 3, 15, 3)
				Else
					a.Padding = New Padding(25, 3, 0, 3)

					a.TextAlign = ContentAlignment.MiddleRight


				End If
			End If
		End If

		If TypeOf item Is ToolStripSeparator Then
			item.Height += 1
		End If

		If TypeOf item Is ToolStripOverflowButton Then
			item.Width += 25
		End If








	End Sub



	Public Sub New()
		MyBase.New(New Windows7ColorTable())
		RoundedEdges = False
	End Sub
	#End Region

	#Region "OnRenderArrow"
	''' <summary>
	''' Raises the RenderArrow event. 
	''' </summary>
	''' <param name="e">An ToolStripArrowRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
		' Cannot paint a zero sized area
		If (e.ArrowRectangle.Width > 0) AndAlso (e.ArrowRectangle.Height > 0) Then
			' Create a path that is used to fill the arrow
			Using arrowPath As GraphicsPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction)
				' Get the rectangle that encloses the arrow and expand slightly
				' so that the gradient is always within the expanding bounds
				'RectangleF boundsF = arrowPath.GetBounds();
				'boundsF.Inflate(5f, 5f);

				'  Color color1 = (e.Item.Enabled ? _arrowLight : _arrowDisabled);

				Dim color2 As Color
				If Not e.Item.Enabled Then
					color2 = _arrowDisabled
				Else
					Dim parent = e.Item.GetCurrentParent()
					If TypeOf parent Is ToolStripDropDown OrElse TypeOf parent Is MenuStrip OrElse TypeOf parent Is ContextMenuStrip Then
						color2 = Color.Black
					Else
						color2 = _arrowDark
					End If
				End If




				'
'                    float angle = 0;
'
'                    // Use gradient angle to match the arrow direction
'                    switch (e.Direction)
'                    {
'                        case ArrowDirection.Right:
'                            angle = 0;
'                            break;
'                        case ArrowDirection.Left:
'                            angle = 180f;
'                            break;
'                        case ArrowDirection.Down:
'                            angle = 90f;
'                            break;
'                        case ArrowDirection.Up:
'                            angle = 270f;
'                            break;
'                    }



				' Draw the actual arrow using a gradient
				'  using (LinearGradientBrush arrowBrush = new LinearGradientBrush(boundsF, color1, color2, angle))
				'  e.Graphics.FillPath(arrowBrush, arrowPath);
				'     e.Graphics.CompositingQuality=SmoothingMode.None;
				Using arrowBrush = New SolidBrush(color2)
					e.Graphics.FillPath(arrowBrush, arrowPath)
				End Using
			End Using
		End If
	End Sub
	#End Region

	Protected Overrides Sub Initialize(toolStrip As ToolStrip)
		MyBase.Initialize(toolStrip)

		If TypeOf toolStrip Is MenuStrip Then
			toolStrip.CanOverflow = False
				' No nothing
		ElseIf TypeOf toolStrip Is ContextMenuStrip Then
		Else

			toolStrip.AutoSize = False
			toolStrip.Height = 32

            toolStrip.Padding = New Padding(5, 2, 5, 2)
			toolStrip.CanOverflow = False

			toolStrip.GripStyle = ToolStripGripStyle.Hidden
		End If

        toolStrip.Font = New Font("Tahoma", 8)




	End Sub

	#Region "OnRenderButtonBackground"
	''' <summary>
	''' Raises the RenderButtonBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
		' Cast to correct type
		Dim button As ToolStripButton = DirectCast(e.Item, ToolStripButton)
		If button.Selected OrElse button.Pressed OrElse button.Checked Then
			RenderToolButtonBackground(e.Graphics, button, e.ToolStrip)
		End If
	End Sub
	#End Region

	#Region "OnRenderDropDownButtonBackground"
	''' <summary>
	''' Raises the RenderDropDownButtonBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderDropDownButtonBackground(e As ToolStripItemRenderEventArgs)
		If e.Item.Selected OrElse e.Item.Pressed Then
			RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip)
		End If
	End Sub
	#End Region

	#Region "OnRenderItemCheck"
	''' <summary>
	''' Raises the RenderItemCheck event. 
	''' </summary>
	''' <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)

		' Staring size of the checkbox is the image rectangle
		Dim checkBox As Rectangle = e.ImageRectangle

		' Make the border of the check box 1 pixel bigger on all sides, as a minimum
		checkBox.Inflate(2, 2)

		' Can we extend upwards?
		If checkBox.Top > _checkInset Then
			Dim diff As Integer = checkBox.Top - _checkInset
			checkBox.Y -= diff
			checkBox.Height += diff
		End If

		' Can we extend downwards?
		If checkBox.Height <= (e.Item.Bounds.Height - (_checkInset * 2)) Then
			Dim diff As Integer = e.Item.Bounds.Height - (_checkInset * 2) - checkBox.Height
			checkBox.Height += diff
		End If

		checkBox.Width = checkBox.Height


		' Drawing with anti aliasing to create smoother appearance
		Using uaa As New UseAntiAlias(e.Graphics)
			' Create border path for the check box
			Using borderPath As GraphicsPath = CreateBorderPath(checkBox, _cutMenuItemBack)
				' Fill the background in a solid color
				Using fillBrush As New SolidBrush(ColorTable.CheckBackground)
					e.Graphics.FillPath(fillBrush, borderPath)
				End Using

				' Draw the border around the check box
				Using borderPen As New Pen(_contextCheckBorder)
					e.Graphics.DrawPath(borderPen, borderPath)
				End Using

				' If there is not an image, then we can draw the tick, square etc...
				If e.Image IsNot Nothing Then
					Dim checkState__1 As CheckState = CheckState.Unchecked

					' Extract the check state from the item
					If TypeOf e.Item Is ToolStripMenuItem Then
						Dim item As ToolStripMenuItem = DirectCast(e.Item, ToolStripMenuItem)
						checkState__1 = item.CheckState
					End If

					' Decide what graphic to draw
					Select Case checkState__1
						Case CheckState.Checked
							' Create a path for the tick
							Using tickPath As GraphicsPath = CreateTickPath(checkBox)
								' Draw the tick with a thickish brush
								Using tickPen As New Pen(_contextCheckTick, _contextCheckTickThickness)
									e.Graphics.DrawPath(tickPen, tickPath)
								End Using
							End Using
							Exit Select
						Case CheckState.Indeterminate
							' Create a path for the indeterminate diamond
							Using tickPath As GraphicsPath = CreateIndeterminatePath(checkBox)
								' Draw the tick with a thickish brush
								Using tickBrush As New SolidBrush(_contextCheckTick)
									e.Graphics.FillPath(tickBrush, tickPath)
								End Using
							End Using
							Exit Select
					End Select
				End If
			End Using
		End Using
	End Sub
	#End Region

	#Region "OnRenderItemText"
	''' <summary>
	''' Raises the RenderItemText event. 
	''' </summary>
	''' <param name="e">An ToolStripItemTextRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)



		If (TypeOf e.ToolStrip Is MenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStrip) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' We set the color depending on the enabled state
			If Not e.Item.Enabled Then
				e.TextColor = _textDisabled
			Else
				'    if ((e.ToolStrip is MenuStrip) && !e.Item.Pressed && !e.Item.Selected)
'                            e.TextColor = _textMenuStripItem;

				If (TypeOf e.ToolStrip Is StatusStrip) AndAlso Not e.Item.Pressed AndAlso Not e.Item.Selected Then
					e.TextColor = _textStatusStripItem
				ElseIf (TypeOf e.ToolStrip Is MenuStrip) Then
					e.TextColor = _textStatusStripItem
				ElseIf TypeOf e.ToolStrip Is ToolStripDropDown Then
					e.TextColor = Color.Black
				Else
					e.TextColor = _textContextMenuItem

				End If
			End If

			e.TextRectangle = AdjustDrawRectangle(e.Item, e.TextRectangle)


			' All text is draw using the ClearTypeGridFit text rendering hint
			Using clearTypeGridFit As New UseClearTypeGridFit(e.Graphics)
				MyBase.OnRenderItemText(e)
			End Using
		Else

			MyBase.OnRenderItemText(e)
		End If
	End Sub

	Private Function AdjustDrawRectangle(item As ToolStripItem, rectangle As Rectangle) As Rectangle
		If LooksPressed(item) Then

			Dim r = rectangle
			r.X += 1
			r.Y += 1
			Return r
		End If

		Return rectangle

	End Function
	#End Region


	Private Function LooksPressed(item As ToolStripItem) As Boolean
		Dim parent = item.GetCurrentParent()
		If TypeOf parent Is MenuStrip Then
			Return False
		End If
		If TypeOf parent Is ContextMenuStrip Then
			Return False
		End If
		If TypeOf parent Is ToolStripDropDown Then
			Return False
		End If

		If item.Pressed Then
			Return True
		End If



		If True Then
			Dim a = TryCast(item, ToolStripDropDownButton)
			If a IsNot Nothing AndAlso a.IsOnDropDown Then
				Return True
			End If
		End If

		If True Then
			Dim a = TryCast(item, ToolStripSplitButton)
			If a IsNot Nothing AndAlso a.IsOnDropDown Then
				Return True
			End If
		End If


		Return False
	End Function

	#Region "OnRenderItemImage"
	''' <summary>
	''' Raises the RenderItemImage event. 
	''' </summary>
	''' <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderItemImage(e As ToolStripItemImageRenderEventArgs)

		' We only override the image drawing for context menus
		' if ((e.ToolStrip is ContextMenuStrip) ||
'                 (e.ToolStrip is ToolStripDropDownMenu))
'             {



		If e.Image IsNot Nothing Then

			Dim checkbox = TryCast(e.Item, ToolStripMenuItem)
			If checkbox Is Nothing OrElse checkbox.CheckState = CheckState.Unchecked Then

				Dim newrect = AdjustDrawRectangle(e.Item, e.ImageRectangle)
				If e.Item.Enabled Then
					e.Graphics.DrawImage(e.Image, newrect)
				Else
					ControlPaint.DrawImageDisabled(e.Graphics, e.Image, newrect.X, newrect.Y, Color.Transparent)
				End If
			End If
		End If


		'  }
'              else
'              {
'               
'
'
'
'                 // base.OnRenderItemImage(e);
'              }

	End Sub
	#End Region

	#Region "OnRenderMenuItemBackground"
	''' <summary>
	''' Raises the RenderMenuItemBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)

		If (TypeOf e.ToolStrip Is MenuStrip) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' if ((e.Item.Pressed) && (e.ToolStrip is MenuStrip))
'                 {
'                     // Draw the menu/tool strip as a header for a context menu item
'                     DrawContextMenuHeader(e.Graphics, e.Item);
'                 }
'                 else

			If True Then
				' We only draw a background if the item is selected and enabled
				If e.Item.Selected Then
					If e.Item.Enabled Then
						' Do we draw as a menu strip or context menu item?
						'  if (e.ToolStrip is MenuStrip)
'                                  DrawGradientToolItem(e.Graphics, e.Item, _itemToolItemSelectedColors);
'                              else


						DrawGradientContextMenuItem(e.Graphics, e.Item, _itemContextItemEnabledColors)
					Else
						' Get the mouse position in tool strip coordinates
						Dim mousePos As Point = e.ToolStrip.PointToClient(Control.MousePosition)

						' If the mouse is not in the item area, then draw disabled
						'if (!e.Item.Bounds.Contains(mousePos))
						'{
						' Do we draw as a menu strip or context menu item?
						If TypeOf e.ToolStrip Is MenuStrip Then
							DrawGradientToolItem(e.Graphics, e.Item, _itemDisabledColors)
						Else
							DrawGradientContextMenuItem(e.Graphics, e.Item, _itemDisabledColors)
							'}
						End If
					End If
				End If
			End If
		Else
			MyBase.OnRenderMenuItemBackground(e)
		End If


	End Sub
	#End Region

	#Region "OnRenderSplitButtonBackground"
	''' <summary>
	''' Raises the RenderSplitButtonBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderSplitButtonBackground(e As ToolStripItemRenderEventArgs)
		If e.Item.Selected OrElse e.Item.Pressed Then
			' Cast to correct type
			Dim splitButton As ToolStripSplitButton = DirectCast(e.Item, ToolStripSplitButton)

			' Draw the border and background
			RenderToolSplitButtonBackground(e.Graphics, splitButton, e.ToolStrip)

			' Get the rectangle that needs to show the arrow
			Dim arrowBounds As Rectangle = splitButton.DropDownButtonBounds

			' Draw the arrow on top of the background
			OnRenderArrow(New ToolStripArrowRenderEventArgs(e.Graphics, splitButton, arrowBounds, SystemColors.ControlText, ArrowDirection.Down))
		Else
			MyBase.OnRenderSplitButtonBackground(e)
		End If
	End Sub
	#End Region

	#Region "OnRenderStatusStripSizingGrip"
	''' <summary>
	''' Raises the RenderStatusStripSizingGrip event. 
	''' </summary>
	''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderStatusStripSizingGrip(e As ToolStripRenderEventArgs)
		Using darkBrush As New SolidBrush(_gripDark), lightBrush As New SolidBrush(_gripLight)
			' Do we need to invert the drawing edge?
			Dim rtl As Boolean = (e.ToolStrip.RightToLeft = RightToLeft.Yes)

			' Find vertical position of the lowest grip line
            Dim y As Integer = e.AffectedBounds.Bottom - _gripSize * 2 + 1

			' Draw three lines of grips
			For i As Integer = _gripLines To 1 Step -1
				' Find the rightmost grip position on the line
                Dim x As Integer = (If(rtl, e.AffectedBounds.Left + 1, e.AffectedBounds.Right - _gripSize * 2 + 1))

				' Draw grips from right to left on line
				For j As Integer = 0 To i - 1
					' Just the single grip glyph
					DrawGripGlyph(e.Graphics, x, y, darkBrush, lightBrush)

					' Move left to next grip position
					x -= (If(rtl, -_gripMove, _gripMove))
				Next

				' Move upwards to next grip line
				y -= _gripMove
			Next
		End Using
	End Sub
	#End Region

	#Region "OnRenderToolStripContentPanelBackground"
	''' <summary>
	''' Raises the RenderToolStripContentPanelBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripContentPanelRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderToolStripContentPanelBackground(e As ToolStripContentPanelRenderEventArgs)

		' Must call base class, otherwise the subsequent drawing does not appear!
		MyBase.OnRenderToolStripContentPanelBackground(e)

		' Cannot paint a zero sized area
		If (e.ToolStripContentPanel.Width > 0) AndAlso (e.ToolStripContentPanel.Height > 0) Then
			Using backBrush As New LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, ColorTable.ToolStripContentPanelGradientEnd, ColorTable.ToolStripContentPanelGradientBegin, 90F)
				e.Graphics.FillRectangle(backBrush, e.ToolStripContentPanel.ClientRectangle)
			End Using
		End If

	End Sub
	#End Region

	#Region "OnRenderSeparator"
	''' <summary>
	''' Raises the RenderSeparator event. 
	''' </summary>
	''' <param name="e">An ToolStripSeparatorRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
		If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' Create the light and dark line pens
			Using lightPen As New Pen(_separatorMenuLight), darkPen As New Pen(_separatorMenuDark)
				DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, _separatorInset, _
					(e.ToolStrip.RightToLeft = RightToLeft.Yes))
			End Using
		ElseIf TypeOf e.ToolStrip Is StatusStrip Then
			' Create the light and dark line pens
			Using lightPen As New Pen(ColorTable.SeparatorLight), darkPen As New Pen(ColorTable.SeparatorDark)
				DrawSeparator(e.Graphics, e.Vertical, e.Item.Bounds, lightPen, darkPen, 0, _
					False)
			End Using
		Else
			MyBase.OnRenderSeparator(e)
		End If



	End Sub
	#End Region

	#Region "OnRenderToolStripBackground"
	''' <summary>
	''' Raises the RenderToolStripBackground event. 
	''' </summary>
	''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)

		If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' Create border and clipping paths
			Using borderPath As GraphicsPath = CreateBorderPath(e.AffectedBounds, _cutContextMenu), clipPath As GraphicsPath = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu)
				' Clip all drawing to within the border path
				Using clipping As New UseClipping(e.Graphics, clipPath)
					' Create the background brush
					Using backBrush As New SolidBrush(_contextMenuBack)
						e.Graphics.FillPath(backBrush, borderPath)
					End Using
				End Using
			End Using
		ElseIf TypeOf e.ToolStrip Is StatusStrip Then
			' We do not paint the top two pixel lines, so are drawn by the status strip border render method
			Dim backRect As New RectangleF(0, 1.5F, e.ToolStrip.Width, e.ToolStrip.Height - 2)

			' Cannot paint a zero sized area
			If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
				Using backBrush = New SolidBrush(_statusBarLight)
					'backBrush.Blend = _statusStripBlend;
					e.Graphics.FillRectangle(backBrush, backRect)
				End Using
				Dim topRect = New Rectangle(0, 0, CInt(Math.Truncate(backRect.Width)), 5)
				Using backBrush = New LinearGradientBrush(topRect, _statusBarDark, _statusBarLight, LinearGradientMode.Vertical)
					'backBrush.Blend = _statusStripBlend;
					e.Graphics.FillRectangle(backBrush, topRect)
				End Using
			End If
		Else
			'  base.OnRenderToolStripBackground(e);
			Dim toolStrip As ToolStrip = e.ToolStrip

			If (toolStrip.Height > 0) AndAlso (toolStrip.Width > 0) Then



				Dim height = toolStrip.Height
				Dim center = height \ 2
				Dim width = toolStrip.Width

				Dim topRect = New Rectangle(0, 0, width, center)
				Dim bottomRect = New Rectangle(0, center, width, height - center - 3)


				Using topBrush = New LinearGradientBrush(topRect, clrWindows7topBegin, clrWindows7topEnd, LinearGradientMode.Vertical)
					e.Graphics.FillRectangle(topBrush, topRect)
				End Using

				Using bottomBrush = New LinearGradientBrush(bottomRect, clrWindows7bottomBegin, clrWindows7bottomEnd, LinearGradientMode.Vertical)
					e.Graphics.FillRectangle(bottomBrush, bottomRect)
				End Using

				Using pen3 = New Pen(clrWindows7bottomBorder3)
					e.Graphics.DrawLine(pen3, 0, height - 3, width, height - 3)
				End Using

				Using pen2 = New Pen(clrWindows7bottomBorder2)
					e.Graphics.DrawLine(pen2, 0, height - 2, width, height - 2)
				End Using

				Using pen1 = New Pen(clrWindows7bottomBorder1)
					e.Graphics.DrawLine(pen1, 0, height - 1, width, height - 1)


					' e.Graphics.FillRectangle(new SolidBrush(clrBGTop2), e.AffectedBounds);


					' e.Graphics.FillRectangle(bottomGradBrush, bottomGradRect);
					'    e.Graphics.FillRectangle(horGradBrush, e.AffectedBounds);

					' e.Graphics.DrawRectangle(new Pen(clrBGBorder, 1), new Rectangle(0, 1, e.ToolStrip.Width - 1, e.ToolStrip.Height - 4));


					' using (LinearGradientBrush brush = new LinearGradientBrush(toolStrip.ClientRectangle, Color.FromArgb(253, 253, 253), Color.FromArgb(229, 233, 238), LinearGradientMode.Vertical))
'                     {
'                         e.Graphics.FillRectangle(brush, 0, 0, toolStrip.Width, toolStrip.Height);
'                     }

				End Using

			End If
		End If


	End Sub
	#End Region

	#Region "OnRenderImageMargin"
	''' <summary>
	''' Raises the RenderImageMargin event. 
	''' </summary>
	''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
		If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' Start with the total margin area
			Dim marginRect As Rectangle = e.AffectedBounds

			' Do we need to draw with separator on the opposite edge?
			Dim rtl As Boolean = (e.ToolStrip.RightToLeft = RightToLeft.Yes)

			marginRect.Y += _marginInset
			marginRect.Height -= _marginInset * 2

			' Reduce so it is inside the border
			If Not rtl Then
				marginRect.X += _marginInset + 3
			Else
				marginRect.X += _marginInset \ 2
			End If



			' Draw the entire margine area in a solid color
			Using backBrush As New SolidBrush(ColorTable.ImageMarginGradientBegin)
				e.Graphics.FillRectangle(backBrush, marginRect)
			End Using

			' Create the light and dark line pens
			Using lightPen As New Pen(_separatorMenuLight), darkPen As New Pen(_separatorMenuDark)
				If Not rtl Then
					' Draw the light and dark lines on the right hand side
					e.Graphics.DrawLine(lightPen, marginRect.Right, marginRect.Top, marginRect.Right, marginRect.Bottom)
					e.Graphics.DrawLine(darkPen, marginRect.Right - 1, marginRect.Top, marginRect.Right - 1, marginRect.Bottom)
				Else
					' Draw the light and dark lines on the left hand side
					e.Graphics.DrawLine(lightPen, marginRect.Left - 1, marginRect.Top, marginRect.Left - 1, marginRect.Bottom)
					e.Graphics.DrawLine(darkPen, marginRect.Left, marginRect.Top, marginRect.Left, marginRect.Bottom)
				End If
			End Using
		Else
			MyBase.OnRenderImageMargin(e)
		End If
	End Sub
	#End Region

	#Region "OnRenderToolStripBorder"
	''' <summary>
	''' Raises the RenderToolStripBorder event. 
	''' </summary>
	''' <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
	Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)

		If (TypeOf e.ToolStrip Is ContextMenuStrip) OrElse (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
			' If there is a connected area to be drawn
			If Not e.ConnectedArea.IsEmpty Then
				Using excludeBrush As New SolidBrush(_contextMenuBack)
					e.Graphics.FillRectangle(excludeBrush, e.ConnectedArea)
				End Using
			End If
			' var k = e.ToolStrip as ToolStripDropDownMenu;
'                 var q = k.Parent;

			Dim connectedArea = Rectangle.Empty

			' Create border and clipping paths
			Using borderPath As GraphicsPath = CreateBorderPath(e.AffectedBounds, connectedArea, _cutContextMenu), insidePath As GraphicsPath = CreateInsideBorderPath(e.AffectedBounds, connectedArea, _cutContextMenu), clipPath As GraphicsPath = CreateClipBorderPath(e.AffectedBounds, connectedArea, _cutContextMenu)
				' Create the different pen colors we need
				Using borderPen As New Pen(ColorTable.MenuBorder), insidePen As New Pen(_separatorMenuLight)
					' Clip all drawing to within the border path
					Using clipping As New UseClipping(e.Graphics, clipPath)
						' Drawing with anti aliasing to create smoother appearance
						Using uaa As New UseAntiAlias(e.Graphics)
							' Draw the inside area first
							e.Graphics.DrawPath(insidePen, insidePath)

							' Draw the border area second, so any overlapping gives it priority
							e.Graphics.DrawPath(borderPen, borderPath)
						End Using

						' Draw the pixel at the bottom right of the context menu
						e.Graphics.DrawLine(borderPen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1)
					End Using
				End Using
			End Using
				' Draw two lines at top of the status strip
				'   using (Pen darkBorder = new Pen(_statusStripBorderDark),
'                             lightBorder = new Pen(_statusStripBorderLight))
'                   {
'                       e.Graphics.DrawLine(darkBorder, 0, 0, e.ToolStrip.Width, 0);
'                       e.Graphics.DrawLine(lightBorder, 0, 1, e.ToolStrip.Width, 1);
'                   }

		ElseIf TypeOf e.ToolStrip Is StatusStrip Then
				'   base.OnRenderToolStripBorder(e);
		Else
		End If

	End Sub
	#End Region

	#Region "Implementation"
	Private Sub RenderToolButtonBackground(g As Graphics, button As ToolStripButton, toolstrip As ToolStrip)

		' We only draw a background if the item is selected or being pressed
		If button.Enabled Then
			If button.Checked Then
				If button.Pressed Then
					DrawGradientToolItem(g, button, _itemToolItemPressedColors)
				ElseIf button.Selected Then
					DrawGradientToolItem(g, button, _itemToolItemCheckPressColors)
				Else
					DrawGradientToolItem(g, button, _itemToolItemCheckedColors)
				End If
			Else
				If button.Pressed Then
					DrawGradientToolItem(g, button, _itemToolItemPressedColors)
				ElseIf button.Selected Then
					DrawGradientToolItem(g, button, _itemToolItemSelectedColors)
				End If
			End If
		Else
			If button.Selected Then
				' Get the mouse position in tool strip coordinates
				Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

				' If the mouse is not in the item area, then draw disabled
				If Not button.Bounds.Contains(mousePos) Then
					DrawGradientToolItem(g, button, _itemDisabledColors)
				End If
			End If
		End If
	End Sub

	Private Sub RenderToolDropButtonBackground(g As Graphics, item As ToolStripItem, toolstrip As ToolStrip)

		' We only draw a background if the item is selected or being pressed
		If item.Selected OrElse item.Pressed Then
			If item.Enabled Then
				If item.Pressed Then
					DrawGradientToolItem(g, item, _itemToolItemPressedColors)
				Else
					' DrawContextMenuHeader(g, item);
					DrawGradientToolItem(g, item, _itemToolItemSelectedColors)
				End If
			Else
				' Get the mouse position in tool strip coordinates
				Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

				' If the mouse is not in the item area, then draw disabled
				If Not item.Bounds.Contains(mousePos) Then
					DrawGradientToolItem(g, item, _itemDisabledColors)
				End If
			End If
		End If

	End Sub

	Private Sub RenderToolSplitButtonBackground(g As Graphics, splitButton As ToolStripSplitButton, toolstrip As ToolStrip)
		' We only draw a background if the item is selected or being pressed
		If splitButton.Selected OrElse splitButton.Pressed Then
			If splitButton.Enabled Then
				If Not splitButton.Pressed AndAlso splitButton.ButtonPressed Then
					' large
					'DrawGradientToolItem(g, splitButton, _itemToolItemCheckPressColors);

					DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors, _itemToolItemPressedColors, _itemContextItemEnabledColors)
				ElseIf splitButton.Pressed AndAlso Not splitButton.ButtonPressed Then
					' small
					'DrawContextMenuHeader(g, splitButton);
					DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors, _itemToolItemPressedColors, _itemContextItemEnabledColors)
				Else
					DrawGradientToolSplitItem(g, splitButton, _itemToolItemSelectedColors, _itemToolItemSelectedColors, _itemContextItemEnabledColors)
				End If
			Else
				' Get the mouse position in tool strip coordinates
				Dim mousePos As Point = toolstrip.PointToClient(Control.MousePosition)

				' If the mouse is not in the item area, then draw disabled
				If Not splitButton.Bounds.Contains(mousePos) Then
					DrawGradientToolItem(g, splitButton, _itemDisabledColors)
				End If
			End If
		End If

	End Sub

	Private Sub DrawGradientToolItem(g As Graphics, item As ToolStripItem, colors As GradientItemColors)
		' Perform drawing into the entire background of the item
		DrawGradientItem(g, New Rectangle(Point.Empty, item.Bounds.Size), colors)
	End Sub

	Private Sub DrawGradientToolSplitItem(g As Graphics, splitButton As ToolStripSplitButton, colorsButton As GradientItemColors, colorsDrop As GradientItemColors, colorsSplit As GradientItemColors)
		' Create entire area and just the drop button area rectangles
		Dim backRect As New Rectangle(Point.Empty, splitButton.Bounds.Size)
		Dim backRectDrop As Rectangle = splitButton.DropDownButtonBounds

		' Cannot paint zero sized areas
		If (backRect.Width > 0) AndAlso (backRectDrop.Width > 0) AndAlso (backRect.Height > 0) AndAlso (backRectDrop.Height > 0) Then
			' Area that is the normal button starts as everything
			Dim backRectButton As Rectangle = backRect

			' The X offset to draw the split line
			Dim splitOffset As Integer

			' Is the drop button on the right hand side of entire area?
			If backRectDrop.X > 0 Then
				backRectButton.Width = backRectDrop.Left
				backRectDrop.X -= 1
				backRectDrop.Width += 1
				splitOffset = backRectDrop.X
			Else
				backRectButton.Width -= backRectDrop.Width - 2
				backRectButton.X = backRectDrop.Right - 1
				backRectDrop.Width += 1
				splitOffset = backRectDrop.Right - 1
			End If

			' Create border path around the item
			Using borderPath As GraphicsPath = CreateBorderPath(backRect, _cutMenuItemBack)
				' Draw the normal button area background
				DrawGradientBack(g, backRectButton, colorsButton)

				' Draw the drop button area background
				DrawGradientBack(g, backRectDrop, colorsDrop)

				' Draw the split line between the areas
				Using splitBrush As New LinearGradientBrush(New Rectangle(backRect.X + splitOffset, backRect.Top, 1, backRect.Height + 1), colorsSplit.Border1, colorsSplit.Border2, 90F)
					' Sigma curve, so go from color1 to color2 and back to color1 again
					splitBrush.SetSigmaBellShape(0.5F)

					' Convert the brush to a pen for DrawPath call
					Using splitPen As New Pen(splitBrush)
						g.DrawLine(splitPen, backRect.X + splitOffset, backRect.Top + 1, backRect.X + splitOffset, backRect.Bottom - 1)
					End Using
				End Using

				' Draw the border of the entire item
				DrawGradientBorder(g, backRect, colorsButton)
			End Using
		End If
	End Sub

	Private Sub DrawContextMenuHeader(g As Graphics, item As ToolStripItem)
		' Get the rectangle the is the items area
		Dim itemRect As New Rectangle(Point.Empty, item.Bounds.Size)

		' Create border and clipping paths
		Using borderPath As GraphicsPath = CreateBorderPath(itemRect, _cutToolItemMenu), insidePath As GraphicsPath = CreateInsideBorderPath(itemRect, _cutToolItemMenu), clipPath As GraphicsPath = CreateClipBorderPath(itemRect, _cutToolItemMenu)
			' Clip all drawing to within the border path
			Using clipping As New UseClipping(g, clipPath)
				' Draw the entire background area first
				Using backBrush As New SolidBrush(_separatorMenuLight)
					g.FillPath(backBrush, borderPath)
				End Using

				' Draw the border
				Using borderPen As New Pen(ColorTable.MenuBorder)
					g.DrawPath(borderPen, borderPath)
				End Using
			End Using
		End Using


	End Sub

	Private Sub DrawGradientContextMenuItem(g As Graphics, item As ToolStripItem, colors As GradientItemColors)
		' Do we need to draw with separator on the opposite edge?
		Dim backRect As New Rectangle(2, 0, item.Bounds.Width - 3, item.Bounds.Height)

		' Perform actual drawing into the background

		backRect.X += 1
		backRect.Width -= 2

		If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
			' Draw the background of the entire item
			DrawGradientBack(g, backRect, colors)

			' Draw the border of the entire item
				' g.Clear(Color.Red);
			DrawGradientBorder(g, backRect, colors)
		End If


		' DrawGradientItem(g, backRect, colors);




	End Sub

	Private Sub DrawGradientItem(g As Graphics, backRect As Rectangle, colors As GradientItemColors)
		' Cannot paint a zero sized area
		If (backRect.Width > 0) AndAlso (backRect.Height > 0) Then
			' Draw the background of the entire item
			DrawGradientBack(g, backRect, colors)

			' Draw the border of the entire item
			DrawGradientBorder(g, backRect, colors)
		End If
	End Sub

	Private Sub DrawGradientBack(g As Graphics, backRect As Rectangle, colors As GradientItemColors)
		' Reduce rect draw drawing inside the border
		backRect.Inflate(-1, -1)

		Dim y2 As Integer = backRect.Height \ 2
		Dim backRect1 As New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
		Dim backRect2 As New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)
		Dim backRect1I As Rectangle = backRect1
		Dim backRect2I As Rectangle = backRect2
		backRect1I.Inflate(1, 1)
		backRect2I.Inflate(1, 1)

		Using insideBrush1 As New LinearGradientBrush(backRect1I, colors.InsideTop1, colors.InsideTop2, 90F), insideBrush2 As New LinearGradientBrush(backRect2I, colors.InsideBottom1, colors.InsideBottom2, 90F)
			g.FillRectangle(insideBrush1, backRect1)
			g.FillRectangle(insideBrush2, backRect2)
		End Using

		y2 = backRect.Height \ 2
		backRect1 = New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
		backRect2 = New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)
		backRect1I = backRect1
		backRect2I = backRect2
		backRect1I.Inflate(1, 1)
		backRect2I.Inflate(1, 1)

		Using fillBrush1 As New LinearGradientBrush(backRect1I, colors.FillTop1, colors.FillTop2, 90F), fillBrush2 As New LinearGradientBrush(backRect2I, colors.FillBottom1, colors.FillBottom2, 90F)
			' Reduce rect one more time for the innermost drawing
			backRect.Inflate(-1, -1)

			y2 = (backRect.Height \ 2) + 1
			backRect1 = New Rectangle(backRect.X, backRect.Y, backRect.Width, y2)
			backRect2 = New Rectangle(backRect.X, backRect.Y + y2, backRect.Width, backRect.Height - y2)

			g.FillRectangle(fillBrush1, backRect1)
			g.FillRectangle(fillBrush2, backRect2)
		End Using
	End Sub

	Private Sub DrawGradientBorder(g As Graphics, backRect As Rectangle, colors As GradientItemColors)
		' Drawing with anti aliasing to create smoother appearance
		Using uaa As New UseAntiAlias(g)
			Dim backRectI As Rectangle = backRect
			backRectI.Inflate(1, 1)

			' Finally draw the border around the menu item
			Using borderBrush As New LinearGradientBrush(backRectI, colors.Border1, colors.Border2, 90F)
				' Sigma curve, so go from color1 to color2 and back to color1 again
				borderBrush.SetSigmaBellShape(0.5F)

				' Convert the brush to a pen for DrawPath call
				Using borderPen As New Pen(borderBrush)
					' Create border path around the entire item
					Using borderPath As GraphicsPath = CreateBorderPath(backRect, _cutMenuItemBack)
						g.DrawPath(borderPen, borderPath)
					End Using
				End Using
			End Using
		End Using
	End Sub

	Private Sub DrawGripGlyph(g As Graphics, x As Integer, y As Integer, darkBrush As Brush, lightBrush As Brush)
		g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare)
		g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare)
	End Sub

	Private Overloads Sub DrawSeparator(g As Graphics, vertical As Boolean, rect As Rectangle, lightPen As Pen, darkPen As Pen, horizontalInset As Integer, _
		rtl As Boolean)
		If vertical Then
			Dim l As Integer = rect.Width \ 2
			Dim t As Integer = rect.Y
			Dim b As Integer = rect.Bottom

			' Draw vertical lines centered
			g.DrawLine(darkPen, l, t, l, b)
			g.DrawLine(lightPen, l + 1, t, l + 1, b)
		Else
			Dim y As Integer = rect.Height \ 2
			Dim l As Integer = rect.X + (If(rtl, 0, horizontalInset))
			Dim r As Integer = rect.Right - (If(rtl, horizontalInset, 0))

			' Draw horizontal lines centered
			g.DrawLine(darkPen, l, y, r, y)
			g.DrawLine(lightPen, l, y + 1, r, y + 1)
		End If
	End Sub

	Private Function CreateBorderPath(rect As Rectangle, exclude As Rectangle, cut As Single) As GraphicsPath
		' If nothing to exclude, then use quicker method
		If exclude.IsEmpty Then
			Return CreateBorderPath(rect, cut)
		End If

		' Drawing lines requires we draw inside the area we want
		rect.Width -= 1
		rect.Height -= 1

		' Create an array of points to draw lines between
		Dim pts As New List(Of PointF)()

		Dim l As Single = rect.X
		Dim t As Single = rect.Y
		Dim r As Single = rect.Right
		Dim b As Single = rect.Bottom
		Dim x0 As Single = rect.X + cut
		Dim x3 As Single = rect.Right - cut
		Dim y0 As Single = rect.Y + cut
		Dim y3 As Single = rect.Bottom - cut
		Dim cutBack As Single = (If(cut = 0F, 1, cut))

		' Does the exclude intercept the top line
		If (rect.Y >= exclude.Top) AndAlso (rect.Y <= exclude.Bottom) Then
			Dim x1 As Single = exclude.X - 1 - cut
			Dim x2 As Single = exclude.Right + cut

			If x0 <= x1 Then
				pts.Add(New PointF(x0, t))
				pts.Add(New PointF(x1, t))
				pts.Add(New PointF(x1 + cut, t - cutBack))
			Else
				x1 = exclude.X - 1
				pts.Add(New PointF(x1, t))
				pts.Add(New PointF(x1, t - cutBack))
			End If

			If x3 > x2 Then
				pts.Add(New PointF(x2 - cut, t - cutBack))
				pts.Add(New PointF(x2, t))
				pts.Add(New PointF(x3, t))
			Else
				x2 = exclude.Right
				pts.Add(New PointF(x2, t - cutBack))
				pts.Add(New PointF(x2, t))
			End If
		Else
			pts.Add(New PointF(x0, t))
			pts.Add(New PointF(x3, t))
		End If

		pts.Add(New PointF(r, y0))
		pts.Add(New PointF(r, y3))
		pts.Add(New PointF(x3, b))
		pts.Add(New PointF(x0, b))
		pts.Add(New PointF(l, y3))
		pts.Add(New PointF(l, y0))

		' Create path using a simple set of lines that cut the corner
		Dim path As New GraphicsPath()

		' Add a line between each set of points
		For i As Integer = 1 To pts.Count - 1
			path.AddLine(pts(i - 1), pts(i))
		Next

		' Add a line to join the last to the first
		path.AddLine(pts(pts.Count - 1), pts(0))

		Return path
	End Function

	Private Function CreateBorderPath(rect As Rectangle, cut As Single) As GraphicsPath
		' Drawing lines requires we draw inside the area we want
		rect.Width -= 1
		rect.Height -= 1

		' Create path using a simple set of lines that cut the corner
		Dim path As New GraphicsPath()
		path.AddLine(rect.Left + cut, rect.Top, rect.Right - cut, rect.Top)
		path.AddLine(rect.Right - cut, rect.Top, rect.Right, rect.Top + cut)
		path.AddLine(rect.Right, rect.Top + cut, rect.Right, rect.Bottom - cut)
		path.AddLine(rect.Right, rect.Bottom - cut, rect.Right - cut, rect.Bottom)
		path.AddLine(rect.Right - cut, rect.Bottom, rect.Left + cut, rect.Bottom)
		path.AddLine(rect.Left + cut, rect.Bottom, rect.Left, rect.Bottom - cut)
		path.AddLine(rect.Left, rect.Bottom - cut, rect.Left, rect.Top + cut)
		path.AddLine(rect.Left, rect.Top + cut, rect.Left + cut, rect.Top)
		Return path
	End Function

	Private Function CreateInsideBorderPath(rect As Rectangle, cut As Single) As GraphicsPath
		' Adjust rectangle to be 1 pixel inside the original area
		rect.Inflate(-1, -1)

		' Now create a path based on this inner rectangle
		Return CreateBorderPath(rect, cut)
	End Function

	Private Function CreateInsideBorderPath(rect As Rectangle, exclude As Rectangle, cut As Single) As GraphicsPath
		' Adjust rectangle to be 1 pixel inside the original area
		rect.Inflate(-1, -1)

		' Now create a path based on this inner rectangle
		Return CreateBorderPath(rect, exclude, cut)
	End Function

	Private Function CreateClipBorderPath(rect As Rectangle, cut As Single) As GraphicsPath
		' Clipping happens inside the rect, so make 1 wider and taller
		rect.Width += 1
		rect.Height += 1

		' Now create a path based on this inner rectangle
		Return CreateBorderPath(rect, cut)
	End Function

	Private Function CreateClipBorderPath(rect As Rectangle, exclude As Rectangle, cut As Single) As GraphicsPath
		' Clipping happens inside the rect, so make 1 wider and taller
		rect.Width += 1
		rect.Height += 1
		'rect.Inflate(10, 10);
		' Now create a path based on this inner rectangle
		Return CreateBorderPath(rect, exclude, cut)
	End Function

	Private Function CreateArrowPath(item As ToolStripItem, rect As Rectangle, direction As ArrowDirection) As GraphicsPath
		Dim x As Integer, y As Integer

		' Find the correct starting position, which depends on direction
		If (direction = ArrowDirection.Left) OrElse (direction = ArrowDirection.Right) Then
			x = rect.Right - (rect.Width - 4) \ 2
			y = rect.Y + rect.Height \ 2
		Else
			x = rect.X + rect.Width \ 2
			y = rect.Bottom - (rect.Height - 3) \ 2

			' The drop down button is position 1 pixel incorrectly when in RTL
			If (TypeOf item Is ToolStripDropDownButton) AndAlso (item.RightToLeft = RightToLeft.Yes) Then
				x += 1
			End If

			If TypeOf item Is ToolStripDropDownButton Then
				If item.DisplayStyle <> ToolStripItemDisplayStyle.Image Then
					x -= 10
				Else
					x -= 1
				End If

			End If
		End If

		y -= 1

		If LooksPressed(item) Then
			x += 1
			y += 1
		End If



		' Create triangle using a series of lines
		Dim path As New GraphicsPath()

		Dim p1 As PointF, p2 As PointF, p3 As PointF

		Dim mw = 3.5F
		Dim t = 2F
		Dim a = 2F

		Select Case direction
			Case ArrowDirection.Right
				p1 = New PointF(x - t, y - mw)
				p2 = New PointF(x - t, y + mw)
				p3 = New PointF(x + a, y)
				Exit Select
			Case ArrowDirection.Left
				p1 = New PointF(x + t, y - mw)
				p2 = New PointF(x + t, y + mw)
				p3 = New PointF(x - a, y)
				Exit Select
			Case ArrowDirection.Down
				p1 = New PointF(x - mw, y - t)
				p2 = New PointF(x + mw, y - t)
				p3 = New PointF(x, y + a)
				Exit Select
			Case ArrowDirection.Up
				p1 = New PointF(x - mw, y - t)
				p2 = New PointF(x + mw, y - t)
				p3 = New PointF(x, y + a)
				Exit Select
			Case Else
				Throw New Exception()
		End Select




		path.AddLine(p1, p2)
		path.AddLine(p2, p3)
		path.AddLine(p3, p1)

		Return path
	End Function

	Private Function CreateTickPath(rect As Rectangle) As GraphicsPath
		' Get the center point of the rect
		Dim x As Integer = rect.X + rect.Width \ 2
		Dim y As Integer = rect.Y + rect.Height \ 2
		x += 1
		y -= 2

		Dim path As New GraphicsPath()
		path.AddLine(x - 4, y, x - 2, y + 4)
		path.AddLine(x - 2, y + 4, x + 3, y - 5)
		Return path
	End Function

	Private Function CreateIndeterminatePath(rect As Rectangle) As GraphicsPath
		' Get the center point of the rect
		Dim x As Integer = rect.X + rect.Width \ 2
		Dim y As Integer = rect.Y + rect.Height \ 2



		Dim path As New GraphicsPath()
		path.AddLine(x - 3, y, x, y - 3)
		path.AddLine(x, y - 3, x + 3, y)
		path.AddLine(x + 3, y, x, y + 3)
		path.AddLine(x, y + 3, x - 3, y)
		Return path
	End Function
	Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
		target = value
		Return value
	End Function
	#End Region


	'protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
	'{
	'    var b=e.Item;
	'    //base.OnRenderOverflowButtonBackground(e);
	'}



End Class
