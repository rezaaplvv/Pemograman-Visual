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
        lblJudul = New Label()
        lblName = New Label()
        txtNama = New TextBox()
        lblTotal = New Label()
        txtTotalBelanja = New TextBox()
        Label1 = New Label()
        cmbStatus = New ComboBox()
        chkMetodeQRIS = New CheckBox()
        btnHitung = New Button()
        btnReset = New Button()
        Label2 = New Label()
        lblSubtotal = New Label()
        Label3 = New Label()
        lblDiskon = New Label()
        Label4 = New Label()
        lblTotalBayar = New Label()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudul.Location = New Point(195, 61)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(149, 21)
        lblJudul.TabIndex = 0
        lblJudul.Text = "KASIR TOKO BUKU"
        lblJudul.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(41, 119)
        lblName.Name = "lblName"
        lblName.Size = New Size(91, 15)
        lblName.TabIndex = 1
        lblName.Text = "Nama Pembeli :"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(228, 116)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(100, 23)
        txtNama.TabIndex = 2
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(41, 151)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(105, 15)
        lblTotal.TabIndex = 3
        lblTotal.Text = "Total Belanja (Rp) :"
        ' 
        ' txtTotalBelanja
        ' 
        txtTotalBelanja.Location = New Point(228, 151)
        txtTotalBelanja.Name = "txtTotalBelanja"
        txtTotalBelanja.Size = New Size(100, 23)
        txtTotalBelanja.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(41, 193)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 15)
        Label1.TabIndex = 5
        Label1.Text = "Status Pembeli :"
        ' 
        ' cmbStatus
        ' 
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.FormattingEnabled = True
        cmbStatus.Items.AddRange(New Object() {"Umum", "Mahasiswa", "Dosen/Guru"})
        cmbStatus.Location = New Point(228, 190)
        cmbStatus.Name = "cmbStatus"
        cmbStatus.Size = New Size(121, 23)
        cmbStatus.TabIndex = 6
        ' 
        ' chkMetodeQRIS
        ' 
        chkMetodeQRIS.AutoSize = True
        chkMetodeQRIS.Location = New Point(228, 219)
        chkMetodeQRIS.Name = "chkMetodeQRIS"
        chkMetodeQRIS.Size = New Size(201, 19)
        chkMetodeQRIS.TabIndex = 7
        chkMetodeQRIS.Text = "Bayar via QRIS (Diskon Ekstra 2%)"
        chkMetodeQRIS.UseVisualStyleBackColor = True
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(329, 256)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(100, 23)
        btnHitung.TabIndex = 8
        btnHitung.Text = "Hitung Total"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(228, 256)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(75, 23)
        btnReset.TabIndex = 9
        btnReset.Text = "Reset Form"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(41, 328)
        Label2.Name = "Label2"
        Label2.Size = New Size(98, 15)
        Label2.TabIndex = 10
        Label2.Text = "Subtotal Belanja :"
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(228, 328)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(30, 15)
        lblSubtotal.TabIndex = 11
        lblSubtotal.Text = "Rp 0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(41, 357)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 15)
        Label3.TabIndex = 12
        Label3.Text = "Total Diskon :"
        ' 
        ' lblDiskon
        ' 
        lblDiskon.AutoSize = True
        lblDiskon.Location = New Point(228, 357)
        lblDiskon.Name = "lblDiskon"
        lblDiskon.Size = New Size(30, 15)
        lblDiskon.TabIndex = 13
        lblDiskon.Text = "Rp 0"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(41, 383)
        Label4.Name = "Label4"
        Label4.Size = New Size(122, 17)
        Label4.TabIndex = 14
        Label4.Text = "Total Akhir Bayar :"
        ' 
        ' lblTotalBayar
        ' 
        lblTotalBayar.AutoSize = True
        lblTotalBayar.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalBayar.Location = New Point(228, 377)
        lblTotalBayar.Name = "lblTotalBayar"
        lblTotalBayar.Size = New Size(52, 25)
        lblTotalBayar.TabIndex = 15
        lblTotalBayar.Text = "Rp 0"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(540, 450)
        Controls.Add(lblTotalBayar)
        Controls.Add(Label4)
        Controls.Add(lblDiskon)
        Controls.Add(Label3)
        Controls.Add(lblSubtotal)
        Controls.Add(Label2)
        Controls.Add(btnReset)
        Controls.Add(btnHitung)
        Controls.Add(chkMetodeQRIS)
        Controls.Add(cmbStatus)
        Controls.Add(Label1)
        Controls.Add(txtTotalBelanja)
        Controls.Add(lblTotal)
        Controls.Add(txtNama)
        Controls.Add(lblName)
        Controls.Add(lblJudul)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sistem Kasir Toko Buku"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtTotalBelanja As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents chkMetodeQRIS As CheckBox
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblDiskon As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalBayar As Label

End Class
