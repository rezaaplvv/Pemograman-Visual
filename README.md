<div align="center">

# DOKUMENTASI PRAKTIKUM PEMOGRAMAN VISUAL

</div>


---

## Daftar Modul Praktikum

| Modul | Topik Pembahasan | Status | Tautan Dokumentasi |
| :---: | :--- | :---: | :---: |
| **Pertemuan 01** | Orientasi & Fundamental Pemrograman Visual | Selesai | [Buka Dokumentasi](./Pertemuan1-OrientasiPemogramanVisual/readme.md) |
| **Pertemuan 02** | Komponen Visual Windows Forms, Event Handling, dan Properti | Selesai | [Buka Dokumentasi](./Pertemuan2-KomponenVisual/readme.md) |
| **Pertemuan 03** | Operator, Struktur Pengendalian, dan Validasi Input | Selesai | [Buka Dokumentasi](./Pertemuan3-Operator-dan-struktur-pengendalian/readme.md) |

---

<div align="center">

# KAMUS SINTAKS
</div>


### 1. Komponen Antarmuka (UI Controls)

| Perintah / Sintaks | Kategori | Penjelasan Singkat |
| :--- | :---: | :--- |
| `txtInput.Text` | `TextBox` | Membaca atau mengisi nilai teks pada kotak input. |
| `txtInput.Clear()` | `TextBox` | Mengosongkan seluruh karakter di dalam TextBox. |
| `txtInput.Focus()` | `TextBox` | Memindahkan kursor keyboard langsung ke TextBox tujuan. |
| `txtInput.SelectionStart = n` | `TextBox` | Mengatur posisi kursor teks ke indeks karakter tertentu. |
| `txtInput.PasswordChar = "*"` | `TextBox` | Mengaburkan input teks dengan karakter khusus (*password masking*). |
| `txtInput.ReadOnly = True` | `TextBox` | Mengunci TextBox agar hanya bisa dibaca (*read-only*), tidak bisa diedit. |
| `cmbRole.SelectedIndex` | `ComboBox` | Mengambil indeks item aktif (`0` untuk item pertama, `-1` jika belum ada yang dipilih). |
| `cmbRole.SelectedItem.ToString()` | `ComboBox` | Mengambil nilai teks string dari item dropdown yang sedang dipilih. |
| `cmbRole.Items.Add("Teks")` | `ComboBox` | Menambahkan opsi pilihan baru ke dalam daftar dropdown secara dinamis. |
| `cmbRole.DropDownStyle = ComboBoxStyle.DropDownList` | `ComboBox` | Mengunci input manual; pengguna hanya diperbolehkan memilih dari daftar. |
| `picAvatar.Image = Image.FromFile("path")` | `PictureBox` | Memuat dan menampilkan berkas gambar secara dinamis dari direktori. |
| `picAvatar.SizeMode = PictureBoxSizeMode.Zoom` | `PictureBox` | Menyesuaikan proporsi gambar otomatis tanpa merusak rasio dimensi (*aspect ratio*). |
| `btnSubmit.Enabled = False / True` | `Button` | Menonaktifkan (*disable*) atau mengaktifkan kembali tombol aksi. |
| `lblHasil.Text = "Hasil"` | `Label` | Menampilkan teks output statis maupun dinamis pada label antarmuka. |

---

### 2. Manipulasi String & Teks

| Perintah / Sintaks | Penjelasan Singkat |
| :--- | :--- |
| `teks.Trim()` | Menghapus spasi kosong berlebih di ujung awal dan akhir teks. |
| `teks.ToLower()` | Mengubah teks menjadi huruf kecil semua (*case-insensitive comparison*). |
| `teks.ToUpper()` | Mengubah teks menjadi huruf kapital semua. |
| `String.IsNullOrWhiteSpace(teks)` | Mengembalikan `True` jika variabel bernilai kosong, `Nothing`, atau hanya berisi spasi. |
| `teks.Replace("a", "b")` | Mengganti substring target menjadi nilai baru (contoh: membersihkan tanda titik ribuan). |
| `teks.Contains("kata")` | Mengecek apakah teks mengandung potongan kata tertentu (mengembalikan `Boolean`). |
| `teks.Length` | Menghitung total jumlah karakter di dalam string. |
| `teks1 & teks2` | Operator penggabung string resmi di VB.NET (*string concatenation*). |
| `vbCrLf` / `Environment.NewLine` | Karakter enter / pembuat baris baru (*newline*). |

