
Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports SeedCs

Public Class Form1


    Private Sub btEncrypt_Click(sender As Object, e As EventArgs) Handles btEncrypt.Click
        Dim Com As New SEED()
        txtSeed.Text = Com.Enc(txtOringin.Text, "BFEBFBFF000406E3")


    End Sub

    Private Sub btDecrypt_Click(sender As Object, e As EventArgs) Handles btDecrypt.Click
        Dim Com As New SEED()
        txtSeed.Text = Com.Dec(txtSeed.Text, "BFEBFBFF000406E3")


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim com As New SEED()
        MsgBox(com.Dec("MPTiwyIsZ89mmtAYuZ321Q==", "BFEBFBFF000406E3"))
    End Sub
End Class

