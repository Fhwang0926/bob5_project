Imports System.Net.Mail

Public Class Form1
    Dim contents = "  <!DOCTYPE html>
<html>

  <body>
   이 메일은 ECPS 발신용 입니다 <br/>
   교육기관 보호 솔루션이 설치된 관리자에게 보내는 메일입니다<br/>
   주기적인 보안 수준 및 개인정보관리 수준 결과 보고서가 포함됩니다<br/>


<br/><br/><br/><br/><br/><br/><br/><br/>
ECPS Manger 보냄<br/>
Fhwang dong-hwa / bluehdh0926@naver.com / 010 - 6559 - 6428 <br/>

  </body>
</html>"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Smtp As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp.UseDefaultCredentials = False
            Smtp.Credentials = New Net.NetworkCredential("bluehdh0926@gmail.com", "bluedeer7")
            Smtp.Port = 587
            Smtp.EnableSsl = True
            Smtp.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("hdh0926@naver.com")
            e_mail.To.Add("hdh0926@naver.com")
            e_mail.Subject = "ECPS 보안 수준 점검 결과 보고서"
            e_mail.IsBodyHtml = True 'Html 사용 여부.
            e_mail.Body = contents
            Smtp.Send(e_mail)
            MsgBox("Mail Sent")


        Catch t As Exception
            MsgBox(t.ToString)

        End Try

    End Sub

End Class
