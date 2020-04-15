Imports DAL
Imports Entities

Public Class RolesReglas

    Public Function getRoles() As ArrayList
        Try

            Dim iObtenerRoles As New DBQuerys

            Return iObtenerRoles.obtenerRoles()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getIdRol(ByVal listaRoles As ArrayList, ByVal rolNombre As String) As Integer
        Try
            Dim idRol As Integer
            Dim rol As Roles = New Roles

            For Each rol In listaRoles
                If rolNombre.Equals(rol.Rol) Then
                    idRol = rol.Id_Rol
                    Exit For
                End If
            Next

            Return idRol
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
