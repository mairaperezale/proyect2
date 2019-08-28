Imports Entidad
Imports Negocio
Public Class BuscarProducto
    Dim objProducto As New NProducto
    Dim objMarca As New NMarca

    Private Sub btnAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        CmbMarca.ResetText()
        CmbMarca.SelectedText = ""
        Close()

    End Sub

    Private Sub frmBuscarProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Limpiar(Me)
        cargarDG()
        cargarCBO()
        CmbMarca.Focus()

    End Sub

    Sub cargarDG()
        dvgDatos.DataSource = objProducto.getBuscarProducto()
        For Each Row As DataGridViewRow In (dvgDatos.Rows)

            If Row.Cells("stock").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Yellow
            End If

        Next
    End Sub

    Sub cargarCBO()

        With CmbMarca
            .DataSource = objMarca.getMarca()
            .DisplayMember = "descripcion"
            .ValueMember = "marca"
            .SelectedIndex = -1
        End With

    End Sub


    Private Sub btnBuscarporMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarporMarca.Click
        If CmbMarca.Text = "" Then
            MsgBox("Debe completar el campo", MsgBoxStyle.Critical, "Advertencia"
                   )
            CmbMarca.Focus()
        Else
            Dim id As Integer = CmbMarca.SelectedIndex

            dvgDatos.DataSource = objProducto.getProductoId(id + 1)
            For Each Row As DataGridViewRow In (dvgDatos.Rows)

                If Row.Cells("stock").Value = 0 Then
                    Row.DefaultCellStyle.BackColor = Color.Yellow
                End If

            Next
            CmbMarca.Text = ""
        End If
    End Sub


    'Private Sub btnBuscarporDes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarporDes.Click
    '    If txtDescripcion.Text = "" Then
    '        MsgBox("Debe completar el campo", MsgBoxStyle.Critical, "Advertencia"
    '               )
    '        txtDescripcion.Focus()
    '    Else
    '        txtDescripcion.Clear()
    '    End If
    'End Sub

    'Private Sub btnBuscarporDes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarporDes.Click
    '    If txtDescripcion.Text = "" Then
    '        MsgBox("Debe completar el campo", MsgBoxStyle.Critical, "Advertencia"
    '               )
    '        txtDescripcion.Focus()
    '    Else

    '        dvgDatos.DataSource = objProducto.getProductoDescripcion(txtDescripcion.Text)
    '    End If
    'End Sub


    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        dvgDatos.DataSource = objProducto.getProductoDescripcion(txtDescripcion.Text)
        For Each Row As DataGridViewRow In (dvgDatos.Rows)

            If Row.Cells("stock").Value = 0 Then
                Row.DefaultCellStyle.BackColor = Color.Yellow
            End If

        Next
    End Sub

    Private Sub cargarTextbox(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvgDatos.CellContentDoubleClick
        Dim Fila As Integer = Me.dvgDatos.CurrentRow.Index

        Dim stock As Integer = Me.dvgDatos.Rows(Fila).Cells(3).Value

        If stock = 0 Then

            MsgBox("El producto seleccionado NO posee Stock", MsgBoxStyle.Exclamation, "Advertencia")
        Else
            frmVentaProducto.txtCodigoPro.Text = Me.dvgDatos.Rows(Fila).Cells(0).Value
            frmVentaProducto.txtMarcaPro.Text = Me.dvgDatos.Rows(Fila).Cells(5).Value
            frmVentaProducto.txtNombrePro.Text = Me.dvgDatos.Rows(Fila).Cells(1).Value
            frmVentaProducto.txtPrecioPro.Text = Me.dvgDatos.Rows(Fila).Cells(2).Value
            frmVentaProducto.txtstock.Text = Me.dvgDatos.Rows(Fila).Cells(3).Value
            Close()
        End If
    End Sub

End Class