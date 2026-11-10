<div align="center">

# PERTEMUAN 06
### Koneksi Database PostgreSQL (Supabase) Menggunakan Npgsql (VB.NET)

</div>

---

## 1. Deskripsi Praktikum

Praktikum ini berfokus pada integrasi aplikasi desktop **Windows Forms (VB.NET)** dengan sistem basis data relasional modern berbasis *cloud* (**PostgreSQL** yang dihosting pada **Supabase**) menggunakan *driver provider* **Npgsql**.

Tujuan utama dari praktikum ini adalah:
- Memahami konsep dasar basis data relasional (*Relational Database*) dan ekosistem *Backend-as-a-Service* (**Supabase**).
- Mengintegrasikan ADO.NET *Data Provider* (**Npgsql**) sebagai jembatan penghubung antara runtime .NET dan PostgreSQL.
- Mengelola konfigurasi string koneksi (*connection string*) secara dinamis dan modular menggunakan file konfigurasi JSON (`appsettings.json`).
- Mengimplementasikan komponen ADO.NET seperti `NpgsqlConnection`, `NpgsqlCommand`, dan `NpgsqlDataAdapter` untuk operasi pengambilan (*Read*) dan manipulasi (*Create, Update, Delete*) data.
- Menjaga keamanan data dari celah keamanan *SQL Injection* menggunakan metode *parameterized query* (`Parameters.AddWithValue`).

---

## 2. Arsitektur Komponen Visual (UI Controls)

| Kontrol UI | Identitas `(Name)` | Properti Kunci | Deskripsi Fungsional |
| :--- | :--- | :--- | :--- |
| **DataGridView** | `dgvMahasiswa` | `ColumnHeadersHeightSizeMode: AutoSize` | Menampilkan data tabel dari database secara tabular |
| **TextBox** | `txtNama` | `Text: ""` | Menerima masukan nama mahasiswa |
| **TextBox** | `txtNIM` | `Text: ""` | Menerima masukan Nomor Induk Mahasiswa (NIM) |
| **TextBox** | `txtJurusan` | `Text: ""` | Menerima masukan jurusan/program studi |
| **Button** | `btnTampilkan` | `Text: "Tampilkan"` | Memicu uji koneksi database dan pemuatan data ke `DataGridView` |
| **Button** | `btnTambah` | `Text: "Tambah"` | Mengeksekusi penambahan data baru (*Insert*) ke tabel database |
| **Label** | `Label1`, `Label2`, `Label3` | `Text: "Nama", "NIM", "Jurusan"` | Memberikan label identifikasi untuk setiap input teks |

---

## 3. Logika Kode Program

### 3.1 `appsettings.json`
Menyimpan konfigurasi string koneksi ke instance cloud Supabase secara terpisah agar aman dan modular:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=aws-0-ap-northeast-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.cwtfcqxaaanflvndjtcz;Password=YOUR_PASSWORD;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

### 3.2 `ModDatabase.vb`
Modul konfigurasi dan manajemen sesi koneksi ke PostgreSQL:

```vb
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase

    ' Mengambil string koneksi dari appsettings.json
    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function

    ' Menguji pembukaan dan penutupan sesi koneksi fisik ke database
    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString())
                conn.Open()
                MessageBox.Show("Koneksi database berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal:" & vbCrLf & ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
```

### 3.3 `ModFunction.vb`
Modul utilitas pengeksekusi query CRUD dan pembaca data:

```vb
Imports Npgsql
Imports System.Data

Module ModFunction

    ' Mengambil data dari database dan memuatnya ke dalam DataTable (In-Memory)
    Public Function AmbilData(query As String) As DataTable
        Dim dt As New DataTable

        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data:" & vbCrLf & ex.Message, "Error Database")
        End Try

        Return dt
    End Function

    ' Mengeksekusi perintah SQL non-query (INSERT, UPDATE, DELETE) dengan Parameterized Query
    Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    For Each parameter In parameters
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                    Next
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengeksekusi data:" & vbCrLf & ex.Message, "Error Database")
            Return False
        End Try
    End Function

End Module
```

### 3.4 `Form1.vb`
Logika pada antarmuka *Windows Forms* yang menghubungkan aksi tombol dengan modul database:

```vb
Public Class Form1

    ' Tombol untuk menguji koneksi database
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        DatabaseKoneksi()
    End Sub

    ' Event handler form load & komponen antarmuka lainnya
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inisialisasi awal atau pemuatan data tabel
    End Sub

End Class
```

---

## 4. Pembahasan Detail Konsep Teknis

### 4.1 Ekosistem PostgreSQL dan Supabase
* **PostgreSQL**: Sistem manajemen basis data relasional objek (*Object-Relational Database Management System* / ORDBMS) open-source yang tangguh, aman, dan mematuhi standar ANSI-SQL.
* **Supabase**: Platform *Backend-as-a-Service* (BaaS) berbasis cloud yang mengemas PostgreSQL dengan panel dasbor interaktif, API bawaan, dan fitur autentikasi otomatis tanpa perlu merancang infrastruktur server dari awal.

