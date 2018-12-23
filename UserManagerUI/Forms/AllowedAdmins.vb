Public Class AllowedAdmins
    Inherits Form
    Dim _UserList As ArrayList
    Dim _Manager As UserManager
    Dim _GroupList As ArrayList


    Private Sub AllowedAdmins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "Administrators"
        processGroupSelection()
    End Sub

    Sub New(UserList As ArrayList, Grouplist As ArrayList, manager As UserManager)

        ' This call is required by the designer.
        InitializeComponent()

        _UserList = UserList
        _GroupList = Grouplist
        _Manager = manager

        ' Add any initialization after the InitializeComponent() call.

        For i = 0 To Grouplist.Count - 1
            ComboBox1.Items.Add(_GroupList(i))
        Next



        Dim colorObj As New Dictionary(Of Object, Color)

        For i = 0 To UserList.Count - 1
            CheckedListBox1.Items.Add(UserList(i))
            colorObj.Add(UserList(i), SystemColors.ControlText)
        Next

        CheckedListBox1.Colors = colorObj

        'CheckedListBox1.Items.AddRange(colorObj)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        processGroupSelection()

    End Sub

    Sub processGroupSelection()
        Dim lst As New ArrayList
        Dim colorObj As New Dictionary(Of Object, Color)
        lst = _Manager.ListUsersInGroup(ComboBox1.SelectedItem.ToString)
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            Dim isInGroup As Boolean = isUserInGroup(CheckedListBox1.Items(i), lst)
            CheckedListBox1.SetItemChecked(i, isInGroup)
            If isInGroup = True Then
                'colorObj.Add(CheckedListBox1.Items(i), Color.Red)
                CheckedListBox1.Colors(CheckedListBox1.Items(i)) = Color.Yellow
            Else
                'colorObj.Add(CheckedListBox1.Items(i), SystemColors.Control)
                CheckedListBox1.Colors(CheckedListBox1.Items(i)) = Color.White
            End If


        Next
        CheckedListBox1.Refresh()
    End Sub


    Function isUserInGroup(username As String, Grouplist As ArrayList) As Boolean
        For i = 0 To Grouplist.Count - 1
            If username.Trim.ToLower = Grouplist(i).ToString.Trim.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = vbCrLf
        Dim group = ComboBox1.Text

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            Dim st As CheckState = CheckedListBox1.GetItemCheckState(i)
            Dim user = CheckedListBox1.Items(i).ToString

            'Add a new user to this group 
            If st = CheckState.Checked And Not CheckedListBox1.Colors(CheckedListBox1.Items(i)) = Color.Yellow Then


                '   TextBox1.Text = TextBox1.Text & $"wmic UserAccount where name='{user}' set Passwordexpires=true" & vbCrLf
                '  TextBox1.Text = TextBox1.Text & $"net user ""{user}"" /logonpasswordchg:yes" & vbCrLf & vbCrLf

                TextBox1.Text = TextBox1.Text & $"net localgroup ""{group}"" ""{user}"" /add" & vbCrLf

                'they were in the group (highlight of yellow) and are no longer checked
            ElseIf st = CheckState.Unchecked And CheckedListBox1.Colors(CheckedListBox1.Items(i)) = Color.Yellow Then
                TextBox1.Text = TextBox1.Text & $"net localgroup ""{group}"" ""{user}"" /delete" & vbCrLf

            End If
        Next

        TextBox1.Text = TextBox1.Text & "pause" & vbCrLf






    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub
End Class


Public Class CheckedListBoxColorable
    Inherits CheckedListBox

    Public Property Colors As Dictionary(Of Object, Color)

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
        Dim BackGroundColor As Color = e.ForeColor
        Dim item As Object = Nothing

        If e.Index >= 0 Then
            If Me.Items.Count > e.Index Then item = Me.Items(e.Index)

            If item IsNot Nothing AndAlso Me.Colors IsNot Nothing AndAlso Me.Colors.ContainsKey(item) Then
                BackGroundColor = Me.Colors(item)
            End If
        End If

        Dim ForeGroundColor = (If(PerceivedBrightness(BackGroundColor) > 130, Color.Black, Color.White))



        Dim tweakedEventArgs = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, ForeGroundColor, BackGroundColor)
        MyBase.OnDrawItem(tweakedEventArgs)
    End Sub
End Class
