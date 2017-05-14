<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class water_mark
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(water_mark))
        Me.timer_mark = New System.Windows.Forms.Timer(Me.components)
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'timer_mark
        '
        Me.timer_mark.Interval = 1000
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("굴림", 24.0!)
        Me.label4.ForeColor = System.Drawing.Color.Red
        Me.label4.Location = New System.Drawing.Point(408, 383)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(112, 32)
        Me.label4.TabIndex = 7
        Me.label4.Text = "Label4"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("굴림", 24.0!)
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(408, 262)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(112, 32)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Label3"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("굴림", 24.0!)
        Me.label2.ForeColor = System.Drawing.Color.Red
        Me.label2.Location = New System.Drawing.Point(400, 158)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(112, 32)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Label2"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("굴림", 24.0!)
        Me.label1.ForeColor = System.Drawing.Color.Red
        Me.label1.Location = New System.Drawing.Point(408, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(112, 32)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Label1"
        '
        'water_mark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 459)
        Me.ControlBox = False
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "water_mark"
        Me.Text = "water_mark"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timer_mark As Timer
    Friend WithEvents label4 As Label
    Friend WithEvents label3 As Label
    Friend WithEvents label2 As Label
    Friend WithEvents label1 As Label
End Class
