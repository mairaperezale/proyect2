Imports Entidad
Imports Negocio
Public Class productos

    Dim objProducto As New NProducto
    Dim objMarca As New NMarca

    Private Sub productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With CmbMarca
            .DataSource = objMarca.getMarca()
            .DisplayMember = "descripcion"
            .ValueMember = "marca"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        filtro_producto.ShowDialog()
        Close()
    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub
End Class