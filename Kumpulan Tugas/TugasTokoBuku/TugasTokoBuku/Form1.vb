Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Umum")
        cmbStatus.Items.Add("Mahasiswa")
        cmbStatus.Items.Add("Dosen/Guru")
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim belanja As Double

        If Not Double.TryParse(txtTotalBelanja.Text, belanja) OrElse belanja <= 0 Then
            MessageBox.Show("Masukkan nominal total belanja yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalBelanja.Focus()
            Return
        End If

        Dim diskonBelanjaPersen As Double = 0.0
        If belanja >= 200000 Then
            diskonBelanjaPersen = 0.15
        ElseIf belanja >= 100000 Then
            diskonBelanjaPersen = 0.1
        Else
            diskonBelanjaPersen = 0.0
        End If

        Dim diskonStatusPersen As Double = 0.0
        If cmbStatus.SelectedIndex = 1 OrElse cmbStatus.SelectedIndex = 2 Then
            diskonStatusPersen = 0.05
        End If

        Dim diskonMetodePersen As Double = 0.0
        If chkMetodeQRIS.Checked Then
            diskonMetodePersen = 0.02
        End If

        Dim potonganBelanja As Double = belanja * diskonBelanjaPersen
        Dim potonganStatus As Double = belanja * diskonStatusPersen
        Dim potonganMetode As Double = belanja * diskonMetodePersen

        Dim totalSemuaDiskon As Double = potonganBelanja + potonganStatus + potonganMetode
        Dim totalAkhir As Double = belanja - totalSemuaDiskon

        lblSubtotal.Text = "Rp " & belanja.ToString("N0")
        lblDiskon.Text = "Rp " & totalSemuaDiskon.ToString("N0")
        lblTotalBayar.Text = "Rp " & totalAkhir.ToString("N0")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNama.Clear()
        txtTotalBelanja.Clear()
        cmbStatus.SelectedIndex = 0
        chkMetodeQRIS.Checked = False
        lblSubtotal.Text = "Rp 0"
        lblDiskon.Text = "Rp 0"
        lblTotalBayar.Text = "Rp 0"
        txtNama.Focus()
    End Sub

End Class