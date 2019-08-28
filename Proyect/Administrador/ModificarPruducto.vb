Public Class ModificarPruducto

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        cmbMarca.ResetText()
        cmbMarca.SelectedText = ""
        Close()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Validacion.SoloNumeros(txtCodigo.Text, e)
    End Sub

    Private Sub txtStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStock.KeyPress
        Validacion.SoloNumeros(txtStock.Text, e)
    End Sub

    Private Sub txtPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecio.KeyPress
        Validacion.SoloNumeros(txtPrecio.Text, e)
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If Trim(txtCodigo.Text) = "" Or Trim(txtNombre.Text) = "" Or Trim(txtModelo.Text) = "" Or Trim(txtDescripcion.Text) = "" Or Trim(txtPrecio.Text) = "" Or Trim(cmbMarca.Text) = "" Then
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical, "Advertencia"
                   )
        ElseIf txtCodigo.TextLength < 4 Or txtCodigo.TextLength > 4 Then
            MsgBox("El Codigo del Producto no cumple con el formato especificado (4 digitos)", MsgBoxStyle.Exclamation, "Advertencia")
            txtCodigo.Focus()
        Else
            MsgBox("El Producto: " & txtNombre.Text & " se Modifico Correctamente", MsgBoxStyle.Information, "Modificar Producto")
            Dim Fila As Integer = frmBuscarProducto.dvgDatos.CurrentRow.Index
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(0).Value = txtCodigo.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(1).Value = txtNombre.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(2).Value = cmbMarca.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(3).Value = txtModelo.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(4).Value = txtDescripcion.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(5).Value = txtPrecio.Text
            frmBuscarProducto.dvgDatos.Rows(Fila).Cells(6).Value = txtStock.Text

            Close()

            txtCodigo.Clear()
            txtNombre.Clear()
            txtModelo.Clear()
            txtDescripcion.Clear()
            txtPrecio.Clear()
            cmbMarca.Text = ""
            txtStock.Clear()

            txtCodigo.Enabled = False
            txtDescripcion.Enabled = False
            txtModelo.Enabled = False
            txtNombre.Enabled = False
            cmbMarca.Enabled = False
            txtPrecio.Enabled = False
            txtStock.Enabled = False
            btnModificar.Enabled = False
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBuscarProducto.ShowDialog()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text)
        txtNombre.SelectionStart = txtNombre.Text.Length
    End Sub

    Private Sub txtModelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModelo.TextChanged
        txtModelo.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtModelo.Text)
        txtModelo.SelectionStart = txtModelo.Text.Length
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        txtDescripcion.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtDescripcion.Text)
        txtDescripcion.SelectionStart = txtDescripcion.Text.Length
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub frmModificarProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCodigo.Focus()
    End Sub
End Class