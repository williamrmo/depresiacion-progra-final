Public Class TipoActivo

#Region "Variables"
    Private intId_Tipo_Activo As Integer
    Private strNombre_Tipo_Activo As String = String.Empty
    Private intVida_Util As Integer
#End Region

#Region "Properties"
    Public Property ID_Tipo_Activo() As Integer
        Get
            Return intId_Tipo_Activo
        End Get
        Set(value As Integer)
            intId_Tipo_Activo = value
        End Set
    End Property

    Public Property Nombre_Tipo_Activo() As String
        Get
            Return strNombre_Tipo_Activo
        End Get
        Set(value As String)
            strNombre_Tipo_Activo = value
        End Set
    End Property

    Public Property Vida_Util() As Integer
        Get
            Return intVida_Util
        End Get
        Set(value As Integer)
            intVida_Util = value
        End Set
    End Property
#End Region
End Class
