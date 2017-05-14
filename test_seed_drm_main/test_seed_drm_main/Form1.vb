Imports System.Text
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports SeedCs
Imports System.IO

Public Class Form1
    Dim full_name As String
    Dim name_tmp As String = ""



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Console.WriteLine()


        'Console.WriteLine("cmd.exe /c ren " & OpenFileDialog1.FileName & " " & Mid(OpenFileDialog1.FileName, 1, InStr(1, OpenFileDialog1.FileName, ".")))
        full_name = TextBox1.Text
        name_tmp = Mid(TextBox1.Text, InStrRev(TextBox1.Text, "\") + 1)
        'MsgBox(name)
        Shell("cmd.exe /c ren """ & full_name & """ """ & name_tmp & ".txt""", vbHidden, True)
        Console.WriteLine("cmd.exe /c ren """ & full_name & """ """ & name_tmp & ".txt""")


        ' Specify a file to read from and to create.
        Dim pathSource As String = full_name & ".txt"



        Dim pathNew As String = full_name & ".ecps"
        Try
            Using fsSource As FileStream = New FileStream(pathSource,
            FileMode.Open, FileAccess.Read)


                Label1.Text = fsSource.Length

                ' Read the source file into a byte array.
                Dim data_tmp() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0
                'My.Computer.FileSystem.DeleteFile(pathSource)
                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(data_tmp, numBytesRead,
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While



                Dim str As String = ""
                Dim data_array(10000) As String
                Dim tmp As Integer = 0
                Dim count As Integer = 0
                For tmp = 0 To data_tmp.Length - 1
                    'Console.WriteLine(data_tmp(tmp).ToString)
                    str += data_tmp(tmp).ToString & "/"

                    If tmp <> 0 And (tmp Mod 100) = 0 Then
                        Console.WriteLine(str)
                        data_array(count) = str
                        count += 1
                        str = ""
                    End If
                    tmp += 1
                Next
                'Console.WriteLine(data_tmp.Length)
                Dim com As New SEED()
                For test = 0 To data_array.Length - 1
                    Try

                        data_array(test) = com.Enc(data_array(test), "1234567890123456")
                    Catch
                        'Console.WriteLine(data_array(test) & "??")
                        'Console.WriteLine(test)
                        Exit For
                    End Try
                Next
                'Console.WriteLine(str)
                For Each test In data_array
                    ' Console.WriteLine(test)
                Next


                'Console.WriteLine("Writing the data.")
                IO.File.WriteAllLines(full_name & ".ecps", data_array)



            End Using
        Catch ioEx As FileNotFoundException
            'Console.WriteLine(ioEx.Message)
        End Try



        RichTextBox1.Text = IO.File.ReadAllText(full_name & ".ecps")
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim read_data() = IO.File.ReadAllLines(full_name & ".ecps")
        Dim com As New SEED()
        For test = 0 To read_data.Length - 1
            Try
                read_data(test) = com.Dec(read_data(test), "1234567890123456")
                Console.WriteLine(read_data(test))
            Catch
                ' Console.WriteLine(read_data(test) & "??")
                'Console.WriteLine(test)
                Exit For
            End Try
        Next
        Dim data_tmp(100000) As Byte
        Dim count As Integer = 0
        Dim dd As Integer = 0
        For Each tmp In read_data
            Try
                Console.WriteLine(tmp)
                For Each tmp_tmp In Split(tmp, "/")

                    data_tmp(count) = tmp_tmp
                    count += 1
                    Console.WriteLine(data_tmp(count))
                Next
            Catch
                Console.WriteLine("null")
                dd += 1
                Exit For
            End Try
            ' Console.WriteLine(dd)
        Next


        IO.File.WriteAllBytes(full_name, data_tmp)
        'Console.WriteLine(data_tmp.Length)
    End Sub
End Class
