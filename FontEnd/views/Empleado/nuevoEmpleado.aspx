<%@ Page Title="Nuevo Empleado" Language="vb" AutoEventWireup="true" MasterPageFile="~/views/privado.Master" CodeBehind="nuevoEmpleado.aspx.vb" Inherits="FontEnd.nuevoEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="gridx">
        <div class="jumbotron">
            <h2>Nuevo Empleado</h2>
            <div class="row">
                <form>
                    <%-- Primera columna --%>
                    <div class="col-md-6">

                        <div class="form-group">
                            <label for="txtIdEmpleado">Identificacion del empleado</label>
                            <input type="text" name="txtIdEmpleado" id="txtIdEmpleado" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="txtNombreEmpleado">Nombre del empleado</label>
                            <input type="text" name="txtNombreEmpleado" id="txtNombreEmpleado" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="dliRolEmpleado">Trabajo del Empleado</label>
                            <asp:DropDownList ID="dliRolEmpleado" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <%-- segunda columna --%>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="txtUsername">Username</label>
                            <input type="text" name="txtUsername" id="txtUsername" class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">Password</label>
                            <input type="password" name="txtPassword" class="form-control" id="txtPassword" runat="server" required="required">
                        </div>
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary float-right" />
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
        </div>

    </div>

</asp:Content>
