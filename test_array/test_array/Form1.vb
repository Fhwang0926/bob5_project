Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tmp(8) As String
        tmp(2) = "asd"

        For Each str As String In tmp
            Try
                RichTextBox1.Text = str.ToString & vbCrLf
            Catch
            End Try

        Next
    End Sub
End Class
