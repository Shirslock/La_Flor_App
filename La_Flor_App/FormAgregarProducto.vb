Imports System.Windows.Forms
Imports System.Data.SqlClient



Public Class FormAgregarProducto
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim nuevoProducto As New Producto()
        nuevoProducto.Nombre = txtNombre.Text
        nuevoProducto.Descripcion = txtDescripcion.Text
        nuevoProducto.Categoria = txtCategoria.Text
        nuevoProducto.Precio = Decimal.Parse(txtPrecio.Text)
        nuevoProducto.Stock = Integer.Parse(txtStock.Text)

        ' Cadena de conexion a la base de datos
        Dim rutaDeConexion As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para agregar el nuevo producto a la base de datos
        Dim consulta As String = "INSERT INTO productos (nombre, descripcion, categoria, precio, stock) VALUES (@Nombre, @Descripcion, @Categoria, @Precio, @Stock)"

        Using conexion As New SqlConnection(rutaDeConexion)
            conexion.Open()

            Using comando As New SqlCommand(consulta, conexion)
                ' Agregar los parámetros de la consulta
                comando.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre)
                comando.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion)
                comando.Parameters.AddWithValue("@Categoria", nuevoProducto.Categoria)
                comando.Parameters.AddWithValue("@Precio", nuevoProducto.Precio)
                comando.Parameters.AddWithValue("@Stock", nuevoProducto.Stock)

                ' Ejecutar la consulta para agregar el nuevo producto
                Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                If filasAfectadas > 0 Then
                    ' Agrega producto a la base de datos
                    MessageBox.Show("Producto agregado correctamente!")
                    DialogResult = DialogResult.OK
                    Close() ' Cierra el formulario "FormAgregarProducto".
                Else

                    MessageBox.Show("No se pudo agregar el nuevo producto a la base de datos.")
                End If
            End Using
        End Using

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class