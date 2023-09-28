
Imports System.Data.SqlClient

Public Class FormConsultaPrecio
    Private Sub btnConsultarPrecio_Click(sender As Object, e As EventArgs) Handles btnConsultarPrecio.Click


        ' Ruta de conexion a la base de datos<<<<
        Dim rutaDeConexion As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los nombres de los productos y sus precios.
        Dim consulta As String = "SELECT nombre, precio FROM productos"

        Using conexion As New SqlConnection(rutaDeConexion)
            conexion.Open()

            Using comando As New SqlCommand(consulta, conexion)
                Using lector As SqlDataReader = comando.ExecuteReader()
                    ' Crea un DataTable para almacenar los resultados
                    Dim dt As New DataTable()
                    dt.Load(lector)

                    ' Asigna el DataTable al DataGridView
                    dgvConsultarPrecio.DataSource = dt
                End Using
            End Using
        End Using


    End Sub

    Private Sub btnModificarPrecio_Click(sender As Object, e As EventArgs) Handles btnModificarPrecio.Click

        ' Verifica si se ha seleccionado una fila en el DataGridView<<<<<<<
        If dgvConsultarPrecio.SelectedRows.Count > 0 Then
            ' Obtiene el índice de la fila seleccionada<<<<<<
            Dim indiceFilas As Integer = dgvConsultarPrecio.SelectedRows(0).Index

            ' Obtiene el nombre y precio del producto seleccionado<<<<<<
            Dim nombreProducto As String = dgvConsultarPrecio.Rows(indiceFilas).Cells("nombre").Value.ToString()
            Dim precioProducto As Decimal = CDec(dgvConsultarPrecio.Rows(indiceFilas).Cells("precio").Value)

            ' Muestra el nombre y precio del producto en un TextBox<<<<<
            txtPrecioNuevo.Text = precioProducto.ToString()

            ' Almacena el nombre del producto en el Tag del TextBox para usarlo en la actualización.<<<<<
            txtPrecioNuevo.Tag = nombreProducto
        Else
            MessageBox.Show("Seleccione un producto para modificar su precio.")
        End If


    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        ' Obteniene el nombre del producto desde el Tag del TextBox.<<<<<
        Dim nombreProducto As String = txtPrecioNuevo.Tag.ToString()

        ' Obtiene el nuevo precio desde el TextBox.<<<<<<
        Dim nuevoPrecio As Decimal
        If Decimal.TryParse(txtPrecioNuevo.Text, nuevoPrecio) Then
            ' Establece la cadena de conexión<<<<<<<<
            Dim rutaDeConexion As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

            ' Consulta SQL para actualizar el precio del producto en la base de datos.<<<<<<
            Dim consulta As String = "UPDATE productos SET precio = @NuevoPrecio WHERE nombre = @NombreProducto"

            Using conexion As New SqlConnection(rutaDeConexion)
                conexion.Open()

                Using comando As New SqlCommand(consulta, conexion)
                    comando.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio)
                    comando.Parameters.AddWithValue("@NombreProducto", nombreProducto)

                    ' Ejecuta la consulta de actualización
                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas > 0 Then

                        MessageBox.Show("Precio actualizado correctamente.")
                        ' Actualiza el DataGridView para reflejar los cambios
                        ConsultarPrecios()
                    Else
                        MessageBox.Show("No se pudo actualizar el precio del producto.")
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Ingrese un precio válido.")
        End If

    End Sub

    Private Sub ConsultarPrecios()

        ' Ruta de conexion a la base de datos SQL<<<<<<<<
        Dim rutaDeConexion As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los nombres de los productos y sus precios
        Dim consulta As String = "SELECT nombre, precio FROM productos"

        Using conexion As New SqlConnection(rutaDeConexion)
            conexion.Open()

            Using comando As New SqlCommand(consulta, conexion)
                Using lector As SqlDataReader = comando.ExecuteReader()
                    ' Crea un DataTable para almacenar los resultados
                    Dim dt As New DataTable()
                    dt.Load(lector)

                    ' Asigna el DataTable al DataGridView
                    dgvConsultarPrecio.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class