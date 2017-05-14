Imports System.IO

Public Class Form1
    Dim bytes As Byte()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fInfo As New FileInfo(RichTextBox1.Text)
        Dim numBytes As Long = fInfo.Length
        Dim fs As New FileStream(RichTextBox1.Text, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fs)
        bytes = br.ReadBytes(CInt(numBytes))
        br.Close()
        fs.Close()
        TextBox1.Text = "파일 읽기 성공"
        ListBox1.Items.Add("파일 읽기 성공")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
