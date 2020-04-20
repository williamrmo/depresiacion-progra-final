Imports DAL
Imports Entities

Public Class EmpleadoReglas
    ''' <summary>
    ''' Valida que el usuario ingresado se válido
    ''' </summary>
    ''' <param name="CodigoUsuario"></param>
    ''' <param name="Pass"></param>
    ''' <returns>
    ''' Objeto usuario con la ionformacion que se ha obtenido
    ''' </returns>
    Public Function validarUsuario(ByVal CodigoUsuario As String, ByVal Pass As String) As Empleado
        Try
            Dim iEmpleado As New Empleado With {
                .Username = CodigoUsuario,
                .Password = Pass
            }

            Dim ivalidarUsuario As New DBQuerys

            Return ivalidarUsuario.ValidarUsuario(iEmpleado)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerUsuario(ByVal Id_Empleado As String) As Empleado
        Try
            Dim iEmpleado As New Empleado With {
                .Id_Empleado = Id_Empleado
            }

            Dim ivalidarUsuario As New DBQuerys

            Return ivalidarUsuario.obtenerUsuario(iEmpleado)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Alamcenar un nuevo empleado
    ''' </summary>
    ''' <param name="IdEmpleado"></param>
    ''' <param name="IdRol"></param>
    ''' <param name="NombreEmpleado"></param>
    ''' <param name="Username"></param>
    ''' <param name="Password"></param>
    Public Sub NuevoEmpleado(ByVal IdEmpleado As String, ByVal IdRol As Integer, ByVal NombreEmpleado As String, ByVal Username As String, ByVal Password As String)
        Try
            Dim iEmpleado As New Empleado With {
                .Id_Empleado = IdEmpleado,
                .ID_Rol = IdRol,
                .Nombre = NombreEmpleado,
                .Username = Username,
                .Password = Password
            }

            Dim iNuevoEmpleado As New DBQuerys

            iNuevoEmpleado.InsertNuevoEmpleado(iEmpleado)
        Catch ex As Exception

        End Try
    End Sub

    Public Function validarAdmin(ByVal iEmpleado As Empleado) As Boolean
        Try
            Dim blAdmin As Boolean = False

            If iEmpleado.Administrador Then
                blAdmin = True
            End If

            Return blAdmin
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function usuarioRepetido(ByVal idEmpleado As String, ByVal username As String) As Boolean
        Try
            Dim iEmpleado As New Empleado With {
                .Id_Empleado = idEmpleado,
                .Username = username
            }

            Dim iUsuarioRepetido As New DBQuerys

            Return iUsuarioRepetido.existeUsuario(iEmpleado)
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
