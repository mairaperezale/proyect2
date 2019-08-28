Public Class SubMenuReportes

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        clientes_filtros.ShowDialog()
    End Sub

    Private Sub btnPorCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorCliente.Click
        empleados_listar.ShowDialog()
    End Sub

    Private Sub btnProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProducto.Click
        productos_listar.ShowDialog()
    End Sub

    Private Sub btnVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVentas.Click
        ventas.ShowDialog()
    End Sub

    Private Sub frmSubMenuReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class