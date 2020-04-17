Public Class SiteMaster
    Inherits MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class