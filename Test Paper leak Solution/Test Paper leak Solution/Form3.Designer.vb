<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.r_docx = New System.Windows.Forms.RadioButton()
        Me.r_hwp = New System.Windows.Forms.RadioButton()
        Me.file_name = New System.Windows.Forms.TextBox()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.ok_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(173, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "공백은 자동으로 ""_""  으로 치환됩니다"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 27)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "파일명"
        '
        'r_docx
        '
        Me.r_docx.AutoSize = True
        Me.r_docx.Location = New System.Drawing.Point(29, 142)
        Me.r_docx.Name = "r_docx"
        Me.r_docx.Size = New System.Drawing.Size(109, 19)
        Me.r_docx.TabIndex = 11
        Me.r_docx.TabStop = True
        Me.r_docx.Text = "워드(.docx)"
        Me.r_docx.UseVisualStyleBackColor = True
        '
        'r_hwp
        '
        Me.r_hwp.AutoSize = True
        Me.r_hwp.Location = New System.Drawing.Point(29, 107)
        Me.r_hwp.Name = "r_hwp"
        Me.r_hwp.Size = New System.Drawing.Size(101, 19)
        Me.r_hwp.TabIndex = 10
        Me.r_hwp.TabStop = True
        Me.r_hwp.Text = "한글(.hwp)"
        Me.r_hwp.UseVisualStyleBackColor = True
        '
        'file_name
        '
        Me.file_name.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.file_name.Location = New System.Drawing.Point(172, 49)
        Me.file_name.Name = "file_name"
        Me.file_name.Size = New System.Drawing.Size(261, 30)
        Me.file_name.TabIndex = 9
        '
        'cancel_btn
        '
        Me.cancel_btn.Location = New System.Drawing.Point(323, 113)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(112, 48)
        Me.cancel_btn.TabIndex = 8
        Me.cancel_btn.Text = "취소"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'ok_btn
        '
        Me.ok_btn.Location = New System.Drawing.Point(182, 113)
        Me.ok_btn.Name = "ok_btn"
        Me.ok_btn.Size = New System.Drawing.Size(112, 48)
        Me.ok_btn.TabIndex = 7
        Me.ok_btn.Text = "확인"
        Me.ok_btn.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 175)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.r_docx)
        Me.Controls.Add(Me.r_hwp)
        Me.Controls.Add(Me.file_name)
        Me.Controls.Add(Me.cancel_btn)
        Me.Controls.Add(Me.ok_btn)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "New File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents r_docx As RadioButton
    Friend WithEvents r_hwp As RadioButton
    Friend WithEvents file_name As TextBox
    Friend WithEvents cancel_btn As Button
    Friend WithEvents ok_btn As Button
End Class
