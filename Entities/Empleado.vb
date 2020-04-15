Public Class Empleado
    Inherits Roles
#Region "Variables"
    Private strId_Empleado As String = String.Empty
    Private strNombre As String = String.Empty
    Private strUsername As String = String.Empty
    Private strPassword As String = String.Empty
    Private blnUsuarioiValido As Boolean = False
    Private blnAdministrador As Boolean = False
#End Region

#Region "Properties"
    Public Property Id_Empleado() As String
        Get
            Return strId_Empleado
        End Get
        Set(value As String)
            strId_Empleado = value
        End Set
    End Property


    Public Property Nombre() As String
        Get
            Return strNombre
        End Get
        Set(value As String)
            strNombre = value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return strUsername
        End Get
        Set(value As String)
            strUsername = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(value As String)
            strPassword = value
        End Set
    End Property

    Public Property UsuarioValido() As Boolean
        Get
            Return blnUsuarioiValido
        End Get
        Set(ByVal value As Boolean)
            blnUsuarioiValido = value
        End Set
    End Property

    Public Property Administrador() As Boolean
        Get
            Return blnAdministrador
        End Get
        Set(ByVal value As Boolean)
            blnAdministrador = value
        End Set
    End Property
#End Region

End Class
