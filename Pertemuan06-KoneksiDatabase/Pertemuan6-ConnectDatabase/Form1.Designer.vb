<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        btnTampilkan = New Button()
        dgvMahasiswa = New DataGridView()
        Me.btnTambah = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Me.txtNama = New TextBox()
        Me.txtNIM = New TextBox()
        txtJurusan = New TextBox()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(94, 203)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(75, 23)
        btnTampilkan.TabIndex = 0
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(12, 34)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.Size = New Size(240, 150)
        dgvMahasiswa.TabIndex = 1
        ' 
        ' btnTambah
        ' 
        Me.btnTambah.Location = New Point(433, 203)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New Size(75, 23)
        Me.btnTambah.TabIndex = 2
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(353, 80)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 3
        Label1.Text = "Nama"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(353, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(30, 15)
        Label2.TabIndex = 4
        Label2.Text = "NIM"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(353, 157)
        Label3.Name = "Label3"
        Label3.Size = New Size(47, 15)
        Label3.TabIndex = 5
        Label3.Text = "Jurusan"
        ' 
        ' txtNama
        ' 
        Me.txtNama.Location = New Point(419, 77)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New Size(124, 23)
        Me.txtNama.TabIndex = 6
        ' 
        ' txtNIM
        ' 
        Me.txtNIM.Location = New Point(419, 112)
        Me.txtNIM.Name = "txtNIM"
        Me.txtNIM.Size = New Size(124, 23)
        Me.txtNIM.TabIndex = 7
        ' 
        ' txtJurusan
        ' 
        txtJurusan.Location = New Point(419, 154)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(124, 23)
        txtJurusan.TabIndex = 8
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(600, 450)
        Controls.Add(txtJurusan)
        Controls.Add(Me.txtNIM)
        Controls.Add(Me.txtNama)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Me.btnTambah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTampilkan)
        Name = "Form1"
        Text = "Form1"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampilkan As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents btnTambah As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents txtJurusan As TextBox

End Class
