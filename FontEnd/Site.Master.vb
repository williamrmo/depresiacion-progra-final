Public Class SiteMaster
    Inherits MasterPage

    Public Shared blLogin As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If blLogin Then
                Me.lbPerfil.Text = frmLogin.iPerfil.Username
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class