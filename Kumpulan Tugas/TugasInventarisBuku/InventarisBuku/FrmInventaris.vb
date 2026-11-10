Option Strict On

Public Class FrmInventaris

    ' Objek penyimpan data buku di memori
    Private tabelBuku As DataTable

    ' Menyiapkan struktur tabel dan 10 data awal saat form dimuat
    Private Sub FrmInventaris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabelBuku = InisialisasiDataAwal()
        bsBuku.DataSource = tabelBuku
        dgvBuku.DataSource = bsBuku

        AturTampilanKolom()

        ' Set nilai default dropdown filter dan urutan
        cboFilterKategori.SelectedIndex = 0
        cboUrut.SelectedIndex = 0

        PerbaruiRingkasan()
    End Sub

    ' Membuat struktur DataTable dan mengisi 10 rekaman buku awal
    Private Function InisialisasiDataAwal() As DataTable
        Dim tabel As New DataTable("Buku")

        ' Definisi struktur kolom
        tabel.Columns.Add("KodeBuku", GetType(String))
        tabel.Columns.Add("Judul", GetType(String))
        tabel.Columns.Add("Penulis", GetType(String))
        tabel.Columns.Add("Kategori", GetType(String))
        tabel.Columns.Add("Tahun", GetType(Integer))
        tabel.Columns.Add("Stok", GetType(Integer))

        ' Menambahkan 10 data awal (4 kategori terwakili, minimal 2 stok 0)
        tabel.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabel.Rows.Add("BK0002", "Bumi Manusia", "Pramoedya Ananta Toer", "Fiksi", 1980, 0)
        tabel.Rows.Add("BK0003", "Filosofi Teras", "Henry Manampiring", "Nonfiksi", 2018, 5)
        tabel.Rows.Add("BK0004", "Kamus Bahasa Indonesia", "Tim Bahasa", "Referensi", 2020, 3)
        tabel.Rows.Add("BK0005", "Majalah Sains Nusantara", "Redaksi Sains", "Majalah", 2024, 0)
        tabel.Rows.Add("BK0006", "Ma'rifat Cahaya", "Ahmad Fauzi", "Nonfiksi", 2019, 4)
        tabel.Rows.Add("BK0007", "Negeri 5 Menara", "Ahmad Fuadi", "Fiksi", 2009, 6)
        tabel.Rows.Add("BK0008", "Atlas Indonesia", "Tim Kartografi", "Referensi", 2022, 2)
        tabel.Rows.Add("BK0009", "Majalah Taman Kita", "Redaksi Taman", "Majalah", 2023, 7)
        tabel.Rows.Add("BK0010", "Sejarah Nusantara", "Dewi Lestari P.", "Nonfiksi", 2021, 0)

        Return tabel
    End Function

    ' Mengatur tata letak visual, header, dan perataan kolom DataGridView
    Private Sub AturTampilanKolom()
        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("Judul").HeaderText = "Judul"
        dgvBuku.Columns("Penulis").HeaderText = "Penulis"
        dgvBuku.Columns("Kategori").HeaderText = "Kategori"
        dgvBuku.Columns("Tahun").HeaderText = "Tahun"
        dgvBuku.Columns("Stok").HeaderText = "Stok"

        ' Pengaturan perataan teks
        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Pengaturan proporsi lebar kolom
        dgvBuku.Columns("Judul").FillWeight = 160
        dgvBuku.Columns("Penulis").FillWeight = 120
        dgvBuku.Columns("KodeBuku").FillWeight = 75
        dgvBuku.Columns("Kategori").FillWeight = 85
        dgvBuku.Columns("Tahun").FillWeight = 60
        dgvBuku.Columns("Stok").FillWeight = 50

        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' Event untuk menambahkan buku baru setelah validasi lolos
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then
            Return
        End If

        Dim tahun As Integer = Integer.Parse(txtTahun.Text.Trim())
        Dim stok As Integer = Integer.Parse(txtStok.Text.Trim())

        ' Tambah data langsung ke DataTable
        tabelBuku.Rows.Add(txtKodeBuku.Text.Trim().ToUpper(),
                           txtJudul.Text.Trim(),
                           txtPenulis.Text.Trim(),
                           cboKategori.Text,
                           tahun,
                           stok)

        BersihkanFormInput()
        PerbaruiRingkasan()
    End Sub

    ' Memvalidasi seluruh isian kontrol input sesuai ketentuan tugas
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim isValid As Boolean = True
        Dim kodeInput As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim tahunInput As Integer
        Dim stokInput As Integer

        ' Validasi format kode buku: BK + 4 digit angka
        If Kosong(kodeInput) Then
            errBuku.SetError(txtKodeBuku, "Kode buku wajib diisi.")
            isValid = False
        ElseIf kodeInput.Length <> 6 OrElse Not kodeInput.StartsWith("BK") OrElse Not SemuaDigit(kodeInput.Substring(2), 4) Then
            errBuku.SetError(txtKodeBuku, "Format kode harus diawali 'BK' dan diikuti 4 digit angka (misal: BK0001).")
            isValid = False
        Else
            ' Validasi keunikan kode buku di dalam DataTable
            For Each baris As DataRow In tabelBuku.Rows
                If baris.RowState <> DataRowState.Deleted Then
                    If baris("KodeBuku").ToString().ToUpper() = kodeInput Then
                        errBuku.SetError(txtKodeBuku, "Kode buku sudah terdaftar di inventaris.")
                        isValid = False
                        Exit For
                    End If
                End If
            Next
        End If

        ' Validasi judul buku
        If Kosong(txtJudul.Text) Then
            errBuku.SetError(txtJudul, "Judul buku wajib diisi.")
            isValid = False
        End If

        ' Validasi penulis
        If Kosong(txtPenulis.Text) Then
            errBuku.SetError(txtPenulis, "Penulis buku wajib diisi.")
            isValid = False
        End If

        ' Validasi kategori
        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Pilih kategori buku.")
            isValid = False
        End If

        ' Validasi tahun terbit (1900 sampai tahun saat ini)
        If Not Integer.TryParse(txtTahun.Text.Trim(), tahunInput) OrElse
           tahunInput < 1900 OrElse tahunInput > Date.Today.Year Then
            errBuku.SetError(txtTahun, "Tahun harus berupa angka antara 1900 dan " & Date.Today.Year.ToString() & ".")
            isValid = False
        End If

        ' Validasi stok (bilangan bulat >= 0)
        If Not Integer.TryParse(txtStok.Text.Trim(), stokInput) OrElse stokInput < 0 Then
            errBuku.SetError(txtStok, "Stok harus berupa bilangan bulat 0 atau lebih.")
            isValid = False
        End If

        Return isValid
    End Function

    ' Mengosongkan form input dan menghapus indikator error
    Private Sub BersihkanFormInput()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        cboKategori.SelectedIndex = -1
        txtTahun.Clear()
        txtStok.Clear()
        errBuku.Clear()
        txtKodeBuku.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanFormInput()
    End Sub

    ' Menerapkan filter gabungan (Pencarian Teks, Kategori, dan Stok Habis)
    Private Sub TerapkanFilterDanUrutan()
        Dim daftarKriteria As New List(Of String)
        Dim kataCari As String = AmankanTeksFilter(txtCari.Text.Trim())

        ' Syarat 1: Pencarian judul atau penulis
        If kataCari <> "" Then
            daftarKriteria.Add(String.Format("(Judul LIKE '%{0}%' OR Penulis LIKE '%{0}%')", kataCari))
        End If

        ' Syarat 2: Pembatasan kategori
        If cboFilterKategori.SelectedIndex > 0 AndAlso cboFilterKategori.Text <> "Semua" Then
            Dim kategoriDipilih As String = AmankanTeksFilter(cboFilterKategori.Text)
            daftarKriteria.Add(String.Format("Kategori = '{0}'", kategoriDipilih))
        End If

        ' Syarat 3: Opsi stok habis
        If chkStokHabis.Checked Then
            daftarKriteria.Add("Stok = 0")
        End If

        ' Gabungkan seluruh syarat dengan operator AND
        If daftarKriteria.Count > 0 Then
            bsBuku.Filter = String.Join(" AND ", daftarKriteria)
        Else
            bsBuku.RemoveFilter()
        End If

        PerbaruiRingkasan()
    End Sub

    ' Event filter saat teks pencarian berubah
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        TerapkanFilterDanUrutan()
    End Sub

    ' Event filter saat pilihan kategori berubah
    Private Sub cboFilterKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterKategori.SelectedIndexChanged
        TerapkanFilterDanUrutan()
    End Sub

    ' Event filter saat checkbox stok habis dicentang / dilepas
    Private Sub chkStokHabis_CheckedChanged(sender As Object, e As EventArgs) Handles chkStokHabis.CheckedChanged
        TerapkanFilterDanUrutan()
    End Sub

    ' Mengatur urutan tampilan data pada BindingSource
    Private Sub cboUrut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUrut.SelectedIndexChanged
        Select Case cboUrut.Text
            Case "Judul A-Z"
                bsBuku.Sort = "Judul ASC"
            Case "Tahun terbaru"
                bsBuku.Sort = "Tahun DESC"
            Case "Stok terbanyak"
                bsBuku.Sort = "Stok DESC"
            Case Else
                bsBuku.Sort = Nothing
        End Select
    End Sub

    ' Menghitung total data dan agregasi stok buku yang sedang tampil di grid
    Private Sub PerbaruiRingkasan()
        Dim jumlahTampil As Integer = bsBuku.Count
        Dim totalBuku As Integer = tabelBuku.Rows.Count
        lblJumlah.Text = "Menampilkan " & jumlahTampil.ToString() & " dari " & totalBuku.ToString() & " buku"

        ' Perhitungan total stok khusus dari baris yang sedang tampil pada dgvBuku
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            If baris.Cells("Stok").Value IsNot Nothing AndAlso Not IsDBNull(baris.Cells("Stok").Value) Then
                totalStok += CInt(baris.Cells("Stok").Value)
            End If
        Next

        lblTotalStok.Text = "Total stok yang tampil: " & totalStok.ToString()
    End Sub

End Class