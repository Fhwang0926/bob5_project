Imports NBitcoin

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' generate a random private key
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim privateKey As New Key()
        Dim publicKey As PubKey = privateKey.PubKey
        Console.WriteLine("public : " & publicKey.ToString)
        Console.WriteLine("private : " & privateKey.ToString)
        Console.WriteLine(publicKey.GetAddress(Network.Main))
        ' 1PUYsjwfNmX64wS368ZR5FMouTtUmvtmTY
        Console.WriteLine(publicKey.GetAddress(Network.TestNet))
        ' n3zWAo2eBnxLr3ueohXnuAa8mTVBhxmPhq
        Dim publicKeyHash = publicKey.Hash
        Console.WriteLine(publicKeyHash)
        ' f6889b21b5540353a29ed18c45ea0031280c42cf
        Dim mainNetAddress = publicKeyHash.GetAddress(Network.Main)
        Dim testNetAddress = publicKeyHash.GetAddress(Network.TestNet)
    End Sub
End Class
