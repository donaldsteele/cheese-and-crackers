
Imports System.Drawing
Imports System.Windows.Forms

Public Class CheckedListBoxColorable
    Inherits Panel
    Private _itemsList As ItemsList
    Public Property Striped As Boolean
    Public Property StripeDarkColor As Color
    Public Property Items As ItemsList

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.Items = New ItemsList(Me)
        Me.AutoScroll = True
    End Sub
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResumeLayout(False)
    End Sub

    Public Class ItemsList
        Inherits List(Of MaterialSkin.Controls.MaterialCheckBox)
        Private _parent As Panel


        Public Sub New(parent As Panel)
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
            '    cb.Width = _parent.Width * 0.75
            Add(cb)
        End Function

        Public Overloads Function Add(ByVal value As MaterialSkin.Controls.MaterialCheckBox) As Integer

            value.Dock = DockStyle.Bottom
            MyBase.Add(value)
            _parent.Controls.Add(value)
        End Function


        Public Overloads Sub Remove(ByVal value As MaterialSkin.Controls.MaterialCheckBox)
            MyBase.Remove(value)
            _parent.Controls.Remove(value)
        End Sub

    End Class

End Class