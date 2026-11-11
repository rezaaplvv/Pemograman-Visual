<div align="center">

# PERTEMUAN 08
### DataGridView, Pemetaan Array, dan Binding Koleksi Data (VB.NET)

</div>

---

## 1. Deskripsi Praktikum

Praktikum ini berfokus pada teknik penyajian dan manipulasi data tabular multi-kolom pada lingkungan **Windows Forms (VB.NET)** menggunakan kontrol visual **DataGridView**. 

Jika sebelumnya data hanya dapat ditampilkan secara linier melalui `ListBox` (yang memiliki keterbatasan kolom tidak sejajar dan sulit diurutkan), pada praktikum ini mahasiswa mempelajari pengelolaan data berbasis baris dan kolom seperti lembar kerja (*spreadsheet*).

Praktikum mencakup:
1. **Mode Unbound (Manual)**: Memetakan **Array 2 Dimensi** ke dalam `DataGridView` menggunakan algoritma perulangan bersarang (*nested loop*).
2. **Mode Bound (Data Binding)**: Menghubungkan data berbasis objek (**Object-Oriented Data**) menggunakan `List(Of T)` dan struktur tabel memori (**`DataTable`**).
3. **Peran `BindingSource`**: Memanfaatkan komponen perantara (*mediator*) untuk menyederhanakan sinkronisasi data, navigasi, pengurutan (*sorting*), dan pemfilteran (*filtering*).
4. **Kustomisasi dan Formatting Kolom**: Merapikan judul header, perataan teks (*alignment*), format numerik desimal (`N2`), dan mode ukuran kolom fleksibel (*AutoSizeColumnsMode.Fill*).
5. **Implementasi Pencarian Cepat**: Membandingkan teknik pencarian berbasis ekspresi memori (`BindingSource.Filter`) pada `DataTable` vs pencarian berbasis perulangan objek (`For Each`) pada `List(Of T)`.

---

## 2. Arsitektur Komponen Visual (UI Controls)

Praktikum ini terdiri dari beberapa form pengujian yang dapat diakses melalui menu navigasi utama (`FrmUtama`):

| Kontrol UI | Identitas `(Name)` | Properti Kunci | Deskripsi Fungsional |
| :--- | :--- | :--- | :--- |
| **DataGridView** | `dgvMahasiswa` | `AutoSizeColumnsMode: Fill` | Menampilkan data baris dan kolom mahasiswa secara tabular |
| **BindingSource**| `bsMahasiswa` | `Component Tray` | Komponen perantara antara sumber data (`List`/`DataTable`) dan `DataGridView` |
| **TextBox** | `txtCari` | `Text: ""` | Kotak pencarian data mahasiswa berdasarkan NIM atau Nama secara *real-time* |
| **TextBox** | `txtNIM` | `MaxLength: 9` | Masukan Nomor Induk Mahasiswa untuk penambahan data baru |
| **TextBox** | `txtNama` | `Text: ""` | Masukan nama lengkap mahasiswa |
| **ComboBox** | `cboJurusan` | `DropDownStyle: DropDownList` | Pilihan program studi / jurusan |
| **TextBox** | `txtAngkatan` | `Text: ""` | Masukan tahun angkatan |
| **TextBox** | `txtIpk` | `Text: ""` | Masukan nilai IPK mahasiswa |
| **Button** | `btnTampilkan` | `Text: "Tampilkan"` | Memuat data dari sumber ke dalam grid |
| **Button** | `btnTambah` | `Text: "Tambah"` | Menambahkan data objek baru ke koleksi dan memperbarui tampilan grid |
| **Button** | `btnRapikan` | `Text: "Rapikan Kolom"` | Menerapkan pemformatan sel, alignment, dan header kolom |
| **Label** | `lblJumlah` | `Text: "Jumlah data: ..."` | Menampilkan ringkasan jumlah baris data yang sedang ditampilkan |
| **ErrorProvider**| `errInput` | `Component Tray` | Menandai kesalahan validasi pada kotak input form |

---

## 3. Logika Kode Program

### 3.1 Model Data Objek (`Mahasiswa.vb`)
Setiap objek `Mahasiswa` merepresentasikan **satu baris** di `DataGridView`. Nama setiap `Public Property` akan dibaca oleh grid sebagai **nama kolom**.

