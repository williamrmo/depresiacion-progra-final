<%@ Page Title="Eliminar activo" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Activos/Activos.master" CodeBehind="eliminarActivo.aspx.vb" Inherits="FontEnd.eliminarActivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Activo" runat="server">

    <div class="gridx">
        <div class="jumbotron">
            <h2><%: Title %></h2>

            
                    <div class="row">
                        <form>
                            <%-- Primera columna --%>
                            <div>
                                <div class="form-group">
                                    <label for="listActivos">Codigo Activo</label>
                                    <asp:DropDownList ID="listActivos" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:Button ID="btnConsultar" runat="server" Text="Consultar Depresiacion" CssClass="btn btn-primary float-right" Style="height: 36px" />
                            </div>
                        </form>
                        
                    </div>

            <%-- Error --%>
            <br />
            <div id="alert" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>

            <%-- Exito ---%>
            <div id="alertExito" runat="server" class="alert alert-success" role="alert">
                <asp:Label ID="lbExito" runat="server" Text=""></asp:Label>
            </div>

            <%-- Tabla Activo --%>
        <hr />
        <asp:GridView ID="dgvActivo" runat="server" AutoGenerateColumns="False" CssClass="table " BackColor="White" BorderColor="Black" BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo Activo" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Valor Historico" HeaderText="Valor Historico" />
                <asp:BoundField DataField="Porcentaje Residuo" HeaderText="Valor Residuo %" />
                <asp:BoundField DataField="Valor Residual" HeaderText="Valor Residuo" />
            </Columns>
        </asp:GridView>

            

        </div>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Activo" CssClass="btn btn-danger float-right" Style="height: 36px" />
    </div>

</asp:Content>
