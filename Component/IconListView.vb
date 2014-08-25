Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Partial Public Class IconListView
    Inherits ListView
    Private Const minWidth As Integer = 16
    Private Const textHeight As Integer = 5
    Private Const verticalSpacing As Integer = 4
    Private ReadOnly TilePadding As Padding

    'Structure needed to set the listviews background watermark image
    Public Structure LVBKIMAGE
        Public ulFlags As Int32
        Public hbm As IntPtr
        Public pszImage As String
        Public cchImageMax As Int32
        Public xOffsetPercent As Int32
        Public yOffsetPercent As Int32
    End Structure

    'Constant Declarations
    Private Const LVM_FIRST As Int32 = &H1000
    Private Const LVM_SETBKIMAGEW As Int32 = (LVM_FIRST + 138)
    Private Const LVBKIF_TYPE_WATERMARK As Int32 = &H10000000

    'API Declarations
    Private Declare Sub CoInitialize Lib "ole32.dll" (ByVal pvReserved As Int32)
    Private Declare Sub CoUninitialize Lib "ole32.dll" ()
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Dim vWatermarkImage As Bitmap
    Dim vWatermarkAlpha As Integer

    ''' <value>
    ''' Returns true on Windows Vista or newer operating systems; otherwise, false.
    ''' </value>
    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property IsVistaOrLater() As Boolean
        Get
            Return Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6
        End Get
    End Property
    
    <Configuration.DefaultSettingValue("200")> _
    Public Property WatermarkAlpha() As Integer
        Get
            Return vWatermarkAlpha
        End Get

        Set(ByVal value As Integer)
            vWatermarkAlpha = value
            SetBkImage()
        End Set
    End Property

    Public Property WatermarkImage() As Bitmap
        Get
            Return vWatermarkImage
        End Get
        Set(ByVal value As Bitmap)
            vWatermarkImage = value
            SetBkImage()
        End Set
    End Property

    Private Sub SetBkImage()
        If Not WatermarkImage Is Nothing Then
            Dim hBMP As IntPtr = GetBMP(WatermarkImage)
            If Not hBMP = IntPtr.Zero Then
                Dim lv As New IconListView.LVBKIMAGE
                lv.hbm = hBMP
                lv.ulFlags = LVBKIF_TYPE_WATERMARK
                Dim lvPTR As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(lv))
                Marshal.StructureToPtr(lv, lvPTR, False)
                SendMessage(Me.Handle, LVM_SETBKIMAGEW, 0, lvPTR)
                Marshal.FreeCoTaskMem(lvPTR)
            End If
        Else
            Dim lv As New IconListView.LVBKIMAGE
            lv.hbm = IntPtr.Zero
            lv.ulFlags = LVBKIF_TYPE_WATERMARK
            Dim lvPTR As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(lv))
            Marshal.StructureToPtr(lv, lvPTR, False)
            SendMessage(Me.Handle, LVM_SETBKIMAGEW, 0, lvPTR)
            Marshal.FreeCoTaskMem(lvPTR)
        End If

    End Sub

    Private Function GetBMP(ByVal FromImage As Image) As IntPtr
        Dim bmp As Bitmap = New Bitmap(FromImage.Width, FromImage.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.Clear(Me.BackColor)
        g.DrawImage(FromImage, 0, 0, bmp.Width, bmp.Height)
        g.FillRectangle(New SolidBrush(Color.FromArgb(WatermarkAlpha, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)), New RectangleF(0, 0, bmp.Width, bmp.Height))
        g.Dispose()
        Return bmp.GetHbitmap
        bmp.Dispose()
    End Function

    Public Sub New()
        InitializeComponent()

        If IsVistaOrLater Then
            TilePadding = New Padding(3, 0, 3, 0)
        Else
            TilePadding = New Padding(3, 1, 3, 1)
        End If

        MyBase.View = View.Tile
        Me.TileSize = MyBase.TileSize
        MyBase.OwnerDraw = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.WatermarkAlpha = 200
        CoInitialize(IntPtr.Zero)
        SetBkImage()

        AddHandler MyBase.DrawItem, New DrawListViewItemEventHandler(AddressOf IconListView_DrawItem)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        CoUninitialize()
    End Sub

    Private Sub cListView_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        SetBkImage()
    End Sub

    Private _tileSize As Size
    Public Shadows Property TileSize() As Size
        Get
            Return _tileSize
        End Get
        Set(value As Size)
            _tileSize = value
            MyBase.BeginUpdate()
            MyBase.TileSize = New Size(Math.Max(minWidth, value.Width) + TilePadding.Horizontal, value.Height + verticalSpacing + TilePadding.Vertical)
            If MyBase.Items.Count <> 0 Then
                Dim list As New List(Of IconListViewItem)(MyBase.Items.Count)
                list.AddRange(MyBase.Items.Cast(Of IconListViewItem)())
                MyBase.Items.Clear()
                For Each item As IconListViewItem In list
                    MyBase.Items.Add(item)
                    'MyBase.RedrawItems(0, MyBase.Items.Count - 1, False)
                Next
            End If

            MyBase.EndUpdate()
        End Set
    End Property

    Private Sub IconListView_DrawItem(sender As Object, e As DrawListViewItemEventArgs)
        Dim item As IconListViewItem = TryCast(e.Item, IconListViewItem)
        If item Is Nothing Then
            e.DrawDefault = True
            Return
        End If

        'draw item
        e.DrawBackground()
        Dim border As Pen = SystemPens.ControlLight
        If e.Item.Selected Then
            If Me.Focused Then
                border = SystemPens.Highlight
            Else
                border = SystemPens.MenuHighlight
            End If
        End If
        Dim centerSpacing As Integer = (e.Bounds.Width - Me.TileSize.Width - TilePadding.Horizontal) \ 2 + TilePadding.Left
        Dim newBounds As New Rectangle(e.Bounds.X + centerSpacing, e.Bounds.Y + TilePadding.Top, Me.TileSize.Width, Me.TileSize.Height)
        e.Graphics.DrawRectangle(border, newBounds)

        'e.Graphics.DrawString("Whatever", this.Font, e., 0, 0);
        Dim x As Integer = e.Bounds.X + (newBounds.Width - item.Icon.Width) \ 2 + centerSpacing + 1
        Dim y As Integer = e.Bounds.Y + (newBounds.Height - item.Icon.Height) \ 2 + TilePadding.Top + 1
        Dim rect As New Rectangle(x, y, item.Icon.Width, item.Icon.Height)
        Dim clipReg As New Region(newBounds)
        e.Graphics.Clip = clipReg
        e.Graphics.DrawIcon(item.Icon, rect)

        'Dim text As String = String.Format("{0} x {1}", item.Icon.Width, item.Icon.Height)
        'Dim stringSize As SizeF = e.Graphics.MeasureString(Text, Me.Font)
        'Dim stringWidth As Integer = CInt(Math.Truncate(Math.Round(stringSize.Width)))
        'Dim stringHeight As Integer = CInt(Math.Truncate(Math.Round(stringSize.Height)))
        'x = e.Bounds.X + (e.Bounds.Width - stringWidth - TilePadding.Horizontal) \ 2 + TilePadding.Left
        'y = e.Bounds.Y + Me.TileSize.Height + verticalSpacing + TilePadding.Top
        'clipReg = New Region(e.Bounds)
        'e.Graphics.Clip = clipReg
        'If e.Item.Selected Then
        'If Me.Focused Then
        'e.Graphics.FillRectangle(SystemBrushes.Highlight, x - 1, y - 1, stringWidth + 2, stringSize.Height + 2)
        'e.Graphics.DrawString(text, Me.Font, SystemBrushes.HighlightText, x, y)
        'Else
        'e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, x - 1, y - 1, stringWidth + 2, stringSize.Height + 2)
        'e.Graphics.DrawString(text, Me.Font, SystemBrushes.ControlText, x, y)
        'End If
        'Else
        'TextRenderer.DrawText(e.Graphics, text, Font, New Rectangle(x, y, ClientRectangle.Width, ClientRectangle.Height), ForeColor, TextFormatFlags.Default)
        'e.Graphics.DrawString(text, Me.Font, SystemBrushes.ControlText, x, y)
        'End If
    End Sub
End Class
Public Class IconListViewItem
	Inherits ListViewItem
	Private _icon As Icon
	Public Property Icon() As Icon
		Get
			Return _icon
		End Get
		Set
			_icon = value
		End Set
	End Property
End Class
