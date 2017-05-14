Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For tmp = 1 To 10
            CheckedListBox1.Items.Add("test" & tmp)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(CheckedListBox1.Items(0))





        'For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
        ' CheckedListBox1.SetItemCheckState(idx, CheckState.Checked)
        ' Next

        '        MsgBox("All checked items")
        '
        '        For idx As Integer = 0 To CheckedListBox1.Items.Count - 1
        'CheckedListBox1.SetItemCheckState(idx, CheckState.Unchecked)
        'Next


        'CheckedListBox1.Items.RemoveAt(0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim index As Integer = 0
        Dim t As Integer = CheckedListBox1.CheckedItems.Count
        Do Until t < 1
            Console.WriteLine(CheckedListBox1.Items.IndexOf(CheckedListBox1.CheckedItems(index)))
            CheckedListBox1.Items.RemoveAt(CheckedListBox1.Items.IndexOf(CheckedListBox1.CheckedItems(index)))
            t = CheckedListBox1.CheckedItems.Count
        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim index As Integer = 0

        Dim t As Integer = CheckedListBox1.CheckedItems.Count
        Do Until t < 1
            Console.WriteLine(CheckedListBox1.Items.IndexOf(CheckedListBox1.CheckedItems(Index)))
            CheckedListBox1.Items.Add(CheckedListBox1.Items(CheckedListBox1.Items.IndexOf(CheckedListBox1.CheckedItems(index))) & ".ecps")
            CheckedListBox1.Items.RemoveAt(CheckedListBox1.Items.IndexOf(CheckedListBox1.CheckedItems(index)))

            t = CheckedListBox1.CheckedItems.Count
        Loop


    End Sub
End Class
