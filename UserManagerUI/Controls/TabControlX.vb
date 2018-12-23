Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace MyTabControl
    Public Partial Class TabControlX
        Inherits UserControl

        Public Sub New()

        End Sub

        Private selected_index As Integer = -1
        Public buttonlist As List(Of ButtonX)
        Public tabPanelCtrlList As List(Of TabPanelControl)

        Private Sub UpdateButtons()
            If buttonlist.Count > 0 Then

                For i As Integer = 0 To buttonlist.Count - 1

                    If i = selected_index Then
                        buttonlist(i).ChangeColorMouseHC = False
                        buttonlist(i).BXBackColor = Color.FromArgb(20, 120, 240)
                        buttonlist(i).ForeColor = Color.White
                        buttonlist(i).MouseHoverColor = Color.FromArgb(20, 120, 240)
                        buttonlist(i).MouseClickColor1 = Color.FromArgb(20, 120, 240)
                    Else
                        buttonlist(i).ChangeColorMouseHC = True
                        buttonlist(i).ForeColor = Color.White
                        buttonlist(i).MouseHoverColor = Color.FromArgb(20, 120, 240)
                        buttonlist(i).BXBackColor = Color.FromArgb(40, 40, 40)
                        buttonlist(i).MouseClickColor1 = Color.FromArgb(20, 80, 200)
                    End If
                Next
            End If
        End Sub

        Private Sub createAndAddButton(ByVal tabtext As String, ByVal tpcontrol As TabPanelControl, ByVal loc As Point)
            Dim b As ButtonX = New ButtonX()
            b.DisplayText = tabtext
            b.Text = tabtext
            b.Size = New Size(130, 30)
            b.Location = loc
            b.ForeColor = Color.White
            b.BXBackColor = Color.FromArgb(20, 120, 240)
            b.MouseHoverColor = Color.FromArgb(20, 120, 240)
            b.MouseClickColor1 = Color.FromArgb(20, 80, 200)
            b.ChangeColorMouseHC = False
            b.TextLocation_X = 10
            b.TextLocation_Y = 9
            b.Font = Me.Font
            AddHandler b.Click, AddressOf button_Click
            TabButtonPanel.Controls.Add(b)
            buttonlist.Add(b)
            selected_index += 1
            tabPanelCtrlList.Add(tpcontrol)
            TabPanel.Controls.Clear()
            TabPanel.Controls.Add(tpcontrol)
            UpdateButtons()
        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim btext As String = (CType(sender, ButtonX)).Text
            Dim i As Integer, index As Integer = 0

            For i = 0 To buttonlist.Count - 1

                If buttonlist(i).Text Is btext Then
                    index = i
                End If
            Next

            TabPanel.Controls.Clear()
            TabPanel.Controls.Add(tabPanelCtrlList(index))
            selected_index = (CType(sender, ButtonX)).TabIndex
            UpdateButtons()
        End Sub

        Public Sub AddTab(ByVal tabtext As String, ByVal tpcontrol As TabPanelControl)
            If Not buttonlist.Any() Then
                createAndAddButton(tabtext, tpcontrol, New Point(0, 0))
            Else
                createAndAddButton(tabtext, tpcontrol, New Point(buttonlist(buttonlist.Count - 1).Size.Width + buttonlist(buttonlist.Count - 1).Location.X, 0))
            End If
        End Sub

        Private Sub toolStripButton1_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs)
            toolStripDropDownButton1.DropDownItems.Clear()
            Dim mergeindex As Integer = 0

            For i As Integer = 0 To buttonlist.Count - 1
                Dim tbr As ToolStripMenuItem = New ToolStripMenuItem()
                tbr.Text = buttonlist(i).Text
                tbr.MergeIndex = mergeindex

                If selected_index = i Then
                    tbr.Checked = True
                End If

                AddHandler tbr.Click, AddressOf tbr_Click
                toolStripDropDownButton1.DropDownItems.Add(tbr)
                mergeindex += 1
            Next
        End Sub

        Private btstrlist As List(Of String)

        Private Sub BackToFront_SelButton()
            Dim i As Integer = 0
            TabButtonPanel.Controls.Clear()
            btstrlist.Clear()

            For i = 0 To buttonlist.Count - 1
                btstrlist.Add(buttonlist(i).Text)
            Next

            buttonlist.Clear()

            For j As Integer = 0 To btstrlist.Count - 1

                If j = 0 Then
                    Dim b As ButtonX = New ButtonX()
                    b.DisplayText = btstrlist(j)
                    b.Text = btstrlist(j)
                    b.Size = New Size(130, 30)
                    b.Location = New Point(0, 0)
                    b.ForeColor = Color.White
                    b.BXBackColor = Color.FromArgb(20, 120, 240)
                    b.MouseHoverColor = Color.FromArgb(20, 120, 240)
                    b.MouseClickColor1 = Color.FromArgb(20, 80, 200)
                    b.ChangeColorMouseHC = False
                    b.TextLocation_X = 10
                    b.TextLocation_Y = 9
                    b.Font = Me.Font
                    AddHandler b.Click, AddressOf button_Click
                    TabButtonPanel.Controls.Add(b)
                    buttonlist.Add(b)
                    selected_index += 1
                ElseIf j > 0 Then
                    Dim b As ButtonX = New ButtonX()
                    b.DisplayText = btstrlist(j)
                    b.Text = btstrlist(j)
                    b.Size = New Size(130, 30)
                    b.ForeColor = Color.White
                    b.BXBackColor = Color.FromArgb(20, 120, 240)
                    b.MouseHoverColor = Color.FromArgb(20, 120, 240)
                    b.MouseClickColor1 = Color.FromArgb(20, 80, 200)
                    b.ChangeColorMouseHC = False
                    b.TextLocation_X = 10
                    b.TextLocation_Y = 9
                    b.Font = Me.Font
                    AddHandler b.Click, AddressOf button_Click
                    b.Location = New Point(buttonlist(j - 1).Size.Width + buttonlist(j - 1).Location.X, 0)
                    TabButtonPanel.Controls.Add(b)
                    buttonlist.Add(b)
                    selected_index += 1
                End If
            Next

            TabPanel.Controls.Clear()
        End Sub

        Private Sub tbr_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim i As Integer

            For k As Integer = 0 To (CType(sender, ToolStripMenuItem)).MergeIndex - 1
                Dim j As Integer = 0

                For i = (CType(sender, ToolStripMenuItem)).MergeIndex To 0
                    Dim but As ButtonX = buttonlist(i)
                    Dim temp As ButtonX = buttonlist(j)
                    buttonlist(i) = temp
                    buttonlist(j) = but
                    Dim uct1 As TabPanelControl = tabPanelCtrlList(i)
                    Dim tempusr As TabPanelControl = tabPanelCtrlList(j)
                    tabPanelCtrlList(i) = tempusr
                    tabPanelCtrlList(j) = uct1
                Next
            Next

            Dim btext As String = (CType(sender, ToolStripMenuItem)).Text
            BackToFront_SelButton()
            selected_index = 0
            TabPanel.Controls.Add(tabPanelCtrlList(buttonlist(0).TabIndex))
            UpdateButtons()
        End Sub

        Public Sub RemoveTab(ByVal index As Integer)
            If index >= 0 AndAlso buttonlist.Count > 0 AndAlso index < buttonlist.Count Then
                buttonlist.RemoveAt(index)
                tabPanelCtrlList.RemoveAt(index)
                BackToFront_SelButton()

                If buttonlist.Count > 1 Then

                    If index - 1 >= 0 Then
                        TabPanel.Controls.Add(tabPanelCtrlList(index - 1))
                    Else
                        TabPanel.Controls.Add(tabPanelCtrlList((index - 1) + 1))
                        selected_index = (index - 1) + 1
                    End If
                End If

                selected_index = index - 1

                If buttonlist.Count = 1 Then
                    TabPanel.Controls.Add(tabPanelCtrlList(0))
                    selected_index = 0
                End If
            End If

            UpdateButtons()
        End Sub
    End Class
End Namespace
