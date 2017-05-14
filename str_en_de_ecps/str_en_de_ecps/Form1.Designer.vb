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
        Me.txtOringin = New System.Windows.Forms.RichTextBox()
        Me.txtSeed = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtOringin
        '
        Me.txtOringin.Location = New System.Drawing.Point(38, 22)
        Me.txtOringin.Name = "txtOringin"
        Me.txtOringin.Size = New System.Drawing.Size(589, 136)
        Me.txtOringin.TabIndex = 0
        Me.txtOringin.Text = "password"
        '
        'txtSeed
        '
        Me.txtSeed.Location = New System.Drawing.Point(38, 191)
        Me.txtSeed.Name = "txtSeed"
        Me.txtSeed.Size = New System.Drawing.Size(589, 136)
        Me.txtSeed.TabIndex = 1
        Me.txtSeed.Text = "salt"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(38, 356)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(589, 136)
        Me.RichTextBox3.TabIndex = 2
        Me.RichTextBox3.Text = "ouput"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(675, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(369, 233)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "암호화"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(675, 269)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(369, 233)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "복호화"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 514)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.txtSeed)
        Me.Controls.Add(Me.txtOringin)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtOringin As RichTextBox
    Friend WithEvents txtSeed As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