---

### 3. Konversi Data & Parsing Numerik

| Perintah / Sintaks | Penjelasan Singkat |
| :--- | :--- |
| `Decimal.TryParse(str, desimalOut)` | Mengonversi string ke `Decimal` secara aman tanpa memicu *runtime crash*. |
| `Integer.TryParse(str, intOut)` | Mengonversi string ke `Integer` tanpa memicu *crash*. |
| `CInt(val)` / `CDbl(val)` / `CDec(val)` | Konversi langsung tipe data ke `Integer`, `Double`, atau `Decimal`. |
| `CStr(val)` / `val.ToString()` | Mengubah sembarang nilai/objek menjadi representasi `String`. |
| `angka.ToString("N0")` | Memformat angka dengan pemisah ribuan standar (contoh: `1.000.000`). |
| `angka.ToString("C0", New CultureInfo("id-ID"))` | Format otomatis ke mata uang Rupiah (contoh: `Rp1.000.000`). |

> [!TIP]
> Selalu utamakan penggunaan `TryParse` dibandingkan fungsi konversi langsung (`CInt`/`CDec`) saat membaca input dari pengguna untuk menghindari `FormatException` atau `InvalidCastException`.

---

### 4. Validasi Karakter Input (`KeyPress Event`)

| Sintaks Pengecekan | Nilai Kembalian / Kegunaan |
| :--- | :--- |
| `e.KeyChar` | Mengambil karakter tombol keyboard yang sedang ditekan. |
| `e.Handled = True` | Membatalkan/menolak karakter agar tidak dicetak ke layar input. |
| `Char.IsDigit(e.KeyChar)` | Mengembalikan `True` jika tombol berupa angka `0–9`. |
| `Char.IsLetter(e.KeyChar)` | Mengembalikan `True` jika tombol berupa huruf alfabet `a–z` atau `A–Z`. |
| `Char.IsControl(e.KeyChar)` | Mengembalikan `True` untuk tombol kontrol sistem (seperti <kbd>Backspace</kbd> atau <kbd>Enter</kbd>). |
| `Char.IsWhiteSpace(e.KeyChar)` | Mengembalikan `True` jika tombol yang ditekan adalah <kbd>Space</kbd>. |

> [!NOTE]
> Contoh pola blokir input selain angka pada event `KeyPress`:
> ```vb
> Private Sub txtHanyaAngka_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHanyaAngka.KeyPress
>     If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
>         e.Handled = True ' Tolak karakter non-angka
>     End If
> End Sub
> ```

---

### 5. Kotak Pesan & Navigasi Antar-Form

| Perintah / Sintaks | Penjelasan Singkat |
| :--- | :--- |
| `MessageBox.Show("Pesan", "Judul", MessageBoxButtons.OK, MessageBoxIcon.Information)` | Menampilkan dialog pop-up informasi dengan ikon biru info (ℹ️). |
| `MessageBox.Show("Pesan", "Judul", MessageBoxButtons.OK, MessageBoxIcon.Warning)` | Menampilkan dialog pop-up peringatan dengan ikon segitiga kuning (⚠️). |
| `MessageBox.Show("Pesan", "Judul", MessageBoxButtons.OK, MessageBoxIcon.Error)` | Menampilkan dialog pop-up kesalahan dengan ikon silang merah (❌). |
| `Dim res = MessageBox.Show("Hapus?", "Tanya", MessageBoxButtons.YesNo)` | Menampilkan dialog konfirmasi pilihan ganda (*Yes/No*). |
| `Dim f As New Form2()` | Membuat instansiasi objek baru untuk form kedua di memori. |
| `f.Show()` | Membuka form baru secara *non-modal* (form induk masih aktif dan bisa diklik). |
| `f.ShowDialog()` | Membuka form baru secara *modal* (mengunci form induk sampai form baru ditutup). |
| `Me.Hide()` | Menyembunyikan tampilan form yang sedang aktif tanpa mematikannya dari memori. |
| `Me.Close()` | Menutup form saat ini dan melepaskan *resource* (*dispose*). |
| `Application.Exit()` | Menghentikan seluruh *thread* dan mematikan total jalannya aplikasi. |
| `Return` | Menghentikan alur eksekusi baris kode di dalam sub/fungsi saat itu juga. |
