Public Class filtro_empleadosfecha

    Private Sub btnFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFecha.Click
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            MsgBox("Incorrecto,Ingrese un fecha en DESDE superior a la fecha HASTA)", MsgBoxStyle.Exclamation, "Advertencia")
        Else

            EMPLEADO_FILTROFECHA.ShowDialog()
            Close()
        End If

    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub btnEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstado.Click
        empleado_estado_fil.ShowDialog()
        Close()
    End Sub

    Private Sub filtro_empleadosFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class