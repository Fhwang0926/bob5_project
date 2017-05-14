<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class search
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(search))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.all_tab = New System.Windows.Forms.TabPage()
        Me.scan_list_all = New System.Windows.Forms.ListBox()
        Me.hwp_tab = New System.Windows.Forms.TabPage()
        Me.hwp_list = New System.Windows.Forms.CheckedListBox()
        Me.exc_tab = New System.Windows.Forms.TabPage()
        Me.exc_list = New System.Windows.Forms.CheckedListBox()
        Me.word_tab = New System.Windows.Forms.TabPage()
        Me.word_list = New System.Windows.Forms.CheckedListBox()
        Me.ppt_tab = New System.Windows.Forms.TabPage()
        Me.ppt_list = New System.Windows.Forms.CheckedListBox()
        Me.txt_tab = New System.Windows.Forms.TabPage()
        Me.txt_list = New System.Windows.Forms.CheckedListBox()
        Me.count_label = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.time_label = New System.Windows.Forms.Label()
        Me.scan_del_part_btn = New System.Windows.Forms.Button()
        Me.scan_enc_part_btn = New System.Windows.Forms.Button()
        Me.timer_start = New System.Windows.Forms.Timer(Me.components)
        Me.timer_count = New System.Windows.Forms.Timer(Me.components)
        Me.HwpCtrl1 = New AxHWPCONTROLLib.AxHwpCtrl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pass_pw_set_file_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.state_label = New System.Windows.Forms.Label()
        Me.all_unchk_btn = New System.Windows.Forms.Button()
        Me.all_chk_btn = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.all_tab.SuspendLayout()
        Me.hwp_tab.SuspendLayout()
        Me.exc_tab.SuspendLayout()
        Me.word_tab.SuspendLayout()
        Me.ppt_tab.SuspendLayout()
        Me.txt_tab.SuspendLayout()
        CType(Me.HwpCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.all_tab)
        Me.TabControl1.Controls.Add(Me.hwp_tab)
        Me.TabControl1.Controls.Add(Me.exc_tab)
        Me.TabControl1.Controls.Add(Me.word_tab)
        Me.TabControl1.Controls.Add(Me.ppt_tab)
        Me.TabControl1.Controls.Add(Me.txt_tab)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TabControl1.Location = New System.Drawing.Point(12, 35)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(731, 386)
        Me.TabControl1.TabIndex = 38
        '
        'all_tab
        '
        Me.all_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.all_tab.Controls.Add(Me.scan_list_all)
        Me.all_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.all_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.all_tab.Location = New System.Drawing.Point(4, 22)
        Me.all_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.all_tab.Name = "all_tab"
        Me.all_tab.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.all_tab.Size = New System.Drawing.Size(723, 360)
        Me.all_tab.TabIndex = 0
        Me.all_tab.Text = "전체 목록"
        Me.all_tab.UseVisualStyleBackColor = True
        '
        'scan_list_all
        '
        Me.scan_list_all.FormattingEnabled = True
        Me.scan_list_all.ItemHeight = 17
        Me.scan_list_all.Location = New System.Drawing.Point(-1, -2)
        Me.scan_list_all.Name = "scan_list_all"
        Me.scan_list_all.Size = New System.Drawing.Size(723, 361)
        Me.scan_list_all.TabIndex = 0
        '
        'hwp_tab
        '
        Me.hwp_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hwp_tab.Controls.Add(Me.hwp_list)
        Me.hwp_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.hwp_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.hwp_tab.Location = New System.Drawing.Point(4, 22)
        Me.hwp_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.hwp_tab.Name = "hwp_tab"
        Me.hwp_tab.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.hwp_tab.Size = New System.Drawing.Size(723, 360)
        Me.hwp_tab.TabIndex = 1
        Me.hwp_tab.Text = "한글"
        Me.hwp_tab.UseVisualStyleBackColor = True
        '
        'hwp_list
        '
        Me.hwp_list.FormattingEnabled = True
        Me.hwp_list.HorizontalScrollbar = True
        Me.hwp_list.Location = New System.Drawing.Point(0, -1)
        Me.hwp_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.hwp_list.Name = "hwp_list"
        Me.hwp_list.Size = New System.Drawing.Size(722, 364)
        Me.hwp_list.TabIndex = 44
        '
        'exc_tab
        '
        Me.exc_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.exc_tab.Controls.Add(Me.exc_list)
        Me.exc_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.exc_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.exc_tab.Location = New System.Drawing.Point(4, 22)
        Me.exc_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.exc_tab.Name = "exc_tab"
        Me.exc_tab.Size = New System.Drawing.Size(723, 360)
        Me.exc_tab.TabIndex = 2
        Me.exc_tab.Text = "엑셀"
        Me.exc_tab.UseVisualStyleBackColor = True
        '
        'exc_list
        '
        Me.exc_list.FormattingEnabled = True
        Me.exc_list.HorizontalScrollbar = True
        Me.exc_list.Location = New System.Drawing.Point(0, -1)
        Me.exc_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.exc_list.Name = "exc_list"
        Me.exc_list.Size = New System.Drawing.Size(722, 364)
        Me.exc_list.TabIndex = 43
        '
        'word_tab
        '
        Me.word_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.word_tab.Controls.Add(Me.word_list)
        Me.word_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.word_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.word_tab.Location = New System.Drawing.Point(4, 22)
        Me.word_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.word_tab.Name = "word_tab"
        Me.word_tab.Size = New System.Drawing.Size(723, 360)
        Me.word_tab.TabIndex = 3
        Me.word_tab.Text = "워드"
        Me.word_tab.UseVisualStyleBackColor = True
        '
        'word_list
        '
        Me.word_list.FormattingEnabled = True
        Me.word_list.HorizontalScrollbar = True
        Me.word_list.Location = New System.Drawing.Point(0, -1)
        Me.word_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.word_list.Name = "word_list"
        Me.word_list.Size = New System.Drawing.Size(722, 364)
        Me.word_list.TabIndex = 42
        '
        'ppt_tab
        '
        Me.ppt_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ppt_tab.Controls.Add(Me.ppt_list)
        Me.ppt_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ppt_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ppt_tab.Location = New System.Drawing.Point(4, 22)
        Me.ppt_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ppt_tab.Name = "ppt_tab"
        Me.ppt_tab.Size = New System.Drawing.Size(723, 360)
        Me.ppt_tab.TabIndex = 4
        Me.ppt_tab.Text = "파워포인트"
        Me.ppt_tab.UseVisualStyleBackColor = True
        '
        'ppt_list
        '
        Me.ppt_list.FormattingEnabled = True
        Me.ppt_list.HorizontalScrollbar = True
        Me.ppt_list.Location = New System.Drawing.Point(0, -1)
        Me.ppt_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ppt_list.Name = "ppt_list"
        Me.ppt_list.Size = New System.Drawing.Size(722, 364)
        Me.ppt_list.TabIndex = 41
        '
        'txt_tab
        '
        Me.txt_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tab.Controls.Add(Me.txt_list)
        Me.txt_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_tab.Location = New System.Drawing.Point(4, 22)
        Me.txt_tab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_tab.Name = "txt_tab"
        Me.txt_tab.Size = New System.Drawing.Size(723, 360)
        Me.txt_tab.TabIndex = 5
        Me.txt_tab.Text = "텍스트"
        Me.txt_tab.UseVisualStyleBackColor = True
        '
        'txt_list
        '
        Me.txt_list.FormattingEnabled = True
        Me.txt_list.HorizontalScrollbar = True
        Me.txt_list.Location = New System.Drawing.Point(0, -1)
        Me.txt_list.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_list.Name = "txt_list"
        Me.txt_list.Size = New System.Drawing.Size(722, 364)
        Me.txt_list.TabIndex = 40
        '
        'count_label
        '
        Me.count_label.AutoSize = True
        Me.count_label.Location = New System.Drawing.Point(749, 37)
        Me.count_label.Name = "count_label"
        Me.count_label.Size = New System.Drawing.Size(42, 12)
        Me.count_label.TabIndex = 41
        Me.count_label.Text = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(82, 4)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(941, 26)
        Me.ProgressBar1.TabIndex = 40
        '
        'time_label
        '
        Me.time_label.AutoSize = True
        Me.time_label.Location = New System.Drawing.Point(1036, 14)
        Me.time_label.Name = "time_label"
        Me.time_label.Size = New System.Drawing.Size(49, 12)
        Me.time_label.TabIndex = 42
        Me.time_label.Text = "00:00:00"
        '
        'scan_del_part_btn
        '
        Me.scan_del_part_btn.Font = New System.Drawing.Font("돋움체", 12.0!, System.Drawing.FontStyle.Bold)
        Me.scan_del_part_btn.Location = New System.Drawing.Point(485, 425)
        Me.scan_del_part_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.scan_del_part_btn.Name = "scan_del_part_btn"
        Me.scan_del_part_btn.Size = New System.Drawing.Size(150, 47)
        Me.scan_del_part_btn.TabIndex = 44
        Me.scan_del_part_btn.Text = "선택 삭제"
        Me.scan_del_part_btn.UseVisualStyleBackColor = True
        '
        'scan_enc_part_btn
        '
        Me.scan_enc_part_btn.Font = New System.Drawing.Font("돋움체", 12.0!, System.Drawing.FontStyle.Bold)
        Me.scan_enc_part_btn.Location = New System.Drawing.Point(329, 425)
        Me.scan_enc_part_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.scan_enc_part_btn.Name = "scan_enc_part_btn"
        Me.scan_enc_part_btn.Size = New System.Drawing.Size(150, 47)
        Me.scan_enc_part_btn.TabIndex = 43
        Me.scan_enc_part_btn.Text = "선택 암호화"
        Me.scan_enc_part_btn.UseVisualStyleBackColor = True
        '
        'timer_start
        '
        '
        'timer_count
        '
        Me.timer_count.Interval = 1000
        '
        'HwpCtrl1
        '
        Me.HwpCtrl1.Enabled = True
        Me.HwpCtrl1.Location = New System.Drawing.Point(745, 51)
        Me.HwpCtrl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HwpCtrl1.Name = "HwpCtrl1"
        Me.HwpCtrl1.OcxState = CType(resources.GetObject("HwpCtrl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.HwpCtrl1.Size = New System.Drawing.Size(344, 427)
        Me.HwpCtrl1.TabIndex = 45
        '
        'Timer1
        '
        '
        'pass_pw_set_file_timer
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(756, 228)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(304, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "미리 보기는 검색 완료후에 가능합니다"
        '
        'state_label
        '
        Me.state_label.AutoSize = True
        Me.state_label.Location = New System.Drawing.Point(21, 13)
        Me.state_label.Name = "state_label"
        Me.state_label.Size = New System.Drawing.Size(0, 12)
        Me.state_label.TabIndex = 47
        '
        'all_unchk_btn
        '
        Me.all_unchk_btn.Font = New System.Drawing.Font("돋움체", 12.0!, System.Drawing.FontStyle.Bold)
        Me.all_unchk_btn.Location = New System.Drawing.Point(173, 425)
        Me.all_unchk_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.all_unchk_btn.Name = "all_unchk_btn"
        Me.all_unchk_btn.Size = New System.Drawing.Size(150, 47)
        Me.all_unchk_btn.TabIndex = 48
        Me.all_unchk_btn.Text = "전체 해제"
        Me.all_unchk_btn.UseVisualStyleBackColor = True
        '
        'all_chk_btn
        '
        Me.all_chk_btn.Font = New System.Drawing.Font("돋움체", 12.0!, System.Drawing.FontStyle.Bold)
        Me.all_chk_btn.Location = New System.Drawing.Point(17, 425)
        Me.all_chk_btn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.all_chk_btn.Name = "all_chk_btn"
        Me.all_chk_btn.Size = New System.Drawing.Size(150, 47)
        Me.all_chk_btn.TabIndex = 49
        Me.all_chk_btn.Text = "전체 선택"
        Me.all_chk_btn.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(745, 51)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(344, 420)
        Me.RichTextBox1.TabIndex = 50
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'search
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 483)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.all_chk_btn)
        Me.Controls.Add(Me.all_unchk_btn)
        Me.Controls.Add(Me.state_label)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HwpCtrl1)
        Me.Controls.Add(Me.scan_del_part_btn)
        Me.Controls.Add(Me.scan_enc_part_btn)
        Me.Controls.Add(Me.time_label)
        Me.Controls.Add(Me.count_label)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "search"
        Me.Text = "개인정보 탐색기"
        Me.TabControl1.ResumeLayout(False)
        Me.all_tab.ResumeLayout(False)
        Me.hwp_tab.ResumeLayout(False)
        Me.exc_tab.ResumeLayout(False)
        Me.word_tab.ResumeLayout(False)
        Me.ppt_tab.ResumeLayout(False)
        Me.txt_tab.ResumeLayout(False)
        CType(Me.HwpCtrl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents all_tab As TabPage
    Friend WithEvents hwp_tab As TabPage
    Friend WithEvents hwp_list As CheckedListBox
    Friend WithEvents exc_tab As TabPage
    Friend WithEvents exc_list As CheckedListBox
    Friend WithEvents word_tab As TabPage
    Friend WithEvents word_list As CheckedListBox
    Friend WithEvents ppt_tab As TabPage
    Friend WithEvents ppt_list As CheckedListBox
    Friend WithEvents txt_tab As TabPage
    Friend WithEvents txt_list As CheckedListBox
    Friend WithEvents count_label As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents time_label As Label
    Friend WithEvents scan_del_part_btn As Button
    Friend WithEvents scan_enc_part_btn As Button
    Friend WithEvents timer_start As Timer
    Friend WithEvents timer_count As Timer
    Friend WithEvents HwpCtrl1 As AxHWPCONTROLLib.AxHwpCtrl
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pass_pw_set_file_timer As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents state_label As Label
    Friend WithEvents all_unchk_btn As Button
    Friend WithEvents all_chk_btn As Button
    Friend WithEvents scan_list_all As ListBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
