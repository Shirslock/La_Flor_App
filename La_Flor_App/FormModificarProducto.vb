Imports System.Windows.Forms
Imports System.Data.SqlClient



Public Class FormModificarProducto

    Private ProductoModificar As Producto

    ' Constructor que acepta un argumento del tipo Producto
    Public Sub New(producto As Producto)
        InitializeComponent()
        ProductoModificar = producto
    End Sub

    ' Evento Load para cargar los datos del producto en los controles
    Private Sub FormModificarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Muestra los datos del producto en los controles
        txtNombre.Text = ProductoModificar.Nombre
        txtDescripcion.Text = ProductoModificar.Descripcion
        txtCategoria.Text = ProductoModificar.Categoria
        txtPrecio.Text = ProductoModificar.Precio.ToString()
        txtStock.Text = ProductoModificar.Stock.ToString()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ' Actualiza los datos del producto con los valores ingresados por el usuario
        ProductoModificar.Nombre = txtNombre.Text
        ProductoModificar.Descripcion = txtDescripcion.Text
        ProductoModificar.Categoria = txtCategoria.Text
        ProductoModificar.Precio = Decimal.Parse(txtPrecio.Text)
        ProductoModificar.Stock = Integer.Parse(txtStock.Text)

        ' Establece la cadena de conexión a la base de datos
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para actualizar los datos del producto en la base de datos
        Dim query As String = "UPDATE productos SET nombre = @Nombre, descripcion = @Descripcion, categoria = @Categoria, precio = @Precio, stock = @Stock WHERE id_producto = @IDProducto"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                ' Agrega los parámetros de la consulta
                command.Parameters.AddWithValue("@Nombre", ProductoModificar.Nombre)
                command.Parameters.AddWithValue("@Descripcion", ProductoModificar.Descripcion)
                command.Parameters.AddWithValue("@Categoria", ProductoModificar.Categoria)
                command.Parameters.AddWithValue("@Precio", ProductoModificar.Precio)
                command.Parameters.AddWithValue("@Stock", ProductoModificar.Stock)
                command.Parameters.AddWithValue("@IDProducto", ProductoModificar.IDProducto)

                ' Ejecuta la consulta de actualización
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then

                    MessageBox.Show("Los cambios se guardaron correctamente en la base de datos.")
                Else

                    MessageBox.Show("No se pudieron guardar los cambios en la base de datos.")
                End If
            End Using
        End Using


        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class