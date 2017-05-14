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
        AddHandler watcher.Changed, AddressOf OnChanged ' 파일 변화만 탐지
        'AddHandler watcher.Created, AddressOf OnChanged ' 파일 생성만 탐지
        'AddHandler watcher.Deleted, AddressOf OnChanged ' 파일 삭제만 탐지


        ' Begin watching.
        watcher.EnableRaisingEvents = True

        Console.WriteLine("개인정보파일 보호 시작 " & Format(Now, "yyyy-MM-dd"))
    End Sub

    ' Define the event handlers.
    Shared cmd = CreateObject("WScript.Shell")

    Private Sub OnChanged(source As Object, e As FileSystemEventArgs)
        '파일 수정하는 것도 반영해야 한다

        '파일 생성후 프로세스 종료를 위해 10초간 대기
        Threading.Thread.Sleep(10000)
        proc_main(e)

    End Sub
    Private Sub proc_main(e As FileSystemEventArgs)
        '파일명 공백 처리

        'Try
        'Dim ll() As String = IO.File.ReadAllLines("tmp_list.txt")
        'For Each path In ll
        'Try
        ' Shell("cmd.exe /c drm_changer """ & cmd.CreateShortcut(e.FullPath).TargetPath & """")
        ' Console.WriteLine("cmd.exe drm_changer """ & cmd.CreateShortcut(e.FullPath).TargetPath & """")
        ' Application.DoEvents()
        ' Catch ex As Exception
        ' Console.WriteLine("메모장 읽기 실패/" & ex.Message)
        ' End Try
        ' Next

        '        Catch er As Exception
        '        Console.WriteLine(er.Message)
        '        End Try
        Try
            Dim ren_tmp = cmd.CreateShortcut(e.FullPath).TargetPath
            Select Case Microsoft.VisualBasic.Right(ren_tmp, 4)
                Case ".hwp"
                    Console.WriteLine("한글 탐지")
                    read_hwp(ren_tmp)
                Case "docx"
                    Console.WriteLine("워드 탐지")
                    read_word(ren_tmp)
                Case ".docx"
                    Console.WriteLine("워드 탐지")
                    read_word(ren_tmp)
                Case ".ppt"'구현 준비중
                Case ".pptx"'구현 준비중
                Case ".xls"
                    Console.WriteLine("엑셀 탐지")
                    read_execl(ren_tmp)
                Case "xlsx"
                    Console.WriteLine("엑셀 탐지")
                    read_execl(ren_tmp)
                Case ".txt"
                    Console.WriteLine("텍스트 탐지")
                    read_txt(ren_tmp)
            End Select

        Catch
            Console.WriteLine("링크 에러 : 문서파일이 아닙니다")
        End Try
        'tmp_list.txt 파일에 다른 프로세스가 사용중이여서 파일 암호화 하지 못한 파일 목록들이 존재
    End Sub

    '윈도우 창 후킹을 위한 라이브러리 추가
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer


    '텍스트 읽기
    Private Sub read_txt(ren_tmp As String)
        Try
            Application.DoEvents()
            If chk_pattern(My.Computer.FileSystem.ReadAllText(ren_tmp)) Then
                Console.WriteLine("텍스트에서 개인정보 탐지 : " & ren_tmp)
                Shell("cmd.exe /c drm_changer """ & ren_tmp & """", vbHidden, True)
                If IO.File.Exists(ren_tmp & ".ecps") Then
                    Console.WriteLine("cmd.exe /c drm_changer """ & ren_tmp & """")
                    Console.WriteLine("텍스트 파일 암호화 완료 : " & ren_tmp & ".ecps")
                End If
                Application.DoEvents()
            End If
        Catch ex As Exception
            Console.WriteLine("텍스트 읽기 에러 : " & ex.Message)
            Shell("cmd.exe /c echo " & ren_tmp & ">> tmp_list.txt", vbHidden, True)
        End Try
    End Sub

    '한글 읽기
    Private Sub read_hwp(ren_tmp As String)
        '한글 보안 모듈 해제 부분
        Application.DoEvents()
        Const HNCRoot As String = "HKEY_Current_User\Software\HNC\HwpCtrl\Modules"
        HwpCtrl1.Clear()
        Dim myProjectPath As String = Path.GetFullPath(".\")
        If Microsoft.Win32.Registry.GetValue(HNCRoot, "FilePathCheckerModule", "Not Exist").Equals("Not Exist") Then
            Microsoft.Win32.Registry.SetValue(HNCRoot, "FilePathCheckerModule", Application.StartupPath + "FilePathCheckerModule.dll")
        End If
        HwpCtrl1.RegisterModule("FilePathCheckDLL", "FilePathCheckerModule")
        Try
            HwpCtrl1.Open(ren_tmp)
            HwpCtrl1.InitScan()


            'Console.WriteLine(HwpCtrl1.GetTextFile("TEXT", "").ToString)
            If chk_pattern(HwpCtrl1.GetTextFile("TEXT", "").ToString) Then
                Console.WriteLine("한글에서 개인정보 탐지 : " & ren_tmp)
                Shell("cmd.exe /c drm_changer """ & ren_tmp & """")
                Console.WriteLine("cmd.exe /c drm_changer """ & ren_tmp & """")
                If IO.File.Exists(ren_tmp & ".ecps") Then
                    Console.WriteLine("한글 파일 암호화 완료 : " & ren_tmp & ".ecps")
                End If
                Application.DoEvents()
            End If
        Catch ex As Exception
            Console.WriteLine("한글 읽기 에러 : " & ex.Message)
            Shell("cmd.exe /c echo " & ren_tmp & ">> tmp_list.txt", vbHidden, True)
        End Try
        Application.DoEvents()
        HwpCtrl1.ReleaseScan()
        HwpCtrl1.Clear()

    End Sub
    '워드 읽기
    Private Sub read_word(ren_tmp As String)
        Try
            ' Extract text from an input file.

            Dim dtt As New ECPS_DRM_Protecter.DocxToTextDemo.DocxToText(ren_tmp)

            Application.DoEvents()

            If chk_pattern(dtt.ExtractText().ToString) Then
                Console.WriteLine("워드에서 개인정보 탐지 : " & ren_tmp)
                Shell("cmd.exe /c drm_changer """ & ren_tmp & """", vbHidden, True)
                If IO.File.Exists(ren_tmp & ".ecps") Then
                    Console.WriteLine("cmd.exe /c drm_changer """ & ren_tmp & """")
                    Console.WriteLine("워드 파일 암호화 완료 : " & ren_tmp & ".ecps")
                End If
                Application.DoEvents()
            End If

        Catch ex As Exception
            Console.WriteLine("워드 읽기 에러 : " & ex.Message)
            Shell("cmd.exe /c echo " & ren_tmp & ">> tmp_list.txt", vbHidden, True)
        End Try
    End Sub
    '엑셀 읽기
    Private Sub read_execl(ren_tmp As String)
        Dim total_str As String = ""
        Shell("cmd.exe /c ren """ & ren_tmp & """ """ & Replace(Mid(ren_tmp, InStrRev(ren_tmp, "\") + 1), " ", "_") & """")
        Dim txt_line = Microsoft.VisualBasic.Left(ren_tmp, InStrRev(ren_tmp, "\")) & Replace(Mid(ren_tmp, InStrRev(ren_tmp, "\") + 1), " ", "_")
        Try
            ' OLEDB를 이용한 엑셀 연결
            ' Excel 97-2003 .xls
            ' string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\x\test.xls;Extended Properties='Excel 8.0;HDR=No'";

            ' Excel 2007 이후 .xlsx
            Dim szConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ren_tmp & ";Extended Properties='Excel 8.0;HDR=No'"

            Dim conn As New OleDbConnection(szConn)
            conn.Open()

            ' 엑셀로부터 데이타 읽기
            Dim cmd As New OleDbCommand("SELECT * FROM [" & conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("Table_Name").ToString() & "]", conn)
            Dim adpt As New OleDbDataAdapter(cmd)
            Dim ds As New DataSet()
            adpt.Fill(ds)
            ' For Each Columns As DataRow In ds.Tables(0).Columns



            For Each Rows As DataRow In ds.Tables(0).Rows
                'Dim data As String = String.Format("F1:{0}, F2:{1}, F3:{2}", Rows(0), Rows(1), Rows(2))

                Dim in_tmp As Integer = 0
                Do While True
                    Try
                        total_str = total_str & Rows(in_tmp).ToString
                        in_tmp += 1
                    Catch
                        Exit Do
                    End Try
                Loop

            Next

            ' Next

            conn.Close()



            If chk_pattern(total_str) Then
                Console.WriteLine("엑셀에서 개인정보 탐지 : " & ren_tmp)
                Shell("cmd.exe /c drm_changer """ & ren_tmp & """", vbHidden, True)
                If IO.File.Exists(ren_tmp & ".ecps") Then
                    Console.WriteLine("cmd.exe /c drm_changer """ & ren_tmp & """")
                    Console.WriteLine("엑셀 파일 암호화 완료 : " & ren_tmp & ".ecps")
                End If
                Application.DoEvents()
            End If

        Catch ex As Exception
            Try



                Console.WriteLine("엑셀 읽기 에러 : " & ex.Message)
                Shell("cmd.exe /c echo " & ren_tmp & ">> tmp_list.txt", vbHidden, True)
            Catch ex_tmp As Exception
                Console.WriteLine("엑셀 읽기 에러 : " & ex_tmp.Message)
                Shell("cmd.exe /c echo " & ren_tmp & ">> tmp_list.txt", vbHidden, True)
            End Try
        End Try
        total_str = ""





    End Sub


    Function chk_pattern(tmp_str As String) '공용으로 사용될 함수 선택한 내용 탐색
        Application.DoEvents()
        Dim regexPattern As String
        Dim regex As Regex
        Dim regexMatches As MatchCollection
        Dim strSource As String
        strSource = tmp_str
        Dim re As Boolean = 0
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("person", 0) = 1 Then
            regexPattern = "([01][0-9]{5}[[:space:],~-]+[1-4][0-9]{6}|[2-9][0-9]{5}[[:space:],~-]+[1-2][0-9]{6})" ' 주민번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("주민번호 찾았다!!")
                re = 1
            End If
        End If

        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("ip", 0) = 1 Then
            regexPattern = "(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((1[0-9]{2})|(2[0-4]\d)|(25[0-5])|(\d{1,2}))" 'ip주소
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine(" ip 주소 찾았다!!")
                re = 1
            End If
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("addr", 0) = 1 Then
            regexPattern = "[\S]+(도|시)\s[\S]+(구|군)\s[\S]+(면|동).*" ' 주소 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("집주소 찾았다!!")
                re = 1
            End If
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("card", 0) = 1 Then

            regexPattern = "[34569][0-9]{3}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}" '카드번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("카드번호 찾았다!!")
                re = 1
            End If
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("bank", 0) = 1 Then
            regexPattern = "([0-9]{2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{6}|[0-9]{3}[-~.[:space:]]([0-9]{5,6}[-~.[:sp
ace:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{5}|[0-9]{2,3}[-~.[:space:]][0-9]{6}|[0-9]{2}[-~.[:sp
ace:]][0-9]{7}|[0-9]{2}[-~.[:space:]][0-9]{4,6}[-~.[:space:]][0-9]|[0-9]{5}[-~.[:space:]][0-9]{
3}[-~.[:space:]][0-9]{2}|[0-9]{2}[-~.[:space:]][0-9]{5}[-~.[:space:]][0-9]{3}|[0-9]{4}[-~.[:spa
ce:]][0-9]{4}[-~.[:space:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{3}|[0-9]{
2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{7})|[0-9]{4}[-~.[:space:]]([0-9]{3}[-~.[:space:]][0
-9]{6}|[0-9]{2}[-~.[:space:]][0-9]{6}[-~.[:space:]][0-9])|[0-9]{5}[-~.[:space:]][0-9]{2}[-~.[:s
pace:]][0-9]{6}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{5,6})" '계좌번호 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("계좌번호 찾았다!!")
                re = 1
            End If
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("email", 0) = 1 Then
            regexPattern = "(\S+)@([^\.\s]+)(?:\.([^\.\s]+))+" '이메일 정규식
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("이메일 찾았다!!")
                re = 1
            End If
        End If
        If Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("call", 0) = 1 Then
            regexPattern = "01[016789][-~.[:space:]][0-9]{3,4}[-~.[:space:]][0-9]{4}" ' 전화번호 정규식

            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(strSource)
            If regexMatches.Count > 0 Then
                Console.WriteLine("전화번호 찾았다!!")
                re = 1
            End If


        End If

        If re Then

            Return 1
        Else
            Return 0
        End If



    End Function ' 정규식 패턴 매치


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Hide()
        Run()

    End Sub ' 자동 시작 타이머

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub ' 폼 로드시 타이머 시작
End Class
'워드 문서 파싱 함수
Namespace DocxToTextDemo
    Public Class DocxToText
        Private Const ContentTypeNamespace As String = "http://schemas.openxmlformats.org/package/2006/content-types"

        Private Const WordprocessingMlNamespace As String = "http://schemas.openxmlformats.org/wordprocessingml/2006/main"

        Private Const DocumentXmlXPath As String = "/t:Types/t:Override[@ContentType=""application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml""]"

        Private Const BodyXPath As String = "/w:document/w:body"

        Private docxFile As String = ""
        Private docxFileLocation As String = ""


        Public Sub New(fileName As String)
            docxFile = fileName
        End Sub

#Region "ExtractText()"
        ''' <summary>
        ''' Extracts text from the Docx file.
        ''' </summary>
        ''' <returns>Extracted text.</returns>
        Public Function ExtractText() As String
            If String.IsNullOrEmpty(docxFile) Then
                Throw New Exception("Input file not specified.")
            End If

            ' Usually it is "/word/document.xml"

            docxFileLocation = FindDocumentXmlLocation()

            If String.IsNullOrEmpty(docxFileLocation) Then
                Throw New Exception("It is not a valid Docx file.")
            End If

            Return ReadDocumentXml()
        End Function
#End Region

#Region "FindDocumentXmlLocation()"
        ''' <summary>
        ''' Gets location of the "document.xml" zip entry.
        ''' </summary>
        ''' <returns>Location of the "document.xml".</returns>
        Private Function FindDocumentXmlLocation() As String
            Dim zip As New ZipFile(docxFile)
            For Each entry As ZipEntry In zip
                ' Find "[Content_Types].xml" zip entry

                If String.Compare(entry.Name, "[Content_Types].xml", True) = 0 Then
                    Dim contentTypes As Stream = zip.GetInputStream(entry)

                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.PreserveWhitespace = True
                    xmlDoc.Load(contentTypes)
                    contentTypes.Close()

                    'Create an XmlNamespaceManager for resolving namespaces

                    Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                    nsmgr.AddNamespace("t", ContentTypeNamespace)

                    ' Find location of "document.xml"

                    Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(DocumentXmlXPath, nsmgr)

                    If node IsNot Nothing Then
                        Dim location As String = DirectCast(node, XmlElement).GetAttribute("PartName")
                        Return location.TrimStart(New Char() {"/"c})
                    End If
                    Exit For
                End If
            Next
            zip.Close()
            Return Nothing
        End Function
#End Region

#Region "ReadDocumentXml()"
        ''' <summary>
        ''' Reads "document.xml" zip entry.
        ''' </summary>
        ''' <returns>Text containing in the document.</returns>
        Private Function ReadDocumentXml() As String
            Dim sb As New StringBuilder()

            Dim zip As New ZipFile(docxFile)
            For Each entry As ZipEntry In zip
                If String.Compare(entry.Name, docxFileLocation, True) = 0 Then
                    Dim documentXml As Stream = zip.GetInputStream(entry)

                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.PreserveWhitespace = True
                    xmlDoc.Load(documentXml)
                    documentXml.Close()

                    Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                    nsmgr.AddNamespace("w", WordprocessingMlNamespace)

                    Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(BodyXPath, nsmgr)

                    If node Is Nothing Then
                        Return String.Empty
                    End If

                    sb.Append(ReadNode(node))

                    Exit For
                End If
            Next
            zip.Close()
            Return sb.ToString()
        End Function
#End Region

#Region "ReadNode()"
        ''' <summary>
        ''' Reads content of the node and its nested childs.
        ''' </summary>
        ''' <param name="node">XmlNode.</param>
        ''' <returns>Text containing in the node.</returns>
        Private Function ReadNode(node As XmlNode) As String
            If node Is Nothing OrElse node.NodeType <> XmlNodeType.Element Then
                Return String.Empty
            End If

            Dim sb As New StringBuilder()
            For Each child As XmlNode In node.ChildNodes
                If child.NodeType <> XmlNodeType.Element Then
                    Continue For
                End If

                Select Case child.LocalName
                    Case "t"
                        ' Text
                        sb.Append(child.InnerText.TrimEnd())

                        Dim space As String = DirectCast(child, XmlElement).GetAttribute("xml:space")
                        If Not String.IsNullOrEmpty(space) AndAlso space = "preserve" Then
                            sb.Append(" "c)
                        End If

                        Exit Select

                    ' Carriage return
                    Case "cr", "br"
                        ' Page break
                        sb.Append(Environment.NewLine)
                        Exit Select

                    Case "tab"
                        ' Tab
                        sb.Append(vbTab)
                        Exit Select

                    Case "p"
                        ' Paragraph
                        sb.Append(ReadNode(child))
                        sb.Append(Environment.NewLine)
                        sb.Append(Environment.NewLine)
                        Exit Select
                    Case Else

                        sb.Append(ReadNode(child))
                        Exit Select
                End Select
            Next
            Return sb.ToString()
        End Function
#End Region
    End Class
End Namespace' 워드 문서 문자열 추출