Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports Microsoft.Win32
Imports System.Text.RegularExpressions


Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip
Imports System.Runtime.InteropServices

Public Class search
    Dim f As Integer = 0




    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer_start.Enabled = True ' 검색 시작 타이머 시작
        'HwpCtrl1.Enabled = False '한글 뷰 안보이기
        HwpCtrl1.Visible = False
    End Sub ' 폼 로드시 실행
    Private Sub timer_start_Tick(sender As Object, e As EventArgs) Handles timer_start.Tick
        'Console.WriteLine(Environment.UserName.ToString)
        timer_start.Enabled = False ' 타이머 종료
        scan_list_all.Items.Clear()
        If main.mode = 1 Then ' 전체 스캔
            del_start_txt()
            timer_count.Enabled = True '프로그레스바 시작
            count_label.Text = "찾을 파일 검색중입니다"
            state_label.Text = "검색중"
            Process("C:\") ' 전체 탐색
            timer_count.Enabled = False
            del_txt()
            Try
                Do While True
                    ProgressBar1.Value += 1
                    Application.DoEvents()
                    Console.WriteLine(ProgressBar1.Value)
                Loop
            Catch

            End Try
            Label1.Text = "         클릭시 미리보기 가능" & vbCrLf & vbCrLf & "        더블 클릭시 파일 실행"
            state_label.Text = "검색 완료"
            MsgBox("검색 완료", vbOKOnly, "결과 알림")

            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("last_search", Format(Now, "yyyy-MM-dd"))

            main.person_tag_date.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_search", "검색이 필요합니다")
        ElseIf main.mode = 0 Then '퀵 버전으로 사용자 계정 경로만 탐색
            del_start_txt()
            timer_count.Enabled = True '프로그레스바 시작
            count_label.Text = "찾을 파일 검색중입니다"
            state_label.Text = "검색중"
            Process("C:\Users\" & Environment.UserName.ToString)
            timer_count.Enabled = False
            del_txt()
            Try
                Do While True
                    ProgressBar1.Value += 1
                    Application.DoEvents()
                    Console.WriteLine(ProgressBar1.Value)
                Loop
            Catch

            End Try
            Label1.Text = "         클릭시 미리보기 가능" & vbCrLf & vbCrLf & "        더블 클릭시 파일 실행"
            MsgBox("검색 완료", vbOKOnly, "결과 알림")
            state_label.Text = "검색 완료"
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("last_search", Format(Now, "yyyy-MM-dd"))

            main.person_tag_date.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_search", "검색이 필요합니다")
        End If



    End Sub ' 자동 스타트 타이머
    Dim fileEntries As String() '파일 목록 변수
    Dim subdirectoryEntries As String() '폴더 목록 변수

    Public Sub Process(targetDirectory As String)

        fileEntries = Directory.GetFiles(targetDirectory)
        '파일목록 받아오기
        Dim fileName As String
        For Each fileName In fileEntries
            'Console.WriteLine("file : " & fileName)
            '각각의 확장자 별로 
            Select Case Microsoft.VisualBasic.Right(fileName, 4).ToString
                Case ".txt"
                    If config.set_txt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\txt.txt")

                    End If

                Case ".ppt"
                    If config.set_ppt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\ppt.txt")
                    End If

                Case "pptx"
                    If config.set_ppt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\ppt.txt")
                    End If


                Case ".doc"
                    If config.set_word.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\doc.txt")
                    End If

                Case "docx"
                    If config.set_word.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\doc.txt")
                    End If

                Case ".hwp"
                    If config.set_hwp.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\hwp.txt")
                    End If

                Case ".xls"
                    If config.set_xls.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\xls.txt")
                    End If

                Case "xlsx"
                    If config.set_xls.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\xls.txt")
                    End If
            End Select


        Next
        '디렉토리목록 받아오기
        subdirectoryEntries = Directory.GetDirectories(targetDirectory)

        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries ' 윈도우 폴더와 휴지통 제외
            If Not (subdirectory.Contains("Windows") Or subdirectory.Contains("WINDOWS") Or subdirectory.Contains("C:\$Recycle")) Then
                'Console.WriteLine("dir : " & subdirectory) '디버깅용

                path_tmp = subdirectory
                'Console.WriteLine(path) ' 디버깅용
                Try
                    all_find_pro()
                Catch

                End Try
            End If


        Next
        '메모장에서 목록 읽기
        update_one()




    End Sub '확장자별로 추출

    Dim finish_check As Boolean = 0 ' 추출 완료 여부 변수
    Dim path_tmp As String ' 위치 변수
    Dim str(5) As String ' 확장자별로 찾았는지 여부
    Private Sub all_find_pro()
        '스레드 변수 선언
        Dim hwp As New System.Threading.Thread(AddressOf hwp_pro) '스레드1 생성 
        Dim docx As New System.Threading.Thread(AddressOf docx_pro) '스레드2  생성
        Dim doc As New System.Threading.Thread(AddressOf doc_pro) '스레드3 생성 
        Dim ppt As New System.Threading.Thread(AddressOf ppt_pro) '스레드4  생성
        Dim pptx As New System.Threading.Thread(AddressOf pptx_pro) '스레드5 생성 
        Dim txt As New System.Threading.Thread(AddressOf txt_pro) '스레드6  생성
        Dim xls As New System.Threading.Thread(AddressOf xls_pro) '스레드7 생성 
        Dim xlsx As New System.Threading.Thread(AddressOf xlsx_pro) '스레드8  생성
        'Console.WriteLine(config.chk_txt.Checked)
        Application.DoEvents()
        If config.set_txt.Checked Then
            txt.Start()

        End If
        If config.set_hwp.Checked Then
            hwp.Start()

        End If

        If config.set_word.Checked Then
            docx.Start()
            doc.Start()

        End If
        If config.set_xls.Checked Then
            xls.Start()
            xlsx.Start()

        End If

        If config.set_ppt.Checked Then
            ppt.Start()
            pptx.Start()

        End If
        '=============
        If config.set_txt.Checked Then
            txt.Join()
            txt.Abort()
        End If
        If config.set_hwp.Checked Then
            hwp.Join()
            hwp.Abort()

        End If

        If config.set_word.Checked Then
            docx.Join()
            doc.Join()
            docx.Abort()
            doc.Abort()

        End If
        If config.set_xls.Checked Then
            xls.Join()
            xlsx.Join()
            xls.Abort()
            xlsx.Abort()

        End If

        If config.set_ppt.Checked Then
            ppt.Join()
            pptx.Join()
            ppt.Abort()
            pptx.Abort()


        End If
        '스레드 실행 및 대기
        finish_check = 1 '완료 알리는 변수
        '=========================

    End Sub ' 확장자별 찾을 것인가를 결정하는 함수
    Private Sub del_start_txt()
        For a = 0 To 4
            Try
                Select Case a
                    Case 0
                        My.Computer.FileSystem.DeleteFile("C:\hwp.txt")
                    Case 1
                        My.Computer.FileSystem.DeleteFile("C:\doc.txt")
                    Case 2
                        My.Computer.FileSystem.DeleteFile("C:\xls.txt")
                    Case 3
                        My.Computer.FileSystem.DeleteFile("C:\ppt.txt")
                    Case 4
                        My.Computer.FileSystem.DeleteFile("C:\txt.txt")

                End Select

            Catch
                Console.WriteLine("No file , can't delete")
            End Try
        Next

    End Sub '스캔 시작 전 파일 삭제
    Private Sub del_txt()
        For Each str_tmp In str
            Try
                If str_tmp.Length = 6 Then
                    My.Computer.FileSystem.DeleteFile("C:\" & Microsoft.VisualBasic.Right(str_tmp, 3) & ".txt")

                End If
            Catch
                Console.WriteLine("No file , can't delete")
            End Try
        Next

    End Sub '스캔 완료 후에 파일 삭제

    '각각의 확장자 파일들 목록 만들어줄 함수들
    Private Sub hwp_pro()
        str(1) = "\*.hwp"
        Shell("cmd.exe /c dir " & path_tmp & str(1) & " /on /b /s >>C:\hwp.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(1) & " /on /b /s >>C:\hwp.txt")
    End Sub
    Private Sub docx_pro()
        str(2) = "\*.doc"
        Shell("cmd.exe /c dir " & path_tmp & "\*.docx" & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(3) & " /on /b /s >>C:\doc.txt")
    End Sub
    Private Sub doc_pro()
        str(2) = "\*.doc"

        Shell("cmd.exe /c dir " & path_tmp & str(2) & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(2) & " /on /b /s >>C:\doc.txt")
    End Sub
    Private Sub ppt_pro()
        str(3) = "\*.ppt"
        Shell("cmd.exe /c dir " & path_tmp & "\*.ppt" & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(6) & " /on /b /s >>C:\ppt.txt")
    End Sub
    Private Sub pptx_pro()
        str(3) = "\*.ppt"
        Shell("cmd.exe /c dir " & path_tmp & "\*.pptx" & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(7) & " /on /b /s >>C:\ppt.txt")
    End Sub
    Private Sub xls_pro()
        str(4) = "\*.xls"
        Shell("cmd.exe /c dir " & path_tmp & str(4) & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(4) & " /on /b /s >>C:\xls.txt")
    End Sub
    Private Sub xlsx_pro()
        str(4) = "\*.xls"
        Shell("cmd.exe /c dir " & path_tmp & "\*.xlsx" & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(5) & " /on /b /s >>C:\xls.txt")
    End Sub
    Private Sub txt_pro()
        str(0) = "\*.txt"
        Shell("cmd.exe /c dir " & path_tmp & str(0) & " /on /b /s >>C:\txt.txt", AppWinStyle.Hide, True)
        Console.WriteLine("dir " & str(0) & " /on /b /s >>C:\txt.txt")
    End Sub

    '메모장 열고 문자열 검사하기
    Private Sub update_one()
        For Each tmp As String In str
            Try
                If tmp.Length = 6 Then
                    read_txt(Microsoft.VisualBasic.Right(tmp, 3).ToString & ".txt")
                End If
            Catch
            End Try
        Next
    End Sub

    Dim count As Integer = 0
    Private Sub read_txt(name_txt As String)

        Select Case Microsoft.VisualBasic.Left(name_txt, 3)
            Case "hwp"

                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "검색할 파일 : " & count.ToString
                pass_pw_set_file_timer.Enabled = True
                Application.DoEvents()
                Const HNCRoot As String = "HKEY_Current_User\Software\HNC\HwpCtrl\Modules"
                HwpCtrl1.Clear()
                Dim myProjectPath As String = path.GetFullPath(".\")
                If Microsoft.Win32.Registry.GetValue(HNCRoot, "FilePathCheckerModule", "Not Exist").Equals("Not Exist") Then
                    Microsoft.Win32.Registry.SetValue(HNCRoot, "FilePathCheckerModule", Application.StartupPath + "FilePathCheckerModule.dll")
                End If
                HwpCtrl1.RegisterModule("FilePathCheckDLL", "FilePathCheckerModule")
                For Each txt_line In Lines
                    Console.WriteLine(txt_line)

                    'Timer1.Enabled = True
                    HwpCtrl1.Open(txt_line)
                    HwpCtrl1.InitScan()
                    Application.DoEvents()
                    Try
                        'Console.WriteLine(HwpCtrl1.GetTextFile("TEXT", "").ToString)
                        If chk_pattern(HwpCtrl1.GetTextFile("TEXT", "").ToString) Then
                            hwp_list.Items.Add(txt_line)

                            scan_list_all.Items.Add(Mid(txt_line, InStrRev(txt_line, "\") + 1))

                            If ProgressBar1.Value < 90 Then
                                ProgressBar1.Value += 1
                            End If
                            Application.DoEvents()
                        End If
                    Catch
                        Console.WriteLine("hwp_hot_find_str")
                    End Try
                    Application.DoEvents()
                    HwpCtrl1.ReleaseScan()


                Next

                pass_pw_set_file_timer.Enabled = False
            Case "doc"
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "검색할 파일 : " & count.ToString
                For Each txt_line In Lines
                    ' Console.WriteLine(txt_line)
                    'Console.WriteLine(txt_line)
                    Timer1.Enabled = True
                    'word_list.Items.Clear()
                    'InitializeComponent()
                    Try
                        ' Extract text from an input file.

                        Dim dtt As New ECPS.DocxToTextDemo.DocxToText(txt_line)
                        'Console.WriteLine(dtt.ExtractText())
                        Application.DoEvents()

                        If chk_pattern(dtt.ExtractText().ToString) Then
                            word_list.Items.Add(txt_line)

                            scan_list_all.Items.Add(Mid(txt_line, InStrRev(txt_line, "\") + 1))

                            If ProgressBar1.Value < 90 Then
                                ProgressBar1.Value += 1
                            End If
                            Application.DoEvents()
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Application.DoEvents()


                Next
            Case "ppt"'구현 준비중
            Case "xls"
                Dim objExcel = CreateObject("Excel.Application") ' 엑셀 객체 생성
                objExcel.Visible = False ' 엑셀 프로그램 보이기, False로 하면 엑셀 창이 보이지 않고, Excel.exe 만 실행이 됩니다.
                Dim total_str As String = ""
                Dim objWorkBook As Object = Nothing
                Dim objWorkSheet As Object = Nothing
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "검색할 파일 : " & count.ToString

                For Each txt_line In Lines

                    Shell("cmd.exe /c ren """ & txt_line & """ """ & Replace(Mid(txt_line, InStrRev(txt_line, "\") + 1), " ", "_") & """")
                    txt_line = Microsoft.VisualBasic.Left(txt_line, InStrRev(txt_line, "\")) & Replace(Mid(txt_line, InStrRev(txt_line, "\") + 1), " ", "_")
                    Try
                        objWorkBook = objExcel.WorkBooks.Open(txt_line)
                        objWorkSheet = objWorkBook.Worksheets(1)

                        Console.WriteLine("Rows    : " & objWorkSheet.UsedRange.Rows.count)
                        Console.WriteLine("Columns : " & objWorkSheet.UsedRange.Columns.count)

                        Dim Range = objWorkSheet.UsedRange

                        ' Range 데이타를 배열 (One-based array)로
                        Dim data As Object(,) = Range.Value
                        For r As Integer = 1 To data.GetLength(0)
                            For c As Integer = 1 To data.GetLength(1)
                                If data(r, c) Is Nothing Then
                                    Continue For
                                Else
                                    Console.WriteLine(data(r, c).ToString())
                                    total_str += data(r, c).ToString()
                                End If
                            Next

                        Next

                        objWorkBook.Close(True)
                        objExcel.Quit()



                        If chk_pattern(total_str) Then
                            exc_list.Items.Add(txt_line)

                            scan_list_all.Items.Add(Mid(txt_line, InStrRev(txt_line, "\") + 1))

                            If ProgressBar1.Value < 90 Then
                                ProgressBar1.Value += 1
                            End If
                            Application.DoEvents()
                        End If
                        ReleaseExcelObject(objWorkSheet)
                        ReleaseExcelObject(objWorkBook)
                    Catch
                        Continue For
                    End Try
                    total_str = ""



                Next
                Try
                    ' Clean up

                    ReleaseExcelObject(objExcel)
                Catch
                End Try






            Case "txt"
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "검색할 파일 : " & count.ToString
                For Each txt_line In Lines
                    Console.WriteLine(txt_line)



                    'Console.WriteLine(My.Computer.FileSystem.ReadAllText(txt_line))
                    Application.DoEvents()
                    If chk_pattern(My.Computer.FileSystem.ReadAllText(txt_line)) Then
                        txt_list.Items.Add(txt_line)

                        scan_list_all.Items.Add(Mid(txt_line, InStrRev(txt_line, "\") + 1))

                        If ProgressBar1.Value < 90 Then
                            ProgressBar1.Value += 1
                        End If
                        Application.DoEvents()
                    End If

                Next

        End Select
        count_list()
    End Sub '  확장자별 파일 목록 메모장 읽기

    Private Function chk_pattern(tmp_str As String) '공용으로 사용될 함수 선택한 내용 탐색
        Application.DoEvents()
        Dim regexPattern As String
        Dim regex As Regex
        Dim regexMatches As MatchCollection
        Dim strSource As String
        strSource = tmp_str
        Dim re As Boolean = 0
        If config.set_person.Checked Then
            regexPattern = "([01][0-9]{5}[[:space:],~-]+[1-4][0-9]{6}|[2-9][0-9]{5}[[:space:],~-]+[1-2][0-9]{6})" ' 주민번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("주민번호 찾았다!!")
                re = 1
            End If
        End If

        If config.set_ip.Checked Then
            regexPattern = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$" 'ip주소
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine(" ip 주소 찾았다!!")
                re = 1
            End If
        End If
        If config.set_addr.Checked Then
            regexPattern = "[\S]+(도|시)\s[\S]+(구|군)*" ' 주소 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("집주소 찾았다!!")
                re = 1
            End If
        End If
        If config.set_card.Checked Then

            regexPattern = "[34569][0-9]{3}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}" '카드번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("카드번호 찾았다!!")
                re = 1
            End If
        End If
        If config.set_bank.Checked Then
            regexPattern = "([0-9]{2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{6}|[0-9]{3}[-~.[:space:]]([0-9]{5,6}[-~.[:sp
ace:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{5}|[0-9]{2,3}[-~.[:space:]][0-9]{6}|[0-9]{2}[-~.[:sp
ace:]][0-9]{7}|[0-9]{2}[-~.[:space:]][0-9]{4,6}[-~.[:space:]][0-9]|[0-9]{5}[-~.[:space:]][0-9]{
3}[-~.[:space:]][0-9]{2}|[0-9]{2}[-~.[:space:]][0-9]{5}[-~.[:space:]][0-9]{3}|[0-9]{4}[-~.[:spa
ce:]][0-9]{4}[-~.[:space:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{3}|[0-9]{
2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{7})|[0-9]{4}[-~.[:space:]]([0-9]{3}[-~.[:space:]][0
-9]{6}|[0-9]{2}[-~.[:space:]][0-9]{6}[-~.[:space:]][0-9])|[0-9]{5}[-~.[:space:]][0-9]{2}[-~.[:s
pace:]][0-9]{6}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{5,6})" '계좌번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("계좌번호 찾았다!!")
                re = 1
            End If
        End If
        If config.set_email.Checked Then
            regexPattern = "(\S+)@([^\.\s]+)(?:\.([^\.\s]+))+" '이메일 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("이메일 찾았다!!")
                re = 1
            End If
        End If
        If config.set_call.Checked Then
            regexPattern = "01[016789][-~.[:space:]][0-9]{3,4}[-~.[:space:]][0-9]{4}" ' 전화번호 정규식

            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("전화번호 찾았다!!")
                re = 1
            End If


        End If

        If re Then
            Return 1
        Else
            Return 0
        End If



    End Function ' 정규식 패턴 매치
    '한글 보안 모듈 해제 부분
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Handle As IntPtr = FindWindow("HNC_DIALOG", "HwpCtrl")
        'Console.WriteLine(Handle.ToString)
        If Not (Handle.Equals(IntPtr.Zero)) Then

            ' activate Notepad window
            If (SetActiveWindow(Handle)) Then
                ' Console.WriteLine(Handle.ToString)
                ' send "Hello World!"

                ' send key "Tab"
                SendKeys.Send("{TAB}")
                ' send key "Enter"
                SendKeys.Send("{ENTER}")
                Timer1.Enabled = False
            End If
        End If

    End Sub '한글 보안 모듈 해제 타이머
    Dim time_log As Integer = 0
    Private Sub timer_count_Tick(sender As Object, e As EventArgs) Handles timer_count.Tick
        time_log += 1

        time_label.Text = Format(Convert.ToDateTime(Int(time_log / 3600).ToString & ":" & Int((time_log Mod 3600) / 60).ToString & ":" & Int((time_log Mod 3600) Mod 60).ToString), "HH:mm:ss")

    End Sub ' 시간 카운트 타이머

    Private Sub pass_pw_set_file_timer_Tick(sender As Object, e As EventArgs) Handles pass_pw_set_file_timer.Tick
        Dim Handle As IntPtr = FindWindow("HNC_DIALOG", "문서 암호")
        Console.WriteLine(Handle.ToString)
        If Not (Handle.Equals(IntPtr.Zero)) Then

            ' activate Notepad window
            If (SetActiveWindow(Handle)) Then
                'Console.WriteLine(Handle.ToString)


                ' send key "Tab"
                SendKeys.Send("{TAB}")
                SendKeys.Send("{TAB}")
                ' send key "Enter"
                SendKeys.Send("{ENTER}")
                pass_pw_set_file_timer.Enabled = False
            End If
        End If

    End Sub '암호가 설정된 파일은 제외

    ' 한글 미리보기
    Private Sub hwp_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hwp_list.SelectedIndexChanged
        RichTextBox1.Visible = False
        Label1.Visible = False
        HwpCtrl1.Visible = True
        If UCase(Microsoft.VisualBasic.Right(hwp_list.SelectedItem, 4)) = "ECPS" Then
            Console.WriteLine("암호화 된 파일 입니다")
            Label1.Visible = True
            Label1.Text = "         암호화된 파일입니다" & vbCrLf & vbCrLf & "        미리 보기를 지원하지 않습니다"
            HwpCtrl1.Visible = False
            Exit Sub
        End If
        HwpCtrl1.Open(hwp_list.SelectedItem)
        HwpCtrl1.InitScan()
        Application.DoEvents()


        HwpCtrl1.ReleaseScan()

    End Sub

    '리스트에서 파일 열기
    Private Sub txt_list_open(sender As Object, e As EventArgs) Handles txt_list.DoubleClick
        Shell("cmd.exe /c " & """" & txt_list.SelectedItem & """")
        Console.WriteLine("cmd.exe /c " & """" & txt_list.SelectedItem & """")
    End Sub
    Private Sub hwp_list_open(sender As Object, e As EventArgs) Handles hwp_list.DoubleClick

        'HwpCtrl1.ReleaseScan()
        HwpCtrl1.Clear()
        Shell("cmd.exe /c " & """" & hwp_list.SelectedItem & """")
        Console.WriteLine("cmd.exe /c " & """" & hwp_list.SelectedItem & """")
    End Sub
    Private Sub word_list_open(sender As Object, e As EventArgs) Handles word_list.DoubleClick
        Shell("cmd.exe /c " & """" & word_list.SelectedItem & """")
        Console.WriteLine("cmd.exe /c " & "" & word_list.SelectedItem & """")
    End Sub
    Private Sub exc_list_open(sender As Object, e As EventArgs) Handles exc_list.DoubleClick
        Shell("cmd.exe /c " & """" & exc_list.SelectedItem & """")
        Console.WriteLine("cmd.exe /c " & """" & exc_list.SelectedItem & """")
    End Sub
    Private Sub ppt_list_open(sender As Object, e As EventArgs) Handles ppt_list.DoubleClick
        Shell("cmd.exe /c " & """" & ppt_list.SelectedItem & """")
        Console.WriteLine("cmd.exe /c " & """" & ppt_list.SelectedItem & """")
    End Sub
    Private Sub scan_list_all_open(sender As Object, e As EventArgs) Handles scan_list_all.DoubleClick
        MsgBox("전체 목록 확인만 가능합니다" & vbCrLf & "상세 위치를 확인시 파일 탭에서 선택해주세요")

    End Sub

    ' 파일 리스트에서 삭제
    Private Sub scan_del_part_btn_Click(sender As Object, e As EventArgs) Handles scan_del_part_btn.Click

        Select Case TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
            Case 0
                MsgBox("전체 목록 탭에서는 목록 확인만 가능합니다" & vbCrLf & "파일 삭제 및 암호화는 각각의 탭에서 가능합니다")

            Case 1

                For Each list_tmp In hwp_list.CheckedItems
                    Try
                        HwpCtrl1.Clear()
                        My.Computer.FileSystem.DeleteFile(list_tmp)


                    Catch
                    End Try

                Next
                Dim t As Integer = hwp_list.CheckedItems.Count
                Do Until t < 1
                    'Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    hwp_list.Items.RemoveAt(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    t = hwp_list.CheckedItems.Count
                Loop
            Case 2
                For Each list_tmp In exc_list.CheckedItems

                    Try
                        My.Computer.FileSystem.DeleteFile(list_tmp)


                    Catch
                    End Try

                Next
                Dim t As Integer = exc_list.CheckedItems.Count
                Do Until t < 1
                    'Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    exc_list.Items.RemoveAt(exc_list.Items.IndexOf(exc_list.CheckedItems(0)))
                    t = exc_list.CheckedItems.Count
                Loop
            Case 3

                For Each list_tmp In word_list.CheckedItems
                    Try
                        My.Computer.FileSystem.DeleteFile(list_tmp)


                    Catch
                    End Try

                Next
                Dim t As Integer = word_list.CheckedItems.Count
                Do Until t < 1
                    'Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    word_list.Items.RemoveAt(word_list.Items.IndexOf(word_list.CheckedItems(0)))
                    t = word_list.CheckedItems.Count
                Loop
            Case 4

                For Each list_tmp In ppt_list.CheckedItems
                    Try
                        My.Computer.FileSystem.DeleteFile(list_tmp)


                    Catch
                    End Try

                Next
                Dim t As Integer = ppt_list.CheckedItems.Count
                Do Until t < 1
                    'Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    ppt_list.Items.RemoveAt(ppt_list.Items.IndexOf(ppt_list.CheckedItems(0)))
                    t = ppt_list.CheckedItems.Count
                Loop
            Case 5

                For Each list_tmp In txt_list.CheckedItems
                    Try
                        My.Computer.FileSystem.DeleteFile(list_tmp)


                    Catch
                    End Try

                Next
                Dim t As Integer = txt_list.CheckedItems.Count
                Do Until txt_list.CheckedItems.Count < 1
                    'Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(0)))
                    txt_list.Items.RemoveAt(txt_list.Items.IndexOf(txt_list.CheckedItems(0)))
                    t = txt_list.CheckedItems.Count
                Loop

        End Select
        count_list()
    End Sub

    ' 파일 리스트 암호화
    Private Sub scan_del_btn_Click(sender As Object, e As EventArgs) Handles scan_enc_part_btn.Click

        Select Case TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
            Case 0
                MsgBox("전체 목록 탭에서는 목록 확인만 가능합니다" & vbCrLf & "파일 삭제 및 암호화는 각각의 탭에서 가능합니다")
            Case 1

                For Each list_tmp In hwp_list.CheckedItems
                    Try

                        HwpCtrl1.Clear()
                        If Not UCase(Microsoft.VisualBasic.Right(list_tmp, 4)) = "ECPS" Then
                            Shell("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                            Console.WriteLine("cmd.exe /c drm_changer.exe """ & list_tmp & """")

                        End If

                    Catch
                    End Try
                Next
                Try
                    Dim t As Integer = hwp_list.CheckedItems.Count
                    Dim tmp As Integer = 0
                    Do Until t < 1
                        Console.WriteLine(hwp_list.Items.IndexOf(hwp_list.CheckedItems(tmp)))
                        If Not UCase(Microsoft.VisualBasic.Right(hwp_list.Items(hwp_list.Items.IndexOf(hwp_list.CheckedItems(tmp))), 4)) = "ECPS" Then
                            hwp_list.Items.Add(hwp_list.Items(hwp_list.Items.IndexOf(hwp_list.CheckedItems(tmp))) & ".ecps")
                            hwp_list.Items.RemoveAt(hwp_list.Items.IndexOf(hwp_list.CheckedItems(tmp)))
                        Else

                            If tmp < hwp_list.CheckedItems.Count Then
                                tmp += 1
                            Else
                                t = 0

                            End If



                        End If


                    Loop
                Catch
                    Console.WriteLine("한글 암호화 에러")
                End Try
            Case 2
                For Each list_tmp In exc_list.CheckedItems
                    Try
                        If Not UCase(Microsoft.VisualBasic.Right(list_tmp, 4)) = "ECPS" Then
                            Shell("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                            Console.WriteLine("cmd.exe /c drm_changer.exe """ & list_tmp & """")

                        End If

                    Catch
                    End Try
                Next
                Try
                    Dim t As Integer = exc_list.CheckedItems.Count
                    Dim tmp As Integer = 0
                    Do Until t < 1
                        If Not UCase(Microsoft.VisualBasic.Right(exc_list.Items(exc_list.Items.IndexOf(exc_list.CheckedItems(tmp))), 4)) = "ECPS" Then
                            Console.WriteLine(exc_list.Items.IndexOf(exc_list.CheckedItems(tmp)))
                            exc_list.Items.Add(exc_list.Items(exc_list.Items.IndexOf(exc_list.CheckedItems(tmp))) & ".ecps")
                            exc_list.Items.RemoveAt(exc_list.Items.IndexOf(exc_list.CheckedItems(tmp)))
                        Else
                            If tmp < exc_list.CheckedItems.Count - 1 Then
                                tmp += 1
                            Else
                                t = 0

                            End If


                        End If

                    Loop
                Catch
                    Console.WriteLine("엑셀 암호화 에러")
                End Try
            Case 3
                For Each list_tmp In word_list.CheckedItems
                    Try
                        If Not UCase(Microsoft.VisualBasic.Right(list_tmp, 4)) = "ECPS" Then
                            Shell("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                            Console.WriteLine("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                        End If

                    Catch
                    End Try
                Next
                Try
                    Dim t As Integer = word_list.CheckedItems.Count
                    Dim tmp As Integer = 0
                    Do Until t < 1
                        If Not UCase(Microsoft.VisualBasic.Right(word_list.Items(word_list.Items.IndexOf(word_list.CheckedItems(tmp))), 4)) = "ECPS" Then
                            Console.WriteLine(word_list.Items.IndexOf(word_list.CheckedItems(tmp)))
                            word_list.Items.Add(word_list.Items(word_list.Items.IndexOf(word_list.CheckedItems(tmp))) & ".ecps")
                            word_list.Items.RemoveAt(word_list.Items.IndexOf(word_list.CheckedItems(tmp)))
                        Else
                            If tmp < word_list.CheckedItems.Count - 1 Then
                                tmp += 1
                            Else
                                t = 0

                            End If


                        End If

                    Loop
                Catch
                    Console.WriteLine("워드 암호화 에러")
                End Try
            Case 4
                For Each list_tmp In ppt_list.CheckedItems
                    Try
                        If Not UCase(Microsoft.VisualBasic.Right(list_tmp, 4)) = "ECPS" Then
                            Shell("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                            Console.WriteLine("cmd.exe /c drm_changer.exe """ & list_tmp & """")

                        End If

                    Catch
                    End Try
                Next
                Try
                    Dim t As Integer = ppt_list.CheckedItems.Count
                    Dim tmp As Integer = 0
                    Do Until t < 1
                        If Not UCase(Microsoft.VisualBasic.Right(ppt_list.Items(ppt_list.Items.IndexOf(ppt_list.CheckedItems(tmp))), 4)) = "ECPS" Then
                            Console.WriteLine(ppt_list.Items.IndexOf(ppt_list.CheckedItems(tmp)))
                            ppt_list.Items.Add(ppt_list.Items(ppt_list.Items.IndexOf(ppt_list.CheckedItems(tmp))) & ".ecps")
                            ppt_list.Items.RemoveAt(ppt_list.Items.IndexOf(ppt_list.CheckedItems(tmp)))
                        Else
                            If tmp < ppt_list.CheckedItems.Count - 1 Then
                                tmp += 1
                            Else
                                t = 0

                            End If

                        End If

                    Loop
                Catch
                    Console.WriteLine("PPT 암호화 에러")
                End Try
            Case 5
                For Each list_tmp In txt_list.CheckedItems
                    Try
                        If Not UCase(Microsoft.VisualBasic.Right(list_tmp, 4)) = "ECPS" Then
                            Shell("cmd.exe /c drm_changer.exe """ & list_tmp & """")
                            Console.WriteLine("cmd.exe /c drm_changer.exe """ & list_tmp & """")

                        End If
                    Catch
                    End Try
                Next
                Try
                    Dim t As Integer = txt_list.CheckedItems.Count
                    Dim tmp As Integer = 0
                    Do Until t < 1
                        If Not UCase(Microsoft.VisualBasic.Right(hwp_list.Items(hwp_list.Items.IndexOf(txt_list.CheckedItems(tmp))), 4)) = "ECPS" Then
                            Console.WriteLine(txt_list.Items.IndexOf(txt_list.CheckedItems(tmp)))
                            txt_list.Items.Add(txt_list.Items(txt_list.Items.IndexOf(txt_list.CheckedItems(tmp))) & ".ecps")
                            txt_list.Items.RemoveAt(txt_list.Items.IndexOf(txt_list.CheckedItems(tmp)))
                        Else

                            If tmp < txt_list.CheckedItems.Count - 1 Then
                                tmp += 1
                            Else
                                t = 0

                            End If

                        End If

                    Loop
                Catch
                    Console.WriteLine("텍스트 암호화 에러")
                End Try
        End Select
        count_list()
    End Sub

    ' 전체 선택
    Private Sub all_chk_btn_click(sender As Object, e As EventArgs) Handles all_chk_btn.Click
        Select Case TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
            Case 0
                MsgBox("전체 목록 탭에서는 목록 확인만 가능합니다" & vbCrLf & "파일 삭제 및 암호화는 각각의 탭에서 가능합니다")

            Case 1
                For idx As Integer = 0 To hwp_list.Items.Count - 1
                    hwp_list.SetItemCheckState(idx, CheckState.Checked)
                Next
            Case 2
                For idx As Integer = 0 To exc_list.Items.Count - 1
                    exc_list.SetItemCheckState(idx, CheckState.Checked)
                Next
            Case 3
                For idx As Integer = 0 To word_list.Items.Count - 1
                    word_list.SetItemCheckState(idx, CheckState.Checked)
                Next
            Case 4
                For idx As Integer = 0 To ppt_list.Items.Count - 1
                    ppt_list.SetItemCheckState(idx, CheckState.Checked)
                Next
            Case 5
                For idx As Integer = 0 To txt_list.Items.Count - 1
                    txt_list.SetItemCheckState(idx, CheckState.Checked)
                Next
        End Select
    End Sub

    ' 전체 선택 해제
    Private Sub all_unchk_btn_click(sender As Object, e As EventArgs) Handles all_unchk_btn.Click
        Select Case TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
            Case 0
                MsgBox("전체 목록 탭에서는 목록 확인만 가능합니다" & vbCrLf & "파일 삭제 및 암호화는 각각의 탭에서 가능합니다")

            Case 1
                For idx As Integer = 0 To hwp_list.Items.Count - 1
                    hwp_list.SetItemCheckState(idx, CheckState.Unchecked)
                Next
            Case 2
                For idx As Integer = 0 To exc_list.Items.Count - 1
                    exc_list.SetItemCheckState(idx, CheckState.Unchecked)
                Next
            Case 3
                For idx As Integer = 0 To word_list.Items.Count - 1
                    word_list.SetItemCheckState(idx, CheckState.Unchecked)
                Next
            Case 4
                For idx As Integer = 0 To ppt_list.Items.Count - 1
                    ppt_list.SetItemCheckState(idx, CheckState.Unchecked)
                Next
            Case 5
                For idx As Integer = 0 To txt_list.Items.Count - 1
                    txt_list.SetItemCheckState(idx, CheckState.Unchecked)
                Next
        End Select
    End Sub

    Private Sub txt_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_list.SelectedIndexChanged
        RichTextBox1.Visible = True
        RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(txt_list.SelectedItem)
    End Sub
    '엑셀 해제 함수
    Private Sub ReleaseExcelObject(obj As Object)
        Try
            If obj IsNot Nothing Then
                Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
            Throw ex
        Finally
            GC.Collect()
        End Try




    End Sub
    '갯수 세주는 함수
    Private Sub count_list()
        If Not (scan_list_all.Items.Count = 0) Then
            TabControl1.TabPages(0).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(0).Text, 5) & "(" & scan_list_all.Items.Count & ")"
        End If
        If Not (hwp_list.Items.Count = 0) Then
            TabControl1.TabPages(1).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(1).Text, 2) & "(" & hwp_list.Items.Count & ")"
        End If
        If Not (exc_list.Items.Count = 0) Then
            TabControl1.TabPages(2).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(2).Text, 2) & "(" & exc_list.Items.Count & ")"
        End If
        If Not (word_list.Items.Count = 0) Then
            TabControl1.TabPages(3).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(3).Text, 2) & "(" & word_list.Items.Count & ")"
        End If
        If Not (ppt_list.Items.Count = 0) Then
            TabControl1.TabPages(4).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(4).Text, 5) & "(" & ppt_list.Items.Count & ")"
        End If

        If Not (txt_list.Items.Count = 0) Then
            TabControl1.TabPages(5).Text = Microsoft.VisualBasic.Left(TabControl1.TabPages(5).Text, 3) & "(" & txt_list.Items.Count & ")"
        End If
    End Sub
End Class
Namespace DocxToTextDemo
    Public Class DocxToText
        Private Const ContentTypeNamespace As String = "http://schemas.openxmlformats.org/package/2006/content-types"

        Private Const WordprocessingMlNamespace As String = "http://schemas.openxmlformats.org/wordprocessingml/2006/main"

        Private Const DocumentXmlXPath As String = "/t:Types/t:Override[@ContentType=""application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml""]"

        Private Const BodyXPath As String = "/w:document/w:body"

        Private docxFile As String = ""
        Private docxFileLocation As String = ""


        Public Sub New(fileName As String)
            docxFile = fileName
        End Sub

#Region "ExtractText()"
        ''' <summary>
        ''' Extracts text from the Docx file.
        ''' </summary>
        ''' <returns>Extracted text.</returns>
        Public Function ExtractText() As String
            If String.IsNullOrEmpty(docxFile) Then
                Throw New Exception("Input file not specified.")
            End If

            ' Usually it is "/word/document.xml"

            docxFileLocation = FindDocumentXmlLocation()

            If String.IsNullOrEmpty(docxFileLocation) Then
                Throw New Exception("It is not a valid Docx file.")
            End If

            Return ReadDocumentXml()
        End Function
#End Region

#Region "FindDocumentXmlLocation()"
        ''' <summary>
        ''' Gets location of the "document.xml" zip entry.
        ''' </summary>
        ''' <returns>Location of the "document.xml".</returns>
        Private Function FindDocumentXmlLocation() As String
            Dim zip As New ZipFile(docxFile)
            For Each entry As ZipEntry In zip
                ' Find "[Content_Types].xml" zip entry

                If String.Compare(entry.Name, "[Content_Types].xml", True) = 0 Then
                    Dim contentTypes As Stream = zip.GetInputStream(entry)

                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.PreserveWhitespace = True
                    xmlDoc.Load(contentTypes)
                    contentTypes.Close()

                    'Create an XmlNamespaceManager for resolving namespaces

                    Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                    nsmgr.AddNamespace("t", ContentTypeNamespace)

                    ' Find location of "document.xml"

                    Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(DocumentXmlXPath, nsmgr)

                    If node IsNot Nothing Then
                        Dim location As String = DirectCast(node, XmlElement).GetAttribute("PartName")
                        Return location.TrimStart(New Char() {"/"c})
                    End If
                    Exit For
                End If
            Next
            zip.Close()
            Return Nothing
        End Function
#End Region

#Region "ReadDocumentXml()"
        ''' <summary>
        ''' Reads "document.xml" zip entry.
        ''' </summary>
        ''' <returns>Text containing in the document.</returns>
        Private Function ReadDocumentXml() As String
            Dim sb As New StringBuilder()

            Dim zip As New ZipFile(docxFile)
            For Each entry As ZipEntry In zip
                If String.Compare(entry.Name, docxFileLocation, True) = 0 Then
                    Dim documentXml As Stream = zip.GetInputStream(entry)

                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.PreserveWhitespace = True
                    xmlDoc.Load(documentXml)
                    documentXml.Close()

                    Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                    nsmgr.AddNamespace("w", WordprocessingMlNamespace)

                    Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(BodyXPath, nsmgr)

                    If node Is Nothing Then
                        Return String.Empty
                    End If

                    sb.Append(ReadNode(node))

                    Exit For
                End If
            Next
            zip.Close()
            Return sb.ToString()
        End Function
#End Region

#Region "ReadNode()"
        ''' <summary>
        ''' Reads content of the node and its nested childs.
        ''' </summary>
        ''' <param name="node">XmlNode.</param>
        ''' <returns>Text containing in the node.</returns>
        Private Function ReadNode(node As XmlNode) As String
            If node Is Nothing OrElse node.NodeType <> XmlNodeType.Element Then
                Return String.Empty
            End If

            Dim sb As New StringBuilder()
            For Each child As XmlNode In node.ChildNodes
                If child.NodeType <> XmlNodeType.Element Then
                    Continue For
                End If

                Select Case child.LocalName
                    Case "t"
                        ' Text
                        sb.Append(child.InnerText.TrimEnd())

                        Dim space As String = DirectCast(child, XmlElement).GetAttribute("xml:space")
                        If Not String.IsNullOrEmpty(space) AndAlso space = "preserve" Then
                            sb.Append(" "c)
                        End If

                        Exit Select

                    ' Carriage return
                    Case "cr", "br"
                        ' Page break
                        sb.Append(Environment.NewLine)
                        Exit Select

                    Case "tab"
                        ' Tab
                        sb.Append(vbTab)
                        Exit Select

                    Case "p"
                        ' Paragraph
                        sb.Append(ReadNode(child))
                        sb.Append(Environment.NewLine)
                        sb.Append(Environment.NewLine)
                        Exit Select
                    Case Else

                        sb.Append(ReadNode(child))
                        Exit Select
                End Select
            Next
            Return sb.ToString()
        End Function
#End Region
    End Class
End Namespace' 워드 문서 문자열 추출