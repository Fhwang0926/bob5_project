Imports Microsoft.Win32
Imports System.Management
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports System.Text.RegularExpressions
Module Module1
    Dim tmp1(3) As String
    Dim stats As Integer
    Dim str As String
    Public pro As New Process()
    '1
    Public Sub check_antivirus()
        ' Open handle to to Windows Security Center '
        Dim oWMI As Object = GetObject(
          "winmgmts:{impersonationLevel=impersonate}!\\.\root\SecurityCenter2")

        ' Run Query for all AntiVirusProduct instances '
        Dim colItems As Object = oWMI.ExecQuery("Select * from AntiVirusProduct")

        ' Check if we found any instances '
        If colItems.count = 0 Then
            Console.WriteLine("No antivirus products")
            Exit Sub
        Else
            ' Iterate over each of the instances found and dump useful display data '
            For Each objItem In colItems

                With objItem
                    stats = .productState
                    Str = stats.ToString("X6")

                    tmp1(3) = Microsoft.VisualBasic.Right(Str, 2)
                    tmp1(2) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Str, 4), 2)
                    tmp1(1) = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(Str, 6), 2)

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
                    d = tmp1(1)
                    'If (2 And d) = 2 Then
                    'log.Items.Add("윈도우 업데이트 자동 설치 설정됨...!")
                    'Else
                    ' log.Items.Add("윈도우 업데이트 자동 설치 미설정됨...!")
                    ' test = test + 1
                    ' End If
                    d = tmp1(2)
                    If (10 And d) = 10 Then
                        set_stats("실시간 검사 작동중...!!", 1)

                    Else
                        set_stats("실시간 검사 미작동중...!!", 1)
                        test = test + 1
                    End If
                    d = tmp1(3)
                    If (0 And d) = 0 Then
                        set_stats(.displayName & "이미 최신 버전입니다...!", 1)

                    Else
                        set_stats(.displayName & "업데이트가 필요합니다...!", 1)
                        test = test + 1
                    End If
                    'msgBox("Product name = " & .displayName & vbLf _
                    '  & "Path to product = " & .pathToSignedProductExe & vbLf _
                    ' & "Product state = " & .productState & vbLf _
                    ', vbOKOnly, "Antivirus product")


                    If test = 0 Then
                        Form2.pic1.BackgroundImage = My.Resources.check_yes
                        set_stats("백신 점검 양호", 1)
                    Else
                        Form2.pic1.BackgroundImage = My.Resources.check_no
                        set_stats("백신 점검 취약", 1)
                    End If
                End With
            Next


        End If

    End Sub
    '2 this fast version 
    Dim Thread1 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드1 생성
    Private Sub ThreadFuction1()
        Shell("cmd.exe /c wmic qfe get installedon >> 123.txt", AppWinStyle.Hide, True)
        Console.WriteLine("thread1 완료")
    End Sub

    Public Sub check_window_update1()
        'Shell("cmd.exe /c echo echo off > C:\123.bat", vbHidden, True)
        'Shell("cmd.exe /c echo cls >> C:\123.bat", vbHidden, True)
        'Shell("cmd.exe /c echo wmic qfe get installedon >> C:\123.bat", vbHidden, True)
        '
        '       Dim oStartInfo As New ProcessStartInfo("C:\123.bat")
        '      oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        '     oStartInfo.UseShellExecute = False
        '    oStartInfo.RedirectStandardOutput = True
        '   pro.StartInfo = oStartInfo
        '  pro.Start()
        Thread1.Start()

        'Dim sOutput As String
        'Using oStreamReader As System.IO.StreamReader = pro.StandardOutput
        ' sOutput = oStreamReader.ReadToEnd()
        'End Using
        'Console.WriteLine(sOutput)
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter("c:\123.txt", True)
        'file.WriteLine(sOutput)
        'file.Close()




        Dim Lines() As String = IO.File.ReadAllLines("123.txt")
        Dim find As Integer
        Dim gap As TimeSpan
        'Console.WriteLine(Lines.Length)
        For tmp = 2 To Lines.Length
            If Lines(tmp - 1).ToString <> "" Then
                Console.WriteLine(Lines(tmp - 1))
                'gap = (Convert.ToDateTime(Format(Today, "MM/dd/yyyy")) - Convert.ToDateTime(Lines(tmp - 1)))
            End If

        Next
        Console.WriteLine(gap.TotalDays)
        If gap.TotalDays < 8 Then
            find = 1
        Else
            find = 0
        End If
        If find Then
            set_stats("최근 윈도우 업데이트를 하였습니다", 1)
            Form2.pic2.BackgroundImage = My.Resources.check_yes
        Else
            set_stats("윈도우 업데이트가 필요합니다", 1)
            Form2.pic2.BackgroundImage = My.Resources.check_no
        End If
        'My.Computer.FileSystem.DeleteFile("C:\123.txt")
        'My.Computer.FileSystem.DeleteFile("C:\123.bat")
    End Sub
    '2 thie slow version
    Public Sub check_window_update()


        Dim updateSession = CreateObject("Microsoft.Update.Session")
        updateSession.ClientApplicationID = "MSDN Sample Script"

        Dim updateSearcher = updateSession.CreateUpdateSearcher()


        Console.WriteLine("Searching for updates...")
        Dim searchResult = updateSearcher.Search("IsInstalled=0 and Type='Software' and IsHidden=0")


        If Not searchResult.Updates.Count = 0 Then
            Console.WriteLine("Can downloads applicable updates.")
            Form2.pic2.BackgroundImage = My.Resources.check_no
        Else
            Form2.pic2.BackgroundImage = My.Resources.check_yes

        End If
        'Dim readValue = My.Computer.Registry.GetValue(
        '"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", Nothing)
        ' MsgBox("The value is " & readValue)

        'fin = 1
    End Sub
    '3
    Public Sub scan_hwp()

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

        Console.WriteLine(comp)
        Dim hwp_update_recycle As Integer
        If comp < 15 Then
            set_stats("한글 업데이트 수준 양호", 1)
            hwp_update_recycle = 0
        Else
            set_stats("한글 업데이트 수준 위험", 1)
            hwp_update_recycle = 1
        End If
        If hwp_use And (hwp_update_recycle Or hwp_auto_update) Then
            Form2.pic3.BackgroundImage = My.Resources.check_no
            set_stats("한글 점검 취약", 1)
        Else
            Form2.pic3.BackgroundImage = My.Resources.check_yes
            set_stats("한글 점검 양호", 1)
        End If


    End Sub
    '4
    Public Sub passwd_safe()
        If Form2.once = 1 Then
            set_stats("암호 설정이 안전합니다", 1)
            Form2.pic4.BackgroundImage = My.Resources.check_yes
        Else
            set_stats("암호 설정이 위험합니다", 1)
            Form2.pic4.BackgroundImage = My.Resources.check_no

        End If
    End Sub
    '5
    Public Sub passwd_recycle()
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
        set_stats(tmp.ToString & "의 패스워드 주기 검사", 1)
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
        Console.WriteLine(tmp)
        If CType(tmp, Integer) > 180 Then
            set_stats("패스워드 변경 후 3개월 경과", 1)
            Form2.pic5.BackgroundImage = My.Resources.check_no
        Else
            set_stats("패스워드 변경 후 3개월 미경과", 1)
            Form2.pic5.BackgroundImage = My.Resources.check_yes
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub
    '6
    Public Sub screen_checker()
        Dim tmp(4) As Integer
        Dim ScreenSaveActive1 As Microsoft.Win32.RegistryKey

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
        If Convert.ToInt32(ScreenSaveTimeOut) <= 600 Then
            tmp(2) = 1
            set_stats("화면 대기시간 10분 이내, 양호", 1)
        Else
            tmp(2) = 0
            set_stats("화면 대기시간 10분 이상, 위험", 1)
        End If
        ScreenSaveActive1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\Desktop\SCRNSAVE.EXE", True)
        If ScreenSaveActive1 Is Nothing Then
            tmp(3) = 0
            set_stats("화면 보호기 설정됨", 1)
        Else
            tmp(3) = 1
            set_stats("화면 보호기 설정됨", 1)
        End If
        Console.WriteLine("ScreenSaveActive : " & ScreenSaveActive2.ToString & " / " & "ScreenSaverIsSecure : " & ScreenSaverIsSecure.ToString & " / " & "ScreenSaveTimeOut : " & ScreenSaveTimeOut.ToString)
        If tmp(0) = 1 And tmp(1) And tmp(2) And tmp(3) Then
            set_stats("화면 보호 양호", 1)
            Form2.pic6.BackgroundImage = My.Resources.check_yes
        Else
            set_stats("화면 보호 취약", 1)
            Form2.pic6.BackgroundImage = My.Resources.check_no
        End If
    End Sub
    '7
    Public Sub share_folder_checker()
        Shell("cmd.exe /c net share > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        Console.WriteLine(Lines.Length)
        If Lines.Length <= 6 Then
            Form2.pic7.BackgroundImage = My.Resources.check_yes
            set_stats("공유 폴더 미존재,양호", 1)
        Else
            Form2.pic7.BackgroundImage = My.Resources.check_no
            set_stats("공유 폴더 존재,취약", 1)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub
    '8
    Public Sub dvice_autorun_checker()
        Shell("cmd.exe /c sc query ""ShellHWDetection"" | find ""RUNNING"" > C:\123.txt", vbHidden, True)
        Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        Console.WriteLine(Lines.Length)

        If Lines.Length Then
            Console.WriteLine(Trim(Microsoft.VisualBasic.Right(Lines(0), 8)))
            Form2.pic8.BackgroundImage = My.Resources.check_no
            set_stats("USB 자동 실행 사용, 취약", 1)
        Else
            Form2.pic8.BackgroundImage = My.Resources.check_yes
            set_stats("USB 자동 실행 중지, 양호", 1)
        End If
        My.Computer.FileSystem.DeleteFile("C:\123.txt")
    End Sub
    '9
    Public Sub old_activex()
        Dim dir As New IO.DirectoryInfo("C:\Windows\Downloaded Program Files")
        Dim fname As IO.FileInfo
        Dim ddir As IO.DirectoryInfo
        Dim re_cunt As Integer
        Dim toto As Date = Format(Now, "yyyy-MM-dd")
        Dim comp As Date
        Dim gap As TimeSpan
        For Each ddir In dir.GetDirectories()
            Console.WriteLine(toto)
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
                Console.WriteLine(gap.TotalDays)
                If gap.TotalDays > 90 Then
                    re_cunt = re_cunt + 1
                    set_stats("90일 경과 ActiveX : O", 1)
                Else
                    set_stats("90일 경과 ActiveX : X", 1)
                End If
            End If
        Next
        If re_cunt > 0 Then
            Form2.pic9.BackgroundImage = My.Resources.check_no
            set_stats("90일 경과 ActiveX 존재, 취약", 1)
        Else
            Form2.pic9.BackgroundImage = My.Resources.check_yes
            set_stats("90일 경과 ActiveX 없음, 양호", 1)
        End If
    End Sub
    'set_state
    Public Sub set_stats(str As String, bool As Boolean)
        If bool Then

            Form2.log.Items.Add(str)
            Form2.log.TopIndex = Form2.log.Items.Count - 1
        End If
        Form2.state_label.Text = "보안 점검 중 :" & str
    End Sub
    'choice_show_mode
    Public Sub show_mode(val As Integer)

        If val = 1 Then
            Form2.GroupBox1.Visible = False
            Form2.GroupBox2.Visible = False
            Form2.scan_all_btn.Visible = False
            Form2.scan_part_btn.Visible = False
            Form2.per_btn.FlatAppearance.BorderSize = 1
            Form2.drm_btn.FlatAppearance.BorderSize = 1
            Form2.tool_btn.FlatAppearance.BorderSize = 0
            set_stats("보안 점검 : 준비완료", 0)

            'page replace
            If Form2.tool_timer.Enabled Or Form2.tmp = 1 Then
                Form2.tool_bar.Visible = True
                Form2.tool_loding.Visible = True
                Form2.tool_start_btn1.Visible = True
                Form2.tool_list.Visible = True
                Form2.pic1.Visible = True
                Form2.pic2.Visible = True
                Form2.pic3.Visible = True
                Form2.pic4.Visible = True
                Form2.pic5.Visible = True
                Form2.pic6.Visible = True
                Form2.pic7.Visible = True
                Form2.pic8.Visible = True
                Form2.pic9.Visible = True
                Form2.tool_main_label.Visible = True
            Else
                Form2.tool_main_label.Visible = True
                Form2.tool_start_btn.Visible = True
                Form2.log.Items.Clear()

            End If

        ElseIf val = 2 Then
            Form2.drm_btn.FlatAppearance.BorderSize = 1
            Form2.tool_btn.FlatAppearance.BorderSize = 1
            Form2.per_btn.FlatAppearance.BorderSize = 0
            set_stats("개인정보탐색기 : 준비완료", 0)
            'page replace
            Form2.tool_bar.Visible = False
            Form2.tool_loding.Visible = False
            Form2.tool_main_label.Visible = False
            Form2.tool_start_btn1.Visible = False
            Form2.tool_start_btn.Visible = False
            Form2.tool_list.Visible = False
            Form2.pic1.Visible = False
            Form2.pic2.Visible = False
            Form2.pic3.Visible = False
            Form2.pic4.Visible = False
            Form2.pic5.Visible = False
            Form2.pic6.Visible = False
            Form2.pic7.Visible = False
            Form2.pic8.Visible = False
            Form2.pic9.Visible = False
            Form2.GroupBox1.Visible = True
            Form2.GroupBox2.Visible = True
            Form2.scan_all_btn.Visible = True
            Form2.scan_part_btn.Visible = True
        ElseIf val = 3 Then
            Form2.per_btn.FlatAppearance.BorderSize = 1
            Form2.tool_btn.FlatAppearance.BorderSize = 1
            Form2.drm_btn.FlatAppearance.BorderSize = 0
            set_stats("문서 보안 : 준비완료", 0)
            'page replace
            Form2.tool_bar.Visible = False
            Form2.tool_loding.Visible = False
            Form2.tool_main_label.Visible = False
            Form2.tool_start_btn1.Visible = False
            Form2.tool_start_btn.Visible = False
            Form2.tool_list.Visible = False
            Form2.pic1.Visible = False
            Form2.pic2.Visible = False
            Form2.pic3.Visible = False
            Form2.pic4.Visible = False
            Form2.pic5.Visible = False
            Form2.pic6.Visible = False
            Form2.pic7.Visible = False
            Form2.pic8.Visible = False
            Form2.pic9.Visible = False
            Form2.GroupBox1.Visible = False
            Form2.GroupBox2.Visible = False
            Form2.scan_all_btn.Visible = False
            Form2.scan_part_btn.Visible = False
        End If

        If Not (Form2.once = 1) Then
            Console.WriteLine(1)

            Form3.Show()
            Form2.Hide()
        Else
            Form3.Hide()
        End If


    End Sub

End Module
