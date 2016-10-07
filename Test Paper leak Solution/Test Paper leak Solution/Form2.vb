Imports System.Threading

Imports System.IO

Public Class Form2
    '실행하는 프로세스
    Public pro As New Process()
    '작업 패치
    Dim path_file As String = "C:\Windows\tpls"
    '파일 명 전체 공통 변수
    Dim item As String
    '프로그램 종료
    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click



        Try
            If Not (pro.HasExited) Then
                MsgBox("문서 프로그램이 종료되어 있지 않습니다" & vbCrLf & "파일을 저장한 후에 프로그램을 종료해주세요", vbYes, "알림")
                Thread.Sleep(1500)
                pro.WaitForInputIdle()
                pro.WaitForExit()
                Form4.Hide()
                Return
            End If
        Catch
        End Try


        '파일 암호화
        file_en()
        '한글 혹은 워드만 암호화
        Form4.Close() '폼 종료
        Form5.Close() '폼 종료
        Timer2.Enabled = False
        End
    End Sub
    '새로 만들기 버튼으로 폼 3 실행
    Private Sub new_btn_Click(sender As Object, e As EventArgs) Handles new_btn.Click

        Me.Hide()
        Form3.WindowState = FormWindowState.Normal
        Form3.file_name.Text = ""
        Form3.Show()
    End Sub
    '폼 로드시 기본 변수 및 셋팅 로드
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form5.Show()
        'Form5.Timer1.Enabled = True
        exprot_btn.Visible = False
        import_btn.Visible = False
        GroupBox2.Visible = False
        pop_up_btn.Enabled = True
        Me.Size = New Size(815, 395)
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.18, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.3)
        '보기 좋은 위치에 로드

        Dim exists As Boolean = System.IO.Directory.Exists(path_file)
        '디렉토리 존재 여부

        If Not (exists) Then
            'MsgBox("새 디렉토리 생성", vbQuestion + vbYes, "tset")
            System.IO.Directory.CreateDirectory(path_file)
        End If
        '새 디렉토리 생성

        file_en() ' 파일 암호화

        file_list.Items.Clear()
        reset_list() ' 리스트 초기화


    End Sub
    '파일 열기
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


        ' 문자열 리스트에서 찾기
        Dim index As Integer = file_list.FindString(item)
        If index = -1 Then '  문자열 값이 없으면 에러 처리
            MessageBox.Show("파일이 존재하지 않거나 잘못되었습니다" & vbCrLf & "프로그램을 다시 실행하여 주십시요")
        Else


            If Mid(item, 2, 7).Equals("protect") Then

                Shell("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", AppWinStyle.Hide, True) '복호화
                'MsgBox("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", vbQuestion + vbYes, "tset")
                'Thread.Sleep(1800)
                'MsgBox("cmd.exe /c " & path_file & "\" & Mid(item, 13), vbQuestion + vbYes, "test")
                'Shell("cmd.exe /c " & path_file & "\" & Mid(item, 13), AppWinStyle.Hide) '열기
                pro.StartInfo.FileName = path_file & "\" & Mid(item, 13)
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                pro.Start()
                Timer1.Enabled = True

            Else
                'MsgBox(path_file & "\" & Mid(item, 13), vbYes, "test")
                pro.StartInfo.FileName = path_file & "\" & item
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                pro.Start()
                Timer1.Enabled = True

            End If



        End If
        Form4.Show()
        Form4.Timer3.Enabled = True ' 촬영 방지 폼 활성화
        Form4.Timer2.Enabled = True '워터마크 타이머 시작
        Form5.Show()

    End Sub
    ' 파일 삭제
    Private Sub del_btn_Click(sender As Object, e As EventArgs) Handles del_btn.Click '파일 삭제
        Try
            item = file_list.SelectedItem.ToString()
            Dim path_file As String
            path_file = "C:\Windows\tpls\"
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
        Catch
            MsgBox("파일을 선택해주세요", vbQuestion + vbYes, "알림")
        End Try


    End Sub
    '리스트 새로고침
    Sub reset_list() '리스트 갱신
        file_list.Items.Clear() '리스트초기화
        Dim dir As New IO.DirectoryInfo("C:\Windows\tpls")
        Dim fname As IO.FileInfo
        For Each fname In dir.GetFiles()
            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then
                file_list.Items.Add(fname)
            End If
            If fname.Extension.Equals(".tpls") Then
                file_list.Items.Add("[protect]->>" & Mid(fname.ToString, 2, (Len(fname.ToString) - 6))) '암호화된 파일 명 추출
            End If

        Next
    End Sub
    '프로그램 종료
    Private Sub Form2_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Determine if text has changed in the textbox by comparing to original text.
        'e.Cancel = True

        Try
            If Not (pro.HasExited) Then
                MsgBox("문서 프로그램이 종료되어 있지 않습니다" & vbCrLf & "파일을 저장한 후에 프로그램을 종료해주세요", vbYes, "알림")
                Thread.Sleep(1500)
                pro.WaitForInputIdle()
                pro.WaitForExit()
                Form4.Hide()
                Return
            End If
        Catch
        End Try


        '파일 암호화
        file_en()
        '한글 혹은 워드만 암호화
        Form4.Close() '폼 종료
        Form5.Close() '폼 종료
        End
    End Sub 'Form2_Closing
    '타이머 1 프로세스 종료시 모두 종료
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'MsgBox(pro.HasExited & vbCrLf & form4.Timer1.Enabled & vbCrLf & form4.Timer2.Enabled & vbCrLf & "form4_hide")
        Try
            If pro.HasExited() Then
                Form4.Hide()

                Form5.Hide()

                Form4.Timer2.Enabled = False
                Form4.Timer1.Enabled = False

                Timer1.Enabled = False
                pop_up_btn.Enabled = True
                file_en()
                exprot_btn.Enabled = True
                import_btn.Enabled = True
            Else
                exprot_btn.Enabled = False
                import_btn.Enabled = False

            End If
        Catch
            Return
        End Try
    End Sub
    '파일 암호화
    Sub file_en()
        Dim dir As New IO.DirectoryInfo("C:\Windows\tpls") '경로 설정
        Dim fname As IO.FileInfo '파일 정보들 받아올 변수 선언
        For Each fname In dir.GetFiles() '디렉토리에서 파일들 받아옴
            If fname.Extension.Equals(".hwp") Or fname.Extension.Equals(".docx") Then '파일의 확장자 점사
                Using file As New IO.FileStream(path_file & "\" & fname.ToString, IO.FileMode.Open) '암호화 되어 있지 않은 한글이나 워드는 직접 까본다
                    Dim value As Integer = file.ReadByte() '한바이트씩 읽어올 변수명
                    Dim count As Integer = 0 '몇 바이트 읽었는지 카운트할 변수 명
                    Do Until count = 1859 '이 값에서 중지 암호 비트
                        'Console.WriteLine(value.ToString("X2")) '디버깅용
                        count += 1 ' 1씩 더해주는 카운트
                        'Console.WriteLine(count)'디버깅용
                        value = file.ReadByte() '읽은 1바이트를 넘겨줌
                    Loop '반복 
                    file.Close() '파일 정상 닫음
                    'value = "15"'디버깅용
                    'Console.WriteLine(Convert.ToString(value, 2))'디버깅용
                    Dim tmp As String '변수 선언
                    tmp = Microsoft.VisualBasic.Right(Convert.ToString(value, 2).ToString, 1) '읽어혼 1바이트를 2진수로 표현하고 오른쪽 1문자 가져옴
                    'Console.WriteLine(tmp)'디버깅용
                    If Not tmp.Equals("1") Then '암호비트로 1인지 검사 1일경우 암호화
                        Shell("cmd.exe /c en.exe " & path_file & " " & fname.ToString, AppWinStyle.Hide, True) '암호화

                    End If 'if문 종료
                End Using 'using 문 종료
            End If 'if문 종료


        Next '파일 전부 돌 때까지 반봅
        reset_list() '리스트 갱신
        '파일 암호화
    End Sub
    '팝업 창 변수
    Private pop_up As Integer
    '팝업 창 동작시킬 모드랑 타이며 설정
    Private Sub pop_up_btn_Click(sender As Object, e As EventArgs) Handles pop_up_btn.Click
        If pop_up Then

            pop_up_btn.Text = ">> 파일 내보내기/가져오기 >>"
            pop_up = 0
            Timer2.Enabled = True
        Else

            pop_up_btn.Text = "<< 파일 내보내기/가져오기 <<"
            pop_up = 1

            Timer2.Enabled = True
        End If
    End Sub
    '팝업 창 동작 이벤트 설정
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If pop_up Then
            For index As Integer = 815 To 1100 Step 3
                Me.Size = New Size(index, 395)
            Next
            Me.Size = New Size(1100, 395)
            Timer2.Enabled = False
            exprot_btn.Visible = True
            import_btn.Visible = True
            GroupBox2.Visible = True
        Else
            GroupBox2.Visible = False
            exprot_btn.Visible = False
            import_btn.Visible = False
            For index As Integer = 1100 To 815 Step -3
                Me.Size = New Size(index, 395)
            Next

            Me.Size = New Size(815, 395)
            Timer2.Enabled = False

        End If

    End Sub

    Private Sub export_btn_Click(sender As Object, e As EventArgs) Handles exprot_btn.Click
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
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "한글 파일 (*.hwp)|*.hwp|암호화된 파일 (*.tpls)|*.tpls|워드 파일 (*.docx)|*.docx"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                ' Code to write the stream goes here.
                myStream.Close()
            End If
        End If
    End Sub

    Private Sub import_btn_Click(sender As Object, e As EventArgs) Handles import_btn.Click


        Dim myStream As Stream
        Dim saveFileDialog1 As New OpenFileDialog()

        saveFileDialog1.Filter = "한글 파일 (*.hwp)|*.hwp|암호화된 파일 (*.tpls)|*.tpls|*.워드 파일 (*.docx)|*.docx"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                ' Code to write the stream goes here.
                myStream.Close()
            End If
        End If
    End Sub
End Class