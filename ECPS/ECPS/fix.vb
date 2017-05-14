Imports Microsoft.Win32
Imports System.Management
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports System.Text.RegularExpressions
Public Class Fix
    '변수들
    Dim tmp As Integer = 0
    Dim check_pass As Integer = 0
    Dim finish As Boolean = 0
    Dim Thread1 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드1 생성
    'tool_lodding
    Dim loding_tmp As Integer = 0
    Private Sub tool_timer_Tick(sender As Object, e As EventArgs) Handles tool_bar_timer.Tick

        loding_tmp = loding_tmp + 1
        If (loding_tmp = 1) Then
            tool_loding.BackgroundImage = My.Resources.lo1

        ElseIf (loding_tmp = 2) Then
            tool_loding.BackgroundImage = My.Resources.lo2

        ElseIf (loding_tmp = 3) Then
            tool_loding.BackgroundImage = My.Resources.lo3

        ElseIf (loding_tmp = 4) Then
            tool_loding.BackgroundImage = My.Resources.lo4
            loding_tmp = 0
        End If

    End Sub '진행 상황 빙빙 돌아가는 진행원
    'reset form
    Private Sub fix_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Location = New Point(main.ActiveForm.Location.X, main.ActiveForm.Location.Y)
        timer_start.Enabled = True
        log.Items.Clear()


    End Sub ' 초기 로드시 리셋
    'tool_button
    Dim mode_tmp As Integer = 0
    Private Sub tool_start_btn_hover(sender As Object, e As EventArgs) Handles tool_btn.MouseHover
        '0 정지
        '1 재시작
        '2 개선
        If mode_tmp = 0 Then
            tool_btn.BackgroundImage = My.Resources.stop_btn_press

        ElseIf mode_tmp = 1 Then
            tool_btn.BackgroundImage = My.Resources.restart_btn_press
        Else
            tool_btn.BackgroundImage = My.Resources.fix_btn_press


        End If

    End Sub '버튼 마우스 진입할때
    Private Sub tool_start_btn_leave(sender As Object, e As EventArgs) Handles tool_btn.MouseLeave
        '0 정지
        '1 재시작
        '2 개선
        If mode_tmp = 0 Then
            tool_btn.BackgroundImage = My.Resources.stop_btn

        ElseIf mode_tmp = 1 Then
            tool_btn.BackgroundImage = My.Resources.restart_btn
        Else
            tool_btn.BackgroundImage = My.Resources.fix_btn


        End If
    End Sub '버튼 마우스 떠날 때
    'tool_do_it
    Private Sub tool_back()
        timer_start.Enabled = False

        '1
        check_antivirus()

        '2
        check_window_update1()

        '3
        scan_hwp()

        '4
        passwd_safe()

        '5
        passwd_recycle()

        '6
        screen_checker()

        '7
        share_folder_checker()

        '8
        dvice_autorun_checker()

        '9
        old_activex()


        TopMost = True
        tool_bar_timer.Enabled = True
    End Sub '버튼 누를때 진행되는 함수 모음
    Public chk(10) As Integer ' 양호는 1, 취약은 0
    Dim tmp1(3) As String '임시변수
    Dim stats As Integer '상태
    Dim str As String '문자열 임시변수
    Private pro As New Process() '프로세스 변수
    '1
    Private Sub check_antivirus()
        ' Open handle to to Windows Security Center '
        Dim oWMI As Object = GetObject(
                  "winmgmts:{impersonationLevel=impersonate}!\\.\root\SecurityCenter2")

        ' Run Query for all AntiVirusProduct instances '
        Dim colItems As Object = oWMI.ExecQuery("Select * from AntiVirusProduct")

        ' Check if we found any instances '
        If colItems.count = 0 Then
            'Console.WriteLine("No antivirus products")
            Exit Sub
        Else
            ' Iterate over each of the instances found and dump useful display data '
            For Each objItem In colItems

                With objItem
                    stats = .productState
                    str = stats.ToString("X6")

                    tmp1(3) = Microsoft.VisualBasic.Right(str, 2)
                    tmp1(2) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(str, 4), 2)
                    tmp1(1) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(str, 6), 2)

                    'Console.WriteLine(tmp1(1))
                    'Console.WriteLine(tmp1(2))
                    'Console.WriteLine(tmp1(3))

                    Dim test As Integer = 0
                    Dim d As Integer = tmp1(1)
                    If (4 And d) = 4 Then
                        set_stats("설치된 백신 : " & .displayName & "!!", 1)

                    Else
                        set_stats("설치된 백신 : 없음!!", 1)
                        test = test + 1
                    End If


                    d = tmp1(2)
                    If (10 And d) = 10 Then
                        set_stats("실시간 검사 작동중...!!", 1)

                    Else
                        set_stats("실시간 검사 미작동중...!!", 1)
                        test = test + 1
                    End If
                    d = tmp1(3)
                    'If (0 And d) = 0 And (2 And d) = 2 Then
                    ' set_stats(.displayName & " 최신 버전 확인 완료...!", 1)
                    ' log.Items.Add("백신 업데이트 상태 양호...!")
                    ' Else
                    ' log.Items.Add("백신 업데이트 상태 취약...!")
                    ' set_stats(.displayName & " 업데이트가 필요합니다...!", 1)
                    ' test = test + 1
                    ' End If
                    'msgBox("Product name = " & .displayName & vbLf _
                    '  & "Path to product = " & .pathToSignedProductExe & vbLf _
                    ' & "Product state = " & .productState & vbLf _
                    ', vbOKOnly, "Antivirus product")


                    If test = 0 Then
                        chk(1) = 1

                        set_stats("백신 점검 양호", 1)
                    Else
                        chk(1) = 0

                        set_stats("백신 점검 취약", 1)
                    End If
                End With
            Next


        End If

    End Sub '백신의 존재 유무 확인 함수
    '2 this fast version 
    Private Sub check_window_update1()
        Shell("cmd.exe /c echo echo off> C:\123.bat", vbHidden, True)
        Shell("cmd.exe /c echo cls>> C:\123.bat", vbHidden, True)
        Shell("cmd.exe /c echo wmic qfe get installedon>> C:\123.bat", vbHidden, True)
        '
        Dim oStartInfo As New ProcessStartInfo("C:\123.bat")
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        pro.StartInfo = oStartInfo
        pro.Start()
        'Thread1.Start()
        'Thread1.Join()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = pro.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using
        'Console.WriteLine(sOutput)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("c:\123.txt", True)
        file.WriteLine(sOutput)
        file.Close()




        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        Dim find As Integer
        Dim gap As TimeSpan
        'Console.WriteLine(Lines.Length)
        For tmp = 3 To Lines.Length - 1
            If Lines(tmp).ToString <> "" Then
                'Console.WriteLine(Lines(tmp - 1))
                gap = (Convert.ToDateTime(Format(Today, "MM/dd/yyyy")) - Convert.ToDateTime(Lines(tmp)))
                If gap.TotalDays < 8 Then
                    find = 1
                Else
                    find = 0
                End If
            End If

        Next
        'Console.WriteLine(gap.TotalDays)

        If find Then
            chk(2) = 1
            set_stats("최근 윈도우 업데이트 일자 경과 7일 이내", 1)
            set_stats("최근 윈도우 업데이트를 하였습니다", 1)

        Else
            chk(2) = 0
            set_stats("최근 윈도우 업데이트 일자 경과 7일 경과", 1)
            set_stats("윈도우 업데이트 확인이 필요합니다", 1)

        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
        My.Computer.FileSystem.DeleteFile("C:\123.bat")
    End Sub '설치된 윈도우 학픽스 확인(설치되어 있는 업데이트 목록 확인, 빠름) 함수
    '2 thie slow version
    Private Sub check_window_update()


        Dim updateSession = CreateObject("Microsoft.Update.Session")
        updateSession.ClientApplicationID = "MSDN Sample Script"

        Dim updateSearcher = updateSession.CreateUpdateSearcher()


        Console.WriteLine("Searching for updates...")
        Dim searchResult = updateSearcher.Search("IsInstalled=0 and Type='Software' and IsHidden=0")


        If Not searchResult.Updates.Count = 0 Then
            Console.WriteLine("Can downloads applicable updates.")
            pic2.BackgroundImage = My.Resources.check_no
        Else
            pic2.BackgroundImage = My.Resources.check_yes

        End If
        'Dim readValue = My.Computer.Registry.GetValue(
        '"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", Nothing)
        ' MsgBox("The value is " & readValue)

        'fin = 1
    End Sub '윈도우 업데이트 체크(윈도우 서버에 물어봐서 느리다) 함수
    '3
    Private Sub scan_hwp()

        Dim hwp_use As Integer

        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey _
                   ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", False)

        Dim SubKeyNames() As String = Key.GetSubKeyNames()


        Dim cnt As Integer = 0

        Dim Index As Integer

        Dim SubKey As RegistryKey

        For Index = 0 To Key.SubKeyCount - 1

            SubKey = Registry.LocalMachine.OpenSubKey _
                       ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" + "\" _
                          + SubKeyNames(Index), False)

            If Not SubKey.GetValue("DisplayName", "") Is "" Then

                If Not (InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한글", 1) Or (InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한컴", 1)) And InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "오피스", 1)) = 0 Then
                    Dim InputString As String = CType(SubKey.GetValue("DisplayName", ""), String)
                    hwp_use = 1

                    Exit For
                Else
                    hwp_use = 0

                End If


            End If
        Next
        If hwp_use = 1 Then
            set_stats("한글 사용중입니다", 1)
        Else
            set_stats("한글 미사용중입니다", 1)
        End If
        Dim hwp_auto_update As Integer
        '------------------------------reseach rtart registry
        'if 64-bit

        Shell("cmd.exe /c reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"" | find ""HncUpdate"" > C:\123.txt", vbHidden, True)

        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        If Lines.Length <> 0 Then
            set_stats("한글 자동 업데이트 사용", 1)
            hwp_auto_update = 0
        Else
            set_stats("한글 자동 업데이트 미사용", 1)
            hwp_auto_update = 1
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
        '---------------------------------------
        'check_update_date
        Dim comp As Integer
        Dim hwp_update_date As String = My.Computer.Registry.GetValue(
              "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\HNC\Shared\HncUpdate", "LastUpdate", 0) '최근 업데이트 일시
        comp = (Year(Now) - Convert.ToInt32(Microsoft.VisualBasic.Left(hwp_update_date, 4))) * 365 + (Month(Now) - Convert.ToInt32(Microsoft.VisualBasic.Mid(hwp_update_date, 5, 2))) * 30 + (Convert.ToInt32(Format(Now, "dd")) - Convert.ToInt32(Microsoft.VisualBasic.Right(hwp_update_date, 2)))

        'Console.WriteLine(comp)
        Dim hwp_update_recycle As Integer
        If comp < 15 Then
            set_stats("한글 업데이트 수준 양호", 1)
            hwp_update_recycle = 0
        Else
            set_stats("한글 업데이트 수준 위험", 1)
            hwp_update_recycle = 1
        End If
        If hwp_use And (hwp_update_recycle Or hwp_auto_update) Then

            set_stats("한글 점검 취약", 1)
            chk(3) = 0
        Else

            set_stats("한글 점검 양호", 1)
            chk(3) = 1
        End If


    End Sub '한글 관련 레지스터 스캔으로 취약, 양호 판단 함수
    '4
    Private Sub passwd_safe()
        If loding.once = 1 Then
            chk(4) = 1
            set_stats("암호 설정이 안전합니다", 1)

        Else
            chk(4) = 0
            set_stats("암호 설정이 위험합니다", 1)


        End If
    End Sub '패스워드 재설정을 통한 초기화 여부 확인 함수
    '5
    Private Sub passwd_recycle()
        Dim tmp As String
        If TypeOf My.User.CurrentPrincipal Is
                   Security.Principal.WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            'Console.WriteLine(username & "1")
            tmp = username
        Else

            'Console.WriteLine(My.User.Name & "0")
            tmp = My.User.Name
        End If
        set_stats(tmp.ToString & " 패스워드 주기 검사", 1)
        tmp = ("cmd.exe /c net user " & Trim(tmp.ToString) & " | find " & """-""" & " > C:\123.txt")
        Shell(tmp, vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines(0) & "/" & Lines(1) & "/" & Lines(2))
        tmp = Microsoft.VisualBasic.Left(Trim(Microsoft.VisualBasic.Right(Lines(0).ToString, 25)), 10)
        Dim text_split() As String = Split(tmp, "-")
        'Console.WriteLine(text_split(0) & "/" & text_split(1) & "/" & text_split(2))
        tmp = ((Convert.ToInt64(Format(Now, "yyyy")) - Convert.ToInt64(text_split(0).ToString)) * 365)
        'Console.WriteLine(tmp)
        'Console.WriteLine(Convert.ToInt64(Format(Now, "MM")))
        'Console.WriteLine((Convert.ToInt64(Format(Now, "dd")) - Convert.ToInt64(text_split(2))))
        tmp = tmp + ((((Convert.ToInt64(Format(Now, "MM")) - Convert.ToInt64(text_split(1).ToString)))) * 30) + (Convert.ToInt64(Format(Now, "dd")) - Convert.ToInt64(text_split(2)))
        'Console.WriteLine(tmp)
        If CType(tmp, Integer) > 180 Then
            chk(5) = 0
            set_stats("패스워드 변경 후 3개월 경과", 1)

        Else
            chk(5) = 1
            set_stats("패스워드 변경 후 3개월 미경과", 1)

        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub ' 패스워드 변경 주기 6개월 경과 여부 파악 함수
    '6
    Private Sub screen_checker()
        Dim tmp(4) As Integer
        Dim ScreenSaveActive2 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", Nothing) '화면 보호기 활성화 여부
        If ScreenSaveActive2 = 1 Then
            tmp(0) = 1
            set_stats("화면 보호기 표시 설정됨", 1)
        Else
            tmp(0) = 0
            set_stats("화면 보호기 표시 미설정됨", 1)
        End If
        Dim ScreenSaverIsSecure = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaverIsSecure", Nothing) ' 화면보호기 재진입시 패스워드 여부
        If ScreenSaverIsSecure = 1 Then
            tmp(1) = 1
            set_stats("화면 재진입시 암호 설정됨", 1)
        Else
            tmp(1) = 0
            set_stats("화면 재진입시 암호 미설정됨", 1)
        End If
        Dim ScreenSaveTimeOut = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveTimeOut", Nothing) ' 화면 보호기 진입 대기 시간 권장 10분
        Dim ClickLockTime = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ClickLockTime", Nothing) ' 화면 보호기 진입 대기 시간 권장 10분
        If Convert.ToInt32(ScreenSaveTimeOut) <= 600 And Convert.ToInt32(ClickLockTime) <= 600 Then
            tmp(2) = 1
            set_stats("화면 대기시간 10분 이내, 양호", 1)
        Else
            tmp(2) = 0
            set_stats("화면 대기시간 10분 이상, 위험", 1)
        End If
        Try
            My.Computer.FileSystem.DeleteFile("123.txt")
        Catch ex As Exception

        End Try
        Shell("cmd.exe /c echo echo off> 123.bat", vbHidden, True)
        Shell("cmd.exe /c echo cls>> 123.bat", vbHidden, True)
        Shell("cmd.exe /c echo reg query ""HKEY_CURRENT_USER\Control Panel\Desktop"" >> 123.bat", vbHidden, True)

        Dim oStartInfo As New ProcessStartInfo("123.bat")
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        pro.StartInfo = oStartInfo
        pro.Start()
        'Thread1.Start()
        'Thread1.Join()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = pro.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using
        Console.WriteLine(sOutput)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("123.txt", True)
        file.WriteLine(sOutput)
        file.Close()

        Dim Lines() As String = IO.File.ReadAllLines("123.txt")
        Dim re As Boolean = 0
        For Each str In Lines

            If str.Contains("SCRNSAVE.EXE") Then
                re = 1
                Exit For
            Else


            End If
        Next
        If re Then
            tmp(3) = 1
            set_stats("화면 보호기 설정됨", 1)
        Else
            tmp(3) = 0
            set_stats("화면 보호기 미설정됨", 1)

        End If
        My.Computer.FileSystem.DeleteFile("123.txt")
        My.Computer.FileSystem.DeleteFile("123.bat")

        'Console.WriteLine("ScreenSaveActive : " & ScreenSaveActive2.ToString & " / " & "ScreenSaverIsSecure : " & ScreenSaverIsSecure.ToString & " / " & "ScreenSaveTimeOut : " & ScreenSaveTimeOut.ToString)
        If tmp(0) And tmp(1) And tmp(2) And tmp(3) Then
            set_stats("화면 보호 양호", 1)
            chk(6) = 1
        Else
            set_stats("화면 보호 취약", 1)
            chk(4) = 0
        End If
    End Sub ' 화면 보호기 여부 확인 함수
    '7
    Private Sub share_folder_checker()
        Shell("cmd.exe /c net share > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines.Length)
        If Lines.Length <= 6 Then

            set_stats("공유 폴더 미존재,양호", 1)
            chk(7) = 1
        Else
            chk(7) = 0
            set_stats("공유 폴더 존재,취약", 1)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub ' 공유 폴더 존재 유무 확인 함수
    '8
    Private Sub dvice_autorun_checker()
        Shell("cmd.exe /c sc query ""ShellHWDetection"" | find ""RUNNING"" > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines.Length)

        If Lines.Length Then
            'Console.WriteLine(Trim(Microsoft.VisualBasic.Right(Lines(0), 8)))

            set_stats("USB 자동 실행 사용, 취약", 1)
            chk(8) = 0
        Else
            chk(8) = 1
            set_stats("USB 자동 실행 중지, 양호", 1)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub 'USB 자동 실행 여부 확인 함수
    '9
    Private Sub old_activex() ' 3개월 경과 ActiveX 존재 유무 확인 함수
        Dim dir As New IO.DirectoryInfo("C:\Windows\Downloaded Program Files")
        Dim fname As IO.FileInfo
        Dim ddir As IO.DirectoryInfo
        Dim re_cunt As Integer
        Dim toto As Date = Format(Now, "yyyy-MM-dd")
        Dim comp As Date
        Dim gap As TimeSpan
        Try
            For Each ddir In dir.GetDirectories()
                'Console.WriteLine(toto)
                'Console.WriteLine(Format(ddir.LastAccessTime, "yyyy-MM-dd"))
                comp = Format(ddir.LastAccessTime, "yyyy-MM-dd")
                gap = toto - comp
                'Console.WriteLine(gap.TotalDays)
                If gap.TotalDays > 90 Then
                    re_cunt = re_cunt + 1
                    set_stats("90일 경과 ActiveX : O", 1)
                Else
                    set_stats("90일 경과 ActiveX : X", 1)
                End If

            Next
            For Each fname In dir.GetFiles()

                If fname.Extension.Equals(".ocx") Or fname.Extension.Equals(".dll") Then
                    'Console.WriteLine(Format(fname.LastAccessTime, "yyyy-MM-dd"))
                    comp = Format(fname.LastAccessTime, "yyyy-MM-dd")
                    gap = toto - comp
                    'Console.WriteLine(gap.TotalDays)
                    If gap.TotalDays > 90 Then
                        re_cunt = re_cunt + 1
                        set_stats("90일 경과 ActiveX : O", 1)
                    Else
                        set_stats("90일 경과 ActiveX : X", 1)
                    End If
                End If
            Next
        Catch ex As Exception
            set_stats("ActiveX 경로 폴더 확인 요망", 1)
        End Try



        If re_cunt > 0 Then
            chk(9) = 0
            set_stats("90일 경과 ActiveX 존재, 취약", 1)
        Else
            chk(9) = 1
            set_stats("90일 경과 ActiveX 없음, 양호", 1)
        End If
        Me.Focus()
    End Sub
    'set_state
    Private Sub set_stats(str As String, bool As Boolean)
        If bool Then

            log.Items.Add(str)
            log.TopIndex = log.Items.Count - 1
        End If

    End Sub 'log 및 상태 업데이트용 함수
    ' thread sub
    Private Sub ThreadFuction1()
        Shell("cmd.exe /c wmic qfe get installedon >> 123.txt", AppWinStyle.Hide, True)
        Console.WriteLine("thread1 완료")

    End Sub '윈도우 업데이트 체크 스레드 처리 함수
    'tool_bar_update_val and chk input
    Private Sub tool_bar_timer_Tick(sender As Object, e As EventArgs) Handles tool_bar_timer.Tick
        Try
            Select Case tool_bar.Value

                Case 100

                    If chk(1) Then
                        pic1.BackgroundImage = My.Resources.check_yes
                    Else

                        pic1.BackgroundImage = My.Resources.check_no
                    End If
                Case 200
                    If chk(2) Then
                        pic2.BackgroundImage = My.Resources.check_yes
                    Else
                        pic2.BackgroundImage = My.Resources.check_no
                    End If


                Case 300
                    If chk(3) Then
                        pic3.BackgroundImage = My.Resources.check_yes
                    Else
                        pic3.BackgroundImage = My.Resources.check_no
                    End If
                Case 400

                    If chk(4) Then
                        pic4.BackgroundImage = My.Resources.check_yes
                    Else
                        pic4.BackgroundImage = My.Resources.check_no
                    End If
                Case 500
                    If chk(5) Then
                        pic5.BackgroundImage = My.Resources.check_yes
                    Else
                        pic5.BackgroundImage = My.Resources.check_no
                    End If
                Case 600
                    If chk(6) Then
                        pic6.BackgroundImage = My.Resources.check_yes
                    Else
                        pic6.BackgroundImage = My.Resources.check_no
                    End If
                Case 700

                    If chk(7) Then
                        pic7.BackgroundImage = My.Resources.check_yes
                    Else
                        pic7.BackgroundImage = My.Resources.check_no
                    End If
                Case 800
                    If chk(8) Then
                        pic8.BackgroundImage = My.Resources.check_yes
                    Else
                        pic8.BackgroundImage = My.Resources.check_no
                    End If
                Case 900

                    If chk(9) Then
                        pic9.BackgroundImage = My.Resources.check_yes
                    Else
                        pic9.BackgroundImage = My.Resources.check_no
                    End If


            End Select

            If (tool_bar.Value > 900) Then
                'Console.WriteLine(tool_bar.Value)
                tool_bar_timer.Enabled = False
                finish_check()
                notice.Show()

            End If
            tool_bar.Value = tool_bar.Value + 10
        Catch

        End Try
    End Sub '프로그래스바 및 점검 결과 표시 함수
    'start form work
    Private Sub timer_start_Tick(sender As Object, e As EventArgs) Handles timer_start.Tick
        tool_back()

    End Sub ' 폼 시작되면 타이머 시작 함수
    'tool_mode_change
    Private Sub tool_btn_Click(sender As Object, e As EventArgs) Handles tool_btn.Click
        '0 정지
        '1 재시작
        '2 개선
        If mode_tmp = 0 Then
            mode_tmp = 1

        ElseIf mode_tmp = 1 Then
            mode_tmp = 0
        Else
            fix_all()


        End If
    End Sub '정지, 개선 버튼 눌렀을 때 이벤트 함수
    'finish_check
    Private Sub finish_check()
        Do While True
            Try
                tool_bar.Value += 10
                Threading.Thread.Sleep(80)
            Catch ex As Exception

                tool_btn.BackgroundImage = My.Resources.fix_btn
                mode_tmp = 2
                ToolStripStatusLabel1.Text = "완료 : 보안 수준 개선이 필요합니다 ""FIX"" 버튼을 눌러 보안 수준을 향상 시키세요"
                finish = 1
                TopMost = False
                Exit Do
            End Try
        Loop
    End Sub '진단 완료를 확인하는 함수, 진단이 완료되면 동작
    'input rich box info
    Private Sub tool_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tool_list.SelectedIndexChanged
        'Console.WriteLine(tool_list.SelectedIndex+1)
        Select Case tool_list.SelectedIndex + 1
            Case 1
                RichTextBox1.Text = "시스템에 바이러스 백신이 설치 여부를 점검합니다
백신의 실시간 감시를 사용하는지 여부를 점검합니다
바이러스 백신이 최신 업데이트 상태를 유지하고 있는지 점검합니다.
결과는 취약, 양호로 나타냅니다
"
            Case 2
                RichTextBox1.Text = "윈도우 자동 업데이트를 사용 여부를 점검합니다
최근 윈도우 보안 업데이트 실시 여부를 점검합니다
최근 업데이트 실행 일자 이후로 7일 경과시에 취약으로 판정합니다
결과는 취약, 양호로 나타냅니다
"
            Case 3
                RichTextBox1.Text = "한컴의 한글 프로그램 설치 여부를 점검합니다
설치되어 있다면 한컴의 한글 프로그램 업데이트 여부를 점검합니다
자동 업데이트 설정을 하였는지 여부를 점검합니다
최근 업데이트 일자 이후로 2주가 경과하면 취약으로 판정합니다
결과는 취약, 양호로 나타냅니다
"
            Case 4
                RichTextBox1.Text = "Windows 로그인 패스워드의 안전성을 점검합니다.
패스워드는 문자, 숫자, 특수문자를 포함하고 있어야 합니다
결과는 취약, 양호로 나타냅니다
"
            Case 6
                RichTextBox1.Text = "화면 보호기 설정 여부를 점검합니다.
결과는 취약, 양호로 나타냅니다
"
            Case 7
                RichTextBox1.Text = "사용자 공유 폴더가 설정되어 있는지 점검합니다.
결과는 취약, 양호로 나타냅니다
"
            Case 8
                RichTextBox1.Text = "USB의 자동 실행이 허용되어 있는지 점검합니다.
결과는 취약, 양호로 나타냅니다
"
            Case 9
                RichTextBox1.Text = "3개월 동안 사용되지 않은 ActiveX 프로그램의 존재하는지 점검합니다.
결과는 취약, 양호로 나타냅니다
"


        End Select

    End Sub '진단 항목별 설명 박스 함수

    Private Sub install_antivirus()
        Dim a As Integer
        a = MsgBox("백신 설치가 필요합니다" & vbCrLf & " 설치 하시겠습니까?" & vbCrLf & "백신은 안철수연구소의 V3 Lite입니다", vbYesNo, "알림")
        If a = 6 Then
            My.Computer.Network.DownloadFile("http://provide.ahnlab.com/v3lite/v30/download/V3Lite_Setup.exe", "C:\V3Lite_Setup.exe")
            Shell("c:\V3Lite_Setup.exe", AppWinStyle.Hide, True)
            My.Computer.FileSystem.DeleteFile("C:\V3Lite_Setup.exe")
        End If
    End Sub 'V3 lite 다운받고 설치하는 함수


    Private Sub fix_all()

        If chk(1) = 0 Then
            Dim oWMI As Object = GetObject(
                  "winmgmts:{impersonationLevel=impersonate}!\\.\root\SecurityCenter2")
            Dim colItems As Object = oWMI.ExecQuery("Select * from AntiVirusProduct")
            If colItems.count = 0 Then
                install_antivirus()
                Exit Sub
            Else
                For Each objItem In colItems
                    With objItem
                        stats = .productState
                        str = stats.ToString("X6")
                        tmp1(3) = Microsoft.VisualBasic.Right(str, 2)
                        tmp1(2) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(str, 4), 2)
                        tmp1(1) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(str, 6), 2)

                        Dim d As Integer = tmp1(1)
                        If Not (4 And d) = 4 Then
                            install_antivirus()
                        End If
                        d = tmp1(2)
                        If Not (10 And d) = 10 Then
                            Shell("cmd.exe /c C:\Windows\System32\wscui.cpl", AppWinStyle.Hide, True)
                            MsgBox("설치된 백신의 실시간 감시를 사용하도록 설정하세요", vbOK, "백신 설정 알림")
                        End If
                        d = tmp1(3)
                        If Not (0 And d) = 0 Then
                            MsgBox(.displayName & " 업데이트가 필요합니다...!", vbYes, "업데이트 알림")
                        End If

                    End With
                Next


            End If
        End If

        '---------------------------1-------------------------------- 백신 관련 설정
        If chk(2) = 0 Then
            Shell("cmd.exe /c wuapp.exe startmenu", vbHidden, True)
        End If
        '---------------------------2-------------------------------- 윈도우 업데이트 설정을 위해 설정 변경 창 띄움
        If chk(3) = 0 Then


            Dim hwp_use As Integer = 0

            Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey _
                       ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", False)

            Dim SubKeyNames() As String = Key.GetSubKeyNames()


            Dim cnt As Integer = 0

            Dim Index As Integer
            Dim location As String
            Dim SubKey As RegistryKey

            For Index = 0 To Key.SubKeyCount - 1

                SubKey = Registry.LocalMachine.OpenSubKey _
                           ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" + "\" _
                              + SubKeyNames(Index), False)

                If Not SubKey.GetValue("InstallLocation", "") Is "" Then
                    'Console.WriteLine(SubKey.GetValue("InstallLocation", ""))
                    If Not (InStr(1, CType(SubKey.GetValue("InstallLocation", ""), String), "\Hnc\", 1) Or InStr(1, CType(SubKey.GetValue("InstallLocation", ""), String), "\HNC\", 1)) Then
                        location = CType(SubKey.GetValue("InstallLocation", ""), String)
                        Console.WriteLine(location)
                        hwp_use = 1
                        Exit For
                    Else


                    End If


                End If
            Next
            If hwp_use = 1 Then

                '------------------------------reseach rstart registry
                'if 64-bit

                Shell("cmd.exe /c reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"" | find ""HncUpdate"" > C:\123.txt", vbHidden, True)

                Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
                If Not Lines.Length <> 0 Then
                    MsgBox("한글 자동 업데이트를 설정하여야 합니다", vbYes, "한글 자동 업데이트 설정")
                End If
                My.Computer.FileSystem.DeleteFile("C:\123.txt")
                '---------------------------------------
                'check_update_date
                Dim comp As Integer
                Dim hwp_update_date As String = My.Computer.Registry.GetValue(
                  "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\HNC\Shared\HncUpdate", "LastUpdate", 0) '최근 업데이트 일시
                comp = (Year(Now) - Convert.ToInt32(Microsoft.VisualBasic.Left(hwp_update_date, 4))) * 365 + (Month(Now) - Convert.ToInt32(Microsoft.VisualBasic.Mid(hwp_update_date, 5, 2))) * 30 + (Convert.ToInt32(Format(Now, "dd")) - Convert.ToInt32(Microsoft.VisualBasic.Right(hwp_update_date, 2)))

                'Console.WriteLine(comp)

                If Not comp < 15 Then
                    MsgBox("한글 업데이트 확인이 필요합니다")
                End If
            End If
        End If
        '---------------------------3-------------------------------- 한글 업데이트 여부 점검
        'If chk(4) = 0 Then
        'chk(4) = 1
        'MsgBox("암호 재설정이 필요합니다")
        'End If
        '---------------------------4--------------------------------
        If chk(5) = 0 Or chk(4) = 0 Then

            MsgBox("윈도우 패스워드 변경이 필요합니다")
            loding.once = 1
            one_chk.Show()

        End If
        '---------------------------5-------------------------------- 패스워드 재설정
        If chk(6) = 0 Then

            Dim ScreenSaveActive1 As Microsoft.Win32.RegistryKey
            Dim ScreenSaveActive2 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", Nothing) '화면 보호기 활성화 여부

            If ScreenSaveActive2 = 0 Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", 1)
            End If
            Dim ScreenSaverIsSecure = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaverIsSecure", Nothing) ' 화면보호기 재진입시 패스워드 여부
            If ScreenSaverIsSecure = 0 Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaverIsSecure", 1)
            End If
            Dim ScreenSaveTimeOut = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveTimeOut", Nothing) ' 화면 보호기 진입 대기 시간 권장 10분
            Dim ClickLockTime = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ClickLockTime", Nothing) ' 화면 보호기 진입 대기 시간 권장 10분
            'Console.WriteLine(Convert.ToInt32(ScreenSaveTimeOut))
            If (Convert.ToInt32(ScreenSaveTimeOut) > 600) Or (Convert.ToInt32(ClickLockTime) > 600) Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveTimeOut", 600)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "ClickLockTime", 600)
            End If
            ScreenSaveActive1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop\SCRNSAVE.EXE", True)
            'Console.WriteLine(ScreenSaveActive1)
            If (ScreenSaveActive1 Is Nothing) Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\Desktop", "SCRNSAVE.EXE", "C:\Windows\system32\PhotoScreensaver.scr")
            End If
        End If
        '---------------------------6-------------------------------- 화면 보호기설정

        If chk(7) = 0 Then
            Shell("cmd.exe /c net share > C:\123.txt", vbHidden, True)
            Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
            'Console.WriteLine(Lines.Length)
            For Each str In Lines

                Shell("cmd.exe /c net share /delete " & Trim(Microsoft.VisualBasic.Left(str, 10))) ' 다이나믹으로 구현
                Console.WriteLine("cmd.exe /c net share /delete " & Trim(Microsoft.VisualBasic.Left(str, 10))) ' 다이나믹으로 구현
            Next
            My.Computer.FileSystem.DeleteFile("C:\123.txt")
            Shell("cmd.exe /c net share /delete IPC$") ' 다이나믹으로 구현
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters", "AutoShareWks", 0)
        End If
        '---------------------------7-------------------------------- 공유 폴더 제거 및 레지스터 등록
        If chk(8) = 0 Then
            Shell("cmd.exe /c sc stop shellHWDetection")
            Shell("cmd.exe /c sc config shellHWDetection start= disabled")
        End If
        '---------------------------8-------------------------------- 자동 실행 방지
        If chk(9) = 0 Then
            Shell("cmd.exe /c del ""C:\Windows\Downloaded Program Files"" /S /Q")
            Shell("cmd.exe /c rd ""C:\Windows\Downloaded Program Files"" /s /q ")
        End If
        '---------------------------9-------------------------------- 엑티브엑스 삭제
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("last_chk", Format(Now, "yyyy-MM-dd"))
    End Sub ' 나온 취약 함수들의 집합체로 개선하는 함수


End Class
Class AntiVirusProduct
    Dim displayName As String              ' Application name
    Dim instanceGui As String            'Unique identifier
    Dim pathToSignedProductExe As String   'Path to application
    Dim pathToSignedReportingExe As String 'Path to provider
    Dim productState As Integer             'Real-time protection & defintion state
End Class'WMI로 Action Center 값 받아오는 구조체