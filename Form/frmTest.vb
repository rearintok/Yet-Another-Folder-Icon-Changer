Imports System.IO

Public Class frmTest

    Private Sub frmTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadIconFromLibraryz(Application.StartupPath & "\Icons\folder.icl")
       
      

    End Sub
    
    Private Function LoadIconFromLibraryz(fileName As String)
        Dim extractedIcons As List(Of Icon)
        Try
            extractedIcons = IconHelper.ExtractAllIcons(fileName)
        Catch exp As Exception
            MessageBox.Show(Me, exp.Message, "Icon Extractor")
            Return False
        End Try
        Me.Refresh()
        ' fileNode = AddFileNode(fileName, True)
        For i As Integer = 0 To extractedIcons.Count - 1
            'Dim iconIndex As Integer = ilTree.Images.Count
            ' ilTree.Images.Add(i.ToString(), 
            ' IconHelper.GetBestFitIcon(extractedIcons(i), SystemInformation.SmallIconSize)
            Dim ic As Icon = IconHelper.GetBestFitIcon(extractedIcons(i), New Size(32, 32))
            Dim item As New IconListViewItem()
            ' item.Name = IconListView1.Items.Count.ToString().PadLeft(3, "0"c)
            item.Icon = ic
            IconListView1.Items.Add(item)
            ' Dim node As TreeNode = fileNode.Nodes.Add(i.ToString(), "Icon #" & i.ToString(), iconIndex, iconIndex)
            ' node.Tag = extractedIcons(i)
            item.Tag = extractedIcons(i)
        Next

        Return True
    End Function

    Private Sub AdjustView(width As Integer)

        tlbarMainView16.Checked = (width = 16)
        tlbarMainView24.Checked = (width = 24)
        tlbarMainView32.Checked = (width = 32)
        tlbarMainView48.Checked = (width = 48)
        tlbarMainView64.Checked = (width = 64)
        tlbarMainView96.Checked = (width = 96)
    End Sub

    Private Sub tlbarMainView16_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView16.Click
        IconListView1.TileSize = New Size(16, 16)
        AdjustView(16)
    End Sub

    Private Sub tlbarMainView24_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView24.Click
        IconListView1.TileSize = New Size(24, 24)
        AdjustView(24)
    End Sub

    Private Sub tlbarMainView32_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView32.Click
        IconListView1.TileSize = New Size(32, 32)
        AdjustView(32)
    End Sub

    Private Sub tlbarMainView48_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView48.Click
        IconListView1.TileSize = New Size(48, 48)
        AdjustView(48)
    End Sub

    Private Sub tlbarMainView64_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView64.Click
        IconListView1.TileSize = New Size(64, 64)
        AdjustView(64)
    End Sub

    Private Sub tlbarMainView96_Click(sender As System.Object, e As System.EventArgs) Handles tlbarMainView96.Click
        IconListView1.TileSize = New Size(96, 96)
        AdjustView(96)
    End Sub

    Private Sub SaveIcon(icon As Icon)
        If diagSaveIcon.ShowDialog(Me) = DialogResult.OK Then
            Dim fs As FileStream = File.Create(diagSaveIcon.FileName)
            icon.Save(fs)
            fs.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' Dim icon As Icon = DirectCast(treeIcons.SelectedNode.Tag, Icon)

        ' If icon IsNot Nothing Then
        'SaveIcon(Icon)
        ' End If

        Dim item As Icon = TryCast(IconListView1.SelectedItems(0).Tag, Icon)
        Me.Icon = item
        If item IsNot Nothing Then
            SaveIcon(item)
        End If

    End Sub
End Class