Imports System.Text
Imports System.IO
Imports str_en_de_ecps.SeedCs
' 20120309 by hong+
Imports System.Collections
' ArrayList 관련
Public Class Form1
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtOringin.Click
        txtOringin.Text = ""
    End Sub
    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtSeed.Click
        txtSeed.Text = ""
    End Sub
    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox3.Click
        RichTextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        txtSeed.Text = String.Empty
        If String.IsNullOrEmpty(txtOringin.Text) Then
            Return
        End If


        cryptoData = SeedCs.SEED.Encrypt(txtOringin.Text)

        ' 암호화된 데이터는 바이트데이터입니다.
        txtSeed.Text = cryptoData


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
    Function AsciiSwitch(InputString As String, ValueToAdd As Integer) As String
        Dim OutputString As String = String.Empty
        Dim c As Char
        For i = 0 To Len(InputString) - 1
            c = InputString.Substring(i, 1)
            OutputString += Chr(Asc(c) + ValueToAdd)
        Next
        Console.WriteLine(OutputString)
        Return OutputString
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        txtOringin.Text = String.Empty
        If String.IsNullOrEmpty(txtSeed.Text) Then
            Return
        End If

        ' 텍스트박스에 표시되어 있는 암호화 데이터는 Base64 인코딩 된 데이터입니다.
        ' 디코딩한 후 복호화 모듈에 넘깁니다.
        Dim plainData As String = SeedCs.SEED.Decrypt(txtSeed.Text)

        ' 복호화된 데이터는 바이트데이터입니다. 문자열로만 바꿉니다.
        txtOringin.Text = plainData



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
    End Sub
    Public cryptoData As String
End Class


Namespace SeedCs
    Public Class SEED
