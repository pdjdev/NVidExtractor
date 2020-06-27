Public Class Form2
    Dim postList As New List(Of String)

#Region "포스트 크롤링"

    Sub GetVideoIDS(userid As String, postid As String)
        Dim data As String = webget("http://blog.naver.com/PostView.nhn?blogId=" + userid + "&logNo=" + postid + "&redirect=Dlog&widgetTypeCall=true&directAccess=false")
        Dim keyList As New List(Of String)
        Dim videoList As New List(Of String)
        Dim outKeyList As New List(Of String)
        Dim tmplist As ListViewItem

        '일단 포스트에 비디오가 있는 경우에만
        If data.Contains(", ""vid"" : """) Then
            videoList.AddRange(multipleMidReturn(", ""vid"" : """, """,", data)) '비디오 ID와
            keyList.AddRange(multipleMidReturn(", ""inkey"" : """, """,", data)) 'inkey 값 수집

            For i = 0 To videoList.Count - 1 Step 1
                data = webget("http://serviceapi.nmv.naver.com/flash/getShareInfo.nhn?vid=" + videoList(i) + "&inKey=" + keyList(i))
                outKeyList.Add(midReturn(data, "&outKey=", "&"))
            Next

            For i = 0 To videoList.Count - 1 Step 1
                tmplist = ListView1.Items.Add(postid)
                tmplist.SubItems.Add(videoList(i))
                tmplist.SubItems.Add(outKeyList(i))
            Next
        End If
    End Sub

    Sub ScanPosts()
        postList.Clear()
        ListView1.Items.Clear()

        Try

            Dim userid As String = TextBox1.Text
            Dim categoryid As String = TextBox2.Text
            Dim currentPage As Integer = 1
            Dim prevFirstNum As String = Nothing

            Dim parentCategory As Boolean = False

            If Not webget("http://blog.naver.com/PostTitleListAsync.nhn?blogId=" + userid _
                  + "&currentPage=" + currentPage.ToString + "&categoryNo=" + categoryid + "&countPerPage=30").contains("tagQueryString") Then
                parentCategory = True
                'MsgBox("pcgy true")
            End If

            While True
                Dim tmplist As New List(Of String)

                Dim data As String = Nothing

                If parentCategory Then
                    data = webget("http://blog.naver.com/PostTitleListAsync.nhn?blogId=" + userid + "&currentPage=" + currentPage.ToString + "&categoryNo=" + categoryid + "&parentCategoryNo=" + categoryid + "&countPerPage=30")
                Else
                    data = webget("http://blog.naver.com/PostTitleListAsync.nhn?blogId=" + userid + "&currentPage=" + currentPage.ToString + "&categoryNo=" + categoryid + "&countPerPage=30")
                End If

                Dim tmp As String = midReturn(data, """tagQueryString"":""", """")

                For Each i As String In tmp.Split("&logNo=")
                    If i.Length > 0 Then tmplist.Add(i.Replace("logNo=", ""))
                Next

                If tmplist.First = prevFirstNum Then
                    Exit While
                Else
                    prevFirstNum = tmplist.First
                    postList.AddRange(tmplist)
                    currentPage += 1
                End If
            End While


            Button1.Text = "탐색 중..." + vbCr + "(" + (currentPage - 1).ToString + " 페이지)"

            For Each i As String In postList
                GetVideoIDS(userid, i)
            Next

        Catch ex As Exception
            MsgBox("불러오는 도중 오류가 발생했습니다:" + vbCr + ex.Message + vbCr + vbCr + "입력 값이 정확한지 확인해 주시고, 문제가 지속될 경우 최신 버전을 확인하고 업데이트하여 다시 시도해 보세요.", vbCritical)
        End Try

        Button1.Enabled = True
        Button2.Enabled = True
        Button1.Text = "다시 탐색하기"
    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("ID값을 입력해 주세요.", vbExclamation)
        ElseIf TextBox2.Text = "" And CheckBox1.Checked = False Then
            MsgBox("카테고리 값을 입력해 주세요.", vbExclamation)
        ElseIf TextBox3.Text = "" And CheckBox1.Checked Then
            MsgBox("포스트 값을 입력해 주세요.", vbExclamation)
        ElseIf Not IsNumeric(TextBox2.Text) And CheckBox1.Checked = False Then
            MsgBox("카테고리 값(categoryNo=)은 숫자여만 합니다.", vbExclamation)
        ElseIf Not IsNumeric(TextBox3.Text) And CheckBox1.Checked Then
            MsgBox("포스트 값(logNo=)은 숫자여만 합니다.", vbExclamation)
        Else
            Button1.Enabled = False
            Button2.Enabled = False
            Button1.Text = "탐색 중..."
            Refresh()

            If CheckBox1.Checked Then
                postList.Clear()
                ListView1.Items.Clear()
                Try
                    GetVideoIDS(TextBox1.Text, TextBox3.Text)
                Catch ex As Exception
                    MsgBox("불러오는 도중 오류가 발생했습니다:" + vbCr + ex.Message + vbCr + vbCr + "입력 값이 정확한지 확인해 주시고, 문제가 지속될 경우 최신 버전을 확인하고 업데이트하여 다시 시도해 보세요.", vbCritical)
                End Try

                Button1.Enabled = True
                Button2.Enabled = True
                Button1.Text = "다시 탐색하기"
            Else
                ScanPosts()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Button2.Text = "추가하는 중..."
        Refresh()

        For i = ListView1.Items.Count - 1 To 0 Step -1
            Dim url = "http://serviceapi.nmv.naver.com/flash/convertIframeTag.nhn?vid=" + ListView1.Items(i).SubItems(1).Text + "&outKey=" + ListView1.Items(i).SubItems(2).Text + "&"
            Form1.AddItem(url)
        Next

        Button2.Enabled = True
        Button2.Text = "목록에 추가하기"
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBox3.Enabled = CheckBox1.Checked
        TextBox2.Enabled = Not CheckBox1.Checked
    End Sub
End Class