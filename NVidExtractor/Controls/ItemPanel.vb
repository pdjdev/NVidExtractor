Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class ItemPanel

#Region "Variables"

    Public WithEvents ProgLabel1 As New Label
    Public WithEvents ProgLabel2 As New Label

    Public Paused As Boolean = False
    Public Selected As Boolean = False
    Public DownBegan As Boolean = False '다운로드를 한번이라도 시작을 했는지
    Public DownFinished As Boolean = False '다운로드를 완료한 상태인지
    Dim captionDownFinished As Boolean = False '자막 다운로드를 완료한 상태인지
    Dim progMode As String = ""

    Dim prevCBSelect() As Integer = {-1, -1} '비디오 info 리셋할때 콤보박스 선택을 보존하기 위해서

    Public DownMode As Integer = 2 '1 = 영상, 2 = 영상+자막, 3 = 자막만
    Public DownQuality As Integer = 4 '1 270p 2 480p 3 720p 4 1080p

    Public WithEvents WC As New DownloadFileAsyncExtended
    Public OriginalURL As String = ""

    Public CapURL As String = ""
    Public MovURL As String = ""
    Public DownloadLoc As String = ""
    'Dim UAString As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36"

    Dim active As Boolean = False
    Dim progPercent As Integer = 0

    Public downloadAutomatically As Boolean = False
    '유효성 체크 끝나고 바로 다운로드 시작하기 -> request가 만료되고 다시 시도하는 상황에서 유용

    Public index As Integer = 0 '리스트 아이템의 인덱스 -> 다중 선택시 꼭필요
    Public videoSiteType As String = "" '비디오 사이트 종류 naver=네이버, kakao=카카오tv
    Public videoId As String = "" '비디오 ID -> 중복 비디오 추가를 막기 위해서

    Dim videoName As New List(Of String)
    Dim videoURL As New List(Of String)
    Dim videoSize As New List(Of Integer)
    Dim videoLength As New List(Of Integer)

    Dim captionName As New List(Of String)
    Dim captionURL As New List(Of String)

    Public vidOK As Boolean = False
    Dim subject As String = ""

    Dim infoText As String = Nothing

    Dim postURL As String  '원영상 포스트 링크
    Dim user_name As String  '조회수
    Dim user_id As String  '조회수
    Dim count As String '조회수
    Dim coverURL As String '동영상 썸네일

#End Region

