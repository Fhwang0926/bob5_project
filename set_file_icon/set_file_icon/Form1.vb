Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            PictureBox1.Image = Drawing.Icon.ExtractAssociatedIcon(TextBox1.Text).ToBitmap()
        Catch
        End Try
        Console.WriteLine("export ok")
        '
        Console.WriteLine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase))
    End Sub
    Public Shared Sub SystemPathControl(AppPath As String)

        Dim _sysPath As String = System.Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine)
        Dim oldPath() As String = _sysPath.Split(";")
        Dim newPath As New System.Text.StringBuilder

        If Not oldPath.Contains(AppPath) Then
            newPath.Append(AppPath + ";")
            For Each ePath As String In oldPath
                newPath.Append(ePath + ";")
            Next
            System.Environment.SetEnvironmentVariable("Path", newPath.ToString, EnvironmentVariableTarget.Machine)
        End If

    End Sub
End Class
