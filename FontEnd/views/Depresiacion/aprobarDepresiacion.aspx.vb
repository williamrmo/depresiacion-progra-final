Imports Entities
Imports BLL

Public Class aprobarDepresiacion
    Inherits System.Web.UI.Page

    Dim iActivoReglas As New ActivoReglas
    Dim iDepreReglas As New DepresiacionReglas

    Dim listaActivos As ArrayList = iActivoReglas.getCodigoActivo()
    Dim listaDepre As ArrayList = New ArrayList

    ''' <summary>
    ''' Actruliza los datos del DropDownList
    ''' </summary>
    Private Sub ItemsComboBoxID()
        Try
            Dim iActivo As New Activo

            ' Limpia los valores anteriores
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

            Me.btnAprobar.Visible = False
            Me.btnAprobar.Enabled = False
            Me.btnRechazar.Visible = False
            Me.btnRechazar.Enabled = False

            ' en caso de que NO tenga valores se ejecuta la funcion
            If Me.listActivos.Items.Count = 0 Then
                ItemsComboBoxID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnBuscarDepre.Click
        Try
            Dim strRol As String = Session("Rol")
            If strRol.Equals("2") Then
                ' Almacena el valor del DropDownList
                Dim strCodigoActivo As String = Me.listActivos.SelectedValue

                ' Busca el Activo y lo almacena en una tabla
                Dim dtActivo As DataTable = iActivoReglas.ObtenerActivo(strCodigoActivo)

                ' Carga lops datos del activo en pantalla
                Me.dgvActivo.DataSource = dtActivo
                Me.dgvActivo.DataBind()

                Dim dtDepre As DataTable = iDepreReglas.ObtenerDepreNoAprobadaTB(strCodigoActivo)
                Me.dgvDepre.DataSource = dtDepre
                Me.dgvDepre.DataBind()

                Me.btnAprobar.Visible = True
                Me.btnAprobar.Enabled = True
                Me.btnRechazar.Visible = True
                Me.btnRechazar.Enabled = True
            Else
                Me.lblError.Text = "No cuenta con los permisos necesarios"
                Me.lblError.Visible = True
                Me.alert.Visible = True
            End If






        Catch ex As Exception
            Me.lblError.Text = "Error al calcular la depresiacion"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub

    Protected Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Try
            Dim idActivo As String = Me.listActivos.SelectedValue
            Dim daFecha As Date = TimeOfDay
            Dim IdEmpleado As String = Session("IdUsuario").ToString

            iDepreReglas.AprobarDepre(idActivo, daFecha, IdEmpleado)

            Me.lbExito.Text = "Aprobacion exitosa"
            Me.lbExito.Visible = True
            Me.alertExito.Visible = True
        Catch ex As Exception
            Me.lblError.Text = "Error al Aprobar la depresiacion"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub

    Protected Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Try
            Dim strRol As String = Session("Rol")
            If strRol.Equals("2") Then
                Dim idActivo As String = Me.listActivos.SelectedValue
                iDepreReglas.eliminarDepre(idActivo)
                Me.lbExito.Text = "Depreciacion rechazada con exito"
                Me.lbExito.Visible = True
                Me.alertExito.Visible = True
            Else
                Me.lblError.Text = "No cuenta con los permiso necesarios para ejecutar esta accion"
                Me.lblError.Visible = True
                Me.alert.Visible = True
            End If


        Catch ex As Exception
            Me.lblError.Text = "Error al rechazar la depresiacion"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub

End Class