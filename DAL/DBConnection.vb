Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class DBConnection
    Dim sqlConnect As SqlConnection

    Public Sub New()
        Try
            'variable que permite generar el string de conexión con la base de datos
            Dim strConnectionString As New System.Text.StringBuilder

            'agregamos cada una de las opciones que se requieren para el string de conexión
            With strConnectionString
                .Append("Data Source=")
                .Append(ConfigurationManager.AppSettings("ServerName"))
                .Append(";Initial Catalog=")
                .Append(ConfigurationManager.AppSettings("DBName"))
                '.Append(";Integrated Security")
                .Append(";User=")
                .Append(ConfigurationManager.AppSettings("User"))
                .Append(";Password=")
                .Append(ConfigurationManager.AppSettings("Pass"))
            End With

            'inicializamos el objeto de conexión con la base de datos
            Me.sqlConnect = New SqlConnection(strConnectionString.ToString)

        Catch ex As Exception
            Throw New Exception("Se ha producido un error al momento de crear el objeto de conexión a la base de datos", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta la sentencia SQL que no requieren retorno de información
    ''' </summary>
    ''' <param name="ConsultaEjecutar">
    ''' Consulta SQL que se desea ejecutar
    ''' </param>
    Protected Sub EjecutarSQL(ByVal ConsultaEjecutar As String)
        Try
            Dim sqlCMD As New SqlCommand(ConsultaEjecutar, Me.sqlConnect)

            'abre la conexión con la base de datos
            Me.sqlConnect.Open()

            'ejecuta la consulta en la base de datos
            sqlCMD.ExecuteNonQuery()

            'cierre la conexión con la base de datos
            Me.sqlConnect.Close()

        Catch ex As Exception
            'en caso de error, valida que la conexión se encuente abierta y en caso de ser así, la cierra
            If Me.sqlConnect.State = ConnectionState.Open Then Me.sqlConnect.Close()
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta la sentencia SQL que no requieren retorno de información
    ''' </summary>
    ''' <param name="sqlEjecutar">
    ''' Consulta que se desea ejecutar en la base de datos
    ''' </param>
    ''' <returns>
    ''' DataSet con la información obtenido de la consulta de base de datos
    ''' </returns>
    Protected Function EjecutarConsultaSQL(ByVal sqlEjecutar As String) As DataSet
        Try

            'variable para almacenar la información que se va a obtener desde la base de datos
            Dim dsConsulta As New DataSet

            'se crea el adapter para cargar la información de la consulta al dataset
            Dim sqlAdapter As New SqlDataAdapter With {
                .SelectCommand = New SqlCommand(sqlEjecutar, Me.sqlConnect)
            }
            sqlAdapter.Fill(dsConsulta)

            'retorna la información que se obtuvo de la ejecución de la consulta
            Return dsConsulta

        Catch ex As Exception
            If Me.sqlConnect.State = ConnectionState.Open Then Me.sqlConnect.Close()
            Throw New Exception("Se ha producido un error al realizar la ejecución de la consulta SQL en la base de datos", ex)
        End Try
    End Function

    ''' <summary>
    ''' Permite ejecutar un procedimiento almacenado
    ''' </summary>
    ''' <param name="NombreProcedimiento">
    ''' Nombre del procedimiento almacenado que se desea ejecutar
    ''' </param>
    ''' <param name="Parametros">
    ''' Lista de parámetros que se requieren para ejecutar el procedimiento almacenado
    ''' </param>
    ''' <returns></returns>
    Protected Function EjecutarSP(ByVal NombreProcedimiento As String, ByVal Parametros As List(Of SqlParameter)) As DataSet
        Try
            'variable del tipo SqlCommand para la ejecución del procedimiento almacenado
            Dim cmdSP As New SqlCommand With {
                .CommandType = CommandType.StoredProcedure,
                .CommandText = NombreProcedimiento,
                .Connection = Me.sqlConnect
            }

            'agrega los parámetros para la ejecución del procedimiento almacenado
            With cmdSP
                'agrega los parámetros de ejecución al procedimiento almacenado
                For Each sqlParametro As SqlParameter In Parametros
                    .Parameters.Add(Parametros)
                Next
            End With

            'instancia del objeto de base de datos que se va a utilizar para almacenar la información que se 
            'obtiene desde la base de datos
            Using dsDatos As New DataSet
                'abre la conexión con la base de datos
                Me.sqlConnect.Open()

                'objeto que permite realizar la consulta de la información con un objeto tipo reader
                Dim myReader As SqlDataReader = cmdSP.ExecuteReader()

                'recorre la información que se ha obtenido de la base de datos y la agrega al DataSet
                If myReader.HasRows Then
                    Do While myReader.Read

                    Loop
                End If

                'cierra el objeto utilizado para la lectura de información
                myReader.Close()

                'cierra la conexción con la base de datos
                Me.sqlConnect.Close()

                'retorna la información que se ha obtenido de la consulta a la base de datos
                Return dsDatos
            End Using

        Catch ex As Exception
            'valida que la conexión a la base de datos haya finalizado
            If Me.sqlConnect.State = ConnectionState.Open Then Me.sqlConnect.Close()
            Throw ex
        End Try
    End Function
End Class
