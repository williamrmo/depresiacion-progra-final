Imports Entities
Imports BLL

Public Class cunsultaAnno
    Inherits System.Web.UI.Page

    Dim iDepreReglas As New DepresiacionReglas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' Error
            Me.lblError.Text = String.Empty
            Me.lblError.Visible = False
            Me.alert.Visible = False
            ' Exito
            Me.lbExito.Text = String.Empty
            Me.lbExito.Visible = False
            Me.alertExito.Visible = False

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

            Me.lbExito.Text = "Consulta exitosa"
            Me.lbExito.Visible = True
            Me.alertExito.Visible = True

        Catch ex As Exception
            Me.lblError.Text = "Error al consultar"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub
End Class