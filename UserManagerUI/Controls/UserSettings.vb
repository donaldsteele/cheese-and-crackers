Public Class UserSettings


    Sub New(Settings As Dictionary(Of String, Boolean))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        For Each item In Settings
            CheckedListBox1.Items.Add(item.Key.ToString, item.Value)
        Next

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub
End Class
