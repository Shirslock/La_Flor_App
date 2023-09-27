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
                        ' Crear un objeto Producto y agregarlo a la lista
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

        ' Mostrar los productos en el DataGridView
        DataGridView1.DataSource = Productos
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click


        ' Verificar si se ha seleccionado un producto en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then

            ' Obtener el índice de la fila seleccionada
            Dim rowIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Verificar si el índice es válido
            If rowIndex >= 0 AndAlso rowIndex < Productos.Count Then
                ' Obtener el producto seleccionado
                Dim productoSeleccionado As Producto = Productos(rowIndex)

                ' Crear una instancia del formulario "FormModificarProducto" y pasar el producto seleccionado
                Dim modificarForm As New FormModificarProducto(productoSeleccionado)

                ' Mostrar el formulario "FormModificarProducto" en modo de diálogo
                If modificarForm.ShowDialog() = DialogResult.OK Then
                    ' Actualizar la información del producto en el DataGridView si es necesario
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


        ' Crear una instancia del formulario "FormAgregarProducto"
        Dim agregarProductoForm As New FormAgregarProducto()

        ' Mostrar el formulario "FormAgregarProducto" en modo de diálogo
        If agregarProductoForm.ShowDialog() = DialogResult.OK Then
            ' El usuario ha agregado un nuevo producto, actualiza el DataGridView
            ActualizarDataGridView()
            Dim reaparecer As New FormVerProductos()
            Me.Close()
            reaparecer.ShowDialog()


        End If

    End Sub

    'Me actualiza el DataGridView
    Private Sub ActualizarDataGridView()
        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los productos
        Dim query As String = "SELECT nombre, descripcion, categoria, precio, stock FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    ' Crear un nuevo DataTable para los datos de productos
                    Dim dt As New DataTable()

                    ' Llenar el DataTable con los datos de productos
                    adapter.Fill(dt)

                    ' Asignar el DataTable al DataGridView
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reaparecer As New FormVerProductos()
        Me.Close()
        reaparecer.ShowDialog()


    End Sub






End Class
