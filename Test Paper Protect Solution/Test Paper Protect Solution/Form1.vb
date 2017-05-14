Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Net.NetworkInformation

Public Class Form1

    '파일 이름 받아오기
    Private pc_name As String = Dns.GetHostEntry(Dns.GetHostName()).ToString
    Private m_mainWmi As Object '레지스터 관련 변수
    Private m_deviceLists As Collection ' 레지스터 관련 변수

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '프로그래스바 시작 타이머
        Timer1.Enabled = True
        '위치 지정
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.34, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.35)
        '공지사항 지정

        '솔루션 훼손 여부 점검
        Dim bios_id As String 'BIOS_ID 변수 선언
        bios_id = GetWmiDeviceSingleValue("Win32_BIOS", "SerialNumber") 'BIOS_ID 가져오기
        Dim cpu_id As String 'CPU_ID 변수 선언
        cpu_id = GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID") 'CPU_ID 가져오기
        '디버깅용
        'Console.WriteLine("CPU_ID : " & cpu_id + vbCrLf + "BIOS_ID : " & bios_id)
        '레지스터 값 검증
        Dim check As Boolean =
            (cpu_id.Equals(Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").GetValue("CPU_ID").ToString) And bios_id.Equals(Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").GetValue("BIOS_ID").ToString))
        '디버깅용
        'Console.WriteLine(check & "/" & cpu_id & "=" & Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").GetValue("CPU_ID") & "/" & bios_id & "=" & Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").GetValue("BIOS_ID"))
        '검증할 파일 변수 선언
        Dim check1 As Boolean = System.IO.File.Exists("en.exe")
        Dim check2 As Boolean = System.IO.File.Exists("de.exe")


        '파일 존재 여부
        If Not (check1 And check2 And check) Then
            MsgBox("솔루션 파일이 누군가 의도하여 훼손되었습니다" & vbCrLf & "담당자를 통해 다시 설치하세요")
            Form2.Hide()
            End
        End If

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Opacity = 1 Then
            Thread.Sleep(2000)
            Do Until Opacity = 0
                Opacity = Opacity - 0.01
                Thread.Sleep(10)
            Loop
            Form2.Show() '폼2를 띄운다
            Hide()
            Timer1.Enabled = False
        Else '//아니면

            Opacity = Opacity + 0.01

        End If '//if문 끝

    End Sub

    Private Function GetMainWMIObject() As Object
        On Error GoTo eh
        If m_mainWmi Is Nothing Then
            m_mainWmi = GetObject("WinMgmts:")
        End If
        GetMainWMIObject = m_mainWmi
        Exit Function
eh:
        GetMainWMIObject = Nothing
    End Function
    Public Function WmiIsAvailable() As Boolean
        WmiIsAvailable = CBool(Not GetMainWMIObject() Is Nothing)
    End Function

    Public Function GetWmiDeviceSingleValue(ByVal WmiClass As String, ByVal WmiProperty As String) As String
        On Error GoTo done
        Dim result As String = ""

        Dim wmiclassObjList As Object
        wmiclassObjList = GetWmiDeviceList(WmiClass)
        Dim wmiclassObj As Object
        For Each wmiclassObj In wmiclassObjList
            result = CallByName(wmiclassObj, WmiProperty, vbGet)
            Exit For
        Next

done:
        GetWmiDeviceSingleValue = Trim(result)
    End Function

    Public Function GetWmiDeviceList(ByVal WmiClass As String) As Object
        If m_deviceLists Is Nothing Then
            m_deviceLists = New Collection
        End If

        On Error GoTo fetchNew

        GetWmiDeviceList = m_deviceLists.Item(WmiClass)
        Exit Function

fetchNew:
        Dim devList As Object
        devList = GetWmiDeviceListInternal(WmiClass)
        If Not devList Is Nothing Then
            Call m_deviceLists.Add(devList, WmiClass)
        End If
        GetWmiDeviceList = devList
    End Function

    Private Function GetWmiDeviceListInternal(ByVal WmiClass As String) As Object
        On Error GoTo eh
        GetWmiDeviceListInternal = GetMainWMIObject.Instancesof(WmiClass)
        Exit Function
eh:
        GetWmiDeviceListInternal = Nothing
    End Function


End Class


'무결성 검증 코드가 존재하지 않는다면 만들고 삭제



'Call SetAttr("just_one_use.exe", vbNormal)
'Kill("just_one_use.exe")


'Call SetAttr("C:\Windows\slpt.txt", vbHidden)

'무결성 코드가 존재한다면 무결성 검사
'Dim Executable As String = "open_check.exe"
'Dim MyStartInfo As New Diagnostics.ProcessStartInfo(Executable, CommandLine)
'MyStartInfo.UseShellExecute = False                                  ' CMD.EXE 등을 사용하지 않음, 직접실행
'MyStartInfo.RedirectStandardOutput = True                     ' 프로그램 출력(STDOUT)을 Redirect 함
'MyStartInfo.CreateNoWindow = True                               ' 프로그램 실행 윈도우즈를 만들지 않음

'Dim MyProcess As New Diagnostics.Process
'MyProcess.StartInfo = MyStartInfo
'MyProcess.Start()                                                             ' 프로세스를 실행함
'Dim STDOUT As New StreamReader(MyProcess.StandardOutput.BaseStream)
'While Not (MyProcess.HasExited)
' Dim dummy As String = STDOUT.ReadLine                             ' 프로세스의 출력된 값에서, 라인 한개를 읽습니다
''
'If dummy = 0 Then
'MsgBox("이 솔루션은 기존에 설치된 컴퓨터에서만 사용 가능합니다
'               " & vbCrLf & "필요할 경우 이 컴퓨터에 설치후 사용 바랍니다")
'End
'End If
'My.Application.DoEvents()                                                             ' 다른 프로세스에 영향을 주지 않도록...
'End While