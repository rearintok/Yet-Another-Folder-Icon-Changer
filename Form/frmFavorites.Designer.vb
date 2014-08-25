<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFavorites
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFavorites))
        Me.mainSplit = New System.Windows.Forms.SplitContainer()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.btnBrowse = New YAFIC.SplitButton()
        Me.btnRemove = New YAFIC.SplitButton()
        Me.btnClean = New YAFIC.SplitButton()
        Me.lstFolder = New System.Windows.Forms.ListBox()
        Me.panelBottom = New System.Windows.Forms.Panel()
        Me.btnApply = New YAFIC.SplitButton()
        Me.btnExit = New YAFIC.SplitButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tabIcon = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.ilvMain = New YAFIC.IconListView()
        Me.tabSoftware = New System.Windows.Forms.TabPage()
        Me.ilvSoftware = New YAFIC.IconListView()
        Me.tabMovies = New System.Windows.Forms.TabPage()
        Me.ilvMovies = New YAFIC.IconListView()
        Me.tabGames = New System.Windows.Forms.TabPage()
        Me.ilvGames = New YAFIC.IconListView()
        Me.tabMusic = New System.Windows.Forms.TabPage()
        Me.ilvMusic = New YAFIC.IconListView()
        Me.tabCustom = New System.Windows.Forms.TabPage()
        Me.ilvCustom = New YAFIC.IconListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnIconDelete = New YAFIC.CustomButton()
        Me.btnIconNew = New YAFIC.CustomButton()
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
        'mainSplit
        '
        Me.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainSplit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mainSplit.Location = New System.Drawing.Point(0, 0)
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
        Me.mainSplit.Size = New System.Drawing.Size(593, 421)
        Me.mainSplit.SplitterDistance = 132
        Me.mainSplit.SplitterWidth = 3
        Me.mainSplit.TabIndex = 0
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
        Me.panelTop.Size = New System.Drawing.Size(593, 132)
        Me.panelTop.TabIndex = 34
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.AutoSize = True
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(484, 12)
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
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.Location = New System.Drawing.Point(484, 45)
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
        Me.btnClean.Image = CType(resources.GetObject("btnClean.Image"), System.Drawing.Image)
        Me.btnClean.Location = New System.Drawing.Point(484, 78)
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
        'lstFolder
        '
        Me.lstFolder.AllowDrop = True
        Me.lstFolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstFolder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFolder.FormattingEnabled = True
        Me.lstFolder.HorizontalScrollbar = True
        Me.lstFolder.IntegralHeight = False
        Me.lstFolder.ItemHeight = 22
        Me.lstFolder.Location = New System.Drawing.Point(7, 12)
        Me.lstFolder.Name = "lstFolder"
        Me.lstFolder.Size = New System.Drawing.Size(471, 117)
        Me.lstFolder.TabIndex = 38
        '
        'panelBottom
        '
        Me.panelBottom.Controls.Add(Me.btnApply)
        Me.panelBottom.Controls.Add(Me.btnExit)
        Me.panelBottom.Controls.Add(Me.Button1)
        Me.panelBottom.Controls.Add(Me.tabIcon)
        Me.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBottom.Location = New System.Drawing.Point(0, 0)
        Me.panelBottom.Name = "panelBottom"
        Me.panelBottom.Size = New System.Drawing.Size(593, 286)
        Me.panelBottom.TabIndex = 36
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.AutoSize = True
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.Location = New System.Drawing.Point(404, 243)
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
        Me.btnExit.Location = New System.Drawing.Point(495, 243)
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(149, 243)
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
        Me.tabIcon.ItemSize = New System.Drawing.Size(42, 22)
        Me.tabIcon.Location = New System.Drawing.Point(7, 6)
        Me.tabIcon.Name = "tabIcon"
        Me.tabIcon.SelectedIndex = 0
        Me.tabIcon.Size = New System.Drawing.Size(579, 231)
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
        Me.tabMain.Size = New System.Drawing.Size(571, 201)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'ilvMain
        '
        Me.ilvMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMain.Location = New System.Drawing.Point(3, 3)
        Me.ilvMain.MultiSelect = False
        Me.ilvMain.Name = "ilvMain"
        Me.ilvMain.OwnerDraw = True
        Me.ilvMain.ShowItemToolTips = True
        Me.ilvMain.Size = New System.Drawing.Size(565, 195)
        Me.ilvMain.TabIndex = 1
        Me.ilvMain.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMain.UseCompatibleStateImageBehavior = False
        Me.ilvMain.View = System.Windows.Forms.View.Tile
        Me.ilvMain.WatermarkAlpha = 200
        Me.ilvMain.WatermarkImage = CType(resources.GetObject("ilvMain.WatermarkImage"), System.Drawing.Bitmap)
        '
        'tabSoftware
        '
        Me.tabSoftware.Controls.Add(Me.ilvSoftware)
        Me.tabSoftware.ImageIndex = 1
        Me.tabSoftware.Location = New System.Drawing.Point(4, 26)
        Me.tabSoftware.Name = "tabSoftware"
        Me.tabSoftware.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSoftware.Size = New System.Drawing.Size(558, 181)
        Me.tabSoftware.TabIndex = 3
        Me.tabSoftware.Text = "Software"
        Me.tabSoftware.UseVisualStyleBackColor = True
        '
        'ilvSoftware
        '
        Me.ilvSoftware.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvSoftware.Location = New System.Drawing.Point(3, 3)
        Me.ilvSoftware.MultiSelect = False
        Me.ilvSoftware.Name = "ilvSoftware"
        Me.ilvSoftware.OwnerDraw = True
        Me.ilvSoftware.Size = New System.Drawing.Size(552, 175)
        Me.ilvSoftware.TabIndex = 2
        Me.ilvSoftware.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvSoftware.UseCompatibleStateImageBehavior = False
        Me.ilvSoftware.View = System.Windows.Forms.View.Tile
        Me.ilvSoftware.WatermarkAlpha = 200
        Me.ilvSoftware.WatermarkImage = CType(resources.GetObject("ilvSoftware.WatermarkImage"), System.Drawing.Bitmap)
        '
        'tabMovies
        '
        Me.tabMovies.AutoScroll = True
        Me.tabMovies.Controls.Add(Me.ilvMovies)
        Me.tabMovies.ImageIndex = 2
        Me.tabMovies.Location = New System.Drawing.Point(4, 26)
        Me.tabMovies.Name = "tabMovies"
        Me.tabMovies.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMovies.Size = New System.Drawing.Size(558, 181)
        Me.tabMovies.TabIndex = 1
        Me.tabMovies.Text = "Movies"
        Me.tabMovies.UseVisualStyleBackColor = True
        '
        'ilvMovies
        '
        Me.ilvMovies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMovies.Location = New System.Drawing.Point(3, 3)
        Me.ilvMovies.MultiSelect = False
        Me.ilvMovies.Name = "ilvMovies"
        Me.ilvMovies.OwnerDraw = True
        Me.ilvMovies.Size = New System.Drawing.Size(552, 175)
        Me.ilvMovies.TabIndex = 2
        Me.ilvMovies.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMovies.UseCompatibleStateImageBehavior = False
        Me.ilvMovies.View = System.Windows.Forms.View.Tile
        Me.ilvMovies.WatermarkAlpha = 200
        Me.ilvMovies.WatermarkImage = CType(resources.GetObject("ilvMovies.WatermarkImage"), System.Drawing.Bitmap)
        '
        'tabGames
        '
        Me.tabGames.Controls.Add(Me.ilvGames)
        Me.tabGames.ImageIndex = 3
        Me.tabGames.Location = New System.Drawing.Point(4, 26)
        Me.tabGames.Name = "tabGames"
        Me.tabGames.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGames.Size = New System.Drawing.Size(558, 181)
        Me.tabGames.TabIndex = 2
        Me.tabGames.Text = "Games"
        Me.tabGames.UseVisualStyleBackColor = True
        '
        'ilvGames
        '
        Me.ilvGames.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvGames.Location = New System.Drawing.Point(3, 3)
        Me.ilvGames.MultiSelect = False
        Me.ilvGames.Name = "ilvGames"
        Me.ilvGames.OwnerDraw = True
        Me.ilvGames.Size = New System.Drawing.Size(552, 175)
        Me.ilvGames.TabIndex = 2
        Me.ilvGames.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvGames.UseCompatibleStateImageBehavior = False
        Me.ilvGames.View = System.Windows.Forms.View.Tile
        Me.ilvGames.WatermarkAlpha = 200
        Me.ilvGames.WatermarkImage = CType(resources.GetObject("ilvGames.WatermarkImage"), System.Drawing.Bitmap)
        '
        'tabMusic
        '
        Me.tabMusic.Controls.Add(Me.ilvMusic)
        Me.tabMusic.ImageIndex = 4
        Me.tabMusic.Location = New System.Drawing.Point(4, 26)
        Me.tabMusic.Name = "tabMusic"
        Me.tabMusic.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMusic.Size = New System.Drawing.Size(558, 181)
        Me.tabMusic.TabIndex = 5
        Me.tabMusic.Text = "Music"
        Me.tabMusic.UseVisualStyleBackColor = True
        '
        'ilvMusic
        '
        Me.ilvMusic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvMusic.Location = New System.Drawing.Point(3, 3)
        Me.ilvMusic.MultiSelect = False
        Me.ilvMusic.Name = "ilvMusic"
        Me.ilvMusic.OwnerDraw = True
        Me.ilvMusic.Size = New System.Drawing.Size(552, 175)
        Me.ilvMusic.TabIndex = 2
        Me.ilvMusic.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvMusic.UseCompatibleStateImageBehavior = False
        Me.ilvMusic.View = System.Windows.Forms.View.Tile
        Me.ilvMusic.WatermarkAlpha = 200
        Me.ilvMusic.WatermarkImage = CType(resources.GetObject("ilvMusic.WatermarkImage"), System.Drawing.Bitmap)
        '
        'tabCustom
        '
        Me.tabCustom.Controls.Add(Me.ilvCustom)
        Me.tabCustom.Controls.Add(Me.Panel1)
        Me.tabCustom.ImageIndex = 5
        Me.tabCustom.Location = New System.Drawing.Point(4, 26)
        Me.tabCustom.Name = "tabCustom"
        Me.tabCustom.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCustom.Size = New System.Drawing.Size(571, 201)
        Me.tabCustom.TabIndex = 4
        Me.tabCustom.Text = "Custom..."
        Me.tabCustom.UseVisualStyleBackColor = True
        '
        'ilvCustom
        '
        Me.ilvCustom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ilvCustom.Location = New System.Drawing.Point(3, 3)
        Me.ilvCustom.MultiSelect = False
        Me.ilvCustom.Name = "ilvCustom"
        Me.ilvCustom.OwnerDraw = True
        Me.ilvCustom.Size = New System.Drawing.Size(495, 195)
        Me.ilvCustom.TabIndex = 41
        Me.ilvCustom.TileSize = New System.Drawing.Size(48, 48)
        Me.ilvCustom.UseCompatibleStateImageBehavior = False
        Me.ilvCustom.View = System.Windows.Forms.View.Tile
        Me.ilvCustom.WatermarkAlpha = 200
        Me.ilvCustom.WatermarkImage = CType(resources.GetObject("ilvCustom.WatermarkImage"), System.Drawing.Bitmap)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnIconDelete)
        Me.Panel1.Controls.Add(Me.btnIconNew)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(498, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 195)
        Me.Panel1.TabIndex = 40
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
        'frmFavorites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 421)
        Me.Controls.Add(Me.mainSplit)
        Me.Name = "frmFavorites"
        Me.Text = "frmFavorites"
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

    End Sub
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
