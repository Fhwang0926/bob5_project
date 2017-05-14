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
        Me.file_list = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pass_list = New System.Windows.Forms.ListBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.other_list = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.export_btn = New System.Windows.Forms.Button()
        Me.import_btn = New System.Windows.Forms.Button()
        Me.new_btn = New System.Windows.Forms.Button()
        Me.open_btn = New System.Windows.Forms.Button()
        Me.del_btn = New System.Windows.Forms.Button()
        Me.popdown = New System.Windows.Forms.Button()
        Me.popup = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'file_list
        '
        Me.file_list.BackColor = System.Drawing.Color.White
        Me.file_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.file_list.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.file_list.ForeColor = System.Drawing.Color.DarkRed
        Me.file_list.FormattingEnabled = True
        Me.file_list.ItemHeight = 20
        Me.file_list.Location = New System.Drawing.Point(0, 0)
        Me.file_list.Name = "file_list"
        Me.file_list.Size = New System.Drawing.Size(811, 244)
        Me.file_list.TabIndex = 8
        '
        'Timer1
        '
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.TabControl1.Font = New System.Drawing.Font("굴림", 11.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.Location = New System.Drawing.Point(12, 77)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(819, 259)
        Me.TabControl1.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.file_list)
        Me.TabPage1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(811, 227)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "이번 년도"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pass_list)
        Me.TabPage2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(811, 227)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "지난 년도"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pass_list
        '
        Me.pass_list.BackColor = System.Drawing.Color.White
        Me.pass_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.pass_list.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.pass_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pass_list.FormattingEnabled = True
        Me.pass_list.ItemHeight = 20
        Me.pass_list.Location = New System.Drawing.Point(0, 0)
        Me.pass_list.Name = "pass_list"
        Me.pass_list.Size = New System.Drawing.Size(811, 244)
        Me.pass_list.TabIndex = 22
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.other_list)
        Me.TabPage3.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(811, 227)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "한글 문서 외"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'other_list
        '
        Me.other_list.BackColor = System.Drawing.Color.White
        Me.other_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.other_list.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.other_list.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.other_list.FormattingEnabled = True
        Me.other_list.ItemHeight = 20
        Me.other_list.Location = New System.Drawing.Point(0, 0)
        Me.other_list.Name = "other_list"
        Me.other_list.Size = New System.Drawing.Size(811, 244)
        Me.other_list.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(317, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Test Paper Protect Solution"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.export_btn)
        Me.GroupBox1.Controls.Add(Me.import_btn)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(837, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(117, 273)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "파일 공유(File Share)"
        '
        'export_btn
        '
        Me.export_btn.BackColor = System.Drawing.Color.White
        Me.export_btn.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.export_btn.Location = New System.Drawing.Point(6, 157)
        Me.export_btn.Name = "export_btn"
        Me.export_btn.Size = New System.Drawing.Size(105, 104)
        Me.export_btn.TabIndex = 1
        Me.export_btn.Text = "내보내기" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Export)"
        Me.export_btn.UseVisualStyleBackColor = False
        '
        'import_btn
        '
        Me.import_btn.BackColor = System.Drawing.Color.White
        Me.import_btn.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.import_btn.Location = New System.Drawing.Point(6, 42)
        Me.import_btn.Name = "import_btn"
        Me.import_btn.Size = New System.Drawing.Size(105, 104)
        Me.import_btn.TabIndex = 0
        Me.import_btn.Text = "가져오기" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Import)"
        Me.import_btn.UseVisualStyleBackColor = False
        '
        'new_btn
        '
        Me.new_btn.BackColor = System.Drawing.Color.Transparent
        Me.new_btn.BackgroundImage = CType(resources.GetObject("new_btn.BackgroundImage"), System.Drawing.Image)
        Me.new_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.new_btn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold)
        Me.new_btn.Location = New System.Drawing.Point(399, 61)
        Me.new_btn.Name = "new_btn"
        Me.new_btn.Size = New System.Drawing.Size(166, 36)
        Me.new_btn.TabIndex = 22
        Me.new_btn.Text = "새로 만들기(New)"
        Me.new_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.new_btn.UseVisualStyleBackColor = False
        '
        'open_btn
        '
        Me.open_btn.BackColor = System.Drawing.Color.Transparent
        Me.open_btn.BackgroundImage = CType(resources.GetObject("open_btn.BackgroundImage"), System.Drawing.Image)
        Me.open_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.open_btn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold)
        Me.open_btn.Location = New System.Drawing.Point(574, 62)
        Me.open_btn.Name = "open_btn"
        Me.open_btn.Size = New System.Drawing.Size(129, 36)
        Me.open_btn.TabIndex = 23
        Me.open_btn.Text = "열기(Open)"
        Me.open_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.open_btn.UseVisualStyleBackColor = False
        '
        'del_btn
        '
        Me.del_btn.BackColor = System.Drawing.Color.Transparent
        Me.del_btn.BackgroundImage = CType(resources.GetObject("del_btn.BackgroundImage"), System.Drawing.Image)
        Me.del_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.del_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.del_btn.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold)
        Me.del_btn.Location = New System.Drawing.Point(711, 63)
        Me.del_btn.Name = "del_btn"
        Me.del_btn.Size = New System.Drawing.Size(118, 36)
        Me.del_btn.TabIndex = 24
        Me.del_btn.Text = "삭제(Del)"
        Me.del_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.del_btn.UseVisualStyleBackColor = False
        '
        'popdown
        '
        Me.popdown.BackgroundImage = CType(resources.GetObject("popdown.BackgroundImage"), System.Drawing.Image)
        Me.popdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.popdown.Location = New System.Drawing.Point(626, 10)
        Me.popdown.Name = "popdown"
        Me.popdown.Size = New System.Drawing.Size(203, 39)
        Me.popdown.TabIndex = 25
        Me.popdown.UseVisualStyleBackColor = True
        '
        'popup
        '
        Me.popup.BackgroundImage = CType(resources.GetObject("popup.BackgroundImage"), System.Drawing.Image)
        Me.popup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.popup.Location = New System.Drawing.Point(626, 10)
        Me.popup.Name = "popup"
        Me.popup.Size = New System.Drawing.Size(203, 39)
        Me.popup.TabIndex = 26
        Me.popup.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("굴림", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(378, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "P.K 팀에서 제작한 시험지 보호 솔루션 입니다"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Azure
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(960, 352)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.del_btn)
        Me.Controls.Add(Me.open_btn)
        Me.Controls.Add(Me.new_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.popdown)
        Me.Controls.Add(Me.popup)
        Me.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Test Paper Protect Solution - P.K Team"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents file_list As ListBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pass_list As ListBox
    Friend WithEvents other_list As ListBox
    Friend WithEvents new_btn As Button
    Friend WithEvents open_btn As Button
    Friend WithEvents del_btn As Button
    Friend WithEvents popdown As Button
    Friend WithEvents popup As Button
    Friend WithEvents export_btn As Button
    Friend WithEvents import_btn As Button
    Friend WithEvents Label2 As Label
End Class
