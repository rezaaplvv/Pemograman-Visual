Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.Generic

Public Class frmPeminjaman

    ' Koleksi untuk menyimpan daftar kode buku yang sedang dipinjam agar tidak dipinjam dua kali
    Private daftarKodeBukuDipinjam As New List(Of String)

    ' Event validating agar kesalahan format kode buku langsung muncul saat fokus berpindah
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If String.IsNullOrWhiteSpace(txtKodeBuku.Text) Then
            Return
        End If

        If KodeBukuValid(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "")
        Else
            errPinjam.SetError(txtKodeBuku, "Kode buku harus BK diikuti 4 digit, contoh BK0012.")
        End If
    End Sub

    ' Fungsi validasi terpusat untuk memeriksa seluruh isian form secara serentak
    Private Function ValidasiInput() As Boolean
        errPinjam.Clear()
        Dim statusValid As Boolean = True

        ' 1. Validasi Kode Buku
        Dim kodeInput As String = txtKodeBuku.Text.Trim().ToUpper()
        If String.IsNullOrWhiteSpace(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku wajib diisi.")
            statusValid = False
        ElseIf Not KodeBukuValid(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku harus BK diikuti 4 digit, contoh BK0012.")
            statusValid = False
        ElseIf daftarKodeBukuDipinjam.Contains(kodeInput) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            statusValid = False
        End If

        ' 2. Validasi Judul Buku
        If String.IsNullOrWhiteSpace(txtJudul.Text) Then
            errPinjam.SetError(txtJudul, "Judul buku wajib diisi.")
            statusValid = False
        End If

        ' 3. Validasi Kategori Buku
        If cboKategori.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cboKategori.Text) Then
            errPinjam.SetError(cboKategori, "Kategori buku wajib dipilih.")
            statusValid = False
        End If

        ' 4. Validasi Nama Peminjam
        If txtNamaPeminjam.Text.Trim().Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            statusValid = False
        End If

        ' 5. Validasi Lama Pinjam
        Dim lamaPinjam As Integer = 0
        If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam) OrElse lamaPinjam < 1 OrElse lamaPinjam > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus angka 1 sampai 14 hari.")
            statusValid = False
        End If

        Return statusValid
    End Function

    ' Prosedur bantuan untuk mengosongkan isian kontrol input
    Private Sub KosongkanInput()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
        txtKodeBuku.Focus()
    End Sub

    ' Event klik tombol Pinjam untuk memproses dan mencatat peminjaman buku
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah."
            Return
        End If

        Dim kodeBuku As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim judulBuku As String = txtJudul.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim namaPeminjam As String = txtNamaPeminjam.Text.Trim()
        Dim lamaPinjam As Integer = Integer.Parse(txtLamaPinjam.Text.Trim())
        Dim tglKembali As String = Date.Today.AddDays(lamaPinjam).ToString("dd/MM/yyyy")

        Dim barisData As String = kodeBuku & " | " & judulBuku & " | " & kategori & " | " & namaPeminjam & " | " & lamaPinjam.ToString() & " hari | kembali " & tglKembali

        lstPeminjaman.Items.Add(barisData)
        daftarKodeBukuDipinjam.Add(kodeBuku)

        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
        KosongkanInput()
    End Sub

    ' Event klik tombol Bersihkan untuk mereset seluruh form
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        KosongkanInput()
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
    End Sub

    ' Event klik tombol Ekspor untuk menyimpan data ke file CSV dengan blok Try Catch Finally
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Daftar peminjaman masih kosong. Tambahkan data terlebih dahulu sebelum mengekspor.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim folderDokumen As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim lokasiFile As String = Path.Combine(folderDokumen, "peminjaman.csv")
        Dim penulis As StreamWriter = Nothing

        Try
            penulis = New StreamWriter(lokasiFile)
            penulis.WriteLine("Kode Buku;Judul Buku;Kategori;Nama Peminjam;Lama Pinjam;Tanggal Kembali")

            For Each barisItem As Object In lstPeminjaman.Items
                penulis.WriteLine(barisItem.ToString().Replace(" | ", ";"))
            Next

            lblStatus.Text = "Data berhasil diekspor ke peminjaman.csv"
            MessageBox.Show("Data berhasil diekspor ke berkas peminjaman.csv di folder Documents.", "Ekspor Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As IOException
            MessageBox.Show("Berkas peminjaman.csv sedang dibuka oleh program lain seperti Microsoft Excel." & vbCrLf & "Tutup berkas tersebut di Excel lalu klik tombol Ekspor lagi.", "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Aplikasi tidak memiliki izin menulis file di folder tujuan." & vbCrLf & "Pastikan Anda memiliki izin akses penyimpanan pada folder tersebut.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan tidak terduga saat menulis berkas." & vbCrLf & ex.Message, "Kesalahan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If penulis IsNot Nothing Then
                penulis.Close()
            End If
        End Try
    End Sub

End Class