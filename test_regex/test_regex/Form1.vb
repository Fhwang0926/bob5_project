Imports System.Text.RegularExpressions

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        chk_pattern(RichTextBox1.Text)
    End Sub
    Private Sub chk_pattern(tmp_str As String) '공용으로 사용될 함수 선택한 내용 탐색

        Dim regexPattern As String
        Dim regex As Regex
        Dim regexMatches As MatchCollection
        Dim strSource As String
        strSource = tmp_str
        Dim re As Boolean = 0

        regexPattern = "([01][0-9]{5}[[:space:],~-]+[1-4][0-9]{6}|[2-9][0-9]{5}[[:space:],~-]+[1-2][0-9]{6})" ' 주민번호 정규식
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("주민번호 찾았다!!")
            ListBox1.Items.Add("주민번호 발견")
            re = 1
        End If
        regexPattern = "01[016789][-~.[:space:]][0-9]{3,4}[-~.[:space:]][0-9]{4}" ' 전화번호 정규식

        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("전화번호 찾았다!!")
            ListBox1.Items.Add("전화번호 발견")
            re = 1
        End If



        regexPattern = "(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((1[0-9]{2})|(2[0-4]\d)|(25[0-5])|(\d{1,2}))" 'ip주소
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine(" ip 주소 찾았다!!")
            ListBox1.Items.Add("IP주소 발견")
            re = 1
        End If


        regexPattern = "[\S]+(도|시)\s[\S]+(구|군)\s[\S]+(면|동).*" ' 주소 정규식
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("집주소 찾았다!!")
            ListBox1.Items.Add("집 주소 발견")
            re = 1
        End If



        regexPattern = "[34569][0-9]{3}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}[-~.[:space:]][0-9]{4}" '카드번호 정규식
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("카드번호 찾았다!!")
            ListBox1.Items.Add("카드번호 발견")
            re = 1
        End If


        regexPattern = "([0-9]{2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{6}|[0-9]{3}[-~.[:space:]]([0-9]{5,6}[-~.[:sp
ace:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{5}|[0-9]{2,3}[-~.[:space:]][0-9]{6}|[0-9]{2}[-~.[:sp
ace:]][0-9]{7}|[0-9]{2}[-~.[:space:]][0-9]{4,6}[-~.[:space:]][0-9]|[0-9]{5}[-~.[:space:]][0-9]{
3}[-~.[:space:]][0-9]{2}|[0-9]{2}[-~.[:space:]][0-9]{5}[-~.[:space:]][0-9]{3}|[0-9]{4}[-~.[:spa
ce:]][0-9]{4}[-~.[:space:]][0-9]{3}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{3}|[0-9]{
2}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{7})|[0-9]{4}[-~.[:space:]]([0-9]{3}[-~.[:space:]][0
-9]{6}|[0-9]{2}[-~.[:space:]][0-9]{6}[-~.[:space:]][0-9])|[0-9]{5}[-~.[:space:]][0-9]{2}[-~.[:s
pace:]][0-9]{6}|[0-9]{6}[-~.[:space:]][0-9]{2}[-~.[:space:]][0-9]{5,6})" '계좌번호 정규식
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("계좌번호 찾았다!!")
            ListBox1.Items.Add("계좌번호 발견")
            re = 1
        End If

        regexPattern = "(\S+)@([^\.\s]+)(?:\.([^\.\s]+))+" '이메일 정규식
        regex = New Regex(regexPattern)
        regexMatches = regex.Matches(strSource)
        If regexMatches.Count > 0 Then
            Console.WriteLine("이메일 찾았다!!")
            ListBox1.Items.Add("이메일 발견")
            re = 1
        End If





        If re Then
            MsgBox("개인정보 탐지")

        End If





    End Sub ' 정규식 패턴 매치
End Class
