Imports System.Data.SqlClient

Public Class LoginForm
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim usuario As String = txtUsuario.Text
        Dim contraseña As String = txtContraseña.Text

        ' Establecer la cadena de conexión
        Dim connectionString As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para verificar el usuario y la contraseña
        Dim query As String = "SELECT COUNT(*) FROM Usuarios WHERE nombre_usuario = @Usuario AND contraseña = @Contraseña"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Usuario", usuario)
                command.Parameters.AddWithValue("@Contraseña", contraseña)

                ' Ejecutar la consulta y obtener el resultado
                Dim count As Integer = CInt(command.ExecuteScalar())

                ' Verificar si el usuario y la contraseña son válidos
                If count > 0 Then
                    ' Usuario autenticado, puedes permitir el acceso a la aplicación
                    MessageBox.Show("Inicio de sesión exitoso.")

                    Dim formPrincipal As New FormPrincipal()
                    formPrincipal.Show()

                    ' Aquí puedes abrir el formulario principal o realizar otras acciones
                Else
                    ' Usuario o contraseña incorrectos
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.")
                End If
            End Using
        End Using



    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Bienvenido a la app Floreria, usuario:admin pass:admin")

    End Sub
End Class
