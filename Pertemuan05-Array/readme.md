<div align="center">

# PERTEMUAN 05
### Modul, Prosedur, Fungsi, Array, dan Koleksi Data (VB.NET)

</div>

---

## 1. Deskripsi Praktikum

Praktikum ini berfokus pada pengorganisasian kode program dan pengelolaan struktur data pada arsitektur **Windows Forms** menggunakan bahasa **Visual Basic .NET (VB.NET)**.

Tujuan utama dari materi ini adalah:
- Memisahkan logika bisnis dari kode antarmuka (*UI Form*) ke dalam **Module** agar program lebih terstruktur, modular, dan mudah dikelola.
- Mengatur hak akses komponen menggunakan **Access Modifier** (`Public` dan `Private`).
- Mengimplementasikan subprogram tanpa nilai balik (**Sub / Procedure**) serta subprogram yang mengembalikan nilai (**Function**).
- Mengelola data terstruktur menggunakan **Array Satu Dimensi** dan **Array Multi-Dimensi (2D)** berbasis indeks 0 (*zero-based indexing*).
- Memahami konsep dan perbedaan berbagai jenis **Koleksi Data** di .NET (`Array`, `List`, `Dictionary`, dan `HashSet`).

---

## 2. Arsitektur Komponen Visual (UI Controls)

| Kontrol UI | Identitas `(Name)` | Properti Kunci | Deskripsi Fungsional |
| :--- | :--- | :--- | :--- |
| **Button** | `btnTampilkan` | `Text: "Tampilkan"` | Memicu eksekusi untuk mengambil data array atau memanggil sub/fungsi dari modul |
| **TextBox** | `TextBox1` | `Text: ""` | Kotak masukan parameter pertama (misal: panjang atau data teks) |
| **TextBox** | `TextBox2` | `Text: ""` | Kotak masukan parameter kedua (misal: lebar atau data pembanding) |
| **ListBox** | `lstNilai` | `FormattingEnabled: True` | Menampilkan deretan nilai dari iterasi elemen array satu dimensi |

---

## 3. Logika Kode Program

### 3.1 `Module1.vb`
Modul digunakan sebagai wadah terpusat untuk menyimpan sub/prosedur, fungsi perhitungan, dan data array yang dapat diakses oleh form.

```vb
Module Module1

    ' Prosedur (Sub): Menjalankan aksi tanpa mengembalikan nilai
    Public Sub tampilkanPesan(nama As String)
        MessageBox.Show("Halo, " & nama)
    End Sub

    ' Fungsi (Function): Memproses parameter dan mengembalikan nilai balik
    Public Function hitung(panjang As Integer, lebar As Integer) As Integer
        If panjang > 20 Then
            Return panjang * lebar
        Else
            Return 2 * (panjang + lebar)
        End If
    End Function

    ' Array Satu Dimensi (1D): Menyimpan sekumpulan nilai linier
    Public nilai() As Integer = {70, 80, 90, 100}

    ' Array Multi-Dimensi (2D): Matriks berukuran 3 baris x 3 kolom
    Public nilai2D(,) As Integer = {
        {80, 85, 82},
        {70, 72, 78},
        {90, 92, 98}
    }

End Module
```

### 3.2 `Form1.vb`
Kode antarmuka (*code-behind*) yang memanggil dan memanfaatkan data dari `Module1`.

```vb
Public Class Form1

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        ' Opsi 1: Menampilkan seluruh elemen Array 1D ke dalam ListBox
        ' lstNilai.Items.Clear()
        ' For i As Integer = 0 To Module1.nilai.Length - 1
        '     lstNilai.Items.Add(Module1.nilai(i))
        ' Next

        ' Opsi 2: Mengakses elemen matriks 2D pada baris indeks ke-1, kolom indeks ke-2
        MessageBox.Show(nilai2D(1, 2).ToString())
    End Sub

End Class
```

---

## 4. Pembahasan Detail Konsep Teknis

### 4.1 Modul dan Access Modifier (`Public` vs `Private`)
* **Module**: Bagian dari program yang digunakan untuk mengelompokkan variabel, prosedur, dan fungsi secara terpisah dari Form. Anggota modul dapat dipanggil langsung tanpa perlu instansiasi objek (*instantiation*).
* **Public**: Anggota modul/variabel dapat diakses oleh bagian form atau modul lain di seluruh proyek.
* **Private**: Anggota hanya dapat diakses di dalam blok modul/form tempat ia dideklarasikan, mencegah modifikasi tak disengaja dari luar.

### 4.2 Prosedur (`Sub`) vs Fungsi (`Function`)
* **Procedure (`Sub`)**: Sekumpulan instruksi yang dibuat untuk menjalankan tugas tertentu tanpa memberikan hasil balik (*return value*).
  * Contoh: `Public Sub tampilkanPesan(nama As String)` hanya bertugas memunculkan `MessageBox`.
