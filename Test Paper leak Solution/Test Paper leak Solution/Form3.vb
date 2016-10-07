Imports System
Imports System.IO
Imports System.Text

Public Class Form3

    Dim full_name As String

    '최소 버튼
    Private Sub cancel_btn_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click
        Me.Hide()
        Form2.Show()
    End Sub
    '파일을 만들고 오픈까지
    Private Sub ok_btn_Click(sender As Object, e As EventArgs) Handles ok_btn.Click
        Dim last_name As String
        Dim tmp As Integer
        last_name = ""
        If r_docx.Checked = True Then
            last_name = ".docx" '파일 확장자 선택
        End If
        If r_hwp.Checked = True Then
            last_name = ".hwp" '파일 확장자 선택
        End If


        full_name = Trim(file_name.Text & last_name)
        full_name = Replace$(full_name, " ", "_") '공백 처리

        If String.IsNullOrEmpty(file_name.Text) Or String.IsNullOrEmpty(last_name) Then
            MsgBox("파일명을 확인 바랍니다", vbQuestion + vbYes, "확인")
        Else
            tmp = MsgBox("파일명 : " & full_name & " 으로 저장하시겠습니까?", vbQuestion + vbYesNo, "확인")
            If tmp = 6 Then
                Dim path_file As String = "C:\Windows\tpls"

                path_file = path_file & "\" & full_name

                ' Create or overwrite the file.

                If last_name.Equals(".hwp") Then
                    Dim exists As Boolean = System.IO.File.Exists("default.tmp")
                    '파일 존재 여부
                    If Not exists Then
                        If MsgBox("한글 파일을 만들 수 없습니다" & vbCrLf & "기본 템플릿 파일의 존재 여부를 확인해 주십시요" & "비어있는 한글 파일을 생성하시겠습니까?", vbQuestion + vbYesNo, "알림") = 6 Then
                            Dim fs As FileStream = File.Create(path_file) '빈 파일 생성
                            fs.Close()
                        Else
                            Return
                        End If
                    Else
                        Shell("cmd.exe /c copy default.tmp " & path_file, AppWinStyle.Hide, True) '시험 기본 템플릿 복사
                    End If

                Else
                    Dim fs As FileStream = File.Create(path_file) '빈 파일 생성
                    fs.Close()
                End If
                Try
                    Hide()
                    Form2.Show()
                    Form2.reset_list()
                    Form2.pro.StartInfo.FileName = path_file
                    Form2.pro.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                    Form2.pro.Start() '시르트에서 지정된 파일 시작
                    Form4.Show() '화면 찍기 방지 폼 활성화
                    Form4.Timer3.Enabled = True '촬영 방지 폼 활성화
                    Form4.Timer2.Enabled = True '워터마크 타이머 시작
                    Form2.Timer1.Enabled = True '프로세스가 종료 되었는지 검사하는 타이머 시작
                    'Form5.Show()
                Catch
                    MsgBox("파일을 생성하지 못했습니다 다시 시도하여 주세요", vbQuestion + vbYes, "알림")
                End Try


            End If
        End If
    End Sub
    '폼 종료
    Private Sub Form3_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Form2.Show()
        Me.Hide()


    End Sub
    '라디오 버튼 설정
    Private Sub r_hwp_CheckedChanged(sender As Object, e As EventArgs) Handles r_hwp.CheckedChanged
        r_hwp.BackColor = Color.Yellow
        r_docx.BackColor = Color.Transparent
    End Sub
    '라디오 버튼 설정
    Private Sub r_docx_CheckedChanged(sender As Object, e As EventArgs) Handles r_docx.CheckedChanged
        r_docx.BackColor = Color.Yellow
        r_hwp.BackColor = Color.Transparent
    End Sub
    '폼 로드시 변수 설정 및 기본 셋팅
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Location = New Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width() * 0.3, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height() * 0.35)
    End Sub
End Class