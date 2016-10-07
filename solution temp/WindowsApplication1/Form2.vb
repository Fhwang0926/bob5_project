Imports System.Threading

Public Class Form2
    Public pro As New Process()
    Dim path_file As String
    Dim form3 As New Form3


    Dim item As String
    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click



        Try
            If Not (pro.HasExited) Then
                MsgBox("문서 프로그램이 종료되어 있지 않습니다" & vbCrLf & "파일을 저장한 후에 프로그램을 종료해주세요", vbYes, "알림")
                pro.WaitForInputIdle()
                pro.WaitForExit()

                Return
            End If
        Catch
        End Try


        '파일 암호화
        Dim dir As New IO.DirectoryInfo("C:\Windows\tmp")
        Dim fname As IO.FileInfo

        For Each fname In dir.GetFiles()

            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then
                path_file = "C:\Windows\tmp"

                Shell("cmd.exe /c en.exe " & path_file & " " & fname.ToString, AppWinStyle.Hide)

            End If
        Next

        End
    End Sub

    Private Sub new_btn_Click(sender As Object, e As EventArgs) Handles new_btn.Click

        Me.Hide()
        form3.WindowState = FormWindowState.Normal
        form3.file_name.Text = ""
        form3.Show()
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.25, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.3)
        Dim exists As Boolean
        path_file = "C:\Windows\tmp"
        exists = System.IO.Directory.Exists(path_file)
        If Not (exists) Then
            MsgBox("새 디렉토리 생성", vbQuestion + vbYes, "tset")
            System.IO.Directory.CreateDirectory(path_file)
        End If
        '새 디렉토리 생성
        file_list.Items.Clear()
        Dim dir As New IO.DirectoryInfo(path_file)
        Dim fname As IO.FileInfo
        Dim pro_tmp As New Process()

        For Each fname In dir.GetFiles()
            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then

                Shell("cmd.exe /c en.exe " & path_file & " " & fname.ToString, AppWinStyle.Hide, True)

            End If

        Next


        reset_list()




    End Sub

    Private Sub open_btn_Click(sender As Object, e As EventArgs) Handles open_btn.Click
        'Get the currently selected item in the ListBox.
        Try
            If String.IsNullOrEmpty(file_list.SelectedItem.ToString()) Then
                MsgBox("파일명을 목록에서 선택해주세요", vbQuestion + vbYes, "알림")
                Return
            Else
                item = file_list.SelectedItem.ToString()
            End If
        Catch
            MsgBox("파일명을 목록에서 선택해주세요", vbQuestion + vbYes, "알림")
            Return
        End Try


        ' Find the string in ListBox2.
        Dim index As Integer = file_list.FindString(item)
        ' If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
        If index = -1 Then
            MessageBox.Show("파일이 존재하지 않거나 잘못되었습니다" & vbCrLf & "프로그램을 다시 실행하여 주십시요")
        Else
            Dim path_file As String
            path_file = "C:\Windows\tmp"
            If Mid(item, 2, 7).Equals("protect") Then

                Shell("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", AppWinStyle.Hide) '복호화
                'MsgBox("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", vbQuestion + vbYes, "tset")
                Thread.Sleep(1800)
                'MsgBox("cmd.exe /c " & path_file & "\" & Mid(item, 13), vbQuestion + vbYes, "test")
                'Shell("cmd.exe /c " & path_file & "\" & Mid(item, 13), AppWinStyle.Hide) '열기
                pro.StartInfo.FileName = path_file & "\" & Mid(item, 13)
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                pro.Start()
            Else
                'MsgBox(path_file & "\" & Mid(item, 13), vbYes, "test")
                pro.StartInfo.FileName = path_file & "\" & item
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                pro.Start()
            End If
            reset_list()


        End If


    End Sub
    Private Sub del_btn_Click(sender As Object, e As EventArgs) Handles del_btn.Click

        item = file_list.SelectedItem.ToString()
        Dim path_file As String
        path_file = "C:\Windows\tmp\"
        If Mid(item, 2, 7).Equals("protect") Then
            path_file = path_file & "_" & Mid(item, 13) & ".tpls"

            My.Computer.FileSystem.DeleteFile(path_file)
        Else
            path_file = path_file & item
            My.Computer.FileSystem.DeleteFile(path_file)
        End If
        'Thread.Sleep(1500)
        MsgBox("삭제된 파일 : " & item, vbQuestion + vbYes, "알림")
        reset_list()


    End Sub
    Sub reset_list()
        file_list.Items.Clear()
        Dim dir As New IO.DirectoryInfo("C:\Windows\tmp")
        Dim fname As IO.FileInfo
        For Each fname In dir.GetFiles()
            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then
                file_list.Items.Add(fname)
            End If
            If fname.Extension.Equals(".tpls") Then
                file_list.Items.Add("[protect]->>" & Mid(fname.ToString, 2, (Len(fname.ToString) - 6)))
            End If
        Next
    End Sub
    Private Sub Form2_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Determine if text has changed in the textbox by comparing to original text.
        'e.Cancel = True

        Try
            If Not (pro.HasExited) Then
                MsgBox("문서 프로그램이 종료되어 있지 않습니다" & vbCrLf & "파일을 저장한 후에 프로그램을 종료해주세요", vbYes, "알림")
                pro.WaitForInputIdle()
                pro.WaitForExit()
                Return
            End If
        Catch
        End Try


        '파일 암호화
        Dim dir As New IO.DirectoryInfo("C:\Windows\tmp")
        Dim fname As IO.FileInfo

        For Each fname In dir.GetFiles()

            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then
                path_file = "C:\Windows\tmp"

                Shell("cmd.exe /c en.exe " & path_file & " " & fname.ToString, AppWinStyle.Hide)

            End If
        Next

        End
    End Sub 'Form2_Closing


End Class
