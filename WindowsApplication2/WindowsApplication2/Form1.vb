Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Security.Permissions

Public Class Form1

    Public Shared Sub Main()



    End Sub

    <PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
    Private Shared Sub Run()

        Console.WriteLine("mon start")

        ' Create a new FileSystemWatcher and set its properties.
        Dim watcher As New FileSystemWatcher()
        watcher.Path = "C:\Users\Fhwang\AppData\Roaming\Microsoft\Windows\Recent"
        ' Watch for changes in LastAccess and LastWrite times, and
        ' the renaming of files or directories. 
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        ' Only watch text files.
        watcher.Filter = "*.*"

        ' Add event handlers.
        'AddHandler watcher.Changed, AddressOf OnChanged
        AddHandler watcher.Created, AddressOf OnChanged
        AddHandler watcher.Deleted, AddressOf OnChanged
        AddHandler watcher.Renamed, AddressOf OnRenamed

        ' Begin watching.
        watcher.EnableRaisingEvents = True

        ' Wait for the user to quit the program.
        Console.WriteLine("Press 'q' to quit the sample.")

        Console.WriteLine("mon end")
    End Sub

    ' Define the event handlers.
    Shared cmd = CreateObject("WScript.Shell")

    Private Shared Sub OnChanged(source As Object, e As FileSystemEventArgs)
        ' Specify what is done when a file is changed, created, or deleted.
        Try
            Console.WriteLine("File: " & cmd.CreateShortcut(e.FullPath).TargetPath & " " & e.ChangeType)
        Catch
            Console.WriteLine("링크 에러")
        End Try
        'change type 
    End Sub

    Private Shared Sub OnRenamed(source As Object, e As RenamedEventArgs)
        ' Specify what is done when a file is renamed.
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text <> "모니터링 시작" Then
            Button1.Text = "모니터링 시작"
        Else
            Button1.Text = "모니터링 중지"
            Run()
        End If
    End Sub
End Class