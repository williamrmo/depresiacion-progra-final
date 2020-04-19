<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Depresiacion/Depresiacion.master" CodeBehind="nuevaDepresiacion.aspx.vb" Inherits="FontEnd.nuevaDepresiacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Depresiacion" runat="server">
    <div class="jumbotron">
        <h2>Calcular Depresiacion</h2>

        <%-- Formulario --%>
        <div class="container">
            <form>

                <div class="row">
                    <div class="form-group">
                        <label for="listActivos">Codigo Activo</label>
                        <asp:DropDownList ID="listActivos" class="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Depresiar Activo" CssClass="btn btn-primary float-right" Style="height: 36px" />
                </div>

            </form>

        </div>

        <%-- Error --%>
        <br />
        <div id="alert" runat="server" class="alert alert-danger" role="alert">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <%-- Exito --%>
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
    </div>

</asp:Content>
