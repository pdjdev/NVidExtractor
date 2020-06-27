Imports System.Net

Module DataModule

    Public Function midReturn(ByRef total As String, ByVal first As String, ByVal last As String)
        If total.Contains(first) Then
            Dim FirstStart As Long = total.IndexOf(first) + first.Length + 1
            Return Trim(Mid$(total, FirstStart, total.Substring(FirstStart).IndexOf(last) + 1))
        Else
            Return Nothing
        End If
    End Function

    Public Function multipleMidReturn(ByVal first As String, ByVal last As String, ByRef total As String) As List(Of String)
        If total.Contains(first) Then
            Dim tmptotal = total
            Dim res As New List(Of String)

ret:
            If tmptotal.Contains(first) = True Then
                Dim FirstStart As Long = tmptotal.IndexOf(first) + first.Length + 1
                res.Add(Trim(Mid$(tmptotal, FirstStart, tmptotal.Substring(FirstStart).IndexOf(last) + 1)))
                tmptotal = Mid(tmptotal, FirstStart, tmptotal.Length)
                GoTo ret
            End If

            Return res
        Else
            Return Nothing
        End If
    End Function

    Public Function webget(url As String)
        Dim source = New System.Net.WebClient()
        source.Encoding = System.Text.Encoding.UTF8
        'MsgBox(url)

        Dim sourcestr As String = Nothing
        sourcestr = source.DownloadString(url)

        Return sourcestr
    End Function

    Public Function ChkURL(url As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse

        Try
            request = CType(WebRequest.Create(url), HttpWebRequest)
            request.Timeout = 10000
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36"

            response = CType(request.GetResponse(), HttpWebResponse)
            response.Close()
            response = Nothing
            Return True
        Catch ex As Exception
            response = Nothing
            Return False
        End Try
    End Function

    Public Function GetVideoId(OriginalURL As String)
        Dim vidkey As String = ""

        If OriginalURL.Contains("tv.kakao.com") Then
            Dim url As String = OriginalURL + "?end"

            If OriginalURL.Contains("/v/") Then
                vidkey = midReturn(url, "/v/", "?end")
            Else 'https://tv.kakao.com/channel/2667441/cliplink/300367536 이런 식일 경우
                vidkey = midReturn(url, "/cliplink/", "?end")
            End If
        Else
            Dim url As String = OriginalURL

            '소스코드인 경우
            If url.Contains("src=""") Then
                url = midReturn(url, "src=""", """")
                vidkey = midReturn(url, "vid=", "&")
            Else '플레이어 URL인 경우
                vidkey = midReturn(url, "vid=", "&")
            End If
        End If

        Return vidkey
    End Function

    Dim DoubleBytes As Double
    Public Function FormatBytes(ByVal BytesCaller As ULong) As String

        Try
            Select Case BytesCaller
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(BytesCaller / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(BytesCaller / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(BytesCaller / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(BytesCaller / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = BytesCaller ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try

    End Function
End Module
