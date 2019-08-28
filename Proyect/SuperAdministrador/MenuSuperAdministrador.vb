Imports System.Data.SqlClient
Imports System.Configuration
Public Class MenuSuperAdministrador
    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)
    Private Sub btnAltaUsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaUsu.Click
        frmAltaUsuario.ShowDialog()

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim ask As MsgBoxResult

        ask = MsgBox("¿Está seguro  que desea salir?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Cerrar Sesion")
        If MsgBoxResult.Yes = ask Then
            Close()

        End If
    End Sub

    Private Sub btnBackap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackap.Click
        Dim nombre_backup As String = (Date.Today.Day.ToString & "-" & Date.Today.Month.ToString & "-" & Date.Today.Year.ToString & "-" & Date.Now.Hour.ToString & "-" & Date.Now.Minute.ToString & "-" & Date.Now.Second.ToString & "MI BACKUP")
        Dim comando As String = "BACKUP DATABASE [mundocel] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\Backup\" & nombre_backup & "' WITH NOFORMAT, NOINIT,  NAME = N'mundocel-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        Dim cmd As SqlCommand = New SqlCommand(comando, miconexion)
        Try
            miconexion.Open()
            cmd.ExecuteNonQuery()
            MsgBox("El Backup se realizo correctamente")
        Catch ex As Exception
            MsgBox("Intente mas Tarde")
        Finally
            miconexion.Close()
            miconexion.Dispose()

        End Try
    End Sub

    Private Sub lblTitulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitulo.Click

    End Sub

    Private Sub frmMenuSuperAdministrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class