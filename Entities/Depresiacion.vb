Public Class Depresiacion
    Inherits Activo

#Region "Variables"
    Private intId_Depresiacion As Integer
    Private douDepresiacion_Anual As Double
    Private douDepresiacion_Acumulada As Double
    Private douValor_Neto As Double
    Private dtmFecha_Aprobacion As Date
    Private strId_Empleado_Aprobacion As String = String.Empty
    Private intAnno As Integer
    Private intAnno_Depresiacion As Integer
#End Region

#Region "Properties"
    Public Property Id_Depresiacion() As Integer
        Get
            Return intId_Depresiacion
        End Get
        Set(value As Integer)
            intId_Depresiacion = value
        End Set
    End Property

    Public Property Depresiacion_Anual() As Double
        Get
            Return douDepresiacion_Anual
        End Get
        Set(value As Double)
            douDepresiacion_Anual = value
        End Set
    End Property

    Public Property Depresiacion_Acumulada() As Double
        Get
            Return douDepresiacion_Acumulada
        End Get
        Set(value As Double)
            douDepresiacion_Acumulada = value
        End Set
    End Property

    Public Property Valor_Neto() As Double
        Get
            Return douValor_Neto
        End Get
        Set(value As Double)
            douValor_Neto = value
        End Set
    End Property

    Public Property Fecha_Aprobacion() As Date
        Get
            Return dtmFecha_Aprobacion
        End Get
        Set(value As Date)
            dtmFecha_Aprobacion = value
        End Set
    End Property

    Public Property Id_Empleado_Aprobacion() As String
        Get
            Return strId_Empleado_Aprobacion
        End Get
        Set(value As String)
            strId_Empleado_Aprobacion = value
        End Set
    End Property

    Public Property Anno() As Integer
        Get
            Return intAnno
        End Get
        Set(value As Integer)
            intAnno = value
        End Set
    End Property

    Public Property Anno_Depresiacion() As Integer
        Get
            Return intAnno_Depresiacion
        End Get
        Set(value As Integer)
            intAnno_Depresiacion = value
        End Set
    End Property
#End Region
End Class
