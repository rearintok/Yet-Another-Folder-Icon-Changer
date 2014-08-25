<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CListView1 = New YAFIC.cListView()
        Me.colLibraries = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAuthor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLicense = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New YAFIC.SplitButton()
        Me.btnHelp = New YAFIC.SplitButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(377, 332)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(369, 306)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "About"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(369, 306)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "License"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.CListView1)
        Me.TabPage3.Controls.Add(Me.Label1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(369, 306)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Credits"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(278, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Complete information of Authors is in the Help Contents."
        '
        'CListView1
        '
        Me.CListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLibraries, Me.colAuthor, Me.colLicense})
        Me.CListView1.ColumnSortBy = YAFIC.ListViewColumnSorter.SortModifiers.SortByText
        Me.CListView1.ColumnSorting = False
        Me.CListView1.Location = New System.Drawing.Point(11, 43)
        Me.CListView1.Name = "CListView1"
        Me.CListView1.OwnerDraw = True
        Me.CListView1.ShowFocusRectangle = False
        Me.CListView1.Size = New System.Drawing.Size(347, 229)
        Me.CListView1.TabIndex = 1
        Me.CListView1.UseCompatibleStateImageBehavior = False
        Me.CListView1.UseVistaThemeing = True
        Me.CListView1.View = System.Windows.Forms.View.Details
        Me.CListView1.WatermarkAlpha = 200
        Me.CListView1.WatermarkImage = Nothing
        '
        'colLibraries
        '
        Me.colLibraries.Text = "Libraires"
        Me.colLibraries.Width = 118
        '
        'colAuthor
        '
        Me.colAuthor.Text = "Author"
        Me.colAuthor.Width = 92
        '
        'colLicense
        '
        Me.colLicense.Text = "License"
        Me.colLicense.Width = 115
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(354, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Some component use external libraries and make extensive use of the following per" & _
    "son's or companies code:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.AutoSize = True
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(305, 349)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 31)
        Me.btnClose.SplitMenu = Nothing
        Me.btnClose.SplitMenuStrip = Nothing
        Me.btnClose.TabIndex = 43
        Me.btnClose.Text = "&Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.AutoSize = True
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(9, 349)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(78, 31)
        Me.btnHelp.SplitMenu = Nothing
        Me.btnHelp.SplitMenuStrip = Nothing
        Me.btnHelp.TabIndex = 44
        Me.btnHelp.Text = "&Help"
        Me.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(394, 385)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As YAFIC.SplitButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CListView1 As YAFIC.cListView
    Friend WithEvents colLibraries As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAuthor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colLicense As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnHelp As YAFIC.SplitButton
End Class
