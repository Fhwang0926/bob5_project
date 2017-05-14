Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If Math.Abs(MousePosition.X - (PictureBox1.Location.X + PictureBox1.Height / 2)) < PictureBox1.Width / 2 And Math.Abs(MousePosition.Y - (PictureBox1.Location.Y + PictureBox1.Height / 2)) < PictureBox1.Height / 2 Then


            MsgBox("test")
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

    End Sub




End Class
