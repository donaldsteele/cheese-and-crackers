
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

Public Class CheckedListBoxColorable
    Inherits CheckedListBox

    ' Public Property Colors As Dictionary(Of Object, Color)
    Public Property Striped As Boolean
    Public Property StripeDarkColor As Color


    Public Sub New()
        Me.DoubleBuffered = True
    End Sub


    Private Function PerceivedBrightness(ByVal c As Color) As Integer


        Dim r As Integer = CInt(c.R) * CInt(c.R) * 0.299
        Dim g As Integer = CInt(c.G) * CInt(c.G) * 0.587
        Dim b As Integer = CInt(c.B) * CInt(c.B) * 0.114
        Return CInt(Math.Sqrt(r + b + g))

    End Function

    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
        Dim item As New CheckedListBoxColorableListItem
        Dim newEventArgs As DrawItemEventArgs = e

        If e.Index >= 0 And Me.Items.Count > 0 Then
            item = (CType(Me.Items(e.Index), CheckedListBoxColorableListItem))
            '  Dim ForeGroundColor = (If(PerceivedBrightness(BackGroundColor) > 130, Color.Black, Color.White))

            newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, item.BackgroundColor)
            If Me.Striped = True And item.BackgroundColor = SystemColors.Control Then
                If e.Index Mod 2 Then
                    newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, ChangeColorBrightness(Me.StripeDarkColor, -0.2))
                Else
                    newEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, item.ForegroundColor, Me.StripeDarkColor)
                End If
            End If
        End If
        MyBase.OnDrawItem(newEventArgs)

    End Sub


    Private Function ChangeColorBrightness(ByVal color As Color, ByVal correctionFactor As Single) As Color
        Dim red As Single = CSng(color.R)
        Dim green As Single = CSng(color.G)
        Dim blue As Single = CSng(color.B)

        If correctionFactor < 0 Then
            correctionFactor = 1 + correctionFactor
            red = red * correctionFactor
            green = green * correctionFactor
            blue = blue * correctionFactor
        Else
            red = (255 - red) * correctionFactor + red
            green = (255 - green) * correctionFactor + green
            blue = (255 - blue) * correctionFactor + blue
        End If

        Return Color.FromArgb(color.A, CInt(red), CInt(green), CInt(blue))
    End Function


End Class