<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTip))
        Me.pnlTip = New System.Windows.Forms.Panel()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.cboStart = New System.Windows.Forms.ComboBox()
        Me.btnNext = New FolderIconCustomizer.CustomButton()
        Me.btnPrevious = New FolderIconCustomizer.CustomButton()
        Me.btnCancel = New FolderIconCustomizer.CustomButton()
        Me.pnlTip.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTip
        '
        Me.pnlTip.BackColor = System.Drawing.Color.White
        Me.pnlTip.BackgroundImage = CType(resources.GetObject("pnlTip.BackgroundImage"), System.Drawing.Image)
        Me.pnlTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTip.Controls.Add(Me.lblTip)
        Me.pnlTip.Location = New System.Drawing.Point(12, 12)
        Me.pnlTip.Name = "pnlTip"
        Me.pnlTip.Size = New System.Drawing.Size(335, 200)
        Me.pnlTip.TabIndex = 1
        '
        'lblTip
        '
        Me.lblTip.BackColor = System.Drawing.Color.Transparent
        Me.lblTip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTip.Location = New System.Drawing.Point(0, 0)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Padding = New System.Windows.Forms.Padding(5)
        Me.lblTip.Size = New System.Drawing.Size(333, 198)
        Me.lblTip.TabIndex = 0
        '
        'cboStart
        '
        Me.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStart.FormattingEnabled = True
        Me.cboStart.Items.AddRange(New Object() {"Never show tips at the start up.", "Always show tips at start up."})
        Me.cboStart.Location = New System.Drawing.Point(49, 252)
        Me.cboStart.Name = "cboStart"
        Me.cboStart.Size = New System.Drawing.Size(266, 21)
        Me.cboStart.TabIndex = 4
        '
        'btnNext
        '
        Me.btnNext.AutoSize = True
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnNext.Location = New System.Drawing.Point(140, 218)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 28)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "&Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.AutoSize = True
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnPrevious.Location = New System.Drawing.Point(49, 218)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(85, 28)
        Me.btnPrevious.TabIndex = 2
        Me.btnPrevious.Text = "&Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AutoSize = True
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnCancel.Location = New System.Drawing.Point(231, 218)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 28)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmTip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(359, 284)
        Me.Controls.Add(Me.cboStart)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.pnlTip)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTip"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tip Of The Day"
        Me.pnlTip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As FolderIconCustomizer.CustomButton
    Friend WithEvents pnlTip As System.Windows.Forms.Panel
    Friend WithEvents btnPrevious As FolderIconCustomizer.CustomButton
    Friend WithEvents btnNext As FolderIconCustomizer.CustomButton
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents cboStart As System.Windows.Forms.ComboBox
End Class
