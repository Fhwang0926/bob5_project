Imports System
Imports System.IO
Imports System.Collections

Imports Microsoft.Win32
Public Class Form4
    Dim f As Integer = 0


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        timer_start.Enabled = True
    End Sub
    'scanning options

    Public Sub ProcessDirectory(targetDirectory As String)
        Try
            Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
            ' Process the list of files found in the directory.
            Dim fileName As String
            For Each fileName In fileEntries
                ProcessFile(fileName)
                f += 1
            Next fileName
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory.
            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries

                ProcessDirectory(subdirectory)
            Next subdirectory
        Catch
            Exit Sub
        End Try
    End Sub 'ProcessDirectory

    ' Insert logic for processing found files here.
    Public Sub ProcessFile(path As String)
        ''Console.WriteLine("Processed file '{0}'.", path)

        Dim tmp As String = Microsoft.VisualBasic.Right(path, 4)

        Console.WriteLine(path & ":" & tmp)
        Application.DoEvents()
        Select Case tmp.ToString()

            Case "xlxs"
                scan_list_all.Items.Add(path)

            Case "docx"
                scan_list_all.Items.Add(path)

            Case "pptx"
                scan_list_all.Items.Add(path)
            Case ".hwp"
                scan_list_all.Items.Add(path)
            Case ".xls"
                scan_list_all.Items.Add(path)

            Case ".doc"
                scan_list_all.Items.Add(path)

            Case ".ppt"
                scan_list_all.Items.Add(path)

            Case ".txt"
                scan_list_all.Items.Add(path)

        End Select


        scan_list_all.TopIndex = scan_list_all.Items.Count - 1
    End Sub 'ProcessFile

    Private Sub search_start(input_path As String)
        timer_start.Enabled = False

        scan_list_all.Items.Clear()
        If File.Exists(input_path) Then
            ' This path is a file.
            ProcessFile(input_path)
        Else
            If Directory.Exists(input_path) Then
                ' This path is a directory.
                ProcessDirectory(input_path)
            Else
                MsgBox("검색된 자료가 없습니다", "알림")
                Console.WriteLine("{0} is not a valid file or directory.", input_path)
            End If
        End If


        count_label.Text = f
    End Sub
    Private Sub search_start_cmd(input_path As String)

        timer_start.Enabled = False

        scan_list_all.Items.Clear()



        count_label.Text = f
    End Sub


    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer

    Private Sub timer_start_Tick(sender As Object, e As EventArgs) Handles timer_start.Tick
        Console.WriteLine(Environment.UserName.ToString)
        If Form2.mode = 1 Then
            timer_count.Enabled = True
            search_start("C:\")

        Else
            search_start("C:\Users\Fhwang\Documents")
            search_start("C:\Users\Fhwang\Downloads")
            search_start("C:\Users\Fhwang\Desktop")

        End If



    End Sub
    Sub ThreadFuction1() '스레드1 함수
        Application.DoEvents()

    End Sub
    Sub ThreadFuction2() '스레드2 함수
        Application.DoEvents()

    End Sub

    Dim Thread1 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드1 생성 
    Dim Thread2 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드2  생성
    Dim Thread3 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드3 생성 
    Dim Thread4 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드4  생성
    Dim Thread5 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드5 생성 
    Dim Thread6 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드6  생성
    Dim Thread7 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드7 생성 
    Dim Thread8 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드8  생성
    Dim Thread9 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드9  생성

    Private Sub timer_count_Tick(sender As Object, e As EventArgs) Handles timer_count.Tick

    End Sub
End Class