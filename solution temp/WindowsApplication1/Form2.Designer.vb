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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.exit_btn = New System.Windows.Forms.Button()
        Me.new_btn = New System.Windows.Forms.Button()
        Me.open_btn = New System.Windows.Forms.Button()
        Me.file_list = New System.Windows.Forms.ListBox()
        Me.del_btn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'exit_btn
        '
        Me.exit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.exit_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.exit_btn.Location = New System.Drawing.Point(598, 258)
        Me.exit_btn.Name = "exit_btn"
        Me.exit_btn.Size = New System.Drawing.Size(210, 69)
        Me.exit_btn.TabIndex = 0
        Me.exit_btn.Text = "종료(exit)"
        Me.exit_btn.UseVisualStyleBackColor = False
        '
        'new_btn
        '
        Me.new_btn.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.new_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.new_btn.Location = New System.Drawing.Point(54, 258)
        Me.new_btn.Name = "new_btn"
        Me.new_btn.Size = New System.Drawing.Size(258, 69)
        Me.new_btn.TabIndex = 1
        Me.new_btn.Text = "새로 만들기(New)"
        Me.new_btn.UseVisualStyleBackColor = False
        '
        'open_btn
        '
        Me.open_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.open_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.open_btn.Location = New System.Drawing.Point(534, 43)
        Me.open_btn.Name = "open_btn"
        Me.open_btn.Size = New System.Drawing.Size(210, 156)
        Me.open_btn.TabIndex = 2
        Me.open_btn.Text = "열기(open)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[목록 선택 후]"
        Me.open_btn.UseVisualStyleBackColor = False
        '
        'file_list
        '
        Me.file_list.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.file_list.FormattingEnabled = True
        Me.file_list.ItemHeight = 20
        Me.file_list.Location = New System.Drawing.Point(84, 46)
        Me.file_list.Name = "file_list"
        Me.file_list.Size = New System.Drawing.Size(420, 144)
        Me.file_list.TabIndex = 3
        '
        'del_btn
        '
        Me.del_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.del_btn.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.del_btn.Location = New System.Drawing.Point(343, 258)
        Me.del_btn.Name = "del_btn"
        Me.del_btn.Size = New System.Drawing.Size(232, 69)
        Me.del_btn.TabIndex = 4
        Me.del_btn.Text = "삭제(Del)"
        Me.del_btn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(93, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "프로그램 종료시 자동으로 암호화 됩니다"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 363)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.del_btn)
        Me.Controls.Add(Me.file_list)
        Me.Controls.Add(Me.open_btn)
        Me.Controls.Add(Me.new_btn)
        Me.Controls.Add(Me.exit_btn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(886, 410)
        Me.MinimumSize = New System.Drawing.Size(886, 410)
        Me.Name = "Form2"
        Me.Text = "Test Paper Leak Solution - P.K Team"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents exit_btn As Button
    Friend WithEvents new_btn As Button
    Friend WithEvents open_btn As Button
    Friend WithEvents file_list As ListBox
    Friend WithEvents del_btn As Button
    Friend WithEvents Label1 As Label
End Class
