<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl1
    Inherits Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MaterialCheckedListBox1 = New MaterialSkin.Controls.MaterialCheckedListBox()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        Me.txtPassword = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.txtScript = New MaterialSkin.Controls.MaterialMultiLineTextField()
        Me.SuspendLayout()
        '
        'MaterialCheckedListBox1
        '
        Me.MaterialCheckedListBox1.AutoScroll = True
        Me.MaterialCheckedListBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialCheckedListBox1.Depth = 0
        Me.MaterialCheckedListBox1.Location = New System.Drawing.Point(25, 91)
        Me.MaterialCheckedListBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckedListBox1.Name = "MaterialCheckedListBox1"
        Me.MaterialCheckedListBox1.Size = New System.Drawing.Size(287, 428)
        Me.MaterialCheckedListBox1.Striped = False
        Me.MaterialCheckedListBox1.StripeDarkColor = System.Drawing.Color.Empty
        Me.MaterialCheckedListBox1.TabIndex = 7
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.AutoSize = True
        Me.MaterialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Icon = Nothing
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(559, 558)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = False
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(73, 36)
        Me.MaterialRaisedButton2.TabIndex = 6
        Me.MaterialRaisedButton2.Text = "Cancel"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = True
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.AutoSize = True
        Me.MaterialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Icon = Nothing
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(331, 558)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(167, 36)
        Me.MaterialRaisedButton1.TabIndex = 5
        Me.MaterialRaisedButton1.Text = "Generate And Apply"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'MaterialLabel2
        '
        Me.MaterialLabel2.AutoSize = True
        Me.MaterialLabel2.Depth = 0
        Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel2.Location = New System.Drawing.Point(21, 549)
        Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel2.Name = "MaterialLabel2"
        Me.MaterialLabel2.Size = New System.Drawing.Size(135, 19)
        Me.MaterialLabel2.TabIndex = 3
        Me.MaterialLabel2.Text = "Set New Password"
        '
        'txtPassword
        '
        Me.txtPassword.Depth = 0
        Me.txtPassword.Hint = ""
        Me.txtPassword.Location = New System.Drawing.Point(21, 571)
        Me.txtPassword.MaxLength = 32767
        Me.txtPassword.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.SelectionLength = 0
        Me.txtPassword.SelectionStart = 0
        Me.txtPassword.Size = New System.Drawing.Size(291, 23)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.TabStop = False
        Me.txtPassword.Text = "Cyb3rPatr1ot!"
        Me.txtPassword.UseSystemPasswordChar = False
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(17, 46)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(113, 19)
        Me.MaterialLabel1.TabIndex = 0
        Me.MaterialLabel1.Text = "Available Users"
        '
        'txtScript
        '
        Me.txtScript.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtScript.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtScript.Depth = 0
        Me.txtScript.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtScript.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtScript.Hint = ""
        Me.txtScript.Location = New System.Drawing.Point(378, 91)
        Me.txtScript.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtScript.Multiline = True
        Me.txtScript.Name = "txtScript"
        Me.txtScript.Size = New System.Drawing.Size(254, 428)
        Me.txtScript.TabIndex = 8
        Me.txtScript.Text = "Hello " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "world" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "this" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a t" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "est"
        '
        'UserControl1
        '
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtScript)
        Me.Controls.Add(Me.MaterialCheckedListBox1)
        Me.Controls.Add(Me.MaterialRaisedButton2)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.MaterialLabel2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(686, 627)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents txtPassword As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialCheckedListBox1 As MaterialSkin.Controls.MaterialCheckedListBox
    Friend WithEvents txtScript As MaterialSkin.Controls.MaterialMultiLineTextField
End Class
