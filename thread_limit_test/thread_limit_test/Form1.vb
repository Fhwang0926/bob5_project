Imports System.Threading
Public Class Form1
    Dim Thread1 As New System.Threading.Thread(AddressOf ThreadFuction1) '스레드1 생성 
    Dim Thread2 As New System.Threading.Thread(AddressOf ThreadFuction2) '스레드1 생성 
    Dim Thread3 As New System.Threading.Thread(AddressOf ThreadFuction3) '스레드1 생성 
    Dim Thread4 As New System.Threading.Thread(AddressOf ThreadFuction4) '스레드1 생성 
    Dim Thread5 As New System.Threading.Thread(AddressOf ThreadFuction5) '스레드1 생성 
    Dim Thread6 As New System.Threading.Thread(AddressOf ThreadFuction6) '스레드1 생성 
    Dim Thread7 As New System.Threading.Thread(AddressOf ThreadFuction7) '스레드1 생성 
    Dim Thread8 As New System.Threading.Thread(AddressOf ThreadFuction8) '스레드1 생성 
    Dim Thread9 As New System.Threading.Thread(AddressOf ThreadFuction9) '스레드1 생성 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Thread1.Start()
        Thread2.Start()
        Thread3.Start()
        Thread4.Start()
        Thread5.Start()
        Thread6.Start()
        Thread7.Start()
        Thread8.Start()
        Thread9.Start()
    End Sub
    Private Sub ThreadFuction3()
        For Index = 1 To 10000000

            Console.WriteLine("3:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction1()
        For Index = 1 To 10000000

            Console.WriteLine("1:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction2()
        For Index = 1 To 10000000

            Console.WriteLine("2:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction4()
        For Index = 1 To 10000000

            Console.WriteLine("4:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction5()
        For Index = 1 To 10000000

            Console.WriteLine("5:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction6()
        For Index = 1 To 10000000

            Console.WriteLine("6:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction7()
        For Index = 1 To 10000000

            Console.WriteLine("7:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction8()
        For Index = 1 To 10000000

            Console.WriteLine("8:" & Index)
        Next


    End Sub
    Private Sub ThreadFuction9()
        For Index = 1 To 10000000

            Console.WriteLine("9:" & Index)
        Next

    End Sub
End Class
