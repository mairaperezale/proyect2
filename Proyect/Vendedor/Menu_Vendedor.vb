Public Class Menu_Vendedor

    Private Sub cmdBuscraProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscraProducto.Click
        frmBuscarProducto.ShowDialog()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click
        Dim ask As MsgBoxResult

        ask = MsgBox("¿Está seguro  que desea salir?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Cerrar Sesion")
        If MsgBoxResult.Yes = ask Then
            Close()

        End If
    End Sub

    Private Sub cmdAltaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAltaCliente.Click
        frmAltaCliente.btnBorrar.Visible = False
        frmAltaCliente.ShowDialog()

    End Sub

    Private Sub cmdBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarCliente.Click
        frmBuscarClientes.ShowDialog()
    End Sub

    Private Sub cmdVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVentas.Click
        frmVentaProducto.Show()
    End Sub

    Private Sub frmMenu_Vendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class