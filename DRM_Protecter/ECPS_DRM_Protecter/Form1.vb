Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Threading
Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Public Class Form1



    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Private Sub Run()
        Timer1.Enabled = False
        Console.WriteLine("monitorring start / C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Recent")

        '모니터링 객체 생성
        Dim watcher As New FileSystemWatcher()
        '모니터링 디렉토리 설정

        watcher.Path = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Recent"
        ' 모니터링할 필터 설정
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        ' Only watch text files.
        watcher.Filter = "*.*"
        '확장자 필터 설정
        ' Add event handlers.
        'AddHandler watcher.Changed, AddressOf OnChanged ' 파일 변화만 탐지
        AddHandler watcher.Created, AddressOf OnChanged ' 파일 생성만 탐지
        'AddHandler watcher.Deleted, AddressOf OnChanged ' 파일 삭제만 탐지


        ' Begin watching.
        watcher.EnableRaisingEvents = True

        Console.WriteLine("문서보안 시작 " & Format(Now, "yyyy-MM-dd"))
    End Sub

    ' Define the event handlers.
    Shared cmd = CreateObject("WScript.Shell")

    Private Sub OnChanged(source As Object, e As FileSystemEventArgs)

        proc_main(e)

    End Sub
    Private Sub proc_main(e As FileSystemEventArgs)

        Try
            Dim ren_tmp = cmd.CreateShortcut(e.FullPath).TargetPath
            Select Case Microsoft.VisualBasic.Right(ren_tmp, 4)
                Case ".hwp"
                    show_info("한글")
                    Console.WriteLine("한글 탐지")

                Case "docx"
                    show_info("Word")
                    Console.WriteLine("Word 탐지")

                Case ".docx"
                    show_info("Word")
                    Console.WriteLine("Word 탐지")
                Case ".ppt" '구현 준비중
                    show_info("PPT")
                    Console.WriteLine("PPT 탐지")
                Case ".pptx" '구현 준비중
                    show_info("PPT")
                    Console.WriteLine("PPT 탐지")
                Case ".xls"
                    show_info("Excel")
                    Console.WriteLine("Excel 탐지")

                Case "xlsx"
                    show_info("Excel")
                    Console.WriteLine("Excel 탐지")

                Case ".txt"
                    show_info("Txt")
                    Console.WriteLine("Txt 탐지")

            End Select
            Console.WriteLine(ren_tmp)
        Catch
            Console.WriteLine("링크 에러 : 문서파일이 아닙니다")
        End Try

    End Sub

    '윈도우 창 후킹을 위한 라이브러리 추가
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Hide()
        Run()
    End Sub ' 자동 시작 타이머

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub ' 폼 로드시 타이머 시작
    Private Sub show_info(str As String)
        NotifyIcon1.BalloonTipText = str & " 문서가 생성되었습니다"
        NotifyIcon1.BalloonTipTitle = "문서 생성 탐지"
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.ShowBalloonTip(1000)
    End Sub
End Class
