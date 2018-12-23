Imports System.Windows.Forms
Imports MaterialSkin.Controls

Public Class UserControl1
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function LoadUsers(UserList As ArrayList)
        ' CheckedListBoxColorable1.Striped = True
        ' CheckedListBoxColorable1.StripeDarkColor = Drawing.Color.DarkGray

        For Each u As String In UserList
            Dim c As New MaterialCheckBox
            ' c.Checked = True
            ' c.Text = u
            ' c.Width = FlowLayoutPanel1.Width * 0.75
            ' FlowLayoutPanel1.Controls.Add(c)
            ' Dim b As New PluginContracts.CheckedListBoxColorableListItem(u)
            CheckedListBoxColorable1.Items.Add(u, True)
        Next
    End Function


End Class
