Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "WU_checker"
        ListBox1.Items.Clear()
    End Sub
    Dim strInput As String
    Private Sub checker_update()
        Dim updateSession = CreateObject("Microsoft.Update.Session")
        updateSession.ClientApplicationID = "MSDN Sample Script"

        Dim updateSearcher = updateSession.CreateUpdateSearcher()

        ListBox1.Items.Add("Searching for updates...")

        Dim searchResult = updateSearcher.Search("IsInstalled=0 and Type='Software' and IsHidden=0")

        ListBox1.Items.Add("List of applicable items on the machine:")

        For I = 0 To searchResult.Updates.Count - 1
            Dim update = searchResult.Updates.Item(I)
            ListBox1.Items.Add(I + 1 & "> " & update.Title)
        Next

        If searchResult.Updates.Count = 0 Then
            ListBox1.Items.Add("There are no applicable updates.")
            Exit Sub
        End If
        ListBox1.Items.Add("Creating collection of updates to download:")

        Dim updatesToDownload = CreateObject("Microsoft.Update.UpdateColl")

        For I = 0 To searchResult.Updates.Count - 1
            Dim update = searchResult.Updates.Item(I)
            Dim addThisUpdate As Boolean
            addThisUpdate = False
            If update.InstallationBehavior.CanRequestUserInput = True Then
                ListBox1.Items.Add(I + 1 & "> skipping: " & update.Title &
                " because it requires user input")
            Else
                If update.EulaAccepted = False Then
                    ListBox1.Items.Add(I + 1 & "> note: " & update.Title &
                    " has a license agreement that must be accepted:")
                    ListBox1.Items.Add(update.EulaText)
                    ListBox1.Items.Add("Do you accept this license agreement? (Y/N)")

                    strInput = "y"

                    If (strInput = "Y" Or strInput = "y") Then
                        update.AcceptEula()
                        addThisUpdate = True
                    Else
                        ListBox1.Items.Add(I + 1 & "> skipping: " & update.Title &
                        " because the license agreement was declined")
                    End If
                Else
                    addThisUpdate = True
                End If
            End If
            If addThisUpdate = True Then
                ListBox1.Items.Add(I + 1 & "> adding: " & update.Title)
                updatesToDownload.Add(update)
            End If
        Next

        If updatesToDownload.Count = 0 Then
            ListBox1.Items.Add("All applicable updates were skipped.")
            Exit Sub
        End If

        ListBox1.Items.Add("Downloading updates...")

        Dim downloader = updateSession.CreateUpdateDownloader()
        downloader.Updates = updatesToDownload
        downloader.Download()

        Dim updatesToInstall = CreateObject("Microsoft.Update.UpdateColl")

        Dim rebootMayBeRequired As Boolean
        rebootMayBeRequired = False

        ListBox1.Items.Add("Successfully downloaded updates:")

        For I = 0 To searchResult.Updates.Count - 1
            Dim update = searchResult.Updates.Item(I)
            If update.IsDownloaded = True Then
                ListBox1.Items.Add(I + 1 & "> " & update.Title)
                updatesToInstall.Add(update)
                If update.InstallationBehavior.RebootBehavior > 0 Then
                    rebootMayBeRequired = True
                End If
            End If
        Next

        If updatesToInstall.Count = 0 Then
            ListBox1.Items.Add("No updates were successfully downloaded.")

        End If

        If rebootMayBeRequired = True Then
            ListBox1.Items.Add(vbCrLf & "These updates may require a reboot.")
        End If

        ListBox1.Items.Add("Would you like to install updates now? (Y/N)")

        strInput = "n"


        If (strInput = "Y" Or strInput = "y") Then
            ListBox1.Items.Add("Installing updates...")
            Dim installer = updateSession.CreateUpdateInstaller()
            installer.Updates = updatesToInstall
            Dim installationResult = installer.Install()

            'Output results of install
            ListBox1.Items.Add("Installation Result: " &
            installationResult.ResultCode)
            ListBox1.Items.Add("Reboot Required: " &
    installationResult.RebootRequired)
            ListBox1.Items.Add("Listing of updates installed " &
    "and individual installation results:")

            For I = 0 To updatesToInstall.Count - 1
                ListBox1.Items.Add(I + 1 & "> " & updatesToInstall.Item(I).Title & ": " & installationResult.GetUpdateResult(I).ResultCode)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        checker_update()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ListBox1.Items.Add("test")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not Timer1.Enabled Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub
End Class
