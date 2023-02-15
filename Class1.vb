Public Class Mahasiswa
    Public Property NIM As String
    Public Property Nama As String
    Public Property Jurusan As String

    Public Sub New(nim As String, nama As String, jurusan As String)
        Me.NIM = nim
        Me.Nama = nama
        Me.Jurusan = jurusan
    End Sub
End Class
