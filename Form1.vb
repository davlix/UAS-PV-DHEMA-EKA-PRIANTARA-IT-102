Public Class Form1
    Public Sub RefreshDataGrid()
        dgvMahasiswa.DataSource = Nothing
        dgvMahasiswa.DataSource = mahasiswaList
    End Sub

    Private mahasiswaList As New List(Of Mahasiswa)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(txtFilePath.Text) Then
            Dim fileReader As New IO.StreamReader(txtFilePath.Text)

            While Not fileReader.EndOfStream
                Dim line As String = fileReader.ReadLine()
                Dim splitLine As String() = line.Split(","c)
                mahasiswaList.Add(New Mahasiswa(splitLine(0), splitLine(1), splitLine(2)))
            End While

            fileReader.Close()
            RefreshDataGrid()
        End If
    End Sub

    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        If mahasiswaList.Count > 0 Then
            RefreshDataGrid()
        Else
            MessageBox.Show("Tidak ada data mahasiswa yang tersedia.")
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim searchNIM As String = txtCari.Text

        Dim result As Mahasiswa = mahasiswaList.FirstOrDefault(Function(mahasiswa) mahasiswa.NIM = searchNIM)

        If result IsNot Nothing Then
            txtNama.Text = result.Nama
            txtJurusan.Text = result.Jurusan
        Else
            MessageBox.Show("Tidak ada mahasiswa dengan NIM " & searchNIM & ".")
        End If
    End Sub

    Public Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim fileWriter As New IO.StreamWriter(txtFilePath.Text)

        For Each mahasiswa In mahasiswaList
            fileWriter.WriteLine(mahasiswa.NIM & "," & mahasiswa.Nama & "," & mahasiswa.Jurusan)
        Next

        fileWriter.Close()

        MessageBox.Show("Data mahasiswa telah berhasil disimpan.")
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If txtNIM.Text <> "" And txtNama.Text <> "" And txtJurusan.Text <> "" Then
            mahasiswaList.Add(New Mahasiswa(txtNIM.Text, txtNama.Text, txtJurusan.Text))

            txtNIM.Clear()
            txtNama.Clear()
            txtJurusan.Clear()

            RefreshDataGrid()
        Else
            MessageBox.Show("Mohon lengkapi data mahasiswa terlebih dahulu.")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
