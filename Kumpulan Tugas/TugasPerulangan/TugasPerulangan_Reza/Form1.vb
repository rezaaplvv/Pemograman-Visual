Public Class Form1

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        lstHasil.Items.Clear()

        Dim batasAtas As Integer
        If Not Integer.TryParse(txtBatas.Text, batasAtas) OrElse batasAtas < 1 Then
            MessageBox.Show("Masukkan angka bulat positif yang valid")
            txtBatas.Focus()
            Exit Sub
        End If

        For angka = 1 To batasAtas Step 2
            lstHasil.Items.Add("Bilangan ganjil = " & angka)
        Next
    End Sub

    Private Sub btnHitungBulan_Click(sender As Object, e As EventArgs) Handles btnHitungBulan.Click
        lstSimulasi.Items.Clear()

        Dim saldoAwal As Double = 100000
        Dim setoranRutin As Double = 50000
        Dim targetNominal As Double = 400000
        Dim bulan As Integer = 0

        While saldoAwal < targetNominal
            bulan += 1
            saldoAwal += setoranRutin
            lstSimulasi.Items.Add("Bulan ke-" & bulan & " | Saldo = Rp " & saldoAwal.ToString("N0"))
        End While

        lblHasil.Text = "Target Rp 400.000 tercapai pada bulan ke-" & bulan
    End Sub

End Class