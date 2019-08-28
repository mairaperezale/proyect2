Imports Entidad
Imports Negocio
Public Class BuscarClientes

    Dim objCliente As New NCliente
    Dim objProvincia As New NProvincia
    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub txtDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDni.KeyPress
        If txtDni.TextLength < 8 Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Formato Incorrecto de DNI (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub

    Private Sub txtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
        dvgDatos.DataSource = objCliente.getClientePorApellido(txtApellido.Text)
    End Sub

    Private Sub frmBuscarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        cargarDG()

    End Sub

    Sub cargarDG()
        dvgDatos.DataSource = objCliente.getBuscarCliente()
    End Sub


    Private Sub btnBuscarDni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDni.Click
        If txtDni.Text = "" Then
            MsgBox("Debe completar el campo", MsgBoxStyle.Critical, "Advertencia"
                   )
            txtDni.Focus()
        ElseIf txtDni.TextLength < 8 Then
            MsgBox("El DNI no cumple con el formato especificado (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtDni.Focus()
        Else
            dvgDatos.DataSource = objCliente.getClienteDNI(txtDni.Text)
            txtDni.Clear()
        End If
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmModificarCliente.Show()
    End Sub



    Private Sub cargarTextbox(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellContentDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index

        frmVentaProducto.txtDniCliente.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
        Dim aux As String = Me.dvgDatos.Rows(Fila).Cells(1).Value & " " & Me.dvgDatos.Rows(Fila).Cells(2).Value
        frmVentaProducto.txtNomCliente.Text = aux
        Close()
    End Sub

    Private Sub CLIENTE_VENTA(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index

        ventas_filtros.txtDniCli.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
        Close()
    End Sub

End Class