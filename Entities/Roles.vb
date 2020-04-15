Public Class Roles

#Region "Variables"
    Private intId_Rol As Integer
    Private strRol_Nombre As String = String.Empty
#End Region

#Region "Properties"

    Public Property Id_Rol() As Integer
        Get
            Return intId_Rol
        End Get
        Set(value As Integer)
            intId_Rol = value
        End Set
    End Property

    Public Property Rol() As String
        Get
            Return strRol_Nombre
        End Get
        Set(value As String)
            strRol_Nombre = value
        End Set
    End Property
#End Region
End Class
