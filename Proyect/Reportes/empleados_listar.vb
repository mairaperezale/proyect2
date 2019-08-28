Public Class empleados_listar

    Private Sub btnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodos.Click
        frmlistado_empleados.ShowDialog()
    End Sub

    Private Sub btnfiltrarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfiltrarFecha.Click

        filtro_empleadosFecha.lblDesde.Visible = True
        filtro_empleadosFecha.lblHasta.Visible = True
        filtro_empleadosFecha.DateTimePicker1.Visible = True
        filtro_empleadosFecha.DateTimePicker2.Visible = True
        filtro_empleadosFecha.btnFecha.Visible = True
        filtro_empleadosFecha.lblEstado.Visible = False
        filtro_empleadosFecha.cmbestado.Visible = False
        filtro_empleadosFecha.btnEstado.Visible = False
        filtro_empleadosFecha.ShowDialog()
    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub btnfiltroporESt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfiltroporESt.Click
        filtro_empleadosFecha.lblDesde.Visible = False
        filtro_empleadosFecha.lblHasta.Visible = False
        filtro_empleadosFecha.DateTimePicker1.Visible = False
        filtro_empleadosFecha.DateTimePicker2.Visible = False
        filtro_empleadosFecha.btnFecha.Visible = False
        filtro_empleadosFecha.lblEstado.Visible = True
        filtro_empleadosFecha.cmbestado.Visible = True
        filtro_empleadosFecha.btnEstado.Visible = True
        filtro_empleadosFecha.ShowDialog()
    End Sub

    Private Sub empleados_listar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class