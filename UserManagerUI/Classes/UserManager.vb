Imports System
Imports System.DirectoryServices
Imports System.Collections

Public Class UserManager
    ''' <summary>
    ''' Dervived from https://docs.microsoft.com/en-us/windows/desktop/ADSchema/a-useraccountcontrol
    ''' Also available in  iads.h enum ADS_USER_FLAG
    ''' </summary>
    Public Enum ADAccountOptions
        UF_SCRIPT = &H1
        UF_ACCOUNTDISABLE = &H2
        UF_HOMEDIR_REQUIRED = &H8
        UF_LOCKOUT = &H10
        UF_PASSWD_NOTREQD = &H20
        UF_PASSWD_CANT_CHANGE = &H40
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = &H80
        UF_TEMP_DUPLICATE_ACCOUNT = &H100
        UF_NORMAL_ACCOUNT = &H200
        UF_INTERDOMAIN_TRUST_ACCOUNT = &H800
        UF_WORKSTATION_TRUST_ACCOUNT = &H1000
        UF_SERVER_TRUST_ACCOUNT = &H2000
        UF_DONT_EXPIRE_PASSWD = &H10000
        UF_MNS_LOGON_ACCOUNT = &H20000
        UF_SMARTCARD_REQUIRED = &H40000
        UF_TRUSTED_FOR_DELEGATION = &H80000
        UF_NOT_DELEGATED = &H100000
        UF_USE_DES_KEY_ONLY = &H200000
        UF_DONT_REQUIRE_PREAUTH = &H400000
        UF_PASSWORD_EXPIRED = &H800000
        UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = &H1000000
    End Enum

    Private aErrMsg As String = ""

    Public ReadOnly Property ErrorMessage As String
        Get
            Return aErrMsg
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Function AddUser(ByVal LoginName As String, ByVal LoginPassword As String) As Boolean
        Return AddUser(LoginName, LoginPassword, "", Nothing)
    End Function

    Public Function AddUser(ByVal LoginName As String, ByVal LoginPassword As String, ByVal LoginDescription As String) As Boolean
        Return AddUser(LoginName, LoginPassword, LoginDescription, Nothing)
    End Function

    Public Function AddUser(ByVal LoginName As String, ByVal LoginPassword As String, ByVal LoginDescription As String, ByVal defaultGroup As String) As Boolean
        Dim created As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")
                Dim found As Boolean = False

                Try
                    found = AD.Children.Find(LoginName, "user") IsNot Nothing
                Catch
                    found = False
                End Try

                If Not found Then

                    Using NewUser As DirectoryEntry = AD.Children.Add(LoginName, "user")
                        NewUser.Invoke("SetPassword", New Object() {LoginPassword})
                        NewUser.Invoke("Put", New Object() {"Description", LoginDescription})
                        NewUser.CommitChanges()
                        SetDefaultOptionFlags(LoginName)
                        created = True

                        If (defaultGroup IsNot Nothing) AndAlso (defaultGroup.Trim().Length > 0) Then
                            Dim grp As DirectoryEntry = Nothing

                            Try
                                grp = AD.Children.Find(defaultGroup, "group")
                                Using grp

                                    If grp IsNot Nothing Then
                                        grp.Invoke("Add", New Object() {NewUser.Path.ToString()})
                                    End If
                                End Using

                            Catch ex As Exception
                                aErrMsg = ex.Message
                            End Try
                        End If
                    End Using
                Else
                    aErrMsg = "User already exists!"
                End If
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return created
    End Function

    Public Function RemoveUser(ByVal LoginName As String) As Boolean
        Dim deleted As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try

                    Using NewUser As DirectoryEntry = AD.Children.Find(LoginName, "user")

                        If NewUser IsNot Nothing Then
                            AD.Children.Remove(NewUser)
                            deleted = True
                        Else
                            aErrMsg = "User not found!"
                        End If
                    End Using

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return deleted
    End Function

    Public Function SetUserPassword(ByVal LoginName As String, ByVal LoginPassword As String) As Boolean
        Dim setted As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using NewUser As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    NewUser.Invoke("SetPassword", New Object() {LoginPassword})
                    NewUser.CommitChanges()
                    setted = True
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return setted
    End Function

    Public Function EnableUser(ByVal LoginName As String) As Boolean
        Dim enabled As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using user As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    Dim pv As PropertyValueCollection = user.Properties("userFlags")
                    Dim currentAccountControl As Integer = CInt(pv.Value)
                    Dim acctControlFlags As Integer = currentAccountControl - CInt(ADAccountOptions.UF_ACCOUNTDISABLE)
                    user.Properties("userFlags").Add(acctControlFlags)
                    user.CommitChanges()
                    enabled = True
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return enabled
    End Function

    Public Function DisableUser(ByVal LoginName As String) As Boolean
        Dim disabled As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using user As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    Dim pv As PropertyValueCollection = user.Properties("userFlags")
                    Dim currentAccountControl As Integer = CInt(pv.Value)
                    Dim acctControlFlags As Integer = currentAccountControl Or CInt(ADAccountOptions.UF_ACCOUNTDISABLE)
                    user.Properties("userFlags").Add(acctControlFlags)
                    user.CommitChanges()
                    disabled = True
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return disabled
    End Function

    Private Shared Sub SetDefaultOptionFlags(ByVal LoginName As String)
        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using NewUser As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    Dim pv As PropertyValueCollection = NewUser.Properties("userFlags")
                    Dim currentAccountControl As Integer = CInt(pv.Value)
                    Dim acctControlFlags As Integer = currentAccountControl
                    acctControlFlags = acctControlFlags Or CInt(ADAccountOptions.UF_NORMAL_ACCOUNT) Or CInt(ADAccountOptions.UF_PASSWD_CANT_CHANGE) Or CInt(ADAccountOptions.UF_DONT_EXPIRE_PASSWD)
                    NewUser.Properties("userFlags").Add(acctControlFlags)
                    NewUser.CommitChanges()
                End Using
            End Using

        Catch
        End Try
    End Sub

    Public Function AddOptionFlagToUser(ByVal LoginName As String, ByVal optionFlag As Integer) As Boolean
        Dim flagAdded As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using user As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    Dim pv As PropertyValueCollection = user.Properties("userFlags")
                    Dim currentAccountControl As Integer = CInt(pv.Value)
                    Dim acctControlFlags As Integer = currentAccountControl Or optionFlag
                    user.Properties("userFlags").Add(acctControlFlags)
                    user.CommitChanges()
                    flagAdded = True
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return flagAdded
    End Function

    Public Function RemoveOptionFlagToUser(ByVal LoginName As String, ByVal optionFlag As Integer) As Boolean
        Dim flagRemoved As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using user As DirectoryEntry = AD.Children.Find(LoginName, "user")
                    Dim pv As PropertyValueCollection = user.Properties("userFlags")
                    Dim currentAccountControl As Integer = CInt(pv.Value)
                    Dim acctControlFlags As Integer = currentAccountControl - optionFlag
                    user.Properties("userFlags").Add(acctControlFlags)
                    user.CommitChanges()
                    flagRemoved = True
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return flagRemoved
    End Function

    Public Function UserProperties(ByVal LoginName As String) As ArrayList
        Dim userprop As ArrayList = New ArrayList()

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try
                    Dim usr As DirectoryEntry = Nothing
                    usr = AD.Children.Find(LoginName, "user")
                    Using usr
                        Dim n As ICollection = usr.Properties.PropertyNames

                        For Each o As Object In n
                            Dim val As String = o.ToString()

                            If val = "PasswordAge" Then
                                Dim b As Integer = (CInt(usr.Properties(o.ToString()).Value)) / 60 / 60 / 24
                                val += " = " & b.ToString()
                            ElseIf (val = "LoginHours") OrElse (val = "objectSid") Then
                                Dim b As Byte() = CType(usr.Properties(o.ToString()).Value, Byte())
                                val += " = "

                                For Each b1 As Byte In b
                                    val += b1.ToString("X").PadLeft(2, "0"c) & " "
                                Next
                            Else
                                val += " = " & usr.Properties(o.ToString()).Value.ToString()
                            End If

                            userprop.Add(val)
                        Next
                    End Using

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return userprop
    End Function

    Public Function ListUsersInServer() As ArrayList
        Dim userList As ArrayList = New ArrayList()

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try
                    AD.Children.SchemaFilter.Add("user")

                    For Each usr As DirectoryEntry In AD.Children
                        userList.Add(usr.Name)
                    Next

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return userList
    End Function

    Public Function AddGroup(ByVal GroupName As String, ByVal Description As String) As Boolean
        Dim created As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")
                Dim found As Boolean = False

                Try
                    found = AD.Children.Find(GroupName, "group") IsNot Nothing
                Catch
                    found = False
                End Try

                If Not found Then

                    Using grp As DirectoryEntry = AD.Children.Add(GroupName, "group")
                        grp.Invoke("Put", New Object() {"Description", Description})
                        grp.CommitChanges()
                        created = True
                    End Using
                Else
                    aErrMsg = "Group already exists!"
                End If
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return created
    End Function

    Public Function AddUserToGroup(ByVal LoginName As String, ByVal GroupName As String) As Boolean
        Dim added As Boolean = False

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Using NewUser As DirectoryEntry = AD.Children.Find(LoginName, "user")

                    Try
                        Dim grp As DirectoryEntry = Nothing
                        grp = AD.Children.Find(GroupName, "group")
                        Try

                            Using grp

                                If grp IsNot Nothing Then
                                    grp.Invoke("Add", New Object() {NewUser.Path.ToString()})
                                    added = True
                                End If
                            End Using

                        Catch ex As Exception
                            aErrMsg = ex.Message
                        End Try

                    Catch ex As Exception
                        aErrMsg = ex.Message
                    End Try
                End Using
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return added
    End Function

    Public Function ListUsersInGroup(ByVal GroupName As String) As ArrayList
        Dim groupMembers As ArrayList = New ArrayList()

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try
                    Dim grp As DirectoryEntry = Nothing
                    grp = AD.Children.Find(GroupName, "group")
                    Using grp

                        If grp IsNot Nothing Then
                            Dim members As Object = grp.Invoke("Members", Nothing)

                            For Each member As Object In CType(members, IEnumerable)
                                Dim x As DirectoryEntry = New DirectoryEntry(member)
                                groupMembers.Add(x.Name)
                            Next
                        End If
                    End Using

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return groupMembers
    End Function

    Public Function ListGroupsInServer() As ArrayList
        Dim groupList As ArrayList = New ArrayList()

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try
                    AD.Children.SchemaFilter.Add("group")

                    For Each grp As DirectoryEntry In AD.Children
                        groupList.Add(grp.Name)
                    Next

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return groupList
    End Function

    Public Function GroupProperties(ByVal GroupName As String) As ArrayList
        Dim groupprop As ArrayList = New ArrayList()

        Try

            Using AD As DirectoryEntry = New DirectoryEntry("WinNT://" & Environment.MachineName & ",computer")

                Try
                    Dim usr As DirectoryEntry = Nothing
                    usr = AD.Children.Find(GroupName, "group")
                    Using usr
                        Dim n As ICollection = usr.Properties.PropertyNames

                        For Each o As Object In n
                            Dim val As String = o.ToString()

                            If (val = "LoginHours") OrElse (val = "objectSid") Then
                                Dim b As Byte() = CType(usr.Properties(o.ToString()).Value, Byte())
                                val += " = " & Convert.ToBase64String(b)
                            Else
                                val += " = " & usr.Properties(o.ToString()).Value.ToString()
                            End If

                            groupprop.Add(val)
                        Next
                    End Using

                Catch ex As Exception
                    aErrMsg = ex.Message
                End Try
            End Using

        Catch ex As Exception
            aErrMsg = ex.Message
        End Try

        Return groupprop
    End Function
End Class

