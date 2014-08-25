Public Class frmTip

    Public fso As Scripting.FileSystemObject
    Public txs, txsTemp As Scripting.TextStream
    Public intFlag As Integer

    '#constants used by the <Tip of the day> dialog's <Previous> and <Next> buttons
    Public Enum tipDirectionConstants
        tipPrevious = 1
        tipNext
    End Enum

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        fso = New Scripting.FileSystemObject()
        txs = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\tips.tip", Scripting.IOMode.ForWriting, True)
        txsTemp = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\tip.tip", Scripting.IOMode.ForReading)
        Dim strLine As String = ""

        Dim intC As Integer = 1
        Do While Not txsTemp.AtEndOfStream
            strLine = txsTemp.ReadLine()

            If intC <> 4 Then
                txs.WriteLine(strLine)
            Else
                ' txs.WriteLine("ShowAtStartup=" & (IIf(cboStart.SelectedIndex = 1, 1, 0)))
            End If
            intC += 1
        Loop

        txs.Close()
        txsTemp.Close()

        ' fso.CopyFile(My.Application.Info.DirectoryPath & "\tips.tip", My.Application.Info.DirectoryPath & "\tip.tip", True)
        '  fso.DeleteFile(My.Application.Info.DirectoryPath & "\tips.tip", True)

        txs = Nothing
        txsTemp = Nothing
        fso = Nothing



        Me.Close()

        If intFlag = 1 Then
            '  mdiMain.DefInstance.Show()
        End If
    End Sub

    Private Sub frmTip_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '#read in and display the current tip
        Dim intShowAtStart As Integer = ReadCurrentTip(tipDirectionConstants.tipNext)
    End Sub

    Private Function ReadCurrentTip(ByRef intDirection As tipDirectionConstants) As Integer
        fso = New Scripting.FileSystemObject()
        txs = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\tip.tip", Scripting.IOMode.ForReading)
        Dim intC, intTotalTips As Integer
        Dim strLine As String = ""

        '#find TotalTips and CurrentTip
        For intC = 1 To 3
            strLine = txs.ReadLine()
            If intC = 2 Then
                intTotalTips = Val(Mid(strLine, (strLine.IndexOf("="c) + 1) + 1))
            End If
        Next
        Dim intD As Integer = Val(Mid(strLine, (strLine.IndexOf("="c) + 1) + 1)) 'this is CurrentTip number

        '#next read in ShowAtStartup value
        strLine = txs.ReadLine()
        Dim intShowAtStartup As Integer = Val(Strings.Right(strLine, 1))

        '#skip the next two lines to reach the beginning of tips
        For intC = 1 To 4
            strLine = txs.ReadLine()
        Next

        If intDirection = tipDirectionConstants.tipNext Then
            intD += 1
            If intD > intTotalTips Then intD = 1
        ElseIf intDirection = tipDirectionConstants.tipPrevious Then
            intD -= 1
            If intD < 1 Then intD = intTotalTips
        End If

        '#now read in the actual current tip
        intC = 1
        Do While Not txs.AtEndOfStream
            strLine = txs.ReadLine()
            If intC = intD Then
                Exit Do
            End If
            intC += 1
        Loop

        lblTip.Text = Strings.Mid(strLine, (strLine.IndexOf("="c) + 1) + 1)
        lblTip.Text = lblTip.Text.Replace("~", Strings.Chr(13).ToString())

        txs.Close()
        txs = Nothing
        fso = Nothing

        '#update current tip number
        ' WriteCurrentTip(intD)

        Return intShowAtStartup
    End Function

    Private Sub WriteCurrentTip(ByRef intCT As Integer)
        fso = New Scripting.FileSystemObject()
        txs = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\tip.tip", Scripting.IOMode.ForWriting, True)
        txsTemp = fso.OpenTextFile(My.Application.Info.DirectoryPath & "\tip.tip", Scripting.IOMode.ForReading)
        Dim strLine As String = ""

        Dim intC As Integer = 1
        Do While Not txsTemp.AtEndOfStream
            strLine = txsTemp.ReadLine()

            If intC <> 3 Then
                txs.WriteLine(strLine)
            Else
                txs.WriteLine("CurrentTip=" & intCT)
            End If
            intC += 1
        Loop

        txs.Close()
        txsTemp.Close()

        '  fso.CopyFile(My.Application.Info.DirectoryPath & "\tip.tip", My.Application.Info.DirectoryPath & "\tip.tip", True)
        '  fso.DeleteFile(My.Application.Info.DirectoryPath & "\tip.tip", True)

        txs = Nothing
        txsTemp = Nothing
        fso = Nothing
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        ReadCurrentTip(tipDirectionConstants.tipNext)
    End Sub

    Private Sub btnPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevious.Click
        ReadCurrentTip(tipDirectionConstants.tipPrevious)
    End Sub
End Class