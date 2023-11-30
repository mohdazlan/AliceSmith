Imports System.Data.SqlClient

Public Class frmAddStaff
    Dim theMain As frmMain
    Private Sub btnAddStudent_Click(sender As Object, e As EventArgs) Handles btnAddStudent.Click
        Dim rowsAffected As Integer
        Dim connectionString As String = "Server=localhost;Database=spmp;User Id=sa;Password=p@ssw0rd;"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim query As String = "INSERT INTO login (name,phone,email,address,postalZip,iban) VALUES (@nama,@telefon,@alamat,@pos,@IBAN)"
        connection.Open()
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@nama", txtName.Text)
        command.Parameters.AddWithValue("@telefon", txtPhone.Text)
        command.Parameters.AddWithValue("@alamat", txtAddress.Text)
        command.Parameters.AddWithValue("@pos", txtPostal.Text)
        command.Parameters.AddWithValue("@IBAN", txtIBAN.Text)
        rowsAffected = command.ExecuteNonQuery()
        MsgBox(CStr(rowsAffected) + "  Data berjaya dimasukkan")
        theMain.BindGrid()

    End Sub
End Class