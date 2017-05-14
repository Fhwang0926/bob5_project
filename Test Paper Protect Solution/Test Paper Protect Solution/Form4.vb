Imports System.Threading
Imports Gma.System
Imports Gma.System.MouseKeyHook



Public Class Form4
    Public Declare Function GetCursorPos Lib "user32.dll" (ByRef lpPoint As POINTAPI) As Long '마우스 후킹
    Private m_GlobalHook As IKeyboardMouseEvents
    Private tmp As Integer
    Public Shadows MouseClick As MouseEventHandler
    Private mode As Integer
    Private tmp_mode As Integer
    Private tmp_mode1 As Integer
    Private x_tmp As Integer
    Private y_tmp As Integer
    Private key_press_tmp As Integer
    '구조체 선언
    Public Structure POINTAPI
        Public x As Integer
        Public y As Integer
    End Structure
    '필요한 변수 및 기본값 지정
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form5.Show() '워터 마크 보이기
        mode = 0 ' 값 초기화
        tmp_mode = 0 ' 값 초기화
        tmp_mode1 = 0 ' 값 초기화
        key_press_tmp = 0 ' 값 초기화
        Location = New Point(0, 0) ' 위치 초기화
        ' 사이즈 초기화
        Me.Size = New System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width(), System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height())
        Me.Opacity = 0.945 ' 투명도 설정
        Me.TopMost = True ' 윈도우 우선순위 top 지정
        Timer1.Enabled = False ' 타이머 초기화 움직임 혹은 버튼 누르면 시작한다
        Timer2.Enabled = True ' timer1의값에 따라 워터마크 표시 여부 지정
        Subscribe() '입력장치 후킹 시작



    End Sub
    '폼 강제종료 방지
    Private Sub Form4_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        Unsubscribe()
    End Sub
    '마우스 클릭 이벤트 감지 tmp_mode = 1
    Private Sub Control1_MouseClick(sender As Object, e As MouseEventArgs) _
     Handles MyBase.MouseClick
        Timer1.Enabled = True '마우스 클릭하면 타이머1 시작
        Me.Opacity = 0 ' 사진 촬영 방지 레이어 숨기기
        tmp_mode = 1 ' 레이어 해제 알리는 변수


    End Sub
    '마우스 스크롤 이벤트 감지 tmp_mode1 = 1
    Public Sub Control1_MouseScroll(sender As Object, e As MouseEventArgs) _
        Handles MyBase.MouseWheel
        Timer1.Enabled = True '마우스 클릭하면 타이머1 시작
        Me.Opacity = 0 ' 사진 촬영 방지 레이어 숨기기
        tmp_mode1 = 1 ' 레이어 해제 알리는 변수

        Return
    End Sub
    '키보드 후킹 시작
    Public Sub Subscribe()
        '어플리케이션을 위한 훅을 변수에 담습니다.
        m_GlobalHook = Hook.GlobalEvents()

        '이벤트를 발생시킬 핸들을 추가합니다.

        AddHandler m_GlobalHook.KeyPress, AddressOf GlobalHookKeyPress
    End Sub
    '키보드 입력시 key_press_tmp = 1 로 설정
    Private Sub GlobalHookKeyPress(sender As Object, e As KeyPressEventArgs)
        If Not String.IsNullOrEmpty(e.KeyChar) Then
            key_press_tmp = 1
        End If

        'Console.WriteLine("KeyPress: " & vbTab & "{0}" & vbTab & "KeyPress: " & vbTab & "{1}", e.KeyChar, key_press_tmp) 'Not String.IsNullOrEmpty(e.KeyChar), key_press_tmp)
    End Sub
    '키보드 후킹 종료
    Public Sub Unsubscribe()
        '이벤트를 발생시키는 핸들을 제거해줍니다.

        RemoveHandler m_GlobalHook.KeyPress, AddressOf GlobalHookKeyPress

        '변수를 버려줍니다.
        m_GlobalHook.Dispose()
    End Sub
    '레이어 폼 안보이게 복구
    Sub show_hidden(init As Integer, time As Long)

        on_off_watermark(False)
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
        Me.Opacity = 0.945


    End Sub

    '마우스 움직임 기록
    Sub Form4_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Me.Text = e.Location.ToString

    End Sub
    'Timer1의 주기는 1초
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If key_press_tmp Then '키 입력 감지
            If Not Timer1.Enabled Then
                Timer1.Enabled = True

            End If
            '키보드 입력이 있는데 타이머가 종료되어 있을 경우 시작
        Else
            If tmp_mode Then '키 입력이 없는데 (마우스 클릭 및 움직일 경우)촬영 방지 레이어 해제일경우 true
                Dim Pnt As POINTAPI 'Pnt를 POINTAPI 구조체로 선언
                Call GetCursorPos(Pnt) 'Pnt에 함수 호출
                SendKeys.Send("^{s}")
                If x_tmp.Equals(Pnt.x) And y_tmp.Equals(Pnt.y) And tmp_mode = 1 Then '촬영방지 레이어 상태에서 위치가 같을 경우

                    'MsgBox("return show_hidden") '디버깅용
                    mode = 0 '같을 경우 변수 초기화
                    Timer1.Enabled = False '타이머 종료 촬영 방지 레이어 숨길거야
                    show_hidden(0, 20) 'layer hidden
                Else '다를경우 저장
                    x_tmp = Pnt.x ' 마우스 x값 대입
                    y_tmp = Pnt.y '마우스 y값 대입
                End If
            Else
                If tmp_mode1 Then '마우스 클릭 및 스크롤 이벤트 감지
                    tmp_mode = 1 ' 촬영 방지 레이어 활성화를 위해 모드 진입
                Else
                    Return '마우스 클릭이 없을 경우 리턴

                End If
                tmp_mode1 = 0 '마우스 클립 감지 해제


            End If
        End If
        key_press_tmp = 0 '키 입력 안한 경우로 리턴, 다시 입력이 있을 경우 이 값은 1로 바뀜


    End Sub
    '워터 마크 프로세스 종료시 해제
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        'If Not (Location.X = 0 And Location.Y = 0) Then
        'Location = New Point(0, 0)
        '
        'Me.Size = New System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width(), System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height())

        'End If
        If Timer1.Enabled Then '타이머가 돌고 있을 경우 즉, 조촬영방지 레이어가 헤제되어 있을 경우
            on_off_watermark(True) ' 워터마크 표시
            Form6.Timer1.Enabled = True
        Else
            on_off_watermark(False)
            Form6.Timer1.Enabled = False
            Form6.Hide()
        End If

    End Sub
    '워터마크 함수
    Private Sub on_off_watermark(on_off As Boolean)
        If on_off Then
            Form5.Show()

        Else
            Form5.Hide()

        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        show_hidden(0, 1)
        Timer3.Enabled = False
    End Sub
End Class