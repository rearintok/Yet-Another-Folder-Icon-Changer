Imports System.Drawing.Drawing2D
Imports System.Drawing.IconLib
Imports System.Drawing.Imaging

Public Class frmIconProperties

    Dim mouseIndex As Integer = -1
    Public icn As Icon
    Public IconDir As String
    Public IconIndex As Integer
    Private ReadOnly mMultiIcon As New MultiIcon()

    Private Sub btnExit_Click(sender As System.Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmIconProperties_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub

    Private Sub frmIconProperties_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        Dim info As New IconInfo(icn)
        Const sizeFormat As String = "{0}x{1} [{2}]"

        lblFormatCount.Text = String.Format("{0} Formats:", info.Images.Count)

        If icn Is Nothing Then
            Return
        End If
        Dim l As List(Of Icon) = IconHelper.SplitGroupIcon(icn)
        For Each ico As Icon In l
            Dim item As New IconInfo(ico)
            lstFormats.Items.Add(String.Format(sizeFormat, ico.Width, ico.Height, GetFriendlyBitDepth(item.PixelFormat)))
        Next

        mMultiIcon.Load(IconDir)
        mMultiIcon.SelectedIndex = IconIndex
        lstFormats.SelectedIndex = 0
        
        pIcon.Image = DrawReflection(pIcon.Image, Color.White)
        mnuImage.Renderer = New MyRenderer
    End Sub
    
    Private Sub lstFormats_DrawItem(sender As Object, e As Windows.Forms.DrawItemEventArgs) Handles lstFormats.DrawItem
        If e.Index = -1 Then Exit Sub
        Dim listBox As Windows.Forms.ListBox = CType(sender, Windows.Forms.ListBox)
        e.DrawBackground()
        Dim isItemSelected As Boolean = ((e.State And DrawItemState.Selected) = DrawItemState.Selected)
        If e.Index >= 0 AndAlso e.Index < listBox.Items.Count Then
            Dim textSize As SizeF = e.Graphics.MeasureString(listBox.Items(e.Index).ToString(), listBox.Font)
            'Dim itemImage As Image = My.Resources.FolderHorizontal
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
            'e.Graphics.DrawImage(itemImage, e.Bounds.X + 2, e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2, itemImage.Width, itemImage.Height)
            'draw the item text
            Dim x, y As Single
            Dim h As Single = textSize.Height
            Dim rect As Rectangle = e.Bounds
            rect.X += listBox.ItemHeight
            rect.Width -= listBox.ItemHeight

            x = e.Bounds.X
            y = rect.Y + (rect.Height - h) / 2

            Dim itemText As String = listBox.Items(e.Index).ToString()
            TextRenderer.DrawText(e.Graphics, itemText, e.Font, New Rectangle(x, y, ClientRectangle.Width, ClientRectangle.Height), itemTextColorBrush, TextFormatFlags.Default)
            'clean up
            backgroundColorBrush.Dispose()
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub lstFormats_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lstFormats.MouseMove
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

    Private Sub pnlIcon_Paint(sender As System.Object, e As Windows.Forms.PaintEventArgs) Handles pnlIcon.Paint
        Using bgBitmap As New Bitmap(16, 16)
            Using g = Graphics.FromImage(bgBitmap)
                Using sb As New SolidBrush(Color.FromArgb(16, Color.Black))
                    g.FillRectangle(sb, New Rectangle(0, 0, 8, 8))
                    g.FillRectangle(sb, New Rectangle(8, 8, 8, 8))
                End Using
            End Using
            Using bgBrush As New TextureBrush(bgBitmap)
                e.Graphics.FillRectangle(bgBrush, ClientRectangle)
            End Using
        End Using
    End Sub

    Private Sub lstFormats_SelectedIndexChanged(sender As System.Object, e As EventArgs) Handles lstFormats.SelectedIndexChanged
        If lstFormats.SelectedIndex = -1 Then
            Return
        End If

        Dim iconImage As IconImage = mMultiIcon(IconIndex)(lstFormats.SelectedIndex)
        picCurrrentImage.Image = iconImage.Icon.ToBitmap()
    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As EventArgs) Handles mnuExport.Click
        dlgSave.DefaultExt = "png"
        dlgSave.Filter = "W3C Portable Network Graphic Images File (*.png)|*.png|Windows Bitmap Images File (*.bmp)|*.bmp"
        If dlgSave.ShowDialog(Me) = DialogResult.OK Then
            If dlgSave.FileName.ToLower().EndsWith(".png") AndAlso mMultiIcon.SelectedIndex <> -1 AndAlso lstFormats.SelectedIndex <> -1 Then
                mMultiIcon(mMultiIcon.SelectedIndex)(lstFormats.SelectedIndex).Transparent.Save(dlgSave.FileName, ImageFormat.Png)
            ElseIf dlgSave.FileName.ToLower().EndsWith(".bmp") AndAlso mMultiIcon.SelectedIndex <> -1 AndAlso lstFormats.SelectedIndex <> -1 Then
                mMultiIcon(mMultiIcon.SelectedIndex)(lstFormats.SelectedIndex).Transparent.Save(dlgSave.FileName, ImageFormat.Bmp)
            End If
        End If
    End Sub

    
End Class