```vb
Option Strict On

Public Class Mahasiswa
    Public Property Nim As String
    Public Property Nama As String
    Public Property Jurusan As String
    Public Property Angkatan As Integer
    Public Property Ipk As Decimal

    Public Sub New(nim As String, nama As String, jurusan As String, angkatan As Integer, ipk As Decimal)
        Me.Nim = nim
        Me.Nama = nama
        Me.Jurusan = jurusan
        Me.Angkatan = angkatan
        Me.Ipk = ipk
    End Sub
End Class
```

### 3.2 Pemetaan Array 2 Dimensi Manual (`FrmDariArray.vb`)
Memasukkan data dari Array 2D ke dalam `DataGridView` tanpa data binding (*unbound mode*) menggunakan *nested loop*:

```vb
Option Strict On

Public Class FrmDariArray
    ' Dimensi 0 = Baris (Mahasiswa), Dimensi 1 = Kolom (NIM, Nama, Jurusan, Angkatan, IPK)
    Private ReadOnly dataMahasiswa(,) As String = {
        {"231712001", "Andi Pratama", "Teknik Informatika", "2023", "3.45"},
        {"231712002", "Sari Wulandari", "Sistem Informasi", "2023", "3.8"},
        {"221712015", "Budi Santoso", "Teknik Informatika", "2022", "3.12"},
        {"241712007", "Dimas Siregar", "Teknik Komputer", "2024", "2.95"}
    }

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.Rows.Clear() ' Mencegah duplikasi data saat tombol diklik ulang

        For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)          ' Iterasi Baris
            Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
            For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)      ' Iterasi Kolom
                dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
            Next
        Next
        lblJumlah.Text = "Jumlah data: " & dgvMahasiswa.Rows.Count.ToString()
    End Sub

    Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
        dgvMahasiswa.Rows.Clear()
        lblJumlah.Text = "Jumlah data: 0"
    End Sub
End Class
```

### 3.3 Binding Koleksi Kuat (`List(Of Mahasiswa)`) (`FrmDariList.vb`)
Menampilkan data objek ke dalam grid secara otomatis melalui perantara `BindingSource`:

```vb
Option Strict On

Public Class FrmDariList
    Private ReadOnly daftarMahasiswa As New List(Of Mahasiswa)

    Private Sub FrmDariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        daftarMahasiswa.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        daftarMahasiswa.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))

        ' Pola Data Binding: List -> BindingSource -> DataGridView
        bsMahasiswa.DataSource = daftarMahasiswa
        dgvMahasiswa.DataSource = bsMahasiswa
        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return

        Dim ipk As Decimal
        CobaDesimal(txtIpk.Text, ipk)
        Dim baru As New Mahasiswa(txtNIM.Text, txtNama.Text.Trim(), cboJurusan.Text,
                                  Integer.Parse(txtAngkatan.Text), ipk)

        ' Tambah via BindingSource agar DataGridView langsung ter-refresh otomatis
        bsMahasiswa.Add(baru)
        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
        BersihkanInput()
    End Sub
End Class
```

### 3.4 Binding Struktur Memori `DataTable` & Filter Cepat (`FrmDataTable.vb`)
Membuat tabel di memori dengan skema kolom yang kuat dan pencarian ekspresi `BindingSource.Filter`:

```vb
Option Strict On

Public Class FrmDataTable
    Private tabelMahasiswa As DataTable

    Private Function BuatTabelMahasiswa() As DataTable
        Dim tabel As New DataTable("Mahasiswa")
        tabel.Columns.Add("Nim", GetType(String))
        tabel.Columns.Add("Nama", GetType(String))
        tabel.Columns.Add("Jurusan", GetType(String))
        tabel.Columns.Add("Angkatan", GetType(Integer))
        tabel.Columns.Add("Ipk", GetType(Decimal))

        tabel.Rows.Add("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D)
        tabel.Rows.Add("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D)
        Return tabel
    End Function

    Private Sub FrmDataTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabelMahasiswa = BuatTabelMahasiswa()
        bsMahasiswa.DataSource = tabelMahasiswa
        dgvMahasiswa.DataSource = bsMahasiswa
        PerbaruiJumlah()
    End Sub

    ' Kustomisasi tampilan kolom dilakukan setelah DataSource diikat
    Private Sub AturKolom()
        dgvMahasiswa.Columns("Nim").HeaderText = "NIM"
        dgvMahasiswa.Columns("Ipk").HeaderText = "IPK"
        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2" ' Format dua digit desimal
        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMahasiswa.Columns("Angkatan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMahasiswa.Columns("Nama").FillWeight = 200
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' Pencarian real-time menggunakan ekspresi Filter di memori
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
        If kata = "" Then
            bsMahasiswa.RemoveFilter()
        Else
            bsMahasiswa.Filter = "Nama LIKE '%" & kata & "%' OR Nim LIKE '%" & kata & "%'"
        End If
        PerbaruiJumlah()
    End Sub
End Class
```

