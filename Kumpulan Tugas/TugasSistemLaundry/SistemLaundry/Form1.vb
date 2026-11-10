Public Class Form1

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim berat As Double
        Dim tarifPerKg As Double = 8000

        If Not Double.TryParse(txtBerat.Text, berat) OrElse berat <= 0 Then
            MessageBox.Show("Masukkan jumlah berat cucian yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBerat.Focus()
            Return
        End If

        Dim subtotal As Double = berat * tarifPerKg

        Dim diskonBeratPersen As Double = 0.0
        If berat >= 7 Then
            diskonBeratPersen = 0.15
        ElseIf berat >= 5 Then
            diskonBeratPersen = 0.1
        Else
            diskonBeratPersen = 0.0
        End If

        Dim diskonMemberPersen As Double = 0.0
        If chkMember.Checked Then
            diskonMemberPersen = 0.05
        End If

        Dim totalPersenDiskon As Double = diskonBeratPersen + diskonMemberPersen
        Dim totalPotongan As Double = subtotal * totalPersenDiskon
        Dim totalBayar As Double = subtotal - totalPotongan

        lblSubtotal.Text = "Rp " & subtotal.ToString("N0")
        lblDiskon.Text = "Rp " & totalPotongan.ToString("N0")
        lblTotalBayar.Text = "Rp " & totalBayar.ToString("N0")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNama.Clear()
        txtBerat.Clear()
        chkMember.Checked = False
        lblSubtotal.Text = "Rp 0"
        lblDiskon.Text = "Rp 0"
        lblTotalBayar.Text = "Rp 0"
        txtNama.Focus()
    End Sub

End Class