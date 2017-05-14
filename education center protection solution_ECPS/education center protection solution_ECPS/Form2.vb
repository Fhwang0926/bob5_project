Imports Microsoft.Win32
Imports System.Management
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports System.Text.RegularExpressions



Public Class Form2

    Public tmp As Integer = 0
    Public once As String
    Public check_pass As Integer = 0


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.28, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.3)
        'ddefualt setting
        drm_btn.FlatAppearance.BorderSize = 1
        per_btn.FlatAppearance.BorderSize = 1
        tool_btn.FlatAppearance.BorderSize = 0
        'tool_setting
        tool_start_btn1.Visible = False
        tool_bar.Visible = False
        tool_loding.Visible = False
        tool_main_label.Visible = True
        tool_start_btn.Visible = True
        tool_list.Visible = False
        pic1.Visible = False
        pic2.Visible = False
        pic3.Visible = False
        pic4.Visible = False
        pic5.Visible = False
        pic6.Visible = False
        pic7.Visible = False
        pic8.Visible = False
        pic9.Visible = False
        'scan_setting
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        scan_all_btn.Visible = False
        scan_part_btn.Visible = False


        log.Items.Clear()
        NotifyIcon1.Visible = False
        once = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("once")
        Console.WriteLine(once)
    End Sub
    'main_page
    Private Sub tool_btn_Click(sender As Object, e As EventArgs) Handles tool_btn.Click
        show_mode(1)

    End Sub

    Private Sub per_btn_Click(sender As Object, e As EventArgs) Handles per_btn.Click
        show_mode(2)

    End Sub

    Private Sub drm_btn_Click(sender As Object, e As EventArgs) Handles drm_btn.Click
        show_mode(3)

    End Sub
    'tool
    'tool_bar
    Private Sub tool_bar_timer_Tick(sender As Object, e As EventArgs) Handles tool_bar_timer.Tick
        Try
            If (tool_bar.Value = 900) Then
                tool_bar_timer.Enabled = False
            End If
            tool_bar.Value = tool_bar.Value + 1
        Catch
            Console.WriteLine(tool_bar.Value)
        End Try
    End Sub
    'tool_pro
    Dim bit As Integer = 1
    Private Sub tool_show(in_tmp2 As Integer, in_tmp3 As Boolean)
        tool_bar_timer.Enabled = in_tmp3
        If tool_loding.Enabled Then
            For val As Integer = 1 To in_tmp2

                If tool_bar.Value = 950 Then
                    If tool_bar_timer.Enabled Then
                        tool_bar_timer.Enabled = False
                    End If
                    bit = 0.1
                    If tool_bar.Value = 1000 Then
                        MsgBox("점검을 완료하였습니다")
                    End If
                Else

                    tool_bar.Value = tool_bar.Value + bit
                End If
            Next
        End If


    End Sub
    'tool_lodding
    Dim loding_tmp As Integer = 0
    Private Sub tool_timer_Tick(sender As Object, e As EventArgs) Handles tool_timer.Tick
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

    End Sub
    'tool_button
    Private Sub tool_start_btn_hover(sender As Object, e As EventArgs) Handles tool_start_btn.MouseHover
        tool_start_btn.Image = My.Resources.start_btn_press

    End Sub
    Private Sub tool_start_btn_leave(sender As Object, e As EventArgs) Handles tool_start_btn.MouseLeave
        tool_start_btn.Image = My.Resources.start_btn
    End Sub
    Private Sub tool_start_btn1_hover(sender As Object, e As EventArgs) Handles tool_start_btn1.MouseHover
        If tmp = 0 Then

            tool_start_btn1.Image = My.Resources.stop_btn_press
        Else
            tool_start_btn1.Image = My.Resources.restart_btn_press

        End If


    End Sub
    Private Sub tool_start_btn1_leave(sender As Object, e As EventArgs) Handles tool_start_btn1.MouseLeave
        If tmp = 0 Then

            tool_start_btn1.Image = My.Resources.stop_btn
        Else
            tool_start_btn1.Image = My.Resources.restart_btn

        End If

    End Sub

    'tool_start, tool_stop
    Private Sub tool_start_btn_Click(sender As Object, e As EventArgs) Handles tool_start_btn.Click

        If Not (once = 1) Then
            'Console.WriteLine(1)

            Form3.Show()
            Me.Hide()
        Else
            Form3.Hide()
            tool_timer.Enabled = True
            tool_start_btn.Visible = False
            show_mode(1)

            tool_bar_timer.Enabled = True
            tool_back()
        End If

    End Sub
    Private Sub tool_start_btn1_Click(sender As Object, e As EventArgs) Handles tool_start_btn1.Click
        If tmp = 0 Then
            set_stats("보안 점검 : 일시정지", 1)
            tmp = 1
            tool_timer.Enabled = False
            tool_bar_timer.Enabled = False
            tool_start_btn1.Image = My.Resources.restart_btn
        Else
            set_stats("보안 점검 : 점검중", 1)
            tool_bar_timer.Enabled = True
            tool_timer.Enabled = True
            tmp = 0
            tool_start_btn1.Image = My.Resources.stop_btn
        End If

    End Sub

    'scan_button
    Private Sub scan_all_btn_hover(sender As Object, e As EventArgs) Handles scan_all_btn.MouseHover
        scan_all_btn.BackgroundImage = My.Resources.scan_all_btn_press

    End Sub
    Private Sub scan_all_btn_leave(sender As Object, e As EventArgs) Handles scan_all_btn.MouseLeave
        scan_all_btn.BackgroundImage = My.Resources.scan_all_btn
    End Sub
    Private Sub scan_part_btn_hover(sender As Object, e As EventArgs) Handles scan_part_btn.MouseHover
        scan_part_btn.BackgroundImage = My.Resources.scan_part_btn_press


    End Sub
    Private Sub scan_part_btn1_leave(sender As Object, e As EventArgs) Handles scan_part_btn.MouseLeave
        scan_part_btn.BackgroundImage = My.Resources.scan_part_btn

    End Sub

    Private Sub close_form(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        hideMe()
        'End
    End Sub


    'strip_menu
    Private Sub 점검도구ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 점검도구ToolStripMenuItem.Click
        show_mode(1)
    End Sub
    Private Sub 개인정보파일탐색기ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 개인정보파일탐색기ToolStripMenuItem.Click
        show_mode(2)
    End Sub
    Private Sub 문서보안ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 문서보안ToolStripMenuItem.Click
        show_mode(3)
    End Sub
    Private Sub 종료EToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 종료EToolStripMenuItem.Click
        End
    End Sub




    'tool_do_it
    Private Sub tool_back()

        '1
        check_antivirus()
        tool_show(50, 0)
        '2
        check_window_update1()
        tool_show(100, 0)
        '3
        scan_hwp()
        tool_show(100, 1)
        '4
        passwd_safe()
        tool_show(200, 0)
        '5
        passwd_recycle()
        tool_show(200, 0)
        '6
        screen_checker()
        tool_show(200, 0)
        '7
        share_folder_checker()
        tool_show(10, 0)
        '8
        dvice_autorun_checker()
        tool_show(10, 0)
        '9
        old_activex()
        tool_show(100, 0)


    End Sub

    'tray_show_hidden
    Private Sub makePopupMenu()
        Me.CtxMenu.Items.Clear()
        Me.CtxMenu.Items.Add("열기")
        Me.CtxMenu.Items.Add("종료")
        Me.CtxMenu.Show(Cursor.Position)
    End Sub
    Public Sub hideMe()
        Me.Hide()                   '폼을 보이지 않게 한다. alt+tab 시 보이지 않는다.
        Me.NotifyIcon1.Visible = True   '트레이의 아이콘을 보이게 한다.
        Me.NotifyIcon1.Text = "Tray-Application is Running!"
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        showMe()
    End Sub
    Private Sub CtxMenu_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxMenu.ItemClicked

        Select Case e.ClickedItem.ToString()

            Case "열기"
                showMe()

            Case "종료"
                End

        End Select

    End Sub
    Private Sub NotifyIcon1_MouseClick(sender As Form2.ControlAccessibleObject, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        makePopupMenu()
    End Sub
    Private Sub showMe()
        Me.Show()   '.Visible = True
        Me.ShowInTaskbar = True  '현재 프로그램을 테스크 바에 표시하게 한다.    
        Me.WindowState = FormWindowState.Normal  ' 폼을 윈도 상태를 normal
        Me.NotifyIcon1.Visible = False '트레이의 아이콘을 보이지 않게 한다. 
    End Sub

    'scan_persen_info
    '
    Public mode As Integer = 0
    Private Sub scan_all_btn_Click(sender As Object, e As EventArgs) Handles scan_all_btn.Click

        mode = 1
        Form4.Show()

    End Sub

    Private Sub scan_part_btn_Click(sender As Object, e As EventArgs) Handles scan_part_btn.Click
        mode = 0
        Form4.Show()
    End Sub
End Class
Class AntiVirusProduct
    Dim displayName As String              ' Application name
    Dim instanceGui As String            'Unique identifier
    Dim pathToSignedProductExe As String   'Path to application
    Dim pathToSignedReportingExe As String 'Path to provider
    Dim productState As Integer             'Real-time protection & defintion state
End Class