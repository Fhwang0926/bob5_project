Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        If ProgressBar1.Value = "100" Then '//만약 프로그래스바의 값이 100이 되면
            'Form2.Show() '//폼2를 띄운다
            'Hide()
            Timer1.Enabled = False
        Else '//아니면
            ProgressBar1.Value = ProgressBar1.Value + 1 '//프로그래스바의 값에 1을 추가한다.
        End If '//if문 끝
    End Sub
End Class