Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
            'MessageBox.Show(sr.ReadToEnd)
            sr.Close()
            Label1.Text = OpenFileDialog1.FileName


        End If
    End Sub
End Class
