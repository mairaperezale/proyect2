Public Class Menu_Administrador

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim ask As MsgBoxResult

        ask = MsgBox("¿Está seguro  que desea salir?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Cerrar Sesion")
        If MsgBoxResult.Yes = ask Then
            Close()

        End If
    End Sub

    Private Sub btnAltaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaProducto.Click
        frmAltaProducto.ShowDialog()
    End Sub


    Private Sub btnAltaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaCliente.Click
        frmAltaCliente.btnBorrar.Visible = True
        frmAltaCliente.ShowDialog()

    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        frmBuscarClientes.ShowDialog()

    End Sub

    Private Sub btnBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProducto.Click
        frmBuscarProducto.ShowDialog()
    End Sub

    'Private Sub btnModificarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    frmModificarCliente.ShowDialog()
    'End Sub

    'Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    frmModificarProducto.ShowDialog()
    'End Sub

    Private Sub btnAltaEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaEmpleado.Click
        frmAlta_Empleado.ShowDialog()
    End Sub

    'Private Sub btnModificarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    frmModificarEmpleado.ShowDialog()
    'End Sub

    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click
        frmBuscarEmpleado.ShowDialog()
    End Sub

    Private Sub frmMenu_Administrador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub txtReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReportes.Click
    '    frmSubMenuReportes.ShowDialog()
    'End Sub

    Private Sub txtReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReportes.Click
        frmSubMenuReportes.ShowDialog()
    End Sub
End Class