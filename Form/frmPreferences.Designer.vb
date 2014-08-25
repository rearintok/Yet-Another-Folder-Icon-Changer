<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferences))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.imlIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Line1 = New YAFIC.Line()
        Me.btnCancel = New YAFIC.CustomButton()
        Me.btnApply = New YAFIC.CustomButton()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Line1)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnApply)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 281)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 50)
        Me.Panel1.TabIndex = 6
        '
        'imlIcon
        '
        Me.imlIcon.ImageStream = CType(resources.GetObject("imlIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlIcon.TransparentColor = System.Drawing.Color.Transparent
        Me.imlIcon.Images.SetKeyName(0, "Gnome-Applications-Other-32.png")
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line1.EndColor = System.Drawing.Color.Transparent
        Me.Line1.LineDirection = YAFIC.Line.Direction.Horizontal
        Me.Line1.LineWidth = 1
        Me.Line1.Location = New System.Drawing.Point(0, 0)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(402, 2)
        Me.Line1.StartColor = System.Drawing.SystemColors.Highlight
        Me.Line1.TabIndex = 6
        Me.Line1.UseGradientInterpolation = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(309, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApply.AutoSize = True
        Me.btnApply.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnApply.Image = CType(resources.GetObject("btnApply.Image"), System.Drawing.Image)
        Me.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnApply.Location = New System.Drawing.Point(223, 10)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(80, 30)
        Me.btnApply.TabIndex = 5
        Me.btnApply.Text = "&Apply"
        Me.btnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(402, 331)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreferences"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Preferences"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnApply As YAFIC.CustomButton
    Friend WithEvents btnCancel As YAFIC.CustomButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Line1 As YAFIC.Line
    Friend WithEvents imlIcon As System.Windows.Forms.ImageList
End Class
