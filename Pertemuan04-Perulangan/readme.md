<div align="center">

# PERTEMUAN 04
### Struktur Perulangan (Looping) dan Iterasi Koleksi Data (VB.NET)

</div>

---

## 1. Deskripsi Praktikum

Praktikum ini berfokus pada pemahaman dan implementasi struktur kontrol **Perulangan (Looping)** pada lingkungan **Windows Forms** menggunakan bahasa **Visual Basic .NET (VB.NET)**.

Tujuan utama dari perulangan adalah mengotomatisasi instruksi berulang, mengisi serta memproses data antarmuka (seperti komponen `ListBox`), dan meminimalisir redundansi penulisan kode program secara manual. Praktikum mencakup pengujian terhadap kategori perulangan terhitung (*counted loop*) dan tidak terhitung (*uncounted loop*), manipulasi langkah iterasi (*step* positif dan negatif), evaluasi kondisi awal vs kondisi akhir, hingga penerapan perulangan bersarang (*nested loop*).

---

## 2. Arsitektur Komponen Visual (UI Controls)

| Kontrol UI | Identitas `(Name)` | Properti Kunci | Deskripsi Fungsional |
| :--- | :--- | :--- | :--- |
| **ListBox** | `lstHasil` | `IntegralHeight: True` | Menampilkan baris hasil keluaran dari setiap iterasi perulangan |
| **TextBox** | `txtBatas` | `Text: ""` | Menerima batas nilai akhir atau jumlah repetisi dari pengguna |
| **Button** | `btnForNext` | `Text: "For-Next"` | Menjalankan iterasi pasti menggunakan pencacah variabel terhitung |
| **Button** | `btnWhile` | `Text: "While"` | Menjalankan perulangan dengan evaluasi kondisi di awal blok |
| **Button** | `btnDoLoop` | `Text: "Do-Loop"` | Menjalankan iterasi kondisional yang diperiksa di akhir blok |
| **Button** | `btnNested` | `Text: "Nested Loop"` | Mengeksekusi perulangan bertingkat (*outer* dan *inner loop*) |
| **Button** | `btnReset` | `Text: "Reset"` | Mengosongkan daftar item pada `ListBox` dan kotak teks masukan |

---

## 3. Logika Kode (`Form1.vb`)

```vb
Public Class Form1

    Private Sub btnForNext_Click(sender As Object, e As EventArgs) Handles btnForNext.Click
        lstHasil.Items.Clear()

        Dim batas As Integer
        If Not Integer.TryParse(txtBatas.Text, batas) OrElse batas < 1 Then
            MessageBox.Show("Masukkan bilangan bulat positif")
            txtBatas.Focus()
            Return
        End If

        For i As Integer = 1 To batas
            lstHasil.Items.Add("Iterasi For: " & i.ToString())
        Next
    End Sub

    Private Sub btnWhile_Click(sender As Object, e As EventArgs) Handles btnWhile.Click
        lstHasil.Items.Clear()

        Dim batas As Integer
        If Not Integer.TryParse(txtBatas.Text, batas) OrElse batas < 1 Then
            MessageBox.Show("Masukkan bilangan bulat positif")
            txtBatas.Focus()
            Return
        End If

        Dim i As Integer = 1
        While i <= batas
            lstHasil.Items.Add("Iterasi While: " & i.ToString())
            i += 1
        End While
    End Sub

    Private Sub btnDoLoop_Click(sender As Object, e As EventArgs) Handles btnDoLoop.Click
        lstHasil.Items.Clear()

        Dim batas As Integer
        If Not Integer.TryParse(txtBatas.Text, batas) OrElse batas < 1 Then
            MessageBox.Show("Masukkan bilangan bulat positif")
            txtBatas.Focus()
            Return
        End If

        Dim i As Integer = 1
        Do
            lstHasil.Items.Add("Iterasi Do-Loop: " & i.ToString())
            i += 1
        Loop While i <= batas
    End Sub

    Private Sub btnNested_Click(sender As Object, e As EventArgs) Handles btnNested.Click
        lstHasil.Items.Clear()

        For i As Integer = 1 To 3
            For j As Integer = 1 To 3
                lstHasil.Items.Add(i.ToString() & "-" & j.ToString())
            Next
        Next
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        lstHasil.Items.Clear()
        txtBatas.Clear()
        txtBatas.Focus()
    End Sub

End Class
```

