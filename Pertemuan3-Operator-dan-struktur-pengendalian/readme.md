\# PERTEMUAN 03

\*\*Operator, Struktur Pengendalian, dan Validasi Input (VB.NET)\*\*



\---



\### 1. Deskripsi Praktikum



Praktikum ini berfokus pada penerapan logika komputasi dan kendali alur eksekusi program pada arsitektur Windows Forms menggunakan bahasa Visual Basic .NET. Studi kasus yang diimplementasikan adalah sistem evaluasi nilai numerik berbasis rentang skor yang dinamis, dilengkapi penanganan kesalahan input (input validation) dan manipulasi aset visual secara runtime.



\---



\### 2. Arsitektur Komponen Visual (UI Controls)



| Kontrol UI | Identitas (Name) | Properti Kunci | Deskripsi Fungsional |

| :--- | :--- | :--- | :--- |

| \*\*PictureBox\*\* | picImage | SizeMode: StretchImage | Menampilkan gambar representasi hasil evaluasi skor secara visual. |

| \*\*TextBox\*\* | txtNilai | Text: "" | Bidang input data nilai numerik dari pengguna. |

| \*\*Button\*\* | btnInput | Text: "Input" | Pemicu eksekusi logika pengujian kondisi dan kalkulasi. |



\---



\### 3. Logika Kode \& Analisis Struktur (Form1.vb)



Public Class Form1



&#x20;   Private Sub btnInput\_Click(sender As Object, e As EventArgs) Handles btnInput.Click

&#x20;       Dim nilai As Integer



&#x20;       ' 1. Validasi Tipe Data: Mencegah error konversi jika input bukan angka

&#x20;       If Not Integer.TryParse(txtNilai.Text, nilai) Then

&#x20;           MessageBox.Show("Masukkan dalam bentuk angka")

&#x20;           txtNilai.Focus()

&#x20;           Return

&#x20;       End If



&#x20;       ' 2. Validasi Batas Nilai: Membatasi jangkauan angka 0 hingga 100

&#x20;       If nilai < 0 OrElse nilai > 100 Then

&#x20;           MessageBox.Show("Masukkan Nilai 0-100")

&#x20;           txtNilai.Focus()

&#x20;           Return

&#x20;       End If



&#x20;       ' 3. Struktur Pengendalian: Percabangan bertingkat untuk pemilihan aset gambar

&#x20;       If nilai <= 50 Then

&#x20;           picImage.Image = Image.FromFile("Asset\\1.jpeg")

&#x20;       ElseIf nilai <= 70 Then

&#x20;           picImage.Image = Image.FromFile("Asset\\2.png")

&#x20;       Else

&#x20;           picImage.Image = Image.FromFile("Asset\\3.png")

&#x20;       End If

&#x20;   End Sub



&#x20;   Private Sub txtNilai\_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress

&#x20;       ' Restriksi Input Real-Time: Hanya mengizinkan digit angka (0-9) dan tombol kontrol (Backspace)

&#x20;       If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then

&#x20;           e.Handled = True

&#x20;       End If

&#x20;   End Sub



End Class



\---



\### 4. Pembahasan Detail Konsep Teknis



\* \*\*Metode Integer.TryParse\*\*: Digunakan untuk melakukan type casting defensif dari tipe string ke integer. Berbeda dengan fungsi konversi standar seperti CInt() yang akan melempar runtime exception saat input kosong atau berupa karakter acak, TryParse mengembalikan nilai boolean (True/False) sehingga alur program tetap aman.

\* \*\*Operator Logika OrElse dan AndAlso (Short-Circuiting)\*\*: Pengecekan batasan nilai menggunakan operator logika short-circuit. Jika kondisi pertama sudah terpenuhi (misal nilai < 0), sistem tidak akan mengevaluasi kondisi kedua (nilai > 100), sehingga meningkatkan efisiensi eksekusi instruksi.

\* \*\*Event Handler KeyPress \& Parameter e.Handled\*\*: Filter input diterapkan langsung pada level penekanan tombol keyboard. Properti e.Handled = True menginstruksikan sistem operasi untuk mengabaikan karakter non-digit sebelum karakter tersebut sempat dicetak ke dalam kontrol TextBox.

\* \*\*Manajemen Aset Runtime (Image.FromFile)\*\*: Pemuatan berkas gambar dilakukan secara dinamis menggunakan jalur relatif (Asset\\...). Hal ini mensyaratkan direktori aset disalin ke direktori target eksekusi program (bin\\Debug\\...) dengan mengatur konfigurasi Copy to Output Directory menjadi Copy if newer.



\---



\### 5. Aturan Bisnis \& Logika Evaluasi Skor



| Rentang Nilai | Kondisi Logika | Output Aset Terpilih |

| :--- | :--- | :--- |

| \*\*0 – 50\*\* | nilai <= 50 | Asset\\1.jpeg |

| \*\*51 – 70\*\* | nilai > 50 AndAlso nilai <= 70 | Asset\\2.png |

| \*\*71 – 100\*\* | nilai > 70 AndAlso nilai <= 100 | Asset\\3.png |

| \*\*< 0 atau > 100\*\* | nilai < 0 OrElse nilai > 100 | Dialog Peringatan: "Masukkan Nilai 0-100" |

