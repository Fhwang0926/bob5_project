Imports System.Text.RegularExpressions
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        check_passwd(TextBox1.Text)
    End Sub
    Public Sub check_passwd(str As String)
        Dim regexMatches As MatchCollection
        Dim regex As Regex
        Dim regexPattern As String
        If str.Length > 7 Then

            regexPattern = "\w\W"
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(str)
            If regexMatches.Count > 0 Then
                Dim tmp As String
                If TypeOf My.User.CurrentPrincipal Is
           Security.Principal.WindowsPrincipal Then
                    Dim parts() As String = Split(My.User.Name, "\")
                    Dim username As String = parts(1)
                    ''Console.WriteLine(username & "1")
                    tmp = username
                Else
                    ' The application is using custom authentication.
                    ''Console.WriteLine(My.User.Name & "0")
                    tmp = My.User.Name
                End If
                tmp = ("cmd.exe /c net user " & Trim(tmp.ToString) & " " & """" & str & """")
                Console.WriteLine(tmp)
                Shell(tmp, vbNormalFocus, True)
                MsgBox("암호가 변경되었습니다")
                Me.Hide()

            Else
                MsgBox("숫자, 문자, 특수문자가 포함되어야합니다")
            End If
            'Console.WriteLine(regexMatches.ToString)
        Else
            MsgBox("암호는 최소 8자리 이상입니다")
        End If
    End Sub
End Class