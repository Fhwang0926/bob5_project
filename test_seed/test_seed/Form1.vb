Imports SeedCs
Imports System.EnterpriseServices
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim seed As New SEED()
        RichTextBox2.Text = seed.Enc(RichTextBox1.Text, "1111111111111111")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim seed As New SEED()
        RichTextBox1.Text = seed.Dec(RichTextBox2.Text, "1111111111111111")
    End Sub
End Class
