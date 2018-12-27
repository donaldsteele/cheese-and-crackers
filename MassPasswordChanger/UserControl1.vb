Imports System.Windows.Forms
Imports MaterialSkin.Controls

Public Class UserControl1
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.TextBox1.BackColor = Me.MaterialSingleLineTextField1.BackColor
        '   Me.TextBox1.Font = Me.MaterialSingleLineTextField1.Font

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
            MaterialCheckedListBox1.Items.Add(u, True)
        Next
    End Function

    Private Sub CheckedListBoxColorable1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        txtScript.Text = vbCrLf
        For i As Integer = 0 To MaterialCheckedListBox1.Items.Count - 1
            Dim st As CheckState = MaterialCheckedListBox1.GetItemCheckState(i)

            If st = CheckState.Checked Then
                txtScript.Text = txtScript.Text & "net user " & Chr(34) & MaterialCheckedListBox1.Items(i).Text & Chr(34) & " " & txtPassword.Text & vbCrLf
            End If
        Next

        txtScript.Text = txtScript.Text & "pause" & vbCrLf
    End Sub
End Class
