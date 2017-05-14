Imports Word = Microsoft.Office.Interop.Word
Imports Microsoft.Office.Core
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim wordApp As New Microsoft.Office.Interop.Word.Application()

        Dim doc As Word.Document = wordApp.Documents.Open("C:\Users\Fhwang\Desktop\123.docx")
        Dim s As String = doc.Content.Text
        RichTextBox1.Text = s
    End Sub
End Class
