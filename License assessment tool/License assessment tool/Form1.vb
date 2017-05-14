Imports Microsoft.VisualBasic
Imports Microsoft.Win32.Registry
' We import System.IO for files
Imports System.IO
' And System.Security.Cryptography for Hashes : MD5, SHA1, SHA256, ...
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim tmp As String = RichTextBox1.Text

            Microsoft.VisualBasic.Left(tmp, InStr(tmp, ".") - 1)
            Dim mail_len As Integer = Microsoft.VisualBasic.Left(tmp, InStr(tmp, "."))
            Dim mail = Microsoft.VisualBasic.Right(tmp, tmp.Length - InStr(tmp, "."))
            Dim last_day = StrReverse(Mid(mail, InStr(mail, "`") + 1, 8))
            Dim code = StrReverse(Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(mail, InStr(mail, "`") - 1), 12))
            Dim count As Integer = 1
            tmp = ""
            Do Until count = mail_len * 2 + 1
                If count Mod 2 = 0 Then
                    tmp += Mid(mail, count, 1)
                End If

                count += 1
            Loop
            mail = Microsoft.VisualBasic.Mid(tmp, InStr(tmp, "Z") + 1, InStr(tmp, "Q") - InStr(tmp, "Z") - 1) &
            "@" & Microsoft.VisualBasic.Right(tmp, tmp.Length - InStr(tmp, "Q")) & "." & Microsoft.VisualBasic.Left(tmp, InStr(tmp, "Z") - 1)

            TextBox1.Text = StrConv(mail, VbStrConv.Lowercase)
            TextBox2.Text = code
            TextBox3.Text = last_day
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("CC").SetValue("mail", StrConv(mail, VbStrConv.Lowercase))
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("CC").SetValue("code", code)
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("CC").SetValue("last_day", last_day)
            Dim [source] As String = EncryptSHA256Managed(code).ToString
            Using md5Hash As MD5 = MD5.Create()

                Dim hash As String = GetMd5Hash(md5Hash, source)
                MsgBox(hash)
                Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software").CreateSubKey("CC").SetValue("license", hash)
            End Using
        Catch
            MsgBox("유효한 라이선스가 아닙니다", vbYes, "경고")
        End Try
    End Sub
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash


    ' Verify a hash against a string.
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
    Public Function EncryptSHA256Managed(ByVal ClearString As String) As String
        Dim uEncode As New UnicodeEncoding()
        Dim bytClearString() As Byte = uEncode.GetBytes(ClearString)
        Dim sha As New _
        System.Security.Cryptography.SHA256Managed()
        Dim hash() As Byte = sha.ComputeHash(bytClearString)
        Console.WriteLine(Convert.ToBase64String(hash))
        Return Convert.ToBase64String(hash)

    End Function
End Class
