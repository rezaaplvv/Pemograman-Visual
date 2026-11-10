Option Strict On

Public Module ModValidasi

    Public Function Kosong(teks As String) As Boolean
        Return String.IsNullOrWhiteSpace(teks)
    End Function

    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If String.IsNullOrEmpty(teks) OrElse teks.Length <> panjang Then
            Return False
        End If

        For Each c As Char In teks
            If Not Char.IsDigit(c) Then
                Return False
            End If
        Next

        Return True
    End Function

End Module