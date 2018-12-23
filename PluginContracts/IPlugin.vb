Public Interface IPlugin
    ReadOnly Property Name() As String
    Function Instance() As Windows.Forms.UserControl
    Function AddUserList(UserList As ArrayList)


End Interface
