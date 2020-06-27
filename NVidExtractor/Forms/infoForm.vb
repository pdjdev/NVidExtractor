Public Class infoForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://github.com/pdjdev")
        RichTextBox1.ReadOnly = False
    End Sub

    Private Sub DownStartBT_Click(sender As Object, e As EventArgs) Handles DownStartBT.Click
        Dim tmp = RichTextBox1.Text

        Dim chr As String() = {"제니", "비모", "아일린", "피오나", "이브"}
        Dim kw As String() = {"커여움", "커엽", "귀여움", "귀엽", "졸커", "졸귀"}

        For Each i In chr
            If tmp.Contains(i) Then
                For Each j In kw
                    If tmp.Contains(j) Then MsgBox("ㅇㅈ", vbInformation)
                Next
            End If
        Next

        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("https://sites.google.com/view/nvext")
        RichTextBox1.ReadOnly = False
    End Sub

    Private Sub infoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerLabel.Text = My.Application.Info.Version.ToString
    End Sub
End Class