Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.DocumentName = TextBox1.Text

        PrintPreviewControl1.Document = PrintDocument1
    End Sub
    ' Declare a string to hold the entire document contents.
    Private documentContents As String

    ' Declare a variable to hold the portion of the document that
    ' is not printed.
    Private stringToPrint As String
    Private Sub toto(str As String)

        Dim stream As New FileStream(str, FileMode.Open)
        Try
            Dim reader As New StreamReader(stream)
            Try
                documentContents = reader.ReadToEnd()
            Finally
                reader.Dispose()
            End Try
        Finally
            stream.Dispose()
        End Try
        stringToPrint = documentContents
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
