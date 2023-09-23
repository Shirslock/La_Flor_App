Public Class FormPrincipal

    'Abrir el Form para ver los productos 
    Private Sub VerProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerProductosToolStripMenuItem.Click

        Dim formVerProducto As New FormVerProductos
        formVerProducto.Show()

    End Sub



End Class
