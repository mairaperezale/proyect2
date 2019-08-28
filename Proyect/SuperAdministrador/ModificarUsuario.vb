Imports Entidad
Imports Negocio
Imports System.Windows.Forms
Public Class ModificarUsuario
    Dim objEmpleado As New NEmpleado



    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub frmModificarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsuario.Focus()
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

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Validacion.SoloLetras(txtNombre.Text, e)
    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        Validacion.SoloLetras(txtDireccion.Text, e)
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Validacion.SoloNumeros(txtTelefono.Text, e)
    End Sub

    Private Sub txtSueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldo.KeyPress
        Validacion.SoloNumeros(txtSueldo.Text, e)
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

    'Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtFechaAlta.Text) = "" Or Trim(txtSueldo.Text) = "" Or Trim(txtTelefono.Text) = "" Then
    '        MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "error"
    '               )
    '        'ElseIf validarEmail(txtEmail.Text) = False Then
    '        '    MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
    '        '    txtEmail.Focus()
    '        '    txtEmail.BackColor = Color.Coral
    '    Else
    '        Dim eempleado As EEmpleado = New EEmpleado
    '        With eempleado
    '            '.Dni = txtDNI.Text
    '            '.Nombre = txtNombre.Text
    '            '.Apellido = txtApellido.Text
    '            '.Telefono = txtTelefono.Text
    '            '.Direccion = txtDireccion.Text
    '            '.Email = txtEmail.Text
    '            '.FechaAlta = txtFechaAlta.Text
    '            '.Sueldo = txtSueldo.Text
    '            '.Estado = 1
    '            .Usuario = txtUsuario.Text
    '            .Contraseña = txtContraseña.Text
    '            .Rol = cmbRol.SelectedValue
    '        End With

    '        If objEmpleado.ActualizarUsuario(eempleado) Then
    '            MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '            txtEmail.BackColor = Color.White
    '            txtDNI.Clear()
    '            txtNombre.Clear()
    '            txtApellido.Clear()
    '            txtDireccion.Clear()
    '            txtEmail.Clear()
    '            txtTelefono.Clear()
    '            txtFechaAlta.Clear()
    '            txtSueldo.Clear()

    '            'btnModificar.Enabled = False
    '            'btnActualizar.Enabled = False
    '            'btnAgregarEmpleado.Enabled = True
    '            'txtDNI.Focus()
    '        Else
    '            MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        End If
    '    End If

    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
    '    'If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtFechaAlta.Text) = "" Or Trim(txtSueldo.Text) = "" Or Trim(txtTelefono.Text) = "" Then
    '    '    MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "error"
    '    '           )
    '    '    'ElseIf validarEmail(txtEmail.Text) = False Then
    '    '    '    MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
    '    '    '    txtEmail.Focus()
    '    '    '    txtEmail.BackColor = Color.Coral
    '    'Else
    '    Dim eempleado As EEmpleado = New EEmpleado
    '    With eempleado
    '        '.Dni = txtDNI.Text
    '        '.Nombre = txtNombre.Text
    '        '.Apellido = txtApellido.Text
    '        '.Telefono = txtTelefono.Text
    '        '.Direccion = txtDireccion.Text
    '        '.Email = txtEmail.Text
    '        '.FechaAlta = txtFechaAlta.Text
    '        '.Sueldo = txtSueldo.Text
    '        '.Estado = 1
    '        .Usuario = txtUsuario.Text
    '        .Contraseña = txtContraseña.Text
    '        .Rol = cmbRol.SelectedValue
    '    End With
    '    Close()
    '    objEmpleado.ActualizarUsuario(eempleado)

    '    'MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


    '    'txtEmail.BackColor = Color.White
    '    'txtDNI.Clear()
    '    'txtNombre.Clear()
    '    'txtApellido.Clear()
    '    'txtDireccion.Clear()
    '    'txtEmail.Clear()
    '    'txtTelefono.Clear()
    '    'txtFechaAlta.Clear()
    '    'txtSueldo.Clear()

    '    'btnModificar.Enabled = False
    '    'btnActualizar.Enabled = False
    '    'btnAgregarEmpleado.Enabled = True
    '    'txtDNI.Focus()
    '    'Else
    '    'MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    'End If

    '    MsgBox("wtf?")
    'End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If Trim(txtUsuario.Text) = "" Or Trim(txtContraseña.Text) = "" Or Trim(cmbRol.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "error"
                   )
        ElseIf txtContraseña.TextLength < 8 Then
            MsgBox("La Contraseña no cumple con el formato especificado (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtContraseña.Focus()
            txtContraseña.BackColor = Color.Coral
        Else
            Dim eempleado As EEmpleado = New EEmpleado

            Dim lista As New List(Of EEmpleado)
            eempleado.Dni = txtDNI.Text
            eempleado.Usuario = txtUsuario.Text
            eempleado.Contraseña = txtContraseña.Text
            eempleado.Rol = cmbRol.SelectedItem

            lista.Add(eempleado)


            'With eempleado
            '    .Dni = txtDNI.Text
            '    '.Nombre = txtNombre.Text
            '    '.Apellido = txtApellido.Text
            '    '.Telefono = txtTelefono.Text
            '    '.Direccion = txtDireccion.Text
            '    '.Email = txtEmail.Text
            '    '.FechaAlta = txtFechaAlta.Text
            '    '.Sueldo = txtSueldo.Text
            '    '.Estado = 1
            '    .Usuario = txtUsuario.Text
            '    .Contraseña = txtContraseña.Text
            '    .Rol = cmbRol.SelectedItem
            'End With
            If objEmpleado.ActualizarUsuario(eempleado.Dni, eempleado.Usuario, eempleado.Contraseña, eempleado.Rol) Then

                'MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)


                'txtEmail.BackColor = Color.White
                'txtDNI.Clear()
                'txtNombre.Clear()
                'txtApellido.Clear()
                'txtDireccion.Clear()
                'txtEmail.Clear()
                'txtTelefono.Clear()
                'txtFechaAlta.Clear()
                'txtSueldo.Clear()

                'btnModificar.Enabled = False
                'btnActualizar.Enabled = False
                'btnAgregarEmpleado.Enabled = True
                'txtDNI.Focus()
            Else
                MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
                frmAltaUsuario.cargarDG()
                'MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub

    Private Sub grpModificarUsuario_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpModificarUsuario.Enter

    End Sub

End Class