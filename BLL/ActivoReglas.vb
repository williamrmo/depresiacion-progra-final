﻿Imports DAL
Imports Entities

Public Class ActivoReglas
    ''Dim iActivo As New Activo

    Public Sub NuevoActivo(ByVal IdActivo As String, ByVal IdEmpleado As String, ByVal IdTipoAcivo As Integer, ByVal nombre As String, ByVal fechaAdquisicion As Date, ByVal ValorHistorico As Double, ByVal ValorResidualPorcent As Double, ByVal ValorResidual As Double)
        Try

            Dim iActivo As New Activo With {
                .Id_Activo = IdActivo,
                .Id_Empleado = IdEmpleado,
                .Tipo_Activo = IdTipoAcivo,
                .Nombre_Activo = nombre,
                .Fecha_Adquisicion = fechaAdquisicion.ToString("d"),
                .Valor_Historico = ValorHistorico,
                .Valor_Residual_Porcent = ValorResidualPorcent,
                .Valor_Residual = ValorResidual
            }

            Dim iNuevoActivo As New DBQuerys

            iNuevoActivo.insertActivo(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerActivo(ByVal idActivo As String) As DataTable
        Try

            Dim iActivo As New Activo With {
                .Id_Activo = idActivo
            }

            Dim iActvoDatos As New DBQuerys


            Return iActvoDatos.consultarActivoTB(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCodigoActivo() As ArrayList
        Try

            Dim iObtenerCodigoActivo As New DBQuerys

            Return iObtenerCodigoActivo.ontenerIdActivo()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerActivoObjeto(ByVal idActivo As String) As Activo
        Try

            Dim iActivo As New Activo With {
                .Id_Activo = idActivo
            }

            Dim iActvoDatos As New DBQuerys


            Return iActvoDatos.obtenerDatoActivo(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
