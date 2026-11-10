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
        txtNama = New TextBox()
        Label3 = New Label()
        txtBerat = New TextBox()
        chkMember = New CheckBox()
        btnHitung = New Button()
        btnReset = New Button()
        Label4 = New Label()
        lblSubtotal = New Label()
        Label5 = New Label()
        Label6 = New Label()
        lblDiskon = New Label()
        Label7 = New Label()
        lblTotalBayar = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(180, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(307, 25)
        Label1.TabIndex = 0
        Label1.Text = "KASIR LAUNDRY BERSIH KILOAN"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(56, 101)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 15)
        Label2.TabIndex = 1
        Label2.Text = "Nama Pelanggan :"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(197, 101)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(117, 23)
        txtNama.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(56, 144)
        Label3.Name = "Label3"
        Label3.Size = New Size(109, 15)
        Label3.TabIndex = 3
        Label3.Text = "Berat Pakaian (Kg) :"
        ' 
        ' txtBerat
        ' 
        txtBerat.Location = New Point(197, 141)
        txtBerat.Name = "txtBerat"
        txtBerat.Size = New Size(117, 23)
        txtBerat.TabIndex = 4
        ' 
        ' chkMember
        ' 
        chkMember.AutoSize = True
        chkMember.Location = New Point(197, 179)
        chkMember.Name = "chkMember"
        chkMember.Size = New Size(199, 19)
        chkMember.TabIndex = 5
        chkMember.Text = "Member Langganan (Diskon 5%)"
        chkMember.UseVisualStyleBackColor = True
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(180, 227)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(83, 29)
        btnHitung.TabIndex = 6
        btnHitung.Text = "Hitung Total"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(290, 227)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(95, 29)
        btnReset.TabIndex = 7
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(56, 281)
        Label4.Name = "Label4"
        Label4.Size = New Size(99, 15)
        Label4.TabIndex = 8
        Label4.Text = "Total Biaya Kotor:"
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Location = New Point(180, 281)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(30, 15)
        lblSubtotal.TabIndex = 9
        lblSubtotal.Text = "Rp 0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(56, 314)
        Label5.Name = "Label5"
        Label5.Size = New Size(0, 15)
        Label5.TabIndex = 10
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(62, 314)
        Label6.Name = "Label6"
        Label6.Size = New Size(101, 15)
        Label6.TabIndex = 11
        Label6.Text = "Potongan Diskon:"
        ' 
        ' lblDiskon
        ' 
        lblDiskon.AutoSize = True
        lblDiskon.Location = New Point(180, 314)
        lblDiskon.Name = "lblDiskon"
        lblDiskon.Size = New Size(30, 15)
        lblDiskon.TabIndex = 12
        lblDiskon.Text = "Rp 0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(62, 349)
        Label7.Name = "Label7"
        Label7.Size = New Size(103, 15)
        Label7.TabIndex = 13
        Label7.Text = "Total Bersih Bayar:"
        ' 
        ' lblTotalBayar
        ' 
        lblTotalBayar.AutoSize = True
        lblTotalBayar.Location = New Point(180, 349)
        lblTotalBayar.Name = "lblTotalBayar"
        lblTotalBayar.Size = New Size(30, 15)
        lblTotalBayar.TabIndex = 14
        lblTotalBayar.Text = "Rp 0"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(580, 450)
        Controls.Add(lblTotalBayar)
        Controls.Add(Label7)
        Controls.Add(lblDiskon)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(lblSubtotal)
        Controls.Add(Label4)
        Controls.Add(btnReset)
        Controls.Add(btnHitung)
        Controls.Add(chkMember)
        Controls.Add(txtBerat)
        Controls.Add(Label3)
        Controls.Add(txtNama)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Public WithEvents txtNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBerat As TextBox
    Friend WithEvents chkMember As CheckBox
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDiskon As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalBayar As Label

End Class
