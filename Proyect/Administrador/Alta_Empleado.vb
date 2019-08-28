Imports Entidad
Imports Negocio
Imports System.Windows.Forms
Public Class Alta_Empleado

    Dim registro As Integer
    Dim objEmpleado As New NEmpleado

    Private Sub txtSueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSueldo.KeyPress
        Validacion.SoloNumeros(txtSueldo.Text, e)
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

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Validacion.SoloNumeros(txtTelefono.Text, e)
    End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Validacion.SoloLetras(txtNombre.Text, e)
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text)
        txtNombre.SelectionStart = txtNombre.Text.Length
    End Sub

    Private Sub txtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
    End Sub

    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
        txtDireccion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDireccion.Text)
        txtDireccion.SelectionStart = txtDireccion.Text.Length
    End Sub

    Private Sub btnAgregarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarEmpleado.Click
        If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtFechaAlta.Text) = "" Or Trim(txtSueldo.Text) = "" Or Trim(txtTelefono.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "error"
                   )
        ElseIf validarEmail(txtEmail.Text) = False Then
            MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
            txtEmail.Focus()
            txtEmail.BackColor = Color.Coral
        ElseIf txtDNI.TextLength < 8 Then
            MsgBox("El DNI no cumple con el formato especificado (8 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtDNI.Focus()
            txtDNI.BackColor = Color.Coral
        ElseIf objEmpleado.getEmpleadoVerificarDNI(txtDNI.Text) Then
            Dim eempleado As EEmpleado = New EEmpleado
            With eempleado
                .Dni = CInt(txtDNI.Text)
                .Nombre = txtNombre.Text
                .Apellido = txtApellido.Text
                .Telefono = CInt(txtTelefono.Text)
                .Direccion = txtDireccion.Text
                .Email = txtEmail.Text
                .FechaAlta = txtFechaAlta.Text
                .Sueldo = txtSueldo.Text
                .Estado = 1
                .Usuario = ""
                .Contraseña = ""
                .Rol = ""
            End With

            If objEmpleado.guardarEmpleado(eempleado) Then
                MessageBox.Show("Empleado Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarDGTodos()
                txtDNI.BackColor = Color.White
                txtEmail.BackColor = Color.White
                txtDNI.Clear()
                txtNombre.Clear()
                txtApellido.Clear()
                txtDireccion.Clear()
                txtEmail.Clear()
                txtTelefono.Clear()
                txtSueldo.Clear()
            Else
                MessageBox.Show("Error al agregar el Empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDNI.Focus()
                txtDNI.BackColor = Color.Coral
            End If
        End If

    End Sub


    Private Sub frmAlta_Empleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtFechaAlta.Text = DateTime.Now.ToString("dd/MM/yyyy")
        txtFechaAlta.Enabled = False

        cargarDGTodos()
        txtDNI.Focus()
    End Sub

    Sub cargarDG()

        dvgDatos.DataSource = objEmpleado.getEmpleado

    End Sub

    Sub cargarDGTodos()

        dvgDatos.DataSource = objEmpleado.getEmpleado

        For Each Row As DataGridViewRow In (dvgDatos.Rows)

            If Row.Cells("estado").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Red
            End If

        Next

        Me.dvgDatos.Columns("estado").Visible = False
        Me.dvgDatos.Columns("usuario").Visible = False
        Me.dvgDatos.Columns("contraseña").Visible = False
        Me.dvgDatos.Columns("rol").Visible = False

        dvgDatos.ClearSelection()

    End Sub
    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Call Limpiar(Me)
        Close()
    End Sub

    Private Sub Click_Boton(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellClick
        btnModificar.Enabled = True
        btnActualizar.Enabled = True
        btnBorrar.Enabled = True
        btnAgregarEmpleado.Enabled = False

    End Sub


    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        registro = 0
        registro = Me.dvgDatos.CurrentRow.Index
        Dim estado As Integer = Me.dvgDatos.Rows(registro).Cells(8).Value

        If estado = 0 Then

            MsgBox("El producto ya se encuentra dado de baja")

            txtDNI.Enabled = True
            txtDNI.Focus()
            txtDNI.Clear()
            txtNombre.Clear()
            txtApellido.Clear()
            txtDireccion.Clear()
            txtEmail.Clear()
            txtTelefono.Clear()
            txtFechaAlta.Clear()
            txtSueldo.Clear()
            cmbEstado.SelectedIndex = -1

            btnModificar.Enabled = False
            btnActualizar.Enabled = False
            btnBorrar.Enabled = False
            btnAgregarEmpleado.Enabled = True

            Exit Sub
        Else

            txtDNI.Enabled = False
            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            txtDNI.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
            txtNombre.Text = dvgDatos.Rows(Fila).Cells(1).Value
            txtApellido.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
            txtTelefono.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
            txtDireccion.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
            txtEmail.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
            txtFechaAlta.Text = Me.dvgDatos.Rows(Fila).Cells(6).Value
            txtSueldo.Text = Me.dvgDatos.Rows(Fila).Cells(7).Value


        End If

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If Trim(txtApellido.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDireccion.Text) = "" Or Trim(txtDNI.Text) = "" Or Trim(txtEmail.Text) = "" Or Trim(txtFechaAlta.Text) = "" Or Trim(txtSueldo.Text) = "" Or Trim(txtTelefono.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "error"
                   )
        ElseIf validarEmail(txtEmail.Text) = False Then
            MsgBox("El EMAIL no cumple con el formato especificado", MsgBoxStyle.Exclamation, "Advertencia")
            txtEmail.Focus()
            txtEmail.BackColor = Color.Coral
        Else
            Dim eempleado As EEmpleado = New EEmpleado
            With eempleado
                .Dni = txtDNI.Text
                .Nombre = txtNombre.Text
                .Apellido = txtApellido.Text
                .Telefono = txtTelefono.Text
                .Direccion = txtDireccion.Text
                .Email = txtEmail.Text
                .FechaAlta = txtFechaAlta.Text
                .Sueldo = txtSueldo.Text
                .Estado = 1
            End With

            If objEmpleado.ActualizarEmpleado(eempleado) Then
                MessageBox.Show("Cliente Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                cargarDGTodos()
                txtEmail.BackColor = Color.White
                txtDNI.Clear()
                txtNombre.Clear()
                txtApellido.Clear()
                txtDireccion.Clear()
                txtEmail.Clear()
                txtTelefono.Clear()
                txtFechaAlta.Clear()
                txtSueldo.Clear()

                btnModificar.Enabled = False
                btnActualizar.Enabled = False
                btnAgregarEmpleado.Enabled = True
                txtDNI.Focus()
            Else
                MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If

    End Sub

    Private Sub cargarDatos()

        registro = Me.dvgDatos.CurrentRow.Index

        Dim dni As String = Me.dvgDatos.Rows(registro).Cells(0).Value
        Dim nombre As String = Me.dvgDatos.Rows(registro).Cells(1).Value
        Dim apellido As String = Me.dvgDatos.Rows(registro).Cells(2).Value
        Dim telefono As Integer = Me.dvgDatos.Rows(registro).Cells(3).Value
        Dim direccion As String = Me.dvgDatos.Rows(registro).Cells(4).Value
        Dim email As String = Me.dvgDatos.Rows(registro).Cells(5).Value
        Dim fechaAlta As Date = Me.dvgDatos.Rows(registro).Cells(6).Value
        Dim sueldo As Integer = Me.dvgDatos.Rows(registro).Cells(7).Value



        Dim estado As Integer = Me.dvgDatos.Rows(registro).Cells(8).Value

        txtDNI.Text = dni
        txtNombre.Text = nombre
        txtApellido.Text = apellido
        txtTelefono.Text = telefono
        txtDireccion.Text = direccion
        txtEmail.Text = email

        txtFechaAlta.Text = fechaAlta
        txtSueldo.Text = sueldo

        cmbEstado.SelectedIndex = estado


    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        cargarDatos()
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
        Dim estado As Integer = Me.dvgDatos.Rows(Fila).Cells(8).Value

        If estado = 0 Then

            MsgBox("El producto ya se encuentra dado de baja")

            txtDNI.Enabled = True
            txtDNI.Focus()
            txtDNI.Clear()
            txtNombre.Clear()
            txtApellido.Clear()
            txtDireccion.Clear()
            txtEmail.Clear()
            txtTelefono.Clear()
            txtFechaAlta.Clear()
            txtSueldo.Clear()
            cmbEstado.SelectedIndex = -1

            btnModificar.Enabled = False
            btnActualizar.Enabled = False
            btnBorrar.Enabled = False
            btnAgregarEmpleado.Enabled = True
            Exit Sub

        End If


        Dim ask As MsgBoxResult

        ask = MsgBox("Los datos serán eliminados. ¿Está seguro?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Borrar registro")
        If MsgBoxResult.Yes = ask Then
            objEmpleado.borrarEmpleado(txtDNI.Text)
            cargarDGTodos()
            dvgDatos.Rows(registro).Selected = True
        End If
        txtDNI.Enabled = True
        txtDNI.Focus()
        txtDNI.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtDireccion.Clear()
        txtEmail.Clear()
        txtTelefono.Clear()
        txtFechaAlta.Clear()
        txtSueldo.Clear()
        cmbEstado.SelectedIndex = -1

        btnModificar.Enabled = False
        btnActualizar.Enabled = False
        btnBorrar.Enabled = False
        btnAgregarEmpleado.Enabled = True

    End Sub
End Class