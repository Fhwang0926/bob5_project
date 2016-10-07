
Imports System.IO
Imports System.IO.StreamReader
Public Class Form1
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer
    Declare Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
    Declare Function GetWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal uCmd As Integer) As IntPtr
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProcDelegate, ByVal hMod As IntPtr, ByVal dwThreadId As Integer) As IntPtr
    Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal hHook As IntPtr) As Boolean
    Declare Function CallNextHookEx Lib "user32" Alias "CallNextHookEx" (ByVal hHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Delegate Function LowLevelKeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Const WH_KEYBOARD_LL As Integer = 13
    Private hWnd As IntPtr
    Private hHook As Long
    Dim intLLKey As IntPtr
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
        Label1.Text = Format(Now, "yyyy:MM:dd-hh:mm")
        Dim Executable As String = "open_check.exe"
        Dim CommandLine As String = "1 1 0"
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("open_check.exe")
        MsgBox("File was last modified on " & infoReader.LastWriteTime)
        Dim MyStartInfo As New Diagnostics.ProcessStartInfo(Executable, CommandLine)
        MyStartInfo.UseShellExecute = False                                  ' CMD.EXE 등을 사용하지 않음, 직접실행
        MyStartInfo.RedirectStandardOutput = True                     ' 프로그램 출력(STDOUT)을 Redirect 함
        MyStartInfo.CreateNoWindow = True                               ' 프로그램 실행 윈도우즈를 만들지 않음

        Dim MyProcess As New Diagnostics.Process
        MyProcess.StartInfo = MyStartInfo
        MyProcess.Start()                                                             ' 프로세스를 실행함
        Dim STDOUT As New StreamReader(MyProcess.StandardOutput.BaseStream)
        While Not (MyProcess.HasExited)

            Dim dummy As String = STDOUT.ReadLine                             ' 프로세스의 출력된 값에서, 라인 한개를 읽습니다

            '
            If dummy = 0 Then
                MsgBox("test")
                Dim cdrive As System.IO.DriveInfo
                cdrive = My.Computer.FileSystem.GetDriveInfo("C:\")
                MsgBox(cdrive.DriveType.ToString)

                End
            End If
            '

            My.Application.DoEvents()                                                             ' 다른 프로세스에 영향을 주지 않도록...
        End While
    End Sub
    '키보드 후킹 함수
    Private Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        Dim blnEat As Boolean = False

        Select Case wParam
            Case 256, 257, 260, 261
                'Tab, Alt+I, Alt+I, Alt+M, Alt+U
                Console.WriteLine("누른 키 : " & lParam.vkCode)
                blnEat = (lParam.vkCode = 9) Or (lParam.vkCode = 18) Or (lParam.vkCode = 164) ' Or ((lParam.vkCode = 18) And (lParam.vkCode = 73)) Or
                '((lParam.vkCode = 18) And (lParam.vkCode = 77)) Or ((lParam.vkCode = 18) And (lParam.vkCode = 85)) Or (lParam.vkCode = 18)

        End Select

        If blnEat = True Then
            Console.WriteLine(blnEat & " : " & lParam.vkCode)

            Return UnhookWindowsHookEx(intLLKey)
        Else
            Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
        Console.WriteLine("활성화")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Console.WriteLine("비활성화")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf LowLevelKeyboardProc, IntPtr.Zero, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SendKeys.Send("{Enter}")
    End Sub
End Class
