Imports System.Security.Cryptography
Imports Microsoft.Win32.RegistryKey
Module get_cpu_id
    ' Dim CPU As String
    ' CPU = GetWmiDeviceSingleValue("Win32_Processor", "ProcessorID")
    'Add the following code to a module (called e.g. WMI)
    Public m_mainWmi As Object
    Public m_deviceLists As Collection

    Public Function GetMainWMIObject() As Object
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

    Public Function GetWmiDeviceListInternal(ByVal WmiClass As String) As Object
        On Error GoTo eh
        GetWmiDeviceListInternal = GetMainWMIObject.Instancesof(WmiClass)
        Exit Function
eh:
        GetWmiDeviceListInternal = Nothing
    End Function



End Module
