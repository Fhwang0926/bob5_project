Imports System.IO
Imports System.Text
Public Class ECPS_changer
    Dim pro As New Process()
    Dim args(Environment.GetCommandLineArgs().Length) As String
    Dim file As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        args = Environment.GetCommandLineArgs()

        'Dim tmp() As Byte = New Byte((System.Environment.GetCommandLineArgs().Length - 1)) {} '파일 바이트 배열 생성
        'Array.Copy(System.Environment.GetCommandLineArgs(), tmp, System.Environment.GetCommandLineArgs().Length - 1)
        Me.Hide()
        'Array.ConstrainedCopy(tmp, 1, args, 0, tmp.Length - 1)
        Dim one As Boolean = 1
        For Each temp In args
            If one Then
                one = 0
            Else
                file += temp & " "
            End If

        Next

        'debug용
        'MsgBox(args(0).ToString & "1")
        file = RTrim(file)
        'MsgBox(file & "2")

        Try
            If Microsoft.VisualBasic.Right(file, 4) = "ECPS" Or Microsoft.VisualBasic.Right(file, 4) = "ecps" Then
                dec(file)

                pro.StartInfo.FileName = Microsoft.VisualBasic.Left(file.ToString, file.ToString.Length - 5)
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                pro.Start()
                Timer1.Enabled = True
            Else

                enc(file)
                End
            End If
        Catch


            Console.WriteLine("force exit")
            End
        End Try


    End Sub
    Private Sub enc(full_name As String)
        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((IO.File.ReadAllBytes(full_name).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(IO.File.ReadAllBytes(full_name), file_tmp, IO.File.ReadAllBytes(full_name).Length) '파일 바이트 배열 받기

        Array.Reverse(file_tmp) ' 파일 바이트 재배열

        IO.File.WriteAllBytes(full_name & ".ecps", Combine(mark_arr, file_tmp))
        Try
            Shell("cmd.exe /c del """ & full_name & """")
        Catch
        End Try
        My.Computer.FileSystem.DeleteFile(full_name)

    End Sub
    Private Sub dec(full_name As String)

        Dim s As String = "[Content_Types].We are P.K Team "
        Dim mark_arr() As Byte = System.Text.Encoding.Default.GetBytes(s) '문자열 바이트로
        Dim file_tmp() As Byte = New Byte((IO.File.ReadAllBytes(full_name).Length - 1)) {} '파일 바이트 배열 생성
        Array.Copy(IO.File.ReadAllBytes(full_name), file_tmp, IO.File.ReadAllBytes(full_name).Length) '파일 바이트 배열 받기
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If pro.HasExited() Then
            enc(Microsoft.VisualBasic.Left(file, file.Length - 5))
            End
        End If
    End Sub
End Class
