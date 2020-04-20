<%@ Page Title="Modificar activo" Language="vb" AutoEventWireup="false" MasterPageFile="~/views/Activos/Activos.master" CodeBehind="modificarActivo.aspx.vb" Inherits="FontEnd.modificarActivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Activo" runat="server">


    <div class="gridx">
        <div class="jumbotron">
            <h2><%: Title %></h2>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <form>
                            <%-- Primera columna --%>
                            <div>
                                <div class="form-group">
                                    <label for="listActivos">Codigo Activo</label>
                                    <asp:DropDownList ID="listActivos" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:Button ID="btnConsultar" runat="server" Text="Buscar Activo" CssClass="btn btn-primary float-right" Style="height: 36px" />
                            </div>
                        </form>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <form>
                            <%-- Primera columna --%>
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label for="txtNombreActivo">Nombre del Activo</label>
                                    <input type="text" name="txtNombreActivo" id="txtNombreActivo" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                                </div>
                                <div class="form-group">
                                    <label for="txtVH">Valor Historico</label>
                                    <input type="number" name="txtVH" id="txtVH" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                                </div>
                            </div>

                            <%-- segunda columna --%>
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label for="txtVR">Valor Residual</label>
                                    <input type="number" name="txtVR" class="form-control" id="txtVR" runat="server" required="required">
                                    <small id="emailHelp" class="form-text text-muted">EJ: 25 (25%)</small>
                                </div>


                            </div>
                        </form>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar Activo" CssClass="btn btn-primary float-right" Style="height: 36px" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            

            <%-- Error --%>
            <br />
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
