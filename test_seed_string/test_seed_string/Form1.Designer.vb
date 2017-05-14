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
        Me.btEncrypt = New System.Windows.Forms.Button()
        Me.btDecrypt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtOringin
        '
        Me.txtOringin.Location = New System.Drawing.Point(53, 51)
        Me.txtOringin.Name = "txtOringin"
        Me.txtOringin.Size = New System.Drawing.Size(392, 86)
        Me.txtOringin.TabIndex = 0
        Me.txtOringin.Text = ""
        '
        'txtSeed
        '
        Me.txtSeed.Location = New System.Drawing.Point(53, 274)
        Me.txtSeed.Name = "txtSeed"
        Me.txtSeed.Size = New System.Drawing.Size(392, 86)
        Me.txtSeed.TabIndex = 1
        Me.txtSeed.Text = ""
        '
        'btEncrypt
        '
        Me.btEncrypt.Location = New System.Drawing.Point(510, 51)
        Me.btEncrypt.Name = "btEncrypt"
        Me.btEncrypt.Size = New System.Drawing.Size(273, 94)
        Me.btEncrypt.TabIndex = 2
        Me.btEncrypt.Text = "btEncrypt"
        Me.btEncrypt.UseVisualStyleBackColor = True
        '
        'btDecrypt
        '
        Me.btDecrypt.Location = New System.Drawing.Point(510, 266)
        Me.btDecrypt.Name = "btDecrypt"
        Me.btDecrypt.Size = New System.Drawing.Size(273, 94)
        Me.btDecrypt.TabIndex = 3
        Me.btDecrypt.Text = "btDecrypt"
        Me.btDecrypt.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 533)
        Me.Controls.Add(Me.btDecrypt)
        Me.Controls.Add(Me.btEncrypt)
        Me.Controls.Add(Me.txtSeed)
        Me.Controls.Add(Me.txtOringin)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtOringin As RichTextBox
    Friend WithEvents txtSeed As RichTextBox
    Friend WithEvents btEncrypt As Button
    Friend WithEvents btDecrypt As Button
End Class
