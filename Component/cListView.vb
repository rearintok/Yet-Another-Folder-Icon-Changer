
Public Class cListView
    Inherits ListView

    Private ReadOnly lvwColumnSorter As ListViewColumnSorter = Nothing

    Dim FirstRun As Boolean
    'Structure needed to set the listviews background watermark image
    Public Structure LVBKIMAGE
        Public ulFlags As Int32
        Public hbm As IntPtr
        Public pszImage As String
        Public cchImageMax As Int32
        Public xOffsetPercent As Int32
        Public yOffsetPercent As Int32
    End Structure

    Private Const WM_CHANGEUISTATE As Integer = &H127
    Private Const UIS_SET As Integer = 1
    Private Const UISF_HIDEFOCUS As Integer = &H1
    Private Const UISF_ACTIVE As Integer = &H4

    'Constant Declarations
    Private Const LVM_FIRST As Int32 = &H1000
    Private Const LVM_SETBKIMAGEW As Int32 = (LVM_FIRST + 138)
    Private Const LVBKIF_TYPE_WATERMARK As Int32 = &H10000000

    ''' <value>
    ''' Returns true on Windows Vista or newer operating systems; otherwise, false.
    ''' </value>
    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property IsVistaOrLater() As Boolean
        Get
            Return Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6
        End Get
    End Property

    Private Function MakeLong(ByVal wLow As Integer, ByVal wHigh As Integer) As Integer
        Dim low As Integer = CType(IntLoWord(wLow), Integer)
        Dim high As Short = IntLoWord(wHigh)
        Dim product As Integer = &H10000 * CType(high, Integer)
        Dim mkLong As Integer = (low Or product)
        Return mkLong
    End Function

    Private Function IntLoWord(ByVal word As Integer) As Short
        Return CType((word And Short.MaxValue), Short)
    End Function

    '// Function used to set Vista-theming on our listview
    <Runtime.InteropServices.DllImport("uxtheme", CharSet:=Runtime.InteropServices.CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal textSubAppName As String, ByVal textSubIdList As String) As Integer
    End Function


    'API Declarations
    Private Declare Sub CoInitialize Lib "ole32.dll" (ByVal pvReserved As Int32)
    Private Declare Sub CoUninitialize Lib "ole32.dll" ()
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Dim vWatermarkImage As Bitmap
    Dim vWatermarkAlpha As Integer
    Dim vUseVistaThemeing As Boolean = True
    Dim vShowFocusRectangle As Boolean = False
    Dim vColumnSorting As Boolean = False
    Dim vColumnSortBy As ListViewColumnSorter.SortModifiers = ListViewColumnSorter.SortModifiers.SortByText

    Public Property ColumnSortBy() As ListViewColumnSorter.SortModifiers
        Get
            Return vColumnSortBy
        End Get
        Set(ByVal value As ListViewColumnSorter.SortModifiers)
            vColumnSortBy = value
            lvwColumnSorter._SortModifier = value
        End Set
    End Property


    Public Property ColumnSorting As Boolean
        Get
            Return vColumnSorting
        End Get
        Set(ByVal value As Boolean)
            vColumnSorting = value
        End Set
    End Property

    Public Property ShowFocusRectangle As Boolean
        Get
            Return vShowFocusRectangle
        End Get
        Set(ByVal value As Boolean)
            vShowFocusRectangle = value
            If Not value Then
                SendMessage(Handle, WM_CHANGEUISTATE, MakeLong(UIS_SET, UISF_HIDEFOCUS), 0)
            Else
                SendMessage(Handle, WM_CHANGEUISTATE, MakeLong(UIS_SET, UISF_ACTIVE), 0)
            End If
        End Set
    End Property

    Public Property UseVistaThemeing As Boolean
        Get
            Return vUseVistaThemeing
        End Get
        Set(ByVal value As Boolean)
            vUseVistaThemeing = value
            If IsVistaOrLater And value Then
                SetWindowTheme(Handle, "explorer", Nothing)
            Else
                SetWindowTheme(Handle, Nothing, Nothing)
            End If
        End Set
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
                Dim lv As New LVBKIMAGE
                lv.hbm = hBMP
                lv.ulFlags = LVBKIF_TYPE_WATERMARK
                Dim lvPTR As IntPtr = Runtime.InteropServices.Marshal.AllocCoTaskMem(Runtime.InteropServices.Marshal.SizeOf(lv))
                Runtime.InteropServices.Marshal.StructureToPtr(lv, lvPTR, False)
                SendMessage(Handle, LVM_SETBKIMAGEW, 0, lvPTR)
                Runtime.InteropServices.Marshal.FreeCoTaskMem(lvPTR)
            End If
        Else
            Dim lv As New LVBKIMAGE
            lv.hbm = IntPtr.Zero
            lv.ulFlags = LVBKIF_TYPE_WATERMARK
            Dim lvPTR As IntPtr = Runtime.InteropServices.Marshal.AllocCoTaskMem(Runtime.InteropServices.Marshal.SizeOf(lv))
            Runtime.InteropServices.Marshal.StructureToPtr(lv, lvPTR, False)
            SendMessage(Handle, LVM_SETBKIMAGEW, 0, lvPTR)
            Runtime.InteropServices.Marshal.FreeCoTaskMem(lvPTR)
        End If
    End Sub

    Private Function GetBMP(ByVal FromImage As Image) As IntPtr
        Dim bmp As Bitmap = New Bitmap(FromImage.Width, FromImage.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(BackColor)
        g.DrawImage(FromImage, 0, 0, bmp.Width, bmp.Height)
        g.FillRectangle(New SolidBrush(Color.FromArgb(WatermarkAlpha, BackColor.R, BackColor.G, BackColor.B)), New RectangleF(0, 0, bmp.Width, bmp.Height))
        g.Dispose()
        Return bmp.GetHbitmap
        bmp.Dispose()
    End Function

    Public Sub New()
        MyBase.New()
        lvwColumnSorter = New ListViewColumnSorter()
        ListViewItemSorter = lvwColumnSorter
        lvwColumnSorter._SortModifier = vColumnSortBy
        FirstRun = True
        OwnerDraw = True
        WatermarkAlpha = 200
        SetStyle(ControlStyles.Opaque, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.EnableNotifyMessage, True)
        CoInitialize(IntPtr.Zero)
        SetBkImage()
        AddHandler ColumnClick, AddressOf _ColumnClick
    End Sub

    Protected Overrides Sub OnNotifyMessage(ByVal m As Message)
        If (m.Msg <> &H14) Then
            MyBase.OnNotifyMessage(m)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        CoUninitialize()
    End Sub

    Private Sub cListView_DrawColumnHeader(ByVal sender As Object, ByVal e As Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles Me.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub cListView_DrawItem(ByVal sender As Object, ByVal e As Windows.Forms.DrawListViewItemEventArgs) Handles Me.DrawItem
        If WatermarkImage IsNot Nothing Then
            If FirstRun Then
                Application.DoEvents()
                FirstRun = False
            End If
            If View = Windows.Forms.View.Tile Then
                Invalidate()
            End If
            e.DrawDefault = True
            Dim ItemBack As SolidBrush = New SolidBrush(Color.FromArgb(100, e.Item.BackColor.R, e.Item.BackColor.G, e.Item.BackColor.B))
            Dim RC As Rectangle = e.Bounds
            If View = Windows.Forms.View.Details Then
                If RC.Width < ClientRectangle.Width Then
                    RC.Width = ClientRectangle.Width
                End If
            End If
            e.Graphics.FillRectangle(ItemBack, RC)
            ItemBack.Dispose()
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private Sub cListView_DrawSubItem(ByVal sender As Object, ByVal e As Windows.Forms.DrawListViewSubItemEventArgs) Handles Me.DrawSubItem
        e.DrawDefault = True
    End Sub

    Private Sub cListView_HandleCreated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.HandleCreated
        SetBkImage()
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)
        If IsVistaOrLater And UseVistaThemeing Then
            SetWindowTheme(Handle, "explorer", Nothing)
        End If
    End Sub

    Private Sub _ColumnClick(ByVal sender As Object, ByVal e As Windows.Forms.ColumnClickEventArgs)
        If vColumnSorting Then
            Dim myListView As ListView = DirectCast(sender, ListView)

            ' Determine if clicked column is already the column that is being sorted.
            If e.Column = lvwColumnSorter.ColumnToSort Then
                ' Reverse the current sort direction for this column.
                If lvwColumnSorter.OrderOfSort = SortOrder.Ascending Then
                    lvwColumnSorter.OrderOfSort = SortOrder.Descending
                Else
                    lvwColumnSorter.OrderOfSort = SortOrder.Ascending
                End If
            Else
                ' Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.ColumnToSort = e.Column
                lvwColumnSorter.OrderOfSort = SortOrder.Ascending
            End If

            ' Perform the sort with these new sort options.
            myListView.Sort()
        End If
    End Sub

End Class

''' <summary>
''' This class is an implementation of the 'IComparer' interface.
''' </summary>
Public Class ListViewColumnSorter
    Implements IComparer
    Public Enum SortModifiers
        SortByText = 1
        SortByImage = 2
        SortByCheckbox = 3
    End Enum

    ''' <summary>
    ''' Specifies the column to be sorted
    ''' </summary>
    Public ColumnToSort As Integer
    ''' <summary>
    ''' Specifies the order in which to sort (i.e. 'Ascending').
    ''' </summary>
    Public OrderOfSort As SortOrder
    ''' <summary>
    ''' Case insensitive comparer object
    ''' </summary>

    Private ReadOnly ObjectCompare As NumberCaseInsensitiveComparer
    Private ReadOnly FirstObjectCompare As ImageTextComparer
    Private ReadOnly FirstObjectCompare2 As CheckboxTextComparer

    Private mySortModifier As SortModifiers = SortModifiers.SortByText
    Public Property _SortModifier() As SortModifiers
        Get
            Return mySortModifier
        End Get
        Set(value As SortModifiers)
            mySortModifier = value
        End Set
    End Property

    ''' <summary>
    ''' Class constructor.  Initializes various elements
    ''' </summary>
    Public Sub New()
        ' Initialize the column to '0'
        ColumnToSort = 0
        OrderOfSort = SortOrder.Ascending
        ' Initialize the CaseInsensitiveComparer object
        ObjectCompare = New NumberCaseInsensitiveComparer()
        FirstObjectCompare = New ImageTextComparer()
        FirstObjectCompare2 = New CheckboxTextComparer()
    End Sub

    ''' <summary>
    ''' This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    ''' </summary>
    ''' <param name="x">First object to be compared</param>
    ''' <param name="y">Second object to be compared</param>
    ''' <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer = 0
        Dim listviewX As ListViewItem, listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects
        listviewX = DirectCast(x, ListViewItem)
        listviewY = DirectCast(y, ListViewItem)

        Dim listViewMain As ListView = listviewX.ListView

        ' Calculate correct return value based on object comparison
        If listViewMain.Sorting <> SortOrder.Ascending AndAlso listViewMain.Sorting <> SortOrder.Descending Then
            ' Return '0' to indicate they are equal
            Return compareResult
        End If

        If mySortModifier.Equals(SortModifiers.SortByText) OrElse ColumnToSort > 0 Then
            ' Compare the two items

            If listviewX.SubItems.Count <= ColumnToSort AndAlso listviewY.SubItems.Count <= ColumnToSort Then
                compareResult = ObjectCompare.Compare(Nothing, Nothing)
            ElseIf listviewX.SubItems.Count <= ColumnToSort AndAlso listviewY.SubItems.Count > ColumnToSort Then
                compareResult = ObjectCompare.Compare(Nothing, listviewY.SubItems(ColumnToSort).Text.Trim())
            ElseIf listviewX.SubItems.Count > ColumnToSort AndAlso listviewY.SubItems.Count <= ColumnToSort Then
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text.Trim(), Nothing)
            Else
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text.Trim(), listviewY.SubItems(ColumnToSort).Text.Trim())
            End If
        Else
            Select Case mySortModifier
                Case SortModifiers.SortByCheckbox
                    compareResult = FirstObjectCompare2.Compare(x, y)
                    Exit Select
                Case SortModifiers.SortByImage
                    compareResult = FirstObjectCompare.Compare(x, y)
                    Exit Select
                Case Else
                    compareResult = FirstObjectCompare.Compare(x, y)
                    Exit Select
            End Select
        End If

        ' Calculate correct return value based on object comparison
        If OrderOfSort = SortOrder.Ascending Then
            ' Ascending sort is selected, return normal result of compare operation
            Return compareResult
        ElseIf OrderOfSort = SortOrder.Descending Then
            ' Descending sort is selected, return negative result of compare operation
            Return (-compareResult)
        Else
            ' Return '0' to indicate they are equal
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    ''' </summary>
    Public Property SortColumn() As Integer
        Get
            Return ColumnToSort
        End Get
        Set(value As Integer)
            ColumnToSort = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    ''' </summary>
    Public Property Order() As SortOrder
        Get
            Return OrderOfSort
        End Get
        Set(value As SortOrder)
            OrderOfSort = value
        End Set
    End Property

