Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Microsoft.VisualBasic.Right(TextBox1.Text, 1) = "\" Then
            Shell("cmd.exe /c dir " & TextBox1.Text & "*.ecps" & " /on /b /s >>C:\ecps.txt", AppWinStyle.Hide, True)
            Console.WriteLine("cmd.exe /c dir " & TextBox1.Text & "*.ecps" & " /on /b /s >>C:\ecps.txt", AppWinStyle.Hide, True)
        Else
            Shell("cmd.exe /c dir " & TextBox1.Text & "\*.ecps" & " /on /b /s >>C:\ecps.txt", AppWinStyle.Hide, True)
            Console.WriteLine("cmd.exe /c dir " & TextBox1.Text & "\*.ecps" & " /on /b /s >>C:\ecps.txt", AppWinStyle.Hide, True)

        End If

        Dim Lines() As String = IO.File.ReadAllLines("C:\ecps.txt", Encoding.Default)
        If Lines.Length = 0 Then
            MsgBox("복호화할 파일이 없습니다")
            End
        End If
        For Each list_tmp In Lines
            Try
                ListBox1.Items.Add(list_tmp)
                ListBox1.TopIndex = ListBox1.Items.Count - 1
                ListBox1.SelectedItem = ListBox1.Items.Count - 1
                dec(list_tmp)
                Console.WriteLine("cmd.exe /c drm_changer.exe ^ """ & list_tmp & """")
                ListBox2.Items.Add(Microsoft.VisualBasic.Left(list_tmp, list_tmp.Length - 5))
                ListBox2.TopIndex = ListBox1.Items.Count - 1
                ListBox2.SelectedItem = ListBox1.Items.Count - 1
            Catch
            End Try
        Next
        Try
            My.Computer.FileSystem.DeleteFile("C:\ecps.txt")
        Catch
        End Try
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
End Class
