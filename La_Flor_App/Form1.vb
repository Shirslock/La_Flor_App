Imports System.Data.SqlClient

Public Class LoginForm


    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim usuario As String = txtUsuario.Text
        Dim contraseña As String = txtContraseña.Text


        'Cadena de conexion <<<<<<<
        Dim rutaDeConexion As String = "Data Source=DESKTOP-IIBHT0L\SQLEXPRESS;Initial Catalog=la_flor;Integrated Security=True"

        ' Consulta SQL para verificar el usuario y la contraseña <<<<<<
        Dim consulta As String = "SELECT COUNT(*) FROM Usuarios WHERE nombre_usuario = @Usuario AND contraseña = @Contraseña"

        Using conexion As New SqlConnection(rutaDeConexion)
            conexion.Open()

            Using command As New SqlCommand(consulta, conexion)
                command.Parameters.AddWithValue("@Usuario", usuario)
                command.Parameters.AddWithValue("@Contraseña", contraseña)

                ' Ejecuta la consulta y obteniene el resultado
                Dim contador As Integer = CInt(command.ExecuteScalar())

                ' Verifica si el usuario y la contraseña son válidos
                If contador > 0 Then
                    ' Si el usuario es valido....
                    MessageBox.Show("Credenciales Validas! Ingresando!.")

                    Dim formPrincipal As New FormPrincipal()
                    Me.Hide()
                    formPrincipal.Show()



                Else
                    'Si el usuario es incorrecto...
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.")
                End If
            End Using
        End Using



    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Bienvenido a la app Floreria, usuario:admin pass:admin")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class
