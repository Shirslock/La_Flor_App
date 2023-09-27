
Imports System.Data.SqlClient



Public Class FormGestionarVentas


    Private Productos As New List(Of Producto)

    Private Sub FormGestionarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llena el ComboBox con los productos disponibles
        CargarProductos()
        cbProductoSeleccionado.DisplayMember = "Nombre"

        DataGridViewStock.Columns.Add("IDProducto", "ID Producto")
        DataGridViewStock.Columns.Add("Nombre", "Nombre")
        DataGridViewStock.Columns.Add("Stock", "Stock")

    End Sub

    Private Sub CargarProductos()
        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los productos disponibles
        Dim query As String = "SELECT id_producto, nombre FROM productos WHERE stock > 0"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Agregar productos al ComboBox
                        Dim producto As New Producto()
                        producto.IDProducto = CInt(reader("id_producto"))
                        producto.Nombre = reader("nombre").ToString()
                        Productos.Add(producto)
                        cbProductoSeleccionado.Items.Add(producto)
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub cbProductoSeleccionado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductoSeleccionado.SelectedIndexChanged
        Dim productoSeleccionado As Producto = DirectCast(cbProductoSeleccionado.SelectedItem, Producto)
        Dim idProducto As Integer = productoSeleccionado.IDProducto

    End Sub

    Private Sub MostrarStockProducto(idProducto As Integer)
        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener el stock del producto seleccionado
        Dim query As String = "SELECT stock FROM productos WHERE id_producto = @IDProducto"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDProducto", idProducto)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Mostrar el stock en el DataGridView
                        DataGridViewStock.Rows.Clear()
                        DataGridViewStock.Rows.Add(idProducto, cbProductoSeleccionado.Text, reader("stock"))
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ' Verificar si se ha seleccionado un producto
        If cbProductoSeleccionado.SelectedIndex >= 0 Then
            ' Obtener el producto seleccionado
            Dim productoSeleccionado As Producto = DirectCast(cbProductoSeleccionado.SelectedItem, Producto)

            ' Obtener la cantidad vendida
            Dim cantidadVendida As Integer
            If Integer.TryParse(txtCantidadVendida.Text, cantidadVendida) AndAlso cantidadVendida > 0 Then
                ' Registrar la venta y actualizar el stock
                RegistrarVenta(productoSeleccionado, cantidadVendida)
            Else
                MessageBox.Show("Ingrese una cantidad válida.")
            End If
        Else
            MessageBox.Show("Seleccione un producto para la venta.")
        End If

    End Sub

    Private Sub RegistrarVenta(producto As Producto, cantidadVendida As Integer)
        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using transaction As SqlTransaction = connection.BeginTransaction()
                Try
                    ' Calcular el total de la venta
                    Dim totalVenta As Decimal = cantidadVendida * producto.Precio

                    ' Registrar la venta en la tabla ventas
                    Dim queryVenta As String = "INSERT INTO ventas (fecha_venta, total_venta, id_producto, cantidad, precio_unitario) VALUES (@FechaVenta, @TotalVenta, @IDProducto, @Cantidad, @PrecioUnitario)"

                    Using commandVenta As New SqlCommand(queryVenta, connection, transaction)
                        commandVenta.Parameters.AddWithValue("@FechaVenta", DateTime.Now)
                        commandVenta.Parameters.AddWithValue("@TotalVenta", totalVenta)
                        commandVenta.Parameters.AddWithValue("@IDProducto", producto.IDProducto)
                        commandVenta.Parameters.AddWithValue("@Cantidad", cantidadVendida)
                        commandVenta.Parameters.AddWithValue("@PrecioUnitario", producto.Precio)

                        ' Ejecutar la consulta de venta
                        commandVenta.ExecuteNonQuery()
                    End Using

                    ' Actualizar el stock del producto
                    Dim queryActualizarStock As String = "UPDATE productos SET stock = stock - @CantidadVendida WHERE id_producto = @IDProducto"

                    Using commandActualizarStock As New SqlCommand(queryActualizarStock, connection, transaction)
                        commandActualizarStock.Parameters.AddWithValue("@CantidadVendida", cantidadVendida)
                        commandActualizarStock.Parameters.AddWithValue("@IDProducto", producto.IDProducto)

                        ' Ejecutar la consulta de actualización de stock
                        commandActualizarStock.ExecuteNonQuery()
                    End Using

                    ' Confirmar la transacción
                    transaction.Commit()

                    ' Mostrar un mensaje de éxito
                    MessageBox.Show("Venta registrada con éxito.")

                    ' Limpiar el TextBox de cantidad vendida
                    txtCantidadVendida.Clear()

                    ' Actualizar el stock mostrado en el DataGridView
                    MostrarStockProducto(producto.IDProducto)
                Catch ex As Exception
                    ' Ocurrió un error, deshacer la transacción
                    transaction.Rollback()
                    MessageBox.Show("Error al registrar la venta. Revise los datos e inténtelo nuevamente.")
                End Try
            End Using
        End Using
    End Sub

    Private Sub ActualizarDataGridView()
        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener los productos
        Dim query As String = "SELECT id_producto, nombre, descripcion, categoria, precio, stock FROM productos"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    ' Crear un nuevo DataTable para los datos de productos
                    Dim dt As New DataTable()

                    ' Llenar el DataTable con los datos de productos desde la base de datos
                    adapter.Fill(dt)

                    ' Asignar el DataTable al DataGridView
                    DataGridViewStock.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnVerHistorial_Click(sender As Object, e As EventArgs) Handles btnVerHistorial.Click

        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para obtener el historial de ventas
        Dim query As String = "SELECT V.id_venta, V.fecha_venta, P.nombre AS NombreProducto, V.cantidad
                            FROM ventas AS V
                            INNER JOIN productos AS P ON V.id_producto = P.id_producto
                            ORDER BY V.fecha_venta DESC"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                Using adapter As New SqlDataAdapter(command)
                    ' Crear un nuevo DataTable para los datos del historial de ventas
                    Dim dt As New DataTable()

                    ' Llenar el DataTable con los datos del historial de ventas desde la base de datos
                    adapter.Fill(dt)

                    ' Asignar el DataTable al DataGridView
                    DataGridViewVentas.DataSource = dt
                End Using
            End Using
        End Using




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class