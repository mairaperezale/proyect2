Imports Entidad
Imports Negocio
Imports System.Windows.Forms
Public Class AltaProducto
    Dim registro As Integer
    Dim objProducto As New NProducto
    Dim objMarca As New NMarca
    Private Sub Alta_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        txtCodigo.Focus()
        cargarDGTodos()
        cargarCBO()
    End Sub

    Sub cargarDGTodos()

        dvgDatos.DataSource = objProducto.getProductoTodos

        For Each Row As DataGridViewRow In (dvgDatos.Rows)

            If Row.Cells("estado").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Red
            ElseIf Row.Cells("stock").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Yellow

            End If

        Next

        Me.dvgDatos.Columns("estado").Visible = False

        dvgDatos.ClearSelection()

    End Sub
    Sub cargarDG()

        dvgDatos.DataSource = objProducto.getProductoTodos

    End Sub

    Sub cargarCBO()

        With cmbmarca
            .DataSource = objMarca.getMarca
            .DisplayMember = "descripcion"
            .ValueMember = "marca"
            .SelectedIndex = -1
        End With

    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Trim(txtCodigo.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDescripcion.Text) = "" Or Trim(txtPrecio.Text) = "" Or Trim(cmbMarca.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        ElseIf txtCodigo.TextLength < 4 Or txtCodigo.TextLength > 4 Then
            MsgBox("El Codigo del Producto no cumple con el formato especificado (4 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtCodigo.Focus()
            txtCodigo.BackColor = Color.Coral
        ElseIf objProducto.getProductoVerificar(txtCodigo.Text) Then

            Dim eproducto As EProductovb = New EProductovb

            With eproducto
                .Codigo = CInt(txtCodigo.Text)
                .Nombre = txtNombre.Text
                .Precio = CInt(txtPrecio.Text)
                .Descripcion = txtDescripcion.Text
                .Stock = CInt(txtStock.Text)
                .Marca = cmbMarca.SelectedValue
                .Estado = 1
            End With

            If objProducto.guardarProducto(eproducto) Then
                MessageBox.Show("Producto Agregado", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cargarDG()
                txtCodigo.BackColor = Color.White
                txtCodigo.Clear()
                txtNombre.Clear()
                txtDescripcion.Clear()
                txtPrecio.Clear()
                txtStock.Clear()
                cmbMarca.ResetText()
                cmbMarca.SelectedText = ""

            Else
                MessageBox.Show("Error al agregar el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Focus()
                txtCodigo.BackColor = Color.Coral
            End If
        End If

    End Sub

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        Close()
    End Sub

    Private Sub lblAltaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAltaProducto.Click

    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If txtCodigo.TextLength < 4 Then
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf (Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Formato Incorrecto de Codigo (4 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub

    Private Sub txtStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStock.KeyPress
        Validacion.SoloNumeros(txtStock.Text, e)
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        Validacion.SoloNumeros(txtPrecio.Text, e)
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text)
        txtNombre.SelectionStart = txtNombre.Text.Length
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        txtDescripcion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDescripcion.Text)
        txtDescripcion.SelectionStart = txtDescripcion.Text.Length
    End Sub

    Private Sub Click_Boton(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellClick
        btnModificar.Enabled = True
        btnActualizar.Enabled = True
        btnAgregar.Enabled = False
        btnBorrar.Enabled = True
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        registro = 0
        registro = Me.dvgDatos.CurrentRow.Index
        Dim estado As Integer = Me.dvgDatos.Rows(registro).Cells(6).Value

        If estado = 0 Then

            MsgBox("El producto ya se encuentra dado de baja")

            txtCodigo.Enabled = True
            txtCodigo.Focus()
            txtCodigo.Clear()
            txtNombre.Clear()
            txtPrecio.Clear()
            txtDescripcion.Clear()
            txtStock.Clear()

            cmbMarca.SelectedIndex = -1
            cmbEstado.SelectedIndex = -1

            btnModificar.Enabled = False
            btnActualizar.Enabled = False
            btnBorrar.Enabled = False
            btnAgregar.Enabled = True

            Exit Sub
        Else


            Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
            txtCodigo.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
            txtNombre.Text = dvgDatos.Rows(Fila).Cells(1).Value
            txtPrecio.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
            txtStock.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
            txtDescripcion.Text = Me.dvgDatos.Rows(Fila).Cells(4).Value
            cmbMarca.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
        End If
    End Sub



    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If Trim(txtCodigo.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtDescripcion.Text) = "" Or Trim(txtPrecio.Text) = "" Or Trim(cmbMarca.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        Else

            Dim eproducto As EProductovb = New EProductovb
            With eproducto
                .Codigo = CInt(txtCodigo.Text)
                .Nombre = txtNombre.Text
                .Precio = CInt(txtPrecio.Text)
                .Descripcion = txtDescripcion.Text
                .Stock = CInt(txtStock.Text)
                .Marca = cmbMarca.SelectedValue
                .Estado = 1
            End With

            If objProducto.ActualizarProducto(eproducto) Then
                MessageBox.Show("Producto Actualizado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

                cargarDGTodos()

                txtCodigo.Clear()
                txtNombre.Clear()
                txtDescripcion.Clear()
                txtPrecio.Clear()
                txtStock.Clear()
                cmbMarca.ResetText()
                cmbMarca.SelectedText = ""

                btnModificar.Enabled = False
                btnActualizar.Enabled = False
                btnBorrar.Enabled = False
                btnAgregar.Enabled = True
                txtCodigo.Focus()
            Else
                MessageBox.Show("Error al actualizar Cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If

    End Sub

    Private Sub cargarDatos()

        registro = Me.dvgDatos.CurrentRow.Index

        Dim codigo As String = Me.dvgDatos.Rows(registro).Cells(0).Value
        Dim nombre As String = Me.dvgDatos.Rows(registro).Cells(1).Value
        Dim precio As String = Me.dvgDatos.Rows(registro).Cells(2).Value
        Dim stock As Integer = Me.dvgDatos.Rows(registro).Cells(3).Value
        Dim descripcion As String = Me.dvgDatos.Rows(registro).Cells(4).Value


        Dim marca As String = Me.dvgDatos.Rows(registro).Cells(5).Value
        Dim estado As Integer = Me.dvgDatos.Rows(registro).Cells(6).Value

        txtCodigo.Text = codigo
        txtNombre.Text = nombre
        txtPrecio.Text = precio
        txtStock.Text = stock
        txtDescripcion.Text = descripcion

        cmbMarca.Text = marca

        cmbEstado.SelectedIndex = estado


    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click

        cargarDatos()
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index
        Dim estado As Integer = Me.dvgDatos.Rows(Fila).Cells(6).Value

        If estado = 0 Then

            MsgBox("El producto ya se encuentra dado de baja")

            txtCodigo.Enabled = True
            txtCodigo.Focus()
            txtCodigo.Clear()
            txtNombre.Clear()
            txtPrecio.Clear()
            txtDescripcion.Clear()
            txtStock.Clear()

            cmbMarca.SelectedIndex = -1
            cmbEstado.SelectedIndex = -1

            btnModificar.Enabled = False
            btnActualizar.Enabled = False
            btnBorrar.Enabled = False
            btnAgregar.Enabled = True
            Exit Sub

        End If


        Dim ask As MsgBoxResult

        ask = MsgBox("Los datos serán eliminados. ¿Está seguro?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Borrar registro")
        If MsgBoxResult.Yes = ask Then
            objProducto.borrarProducto(txtCodigo.Text)
            cargarDGTodos()
            dvgDatos.Rows(registro).Selected = True
        End If
        txtCodigo.Enabled = True
        txtCodigo.Focus()
        txtCodigo.Clear()
        txtNombre.Clear()
        txtPrecio.Clear()
        txtDescripcion.Clear()
        txtStock.Clear()

        cmbMarca.SelectedIndex = -1
        cmbEstado.SelectedIndex = -1

        btnModificar.Enabled = False
        btnActualizar.Enabled = False
        btnBorrar.Enabled = False
        btnAgregar.Enabled = True

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

End Class