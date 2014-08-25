
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports LukeSw.Windows.Forms
Imports Microsoft.Win32

Module mFunctions

    <Flags()>
    Public Enum HChangeNotifyFlags
        SHCNF_DWORD = &H3
        SHCNF_IDLIST = &H0
        SHCNF_PATHA = &H1
        SHCNF_PATHW = &H5
        SHCNF_PRINTERA = &H2
        SHCNF_PRINTERW = &H6
        SHCNF_FLUSH = &H1000
        SHCNF_FLUSHNOWAIT = &H2000
    End Enum

    <Flags()>
    Public Enum HChangeNotifyEventID
        SHCNE_ALLEVENTS = &H7FFFFFFF
        SHCNE_ASSOCCHANGED = &H8000000
        SHCNE_ATTRIBUTES = &H800
        SHCNE_CREATE = &H2
        SHCNE_DELETE = &H4
        SHCNE_DRIVEADD = &H10
        SHCNE_DRIVEADDGUI = &H10000
        SHCNE_DRIVEREMOVED = &H80
        SHCNE_EXTENDED_EVENT = &H4000000
        SHCNE_FREESPACE = &H40000
        SHCNE_MEDIAINSERTED = &H20
        SHCNE_MEDIAREMOVED = &H40
        SHCNE_MKDIR = &H8
        SHCNE_NETSHARE = &H200
        SHCNE_NETUNSHARE = &H400
        SHCNE_RENAMEFOLDER = &H20000
        SHCNE_RENAMEITEM = &H1
        SHCNE_RMDIR = &H10
        SHCNE_SERVERDISCONNECT = &H4000
        SHCNE_UPDATEDIR = &H1000
        SHCNE_UPDATEIMAGE = &H8000
    End Enum

    <DllImport("shell32.dll")>
    Sub SHChangeNotify(ByVal wEventID As HChangeNotifyEventID, ByVal uFlags As HChangeNotifyFlags, ByVal dwItem1 As IntPtr, ByVal dwItem2 As IntPtr)
    End Sub

    <DllImport("Shell32.dll", CharSet:=CharSet.Auto)>
    Function SHGetSetFolderCustomSettings(ByRef pfcs As LPSHFOLDERCUSTOMSETTINGS, pszPath As String, dwReadWrite As UInt32) As UInt32
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Structure LPSHFOLDERCUSTOMSETTINGS
        Public dwSize As UInt32
        Public dwMask As UInt32
        Public pvid As IntPtr
        Public pszWebViewTemplate As String
        Public cchWebViewTemplate As UInt32
        Public pszWebViewTemplateVersion As String
        Public pszInfoTip As String
        Public cchInfoTip As UInt32
        Public pclsid As IntPtr
        Public dwFlags As UInt32
        Public pszIconFile As String
        Public cchIconFile As UInt32
        Public iIconIndex As Integer
        Public pszLogo As String
        Public cchLogo As UInt32
    End Structure

    Public Enum DirectoryAction
        ChangeFolderIcon = 1
        RestoreFolderIcon = 2
    End Enum

    Public Enum FolderAction
        SingleFolder = 1
        MultipleFolder = 2
    End Enum

    Public pPreferences As New clsINI
    Public Const MyEnvironmentVariable = "YAFIC_DIR"
    Public RegKey As RegistryKey = Nothing
    Public MajorVersion As Integer = Environment.OSVersion.Version.Major
    Public fDialog As New VDialog()

    'Uncheck all menu items in this menu except checked_item.
    Public Sub CheckMenuItem(ByVal mnu As ToolStripMenuItem, ByVal checked_item As ToolStripMenuItem)
        'Uncheck the menu items except checked_item.
        For Each menu_item As ToolStripMenuItem In mnu.DropDownItems.OfType(Of ToolStripMenuItem)()
            menu_item.Checked = (menu_item Is checked_item)
        Next
    End Sub

    Public Sub LoadIconFromLibrary(ByVal IconFile As String, ByVal lv As IconListView)
        Try
            lv.Items.Clear()
            If IconFile Is Nothing Then
                Return
            End If
            Dim ExtractedIcons As List(Of Icon)

            ExtractedIcons = IconHelper.ExtractAllIcons(IconFile)
            lv.Refresh()
            For Each ic As Icon In ExtractedIcons
                Dim item As New IconListViewItem()
                item.Icon = ic
                lv.Items.Add(item)
                item.Tag = ic
            Next
            Return
        Catch exp As Exception
            MsgBox(exp.Message)
            Return
        End Try
    End Sub

    Public Function LoadIconContainer(ByVal iconfile As String, ByVal lv As IconListView, ByVal IconSize As Size)
        Dim extractedIcons As List(Of Icon)
        Try
            lv.Items.Clear()
            extractedIcons = IconHelper.ExtractAllIcons(iconfile)
            lv.Refresh()
            For i As Integer = 0 To extractedIcons.Count - 1
                Dim ic As Icon = IconHelper.GetBestFitIcon(extractedIcons(i), IconSize)
                Dim item As New IconListViewItem()
                item.Icon = ic
                lv.Items.Add(item)
                item.Tag = extractedIcons(i)
            Next
            Return True
        Catch exp As Exception
            Console.WriteLine(exp.Message)
            Return False
        End Try

    End Function

    Public Sub FillIconListView(icon As Icon, ByVal lv As IconListView)
        lv.Items.Clear()
        If icon Is Nothing Then
            Return
        End If
        Dim l As List(Of Icon) = IconHelper.SplitGroupIcon(icon)
        For Each icn As Icon In l
            Dim item As New IconListViewItem()
            item.Name = lv.Items.Count.ToString().PadLeft(5, "0"c)
            item.Icon = icn
            lv.Items.Add(item)
        Next
    End Sub
    
    Public Function GetFriendlyBitDepth(pixelFormat__1 As PixelFormat) As String
        Select Case pixelFormat__1
            Case PixelFormat.Format1bppIndexed
                Return "1-Bit B/W"
            Case PixelFormat.Format24bppRgb
                Return "24-Bit True Colors"
            Case PixelFormat.Format32bppArgb, PixelFormat.Format32bppRgb
                Return "32-Bit Alpha Channel"
            Case PixelFormat.Format8bppIndexed
                Return "8-Bit 256 Colors"
            Case PixelFormat.Format4bppIndexed
                Return "4-Bit 16 Colors"
        End Select
        Return "Unknown"
    End Function

    Public Function DrawReflection(img As Image, toBG As Color, Optional ReflectHeight As Integer = 30) As Image
        Dim height As Integer = img.Height + ReflectHeight
        Dim bmp As New Bitmap(img.Width, height, PixelFormat.Format64bppPArgb)
        Dim brsh As Brush = New LinearGradientBrush(New Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode.Vertical)
        bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution)
        Using grfx As Graphics = Graphics.FromImage(bmp)
            Dim bm As Bitmap = CType(img, Bitmap)
            grfx.DrawImage(bm, 0, 0, img.Width, img.Height)
            Dim bm1 As Bitmap = CType(img, Bitmap)
            bm1.RotateFlip(RotateFlipType.Rotate180FlipX)
            grfx.DrawImage(bm1, 0, img.Height)
            Dim rt As New Rectangle(0, img.Height, img.Width, 100)
            grfx.FillRectangle(brsh, rt)
        End Using
        Return bmp
    End Function

    Public Function IsListBoxEmpty(ByVal lb As ListBox) As Boolean
        If lb.Items.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
