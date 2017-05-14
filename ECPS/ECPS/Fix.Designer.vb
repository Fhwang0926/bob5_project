<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fix
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fix))
        Me.tool_list = New System.Windows.Forms.ListBox()
        Me.tool_bar = New System.Windows.Forms.ProgressBar()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.log = New System.Windows.Forms.ListBox()
        Me.tool_btn = New System.Windows.Forms.PictureBox()
        Me.pic6 = New System.Windows.Forms.PictureBox()
        Me.pic7 = New System.Windows.Forms.PictureBox()
        Me.pic8 = New System.Windows.Forms.PictureBox()
        Me.pic9 = New System.Windows.Forms.PictureBox()
        Me.pic5 = New System.Windows.Forms.PictureBox()
        Me.pic4 = New System.Windows.Forms.PictureBox()
        Me.pic3 = New System.Windows.Forms.PictureBox()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tool_loding = New System.Windows.Forms.PictureBox()
        Me.tool_bar_timer = New System.Windows.Forms.Timer(Me.components)
        Me.timer_start = New System.Windows.Forms.Timer(Me.components)
        CType(Me.tool_btn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.tool_loding, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tool_list
        '
        Me.tool_list.Font = New System.Drawing.Font("새굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tool_list.FormattingEnabled = True
        Me.tool_list.ItemHeight = 16
        Me.tool_list.Items.AddRange(New Object() {"- 바이러스 백신의 설치, 실행, 최신 업데이트 여부 점검", "- 운영체제, MS Office의 최신 보안 패치 설치 여부 점검", "- 한글의 최신 보안 패치 설치 여부 점검", "- 로그인 패스워드 안전성 여부 점검", "- 로그인 패스워드 2분기 1회 이상 변경 여부 점검", "- 화면 보호기 설정 여부 및 대기 시간 10분 설정 여부 점검", "- 사용자 공유 폴더 설정 여부 점검", "- USB 자동 실행 허용 여부 점검", "- 3개월 미사용 Active 프로그램 존재 여부 점검"})
        Me.tool_list.Location = New System.Drawing.Point(17, 71)
        Me.tool_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_list.Name = "tool_list"
        Me.tool_list.Size = New System.Drawing.Size(654, 196)
        Me.tool_list.TabIndex = 27
        '
        'tool_bar
        '
        Me.tool_bar.Location = New System.Drawing.Point(61, 28)
        Me.tool_bar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_bar.Maximum = 1000
        Me.tool_bar.Name = "tool_bar"
        Me.tool_bar.Size = New System.Drawing.Size(844, 18)
        Me.tool_bar.Step = 1
        Me.tool_bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tool_bar.TabIndex = 26
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("맑은 고딕", 12.0!)
        Me.RichTextBox1.Location = New System.Drawing.Point(17, 271)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox1.Size = New System.Drawing.Size(654, 96)
        Me.RichTextBox1.TabIndex = 39
        Me.RichTextBox1.Text = ""
        '
        'log
        '
        Me.log.FormattingEnabled = True
        Me.log.ItemHeight = 12
        Me.log.Location = New System.Drawing.Point(676, 271)
        Me.log.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.log.Name = "log"
        Me.log.Size = New System.Drawing.Size(230, 100)
        Me.log.TabIndex = 40
        '
        'tool_btn
        '
        Me.tool_btn.BackgroundImage = Global.ECPS.My.Resources.Resources.stop_btn
        Me.tool_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tool_btn.Location = New System.Drawing.Point(676, 71)
        Me.tool_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_btn.Name = "tool_btn"
        Me.tool_btn.Size = New System.Drawing.Size(229, 194)
        Me.tool_btn.TabIndex = 41
        Me.tool_btn.TabStop = False
        '
        'pic6
        '
        Me.pic6.BackColor = System.Drawing.Color.White
        Me.pic6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic6.Location = New System.Drawing.Point(620, 151)
        Me.pic6.Name = "pic6"
        Me.pic6.Size = New System.Drawing.Size(49, 18)
        Me.pic6.TabIndex = 33
        Me.pic6.TabStop = False
        '
        'pic7
        '
        Me.pic7.BackColor = System.Drawing.Color.White
        Me.pic7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic7.Location = New System.Drawing.Point(620, 166)
        Me.pic7.Name = "pic7"
        Me.pic7.Size = New System.Drawing.Size(49, 18)
        Me.pic7.TabIndex = 34
        Me.pic7.TabStop = False
        '
        'pic8
        '
        Me.pic8.BackColor = System.Drawing.Color.White
        Me.pic8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic8.Location = New System.Drawing.Point(620, 183)
        Me.pic8.Name = "pic8"
        Me.pic8.Size = New System.Drawing.Size(49, 18)
        Me.pic8.TabIndex = 35
        Me.pic8.TabStop = False
        '
        'pic9
        '
        Me.pic9.BackColor = System.Drawing.Color.White
        Me.pic9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic9.Location = New System.Drawing.Point(620, 201)
        Me.pic9.Name = "pic9"
        Me.pic9.Size = New System.Drawing.Size(49, 18)
        Me.pic9.TabIndex = 36
        Me.pic9.TabStop = False
        '
        'pic5
        '
        Me.pic5.BackColor = System.Drawing.Color.White
        Me.pic5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic5.Location = New System.Drawing.Point(620, 135)
        Me.pic5.Name = "pic5"
        Me.pic5.Size = New System.Drawing.Size(49, 18)
        Me.pic5.TabIndex = 32
        Me.pic5.TabStop = False
        '
        'pic4
        '
        Me.pic4.BackColor = System.Drawing.Color.White
        Me.pic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic4.Location = New System.Drawing.Point(620, 119)
        Me.pic4.Name = "pic4"
        Me.pic4.Size = New System.Drawing.Size(49, 18)
        Me.pic4.TabIndex = 31
        Me.pic4.TabStop = False
        '
        'pic3
        '
        Me.pic3.BackColor = System.Drawing.Color.White
        Me.pic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic3.Location = New System.Drawing.Point(620, 103)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(49, 18)
        Me.pic3.TabIndex = 30
        Me.pic3.TabStop = False
        '
        'pic2
        '
        Me.pic2.BackColor = System.Drawing.Color.White
        Me.pic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic2.Location = New System.Drawing.Point(620, 87)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(49, 18)
        Me.pic2.TabIndex = 29
        Me.pic2.TabStop = False
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.White
        Me.pic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pic1.Location = New System.Drawing.Point(620, 72)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(49, 18)
        Me.pic1.TabIndex = 28
        Me.pic1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 372)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 12, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(912, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 42
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel1.Text = "보안점검 : 점검중"
        '
        'tool_loding
        '
        Me.tool_loding.BackgroundImage = Global.ECPS.My.Resources.Resources.lo1
        Me.tool_loding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tool_loding.Location = New System.Drawing.Point(18, 20)
        Me.tool_loding.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tool_loding.Name = "tool_loding"
        Me.tool_loding.Size = New System.Drawing.Size(37, 34)
        Me.tool_loding.TabIndex = 43
        Me.tool_loding.TabStop = False
        '
        'tool_bar_timer
        '
        Me.tool_bar_timer.Interval = 10
        '
        'timer_start
        '
        Me.timer_start.Interval = 3000
        '
        'Fix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(912, 394)
        Me.Controls.Add(Me.tool_loding)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tool_btn)
        Me.Controls.Add(Me.log)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.pic6)
        Me.Controls.Add(Me.pic7)
        Me.Controls.Add(Me.pic8)
        Me.Controls.Add(Me.pic9)
        Me.Controls.Add(Me.pic5)
        Me.Controls.Add(Me.pic4)
        Me.Controls.Add(Me.pic3)
        Me.Controls.Add(Me.pic2)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.tool_list)
        Me.Controls.Add(Me.tool_bar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Fix"
        Me.Text = "보안 점검"
        CType(Me.tool_btn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.tool_loding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pic6 As PictureBox
    Friend WithEvents pic7 As PictureBox
    Friend WithEvents pic8 As PictureBox
    Friend WithEvents pic9 As PictureBox
    Friend WithEvents pic5 As PictureBox
    Friend WithEvents pic4 As PictureBox
    Friend WithEvents pic3 As PictureBox
    Friend WithEvents pic2 As PictureBox
    Friend WithEvents pic1 As PictureBox
    Friend WithEvents tool_list As ListBox
    Friend WithEvents tool_bar As ProgressBar
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents log As ListBox
    Friend WithEvents tool_btn As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tool_loding As PictureBox
    Friend WithEvents tool_bar_timer As Timer
    Friend WithEvents timer_start As Timer
End Class
