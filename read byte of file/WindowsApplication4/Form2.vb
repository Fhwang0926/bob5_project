Imports System.IO.FileStream
Imports System.String
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim bytes = My.Computer.FileSystem.ReadAllBytes("C:/Documents and Settings/selfportrait.jpg")
        'ReadBinaryFile("C:\Users\Fhwang\Desktop\1.hwp")

        Dim path As String = "C:\Users\Fhwang\Desktop\00.hwp"

        Using file As New IO.FileStream(path, IO.FileMode.Open)
            Dim value As Integer = file.ReadByte()
            Dim count As Integer = 0
            Do Until count = 1860
                Console.WriteLine(value.ToString("X2"))
                count += 1
                Console.WriteLine(count)
                value = file.ReadByte()
            Loop
            file.Close()
            'value = "15"
            Console.WriteLine(Convert.ToString(value, 2))
            Dim tmp As Integer
            tmp = Convert.ToString(value, 2).ToString
            tmp = Microsoft.VisualBasic.Right(tmp, 1)
            Console.WriteLine(tmp)
        End Using
        '
        'Dim bytes As Byte() = IO.File.ReadAllBytes(path)
        'Dim hex As String() = Array.ConvertAll(bytes, Function(b) b.ToString("X2"))

        'Console.WriteLine(String.Join(" ", hex))
    End Sub


End Class