End Class

Public Class ImageTextComparer
    Implements IComparer
    'private CaseInsensitiveComparer ObjectCompare;
    Private ReadOnly ObjectCompare As NumberCaseInsensitiveComparer

    Public Sub New()
        ' Initialize the CaseInsensitiveComparer object
        ObjectCompare = New NumberCaseInsensitiveComparer()
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        'int compareResult;
        Dim image1 As Integer, image2 As Integer
        Dim listviewX As ListViewItem, listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects
        listviewX = DirectCast(x, ListViewItem)
        image1 = listviewX.ImageIndex
        listviewY = DirectCast(y, ListViewItem)
        image2 = listviewY.ImageIndex

        If image1 < image2 Then
            Return -1
        ElseIf image1 = image2 Then
            Return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim())
        Else
            Return 1
        End If
    End Function
End Class

Public Class CheckboxTextComparer
    Implements IComparer
    Private ReadOnly ObjectCompare As NumberCaseInsensitiveComparer

    Public Sub New()
        ' Initialize the CaseInsensitiveComparer object
        ObjectCompare = New NumberCaseInsensitiveComparer()
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        ' Cast the objects to be compared to ListViewItem objects
        Dim listviewX As ListViewItem = DirectCast(x, ListViewItem)
        Dim listviewY As ListViewItem = DirectCast(y, ListViewItem)

        If listviewX.Checked AndAlso Not listviewY.Checked Then
            Return -1
        ElseIf listviewX.Checked.Equals(listviewY.Checked) Then
            If listviewX.ImageIndex < listviewY.ImageIndex Then
                Return -1
            ElseIf listviewX.ImageIndex = listviewY.ImageIndex Then
                Return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim())
            Else
                Return 1
            End If
        Else
            Return 1
        End If
    End Function
End Class


Public Class NumberCaseInsensitiveComparer
    Inherits CaseInsensitiveComparer

    Public Sub New()
    End Sub

    Public Shadows Function Compare(x As Object, y As Object) As Integer
        If x Is Nothing AndAlso y Is Nothing Then
            Return 0
        ElseIf x Is Nothing AndAlso y IsNot Nothing Then
            Return -1
        ElseIf x IsNot Nothing AndAlso y Is Nothing Then
            Return 1
        End If
        If (TypeOf x Is System.String) AndAlso IsWholeNumber(DirectCast(x, String)) AndAlso (TypeOf y Is System.String) AndAlso IsWholeNumber(DirectCast(y, String)) Then
            Try
                Return MyBase.Compare(Convert.ToUInt64(DirectCast(x, String).Trim()), Convert.ToUInt64(DirectCast(y, String).Trim()))
            Catch
                Return -1
            End Try
        Else
            Return MyBase.Compare(x, y)
        End If
    End Function

    Private Function IsWholeNumber(strNumber As String) As Boolean
        Dim wholePattern As New System.Text.RegularExpressions.Regex("^\d+$")
        Return wholePattern.IsMatch(strNumber)
    End Function
End Class
