Imports PluginContracts

Public Class Project
    Implements IPlugin
    Private _instance As Windows.Forms.UserControl

    Public ReadOnly Property Name As String Implements IPlugin.Name
        Get
            Return "Group Manager"
        End Get
    End Property

    Public Function Instance() As Windows.Forms.UserControl Implements IPlugin.Instance
        If _instance Is Nothing Then
            _instance = New UserControl1

        End If
        Return _instance
    End Function

    Function AddUserList(UserList As ArrayList) As Object Implements IPlugin.AddUserList
        Dim uc As UserControl1 = Me.Instance()
        uc.LoadUsers(UserList)
    End Function
End Class
