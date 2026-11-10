<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPeminjaman
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
        errPinjam = New ErrorProvider(components)
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblNamaPeminjam = New Label()
        txtNamaPeminjam = New TextBox()
        lblLamaPinjam = New Label()
        txtLamaPinjam = New TextBox()
        btnPinjam = New Button()
        btnBersihkan = New Button()
        btnEkspor = New Button()
        lblStatus = New Label()
        lstPeminjaman = New ListBox()
        CType(errPinjam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' errPinjam
        ' 
        errPinjam.ContainerControl = Me
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudulForm.Location = New Point(12, 20)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(173, 25)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Buku"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Location = New Point(12, 63)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(61, 15)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "KodeBuku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(12, 81)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(140, 23)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(12, 116)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(65, 15)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul Buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(12, 134)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(140, 23)
        txtJudul.TabIndex = 4
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(12, 172)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(51, 15)
        lblKategori.TabIndex = 5
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(12, 190)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(140, 23)
        cboKategori.TabIndex = 6
        ' 
        ' lblNamaPeminjam
        ' 
        lblNamaPeminjam.AutoSize = True
        lblNamaPeminjam.Location = New Point(12, 226)
        lblNamaPeminjam.Name = "lblNamaPeminjam"
        lblNamaPeminjam.Size = New Size(96, 15)
        lblNamaPeminjam.TabIndex = 7
        lblNamaPeminjam.Text = "Nama Peminjam"
        ' 
        ' txtNamaPeminjam
        ' 
        txtNamaPeminjam.Location = New Point(12, 244)
        txtNamaPeminjam.Name = "txtNamaPeminjam"
        txtNamaPeminjam.Size = New Size(140, 23)
        txtNamaPeminjam.TabIndex = 8
        ' 
        ' lblLamaPinjam
        ' 
        lblLamaPinjam.AutoSize = True
        lblLamaPinjam.Location = New Point(12, 280)
        lblLamaPinjam.Name = "lblLamaPinjam"
        lblLamaPinjam.Size = New Size(107, 15)
        lblLamaPinjam.TabIndex = 9
        lblLamaPinjam.Text = "Lama Pinjam (hari)"
        ' 
        ' txtLamaPinjam
        ' 
        txtLamaPinjam.Location = New Point(12, 298)
        txtLamaPinjam.Name = "txtLamaPinjam"
        txtLamaPinjam.Size = New Size(140, 23)
        txtLamaPinjam.TabIndex = 10
        ' 
        ' btnPinjam
        ' 
        btnPinjam.Location = New Point(12, 357)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(108, 31)
        btnPinjam.TabIndex = 11
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = True
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.CausesValidation = False
        btnBersihkan.Location = New Point(147, 357)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(109, 31)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' btnEkspor
        ' 
        btnEkspor.Location = New Point(284, 357)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(109, 31)
        btnEkspor.TabIndex = 13
        btnEkspor.Text = "Ekspor CSV"
        btnEkspor.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(12, 422)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(124, 15)
        lblStatus.TabIndex = 14
        lblStatus.Text = "Jumlah peminjaman 0"
        ' 
        ' lstPeminjaman
        ' 
        lstPeminjaman.FormattingEnabled = True
        lstPeminjaman.Location = New Point(258, 20)
        lstPeminjaman.Name = "lstPeminjaman"
        lstPeminjaman.Size = New Size(454, 319)
        lstPeminjaman.TabIndex = 15
        ' 
        ' frmPeminjaman
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.PapayaWhip
        ClientSize = New Size(744, 481)
        Controls.Add(lstPeminjaman)
        Controls.Add(lblStatus)
        Controls.Add(btnEkspor)
        Controls.Add(btnBersihkan)
        Controls.Add(btnPinjam)
        Controls.Add(txtLamaPinjam)
        Controls.Add(lblLamaPinjam)
        Controls.Add(txtNamaPeminjam)
        Controls.Add(lblNamaPeminjam)
        Controls.Add(cboKategori)
        Controls.Add(lblKategori)
        Controls.Add(txtJudul)
        Controls.Add(lblJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        Name = "frmPeminjaman"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Peminjaman Buku"
        CType(errPinjam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents errPinjam As ErrorProvider
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents lblNamaPeminjam As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents btnPinjam As Button
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents btnEkspor As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents lblStatus As Label

End Class
