Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Shell("cmd.exe /c wmic qfe get installedon > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        Dim find As Integer
        Dim gap As TimeSpan
        Console.WriteLine(Lines.Length)
        For tmp = 2 To Lines.Length
            Console.WriteLine(Lines(tmp - 1))
            gap = (Convert.ToDateTime(Format(Today, "MM/dd/yyyy")) - Convert.ToDateTime(Lines(tmp - 1)))
        Next
        Console.WriteLine(gap.TotalDays)
        If gap.TotalDays < 8 Then
            find = 1
        Else
            find = 0
        End If
        If find Then
            Console.WriteLine("최근 윈도우 업데이트를 하였습니다")
        Else
            Console.WriteLine("윈도우 업데이트가 필요합니다")
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub
End Class
