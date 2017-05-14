Imports System.IO
Imports System.Net.Mail



Public Class Form1
    Public Declare Function InternetGetConnectedState Lib "wininet" (ByRef dwFlags As Long, ByVal dwReserved As Long) As Long
    Private Sub txtDirPath_DragEnter(sender As Object, e As DragEventArgs) Handles textto.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub
    Private Sub txtDirPath_DragDrop(sender As Object, e As DragEventArgs) Handles textto.DragDrop
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            Dim strFiles() As String = e.Data.GetData(DataFormats.FileDrop)
            Me.textto.Clear()
            For Each sf In strFiles
                Convert.ToString(sf)
                Me.textto.Text = textto.Text & sf
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("bluehdh0926@gmail.com", "bluedeer7")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(textfrom.Text)
            e_mail.To.Add(textto.Text)
            e_mail.Subject = "test"
            e_mail.IsBodyHtml = False
            e_mail.Body = textmsg.Text
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub
    'BOOL InternetGetConnectedState(
    '      __out  LPDWORD lpdwFlags,
    '      __in   DWORD dwReserved
    '    );


    '인터넷 연결 모드 상수 
    Public Enum InternetConnectionStats As Integer
        INTERNET_CONNECTION_MODEM = 1
        INTERNET_CONNECTION_LAN = 2
        INTERNET_CONNECTION_PROXY = 4
        INTERNET_RAS_INSTALLED = 10
        INTERNET_CONNECTION_OFFLINE = 20
        INTERNET_CONNECTION_CONFIGURED = 40
    End Enum

    '인터넷 연결 체크 
    Dim rtnStr As Boolean
    Public Function IsConnectedToInternet(Optional ByRef pConnectMode As Integer = 2) As Boolean

        Dim flags As Long
        rtnStr = InternetGetConnectedState(flags, 0)
        pConnectMode = flags
        Return rtnStr
    End Function
    '---------------------------------------------------------------------------------------------------
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Button1.Click
        If Not IsConnectedToInternet() Then
            MessageBox.Show("인터넷에 연결되어 있지 않습니다.")
        Else
            MessageBox.Show("인터넷에 연결되어 있습니다.")
        End If
    End Sub
End Class