---

## 4. Pembahasan Detail Konsep Teknis

### Paradigma Counted Loop vs Uncounted Loop
* **Counted Loop**: Struktur perulangan di mana batas iterasi telah didefinisikan secara presisi sebelum blok dijalankan, umumnya memakai `For...To...Next`.
* **Uncounted Loop**: Struktur perulangan di mana jumlah eksekusi tidak ditentukan di awal melainkan bergantung pada kebenaran kondisi logika (boolean `True`/`False`), seperti pada `While...End While` atau `Do...Loop While`.

### Penggunaan Variabel Pengontrol dan Parameter Step
Variabel pengontrol bertindak sebagai register nilai pencacah (*counter*). Secara *default*, nilai pencacah bertambah `+1`, tetapi dapat dikonfigurasi melalui klausa `Step`:
* **Inkrementasi**: `For i As Integer = 1 To 10 Step 1` menaikkan nilai variabel pada setiap siklus.
* **Dekrementasi**: `For i As Integer = 10 To 1 Step -1` menurunkan nilai variabel secara bertahap.

### Perbedaan Evaluasi: While (Kondisi di Awal) vs Do-Loop (Kondisi di Akhir)
* **While...End While / Do While...Loop**: Pengujian kondisi dilakukan di awal (*pre-condition*). Jika kondisi bernilai `False` sejak baris pertama, blok kode di dalamnya tidak akan pernah dijalankan sama sekali (0 kali).
* **Do...Loop While**: Instruksi dieksekusi terlebih dahulu sebelum pemeriksaan kondisi dilakukan di bagian bawah (*post-condition*). Hal ini menjamin blok kode dijalankan minimal satu kali meskipun kondisi awalnya bernilai salah.

### Konsep Perulangan Bersarang (Nested Loop)
Perulangan bersarang melibatkan struktur loop di dalam loop lain. Mekanisme alurnya: perulangan dalam (*inner loop*) akan menyelesaikan seluruh daur iterasinya dari awal hingga tuntas pada setiap satu kali pergantian iterasi perulangan luar (*outer loop*).

---

## 5. Klasifikasi dan Karakteristik Struktur Perulangan

| Jenis Perulangan | Tipe Kategori | Posisi Pengecekan | Jumlah Eksekusi Minimal | Kasus Penggunaan Ideal |
| :--- | :--- | :--- | :--- | :--- |
| `For...Next` | *Counted* | Awal iterasi | 0 Kali | Iterasi dengan batas indeks, array, atau pencacah pasti |
| `For...Step -1` | *Counted* | Awal iterasi | 0 Kali | Operasi hitung mundur (*countdown*) atau penelusuran terbalik |
| `While...End While` | *Uncounted* | Awal iterasi | 0 Kali | Proses yang hanya boleh berjalan jika syarat ketat terpenuhi |
| `Do...Loop While` | *Uncounted* | Akhir iterasi | 1 Kali | Validasi masukan berulang dan pembacaan *stream* data sekurang-kurangnya sekali |
| `Nested For` | Bertingkat | Hirarkis (*outer/inner*) | 0 Kali | Pemrosesan matriks, koordinat kisi (*grid*), atau kombinasi berpasangan |

---

## 6. Kesimpulan

Pada praktikum Pertemuan 04 ini diterapkan prinsip-prinsip kontrol perulangan dalam lingkungan VB.NET, yaitu:

* **Otomasi penambahan koleksi data**: Menggunakan *method* `ListBox.Items.Add()` untuk mengisi kontrol antarmuka visual secara dinamis.
* **Struktur perulangan terhitung (`For...Next`)**: Mengeksekusi instruksi dengan batas repetisi yang terdefinisi secara pasti.
* **Pengaturan arah dan interval pencacahan**: Menggunakan parameter `Step` positif (inkrementasi) dan negatif (dekrementasi).
* **Struktur perulangan tidak terhitung (`While` dan `Do-Loop`)**: Eksekusi perulangan berdasarkan evaluasi kondisi boolean.
* **Perbedaan alur evaluasi kondisi**: Pemahaman perbedaan antara evaluasi di awal (*pre-condition*) dan evaluasi di akhir (*post-condition*).
* **Perulangan bertingkat (*nested loop*)**: Memetakan dan memproses hubungan data multidimensi atau kombinasi baris dan kolom.
