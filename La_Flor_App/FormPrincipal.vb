﻿Public Class FormPrincipal

    'Abrir el Form para ver los productos 
    Private Sub VerProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerProductosToolStripMenuItem.Click

        Dim formVerProducto As New FormVerProductos
        formVerProducto.Show()

    End Sub

    Private Sub RegistrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarVentaToolStripMenuItem.Click
        Dim formGestionarVentas As New FormGestionarVentas
        formGestionarVentas.Show()


    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ConsultarPrecioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarPrecioToolStripMenuItem.Click

        Dim formConsultarPrecio As New FormConsultaPrecio
        formConsultarPrecio.Show()

    End Sub
End Class
