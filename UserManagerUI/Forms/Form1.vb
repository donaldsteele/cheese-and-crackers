Public Class Form1
    Private Sub MaterialSingleLineTextField1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Not Me.WindowState = FormWindowState.Minimized Then
            '    MaterialTabControl1.Width = Me.Width
            '   MaterialTabControl1.Height = MaterialTabControl1.Top - Me.Height
            MaterialTabSelector1.Width = Me.Width
        End If
    End Sub
End Class
