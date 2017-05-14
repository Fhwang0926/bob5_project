Imports Microsoft.Win32.Registry
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Public Class one_chk
    Private m_mainWmi As Object
    Private m_deviceLists As Collection
    Dim tempKey As Microsoft.Win32.RegistryKey
    Dim registryObject As Microsoft.Win32.RegistryKey = Nothing
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        check_passwd(TextBox1.Text)
    End Sub

    Private Sub set_pw()
        Dim bios_id As String
        bios_id = GetWmiDeviceSingleValue("Win32_BIOS", "SerialNumber")

        Dim cpu_id As String
        cpu_id = GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID")
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
    Public Sub check_passwd(str As String)
        Dim regexMatches As MatchCollection
        Dim regex As Regex
        Dim regexPattern As String
        If str.Length > 7 Then

            regexPattern = "\w\W"
            regex = New Regex(regexPattern)
            regexMatches = regex.Matches(str)
            If regexMatches.Count > 0 Then
                Dim tmp As String
                If TypeOf My.User.CurrentPrincipal Is
           Security.Principal.WindowsPrincipal Then
                    Dim parts() As String = Split(My.User.Name, "\")
                    Dim username As String = parts(1)
                    ''Console.WriteLine(username & "1")
                    tmp = username
                Else
                    ' The application is using custom authentication.
                    ''Console.WriteLine(My.User.Name & "0")
                    tmp = My.User.Name
                End If
                tmp = ("cmd.exe /c net user " & Trim(tmp.ToString) & " " & """" & str & """")
                Console.WriteLine(tmp)
                Shell(tmp, vbHidden, True)
                MsgBox("암호가 변경되었습니다")
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("once", 1)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").SetValue("pw", 1)
                loding.once = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("once")
                Me.Hide()
                main.Show()
            Else
                MsgBox("숫자, 문자, 특수문자가 포함되어야합니다" & vbCrLf & "특수문자는 가급적 맨 앞에 넣지 마십시요")
            End If
            'Console.WriteLine(regexMatches.ToString)
        Else
            MsgBox("암호는 최소 8자리 이상입니다")
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loding.once = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("ECPS").GetValue("once")
        'Console.WriteLine(loding.once)
        If loding.once = 1 Then
            Me.Text = "암호 재설정"
            Label2.Text = "윈도우 암호를 재설정합니다
기존의 암호가 있다면 암호가 재설정됩니다
변경된 암호를 꼭 숙지하시기 바랍니다
기존과 동일한 암호를 입력하셔도 상관 없습니다"
        Else
            Me.Text = "윈도우 암호 재설정"
            Label2.Text = "프로그램 설치시 최초 1회 윈도우 암호를 설정합니다
기존의 암호가 있다면 암호가 재설정됩니다
변경된 암호를 꼭 숙지하시기 바랍니다
기존과 동일한 암호를 입력하셔도 상관 없습니다"
        End If
    End Sub


End Class
