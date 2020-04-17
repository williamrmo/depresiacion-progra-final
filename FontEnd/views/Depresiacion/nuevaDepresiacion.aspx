<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Depresiacion/Depresiacion.master" CodeBehind="nuevaDepresiacion.aspx.vb" Inherits="FontEnd.nuevaDepresiacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Depresiacion" runat="server">
    <div class="gridx">
        <div class="jumbotron">
            <h2><%-- Error --%></h2>

            <div class="row" >
                <form>
                    <%-- Primera columna --%>
                    <div>
                        <div class="form-group">
                            <label for="listActivos">Codigo Activo</label>
                            <asp:DropDownList ID="listActivos" class="form-control" runat="server"></asp:DropDownList>            
                        </div>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Activo"  CssClass="btn btn-primary float-right" style="height: 36px" />
                        <asp:Button ID="btnDepresiar" runat="server" Text="Depresiar Activo"  CssClass="btn btn-primary float-right" style="height: 36px" />
                    </div>

                </form>

            </div>
             <%-- Tabla con el Activo --%>
            <br/>
            <div id="alert" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <asp:GridView ID="dgvActivo" runat="server" AutoGenerateColumns="False">
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
            <br />
            <%-- Tabla con la Depresiacion --%>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>

    <br />

</asp:Content>
