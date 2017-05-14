Imports System.Threading

Imports System.IO

Public Class Form2
    Dim list_item_tmp As Integer = 0
    '실행하는 프로세스
    Public pro As New Process()
    '작업 패치
    Dim path_file As String = "C:\Windows\tpps"
    '파일 명 전체 공통 변수
    Dim item As String
    '폼 로드시 기본 변수 및 셋팅 로드
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Size = New Size(852, 395)
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.25)
        '보기 좋은 위치에 로드

        Dim exists As Boolean = System.IO.Directory.Exists(path_file)
        '디렉토리 존재 여부

        If Not (exists) Then
            'MsgBox("새 디렉토리 생성", vbQuestion + vbYes, "tset")
            System.IO.Directory.CreateDirectory(path_file)
        End If
        '새 디렉토리 생성

        file_en() ' 파일 암호화


        reset_list() ' 리스트 초기화


    End Sub
    '리스트 새로고침
    Sub reset_list() '리스트 갱신
        file_list.Items.Clear() '리스트초기화
        pass_list.Items.Clear()
        other_list.Items.Clear()
        Dim dir As New IO.DirectoryInfo("C:\Windows\tpps")
        Dim fname As IO.FileInfo

        For Each fname In dir.GetFiles() '디렉토리에서 파일들 받고
            If fname.ToString.Contains(".hwp") Then '한글파일인지 검사
                'Console.WriteLine(fname.CreationTime.Year & "=" & Now.Year.ToString)디버깅용
                If fname.CreationTime.Year.ToString.Equals(Now.Year.ToString) Then '만든 날짜 비교
                    If fname.Extension.Equals(".tpls") Then ' 암호화한 파일 비교
                        file_list.Items.Add("[protect]->>" & Mid(fname.ToString, 2, (Len(fname.ToString) - 6))) '암호화된 파일 명 추출
                    Else
                        file_list.Items.Add(fname) '그냥 한글 파일 리스트에 추가
                    End If
                Else
                    If fname.Extension.Equals(".tpls") Then '한글파일이면서 지난연도 파일은 이쪽으로
                        pass_list.Items.Add("[protect]->>" & Mid(fname.ToString, 2, (Len(fname.ToString) - 6))) '암호화된 파일 명 추출
                    Else
                        pass_list.Items.Add(fname) '여기에 넣어준다
                    End If
                End If

            Else

                If fname.Extension.Equals(".tpls") Then '암호화된 파일은 암호화 해서 넣어준다 나머지
                    other_list.Items.Add("[protect]->>" & Mid(fname.ToString, 2, (Len(fname.ToString) - 6))) '암호화된 파일 명 추출
                Else
                    other_list.Items.Add(fname) '그냥 파일 명 넣어준다
                End If
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
                Call SetAttr(pro.StartInfo.FileName, vbNormal)
                FileClose(1)
                Form4.Hide()

                Form5.Hide()

                Form4.Timer2.Enabled = False
                Form4.Timer1.Enabled = False

                Timer1.Enabled = False

                file_en()
                export_btn.Enabled = True
                import_btn.Enabled = True
            Else
                export_btn.Enabled = False
                import_btn.Enabled = False

            End If
        Catch
            Return
        End Try
    End Sub
    '파일 암호화
    Sub file_en()
        Dim dir As New IO.DirectoryInfo("C:\Windows\tpps") '경로 설정
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
    '파일 내보내기
    Private Sub export_btn_Click(sender As Object, e As EventArgs) Handles export_btn.Click
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

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "한글 파일 (*.hwp)|*.hwp|암호화된 파일 (*.tpls)|*.tpls|워드 파일 (*.docx)|*.docx"
        If Mid(item, 2, 7).Equals("protect") Then
            saveFileDialog1.FilterIndex = 2
        Else
            If Microsoft.VisualBasic.Right(item, 1).Equals("p") Then
                saveFileDialog1.FilterIndex = 1
            Else
                saveFileDialog1.FilterIndex = 3
            End If
        End If
        If Mid(item, 2, 7).Equals("protect") Then
            saveFileDialog1.FileName = "_" & Mid(item, 13) & ".tpls"
        Else
            saveFileDialog1.FileName = item
        End If
        saveFileDialog1.RestoreDirectory = True



        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            'MsgBox(path_file & "\" & file_list.SelectedItem.ToString)디버깅용
            Dim Source As String = ""
            Dim Destination As String = ""
            If Mid(item, 2, 7).Equals("protect") Then
                Dim m As Integer = 1
                Dim l As Integer = 1
                Dim re As String = ""
                Dim last_name As String = ""
                Dim path_tmp As String = ""

                If Mid(item, 13).Contains("docx") Then
                    last_name = ".docx"
                ElseIf Mid(item, 13).Contains("hwp") Then
                    last_name = ".hwp"

                End If

                Do Until m = -1
                    'Console.WriteLine(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(saveFileDialog1.FileName, m), 1))
                    re = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(saveFileDialog1.FileName, m), 1)
                    If Not re.Equals(".") Then
                        m = m + 1 '확장자와 파일 명 사이 m 인덱스
                    Else

                        Do Until l = -1
                            re = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Mid(saveFileDialog1.FileName, 1, Len(saveFileDialog1.FileName) - m), l), 1)
                            If Not re.Equals("\") Then
                                Source = re & Source '소스가 파일 명이 된다
                                l = l + 1 ' l 인덱스
                            Else
                                path_tmp = Microsoft.VisualBasic.Left(saveFileDialog1.FileName, (Len(saveFileDialog1.FileName) - (l + m - 1)))
                                l = -1
                            End If
                        Loop


                        m = -1
                    End If

                Loop
                If Microsoft.VisualBasic.Left(Source, 1).Equals("_") Then
                    Destination = Replace$(path_tmp & Source & last_name + ".tpls", "", "_")
                Else
                    Destination = Replace$(path_tmp & "_" & Source & last_name + ".tpls", "", "_")
                End If

                Source = path_file & "\" & "_" & Mid(item, 13) & ".tpls"

            Else
                Source = path_file & "\" & item
                Destination = Replace$(saveFileDialog1.FileName.ToString, " ", "_")
            End If

            'MsgBox(Source)
            Source = Replace$(Source, " ", "_")
            Destination = Replace$(Destination, " ", "_")
            System.IO.File.Copy(Source, Destination, True)
        End If
        reset_list()
    End Sub
    '파일 불러오기
    Private Sub import_btn_Click(sender As Object, e As EventArgs) Handles import_btn.Click
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "한글 파일 (*.hwp)|*.hwp|암호화된 파일 (*.tpls)|*.tpls|*.워드 파일 (*.docx)|*.docx"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        Dim Source As String = ""
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim m As Integer = 1
            Dim re As String = ""
            Do Until m = -1
                re = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(openFileDialog1.FileName, m), 1)
                If Not re.Equals("\") Then
                    Source = re & Source
                    m = m + 1
                Else
                    m = -1
                End If
            Loop
            'MsgBox(Source)

            Dim Destination As String = path_file & "\" & Source
            Source = Replace$(openFileDialog1.FileName.ToString, " ", "_")
            System.IO.File.Copy(Source, Destination, True)
        End If
        reset_list()
    End Sub
    '새로 만들기 버튼으로 폼 3 실행
    Private Sub new_btn_Click_1(sender As Object, e As EventArgs) Handles new_btn.Click
        Me.Hide()
        Form3.WindowState = FormWindowState.Normal
        Form3.file_name.Text = ""
        Form3.Show()
    End Sub
    ' 파일 삭제
    Private Sub del_btn_Click_1(sender As Object, e As EventArgs) Handles del_btn.Click

        Try
            Select Case list_item_tmp
                Case 0
                    item = file_list.SelectedItem.ToString()
                Case 1
                    item = pass_list.SelectedItem.ToString()
                Case 2
                    item = other_list.SelectedItem.ToString()
            End Select
            Console.WriteLine(item)
            Dim path_file As String
            path_file = "C:\Windows\tpps\"
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
    '파일 열기
    Private Sub open_btn_Click_1(sender As Object, e As EventArgs) Handles open_btn.Click
        open_func()
    End Sub
    '리스트 더블 클릭시 파일 열기 실행
    Private Sub list_duble_click1(sender As Object, e As EventArgs) Handles file_list.DoubleClick
        open_func()
    End Sub
    Private Sub list_duble_click2(sender As Object, e As EventArgs) Handles pass_list.DoubleClick
        open_func()
    End Sub
    Private Sub list_duble_click(sender As Object, e As EventArgs) Handles other_list.DoubleClick
        open_func()
    End Sub
    '어느 탭을 선택 했느지 변수 설정
    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) _
     Handles TabControl1.Selected

        'Dim messageBoxVB As New System.Text.StringBuilder()
        'messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
        'messageBoxVB.AppendLine()
        'messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
        'messageBoxVB.AppendLine()
        'messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
        'messageBoxVB.AppendLine()
        'MessageBox.Show(messageBoxVB.ToString(), "Selected Event")
        '탭 페이지 설정해주는 부분
        Select Case e.TabPageIndex
            Case 0
                list_item_tmp = 0
            Case 1
                list_item_tmp = 1
            Case 2
                list_item_tmp = 2
        End Select
    End Sub
    '팝업 창 숨기기
    Private Sub popdown_Click(sender As Object, e As EventArgs) Handles popdown.Click
        popup.Enabled = True
        popup.Visible = True

        Me.Size = New Size(982, 395)
        popdown.Visible = False
        popdown.Enabled = False

        GroupBox1.Visible = True
        import_btn.Visible = True
        export_btn.Visible = True

    End Sub
    '팝업 창 보이기
    Private Sub popup_Click(sender As Object, e As EventArgs) Handles popup.Click
        popup.Enabled = False
        popup.Visible = False

        Me.Size = New Size(852, 395)
        popdown.Visible = True
        popdown.Enabled = True
        GroupBox1.Visible = False
        import_btn.Visible = False
        export_btn.Visible = False

    End Sub
    '파일 열기 함수
    Private Sub open_func()
        Try
            Select Case list_item_tmp
                Case 0
                    item = file_list.SelectedItem.ToString()
                Case 1
                    item = pass_list.SelectedItem.ToString()
                Case 2
                    item = other_list.SelectedItem.ToString()
            End Select

            If String.IsNullOrEmpty(item) Then
                MsgBox("파일명을 목록에서 선택해주세요", vbQuestion + vbYes, "알림")
                Return
            Else
                item = item
            End If
        Catch
            MsgBox("파일명을 목록에서 선택해주세요", vbQuestion + vbYes, "알림")
            Return
        End Try


        ' 문자열 리스트에서 찾기
        Dim index As Integer
        Select Case list_item_tmp
            Case 0
                index = file_list.FindString(item)
            Case 1
                index = pass_list.FindString(item)
            Case 2
                index = other_list.FindString(item)
        End Select

        If index = -1 Then '  문자열 값이 없으면 에러 처리
            MessageBox.Show("파일이 존재하지 않거나 잘못되었습니다" & vbCrLf & "프로그램을 다시 실행하여 주십시요")
        Else


            If Mid(item, 2, 7).Equals("protect") Then

                Shell("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", AppWinStyle.Hide, True) '복호화
                'MsgBox("cmd.exe /c " & "de.exe " & path_file & " _" & Mid(item, 13) & ".tpls", vbQuestion + vbYes, "tset")
                'Thread.Sleep(1800)
                'MsgBox("cmd.exe /c " & path_file & "\" & Mid(item, 13), vbQuestion + vbYes, "test")
                'Shell("cmd.exe /c " & path_file & "\" & Mid(item, 13), AppWinStyle.Hide) '열기
                Call SetAttr(path_file & "\" & Mid(item, 13), vbHidden)
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
    '내보내기 마우스 가져다가 댈 때 
    Private Sub export_btn_MouseHover(sender As Object, e As EventArgs) Handles export_btn.MouseHover
        export_btn.Image = My.Resources.ex
        export_btn.Text = ""
    End Sub
    '가져오기 마우스 가져다가 댈 때
    Private Sub import_btn_MouseHover(sender As Object, e As EventArgs) Handles import_btn.MouseHover
        import_btn.Image = My.Resources.im
        import_btn.Text = ""
    End Sub
    '내보내기 마우스 멀어질 때
    Private Sub export_btn_MouseLeave(sender As Object, e As EventArgs) Handles export_btn.MouseLeave
        export_btn.Image = export_btn.BackgroundImage
        export_btn.Text = "내보내기" & vbCrLf & "(Export)"
    End Sub
    '가져오기 마우스 멀어질 때
    Private Sub import_btn_MouseLeave(sender As Object, e As EventArgs) Handles import_btn.MouseLeave
        import_btn.Image = import_btn.BackgroundImage
        import_btn.Text = "내보내기" & vbCrLf & "(Export)"
    End Sub
End Class