#Region "SSN"

        Private Shared SS0 As UInteger() = New UInteger(255) {&H2989A1A8, &H5858184, &H16C6D2D4, &H13C3D3D0, &H14445054, &H1D0D111C,
            &H2C8CA0AC, &H25052124, &H1D4D515C, &H3434340, &H18081018, &H1E0E121C,
            &H11415150, &H3CCCF0FC, &HACAC2C8, &H23436360, &H28082028, &H4444044,
            &H20002020, &H1D8D919C, &H20C0E0E0, &H22C2E2E0, &H8C8C0C8, &H17071314,
            &H2585A1A4, &HF8F838C, &H3030300, &H3B4B7378, &H3B8BB3B8, &H13031310,
            &H12C2D2D0, &H2ECEE2EC, &H30407070, &HC8C808C, &H3F0F333C, &H2888A0A8,
            &H32023230, &H1DCDD1DC, &H36C6F2F4, &H34447074, &H2CCCE0EC, &H15859194,
            &HB0B0308, &H17475354, &H1C4C505C, &H1B4B5358, &H3D8DB1BC, &H1010100,
            &H24042024, &H1C0C101C, &H33437370, &H18889098, &H10001010, &HCCCC0CC,
            &H32C2F2F0, &H19C9D1D8, &H2C0C202C, &H27C7E3E4, &H32427270, &H3838380,
            &H1B8B9398, &H11C1D1D0, &H6868284, &H9C9C1C8, &H20406060, &H10405050,
            &H2383A3A0, &H2BCBE3E8, &HD0D010C, &H3686B2B4, &H1E8E929C, &HF4F434C,
            &H3787B3B4, &H1A4A5258, &H6C6C2C4, &H38487078, &H2686A2A4, &H12021210,
            &H2F8FA3AC, &H15C5D1D4, &H21416160, &H3C3C3C0, &H3484B0B4, &H1414140,
            &H12425250, &H3D4D717C, &HD8D818C, &H8080008, &H1F0F131C, &H19899198,
            &H0, &H19091118, &H4040004, &H13435350, &H37C7F3F4, &H21C1E1E0,
            &H3DCDF1FC, &H36467274, &H2F0F232C, &H27072324, &H3080B0B0, &HB8B8388,
            &HE0E020C, &H2B8BA3A8, &H2282A2A0, &H2E4E626C, &H13839390, &HD4D414C,
            &H29496168, &H3C4C707C, &H9090108, &HA0A0208, &H3F8FB3BC, &H2FCFE3EC,
            &H33C3F3F0, &H5C5C1C4, &H7878384, &H14041014, &H3ECEF2FC, &H24446064,
            &H1ECED2DC, &H2E0E222C, &HB4B4348, &H1A0A1218, &H6060204, &H21012120,
            &H2B4B6368, &H26466264, &H2020200, &H35C5F1F4, &H12829290, &HA8A8288,
            &HC0C000C, &H3383B3B0, &H3E4E727C, &H10C0D0D0, &H3A4A7278, &H7474344,
            &H16869294, &H25C5E1E4, &H26062224, &H808080, &H2D8DA1AC, &H1FCFD3DC,
            &H2181A1A0, &H30003030, &H37073334, &H2E8EA2AC, &H36063234, &H15051114,
            &H22022220, &H38083038, &H34C4F0F4, &H2787A3A4, &H5454144, &HC4C404C,
            &H1818180, &H29C9E1E8, &H4848084, &H17879394, &H35053134, &HBCBC3C8,
            &HECEC2CC, &H3C0C303C, &H31417170, &H11011110, &H7C7C3C4, &H9898188,
            &H35457174, &H3BCBF3F8, &H1ACAD2D8, &H38C8F0F8, &H14849094, &H19495158,
            &H2828280, &H4C4C0C4, &H3FCFF3FC, &H9494148, &H39093138, &H27476364,
            &HC0C0C0, &HFCFC3CC, &H17C7D3D4, &H3888B0B8, &HF0F030C, &HE8E828C,
            &H2424240, &H23032320, &H11819190, &H2C4C606C, &H1BCBD3D8, &H2484A0A4,
            &H34043034, &H31C1F1F0, &H8484048, &H2C2C2C0, &H2F4F636C, &H3D0D313C,
            &H2D0D212C, &H404040, &H3E8EB2BC, &H3E0E323C, &H3C8CB0BC, &H1C1C1C0,
            &H2A8AA2A8, &H3A8AB2B8, &HE4E424C, &H15455154, &H3B0B3338, &H1CCCD0DC,
            &H28486068, &H3F4F737C, &H1C8C909C, &H18C8D0D8, &HA4A4248, &H16465254,
            &H37477374, &H2080A0A0, &H2DCDE1EC, &H6464244, &H3585B1B4, &H2B0B2328,
            &H25456164, &H3ACAF2F8, &H23C3E3E0, &H3989B1B8, &H3181B1B0, &H1F8F939C,
            &H1E4E525C, &H39C9F1F8, &H26C6E2E4, &H3282B2B0, &H31013130, &H2ACAE2E8,
            &H2D4D616C, &H1F4F535C, &H24C4E0E4, &H30C0F0F0, &HDCDC1CC, &H8888088,
            &H16061214, &H3A0A3238, &H18485058, &H14C4D0D4, &H22426260, &H29092128,
            &H7070304, &H33033330, &H28C8E0E8, &H1B0B1318, &H5050104, &H39497178,
            &H10809090, &H2A4A6268, &H2A0A2228, &H1A8A9298}

        Private Shared SS1 As UInteger() = New UInteger(255) {&H38380830, &HE828C8E0UI, &H2C2D0D21, &HA42686A2UI, &HCC0FCFC3UI, &HDC1ECED2UI,
            &HB03383B3UI, &HB83888B0UI, &HAC2F8FA3UI, &H60204060, &H54154551, &HC407C7C3UI,
            &H44044440, &H6C2F4F63, &H682B4B63, &H581B4B53, &HC003C3C3UI, &H60224262,
            &H30330333, &HB43585B1UI, &H28290921, &HA02080A0UI, &HE022C2E2UI, &HA42787A3UI,
            &HD013C3D3UI, &H90118191UI, &H10110111, &H4060602, &H1C1C0C10, &HBC3C8CB0UI,
            &H34360632, &H480B4B43, &HEC2FCFE3UI, &H88088880UI, &H6C2C4C60, &HA82888A0UI,
            &H14170713, &HC404C4C0UI, &H14160612, &HF434C4F0UI, &HC002C2C2UI, &H44054541,
            &HE021C1E1UI, &HD416C6D2UI, &H3C3F0F33, &H3C3D0D31, &H8C0E8E82UI, &H98188890UI,
            &H28280820, &H4C0E4E42, &HF436C6F2UI, &H3C3E0E32, &HA42585A1UI, &HF839C9F1UI,
            &HC0D0D01, &HDC1FCFD3UI, &HD818C8D0UI, &H282B0B23, &H64264662, &H783A4A72,
            &H24270723, &H2C2F0F23, &HF031C1F1UI, &H70324272, &H40024242, &HD414C4D0UI,
            &H40014141, &HC000C0C0UI, &H70334373, &H64274763, &HAC2C8CA0UI, &H880B8B83UI,
            &HF437C7F3UI, &HAC2D8DA1UI, &H80008080UI, &H1C1F0F13, &HC80ACAC2UI, &H2C2C0C20,
            &HA82A8AA2UI, &H34340430, &HD012C2D2UI, &H80B0B03, &HEC2ECEE2UI, &HE829C9E1UI,
            &H5C1D4D51, &H94148490UI, &H18180810, &HF838C8F0UI, &H54174753, &HAC2E8EA2UI,
            &H8080800, &HC405C5C1UI, &H10130313, &HCC0DCDC1UI, &H84068682UI, &HB83989B1UI,
            &HFC3FCFF3UI, &H7C3D4D71, &HC001C1C1UI, &H30310131, &HF435C5F1UI, &H880A8A82UI,
            &H682A4A62, &HB03181B1UI, &HD011C1D1UI, &H20200020, &HD417C7D3UI, &H20202,
            &H20220222, &H4040400, &H68284860, &H70314171, &H4070703, &HD81BCBD3UI,
            &H9C1D8D91UI, &H98198991UI, &H60214161, &HBC3E8EB2UI, &HE426C6E2UI, &H58194951,
            &HDC1DCDD1UI, &H50114151, &H90108090UI, &HDC1CCCD0UI, &H981A8A92UI, &HA02383A3UI,
            &HA82B8BA3UI, &HD010C0D0UI, &H80018181UI, &HC0F0F03, &H44074743, &H181A0A12,
            &HE023C3E3UI, &HEC2CCCE0UI, &H8C0D8D81UI, &HBC3F8FB3UI, &H94168692UI, &H783B4B73,
            &H5C1C4C50, &HA02282A2UI, &HA02181A1UI, &H60234363, &H20230323, &H4C0D4D41,
            &HC808C8C0UI, &H9C1E8E92UI, &H9C1C8C90UI, &H383A0A32, &HC0C0C00, &H2C2E0E22,
            &HB83A8AB2UI, &H6C2E4E62, &H9C1F8F93UI, &H581A4A52, &HF032C2F2UI, &H90128292UI,
            &HF033C3F3UI, &H48094941, &H78384870, &HCC0CCCC0UI, &H14150511, &HF83BCBF3UI,
            &H70304070, &H74354571, &H7C3F4F73, &H34350531, &H10100010, &H30303,
            &H64244460, &H6C2D4D61, &HC406C6C2UI, &H74344470, &HD415C5D1UI, &HB43484B0UI,
            &HE82ACAE2UI, &H8090901, &H74364672, &H18190911, &HFC3ECEF2UI, &H40004040,
            &H10120212, &HE020C0E0UI, &HBC3D8DB1UI, &H4050501, &HF83ACAF2UI, &H10101,
            &HF030C0F0UI, &H282A0A22, &H5C1E4E52, &HA82989A1UI, &H54164652, &H40034343,
            &H84058581UI, &H14140410, &H88098981UI, &H981B8B93UI, &HB03080B0UI, &HE425C5E1UI,
            &H48084840, &H78394971, &H94178793UI, &HFC3CCCF0UI, &H1C1E0E12, &H80028282UI,
            &H20210121, &H8C0C8C80UI, &H181B0B13, &H5C1F4F53, &H74374773, &H54144450,
            &HB03282B2UI, &H1C1D0D11, &H24250521, &H4C0F4F43, &H0, &H44064642,
            &HEC2DCDE1UI, &H58184850, &H50124252, &HE82BCBE3UI, &H7C3E4E72, &HD81ACAD2UI,
            &HC809C9C1UI, &HFC3DCDF1UI, &H30300030, &H94158591UI, &H64254561, &H3C3C0C30,
            &HB43686B2UI, &HE424C4E0UI, &HB83B8BB3UI, &H7C3C4C70, &HC0E0E02, &H50104050,
            &H38390931, &H24260622, &H30320232, &H84048480UI, &H68294961, &H90138393UI,
            &H34370733, &HE427C7E3UI, &H24240420, &HA42484A0UI, &HC80BCBC3UI, &H50134353,
            &H80A0A02, &H84078783UI, &HD819C9D1UI, &H4C0C4C40, &H80038383UI, &H8C0F8F83UI,
            &HCC0ECEC2UI, &H383B0B33, &H480A4A42, &HB43787B3UI}

        Private Shared SS2 As UInteger() = New UInteger(255) {&HA1A82989UI, &H81840585UI, &HD2D416C6UI, &HD3D013C3UI, &H50541444, &H111C1D0D,
            &HA0AC2C8CUI, &H21242505, &H515C1D4D, &H43400343, &H10181808, &H121C1E0E,
            &H51501141, &HF0FC3CCCUI, &HC2C80ACAUI, &H63602343, &H20282808, &H40440444,
            &H20202000, &H919C1D8DUI, &HE0E020C0UI, &HE2E022C2UI, &HC0C808C8UI, &H13141707,
            &HA1A42585UI, &H838C0F8FUI, &H3000303, &H73783B4B, &HB3B83B8BUI, &H13101303,
            &HD2D012C2UI, &HE2EC2ECEUI, &H70703040, &H808C0C8CUI, &H333C3F0F, &HA0A82888UI,
            &H32303202, &HD1DC1DCDUI, &HF2F436C6UI, &H70743444, &HE0EC2CCCUI, &H91941585UI,
            &H3080B0B, &H53541747, &H505C1C4C, &H53581B4B, &HB1BC3D8DUI, &H1000101,
            &H20242404, &H101C1C0C, &H73703343, &H90981888UI, &H10101000, &HC0CC0CCCUI,
            &HF2F032C2UI, &HD1D819C9UI, &H202C2C0C, &HE3E427C7UI, &H72703242, &H83800383UI,
            &H93981B8BUI, &HD1D011C1UI, &H82840686UI, &HC1C809C9UI, &H60602040, &H50501040,
            &HA3A02383UI, &HE3E82BCBUI, &H10C0D0D, &HB2B43686UI, &H929C1E8EUI, &H434C0F4F,
            &HB3B43787UI, &H52581A4A, &HC2C406C6UI, &H70783848, &HA2A42686UI, &H12101202,
            &HA3AC2F8FUI, &HD1D415C5UI, &H61602141, &HC3C003C3UI, &HB0B43484UI, &H41400141,
            &H52501242, &H717C3D4D, &H818C0D8DUI, &H80808, &H131C1F0F, &H91981989UI,
            &H0, &H11181909, &H40404, &H53501343, &HF3F437C7UI, &HE1E021C1UI,
            &HF1FC3DCDUI, &H72743646, &H232C2F0F, &H23242707, &HB0B03080UI, &H83880B8BUI,
            &H20C0E0E, &HA3A82B8BUI, &HA2A02282UI, &H626C2E4E, &H93901383UI, &H414C0D4D,
            &H61682949, &H707C3C4C, &H1080909, &H2080A0A, &HB3BC3F8FUI, &HE3EC2FCFUI,
            &HF3F033C3UI, &HC1C405C5UI, &H83840787UI, &H10141404, &HF2FC3ECEUI, &H60642444,
            &HD2DC1ECEUI, &H222C2E0E, &H43480B4B, &H12181A0A, &H2040606, &H21202101,
            &H63682B4B, &H62642646, &H2000202, &HF1F435C5UI, &H92901282UI, &H82880A8AUI,
            &HC0C0C, &HB3B03383UI, &H727C3E4E, &HD0D010C0UI, &H72783A4A, &H43440747,
            &H92941686UI, &HE1E425C5UI, &H22242606, &H80800080UI, &HA1AC2D8DUI, &HD3DC1FCFUI,
            &HA1A02181UI, &H30303000, &H33343707, &HA2AC2E8EUI, &H32343606, &H11141505,
            &H22202202, &H30383808, &HF0F434C4UI, &HA3A42787UI, &H41440545, &H404C0C4C,
            &H81800181UI, &HE1E829C9UI, &H80840484UI, &H93941787UI, &H31343505, &HC3C80BCBUI,
            &HC2CC0ECEUI, &H303C3C0C, &H71703141, &H11101101, &HC3C407C7UI, &H81880989UI,
            &H71743545, &HF3F83BCBUI, &HD2D81ACAUI, &HF0F838C8UI, &H90941484UI, &H51581949,
            &H82800282UI, &HC0C404C4UI, &HF3FC3FCFUI, &H41480949, &H31383909, &H63642747,
            &HC0C000C0UI, &HC3CC0FCFUI, &HD3D417C7UI, &HB0B83888UI, &H30C0F0F, &H828C0E8EUI,
            &H42400242, &H23202303, &H91901181UI, &H606C2C4C, &HD3D81BCBUI, &HA0A42484UI,
            &H30343404, &HF1F031C1UI, &H40480848, &HC2C002C2UI, &H636C2F4F, &H313C3D0D,
            &H212C2D0D, &H40400040, &HB2BC3E8EUI, &H323C3E0E, &HB0BC3C8CUI, &HC1C001C1UI,
            &HA2A82A8AUI, &HB2B83A8AUI, &H424C0E4E, &H51541545, &H33383B0B, &HD0DC1CCCUI,
            &H60682848, &H737C3F4F, &H909C1C8CUI, &HD0D818C8UI, &H42480A4A, &H52541646,
            &H73743747, &HA0A02080UI, &HE1EC2DCDUI, &H42440646, &HB1B43585UI, &H23282B0B,
            &H61642545, &HF2F83ACAUI, &HE3E023C3UI, &HB1B83989UI, &HB1B03181UI, &H939C1F8FUI,
            &H525C1E4E, &HF1F839C9UI, &HE2E426C6UI, &HB2B03282UI, &H31303101, &HE2E82ACAUI,
            &H616C2D4D, &H535C1F4F, &HE0E424C4UI, &HF0F030C0UI, &HC1CC0DCDUI, &H80880888UI,
            &H12141606, &H32383A0A, &H50581848, &HD0D414C4UI, &H62602242, &H21282909,
            &H3040707, &H33303303, &HE0E828C8UI, &H13181B0B, &H1040505, &H71783949,
            &H90901080UI, &H62682A4A, &H22282A0A, &H92981A8AUI}

        Private Shared SS3 As UInteger() = New UInteger(255) {&H8303838, &HC8E0E828UI, &HD212C2D, &H86A2A426UI, &HCFC3CC0FUI, &HCED2DC1EUI,
            &H83B3B033UI, &H88B0B838UI, &H8FA3AC2FUI, &H40606020, &H45515415, &HC7C3C407UI,
            &H44404404, &H4F636C2F, &H4B63682B, &H4B53581B, &HC3C3C003UI, &H42626022,
            &H3333033, &H85B1B435UI, &H9212829, &H80A0A020UI, &HC2E2E022UI, &H87A3A427UI,
            &HC3D3D013UI, &H81919011UI, &H1111011, &H6020406, &HC101C1C, &H8CB0BC3CUI,
            &H6323436, &H4B43480B, &HCFE3EC2FUI, &H88808808UI, &H4C606C2C, &H88A0A828UI,
            &H7131417, &HC4C0C404UI, &H6121416, &HC4F0F434UI, &HC2C2C002UI, &H45414405,
            &HC1E1E021UI, &HC6D2D416UI, &HF333C3F, &HD313C3D, &H8E828C0EUI, &H88909818UI,
            &H8202828, &H4E424C0E, &HC6F2F436UI, &HE323C3E, &H85A1A425UI, &HC9F1F839UI,
            &HD010C0D, &HCFD3DC1FUI, &HC8D0D818UI, &HB23282B, &H46626426, &H4A72783A,
            &H7232427, &HF232C2F, &HC1F1F031UI, &H42727032, &H42424002, &HC4D0D414UI,
            &H41414001, &HC0C0C000UI, &H43737033, &H47636427, &H8CA0AC2CUI, &H8B83880BUI,
            &HC7F3F437UI, &H8DA1AC2DUI, &H80808000UI, &HF131C1F, &HCAC2C80AUI, &HC202C2C,
            &H8AA2A82AUI, &H4303434, &HC2D2D012UI, &HB03080B, &HCEE2EC2EUI, &HC9E1E829UI,
            &H4D515C1D, &H84909414UI, &H8101818, &HC8F0F838UI, &H47535417, &H8EA2AC2EUI,
            &H8000808, &HC5C1C405UI, &H3131013, &HCDC1CC0DUI, &H86828406UI, &H89B1B839UI,
            &HCFF3FC3FUI, &H4D717C3D, &HC1C1C001UI, &H1313031, &HC5F1F435UI, &H8A82880AUI,
            &H4A62682A, &H81B1B031UI, &HC1D1D011UI, &H202020, &HC7D3D417UI, &H2020002,
            &H2222022, &H4000404, &H48606828, &H41717031, &H7030407, &HCBD3D81BUI,
            &H8D919C1DUI, &H89919819UI, &H41616021, &H8EB2BC3EUI, &HC6E2E426UI, &H49515819,
            &HCDD1DC1DUI, &H41515011, &H80909010UI, &HCCD0DC1CUI, &H8A92981AUI, &H83A3A023UI,
            &H8BA3A82BUI, &HC0D0D010UI, &H81818001UI, &HF030C0F, &H47434407, &HA12181A,
            &HC3E3E023UI, &HCCE0EC2CUI, &H8D818C0DUI, &H8FB3BC3FUI, &H86929416UI, &H4B73783B,
            &H4C505C1C, &H82A2A022UI, &H81A1A021UI, &H43636023, &H3232023, &H4D414C0D,
            &HC8C0C808UI, &H8E929C1EUI, &H8C909C1CUI, &HA32383A, &HC000C0C, &HE222C2E,
            &H8AB2B83AUI, &H4E626C2E, &H8F939C1FUI, &H4A52581A, &HC2F2F032UI, &H82929012UI,
            &HC3F3F033UI, &H49414809, &H48707838, &HCCC0CC0CUI, &H5111415, &HCBF3F83BUI,
            &H40707030, &H45717435, &H4F737C3F, &H5313435, &H101010, &H3030003,
            &H44606424, &H4D616C2D, &HC6C2C406UI, &H44707434, &HC5D1D415UI, &H84B0B434UI,
            &HCAE2E82AUI, &H9010809, &H46727436, &H9111819, &HCEF2FC3EUI, &H40404000,
            &H2121012, &HC0E0E020UI, &H8DB1BC3DUI, &H5010405, &HCAF2F83AUI, &H1010001,
            &HC0F0F030UI, &HA22282A, &H4E525C1E, &H89A1A829UI, &H46525416, &H43434003,
            &H85818405UI, &H4101414, &H89818809UI, &H8B93981BUI, &H80B0B030UI, &HC5E1E425UI,
            &H48404808, &H49717839, &H87939417UI, &HCCF0FC3CUI, &HE121C1E, &H82828002UI,
            &H1212021, &H8C808C0CUI, &HB13181B, &H4F535C1F, &H47737437, &H44505414,
            &H82B2B032UI, &HD111C1D, &H5212425, &H4F434C0F, &H0, &H46424406,
            &HCDE1EC2DUI, &H48505818, &H42525012, &HCBE3E82BUI, &H4E727C3E, &HCAD2D81AUI,
            &HC9C1C809UI, &HCDF1FC3DUI, &H303030, &H85919415UI, &H45616425, &HC303C3C,
            &H86B2B436UI, &HC4E0E424UI, &H8BB3B83BUI, &H4C707C3C, &HE020C0E, &H40505010,
            &H9313839, &H6222426, &H2323032, &H84808404UI, &H49616829, &H83939013UI,
            &H7333437, &HC7E3E427UI, &H4202424, &H84A0A424UI, &HCBC3C80BUI, &H43535013,
            &HA02080A, &H87838407UI, &HC9D1D819UI, &H4C404C0C, &H83838003UI, &H8F838C0FUI,
            &HCEC2CC0EUI, &HB33383B, &H4A42480A, &H87B3B437UI}

