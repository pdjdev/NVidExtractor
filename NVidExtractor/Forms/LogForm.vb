Public Class LogForm
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
        RichTextBox1.ScrollToCaret()
    End Sub

    Public Sub addLog(text As String)
        If LogChk.Checked Then
            RichTextBox1.Text += "[" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + text + vbCrLf
        End If
    End Sub

    Private Sub LogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub
End Class