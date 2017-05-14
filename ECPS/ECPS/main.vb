Imports Microsoft.Win32
Imports System.Management
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports SeedCs
Imports System.Text.RegularExpressions

Public Class main

    Dim pro As Process()
    Public Function chk_state()
        Dim gap As TimeSpan
        Try
            gap = Convert.ToDateTime(Format(Now, "yyyy-MM-dd")) - Convert.ToDateTime(Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_chk", ""))
        Catch
            gap = Nothing
        End Try
        If gap.TotalDays > 30 And Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_chk", "") <> "" Then
            main_state.BackgroundImage = My.Resources.bad_back
            use_p_drm_label.Image = My.Resources.bad_back
            main_tag.Image = My.Resources.bad_back
            main_tag.Text = "보안 수준이 취약 합니다"
            security_tag.Image = My.Resources.bad_back
            security_tag_date.Image = My.Resources.bad_back
            security_tag_date.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_chk", "")
            If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then
                drm_state.BackgroundImage = My.Resources.on_off
            Else
                drm_state.BackgroundImage = My.Resources.off_off

            End If
            person_tag.Image = My.Resources.bad_back
            person_tag_date.Image = My.Resources.bad_back


            log_tag.Image = My.Resources.bad_back
            log_tag_date.Image = My.Resources.bad_back
            Return 0

        Else
            main_state.BackgroundImage = My.Resources.good_back
            main_tag.Image = My.Resources.good_back
            use_p_drm_label.Image = My.Resources.good_back
            main_tag.Text = "보안 수준이 양호 합니다"

            security_tag.Image = My.Resources.good_back
            security_tag_date.Image = My.Resources.good_back
            security_tag_date.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_chk", "")
            If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then
                drm_state.BackgroundImage = My.Resources.on_on
            Else
                drm_state.BackgroundImage = My.Resources.off_on

            End If



            person_tag.Image = My.Resources.good_back
            person_tag_date.Image = My.Resources.good_back

            log_tag.Image = My.Resources.good_back
            log_tag_date.Image = My.Resources.good_back
            Return 1
        End If

    End Function

    Public Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.22, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.22)
        config.Show()
        config.Hide()
        If config.set_drm.Checked Then
            drm_timer.Enabled = True
        End If
        chk_state()
        person_tag_date.Text = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("last_search", "개인정보 파일 검색이 필요합니다")

    End Sub


    Public mode = 0
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub
    Dim PROC As Integer
    Public Sub chk_pro_drm(tmp As Boolean)
        If tmp Then
            Try

                Console.WriteLine("개인정보파일 보호 시작")
                PROC = Shell(Application.StartupPath & "\ECPS_DRM_Protecter.exe")

            Catch ex As Exception
                Console.WriteLine("개인정보파일 보호 시작 오류")
            End Try
        Else
            Try
                Console.WriteLine("개인정보파일 보호 중지")
                Dim GP As System.Diagnostics.Process
                GP = System.Diagnostics.Process.GetProcessById(PROC)
                GP.Kill()
                GP = Nothing

            Catch ex As Exception
                Console.WriteLine("개인정보파일 보호 중지 오류")
            End Try

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles drm_state.Click
        If chk_state() Then
            If Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then
                drm_state.BackgroundImage = My.Resources.off_on
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 0)
                chk_pro_drm(0)
                drm_timer.Enabled = False
                config.set_drm.Checked = False

                config.set_exit.Enabled = False


            Else
                drm_state.BackgroundImage = My.Resources.on_on
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 1)
                chk_pro_drm(1)
                drm_timer.Enabled = True
                config.set_drm.Checked = True

                config.set_exit.Enabled = True

            End If
        Else
            If Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("use_drm", 0) Then
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 0)
                chk_pro_drm(0)
                drm_state.BackgroundImage = My.Resources.off_off
                drm_timer.Enabled = False
                config.set_drm.Checked = False

                config.set_exit.Enabled = False

            Else
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("use_drm", 1)
                chk_pro_drm(1)
                drm_state.BackgroundImage = My.Resources.on_off
                drm_timer.Enabled = True
                config.set_drm.Checked = True

                config.set_exit.Enabled = True


            End If


        End If
    End Sub

    Private Sub setting_btn_Click(sender As Object, e As EventArgs) Handles setting_btn.MouseHover
        setting_btn.BackgroundImage = Nothing
        setting_btn.Text = "설정"

    End Sub
    Private Sub setting_btn_lost(sender As Object, e As EventArgs) Handles setting_btn.MouseLeave
        setting_btn.BackgroundImage = My.Resources.setting
        setting_btn.Text = ""

    End Sub

    Private Sub setting_btn_Click_1(sender As Object, e As EventArgs) Handles setting_btn.Click
        config.Show()
    End Sub

    Private Sub security_chk_btn_focus(sender As Object, e As EventArgs) Handles security_chk_btn.MouseHover
        security_chk_btn.BackgroundImage = Nothing
        security_chk_btn.Text = "보안 점검"
    End Sub
    Private Sub security_chk_lost(sender As Object, e As EventArgs) Handles security_chk_btn.MouseLeave

        security_chk_btn.BackgroundImage = My.Resources.security_check
        security_chk_btn.Text = ""

    End Sub

    Private Sub all_btn_focus(sender As Object, e As EventArgs) Handles all_btn.MouseHover
        all_btn.BackgroundImage = Nothing
        all_btn.Text = "전체 검색"

    End Sub
    Private Sub all_btn_lost(sender As Object, e As EventArgs) Handles all_btn.MouseLeave
        all_btn.BackgroundImage = My.Resources.search
        all_btn.Text = ""
    End Sub

    Private Sub quick_btn_focus(sender As Object, e As EventArgs) Handles quick_btn.MouseHover
        quick_btn.BackgroundImage = Nothing
        quick_btn.Text = "빠른 검색"
    End Sub
    Private Sub quick_btn_lost(sender As Object, e As EventArgs) Handles quick_btn.MouseLeave
        quick_btn.BackgroundImage = My.Resources.quick_search
        quick_btn.Text = ""
    End Sub

    Private Sub security_chk_btn_Click(sender As Object, e As EventArgs) Handles security_chk_btn.Click
        Fix.Show()
    End Sub

    Private Sub all_btn_Click(sender As Object, e As EventArgs) Handles all_btn.Click

        mode = 1
        search.Show()
    End Sub

    Private Sub quick_btn_Click(sender As Object, e As EventArgs) Handles quick_btn.Click
        search.Show()
    End Sub


    'tray_show_hidden
    Private Sub showMe()
        Me.Show()   '.Visible = True
        Me.ShowInTaskbar = True  '현재 프로그램을 테스크 바에 표시하게 한다.    
        Me.WindowState = FormWindowState.Normal  ' 폼을 윈도 상태를 normal
        NotifyIcon1.Visible = False '트레이의 아이콘을 보이지 않게 한다. 
    End Sub

    Private Sub hideMe()
        Me.Hide()                   '폼을 보이지 않게 한다. alt+tab 시 보이지 않는다.
        NotifyIcon1.Visible = True   '트레이의 아이콘을 보이게 한다.
        Me.NotifyIcon1.Text = "교육기관 보안 솔루션"
    End Sub

    Private Sub makePopupMenu()
        Me.ctxmenu.Items.Clear()
        Me.ctxmenu.Items.Add("열기")
        Me.ctxmenu.Items.Add("종료")
        Me.ctxmenu.Show(Cursor.Position)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        hideMe()

    End Sub
    Private Sub close_btn_click(ByVal sender As Object, ByVal e As EventArgs) Handles close_btn.Click

        hideMe()

    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick

        makePopupMenu()

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        showMe()
    End Sub


    Private Sub CtxMenu_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ctxmenu.ItemClicked

        Select Case e.ClickedItem.ToString()

            Case "열기"
                showMe()

            Case "종료"
                Dim com As New SEED()
                Try
                    If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("chk_exit", 0) = 1 Then
                        If (Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("pw", 0) = com.Enc(InputBox("암호를 입력하세요", "관리자 종료 확인"), GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID").ToString)) Then
                            Console.WriteLine("프로그램을 종료합니다")
                            End
                        Else
                            MsgBox("종료할 수 없습니다 관리자 패스워드를 입력하세요")
                        End If
                    Else
                        End
                    End If


                Catch
                    MsgBox("프로그램을 종료 할 수 없습니다" & vbCrLf & "관리자에게 문의하세요")
                End Try

        End Select

    End Sub


End Class
