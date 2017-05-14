Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.PowerPoint
Public Class Form1
    Public doc As Document
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim wordApp As New Microsoft.Office.Interop.Word.Application()

        wordApp.Visible = False

        Dim doc As Microsoft.Office.Interop.Word.Document = wordApp.Documents.Open("G:\멘토스쿨초창기\1. 유닉스 서버_C.docx")
        doc.ActiveWindow.Visible = False



        Dim s As String = doc.Content.Text

        doc.Close()
        wordApp.Quit()
        Console.WriteLine(s)

        Console.WriteLine("----------------------------------------------------------------------------")




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
