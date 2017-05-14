Imports System.Security.Cryptography
Imports Microsoft.Win32.RegistryKey
Imports SeedCs
Imports System.Globalization

Imports System.Text
Imports Microsoft.Win32
Imports System.Text.RegularExpressions

Public Class config

    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.22, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.22)
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("addr", 0) Then
            set_addr.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("bank", 0) Then
            set_bank.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("call", 0) Then
            set_call.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("card", 0) Then
            set_card.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("chk_exit", 0) And Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then

            set_exit.Checked = True

        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("email", 0) Then
            set_email.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("hwp", 0) Then
            set_hwp.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("ip", 0) Then
            set_ip.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("person", 0) Then
            set_person.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("ppt", 0) Then
            set_ppt.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("txt", 0) Then
            set_txt.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("word", 0) Then
            set_word.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("xls", 0) Then
            set_xls.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_mark", 0) Then
            set_mark.Checked = True
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then

            set_drm.Checked = True
            main.chk_pro_drm(1)
            set_exit.Enabled = True
        Else
            main.chk_pro_drm(0)
            set_exit.Enabled = False


        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("send_mail", "") <> "" Then
            If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("send_mail_chk", 0) = 1 Then
                set_mail_chk.Checked = True
                set_mail_input.Enabled = True
                set_mail_input.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("send_mail", "")
            Else
                set_mail_input.Text = "메일을 입력해주세요"
            End If

        Else
            set_mail_input.Text = "메일을 입력해주세요"
        End If
        Try
            If Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run").GetValue("ECPS", "") = "" Then
                set_startup.Checked = False
            Else
                set_startup.Checked = True
            End If
        Catch
            set_startup.Checked = False
        End Try
    End Sub '로딩하면서 설정
    '동작 함수들
    Private Sub set_mail_input_TextChanged1(sender As Object, e As EventArgs) Handles set_mail_input.GotFocus
        If set_mail_input.Text.ToString = "메일을 입력해주세요" Then
            set_mail_input.Text = ""
        End If

    End Sub '이메일 없을 시 초기화
    Private Sub set_mail_input_TextChanged2(sender As Object, e As EventArgs) Handles set_mail_input.LostFocus
        If set_mail_input.Text.ToString <> "" Or set_mail_input.Text.ToString <> "메일을 입력해주세요" Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", set_mail_input.Text)
        End If

    End Sub '기본값에서 변경이 있을 경우

    ' ========== 보안 점검
    Private Sub set_mail_CheckedChanged(sender As Object, e As EventArgs) Handles set_mail_chk.Click
        If set_mail_chk.Checked Then
            set_mail_input.Enabled = True
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail_chk", 1)
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", set_mail_input.Text)
            MsgBox("메일을 입력하세요", vbOKOnly, "ECPS 설정")
            set_mail_input.Text = ""
            set_mail_input.Focus()
        Else
            set_mail_input.Enabled = False
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail_chk", 0)
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", "")
        End If
    End Sub ' 보안 점검 결과 메일 수신 여부


    ' ========== 프로그램 설정
    Private Sub set_exit_CheckedChanged(sender As Object, e As EventArgs) Handles set_exit.CheckedChanged
        If set_exit.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("chk_exit", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("chk_exit", 0)

        End If
    End Sub ' 종료시 암호 물어보는 여부
    Private Sub set_startup_CheckedChanged(sender As Object, e As EventArgs) Handles set_startup.Click
        If set_startup.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("startup", 1)
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run").SetValue("ECPS", Application.ExecutablePath.ToString)
            'Console.WriteLine(Application.ExecutablePath.ToString)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("startup", 0)
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run").SetValue("ECPS", 0)

        End If
    End Sub '시작 프로그램 등록 여부

    '==================== 개인정보 탐색기
    ' 검사 파일 레지스트리 등록
    Private Sub chk_hwp_CheckedChanged(sender As Object, e As EventArgs) Handles set_hwp.CheckedChanged
        If set_hwp.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("hwp", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("hwp", 0)

        End If
    End Sub '한글 검사 여부

    Private Sub chk_exc_CheckedChanged(sender As Object, e As EventArgs) Handles set_xls.CheckedChanged
        If set_xls.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("xls", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("xls", 0)

        End If
    End Sub '엑셀 검사 여부

    Private Sub chk_txt_CheckedChanged(sender As Object, e As EventArgs) Handles set_txt.CheckedChanged
        If set_txt.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("txt", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("txt", 0)

        End If
    End Sub '텍스트 검사 여부

    Private Sub chk_word_CheckedChanged(sender As Object, e As EventArgs) Handles set_word.CheckedChanged
        If set_word.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("word", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("word", 0)

        End If
    End Sub '워드 검사 여부

    Private Sub chk_ppt_CheckedChanged(sender As Object, e As EventArgs) Handles set_ppt.CheckedChanged
        If set_ppt.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ppt", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ppt", 0)

        End If
    End Sub ' 피피티 검사 여부
    '패턴 매칭 레지스트리 등록
    Private Sub chk1_per_number_CheckedChanged(sender As Object, e As EventArgs) Handles set_person.CheckedChanged
        If set_person.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("person", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("person", 0)

        End If
    End Sub ' 주민번호 매칭 여부

    Private Sub chk1_phone_CheckedChanged(sender As Object, e As EventArgs) Handles set_call.CheckedChanged
        If set_call.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("call", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("call", 0)

        End If
    End Sub ' 전화번호 매칭 여부

    Private Sub set_email_CheckedChanged(sender As Object, e As EventArgs) Handles set_email.CheckedChanged
        If set_email.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("email", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("email", 0)

        End If
    End Sub ' 이메일 매칭 여부

    Private Sub chk1_ip_CheckedChanged(sender As Object, e As EventArgs) Handles set_ip.CheckedChanged
        If set_ip.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ip", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ip", 0)

        End If
    End Sub ' ip 매칭 여부

    Private Sub chk1_bank_CheckedChanged(sender As Object, e As EventArgs) Handles set_bank.CheckedChanged
        If set_bank.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("bank", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("bank", 0)

        End If
    End Sub '계좌번호 매칭 유무

    Private Sub chk1_card_CheckedChanged(sender As Object, e As EventArgs) Handles set_card.CheckedChanged
        If set_card.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("card", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("card", 0)

        End If
    End Sub '카드 매칭 유무

    Private Sub chk1_addr_CheckedChanged(sender As Object, e As EventArgs) Handles set_addr.CheckedChanged
        If set_addr.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("addr", 1)
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("addr", 0)

        End If
    End Sub ' 주소 매칭 유무


    '================== 문서보안
    Private Sub set_mark_CheckedChanged(sender As Object, e As EventArgs) Handles set_mark.CheckedChanged
        If set_mark.Checked Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_mark", 1) '워터 마크 사용 레지스트리 등록
            water_mark.timer_mark.Enabled = True

            water_mark.Show()
        Else
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_mark", 0) ' 워터 마크 사용 레지스트리 해제
            water_mark.timer_mark.Enabled = False
            water_mark.Hide()
        End If
    End Sub '워터마크 사용 여부
    Private Sub set_drm_CheckedChanged(sender As Object, e As EventArgs) Handles set_drm.Click
        If main.chk_state() Then
            If set_drm.Checked Then
                main.drm_state.BackgroundImage = My.Resources.on_on
                main.drm_timer.Enabled = True
                'main.chk_pro_drm(1)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 1)

                set_exit.Enabled = True




            Else

                main.drm_state.BackgroundImage = My.Resources.off_on
                main.drm_timer.Enabled = False

                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 0)
                'main.chk_pro_drm(0)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("pw", "")
                set_exit.Enabled = False

            End If
        Else
            If set_drm.Checked Then
                main.drm_state.BackgroundImage = My.Resources.on_off
                main.drm_timer.Enabled = True

                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 1)
                'main.chk_pro_drm(1)
                set_exit.Enabled = True


            Else

                main.drm_state.BackgroundImage = My.Resources.off_off
                main.drm_timer.Enabled = False
                'main.chk_pro_drm(0)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 0)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("pw", "")
                set_exit.Enabled = False

            End If
        End If

    End Sub ' DRM 사용 여부

    Public Sub save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
        If set_drm.Checked Then
            main.chk_pro_drm(1)
        Else
            main.chk_pro_drm(0)
        End If
        If set_mail_input.Visible And (set_mail_input.Text <> "" Or set_mail_input.Text <> "메일을 입력해주세요") Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", set_mail_input.Text)
        Else
            MsgBox("메일 주소를 입력해주세요", vbOKOnly, "ECPS 설정")
            set_mail_input.Focus()
        End If


        Me.Hide()
    End Sub ' 저장 버튼 클릭
    Private Sub config_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        If set_mail_input.Visible And (set_mail_input.Text <> "" Or set_mail_input.Text <> "메일을 입력해주세요") Then
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", set_mail_input.Text)
            Me.Hide()
        Else
            MsgBox("메일 주소를 입력해주세요", vbOKOnly, "ECPS 설정")

            set_mail_input.Focus()
        End If


    End Sub

    Private Sub reset_config_btn_Click(sender As Object, e As EventArgs) Handles reset_config_btn.Click
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("addr", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("bank", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("call", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("card", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("chk_exit", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("email", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("hwp", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ip", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("person", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("ppt", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("txt", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("word", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("xls", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_mark", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("pw", "")
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail_chk", 0)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("send_mail", "")
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("Run").SetValue("ECPS", "")
        If water_mark.timer_mark.Enabled Then
            water_mark.timer_mark.Enabled = False
        End If


        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        config_Load(e, e) 'Load everything in your form load event again
    End Sub

    Private Sub set_mail_input_TextChanged(sender As Object, e As EventArgs) Handles set_mail_input.LostFocus
        If set_mail_input.Text = "" Then
            MsgBox("메일 주소를 입력하세요")
            set_mail_input.Focus()
        Else
            Dim regexPattern As String
            Dim regex As Regex
            Dim regexMatches As MatchCollection
            Dim strSource As String
            strSource = set_mail_input.Text
            regexPattern = "(\S+)@([^\.\s]+)(?:\.([^\.\s]+))+" '이메일 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If Not regexMatches.Count > 0 Then
                MsgBox("이메일 주소를 올바르게 입력했는지 확인 바랍니다")
                set_mail_input.Text = ""
                set_mail_input.Focus()


            End If
        End If

    End Sub
End Class

