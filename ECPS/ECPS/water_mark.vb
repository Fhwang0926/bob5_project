Imports System.Environment
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading


Public Class water_mark
    Public switch As String = 1
    Private myWMI As Object, myObj As Object, Itm
    Private tmp As String '마크 값 변수

    '창 종료 방지
    Private Sub Form5_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True

    End Sub
    '기본 값 로드 및 컴퓨터 고유 값 처리
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TopMost = True ' 화면에 고정

        ' m = 1
        BackColor = Color.Red '컬러 지정
        Opacity = 0.24
        '위치 지정
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.3, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.2)
        '사이즈 지정
        Size = New System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.5, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.8)
        mark() '컴퓨터마다 고유한 값 불러오기
        '위치 잡고 가져온 컴터 고유 값 라벨에 뿌려주기
        label1.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.15, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.2)
        label2.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.15, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.4)
        label3.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.15, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.6)
        label4.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.15, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.8)
        label1.Text = tmp
        Label2.Text = tmp
        Label3.Text = tmp
        Label4.Text = tmp
        InitializeMyForm() '뒷 배경 바로 보이도록 함1



    End Sub
    '폼 배경 설정
    Public Sub InitializeMyForm()
        BackColor = Color.Black
        ' Make the background color of form display transparently.
        TransparencyKey = BackColor
    End Sub 'InitializeMyForm


    '마크에 값 넣어주기
    Private Sub mark()

        myWMI = GetObject("winmgmts:\\.\root\cimv2")
        myObj = myWMI.ExecQuery("SELECT * FROM " &
                 "Win32_NetworkAdapterConfiguration " &
                 "WHERE IPEnabled = True")
        Dim result As String
        result = Environment.UserName


        For Each Itm In myObj
            'MsgBox(Itm.IPAddress(0))
            'MsgBox(Itm.MACAddress)

            tmp = result & " : " & Itm.IPAddress(0) & " : " & Itm.MACAddress & ":" & Format(Now, "yyyy:MM:dd-hh:mm")
            'Console.WriteLine("test" & result & " : " & Itm.IPAddress(0) & " : " & Itm.MACAddress)

            Exit For
        Next

        If IsNothing(Itm) Then
            MsgBox("워터 마크를 위한 컴퓨터 고유 값을 식별할 수 없습니다")
            tmp = result & " : " & Format(Now, "yyyy:MM:dd-hh:mm | ") & "No User IP and MAC"
        End If

    End Sub
    Private Sub timer_mark_Tick(sender As Object, e As EventArgs) Handles timer_mark.Tick
        Console.WriteLine("doing")
        Dim localAll As Process() = Process.GetProcesses()
        Dim tmp As Boolean = 0
        For Each local In localAll
            If local.MainWindowTitle.Contains("Excel") Or local.MainWindowTitle.Contains("한컴오피스") Or
                local.MainWindowTitle.Contains("PowerPoint") Or local.MainWindowTitle.Contains("Word") Then
                Console.WriteLine("find! : " & local.MainWindowTitle.ToString)
                tmp = 1
                TopMost = True ' 화면에 고정

            End If

        Next
        If tmp Then
            TopMost = True
            Me.Show()
        Else
            Me.Hide()
        End If

    End Sub
End Class