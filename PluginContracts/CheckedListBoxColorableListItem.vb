Imports System.Drawing

Public Class CheckedListBoxColorableListItem
    Inherits Object

    Public Overridable Property Text As String
    Public Overridable Property Tag As Object
    Public Overridable Property [Object] As Object
    Public Overridable Property Name As String
    Public Overridable Property ForegroundColor As Color
    Public Overridable Property BackgroundColor As Color

    Public Sub New()
        Me.Text = String.Empty
        Me.Tag = Nothing
        Me.Name = String.Empty
        Me.Object = Nothing
        Me.ForegroundColor = SystemColors.ControlText
        Me.BackgroundColor = SystemColors.Control
    End Sub
    Public Sub New(ByVal [Object] As Object, ByVal ForegroundColor As Color, ByVal BackgroundColor As Color)
        Me.Text = [Object].ToString
        Me.Tag = [Object].ToString
        Me.Name = [Object].ToString
        Me.Object = [Object]
        Me.ForegroundColor = ForegroundColor
        Me.BackgroundColor = BackgroundColor
    End Sub
    Public Sub New(ByVal Text As String, ByVal Name As String, ByVal Tag As Object, ByVal [Object] As Object, ByVal ForegroundColor As Color, ByVal BackgroundColor As Color)
        Me.Text = Text
        Me.Tag = Tag
        Me.Name = Name
        Me.Object = [Object]
        Me.ForegroundColor = ForegroundColor
        Me.BackgroundColor = BackgroundColor
    End Sub
    Public Sub New(ByVal Text As String, ByVal Name As String, ByVal Tag As Object, ByVal [Object] As Object, ByVal ForegroundColor As Color)
        Me.Text = Text
        Me.Tag = Tag
        Me.Name = Name
        Me.Object = [Object]
        Me.ForegroundColor = ForegroundColor
        Me.BackgroundColor = SystemColors.Control
    End Sub

    Public Sub New(ByVal Text As String, ByVal Name As String, ByVal Tag As Object, ByVal [Object] As Object)
        Me.Text = Text
        Me.Tag = Tag
        Me.Name = Name
        Me.Object = [Object]
        Me.ForegroundColor = SystemColors.ControlText
        Me.BackgroundColor = SystemColors.Control
    End Sub

    Public Sub New(ByVal [Object] As Object)
        Me.Text = [Object].ToString()
        Me.Name = [Object].ToString()
        Me.Object = [Object]
        Me.ForegroundColor = SystemColors.ControlText
        Me.BackgroundColor = SystemColors.Control
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Text
    End Function
End Class


