Imports System.Data.SqlClient

Public Class frmLogin
    Public securityLevel As String
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connectionString As String = "Server=localhost;Database=sekolah;User Id=sa;Password=p@ssw0rd;"
        Dim connection As SqlConnection = New SqlConnection(connectionString)
        Dim query As String = "SELECT * FROM login WHERE username=@nama AND password=@katalaluan"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@nama", txtUserName.Text)
        command.Parameters.AddWithValue("@katalaluan", txtPassword.Text)
        connection.Open()
        Try
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                securityLevel = reader("securitylevel")
            End While
            If reader.HasRows Then
                If securityLevel = 1 Then
                    securityLevel = "staff"
                    frmMain.Show()
                Else
                    securityLevel = "admin"
                    frmMain.Show()
                End If
            Else
                MsgBox("UnAuthorized User")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class