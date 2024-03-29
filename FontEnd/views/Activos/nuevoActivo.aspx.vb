﻿Imports Entities
Imports BLL

Public Class nuevoActivo
    Inherits System.Web.UI.Page

    Dim iTipoActivosReglas As New TipoActivosReglas
    Dim listaTiposActivo As ArrayList = iTipoActivosReglas.getTipoActivo

    Private Sub ItemsComboBoxID()
        Try
            Dim tipoActivo As New TipoActivo

            Me.dliTipoActivo.Items.Clear()

            For Each tipoActivo In listaTiposActivo
                Me.dliTipoActivo.Items.Add(tipoActivo.Nombre_Tipo_Activo)
            Next
            Me.dliTipoActivo.SelectedIndex = 0

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

            If Me.dliTipoActivo.Items.Count = 0 Then
                ItemsComboBoxID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try

            Dim idEmpleado As String = Session("IdUsuario").ToString
            Dim idTipoActivo As String = iTipoActivosReglas.getIdTipoActivo(listaTiposActivo, Me.dliTipoActivo.SelectedValue)
            Dim ValorResidualPorcent As Double = CDbl(Me.txtVR.Value / 100)
            Dim ValorResidual As Double = CDbl(Me.txtVH.Value * ValorResidualPorcent)
            Dim strFecha As Date = Me.txtFecha.Value

            Dim iActivoReglas As New ActivoReglas

            iActivoReglas.NuevoActivo(CStr(Me.txtIdActivo.Value), idEmpleado, idTipoActivo, CStr(Me.txtNombreActivo.Value), strFecha, CDbl(Me.txtVH.Value), ValorResidualPorcent, ValorResidual)

            Me.lbExito.Text = "Activo registrado exitosa"
            Me.lbExito.Visible = True
            Me.alertExito.Visible = True
        Catch ex As Exception
            Me.lblError.Text = "Error al registrar el activo"
            Me.lblError.Visible = True
            Me.alert.Visible = True
        End Try
    End Sub

End Class