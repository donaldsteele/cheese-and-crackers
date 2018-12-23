Public Class CustomTabControl
    Inherits TabControl
    Private Sub TabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        Dim tabctl As TabControl = DirectCast(sender, TabControl)
        Dim g As Graphics = e.Graphics
        'Dim bg As New SolidBrush(Color.Black)
        Dim bg As New SolidBrush(Color.FromArgb(255, 42, 47, 49))
        Dim brush As New SolidBrush(Color.FromArgb(255, 111, 140, 141))
        Dim tabTextArea As RectangleF = RectangleF.op_Implicit(tabctl.GetTabRect(e.Index))
        If tabctl.SelectedIndex = e.Index Then
            Font = New Font(Me.Font, FontStyle.Bold)
            brush = New SolidBrush(Color.FromArgb(255, 250, 158, 88))
        End If

        g.FillRectangle(bg, e.Bounds)

        g.DrawString(tabctl.TabPages(e.Index).Text, Font, brush, tabTextArea)
    End Sub

End Class
