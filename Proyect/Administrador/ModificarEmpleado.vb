Public Class ModificarEmpleado

    'Private Sub frmModificarEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Call Limpiar(Me)
    '    dvgDatos.Rows.Add("37909567", "Juan Alberto", "Lopez", "Madariaga 1290", "4456789", "juan@gmail.com", "Cajero", "7.899", "14/09/2017", "", "")
    'End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtFechaAlta.Text) = "" Or Trim(txtSueldo.Text) = "" Or Trim(txtTelefono.Text) = "" Or Trim(CmbCargo.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        ElseIf validarEmail(txtEmail.Text) = False Then
            MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
            txtEmail.Focus()
        ElseIf txtDNI.TextLength < 8 Then
            MsgBox("El DNI no cumple con el formato especificado (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtDNI.Focus()
        Else
            MsgBox("El Empleado: " & txtApellido.Text & " " & txtNombre.Text & " se Modifico Correctamente", MsgBoxStyle.Information, "Modificar Empleado")
            Dim Fila As Integer = frmBuscarEmpleado.dvgDatos.CurrentRow.Index
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(0).Value = txtDNI.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(2).Value = txtApellido.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(1).Value = txtNombre.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(3).Value = txtDireccion.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(5).Value = txtEmail.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(4).Value = txtTelefono.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(6).Value = CmbCargo.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(7).Value = txtSueldo.Text
            frmBuscarEmpleado.dvgDatos.Rows(Fila).Cells(8).Value = txtFechaAlta.Text


            txtDNI.Clear()
            txtNombre.Clear()
            txtApellido.Clear()
            txtDireccion.Clear()
            txtEmail.Clear()
            CmbCargo.ResetText()
            CmbCargo.SelectedText = ""
            txtSueldo.Clear()
            txtFechaAlta.Clear()
            txtTelefono.Clear()
            Close()


            txtApellido.Enabled = False
            txtDNI.Enabled = False
            txtEmail.Enabled = False
            txtDireccion.Enabled = False
            txtNombre.Enabled = False
            CmbCargo.Enabled = False
            txtTelefono.Enabled = False
            txtSueldo.Enabled = False
            txtFechaAlta.Enabled = False

            btnModificar.Enabled = False
        End If

    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub txtDNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
        If txtDNI.TextLength < 8 Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Formato Incorrecto de DNI", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        Validacion.SoloLetras(txtDireccion.Text, e)
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Validacion.SoloLetras(txtNombre.Text, e)
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Validacion.SoloNumeros(txtTelefono.Text, e)
    End Sub

    Private Sub txtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text)
        txtNombre.SelectionStart = txtNombre.Text.Length
    End Sub

    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
        txtDireccion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDireccion.Text)
        txtDireccion.SelectionStart = txtDireccion.Text.Length
    End Sub

    Private Sub txtSueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldo.KeyPress
        Validacion.SoloNumeros(txtSueldo.Text, e)
    End Sub

    Private Sub frmModificarEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDNI.Focus()
    End Sub
End Class