### 3.5 Pengamanan String Filter (`ModPencarian.vb`)
Mencegah error sintaks saat input pencarian mengandung karakter khusus seperti kutip tunggal (`'`) atau wildcard (`*`, `%`, `[`):

```vb
Option Strict On

Public Module ModPencarian
    Public Function AmankanTeksFilter(teks As String) As String
        Dim hasil As String = ""
        For Each karakter As Char In teks
            Select Case karakter
                Case "'"c
                    hasil &= "''" ' Gandakan tanda kutip tunggal
                Case "["c, "]"c, "*"c, "%"c
                    hasil &= "[" & karakter & "]" ' Bungkus simbol khusus
                Case Else
                    hasil &= karakter
            End Select
        Next
        Return hasil
    End Function
End Module
```

---

## 4. Pembahasan Detail Konsep Teknis

### 4.1 Mode Unbound vs Mode Bound
* **Unbound Mode (`Rows.Add`)**:
  * Kolom harus dibuat terlebih dahulu secara manual (baik melalui Designer atau `Columns.Add`).
  * Nilai dimasukkan sel per sel menggunakan indeks baris dan kolom: `dgvMahasiswa.Rows(baris).Cells(kolom).Value`.
  * Cocok untuk data statis berukuran kecil.
* **Bound Mode (`DataSource`)**:
  * Grid secara otomatis membaca skema properti atau skema kolom dari sumber data.
  * Kolom dan tipe data dibuat secara instan tanpa perlu perulangan manual.
  > [!WARNING]
  > **Jangan pernah menggabungkan kedua mode!** Jika grid sudah memiliki `DataSource`, memanggil `Rows.Add()` akan memicu runtime error `InvalidOperationException`.

### 4.2 Keterbatasan Array 2D Dibandingkan Koleksi Objek
Meskipun Array 2D mudah dipahami, ia memiliki sejumlah kekurangan nyata saat dipakai untuk antarmuka tabel:
1. **Homogenitas Tipe Data**: Pada `Array(,) As String`, seluruh nilai berupa teks. Akibatnya, nilai IPK tidak dapat dihitung atau diformat angka secara langsung tanpa konversi manual.
2. **Keterbatasan Ukuran**: Array berukuran tetap. Menambah baris data baru sangat sulit karena `ReDim Preserve` pada VB.NET hanya dapat mengubah ukuran **dimensi terakhir** (kolom), bukan dimensi baris pertama.
3. **Penyalinan Terputus**: Perubahan data pada Array tidak otomatis mengubah tampilan grid.
4. **Indeks Rentan Tertukar**: Pengaksesan `data(i, 3)` rawan kesalahan penempatan kolom (apakah indeks 3 angkatan atau IPK?).

### 4.3 Arsitektur Objek: "Satu Baris = Satu Objek"
Dengan mendefinisikan kelas `Mahasiswa`:
* Setiap objek cetakan (*instance*) `New Mahasiswa(...)` mewakili **satu baris** data lengkap.
* Setiap `Public Property` (`Nim`, `Nama`, `Jurusan`, dsb.) langsung bertransformasi menjadi **nama kolom** pada `DataGridView`.
* Tipe data tiap kolom terjaga secara murni (*strongly-typed*): IPK bertipe `Decimal` dan Angkatan bertipe `Integer`.

### 4.4 Peran `BindingSource` sebagai Mediator
`BindingSource` bertindak sebagai jembatan perantara antara sumber data asli dengan komponen visual:
* **Analogi Layanan**: Seperti petugas meja perpustakaan. Pengunjung (`DataGridView`) tidak berurusan langsung dengan rak buku (`List`/`DataTable`), melainkan melalui petugas (`BindingSource`) yang dapat mengatur filter, urutan buku, dan penambahan buku baru.
* **Sinkronisasi**: Menambahkan data baru melalui `bsMahasiswa.Add(baru)` otomatis menyegarkan tampilan grid tanpa perlu memanggil ulang `dgv.Refresh()`.

