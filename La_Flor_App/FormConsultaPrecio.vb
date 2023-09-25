
Imports System.Data.SqlClient

Public Class FormConsultaPrecio
    Private Sub btnConsultarPrecio_Click(sender As Object, e As EventArgs) Handles btnConsultarPrecio.Click


        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los nombres de los productos y sus precios
        Dim query As String = "SELECT nombre, precio FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Crear un DataTable para almacenar los resultados
                    Dim dt As New DataTable()
                    dt.Load(reader)

                    ' Asignar el DataTable al DataGridView
                    dgvConsultarPrecio.DataSource = dt
                End Using
            End Using
        End Using


    End Sub

    Private Sub btnModificarPrecio_Click(sender As Object, e As EventArgs) Handles btnModificarPrecio.Click

        ' Verificar si se ha seleccionado una fila en el DataGridView
        If dgvConsultarPrecio.SelectedRows.Count > 0 Then
            ' Obtener el índice de la fila seleccionada
            Dim rowIndex As Integer = dgvConsultarPrecio.SelectedRows(0).Index

            ' Obtener el nombre y precio del producto seleccionado
            Dim nombreProducto As String = dgvConsultarPrecio.Rows(rowIndex).Cells("nombre").Value.ToString()
            Dim precioProducto As Decimal = CDec(dgvConsultarPrecio.Rows(rowIndex).Cells("precio").Value)

            ' Mostrar el nombre y precio del producto en un TextBox
            txtPrecioNuevo.Text = precioProducto.ToString()

            ' Almacenar el nombre del producto en el Tag del TextBox para usarlo en la actualización
            txtPrecioNuevo.Tag = nombreProducto
        Else
            MessageBox.Show("Seleccione un producto para modificar su precio.")
        End If


    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        ' Obtener el nombre del producto desde el Tag del TextBox
        Dim nombreProducto As String = txtPrecioNuevo.Tag.ToString()

        ' Obtener el nuevo precio desde el TextBox
        Dim nuevoPrecio As Decimal
        If Decimal.TryParse(txtPrecioNuevo.Text, nuevoPrecio) Then
            ' Establecer la cadena de conexión
            Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

            ' Consulta SQL para actualizar el precio del producto en la base de datos
            Dim query As String = "UPDATE productos SET precio = @NuevoPrecio WHERE nombre = @NombreProducto"

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio)
                    command.Parameters.AddWithValue("@NombreProducto", nombreProducto)

                    ' Ejecutar la consulta de actualización
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        ' Actualización exitosa
                        MessageBox.Show("Precio actualizado correctamente.")
                        ' Actualizar el DataGridView para reflejar los cambios
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

        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los nombres de los productos y sus precios
        Dim query As String = "SELECT nombre, precio FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Crear un DataTable para almacenar los resultados
                    Dim dt As New DataTable()
                    dt.Load(reader)

                    ' Asignar el DataTable al DataGridView
                    dgvConsultarPrecio.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class