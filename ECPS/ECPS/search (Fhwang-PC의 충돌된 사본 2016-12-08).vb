Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports Microsoft.Win32
Imports System.Text.RegularExpressions


Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip
Public Class search
    Dim f As Integer = 0




    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer_start.Enabled = True ' 검색 시작 타이머 시작
        'HwpCtrl1.Enabled = False '한글 뷰 안보이기
        HwpCtrl1.Visible = False
    End Sub ' 폼 로드시 실행
    Private Sub timer_start_Tick(sender As Object, e As EventArgs) Handles timer_start.Tick
        'Console.WriteLine(Environment.UserName.ToString)
        timer_start.Enabled = False ' 타이머 종료
        scan_list_all.Items.Clear()
        If main.mode = 1 Then ' 전체 스캔
            timer_count.Enabled = True '프로그레스바 시작
            count_label.Text = "검색중"
            Process("C:\") ' 전체 탐색
            timer_count.Enabled = False
            del_txt()
            Try
                Do While True
                    ProgressBar1.Value += 1
                    Application.DoEvents()
                    Console.WriteLine(ProgressBar1.Value)
                Loop
            Catch

            End Try
            Label1.Text = "    클릭시 미리보기 가능" & vbCrLf & vbCrLf & "   더블 클릭시 파일 실행"
            MsgBox("검색 완료", vbOKOnly, "결과 알림")

        ElseIf main.mode = 0 Then '퀵 버전으로 3경로만 탐색

            timer_count.Enabled = True '프로그레스바 시작
            count_label.Text = "검색중"
            Process("C:\Users\" & Environment.UserName.ToString)
            timer_count.Enabled = False
            del_txt()
            Try
                Do While True
                    ProgressBar1.Value += 1
                    Application.DoEvents()
                    Console.WriteLine(ProgressBar1.Value)
                Loop
            Catch

            End Try
            Label1.Text = "    클릭시 미리보기 가능" & vbCrLf & vbCrLf & "   더블 클릭시 파일 실행"
            MsgBox("검색 완료", vbOKOnly, "결과 알림")
        End If



    End Sub ' 자동 스타트 타이머
    Dim fileEntries As String() '파일 목록 변수
    Dim subdirectoryEntries As String() '폴더 목록 변수

    Public Sub Process(targetDirectory As String)

        fileEntries = Directory.GetFiles(targetDirectory)
        '파일목록 받아오기
        Dim fileName As String
        For Each fileName In fileEntries
            'Console.WriteLine("file : " & fileName)
            '각각의 확장자 별로 
            Select Case Microsoft.VisualBasic.Right(fileName, 4).ToString
                Case ".txt"
                    If config.set_txt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\txt.txt")

                    End If

                Case ".ppt"
                    If config.set_ppt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\ppt.txt")
                    End If

                Case "pptx"
                    If config.set_ppt.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\ppt.txt")
                    End If


                Case ".doc"
                    If config.set_word.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\doc.txt")
                    End If

                Case "docx"
                    If config.set_word.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\doc.txt")
                    End If

                Case ".hwp"
                    If config.set_hwp.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\hwp.txt")
                    End If

                Case ".xls"
                    If config.set_xls.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\xls.txt")
                    End If

                Case "xlsx"
                    If config.set_xls.Checked Then
                        Shell("cmd.exe /c echo " & fileName.ToString & " >> C:\xls.txt")
                    End If
            End Select


        Next
        '디렉토리목록 받아오기
        subdirectoryEntries = Directory.GetDirectories(targetDirectory)

        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            If Microsoft.VisualBasic.Left(subdirectory, 10) <> "C:\Windows" Or Microsoft.VisualBasic.Left(subdirectory, 11) <> "C:\$Recycle" Then
                'Console.WriteLine("dir : " & subdirectory) 

                path = subdirectory
                'Console.WriteLine(path)
                Try
                    all_find_pro()
                Catch

                End Try
            End If


        Next
        '메모장에서 목록 읽기
        update_one()




    End Sub '확장자별로 추출

    Dim finish_check As Boolean = 0 ' 추출 완료 여부 변수
    Dim path As String ' 위치 변수
    Dim str(5) As String ' 확장자별로 찾았는지 여부 = 
    Private Sub all_find_pro()
        '스레드 변수 선언
        Dim hwp As New System.Threading.Thread(AddressOf hwp_pro) '스레드1 생성 
        Dim docx As New System.Threading.Thread(AddressOf docx_pro) '스레드2  생성
        Dim doc As New System.Threading.Thread(AddressOf doc_pro) '스레드3 생성 
        Dim ppt As New System.Threading.Thread(AddressOf ppt_pro) '스레드4  생성
        Dim pptx As New System.Threading.Thread(AddressOf pptx_pro) '스레드5 생성 
        Dim txt As New System.Threading.Thread(AddressOf txt_pro) '스레드6  생성
        Dim xls As New System.Threading.Thread(AddressOf xls_pro) '스레드7 생성 
        Dim xlsx As New System.Threading.Thread(AddressOf xlsx_pro) '스레드8  생성
        'Console.WriteLine(config.chk_txt.Checked)
        Application.DoEvents()
        If config.set_txt.Checked Then
            txt.Start()

        End If
        If config.set_hwp.Checked Then
            hwp.Start()

        End If

        If config.set_word.Checked Then
            docx.Start()
            doc.Start()

        End If
        If config.set_xls.Checked Then
            xls.Start()
            xlsx.Start()

        End If

        If config.set_ppt.Checked Then
            ppt.Start()
            pptx.Start()

        End If
        '=============
        If config.set_txt.Checked Then
            txt.Join()
            txt.Abort()
        End If
        If config.set_hwp.Checked Then
            hwp.Join()
            hwp.Abort()

        End If

        If config.set_word.Checked Then
            docx.Join()
            doc.Join()
            docx.Abort()
            doc.Abort()

        End If
        If config.set_xls.Checked Then
            xls.Join()
            xlsx.Join()
            xls.Abort()
            xlsx.Abort()

        End If

        If config.set_ppt.Checked Then
            ppt.Join()
            pptx.Join()
            ppt.Abort()
            pptx.Abort()


        End If
        '스레드 실행 및 대기
        finish_check = 1 '완료 알리는 변수
        '=========================

    End Sub ' 확장자별 찾을 것인가를 결정하는 함수
    Private Sub del_txt()
        For Each str_tmp In str
            Try
                If str_tmp.Length = 6 Then
                    My.Computer.FileSystem.DeleteFile("C:\" & Microsoft.VisualBasic.Right(str_tmp, 3) & ".txt")
                End If
            Catch
                Console.WriteLine("error")
            End Try
        Next

    End Sub

    '각각의 확장자 파일들 목록 만들어줄 함수들
    Private Sub hwp_pro()
        str(1) = "\*.hwp"
        Shell("cmd.exe /c dir " & path & str(1) & " /on /b /s >>C:\hwp.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(1) & " /on /b /s >>C:\hwp.txt")
    End Sub
    Private Sub docx_pro()
        str(2) = "\*.doc"
        Shell("cmd.exe /c dir " & path & "\*.docx" & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(3) & " /on /b /s >>C:\doc.txt")
    End Sub
    Private Sub doc_pro()
        str(2) = "\*.doc"

        Shell("cmd.exe /c dir " & path & str(2) & " /on /b /s >>C:\doc.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(2) & " /on /b /s >>C:\doc.txt")
    End Sub
    Private Sub ppt_pro()
        str(3) = "\*.ppt"
        Shell("cmd.exe /c dir " & path & str(6) & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(6) & " /on /b /s >>C:\ppt.txt")
    End Sub
    Private Sub pptx_pro()
        str(3) = "\*.ppt"
        Shell("cmd.exe /c dir " & path & "\*.pptx" & " /on /b /s >>C:\ppt.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(7) & " /on /b /s >>C:\ppt.txt")
    End Sub
    Private Sub xls_pro()
        str(4) = "\*.xls"
        Shell("cmd.exe /c dir " & path & str(4) & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(4) & " /on /b /s >>C:\xls.txt")
    End Sub
    Private Sub xlsx_pro()
        str(4) = "\*.xls"
        Shell("cmd.exe /c dir " & path & "\*.xlsx" & " /on /b /s >>C:\xls.txt", AppWinStyle.Hide, True)
        'Console.WriteLine("dir " & str(5) & " /on /b /s >>C:\xls.txt")
    End Sub
    Private Sub txt_pro()
        str(0) = "\*.txt"
        Shell("cmd.exe /c dir " & path & str(0) & " /on /b /s >>C:\txt.txt", AppWinStyle.Hide, True)
        Console.WriteLine("dir " & str(0) & " /on /b /s >>C:\txt.txt")
    End Sub
    '메모장 열고 문자열 검사하기
    Private Sub update_one()
        For Each tmp As String In str
            Try
                If tmp.Length = 6 Then
                    read_txt(Microsoft.VisualBasic.Right(tmp, 3).ToString & ".txt")
                End If
            Catch
            End Try
        Next
    End Sub
    Dim count As Integer = 0
    Private Sub read_txt(name_txt As String)
        Select Case Microsoft.VisualBasic.Left(name_txt, 3)
            Case "hwp"
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "총 : " & count.ToString
                pass_pw_set_file_timer.Enabled = True
                For Each txt_line In Lines
                    Console.WriteLine(txt_line)

                    Timer1.Enabled = True
                    HwpCtrl1.Open(txt_line)
                    HwpCtrl1.InitScan()
                    Application.DoEvents()
                    Try
                        'Console.WriteLine(HwpCtrl1.GetTextFile("TEXT", "").ToString)
                        If ProgressBar1.Value < 90 Then
                            ProgressBar1.Value += 1
                        End If
                        If chk_pattern(HwpCtrl1.GetTextFile("TEXT", "").ToString) Then
                            hwp_list.Items.Add(txt_line)
                            scan_list_all.Items.Add(txt_line)

                            Application.DoEvents()
                        End If
                    Catch
                        Console.WriteLine("hwp_hot_find_str")
                    End Try
                    Application.DoEvents()
                    HwpCtrl1.ReleaseScan()


                Next
                pass_pw_set_file_timer.Enabled = False
            Case "doc"
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "총 : " & count.ToString
                For Each txt_line In Lines
                    ' Console.WriteLine(txt_line)
                    'Console.WriteLine(txt_line)
                    Timer1.Enabled = True
                    'word_list.Items.Clear()
                    'InitializeComponent()
                    Try
                        ' Extract text from an input file.
                        If ProgressBar1.Value < 90 Then
                            ProgressBar1.Value += 1
                        End If
                        Dim dtt As New ECPS.DocxToTextDemo.DocxToText(txt_line)
                        'Console.WriteLine(dtt.ExtractText())
                        Application.DoEvents()

                        If chk_pattern(dtt.ExtractText().ToString) Then
                            word_list.Items.Add(txt_line)
                            scan_list_all.Items.Add(txt_line)

                            Application.DoEvents()
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Application.DoEvents()


                Next
            Case "ppt"'구현 준비중
            Case "xls"
            Case "txt"
                If ProgressBar1.Value < 90 Then
                    ProgressBar1.Value += 1
                End If
                Dim Lines() As String = IO.File.ReadAllLines("C:\" & name_txt, Encoding.Default)
                count += Lines.Length
                count_label.Text = "총 : " & count.ToString
                For Each txt_line In Lines
                    Console.WriteLine(txt_line)

                    Timer1.Enabled = True

                    Console.WriteLine(My.Computer.FileSystem.ReadAllText(txt_line))
                    Application.DoEvents()
                    If chk_pattern(My.Computer.FileSystem.ReadAllText(txt_line)) Then
                        hwp_list.Items.Add(txt_line)
                        scan_list_all.Items.Add(txt_line)

                        Application.DoEvents()
                    End If

                Next

        End Select

    End Sub
    Private Function chk_pattern(tmp_str As String) '공용으로 사용될 함수 선택한 내용 탐색
        Application.DoEvents()
        Dim regexPattern As String
        Dim regex As Regex
        Dim regexMatches As MatchCollection
        Dim strSource As String
        strSource = tmp_str
        Select Case True
            Case config.set_person.Checked
                regexPattern = "\d{6}-?\d{7}" ' 주민번호 정규식
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("주민번호 찾았다!!")
                    Return 1
                End If
            Case config.set_ip.Checked
                regexPattern = "(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((1[0-9]{2})|(2[0-4]\d)|(25[0-5])|(\d{1,2}))" 'ip주소
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine(" ip 주소 찾았다!!")
                    Return 1
                End If
            Case config.set_addr.Checked
                regexPattern = "[\S]+(도|시)\s[\S]+(구|군)\s[\S]+(면|동).*" ' 주소 정규식
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("집주소 찾았다!!")
                    Return 1
                End If
            Case config.set_card.Checked

                regexPattern = "[1-9][0-9]{3} [0-9]{4} [0-9]{4} [0-9]{4}" '카드번호 정규식
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("카드번호 찾았다!!")
                    Return 1
                End If
            Case config.set_bank.Checked
                regexPattern = "[0-9,\-]{3,6}\-[0-9,\-]{2,6}\q-[0-9,\-]" '계좌번호 정규식
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("계좌번호 찾았다!!")
                    Return 1
                End If
            Case config.set_email.Checked
                regexPattern = "(\S+)@([^\.\s]+)(?:\.([^\.\s]+))+" '이메일 정규식
                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("이메일 찾았다!!")
                    Return 1
                End If
            Case config.set_call.Checked
                regexPattern = "[0][1][0-9]-[1-9][0-9]{3,4}-[0-9]{4,4}" ' 전화번호 정규식

                regex = New Regex(regexPattern)
                regexMatches = regex.Matches(strSource)
                If regexMatches.Count > 0 Then
                    Console.WriteLine("전화번호 찾았다!!")
                    Return 1
                End If


        End Select




        Return 0






    End Function
    '한글 보안 모듈 해제 부분
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

    End Sub '한글 보안 모듈 해제 타이머
    Dim time_log As Integer = 0
    Private Sub timer_count_Tick(sender As Object, e As EventArgs) Handles timer_count.Tick
        time_log += 1

        time_label.Text = Format(Convert.ToDateTime(Int(time_log / 3600).ToString & ":" & Int((time_log Mod 3600) / 60).ToString & ":" & Int((time_log Mod 3600) Mod 60).ToString), "HH:mm:ss")

    End Sub

    Private Sub pass_pw_set_file_timer_Tick(sender As Object, e As EventArgs) Handles pass_pw_set_file_timer.Tick
        Dim Handle As IntPtr = FindWindow("HNC_DIALOG", "문서 암호")
        Console.WriteLine(Handle.ToString)
        If Not (Handle.Equals(IntPtr.Zero)) Then

            ' activate Notepad window
            If (SetActiveWindow(Handle)) Then
                Console.WriteLine(Handle.ToString)
                ' send "Hello World!"

                ' send key "Tab"
                SendKeys.Send("{TAB}")
                SendKeys.Send("{TAB}")
                ' send key "Enter"
                SendKeys.Send("{ENTER}")
                Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub hwp_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hwp_list.SelectedIndexChanged
        Label1.Visible = False
        HwpCtrl1.Visible = True
        HwpCtrl1.Open(hwp_list.SelectedItem)
        HwpCtrl1.InitScan()
        Application.DoEvents()


        HwpCtrl1.ReleaseScan()
    End Sub
End Class
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
End Namespace