#End Region

        Private Shared Function GetB0(A As UInteger) As Byte
            Return BitConverter.GetBytes(A)(0)
        End Function
        Private Shared Function GetB1(A As UInteger) As Byte
            Return BitConverter.GetBytes(A)(1)
        End Function
        Private Shared Function GetB2(A As UInteger) As Byte
            Return BitConverter.GetBytes(A)(2)
        End Function
        Private Shared Function GetB3(A As UInteger) As Byte
            Return BitConverter.GetBytes(A)(3)
        End Function

        '************************* Macros for Key schedule **************************

        Private Shared Sub EncRoundKeyUpdate0(ByRef K As UInteger(), idx As Integer, ByRef A As UInteger, ByRef B As UInteger, ByRef C As UInteger, ByRef D As UInteger,
            KC As UInteger)
            Dim T0 As UInteger, T1 As UInteger
            T0 = A
            A = (A >> 8) Xor (B << 24)
            B = (B >> 8) Xor (T0 << 24)
            T0 = A + C - KC
            T1 = B + KC - D
            K(0 + idx) = SS0(GetB0(T0)) Xor SS1(GetB1(T0)) Xor SS2(GetB2(T0)) Xor SS3(GetB3(T0))
            K(1 + idx) = SS0(GetB0(T1)) Xor SS1(GetB1(T1)) Xor SS2(GetB2(T1)) Xor SS3(GetB3(T1))

            Return
        End Sub

        Private Shared Sub EncRoundKeyUpdate1(ByRef K As UInteger(), idx As Integer, ByRef A As UInteger, ByRef B As UInteger, ByRef C As UInteger, ByRef D As UInteger,
            KC As UInteger)
            Dim T0 As UInteger, T1 As UInteger
            T0 = C
            C = (C << 8) Xor (D >> 24)
            D = (D << 8) Xor (T0 >> 24)
            T0 = A + C - KC
            T1 = B + KC - D
            K(0 + idx) = SS0(GetB0(T0)) Xor SS1(GetB1(T0)) Xor SS2(GetB2(T0)) Xor SS3(GetB3(T0))
            K(1 + idx) = SS0(GetB0(T1)) Xor SS1(GetB1(T1)) Xor SS2(GetB2(T1)) Xor SS3(GetB3(T1))
            Return
        End Sub

        Private Shared Function EndianChange(dwS As UInteger) As UInteger
            Return ((ROTL((dwS), 8) And CUInt(&HFF00FF)) Or (ROTL((dwS), 24) And CUInt(&HFF00FF00UI)))
        End Function

        Private Shared Function ROTL(x As UInteger, n As Integer) As UInteger
            Return (((x) << (n)) Or ((x) >> (32 - (n))))
        End Function

        '*********************** Constants for Key schedule *************************

        Private Shared Sub SeedEncRoundKey(ByRef pRoundKey As UInteger(), UserKey As Byte())
            Dim A As UInteger, B As UInteger, C As UInteger, D As UInteger, T0 As UInteger, T1 As UInteger
            Dim K As UInteger() = pRoundKey

            Dim KC0 As UInteger = &H9E3779B9UI
            Dim KC1 As UInteger = &H3C6EF373
            Dim KC2 As UInteger = &H78DDE6E6
            Dim KC3 As UInteger = &HF1BBCDCCUI
            Dim KC4 As UInteger = &HE3779B99UI
            Dim KC5 As UInteger = &HC6EF3733UI
            Dim KC6 As UInteger = &H8DDE6E67UI
            Dim KC7 As UInteger = &H1BBCDCCF
            Dim KC8 As UInteger = &H3779B99E
            Dim KC9 As UInteger = &H6EF3733C
            Dim KC10 As UInteger = &HDDE6E678UI
            Dim KC11 As UInteger = &HBBCDCCF1UI
            Dim KC12 As UInteger = &H779B99E3
            Dim KC13 As UInteger = &HEF3733C6UI
            Dim KC14 As UInteger = &HDE6E678DUI
            Dim KC15 As UInteger = &HBCDCCF1BUI

            A = BitConverter.ToUInt32(UserKey, 0)
            B = BitConverter.ToUInt32(UserKey, 4)
            C = BitConverter.ToUInt32(UserKey, 8)
            D = BitConverter.ToUInt32(UserKey, 12)

            A = EndianChange(A)
            B = EndianChange(B)
            C = EndianChange(C)
            D = EndianChange(D)

            T0 = A + C - KC0
            T1 = B - D + KC0
            K(0) = SS0(GetB0(T0)) Xor SS1(GetB1(T0)) Xor SS2(GetB2(T0)) Xor SS3(GetB3(T0))
            K(1) = SS0(GetB0(T1)) Xor SS1(GetB1(T1)) Xor SS2(GetB2(T1)) Xor SS3(GetB3(T1))

            EncRoundKeyUpdate0(K, 2, A, B, C, D,
                KC1)
            EncRoundKeyUpdate1(K, 4, A, B, C, D,
                KC2)
            EncRoundKeyUpdate0(K, 6, A, B, C, D,
                KC3)
            EncRoundKeyUpdate1(K, 8, A, B, C, D,
                KC4)
            EncRoundKeyUpdate0(K, 10, A, B, C, D,
                KC5)
            EncRoundKeyUpdate1(K, 12, A, B, C, D,
                KC6)
            EncRoundKeyUpdate0(K, 14, A, B, C, D,
                KC7)
            EncRoundKeyUpdate1(K, 16, A, B, C, D,
                KC8)
            EncRoundKeyUpdate0(K, 18, A, B, C, D,
                KC9)
            EncRoundKeyUpdate1(K, 20, A, B, C, D,
                KC10)
            EncRoundKeyUpdate0(K, 22, A, B, C, D,
                KC11)
            EncRoundKeyUpdate1(K, 24, A, B, C, D,
                KC12)
            EncRoundKeyUpdate0(K, 26, A, B, C, D,
                KC13)
            EncRoundKeyUpdate1(K, 28, A, B, C, D,
                KC14)
            EncRoundKeyUpdate0(K, 30, A, B, C, D,
                KC15)
        End Sub

        ' Round function F and adding output of F to L.
        ' L0, L1 : left input values at each round
        ' R0, R1 : right input values at each round
        ' K : round keys at each round
        Private Shared Sub SeedRound(ByRef L0 As UInteger, ByRef L1 As UInteger, R0 As UInteger, R1 As UInteger, K As UInteger(), idx As Integer)
            Dim T0 As UInteger, T1 As UInteger
            T0 = R0 Xor K(0 + idx)
            T1 = R1 Xor K(1 + idx)
            T1 = T1 Xor T0
            T1 = SS0(GetB0(T1)) Xor SS1(GetB1(T1)) Xor SS2(GetB2(T1)) Xor SS3(GetB3(T1))
            T0 += T1
            T0 = SS0(GetB0(T0)) Xor SS1(GetB1(T0)) Xor SS2(GetB2(T0)) Xor SS3(GetB3(T0))
            T1 += T0
            T1 = SS0(GetB0(T1)) Xor SS1(GetB1(T1)) Xor SS2(GetB2(T1)) Xor SS3(GetB3(T1))
            T0 += T1
            L0 = L0 Xor T0
            L1 = L1 Xor T1
        End Sub

        Private Shared Sub SeedEncryptBlock(ByRef pData As Byte(), RoundKey As UInteger())
            Dim L0 As UInteger, L1 As UInteger, R0 As UInteger, R1 As UInteger
            Dim K As UInteger() = RoundKey

            ' Set up input values for first round
            L0 = BitConverter.ToUInt32(pData, 0)
            L1 = BitConverter.ToUInt32(pData, 4)
            R0 = BitConverter.ToUInt32(pData, 8)
            R1 = BitConverter.ToUInt32(pData, 12)

            ' Reorder for big endian 
            ' Because SEED use little endian order in default
            L0 = EndianChange(L0)
            L1 = EndianChange(L1)
            R0 = EndianChange(R0)
            R1 = EndianChange(R1)

            SeedRound(L0, L1, R0, R1, K, 0)
            ' Round 1
            SeedRound(R0, R1, L0, L1, K, 2)
            ' Round 2
            SeedRound(L0, L1, R0, R1, K, 4)
            ' Round 3
            SeedRound(R0, R1, L0, L1, K, 6)
            ' Round 4
            SeedRound(L0, L1, R0, R1, K, 8)
            ' Round 5
            SeedRound(R0, R1, L0, L1, K, 10)
            ' Round 6
            SeedRound(L0, L1, R0, R1, K, 12)
            ' Round 7
            SeedRound(R0, R1, L0, L1, K, 14)
            ' Round 8
            SeedRound(L0, L1, R0, R1, K, 16)
            ' Round 9
            SeedRound(R0, R1, L0, L1, K, 18)
            ' Round 10
            SeedRound(L0, L1, R0, R1, K, 20)
            ' Round 11
            SeedRound(R0, R1, L0, L1, K, 22)
            ' Round 12
            SeedRound(L0, L1, R0, R1, K, 24)
            ' Round 13
            SeedRound(R0, R1, L0, L1, K, 26)
            ' Round 14
            SeedRound(L0, L1, R0, R1, K, 28)
            ' Round 15
            SeedRound(R0, R1, L0, L1, K, 30)
            ' Round 16
            L0 = EndianChange(L0)
            L1 = EndianChange(L1)
            R0 = EndianChange(R0)
            R1 = EndianChange(R1)

            ' Copying output values from last round to pbData
            Buffer.BlockCopy(BitConverter.GetBytes(R0), 0, pData, 0, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(R1), 0, pData, 4, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(L0), 0, pData, 8, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(L1), 0, pData, 12, 4)
        End Sub

        ' Same as encrypt, except that round keys are applied in reverse order
        Private Shared Sub SeedDecryptBlock(ByRef pData As Byte(), RoundKey As UInteger())
            'DWORD L0, L1, R0, R1, T0, T1, *K = pdwRoundKey;
            Dim L0 As UInteger, L1 As UInteger, R0 As UInteger, R1 As UInteger
            Dim K As UInteger() = RoundKey

            ' Set up input values for first round
            L0 = BitConverter.ToUInt32(pData, 0)
            L1 = BitConverter.ToUInt32(pData, 4)
            R0 = BitConverter.ToUInt32(pData, 8)
            R1 = BitConverter.ToUInt32(pData, 12)

            ' Reorder for big endian
            L0 = EndianChange(L0)
            L1 = EndianChange(L1)
            R0 = EndianChange(R0)
            R1 = EndianChange(R1)

            SeedRound(L0, L1, R0, R1, K, 30)
            SeedRound(R0, R1, L0, L1, K, 28)
            SeedRound(L0, L1, R0, R1, K, 26)
            SeedRound(R0, R1, L0, L1, K, 24)
            SeedRound(L0, L1, R0, R1, K, 22)
            SeedRound(R0, R1, L0, L1, K, 20)
            SeedRound(L0, L1, R0, R1, K, 18)
            SeedRound(R0, R1, L0, L1, K, 16)
            SeedRound(L0, L1, R0, R1, K, 14)
            SeedRound(R0, R1, L0, L1, K, 12)
            SeedRound(L0, L1, R0, R1, K, 10)
            SeedRound(R0, R1, L0, L1, K, 8)
            SeedRound(L0, L1, R0, R1, K, 6)
            SeedRound(R0, R1, L0, L1, K, 4)
            SeedRound(L0, L1, R0, R1, K, 2)
            SeedRound(R0, R1, L0, L1, K, 0)

            L0 = EndianChange(L0)
            L1 = EndianChange(L1)
            R0 = EndianChange(R0)
            R1 = EndianChange(R1)

            Buffer.BlockCopy(BitConverter.GetBytes(R0), 0, pData, 0, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(R1), 0, pData, 4, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(L0), 0, pData, 8, 4)
            Buffer.BlockCopy(BitConverter.GetBytes(L1), 0, pData, 12, 4)
        End Sub

        Private Shared Sub XorByte(ByRef operand1 As Byte(), operand2 As Byte())
            For i As Integer = 0 To operand1.Length - 1 Step 4
                Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(operand1, i) Xor BitConverter.ToUInt32(operand2, i)), 0, operand1, i, 4)
            Next
        End Sub

        Public Shared Function Encrypt(Data1 As String) As String
            Dim Data As Byte() = Encoding.[Default].GetBytes(Data1)

            Dim nOutSize As Integer = 16

            Dim nInSize As Integer = Data.Length

            Dim OutData As Byte() = New Byte(nOutSize - 1) {}

            Buffer.BlockCopy(Data, 0, OutData, 0, nInSize)

            Dim RoundKey As UInteger() = New UInteger(31) {}
            Dim seedKey As Byte() = LoadConfig()
            SeedEncRoundKey(RoundKey, seedKey)

            ' CBC 모드 초기값 IV
            Dim PrevData As Byte() = New Byte(15) {}

            For i As Integer = 0 To nOutSize - 1 Step 16
                Dim DataBlock As Byte() = New Byte(15) {}
                Buffer.BlockCopy(OutData, i, DataBlock, 0, 16)

                SeedEncryptBlock(DataBlock, RoundKey)


                Buffer.BlockCopy(DataBlock, 0, OutData, i, 16)
            Next

            Dim OutData1 As String = Convert.ToBase64String(OutData)

            Return OutData1
        End Function

        Public Shared Function Decrypt(Data1 As String) As String
            Dim Data As Byte() = Convert.FromBase64String(Data1)

            Dim nOutSize As Integer = 16

            Dim nInSize As Integer = Data.Length

            Dim OutData As Byte() = New Byte(nOutSize - 1) {}

            Buffer.BlockCopy(Data, 0, OutData, 0, nInSize)

            Dim RoundKey As UInteger() = New UInteger(31) {}
            Dim seedKey As Byte() = LoadConfig()
            SeedEncRoundKey(RoundKey, seedKey)

            ' CBC 모드 초기값 IV
            Dim PrevData As Byte() = New Byte(15) {}

            For i As Integer = 0 To nOutSize - 1 Step 16
                Dim DataBlock As Byte() = New Byte(15) {}
                Buffer.BlockCopy(OutData, i, DataBlock, 0, 16)

                SeedDecryptBlock(DataBlock, RoundKey)


                Buffer.BlockCopy(DataBlock, 0, OutData, i, 16)
            Next

            Dim OutData1 As String = Encoding.[Default].GetString(OutData)

            Return OutData1
        End Function

        ' 20120312 by hong+ start
        Public Shared Function LoadConfig(p As String) As Byte()
            Dim sStr As String = ""

            Dim reader As New StreamReader(p, Encoding.GetEncoding("euc-kr"))
            sStr = reader.ReadToEnd()
            reader.Close()

            sStr = clearTag(sStr)

            Return toByteArray(sStr)

        End Function

        Public Shared Function clearTag(s As String) As String
            Dim stringbuilder As New StringBuilder()
            Dim i As Integer = s.IndexOf("{"c)
            Dim j As Integer = s.LastIndexOf("}"c)
            s = s.Substring(i + 1, j - i - 1)
            Dim split As [String]() = s.Split(","c)
            Dim k As Integer = split.Length
            For l As Integer = 0 To k - 1
                Dim s1 As String = split(1)
                If s1.Length = 4 AndAlso s1.StartsWith("0x") Then
                    stringbuilder.Append(s1.Substring(2))
                End If
            Next

            Return stringbuilder.ToString()
        End Function

        Public Shared Function toByteArray(s As String) As Byte()
            Dim encoding As New System.Text.UTF8Encoding()
            Return encoding.GetBytes(s)
        End Function

        Public Shared Function LoadConfig() As Byte()

            Dim sStr As String = ""



            sStr = "KEY = {0x7A,0xD5,0x4F,0x8F,0x08,0x1A,0x71,0xF2,0xE9,0xF3,0x4R,0x4G,0x0A,0xD4,0x0T,0x8D}"


            sStr = clearTag(sStr)

            Return toByteArray(sStr)

        End Function

        ' 20120312 by hong+ end
    End Class
End Namespace


