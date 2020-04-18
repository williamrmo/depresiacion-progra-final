Imports Entities
Imports BLL

Public Class cunsultaAnno
    Inherits System.Web.UI.Page

    Dim iDepreReglas As New DepresiacionReglas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.lblError.Text = String.Empty
            Me.lblError.Visible = False
            Me.alert.Visible = False


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            Dim strAnno As String = CStr(Me.txtAnno.Value)

            Dim dtActivo As DataTable = iDepreReglas.ObtenerDepreAnnoTB(strAnno)
            Me.dgvDepre.DataSource = dtActivo
            Me.dgvDepre.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class