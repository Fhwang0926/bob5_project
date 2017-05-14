Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Timer1.Enabled Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ListBox1.Items.Clear()
        Dim localAll As Process() = Process.GetProcesses()
        For Each local In localAll
            If local.MainWindowTitle.Contains("Excel") Or local.MainWindowTitle.Contains("한글") Or
                local.MainWindowTitle.Contains("PowerPoint") Or local.MainWindowTitle.Contains("Word") Then
                Console.WriteLine("find! : " & local.MainWindowTitle.ToString)
                ListBox1.Items.Add(local.MainWindowTitle.ToString)
            End If
        Next

    End Sub


End Class
