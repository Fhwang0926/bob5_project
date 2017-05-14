
Imports System.IO
Imports Microsoft.Office.Interop


Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim doc As Word.Document

        Dim allText As String

        Try

            doc = Microsoft.Office.Interop.Word.Documents.Open("C:\Users\Fhwang\Desktop\123.docx")

            allText = doc.Range.Text()

            doc.Close()

            Console.WriteLine(allText)

        Catch




        End Try

    End Sub



    Private Sub read_btn_Click(sender As Object, e As EventArgs) Handles read_btn.Click
        Dim xl As Excel.Application
        Dim wb As Excel.Workbook
        Dim sht As Excel.Worksheet
        xl = CreateObject("Excel.application")
        wb = xl.Workbooks.Open("‪C:\Users\Fhwang\Desktop\123.xls")
        sht = wb.Worksheets(1)
        Dim Row As Integer
        Row = 1
        Do While 1
            If sht.Cells(Row, 1) = "" Then
                Exit Do
            End If
            Console.WriteLine(sht.Cells(Row, 1))
            Console.WriteLine(sht.Cells(Row, 2))
            Console.WriteLine(sht.Cells(Row, 3))
            Row = Row + 1
        Loop
        xl = Nothing
        wb = Nothing
        sht = Nothing

    End Sub

End Class
