Public Class Activo
    Inherits TipoActivo

#Region "Variables"
    Private intId_Activo As String = String.Empty
    Private strId_Empleado As String = String.Empty
    Private intTipo_Activo As Integer
    Private strNombre_Activo As String = String.Empty
    Private dtmFecha_Adquisicion As Date
    Private douValor_Historico As Double
    Private douValor_Residual_Porcent As Double
    Private douValor_Residual As Double
    Private blnAprobado As Boolean = False
#End Region

#Region "Properties"
    Public Property Id_Activo() As String
        Get
            Return intId_Activo
        End Get
        Set(value As String)
            intId_Activo = value
        End Set
    End Property

    Public Property Id_Empleado() As String
        Get
            Return strId_Empleado
        End Get
        Set(value As String)
            strId_Empleado = value
        End Set
    End Property

    Public Property Tipo_Activo() As Integer
        Get
            Return intTipo_Activo
        End Get
        Set(value As Integer)
            intTipo_Activo = value
        End Set
    End Property

    Public Property Nombre_Activo() As String
        Get
            Return strNombre_Activo
        End Get
        Set(value As String)
            strNombre_Activo = value
        End Set
    End Property

    Public Property Fecha_Adquisicion() As Date
        Get
            Return dtmFecha_Adquisicion
        End Get
        Set(value As Date)
            dtmFecha_Adquisicion = value
        End Set
    End Property

    Public Property Valor_Historico() As Double
        Get
            Return douValor_Historico
        End Get
        Set(value As Double)
            douValor_Historico = value
        End Set
    End Property

    Public Property Valor_Residual() As Double
        Get
            Return douValor_Residual
        End Get
        Set(value As Double)
            douValor_Residual = value
        End Set
    End Property

    Public Property Valor_Residual_Porcent() As Double
        Get
            Return douValor_Residual_Porcent
        End Get
        Set(value As Double)
            douValor_Residual_Porcent = value
        End Set
    End Property

    Public Property Aprobado() As Boolean
        Get
            Return blnAprobado
        End Get
        Set(value As Boolean)
            blnAprobado = value
        End Set
    End Property
#End Region
End Class
