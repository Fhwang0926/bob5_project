
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports Microsoft.Office.Interop

Partial Public Class Form1

    Public Sub read_excel()
        Dim excelApp As Excel.Application
        Dim wb As Excel.Workbook = Nothing
        Dim ws As Excel.Worksheet = Nothing

        Try
            excelApp = New Excel.Application()

            ' 엑셀 파일 열기
            wb = excelApp.Workbooks.Open("C:\Temp\test.xlsx")

            ' 첫번째 Worksheet
            ws = TryCast(wb.Worksheets.get_Item(1), Excel.Worksheet)

            ' 현재 Worksheet에서 사용된 Range 전체를 선택
            Dim rng As Excel.Range = ws.UsedRange

            ' 현재 Worksheet에서 일부 범위만 선택
            ' Excel.Range rng = ws.Range[ws.Cells[2, 1], ws.Cells[5, 3]];

            ' Range 데이타를 배열 (One-based array)로
            Dim data As Object(,) = rng.Value

            For r As Integer = 1 To data.GetLength(0)
                For c As Integer = 1 To data.GetLength(1)
                    If data(r, c) Is Nothing Then
                        Continue For
                    Else
                        Debug.Write(data(r, c).ToString() + " ")
                    End If
                Next
                Debug.WriteLine("")
            Next

            wb.Close(True)
            excelApp.Quit()
        Finally
            ' Clean up
            ReleaseExcelObject(ws)
            ReleaseExcelObject(wb)
            ReleaseExcelObject(excelApp)
        End Try
    End Sub
    Private Shared Sub ReleaseExcelObject(obj As Object)
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


