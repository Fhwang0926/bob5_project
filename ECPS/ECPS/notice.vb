Public Class notice


    Private Sub notice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.4, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.4)
        Dim ok As Integer = 0
        For Each index In Fix.chk
            'Console.WriteLine(index)
            If index = 1 Then
                ok += 1
            End If

        Next
        Label1.Text = "총 " & Fix.chk.Length - 2 & "개의 검사 항목 중"
        'Console.WriteLine(ok)
        Label2.Text = (ok).ToString & "건 양호"
        Label3.Text = (Fix.chk.Length - ok - 2) & "건 취약"
        Try
            Fix.ActiveForm.TopMost = False
        Catch
        End Try

        TopMost = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

End Class