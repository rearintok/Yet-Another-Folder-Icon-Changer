<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIconProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIconProperties))
        Me.tabProperties = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.lblFormatCount = New System.Windows.Forms.Label()
        Me.lstFormats = New System.Windows.Forms.ListBox()
        Me.lblFormats = New System.Windows.Forms.Label()
        Me.Line2 = New YAFIC.Line()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.Line1 = New YAFIC.Line()
        Me.pIcon = New System.Windows.Forms.PictureBox()
        Me.tabImage = New System.Windows.Forms.TabPage()
        Me.pnlIcon = New System.Windows.Forms.Panel()
        Me.picCurrrentImage = New System.Windows.Forms.PictureBox()
        Me.mnuImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnHelp = New YAFIC.SplitButton()
        Me.btnExit = New YAFIC.SplitButton()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.tabProperties.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        CType(Me.pIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabImage.SuspendLayout()
        Me.pnlIcon.SuspendLayout()
        CType(Me.picCurrrentImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuImage.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabProperties
        '
        Me.tabProperties.Controls.Add(Me.tabGeneral)
        Me.tabProperties.Controls.Add(Me.tabImage)
        Me.tabProperties.Location = New System.Drawing.Point(8, 12)
        Me.tabProperties.Name = "tabProperties"
        Me.tabProperties.SelectedIndex = 0
        Me.tabProperties.Size = New System.Drawing.Size(326, 336)
        Me.tabProperties.TabIndex = 0
        '
        'tabGeneral
        '
        Me.tabGeneral.Controls.Add(Me.lblFormatCount)
        Me.tabGeneral.Controls.Add(Me.lstFormats)
        Me.tabGeneral.Controls.Add(Me.lblFormats)
        Me.tabGeneral.Controls.Add(Me.Line2)
        Me.tabGeneral.Controls.Add(Me.lblFile)
        Me.tabGeneral.Controls.Add(Me.Line1)
        Me.tabGeneral.Controls.Add(Me.pIcon)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(318, 310)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        Me.tabGeneral.UseVisualStyleBackColor = True
        '
        'lblFormatCount
        '
        Me.lblFormatCount.AutoSize = True
        Me.lblFormatCount.Location = New System.Drawing.Point(64, 138)
        Me.lblFormatCount.Name = "lblFormatCount"
        Me.lblFormatCount.Size = New System.Drawing.Size(55, 13)
        Me.lblFormatCount.TabIndex = 6
        Me.lblFormatCount.Text = "4 Formats"
        '
        'lstFormats
        '
        Me.lstFormats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstFormats.FormattingEnabled = True
        Me.lstFormats.IntegralHeight = False
        Me.lstFormats.ItemHeight = 18
        Me.lstFormats.Location = New System.Drawing.Point(125, 138)
        Me.lstFormats.Name = "lstFormats"
        Me.lstFormats.Size = New System.Drawing.Size(176, 155)
        Me.lstFormats.TabIndex = 0
        '
        'lblFormats
        '
        Me.lblFormats.AutoSize = True
        Me.lblFormats.Location = New System.Drawing.Point(65, 100)
        Me.lblFormats.Name = "lblFormats"
        Me.lblFormats.Size = New System.Drawing.Size(50, 13)
        Me.lblFormats.TabIndex = 4
        Me.lblFormats.Text = "Formats:"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.White
        Me.Line2.EndColor = System.Drawing.Color.White
        Me.Line2.LineDirection = YAFIC.Line.Direction.Horizontal
        Me.Line2.LineWidth = 1
        Me.Line2.Location = New System.Drawing.Point(67, 106)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(245, 20)
        Me.Line2.StartColor = System.Drawing.Color.DodgerBlue
        Me.Line2.TabIndex = 3
        Me.Line2.UseGradientInterpolation = True
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(64, 16)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(51, 13)
        Me.lblFile.TabIndex = 2
        Me.lblFile.Text = "Icon File:"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.EndColor = System.Drawing.Color.White
        Me.Line1.LineDirection = YAFIC.Line.Direction.Horizontal
        Me.Line1.LineWidth = 1
        Me.Line1.Location = New System.Drawing.Point(68, 22)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(244, 20)
        Me.Line1.StartColor = System.Drawing.Color.DodgerBlue
        Me.Line1.TabIndex = 1
        Me.Line1.UseGradientInterpolation = True
        '
        'pIcon
        '
        Me.pIcon.Image = CType(resources.GetObject("pIcon.Image"), System.Drawing.Image)
        Me.pIcon.Location = New System.Drawing.Point(10, 10)
        Me.pIcon.Name = "pIcon"
        Me.pIcon.Size = New System.Drawing.Size(48, 60)
        Me.pIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pIcon.TabIndex = 0
        Me.pIcon.TabStop = False
        '
        'tabImage
        '
        Me.tabImage.Controls.Add(Me.pnlIcon)
        Me.tabImage.Location = New System.Drawing.Point(4, 22)
        Me.tabImage.Name = "tabImage"
        Me.tabImage.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImage.Size = New System.Drawing.Size(318, 310)
        Me.tabImage.TabIndex = 1
        Me.tabImage.Text = "Current Image Format"
        Me.tabImage.UseVisualStyleBackColor = True
        '
        'pnlIcon
        '
        Me.pnlIcon.Controls.Add(Me.picCurrrentImage)
        Me.pnlIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIcon.Location = New System.Drawing.Point(3, 3)
        Me.pnlIcon.Name = "pnlIcon"
        Me.pnlIcon.Size = New System.Drawing.Size(312, 304)
        Me.pnlIcon.TabIndex = 4
        '
        'picCurrrentImage
        '
        Me.picCurrrentImage.ContextMenuStrip = Me.mnuImage
        Me.picCurrrentImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picCurrrentImage.Location = New System.Drawing.Point(0, 0)
        Me.picCurrrentImage.Name = "picCurrrentImage"
        Me.picCurrrentImage.Size = New System.Drawing.Size(312, 304)
        Me.picCurrrentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picCurrrentImage.TabIndex = 0
        Me.picCurrrentImage.TabStop = False
        '
        'mnuImage
        '
        Me.mnuImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExport, Me.ToolStripSeparator2, Me.ToolStripMenuItem2})
        Me.mnuImage.Name = "cIconList"
        Me.mnuImage.Size = New System.Drawing.Size(167, 54)
        '
        'mnuExport
        '
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(166, 22)
        Me.mnuExport.Text = "&Export Image As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(166, 22)
        Me.ToolStripMenuItem2.Text = "Image P&roperties"
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.AutoSize = True
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(8, 352)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(76, 31)
        Me.btnHelp.SplitMenu = Nothing
        Me.btnHelp.SplitMenuStrip = Nothing
        Me.btnHelp.TabIndex = 45
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.AutoSize = True
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.Location = New System.Drawing.Point(252, 352)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 31)
        Me.btnExit.SplitMenu = Nothing
        Me.btnExit.SplitMenuStrip = Nothing
        Me.btnExit.TabIndex = 42
        Me.btnExit.Text = "&Close"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "png"
        Me.dlgSave.Filter = "PNG Image File (*.png)|*.png"
        Me.dlgSave.SupportMultiDottedExtensions = True
        Me.dlgSave.Title = "Export Image to"
        '
        'frmIconProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(338, 389)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tabProperties)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIconProperties"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Icon Properties"
        Me.tabProperties.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.tabGeneral.PerformLayout()
        CType(Me.pIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabImage.ResumeLayout(False)
        Me.pnlIcon.ResumeLayout(False)
        CType(Me.picCurrrentImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuImage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabProperties As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabImage As System.Windows.Forms.TabPage
    Friend WithEvents pIcon As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As YAFIC.SplitButton
    Friend WithEvents Line1 As YAFIC.Line
    Friend WithEvents lblFormats As System.Windows.Forms.Label
    Friend WithEvents Line2 As YAFIC.Line
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lstFormats As System.Windows.Forms.ListBox
    Friend WithEvents btnHelp As YAFIC.SplitButton
    Friend WithEvents lblFormatCount As System.Windows.Forms.Label
    Friend WithEvents pnlIcon As System.Windows.Forms.Panel
    Friend WithEvents picCurrrentImage As System.Windows.Forms.PictureBox
    Private WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuImage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
End Class
