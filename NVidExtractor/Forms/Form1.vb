Imports System.Runtime.InteropServices

Public Class Form1
    Dim lastindex = 0
    Dim allowedCount = 2
    Dim selectedCount = 0
    Public lastclickedIndex = -1
    Public downStarted = False

    Dim downWarnShowed As Boolean = False
    Dim pandoraWarnShowed As Boolean = False

    Public saveLocation As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\"))

#Region "Interface"

    Public Sub AddItem(link As String)
        Dim currentId As String = GetVideoId(link)

        For Each ctrl As ItemPanel In ListPanel.Controls
            If ctrl.videoId = currentId Then
                Exit Sub
            End If
        Next

        Dim itemPanel As New ItemPanel
        itemPanel.Dock = DockStyle.Top
        itemPanel.index = lastindex
        itemPanel.OriginalURL = link
        itemPanel.videoId = currentId '비디오 키 설정 (중복 비디오 추가를 막기 위해)
        itemPanel.DownQuality = QualityCB.SelectedIndex
        itemPanel.Name = "itemPanel" + lastindex.ToString
        itemPanel.DownloadLoc = saveLocation

        If link.Contains("tv.kakao.com") Then
            '카카오는 영상밖에 없으므로
            itemPanel.DownMode = 1
            itemPanel.videoSiteType = "kakao"
        ElseIf link.Contains("pandora.tv") Or link.Contains("pan.best") Then
            itemPanel.DownMode = 1
            itemPanel.videoSiteType = "pandora"

            '판도라 경고 띄우기
            If Not pandoraWarnShowed Then
                MsgBox("판도라 영상을 추가하였습니다." + vbCr + vbCr _
                       + "판도라TV의 경우 추출은 가능하지만 다소 불안정적인 다운로드 속도를 보이고 있습니다. 그렇기 때문에 동시 다운로드가 불가능하며, 다운로드 도중 멈춤이 있을 수 있습니다." + vbCr + vbCr _
                       + "불안정한 상태가 지속된다면 비디오를 추가하신 뒤 메뉴 버튼(...) > 스트리밍 링크 추출을 클릭하여 브라우저 등에서 다운로드 받아 보시기 바랍니다.", vbInformation)
                pandoraWarnShowed = True
            End If
        Else
            itemPanel.DownMode = ModeCB.SelectedIndex + 1
            itemPanel.videoSiteType = "naver"
        End If

        lastindex += 1

        AddHandler itemPanel.RemoveClicked, AddressOf ctrl_RemoveClicked
        ListPanel.Controls.Add(itemPanel)

        CheckAndShowTip()
    End Sub

    Public Sub CheckAndShowTip()
        If ListPanel.Controls.Count < 1 Then
            TipLabel.Visible = True
            DownStartBT.Enabled = False
            SelectAllBT.Enabled = False
            DeleteCompleteBT.Enabled = False
        Else
            TipLabel.Visible = False
            DownStartBT.Enabled = True
            SelectAllBT.Enabled = True
            DeleteCompleteBT.Enabled = True
        End If
    End Sub

    Private Sub SaveLocTB_TextChanged(sender As Object, e As EventArgs) Handles SaveLocTB.TextChanged
        saveLocation = SaveLocTB.Text
    End Sub

#End Region

