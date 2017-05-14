Imports SeedCs

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bytess(15) As String
        Dim a(15) As String
        Dim count As Integer = 0
        For Each b In Split("48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 49, 50, 51, 52, 53", ",")
            a(count) = b
            count += 1
        Next
        ' 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 49, 50, 51, 52, 53 };
        count = 0
        Dim tmp = 0
        For Each tmp In Split("32, 32, 32, 32, 32, 32, 49, 49, 57, 55, 54, 54, 55, 54, 54, 57", ",")
            tmp = Convert.ToInt32(tmp) + Convert.ToInt32(a(count))
            bytess(count) = Chr(tmp)
            count += 1
        Next
        Console.WriteLine(UnicodeBytesToString(bytess).ToString)
        Dim com As New SEED()
        RichTextBox2.Text = com.Dec(RichTextBox1.Text, "PQRSTUghqpfgiijn")

    End Sub


    Private Function UnicodeBytesToString(
        ByVal bytes() As String) As String
        Dim str As String = ""
        For Each tmp In bytes
            str += tmp
        Next
        Console.WriteLine(str)
        Return str
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = "eJyzYUhjyGfIYyhhUACyEhmSGVIZbBmUGErW7tm55YwSULSYIZOhCipqBMR2DI5waMOgD9dvxwAAZ6YOqw=="
    End Sub
End Class
