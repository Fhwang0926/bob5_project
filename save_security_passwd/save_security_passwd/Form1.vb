Imports Microsoft.Win32.Registry
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Public Class Form1
    Private m_mainWmi As Object
    Private m_deviceLists As Collection
    Dim tempKey As Microsoft.Win32.RegistryKey
    Dim registryObject As Microsoft.Win32.RegistryKey = Nothing

    Sub TestDecoding(passwd As String)
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(
        My.Computer.FileSystem.SpecialDirectories.MyDocuments &
            "\cipherText.txt")
        Dim password As String = passwd
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            Console.WriteLine("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
    Sub TestEncoding(passwd As String, salt As String)
        Dim plainText As String = salt
        Dim password As String = passwd

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        Console.WriteLine("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText(
        My.Computer.FileSystem.SpecialDirectories.MyDocuments &
        "\cipherText.txt", cipherText, False)
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
End Class
Public NotInheritable Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function
    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub
    Public Function EncryptData(
    ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function
    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function
End Class
