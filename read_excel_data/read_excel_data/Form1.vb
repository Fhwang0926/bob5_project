Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objExcel = CreateObject("Excel.Application") ' 엑셀 객체 생성
        objExcel.Visible = False ' 엑셀 프로그램 보이기, False로 하면 엑셀 창이 보이지 않고, Excel.exe 만 실행이 됩니다.

        Dim objWorkBook = objExcel.WorkBooks.Open("C:\Users\Fhwang\Desktop\aaaaa.xlsx")

            Dim objWorkSheet = objWorkBook.Worksheets(1)


            Dim rowCount = objWorkSheet.UsedRange.Rows.count
            Dim colCount = objWorkSheet.UsedRange.Columns.count

            MsgBox("Rows    :" & rowCount)
            MsgBox("Columns :" & colCount)

            Dim Range = objWorkSheet.UsedRange

            ' Range 데이타를 배열 (One-based array)로
            Dim data As Object(,) = Range.Value
        Try
            For r As Integer = 1 To data.GetLength(0)
                For c As Integer = 1 To data.GetLength(1)
                    If data(r, c) Is Nothing Then
                        Continue For
                    Else
                        Console.WriteLine(data(r, c).ToString())
                    End If
                Next

            Next

            objWorkBook.Close(True)
            objExcel.Quit()

        Finally
            ' Clean up
            ReleaseExcelObject(objWorkSheet)
        ReleaseExcelObject(objWorkBook)
        ReleaseExcelObject(objExcel)
        End Try
    End Sub
    Private Sub ReleaseExcelObject(obj As Object)
        Try
            If obj IsNot Nothing Then
                Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
            Throw ex
        Finally
            GC.Collect()
        End Try




    End Sub
End Class
