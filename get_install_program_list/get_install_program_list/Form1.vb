Imports System.Management
Imports Microsoft.Win32.RegistryKey
Imports Microsoft.Win32
Public Class Form1
    Dim path As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim sh = CreateObject("wscript.shell")
        'Dim oExec = sh.exec("wmic product")
        'Console.WriteLine("Product")
        'Dim line As String
        'Do While Not oExec.stdout.atendofstream
        'line = oExec.stdout.readline
        ' line = Trim(Mid(line, InStr(line, "  ") + 1, Len(line)))
        ' line = Trim(Microsoft.VisualBasic.Left(line, InStr(line, "  ")))
        'Console.WriteLine(line)
        'Loop
        ListBox1.Items.Clear()


        'Dim objWMIService = GetObject("winmgmts:" &
        '"{impersonationLevel=impersonate}!\\" &'
        '"." &
        '"\root\cimv2")
        '
        ' Dim colSoftware = objWMIService.ExecQuery _
        '    ("SELECT * FROM Win32_Product")



        'colSoftware = colSoftware.Get
        'For Each mo In colSoftware
        '    ListBox1.Items.Add(mo("Name").ToString)
        ' Next
        '-------------------
        'ListBox1.Items.Clear()
        'Dim unInstallkey = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Uninstall")
        'Dim temp = vbNull
        'Dim path = String.Empty
        'Dim displayName = String.Empty
        'Dim subkeyLists() = unInstallkey.GetSubKeyNames()
        'Dim subkey As String = String.Empty
        'For Each subkey In subkeyLists

        '        path = "Software\Microsoft\Windows\CurrentVersion\Uninstall\" + subkey
        '        Dim tm = My.Computer.Registry.LocalMachine.OpenSubKey(path)
        '        If Not (temp = vbNull) Then
        '
        '        displayName = tm.GetValue("DisplayName")
        '        End If
        '        If Not (displayName = vbNull) Then
        '        ListBox1.Items.Add(displayName)
        '        End If

        '        Next


        '---------------------------------------------------
        ' Open the Uninstall registry subkey.
        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey _
           ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", False)
        ' Retrieve a list of installed software products.
        ' This list also includes some software products that are not valid.
        Dim SubKeyNames() As String = Key.GetSubKeyNames()

        Dim strarray() As String = Nothing
        Dim cnt As Integer = 0

        ' Declare a variable to iterate through the retrieved list of 
        ' installed software products.
        Dim Index As Integer
        ' Declare a variable to hold the registry subkey that correspond
        ' to each retrieved software product.
        Dim SubKey As RegistryKey
        Console.WriteLine("The following software products are installed on this computer:")
        Console.WriteLine("")
        ' Iterate through the retrieved software products.
        For Index = 0 To Key.SubKeyCount - 1
            ' Open the registry subkey that corresponds to the current software product.
            ' SubKeyNames(Index) contains the name of the node that corresponds to the 
            ' current software product.
            SubKey = Registry.LocalMachine.OpenSubKey _
               ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" + "\" _
                  + SubKeyNames(Index), False)
            ' Verify that the DisplayName exists. If the DisplayName does not exist, 
            ' return a null string. If the returned value is a null string, the 
            ' DisplayName does not exist, and the software product is not valid.
            If Not SubKey.GetValue("DisplayName", "") Is "" Then
                ' The current software product is valid.
                ' Display the DisplayName of this valid software product.
                Console.WriteLine(CType(SubKey.GetValue("DisplayName", ""), String))
                ListBox1.Items.Add(CType(SubKey.GetValue("DisplayName", ""), String))
                If Not (InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한글", 1) Or InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한컴", 1)) = 0 Then
                    MsgBox(CType(SubKey.GetValue("InstallLocation", ""), String))
                    path = CType(SubKey.GetValue("InstallLocation", ""), String)
                End If


            End If
        Next

        Console.WriteLine("Press ENTER to quit.")
        Console.ReadLine()

    End Sub
    Public Function FindFiles(ByVal start_dir As String, ByVal file_pattern As String, ByVal bottomtree_find As Boolean) As String
        Dim dirs() As String = Nothing
        Dim num_dirs As Long = -1
        Dim sub_dir As String
        Dim file_name As String
        Dim i As Integer
        Dim txt As String = Nothing
        Application.DoEvents()
        '현재 폴더의 파일들 검색
        file_name = Dir$(start_dir & file_pattern, vbNormal)
        Do While Len(file_name) > 0
            txt = txt & start_dir & file_name
            file_name = Dir(file_name, vbNormal)
        Loop

        '하위 폴더도 찾는다면
        If bottomtree_find Then
            '하위 폴더 찾기를 위해 폴더 목록 검색
            sub_dir = Dir(start_dir & "*", vbDirectory)
            Do While Len(sub_dir) > 0
                If UCase(sub_dir) <> "PAGEFILE.SYS" And sub_dir <> "." And sub_dir <> ".." Then
                    sub_dir = start_dir & sub_dir
                    If GetAttr(sub_dir) And vbDirectory Then
                        num_dirs = num_dirs + 1
                        ReDim Preserve dirs(0 To num_dirs)
                        dirs(num_dirs) = sub_dir & "\"
                        ListBox1.Items.Add("Sub : " & sub_dir & "\")

                    End If
                End If

                sub_dir = Dir(sub_dir, vbDirectory)
            Loop

            '각각의 폴더에 대해 파일 찾기/재귀 호출
            For i = 1 To num_dirs
                txt = txt & FindFiles(dirs(i), file_pattern, bottomtree_find)
            Next i

        End If
        '최종 결과 반환
        ListBox1.Items.Add(txt)
    End Function
    Dim a As String

    Public Function lsGetDirectory(lsPath As String, lsLeve As Long, view As Integer)
        'view 1 -> 폴더보기
        'view 2 -> 파일보기
        'view 3 -> 폴더&파일보기
        On Error GoTo ERR_RTN
        Dim MyFile, MyPath, MyName
        Dim lsCnt As Long
        Dim PreName As String
        '디렉토리 위치를 표현 하기 위해서 카운트(루터로부터의 위치)
        lsCnt = lsLeve + 1
        MyName = Dir(lsPath, vbDirectory)  ' 첫번째 항목을 검색합니다.
        Do While MyName <> ""   ' 루프(loop)를 시작합니다.
            ' 현재 디렉토리와 포함하는 디렉토리를 무시합니다.
            If MyName <> "." And MyName <> ".." Then
                ' MyName이 디렉토리인지 확인하기 위해서 비트별(bitwise) 비교를 사용합니다.


                If (GetAttr(lsPath & MyName) And vbDirectory) Then
                    If view = 1 Or view = 3 Then
                        a = a & Space(lsCnt * 3) & lsPath & MyName & "\" & vbCrLf ' 항목만 표시합니다
                        '디렉토리를 찾았다면 재귀호출 합니다.(하위도 계속 찾아야 겠죠)
                    End If
                    Call lsGetDirectory(lsPath & MyName & "\", lsCnt, view)
                    '디렉토리 위치를 초기화 하기 위해 사용합니다.(속도 계선이 좀 필요 하겠네요)
                    PreName = Dir(lsPath, vbDirectory)
                    Do Until PreName = MyName
                        PreName = Dir()
                    Loop
                    Application.DoEvents()

                Else
                    If view = 2 Or view = 3 Then
                        a = a & Space(lsCnt * 3) & lsPath & MyName & vbCrLf
                    End If
                End If




            End If
            MyName = Dir()   ' 다음 항목을 읽어들입니다.

        Loop
        ListBox1.Items.Add(a)
ERR_RTN:

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        'FindFiles(path, "*", 1)
        lsGetDirectory(path, 1, 3)
    End Sub

End Class
