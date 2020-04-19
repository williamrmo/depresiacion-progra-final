<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Depresiacion/Depresiacion.master" CodeBehind="aprobarDepresiacion.aspx.vb" Inherits="FontEnd.aprobarDepresiacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Depresiacion" runat="server">
    <div class="jumbotron">
        <h2>Aprobar Depresiacion</h2>

        <%-- Tabla Activo --%>
        <div class="container">
            <form>

                <div class="row">
                    <div class="form-group">
                        <label for="listActivos">Codigo Activo</label>
                        <asp:DropDownList ID="listActivos" class="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnBuscarDepre" runat="server" Text="Buscar Depresiacion" CssClass="btn btn-primary float-right" Style="height: 36px" />
                </div>

            </form>

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

        <hr />
        <%-- Tabla con la Depresiacion --%>
        <asp:GridView ID="dgvDepre" runat="server" AutoGenerateColumns="False" CssClass="table " BackColor="White" BorderColor="Black" BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="Año" HeaderText="Año" />
                <asp:BoundField DataField="Año Depresiacion" HeaderText="Año Depresiacion" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Valor Historico" HeaderText="Valor Historico" />
                <asp:BoundField DataField="Depresicion Anual" HeaderText="Depresicion Anual" />
                <asp:BoundField DataField="Depresiacion Acumulada" HeaderText="Depresiacion Acumulada" />
                <asp:BoundField DataField="Valor Neto" HeaderText="Valor Neto" />
            </Columns>
        </asp:GridView>

        <br />

        <div class="gridx">
            <div class="btn-group" role="group" aria-label="Basic example">
                <asp:Button ID="btnAprobar" runat="server" Text="Aprobar Depresiacion" CssClass="btn btn-success float-right" Style="height: 36px" />

                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar Depresiacion" CssClass="btn btn-danger float-right" Style="height: 36px" />

            </div>

        </div>

         <%-- Tabla con la Depresiacion --%>
        <br />
        <div id="alert" runat="server" class="alert alert-danger" role="alert">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <%-- Exito --%>
        <div id="alertExito" runat="server" class="alert alert-success" role="alert">
            <asp:Label ID="lbExito" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
