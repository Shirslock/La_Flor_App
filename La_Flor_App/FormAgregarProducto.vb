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

        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para agregar el nuevo producto a la base de datos
        Dim query As String = "INSERT INTO productos (nombre, descripcion, categoria, precio, stock) VALUES (@Nombre, @Descripcion, @Categoria, @Precio, @Stock)"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                ' Agregar los parámetros de la consulta
                command.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre)
                command.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion)
                command.Parameters.AddWithValue("@Categoria", nuevoProducto.Categoria)
                command.Parameters.AddWithValue("@Precio", nuevoProducto.Precio)
                command.Parameters.AddWithValue("@Stock", nuevoProducto.Stock)

                ' Ejecutar la consulta para agregar el nuevo producto
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    ' El nuevo producto se agregó con éxito a la base de datos
                    MessageBox.Show("El nuevo producto se agregó correctamente a la base de datos.")
                    DialogResult = DialogResult.OK
                    Close() ' Cierra el formulario "FormAgregarProducto"
                Else
                    ' No se pudo agregar el nuevo producto a la base de datos
                    MessageBox.Show("No se pudo agregar el nuevo producto a la base de datos.")
                End If
            End Using
        End Using

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class