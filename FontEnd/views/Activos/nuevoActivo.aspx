<%@ Page Title="Nuevo Activo" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Activos/Activos.master" CodeBehind="nuevoActivo.aspx.vb" Inherits="FontEnd.nuevoActivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Activo" runat="server">
    
    <div class="gridx">
        <div class="jumbotron">
            <h2><%: Title %></h2>

            <div class="row" >
                <form>
                    <%-- Primera columna --%>
                    <div class="col-md-6">

                        <div class="form-group">
                            <label for="txtIdActivo">Codigo del Activo</label>
                            <input type="text"  name="txtIdActivo" id="txtIdActivo"  class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="txtNombreActivo">Nombre del Activo</label>
                            <input type="text" name="txtNombreActivo" id="txtNombreActivo" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="dliTipoActivo">Tipo Activo</label>
                            <asp:DropDownList ID="dliTipoActivo" class="form-control" runat="server"></asp:DropDownList>            
                        </div>
                    </div>
          
                    <%-- segunda columna --%>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="txtFecha">Fecha de Adquisicion</label>
                            <input type="date"  name="txtFecha" id="txtFecha"  class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="txtVH">Valor Historico</label>
                            <input type="number"  name="txtVH" id="txtVH"  class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="txtVR">Valor Residual</label>
                            <input type="number" name="txtVR" class="form-control" id="txtVR" runat="server" required="required">
                            <small id="emailHelp" class="form-text text-muted">EJ: 25 (25%)</small>
                        </div>
                        
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Activo"  CssClass="btn btn-primary float-right" style="height: 36px" />
                    </div>
                </form>

               
            </div>
             <%-- Error --%>
            <br/>
            <div id="alert" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>

            <%-- Exito ---%>
            <div id="alertExito" runat="server" class="alert alert-success" role="alert">
              <asp:Label ID="lbExito" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
