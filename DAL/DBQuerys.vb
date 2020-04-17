Imports Entities
Imports System.Text
Imports System.Data.SqlClient

Public Class DBQuerys
    Inherits DBConnection

#Region "Empleado"
    ''' <summary>
    ''' Valida que el usuario que se está autenticando sea válido
    ''' </summary>
    ''' <param name="iEmpleado">
    ''' Objeto de tipo usuario con la información que se requiere para la consulta de validez
    ''' </param>
    ''' <returns>
    ''' Objeto del tipo usuario con los datos obtenidos
    ''' </returns>
    Public Function ValidarUsuario(ByVal iEmpleado As Empleado) As Empleado
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("Select ID_EMPLEADO, ID_ROL, NOMBRE_EMPLEADO")

            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append(" From EMPLEADO WHERE USERNAME_EMPLEADO = '")
                .Append(iEmpleado.Username)
                .Append("' and PASSWORD_EMPLEADO = '")
                .Append(iEmpleado.Password)
                .Append("'")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'inicializa la propiedad en false para negar el logueo del usuario ante cualquier error
            iEmpleado.UsuarioValido = False

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then
                    'valida que la tabla tenga registros para cargar la información en la clase
                    If dsDatos.Tables(0).Rows.Count > 0 Then
                        Dim drEmpleado As DataRow = dsDatos.Tables(0).Rows(0)
                        With iEmpleado
                            .Id_Empleado = CStr(drEmpleado("ID_EMPLEADO"))
                            .Id_Rol = CStr(drEmpleado("ID_ROL"))
                            .Nombre = CStr(drEmpleado("NOMBRE_EMPLEADO"))
                            .UsuarioValido = True

                            Select Case CStr(drEmpleado("ID_ROL"))
                                Case "3"
                                    .Administrador = True
                                Case Else
                                    .Administrador = False
                            End Select
                        End With

                    End If
                End If
            End If

            'retorna la información del usuario 
            Return iEmpleado
        Catch ex As Exception
            iEmpleado.UsuarioValido = False
            Return iEmpleado
        End Try
    End Function

    ''' <summary>
    ''' Retorna el perfil de el usuario logueado
    ''' </summary>
    ''' <param name="iEmpleado"></param>
    ''' <returns>
    ''' Un objeto Empleado con los datos del perfil del usuario activo
    ''' </returns>
    Public Function obtenerUsuario(ByVal iEmpleado As Empleado) As Empleado
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("Select Empleado.ID_EMPLEADO, Empleado.NOMBRE_EMPLEADO, Empleado.USERNAME_EMPLEADO, Rol_Empleado.ID_ROL, Rol_Empleado.NOMBRE_ROL")


            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append(" from Empleado inner join Rol_Empleado on Rol_Empleado.ID_ROL")
                '.Append(iEmpleado.ID_Rol)
                .Append(" = Empleado.ID_ROL")
                '.Append(iEmpleado.ID_Rol)
                .Append(" where ID_EMPLEADO = '")
                .Append(iEmpleado.Id_Empleado)
                .Append("';")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then
                    'valida que la tabla tenga registros para cargar la información en la clase
                    If dsDatos.Tables(0).Rows.Count > 0 Then
                        Dim drEmpleado As DataRow = dsDatos.Tables(0).Rows(0)

                        With iEmpleado
                            .Id_Empleado = CStr(drEmpleado("ID_EMPLEADO"))
                            .Nombre = CStr(drEmpleado("NOMBRE_EMPLEADO"))
                            .Username = CStr(drEmpleado("USERNAME_EMPLEADO"))
                            .Rol = CStr(drEmpleado("NOMBRE_ROL"))
                            .UsuarioValido = True

                            Select Case CStr(drEmpleado("ID_ROL"))
                                Case "3"
                                    .Administrador = True
                                Case Else
                                    .Administrador = False
                            End Select
                        End With

                    End If
                End If
            End If
            Return iEmpleado
        Catch ex As Exception
            Return iEmpleado
        End Try
    End Function

    ''' <summary>
    ''' busca todos los roles de empleo almacenados en la DB
    ''' </summary>
    ''' <returns>
    ''' Un arraylist con objetos de tipo Roles
    ''' </returns>
    Public Function obtenerRoles() As ArrayList
        Dim listaRoles As ArrayList = New ArrayList()
        Try


            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Rol_Empleado;")

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drRoles As DataRow In dsDatos.Tables(0).Rows
                        Dim iRoles As New Roles
                        With iRoles
                            .Id_Rol = CInt(drRoles("ID_ROL"))
                            .Rol = CStr(drRoles("NOMBRE_ROL"))
                        End With

                        listaRoles.Add(iRoles)
                    Next

                End If
            End If
            Return listaRoles
        Catch ex As Exception
            Return listaRoles
        End Try
    End Function

    ''' <summary>
    ''' Insert a la tabla Empleado con el objeto Empleado
    ''' </summary>
    ''' <param name="iEmpleado"></param>
    Public Sub InsertNuevoEmpleado(ByVal iEmpleado As Empleado)
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("insert into Empleado values('")

            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append(iEmpleado.Id_Empleado)
                .Append("', ")
                .Append(iEmpleado.Id_Rol)
                .Append(", '")
                .Append(iEmpleado.Nombre)
                .Append("', '")
                .Append(iEmpleado.Password)
                .Append("', '")
                .Append(iEmpleado.Username)
                .Append("');")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Activo"
    ''' <summary>
    ''' Consulta a la DB los tios de activos
    ''' </summary>
    ''' <returns>
    ''' Arraylis de Objetos TipoActivo 
    ''' </returns>
    Public Function obtenerTipoActivo() As ArrayList
        Try
            Dim listaTiposActivo As ArrayList = New ArrayList()

            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Tipo_Activo;")

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drTipoActivo As DataRow In dsDatos.Tables(0).Rows
                        Dim iTipoActivo As New TipoActivo
                        With iTipoActivo
                            .ID_Tipo_Activo = CInt(drTipoActivo("ID_TIPO_ACTIVO"))
                            .Nombre_Tipo_Activo = CStr(drTipoActivo("NOMBRE_TIPO_ACTIVO"))
                            .Vida_Util = CInt(drTipoActivo("VIDA_UTIL"))
                        End With

                        listaTiposActivo.Add(iTipoActivo)
                    Next

                End If
            End If
            Return listaTiposActivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' insert a la tabla activo con el objeto activo
    ''' </summary>
    ''' <param name="iActivo"></param>
    Public Sub insertActivo(ByVal iActivo As Activo)
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("insert into Activo (ID_ACTIVO,ID_EMPLEADO,ID_TIPO_ACTIVO,NOMBRE_ACTIVO,FECHA_ADQUISICION,VALOR_HISTORICO,VALOR_RESIDUAL_PORCENTAJE,VALOR_RESIDUAL)")

            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append("values('")
                .Append(iActivo.Id_Activo)
                .Append("', '")
                .Append(iActivo.Id_Empleado)
                .Append("', ")
                .Append(iActivo.Tipo_Activo)
                .Append(", '")
                .Append(iActivo.Nombre_Activo)
                .Append("', '")
                .Append(iActivo.Fecha_Adquisicion)
                .Append("', ")
                .Append(iActivo.Valor_Historico)
                .Append(", ")
                .AppendFormat("{0}", iActivo.Valor_Residual_Porcent)
                ''.Append(iActivo.Valor_Residual_Porcent)
                .Append(", ")
                .Append(iActivo.Valor_Residual)
                .Append(");")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ontenerIdActivo() As ArrayList
        Try
            Dim listaIdActivo As ArrayList = New ArrayList()

            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Activo;")

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drActivo As DataRow In dsDatos.Tables(0).Rows
                        Dim iActivo As New Activo
                        With iActivo
                            .Id_Activo = CStr(drActivo("ID_ACTIVO"))
                        End With

                        listaIdActivo.Add(iActivo)
                    Next

                End If
            End If
            Return listaIdActivo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' busca un Activo en la base de datos con el ID_Activo
    ''' </summary>
    ''' <param name="iActivo"></param>
    ''' <returns>Un Objeto de tipo Activo</returns>
    Public Function obtenerDatoActivo(ByVal iActivo As Activo) As Activo
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("Select * from Activo ")


            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append("inner join Tipo_Activo ")
                .Append("on Tipo_Activo.ID_TIPO_ACTIVO = Activo.ID_TIPO_ACTIVO ")
                .Append("where Activo.ID_ACTIVO = '")
                .Append(iActivo.Id_Activo)
                .Append("';")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then
                    'valida que la tabla tenga registros para cargar la información en la clase
                    If dsDatos.Tables(0).Rows.Count > 0 Then
                        Dim drActivo As DataRow = dsDatos.Tables(0).Rows(0)

                        With iActivo
                            .Id_Activo = CStr(drActivo("ID_ACTIVO"))
                            .Tipo_Activo = CInt(drActivo("ID_TIPO_ACTIVO"))
                            .Nombre_Activo = CStr(drActivo("NOMBRE_ACTIVO"))
                            .Fecha_Adquisicion = CDate(drActivo("FECHA_ADQUISICION"))
                            .Valor_Historico = CDbl(drActivo("VALOR_HISTORICO"))
                            .Valor_Residual_Porcent = CDbl(drActivo("VALOR_RESIDUAL_PORCENTAJE"))
                            .Valor_Residual = CDbl(drActivo("VALOR_RESIDUAL"))
                            .Vida_Util = CInt(drActivo("VIDA_UTIL"))
                            .Nombre_Tipo_Activo = CStr(drActivo("NOMBRE_TIPO_ACTIVO"))

                            Select Case CStr(drActivo("APROBADO"))
                                Case "1"
                                    .Aprobado = True
                                Case Else
                                    .Aprobado = False
                            End Select
                        End With

                    End If
                End If
            End If
            Return iActivo
        Catch ex As Exception
            Return iActivo
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta un update al Activo seleccionado
    ''' </summary>
    ''' <param name="iActivo"></param>
    Public Sub actualizarActivo(ByVal iActivo As Activo)
        Try
            ' Validar que el objeto no ha sido aprobado
            If Not iActivo.Aprobado Then
                'variable para realizar la consulta de la información
                Dim strConsultaSQL As New StringBuilder("update Activo ")

                'agrega los filtros a la consulta de la información
                With strConsultaSQL
                    .Append("set ID_TIPO_ACTIVO = ")
                    .Append(iActivo.Tipo_Activo)
                    .Append(", NOMBRE_ACTIVO = '")
                    .Append(iActivo.Nombre_Activo)
                    .Append("', FECHA_ADQUISICION = '")
                    .Append(iActivo.Fecha_Adquisicion)
                    .Append("', VALOR_HISTORICO = ")
                    .Append(iActivo.Valor_Historico)
                    .Append(", VALOR_RESIDUAL_PORCENTAJE = ")
                    .Append(iActivo.Valor_Residual_Porcent)
                    .Append(", VALOR_RESIDUAL = ")
                    .Append(iActivo.Valor_Residual)
                    .Append("where ID_ACTIVO = '")
                    .Append(iActivo.Id_Activo)
                    .Append("';")
                End With

                'ejecuta la sentencia a base de datos
                Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Elimina un Activo de la DB si este no ha sido aprobado
    ''' </summary>
    ''' <param name="iActivo"></param>
    Public Sub eliminarActivo(ByVal iActivo As Activo)
        Try
            ' Validar que el objeto no ha sido aprobado
            If Not iActivo.Aprobado Then
                'variable para realizar la consulta de la información
                Dim strConsultaSQL As New StringBuilder("delete from Activo ")

                'agrega los filtros a la consulta de la información
                With strConsultaSQL
                    .Append("where ID_ACTIVO = '")
                    .Append(iActivo.Id_Activo)
                    .Append("';")
                End With

                'ejecuta la sentencia a base de datos
                Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Aprobar una depresiacion
    ''' </summary>
    ''' <param name="iDepresiacion"></param>
    Public Sub aprobarDepresiacion(ByVal iDepresiacion As Depresiacion)
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("update Activo ")

            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append("set APROBADO = 1")
                .Append("where ID_ACTIVO = '")
                .Append(iDepresiacion.Id_Activo)
                .Append("';")
                .Append("update Depresiacion ")
                .Append("set FECHA_APROBACION = '")
                .Append(iDepresiacion.Fecha_Aprobacion)
                .Append("', ")
                .Append("ID_EMPLEADO_APROBACION ='")
                .Append(iDepresiacion.Id_Empleado)
                .Append("', ")
                .Append("where ID_ACTIVO = '")
                .Append(iDepresiacion.Id_Activo)
                .Append("';")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarActivoTB(ByVal iActivo As Activo) As DataTable
        Try
            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select ID_ACTIVO as Codigo, NOMBRE_TIPO_ACTIVO as Categoria, NOMBRE_ACTIVO as Nombre, VALOR_HISTORICO as 'Valor Historico', VALOR_RESIDUAL_PORCENTAJE as 'Porcentaje Residuo', VALOR_RESIDUAL as 'Valor Residual', APROBADO as 'Aprobado' ")

            'agrega los filtros a la consulta de la información
            With strConsultaSQL
                .Append("from Activo ")
                .Append("inner join Tipo_Activo ")
                .Append("on Activo.ID_TIPO_ACTIVO = Tipo_Activo.ID_TIPO_ACTIVO ")
                .Append("where ID_ACTIVO = '")
                .Append(iActivo.Id_Activo)
                .Append("';")
            End With

            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            If dsDatos.Tables.Count >= 0 Then
                Return dsDatos.Tables(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Depresiacion"
    ''' <summary>
    ''' insert de un objeto Dpresiacion en la DB
    ''' </summary>
    ''' <param name="iDepresiacion"></param>
    Public Sub insertDepresiacion(ByVal iDepresiacion As Depresiacion)
        Try
            Try
                'variable para realizar la consulta de la información
                Dim strConsultaSQL As New StringBuilder("insert into Depresiacion (ID_ACTIVO,DEPRESIACION_ANUAL,DEPRESIACION_ACUMULADA,VALOR_NETO,ANNO,ANNO_DEPRESIACION) ")

                'agrega los filtros a la consulta de la información
                With strConsultaSQL
                    .Append("values('")
                    .Append(iDepresiacion.Id_Activo)
                    .Append("', ")
                    .Append(iDepresiacion.Depresiacion_Anual)
                    .Append(", ")
                    .Append(iDepresiacion.Depresiacion_Acumulada)
                    .Append(", ")
                    .Append(iDepresiacion.Valor_Neto)
                    .Append(", ")
                    .Append(iDepresiacion.Anno)
                    .Append(", ")
                    .Append(iDepresiacion.Anno_Depresiacion)
                    .Append(");")
                End With

                'ejecuta la sentencia a base de datos
                Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Busca Todas las depresiaciones correspondientes a un activo especifico
    ''' </summary>
    ''' <param name="iActivo"></param>
    ''' <returns>
    ''' Un Arraylist de objetos Depresiacion
    ''' </returns>
    Public Function obtenerDepresiacionID(ByVal iActivo As Activo) As ArrayList
        Try
            Dim listaDepresiacion As ArrayList = New ArrayList()

            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Depresiacion ")

            With strConsultaSQL
                .Append("inner join Activo ")
                .Append("on Activo.ID_ACTIVO = Depresiacion.ID_ACTIVO ")
                .Append("inner join Tipo_Activo ")
                .Append("on Activo.ID_TIPO_ACTIVO = Tipo_Activo.ID_TIPO_ACTIVO;")
            End With
            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drDepresiacion As DataRow In dsDatos.Tables(0).Rows
                        Dim iDepresiacion As New Depresiacion
                        With iDepresiacion
                            .Id_Depresiacion = CInt(drDepresiacion("ID_DEPRESIACION"))
                            .Id_Activo = CStr(drDepresiacion("ID_ACTIVO"))
                            .Depresiacion_Anual = CDbl(drDepresiacion("DEPRESIACION_ANUAL"))
                            .Depresiacion_Acumulada = CDbl(drDepresiacion("DEPRESIACION_ACUMULADA"))
                            .Valor_Neto = CDbl(drDepresiacion("VALOR_NETO"))
                            .Id_Empleado = CStr(drDepresiacion("ID_EMPLEADO"))
                            .Nombre_Tipo_Activo = CStr(drDepresiacion("NOMBRE_ACTIVO"))
                            .Fecha_Adquisicion = CDate(drDepresiacion("FECHA_ADQUISICION"))
                            .Vida_Util = CInt(drDepresiacion("VIDA_UTIL"))
                            .Valor_Historico = CDbl(drDepresiacion("VALOR_HISTORICO"))
                            .Valor_Residual = CDbl(drDepresiacion("VALOR_RESIDUAL"))
                            .Valor_Residual_Porcent = CDbl(drDepresiacion("VALOR_RESIDUAL_PORCENTAJE"))
                            .Anno = CInt(drDepresiacion("ANNO"))
                            .Anno_Depresiacion = CInt(drDepresiacion("ANNO_DEPRESIACION"))

                            Select Case CStr(drDepresiacion("APROBADO"))
                                Case "1"
                                    .Fecha_Aprobacion = CDate(drDepresiacion("FECHA_APROBACION"))
                                    .Id_Empleado_Aprobacion = CStr(drDepresiacion("ID_EMPLEADO_APROBACION"))
                                    .Aprobado = True
                                Case Else
                                    .Aprobado = False
                            End Select
                        End With

                        If iActivo.Id_Activo.Equals(iDepresiacion.Id_Activo) Then
                            listaDepresiacion.Add(iDepresiacion)
                        End If
                    Next

                End If
            End If
            Return listaDepresiacion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Busca Todas las depresiaciones correspondientes a un anno especifico
    ''' </summary>
    ''' <param name="anno"></param>
    ''' <returns>
    ''' Un Arraylist de objetos Depresiacion
    ''' </returns>
    Public Function obtenerDepresiacionANNO(ByVal anno As Integer) As ArrayList
        Try
            Dim listaDepresiacion As ArrayList = New ArrayList()

            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Depresiacion ")

            With strConsultaSQL
                .Append("inner join Activo ")
                .Append("on Activo.ID_ACTIVO = Depresiacion.ID_ACTIVO ")
                .Append("inner join Tipo_Activo ")
                .Append("on Activo.ID_TIPO_ACTIVO = Tipo_Activo.ID_TIPO_ACTIVO;")
            End With
            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drDepresiacion As DataRow In dsDatos.Tables(0).Rows
                        Dim iDepresiacion As New Depresiacion

                        If anno.Equals(CInt(drDepresiacion("ANNO"))) Then
                            With iDepresiacion
                                .Id_Depresiacion = CInt(drDepresiacion("ID_DEPRESIACION"))
                                .Id_Activo = CStr(drDepresiacion("ID_ACTIVO"))
                                .Depresiacion_Anual = CDbl(drDepresiacion("DEPRESIACION_ANUAL"))
                                .Depresiacion_Acumulada = CDbl(drDepresiacion("DEPRESIACION_ACUMULADA"))
                                .Valor_Neto = CDbl(drDepresiacion("VALOR_NETO"))
                                .Id_Empleado = CStr(drDepresiacion("ID_EMPLEADO"))
                                .Nombre_Tipo_Activo = CStr(drDepresiacion("NOMBRE_ACTIVO"))
                                .Fecha_Adquisicion = CDate(drDepresiacion("FECHA_ADQUISICION"))
                                .Vida_Util = CInt(drDepresiacion("VIDA_UTIL"))
                                .Valor_Historico = CDbl(drDepresiacion("VALOR_HISTORICO"))
                                .Valor_Residual = CDbl(drDepresiacion("VALOR_RESIDUAL"))
                                .Valor_Residual_Porcent = CDbl(drDepresiacion("VALOR_RESIDUAL_PORCENTAJE"))
                                .Anno = CInt(drDepresiacion("ANNO"))
                                .Anno_Depresiacion = CInt(drDepresiacion("ANNO_DEPRESIACION"))

                                Select Case CStr(drDepresiacion("APROBADO"))
                                    Case "1"
                                        .Fecha_Aprobacion = CDate(drDepresiacion("FECHA_APROBACION"))
                                        .Id_Empleado_Aprobacion = CStr(drDepresiacion("ID_EMPLEADO_APROBACION"))
                                        .Aprobado = True
                                    Case Else
                                        .Aprobado = False
                                End Select
                            End With
                            listaDepresiacion.Add(iDepresiacion)
                        End If
                    Next

                End If
            End If
            Return listaDepresiacion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Busca Todas las depresiaciones aprobadas
    ''' </summary>
    ''' <returns>
    ''' Un Arraylist de objetos Depresiacion
    ''' </returns>
    Public Function obtenerDepresiacionAprobaods() As ArrayList
        Try
            Dim listaDepresiacion As ArrayList = New ArrayList()

            'variable para realizar la consulta de la información
            Dim strConsultaSQL As New StringBuilder("select * from Depresiacion ")

            With strConsultaSQL
                .Append("inner join Activo ")
                .Append("on Activo.ID_ACTIVO = Depresiacion.ID_ACTIVO ")
                .Append("inner join Tipo_Activo ")
                .Append("on Activo.ID_TIPO_ACTIVO = Tipo_Activo.ID_TIPO_ACTIVO;")
            End With
            'ejecuta la sentencia a base de datos
            Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)

            'valida que el DataSet no sea nulo
            If Not IsNothing(dsDatos) Then
                'valida que se hayan obtenido tablas de la base de datos
                If dsDatos.Tables.Count > 0 Then

                    For Each drDepresiacion As DataRow In dsDatos.Tables(0).Rows
                        Dim iDepresiacion As New Depresiacion

                        If CStr(drDepresiacion("APROBADO")).Equals("1") Then
                            With iDepresiacion
                                .Id_Depresiacion = CInt(drDepresiacion("ID_DEPRESIACION"))
                                .Id_Activo = CStr(drDepresiacion("ID_ACTIVO"))
                                .Depresiacion_Anual = CDbl(drDepresiacion("DEPRESIACION_ANUAL"))
                                .Depresiacion_Acumulada = CDbl(drDepresiacion("DEPRESIACION_ACUMULADA"))
                                .Valor_Neto = CDbl(drDepresiacion("VALOR_NETO"))
                                .Id_Empleado = CStr(drDepresiacion("ID_EMPLEADO"))
                                .Nombre_Tipo_Activo = CStr(drDepresiacion("NOMBRE_ACTIVO"))
                                .Fecha_Adquisicion = CDate(drDepresiacion("FECHA_ADQUISICION"))
                                .Vida_Util = CInt(drDepresiacion("VIDA_UTIL"))
                                .Valor_Historico = CDbl(drDepresiacion("VALOR_HISTORICO"))
                                .Valor_Residual = CDbl(drDepresiacion("VALOR_RESIDUAL"))
                                .Valor_Residual_Porcent = CDbl(drDepresiacion("VALOR_RESIDUAL_PORCENTAJE"))
                                .Anno = CInt(drDepresiacion("ANNO"))
                                .Anno_Depresiacion = CInt(drDepresiacion("ANNO_DEPRESIACION"))
                                .Fecha_Aprobacion = CDate(drDepresiacion("FECHA_APROBACION"))
                                .Id_Empleado_Aprobacion = CStr(drDepresiacion("ID_EMPLEADO_APROBACION"))
                                .Aprobado = True
                            End With
                            listaDepresiacion.Add(iDepresiacion)
                        End If

                    Next

                End If
            End If
            Return listaDepresiacion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Elimina todas las depresiaciones por el id del activo
    ''' </summary>
    ''' <param name="iActivo"></param>
    Public Sub eliminarDepresiacion(ByVal iActivo As Activo)
        Try
            ' Validar que el objeto no ha sido aprobado
            If Not iActivo.Aprobado Then
                'variable para realizar la consulta de la información
                Dim strConsultaSQL As New StringBuilder("delete from Depresiacion ")

                'agrega los filtros a la consulta de la información
                With strConsultaSQL
                    .Append("where ID_ACTIVO = '")
                    .Append(iActivo.Id_Activo)
                    .Append("';")
                End With

                'ejecuta la sentencia a base de datos
                Dim dsDatos As DataSet = Me.EjecutarConsultaSQL(strConsultaSQL.ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class
