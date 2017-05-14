Imports System
Imports System.IO
Imports System.Collections
Imports HWPCONTROLLib
Imports Microsoft.Win32

Public Class Form1

    Public Shared Function SendMessage(hWnd As IntPtr, uMsg As Int32, WParam As IntPtr, LParam As IntPtr) As Int32
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "폴더 개수"
        Label2.Text = "파일 개수"
        Button1.Text = "Serch"
        Label3.Text = "검색 위치"
        Label4.Text = "확장자"
        Label5.Text = "찾은 개수"
        ListBox1.Items.Clear()

    End Sub


    Dim d As Integer = 0
    Dim f As Integer = 0



    ' Process all files in the directory passed in, recurse on any directories 
    ' that are found, and process the files they contain.
    Public Sub ProcessDirectory(targetDirectory As String, filter As String)
        Try
            Dim fileEntries As String() = Directory.GetFiles(targetDirectory)


            ' Process the list of files found in the directory.
            Dim fileName As String
            For Each fileName In fileEntries
                ProcessFile(fileName, filter)
                f += 1
            Next fileName
            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            ' Recurse into subdirectories of this directory.
            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                d += 1
                ProcessDirectory(subdirectory, filter)
            Next subdirectory
        Catch
            Exit Sub
        End Try
    End Sub 'ProcessDirectory

    ' Insert logic for processing found files here.
    Public Sub ProcessFile(path As String, filter As String)
        ''Console.WriteLine("Processed file '{0}'.", path)
        If filter.Length = 3 Then
            If Microsoft.VisualBasic.Right(path, 3) = filter Then
                'Console.WriteLine(path)
                ListBox1.Items.Add(path)
                Application.DoEvents()
            End If
        Else
            If Microsoft.VisualBasic.Right(path, 4) = filter Then
                'Console.WriteLine(path)
                ListBox1.Items.Add(path)
                Application.DoEvents()
            End If

        End If
        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub 'ProcessFile




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String = TextBox3.Text
        Dim filter As String = TextBox4.Text
        ListBox1.Items.Clear()
        If File.Exists(path) Then
            ' This path is a file.
            ProcessFile(path, filter)
        Else
            If Directory.Exists(path) Then
                ' This path is a directory.
                ProcessDirectory(path, filter)
            Else
                Console.WriteLine("{0} is not a valid file or directory.", path)
            End If
        End If

        'ArrayList("C:\Program Files (x86)\Hnc\HncDic80", "*")
        'TextBox1.Text = count_dir
        'TextBox2.Text = count_file
        TextBox1.Text = d
        TextBox2.Text = f
        TextBox5.Text = ListBox1.Items.Count
        MsgBox("완료!!!!")
    End Sub

    Private Sub find_hwp_btn_Click(sender As Object, e As EventArgs) Handles find_hwp_btn.Click



        'Dim HNCRoot = "HKEY_CURRENT_USER\SOFTWARE\Hnc\HwpUserAction"
        'HwpCtrl1.Clear()



        'Microsoft.Win32.Registry.SetValue(HNCRoot, "FilePathCheckerModuleExample", "C:\Windows\System32\FilePathCheckerModuleExample.dll")




        'On Error Resume Next
        'FilePathCheckerModuleExample.dll<- 보안설정을 해제하는 dll 입니다. 우선 제외합니다.
        '***** 보안 설정 해제 *****

        'HwpCtrl1.RegisterModule("FilePathCheckDLL", "FilePathCheckerModuleExample")
        'HwpCtrl1.RegisterModule("FilePathCheckHandle", 100)
        '***************************
        'HwpCtrl1.ReadOnlyMode = True

        Dim path As String = "C:\8.hwp"
        Timer1.Enabled = True
        HwpCtrl1.Open(path)
        HwpCtrl1.InitScan()

        RichTextBox1.Text = HwpCtrl1.GetTextFile("TEXT", "").ToString






        HwpCtrl1.ReleaseScan()
        HwpCtrl1.InitScan()
        'Do While (Not (GetText() = 1))

        'Loop
        HwpCtrl1.ReleaseScan()






    End Sub
    Private Function GetText()


        Dim a As Integer = 0
        Dim TextSet As HWPCONTROLLib.HwpCtrl
        TextSet = HwpCtrl1.CreateSet("GetText")
        a = HwpCtrl1.GetTextBySet(TextSet)
        Dim txt = TextSet.Item("Text")

        TextBox1.Text += txt
        Return a
    End Function


    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Handle As IntPtr = FindWindow("HNC_DIALOG", "HwpCtrl")
        Console.WriteLine(Handle.ToString)
        If Not (Handle.Equals(IntPtr.Zero)) Then

            ' activate Notepad window
            If (SetActiveWindow(Handle)) Then
                Console.WriteLine(Handle.ToString)
                ' send "Hello World!"

                ' send key "Tab"
                SendKeys.Send("{TAB}")
                ' send key "Enter"
                SendKeys.Send("{ENTER}")
                Timer1.Enabled = False
            End If
        End If

    End Sub
End Class
