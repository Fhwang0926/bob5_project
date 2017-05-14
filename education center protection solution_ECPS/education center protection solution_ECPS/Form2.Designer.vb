<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.state_label = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.프로그램PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.점검도구ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.개인정보파일탐색기ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.문서보안ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.종료EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.선택CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.프로그램정보ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.제작자PKTeamToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.제작ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.문의Hdh0926navercomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tool_main_label = New System.Windows.Forms.Label()
        Me.tool_bar = New System.Windows.Forms.ProgressBar()
        Me.tool_timer = New System.Windows.Forms.Timer(Me.components)
        Me.tool_list = New System.Windows.Forms.ListBox()
        Me.tool_bar_timer = New System.Windows.Forms.Timer(Me.components)
        Me.log = New System.Windows.Forms.ListBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CtxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_per2 = New System.Windows.Forms.CheckBox()
        Me.chk_per1 = New System.Windows.Forms.CheckBox()
        Me.chk_acount = New System.Windows.Forms.CheckBox()
        Me.chk_card = New System.Windows.Forms.CheckBox()
        Me.chk_phone = New System.Windows.Forms.CheckBox()
        Me.chk_mail = New System.Windows.Forms.CheckBox()
        Me.chk_ip_addr = New System.Windows.Forms.CheckBox()
        Me.chk_addr = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_txt = New System.Windows.Forms.CheckBox()
        Me.chk_word = New System.Windows.Forms.CheckBox()
        Me.chk_ppt = New System.Windows.Forms.CheckBox()
        Me.chk_exc = New System.Windows.Forms.CheckBox()
        Me.chk_hwp = New System.Windows.Forms.CheckBox()
        Me.scan_part_btn = New System.Windows.Forms.PictureBox()
        Me.scan_all_btn = New System.Windows.Forms.PictureBox()
        Me.pic6 = New System.Windows.Forms.PictureBox()
        Me.pic7 = New System.Windows.Forms.PictureBox()
        Me.pic8 = New System.Windows.Forms.PictureBox()
        Me.pic9 = New System.Windows.Forms.PictureBox()
        Me.pic5 = New System.Windows.Forms.PictureBox()
        Me.pic4 = New System.Windows.Forms.PictureBox()
        Me.pic3 = New System.Windows.Forms.PictureBox()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.tool_loding = New System.Windows.Forms.PictureBox()
        Me.tool_start_btn1 = New System.Windows.Forms.Button()
        Me.tool_start_btn = New System.Windows.Forms.Button()
        Me.per_btn = New System.Windows.Forms.Button()
        Me.drm_btn = New System.Windows.Forms.Button()
        Me.tool_btn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.scan_part_btn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scan_all_btn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tool_loding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.state_label})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(978, 25)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'state_label
        '
        Me.state_label.BackColor = System.Drawing.SystemColors.Window
        Me.state_label.Name = "state_label"
        Me.state_label.Size = New System.Drawing.Size(39, 20)
        Me.state_label.Text = "준비"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.프로그램PToolStripMenuItem, Me.선택CToolStripMenuItem, Me.프로그램정보ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(978, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '프로그램PToolStripMenuItem
        '
        Me.프로그램PToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.점검도구ToolStripMenuItem, Me.개인정보파일탐색기ToolStripMenuItem, Me.문서보안ToolStripMenuItem, Me.종료EToolStripMenuItem})
        Me.프로그램PToolStripMenuItem.Name = "프로그램PToolStripMenuItem"
        Me.프로그램PToolStripMenuItem.Size = New System.Drawing.Size(100, 24)
        Me.프로그램PToolStripMenuItem.Text = "프로그램(P)"
        '
        '점검도구ToolStripMenuItem
        '
        Me.점검도구ToolStripMenuItem.Name = "점검도구ToolStripMenuItem"
        Me.점검도구ToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.점검도구ToolStripMenuItem.Text = "점검도구(T)"
        '
        '개인정보파일탐색기ToolStripMenuItem
        '
        Me.개인정보파일탐색기ToolStripMenuItem.Name = "개인정보파일탐색기ToolStripMenuItem"
        Me.개인정보파일탐색기ToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.개인정보파일탐색기ToolStripMenuItem.Text = "개인정보파일 탐색기(I)"
        '
        '문서보안ToolStripMenuItem
        '
        Me.문서보안ToolStripMenuItem.Name = "문서보안ToolStripMenuItem"
        Me.문서보안ToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.문서보안ToolStripMenuItem.Text = "문서보안(P)"
        '
        '종료EToolStripMenuItem
        '
        Me.종료EToolStripMenuItem.Name = "종료EToolStripMenuItem"
        Me.종료EToolStripMenuItem.Size = New System.Drawing.Size(238, 26)
        Me.종료EToolStripMenuItem.Text = "종료(E)"
        '
        '선택CToolStripMenuItem
        '
        Me.선택CToolStripMenuItem.Name = "선택CToolStripMenuItem"
        Me.선택CToolStripMenuItem.Size = New System.Drawing.Size(71, 24)
        Me.선택CToolStripMenuItem.Text = "설정(C)"
        '
        '프로그램정보ToolStripMenuItem
        '
        Me.프로그램정보ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.제작자PKTeamToolStripMenuItem, Me.제작ToolStripMenuItem, Me.문의Hdh0926navercomToolStripMenuItem, Me.목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem})
        Me.프로그램정보ToolStripMenuItem.Name = "프로그램정보ToolStripMenuItem"
        Me.프로그램정보ToolStripMenuItem.Size = New System.Drawing.Size(134, 24)
        Me.프로그램정보ToolStripMenuItem.Text = "프로그램 정보(S)"
        '
        '제작자PKTeamToolStripMenuItem
        '
        Me.제작자PKTeamToolStripMenuItem.Name = "제작자PKTeamToolStripMenuItem"
        Me.제작자PKTeamToolStripMenuItem.Size = New System.Drawing.Size(1096, 26)
        Me.제작자PKTeamToolStripMenuItem.Text = "제작자 : PK Team"
        '
        '제작ToolStripMenuItem
        '
        Me.제작ToolStripMenuItem.Name = "제작ToolStripMenuItem"
        Me.제작ToolStripMenuItem.Size = New System.Drawing.Size(1096, 26)
        Me.제작ToolStripMenuItem.Text = "2016년 11월 제작"
        '
        '문의Hdh0926navercomToolStripMenuItem
        '
        Me.문의Hdh0926navercomToolStripMenuItem.Name = "문의Hdh0926navercomToolStripMenuItem"
        Me.문의Hdh0926navercomToolStripMenuItem.Size = New System.Drawing.Size(1096, 26)
        Me.문의Hdh0926navercomToolStripMenuItem.Text = "문의 : hdh0926@naver.com"
        '
        '목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem
        '
        Me.목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem.Name = "목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem"
        Me.목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem.Size = New System.Drawing.Size(1096, 26)
        Me.목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem.Text = "목적 : 학교 이외의 교육기관(학원, 교습소, 기타 등등)의 보안 수준 향상 및 개인정보 관리 수준 향상, 교육기관들의 문서 보안을 하는데 목적이" &
    " 있습니다"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Cornsilk
        Me.Label1.Location = New System.Drawing.Point(64, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(873, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "학교 이외의 교육기관에서 쉽게 보안 점검, 개인정보 파일 암호화, 문서보안을 지원하는 솔루션 입니다"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tool_main_label
        '
        Me.tool_main_label.AutoSize = True
        Me.tool_main_label.BackColor = System.Drawing.Color.White
        Me.tool_main_label.Font = New System.Drawing.Font("새굴림", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tool_main_label.Location = New System.Drawing.Point(350, 135)
        Me.tool_main_label.Name = "tool_main_label"
        Me.tool_main_label.Size = New System.Drawing.Size(471, 34)
        Me.tool_main_label.TabIndex = 10
        Me.tool_main_label.Text = "보안 점검을 지금 시작하세요"
        '
        'tool_bar
        '
        Me.tool_bar.Location = New System.Drawing.Point(282, 85)
        Me.tool_bar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_bar.Maximum = 1000
        Me.tool_bar.Name = "tool_bar"
        Me.tool_bar.Size = New System.Drawing.Size(609, 20)
        Me.tool_bar.Step = 1
        Me.tool_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tool_bar.TabIndex = 12
        '
        'tool_timer
        '
        '
        'tool_list
        '
        Me.tool_list.Font = New System.Drawing.Font("새굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tool_list.FormattingEnabled = True
        Me.tool_list.ItemHeight = 20
        Me.tool_list.Items.AddRange(New Object() {"- 바이러스 백신의 설치, 실행, 최신 업데이트 여부 점검", "- 운영체제, MS Office의 최신 보안 패치 설치 여부 점검", "- 한글의 최신 보안 패치 설치 여부 점검", "- 로그인 패스워드 안전성 여부 점검", "- 로그인 패스워드 2분기 1회 이상 변경 여부 점검", "- 화면 보호기 설정 여부 및 대기 시간 10분 설정 여부 점검", "- 사용자 공유 폴더 설정 여부 점검", "- USB 자동 실행 허용 여부 점검", "- 3개월 미사용 Active 프로그램 존재 여부 점검", "- Adobe PDF 프로그램의 최신 보안 패치 설치 여부"})
        Me.tool_list.Location = New System.Drawing.Point(222, 126)
        Me.tool_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_list.Name = "tool_list"
        Me.tool_list.Size = New System.Drawing.Size(586, 264)
        Me.tool_list.TabIndex = 14
        '
        'tool_bar_timer
        '
        Me.tool_bar_timer.Interval = 300
        '
        'log
        '
        Me.log.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.log.FormattingEnabled = True
        Me.log.Location = New System.Drawing.Point(11, 359)
        Me.log.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.log.Name = "log"
        Me.log.Size = New System.Drawing.Size(188, 56)
        Me.log.TabIndex = 16
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.CtxMenu
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Visible = True
        '
        'CtxMenu
        '
        Me.CtxMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CtxMenu.Name = "CtxMenu"
        Me.CtxMenu.Size = New System.Drawing.Size(67, 4)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.chk_per2)
        Me.GroupBox1.Controls.Add(Me.chk_per1)
        Me.GroupBox1.Controls.Add(Me.chk_acount)
        Me.GroupBox1.Controls.Add(Me.chk_card)
        Me.GroupBox1.Controls.Add(Me.chk_phone)
        Me.GroupBox1.Controls.Add(Me.chk_mail)
        Me.GroupBox1.Controls.Add(Me.chk_ip_addr)
        Me.GroupBox1.Controls.Add(Me.chk_addr)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(69, 359)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 80)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " 검색 패턴"
        '
        'chk_per2
        '
        Me.chk_per2.AutoSize = True
        Me.chk_per2.Location = New System.Drawing.Point(166, 47)
        Me.chk_per2.Name = "chk_per2"
        Me.chk_per2.Size = New System.Drawing.Size(134, 27)
        Me.chk_per2.TabIndex = 7
        Me.chk_per2.Text = "개인식별번호"
        Me.chk_per2.UseVisualStyleBackColor = True
        '
        'chk_per1
        '
        Me.chk_per1.AutoSize = True
        Me.chk_per1.Checked = True
        Me.chk_per1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_per1.Location = New System.Drawing.Point(26, 47)
        Me.chk_per1.Name = "chk_per1"
        Me.chk_per1.Size = New System.Drawing.Size(134, 27)
        Me.chk_per1.TabIndex = 6
        Me.chk_per1.Text = "주민등록번호"
        Me.chk_per1.UseVisualStyleBackColor = True
        '
        'chk_acount
        '
        Me.chk_acount.AutoSize = True
        Me.chk_acount.Checked = True
        Me.chk_acount.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_acount.Location = New System.Drawing.Point(537, 23)
        Me.chk_acount.Name = "chk_acount"
        Me.chk_acount.Size = New System.Drawing.Size(100, 27)
        Me.chk_acount.TabIndex = 5
        Me.chk_acount.Text = "계좌번호"
        Me.chk_acount.UseVisualStyleBackColor = True
        '
        'chk_card
        '
        Me.chk_card.AutoSize = True
        Me.chk_card.Location = New System.Drawing.Point(397, 23)
        Me.chk_card.Name = "chk_card"
        Me.chk_card.Size = New System.Drawing.Size(134, 27)
        Me.chk_card.TabIndex = 4
        Me.chk_card.Text = "신용카드번호"
        Me.chk_card.UseVisualStyleBackColor = True
        '
        'chk_phone
        '
        Me.chk_phone.AutoSize = True
        Me.chk_phone.Checked = True
        Me.chk_phone.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_phone.Location = New System.Drawing.Point(291, 23)
        Me.chk_phone.Name = "chk_phone"
        Me.chk_phone.Size = New System.Drawing.Size(100, 27)
        Me.chk_phone.TabIndex = 3
        Me.chk_phone.Text = "전화번호"
        Me.chk_phone.UseVisualStyleBackColor = True
        '
        'chk_mail
        '
        Me.chk_mail.AutoSize = True
        Me.chk_mail.Checked = True
        Me.chk_mail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_mail.Location = New System.Drawing.Point(185, 23)
        Me.chk_mail.Name = "chk_mail"
        Me.chk_mail.Size = New System.Drawing.Size(100, 27)
        Me.chk_mail.TabIndex = 2
        Me.chk_mail.Text = "전자우편"
        Me.chk_mail.UseVisualStyleBackColor = True
        '
        'chk_ip_addr
        '
        Me.chk_ip_addr.AutoSize = True
        Me.chk_ip_addr.Checked = True
        Me.chk_ip_addr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_ip_addr.Location = New System.Drawing.Point(98, 23)
        Me.chk_ip_addr.Name = "chk_ip_addr"
        Me.chk_ip_addr.Size = New System.Drawing.Size(81, 27)
        Me.chk_ip_addr.TabIndex = 1
        Me.chk_ip_addr.Text = "IP주소"
        Me.chk_ip_addr.UseVisualStyleBackColor = True
        '
        'chk_addr
        '
        Me.chk_addr.AutoSize = True
        Me.chk_addr.Location = New System.Drawing.Point(26, 23)
        Me.chk_addr.Name = "chk_addr"
        Me.chk_addr.Size = New System.Drawing.Size(66, 27)
        Me.chk_addr.TabIndex = 0
        Me.chk_addr.Text = "주소"
        Me.chk_addr.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.chk_txt)
        Me.GroupBox2.Controls.Add(Me.chk_word)
        Me.GroupBox2.Controls.Add(Me.chk_ppt)
        Me.GroupBox2.Controls.Add(Me.chk_exc)
        Me.GroupBox2.Controls.Add(Me.chk_hwp)
        Me.GroupBox2.Font = New System.Drawing.Font("맑은 고딕", 10.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(242, 351)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(685, 53)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "검색 파일"
        '
        'chk_txt
        '
        Me.chk_txt.AutoSize = True
        Me.chk_txt.Location = New System.Drawing.Point(365, 21)
        Me.chk_txt.Name = "chk_txt"
        Me.chk_txt.Size = New System.Drawing.Size(83, 27)
        Me.chk_txt.TabIndex = 4
        Me.chk_txt.Text = "메모장"
        Me.chk_txt.UseVisualStyleBackColor = True
        '
        'chk_word
        '
        Me.chk_word.AutoSize = True
        Me.chk_word.Checked = True
        Me.chk_word.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_word.Location = New System.Drawing.Point(293, 21)
        Me.chk_word.Name = "chk_word"
        Me.chk_word.Size = New System.Drawing.Size(66, 27)
        Me.chk_word.TabIndex = 3
        Me.chk_word.Text = "워드"
        Me.chk_word.UseVisualStyleBackColor = True
        '
        'chk_ppt
        '
        Me.chk_ppt.AutoSize = True
        Me.chk_ppt.Location = New System.Drawing.Point(170, 21)
        Me.chk_ppt.Name = "chk_ppt"
        Me.chk_ppt.Size = New System.Drawing.Size(117, 27)
        Me.chk_ppt.TabIndex = 2
        Me.chk_ppt.Text = "파워포인트"
        Me.chk_ppt.UseVisualStyleBackColor = True
        '
        'chk_exc
        '
        Me.chk_exc.AutoSize = True
        Me.chk_exc.Checked = True
        Me.chk_exc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_exc.Location = New System.Drawing.Point(98, 21)
        Me.chk_exc.Name = "chk_exc"
        Me.chk_exc.Size = New System.Drawing.Size(66, 27)
        Me.chk_exc.TabIndex = 1
        Me.chk_exc.Text = "엑셀"
        Me.chk_exc.UseVisualStyleBackColor = True
        '
        'chk_hwp
        '
        Me.chk_hwp.AutoSize = True
        Me.chk_hwp.Checked = True
        Me.chk_hwp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_hwp.Location = New System.Drawing.Point(26, 21)
        Me.chk_hwp.Name = "chk_hwp"
        Me.chk_hwp.Size = New System.Drawing.Size(66, 27)
        Me.chk_hwp.TabIndex = 0
        Me.chk_hwp.Text = "한글"
        Me.chk_hwp.UseVisualStyleBackColor = True
        '
        'scan_part_btn
        '
        Me.scan_part_btn.BackColor = System.Drawing.Color.White
        Me.scan_part_btn.BackgroundImage = Global.education_center_protection_solution_ECPS.My.Resources.Resources.scan_part_btn
        Me.scan_part_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.scan_part_btn.Location = New System.Drawing.Point(659, 395)
        Me.scan_part_btn.Name = "scan_part_btn"
        Me.scan_part_btn.Size = New System.Drawing.Size(307, 179)
        Me.scan_part_btn.TabIndex = 27
        Me.scan_part_btn.TabStop = False
        '
        'scan_all_btn
        '
        Me.scan_all_btn.BackColor = System.Drawing.Color.White
        Me.scan_all_btn.BackgroundImage = Global.education_center_protection_solution_ECPS.My.Resources.Resources.scan_all_btn
        Me.scan_all_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.scan_all_btn.Location = New System.Drawing.Point(175, 362)
        Me.scan_all_btn.Name = "scan_all_btn"
        Me.scan_all_btn.Size = New System.Drawing.Size(354, 175)
        Me.scan_all_btn.TabIndex = 26
        Me.scan_all_btn.TabStop = False
        '
        'pic6
        '
        Me.pic6.BackColor = System.Drawing.Color.White
        Me.pic6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic6.Location = New System.Drawing.Point(751, 225)
        Me.pic6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic6.Name = "pic6"
        Me.pic6.Size = New System.Drawing.Size(56, 22)
        Me.pic6.TabIndex = 22
        Me.pic6.TabStop = False
        '
        'pic7
        '
        Me.pic7.BackColor = System.Drawing.Color.White
        Me.pic7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic7.Location = New System.Drawing.Point(751, 244)
        Me.pic7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic7.Name = "pic7"
        Me.pic7.Size = New System.Drawing.Size(56, 22)
        Me.pic7.TabIndex = 23
        Me.pic7.TabStop = False
        '
        'pic8
        '
        Me.pic8.BackColor = System.Drawing.Color.White
        Me.pic8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic8.Location = New System.Drawing.Point(751, 265)
        Me.pic8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic8.Name = "pic8"
        Me.pic8.Size = New System.Drawing.Size(56, 22)
        Me.pic8.TabIndex = 24
        Me.pic8.TabStop = False
        '
        'pic9
        '
        Me.pic9.BackColor = System.Drawing.Color.White
        Me.pic9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic9.Location = New System.Drawing.Point(751, 288)
        Me.pic9.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic9.Name = "pic9"
        Me.pic9.Size = New System.Drawing.Size(56, 22)
        Me.pic9.TabIndex = 25
        Me.pic9.TabStop = False
        '
        'pic5
        '
        Me.pic5.BackColor = System.Drawing.Color.White
        Me.pic5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic5.Location = New System.Drawing.Point(751, 205)
        Me.pic5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic5.Name = "pic5"
        Me.pic5.Size = New System.Drawing.Size(56, 22)
        Me.pic5.TabIndex = 21
        Me.pic5.TabStop = False
        '
        'pic4
        '
        Me.pic4.BackColor = System.Drawing.Color.White
        Me.pic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic4.Location = New System.Drawing.Point(751, 186)
        Me.pic4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic4.Name = "pic4"
        Me.pic4.Size = New System.Drawing.Size(56, 22)
        Me.pic4.TabIndex = 20
        Me.pic4.TabStop = False
        '
        'pic3
        '
        Me.pic3.BackColor = System.Drawing.Color.White
        Me.pic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic3.Location = New System.Drawing.Point(751, 166)
        Me.pic3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(56, 22)
        Me.pic3.TabIndex = 19
        Me.pic3.TabStop = False
        '
        'pic2
        '
        Me.pic2.BackColor = System.Drawing.Color.White
        Me.pic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic2.Location = New System.Drawing.Point(751, 148)
        Me.pic2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(56, 22)
        Me.pic2.TabIndex = 18
        Me.pic2.TabStop = False
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.White
        Me.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic1.Location = New System.Drawing.Point(751, 128)
        Me.pic1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(56, 22)
        Me.pic1.TabIndex = 17
        Me.pic1.TabStop = False
        '
        'tool_loding
        '
        Me.tool_loding.BackColor = System.Drawing.Color.White
        Me.tool_loding.BackgroundImage = CType(resources.GetObject("tool_loding.BackgroundImage"), System.Drawing.Image)
        Me.tool_loding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tool_loding.Location = New System.Drawing.Point(242, 79)
        Me.tool_loding.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_loding.Name = "tool_loding"
        Me.tool_loding.Size = New System.Drawing.Size(29, 29)
        Me.tool_loding.TabIndex = 13
        Me.tool_loding.TabStop = False
        '
        'tool_start_btn1
        '
        Me.tool_start_btn1.BackColor = System.Drawing.Color.White
        Me.tool_start_btn1.FlatAppearance.BorderSize = 0
        Me.tool_start_btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tool_start_btn1.Image = CType(resources.GetObject("tool_start_btn1.Image"), System.Drawing.Image)
        Me.tool_start_btn1.Location = New System.Drawing.Point(806, 182)
        Me.tool_start_btn1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_start_btn1.Name = "tool_start_btn1"
        Me.tool_start_btn1.Size = New System.Drawing.Size(159, 159)
        Me.tool_start_btn1.TabIndex = 11
        Me.tool_start_btn1.UseVisualStyleBackColor = False
        '
        'tool_start_btn
        '
        Me.tool_start_btn.BackColor = System.Drawing.Color.White
        Me.tool_start_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tool_start_btn.FlatAppearance.BorderSize = 0
        Me.tool_start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tool_start_btn.Image = CType(resources.GetObject("tool_start_btn.Image"), System.Drawing.Image)
        Me.tool_start_btn.Location = New System.Drawing.Point(491, 198)
        Me.tool_start_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_start_btn.Name = "tool_start_btn"
        Me.tool_start_btn.Size = New System.Drawing.Size(159, 159)
        Me.tool_start_btn.TabIndex = 9
        Me.tool_start_btn.UseVisualStyleBackColor = False
        '
        'per_btn
        '
        Me.per_btn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.per_btn.BackgroundImage = CType(resources.GetObject("per_btn.BackgroundImage"), System.Drawing.Image)
        Me.per_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.per_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.per_btn.Location = New System.Drawing.Point(11, 135)
        Me.per_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.per_btn.Name = "per_btn"
        Me.per_btn.Size = New System.Drawing.Size(203, 56)
        Me.per_btn.TabIndex = 5
        Me.per_btn.Text = "개인정보탐색기"
        Me.per_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.per_btn.UseVisualStyleBackColor = True
        '
        'drm_btn
        '
        Me.drm_btn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.drm_btn.BackgroundImage = CType(resources.GetObject("drm_btn.BackgroundImage"), System.Drawing.Image)
        Me.drm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.drm_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.drm_btn.Location = New System.Drawing.Point(11, 198)
        Me.drm_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.drm_btn.Name = "drm_btn"
        Me.drm_btn.Size = New System.Drawing.Size(203, 56)
        Me.drm_btn.TabIndex = 4
        Me.drm_btn.Text = "문서보안"
        Me.drm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.drm_btn.UseVisualStyleBackColor = True
        '
        'tool_btn
        '
        Me.tool_btn.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tool_btn.BackgroundImage = CType(resources.GetObject("tool_btn.BackgroundImage"), System.Drawing.Image)
        Me.tool_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tool_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.tool_btn.Location = New System.Drawing.Point(11, 72)
        Me.tool_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_btn.Name = "tool_btn"
        Me.tool_btn.Size = New System.Drawing.Size(203, 56)
        Me.tool_btn.TabIndex = 3
        Me.tool_btn.Text = "보안 점검"
        Me.tool_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tool_btn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.education_center_protection_solution_ECPS.My.Resources.Resources.back
        Me.PictureBox1.Location = New System.Drawing.Point(202, 69)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(763, 354)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(978, 460)
        Me.Controls.Add(Me.scan_part_btn)
        Me.Controls.Add(Me.scan_all_btn)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pic6)
        Me.Controls.Add(Me.pic7)
        Me.Controls.Add(Me.pic8)
        Me.Controls.Add(Me.pic9)
        Me.Controls.Add(Me.pic5)
        Me.Controls.Add(Me.pic4)
        Me.Controls.Add(Me.pic3)
        Me.Controls.Add(Me.pic2)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.log)
        Me.Controls.Add(Me.tool_list)
        Me.Controls.Add(Me.tool_loding)
        Me.Controls.Add(Me.tool_bar)
        Me.Controls.Add(Me.tool_start_btn1)
        Me.Controls.Add(Me.tool_main_label)
        Me.Controls.Add(Me.tool_start_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.per_btn)
        Me.Controls.Add(Me.drm_btn)
        Me.Controls.Add(Me.tool_btn)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.Text = "ECPS:[Education Center Protection Solution]"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.scan_part_btn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.scan_all_btn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tool_loding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 프로그램PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 점검도구ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 개인정보파일탐색기ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 문서보안ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 종료EToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 선택CToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents state_label As ToolStripStatusLabel
    Friend WithEvents 프로그램정보ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 제작자PKTeamToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 제작ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 문의Hdh0926navercomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents drm_btn As Button
    Friend WithEvents per_btn As Button
    Friend WithEvents tool_btn As Button
    Friend WithEvents tool_start_btn As Button
    Friend WithEvents tool_main_label As Label
    Friend WithEvents 목적학교이외의교육기관학원교습소기타등등의보안수준향상및개인정보관리수준향상교육기관들이문서보안을하는데목적이있습니다ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tool_start_btn1 As Button
    Friend WithEvents tool_bar As ProgressBar
    Friend WithEvents tool_timer As Timer
    Friend WithEvents tool_loding As PictureBox
    Friend WithEvents tool_list As ListBox
    Friend WithEvents tool_bar_timer As Timer
    Friend WithEvents log As ListBox
    Friend WithEvents pic1 As PictureBox
    Friend WithEvents pic2 As PictureBox
    Friend WithEvents pic3 As PictureBox
    Friend WithEvents pic4 As PictureBox
    Friend WithEvents pic8 As PictureBox
    Friend WithEvents pic7 As PictureBox
    Friend WithEvents pic6 As PictureBox
    Friend WithEvents pic5 As PictureBox
    Friend WithEvents pic9 As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents CtxMenu As ContextMenuStrip
    Friend WithEvents scan_all_btn As PictureBox
    Friend WithEvents scan_part_btn As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chk_txt As CheckBox
    Friend WithEvents chk_word As CheckBox
    Friend WithEvents chk_ppt As CheckBox
    Friend WithEvents chk_exc As CheckBox
    Friend WithEvents chk_hwp As CheckBox
    Friend WithEvents chk_per2 As CheckBox
    Friend WithEvents chk_per1 As CheckBox
    Friend WithEvents chk_acount As CheckBox
    Friend WithEvents chk_card As CheckBox
    Friend WithEvents chk_phone As CheckBox
    Friend WithEvents chk_mail As CheckBox
    Friend WithEvents chk_ip_addr As CheckBox
    Friend WithEvents chk_addr As CheckBox
End Class
