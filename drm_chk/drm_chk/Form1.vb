Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Timer1.Enabled = True
    End Sub
    Private Sub drm_chk()
        Dim watcher As New System.IO.FileSystemWatcher
        Console.WriteLine("doing____")
        Application.DoEvents()
        '감시하는 디렉토리를 지정

        watcher.Path = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Recent"

        '*.txt파일을 감시, 모두 감시할 때는""으로 한다.

        watcher.Filter = ""

        '파일명과 디렉토리명으로 최종적으로 쓴날짜의 변경을 감시
        watcher.NotifyFilter = System.IO.NotifyFilters.FileName Or
            System.IO.NotifyFilters.DirectoryName Or
            System.IO.NotifyFilters.LastWrite

        '서브디렉토리는 감시하지않는다.
        watcher.IncludeSubdirectories = True

        '필요에따라서 버퍼의 사이즈를 변경한다.

        watcher.InternalBufferSize = 4096

        Application.DoEvents()
        Application.DoEvents()
        '동기적인 감시를 실시한다.
        Dim changedResult As System.IO.WaitForChangedResult =
            watcher.WaitForChanged(System.IO.WatcherChangeTypes.All)

        If changedResult.TimedOut Then
            Console.WriteLine("타임아웃 되었습니다.")
            Return
        End If
        Application.DoEvents()

        Application.DoEvents()
        '변경이 있었을때 결과를 표시한다.
        Dim name_tmp As String = ""
        Select Case changedResult.ChangeType
            Case System.IO.WatcherChangeTypes.Changed
                Console.WriteLine(("파일 [" +
                    changedResult.Name + "] 가 변경되었습니다."))
                name_tmp = changedResult.Name.ToString
                'en_de(watcher.Path, changedResult.Name)
            Case System.IO.WatcherChangeTypes.Created
                Console.WriteLine(("파일 [" +
                    changedResult.Name + "] 가 생성되었습니다."))
                name_tmp = changedResult.Name.ToString
                'en_de(watcher.Path, changedResult.Name)



        End Select
        Dim shell = CreateObject("WScript.Shell")
        If Microsoft.VisualBasic.Right(name_tmp, 4).Equals(".lnk") Then
            Console.WriteLine(shell.CreateShortcut(watcher.Path & name_tmp).TargetPath)
        End If

    End Sub
    Private Sub en_de(path_tmp As String, name As String)
        Try
            Dim shell = CreateObject("WScript.Shell")
            Dim path = shell.CreateShortcut(path_tmp & name).TargetPath
            Console.WriteLine(path)
        Catch
            Console.WriteLine("error")
        End Try


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        drm_chk()
        Application.DoEvents()
    End Sub
End Class
