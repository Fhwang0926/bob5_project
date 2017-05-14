Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = "cmd.exe /c ren """ & TextBox1.Text & """ """ & Replace(Mid(TextBox1.Text, InStrRev(TextBox1.Text, "\") + 1), " ", "_") & """"
        'Shell("cmd.exe /c ren """ & TextBox1.Text & """" & Replace(Mid(TextBox1.Text, InStrRev(TextBox1.Text, "\") + 1)), " ", "_"))
    End Sub
End Class
