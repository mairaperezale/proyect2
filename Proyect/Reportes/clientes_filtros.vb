Imports Entidad
Imports Negocio
Public Class clientes_filtros

    Dim objProvincia As New NProvincia
    Private Sub btnListarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListarTodos.Click
        todosloClientes.ShowDialog()

        'frmlistar_clientes.listar_clientesTableAdapter.Fill(frmlistar_clientes.mundocelDataSet5.listar_clientes)
        'frmlistar_clientes.ReportViewer1.Visible = True
    End Sub

    Private Sub btnFiltrarPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarPro.Click

        Filtro_clientes.lblProvincia.Visible = True
        Filtro_clientes.CmbProvincia.Visible = True
        Filtro_clientes.btnBuscar.Visible = True

        Filtro_clientes.lblEstado.Visible = False
        Filtro_clientes.cmbestado.Visible = False
        Filtro_clientes.btnEstado.Visible = False

        Filtro_clientes.ShowDialog()

    End Sub

    Private Sub btnfiltroporESt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfiltroporESt.Click
        Filtro_clientes.lblProvincia.Visible = False
        Filtro_clientes.CmbProvincia.Visible = False
        Filtro_clientes.btnBuscar.Visible = False

        Filtro_clientes.lblEstado.Visible = True
        Filtro_clientes.cmbestado.Visible = True
        Filtro_clientes.btnEstado.Visible = True
        Filtro_clientes.ShowDialog()

    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub clientes_filtros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class