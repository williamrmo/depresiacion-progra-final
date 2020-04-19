<%@ Page Title="Consultar por Activo" Language="vb" AutoEventWireup="true" MasterPageFile="~/views/Consultas/consultas.master" CodeBehind="consultaActivo.aspx.vb" Inherits="FontEnd.actico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Consultas" runat="server">
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
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar Depresiacion"  CssClass="btn btn-primary float-right" style="height: 36px" />
                    </div>

                </form>

            </div>
             <%-- Error --%>
            <div id="alert" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>

            <div id="alertExito" runat="server" class="alert alert-success" role="alert">
              <asp:Label ID="lbExito" runat="server" Text=""></asp:Label>
            </div>

            <hr />

            <asp:GridView ID="dgvDepre" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Año" HeaderText="Año" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo Activo" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="Valor Historico" HeaderText="Valor Historico" />
                    <asp:BoundField DataField="Depresicion Anual" HeaderText="Depresicion Anual" />
                    <asp:BoundField DataField="Depresiacion Acumulada" HeaderText="Depresiacion Acumulada" />
                    <asp:BoundField DataField="Año Depresiacion" HeaderText="Año Depresiacion" />
                    <asp:BoundField DataField="Valor Neto" HeaderText="Valor Neto" />
                    <asp:BoundField DataField="Fecha de Aprobacion" HeaderText="Fecha de Aprobacion" />
                    <asp:BoundField DataField="Empleado que Aprobo" HeaderText="Empleado que Aprobo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>


