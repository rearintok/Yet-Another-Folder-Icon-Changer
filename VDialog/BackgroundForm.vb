''' <summary>
''' Form used in LockSystem mode. Contains an image of grayed desktop.
''' </summary>
Friend Class BackgroundForm
    Inherits Form

    Private ReadOnly background As Bitmap

    Public Sub New(ByVal background As Bitmap)
        Me.BackColor = Color.Black
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Location = Point.Empty
        Me.Size = Screen.PrimaryScreen.Bounds.Size
        Me.StartPosition = FormStartPosition.Manual
        Me.Visible = True
        Me.background = background
    End Sub

    Protected Overrides Sub OnShown(ByVal e As System.EventArgs)
        Me.BackgroundImage = background
        Me.DoubleBuffered = True
        MyBase.OnShown(e)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BackgroundForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "BackgroundForm"
        Me.ResumeLayout(False)

    End Sub
End Class