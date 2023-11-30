Imports System.Data.SqlClient

Public Class frmMain
    Public Sub BindGrid()
        Dim strConnString As String = "Server=localhost;Database=sekolah;User Id=sa;Password=p@ssw0rd;"
        Using con As SqlConnection = New SqlConnection(strConnString)
            Dim dt As New DataTable
            Using cmd As SqlCommand = New SqlCommand("select * from students", con)
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                da.Fill(dt)
                dgvStudents.DataSource = dt
                dgvStudents.AutoResizeColumns(
             DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
            End Using
        End Using
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BindGrid()
    End Sub
End Class