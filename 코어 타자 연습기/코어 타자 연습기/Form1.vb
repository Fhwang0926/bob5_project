Public Class Form1
    Dim start_time As Date
    Dim end_time As Date

    Private Sub start_btn_Click(sender As Object, e As EventArgs) Handles start_btn.Click
        If Timer1.Enabled Then
            Timer1.Enabled = False
            start_btn.Text = "시작"
            close_btn.Enabled = True
            TextBox1.Enabled = True
        Else
            Timer1.Enabled = True
            close_btn.Enabled = False
            start_btn.Text = "중지"
            TextBox1.Enabled = True
        End If

    End Sub
    Dim time_tmp As Integer = 0
    Private Sub time_Click(sender As Object, e As EventArgs) Handles Timer1.Tick
        time.Text = time_tmp & " 초"
        time_tmp += 1
        'Console.WriteLine(time_tmp)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Back Then
            Exit Sub
        End If
        TextBox1.Text = TextBox1.Text.ToUpper

        If Replace(TextBox1.Text, "-", "").Length Mod 5 = 0 And Replace(TextBox1.Text, "-", "").Length <> 30 Then
            TextBox1.Text += "-"
        End If
        TextBox1.Select(TextBox1.TextLength, 0)
        If e.KeyCode = Keys.Return Then
            'Button1_Click(sender, New System.EventArgs())
            If core.Text.Equals(TextBox1.Text) Then
                good.Text = Convert.ToInt32(good.Text) + 1
            Else
                good.Text = Convert.ToInt32(bad.Text) + 1
            End If
            TextBox1.Text = ""
            make_core()
        End If
    End Sub

    Private Sub close_btn_Click(sender As Object, e As EventArgs) Handles close_btn.Click
        End
    End Sub

    Private Sub make_core()
        core.Text = ""
        Randomize()
        For tmp = 1 To 30
            core.Text += Mid("abcdefghijk0123456789lmnopqrstuvwxyz", Int(Rnd() * 10) + 21, 1).ToUpper
            If tmp Mod 5 = 0 And tmp <> 30 Then
                core.Text += "-"
            End If
        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        make_core()
        TextBox1.Enabled = False
    End Sub
End Class
