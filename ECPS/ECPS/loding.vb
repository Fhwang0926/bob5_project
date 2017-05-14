Imports System.Text
Imports System.Threading
Imports Microsoft.Win32.Registry
Public Class loding
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
    Public once As String
    Private Sub loding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Shell("cmd.exe /c sc query ""WSearch"" | find ""4"" > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines.Length)

        If Lines.Length <> 1 Then
            'Console.WriteLine(Trim(Microsoft.VisualBasic.Right(Lines(0), 8)))
            Shell("cmd.exe /c sc start ""WSearch""", vbHidden, True)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.33, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.15)
        once = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("once")
        Timer1.Enabled = True
        SystemPathControl(Application.StartupPath)
        Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(".ecps").CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command").SetValue("", Application.StartupPath & "\drm_changer.exe %1")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Opacity = 1 Then
            Thread.Sleep(2000)
            Do Until Opacity = 0
                Opacity = Opacity - 0.01
                Thread.Sleep(10)
            Loop
            If Not (once = 1) Then
                one_chk.Show()
                Me.Hide()
                Timer1.Enabled = False
            Else
                main.Show() '폼2를 띄운다
                Hide()
                Timer1.Enabled = False
            End If

        Else '//아니면

            Opacity = Opacity + 0.01

        End If '//if문 끝
    End Sub
End Class
