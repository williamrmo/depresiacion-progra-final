Imports Entities
Imports BLL

Public Class actico
    Inherits System.Web.UI.Page

    Dim iActivoReglas As New ActivoReglas
    Dim iDepreReglas As New DepresiacionReglas

    Dim listaActivos As ArrayList = iActivoReglas.getCodigoActivoAprobados()

    Private Sub ItemsComboBoxID()
        Try
            Dim iActivo As New Activo

            Me.listActivos.Items.Clear()

            For Each iActivo In listaActivos
                Me.listActivos.Items.Add(iActivo.Id_Activo)
            Next
            Me.listActivos.SelectedIndex = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

            If Me.listActivos.Items.Count = 0 Then
                ItemsComboBoxID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            Dim strCodigoActivo As String = Me.listActivos.SelectedValue

            Dim dtActivo As DataTable = iDepreReglas.ObtenerDepreTB(strCodigoActivo)
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