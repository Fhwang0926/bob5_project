Imports System.IO
Imports Microsoft.Win32
Imports System.Management
Imports System.Text

Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports System.Text.RegularExpressions
Public Class Form1
    Dim scan_dir(10) As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '    Dim dir As New IO.DirectoryInfo("C:\")
        '   Dim fname As IO.DirectoryInfo
        '  Dim index As Integer = 0
        Timer1.Enabled = True
        Thread1.Start()


    End Sub

    Dim a As Integer
    Dim Thread1 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드1 생성 
    Dim str(8) As String
    Dim path As String = "C:\"
    Private Sub ThreadFuction1()

        If CheckBox1.Checked Then
            str(0) = "*.txt"
            Shell("cmd.exe /c dir " & path & str(0) & " /on /b /s >C:\txt.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(0) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox2.Checked Then
            str(1) = "*.hwp"
            Shell("cmd.exe /c dir " & path & str(1) & " /on /b /s >C:\hwp.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(1) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox3.Checked Then
            str(2) = "*.doc"

            Shell("cmd.exe /c dir " & path & str(2) & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(2) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox4.Checked Then
            str(3) = "*.docx"
            Shell("cmd.exe /c dir " & path & str(3) & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(3) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox5.Checked Then
            str(4) = "*.xls"
            Shell("cmd.exe /c dir " & path & str(4) & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(4) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox6.Checked Then
            str(5) = "*.xlxs"
            Shell("cmd.exe /c dir " & path & str(5) & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(5) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox7.Checked Then
            str(6) = "*.ppt"
            Shell("cmd.exe /c dir " & path & str(6) & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(6) & " /on /b /s >>C:\txt.txt")
        End If
        If CheckBox8.Checked Then
            str(7) = "*.pptx"
            Shell("cmd.exe /c dir " & path & str(7) & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
            Console.WriteLine("dir " & str(7) & " /on /b /s >>C:\txt.txt")
        End If

        a = 1
        MsgBox("완료")

    End Sub
    Public Sub scanfile(str As String)
        Dim dir As New IO.DirectoryInfo("C:\")
        Dim fname As IO.FileInfo

        For Each fname In dir.GetFiles()
            If fname.Extension.ToString.Contains(str) Then
                ListBox1.Items.Add("C:\" & fname.ToString)
            End If
        Next

        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub 'ProcessFile
    Dim time As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.Text = time
        time += 1
        If a = 1 Then
            Timer1.Enabled = False
        End If
    End Sub
End Class
