Imports Entidad
Imports Negocio
Public Class AltaUsuario

    Dim objEmpleado As New NEmpleado

    'Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
    '    Dim filas As Integer = dvgDatos.Rows.Count
    '    If filas > 0 Then
    '        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
    '        frmModificarUsuario.txtDNI.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
    '        frmModificarUsuario.txtDNI.Enabled = False
    '        frmModificarUsuario.txtNombre.Text = Me.dvgDatos.Rows(Fila).Cells(1).Value
    '        frmModificarUsuario.txtNombre.Enabled = False
    '        frmModificarUsuario.txtApellido.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
    '        frmModificarUsuario.txtApellido.Enabled = False
    '        frmModificarUsuario.txtDireccion.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
    '        frmModificarUsuario.txtDireccion.Enabled = False
    '        frmModificarUsuario.txtTelefono.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
    '        frmModificarUsuario.txtTelefono.Enabled = False
    '        frmModificarUsuario.txtEmail.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
    '        frmModificarUsuario.txtEmail.Enabled = False
    '        frmModificarUsuario.txtSueldo.Text = Me.dvgDatos.Rows(Fila).Cells(7).Value
    '        frmModificarUsuario.txtSueldo.Enabled = False
    '        frmModificarUsuario.txtFechaAlta.Text = Me.dvgDatos.Rows(Fila).Cells(6).Value
    '        frmModificarUsuario.txtFechaAlta.Enabled = False
    '        frmModificarUsuario.txtUsuario.Text = Me.dvgDatos.Rows(Fila).Cells(9).Value
    '        frmModificarUsuario.txtContraseña.Text = Me.dvgDatos.Rows(Fila).Cells(10).Value
    '        frmModificarUsuario.btnModificar.Enabled = True
    '        frmModificarUsuario.cmbRol.Text = Me.dvgDatos.Rows(Fila).Cells(11).Value
    '        frmModificarUsuario.btnModificar.Enabled = True
    '        frmModificarUsuario.Show()
    '    Else
    '        MsgBox("No hay Registros para Editar", MsgBoxStyle.Critical, "Advertencia"
    '                  )
    '    End If
    'End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub frmAltaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        cargarDG()

        txtDni.Focus()
    End Sub
    Sub cargarDG()

        dvgDatos.DataSource = objEmpleado.getEmpleado

        For Each Row As DataGridViewRow In (dvgDatos.Rows)

            If Row.Cells("estado").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Red

            End If
            Me.dvgDatos.Columns("estado").Visible = False
        Next
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
            MsgBox("Formato Incorrecto de DNI", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub


    Private Sub txtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
        dvgDatos.DataSource = objEmpleado.getusuarioPorApellido(txtApellido.Text)
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
            dvgDatos.DataSource = objEmpleado.getusuarioDni(txtDni.Text)
            txtDni.Clear()
        End If
    End Sub


    Private Sub cargarXfa(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellContentDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
        frmModificarUsuario.txtDNI.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
        frmModificarUsuario.txtNombre.Text = dvgDatos.Rows(Fila).Cells(1).Value
        frmModificarUsuario.txtApellido.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
        frmModificarUsuario.txtTelefono.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
        frmModificarUsuario.txtDireccion.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
        frmModificarUsuario.txtEmail.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
        frmModificarUsuario.txtFechaAlta.Text = Me.dvgDatos.Rows(Fila).Cells(6).Value
        frmModificarUsuario.txtSueldo.Text = Me.dvgDatos.Rows(Fila).Cells(7).Value
        frmModificarUsuario.cmbEstado.Text = Me.dvgDatos.Rows(Fila).Cells(8).Value
        frmModificarUsuario.txtUsuario.Text = Me.dvgDatos.Rows(Fila).Cells(9).Value
        frmModificarUsuario.txtContraseña.Text = Me.dvgDatos.Rows(Fila).Cells(10).Value
        frmModificarUsuario.cmbRol.Text = Me.dvgDatos.Rows(Fila).Cells(11).Value
        frmModificarUsuario.ShowDialog()
        'Close()
    End Sub

    'Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim eempleado As EEmpleado = New EEmpleado
    '    With eempleado
    '        .Dni = txtDni.Text
    '        .Nombre = txtNombre.Text
    '        .Apellido = txtApellido.Text
    '        .Telefono = txtTelefono.Text
    '        .Direccion = txtDireccion.Text
    '        .Email = txtEmail.Text
    '        .FechaAlta = txtFechaAlta.Text
    '        .Sueldo = txtSueldo.Text
    '        .Estado = 1
    '        .Usuario = txtUsuario.Text
    '        .Contraseña = txtContraseña.Text
    '        .Rol = cmbRol.SelectedValue
    '    End With

    '    If objEmpleado.ActualizarUsuario(eempleado) Then
    '        MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        cargarDG()
    '        'txtEmail.BackColor = Color.White
    '        'txtDni.Clear()
    '        'txtNombre.Clear()
    '        'txtApellido.Clear()
    '        'txtDireccion.Clear()
    '        'txtEmail.Clear()
    '        'txtTelefono.Clear()
    '        'txtFechaAlta.Clear()
    '        'txtSueldo.Clear()

    '        'btnModificar.Enabled = False
    '        'btnActualizar.Enabled = False
    '        'btnAgregarEmpleado.Enabled = True
    '        'txtDni.Focus()
    '    Else
    '        MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End If


    'End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim filas As Integer = dvgDatos.Rows.Count
        If filas > 0 Then
            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            Dim asx As String
            asx = Me.dvgDatos.Rows(Fila).Cells(10).Value
            If asx = "" Then
                MsgBox("El Registro Seleccionado No es usuario del Sistema", MsgBoxStyle.Critical, "Advertencia")
            Else
                Dim ask As MsgBoxResult
                ask = MsgBox("Está seguro que desea Eliminar el Usuario Seleccionado", MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, "Confirmar Eliminación")
                If ask = MsgBoxResult.Yes Then
                    'Me.dvgDatos.Rows(Fila).Cells(9).Value = ""
                    'Me.dvgDatos.Rows(Fila).Cells(10).Value = ""
                    'Me.dvgDatos.Rows(Fila).Cells(11).Value = ""

                    Dim eempleado As EEmpleado = New EEmpleado

                    Dim lista As New List(Of EEmpleado)
                    eempleado.Dni = Me.dvgDatos.Rows(Fila).Cells(0).Value
                    eempleado.Usuario = ""
                    eempleado.Contraseña = ""
                    eempleado.Rol = ""

                    lista.Add(eempleado)
                    If objEmpleado.ActualizarUsuario(eempleado.Dni, eempleado.Usuario, eempleado.Contraseña, eempleado.Rol) Then

                    Else
                        MsgBox("El Usuario se Eliminó Correctamente: ", MsgBoxStyle.Information, "Eliminar")
                        cargarDG()
                    End If
                End If

            End If
        Else
            MsgBox("No hay Registros para Eliminar", MsgBoxStyle.Critical, "Advertencia"
                   )
        End If
    End Sub

    Private Sub activarboton(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellContentClick
        btnEliminar.Enabled = True
    End Sub
End Class