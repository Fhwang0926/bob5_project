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
        Me.del_btn = New System.Windows.Forms.Button()
        Me.file_list = New System.Windows.Forms.ListBox()
        Me.open_btn = New System.Windows.Forms.Button()
        Me.new_btn = New System.Windows.Forms.Button()
        Me.exit_btn = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pop_up_btn = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.exprot_btn = New System.Windows.Forms.Button()
        Me.import_btn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'del_btn
        '
        Me.del_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.del_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.del_btn.Location = New System.Drawing.Point(294, 254)
        Me.del_btn.Name = "del_btn"
        Me.del_btn.Size = New System.Drawing.Size(214, 69)
        Me.del_btn.TabIndex = 9
        Me.del_btn.Text = "삭제(Del)"
        Me.del_btn.UseVisualStyleBackColor = False
        '
        'file_list
        '
        Me.file_list.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.file_list.FormattingEnabled = True
        Me.file_list.ItemHeight = 20
        Me.file_list.Location = New System.Drawing.Point(45, 47)
        Me.file_list.Name = "file_list"
        Me.file_list.Size = New System.Drawing.Size(446, 164)
        Me.file_list.TabIndex = 8
        '
        'open_btn
        '
        Me.open_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.open_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.open_btn.Location = New System.Drawing.Point(523, 47)
        Me.open_btn.Name = "open_btn"
        Me.open_btn.Size = New System.Drawing.Size(244, 186)
        Me.open_btn.TabIndex = 7
        Me.open_btn.Text = "열기(Open)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[목록 선택 후]"
        Me.open_btn.UseVisualStyleBackColor = False
        '
        'new_btn
        '
        Me.new_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.new_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.new_btn.Location = New System.Drawing.Point(30, 254)
        Me.new_btn.Name = "new_btn"
        Me.new_btn.Size = New System.Drawing.Size(258, 69)
        Me.new_btn.TabIndex = 6
        Me.new_btn.Text = "새로 만들기(New)"
        Me.new_btn.UseVisualStyleBackColor = False
        '
        'exit_btn
        '
        Me.exit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.exit_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.exit_btn.Location = New System.Drawing.Point(523, 254)
        Me.exit_btn.Name = "exit_btn"
        Me.exit_btn.Size = New System.Drawing.Size(244, 69)
        Me.exit_btn.TabIndex = 5
        Me.exit_btn.Text = "종료(exit)"
        Me.exit_btn.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 216)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "목록(List)"
        '
        'pop_up_btn
        '
        Me.pop_up_btn.BackColor = System.Drawing.Color.Bisque
        Me.pop_up_btn.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Bold)
        Me.pop_up_btn.Location = New System.Drawing.Point(523, 6)
        Me.pop_up_btn.Name = "pop_up_btn"
        Me.pop_up_btn.Size = New System.Drawing.Size(244, 34)
        Me.pop_up_btn.TabIndex = 13
        Me.pop_up_btn.Text = ">> 파일 내보내기/가져오기 >>"
        Me.pop_up_btn.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 1
        '
        'exprot_btn
        '
        Me.exprot_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.exprot_btn.Location = New System.Drawing.Point(15, 187)
        Me.exprot_btn.Name = "exprot_btn"
        Me.exprot_btn.Size = New System.Drawing.Size(231, 131)
        Me.exprot_btn.TabIndex = 15
        Me.exprot_btn.Text = "내보내기" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Export)"
        Me.exprot_btn.UseVisualStyleBackColor = True
        '
        'import_btn
        '
        Me.import_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.import_btn.Location = New System.Drawing.Point(816, 37)
        Me.import_btn.Name = "import_btn"
        Me.import_btn.Size = New System.Drawing.Size(231, 131)
        Me.import_btn.TabIndex = 16
        Me.import_btn.Text = "가져오기" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Import)"
        Me.import_btn.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.exprot_btn)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(801, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(262, 330)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "파일(File)"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.ClientSize = New System.Drawing.Size(1117, 348)
        Me.Controls.Add(Me.import_btn)
        Me.Controls.Add(Me.pop_up_btn)
        Me.Controls.Add(Me.file_list)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.del_btn)
        Me.Controls.Add(Me.open_btn)
        Me.Controls.Add(Me.new_btn)
        Me.Controls.Add(Me.exit_btn)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Test Paper Leak Solution - P.K Team"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents del_btn As Button
    Friend WithEvents file_list As ListBox
    Friend WithEvents open_btn As Button
    Friend WithEvents new_btn As Button
    Friend WithEvents exit_btn As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pop_up_btn As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents exprot_btn As Button
    Friend WithEvents import_btn As Button
    Friend WithEvents GroupBox2 As GroupBox
End Class
