Imports Entities
Imports BLL

Public Class nuevoEmpleado
    Inherits System.Web.UI.Page

    Dim iEmpleadoReglas As New EmpleadoReglas
    Dim iRolesReglas As New RolesReglas
    Dim listaRoles As ArrayList = iRolesReglas.getRoles
    Dim strRol As String

    Private Sub ItemsComboBoxID()
        Try
            Dim rol As Roles = New Roles
            Me.dliRolEmpleado.Items.Clear()

            For Each rol In listaRoles
                Me.dliRolEmpleado.Items.Add(rol.Rol)
            Next
            Me.dliRolEmpleado.SelectedIndex = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            '    FormsAuthentication.RedirectToLoginPage()
            'Else
            Me.lblError.Text = String.Empty
                Me.lblError.Visible = False
                Me.alert.Visible = False

                If Me.dliRolEmpleado.Items.Count = 0 Then
                    ItemsComboBoxID()
                End If
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try

            If iEmpleadoReglas.validarAdmin(frmLogin.iPerfil) Then
                Dim idRol As Integer

                idRol = iRolesReglas.getIdRol(listaRoles, strRol)

                Dim iEmpleadosReglas As New EmpleadoReglas

                iEmpleadosReglas.NuevoEmpleado(CStr(Me.txtIdEmpleado.Value), idRol, CStr(Me.txtNombreEmpleado.Value), CStr(Me.txtUsername.Value), CStr(Me.txtPassword.Value))

            Else
                Me.lblError.Text = "El usuario no cuenta con los permisos necesarios"
                Me.lblError.Visible = True
                Me.alert.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub dliRolEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dliRolEmpleado.SelectedIndexChanged
        strRol = Me.dliRolEmpleado.SelectedItem.Value
    End Sub
End Class