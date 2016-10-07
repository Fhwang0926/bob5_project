Imports System.Threading
Imports Gma.System
Imports Gma.System.MouseKeyHook

Public Class Form1
    public Declare Function GetCursorPos Lib "user32.dll" (
    ByRef lpPoint As POINTAPI) As Long
    Private m_GlobalHook As IKeyboardMouseEvents

    Private tmp As Integer
    Public Event MouseClick As MouseEventHandler
    Private mode As Integer
    Private tmp_mode As Integer
    Private tmp_mode1 As Integer
    Private x_tmp As Integer
    Private y_tmp As Integer
    Private key_press_tmp As Integer

    Public Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure


    'MessageBox.Show(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() & vbCrLf & System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height())


    'Location = New Point(100, 100)
    'Size = New System.Drawing.Size(300, 200)

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Opacity = Me.Opacity - 0.1
        Label1.Text = Me.Opacity
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Opacity = Me.Opacity + 0.1
        Label1.Text = Me.Opacity
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Opacity = Me.Opacity + 0.01
        Label1.Text = Me.Opacity
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Opacity = Me.Opacity - 0.01
        Label1.Text = Me.Opacity
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width(), System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height())
        Label1.BackColor = Color.White
        mode = 0
        Me.TopMost = True
        Timer1.Enabled = False
        tmp_mode = 0
        Me.TopMost = True
        tmp_mode1 = 0
        Subscribe()
        key_press_tmp = 0
        Location = New Point(0, 0)

    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Unsubscribe()
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If tmp Then
            Me.TopMost = True
            tmp = 0
        Else
            Me.TopMost = False
            tmp = 1
        End If
    End Sub
    Private Sub Control1_MouseClick(sender As Object, e As MouseEventArgs) _
     Handles MyBase.MouseClick
        Timer1.Enabled = True '타이머 시작
        Me.Opacity = 0.0 'layer hidden
        tmp_mode = 1


    End Sub
    Public Sub Control1_MouseScroll(sender As Object, e As MouseEventArgs) _
        Handles MyBase.MouseWheel

        Me.Opacity = 0
        Timer1.Enabled = True
        tmp_mode = 0

        tmp_mode1 = 1

        Return
    End Sub
    Public Sub Subscribe()
        '어플리케이션을 위한 훅을 변수에 담습니다.
        m_GlobalHook = Hook.GlobalEvents()

        '이벤트를 발생시킬 핸들을 추가합니다.

        AddHandler m_GlobalHook.KeyPress, AddressOf GlobalHookKeyPress
    End Sub

    Private Sub GlobalHookKeyPress(sender As Object, e As KeyPressEventArgs)

        key_press_tmp = 1
        Console.WriteLine("KeyPress: " & vbTab & "{0}" & "KeyPress: " & vbTab & "{1}", e.KeyChar, key_press_tmp)
    End Sub

    Public Sub Unsubscribe()
        '이벤트를 발생시키는 핸들을 제거해줍니다.

        RemoveHandler m_GlobalHook.KeyPress, AddressOf GlobalHookKeyPress

        '변수를 버려줍니다.
        m_GlobalHook.Dispose()
    End Sub

    Sub show_hidden(init As Integer, time As Long)
        If init Then
            Me.Opacity = 0
        End If

        Thread.Sleep(time)
        Me.Opacity = 0.53
        Thread.Sleep(time)
        Me.Opacity = 0.63
        Thread.Sleep(time)
        Me.Opacity = 0.73
        Thread.Sleep(time)
        Me.Opacity = 0.83
        Thread.Sleep(time)
        Me.Opacity = 0.93
    End Sub


    Sub Form1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Me.Text = e.Location.ToString
        'Dim Pnt As POINTAPI 'Pnt를 POINTAPI 구조체로 선언
        't_tmp = Pnt.x & ", " & Pnt.y
        'Thread.Sleep(1000)

        't_tmp1 = Pnt.x & ", " & Pnt.y

        'MsgBox(t_tmp & vbCrLf & t_tmp1 & vbCrLf & e.Location.ToString & vbCrLf & mode)
        'If t_tmp.Equals(t_tmp1) Then
        'mode = 0
        'show_hidden(0, 100)
        ''MsgBox(t_tmp & vbCrLf & t_tmp1 & vbCrLf & e.Location.ToString & vbCrLf & mode)
        'End If

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick

        If key_press_tmp Then
            If Timer1.Enabled Then
                'Return
            Else
                Timer1.Enabled = True
            End If
        Else
            If tmp_mode Then
                Dim Pnt As POINTAPI 'Pnt를 POINTAPI 구조체로 선언
                Call GetCursorPos(Pnt) 'Pnt에 함수 호출
                Label3.Text = (x_tmp & "=" & Pnt.x & vbCrLf & y_tmp & "=" & Pnt.y)
                If x_tmp.Equals(Pnt.x) And y_tmp.Equals(Pnt.y) And tmp_mode = 1 Then

                    'MsgBox("return show_hidden") '디버깅용
                    mode = 0
                    Timer1.Enabled = False '타이머 종료
                    show_hidden(0, 20) 'layer hidden
                Else
                    x_tmp = Pnt.x ' 마우스 x값 대입
                    y_tmp = Pnt.y '마우스 y값 대입
                End If
            Else
                If tmp_mode1 Then
                    tmp_mode = 1
                Else
                    Return

                End If
                tmp_mode1 = 0


            End If
        End If
        key_press_tmp = 0


    End Sub
End Class
