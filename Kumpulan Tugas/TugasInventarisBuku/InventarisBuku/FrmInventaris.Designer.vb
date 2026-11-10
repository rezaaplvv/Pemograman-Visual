<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInventaris
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblPenulis = New Label()
        txtPenulis = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblTahun = New Label()
        txtTahun = New TextBox()
        lblStok = New Label()
        txtStok = New TextBox()
        btnTambah = New Button()
        btnBersihkan = New Button()
        lblCari = New Label()
        txtCari = New TextBox()
        lblFilterKategor = New Label()
        cboFilterKategori = New ComboBox()
        chkStokHabis = New CheckBox()
        lblUrutkan = New Label()
        cboUrut = New ComboBox()
        dgvBuku = New DataGridView()
        lblJumlah = New Label()
        lblTotalStok = New Label()
        bsBuku = New BindingSource(components)
        errBuku = New ErrorProvider(components)
        CType(dgvBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(errBuku, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(12, 9)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(278, 25)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Inventaris Buku Perpustakaan"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Location = New Point(12, 45)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(64, 15)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.BackColor = Color.White
        txtKodeBuku.Location = New Point(12, 63)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(260, 23)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(11, 113)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(65, 15)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul Buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(12, 131)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(260, 23)
        txtJudul.TabIndex = 4
        ' 
        ' lblPenulis
        ' 
        lblPenulis.AutoSize = True
        lblPenulis.Location = New Point(12, 169)
        lblPenulis.Name = "lblPenulis"
        lblPenulis.Size = New Size(45, 15)
        lblPenulis.TabIndex = 5
        lblPenulis.Text = "Penulis"
        ' 
        ' txtPenulis
        ' 
        txtPenulis.Location = New Point(12, 187)
        txtPenulis.Name = "txtPenulis"
        txtPenulis.Size = New Size(260, 23)
        txtPenulis.TabIndex = 6
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(12, 239)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(51, 15)
        lblKategori.TabIndex = 7
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(12, 257)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(260, 23)
        cboKategori.TabIndex = 8
        ' 
        ' lblTahun
        ' 
        lblTahun.AutoSize = True
        lblTahun.Location = New Point(12, 310)
        lblTahun.Name = "lblTahun"
        lblTahun.Size = New Size(73, 15)
        lblTahun.TabIndex = 9
        lblTahun.Text = "Tahun Terbit"
        ' 
        ' txtTahun
        ' 
        txtTahun.Location = New Point(12, 328)
        txtTahun.MaxLength = 4
        txtTahun.Name = "txtTahun"
        txtTahun.Size = New Size(260, 23)
        txtTahun.TabIndex = 10
        ' 
        ' lblStok
        ' 
        lblStok.AutoSize = True
        lblStok.Location = New Point(12, 386)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(30, 15)
        lblStok.TabIndex = 11
        lblStok.Text = "Stok"
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(12, 404)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(260, 23)
        txtStok.TabIndex = 12
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(12, 451)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(109, 33)
        btnTambah.TabIndex = 13
        btnTambah.Text = "Tambah Buku"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.Location = New Point(163, 451)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(109, 33)
        btnBersihkan.TabIndex = 14
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' lblCari
        ' 
        lblCari.AutoSize = True
        lblCari.Location = New Point(324, 45)
        lblCari.Name = "lblCari"
        lblCari.Size = New Size(101, 15)
        lblCari.TabIndex = 15
        lblCari.Text = "Cari judul/penulis"
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(324, 63)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(592, 23)
        txtCari.TabIndex = 16
        ' 
        ' lblFilterKategor
        ' 
        lblFilterKategor.AutoSize = True
        lblFilterKategor.Location = New Point(324, 98)
        lblFilterKategor.Name = "lblFilterKategor"
        lblFilterKategor.Size = New Size(80, 15)
        lblFilterKategor.TabIndex = 17
        lblFilterKategor.Text = "Filter Kategori"
        ' 
        ' cboFilterKategori
        ' 
        cboFilterKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterKategori.FormattingEnabled = True
        cboFilterKategori.Items.AddRange(New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboFilterKategori.Location = New Point(324, 116)
        cboFilterKategori.Name = "cboFilterKategori"
        cboFilterKategori.Size = New Size(172, 23)
        cboFilterKategori.TabIndex = 18
        ' 
        ' chkStokHabis
        ' 
        chkStokHabis.AutoSize = True
        chkStokHabis.Location = New Point(502, 118)
        chkStokHabis.Name = "chkStokHabis"
        chkStokHabis.Size = New Size(119, 19)
        chkStokHabis.TabIndex = 19
        chkStokHabis.Text = "Hanya Stok Habis"
        chkStokHabis.UseVisualStyleBackColor = True
        ' 
        ' lblUrutkan
        ' 
        lblUrutkan.AutoSize = True
        lblUrutkan.Location = New Point(705, 98)
        lblUrutkan.Name = "lblUrutkan"
        lblUrutkan.Size = New Size(79, 15)
        lblUrutkan.TabIndex = 20
        lblUrutkan.Text = "Urutkan Buku"
        ' 
        ' cboUrut
        ' 
        cboUrut.DropDownStyle = ComboBoxStyle.DropDownList
        cboUrut.FormattingEnabled = True
        cboUrut.Items.AddRange(New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"})
        cboUrut.Location = New Point(705, 118)
        cboUrut.Name = "cboUrut"
        cboUrut.Size = New Size(211, 23)
        cboUrut.TabIndex = 21
        ' 
        ' dgvBuku
        ' 
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.AllowUserToDeleteRows = False
        dgvBuku.BackgroundColor = Color.White
        dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBuku.Location = New Point(324, 158)
        dgvBuku.MultiSelect = False
        dgvBuku.Name = "dgvBuku"
        dgvBuku.ReadOnly = True
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.Size = New Size(592, 326)
        dgvBuku.TabIndex = 22
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(324, 504)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(151, 15)
        lblJumlah.TabIndex = 23
        lblJumlah.Text = "Menampilkan 0 dari 0 buku"
        ' 
        ' lblTotalStok
        ' 
        lblTotalStok.AutoSize = True
        lblTotalStok.Location = New Point(324, 537)
        lblTotalStok.Name = "lblTotalStok"
        lblTotalStok.Size = New Size(136, 15)
        lblTotalStok.TabIndex = 24
        lblTotalStok.Text = "Total stok yang tampil: 0"
        ' 
        ' errBuku
        ' 
        errBuku.ContainerControl = Me
        ' 
        ' FrmInventaris
        ' 
        AcceptButton = btnTambah
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Ivory
        ClientSize = New Size(944, 561)
        Controls.Add(lblTotalStok)
        Controls.Add(lblJumlah)
        Controls.Add(dgvBuku)
        Controls.Add(cboUrut)
        Controls.Add(lblUrutkan)
        Controls.Add(chkStokHabis)
        Controls.Add(cboFilterKategori)
        Controls.Add(lblFilterKategor)
        Controls.Add(txtCari)
        Controls.Add(lblCari)
        Controls.Add(btnBersihkan)
        Controls.Add(btnTambah)
        Controls.Add(txtStok)
        Controls.Add(lblStok)
        Controls.Add(txtTahun)
        Controls.Add(lblTahun)
        Controls.Add(cboKategori)
        Controls.Add(lblKategori)
        Controls.Add(txtPenulis)
        Controls.Add(lblPenulis)
        Controls.Add(txtJudul)
        Controls.Add(lblJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        MaximizeBox = False
        Name = "FrmInventaris"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventaris Buku Perpustakaan"
        CType(dgvBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(errBuku, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblPenulis As Label
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblTahun As Label
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblFilterKategor As Label
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents lblUrutkan As Label
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents errBuku As ErrorProvider
    Friend WithEvents txtCari As System.Windows.Forms.TextBox

End Class
