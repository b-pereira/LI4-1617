<%@ Page Title="Mnham-Mnham" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mnham_mnham.Client.Preferences" %>


<asp:Content runat="server" ID="MainClientSidebar" ContentPlaceHolderID="SideBarContent">
    <li class="sidebar-brand">
        <a class="navbar-brand" runat="server" href="~/"><i class="fa fa-pull-left fa-2x fa-home">
        </i>Home</a>
    </li>
   <li>
        <a runat="server" href="~/Client/Preferences"><i class="fa fa-pull-left fa-2x fa-heart"></i>Preferences</a>
    </li>
    <%--<asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <li><a runat="server" href="~/Account/Register"><i class="fa fa-pull-left fa-2x fa-group"></i>Register</a></li>
            <li><a runat="server" href="~/Account/Login"><i class="fa fa-pull-left fa-2x fa-laptop"></i>Log in</a></li>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <li><a runat="server" href="~/Account/Manage" title="Manage your account"><i class="fa fa-pull-left fa-2x fa-cog">Hello, <%: Context.User.Identity.GetUserName()  %> !</a></li>
            <li>
                <i class="fa fa-pull-left fa-2x fa-power-off">
                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" /></li>
        </LoggedInTemplate>
    </asp:LoginView> --%>

</asp:Content>

<asp:Content runat="server" ID="MainContentClient" ContentPlaceHolderID="MainContent">
    <div class="page-header row">
    <div class="col-sm-3">
    <i class="fa fa-5x fa-heart" style="color: #ffffff"></i>
    </div>
    <div class="col-sm-6">
    <h2 class="fa fa-2x" style="color: #ffffff">Choose your search preferences</h2>
    </div>
    <div class="col-sm-3">
    </div>
    </div>
    <div class="jumbotron">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="checkbox palette-asbestos fa fa-3x">
            <asp:ListItem>Distância</asp:ListItem>
            <asp:ListItem>Avaliação Iguaria</asp:ListItem>
            <asp:ListItem>Avaliação Estabelecimento</asp:ListItem>
            <asp:ListItem>Popularidade Estabelecimento</asp:ListItem>
            <asp:ListItem>Popularidade Iguaria</asp:ListItem>
        </asp:CheckBoxList>

    </div>
</asp:Content>
