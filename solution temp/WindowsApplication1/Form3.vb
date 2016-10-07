Imports System
Imports System.IO
Imports System.Text

Public Class Form3

    Dim full_name As String


    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub ok_btn_Click(sender As Object, e As EventArgs) Handles ok_btn.Click
        Dim last_name As String
        Dim tmp As Integer
        last_name = ""
        If r_docx.Checked = True Then
            last_name = ".docx"
        End If
        If r_hwp.Checked = True Then
            last_name = ".hwp"
        End If


        full_name = Trim(file_name.Text & last_name)
        full_name = Replace$(full_name, " ", "_")

        If String.IsNullOrEmpty(file_name.Text) Or String.IsNullOrEmpty(last_name) Then
            MsgBox("파일명을 확인 바랍니다", vbQuestion + vbYes, "확인")
        Else
            tmp = MsgBox("파일명 : " & full_name & " 으로 저장하시겠습니까?", vbQuestion + vbYesNo, "확인")
            If tmp = 6 Then
                Dim path_file As String

                path_file = "C:\Windows\tmp\" & full_name

                ' Create or overwrite the file.
                Dim fs As FileStream = File.Create(path_file)
                fs.Close()
                Form2.Show()
                Form2.reset_list()
                Form2.pro.StartInfo.FileName = path_file
                Form2.pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                Form2.pro.Start()
                Me.Hide()


            End If
        End If
    End Sub

    Private Sub r_hwp_CheckedChanged(sender As Object, e As EventArgs) Handles r_hwp.CheckedChanged
        r_hwp.BackColor = Color.Yellow
        r_docx.BackColor = Color.Transparent
    End Sub

    Private Sub r_docx_CheckedChanged(sender As Object, e As EventArgs) Handles r_docx.CheckedChanged
        r_docx.BackColor = Color.Yellow
        r_hwp.BackColor = Color.Transparent
    End Sub


End Class