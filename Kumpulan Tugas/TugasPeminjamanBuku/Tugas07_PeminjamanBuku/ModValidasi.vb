Imports System

Module ModValidasi

    ' Fungsi bantuan untuk memeriksa apakah seluruh karakter berupa angka dengan panjang tertentu
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If String.IsNullOrEmpty(teks) OrElse teks.Length <> panjang Then
            Return False
        End If

        For Each ch As Char In teks
            If Not Char.IsDigit(ch) Then
                Return False
            End If
        Next

        Return True
    End Function

    ' Fungsi tantangan nilai plus untuk memeriksa validitas kode buku berformat BK diikuti 4 digit angka
    Public Function KodeBukuValid(kode As String) As Boolean
        If String.IsNullOrWhiteSpace(kode) Then
            Return False
        End If

        Dim teksBersih As String = kode.Trim().ToUpper()

        If teksBersih.Length <> 6 Then
            Return False
        End If

        If Not teksBersih.StartsWith("BK") Then
            Return False
        End If

        Dim empatDigit As String = teksBersih.Substring(2)
        Return SemuaDigit(empatDigit, 4)
    End Function

End Module