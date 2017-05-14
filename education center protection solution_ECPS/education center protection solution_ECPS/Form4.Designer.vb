<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.scan_del_part_btn = New System.Windows.Forms.Button()
        Me.scan_del_btn = New System.Windows.Forms.Button()
        Me.scan_list_all = New System.Windows.Forms.CheckedListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.all_tab = New System.Windows.Forms.TabPage()
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.count_label = New System.Windows.Forms.Label()
        Me.time_label = New System.Windows.Forms.Label()
        Me.list_tmp = New System.Windows.Forms.ListBox()
        Me.timer_start = New System.Windows.Forms.Timer(Me.components)
        Me.timer_count = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.all_tab.SuspendLayout()
        Me.hwp_tab.SuspendLayout()
        Me.exc_tab.SuspendLayout()
        Me.word_tab.SuspendLayout()
        Me.ppt_tab.SuspendLayout()
        Me.txt_tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'scan_del_part_btn
        '
        Me.scan_del_part_btn.Location = New System.Drawing.Point(333, 551)
        Me.scan_del_part_btn.Name = "scan_del_part_btn"
        Me.scan_del_part_btn.Size = New System.Drawing.Size(296, 56)
        Me.scan_del_part_btn.TabIndex = 36
        Me.scan_del_part_btn.Text = "Button2"
        Me.scan_del_part_btn.UseVisualStyleBackColor = True
        '
        'scan_del_btn
        '
        Me.scan_del_btn.Location = New System.Drawing.Point(31, 546)
        Me.scan_del_btn.Name = "scan_del_btn"
        Me.scan_del_btn.Size = New System.Drawing.Size(296, 61)
        Me.scan_del_btn.TabIndex = 35
        Me.scan_del_btn.Text = "Button1"
        Me.scan_del_btn.UseVisualStyleBackColor = True
        '
        'scan_list_all
        '
        Me.scan_list_all.FormattingEnabled = True
        Me.scan_list_all.HorizontalScrollbar = True
        Me.scan_list_all.Location = New System.Drawing.Point(0, -1)
        Me.scan_list_all.Name = "scan_list_all"
        Me.scan_list_all.Size = New System.Drawing.Size(825, 454)
        Me.scan_list_all.TabIndex = 34
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
        Me.TabControl1.Location = New System.Drawing.Point(27, 54)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(835, 482)
        Me.TabControl1.TabIndex = 37
        '
        'all_tab
        '
        Me.all_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.all_tab.Controls.Add(Me.scan_list_all)
        Me.all_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.all_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.all_tab.Location = New System.Drawing.Point(4, 25)
        Me.all_tab.Name = "all_tab"
        Me.all_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.all_tab.Size = New System.Drawing.Size(827, 453)
        Me.all_tab.TabIndex = 0
        Me.all_tab.Text = "전체"
        Me.all_tab.UseVisualStyleBackColor = True
        '
        'hwp_tab
        '
        Me.hwp_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hwp_tab.Controls.Add(Me.hwp_list)
        Me.hwp_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.hwp_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.hwp_tab.Location = New System.Drawing.Point(4, 25)
        Me.hwp_tab.Name = "hwp_tab"
        Me.hwp_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.hwp_tab.Size = New System.Drawing.Size(827, 453)
        Me.hwp_tab.TabIndex = 1
        Me.hwp_tab.Text = "한글"
        Me.hwp_tab.UseVisualStyleBackColor = True
        '
        'hwp_list
        '
        Me.hwp_list.FormattingEnabled = True
        Me.hwp_list.HorizontalScrollbar = True
        Me.hwp_list.Location = New System.Drawing.Point(0, -1)
        Me.hwp_list.Name = "hwp_list"
        Me.hwp_list.Size = New System.Drawing.Size(825, 454)
        Me.hwp_list.TabIndex = 44
        '
        'exc_tab
        '
        Me.exc_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.exc_tab.Controls.Add(Me.exc_list)
        Me.exc_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.exc_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.exc_tab.Location = New System.Drawing.Point(4, 25)
        Me.exc_tab.Name = "exc_tab"
        Me.exc_tab.Size = New System.Drawing.Size(827, 453)
        Me.exc_tab.TabIndex = 2
        Me.exc_tab.Text = "엑셀"
        Me.exc_tab.UseVisualStyleBackColor = True
        '
        'exc_list
        '
        Me.exc_list.FormattingEnabled = True
        Me.exc_list.HorizontalScrollbar = True
        Me.exc_list.Location = New System.Drawing.Point(0, 0)
        Me.exc_list.Name = "exc_list"
        Me.exc_list.Size = New System.Drawing.Size(825, 454)
        Me.exc_list.TabIndex = 43
        '
        'word_tab
        '
        Me.word_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.word_tab.Controls.Add(Me.word_list)
        Me.word_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.word_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.word_tab.Location = New System.Drawing.Point(4, 25)
        Me.word_tab.Name = "word_tab"
        Me.word_tab.Size = New System.Drawing.Size(827, 453)
        Me.word_tab.TabIndex = 3
        Me.word_tab.Text = "워드"
        Me.word_tab.UseVisualStyleBackColor = True
        '
        'word_list
        '
        Me.word_list.FormattingEnabled = True
        Me.word_list.HorizontalScrollbar = True
        Me.word_list.Location = New System.Drawing.Point(0, 0)
        Me.word_list.Name = "word_list"
        Me.word_list.Size = New System.Drawing.Size(825, 454)
        Me.word_list.TabIndex = 42
        '
        'ppt_tab
        '
        Me.ppt_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ppt_tab.Controls.Add(Me.ppt_list)
        Me.ppt_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ppt_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ppt_tab.Location = New System.Drawing.Point(4, 25)
        Me.ppt_tab.Name = "ppt_tab"
        Me.ppt_tab.Size = New System.Drawing.Size(827, 453)
        Me.ppt_tab.TabIndex = 4
        Me.ppt_tab.Text = "파워포인트"
        Me.ppt_tab.UseVisualStyleBackColor = True
        '
        'ppt_list
        '
        Me.ppt_list.FormattingEnabled = True
        Me.ppt_list.HorizontalScrollbar = True
        Me.ppt_list.Location = New System.Drawing.Point(0, 0)
        Me.ppt_list.Name = "ppt_list"
        Me.ppt_list.Size = New System.Drawing.Size(825, 454)
        Me.ppt_list.TabIndex = 41
        '
        'txt_tab
        '
        Me.txt_tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tab.Controls.Add(Me.txt_list)
        Me.txt_tab.Font = New System.Drawing.Font("맑은 고딕", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txt_tab.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_tab.Location = New System.Drawing.Point(4, 25)
        Me.txt_tab.Name = "txt_tab"
        Me.txt_tab.Size = New System.Drawing.Size(827, 453)
        Me.txt_tab.TabIndex = 5
        Me.txt_tab.Text = "텍스트"
        Me.txt_tab.UseVisualStyleBackColor = True
        '
        'txt_list
        '
        Me.txt_list.FormattingEnabled = True
        Me.txt_list.HorizontalScrollbar = True
        Me.txt_list.Location = New System.Drawing.Point(0, 0)
        Me.txt_list.Name = "txt_list"
        Me.txt_list.Size = New System.Drawing.Size(825, 454)
        Me.txt_list.TabIndex = 40
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(101, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1108, 23)
        Me.ProgressBar1.TabIndex = 38
        '
        'count_label
        '
        Me.count_label.AutoSize = True
        Me.count_label.Location = New System.Drawing.Point(13, 14)
        Me.count_label.Name = "count_label"
        Me.count_label.Size = New System.Drawing.Size(50, 15)
        Me.count_label.TabIndex = 39
        Me.count_label.Text = "Label1"
        '
        'time_label
        '
        Me.time_label.AutoSize = True
        Me.time_label.Location = New System.Drawing.Point(1227, 14)
        Me.time_label.Name = "time_label"
        Me.time_label.Size = New System.Drawing.Size(50, 15)
        Me.time_label.TabIndex = 40
        Me.time_label.Text = "Label2"
        '
        'list_tmp
        '
        Me.list_tmp.FormattingEnabled = True
        Me.list_tmp.ItemHeight = 15
        Me.list_tmp.Location = New System.Drawing.Point(863, 80)
        Me.list_tmp.Name = "list_tmp"
        Me.list_tmp.Size = New System.Drawing.Size(10, 454)
        Me.list_tmp.TabIndex = 41
        Me.list_tmp.Visible = False
        '
        'timer_start
        '
        '
        'timer_count
        '
        Me.timer_count.Interval = 1000
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 619)
        Me.Controls.Add(Me.list_tmp)
        Me.Controls.Add(Me.time_label)
        Me.Controls.Add(Me.count_label)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.scan_del_part_btn)
        Me.Controls.Add(Me.scan_del_btn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.Text = "Form4"
        Me.TabControl1.ResumeLayout(False)
        Me.all_tab.ResumeLayout(False)
        Me.hwp_tab.ResumeLayout(False)
        Me.exc_tab.ResumeLayout(False)
        Me.word_tab.ResumeLayout(False)
        Me.ppt_tab.ResumeLayout(False)
        Me.txt_tab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents scan_del_part_btn As Button
    Friend WithEvents scan_del_btn As Button
    Friend WithEvents scan_list_all As CheckedListBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents all_tab As TabPage
    Friend WithEvents hwp_tab As TabPage
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents exc_tab As TabPage
    Friend WithEvents word_tab As TabPage
    Friend WithEvents ppt_tab As TabPage
    Friend WithEvents txt_tab As TabPage
    Friend WithEvents hwp_list As CheckedListBox
    Friend WithEvents exc_list As CheckedListBox
    Friend WithEvents word_list As CheckedListBox
    Friend WithEvents ppt_list As CheckedListBox
    Friend WithEvents txt_list As CheckedListBox
    Friend WithEvents count_label As Label
    Friend WithEvents time_label As Label
    Friend WithEvents list_tmp As ListBox
    Friend WithEvents timer_start As Timer
    Friend WithEvents timer_count As Timer
End Class
