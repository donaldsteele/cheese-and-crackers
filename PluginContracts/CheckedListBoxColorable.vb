
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

Public Class CheckedListBoxColorable
    Inherits FlowLayoutPanel
    Private _itemsList As ItemsList
    ' Public Property Colors As Dictionary(Of Object, Color)
    Public Property Striped As Boolean
    Public Property StripeDarkColor As Color
    Public Property Items As ItemsList

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Items = New ItemsList(Me)

    End Sub


    'Private Function PerceivedBrightness(ByVal c As Color) As Integer


    '    Dim r As Integer = CInt(c.R) * CInt(c.R) * 0.299
    '    Dim g As Integer = CInt(c.G) * CInt(c.G) * 0.587
    '    Dim b As Integer = CInt(c.B) * CInt(c.B) * 0.114
    '    Return CInt(Math.Sqrt(r + b + g))

    'End Function

    Private Sub CheckedListBoxColorable_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded

    End Sub

    Private Sub CheckedListBoxColorable_ControlRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved

    End Sub

    Private Sub ItemsList_ItemAdded(Index As Integer)

    End Sub
    Private Sub ItemsList_ItemRemoved(ByVal Index As Integer)

    End Sub

    Public Class ItemsList
        Inherits List(Of MaterialSkin.Controls.MaterialCheckBox)
        Private _parent As FlowLayoutPanel


        Public Sub New(parent As FlowLayoutPanel)
            _parent = parent
        End Sub

        Public Event SelectedIndexChanged(ByVal Index As Integer)



        Public Overloads Function Add(text As String)
            Add(text, False)
        End Function

        Public Overloads Function Add(text As String, checked As Boolean)
            Dim cb As New MaterialSkin.Controls.MaterialCheckBox
            cb.Checked = checked
            cb.Text = text
            cb.Width = _parent.Width * 0.75
            Add(cb)
        End Function

        Public Overloads Function Add(ByVal value As MaterialSkin.Controls.MaterialCheckBox) As Integer


            MyBase.Add(value)
            _parent.Controls.Add(value)
        End Function


        Public Overloads Sub Remove(ByVal value As MaterialSkin.Controls.MaterialCheckBox)
            MyBase.Remove(value)
            _parent.Controls.Remove(value)
        End Sub


    End Class



    'Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
    '    Dim item As New CheckedListBoxColorableListItem
    '    Dim newEventArgs As DrawItemEventArgs = e

    '    If e.Index >= 0 And Me.Items.Count > 0 Then
    '        item = (CType(Me.Items(e.Index), CheckedListBoxColorableListItem))
    '        '  Dim ForeGroundColor = (If(PerceivedBrightness(BackGroundColor) > 130, Color.Black, Color.White))

    '        newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, item.BackgroundColor)
    '        If Me.Striped = True And item.BackgroundColor = SystemColors.Control Then
    '            If e.Index Mod 2 Then
    '                newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, ChangeColorBrightness(Me.StripeDarkColor, -0.2))
    '            Else
    '                newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, Me.StripeDarkColor)
    '            End If
    '        End If
    '    End If
    '    MyBase.OnDrawItem(newEventArgs)

    'End Sub


    'Private Function ChangeColorBrightness(ByVal color As Color, ByVal correctionFactor As Single) As Color
    '    Dim red As Single = CSng(color.R)
    '    Dim green As Single = CSng(color.G)
    '    Dim blue As Single = CSng(color.B)

    '    If correctionFactor < 0 Then
    '        correctionFactor = 1 + correctionFactor
    '        red = red * correctionFactor
    '        green = green * correctionFactor
    '        blue = blue * correctionFactor
    '    Else
    '        red = (255 - red) * correctionFactor + red
    '        green = (255 - green) * correctionFactor + green
    '        blue = (255 - blue) * correctionFactor + blue
    '    End If

    '    Return Color.FromArgb(color.A, CInt(red), CInt(green), CInt(blue))
    'End Function


End Class