Imports Entities
Imports BLL

Public Class nuevaDepresiacion
    Inherits System.Web.UI.Page


    Dim iActivoReglas As New ActivoReglas
    Dim iDepreReglas As New DepresiacionReglas

    Dim listaActivos As ArrayList = iActivoReglas.getCodigoActivo()
    Dim listaDepre As ArrayList = New ArrayList

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
            Me.lblError.Text = String.Empty
            Me.lblError.Visible = False
            Me.alert.Visible = False

            If Me.listActivos.Items.Count = 0 Then
                ItemsComboBoxID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            Dim strCodigoActivo As String = Me.listActivos.SelectedValue

            Dim dtActivo As DataTable = iActivoReglas.ObtenerActivo(strCodigoActivo)
            listaDepre = iDepreReglas.CalcularDpresiacion(strCodigoActivo)
            Me.dgvActivo.DataSource = dtActivo
            Me.dgvActivo.DataBind()
            iDepreReglas.GuardarNuevaDepresiacion(listaDepre)
            ItemsComboBoxID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class