#Region "BTEvents"

    Private Sub GetBlogPostBT_Click(sender As Object, e As EventArgs) Handles GetBlogPostBT.Click
        If Not My.Computer.FileSystem.DirectoryExists(saveLocation) Then
            MsgBox("올바른 저장 경로를 지정해 주세요.", vbExclamation)
            Exit Sub
        End If

        Form2.ShowDialog(Me)
    End Sub

    Private Sub LinkAddBT_Click(sender As Object, e As EventArgs) Handles LinkAddBT.Click
        If UrlTB.Text = Nothing Then
            MsgBox("링크를 입력해 주세요.", vbExclamation)
            Exit Sub
        ElseIf Not ChkURL(UrlTB.Text) Then
            MsgBox("입력한 링크에 접속할 수 없습니다. 인터넷 연결 상태 또는 링크의 유효성을 확인해주세요.", vbExclamation)
            Exit Sub
        ElseIf Not My.Computer.FileSystem.DirectoryExists(saveLocation) Then
            MsgBox("올바른 저장 경로를 지정해 주세요.", vbExclamation)
            Exit Sub
        End If

        AddItem(UrlTB.Text)
        UrlTB.Text = Nothing
    End Sub

    Private Sub DownStartBT_Click(sender As Object, e As EventArgs) Handles DownStartBT.Click
        If downStarted Then
            downStarted = False
            DownCheckTimer.Stop()

            For Each ctrl As ItemPanel In ListPanel.Controls
                ctrl.PauseDown()
            Next

            LogForm.addLog("다운로드 타이머 정지됨")
            DownStartBT.Text = "다운로드 시작"
        Else
            downStarted = True

            For Each ctrl As ItemPanel In ListPanel.Controls
                If Not ctrl.WC.IsBusy And ctrl.Paused And ctrl.DownBegan And Not ctrl.DownFinished Then
                    ctrl.ResumeDown()
                End If
            Next

            DownCheckTimer.Start()
            LogForm.addLog("다운로드 타이머 시작됨")
            DownStartBT.Text = "일시 정지"
        End If
    End Sub

    Private Sub SelectAllBT_Click(sender As Object, e As EventArgs) Handles SelectAllBT.Click
        Dim allSelected = True

        For Each ctrl As ItemPanel In ListPanel.Controls
            If ctrl.Selected = False Then
                allSelected = False
                Exit For
            End If
        Next

        If allSelected Then '모두 다 선택되었다면 -> 모두 다 선택 해제하기
            For Each ctrl As ItemPanel In ListPanel.Controls
                ctrl.Selected = False
                ctrl.SelectModeApply(False)
            Next
        Else '모두 다 선택안되었다면 -> 모두 다 선택하기
            For Each ctrl As ItemPanel In ListPanel.Controls
                ctrl.Selected = True
                ctrl.SelectModeApply(True)
            Next
        End If

        CheckSelected()
    End Sub

    Private Sub SelectionApplyBT_Click(sender As Object, e As EventArgs) Handles SelectionApplyBT.Click
        If Not My.Computer.FileSystem.DirectoryExists(saveLocation) Then
            MsgBox("올바른 저장 경로를 지정해 주세요.", vbExclamation)
            Exit Sub
        End If

        Dim quality As Integer = QualityCB.SelectedIndex
        Dim downmode As Integer = 0

        downmode = ModeCB.SelectedIndex + 1

        For Each ctrl As ItemPanel In ListPanel.Controls
            '이미 시작하면 변경 못함
            If ctrl.Selected And Not ctrl.WC.IsBusy And Not ctrl.DownBegan Then
                LogForm.addLog("일괄 다운로드 설정적용 (" + ctrl.Name + ")")
                ctrl.DownQuality = quality
                ctrl.DownMode = downmode
                ctrl.DownloadLoc = saveLocation
                ctrl.SaveLocTB.Text = ctrl.DownloadLoc

                ctrl.SetQuality()
                ctrl.setMode()
            End If
        Next
    End Sub

    'Private Sub PauseBT_Click(sender As Object, e As EventArgs)
    ' For Each ctrl As ItemPanel In ListPanel.Controls
    ' If ctrl.Selected And ctrl.WC.IsBusy Then
    '             ctrl.WC.CancelAsync()
    ' End If
    ' Next
    'End Sub

    Private Sub ForceResetBT_Click(sender As Object, e As EventArgs) Handles ForceResetBT.Click
        If ListPanel.Controls.Count > 0 Then
            If MsgBox("다운받은 데이터가 초기화되고 처음부터 다시 받게 됩니다. 오류 등으로 인해 다운로드를 진행할 수 없는 경우에만 사용하세요." + vbCr + vbCr + "계속하시겠습니까?", vbExclamation + vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If

        For Each ctrl As ItemPanel In ListPanel.Controls
            If ctrl.Selected Then 'And Not ctrl.WC.IsBusy And ctrl.DownBegan And Not ctrl.DownFinished Then
                ctrl.forceReset(False)
            End If
        Next
    End Sub

    Private Sub DeleteCompleteBT_Click(sender As Object, e As EventArgs) Handles DeleteCompleteBT.Click
        If ListPanel.Controls.Count > 0 Then
            Dim killlist As New List(Of String)

            For Each ctrl As ItemPanel In ListPanel.Controls
                If ctrl.DownFinished Then
                    ctrl.WC.CancelAsync()
                    ctrl.WC = Nothing
                    killlist.Add(ctrl.Name)
                End If
            Next

            For Each n As String In killlist
                LogForm.addLog("완료 다운로드 삭제 (" + n + ")")
                ListPanel.Controls.RemoveByKey(n)
            Next
        End If

        CheckAndShowTip()
    End Sub

    Private Sub DeleteBT_Click(sender As Object, e As EventArgs) Handles DeleteBT.Click
        If ListPanel.Controls.Count > 0 Then
            Dim killlist As New List(Of String)

            For Each ctrl As ItemPanel In ListPanel.Controls
                If ctrl.Selected Then
                    ctrl.WC.CancelAsync()
                    ctrl.WC = Nothing
                    killlist.Add(ctrl.Name)
                End If
            Next

            For Each n As String In killlist
                LogForm.addLog("일괄 다운로드 삭제 (" + n + ")")
                ListPanel.Controls.RemoveByKey(n)
            Next
        End If

        CheckAndShowTip()
    End Sub

    Private Sub LogBT_Click(sender As Object, e As EventArgs) Handles LogBT.Click
        LogForm.SetDesktopLocation(Location.X + Width, Location.Y)
        LogForm.Show()
    End Sub

    Private Sub SetLocationBT_Click(sender As Object, e As EventArgs) Handles SetLocationBT.Click
        If My.Computer.FileSystem.DirectoryExists(saveLocation) Then
            FolderBrowserDialog1.SelectedPath = saveLocation
        End If

        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            SaveLocTB.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

#End Region

    Private Sub ctrl_RemoveClicked(sender As Object, e As EventArgs)
        ListPanel.Controls.Remove(DirectCast(sender, Control))
        CheckAndShowTip()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QualityCB.SelectedIndex = 3
        ModeCB.SelectedIndex = 1
        SaveLocTB.Text = saveLocation
        CheckAndShowTip()
        CheckSelected()
    End Sub

    Private Sub DownCheckTimer_Tick(sender As Object, e As EventArgs) Handles DownCheckTimer.Tick
        Dim busycount = 0
        Dim unfinished = 0
        '판도라는 한번에 하나밖에 못받도록 해야함 (여러개 받으면 속도 매우 저하됨)
        Dim pandora_busy = 0

        For Each ctrl As ItemPanel In ListPanel.Controls
            '시작은 했는데 끝을 못본 놈이 있으면 (그리고 오류도 아님)
            If ctrl.WC.IsBusy Or (ctrl.DownBegan And Not ctrl.DownFinished And Not ctrl.progMode = "error") Then
                busycount += 1
                If ctrl.videoSiteType = "pandora" Then
                    pandora_busy += 1
                End If
            End If

            If Not ctrl.DownFinished Then
                unfinished += 1
            End If
        Next

        '현재 바쁜 클라이언트가 허용 클라이언트보다 같거나 많을 때
        If busycount >= allowedCount Then
            Exit Sub
        Else
            '바쁜 클라이언트가 허용 클라이언트보다 적을 때

            For Each ctrl As ItemPanel In ListPanel.Controls
                If busycount >= allowedCount Then
                    Exit Sub

                ElseIf Not ctrl.DownBegan And ctrl.vidOK Then '다운을 시작안했고 비디오가 괜찮으면
                    'ctrl.StartDownload()

                    '대상 비디오가 판도라인데 현재 판도라가 한놈이라도 돌아가면
                    If ctrl.videoSiteType = "pandora" And pandora_busy > 0 Then
                        Continue For
                    End If

                    '그냥 다운로드를 시작하면 무조건 비디오info 다시 조회하고 받도록 하기
                    ctrl.VideoInfoReset()
                    ctrl.downloadAutomatically = True
                    ctrl.DownBegan = True
                    ctrl.VideoInfoReader.RunWorkerAsync()
                    'busycount += 1

                    '한 tick에 한 놈씩 활성화 -> 느긋하게 하는게 좋다
                    Exit Sub
                End If
            Next
        End If

        '모든 작업이 완료되었을때
        If unfinished = 0 Then
            downStarted = False
            DownCheckTimer.Stop()

            DownStartBT.Text = "다운로드 시작"
        End If
    End Sub

    Private Sub DownCountUD_ValueChanged(sender As Object, e As EventArgs) Handles DownCountUD.ValueChanged
        If DownCountUD.Value > 4 And Not downWarnShowed Then
            If MsgBox("동시 다운로드 수가 높으면 속도가 저하되거나 서버로부터 접속이 제한되어 동영상이 제대로 다운로드 되지 않을 수 있습니다." + vbCr + vbCr + "그래도 계속하시겠습니까?", vbExclamation + vbYesNo) = vbNo Then
                DownCountUD.Value = 4
            Else
                downWarnShowed = True
            End If
        End If

        allowedCount = DownCountUD.Value
    End Sub

    Private Sub ClipboardChk_CheckedChanged(sender As Object, e As EventArgs) Handles ClipboardChk.CheckedChanged
        If ClipboardChk.Checked Then
            ClipboardChecker.Start()
        Else
            ClipboardChecker.Stop()
        End If
    End Sub

    Dim prevClipTxt As String = ""
    Private Sub ClipboardChecker_Tick(sender As Object, e As EventArgs) Handles ClipboardChecker.Tick
        Dim nowClipTxt As String = Clipboard.GetText
        Dim validate As Boolean = False

        If (Not nowClipTxt = prevClipTxt) And (Not nowClipTxt = UrlTB.Text) Then
            If nowClipTxt.Contains("/tv.kakao.com/") Then
                validate = True
            ElseIf nowClipTxt.Contains("/serviceapi.nmv.naver.com/") Then
                validate = True
            End If

            If validate Then
                UrlTB.Text = nowClipTxt

                '위치도 잘 지정되어 있으면 바로 넣어버리기
                If My.Computer.FileSystem.DirectoryExists(saveLocation) Then
                    AddItem(UrlTB.Text)
                End If
            End If
        End If

        prevClipTxt = nowClipTxt
    End Sub

    Public Sub CheckSelected()
        selectedCount = 0

        For Each ctrl As ItemPanel In ListPanel.Controls
            If ctrl.Selected Then
                selectedCount += 1
            End If
        Next

        If selectedCount > 0 Then
            ForceResetBT.Enabled = True
            DeleteBT.Enabled = True
        Else
            ForceResetBT.Enabled = False
            DeleteBT.Enabled = False
        End If
    End Sub

    Private Sub devurl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles devurl.LinkClicked
        infoForm.ShowDialog(Me)
    End Sub

    Private Sub appurl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles appurl.LinkClicked
        Process.Start("https://sites.google.com/view/nvext")
    End Sub
End Class
