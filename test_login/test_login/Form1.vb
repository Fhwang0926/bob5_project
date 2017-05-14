Public Class Form1
    Dim tmp As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If TypeOf My.User.CurrentPrincipal Is
            Security.Principal.WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Console.WriteLine(username & "1")
            tmp = username
        Else
            ' The application is using custom authentication.
            Console.WriteLine(My.User.Name & "0")
            tmp = My.User.Name
        End If

        tmp = ("cmd.exe /c net user " & Trim(tmp.ToString) & " | find " & """-""" & " > C:\123.txt")
        Shell(tmp, vbHidden, True)

        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines(0) & "/" & Lines(1) & "/" & Lines(2))
        tmp = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Lines(0).ToString, 24), 10)
        Dim text_split() As String = Split(tmp, "-")

        tmp = ((Convert.ToInt64(Format(Now, "yyyy")) - Convert.ToInt64(text_split(0).ToString)) * 365) + Convert.ToInt64(text_split(2))
        'Console.WriteLine(tmp)
        'Console.WriteLine(Convert.ToInt64(Format(Now, "mm")))
        tmp = tmp + ((((Convert.ToInt64(Format(Now, "MM")) - Convert.ToInt64(text_split(1).ToString)))) * 30)
        Console.WriteLine(tmp)
        If CType(tmp, Integer) > 180 Then

        Else
            MsgBox(Format(Now, "dd"))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell(tmp, vbNormalFocus, True)
        Console.WriteLine(tmp)
    End Sub
End Class
