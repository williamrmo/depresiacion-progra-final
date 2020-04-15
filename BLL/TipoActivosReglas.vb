Imports DAL
Imports Entities

Public Class TipoActivosReglas


    Public Function getTipoActivo() As ArrayList
        Try

            Dim iObtenerTipoActivo As New DBQuerys

            Return iObtenerTipoActivo.obtenerTipoActivo()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getIdTipoActivo(ByVal listaTiposActivo As ArrayList, ByVal TipoActivoNombre As String) As String
        Try
            Dim idTipoActivo As String = String.Empty
            Dim iTipoActivo As TipoActivo = New TipoActivo

            For Each iTipoActivo In listaTiposActivo
                If TipoActivoNombre.Equals(iTipoActivo.Nombre_Tipo_Activo) Then
                    idTipoActivo = iTipoActivo.ID_Tipo_Activo
                    Exit For
                End If
            Next

            Return idTipoActivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
