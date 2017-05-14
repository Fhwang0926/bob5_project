Imports Microsoft.Win32
Imports System.Management
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Windows.Forms
Imports System
Imports System.Collections
Public Class Form1
    Dim path As String
    Dim hwp As Integer
    Dim hwp_version As String
    Public Shared Sub ProcessDirectory(targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ' Process the list of files found in the directory.
        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        ' Recurse into subdirectories of this directory.
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub 'ProcessDirectory

    ' Insert logic for processing found files here.
    Public Shared Sub ProcessFile(path As String)
        ''Console.WriteLine("Processed file '{0}'.", path)
        If InStr(1, path, "HncUpdate.exe") Then
            Console.WriteLine(path)
        End If
    End Sub 'ProcessFile
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey _
           ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", False)
        ' Retrieve a list of installed software products.
        ' This list also includes some software products that are not valid.
        Dim SubKeyNames() As String = Key.GetSubKeyNames()

        Dim strarray() As String = Nothing
        Dim cnt As Integer = 0

        ' Declare a variable to iterate through the retrieved list of 
        ' installed software products.
        Dim Index As Integer
        ' Declare a variable to hold the registry subkey that correspond
        ' to each retrieved software product.
        Dim SubKey As RegistryKey
        'Console.WriteLine("The following software products are installed on this computer:")
        'Console.WriteLine("")
        ' Iterate through the retrieved software products.
        For Index = 0 To Key.SubKeyCount - 1
            ' Open the registry subkey that corresponds to the current software product.
            ' SubKeyNames(Index) contains the name of the node that corresponds to the 
            ' current software product.
            SubKey = Registry.LocalMachine.OpenSubKey _
               ("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" + "\" _
                  + SubKeyNames(Index), False)
            ' Verify that the DisplayName exists. If the DisplayName does not exist, 
            ' return a null string. If the returned value is a null string, the 
            ' DisplayName does not exist, and the software product is not valid.
            If Not SubKey.GetValue("DisplayName", "") Is "" Then
                ' The current software product is valid.
                ' Display the DisplayName of this valid software product.

                'ListBox1.Items.Add(CType(SubKey.GetValue("DisplayName", ""), String))
                If Not (InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한글", 1) Or InStr(1, CType(SubKey.GetValue("DisplayName", ""), String), "한컴", 1)) = 0 Then
                    Console.WriteLine(CType(SubKey.GetValue("DisplayName", ""), String))
                    Dim InputString As String = CType(SubKey.GetValue("DisplayName", ""), String)
                    Dim Num As Integer
                    For i = Len(InputString) To 1 Step -1
                        If IsNumeric(Mid(InputString, i, 1)) Then
                            Num = Mid(InputString, i, 1) & Num
                        End If
                    Next i
                    hwp_version = Num
                    Console.WriteLine(hwp_version)
                    'MsgBox(CType(SubKey.GetValue("InstallLocation", ""), String))
                    Path = CType(SubKey.GetValue("InstallLocation", ""), String)
                    hwp = 1
                    Exit For
                End If


            End If
        Next


        If File.Exists(Path) Then
            ' This path is a file.
            ProcessFile(Path)
        Else
            If Directory.Exists(Path) Then
                ' This path is a directory.
                ProcessDirectory(Path)
            Else
                Console.WriteLine("{0} is not a valid file or directory.", Path)
            End If
        End If

    End Sub
End Class