#Region "비디오 환경설정"

    Public Sub SetQuality()
        '화질 선택 : 만약 해당 화질 존재 안하면 한단계 낮은 화질로 설정
        Select Case DownQuality
            Case 0 '270선택
                If Not ComboBox1.FindString("270p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("270p")
                End If
            Case 1 '480p 4 720p 5 1080p
                If Not ComboBox1.FindString("480p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("480p")
                ElseIf Not ComboBox1.FindString("270p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("270p")
                End If
            Case 2 '720p
                If Not ComboBox1.FindString("720p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("720p")
                ElseIf Not ComboBox1.FindString("480p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("480p")
                ElseIf Not ComboBox1.FindString("270p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("270p")
                End If
            Case 3 '1080p
                If Not ComboBox1.FindString("1080p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("1080p")
                ElseIf Not ComboBox1.FindString("720p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("720p")
                ElseIf Not ComboBox1.FindString("480p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("480p")
                ElseIf Not ComboBox1.FindString("270p") = -1 Then
                    ComboBox1.SelectedIndex = ComboBox1.FindString("270p")
                End If
        End Select
    End Sub

    Public Sub setMode()
        '카카오면 무조건 다운모드 1
        If videoSiteType = "kakao" Then DownMode = 1

        Select Case DownMode
            Case 1
                ComboBox1.Enabled = True
                ComboBox2.Enabled = False
                If videoSiteType = "kakao" Then
                    DownModeLabel.Text = "영상(카카오)"
                Else
                    DownModeLabel.Text = "영상"
                End If

            Case 2
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                DownModeLabel.Text = "영상+자막"
            Case 3
                ComboBox1.Enabled = False
                ComboBox2.Enabled = True
                DownModeLabel.Text = "자막"
        End Select
    End Sub

    Sub VideoInfoReset()
        LogForm.addLog("비디오 정보 초기화됨 (" + Me.Name + ")")

        prevCBSelect(0) = ComboBox1.SelectedIndex
        prevCBSelect(1) = ComboBox2.SelectedIndex

        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        videoName.Clear()
        videoURL.Clear()
        videoSize.Clear()
        videoLength.Clear()

        captionName.Clear()
        captionURL.Clear()

        vidOK = False

        TitleLabel.Text = "비디오 정보를 다시 읽어내는중..."
        LengthLabel.Text = Nothing
        ThumbnailBox.BackgroundImage = My.Resources.alim_notfound

        Refresh()
    End Sub

    'directDown = True 시 초기화 후 바로 다운로드 작업
    Public Sub forceReset(directDown As Boolean)
        If Not VideoInfoReader.IsBusy Then
            VideoInfoReset()

            WC.CancelAsync()
            WC = Nothing
            WC = New DownloadFileAsyncExtended

            downloadAutomatically = directDown
            VideoInfoReader.RunWorkerAsync()

            Paused = False
            DownBegan = False '다운로드를 한번이라도 시작을 했는지
            DownFinished = False '다운로드를 완료한 상태인지
            captionDownFinished = False '자막 다운로드를 완료한 상태인지

            ProgPanel.BackColor = MainPanel.BackColor
            ProgPanelOver.BackColor = MainPanel.BackColor
            ProgLabel1.Text = ""
            ProgLabel2.Text = ""
        End If
    End Sub

#End Region

#Region "GUI 업데이트"

    Private Sub BT_MouseEnter(sender As Object, e As EventArgs) Handles PauseResumeBT.MouseEnter, CloseBT.MouseEnter, MenuBT.MouseEnter
        Dim ctrl As Control = sender
        ctrl.BackColor = darkencolor(MainPanel.BackColor, 10)
    End Sub

    Private Sub BT_MouseLeave(sender As Object, e As EventArgs) Handles PauseResumeBT.MouseLeave, CloseBT.MouseLeave, MenuBT.MouseLeave
        Dim ctrl As Control = sender
        ctrl.BackColor = MainPanel.BackColor
    End Sub

    Private Sub MenuBT_MouseDown(sender As Object, e As MouseEventArgs) Handles PauseResumeBT.MouseDown, CloseBT.MouseDown, MenuBT.MouseDown
        Dim ctrl As Control = sender
        ctrl.BackColor = darkencolor(MainPanel.BackColor, 30)
    End Sub

    Private Sub MenuBT_MouseUp(sender As Object, e As MouseEventArgs) Handles PauseResumeBT.MouseUp, CloseBT.MouseUp, MenuBT.MouseUp
        Dim ctrl As Control = sender
        ctrl.BackColor = darkencolor(MainPanel.BackColor, 10)
    End Sub

    Sub SetProgBar(text As String)
        ProgLabel1.Text = text
        ProgLabel2.Text = ProgLabel1.Text

        DrawProgBar()
        ProgPanel.BackColor = MainPanel.BackColor

        Select Case progMode
            Case "downloading"
                ProgPanelOver.BackColor = Color.DodgerBlue
            Case "pause"
                ProgPanelOver.BackColor = Color.DarkGray
            Case "finished"
                ProgPanelOver.BackColor = Color.FromArgb(60, 182, 90)
            Case "error"
                ProgPanelOver.BackColor = Color.DarkRed
                ProgPanel.BackColor = Color.FromArgb(255, 230, 230)
            Case Else
                ProgPanelOver.BackColor = Color.Gray
        End Select
    End Sub

    Sub DrawProgBar()
        ProgPanelOver.Width = (progPercent / 100) * ProgPanel.Width

        Dim loc As New Point(ProgPanel.Width / 2 - ProgLabel1.Width / 2, ProgLabel1.Location.Y)
        ProgLabel1.Location = loc
        ProgLabel2.Location = loc
    End Sub

    Private Sub ItemPanel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        DrawProgBar()
    End Sub

    Function DaysCalc(seconds As Integer)
        Dim days As Integer = 0
        Dim hours As Integer = 0
        Dim minutes As Integer = seconds \ 60
        Dim res As String = ""

        While minutes >= 60
            minutes -= 60
            hours += 1
        End While

        While hours >= 24
            hours -= 24
            days += 1
        End While

        If Not days = 0 Then res += days.ToString + "일 "
        If Not hours = 0 Then res += hours.ToString + "시간 "
        If Not minutes = 0 Then res += minutes.ToString + "분 "
        If Not seconds Mod 60 = 0 Then res += (seconds Mod 60).ToString + "초"

        Return res
    End Function

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles MainPanel.Click, TitleLabel.Click, ThumbnailBox.Click, DownModeLabel.Click
        Selected = Not Selected
        SelectModeApply(Selected)

        If My.Computer.Keyboard.ShiftKeyDown And Not Form1.lastclickedIndex = -1 Then
            Dim startIndex = Math.Min(index, Form1.lastclickedIndex)
            Dim endindex = Math.Max(index, Form1.lastclickedIndex)

            For Each ctrl As ItemPanel In Form1.ListPanel.Controls
                If ctrl.index > startIndex And ctrl.index < endindex Then
                    ctrl.Selected = Not ctrl.Selected
                    ctrl.SelectModeApply(ctrl.Selected)
                End If
            Next

        Else
            Form1.lastclickedIndex = index
        End If

        Form1.CheckSelected()
    End Sub

    '체크 여부를 확인하고 이에 맞게 모양을 바꾸는 것
    Sub SelectModeApply(selected As Boolean)
        If selected Then
            CheckBox1.Checked = True
            MainPanel.BackColor = Color.FromArgb(224, 243, 254)
            SidePanel.BackColor = Color.FromArgb(224, 243, 254)
            ProgPanel.BackColor = Color.FromArgb(224, 243, 254)
            CloseBT.BackColor = Color.FromArgb(224, 243, 254)
            MenuBT.BackColor = Color.FromArgb(224, 243, 254)
            PauseResumeBT.BackColor = Color.FromArgb(224, 243, 254)
            SaveLocTB.BackColor = Color.FromArgb(224, 243, 254)
        Else
            CheckBox1.Checked = False
            MainPanel.BackColor = Color.White
            SidePanel.BackColor = Color.White
            CloseBT.BackColor = Color.White
            MenuBT.BackColor = Color.White
            PauseResumeBT.BackColor = Color.White
            SaveLocTB.BackColor = Color.White

            If progMode = "error" Then
                ProgPanel.BackColor = Color.FromArgb(255, 230, 230)
            Else
                ProgPanel.BackColor = Color.White
            End If

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Selected = True
        Else
            Selected = False
        End If

        SelectModeApply(Selected)
    End Sub


#End Region

#Region "다운로드 작업"

    Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As FileDownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        progMode = "downloading"
        SetProgBar(e.ProgressPercentage.ToString _
                   + "% (" + FormatBytes(e.DownloadSpeedBytesPerSec) + "/s, " _
                   + FormatBytes(e.BytesReceived) + "/" + FormatBytes(e.TotalBytesToReceive) _
                   + ", " + DaysCalc(e.RemainingTimeSeconds) + " 남음)")
        progPercent = e.ProgressPercentage

        ProgPanelOver.Width = (e.ProgressPercentage / 100) * ProgPanel.Width
    End Sub

    Public Sub StartDownload()
        LogForm.addLog("다운로드 작업 시작.. (" + Me.Name + ")")

        DownBegan = True
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False

        'URL의 유효성을 체크... 하려고 했으나 자꾸 Freezing 걸려서 그냥 안함
        'If ChkURL(videoURL(ComboBox1.SelectedIndex)) Then
        If vidOK Then
            '비디오명은 "제목 [화질] (비디오아이디 (10자리까지만))" 로 함
            Dim nameid As String = ""
            If videoId.Length > 9 Then
                nameid = Mid(videoId, 1, 9)
            Else
                nameid = videoId
            End If

            Dim fixedTitle As String = System.Text.RegularExpressions.Regex.Replace(subject + " [" + videoName(ComboBox1.SelectedIndex) + "] (" + nameid + ")", String.Format("[{0}]", String.Join(String.Empty, IO.Path.GetInvalidFileNameChars)), "-")

            LogForm.addLog("파일 저장 이름: " + fixedTitle + " (" + Me.Name + ")")

            '다운로드 모드가 1이 아닐 경우 (자막 다운로드 절차를 거쳐야 하는 경우)
            If Not DownMode = 1 And videoSiteType = "naver" Then

                '자막을 받지 않았는 경우
                If Not captionDownFinished Then

                    '자막이 없거나 선택 안한 경우
                    If ComboBox2.Text.Contains("없음") Or Not captionURL.Count > 0 Then
                        captionDownFinished = True

                        '자막일 경우
                        If DownMode = 3 Then
                            progMode = "finished"
                            SetProgBar("자막이 선택되지 않아 해당 다운로드는 건너뜁니다")
                            Paused = False
                            PauseResumeBT.Visible = False
                            DownFinished = True
                        Else '영상+자막일 경우
                            DownVid(DownloadLoc + "\" + fixedTitle + ".mp4")

                        End If
                    Else
                        DownSub(DownloadLoc + "\" + fixedTitle + ".srt")

                    End If

                    '자막을 받은 경우
                Else
                    DownVid(DownloadLoc + "\" + fixedTitle + ".mp4")
                End If
            Else
                DownVid(DownloadLoc + "\" + fixedTitle + ".mp4")
            End If
        End If
        'Else
        ' LogForm.addLog("유효성 체크가 실패했습니다. (" + Me.Name + ") 다시 시도하는중...")
        ' 'MsgBox("비디오 문제있슴", vbInformation)
        ' '링크가 만료되었을시
        ' downloadAutomatically = True
        ' '비디오 체크 끝나고 바로 (다시) 받도록
        ' VideoInfoReset()
        ' VideoInfoReader.RunWorkerAsync()
        ' End If
    End Sub

    Sub DownVid(filename As String)
        LogForm.addLog("비디오 다운로드 시작. (" + Me.Name + ")")
        WC.SynchronizingObject = Me
        WC.ProgressUpdateFrequency = DownloadFileAsyncExtended.UpdateFrequency.HalfSecond
        Me.Tag = WC
        WC.DowloadFileAsync(videoURL(ComboBox1.SelectedIndex), filename, Me)

        PauseResumeBT.Image = My.Resources.pause_b
        PauseResumeBT.Visible = True
        MenuBT.Visible = True
        Paused = False
    End Sub

    Sub DownSub(filename As String)
        LogForm.addLog("자막 다운로드 시작. (" + Me.Name + ")")
        WC.SynchronizingObject = Me
        WC.ProgressUpdateFrequency = DownloadFileAsyncExtended.UpdateFrequency.HalfSecond
        Me.Tag = WC
        WC.DowloadFileAsync(captionURL(ComboBox2.SelectedIndex), filename, Me)
    End Sub

    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As FileDownloadCompletedEventArgs) Handles WC.DownloadCompleted
        If Not captionDownFinished And Not DownMode = 1 Then
            captionDownFinished = True
            If e.ErrorMessage IsNot Nothing Then '오류 발생시
                progMode = "error"
                SetProgBar("자막 오류 발생: " + e.ErrorMessage.Message.ToString)
            Else
                progMode = "finished"
                SetProgBar("자막 다운로드 완료")
            End If

            '자막만 다운받는 모드라면
            If DownMode = 3 Then
                Paused = False
                PauseResumeBT.Visible = False
                DownFinished = True
            Else
                '영상 다운로드 시작
                StartDownload()
            End If
        Else
            If e.ErrorMessage IsNot Nothing Then '오류 발생시
                progMode = "error"
                SetProgBar(e.ErrorMessage.Message.ToString)
                PauseResumeBT.Image = My.Resources.resume_b
                Paused = True
            ElseIf e.Cancelled Then '다운로드 취소시
                progMode = "pause"
                SetProgBar("일시 정지됨")
                PauseResumeBT.Image = My.Resources.resume_b
                Paused = True
            Else '다운로드 성공시
                LogForm.addLog("비디오 다운로드 완료. (" + Me.Name + ")")
                If progPercent < 100 Then
                    LogForm.addLog("진행도를 만족하지 못해 다시 다운로드 재개 (" + Me.Name + ")")
                    If Not WC.IsBusy Then
                        WC.ResumeAsync()
                    End If
                Else
                    LogForm.addLog("DownFinished = True (" + Me.Name + ")")
                    progMode = "finished"
                    SetProgBar("다운로드 완료")
                    Paused = False
                    PauseResumeBT.Visible = False
                    DownFinished = True
                End If
            End If
        End If

    End Sub

    Private Sub PauseResumeBT_Click(sender As Object, e As EventArgs) Handles PauseResumeBT.Click
        If Paused Then
            ResumeDown()
        Else
            Paused = True
            PauseDown()
        End If
    End Sub

    Public Sub PauseDown()
        Paused = True
        WC.CancelAsync()
    End Sub

    Public Sub ResumeDown()
        Try
            If Not WC.IsBusy Then '이미 바쁠때 (사용중일때) 가 아닐 때에만
                WC.ResumeAsync()
            End If
            Paused = False
            PauseResumeBT.Image = My.Resources.pause_b
        Catch ex As Exception
            LogForm.addLog("클라이언트 ResumeAsync 실패 (" + Name + ") [" + ex.Message + "]")
            Paused = True
            PauseResumeBT.Image = My.Resources.resume_b
        End Try
    End Sub

    Private Sub VideoInfoReader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles VideoInfoReader.DoWork
        '일단 부하를 막기 위해 1초 정도 쉬고
        Threading.Thread.Sleep(1000)

        Try
            Select Case videoSiteType
                Case "naver"
                    Dim url As String = OriginalURL
                    Dim key1 As String = Nothing
                    Dim key2 As String = Nothing

                    '소스코드인 경우
                    If url.Contains("src=""") Then
                        url = midReturn(url, "src=""", """")
                        key1 = midReturn(url, "vid=", "&")
                        key2 = Mid(url, url.IndexOf("outKey=") + 8, url.Length)
                    Else '플레이어 URL인 경우
                        key1 = midReturn(url, "vid=", "&")
                        key2 = midReturn(url, "outKey=", "&")
                    End If

                    Dim dataJson As String = webget("http://apis.naver.com/rmcnmv/rmcnmv/vod/play/v2.0/" + key1 + "?key=" + key2)
                    Dim json As JObject = JObject.Parse(dataJson)


                    Dim tmp1 = json.SelectToken("meta")

                    postURL = tmp1.SelectToken("url").ToString '원영상 포스트 링크
                    user_name = tmp1.SelectToken("user").SelectToken("name").ToString '조회수
                    user_id = tmp1.SelectToken("user").SelectToken("id").ToString '조회수
                    subject = tmp1.SelectToken("subject").ToString '동영상 제목
                    count = tmp1.SelectToken("count").ToString '조회수
                    coverURL = tmp1.SelectToken("cover").SelectToken("source").ToString '동영상 썸네일

                    tmp1 = json.SelectToken("videos")

                    Dim videos = tmp1.SelectToken("list")

                    For Each raw In videos
                        videoName.Add(raw.SelectToken("encodingOption").SelectToken("name"))
                        videoURL.Add(raw.SelectToken("source"))
                        videoSize.Add(Convert.ToInt64(raw.SelectToken("size")))
                        videoLength.Add(Convert.ToInt64(raw.SelectToken("duration")))
                    Next

                    tmp1 = json.SelectToken("captions")

                    If tmp1 IsNot Nothing Then

                        Dim captions = tmp1.SelectToken("list")

                        For Each raw In captions
                            captionName.Add(raw.SelectToken("label"))
                            captionURL.Add(raw.SelectToken("source"))
                        Next
                    End If

                    captionName.Add("(없음)")

                Case "kakao"

                    'MsgBox("카카오 작업 수행")

                    Dim url As String = OriginalURL + "?end"
                    Dim vidkey As String = ""
                    'https://tv.kakao.com/v/300367536 이런 식일 경우
                    If OriginalURL.Contains("/v/") Then
                        vidkey = midReturn(url, "/v/", "?end")
                    Else 'https://tv.kakao.com/channel/2667441/cliplink/300367536 이런 식일 경우
                        vidkey = midReturn(url, "/cliplink/", "?end")
                    End If



                    'HIGH4(1080p) HIGH(720p) MAIN(360p+) BASE(360p) LOW(240p)
                    Dim baselink As String = "https://tv.kakao.com/katz/v1/ft/cliplink/" + vidkey _
                                             + "/readyNplay?player=monet_html5&uuid=&profile="

                    '1080p 추출
                    Dim dataJson As String = webget(baselink + "HIGH4")
                    Dim json As JObject = JObject.Parse(dataJson)
                    Dim vidjson As JObject = json.SelectToken("videoLocation")

                    If vidjson.SelectToken("profile").ToString = "HIGH4" Then
                        videoName.Add("1080p")
                        videoURL.Add(vidjson.SelectToken("url").ToString)
                        videoSize.Add(0)
                        videoLength.Add(Convert.ToInt64(json.SelectToken("vmapReq").SelectToken("content_data").SelectToken("duration")))
                    End If

                    '720p 추출
                    dataJson = webget(baselink + "HIGH")
                    json = JObject.Parse(dataJson)
                    vidjson = json.SelectToken("videoLocation")

                    If vidjson.SelectToken("profile").ToString = "HIGH" Then
                        videoName.Add("720p")
                        videoURL.Add(vidjson.SelectToken("url").ToString)
                        videoSize.Add(0)
                        videoLength.Add(Convert.ToInt64(json.SelectToken("vmapReq").SelectToken("content_data").SelectToken("duration")))
                    End If

                    '360p+ 추출
                    dataJson = webget(baselink + "MAIN")
                    json = JObject.Parse(dataJson)
                    vidjson = json.SelectToken("videoLocation")

                    If vidjson.SelectToken("profile").ToString = "MAIN" Then
                        videoName.Add("360p+")
                        videoURL.Add(vidjson.SelectToken("url").ToString)
                        videoSize.Add(0)
                        videoLength.Add(Convert.ToInt64(json.SelectToken("vmapReq").SelectToken("content_data").SelectToken("duration")))
                    End If

                    '360p 추출
                    dataJson = webget(baselink + "BASE")
                    json = JObject.Parse(dataJson)
                    vidjson = json.SelectToken("videoLocation")

                    If vidjson.SelectToken("profile").ToString = "BASE" Then
                        videoName.Add("360p")
                        videoURL.Add(vidjson.SelectToken("url").ToString)
                        videoSize.Add(0)
                        videoLength.Add(Convert.ToInt64(json.SelectToken("vmapReq").SelectToken("content_data").SelectToken("duration")))
                    End If

                    '240p 추출
                    dataJson = webget(baselink + "LOW")
                    json = JObject.Parse(dataJson)
                    vidjson = json.SelectToken("videoLocation")

                    If vidjson.SelectToken("profile").ToString = "LOW" Then
                        videoName.Add("240p")
                        videoURL.Add(vidjson.SelectToken("url").ToString)
                        videoSize.Add(0)
                        videoLength.Add(Convert.ToInt64(json.SelectToken("vmapReq").SelectToken("content_data").SelectToken("duration")))
                    End If

                    Dim tmp1 = JObject.Parse(webget("https://tv.kakao.com/api/v1/ft/playmeta/cliplink/" + vidkey)).SelectToken("clipLink")

                    postURL = "https://tv.kakao.com/v/" + vidkey '원영상 포스트 링크
                    user_name = tmp1.SelectToken("channel").SelectToken("name").ToString '유저명
                    user_id = tmp1.SelectToken("clip").SelectToken("userId").ToString '유저ID
                    subject = tmp1.SelectToken("clip").SelectToken("title").ToString '동영상 제목
                    count = tmp1.SelectToken("clip").SelectToken("playCount").ToString '조회수
                    coverURL = tmp1.SelectToken("clip").SelectToken("thumbnailUrl").ToString '동영상 썸네일

            End Select



        Catch ex As Exception

            'MsgBox("오류 발생:" + vbCr + ex.Message, vbCritical)

            LogForm.addLog("비디오인포 수집 중 오류 발생. (" + Me.Name + ")")
        End Try

        '일단 부하를 막기 위해 1초 정도 쉬고
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub VideoInfoReader_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles VideoInfoReader.RunWorkerCompleted
        LogForm.addLog("비디오인포 읽기 완료. (" + Me.Name + ")")

        Try
            LogForm.addLog("결과값을 적용하는 중... (" + Me.Name + ")")
            MenuBT.Visible = True

            '비디오 항목 채우기
            If videoSiteType = "naver" Then
                For i = 0 To videoName.Count - 1
                    ComboBox1.Items.Add(videoName(i) + " (" + FormatBytes(videoSize(i)) + ")")
                Next
            Else
                For i = 0 To videoName.Count - 1
                    ComboBox1.Items.Add(videoName(i))
                Next
            End If


            If videoSiteType = "naver" Then
                '자막 항목 채우기
                For i = 0 To captionName.Count - 1
                    ComboBox2.Items.Add(captionName(i))
                Next
            End If

            '영상 썸네일 채우기
            Try
                Dim tClient As Net.WebClient = New Net.WebClient
                ThumbnailBox.BackgroundImage = Bitmap.FromStream(New IO.MemoryStream(tClient.DownloadData(coverURL)))
            Catch ex As Exception
                ThumbnailBox.BackgroundImage = My.Resources.alim_notfound
            End Try

            infoText = "제목: " + subject + vbCr
            infoText += "게시자: " + user_name + " (" + user_id + ")" + vbCr
            infoText += "조회수: " + count + vbCr
            infoText += "원주소: " + postURL

            'InfoTB.Text = infoText
            TitleLabel.Text = subject

            Dim len As Integer = videoLength.First

            Dim timeLength As String = (len \ 60).ToString + ":"
            If len Mod 60 = 0 Then
                timeLength += "00"
            Else
                timeLength += (len Mod 60).ToString("D2")
            End If

            LengthLabel.Text = "#" + index.ToString + " " + timeLength

            SetQuality()
            setMode()

            '이전에 선택한 모드가 있다면 그걸로 하고, 없다면 화질은 SetQuality에 맞게, 자막은 가장 첫번째 아이템으로.
            If ComboBox1.Items.Count > 0 And Not prevCBSelect(0) = -1 Then ComboBox1.SelectedIndex = prevCBSelect(0)
            If videoSiteType = "naver" Then
                If ComboBox2.Items.Count > 0 And Not prevCBSelect(1) = -1 Then
                    ComboBox2.SelectedIndex = prevCBSelect(1)
                Else
                    ComboBox2.SelectedIndex = 0
                End If
            End If

            vidOK = True

            If downloadAutomatically Then
                downloadAutomatically = False
                StartDownload()
            End If

            LogForm.addLog("정보 (" + Me.Name + ")" + vbCrLf + infoText)

        Catch ex As Exception

            vidOK = False
            progMode = "error"
            SetProgBar("비디오 정보를 읽어오는데 문제가 발생했습니다.")
            LogForm.addLog("비디오 정보 읽기 실패 (" + Me.Name + "), [" + ex.Message + "]")

        End Try
    End Sub

#End Region

    Public Event RemoveClicked As EventHandler
    Public Sub OnRemoveClicked(e As EventArgs)
        RaiseEvent RemoveClicked(Me, e)
    End Sub

    Public Sub Killme()
        WC.CancelAsync()
        OnRemoveClicked(EventArgs.Empty)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Killme()
    End Sub

    Private Sub ItemPanel_Load(sender As Object, e As EventArgs) Handles Me.Load
        '프로그레스바 모양 설정
        ProgPanel.Controls.Add(ProgLabel1)
        ProgPanelOver.Controls.Add(ProgLabel2)
        ProgLabel1.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular,
                                                  System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        ProgLabel2.Font = New System.Drawing.Font("맑은 고딕", 7.0!, System.Drawing.FontStyle.Regular,
                                                  System.Drawing.GraphicsUnit.Point, CType(129, Byte))

        ProgLabel2.ForeColor = Color.White
        ProgLabel1.AutoSize = True
        ProgLabel2.AutoSize = True

        PauseResumeBT.Visible = False
        MenuBT.Visible = False
        SaveLocTB.Text = DownloadLoc

        '비디오 정보 불러오기
        'GetVidInfo(OriginalURL)
        LengthLabel.Text = Nothing
        LogForm.addLog("ItemPanel 로드(" + Me.Name + "), 비디오인포 읽기 시작")
        VideoInfoReader.RunWorkerAsync()
    End Sub

    Private Sub ToOriginalLink_Menu_Click(sender As Object, e As EventArgs) Handles ToOriginalLink_Menu.Click
        Process.Start("explorer.exe", postURL)
    End Sub

    Private Sub 비디오정보보기ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 비디오정보보기ToolStripMenuItem.Click
        MsgBox(infoText, vbInformation)
    End Sub

    Private Sub GetStrLink_Menu_Click(sender As Object, e As EventArgs) Handles GetStrLink_Menu.Click
        If ComboBox1.Items.Count > 0 And videoURL.Count > 0 Then
            Clipboard.SetText(videoURL(ComboBox1.SelectedIndex))
            MsgBox("클립보드에 복사되었습니다.", vbInformation)
        Else
            MsgBox("비디오 정보를 읽을 수 없습니다.", vbCritical)
        End If

    End Sub

    Private Sub MenuBT_Click(sender As Object, e As EventArgs) Handles MenuBT.Click
        VidInfo_Menu.Show(Cursor.Position)
    End Sub

    Private Sub ForceInfoRead_Menu_Click(sender As Object, e As EventArgs) Handles ForceInfoRead_Menu.Click
        If Not VideoInfoReader.IsBusy Then
            VideoInfoReset()

            downloadAutomatically = False
            LogForm.addLog("강제 비디오인포 읽기 시작. (메뉴 선택, 자동다운시작 False)")
            VideoInfoReader.RunWorkerAsync()
        End If
    End Sub

    Private Sub ForceReset_Menu_Click(sender As Object, e As EventArgs) Handles ForceReset_Menu.Click
        forceReset(False)
    End Sub

    Private Sub OpenSavePathMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSavePathMenuToolStripMenuItem.Click
        Process.Start("explorer.exe", DownloadLoc)
    End Sub
End Class
