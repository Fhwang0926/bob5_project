Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32
Imports System.Management
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.ComponentModel.Component
Imports Microsoft.Win32.RegistryKey
Imports System.Collections
Imports System.Text.RegularExpressions
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Search_engin()
        ListBox1.Items.Clear()
        Dim str As Object = 1
        Do Until str = ""

            str = My.Computer.FileSystem.GetFiles(
           "C:\",
            FileIO.SearchOption.SearchAllSubDirectories, "*.hwp", "*.txt")
        Loop

        ' Add each image in the Pictures directory to list box.
        For Each file As String In
            My.Computer.FileSystem.GetFiles(
           "C:\",
            FileIO.SearchOption.SearchAllSubDirectories, "*.hwp", "*.txt")
            Application.DoEvents()
            Console.WriteLine(file)
            Me.ListBox1.Items.Add(file)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Search_engin()
    End Sub
End Class
