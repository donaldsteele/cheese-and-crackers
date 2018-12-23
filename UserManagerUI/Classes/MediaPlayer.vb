Imports System.IO

Public Class MediaPlayer
    Private soundPlayer As System.Media.SoundPlayer
    Public Event Stopped()


    Public Sub New()
        Dim buffer As Byte() = New Byte(My.Resources.cheese_and_crackers.Length) {}
        My.Resources.cheese_and_crackers.Read(Buffer, 0, My.Resources.cheese_and_crackers.Length)
        Dim memoryStream = New MemoryStream(Buffer, 0, Buffer.Length)
        soundPlayer = New System.Media.SoundPlayer(My.Resources.cheese_and_crackers)

    End Sub

    Public Sub Play()
        soundPlayer.Play()
    End Sub

    Public Sub Play(ByVal buffer As Byte())
        soundPlayer.Stream.Seek(0, SeekOrigin.Begin)
        soundPlayer.Stream.Write(buffer, 0, buffer.Length)
        soundPlayer.Play()
    End Sub
End Class
