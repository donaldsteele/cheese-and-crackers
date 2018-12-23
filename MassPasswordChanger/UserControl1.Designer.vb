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
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.CheckedListBoxColorable1 = New PluginContracts.CheckedListBoxColorable()
        Me.SuspendLayout()
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(17, 46)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(139, 24)
        Me.MaterialLabel1.TabIndex = 0
        Me.MaterialLabel1.Text = "Available Users"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(21, 91)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(257, 128)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'CheckedListBoxColorable1
        '
        Me.CheckedListBoxColorable1.FormattingEnabled = True
        Me.CheckedListBoxColorable1.Location = New System.Drawing.Point(21, 355)
        Me.CheckedListBoxColorable1.Name = "CheckedListBoxColorable1"
        Me.CheckedListBoxColorable1.Size = New System.Drawing.Size(616, 140)
        Me.CheckedListBoxColorable1.Striped = False
        Me.CheckedListBoxColorable1.StripeDarkColor = System.Drawing.Color.Empty
        Me.CheckedListBoxColorable1.TabIndex = 1
        '
        'UserControl1
        '
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.CheckedListBoxColorable1)
        Me.Controls.Add(Me.MaterialLabel1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(686, 627)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents CheckedListBoxColorable1 As PluginContracts.CheckedListBoxColorable
    Friend WithEvents FlowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
End Class
