Imports Entities
Imports BLL

Public Class frmLogin
    Inherits System.Web.UI.Page

    Public Shared iPerfil As Empleado

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Text = String.Empty
            Me.lblError.Visible = False
            Me.alert.Visible = False
        Catch ex As Exception
            Response.Redirect("~/Pages/frmError.aspx")
        End Try
    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click
        Try
            Dim strCodigoUser As String = Me.username.Value
            Dim strPass As String = Me.password.Value
            Dim blnRecordarme As Boolean = Me.chkRecordar.Checked

            ' Instancia de la clase usuario que permite validar ei el usuario y la contraseña
            ' concuerda con algun usuario ya registrado
            Dim iEmpleado As New Empleado With {
                .Username = strCodigoUser,
                .Password = strPass
            }

            ' Instancia del objeto empleado de la capa de negocios para validar que el usuario es correcto
            Dim iEmpleadoReglas As New EmpleadoReglas

            ' Valida si las credenciales brindads corresponden a un usuario valido
            iEmpleado = iEmpleadoReglas.validarUsuario(strCodigoUser, strPass)

            If iEmpleado.UsuarioValido Then
                FormsAuthentication.RedirectFromLoginPage(iEmpleado.Username, blnRecordarme)
                Session("User") = iEmpleado.Nombre
                Session("Rol") = iEmpleado.Id_Rol
                Session("IdUsuario") = iEmpleado.Id_Empleado

            Else
                Me.lblError.Text = "El usuario y/o la contraseña son invalidos"
                Me.lblError.Visible = True
                Me.alert.Visible = True
            End If

        Catch ex As Exception
            Response.Redirect("~/Pages/frmError.aspx")
        End Try
    End Sub

    Protected Sub chkRecordar_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class