<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.slInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.fFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.dlgSaveIcon = New System.Windows.Forms.SaveFileDialog()
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRemoveFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClean = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuApply = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRestoreIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRollbackAllChanges = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefreshSystemIcons = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuChangeSystemFolderIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRestoreSystemFolderIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDistributable = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIncludeSubfolders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFolders = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSingleFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMultipleFolders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFavorites = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEnglish = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCroatian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCzech = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDutch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFrench = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGerman = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHungarian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIndonesian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItalian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPolish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSlovak = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSpanish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSwedish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTurkish = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVietnamese = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHomepage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDownloadFolderIconPacks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDonate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFacebook = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTwitter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuRemoveFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuClean = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmnuPasteClipboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmnuAddToFavorites = New System.Windows.Forms.ToolStripMenuItem()
        Me.cIconList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExtractIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuIconProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.mainSplit = New System.Windows.Forms.SplitContainer()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.lstFolder = New System.Windows.Forms.ListBox()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tabIcon = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.tabSoftware = New System.Windows.Forms.TabPage()
        Me.tabMovies = New System.Windows.Forms.TabPage()
        Me.tabGames = New System.Windows.Forms.TabPage()
        Me.tabMusic = New System.Windows.Forms.TabPage()
        Me.tabCustom = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBrowse = New YAFIC.SplitButton()
        Me.btnRemove = New YAFIC.SplitButton()
        Me.btnClean = New YAFIC.SplitButton()
        Me.btnApply = New YAFIC.SplitButton()
        Me.btnExit = New YAFIC.SplitButton()
        Me.ilvMain = New YAFIC.IconListView()
        Me.ilvSoftware = New YAFIC.IconListView()
        Me.ilvMovies = New YAFIC.IconListView()
        Me.ilvGames = New YAFIC.IconListView()
        Me.ilvMusic = New YAFIC.IconListView()
        Me.ilvCustom = New YAFIC.IconListView()
        Me.btnIconDelete = New YAFIC.CustomButton()
        Me.btnIconNew = New YAFIC.CustomButton()
        Me.statMsg = New YAFIC.StatusMessage()
        Me.iconDialog = New YAFIC.IconPickerDialog()
        Me.StatusStrip.SuspendLayout()
        Me.mainMenu.SuspendLayout()
        Me.cMenu.SuspendLayout()
        Me.cIconList.SuspendLayout()
        CType(Me.mainSplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainSplit.Panel1.SuspendLayout()
        Me.mainSplit.Panel2.SuspendLayout()
        Me.mainSplit.SuspendLayout()
        Me.panelTop.SuspendLayout()
        Me.panelBottom.SuspendLayout()
        Me.tabIcon.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabSoftware.SuspendLayout()
        Me.tabMovies.SuspendLayout()
        Me.tabGames.SuspendLayout()
        Me.tabMusic.SuspendLayout()
        Me.tabCustom.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.AutoSize = False
        Me.StatusStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slInfo})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 422)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.ShowItemToolTips = True
        Me.StatusStrip.Size = New System.Drawing.Size(580, 28)
        Me.StatusStrip.TabIndex = 10
        '
        'slInfo
        '
        Me.slInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.slInfo.Margin = New System.Windows.Forms.Padding(3, 3, 0, 2)
        Me.slInfo.Name = "slInfo"
        Me.slInfo.Size = New System.Drawing.Size(562, 23)
        Me.slInfo.Spring = True
        Me.slInfo.Text = "Yet Another Folder Icon Customizer"
        Me.slInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fFolder
        '
        Me.fFolder.Description = "Please choose a directory to be customized:"
        '
        'dlgSaveIcon
        '
        Me.dlgSaveIcon.DefaultExt = "*.ico"
        Me.dlgSaveIcon.Filter = "Windows® Icon Files|*.ico"
        Me.dlgSaveIcon.Title = "Extract Icon As..."
        '
        'imlTab
        '
        Me.imlTab.ImageStream = CType(resources.GetObject("imlTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTab.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTab.Images.SetKeyName(0, "folder-horizontal.png")
        Me.imlTab.Images.SetKeyName(1, "Applic Command 16x16.png")
        Me.imlTab.Images.SetKeyName(2, "film.png")
        Me.imlTab.Images.SetKeyName(3, "joystick.png")
        Me.imlTab.Images.SetKeyName(4, "media-player-medium-green.png")
        Me.imlTab.Images.SetKeyName(5, "box.png")
        Me.imlTab.Images.SetKeyName(6, "sofa.png")
        '
        'mainMenu
        '
        Me.mainMenu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuAction, Me.mnuTools, Me.mnuHelp})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(580, 24)
        Me.mainMenu.TabIndex = 28
        Me.mainMenu.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBrowse, Me.mnuRemoveFolder, Me.mnuClean, Me.ToolStripSeparator2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.statMsg.SetStatusMessage(Me.mnuFile, "")
        Me.mnuFile.Text = "&File"
        '
        'mnuBrowse
        '
        Me.mnuBrowse.Image = CType(resources.GetObject("mnuBrowse.Image"), System.Drawing.Image)
        Me.mnuBrowse.Name = "mnuBrowse"
        Me.mnuBrowse.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.mnuBrowse, "Browse and add new folder to the list.")
        Me.mnuBrowse.Text = "&Browse Folder..."
        '
        'mnuRemoveFolder
        '
        Me.mnuRemoveFolder.Enabled = False
        Me.mnuRemoveFolder.Image = CType(resources.GetObject("mnuRemoveFolder.Image"), System.Drawing.Image)
        Me.mnuRemoveFolder.Name = "mnuRemoveFolder"
        Me.mnuRemoveFolder.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.mnuRemoveFolder, "Remove selected folder on the list.")
        Me.mnuRemoveFolder.Text = "Remove Selected Folder"
        '
        'mnuClean
        '
        Me.mnuClean.Enabled = False
        Me.mnuClean.Image = CType(resources.GetObject("mnuClean.Image"), System.Drawing.Image)
        Me.mnuClean.Name = "mnuClean"
        Me.mnuClean.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.mnuClean, "Remove all the folder the list.")
        Me.mnuClean.Text = "Remove All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(187, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Image = CType(resources.GetObject("mnuExit.Image"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.mnuExit, "Exit the program.")
        Me.mnuExit.Text = "E&xit..."
        '
        'mnuAction
        '
        Me.mnuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuApply, Me.mnuRestoreIcon, Me.ToolStripMenuItem5, Me.mnuRollbackAllChanges, Me.mnuRefreshSystemIcons, Me.ToolStripSeparator4, Me.mnuChangeSystemFolderIcon, Me.mnuRestoreSystemFolderIcon})
        Me.mnuAction.Name = "mnuAction"
        Me.mnuAction.Size = New System.Drawing.Size(49, 20)
        Me.statMsg.SetStatusMessage(Me.mnuAction, "")
        Me.mnuAction.Text = "&Action"
        '
        'mnuApply
        '
        Me.mnuApply.Image = CType(resources.GetObject("mnuApply.Image"), System.Drawing.Image)
        Me.mnuApply.Name = "mnuApply"
        Me.mnuApply.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuApply, "Changes icon for current folder(s). Acting the same way if you would press ""Apply" & _
        """ button.")
        Me.mnuApply.Text = "&Apply Icon Changes"
        '
        'mnuRestoreIcon
        '
        Me.mnuRestoreIcon.Image = CType(resources.GetObject("mnuRestoreIcon.Image"), System.Drawing.Image)
        Me.mnuRestoreIcon.Name = "mnuRestoreIcon"
        Me.mnuRestoreIcon.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuRestoreIcon, "After application of this command on an icon of a folder, a standard icon results" & _
        ".")
        Me.mnuRestoreIcon.Text = "Restore &Default Icon for Chosen Folder(s)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(330, 6)
        '
        'mnuRollbackAllChanges
        '
        Me.mnuRollbackAllChanges.Image = CType(resources.GetObject("mnuRollbackAllChanges.Image"), System.Drawing.Image)
        Me.mnuRollbackAllChanges.Name = "mnuRollbackAllChanges"
        Me.mnuRollbackAllChanges.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuRollbackAllChanges, "Discards all changes which were made by program.")
        Me.mnuRollbackAllChanges.Text = "&Rollback All Changes"
        '
        'mnuRefreshSystemIcons
        '
        Me.mnuRefreshSystemIcons.Image = CType(resources.GetObject("mnuRefreshSystemIcons.Image"), System.Drawing.Image)
        Me.mnuRefreshSystemIcons.Name = "mnuRefreshSystemIcons"
        Me.mnuRefreshSystemIcons.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuRefreshSystemIcons, "Rebuilds Icon Cache if Windows Icons do not update correctly.")
        Me.mnuRefreshSystemIcons.Text = "Refresh System Icons"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(330, 6)
        '
        'mnuChangeSystemFolderIcon
        '
        Me.mnuChangeSystemFolderIcon.Image = CType(resources.GetObject("mnuChangeSystemFolderIcon.Image"), System.Drawing.Image)
        Me.mnuChangeSystemFolderIcon.Name = "mnuChangeSystemFolderIcon"
        Me.mnuChangeSystemFolderIcon.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuChangeSystemFolderIcon, "Applies the chosen icon as a standard icon in the system. Replaces a standard ico" & _
        "n in the system.")
        Me.mnuChangeSystemFolderIcon.Text = "Use Selected Icon as the System's Default Folder Icon"
        '
        'mnuRestoreSystemFolderIcon
        '
        Me.mnuRestoreSystemFolderIcon.Image = CType(resources.GetObject("mnuRestoreSystemFolderIcon.Image"), System.Drawing.Image)
        Me.mnuRestoreSystemFolderIcon.Name = "mnuRestoreSystemFolderIcon"
        Me.mnuRestoreSystemFolderIcon.Size = New System.Drawing.Size(333, 22)
        Me.statMsg.SetStatusMessage(Me.mnuRestoreSystemFolderIcon, "Restores the standard yellow icon in the system as the default one.")
        Me.mnuRestoreSystemFolderIcon.Text = "Restore System's Default Folder Icon"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDistributable, Me.mnuIncludeSubfolders, Me.ToolStripSeparator3, Me.mnuFolders, Me.ToolStripSeparator9, Me.mnuFavorites, Me.mnuLanguage, Me.ToolStripSeparator6, Me.mnuPreferences})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(44, 20)
        Me.statMsg.SetStatusMessage(Me.mnuTools, "")
        Me.mnuTools.Text = "&Tools"
        '
        'mnuDistributable
        '
        Me.mnuDistributable.Checked = True
        Me.mnuDistributable.CheckOnClick = True
        Me.mnuDistributable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuDistributable.Name = "mnuDistributable"
        Me.mnuDistributable.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuDistributable, "If the given option is chosen, the icon will be copied in the chosen directory.")
        Me.mnuDistributable.Text = "Make Customized Folder Distributable"
        '
        'mnuIncludeSubfolders
        '
        Me.mnuIncludeSubfolders.Checked = True
        Me.mnuIncludeSubfolders.CheckOnClick = True
        Me.mnuIncludeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuIncludeSubfolders.Name = "mnuIncludeSubfolders"
        Me.mnuIncludeSubfolders.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuIncludeSubfolders, "The given option allows you to change an icon for all enclosed folders of the cho" & _
        "sen directory.")
        Me.mnuIncludeSubfolders.Text = "Apply Selected Icon for all Subfolders"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(250, 6)
        '
        'mnuFolders
        '
        Me.mnuFolders.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSingleFolder, Me.mnuMultipleFolders})
        Me.mnuFolders.Image = CType(resources.GetObject("mnuFolders.Image"), System.Drawing.Image)
        Me.mnuFolders.Name = "mnuFolders"
        Me.mnuFolders.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuFolders, "")
        Me.mnuFolders.Text = "Folders"
        '
        'mnuSingleFolder
        '
        Me.mnuSingleFolder.Name = "mnuSingleFolder"
        Me.mnuSingleFolder.Size = New System.Drawing.Size(160, 22)
        Me.statMsg.SetStatusMessage(Me.mnuSingleFolder, "")
        Me.mnuSingleFolder.Text = "Single Folder..."
        '
        'mnuMultipleFolders
        '
        Me.mnuMultipleFolders.Name = "mnuMultipleFolders"
        Me.mnuMultipleFolders.Size = New System.Drawing.Size(160, 22)
        Me.statMsg.SetStatusMessage(Me.mnuMultipleFolders, "")
        Me.mnuMultipleFolders.Text = "Multiple Folders..."
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(250, 6)
        '
        'mnuFavorites
        '
        Me.mnuFavorites.Image = CType(resources.GetObject("mnuFavorites.Image"), System.Drawing.Image)
        Me.mnuFavorites.Name = "mnuFavorites"
        Me.mnuFavorites.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuFavorites, "")
        Me.mnuFavorites.Text = "Favorites..."
        '
        'mnuLanguage
        '
        Me.mnuLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEnglish, Me.ToolStripSeparator7, Me.mnuCroatian, Me.mnuCzech, Me.mnuDutch, Me.mnuFrench, Me.mnuGerman, Me.mnuHungarian, Me.mnuIndonesian, Me.mnuItalian, Me.mnuPolish, Me.mnuSlovak, Me.mnuSpanish, Me.mnuSwedish, Me.mnuTurkish, Me.mnuVietnamese})
        Me.mnuLanguage.Image = CType(resources.GetObject("mnuLanguage.Image"), System.Drawing.Image)
        Me.mnuLanguage.Name = "mnuLanguage"
        Me.mnuLanguage.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuLanguage, "")
        Me.mnuLanguage.Text = "Language..."
        '
        'mnuEnglish
        '
        Me.mnuEnglish.Checked = True
        Me.mnuEnglish.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuEnglish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEnglish.Name = "mnuEnglish"
        Me.mnuEnglish.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuEnglish, "")
        Me.mnuEnglish.Tag = "English"
        Me.mnuEnglish.Text = "English (Default)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(184, 6)
        '
        'mnuCroatian
        '
        Me.mnuCroatian.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCroatian.Name = "mnuCroatian"
        Me.mnuCroatian.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuCroatian, "")
        Me.mnuCroatian.Tag = "Croatian"
        Me.mnuCroatian.Text = "Croatian (Hrvatski)"
        '
        'mnuCzech
        '
        Me.mnuCzech.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCzech.Name = "mnuCzech"
        Me.mnuCzech.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuCzech, "")
        Me.mnuCzech.Tag = "Czech"
        Me.mnuCzech.Text = "Czech (Èeština)"
        '
        'mnuDutch
        '
        Me.mnuDutch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDutch.Name = "mnuDutch"
        Me.mnuDutch.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuDutch, "")
        Me.mnuDutch.Tag = "Dutch"
        Me.mnuDutch.Text = "Dutch (Nederlands)"
        '
        'mnuFrench
        '
        Me.mnuFrench.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuFrench.Name = "mnuFrench"
        Me.mnuFrench.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuFrench, "")
        Me.mnuFrench.Tag = "French"
        Me.mnuFrench.Text = "French (Français)"
        '
        'mnuGerman
        '
        Me.mnuGerman.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuGerman.Name = "mnuGerman"
        Me.mnuGerman.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuGerman, "")
        Me.mnuGerman.Tag = "German"
        Me.mnuGerman.Text = "German (Deutsch)"
        '
        'mnuHungarian
        '
        Me.mnuHungarian.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuHungarian.Name = "mnuHungarian"
        Me.mnuHungarian.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuHungarian, "")
        Me.mnuHungarian.Tag = "Hungarian"
        Me.mnuHungarian.Text = "Hungarian (Magyar)"
        '
        'mnuIndonesian
        '
        Me.mnuIndonesian.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuIndonesian.Name = "mnuIndonesian"
        Me.mnuIndonesian.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuIndonesian, "")
        Me.mnuIndonesian.Tag = "Indonesian"
        Me.mnuIndonesian.Text = "Indonesian (Indonesia)"
        '
        'mnuItalian
        '
        Me.mnuItalian.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuItalian.Name = "mnuItalian"
        Me.mnuItalian.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuItalian, "")
        Me.mnuItalian.Tag = "Italian"
        Me.mnuItalian.Text = "Italian (Italiano)"
        '
        'mnuPolish
        '
        Me.mnuPolish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPolish.Name = "mnuPolish"
        Me.mnuPolish.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuPolish, "")
        Me.mnuPolish.Tag = "Polish"
        Me.mnuPolish.Text = "Polish (Polski)"
        '
        'mnuSlovak
        '
        Me.mnuSlovak.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSlovak.Name = "mnuSlovak"
        Me.mnuSlovak.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuSlovak, "")
        Me.mnuSlovak.Tag = "Slovak"
        Me.mnuSlovak.Text = "Slovak (Slovensk?)"
        '
        'mnuSpanish
        '
        Me.mnuSpanish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSpanish.Name = "mnuSpanish"
        Me.mnuSpanish.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuSpanish, "")
        Me.mnuSpanish.Tag = "Spanish"
        Me.mnuSpanish.Text = "Spanish (Español)"
        '
        'mnuSwedish
        '
        Me.mnuSwedish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSwedish.Name = "mnuSwedish"
        Me.mnuSwedish.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuSwedish, "")
        Me.mnuSwedish.Tag = "Swedish"
        Me.mnuSwedish.Text = "Swedish (Svenska)"
        '
        'mnuTurkish
        '
        Me.mnuTurkish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuTurkish.Name = "mnuTurkish"
        Me.mnuTurkish.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuTurkish, "")
        Me.mnuTurkish.Tag = "Turkish"
        Me.mnuTurkish.Text = "Turkish (Turkish)"
        '
        'mnuVietnamese
        '
        Me.mnuVietnamese.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuVietnamese.Name = "mnuVietnamese"
        Me.mnuVietnamese.Size = New System.Drawing.Size(187, 22)
        Me.statMsg.SetStatusMessage(Me.mnuVietnamese, "")
        Me.mnuVietnamese.Tag = "Vietnamese"
        Me.mnuVietnamese.Text = "Vietnamese (Tieng viet)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(250, 6)
        '
        'mnuPreferences
        '
        Me.mnuPreferences.Image = CType(resources.GetObject("mnuPreferences.Image"), System.Drawing.Image)
        Me.mnuPreferences.Name = "mnuPreferences"
        Me.mnuPreferences.Size = New System.Drawing.Size(253, 22)
        Me.statMsg.SetStatusMessage(Me.mnuPreferences, "Load Preferences.")
        Me.mnuPreferences.Text = "&Preferences..."
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpContents, Me.mnuTip, Me.ToolStripMenuItem1, Me.mnuHomepage, Me.mnuEmail, Me.mnuDownloadFolderIconPacks, Me.ToolStripSeparator1, Me.mnuDonate, Me.ToolStripMenuItem2, Me.mnuFacebook, Me.mnuTwitter, Me.ToolStripMenuItem3, Me.mnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(40, 20)
        Me.statMsg.SetStatusMessage(Me.mnuHelp, "")
        Me.mnuHelp.Text = "&Help"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Image = CType(resources.GetObject("mnuHelpContents.Image"), System.Drawing.Image)
        Me.mnuHelpContents.Name = "mnuHelpContents"
        Me.mnuHelpContents.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.mnuHelpContents.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuHelpContents, "Opens Help File.")
        Me.mnuHelpContents.Text = "Help &Contents"
        '
        'mnuTip
        '
        Me.mnuTip.Image = CType(resources.GetObject("mnuTip.Image"), System.Drawing.Image)
        Me.mnuTip.Name = "mnuTip"
        Me.mnuTip.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuTip, "Tip Of The Day")
        Me.mnuTip.Text = "Tip Of The Day"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(205, 6)
        '
        'mnuHomepage
        '
        Me.mnuHomepage.Image = CType(resources.GetObject("mnuHomepage.Image"), System.Drawing.Image)
        Me.mnuHomepage.Name = "mnuHomepage"
        Me.mnuHomepage.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuHomepage, "Visit Author Homepage.")
        Me.mnuHomepage.Text = "H&omepage"
        '
        'mnuEmail
        '
        Me.mnuEmail.Image = CType(resources.GetObject("mnuEmail.Image"), System.Drawing.Image)
        Me.mnuEmail.Name = "mnuEmail"
        Me.mnuEmail.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuEmail, "Email Us.")
        Me.mnuEmail.Text = "&Email"
        '
        'mnuDownloadFolderIconPacks
        '
        Me.mnuDownloadFolderIconPacks.Image = CType(resources.GetObject("mnuDownloadFolderIconPacks.Image"), System.Drawing.Image)
        Me.mnuDownloadFolderIconPacks.Name = "mnuDownloadFolderIconPacks"
        Me.mnuDownloadFolderIconPacks.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuDownloadFolderIconPacks, "Download Free Folder Icon and Icon Packs.")
        Me.mnuDownloadFolderIconPacks.Text = "Download Folder Icon Packs"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(205, 6)
        '
        'mnuDonate
        '
        Me.mnuDonate.Image = CType(resources.GetObject("mnuDonate.Image"), System.Drawing.Image)
        Me.mnuDonate.Name = "mnuDonate"
        Me.mnuDonate.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuDonate, "Donate a small amount to help defer the costs of maitaining and continued develop" & _
        "ment, we do appreciate donations. ")
        Me.mnuDonate.Text = "Donate"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(205, 6)
        '
        'mnuFacebook
        '
        Me.mnuFacebook.Image = CType(resources.GetObject("mnuFacebook.Image"), System.Drawing.Image)
        Me.mnuFacebook.Name = "mnuFacebook"
        Me.mnuFacebook.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuFacebook, "Like Us on Facebook.")
        Me.mnuFacebook.Text = "Like Us On Facebook"
        '
        'mnuTwitter
        '
        Me.mnuTwitter.Image = CType(resources.GetObject("mnuTwitter.Image"), System.Drawing.Image)
        Me.mnuTwitter.Name = "mnuTwitter"
        Me.mnuTwitter.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuTwitter, "Follow Us on Twitter.")
        Me.mnuTwitter.Text = "Follow Us On Twitter"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(205, 6)
        '
        'mnuAbout
        '
        Me.mnuAbout.Image = CType(resources.GetObject("mnuAbout.Image"), System.Drawing.Image)
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(208, 22)
        Me.statMsg.SetStatusMessage(Me.mnuAbout, "Shows you information about the Program.")
        Me.mnuAbout.Text = "&About..."
        '
        'cMenu
        '
        Me.cMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuBrowse, Me.cmnuRemoveFolder, Me.cmnuClean, Me.ToolStripSeparator5, Me.cmnuPasteClipboard, Me.cmnuAddToFavorites})
        Me.cMenu.Name = "ContextMenuStrip1"
        Me.cMenu.Size = New System.Drawing.Size(191, 120)
        '
        'cmnuBrowse
        '
        Me.cmnuBrowse.Image = CType(resources.GetObject("cmnuBrowse.Image"), System.Drawing.Image)
        Me.cmnuBrowse.Name = "cmnuBrowse"
        Me.cmnuBrowse.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.cmnuBrowse, "")
        Me.cmnuBrowse.Text = "Browse Folder..."
        '
        'cmnuRemoveFolder
        '
        Me.cmnuRemoveFolder.Image = CType(resources.GetObject("cmnuRemoveFolder.Image"), System.Drawing.Image)
        Me.cmnuRemoveFolder.Name = "cmnuRemoveFolder"
        Me.cmnuRemoveFolder.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.cmnuRemoveFolder, "")
        Me.cmnuRemoveFolder.Text = "Remove Selected Folder"
        '
        'cmnuClean
        '
        Me.cmnuClean.Image = CType(resources.GetObject("cmnuClean.Image"), System.Drawing.Image)
        Me.cmnuClean.Name = "cmnuClean"
        Me.cmnuClean.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.cmnuClean, "")
        Me.cmnuClean.Text = "Remove All"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(187, 6)
        '
        'cmnuPasteClipboard
        '
        Me.cmnuPasteClipboard.Image = CType(resources.GetObject("cmnuPasteClipboard.Image"), System.Drawing.Image)
        Me.cmnuPasteClipboard.Name = "cmnuPasteClipboard"
        Me.cmnuPasteClipboard.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.cmnuPasteClipboard, "")
        Me.cmnuPasteClipboard.Text = "Paste from Clipboard..."
        '
        'cmnuAddToFavorites
        '
        Me.cmnuAddToFavorites.Image = CType(resources.GetObject("cmnuAddToFavorites.Image"), System.Drawing.Image)
        Me.cmnuAddToFavorites.Name = "cmnuAddToFavorites"
        Me.cmnuAddToFavorites.Size = New System.Drawing.Size(190, 22)
        Me.statMsg.SetStatusMessage(Me.cmnuAddToFavorites, "")
        Me.cmnuAddToFavorites.Text = "Add to Favorites..."
        '
        'cIconList
        '
        Me.cIconList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExtractIcon, Me.ToolStripSeparator8, Me.mnuIconProperties})
        Me.cIconList.Name = "cIconList"
        Me.cIconList.Size = New System.Drawing.Size(161, 54)
        '
        'mnuExtractIcon
        '
        Me.mnuExtractIcon.Image = CType(resources.GetObject("mnuExtractIcon.Image"), System.Drawing.Image)
        Me.mnuExtractIcon.Name = "mnuExtractIcon"
        Me.mnuExtractIcon.Size = New System.Drawing.Size(160, 22)
        Me.statMsg.SetStatusMessage(Me.mnuExtractIcon, "")
        Me.mnuExtractIcon.Text = "&Extract Icon As..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(157, 6)
        '
        'mnuIconProperties
        '
        Me.mnuIconProperties.Image = CType(resources.GetObject("mnuIconProperties.Image"), System.Drawing.Image)
        Me.mnuIconProperties.Name = "mnuIconProperties"
        Me.mnuIconProperties.Size = New System.Drawing.Size(160, 22)
        Me.statMsg.SetStatusMessage(Me.mnuIconProperties, "")
        Me.mnuIconProperties.Text = "Icon P&roperties"
        '
        'imlIcon
        '
        Me.imlIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imlIcon.ImageSize = New System.Drawing.Size(32, 32)
        Me.imlIcon.TransparentColor = System.Drawing.Color.Transparent
        '
        'mainSplit
        '
        Me.mainSplit.Cursor = System.Windows.Forms.Cursors.Default
        Me.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainSplit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainSplit.Location = New System.Drawing.Point(0, 24)
        Me.mainSplit.Name = "mainSplit"
        Me.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'mainSplit.Panel1
        '
        Me.mainSplit.Panel1.Controls.Add(Me.panelTop)
        Me.mainSplit.Panel1MinSize = 132
        '
        'mainSplit.Panel2
        '
        Me.mainSplit.Panel2.Controls.Add(Me.panelBottom)
        Me.mainSplit.Panel2MinSize = 200
        Me.mainSplit.Size = New System.Drawing.Size(580, 398)
        Me.mainSplit.SplitterDistance = 132
        Me.mainSplit.SplitterWidth = 2
        Me.mainSplit.TabIndex = 29
        '
        'panelTop
        '
        Me.panelTop.Controls.Add(Me.btnBrowse)
        Me.panelTop.Controls.Add(Me.btnRemove)
        Me.panelTop.Controls.Add(Me.btnClean)
        Me.panelTop.Controls.Add(Me.lstFolder)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelTop.Location = New System.Drawing.Point(0, 0)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(580, 132)
        Me.panelTop.TabIndex = 34
        '
        'lstFolder
        '
        Me.lstFolder.AllowDrop = True
        Me.lstFolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFolder.ContextMenuStrip = Me.cMenu
        Me.lstFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstFolder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFolder.FormattingEnabled = True
        Me.lstFolder.HorizontalScrollbar = True
        Me.lstFolder.IntegralHeight = False
        Me.lstFolder.ItemHeight = 22
        Me.lstFolder.Location = New System.Drawing.Point(7, 12)
        Me.lstFolder.Name = "lstFolder"
        Me.lstFolder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFolder.Size = New System.Drawing.Size(458, 118)
        Me.lstFolder.TabIndex = 38
        '
        'panelBottom
        '
        Me.panelBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.panelBottom.Controls.Add(Me.btnApply)
        Me.panelBottom.Controls.Add(Me.btnExit)
        Me.panelBottom.Controls.Add(Me.Button1)
        Me.panelBottom.Controls.Add(Me.tabIcon)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBottom.Location = New System.Drawing.Point(0, 0)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(580, 264)
        Me.panelBottom.TabIndex = 36
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(136, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 21)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'tabIcon
        '
        Me.tabIcon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabIcon.Controls.Add(Me.tabMain)
        Me.tabIcon.Controls.Add(Me.tabSoftware)
        Me.tabIcon.Controls.Add(Me.tabMovies)
        Me.tabIcon.Controls.Add(Me.tabGames)
        Me.tabIcon.Controls.Add(Me.tabMusic)
        Me.tabIcon.Controls.Add(Me.tabCustom)
        Me.tabIcon.ImageList = Me.imlTab
        Me.tabIcon.ItemSize = New System.Drawing.Size(42, 22)
        Me.tabIcon.Location = New System.Drawing.Point(7, 3)
        Me.tabIcon.Name = "tabIcon"
        Me.tabIcon.SelectedIndex = 0
        Me.tabIcon.Size = New System.Drawing.Size(566, 212)
        Me.tabIcon.TabIndex = 34
        Me.tabIcon.TabStop = False
        '
        'tabMain
        '
        Me.tabMain.AutoScroll = True
        Me.tabMain.Controls.Add(Me.ilvMain)
        Me.tabMain.ImageIndex = 0
        Me.tabMain.Location = New System.Drawing.Point(4, 26)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(558, 182)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'tabSoftware
        '
        Me.tabSoftware.Controls.Add(Me.ilvSoftware)
        Me.tabSoftware.ImageIndex = 1
        Me.tabSoftware.Location = New System.Drawing.Point(4, 26)
        Me.tabSoftware.Name = "tabSoftware"
        Me.tabSoftware.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSoftware.Size = New System.Drawing.Size(558, 182)
        Me.tabSoftware.TabIndex = 3
        Me.tabSoftware.Text = "Software"
        Me.tabSoftware.UseVisualStyleBackColor = True
        '
        'tabMovies
        '
        Me.tabMovies.AutoScroll = True
        Me.tabMovies.Controls.Add(Me.ilvMovies)
        Me.tabMovies.ImageIndex = 2
        Me.tabMovies.Location = New System.Drawing.Point(4, 26)
        Me.tabMovies.Name = "tabMovies"
        Me.tabMovies.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMovies.Size = New System.Drawing.Size(558, 182)
        Me.tabMovies.TabIndex = 1
        Me.tabMovies.Text = "Movies"
        Me.tabMovies.UseVisualStyleBackColor = True
        '
        'tabGames
        '
        Me.tabGames.Controls.Add(Me.ilvGames)
        Me.tabGames.ImageIndex = 3
        Me.tabGames.Location = New System.Drawing.Point(4, 26)
        Me.tabGames.Name = "tabGames"
        Me.tabGames.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGames.Size = New System.Drawing.Size(558, 182)
        Me.tabGames.TabIndex = 2
        Me.tabGames.Text = "Games"
        Me.tabGames.UseVisualStyleBackColor = True
        '
        'tabMusic
        '
        Me.tabMusic.Controls.Add(Me.ilvMusic)
        Me.tabMusic.ImageIndex = 4
        Me.tabMusic.Location = New System.Drawing.Point(4, 26)
        Me.tabMusic.Name = "tabMusic"
        Me.tabMusic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMusic.Size = New System.Drawing.Size(558, 182)
        Me.tabMusic.TabIndex = 5
        Me.tabMusic.Text = "Music"
        Me.tabMusic.UseVisualStyleBackColor = True
        '
        'tabCustom
        '
        Me.tabCustom.Controls.Add(Me.ilvCustom)
        Me.tabCustom.Controls.Add(Me.Panel1)
        Me.tabCustom.ImageIndex = 5
        Me.tabCustom.Location = New System.Drawing.Point(4, 26)
        Me.tabCustom.Name = "tabCustom"
        Me.tabCustom.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustom.Size = New System.Drawing.Size(558, 182)
        Me.tabCustom.TabIndex = 4
        Me.tabCustom.Text = "Custom..."
        Me.tabCustom.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnIconDelete)
        Me.Panel1.Controls.Add(Me.btnIconNew)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(485, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 176)
        Me.Panel1.TabIndex = 40
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.AutoSize = True
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(471, 12)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(100, 31)
        Me.btnBrowse.SplitMenu = Nothing
        Me.btnBrowse.SplitMenuStrip = Nothing
        Me.btnBrowse.TabIndex = 42
        Me.btnBrowse.Text = "&Browse..."
        Me.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.AutoSize = True
        Me.btnRemove.Enabled = False
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(471, 45)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 31)
        Me.btnRemove.SplitMenu = Nothing
        Me.btnRemove.SplitMenuStrip = Nothing
        Me.btnRemove.TabIndex = 41
        Me.btnRemove.Text = "&Remove..."
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClean.AutoSize = True
        Me.btnClean.Enabled = False
        Me.btnClean.Image = CType(resources.GetObject("btnClean.Image"), System.Drawing.Image)
        Me.btnClean.Location = New System.Drawing.Point(471, 78)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(100, 31)
        Me.btnClean.SplitMenu = Nothing
        Me.btnClean.SplitMenuStrip = Nothing
        Me.btnClean.TabIndex = 40
        Me.btnClean.Text = "&Remove All"
        Me.btnClean.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.AutoSize = True
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.Location = New System.Drawing.Point(391, 221)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(90, 31)
        Me.btnApply.SplitMenu = Nothing
        Me.btnApply.SplitMenuStrip = Nothing
        Me.btnApply.TabIndex = 42
        Me.btnApply.Text = "&Apply"
        Me.btnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.AutoSize = True
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(482, 221)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(89, 31)
        Me.btnExit.SplitMenu = Nothing
        Me.btnExit.SplitMenuStrip = Nothing
        Me.btnExit.TabIndex = 41
        Me.btnExit.Text = "&Exit..."
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'ilvMain
        '
        Me.ilvMain.ContextMenuStrip = Me.cIconList
        Me.ilvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMain.Location = New System.Drawing.Point(3, 3)
        Me.ilvMain.MultiSelect = False
        Me.ilvMain.Name = "ilvMain"
        Me.ilvMain.OwnerDraw = True
        Me.ilvMain.ShowItemToolTips = True
        Me.ilvMain.Size = New System.Drawing.Size(552, 176)
        Me.ilvMain.TabIndex = 1
        Me.ilvMain.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMain.UseCompatibleStateImageBehavior = False
        Me.ilvMain.View = System.Windows.Forms.View.Tile
        Me.ilvMain.WatermarkAlpha = 200
        Me.ilvMain.WatermarkImage = CType(resources.GetObject("ilvMain.WatermarkImage"), System.Drawing.Bitmap)
        '
        'ilvSoftware
        '
        Me.ilvSoftware.ContextMenuStrip = Me.cIconList
        Me.ilvSoftware.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvSoftware.Location = New System.Drawing.Point(3, 3)
        Me.ilvSoftware.MultiSelect = False
        Me.ilvSoftware.Name = "ilvSoftware"
        Me.ilvSoftware.OwnerDraw = True
        Me.ilvSoftware.Size = New System.Drawing.Size(552, 176)
        Me.ilvSoftware.TabIndex = 2
        Me.ilvSoftware.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvSoftware.UseCompatibleStateImageBehavior = False
        Me.ilvSoftware.View = System.Windows.Forms.View.Tile
        Me.ilvSoftware.WatermarkAlpha = 200
        Me.ilvSoftware.WatermarkImage = CType(resources.GetObject("ilvSoftware.WatermarkImage"), System.Drawing.Bitmap)
        '
        'ilvMovies
        '
        Me.ilvMovies.ContextMenuStrip = Me.cIconList
        Me.ilvMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMovies.Location = New System.Drawing.Point(3, 3)
        Me.ilvMovies.MultiSelect = False
        Me.ilvMovies.Name = "ilvMovies"
        Me.ilvMovies.OwnerDraw = True
        Me.ilvMovies.Size = New System.Drawing.Size(552, 176)
        Me.ilvMovies.TabIndex = 2
        Me.ilvMovies.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMovies.UseCompatibleStateImageBehavior = False
        Me.ilvMovies.View = System.Windows.Forms.View.Tile
        Me.ilvMovies.WatermarkAlpha = 200
        Me.ilvMovies.WatermarkImage = CType(resources.GetObject("ilvMovies.WatermarkImage"), System.Drawing.Bitmap)
        '
        'ilvGames
        '
        Me.ilvGames.ContextMenuStrip = Me.cIconList
        Me.ilvGames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvGames.Location = New System.Drawing.Point(3, 3)
        Me.ilvGames.MultiSelect = False
        Me.ilvGames.Name = "ilvGames"
        Me.ilvGames.OwnerDraw = True
        Me.ilvGames.Size = New System.Drawing.Size(552, 176)
        Me.ilvGames.TabIndex = 2
        Me.ilvGames.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvGames.UseCompatibleStateImageBehavior = False
        Me.ilvGames.View = System.Windows.Forms.View.Tile
        Me.ilvGames.WatermarkAlpha = 200
        Me.ilvGames.WatermarkImage = CType(resources.GetObject("ilvGames.WatermarkImage"), System.Drawing.Bitmap)
        '
        'ilvMusic
        '
        Me.ilvMusic.ContextMenuStrip = Me.cIconList
        Me.ilvMusic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMusic.Location = New System.Drawing.Point(3, 3)
        Me.ilvMusic.MultiSelect = False
        Me.ilvMusic.Name = "ilvMusic"
        Me.ilvMusic.OwnerDraw = True
        Me.ilvMusic.Size = New System.Drawing.Size(552, 176)
        Me.ilvMusic.TabIndex = 2
        Me.ilvMusic.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMusic.UseCompatibleStateImageBehavior = False
        Me.ilvMusic.View = System.Windows.Forms.View.Tile
        Me.ilvMusic.WatermarkAlpha = 200
        Me.ilvMusic.WatermarkImage = CType(resources.GetObject("ilvMusic.WatermarkImage"), System.Drawing.Bitmap)
        '
        'ilvCustom
        '
        Me.ilvCustom.ContextMenuStrip = Me.cIconList
        Me.ilvCustom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvCustom.Location = New System.Drawing.Point(3, 3)
        Me.ilvCustom.MultiSelect = False
        Me.ilvCustom.Name = "ilvCustom"
        Me.ilvCustom.OwnerDraw = True
        Me.ilvCustom.Size = New System.Drawing.Size(482, 176)
        Me.ilvCustom.TabIndex = 41
        Me.ilvCustom.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvCustom.UseCompatibleStateImageBehavior = False
        Me.ilvCustom.View = System.Windows.Forms.View.Tile
        Me.ilvCustom.WatermarkAlpha = 200
        Me.ilvCustom.WatermarkImage = CType(resources.GetObject("ilvCustom.WatermarkImage"), System.Drawing.Bitmap)
        '
        'btnIconDelete
        '
        Me.btnIconDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIconDelete.AutoSize = True
        Me.btnIconDelete.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnIconDelete.Image = CType(resources.GetObject("btnIconDelete.Image"), System.Drawing.Image)
        Me.btnIconDelete.Location = New System.Drawing.Point(4, 37)
        Me.btnIconDelete.Name = "btnIconDelete"
        Me.btnIconDelete.Size = New System.Drawing.Size(64, 30)
        Me.btnIconDelete.TabIndex = 38
        Me.btnIconDelete.Text = "&Delete"
        Me.btnIconDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIconDelete.UseVisualStyleBackColor = True
        '
        'btnIconNew
        '
        Me.btnIconNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIconNew.AutoSize = True
        Me.btnIconNew.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnIconNew.Image = CType(resources.GetObject("btnIconNew.Image"), System.Drawing.Image)
        Me.btnIconNew.Location = New System.Drawing.Point(4, 3)
        Me.btnIconNew.Name = "btnIconNew"
        Me.btnIconNew.Size = New System.Drawing.Size(64, 30)
        Me.btnIconNew.TabIndex = 37
        Me.btnIconNew.Text = "&New"
        Me.btnIconNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIconNew.UseVisualStyleBackColor = True
        '
        'statMsg
        '
        Me.statMsg.StatusBar = Me.slInfo
        '
        'iconDialog
        '
        Me.iconDialog.Filename = Nothing
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(580, 450)
        Me.Controls.Add(Me.mainSplit)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.mainMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(474, 487)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yet Another Folder Icon Customizer"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.cMenu.ResumeLayout(False)
        Me.cIconList.ResumeLayout(False)
        Me.mainSplit.Panel1.ResumeLayout(False)
        Me.mainSplit.Panel2.ResumeLayout(False)
        CType(Me.mainSplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainSplit.ResumeLayout(False)
        Me.panelTop.ResumeLayout(False)
        Me.panelTop.PerformLayout()
        Me.panelBottom.ResumeLayout(False)
        Me.panelBottom.PerformLayout()
        Me.tabIcon.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabSoftware.ResumeLayout(False)
        Me.tabMovies.ResumeLayout(False)
        Me.tabGames.ResumeLayout(False)
        Me.tabMusic.ResumeLayout(False)
        Me.tabCustom.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents fFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dlgSaveIcon As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuApply As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpContents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuHomepage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEmail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDonate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFacebook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTwitter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRestoreIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRollbackAllChanges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents slInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuTip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuRemoveFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmnuClean As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDistributable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIncludeSubfolders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRefreshSystemIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuChangeSystemFolderIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents statMsg As YAFIC.StatusMessage
    Friend WithEvents mnuDownloadFolderIconPacks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClean As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imlTab As System.Windows.Forms.ImageList
    Friend WithEvents cmnuPasteClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
    Friend WithEvents mnuFavorites As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmnuAddToFavorites As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEnglish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFrench As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents iconDialog As YAFIC.IconPickerDialog
    Friend WithEvents mnuDutch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGerman As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRestoreSystemFolderIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCroatian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCzech As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHungarian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIndonesian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuItalian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPolish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSlovak As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSpanish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSwedish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTurkish As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVietnamese As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cIconList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExtractIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuIconProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFolders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSingleFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMultipleFolders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mainSplit As System.Windows.Forms.SplitContainer
    Friend WithEvents panelTop As System.Windows.Forms.Panel
    Friend WithEvents btnBrowse As YAFIC.SplitButton
    Friend WithEvents btnRemove As YAFIC.SplitButton
    Friend WithEvents btnClean As YAFIC.SplitButton
    Friend WithEvents lstFolder As System.Windows.Forms.ListBox
    Friend WithEvents panelBottom As System.Windows.Forms.Panel
    Friend WithEvents btnApply As YAFIC.SplitButton
    Friend WithEvents btnExit As YAFIC.SplitButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tabIcon As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents ilvMain As YAFIC.IconListView
    Friend WithEvents tabSoftware As System.Windows.Forms.TabPage
    Friend WithEvents ilvSoftware As YAFIC.IconListView
    Friend WithEvents tabMovies As System.Windows.Forms.TabPage
    Friend WithEvents ilvMovies As YAFIC.IconListView
    Friend WithEvents tabGames As System.Windows.Forms.TabPage
    Friend WithEvents ilvGames As YAFIC.IconListView
    Friend WithEvents tabMusic As System.Windows.Forms.TabPage
    Friend WithEvents ilvMusic As YAFIC.IconListView
    Friend WithEvents tabCustom As System.Windows.Forms.TabPage
    Friend WithEvents ilvCustom As YAFIC.IconListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnIconDelete As YAFIC.CustomButton
    Friend WithEvents btnIconNew As YAFIC.CustomButton
End Class
