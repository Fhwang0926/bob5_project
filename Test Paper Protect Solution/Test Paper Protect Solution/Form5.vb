Imports System.Environment
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading


Public Class Form5
    Private host As String
    Private myWMI As Object, myObj As Object, Itm
    Private tmp As String '마크 값 변수
    ' Private m As Integer ' 화면 깜빡일 변수

    '깜빡일 용도로 만들었음 지금은 사용 안함
    'Private Sub Timer2_Tick(sender As Object, e As EventArgs)
    'If m Then
    '       Opacity = 0.2
    '      Thread.Sleep(1)
    '     Opacity = 0.1
    '    Thread.Sleep(1)
    'Opacity = 0.12
    'Thread.Sleep(1)
    'Opacity = 0.04
    'Thread.Sleep(1)
    'Opacity = 0.04
    'Thread.Sleep(1)
    '    Opacity = 0
    'Thread.Sleep(1)
    '   m = 0
    'Else
    '       Opacity = 0
    '      Thread.Sleep(1)
    '     Opacity = 0.1
    '    Thread.Sleep(1)
    'Opacity = 0.08
    'Thread.Sleep(1)
    'Opacity = 0.012
    'Thread.Sleep(1)
    'Opacity = 0.016
    'Thread.Sleep(1)
    '   Opacity = 0.2
    'Thread.Sleep(1)
    '  m = 1
    'End If
    'End Sub
    '창 종료 방지
    Private Sub Form5_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True

    End Sub
    '기본 값 로드 및 컴퓨터 고유 값 처리
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TopMost = True ' 화면에 고정

        ' m = 1
        BackColor = Color.Red '컬러 지정
        Opacity = 0.25 '기본 투명도 지정
        '위치 지정
        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.3, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.2)
        '사이즈 지정
        Size = New System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.5, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.8)
        mark() '컴퓨터마다 고유한 값 불러오기
        '위치 잡고 가져온 컴터 고유 값 라벨에 뿌려주기
        label1.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0)
        label2.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.2)
        label3.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.4)
        label4.Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.6)
        label1.Text = tmp
        label2.Text = tmp
        label3.Text = tmp
        label4.Text = tmp
        InitializeMyForm() '뒷 배경 바로 보이도록 함



    End Sub
    '폼 배경 설정
    Public Sub InitializeMyForm()
        BackColor = Color.Black
        ' Make the background color of form display transparently.
        TransparencyKey = BackColor
    End Sub 'InitializeMyForm
    '마크에 값 넣어주기
    Private Sub mark()
        host = Dns.GetHostEntry(Dns.GetHostName()).ToString
        myWMI = GetObject("winmgmts:\\.\root\cimv2")
        myObj = myWMI.ExecQuery("SELECT * FROM " &
                 "Win32_NetworkAdapterConfiguration " &
                 "WHERE IPEnabled = True")
        Dim result As String
        result = Dns.GetHostByName("LocalHost").HostName


        For Each Itm In myObj
            'MsgBox(Itm.IPAddress(0))
            'MsgBox(Itm.MACAddress)

            tmp = result & " : " & Itm.IPAddress(0) & " : " & Itm.MACAddress & vbCrLf & vbCrLf & Format(Now, "yyyy:MM:dd-hh:mm")
            'Console.WriteLine("test" & result & " : " & Itm.IPAddress(0) & " : " & Itm.MACAddress)

            Exit For
        Next

        If IsNothing(Itm) Then
            MsgBox("워터 마크를 위한 컴퓨터 고유 값을 식별할 수 없습니다")
            tmp = result & " : " & Format(Now, "yyyy:MM:dd-hh:mm | ") & "No User IP and MAC"
        End If

    End Sub

End Class