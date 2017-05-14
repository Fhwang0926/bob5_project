Imports System.IO
Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((File.ReadAllBytes(TextBox1.Text).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(File.ReadAllBytes(TextBox1.Text), file_tmp, File.ReadAllBytes(TextBox1.Text).Length) '파일 바이트 배열 받기

        Array.Reverse(file_tmp) ' 파일 바이트 재배열

        IO.File.WriteAllBytes(TextBox1.Text & ".ecps", Combine(mark_arr, file_tmp))
        TextBox2.Text = TextBox1.Text & ".ecps"
        My.Computer.FileSystem.DeleteFile(TextBox1.Text)
        RichTextBox1.Text = IO.File.ReadAllText(TextBox2.Text)
    End Sub

    Private Function Combine(a As Byte(), b As Byte()) As Byte()


        Dim c As Byte() = New Byte(a.Length + (b.Length - 1)) {}

        System.Buffer.BlockCopy(a, 0, c, 0, a.Length)

        System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length)

        Return c
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((File.ReadAllBytes(TextBox2.Text).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(File.ReadAllBytes(TextBox2.Text), file_tmp, File.ReadAllBytes(TextBox2.Text).Length) '파일 바이트 배열 받기
        Dim dec_arr() As Byte = New Byte((file_tmp.Length - mark_arr.Length - 1)) {} '파일 바이트 배열 생성
        Array.ConstrainedCopy(file_tmp, mark_arr.Length, dec_arr, 0, file_tmp.Length - mark_arr.Length)
        Array.Reverse(dec_arr) ' 파일 바이트 재배열


        IO.File.WriteAllBytes(Microsoft.VisualBasic.Left(TextBox2.Text, TextBox2.Text.Length - 5), dec_arr)
        TextBox1.Text = Microsoft.VisualBasic.Left(TextBox2.Text, TextBox2.Text.Length - 5)
        My.Computer.FileSystem.DeleteFile(TextBox2.Text)
        RichTextBox1.Text = IO.File.ReadAllText(TextBox1.Text)
    End Sub
End Class
