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

            Dim intAnnoCont As Integer = 0
            Dim intAnnoDepre As Integer = CInt(Format(iActivo.Fecha_Adquisicion, "yyyy"))
            Dim dblCostoDpre As Double = iActivo.Valor_Historico - iActivo.Valor_Residual
            Dim dblTasaDepre As Double = 1 / iActivo.Vida_Util
            Dim dblImporteDepre As Double = dblCostoDpre * dblTasaDepre
            Dim dblDepreAculada As Double = 0

            While iActivo.Vida_Util >= intAnnoCont
                Dim iDepresiacion As New Depresiacion

                iDepresiacion.Id_Activo = iActivo.Id_Activo
                iDepresiacion.Anno = intAnnoCont
                iDepresiacion.Anno_Depresiacion = intAnnoDepre
                iDepresiacion.Depresiacion_Anual = dblImporteDepre
                iDepresiacion.Depresiacion_Acumulada = dblDepreAculada + dblImporteDepre
                iDepresiacion.Valor_Neto = iActivo.Valor_Historico - dblDepreAculada

                listaDepresiacion.Add(iDepresiacion)

                intAnnoDepre = intAnnoDepre + 1
                intAnnoCont = intAnnoCont + 1
                dblDepreAculada = dblDepreAculada + dblImporteDepre
            End While

            Return listaDepresiacion

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarNuevaDepresiacion(ByVal listaDepre As ArrayList)
        Try

            Dim iNuevaDepre As New DBQuerys

            Dim iDepre As New Depresiacion


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
End Class
