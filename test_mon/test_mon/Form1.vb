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

Public Class Form1



    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Private Sub Run()

        Console.WriteLine("monitorring start / C:\Users\Fhwang\AppData\Roaming\Microsoft\Windows\Recent")

        ' Create a new FileSystemWatcher and set its properties.
        Dim watcher As New FileSystemWatcher()
        watcher.Path = "C:\Users\Fhwang\AppData\Roaming\Microsoft\Windows\Recent"
        ' Watch for changes in LastAccess and LastWrite times, and
        ' the renaming of files or directories. 
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        ' Only watch text files.
        watcher.Filter = "*.*"

        ' Add event handlers.
        AddHandler watcher.Changed, AddressOf OnChanged
        AddHandler watcher.Created, AddressOf OnChanged ' 파일 생성만 탐지
        AddHandler watcher.Deleted, AddressOf OnChanged ' 파일 삭제만 탐진


        ' Begin watching.
        watcher.EnableRaisingEvents = True

        Console.WriteLine("개인정보파일 보호 시작 " & Format(Now, "yyyy-MM-dd"))
    End Sub

    ' Define the event handlers.
    Shared cmd = CreateObject("WScript.Shell")

    Private Sub OnChanged(source As Object, e As FileSystemEventArgs)
        ' Specify what is done when a file is changed, created, or deleted.
        Try
            Console.WriteLine("File: " & cmd.CreateShortcut(e.FullPath).TargetPath & " / " & e.ChangeType)
            Console.WriteLine(Microsoft.VisualBasic.Right(cmd.CreateShortcut(e.FullPath).TargetPath, 4))

        Catch
            Console.WriteLine("링크 에러")
        End Try
        'change type 
    End Sub





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Run()
        Button1.Enabled = False
    End Sub
End Class
