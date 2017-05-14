<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class config
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(config))
        Me.set_xls = New System.Windows.Forms.CheckBox()
        Me.set_ppt = New System.Windows.Forms.CheckBox()
        Me.set_hwp = New System.Windows.Forms.CheckBox()
        Me.set_word = New System.Windows.Forms.CheckBox()
        Me.set_txt = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.set_mail_input = New System.Windows.Forms.TextBox()
        Me.set_mail_chk = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.set_addr = New System.Windows.Forms.CheckBox()
        Me.set_card = New System.Windows.Forms.CheckBox()
        Me.set_bank = New System.Windows.Forms.CheckBox()
        Me.set_ip = New System.Windows.Forms.CheckBox()
        Me.set_email = New System.Windows.Forms.CheckBox()
        Me.set_call = New System.Windows.Forms.CheckBox()
        Me.set_person = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.set_drm = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.set_mark = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.save_btn = New System.Windows.Forms.Button()
        Me.reset_config_btn = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.set_startup = New System.Windows.Forms.CheckBox()
        Me.set_exit = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'set_xls
        '
        Me.set_xls.AutoSize = True
        Me.set_xls.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_xls.Location = New System.Drawing.Point(259, 38)
        Me.set_xls.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_xls.Name = "set_xls"
        Me.set_xls.Size = New System.Drawing.Size(117, 24)
        Me.set_xls.TabIndex = 0
        Me.set_xls.Text = "엑셀(xls,xlsx)"
        Me.set_xls.UseVisualStyleBackColor = True
        '
        'set_ppt
        '
        Me.set_ppt.AutoSize = True
        Me.set_ppt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_ppt.Location = New System.Drawing.Point(698, 39)
        Me.set_ppt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_ppt.Name = "set_ppt"
        Me.set_ppt.Size = New System.Drawing.Size(175, 24)
        Me.set_ppt.TabIndex = 1
        Me.set_ppt.Text = "파워포인트(ppt,pptx)"
        Me.set_ppt.UseVisualStyleBackColor = True
        '
        'set_hwp
        '
        Me.set_hwp.AutoSize = True
        Me.set_hwp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_hwp.Location = New System.Drawing.Point(138, 38)
        Me.set_hwp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_hwp.Name = "set_hwp"
        Me.set_hwp.Size = New System.Drawing.Size(99, 24)
        Me.set_hwp.TabIndex = 2
        Me.set_hwp.Text = "한글(hwp)"
        Me.set_hwp.UseVisualStyleBackColor = True
        '
        'set_word
        '
        Me.set_word.AutoSize = True
        Me.set_word.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_word.Location = New System.Drawing.Point(536, 38)
        Me.set_word.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_word.Name = "set_word"
        Me.set_word.Size = New System.Drawing.Size(133, 24)
        Me.set_word.TabIndex = 3
        Me.set_word.Text = "워드(docx,doc)"
        Me.set_word.UseVisualStyleBackColor = True
        '
        'set_txt
        '
        Me.set_txt.AutoSize = True
        Me.set_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_txt.Location = New System.Drawing.Point(409, 38)
        Me.set_txt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_txt.Name = "set_txt"
        Me.set_txt.Size = New System.Drawing.Size(103, 24)
        Me.set_txt.TabIndex = 5
        Me.set_txt.Text = "텍스트(txt)"
        Me.set_txt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.set_mail_input)
        Me.GroupBox1.Controls.Add(Me.set_mail_chk)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(382, 74)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "보안점검"
        '
        'set_mail_input
        '
        Me.set_mail_input.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.set_mail_input.Location = New System.Drawing.Point(137, 30)
        Me.set_mail_input.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_mail_input.Name = "set_mail_input"
        Me.set_mail_input.Size = New System.Drawing.Size(240, 23)
        Me.set_mail_input.TabIndex = 6
        Me.set_mail_input.Text = "메일을 입력하세요"
        '
        'set_mail_chk
        '
        Me.set_mail_chk.AutoSize = True
        Me.set_mail_chk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.set_mail_chk.Location = New System.Drawing.Point(10, 32)
        Me.set_mail_chk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_mail_chk.Name = "set_mail_chk"
        Me.set_mail_chk.Size = New System.Drawing.Size(119, 21)
        Me.set_mail_chk.TabIndex = 5
        Me.set_mail_chk.Text = "결과 메일 수신"
        Me.set_mail_chk.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.set_addr)
        Me.GroupBox2.Controls.Add(Me.set_card)
        Me.GroupBox2.Controls.Add(Me.set_bank)
        Me.GroupBox2.Controls.Add(Me.set_ip)
        Me.GroupBox2.Controls.Add(Me.set_email)
        Me.GroupBox2.Controls.Add(Me.set_call)
        Me.GroupBox2.Controls.Add(Me.set_person)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.set_ppt)
        Me.GroupBox2.Controls.Add(Me.set_word)
        Me.GroupBox2.Controls.Add(Me.set_xls)
        Me.GroupBox2.Controls.Add(Me.set_txt)
        Me.GroupBox2.Controls.Add(Me.set_hwp)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 89)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(891, 120)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "개인정보 검색 범위 설정"
        '
        'set_addr
        '
        Me.set_addr.AutoSize = True
        Me.set_addr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_addr.Location = New System.Drawing.Point(731, 79)
        Me.set_addr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_addr.Name = "set_addr"
        Me.set_addr.Size = New System.Drawing.Size(60, 24)
        Me.set_addr.TabIndex = 13
        Me.set_addr.Text = "주소"
        Me.set_addr.UseVisualStyleBackColor = True
        '
        'set_card
        '
        Me.set_card.AutoSize = True
        Me.set_card.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_card.Location = New System.Drawing.Point(626, 79)
        Me.set_card.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_card.Name = "set_card"
        Me.set_card.Size = New System.Drawing.Size(92, 24)
        Me.set_card.TabIndex = 12
        Me.set_card.Text = "카드번호"
        Me.set_card.UseVisualStyleBackColor = True
        '
        'set_bank
        '
        Me.set_bank.AutoSize = True
        Me.set_bank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_bank.Location = New System.Drawing.Point(521, 80)
        Me.set_bank.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_bank.Name = "set_bank"
        Me.set_bank.Size = New System.Drawing.Size(92, 24)
        Me.set_bank.TabIndex = 11
        Me.set_bank.Text = "계좌번호"
        Me.set_bank.UseVisualStyleBackColor = True
        '
        'set_ip
        '
        Me.set_ip.AutoSize = True
        Me.set_ip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_ip.Location = New System.Drawing.Point(437, 79)
        Me.set_ip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_ip.Name = "set_ip"
        Me.set_ip.Size = New System.Drawing.Size(75, 24)
        Me.set_ip.TabIndex = 10
        Me.set_ip.Text = "IP주소"
        Me.set_ip.UseVisualStyleBackColor = True
        '
        'set_email
        '
        Me.set_email.AutoSize = True
        Me.set_email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_email.Location = New System.Drawing.Point(349, 79)
        Me.set_email.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_email.Name = "set_email"
        Me.set_email.Size = New System.Drawing.Size(76, 24)
        Me.set_email.TabIndex = 9
        Me.set_email.Text = "이메일"
        Me.set_email.UseVisualStyleBackColor = True
        '
        'set_call
        '
        Me.set_call.AutoSize = True
        Me.set_call.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_call.Location = New System.Drawing.Point(244, 79)
        Me.set_call.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_call.Name = "set_call"
        Me.set_call.Size = New System.Drawing.Size(92, 24)
        Me.set_call.TabIndex = 8
        Me.set_call.Text = "전화번호"
        Me.set_call.UseVisualStyleBackColor = True
        '
        'set_person
        '
        Me.set_person.AutoSize = True
        Me.set_person.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.set_person.Location = New System.Drawing.Point(137, 79)
        Me.set_person.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_person.Name = "set_person"
        Me.set_person.Size = New System.Drawing.Size(92, 24)
        Me.set_person.TabIndex = 6
        Me.set_person.Text = "주민번호"
        Me.set_person.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "검색 정보 : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "검색 파일 : "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.set_drm)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.set_mark)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 214)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(891, 127)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "개인정보파일 보호 / 문서 보안"
        '
        'set_drm
        '
        Me.set_drm.AutoSize = True
        Me.set_drm.Location = New System.Drawing.Point(85, 26)
        Me.set_drm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_drm.Name = "set_drm"
        Me.set_drm.Size = New System.Drawing.Size(234, 28)
        Me.set_drm.TabIndex = 5
        Me.set_drm.Text = "개인정보 파일 보호 사용"
        Me.set_drm.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(472, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(376, 39)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "문서 유출시 추적을 위한 워터마크를 사용합니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "아직 출력물에는 표시가 되지 않으며 모니터에 화면상으로 출력됩니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "사진 촬영으로 인한 유출시 추" &
    "적을 돕고자 사용하는 기능입니다"
        '
        'set_mark
        '
        Me.set_mark.AutoSize = True
        Me.set_mark.Location = New System.Drawing.Point(536, 26)
        Me.set_mark.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_mark.Name = "set_mark"
        Me.set_mark.Size = New System.Drawing.Size(229, 28)
        Me.set_mark.TabIndex = 3
        Me.set_mark.Text = "문서보안 워터마크 사용"
        Me.set_mark.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(82, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(252, 39)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "관리자가 설정한 암호를 사용합니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "암호를 이용하여 파일이 암호화/복호화 됩니다" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "설치시 입력한 암호는 관리자에게 문의하세요"
        '
        'save_btn
        '
        Me.save_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.save_btn.Location = New System.Drawing.Point(750, 346)
        Me.save_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.save_btn.Name = "save_btn"
        Me.save_btn.Size = New System.Drawing.Size(151, 39)
        Me.save_btn.TabIndex = 11
        Me.save_btn.Text = "저장"
        Me.save_btn.UseVisualStyleBackColor = True
        '
        'reset_config_btn
        '
        Me.reset_config_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.reset_config_btn.Location = New System.Drawing.Point(593, 346)
        Me.reset_config_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.reset_config_btn.Name = "reset_config_btn"
        Me.reset_config_btn.Size = New System.Drawing.Size(151, 39)
        Me.reset_config_btn.TabIndex = 12
        Me.reset_config_btn.Text = "초기화"
        Me.reset_config_btn.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.set_startup)
        Me.GroupBox4.Controls.Add(Me.set_exit)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(398, 10)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(503, 74)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "프로그램 설정"
        '
        'set_startup
        '
        Me.set_startup.AutoSize = True
        Me.set_startup.Location = New System.Drawing.Point(244, 30)
        Me.set_startup.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_startup.Name = "set_startup"
        Me.set_startup.Size = New System.Drawing.Size(191, 28)
        Me.set_startup.TabIndex = 1
        Me.set_startup.Text = "시작 프로그램 등록"
        Me.set_startup.UseVisualStyleBackColor = True
        '
        'set_exit
        '
        Me.set_exit.AutoSize = True
        Me.set_exit.Location = New System.Drawing.Point(24, 30)
        Me.set_exit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.set_exit.Name = "set_exit"
        Me.set_exit.Size = New System.Drawing.Size(172, 28)
        Me.set_exit.TabIndex = 0
        Me.set_exit.Text = "종료시 암호 입력"
        Me.set_exit.UseVisualStyleBackColor = True
        '
        'config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(912, 394)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.reset_config_btn)
        Me.Controls.Add(Me.save_btn)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "config"
        Me.ShowInTaskbar = False
        Me.Text = "ECPS 설정"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents set_xls As CheckBox
    Friend WithEvents set_ppt As CheckBox
    Friend WithEvents set_hwp As CheckBox
    Friend WithEvents set_word As CheckBox
    Friend WithEvents set_txt As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents set_addr As CheckBox
    Friend WithEvents set_card As CheckBox
    Friend WithEvents set_bank As CheckBox
    Friend WithEvents set_ip As CheckBox
    Friend WithEvents set_email As CheckBox
    Friend WithEvents set_call As CheckBox
    Friend WithEvents set_person As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents save_btn As Button
    Friend WithEvents reset_config_btn As Button
    Friend WithEvents set_mail_input As TextBox
    Friend WithEvents set_mail_chk As CheckBox
    Friend WithEvents set_drm As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents set_mark As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents set_startup As CheckBox
    Friend WithEvents set_exit As CheckBox
End Class
