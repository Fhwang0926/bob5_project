<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.main_tag = New System.Windows.Forms.Label()
        Me.log_tag_date = New System.Windows.Forms.Label()
        Me.person_tag_date = New System.Windows.Forms.Label()
        Me.security_tag_date = New System.Windows.Forms.Label()
        Me.log_tag = New System.Windows.Forms.Label()
        Me.person_tag = New System.Windows.Forms.Label()
        Me.security_tag = New System.Windows.Forms.Label()
        Me.quick_btn = New System.Windows.Forms.Button()
        Me.setting_btn = New System.Windows.Forms.Button()
        Me.all_btn = New System.Windows.Forms.Button()
        Me.security_chk_btn = New System.Windows.Forms.Button()
        Me.drm_state = New System.Windows.Forms.PictureBox()
        Me.main_state = New System.Windows.Forms.PictureBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ctxmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.drm_timer = New System.Windows.Forms.Timer(Me.components)
        Me.use_p_drm_label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.close_btn = New System.Windows.Forms.Button()
        CType(Me.drm_state, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.main_state, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'main_tag
        '
        Me.main_tag.AutoSize = True
        Me.main_tag.BackColor = System.Drawing.Color.Black
        Me.main_tag.Font = New System.Drawing.Font("맑은 고딕", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.main_tag.ForeColor = System.Drawing.Color.White
        Me.main_tag.Location = New System.Drawing.Point(76, 115)
        Me.main_tag.Name = "main_tag"
        Me.main_tag.Size = New System.Drawing.Size(465, 54)
        Me.main_tag.TabIndex = 45
        Me.main_tag.Text = "보안 수준이 양호 합니다"
        '
        'log_tag_date
        '
        Me.log_tag_date.AutoSize = True
        Me.log_tag_date.BackColor = System.Drawing.Color.Black
        Me.log_tag_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.log_tag_date.ForeColor = System.Drawing.Color.White
        Me.log_tag_date.Location = New System.Drawing.Point(145, 364)
        Me.log_tag_date.Name = "log_tag_date"
        Me.log_tag_date.Size = New System.Drawing.Size(97, 20)
        Me.log_tag_date.TabIndex = 44
        Me.log_tag_date.Text = "2016. 11. 24"
        '
        'person_tag_date
        '
        Me.person_tag_date.AutoSize = True
        Me.person_tag_date.BackColor = System.Drawing.Color.Black
        Me.person_tag_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.person_tag_date.ForeColor = System.Drawing.Color.White
        Me.person_tag_date.Location = New System.Drawing.Point(145, 320)
        Me.person_tag_date.Name = "person_tag_date"
        Me.person_tag_date.Size = New System.Drawing.Size(97, 20)
        Me.person_tag_date.TabIndex = 43
        Me.person_tag_date.Text = "2016. 11. 24"
        '
        'security_tag_date
        '
        Me.security_tag_date.AutoSize = True
        Me.security_tag_date.BackColor = System.Drawing.Color.Black
        Me.security_tag_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.security_tag_date.ForeColor = System.Drawing.Color.White
        Me.security_tag_date.Location = New System.Drawing.Point(145, 272)
        Me.security_tag_date.Name = "security_tag_date"
        Me.security_tag_date.Size = New System.Drawing.Size(97, 20)
        Me.security_tag_date.TabIndex = 42
        Me.security_tag_date.Text = "2016. 11. 24"
        '
        'log_tag
        '
        Me.log_tag.AutoSize = True
        Me.log_tag.BackColor = System.Drawing.Color.Black
        Me.log_tag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.log_tag.ForeColor = System.Drawing.Color.White
        Me.log_tag.Location = New System.Drawing.Point(38, 341)
        Me.log_tag.Name = "log_tag"
        Me.log_tag.Size = New System.Drawing.Size(121, 20)
        Me.log_tag.TabIndex = 41
        Me.log_tag.Text = "최근 로그 기록"
        '
        'person_tag
        '
        Me.person_tag.AutoSize = True
        Me.person_tag.BackColor = System.Drawing.Color.Black
        Me.person_tag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.person_tag.ForeColor = System.Drawing.Color.White
        Me.person_tag.Location = New System.Drawing.Point(38, 296)
        Me.person_tag.Name = "person_tag"
        Me.person_tag.Size = New System.Drawing.Size(155, 20)
        Me.person_tag.TabIndex = 40
        Me.person_tag.Text = "최근 개인정보 검색"
        '
        'security_tag
        '
        Me.security_tag.AutoSize = True
        Me.security_tag.BackColor = System.Drawing.Color.Black
        Me.security_tag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.security_tag.ForeColor = System.Drawing.Color.White
        Me.security_tag.Location = New System.Drawing.Point(38, 248)
        Me.security_tag.Name = "security_tag"
        Me.security_tag.Size = New System.Drawing.Size(121, 20)
        Me.security_tag.TabIndex = 39
        Me.security_tag.Text = "최근 보안 점검"
        '
        'quick_btn
        '
        Me.quick_btn.BackColor = System.Drawing.Color.White
        Me.quick_btn.BackgroundImage = Global.ECPS.My.Resources.Resources.quick_search
        Me.quick_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.quick_btn.Font = New System.Drawing.Font("맑은 고딕", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.quick_btn.Location = New System.Drawing.Point(634, 312)
        Me.quick_btn.Name = "quick_btn"
        Me.quick_btn.Size = New System.Drawing.Size(266, 90)
        Me.quick_btn.TabIndex = 38
        Me.quick_btn.UseVisualStyleBackColor = False
        '
        'setting_btn
        '
        Me.setting_btn.BackColor = System.Drawing.Color.White
        Me.setting_btn.BackgroundImage = Global.ECPS.My.Resources.Resources.setting
        Me.setting_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.setting_btn.Font = New System.Drawing.Font("맑은 고딕", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.setting_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.setting_btn.Location = New System.Drawing.Point(634, 28)
        Me.setting_btn.Name = "setting_btn"
        Me.setting_btn.Size = New System.Drawing.Size(266, 67)
        Me.setting_btn.TabIndex = 37
        Me.setting_btn.UseVisualStyleBackColor = False
        '
        'all_btn
        '
        Me.all_btn.BackColor = System.Drawing.Color.White
        Me.all_btn.BackgroundImage = Global.ECPS.My.Resources.Resources.search
        Me.all_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.all_btn.Font = New System.Drawing.Font("맑은 고딕", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.all_btn.Location = New System.Drawing.Point(634, 213)
        Me.all_btn.Name = "all_btn"
        Me.all_btn.Size = New System.Drawing.Size(266, 92)
        Me.all_btn.TabIndex = 36
        Me.all_btn.UseVisualStyleBackColor = False
        '
        'security_chk_btn
        '
        Me.security_chk_btn.BackColor = System.Drawing.Color.White
        Me.security_chk_btn.BackgroundImage = Global.ECPS.My.Resources.Resources.security_check
        Me.security_chk_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.security_chk_btn.Font = New System.Drawing.Font("맑은 고딕", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.security_chk_btn.Location = New System.Drawing.Point(634, 102)
        Me.security_chk_btn.Name = "security_chk_btn"
        Me.security_chk_btn.Size = New System.Drawing.Size(266, 105)
        Me.security_chk_btn.TabIndex = 35
        Me.security_chk_btn.UseVisualStyleBackColor = False
        '
        'drm_state
        '
        Me.drm_state.BackgroundImage = Global.ECPS.My.Resources.Resources.on_on
        Me.drm_state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.drm_state.Location = New System.Drawing.Point(444, 320)
        Me.drm_state.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.drm_state.Name = "drm_state"
        Me.drm_state.Size = New System.Drawing.Size(164, 60)
        Me.drm_state.TabIndex = 46
        Me.drm_state.TabStop = False
        '
        'main_state
        '
        Me.main_state.BackColor = System.Drawing.Color.White
        Me.main_state.BackgroundImage = Global.ECPS.My.Resources.Resources.good_back
        Me.main_state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.main_state.Location = New System.Drawing.Point(11, 28)
        Me.main_state.Name = "main_state"
        Me.main_state.Size = New System.Drawing.Size(617, 371)
        Me.main_state.TabIndex = 34
        Me.main_state.TabStop = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        '
        'ctxmenu
        '
        Me.ctxmenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxmenu.Name = "ctxmenu"
        Me.ctxmenu.Size = New System.Drawing.Size(61, 4)
        '
        'drm_timer
        '
        Me.drm_timer.Interval = 1000
        '
        'use_p_drm_label
        '
        Me.use_p_drm_label.AutoSize = True
        Me.use_p_drm_label.BackColor = System.Drawing.Color.Black
        Me.use_p_drm_label.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold)
        Me.use_p_drm_label.ForeColor = System.Drawing.Color.White
        Me.use_p_drm_label.Location = New System.Drawing.Point(356, 284)
        Me.use_p_drm_label.Name = "use_p_drm_label"
        Me.use_p_drm_label.Size = New System.Drawing.Size(252, 21)
        Me.use_p_drm_label.TabIndex = 47
        Me.use_p_drm_label.Text = "개인정보파일 문서보안 사용 여부"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 12)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "ECPS : [Education Center Protection Solution] / 교육기관 보안 솔루션"
        '
        'close_btn
        '
        Me.close_btn.BackColor = System.Drawing.Color.Black
        Me.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.close_btn.ForeColor = System.Drawing.Color.Yellow
        Me.close_btn.Location = New System.Drawing.Point(874, 6)
        Me.close_btn.Margin = New System.Windows.Forms.Padding(0)
        Me.close_btn.Name = "close_btn"
        Me.close_btn.Size = New System.Drawing.Size(22, 20)
        Me.close_btn.TabIndex = 49
        Me.close_btn.Text = "X"
        Me.close_btn.UseVisualStyleBackColor = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ECPS.My.Resources.Resources.back1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(912, 410)
        Me.Controls.Add(Me.close_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.use_p_drm_label)
        Me.Controls.Add(Me.drm_state)
        Me.Controls.Add(Me.main_tag)
        Me.Controls.Add(Me.log_tag_date)
        Me.Controls.Add(Me.person_tag_date)
        Me.Controls.Add(Me.security_tag_date)
        Me.Controls.Add(Me.log_tag)
        Me.Controls.Add(Me.person_tag)
        Me.Controls.Add(Me.security_tag)
        Me.Controls.Add(Me.quick_btn)
        Me.Controls.Add(Me.setting_btn)
        Me.Controls.Add(Me.all_btn)
        Me.Controls.Add(Me.security_chk_btn)
        Me.Controls.Add(Me.main_state)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.Text = "ECPS : [Education Center Protection Solution] : 교육기관 보호 솔루션"
        CType(Me.drm_state, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.main_state, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents drm_state As PictureBox
    Friend WithEvents main_tag As Label
    Friend WithEvents log_tag_date As Label
    Friend WithEvents person_tag_date As Label
    Friend WithEvents security_tag_date As Label
    Friend WithEvents log_tag As Label
    Friend WithEvents person_tag As Label
    Friend WithEvents security_tag As Label
    Friend WithEvents quick_btn As Button
    Friend WithEvents setting_btn As Button
    Friend WithEvents all_btn As Button
    Friend WithEvents security_chk_btn As Button
    Friend WithEvents main_state As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ctxmenu As ContextMenuStrip
    Friend WithEvents drm_timer As Timer
    Friend WithEvents use_p_drm_label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents close_btn As Button
End Class
