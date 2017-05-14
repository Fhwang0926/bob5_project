Imports Microsoft.Win32.RegistryKey
Public Class Form1
    Dim tempKey As Microsoft.Win32.RegistryKey
    Dim registryObject As Microsoft.Win32.RegistryKey = Nothing
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bios_id As String
        bios_id = GetWmiDeviceSingleValue("Win32_BIOS", "SerialNumber")

        Dim cpu_id As String
        cpu_id = GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID")

        'MsgBox("CPU_ID : " & cpu_id + vbCrLf + "BIOS_ID : " & bios_id)

        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").SetValue("CPU_ID", cpu_id)
        Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").SetValue("BIOS_ID", bios_id)
        MsgBox("인증되었습니다" & vbCrLf & "Test Paper Protect solution 을 사용할 수 있습니다", vbQuestion + vbYes, "알림")
    End Sub
    ' Dim CPU As String
    ' CPU = GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID")
    'Add the following code to a module (called e.g. WMI)
    Private m_mainWmi As Object
    Private m_deviceLists As Collection

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



    Private Sub check_btn_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update").GetValue("AUOptions", 0))
        Label1.Text = "CPU_ID : " &
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("Microsoft").CreateSubKey("Windows").CreateSubKey("CurrentVersion").CreateSubKey("WindowsUpdate").CreateSubKey("Auto Update").GetValue("test") &
vbCrLf & "BIOS_ID : " & Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("tpls").GetValue("BIOS_ID")
    End Sub
End Class
