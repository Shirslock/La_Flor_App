Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class FormVerProductos

    Private Productos As New List(Of Producto)

    Private Sub FormVerProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los productos
        Dim query As String = "SELECT id_producto, nombre, descripcion, categoria, precio, stock FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Crea un objeto Producto y lo agrega a la lista
                        Dim producto As New Producto()
                        producto.IDProducto = reader("id_producto").ToString()
                        producto.Nombre = reader("nombre").ToString()
                        producto.Descripcion = reader("descripcion").ToString()
                        producto.Categoria = reader("categoria").ToString()
                        producto.Precio = Decimal.Parse(reader("precio").ToString())
                        producto.Stock = Integer.Parse(reader("stock").ToString())

                        Productos.Add(producto)
                    End While
                End Using
            End Using
        End Using

        ' Muestra los productos en el DataGridView
        DataGridView1.DataSource = Productos
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click


        ' Verifica si se ha seleccionado un producto en el DataGridView<<<<<<<
        If DataGridView1.SelectedRows.Count > 0 Then

            ' Obtiene el índice de la fila seleccionada<<<<<<
            Dim rowIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Verifica si el índice es válido<<<<<<<
            If rowIndex >= 0 AndAlso rowIndex < Productos.Count Then
                ' Obtiene el producto seleccionado<<<<<<<<
                Dim productoSeleccionado As Producto = Productos(rowIndex)

                ' Crea una instancia del formulario "FormModificarProducto" y pasar el producto seleccionado<<<<<<
                Dim modificarForm As New FormModificarProducto(productoSeleccionado)

                ' Muestra el formulario "FormModificarProducto" en modo de diálogo<<<<<<<
                If modificarForm.ShowDialog() = DialogResult.OK Then
                    ' Actualiza la información del producto en el DataGridView si es necesario.<<<<<<<
                    ActualizarDataGridView()
                    Dim reaparecer As New FormVerProductos()
                    Me.Close()
                    reaparecer.ShowDialog()
                End If
            Else
                MessageBox.Show("El índice de la fila seleccionada no es válido.")
            End If
        Else
            MessageBox.Show("Seleccione un producto para modificar.")
        End If

    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click


        ' Crea una instancia del formulario "FormAgregarProducto"
        Dim agregarProductoForm As New FormAgregarProducto()

        ' Muestra el formulario "FormAgregarProducto" en modo de diálogo
        If agregarProductoForm.ShowDialog() = DialogResult.OK Then

            ActualizarDataGridView()
            Dim reaparecer As New FormVerProductos()
            Me.Close()
            reaparecer.ShowDialog()


        End If

    End Sub

    'Me actualiza el DataGridView
    Private Sub ActualizarDataGridView()
        ' Establece la cadena de conexión a la base de datos<<<<<
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los productos<<<<<<
        Dim query As String = "SELECT nombre, descripcion, categoria, precio, stock FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    ' Crea un nuevo DataTable para los datos de productos<<<<<<
                    Dim dt As New DataTable()

                    ' Llena el DataTable con los datos de productos<<<<<<
                    adapter.Fill(dt)

                    ' Asigna el DataTable al DataGridView<<<<<<<<<<
                    DataGridView1.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click


        ' Verifica si se ha seleccionado una fila en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then

            ' Obtiene el ID del producto seleccionado (suponiendo que el ID esté en la primera columna)
            Dim idProducto As Integer = CInt(DataGridView1.SelectedRows(0).Cells("IDProducto").Value)

            ' Establece la cadena de conexión
            Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

            ' Consulta SQL para eliminar el producto de la base de datos
            Dim query As String = "DELETE FROM productos WHERE id_producto = @IDProducto"

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand(query, connection)
                    ' Agrega el parámetro del ID del producto
                    command.Parameters.AddWithValue("@IDProducto", idProducto)

                    ' Ejecuta la consulta de eliminación
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then


                        MessageBox.Show("El producto se eliminó correctamente de la base de datos.")

                        ' Actualiza el DataGridView para reflejar los cambios
                        ActualizarDataGridView()
                        Dim reaparecer As New FormVerProductos()
                        Me.Close()
                        reaparecer.ShowDialog()

                    Else

                        MessageBox.Show("No se pudo eliminar el producto de la base de datos.")
                    End If
                End Using
            End Using
        Else
            MessageBox.Show("Seleccione un producto para eliminar.")
        End If

    End Sub

    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged

        ' Obtén el término de búsqueda ingresado por el usuario
        Dim searchTerm As String = txtBuscador.Text

        ' Construye la consulta SQL para buscar en la base de datos
        Dim query As String = "SELECT * FROM productos WHERE nombre LIKE @searchTerm OR categoria LIKE @searchTerm OR precio LIKE @searchterm"

        ' Establece la cadena de conexión (usando la que proporcionaste anteriormente)
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Crea una conexión a la base de datos
        Using connection As New SqlConnection(connectionString)
            ' Abre la conexión
            connection.Open()

            ' Crea un adaptador de datos y un conjunto de datos para almacenar los resultados
            Using adapter As New SqlDataAdapter(query, connection)
                ' Configura los parámetros de la consulta
                adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" & searchTerm & "%")

                ' Crea un conjunto de datos para almacenar los resultados de la consulta
                Dim dataset As New DataSet()

                ' Llena el conjunto de datos con los resultados de la consulta
                adapter.Fill(dataset)

                ' Asigna el conjunto de datos como origen de datos del DataGridView
                DataGridView1.DataSource = dataset.Tables(0)
            End Using
        End Using


    End Sub
End Class
