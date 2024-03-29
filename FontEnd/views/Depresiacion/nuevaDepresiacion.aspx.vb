﻿Imports Entities
Imports BLL

Public Class nuevaDepresiacion
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

            ' en caso de que NO tenga valores se ejecuta la funcion
            If Me.listActivos.Items.Count = 0 Then
                ItemsComboBoxID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            ' Almacena el valor del DropDownList
            Dim strCodigoActivo As String = Me.listActivos.SelectedValue

            ' Busca el Activo y lo almacena en una tabla
            Dim dtActivo As DataTable = iActivoReglas.ObtenerActivo(strCodigoActivo)

            ' Ejecuta el metodo CalularDepresiacion donde hace todos los calculos necesarios y lo almacena en un arraylist
            listaDepre = iDepreReglas.CalcularDpresiacion(strCodigoActivo)

            ' Carga lops datos del activo en pantalla
            Me.dgvActivo.DataSource = dtActivo
            Me.dgvActivo.DataBind()

            ' Almacena la depresiacion almacenada en el arraylis
            iDepreReglas.GuardarNuevaDepresiacion(listaDepre)

            Dim dtDepre As DataTable = iDepreReglas.ObtenerDepreNoAprobadaTB(strCodigoActivo)
            Me.dgvDepre.DataSource = dtDepre
            Me.dgvDepre.DataBind()

            ' Actuliza el DropDoenList
            ItemsComboBoxID()

            Me.lbExito.Text = "Depresiacion exitosa"
            Me.lbExito.Visible = True
            Me.alertExito.Visible = True

        Catch ex As Exception
            Me.lblError.Text = "Error al calcular la depresiacion"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub

End Class