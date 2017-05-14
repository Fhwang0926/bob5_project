Imports Microsoft.VisualBasic.Devices
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Network.DownloadFile(
    "http://provide.ahnlab.com/v3lite/v30/download/V3Lite_Setup.exe",
    "C:\test.exe")
    End Sub

End Class
