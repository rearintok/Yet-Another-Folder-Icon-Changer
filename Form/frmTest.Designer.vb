<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTest))
        Me.tlbarMain = New System.Windows.Forms.ToolStrip()
        Me.tlbarMainView = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tlbarMainView16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlbarMainView24 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlbarMainView32 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlbarMainView48 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlbarMainView64 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlbarMainView96 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilTree = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.diagSaveIcon = New System.Windows.Forms.SaveFileDialog()
        Me.IconListView1 = New YAFIC.IconListView()
        Me.panelSplit = New System.Windows.Forms.Splitter()
        Me.tlbarMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbarMain
        '
        Me.tlbarMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbarMainView})
        Me.tlbarMain.Location = New System.Drawing.Point(0, 0)
        Me.tlbarMain.Name = "tlbarMain"
        Me.tlbarMain.Size = New System.Drawing.Size(644, 25)
        Me.tlbarMain.TabIndex = 9
        Me.tlbarMain.Text = "toolStrip1"
        '
        'tlbarMainView
        '
        Me.tlbarMainView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlbarMainView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbarMainView16, Me.tlbarMainView24, Me.tlbarMainView32, Me.tlbarMainView48, Me.tlbarMainView64, Me.tlbarMainView96})
        Me.tlbarMainView.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tlbarMainView.Name = "tlbarMainView"
        Me.tlbarMainView.Size = New System.Drawing.Size(42, 22)
        Me.tlbarMainView.Text = "&View"
        '
        'tlbarMainView16
        '
        Me.tlbarMainView16.Name = "tlbarMainView16"
        Me.tlbarMainView16.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView16.Text = "16 x 16"
        '
        'tlbarMainView24
        '
        Me.tlbarMainView24.Name = "tlbarMainView24"
        Me.tlbarMainView24.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView24.Text = "24 x 24"
        '
        'tlbarMainView32
        '
        Me.tlbarMainView32.Name = "tlbarMainView32"
        Me.tlbarMainView32.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView32.Text = "32 x 32"
        '
        'tlbarMainView48
        '
        Me.tlbarMainView48.Name = "tlbarMainView48"
        Me.tlbarMainView48.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView48.Text = "48 x 48"
        '
        'tlbarMainView64
        '
        Me.tlbarMainView64.Name = "tlbarMainView64"
        Me.tlbarMainView64.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView64.Text = "64 x 64"
        '
        'tlbarMainView96
        '
        Me.tlbarMainView96.Name = "tlbarMainView96"
        Me.tlbarMainView96.Size = New System.Drawing.Size(110, 22)
        Me.tlbarMainView96.Text = "96 x 96"
        '
        'ilTree
        '
        Me.ilTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ilTree.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilTree.TransparentColor = System.Drawing.Color.Transparent
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 34)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'diagSaveIcon
        '
        Me.diagSaveIcon.DefaultExt = "*.ico"
        Me.diagSaveIcon.Filter = "Icon Files|*.ico"
        Me.diagSaveIcon.Title = "Save Icon"
        '
        'IconListView1
        '
        Me.IconListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconListView1.Location = New System.Drawing.Point(12, 28)
        Me.IconListView1.Name = "IconListView1"
        Me.IconListView1.OwnerDraw = True
        Me.IconListView1.Size = New System.Drawing.Size(620, 314)
        Me.IconListView1.TabIndex = 0
        Me.IconListView1.TileSize = New System.Drawing.Size(48, 48)
        Me.IconListView1.UseCompatibleStateImageBehavior = False
        Me.IconListView1.View = System.Windows.Forms.View.Tile
        Me.IconListView1.WatermarkAlpha = 100
        Me.IconListView1.WatermarkImage = CType(resources.GetObject("IconListView1.WatermarkImage"), System.Drawing.Bitmap)
        '
        'panelSplit
        '
        Me.panelSplit.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.panelSplit.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSplit.Location = New System.Drawing.Point(0, 25)
        Me.panelSplit.MinExtra = 200
        Me.panelSplit.MinSize = 132
        Me.panelSplit.Name = "panelSplit"
        Me.panelSplit.Size = New System.Drawing.Size(644, 3)
        Me.panelSplit.TabIndex = 37
        Me.panelSplit.TabStop = False
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 414)
        Me.Controls.Add(Me.panelSplit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tlbarMain)
        Me.Controls.Add(Me.IconListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.tlbarMain.ResumeLayout(False)
        Me.tlbarMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IconListView1 As YAFIC.IconListView
    Private WithEvents tlbarMain As System.Windows.Forms.ToolStrip
    Private WithEvents tlbarMainView As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tlbarMainView16 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlbarMainView24 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlbarMainView32 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlbarMainView48 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlbarMainView64 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tlbarMainView96 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ilTree As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents diagSaveIcon As System.Windows.Forms.SaveFileDialog
    Friend WithEvents panelSplit As System.Windows.Forms.Splitter
End Class
