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
        Me.textto = New System.Windows.Forms.TextBox()
        Me.textfrom = New System.Windows.Forms.TextBox()
        Me.textmsg = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textto
        '
        Me.textto.AllowDrop = True
        Me.textto.Location = New System.Drawing.Point(41, 42)
        Me.textto.Name = "textto"
        Me.textto.Size = New System.Drawing.Size(200, 25)
        Me.textto.TabIndex = 0
        Me.textto.Text = "to"
        '
        'textfrom
        '
        Me.textfrom.Location = New System.Drawing.Point(41, 94)
        Me.textfrom.Name = "textfrom"
        Me.textfrom.Size = New System.Drawing.Size(200, 25)
        Me.textfrom.TabIndex = 1
        Me.textfrom.Text = "from"
        '
        'textmsg
        '
        Me.textmsg.Location = New System.Drawing.Point(41, 161)
        Me.textmsg.Name = "textmsg"
        Me.textmsg.Size = New System.Drawing.Size(200, 25)
        Me.textmsg.TabIndex = 2
        Me.textmsg.Text = "msg"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(280, 42)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(362, 190)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 253)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.textmsg)
        Me.Controls.Add(Me.textfrom)
        Me.Controls.Add(Me.textto)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textto As TextBox
    Friend WithEvents textfrom As TextBox
    Friend WithEvents textmsg As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
