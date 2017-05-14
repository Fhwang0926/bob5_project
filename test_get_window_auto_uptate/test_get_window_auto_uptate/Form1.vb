
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("cmd.exe /c reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate"" /s  > C:\123.txt", vbNormalFocus, True)
        'RunCommandCom()
        Console.WriteLine("cmd.exe /c reg query HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\  > C:\123.txt")
        Try
            Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
            For index = 0 To Lines.Length
                ListBox1.Items.Add(Lines(index))
            Next
        Catch
            Console.WriteLine("failed")
        End Try

    End Sub

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

End Sub
    Shared Sub RunCommandCom()
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = "reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update""  > C:\123.txt"
        Console.WriteLine(pi.Arguments)
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start("cmd.exe", "reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update""  > C:\123.txt")
    End Sub
End Class