### 4.2 Peran Npgsql dalam Arsitektur .NET
**Npgsql** adalah pustaka ADO.NET *Data Provider* sumber terbuka yang bertindak sebagai "jembatan komunikasi" antara aplikasi .NET (VB.NET/C#) dengan server database PostgreSQL menggunakan protokol jaringan PostgreSQL native.

### 4.3 Empat Komponen Utama ADO.NET Npgsql
1. **`NpgsqlConnection`**: Bertanggung jawab membuka, menjaga, dan menutup jalur koneksi fisik/sesi jaringan antara aplikasi dengan server PostgreSQL.
2. **`NpgsqlCommand`**: Menampung perintah SQL (`SELECT`, `INSERT`, `UPDATE`, `DELETE`) atau *stored procedure* untuk dieksekusi melalui koneksi yang terbuka.
3. **`NpgsqlDataAdapter`**: Jembatan data dua arah yang menarik hasil query dari database ke objek memori lokal (`DataTable`/`DataSet`) melalui metode `.Fill()`, serta menyinkronkan kembali perubahan ke server.
4. **`NpgsqlCommandBuilder`**: Utilitas otomatis yang menghasilkan kueri SQL modifikasi (`INSERT`, `UPDATE`, `DELETE`) secara otomatis berdasarkan perintah `SELECT` milik data adapter.

### 4.4 Keamanan Parameterized Query (Pencegahan SQL Injection)
Pada fungsi `EksekusiData`, alih-alih menggabungkan string kueri secara manual (*string concatenation*):
```vb
' CARA TIDAK AMAN (Rentan SQL Injection):
Dim query As String = "INSERT INTO mahasiswa VALUES ('" & txtNama.Text & "')"
```
Kode menggunakan dictionary parameter dan `cmd.Parameters.AddWithValue`:
```vb
' CARA AMAN (Parameterized Query):
For Each parameter In parameters
    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
Next
```
Pendekatan ini menjamin input pengguna diperlakukan murni sebagai nilai data (*literal value*) dan tidak akan dieksekusi sebagai instruksi SQL berbahaya.

### 4.5 Manajemen Sumber Daya dengan Blok `Using`
Semua objek koneksi (`NpgsqlConnection`), perintah (`NpgsqlCommand`), dan adapter (`NpgsqlDataAdapter`) dibungkus dalam blok `Using`:
* Memastikan koneksi jaringan dan *unmanaged resources* langsung ditutup dan dibersihkan dari memori (*dispose*) segera setelah blok selesai dieksekusi, bahkan jika terjadi error (*exception*).

---

## 5. Klasifikasi Komponen ADO.NET Npgsql

| Komponen ADO.NET | Tipe Objek | Peran Utama | Metode / Properti Kunci | Kasus Penggunaan Ideal |
| :--- | :--- | :--- | :--- | :--- |
| **`NpgsqlConnection`** | Jalur Komunikasi | Mengelola sesi koneksi ke host database | `.Open()`, `.Close()`, `.State` | Membuka dan mengamankan saluran transfer data ke Supabase |
| **`NpgsqlCommand`** | Eksekutor Kueri | Mengirim dan mengeksekusi instruksi SQL | `.ExecuteNonQuery()`, `.ExecuteReader()` | Menjalankan perintah manipulasi data atau kueri langsung |
| **`NpgsqlDataAdapter`** | Jembatan Data | Menghubungkan database dengan memori aplikasi | `.Fill(DataTable)`, `.Update(DataTable)` | Mengisi data ke kontrol visual seperti `DataGridView` |
| **`NpgsqlCommandBuilder`** | Generator SQL | Mengenerate kueri SQL modifikasi otomatis | `.GetInsertCommand()`, `.GetUpdateCommand()` | Menyimpan perubahan grid kembali ke database otomatis |
| **`DataTable`** | Wadah Memori (*In-Memory*) | Menyimpan tabel data di memori klien | `.Rows`, `.Columns`, `.Clear()` | Sumber data (*DataSource*) untuk komponen visual |

---

## 6. Kesimpulan

Pada praktikum Pertemuan 06 ini disimpulkan prinsip-prinsip penting integrasi database:

1. **Pemisahan Konfigurasi**: Mengamankan *connection string* di file `appsettings.json` memisahkan data kredensial dari kode logika program.
2. **Koneksi Modern Berbasis Cloud**: Pemanfaatan Supabase mempermudah pengelolaan database PostgreSQL tanpa perlu setup server lokal manual.
3. **Penyedia Data ADO.NET**: Npgsql menyediakan integrasi native yang efisien untuk mengeksekusi perintah SQL di lingkungan .NET.
4. **Pencegahan SQL Injection**: Penggunaan parameterisasi query (`AddWithValue`) adalah standar wajib dalam menjaga integritas dan keamanan aplikasi dari peretasan basis data.
5. **Manajemen Memori yang Aman**: Penggunaan blok `Using` menjamin jalur koneksi selalu ditutup secara otomatis untuk mencegah kebocoran koneksi (*connection leak*).

