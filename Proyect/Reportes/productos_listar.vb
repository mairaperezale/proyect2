Public Class productos_listar

    Private Sub btntodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntodos.Click
        todos_productos.ShowDialog()
    End Sub

    Private Sub btnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarca.Click
        productos.ShowDialog()
    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub


    Private Sub productos_listar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class