* **Function**: Blok kode pemrosesan yang wajib mengembalikan sebuah nilai (*return value*) ke pemanggil menggunakan kata kunci `Return`.
  * Contoh: `Public Function hitung(...) As Integer` mengembalikan hasil perkalian atau keliling berdasarkan kondisi nilai panjang.

### 4.3 Karakteristik Array (Satu Dimensi & Multi-Dimensi)
* **Pengindeksan Nol (*Zero-Based*)**: Elemen pertama selalu berada pada indeks ke-`0`, dan elemen terakhir berada pada indeks ke-`N-1`.
* **Ukuran Tetap (*Fixed Size*)**: Panjang kapasitas array dialokasikan saat inisialisasi dan tidak dapat bertambah secara langsung tanpa realokasi memori.
* **Array Satu Dimensi**: Menyimpan data berurutan secara linier.
  ```vb
  Dim nilai() As Integer = {70, 80, 90, 100}
  ' nilai(0) = 70, nilai(1) = 80, nilai(2) = 90, nilai(3) = 100
  ```
* **Array Multi-Dimensi (2D Matrix)**: Membentuk struktur matriks berbaris dan berkolom seragam.
  ```vb
  ' Mengakses nilai baris indeks ke-1 dan kolom indeks ke-2:
  ' Baris 0: {80, 85, 82}
  ' Baris 1: {70, 72, 78} -> Kolom ke-2 adalah 78
  ' Baris 2: {90, 92, 98}
  Dim hasil As Integer = nilai2D(1, 2) ' Menghasilkan 78
  ```

### 4.4 Ragam Struktur Koleksi Data (.NET Collections)
Selain Array konvensional, .NET menyediakan struktur koleksi data dinamis yang fleksibel:
1. **List (`List(Of T)`)**: Menyimpan data linier dengan ukuran dinamis yang dapat membesar/mengecil otomatis melalui *method* `.Add()` dan `.Remove()`.
2. **Dictionary (`Dictionary(Of TKey, TValue)`)**: Menyimpan data berpasangan antara *key* (kunci unik) dan *value* (nilai). Sangat cepat untuk pencarian berbasis label/identitas (misal: pencarian berdasarkan NIM).
3. **Set (`HashSet(Of T)`)**: Menyimpan kumpulan nilai unik tanpa urutan indeks tertentu, secara otomatis menolak dan mengabaikan penambahan data duplikat.

---

## 5. Klasifikasi dan Karakteristik Koleksi Data

| Struktur Data | Kapasitas Ukuran | Akses Elemen | Karakteristik Duplikasi | Contoh Deklarasi (VB.NET) | Kasus Penggunaan Ideal |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **Array** | Tetap (*Fixed*) | Berbasis Indeks (`0, 1, ..`) | Mengizinkan duplikasi | `Dim nilai() As Integer = {10, 20, 30}` | Kumpulan data konstan yang jumlahnya sudah pasti |
| **List** | Dinamis | Berbasis Indeks (`0, 1, ..`) | Mengizinkan duplikasi | `Dim angka As New List(Of Integer)` | Data yang jumlahnya fleksibel dan butuh operasi tambah/hapus |
| **Dictionary** | Dinamis | Berbasis Kunci (*Key*) | Kunci wajib unik (*Unique Key*) | `Dim mhs As New Dictionary(Of String, String)` | Data berpasangan dengan label pengenal unik (NIM, Kode Barang) |
| **HashSet** | Dinamis | Nilai Langsung (*No Index*) | Tidak mengizinkan duplikasi | `Dim setAngka As New HashSet(Of Integer)` | Filter data unik dan pengujian keanggotaan nilai (*membership test*) |

---

## 6. Kesimpulan

Pada praktikum Pertemuan 05 ini disimpulkan beberapa prinsip kunci:

1. **Modularitas Program**: Menggunakan `Module` mempermudah pemeliharaan kode dan mencegah penumpukan logika di dalam file `Form`.
2. **Enkapsulasi Akses**: Penerapan `Public` dan `Private` memastikan integritas data dan keamanan akses antar-komponen.
3. **Efisiensi Subprogram**: Pemilihan antara `Sub` (prosedural murni) dan `Function` (kalkulasi nilai balik) membuat kode dapat digunakan kembali (*reusable*).
4. **Manipulasi Matriks**: Array multidimensi mempermudah representasi data berbentuk tabel atau koordinat melalui pasangan indeks baris dan kolom `(baris, kolom)`.
5. **Kesesuaian Struktur Koleksi**: Pemilihan antara `Array`, `List`, `Dictionary`, dan `HashSet` harus disesuaikan dengan kebutuhan performa, kebutuhan duplikasi data, dan fleksibilitas ukuran koleksi.

