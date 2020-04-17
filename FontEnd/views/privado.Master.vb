Public Class privado
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                FormsAuthentication.RedirectToLoginPage()
            Else
                Dim strNombre As String = Session("User").ToString
                Me.lbPerfil.Text = strNombre
            End If

        Catch ex As Exception
            Session("Error") = ex.Message
            Response.Redirect("#", False)
        End Try
    End Sub

    Protected Sub lbtnCerrarSesion_Click(sender As Object, e As EventArgs) Handles lbtnCerrarSesion.Click
        Try
            FormsAuthentication.SignOut()
        Catch ex As Exception
            Session("Error") = ex.Message
            Response.Redirect("#", False)
        End Try
    End Sub
End Class