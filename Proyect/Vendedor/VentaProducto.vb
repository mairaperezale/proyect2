Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports Entidad
Imports Negocio
Public Class VentaProducto

    Dim objFactura As New NFactura

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub


    Private Sub frmVentaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        txtTotal.Text = "0"
        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        'txtHora.Text = Now.ToString("HH:mm:ss")

        txtFecha.Enabled = False
        txtFactura.Enabled = False

        dvgDatos2.DataSource = objFactura.obtenerId()

        For Each Row As DataGridViewRow In (dvgDatos2.Rows)

            txtFactura.Text = Row.Cells(0).Value.ToString
            'dvgDatos2.DataSource = objFactura.obtenerId()
            'txtFactura.Text = Me.dvgDatos2.Rows(0).Cells(0).Value
        Next

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        frmBuscarClientes.ShowDialog()
    End Sub

    Private Sub btnAgregarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCliente.Click
        frmAltaCliente.ShowDialog()
    End Sub

    Private Sub btnBuscarPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPro.Click
        frmBuscarProducto.ShowDialog()
    End Sub

    Private Sub btnAgregarPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPro.Click

        Dim filas As Integer = dvgDatos.Rows.Count
        If Trim(txtCodigoPro.Text) = "" Or Trim(txtNombrePro.Text) = " " Or Trim(txtPrecioPro.Text) = "" Or Trim(txtMarcaPro.Text) = "" Or Trim(txtCantidadPro.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        ElseIf txtCantidadPro.Text > txtstock.Text Then
            MsgBox("No se cuenta con stock suficiente", MsgBoxStyle.Critical, "Advertencia")
            txtCantidadPro.Focus()
        ElseIf filas = 1 Then
            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            If Me.dvgDatos.Rows(Fila).Cells(0).Value = txtCodigoPro.Text Then
                Dim lx As Integer = Me.dvgDatos.Rows(Fila).Cells(5).Value
                Dim prueba As Integer = txtCantidadPro.Text
                Dim tre As Integer = Me.dvgDatos.Rows(Fila).Cells(4).Value + prueba

                Me.dvgDatos.Rows(Fila).Cells(4).Value = tre
                Dim ex As Integer

                ex = txtCantidadPro.Text * txtPrecioPro.Text
                Me.dvgDatos.Rows(Fila).Cells(5).Value = ex + lx
                txtTotal.Text = ex + lx
                txtCodigoPro.Clear()
                txtNombrePro.Clear()
                txtPrecioPro.Clear()
                txtMarcaPro.Clear()
                txtCantidadPro.Clear()
                btnEliminarPro.Enabled = True
                btnEditarPro.Enabled = True
            Else
                Dim asx As Integer
                asx = txtCantidadPro.Text * txtPrecioPro.Text
                txtTotal.Text = txtTotal.Text + asx
                dvgDatos.Rows.Add(txtCodigoPro.Text, txtMarcaPro.Text, txtNombrePro.Text, txtPrecioPro.Text, txtCantidadPro.Text, asx)
                MsgBox("El Producto se Agrego al Carrito Correctamente", MsgBoxStyle.Information, "Agregar al Carrito")
                txtCodigoPro.Clear()
                txtNombrePro.Clear()
                txtPrecioPro.Clear()
                txtMarcaPro.Clear()
                txtCantidadPro.Clear()
                btnEliminarPro.Enabled = True
                btnEditarPro.Enabled = True
            End If
        Else
            Dim asx As Integer
            asx = txtCantidadPro.Text * txtPrecioPro.Text
            txtTotal.Text = txtTotal.Text + asx
            dvgDatos.Rows.Add(txtCodigoPro.Text, txtMarcaPro.Text, txtNombrePro.Text, txtPrecioPro.Text, txtCantidadPro.Text, asx)
            MsgBox("El Producto se Agrego al Carrito Correctamente", MsgBoxStyle.Information, "Agregar al Carrito")
            txtCodigoPro.Clear()
            txtNombrePro.Clear()
            txtPrecioPro.Clear()
            txtMarcaPro.Clear()
            txtCantidadPro.Clear()
            btnEliminarPro.Enabled = True
            btnEditarPro.Enabled = True
        End If
    End Sub

    Private Sub btnEditarPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarPro.Click
        If Trim(txtCantidadPro.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        Else
            Dim asx As Integer
            Dim filas As Integer = dvgDatos.Rows.Count
            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            txtTotal.Text = txtTotal.Text - Me.dvgDatos.Rows(Fila).Cells(5).Value
            Me.dvgDatos.Rows(Fila).Cells(0).Value = txtCodigoPro.Text
            Me.dvgDatos.Rows(Fila).Cells(1).Value = txtMarcaPro.Text
            Me.dvgDatos.Rows(Fila).Cells(2).Value = txtNombrePro.Text
            Me.dvgDatos.Rows(Fila).Cells(3).Value = txtPrecioPro.Text
            Me.dvgDatos.Rows(Fila).Cells(4).Value = txtCantidadPro.Text
            asx = txtPrecioPro.Text * txtCantidadPro.Text
            Me.dvgDatos.Rows(Fila).Cells(5).Value = asx
            If filas = 1 Then
                txtTotal.Text = asx
                MsgBox("El Producto se Actualizo Correctamente", MsgBoxStyle.Information, "Actualizar Carrito")
                txtCodigoPro.Clear()
                txtNombrePro.Clear()
                txtPrecioPro.Clear()
                txtMarcaPro.Clear()
                txtCantidadPro.Clear()
            Else
                txtTotal.Text = txtTotal.Text + Me.dvgDatos.Rows(Fila).Cells(5).Value
                MsgBox("El Producto se Actualizo Correctamente", MsgBoxStyle.Information, "Actualizar Carrito")
                txtCodigoPro.Clear()
                txtNombrePro.Clear()
                txtPrecioPro.Clear()
                txtMarcaPro.Clear()
                txtCantidadPro.Clear()
            End If
        End If
    End Sub

    Private Sub clickEnCodigo(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellDoubleClick
        If dvgDatos.CurrentCell.ColumnIndex = 0 Then
            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            txtCodigoPro.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
            txtMarcaPro.Text = Me.dvgDatos.Rows(Fila).Cells(1).Value
            txtNombrePro.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
            txtPrecioPro.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
            txtCantidadPro.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
            txtCantidadPro.Enabled = True
            btnEditarPro.Enabled = True
        End If
    End Sub

    Private Sub btnEliminarPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarPro.Click
        Dim filas As Integer = dvgDatos.Rows.Count
        If filas > 0 Then
            Dim ask As MsgBoxResult
            ask = MsgBox("Está seguro que desea Eliminarlo del Carrito", MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, "Confirmar Eliminación")
            If ask = MsgBoxResult.Yes Then
                Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
                Dim asx As Integer
                asx = Me.dvgDatos.Rows(Fila).Cells(5).Value
                txtTotal.Text = txtTotal.Text - asx
                dvgDatos.Rows.Remove(Me.dvgDatos.CurrentRow)
                MsgBox("El Producto se Eliminó Correctamente del Carrito: ", MsgBoxStyle.Information, "Eliminar")
            End If
        Else
            MsgBox("No hay Registros para Eliminar", MsgBoxStyle.Critical, "Advertencia"
                   )
        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblHora.Text = Date.Now.ToLongTimeString
    End Sub

    'Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVendedor.Click
    '    frmBuscarEmpleado.btnEditar.Visible = False
    '    frmBuscarEmpleado.btnEliminar.Visible = False
    '    frmBuscarEmpleado.ShowDialog()
    'End Sub

    Private Sub btnComprar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprar.Click

        If Trim(txtDniCliente.Text) = "" Or Trim(txtDniVendedor.Text) = "" Or Trim(txtNombreVen.Text) = "" Or Trim(txtNomCliente.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
            txtCantidadPro.Focus()
        Else

            Dim objEnFactura As EFactura = New EFactura
            Dim objNeFactura As NFactura = New NFactura

            Dim lista As New List(Of EFactura)
            objEnFactura.IdFactura = txtFactura.Text
            objEnFactura.Fecha = txtFecha.Text
            objEnFactura.Dni_Cliente = txtDniCliente.Text
            objEnFactura.Total = txtTotal.Text
            objEnFactura.Dni_Empleado = txtDniVendedor.Text
            lista.Add(objEnFactura)

            'With objEnFactura
            '    .IdFactura = txtFactura.Text
            '    .Fecha = CDate(txtFecha.Text)
            '    .Dni_Cliente = CInt(txtDniCliente.Text)
            '    .Dni_Empleado = CInt(txtDniVendedor.Text)
            '    .Total = CDec(txtTotal.Text)
            '    '.Estado = 1
            'End With
            Dim listaDetalle As New List(Of EDetalle)
            For i As Integer = 0 To dvgDatos.Rows.Count - 1
                Dim item As EDetalle = New EDetalle
                item.FacturaId = CInt(txtFactura.Text)
                item.CodigoProducto = Me.dvgDatos.Rows(i).Cells(0).Value
                item.Nombre = Me.dvgDatos.Rows(i).Cells(1).Value & " " & Me.dvgDatos.Rows(i).Cells(2).Value
                item.Cantidad = Me.dvgDatos.Rows(i).Cells(4).Value
                item.Precio = Me.dvgDatos.Rows(i).Cells(3).Value
                item.Subtotal = Me.dvgDatos.Rows(i).Cells(5).Value
                listaDetalle.Add(item)
            Next
            objNeFactura.guardarFactura(objEnFactura, listaDetalle)
            'MsgBox("ok")
            'Close()
            'Dim factura = New frmFactura
            'frmFactura.lblFac = txtFactura.Text
            'frmFactura.ShowDialog()
            'limpiarCampos()


            Dim fila As Integer = dvgDatos.Rows.Count
            If fila >= 1 Then
                frmFactura.lblCliente.Text = txtNomCliente.Text
                frmFactura.lblDNI.Text = txtDniCliente.Text
                frmFactura.lblVen.Text = txtNombreVen.Text
                frmFactura.lblFac.Text = txtFactura.Text
                frmFactura.lblRes.Text = txtTotal.Text
                frmFactura.lblTipo.Text = "Efectivo"


                'Dim aux As String
                'For i = 0 To fila

                '    frmFactura.dvgDatos.Rows(0).Cells(0).Value = "               " & Me.dvgDatos.Rows(i).Cells(0).Value
                '    frmFactura.dvgDatos.Rows(0).Cells(1).Value = Me.dvgDatos.Rows(i).Cells(4).Value
                '    aux = Me.dvgDatos.Rows(0).Cells(1).Value & " " & Me.dvgDatos.Rows(i).Cells(2).Value
                '    frmFactura.dvgDatos.Rows(0).Cells(2).Value = aux
                '    frmFactura.dvgDatos.Rows(0).Cells(3).Value = Me.dvgDatos.Rows(i).Cells(3).Value
                '    frmFactura.dvgDatos.Rows(0).Cells(4).Value = Me.dvgDatos.Rows(i).Cells(5).Value
                '    frmFactura.lblRes.Text = Me.dvgDatos.Rows(0).Cells(5).Value

                'Next
                frmFactura.ShowDialog()
                Close()
            Else
                MsgBox("Debe Cargar Un Producto al Carrito", MsgBoxStyle.Critical, "Advertencia")
            End If
        End If
    End Sub

    Private Sub txtCodigoPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoPro.KeyPress
        Validacion.SoloNumeros(txtCodigoPro.Text, e)
    End Sub

    Private Sub txtMarcaPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarcaPro.KeyPress
        Validacion.SoloLetras(txtMarcaPro.Text, e)
    End Sub

    Private Sub txtPrecioPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioPro.KeyPress
        Validacion.SoloNumeros(txtPrecioPro.Text, e)
    End Sub

    Private Sub txtCantidadPro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidadPro.KeyPress
        Validacion.SoloNumeros(txtCantidadPro.Text, e)
    End Sub

    Private Sub txtDniCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDniCliente.KeyPress
        If txtDniCliente.TextLength < 8 Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Formato Incorrecto de DNI", MsgBoxStyle.Information, "Advertencia")
        End If
    End Sub

    Private Sub txtDniVendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDniVendedor.KeyPress
        If txtDniVendedor.TextLength < 8 Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Formato Incorrecto de DNI", MsgBoxStyle.Information, "Advertencia")
        End If
    End Sub

    Private Sub txtNomCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomCliente.KeyPress
        Validacion.SoloLetras(txtNomCliente.Text, e)
    End Sub

    Private Sub txtNombreVen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreVen.KeyPress
        Validacion.SoloLetras(txtNombreVen.Text, e)
    End Sub

    Private Sub txtNomCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomCliente.TextChanged
        txtNomCliente.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNomCliente.Text)
        txtNomCliente.SelectionStart = txtNomCliente.Text.Length
    End Sub

    Private Sub txtNombreVen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreVen.TextChanged
        txtNombreVen.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombreVen.Text)
        txtNombreVen.SelectionStart = txtNombreVen.Text.Length
    End Sub

    Private Sub btnBuscarVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarVendedor.Click
        frmBuscarEmpleado.ShowDialog()
    End Sub

End Class