Public Class ModificarCliente

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Validacion.SoloLetras(txtNombre.Text, e)
    End Sub

    Private Sub txtProvincia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Validacion.SoloLetras(cmbProvincia.Text, e)
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
            MsgBox("Formato Incorrecto de DNI (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Validacion.SoloNumeros(txtTelefono.Text, e)
    End Sub



    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(cmbProvincia.Text) = "" Or Trim(txtTelefono.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        ElseIf validarEmail(txtEmail.Text) = False Then
            MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
            txtEmail.Focus()
        ElseIf txtDNI.TextLength < 8 Then
            MsgBox("El DNI no cumple con el formato especificado (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtDNI.Focus()
        Else
            MsgBox("El Cliente: " & txtApellido.Text & " " & txtNombre.Text & " se Modifico Correctamente", MsgBoxStyle.Information, "Modificar Cliente")
            Dim Fila As Integer = frmBuscarClientes.dvgDatos.CurrentRow.Index
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(0).Value = txtDNI.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(2).Value = txtApellido.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(1).Value = txtNombre.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(3).Value = txtDireccion.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(6).Value = txtEmail.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(4).Value = txtTelefono.Text
            frmBuscarClientes.dvgDatos.Rows(Fila).Cells(5).Value = cmbProvincia.Text

            txtDNI.Clear()
            txtNombre.Clear()
            txtApellido.Clear()
            txtDireccion.Clear()
            txtEmail.Clear()
            cmbProvincia.ResetText()
            cmbProvincia.SelectedText = " "
            txtTelefono.Clear()
            Close()



            txtApellido.Enabled = False
            txtDNI.Enabled = False
            txtEmail.Enabled = False
            txtDireccion.Enabled = False
            txtNombre.Enabled = False
            cmbProvincia.Enabled = False
            txtTelefono.Enabled = False
            btnModificar.Enabled = False
        End If


    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBuscarClientes.Show()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBuscarClientes.ShowDialog()
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

    Private Sub frmModificarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDNI.Focus()
    End Sub
End Class