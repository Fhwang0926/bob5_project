Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim dir As New IO.DirectoryInfo("C:\Windows\Downloaded Program Files")
        Dim fname As IO.FileInfo
        Dim ddir As IO.DirectoryInfo
        Dim re_cunt As Integer

        For Each ddir In dir.GetDirectories()

            re_cunt = re_cunt + 1

        Next


        Dim today As Date = Format(Now, "yyyy-MM-dd")
        Dim comp As Date
        Dim gap As TimeSpan

        For Each fname In dir.GetFiles()

            If fname.Extension.Equals(".ocx") Or fname.Extension.Equals(".dll") Then
                Console.WriteLine(Format(fname.LastAccessTime, "yyyy-MM-dd"))
                comp = Format(fname.LastAccessTime, "yyyy-MM-dd")
                gap = comp - today
                If gap.TotalDays > 90 Then
                    Console.WriteLine("del")
                Else
                    re_cunt = re_cunt + 1
                End If
            End If
        Next
        Console.WriteLine(re_cunt)
    End Sub
End Class
