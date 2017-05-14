Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sourceDir As String = "C:\Users\Fhwang\Desktop\1111.hwp"
        Dim backupDir As String = "C:\Users\Fhwang\Desktop\2222.hwp"
        File.Copy(sourceDir, backupDir, True)
    End Sub
End Class
