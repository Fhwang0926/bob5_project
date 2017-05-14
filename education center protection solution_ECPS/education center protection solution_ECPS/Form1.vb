Imports System.Threading
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Shell("cmd.exe /c sc query ""WSearch"" | find ""4"" > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines.Length)

        If Lines.Length <> 1 Then
            'Console.WriteLine(Trim(Microsoft.VisualBasic.Right(Lines(0), 8)))
            Shell("cmd.exe /c sc start ""WSearch""", vbHidden, True)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.25, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.25)
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Opacity = 1 Then
            Thread.Sleep(2000)
            Do Until Opacity = 0
                Opacity = Opacity - 0.01
                Thread.Sleep(10)
            Loop
            Form2.Show() '폼2를 띄운다
            Hide()
            Timer1.Enabled = False
        Else '//아니면

            Opacity = Opacity + 0.01

        End If '//if문 끝
    End Sub
End Class
