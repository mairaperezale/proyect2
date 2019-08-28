Imports Entidad
Imports Negocio
Public Class Factura
    Dim objFactura As New NFactura

    Private Sub frmFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblFec.Text = DateTime.Now.ToString("dd/MM/yyyy")

        dvgDatos.DataSource = objFactura.cargarfac(lblFac.Text)
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

        MsgBox("La Factura Fue Impresa Corretamente", MsgBoxStyle.Information, "Imprimir Factura")
        Close()
    End Sub


End Class