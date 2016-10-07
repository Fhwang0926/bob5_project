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
        Me.ok_btn = New System.Windows.Forms.Button()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.file_name = New System.Windows.Forms.TextBox()
        Me.r_hwp = New System.Windows.Forms.RadioButton()
        Me.r_docx = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ok_btn
        '
        Me.ok_btn.Location = New System.Drawing.Point(188, 111)
        Me.ok_btn.Name = "ok_btn"
        Me.ok_btn.Size = New System.Drawing.Size(112, 48)
        Me.ok_btn.TabIndex = 0
        Me.ok_btn.Text = "확인"
        Me.ok_btn.UseVisualStyleBackColor = True
        '
        'cancel_btn
        '
        Me.cancel_btn.Location = New System.Drawing.Point(329, 111)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(112, 48)
        Me.cancel_btn.TabIndex = 1
        Me.cancel_btn.Text = "취소"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'file_name
        '
        Me.file_name.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.file_name.Location = New System.Drawing.Point(178, 47)
        Me.file_name.Name = "file_name"
        Me.file_name.Size = New System.Drawing.Size(261, 30)
        Me.file_name.TabIndex = 2
        '
        'r_hwp
        '
        Me.r_hwp.AutoSize = True
        Me.r_hwp.Location = New System.Drawing.Point(35, 105)
        Me.r_hwp.Name = "r_hwp"
        Me.r_hwp.Size = New System.Drawing.Size(101, 19)
        Me.r_hwp.TabIndex = 3
        Me.r_hwp.TabStop = True
        Me.r_hwp.Text = "한글(.hwp)"
        Me.r_hwp.UseVisualStyleBackColor = True
        '
        'r_docx
        '
        Me.r_docx.AutoSize = True
        Me.r_docx.Location = New System.Drawing.Point(35, 140)
        Me.r_docx.Name = "r_docx"
        Me.r_docx.Size = New System.Drawing.Size(109, 19)
        Me.r_docx.TabIndex = 4
        Me.r_docx.TabStop = True
        Me.r_docx.Text = "워드(.docx)"
        Me.r_docx.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "파일명"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(179, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "공백은 자동으로 ""_""  으로 치환됩니다"
        '
        'Form2
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(482, 222)
        Me.MinimumSize = New System.Drawing.Size(482, 222)
        Me.Name = "Form2"
        Me.Text = "New File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ok_btn As Button
    Friend WithEvents cancel_btn As Button
    Friend WithEvents file_name As TextBox
    Friend WithEvents r_hwp As RadioButton
    Friend WithEvents r_docx As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
