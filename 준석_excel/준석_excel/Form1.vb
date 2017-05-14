Imports ExPar
Imports Microsoft.Office
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim test As Object = New Exc()
        Dim tmp = test.Pars("C:\Users\Fhwang\Desktop\123.xlsx")
        Console.WriteLine(tmp.ToString)
    End Sub
End Class
