Public Class Form1
    Private pro As New Process()
    Const KEYEVENTF_EXTENDEDKEY = &H1
    Const KEYEVENTF_KEYUP = &H2
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
    (ByVal Hwnd As IntPtr, ByVal wMsg As Integer,
     ByVal wParam As Integer, ByVal lParam As String) As Integer ' Integer 을 String 문자를 보내기 위함

    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
        (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Public Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" _
        (ByVal hWndParent As Integer, ByVal hWndChildAfter As Integer,
         ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Public Const WM_SETTEXT = &HC 'SendMessage에서 문자열을 보내기위한
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'pro.StartInfo.FileName = "cmd.exe"
        'pro.StartInfo.Arguments = "tset.bat"
        'pro.StartInfo.WindowStyle = AppWinStyle.MaximizedFocus
        'pro.Start()
        'Dim ProcID As Integer
        ' Start the Calculator application, and store the process id.

        ' Activate the Calculator application.

        'Shell("cmd.exe /c reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion"" /s | find ""AUOptions""> C:\123.txt", vbNormalFocus, True)
        'Dim Lines() As String = IO.File.ReadAllLines("C:\123.txt")
        'Console.WriteLine(Lines.Length)
        Dim process As New Process()
        process.StartInfo.FileName = "powershell "
        process.StartInfo.Verb = "runas"
        process.StartInfo.UseShellExecute = False



        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.WindowStyle = vbNormalFocus

        process.Start()
        process.StandardInput.WriteLine("reg query ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update""")
        process.StandardInput.WriteLine("exit")
        Dim input As String = process.StandardOutput.ReadToEnd
        process.Close()
        Console.WriteLine(input)


    End Sub
End Class
