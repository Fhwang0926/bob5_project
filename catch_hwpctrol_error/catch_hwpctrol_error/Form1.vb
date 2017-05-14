Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
    End Sub
    Private Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Declare Function SetActiveWindow Lib "user32" Alias "SetActiveWindow" (ByVal hwnd As Integer) As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Handle As IntPtr = FindWindow(vbNullString, "HwpCtrl")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
        ListBox1.SelectedItem = ListBox1.Items.Count - 1
        ListBox1.Items.Add("찾는중")
        'Console.WriteLine(Handle.ToString)
        If Not (Handle.Equals(IntPtr.Zero)) Then

            ' activate Notepad window
            If (SetActiveWindow(Handle)) Then
                'Console.WriteLine(Handle.ToString)
                ListBox1.Items.Add("찾았다" & "/PID : " & Handle.ToString)
                ' send key "Enter"
                SendKeys.Send("{ENTER}")

            End If
        End If
    End Sub
End Class