### 4.5 Kustomisasi dan Formatting Kolom DataGridView
* Pengaturan properti global seperti `ReadOnly = True`, `SelectionMode = FullRowSelect`, dan `AllowUserToAddRows = False` dapat diatur langsung pada jendela **Designer**.
* Pengaturan kolom individual harus dilakukan di kode **setelah `DataSource` diikat**:
  * **Header Kolom**: `dgv.Columns("Nim").HeaderText = "NIM"`
  * **Format Numerik Desimal**: `DefaultCellStyle.Format = "N2"` menjamin nilai IPK tampil rapi dengan 2 digit di belakang koma (misal: `3.80` bukan `3.8`).
  * **Perataan Teks (*Alignment*)**: Kolom teks rata kiri (*MiddleLeft*), angka/tahun rata tengah (*MiddleCenter*), dan nilai desimal/keuangan rata kanan (*MiddleRight*).

### 4.6 Strategi Pencarian Data: Filter vs Perulangan
1. **`BindingSource.Filter` pada `DataTable`**:
   * Memanfaatkan ekspresi filter mirip SQL di memori klien (misal: `Nama LIKE '%Andi%'`).
   * Tidak menghapus data asli, hanya menyembunyikan baris yang tidak cocok secara instan.
   * Tetap mendukung pengurutan kolom (*column sorting*) saat header diklik.
2. **Pencarian Perulangan (`For Each`) pada `List(Of T)`**:
   * Digunakan karena `List(Of T)` bawaan tidak mendukung fitur `.Filter` milik `BindingSource`.
   * Menelusuri seluruh elemen list, menyaring objek yang memenuhi kriteria `.Contains()`, lalu mengikat hasilnya ke `bsMahasiswa.DataSource = hasil`.

---

## 5. Klasifikasi Perbandingan Sumber Data Grid

| Aspek Komparasi | Array 2 Dimensi | `List(Of T)` + Class | `DataTable` (In-Memory) |
| :--- | :--- | :--- | :--- |
| **Kapasitas Ukuran** | Tetap (*Fixed Size*) | Dinamis (*Fleksibel*) | Dinamis (*Fleksibel*) |
| **Tipe Data per Kolom** | Satu tipe (umumnya String) | Kuat (*Strongly-Typed per Property*) | Kuat (*Sesuai DataColumn.DataType*) |
| **Metode Pengisian Grid** | `Rows.Add()` (Unbound) | `DataSource` via `BindingSource` | `DataSource` via `BindingSource` |
| **Pembentukan Kolom** | Dibuat manual satu per satu | Otomatis dari `Public Property` | Otomatis dari `DataColumn` |
| **Pengurutan Header Kolom** | Terbatas (Urut berbasis teks) | Tidak aktif secara native | Aktif otomatis (Sesuai tipe data) |
| **Fitur `BindingSource.Filter`** | Tidak didukung | Diabaikan (*Not Supported*) | Didukung penuh (Ekspresi Memori) |
| **Kasus Penggunaan Ideal** | Data matriks statis berukuran kecil | Data terstruktur OOP murni di kode | Data tabel relasional / butuh filter & sort cepat |

---

## 6. Kesimpulan

Praktikum Pertemuan 08 memberikan pemahaman fundamental mengenai penyajian data tabel pada Windows Forms:

1. **Efisiensi DataGridView**: Menyediakan tampilan tabular modern yang jauh lebih unggul dibandingkan `ListBox` untuk data multi-atribut.
2. **Pemisahan Mode Unbound dan Bound**: Mode bound berbasis `DataSource` jauh lebih efisien, terstruktur, dan minim kode dibandingkan manipulasi sel manual.
3. **Keunggulan Pendekatan Objek**: Menggabungkan `Class` dan `List(Of T)` memberikan integritas tipe data dan keterbacaan kode yang tinggi.
4. **Peran Sentral `BindingSource`**: Menyediakan arsitektur manajemen data yang rapi dan menyinkronkan perubahan data ke UI secara otomatis.
5. **Pencarian Cepat & Aman**: Penggunaan `DataTable.DefaultView.RowFilter` bersama pengamanan karakter khusus (`AmankanTeksFilter`) memberikan fitur pencarian yang cepat, aman, dan tanpa melempar runtime exception.

