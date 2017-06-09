<%@ Page Title="Mnham-Mnham" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Mnham_mnham.Client.MainClient" %>


<asp:Content runat="server" ID="MainClientSidebar" ContentPlaceHolderID="SideBarContent">
    <li class="sidebar-brand">
        <a class="navbar-brand" runat="server" href="~/" onclick="Unnamed_LoggingOut"><i class="fa fa-pull-left fa-2x fa-home"></i>Sair</a>
    </li>
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <li><a runat="server" href="~/Client/Register"><i class="fa fa-pull-left fa-2x fa-group"></i>Registo</a></li>
            <li><a runat="server" href="~/Client/Login"><i class="fa fa-pull-left fa-2x fa-laptop"></i>Entrada</a></li>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <li><a runat="server" href="~/Client/History"><i class="fa fa-pull-left fa-2x fa-history"></i>Histórico</a></li>
    <li>
        <a runat="server" href="~/Client/Preferences"><i class="fa fa-pull-left fa-2x fa-heart"></i>Preferências</a>
    </li>
            <li><a runat="server" href="~/Client/Settings"><i class="fa fa-pull-left fa-2x fa-cog"></i>Configurações</a></li>

        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

<asp:Content runat="server" ID="MainContentClient" ContentPlaceHolderID="MainContent">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="700px" CssClass="form-control flat">Input your search...</asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-sm" />
        <asp:GridView ID="gvQuery" runat="server" CssClass="list-group jumbotron" 
                      AllowPaging="true" AutoGenerateColumns="false"
                      RowHeaderColumn="Name" PageSize="5">
            <Columns>
                <asp:BoundField DataField="Name" ItemStyle-CssClass="fa" ReadOnly="true" />
                <asp:BoundField DataField="Rating" ItemStyle-CssClass="fa" ReadOnly="true" />
                <asp:HyperLinkField Text="Ver Críticas" NavigateUrl="#ver" ItemStyle-CssClass="btn fa" />
                <asp:BoundField DataField="Horario" ItemStyle-CssClass="fa" ReadOnly="true" />
                <asp:BoundField DataField="Phone" ItemStyle-CssClass="fa" ReadOnly="true" />
                <asp:BoundField DataField="Price" ItemStyle-CssClass="fa" ReadOnly="true" />
                <asp:BoundField DataField="NameIg" ItemStyle-CssClass="fa" ReadOnly="true"/>
                <asp:BoundField DataField="RatingIg" ItemStyle-CssClass="fa" ReadOnly="true"/>
                <asp:HyperLinkField Text="Direções" NavigateURL="#map" ItemStyle-CssClass="btn fa"/>
                <asp:HyperLinkField Text="Avaliar" NavigateUrl="#avalia" ItemStyle-CssClass="btn fa"/>
            </Columns>
            <PagerTemplate>
            </PagerTemplate>
        </asp:GridView>

    </div>
</asp:Content>
