Public Class Activos1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Not HttpContext.Current.User.Identity.IsAuthenticated Then
            '    FormsAuthentication.RedirectToLoginPage()
            'Else
            '    Dim strNombre As String = Session("User")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class