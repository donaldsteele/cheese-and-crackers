Partial Public Class mainform
    Inherits DarkUI.Forms.DarkForm


    Dim UsersList As New ArrayList
    Dim GroupList As New ArrayList
    Dim Manager As UserManager



    Public Sub New()
        InitializeComponent()
        Me.Text = "Users & Groups Browser - Computername: " & Environment.MachineName
        Init()
    End Sub


    Private Sub Init()
        Dim um As UserManager = New UserManager()
        Manager = um
        Dim lst As ArrayList = New ArrayList()
        GroupList = um.ListGroupsInServer()
        Dim root As TreeNode = New TreeNode()
        root = treeView1.Nodes(0)
        root.Nodes.Clear()

        For Each o As Object In GroupList
            Dim node As TreeNode = New TreeNode(o.ToString()) With {
                .ImageIndex = 0,
                .SelectedImageIndex = 0
            }
            root.Nodes.Add(node)
        Next


        UsersList = um.ListUsersInServer()

        root = treeView1.Nodes(1)
        root.Nodes.Clear()

        For Each o As Object In UsersList
            Dim node As TreeNode = New TreeNode(o.ToString()) With {
                .ImageIndex = 1,
                .SelectedImageIndex = 1
            }
            root.Nodes.Add(node)
        Next
        um = Nothing
    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles treeView1.NodeMouseClick

        If (e.Node.Parent IsNot Nothing) AndAlso (e.Button = MouseButtons.Left) Then
            Dim um As UserManager = New UserManager()
            Dim lst As ArrayList = New ArrayList()
            TextBox1.Text = ""
            Dim UserPermissions As New Dictionary(Of String, Boolean)

            If e.Node.Parent.Tag.ToString() = "user_root" Then
                TextBox1.Text += "User: " & e.Node.Text & vbCrLf & vbCrLf & "Properties:" & vbCrLf
                lst = um.UserProperties(e.Node.Text)

                For Each o As Object In lst
                    TextBox1.Text += o.ToString() & vbCrLf




                    If o.ToString().IndexOf("UserFlags") >= 0 Then

                        Dim items As Array
                        items = System.Enum.GetValues(GetType(UserManager.ADAccountOptions))



                        Dim val As Integer = Convert.ToInt32(o.ToString().Substring(o.ToString().IndexOf("="c) + 1))

                        Dim item As String
                        For Each item In items
                            Dim tmpval As UserManager.ADAccountOptions = [Enum].Parse(GetType(UserManager.ADAccountOptions), item)
                            '   TextBox1.Text += "Option " & [Enum].GetName(GetType(UserManager.ADAccountOptions), CInt(item)) & vbTab & ((CInt(tmpval) Or val) = val) & vbCrLf

                            UserPermissions.Add([Enum].GetName(GetType(UserManager.ADAccountOptions), CInt(item)), ((CInt(tmpval) Or val) = val))
                        Next
                        TextBox1.Text += vbCrLf
                        TextBox1.Text += vbCrLf
                    End If
                Next
            End If

            Dim u As New UserSettings(UserPermissions)
            FlowLayoutPanel1.Controls.Add(u)

            u.Width = FlowLayoutPanel1.Width


            If e.Node.Parent.Tag.ToString() = "group_root" Then
                lst = um.GroupProperties(e.Node.Text)
                TextBox1.Text = "Group: " & e.Node.Text & vbCrLf & vbCrLf & "Properties:" & vbCrLf

                For Each o As Object In lst
                    TextBox1.Text += o.ToString() & vbCrLf
                Next

                lst = um.ListUsersInGroup(e.Node.Text)
                TextBox1.Text += vbCrLf & "Members:" & vbCrLf

                For Each o As Object In lst
                    TextBox1.Text += o.ToString() & vbCrLf
                Next
            End If

            um = Nothing
        End If
    End Sub

    'Private Sub newUserToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim frm As FormAddUser = New FormAddUser()
    '    frm.ShowDialog()
    '    frm = Nothing
    'End Sub

    'Private Sub addOptionFlagToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim frm As FormOptions = New FormOptions(1)
    '    frm.ShowDialog()
    '    frm = Nothing
    'End Sub

    'Private Sub removeOptionFlagToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim frm As FormOptions = New FormOptions(2)
    '    frm.ShowDialog()
    '    frm = Nothing
    'End Sub

    'Private Sub newGroupToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim frm As FormAddGroup = New FormAddGroup()
    '    frm.ShowDialog()
    '    frm = Nothing
    'End Sub

    Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Init()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ms As New MediaPlayer
        Dim b As New splash
        b.Show()
        ms.Play()
    End Sub

    Private Sub treeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeView1.AfterSelect

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim up As New massPasswordChange(UsersList)
        up.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim ug As New AllowedAdmins(UsersList, GroupList, Manager)
        ug.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim A As New Form1(UsersList)
        A.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim up As New massPasswordChange(UsersList)
        up.ShowDialog()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ug As New AllowedAdmins(UsersList, GroupList, Manager)
        ug.ShowDialog()
    End Sub
End Class
