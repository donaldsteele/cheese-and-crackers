<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
    Inherits DarkUI.Forms.DarkForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Groups", 5, 6)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users", 26, 1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainform))
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New DarkUI.Controls.DarkButton()
        Me.Button2 = New DarkUI.Controls.DarkButton()
        Me.SuspendLayout()
        '
        'treeView1
        '
        Me.treeView1.ImageIndex = 0
        Me.treeView1.ImageList = Me.ImageList1
        Me.treeView1.Location = New System.Drawing.Point(20, 101)
        Me.treeView1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.treeView1.Name = "treeView1"
        TreeNode3.ImageIndex = 5
        TreeNode3.Name = "Node0"
        TreeNode3.SelectedImageIndex = 6
        TreeNode3.Tag = "group_root"
        TreeNode3.Text = "Groups"
        TreeNode3.ToolTipText = "Local groups"
        TreeNode4.ImageIndex = 26
        TreeNode4.Name = "Node1"
        TreeNode4.SelectedImageIndex = 1
        TreeNode4.Tag = "user_root"
        TreeNode4.Text = "Users"
        TreeNode4.ToolTipText = "Local users"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Me.treeView1.SelectedImageIndex = 0
        Me.treeView1.Size = New System.Drawing.Size(506, 718)
        Me.treeView1.TabIndex = 3
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "add-1_24.ico")
        Me.ImageList1.Images.SetKeyName(1, "antivirus_24.ico")
        Me.ImageList1.Images.SetKeyName(2, "app_24.ico")
        Me.ImageList1.Images.SetKeyName(3, "archive-1_24.ico")
        Me.ImageList1.Images.SetKeyName(4, "controls-7_24.ico")
        Me.ImageList1.Images.SetKeyName(5, "folder-5_24.ico")
        Me.ImageList1.Images.SetKeyName(6, "folder-9_24.ico")
        Me.ImageList1.Images.SetKeyName(7, "folder-12_24.ico")
        Me.ImageList1.Images.SetKeyName(8, "forbidden_24.ico")
        Me.ImageList1.Images.SetKeyName(9, "id-card-3_24.ico")
        Me.ImageList1.Images.SetKeyName(10, "id-card-4_24.ico")
        Me.ImageList1.Images.SetKeyName(11, "locked_24.ico")
        Me.ImageList1.Images.SetKeyName(12, "locked-1_24.ico")
        Me.ImageList1.Images.SetKeyName(13, "locked-2_24.ico")
        Me.ImageList1.Images.SetKeyName(14, "locked-3_24.ico")
        Me.ImageList1.Images.SetKeyName(15, "padlock-2_24.ico")
        Me.ImageList1.Images.SetKeyName(16, "padlock-3_24.ico")
        Me.ImageList1.Images.SetKeyName(17, "plus_24.ico")
        Me.ImageList1.Images.SetKeyName(18, "settings-2_24.ico")
        Me.ImageList1.Images.SetKeyName(19, "shield_24.ico")
        Me.ImageList1.Images.SetKeyName(20, "shield-1_24.ico")
        Me.ImageList1.Images.SetKeyName(21, "shield-2_24.ico")
        Me.ImageList1.Images.SetKeyName(22, "shield-3_24.ico")
        Me.ImageList1.Images.SetKeyName(23, "siren_24.ico")
        Me.ImageList1.Images.SetKeyName(24, "stop-1_24.ico")
        Me.ImageList1.Images.SetKeyName(25, "success_24.ico")
        Me.ImageList1.Images.SetKeyName(26, "users-1_24.ico")
        Me.ImageList1.Images.SetKeyName(27, "warning_24.ico")
        Me.ImageList1.Images.SetKeyName(28, "zoom-in_24.ico")
        Me.ImageList1.Images.SetKeyName(29, "zoom-out_24.ico")
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(538, 311)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(652, 508)
        Me.TextBox1.TabIndex = 4
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(538, 102)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(655, 185)
        Me.FlowLayoutPanel1.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(562, 16)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 19)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5)
        Me.Button1.Size = New System.Drawing.Size(149, 30)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "DarkButton1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(259, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(5)
        Me.Button2.Size = New System.Drawing.Size(149, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "DarkButton1"
        '
        'mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1218, 829)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.treeView1)
        Me.Font = New System.Drawing.Font("Monoid", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Name = "mainform"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents treeView1 As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As DarkUI.Controls.DarkButton
    Friend WithEvents Button2 As DarkUI.Controls.DarkButton
End Class
