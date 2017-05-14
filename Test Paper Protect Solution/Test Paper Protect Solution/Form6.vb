


Public Class Form6
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
    Declare Function GetWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal uCmd As Integer) As IntPtr
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProcDelegate, ByVal hMod As IntPtr, ByVal dwThreadId As Integer) As IntPtr
    Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal hHook As IntPtr) As Boolean
    Declare Function CallNextHookEx Lib "user32" Alias "CallNextHookEx" (ByVal hHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Delegate Function LowLevelKeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    '현재 활성 창의 구조체 정의
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    '키보드 후킹 구조체 정의
    Structure KBDLLHOOKSTRUCT
        Dim vkCode As Integer
        Dim scanCode As Integer
        Dim flags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
    End Structure
    '상수 값 지정 및 변수 선언
    Const WH_KEYBOARD_LL As Integer = 13
    Private hWnd As IntPtr
    Private hHook As Long
    Dim intLLKey As IntPtr

    '처음 히든 상태로 폼 로드
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        TopMost = True

    End Sub
    Private tmp As IntPtr
    Private tmp1 As IntPtr
    Private tmp2 As IntPtr
    Private stRect As RECT
    Private once As Boolean = 1

    '다른이름으로 저장 창이 있는지 검사 있을 경우 타이머 2 실행
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tmp = FindWindow("HNC_DIALOG", "다른 이름으로 저장하기")
        tmp1 = FindWindow("HNC_DIALOG", "문서 암호 설정")
        tmp2 = FindWindow("HNC_DIALOG", "저장 설정")
        If (tmp <> 0) And Not ((tmp1 <> 0) Or (tmp2 <> 0)) Then
            'Console.WriteLine("찾은 핸들 값 : " & tmp.ToString)
            Show()
            GetWindowRect(tmp, stRect)
            Timer2.Enabled = True
            If once Then

                once = 0
            End If
        Else
            UnhookWindowsHookEx(intLLKey)
            notice.Text = "" '알림 문자열 초기화
            'Console.WriteLine("Failed")
            Timer2.Enabled = False
            Hide()
        End If
        'Console.WriteLine(tmp)

    End Sub
    '타이머2로 위치 고정
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Show()
        GetWindowRect(tmp, stRect)

        Location = New Point(stRect.left + 5, stRect.top + 32)
        Opacity = 0.5
        '화면 투명도 값
        notice.Text = "다른이름으로 저장 금지" & vbCrLf & vbCrLf & "암호 설정 및 저장 설정만 가능"
        notice.Location = New Point(Me.Width * 0.25, Me.Height * 0.25) '가운데 위치 조정
        Me.Size = New System.Drawing.Size((stRect.right - stRect.left) - 100, (stRect.bottom - stRect.top) - 125)
        intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf LowLevelKeyboardProc, IntPtr.Zero, 0)
    End Sub
    '키보드 후킹 함수

    Dim asas As Integer = 0
    Private Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        Dim blnEat As Boolean = False

        Select Case wParam
            Case 256, 257, 260, 261
                'Tab, Alt+I, Alt+I, Alt+M, Alt+U    
                blnEat = (lParam.vkCode = 9) Or (lParam.vkCode = 18) Or (lParam.vkCode = 164) ' Or ((lParam.vkCode = 18) And (lParam.vkCode = 73)) Or
                '((lParam.vkCode = 18) And (lParam.vkCode = 77)) Or ((lParam.vkCode = 18) And (lParam.vkCode = 85)) Or (lParam.vkCode = 18)

        End Select
        Try

            If blnEat = True Then '키 탐지
                'Console.WriteLine(blnEat)
                SetActiveWindow(tmp) '윈도우 활성창으로 전환
                SendKeys.Send("{Esc}") '다른이름으로 저장 창 취소 키 누름
                Return UnhookWindowsHookEx(intLLKey)
            Else
                asas = CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
                Return asas
            End If
        Catch
            Return 0
        End Try
    End Function
    '폼 닫을때 해제
    Private Sub Form4_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
        UnhookWindowsHookEx(intLLKey)
    End Sub
    '폼 클릭시 경고창 발생
    Private Sub Form6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        MsgBox("다른 경로에 파일을 저장 할 수 없습니다" & vbCrLf & "암호 설정 및 저장 설정만 변경하여 저장 가능합니다", vbQuestion + vbYes, "알림")
       
    End Sub


End Class

