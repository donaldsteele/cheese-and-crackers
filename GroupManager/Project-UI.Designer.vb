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
        Me.MaterialComboBox1 = New MaterialSkin.Controls.MaterialComboBox()
        Me.SuspendLayout()
        '
        'MaterialComboBox1
        '
        Me.MaterialComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaterialComboBox1.Depth = 0
        Me.MaterialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaterialComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.MaterialComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialComboBox1.FormattingEnabled = True
        Me.MaterialComboBox1.Location = New System.Drawing.Point(50, 44)
        Me.MaterialComboBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialComboBox1.Name = "MaterialComboBox1"
        Me.MaterialComboBox1.Size = New System.Drawing.Size(121, 26)
        Me.MaterialComboBox1.TabIndex = 0
        '
        'UserControl1
        '
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.MaterialComboBox1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(686, 627)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MaterialComboBox1 As MaterialSkin.Controls.MaterialComboBox
End Class
