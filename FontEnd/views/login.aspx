<%@ Page Title="Login" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="login.aspx.vb" Inherits="FontEnd.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div class="gridx">
        <div class="jumbotron">
            <h2><%: Title %></h2>
            <form>
              <div class="form-group">
                <label for="username">Username</label>
                <input type="text"  name="username" id="username"  class="form-control" aria-describedby="emailHelp" runat="server" required="required">
                <%--<small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>--%>
              </div>
              <div class="form-group">
                <label for="password">Password</label>
                <input type="password" name="password" class="form-control" id="password" runat="server" required="required">
              </div>
                <%-- checkbox --%>
              <div class="form-group form-check">
                <asp:CheckBox ID="chkRecordar" CssClass="form-check-input" runat="server" AutoPostBack="false"/>
                <label class="form-check-label">Check me out</label>
              </div>
                <%-- boton --%>
                <asp:Button ID="submit" runat="server" Text="Acceptar"  CssClass="btn btn-primary" />
            </form>
            <%-- Error --%>
            <div id="alert" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
      </div>
    </div>

</asp:Content>
