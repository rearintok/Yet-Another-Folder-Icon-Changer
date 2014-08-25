<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLanguages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLanguages))
        Me.imlTab = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
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
        'frmLanguages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(510, 391)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(175, 150)
        Me.Name = "frmLanguages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmLanguages"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imlTab As System.Windows.Forms.ImageList
End Class
