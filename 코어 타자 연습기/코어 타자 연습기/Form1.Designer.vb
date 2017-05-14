<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.core = New System.Windows.Forms.Label()
        Me.start_btn = New System.Windows.Forms.Button()
        Me.close_btn = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.time = New System.Windows.Forms.Label()
        Me.good = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.bad = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'core
        '
        Me.core.AutoSize = True
        Me.core.Font = New System.Drawing.Font("굴림", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.core.Location = New System.Drawing.Point(58, 41)
        Me.core.Name = "core"
        Me.core.Size = New System.Drawing.Size(63, 24)
        Me.core.TabIndex = 0
        Me.core.Text = "Core"
        '
        'start_btn
        '
        Me.start_btn.Font = New System.Drawing.Font("굴림", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.start_btn.Location = New System.Drawing.Point(738, 110)
        Me.start_btn.Name = "start_btn"
        Me.start_btn.Size = New System.Drawing.Size(245, 69)
        Me.start_btn.TabIndex = 1
        Me.start_btn.Text = "시작"
        Me.start_btn.UseVisualStyleBackColor = True
        '
        'close_btn
        '
        Me.close_btn.Font = New System.Drawing.Font("굴림", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.close_btn.Location = New System.Drawing.Point(738, 209)
        Me.close_btn.Name = "close_btn"
        Me.close_btn.Size = New System.Drawing.Size(245, 71)
        Me.close_btn.TabIndex = 2
        Me.close_btn.Text = "닫기"
        Me.close_btn.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(48, 130)
        Me.TextBox1.MaxLength = 36
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(649, 35)
        Me.TextBox1.TabIndex = 3
        '
        'time
        '
        Me.time.AutoSize = True
        Me.time.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.time.Location = New System.Drawing.Point(812, 316)
        Me.time.Name = "time"
        Me.time.Size = New System.Drawing.Size(143, 29)
        Me.time.TabIndex = 5
        Me.time.Text = "00:00:00"
        '
        'good
        '
        Me.good.AutoSize = True
        Me.good.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.good.Location = New System.Drawing.Point(193, 245)
        Me.good.Name = "good"
        Me.good.Size = New System.Drawing.Size(31, 29)
        Me.good.TabIndex = 6
        Me.good.Text = "0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'bad
        '
        Me.bad.AutoSize = True
        Me.bad.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.bad.Location = New System.Drawing.Point(193, 316)
        Me.bad.Name = "bad"
        Me.bad.Size = New System.Drawing.Size(31, 29)
        Me.bad.TabIndex = 7
        Me.bad.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 245)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 29)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "정답 : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 316)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 29)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "오답 : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(646, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 29)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "소요시간 : "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 386)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bad)
        Me.Controls.Add(Me.good)
        Me.Controls.Add(Me.time)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.close_btn)
        Me.Controls.Add(Me.start_btn)
        Me.Controls.Add(Me.core)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "코어 입력 연습프로그램 - Redstone"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents core As Label
    Friend WithEvents start_btn As Button
    Friend WithEvents close_btn As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents time As Label
    Friend WithEvents good As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents bad As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
