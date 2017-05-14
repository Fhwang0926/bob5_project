Module Module1

    Sub Main()
        Dim watcher As New System.IO.FileSystemWatcher
        Console.WriteLine("doing____")

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

        'watcher.InternalBufferSize = 4096



        '동기적인 감시를 실시한다.
        Dim changedResult As System.IO.WaitForChangedResult =
            watcher.WaitForChanged(System.IO.WatcherChangeTypes.All)

        If changedResult.TimedOut Then
            Console.WriteLine("타임아웃 되었습니다.")
            Return
        End If



        '변경이 있었을때 결과를 표시한다.
        Select Case changedResult.ChangeType
            Case System.IO.WatcherChangeTypes.Changed
                Console.WriteLine(("파일 [" +
                    changedResult.Name + "] 가 변경되었습니다."))
            Case System.IO.WatcherChangeTypes.Created
                Console.WriteLine(("파일 [" +
                    changedResult.Name + "] 가 작성되었습니다."))
                'Case System.IO.WatcherChangeTypes.Deleted
                '   Console.WriteLine(("파일 [" +
                '  changedResult.Name + "] 가 삭제되었습니다."))
            Case System.IO.WatcherChangeTypes.Renamed

                Console.WriteLine(("파일 [" +
                changedResult.OldName + "] 의 이름이 [" +
                changedResult.Name + "] 로 변경되었습니다."))
        End Select
    End Sub

End Module
