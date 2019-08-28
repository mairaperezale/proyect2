Imports Entidad
Imports Negocio
Public Class BuscarEmpleado
    Dim objEmpleado As New NEmpleado
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
            MsgBox("Formato Incorrecto de DNI", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    'Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
    '    Dim filas As Integer = dvgDatos.Rows.Count
    '    If filas > 0 Then
    '        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
    '        frmModificarEmpleado.txtDNI.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
    '        frmModificarEmpleado.txtDNI.Enabled = True
    '        frmModificarEmpleado.txtNombre.Text = Me.dvgDatos.Rows(Fila).Cells(1).Value
    '        frmModificarEmpleado.txtNombre.Enabled = True
    '        frmModificarEmpleado.txtApellido.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
    '        frmModificarEmpleado.txtApellido.Enabled = True
    '        frmModificarEmpleado.txtDireccion.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
    '        frmModificarEmpleado.txtDireccion.Enabled = True
    '        frmModificarEmpleado.txtTelefono.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
    '        frmModificarEmpleado.txtTelefono.Enabled = True
    '        frmModificarEmpleado.CmbCargo.Text = Me.dvgDatos.Rows(Fila).Cells(6).Value
    '        frmModificarEmpleado.CmbCargo.Enabled = True
    '        frmModificarEmpleado.txtEmail.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
    '        frmModificarEmpleado.txtEmail.Enabled = True
    '        frmModificarEmpleado.txtSueldo.Text = Me.dvgDatos.Rows(Fila).Cells(7).Value
    '        frmModificarEmpleado.txtSueldo.Enabled = True
    '        frmModificarEmpleado.txtFechaAlta.Text = Me.dvgDatos.Rows(Fila).Cells(8).Value
    '        frmModificarEmpleado.btnModificar.Enabled = True
    '        frmModificarEmpleado.Show()
    '    Else
    '        MsgBox("No hay Registros para Editar", MsgBoxStyle.Critical, "Advertencia"
    '                  )
    '    End If
    'End Sub


    Private Sub frmBuscarEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        cargarDG()

    End Sub
    Sub cargarDG()
        dvgDatos.DataSource = objEmpleado.getBuscarEmpleado()
        Me.dvgDatos.Columns("estado").Visible = False
        Me.dvgDatos.Columns("usuario").Visible = False
        Me.dvgDatos.Columns("contraseña").Visible = False
        Me.dvgDatos.Columns("rol").Visible = False
    End Sub

    'Private Sub ClickBoton(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellClick
    '    If dvgDatos.CurrentCell.ColumnIndex = 0 Then
    '        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
    '        Dim NomyApe As String
    '        frmVentaProducto.txtDniVendedor.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
    '        frmVentaProducto.txtDniVendedor.Enabled = False
    '        NomyApe = Me.dvgDatos.Rows(Fila).Cells(2).Value & " " & Me.dvgDatos.Rows(Fila).Cells(1).Value
    '        frmVentaProducto.txtNombreVen.Text = NomyApe
    '        frmVentaProducto.txtNombreVen.Enabled = False
    '        Close()
    '    End If
    'End Sub

    'Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    '    Dim filas As Integer = dvgDatos.Rows.Count
    '    If filas > 0 Then
    '        Dim ask As MsgBoxResult
    '        ask = MsgBox("Está seguro que desea Eliminar el Registro", MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, "Confirmar Eliminación")
    '        If ask = MsgBoxResult.Yes Then
    '            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
    '            dvgDatos.Rows.Remove(Me.dvgDatos.CurrentRow)
    '            MsgBox("El Registro se Eliminó Correctamente: ", MsgBoxStyle.Information, "Eliminar")
    '        End If
    '    Else
    '        MsgBox("No hay Registros para Eliminar", MsgBoxStyle.Critical, "Advertencia"
    '               )
    '    End If
    'End Sub

    Private Sub txtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
        Validacion.SoloLetras(txtApellido.Text, e)
    End Sub

    Private Sub txtApellido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido.TextChanged
        txtApellido.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text)
        txtApellido.SelectionStart = txtApellido.Text.Length
        dvgDatos.DataSource = objEmpleado.getEmpleadoPorApellido(txtApellido.Text)
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
            dvgDatos.DataSource = objEmpleado.getEmpleadoDNI(txtDni.Text)
            txtDni.Clear()
        End If
    End Sub

    Private Sub btnBuscarApellido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub ClickReporte(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellDoubleClick
    '    If dvgDatos.CurrentCell.ColumnIndex = 1 Then
    '        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
    '        Dim NomyApe As String
    '        frmReportesPorVendedor.txtDni.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
    '        NomyApe = Me.dvgDatos.Rows(Fila).Cells(2).Value & " " & Me.dvgDatos.Rows(Fila).Cells(1).Value
    '        frmReportesPorVendedor.txtNombre.Text = NomyApe
    '        Close()
    '    End If
    'End Sub

    Private Sub cargarTextbox(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellContentDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index

        frmVentaProducto.txtDniVendedor.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
        Dim aux As String = Me.dvgDatos.Rows(Fila).Cells(1).Value & " " & Me.dvgDatos.Rows(Fila).Cells(2).Value
        frmVentaProducto.txtNombreVen.Text = aux
        Close()
    End Sub

    Private Sub ventas_Emp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index

        ventas_filtros.txtDniEmp.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
        Close()
    End Sub

End Class