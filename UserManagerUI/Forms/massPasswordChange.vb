Public Class massPasswordChange
    Inherits Form
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(UserList As ArrayList)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        For Each u In UserList
            CheckedListBox1.Items.Add(u)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = vbCrLf
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            Dim st As CheckState = CheckedListBox1.GetItemCheckState(i)

            If st = CheckState.Checked Then
                TextBox2.Text = TextBox2.Text & "net user " & Chr(34) & CheckedListBox1.Items(i).ToString & Chr(34) & " " & TextBox1.Text & vbCrLf
            End If
        Next

        TextBox2.Text = TextBox2.Text & "pause" & vbCrLf

        Dim fileName As String = System.IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".bat"
        My.Computer.FileSystem.WriteAllText(fileName, TextBox2.Text.ToString, False, System.Text.Encoding.Default)

        System.Diagnostics.Process.Start(fileName)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class