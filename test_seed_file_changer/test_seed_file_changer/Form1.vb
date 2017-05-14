
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text


Public Class form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main()
    End Sub



    '  Call this function to remove the key from memory after use for security
    <System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint:="RtlZeroMemory")>
    Public Shared Function ZeroMemory(Destination As IntPtr, Length As Integer) As Boolean
    End Function

    ' Function to Generate a 64 bits Key.
    Private Shared Function GenerateKey() As String
        ' Create an instance of Symetric Algorithm. Key and IV is generated automatically.
        Dim desCrypto As DESCryptoServiceProvider = DirectCast(DESCryptoServiceProvider.Create(), DESCryptoServiceProvider)

        ' Use the Automatically generated key for Encryption. 
        Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)
    End Function

    Private Shared Sub EncryptFile(sInputFilename As String, sOutputFilename As String, sKey As String)
        Dim fsInput As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)

        Dim fsEncrypted As New FileStream(sOutputFilename, FileMode.Create, FileAccess.Write)
        Dim DES As New DESCryptoServiceProvider()
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        Dim cryptostream As New CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write)

        Dim bytearrayinput As Byte() = New Byte(fsInput.Length - 1) {}
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
        fsInput.Close()
        fsEncrypted.Close()
    End Sub

    Private Shared Sub DecryptFile(sInputFilename As String, sOutputFilename As String, sKey As String)
        Dim DES As New DESCryptoServiceProvider()
        'A 64 bit key and IV is required for this provider.
        'Set secret key For DES algorithm.
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
        'Set initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create a file stream to read the encrypted file back.
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'Create a DES decryptor from the DES instance.
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'Create crypto stream set to read and do a 
        'DES decryption transform on incoming bytes.
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'Print the contents of the decrypted file.
        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd())
        fsDecrypted.Flush()
        fsDecrypted.Close()
    End Sub

    Private Shared Sub Main()
        ' Must be 64 bits, 8 bytes.
        ' Distribute this key to the user who will decrypt this file.
        Dim sSecretKey As String

        ' Get the Key for the file to Encrypt.
        sSecretKey = GenerateKey()

        ' For additional security Pin the key.
        Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)

        ' Encrypt the file.        
        EncryptFile("‪‪C:\Users\Fhwang\Desktop\doc.txt", "C:\Encrypted.txt", sSecretKey)

        ' Decrypt the file.
        DecryptFile("C:\Encrypted.txt", "C:\Decrypted.txt", sSecretKey)

        ' Remove the Key from memory. 
        ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
        gch.Free()
    End Sub

End Class

