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
        Label1 = New Label()
        Label2 = New Label()
        txtBatas = New TextBox()
        btnTampilkan = New Button()
        lstHasil = New ListBox()
        Label3 = New Label()
        btnHitungBulan = New Button()
        lstSimulasi = New ListBox()
        lblHasil = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(254, 17)
        Label1.TabIndex = 0
        Label1.Text = "CONTOH 1 - FOR NEXT (DERET GANJIL)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 15)
        Label2.TabIndex = 1
        Label2.Text = "Masukkan Batas Angka"
        ' 
        ' txtBatas
        ' 
        txtBatas.Location = New Point(147, 50)
        txtBatas.Name = "txtBatas"
        txtBatas.Size = New Size(179, 23)
        txtBatas.TabIndex = 2
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(147, 79)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(106, 23)
        btnTampilkan.TabIndex = 3
        btnTampilkan.Text = "Tampilkan Deret"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' lstHasil
        ' 
        lstHasil.FormattingEnabled = True
        lstHasil.Location = New Point(147, 108)
        lstHasil.Name = "lstHasil"
        lstHasil.Size = New Size(179, 124)
        lstHasil.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(412, 25)
        Label3.Name = "Label3"
        Label3.Size = New Size(301, 17)
        Label3.TabIndex = 5
        Label3.Text = "CONTOH 2 - WHILE DO (SIMULASI TABUNGAN)"
        ' 
        ' btnHitungBulan
        ' 
        btnHitungBulan.Location = New Point(461, 53)
        btnHitungBulan.Name = "btnHitungBulan"
        btnHitungBulan.Size = New Size(203, 23)
        btnHitungBulan.TabIndex = 6
        btnHitungBulan.Text = "Mulai Simulasi Target Rp 400.000"
        btnHitungBulan.UseVisualStyleBackColor = True
        ' 
        ' lstSimulasi
        ' 
        lstSimulasi.FormattingEnabled = True
        lstSimulasi.Location = New Point(431, 108)
        lstSimulasi.Name = "lstSimulasi"
        lstSimulasi.Size = New Size(257, 124)
        lstSimulasi.TabIndex = 7
        ' 
        ' lblHasil
        ' 
        lblHasil.AutoSize = True
        lblHasil.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHasil.Location = New Point(431, 244)
        lblHasil.Name = "lblHasil"
        lblHasil.Size = New Size(206, 17)
        lblHasil.TabIndex = 8
        lblHasil.Text = "Status target akan tampil di sini"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(734, 481)
        Controls.Add(lblHasil)
        Controls.Add(lstSimulasi)
        Controls.Add(btnHitungBulan)
        Controls.Add(Label3)
        Controls.Add(lstHasil)
        Controls.Add(btnTampilkan)
        Controls.Add(txtBatas)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Simulasi Perulangan For Next dan While Do"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBatas As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lstHasil As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnHitungBulan As Button
    Friend WithEvents lstSimulasi As ListBox
    Friend WithEvents lblHasil As Label

End Class
