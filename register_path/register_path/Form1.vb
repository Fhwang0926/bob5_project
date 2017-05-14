Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SystemPathControl("test")
        'Shell("cmd.exe /c setx path """ & Application.StartupPath & """  -m")
        'Console.WriteLine("cmd.exe /c setx ""%PATH%;" & Application.StartupPath & ";"" ")
    End Sub
    Public Shared Sub SystemPathControl(AppPath As String)

        Dim _sysPath As String = System.Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine)
        Dim oldPath() As String = _sysPath.Split(";")
        Dim newPath As New StringBuilder

        If Not oldPath.Contains(AppPath) Then
            newPath.Append(AppPath + ";")
            For Each ePath As String In oldPath
                newPath.Append(ePath + ";")
            Next
            System.Environment.SetEnvironmentVariable("Path", newPath.ToString, EnvironmentVariableTarget.Machine)
        End If

    End Sub
End Class
