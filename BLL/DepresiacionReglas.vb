Imports DAL
Imports Entities

Public Class DepresiacionReglas
    Inherits ActivoReglas

    ''' <summary>
    ''' Calcula la depresiacion
    ''' </summary>
    ''' <param name="IdActivo"></param>
    ''' <returns>
    ''' Retorna un activo con los datos
    ''' </returns>
    Public Function CalcularDpresiacion(ByVal IdActivo As String) As ArrayList
        Try
            Dim listaDepresiacion As ArrayList = New ArrayList
            Dim iActivo As Activo

            iActivo = ObtenerActivoObjeto(IdActivo)

            ' Calculos iniciales para comenzar la depre
            Dim intAnnoCont As Integer = 0
            Dim intAnnoDepre As Integer = CInt(Format(iActivo.Fecha_Adquisicion, "yyyy"))
            Dim dblCostoDpre As Double = iActivo.Valor_Historico - iActivo.Valor_Residual
            Dim dblTasaDepre As Double = 1 / iActivo.Vida_Util
            Dim dblImporteDepre As Double = dblCostoDpre * dblTasaDepre
            Dim dblDepreAculada As Double = 0

            ' Mientras no se completa la vida util
            While iActivo.Vida_Util >= intAnnoCont
                Dim iDepresiacion As New Depresiacion

                ' calculos depresiacion
                iDepresiacion.Id_Activo = iActivo.Id_Activo
                iDepresiacion.Anno = intAnnoCont
                iDepresiacion.Anno_Depresiacion = intAnnoDepre
                iDepresiacion.Depresiacion_Anual = dblImporteDepre
                iDepresiacion.Depresiacion_Acumulada = dblDepreAculada + dblImporteDepre
                iDepresiacion.Valor_Neto = iActivo.Valor_Historico - dblDepreAculada

                ' Almacena el ojeto depre. en el arraylist
                listaDepresiacion.Add(iDepresiacion)

                ' Incrementa variables
                intAnnoDepre = intAnnoDepre + 1
                intAnnoCont = intAnnoCont + 1
                dblDepreAculada = dblDepreAculada + dblImporteDepre
            End While

            ' Returna el arraylist
            Return listaDepresiacion

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Guarda los datos en la tabla depre
    ''' </summary>
    ''' <param name="listaDepre"></param>
    Public Sub GuardarNuevaDepresiacion(ByVal listaDepre As ArrayList)
        Try

            Dim iNuevaDepre As New DBQuerys

            Dim iDepre As New Depresiacion

            ' Por cada objeto en el arraylist ejecuta un insert
            For Each iDepre In listaDepre
                iNuevaDepre.insertDepresiacion(iDepre)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerDepreTB(ByVal idActivo As String) As DataTable
        Try

            Dim iActivo As New Activo With {
                .Id_Activo = idActivo
            }

            Dim iActvoDatos As New DBQuerys


            Return iActvoDatos.consultarDepreTB(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDepreAnnoTB(ByVal anno As String) As DataTable
        Try

            Dim iDepresiacion As New Depresiacion With {
                .Anno_Depresiacion = anno
            }

            Dim iActvoDatos As New DBQuerys


            Return iActvoDatos.consultarDepreAnnoTB(iDepresiacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDepreNoAprobadaTB(ByVal idActivo As String) As DataTable
        Try

            Dim iActivo As New Activo With {
                .Id_Activo = idActivo
            }

            Dim iActvoDatos As New DBQuerys


            Return iActvoDatos.consultarDepreNoAprobadosTB(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub AprobarDepre(ByVal idActivo As String, ByVal daFecha As Date, ByVal idEmpleado As String)
        Try
            Dim iDepresiacion As New Depresiacion With {
                .Id_Activo = idActivo,
                .Fecha_Aprobacion = daFecha,
                .Id_Empleado = idEmpleado
            }

            Dim iAprobarDepre As New DBQuerys

            iAprobarDepre.aprobarDepresiacion(iDepresiacion)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub eliminarDepre(ByVal codigoActivo As String)
        Try
            Dim iActivo As New Activo With {
                .Id_Activo = codigoActivo
            }
            Dim iEliminarDepre As New DBQuerys

            iEliminarDepre.eliminarDepresiacion(iActivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
