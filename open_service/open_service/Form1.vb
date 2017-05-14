Imports Microsoft.Win32
Public Class Form1
    Private pro As New Process()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell("cmd.exe /c reg add ""HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update"" /v AUOptions /t REG_DWORD /d 4 /f", vbHidden, True)

        'Shell("cmd.exe /c echo echo off> C:\123.bat", vbHidden, True)
        'Shell("cmd.exe /c echo cls>> C:\123.bat", vbHidden, True)
        Shell("cmd.exe /c echo reg add ""HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update"" /v AUOptions /t REG_DWORD /d 1 /f>> C:\123.bat", vbHidden, True)
        '
        Dim oStartInfo As New ProcessStartInfo("C:\123.bat")
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        pro.StartInfo = oStartInfo
        pro.Start()
        'Thread1.Start()
        'Thread1.Join()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = pro.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using
        'Console.WriteLine(sOutput)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("c:\123.txt", True)
        file.WriteLine(sOutput)
        file.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("cmd.exe /c C:\Windows\System32\wscui.cpl", AppWinStyle.Hide, True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Shell("cmd.exe /c C:\123.bat", AppWinStyle.NormalFocus, True)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Shell("cmd.exe /c reg add ""HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsU
pdate\ Auto Update"" /v AUOptions /t REG_DWORD /d 1 /f", AppWinStyle.NormalFocus, True)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe "
        process.StartInfo.Verb = "runas"
        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.CreateNoWindow = True

        process.Start()
        process.StandardInput.WriteLine("reg add ""HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update"" /v AUOptions /t REG_DWORD /d 4 /f")
        process.StandardInput.WriteLine("exit")
        Dim input As String = process.StandardOutput.ReadToEnd
        process.Close()
        Console.WriteLine(input)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Shell("cmd.exe /c wuapp.exe startmenu", vbHidden, True)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click


        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey _
                   ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", False)

        Dim SubKeyNames() As String = Key.GetSubKeyNames()


        Dim cnt As Integer = 0

        Dim Index As Integer

        Dim SubKey As RegistryKey

        For Index = 0 To Key.SubKeyCount - 1

            SubKey = Registry.LocalMachine.OpenSubKey _
                       ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" + "\" _
                          + SubKeyNames(Index), False)

            If Not SubKey.GetValue("InstallLocation", "") Is "" Then
                'Console.WriteLine(SubKey.GetValue("InstallLocation", ""))
                If Not (InStr(1, CType(SubKey.GetValue("InstallLocation", ""), String), "Hnc", 1) Or (InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한컴", 1)) And InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "InstallLocation", 1)) = 0 Then
                    Dim InputString As String = CType(SubKey.GetValue("InstallLocation", ""), String)
                    Console.WriteLine(CType(SubKey.GetValue("InstallLocation", ""), String))

                    Exit For
                Else


                End If


            End If
        Next
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters", "AutoShareWks", 0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Shell("cmd.exe /c C:\Windows\System32\control.exe /name Microsoft.WindowsUpdate", AppWinStyle.Hide, True)

    End Sub
End Class
