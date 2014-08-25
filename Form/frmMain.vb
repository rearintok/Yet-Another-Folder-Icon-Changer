Option Explicit On

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Drawing2D
Imports LukeSw.Windows.Forms
Imports Microsoft.Win32

Public Class frmMain

    Dim mouseIndex As Integer = -1
    Public SelectedListView As ListView
    Private SelectedIconContainer As String
    Private SplitterWidth As Integer
    
    Private ReadOnly IconFolderContainer As String = Path.Combine(Application.StartupPath, "Icons", "folder.icl")
    Private ReadOnly IconSoftwareContainer As String = Path.Combine(Application.StartupPath, "Icons", "software.icl")
    Private ReadOnly IconMoviesTVContainer As String = Path.Combine(Application.StartupPath, "Icons", "tvseries.icl")

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'add 
        Const strReg = "SYSTEM\CurrentControlSet\Control\Session Manager\Environment"
        Dim RegKey As RegistryKey
        Dim keyExist As RegistryKey = Registry.LocalMachine.OpenSubKey(strReg)
        If keyExist IsNot Nothing Then
            If keyExist.GetValue("YAFIC_DIR") Is Nothing Then
                RegKey = Registry.LocalMachine.CreateSubKey(strReg, RegistryKeyPermissionCheck.ReadWriteSubTree)
                RegKey.SetValue("YAFIC_DIR", Application.StartupPath)
                RegKey.Close()
            End If
        End If

        'add handlers to other controls with the same functions
        For Each item As ToolStripMenuItem In From mnu_items In mnuLanguage.DropDownItems.OfType(Of ToolStripMenuItem)() Where mnu_items.Name IsNot "mnuEnglish"
            AddHandler item.Click, AddressOf mnuEnglish_Click
        Next

        AddHandler mnuMultipleFolders.Click, AddressOf mnuSingleFolder_Click
        AddHandler cmnuBrowse.Click, AddressOf btnBrowse_Click
        AddHandler mnuBrowse.Click, AddressOf btnBrowse_Click
        AddHandler mnuRemoveFolder.Click, AddressOf btnRemove_Click
        AddHandler cmnuRemoveFolder.Click, AddressOf btnRemove_Click
        AddHandler mnuClean.Click, AddressOf btnClean_Click
        AddHandler cmnuClean.Click, AddressOf btnClean_Click
        AddHandler mnuExit.Click, AddressOf btnExit_Click
        AddHandler mnuApply.Click, AddressOf btnApply_Click

        'apply renderer
        mainMenu.Renderer = New MyRenderer
        StatusStrip.Renderer = New MyRenderer
        cMenu.Renderer = New MyRenderer
        cIconList.Renderer = New MyRenderer
        Application.DoEvents()
        LoadIconFromLibrary(IconFolderContainer, ilvMain)
        'LoadIconFromLibrary(IconSoftwareContainer, ilvSoftware)
        'LoadIconFromLibrary(IconMoviesTVContainer, ilvMovies)
        SelectedListView = ilvMain

        'apply settings
        pPreferences.FileName = Path.Combine(Application.StartupPath, "settings.ini")
        mnuDistributable.Checked = pPreferences.ReadString("General", "Distributable", True)
        mnuIncludeSubfolders.Checked = pPreferences.ReadString("General", "IncludeSubfolders", True)
    End Sub

    Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApply.Click

        If lstFolder.Items.Count > 0 Then
            If SelectedListView.SelectedIndices.Count < 1 Then
                MsgBox("please select an icon")
                Exit Sub
            Else
                For i As Integer = 0 To lstFolder.Items.Count - 1
                    ProcessDirectory(SelectedListView, lstFolder.Items(i).ToString(), mnuDistributable.Checked, mnuIncludeSubfolders.Checked)
                Next

                With fDialog
                    .Owner = Me
                    .WindowTitle = My.Application.Info.Title
                    .Content = "Folder(s) Icon are successfully changed."
                    .CustomMainIcon = My.Resources.OK
                    .Buttons = New VDialogButton() {New VDialogButton(VDialogResult.Close, "Done...")}
                    .Show()
                End With
            End If
        Else
            With fDialog
                .Owner = Me
                .WindowTitle = My.Application.Info.Title
                ' .MainInstruction = "Agdgsd"
                .Content = "A list of folder for customizing the icon is empty." & vbCrLf & "Please select at least one valid folder to the list."
                .CustomMainIcon = My.Resources.Cancel
                .Buttons = New VDialogButton() {New VDialogButton(VDialogResult.OK, "Browse..."), New VDialogButton(VDialogResult.Cancel)}
                .Show()
            End With

            If fDialog.Result = VDialogResult.OK Then
                btnBrowse.PerformClick()
            End If

        End If
    End Sub

    Public Sub DoVistaLater(ByVal target As String, ByVal IconFile As String, Optional ByVal IconIndex As Integer = 0)
        Dim FolderSettings As New LPSHFOLDERCUSTOMSETTINGS()
        FolderSettings.dwMask = &H10
        FolderSettings.pszIconFile = IconFile
        FolderSettings.iIconIndex = IconIndex
        Const FCS_READ As UInteger = &H1
        Const FCS_FORCEWRITE As UInteger = &H2
        Const FCS_WRITE As UInteger = FCS_READ Or FCS_FORCEWRITE
        Dim pszPath As String = target
        SHGetSetFolderCustomSettings(FolderSettings, pszPath, FCS_WRITE)
    End Sub

    Public Sub ProcessDirectory(ByVal ilv As IconListView, ByVal target As String, ByVal IncludeIcon As Boolean, Optional ByVal IncludeSubFolders As Boolean = True, Optional ByVal FolderDepth As Integer = 0)

        Dim folder As DirectoryInfo
        Dim iconfilename, iconindex As String
        Try
            Dim item As Icon = TryCast(ilv.SelectedItems(0).Tag, Icon)
            If item IsNot Nothing Then
                iconfilename = "folder.ico"
                folder = New DirectoryInfo(target)
                'delete icon if the same filename exist in target directory
                Dim filename As String = Path.Combine(target, iconfilename)
                If File.Exists(filename) Then File.Delete(filename)
                'check if to extract the icon from the container or not
                If IncludeIcon = True Then
                    'extract icon from icon container
                    Dim ficon As Icon = item
                    Dim fs As FileStream = File.Create(filename)
                    ficon.Save(fs)
                    fs.Close()
                    iconindex = 0
                Else
                    iconfilename = SelectedIconContainer
                    iconindex = ilv.SelectedItems(0).Index
                End If

                If MajorVersion <= 5 Then 'for windows XP & lower
                    MakeDesktopINI(target, iconfilename, iconindex)
                Else 'for windows vista & later
                    Dim inifilename As New FileInfo(Path.Combine(target, "desktop.ini"))
                    If inifilename.Exists Then inifilename.Delete()
                    DoVistaLater(target, iconfilename, iconindex)
                End If
                'check if to include all the subfolders
                If IncludeSubFolders Then
                    Dim subDirectoryEntries As String() = Directory.GetDirectories(target)
                    If subDirectoryEntries.Length > 0 Then
                        For Each subDirectory As String In subDirectoryEntries
                            ProcessDirectory(ilv, subDirectory, mnuDistributable.Checked, mnuIncludeSubfolders.Checked)
                        Next
                    End If
                End If
                'update the folder attributes
                folder.Attributes = folder.Attributes Or FileAttributes.System
                folder.Refresh()
                'hide the icon
                If File.Exists(filename) Then File.SetAttributes(filename, File.GetAttributes(filename) Or FileAttributes.Hidden)
            End If
            SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Public Sub MakeDesktopINI(ByVal target As String, ByVal IconFile As String, Optional ByVal IconIndex As Integer = 0)

        Dim folder As DirectoryInfo
        Dim filename As String = "desktop.ini"

        If Not Directory.Exists(target) Then
            MsgBox("Directory Does not Exist")
        End If
        Try
            folder = New DirectoryInfo(target)
            filename = Path.Combine(target, filename)
            File.Delete(filename)
            Using sw As New StreamWriter(filename)
                sw.WriteLine("[.ShellClassInfo]")
                sw.WriteLine("IconFile={0}", IconFile)
                sw.WriteLine("IconIndex={0}", IconIndex)
                sw.Close()
            End Using
            'update the folder attributes
            folder.Attributes = folder.Attributes Or FileAttributes.System
            folder.Refresh()
            'hide the desktop.ini
            File.SetAttributes(filename, File.GetAttributes(filename) Or FileAttributes.Hidden)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub RestoreFolderIcon(target As String, Optional ByVal IncludesubFolders As Boolean = True)
        Dim folder As DirectoryInfo
        Try
            folder = New DirectoryInfo(target)

            'remove the file [desktop.ini & folder.ico]
            If File.Exists(Path.Combine(target, "desktop.ini")) Then File.Delete(Path.Combine(target, "desktop.ini"))
            If File.Exists(Path.Combine(target, "folder.ico")) Then File.Delete(Path.Combine(target, "folder.ico"))

            'recurse through the subfolders
            If IncludesubFolders Then
                Dim subDirectoryEntries As String() = Directory.GetDirectories(target)
                If subDirectoryEntries.Length > 0 Then
                    For Each subDirectory As String In subDirectoryEntries
                        RestoreFolderIcon(subDirectory)
                    Next
                End If
            End If

            folder.Attributes = (folder.Attributes Or FileAttributes.System)
            SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shared Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
    
    Private Sub mnuAbout_Click(sender As System.Object, e As EventArgs) Handles mnuAbout.Click
        frmAbout.ShowDialog()
        frmAbout.Dispose()
    End Sub
    
    Private Sub btnBrowse_Click(sender As System.Object, e As EventArgs) Handles btnBrowse.Click
        If fFolder.ShowDialog = DialogResult.OK Then
            If Not lstFolder.Items.Contains(fFolder.SelectedPath) Then
                lstFolder.Items.Add(fFolder.SelectedPath.ToString())
            End If
        End If
        btnClean.Enabled = IsListBoxEmpty(lstFolder)
    End Sub

    Private Sub mnuTip_Click(sender As System.Object, e As EventArgs) Handles mnuTip.Click
        ' frmTip.ShowDialog()
        '  frmTip.Dispose()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As EventArgs) Handles btnRemove.Click
        For x As Integer = lstFolder.SelectedIndices.Count - 1 To 0 Step -1
            Dim idx As Integer = lstFolder.SelectedIndices(x)
            lstFolder.Items.RemoveAt(idx)
        Next
        btnClean.Enabled = IsListBoxEmpty(lstFolder)
    End Sub

    Private Sub btnClean_Click(sender As System.Object, e As EventArgs) Handles btnClean.Click
        lstFolder.Items.Clear()
        btnClean.Enabled = IsListBoxEmpty(lstFolder)
        btnRemove.Enabled = IsListBoxEmpty(lstFolder)
    End Sub
    
    Private Sub mnuPreferences_Click(sender As System.Object, e As EventArgs) Handles mnuPreferences.Click
        frmPreferences.ShowDialog()
        frmPreferences.Dispose()
    End Sub

    Private Sub mnuDistributable_Click(sender As System.Object, e As EventArgs) Handles mnuDistributable.Click
        pPreferences.WriteString("General", "Distributable", mnuDistributable.Checked)
    End Sub

    Private Sub mnuIncludeSubfolders_Click(sender As System.Object, e As EventArgs) Handles mnuIncludeSubfolders.Click
        pPreferences.WriteString("General", "IncludeSubfolders", mnuIncludeSubfolders.Checked)
    End Sub

    Private Sub mnuDownloadFolderIconPacks_Click(sender As System.Object, e As EventArgs) Handles mnuDownloadFolderIconPacks.Click
        frmTest.ShowDialog()
    End Sub

    Private Sub lstFolder_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles lstFolder.DragDrop
        'transfer the folder to a string array
        'yes, everything to the left of the "=" can be put in the 
        'for each loop in place of "folder", but this is easier to understand.
        Dim directories As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
        'loop through the string array, check if folder exist then adding each folder to the ListBox
        For Each folder As String In From folders In directories Where Directory.Exists(folders)
            If Not lstFolder.Items.Contains(folder.ToString()) Then
                lstFolder.Items.Add(folder.ToString())
            End If
        Next
        btnClean.Enabled = IsListBoxEmpty(lstFolder)
    End Sub

    Private Shared Sub lstFolder_DragEnter(sender As Object, e As Windows.Forms.DragEventArgs) Handles lstFolder.DragEnter
        'make sure they're actually dropping files (not text or anything else)
        If e.Data.GetDataPresent(DataFormats.FileDrop, False) = True Then
            'allow them to continue
            '(without this, the cursor stays a "NO" symbol
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lstFolder_DrawItem(sender As Object, e As Windows.Forms.DrawItemEventArgs) Handles lstFolder.DrawItem
        If e.Index = -1 Then Exit Sub
        Dim listBox As Windows.Forms.ListBox = CType(sender, Windows.Forms.ListBox)
        e.DrawBackground()
        Dim isItemSelected As Boolean = ((e.State And DrawItemState.Selected) = DrawItemState.Selected)
        If e.Index >= 0 AndAlso e.Index < listBox.Items.Count Then
            Dim textSize As SizeF = e.Graphics.MeasureString(listBox.Items(e.Index).ToString(), listBox.Font)
            Dim itemImage As Image = My.Resources.FolderHorizontal
            'set background and text color
            Dim backgroundColorBrush As New SolidBrush(If((isItemSelected), Color.CornflowerBlue, Color.White))
            Dim itemTextColorBrush As Color = If((isItemSelected), Color.White, Color.Black)

            If mouseIndex > -1 AndAlso mouseIndex = e.Index AndAlso Not isItemSelected Then
                backgroundColorBrush = New SolidBrush(Color.FromArgb(233, 245, 255))
                itemTextColorBrush = Color.Black
            End If

            e.Graphics.FillRectangle(backgroundColorBrush, e.Bounds)
            'draw the item image
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            e.Graphics.DrawImage(itemImage, e.Bounds.X + 2, e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2, itemImage.Width, itemImage.Height)
            'draw the item text
            Dim x, y As Single
            Dim h As Single = textSize.Height
            Dim rect As Rectangle = e.Bounds
            rect.X += listBox.ItemHeight
            rect.Width -= listBox.ItemHeight

            x = rect.X - 3
            y = rect.Y + (rect.Height - h) / 2

            Dim itemText As String = listBox.Items(e.Index).ToString()
            TextRenderer.DrawText(e.Graphics, itemText, e.Font, New Rectangle(x, y, ClientRectangle.Width, ClientRectangle.Height), itemTextColorBrush, TextFormatFlags.Default)
            'clean up
            backgroundColorBrush.Dispose()
        End If
        e.DrawFocusRectangle()
    End Sub
    
    Private Sub lstFolder_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lstFolder.MouseMove
        Dim listBox As Windows.Forms.ListBox = CType(sender, Windows.Forms.ListBox)
        Dim index As Integer = listBox.IndexFromPoint(e.Location)
        If index <> mouseIndex Then
            If mouseIndex > -1 Then
                Dim oldIndex As Integer = mouseIndex
                mouseIndex = -1
                If oldIndex <= listBox.Items.Count - 1 Then
                    listBox.Invalidate(listBox.GetItemRectangle(oldIndex))
                End If
            End If
            mouseIndex = index
            If mouseIndex > -1 Then
                listBox.Invalidate(listBox.GetItemRectangle(mouseIndex))
            End If
        End If
    End Sub

    Private Sub cmnuPasteClipboard_Click(sender As System.Object, e As EventArgs) Handles cmnuPasteClipboard.Click
        Dim directories As String() = CType(Clipboard.GetData(Windows.Forms.DataFormats.FileDrop), String())
        'loop through the string array, check if folder exist then adding each folder to the ListBox
        For Each folder As String In From folders In directories Where Directory.Exists(folders)
            If Not lstFolder.Items.Contains(folder.ToString()) Then
                lstFolder.Items.Add(folder.ToString())
            End If
        Next
    End Sub

    Private Sub mnuRestoreIcon_Click(sender As System.Object, e As EventArgs) Handles mnuRestoreIcon.Click
        If lstFolder.Items.Count > 0 Then
            For i As Integer = 0 To lstFolder.Items.Count - 1
                RestoreFolderIcon(lstFolder.Items(i).ToString())
            Next
        Else
            MsgBox("Please select a folder")
        End If
    End Sub

    Private Shared Sub mnuRefreshSystemIcons_Click(sender As System.Object, e As EventArgs) Handles mnuRefreshSystemIcons.Click
        Dim myprocess As New Process()
        myprocess.StartInfo.FileName = Path.Combine(Environment.SystemDirectory, "ie4uinit.exe")
        myprocess.StartInfo.Arguments = "-ClearIconCache"
        myprocess.Start()
    End Sub

    Private Sub ilvMain_Enter(sender As Object, e As EventArgs) Handles ilvMain.Enter
        SelectedListView = ilvMain
        SelectedIconContainer = IconFolderContainer
    End Sub

    Private Sub btnIconNew_Click(sender As System.Object, e As EventArgs) Handles btnIconNew.Click
        Dim result As DialogResult = iconDialog.ShowDialog(Me)
        If result <> DialogResult.OK Then
            Return
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        ' Dim i As Integer
        ' For i = 0 To lstFolder.Items.Count - 1
        'MsgBox(lstFolder.Items(i).ToString)
        'Next i
        ' Dim item As String = TryCast(ilvMain.SelectedItems(0).Tag, String)
        MsgBox(ilvMain.SelectedItems(0).Index.ToString())
    End Sub

    Private Sub mnuEnglish_Click(sender As System.Object, e As EventArgs) Handles mnuEnglish.Click
        'check the menu item.
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        CheckMenuItem(mnuLanguage, item)

        MsgBox(item.Tag)
    End Sub

    Private Sub mnuChangeSystemFolderIcon_Click(sender As System.Object, e As EventArgs) Handles mnuChangeSystemFolderIcon.Click
        Const strReg = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons"
        RegKey = Registry.LocalMachine.CreateSubKey(strReg, RegistryKeyPermissionCheck.ReadWriteSubTree)
        RegKey.SetValue("3", SelectedIconContainer & "," & SelectedListView.SelectedItems(0).Index)
        RegKey.Close()
    End Sub

    Private Shared Sub mnuRestoreSystemFolderIcon_Click(sender As System.Object, e As EventArgs) Handles mnuRestoreSystemFolderIcon.Click
        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons")
        If key IsNot Nothing Then
            If key.GetValue("3") IsNot Nothing Then
                Const strReg = "SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons"
                RegKey = Registry.LocalMachine.CreateSubKey(strReg, RegistryKeyPermissionCheck.ReadWriteSubTree)
                RegKey.DeleteValue("3")
                RegKey.Close()
            End If
        End If
    End Sub

    Private Sub mnuAction_DropDownOpening(sender As Object, e As EventArgs) Handles mnuAction.DropDownOpening
        Dim item As IconListViewItem = Nothing
        If SelectedListView.SelectedIndices.Count = 1 Then
            item = TryCast(SelectedListView.SelectedItems(0), IconListViewItem)
        End If
        mnuChangeSystemFolderIcon.Enabled = (item IsNot Nothing)
        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Icons")
        If key IsNot Nothing Then
            mnuRestoreSystemFolderIcon.Enabled = (key.GetValue("3") IsNot Nothing)
        Else
            mnuRestoreSystemFolderIcon.Enabled = (key IsNot Nothing)
        End If
    End Sub

    Private Sub cIconList_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cIconList.Opening
        Dim item As IconListViewItem = Nothing
        If SelectedListView.SelectedIndices.Count = 1 Then
            item = TryCast(SelectedListView.SelectedItems(0), IconListViewItem)
        End If
        mnuExtractIcon.Enabled = (item IsNot Nothing)
        mnuIconProperties.Enabled = (item IsNot Nothing)
    End Sub

    Private Sub mnuExtractIcon_Click(sender As System.Object, e As EventArgs) Handles mnuExtractIcon.Click
        Dim item As Icon = TryCast(SelectedListView.SelectedItems(0).Tag, Icon)
        If item IsNot Nothing Then
            If dlgSaveIcon.ShowDialog(Me) = DialogResult.OK Then
                Dim fs As FileStream = File.Create(dlgSaveIcon.FileName)
                item.Save(fs)
                fs.Close()
            End If
        End If
    End Sub

    Private Sub mnuIconProperties_Click(sender As System.Object, e As EventArgs) Handles mnuIconProperties.Click
        With frmIconProperties
            .icn = DirectCast(SelectedListView.SelectedItems(0).Tag, Icon)
            .IconDir = IconFolderContainer
            .IconIndex = SelectedListView.SelectedItems(0).Index
            .ShowDialog()
        End With
    End Sub

    Private Sub ilvSoftware_Enter(sender As Object, e As EventArgs) Handles ilvSoftware.Enter
        SelectedListView = ilvSoftware
        SelectedIconContainer = IconSoftwareContainer
    End Sub

    Private Shared Sub mnuEmail_Click(sender As System.Object, e As EventArgs) Handles mnuEmail.Click
        Process.Start("mailto:rojsoftsolutionsltd@gmail.com")
    End Sub

    Private Shared Sub mnuHomepage_Click(sender As System.Object, e As EventArgs) Handles mnuHomepage.Click
        Process.Start("http://www.rojsoft-solutions.x10.mx")
    End Sub

    Private Sub mnuSingleFolder_Click(sender As System.Object, e As EventArgs) Handles mnuSingleFolder.Click
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        CheckMenuItem(mnuFolders, item)
        SplitterWidth = mainSplit.Panel1.Width
        If mnuSingleFolder.Checked Then
            mainSplit.Panel1Collapsed = False
            ' Width -= SplitterWidth
        Else
            mainSplit.Panel1Collapsed = True
            ' Width += SplitterWidth
        End If

    End Sub

    Private Sub mnuFavorites_Click(sender As System.Object, e As EventArgs) Handles mnuFavorites.Click
        frmLanguages.ShowDialog()
    End Sub

    Private Sub cMenu_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cMenu.Opening
        '  Dim item As ListItem = Nothing

        'If lstFolder.SelectedIndices.Count = 1 Then
        'item = TryCast(lstFolder.SelectedItem, ListItem)
        '  End If

        ' cmnuRemove.Enabled = (item IsNot Nothing)
        cmnuRemoveFolder.Enabled = (lstFolder.SelectedIndex > -1)
        cmnuClean.Enabled = IsListBoxEmpty(lstFolder)
        cmnuPasteClipboard.Enabled = (lstFolder.SelectedIndex > -1)
        cmnuAddToFavorites.Enabled = (lstFolder.SelectedIndex > -1)
    End Sub
    
    Private Sub mnuFile_DropDownOpening(sender As Object, e As EventArgs) Handles mnuFile.DropDownOpening
        mnuRemoveFolder.Enabled = (lstFolder.SelectedIndex > -1)
        mnuClean.Enabled = IsListBoxEmpty(lstFolder)
    End Sub

    Private Sub lstFolder_SelectedIndexChanged(sender As System.Object, e As EventArgs) Handles lstFolder.SelectedIndexChanged
        btnRemove.Enabled = (lstFolder.SelectedIndex > -1)
    End Sub
End Class
