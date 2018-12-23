Imports MaterialSkin
Imports MaterialSkin.Controls
Imports PluginContracts



<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits MaterialSkin.Controls.MaterialForm
    Private _Plugins As Dictionary(Of String, IPlugin)
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Public Sub New(UserList As ArrayList)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim materialSkinManager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance

        materialSkinManager.AddFormToManage(Me)
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK
        materialSkinManager.ColorScheme = New ColorScheme(Primary.Grey700, Primary.Grey900, Primary.Cyan200, Accent.Cyan400, TextShade.WHITE)


        ' Add any initialization after the InitializeComponent() call.
        _Plugins = New Dictionary(Of String, IPlugin)
        Dim plugins As ICollection(Of IPlugin) = PluginLoader.LoadPlugins("Plugins")

        If plugins Is Nothing Then
            Close()
            MessageBox.Show("No plugins loaded. Application Closed.")
            Return
        End If

        For Each item In plugins
            _Plugins.Add(item.Name, item)

            Dim tb As New TabPage
            tb.Name = item.Name
            tb.Text = item.Name

            For Each c As Control In item.Instance.Controls

                Dim btn As Button = TryCast(c, Button)
                If btn IsNot Nothing Then
                    btn.BackColor = materialSkinManager.GetDividersColor

                End If

                Dim lbl As Label = TryCast(c, Label)
                If lbl IsNot Nothing Then
                    lbl.ForeColor = materialSkinManager.GetPrimaryTextColor
                    lbl.BackColor = Color.Transparent
                End If
            Next

            item.Instance.BackColor = materialSkinManager.GetApplicationBackgroundColor
            item.AddUserList(UserList)
            item.Instance.Dock = DockStyle.Fill
            tb.Controls.Add(item.Instance)

            tb.UseVisualStyleBackColor = True
            MaterialTabControl1.TabPages.Add(tb)


        Next
        'since we added new stuff refresh the tab selector 
        ' MaterialTabSelector1.Refresh()


    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MaterialCheckBox1 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.MaterialTabSelector1 = New MaterialSkin.Controls.MaterialTabSelector()
        Me.MaterialTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MaterialTabControl1
        '
        Me.MaterialTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage1)
        Me.MaterialTabControl1.Controls.Add(Me.TabPage2)
        Me.MaterialTabControl1.Depth = 0
        Me.MaterialTabControl1.Location = New System.Drawing.Point(12, 66)
        Me.MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabControl1.Name = "MaterialTabControl1"
        Me.MaterialTabControl1.SelectedIndex = 0
        Me.MaterialTabControl1.Size = New System.Drawing.Size(644, 205)
        Me.MaterialTabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.MaterialLabel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(636, 176)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'MaterialLabel1
        '
        Me.MaterialLabel1.AutoSize = True
        Me.MaterialLabel1.Depth = 0
        Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 11.0!)
        Me.MaterialLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialLabel1.Location = New System.Drawing.Point(181, 59)
        Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialLabel1.Name = "MaterialLabel1"
        Me.MaterialLabel1.Size = New System.Drawing.Size(136, 24)
        Me.MaterialLabel1.TabIndex = 0
        Me.MaterialLabel1.Text = "MaterialLabel1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.MaterialCheckBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(636, 176)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MaterialCheckBox1
        '
        Me.MaterialCheckBox1.AutoSize = True
        Me.MaterialCheckBox1.Depth = 0
        Me.MaterialCheckBox1.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.MaterialCheckBox1.Location = New System.Drawing.Point(65, 79)
        Me.MaterialCheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialCheckBox1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckBox1.Name = "MaterialCheckBox1"
        Me.MaterialCheckBox1.Ripple = True
        Me.MaterialCheckBox1.Size = New System.Drawing.Size(181, 30)
        Me.MaterialCheckBox1.TabIndex = 0
        Me.MaterialCheckBox1.Text = "MaterialCheckBox1"
        Me.MaterialCheckBox1.UseVisualStyleBackColor = True
        '
        'MaterialTabSelector1
        '
        Me.MaterialTabSelector1.BaseTabControl = Me.MaterialTabControl1
        Me.MaterialTabSelector1.Depth = 0
        Me.MaterialTabSelector1.Location = New System.Drawing.Point(2, 25)
        Me.MaterialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialTabSelector1.Name = "MaterialTabSelector1"
        Me.MaterialTabSelector1.Size = New System.Drawing.Size(251, 35)
        Me.MaterialTabSelector1.TabIndex = 1
        Me.MaterialTabSelector1.Text = "MaterialTabSelector1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(668, 300)
        Me.Controls.Add(Me.MaterialTabSelector1)
        Me.Controls.Add(Me.MaterialTabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MaterialTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MaterialTabControl1 As MaterialTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents MaterialTabSelector1 As MaterialTabSelector
    Friend WithEvents MaterialLabel1 As MaterialLabel
    Friend WithEvents MaterialCheckBox1 As MaterialCheckBox


End Class
